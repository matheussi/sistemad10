using System;
using System.Web;
using System.Linq;
using System.Web.UI;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Collections.Generic;

using System.Data;
using System.Data.SqlClient;
using Entidade;
using LC.Framework.Phantom;

public partial class clientes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtCPF.Attributes.Add("onkeypress", "keepTextBoxFucused('" + txtCPF.ID + "', '" + txtTextBoxId.ClientID + "')");
        txtNome.Attributes.Add("onkeypress", "keepTextBoxFucused('" + txtNome.ID + "', '" + txtTextBoxId.ClientID + "')");
        txtFicha.Attributes.Add("onkeypress", "keepTextBoxFucused('" + txtFicha.ID + "', '" + txtTextBoxId.ClientID + "')");

        //txtCPF.Attributes.Add("onkeypress", "button_click(this,'" + cmdProcurar.ClientID + "', '" + txtCPF.ClientID + "', '" + txtTextBoxId.ClientID + "')");
        //txtNome.Attributes.Add("onkeypress", "button_click(this,'" + cmdProcurar.ClientID + "', '" + txtNome.ClientID + "', '" + txtTextBoxId.ClientID + "')");
        //txtFicha.Attributes.Add("onkeypress", "button_click(this,'" + cmdProcurar.ClientID + "', '" + txtFicha.ClientID + "', '" + txtTextBoxId.ClientID + "')");

        if (!IsPostBack)
        {
            this.carregarClientes();
        }
    }

    void carregarClientes()
    {
        #region comentado 

        //linha 245 clientes.asp
        //string sql = string.Concat(
        //    "SELECT top 100 A.ID AS ID,SENHA, A.NOME,dbo.formatarCPF(CPF) AS CPF,",
        //    " (select CAST(DAY(TC.DATA_USU) AS VARCHAR(2))+'/'+CAST(MONTH(TC.DATA_USU)AS VARCHAR(2))+'/'+CAST(YEAR(TC.DATA_USU)AS VARCHAR(4)) AS DT_FIM from CLI_TRATA_CONCLUIDO ",
        //    "TC (nolock) ,CLI_MOVDIARIO MV (nolock) ",
        //    "  WHERE TC.ID_MOV = MV.ID ",
        //    " AND MV.ID_CLIENTE = A.ID ) AS [DT_TRAT_CONCLUIDO] ",
        //    " FROM CLI_CLIENTES_CENTR A (nolock) WHERE ID_EMPRESA=", Request["EMPRESA"], " ",
        //    " ORDER BY A.ID DESC ");

        //using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn01"].ConnectionString))
        //{
        //    conn.Open();
        //    SqlDataAdapter adp = new SqlDataAdapter(sql, conn);
        //    DataTable dt = new DataTable();
        //    adp.Fill(dt);

        //    grid.DataSource = dt;
        //    grid.DataBind();
        //    adp.Dispose();
        //    conn.Close();
        //}
        #endregion

        string empresa = Request["EMPRESA"];
        if (string.IsNullOrEmpty(empresa)) empresa = "1";

        if (string.IsNullOrWhiteSpace(txtFicha.Text))
        {
            string nome = txtNome.Text;
            string cpf = txtCPF.Text.Replace(".", "").Replace("-", "");

            var clientes = Cliente.Carregar(nome, cpf, empresa);

            //if (string.IsNullOrEmpty(nome) && string.IsNullOrEmpty(cpf) && clientes != null)
            //    grid.DataSource = clientes.OrderBy(c => c.NOME).ToList();
            //else
            if (clientes != null)
                grid.DataSource = clientes.OrderBy(c => c.NOME).ToList();
            else
                grid.DataSource = null;
        }
        else
        {
            IList<Cliente> cli = Cliente.CarregarPorFicha(txtFicha.Text, empresa);
            List<Cliente> result = new List<Cliente>();
            List<Cliente> aux = new List<Cliente>();

            if (txtNome.Text.Trim() != "")
            {
                string[] arrnome = txtNome.Text.Trim().Split(' ');

                for (int i = 0; i < arrnome.Length; i++)
                {
                    aux = cli.Where(c => c.NOME.ToLower().Contains(arrnome[i].ToLower())).ToList();

                    foreach (var a in aux)
                    {
                        if (!resutTem(result, a)) result.Add(a);
                    }
                }

                //cli = cli.Where(c => c.NOME.ToLower().Contains(txtNome.Text.ToLower())).ToList();
            }

            if (txtCPF.Text.Trim() != "")
            {
                cli = cli.Where(c => c.CPF.ToLower().Contains(txtCPF.Text.ToLower())).ToList();
                if (cli != null && cli.Count > 0) result.AddRange(cli);
            }

            if (result.Count > 0)
                grid.DataSource = result;
            else
                grid.DataSource = cli;
        }

        grid.DataBind();
    }

    bool resutTem(List<Cliente> result, Cliente cli)
    {
        if (result == null || result.Count == 0) return false;

        foreach (Cliente _c in result)
        {
            if (Convert.ToString(_c.ID) == Convert.ToString(cli.ID)) return true;
        }

        return false;
    }

    protected void lnkNovo_Click(object sender, EventArgs e)
    {
        Response.Redirect(string.Concat("cliente.aspx?", Keys.EmpresaIDKey, "=", Request[Keys.EmpresaIDKey], "&", Keys.UsuarioIDKey, "=", Request[Keys.UsuarioIDKey]));
    }

    protected void cmdProcurar_Click(object sender, EventArgs e)
    {
        this.carregarClientes();

        if (txtTextBoxId.Value == "txtCPF")
        {
            Geral.JSScript(this, "focusOnTheEnd('" + txtCPF.ClientID + "');");
        }
        else if (txtTextBoxId.Value == "txtNome")
        {
            Geral.JSScript(this, "focusOnTheEnd('" + txtNome.ClientID + "');");
        }
        else if (txtTextBoxId.Value == "txtFicha")
        {
            Geral.JSScript(this, "focusOnTheEnd('" + txtFicha.ClientID + "');");
        }
    }

    protected void grid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ////Util.Geral.grid_AdicionaToolTip<LinkButton>(e, 2, 0, "Editar");
            ////Util.Geral.grid_AdicionaToolTip<LinkButton>(e, 3, 0, "Arquivo de log");

            //ConfigEmailAviso obj = e.Row.DataItem as ConfigEmailAviso;
            //if (obj != null && !obj.Ativo) e.Row.ForeColor = System.Drawing.Color.Red;

            //Geral.grid_RowDataBound_Confirmacao(sender, e, 3, "Deseja realmente excluir?");
        }
    }

    protected void grid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("editar"))
        {
            string id = Geral.ObterDataKeyValDoGrid<string>(grid, e, 0);
            Response.Redirect(string.Format("cliente.aspx?{0}={1}&{2}={3}&{4}={5}", Keys.IDKey, id, Keys.EmpresaIDKey, Request[Keys.EmpresaIDKey], Keys.UsuarioIDKey, Request[Keys.UsuarioIDKey]));
        }
        else if (e.CommandName.Equals("ficha"))
        {
            string id = Geral.ObterDataKeyValDoGrid<string>(grid, e, 0);
            Cliente cli = new Cliente();
            cli.ID = id;
            cli.Carregar();
            //if(!cli.Importado)
                Response.Redirect(string.Format("fichas.aspx?{0}={1}&{2}={3}&{4}={5}", Keys.ClienteIDKey, id, Keys.EmpresaIDKey, Request[Keys.EmpresaIDKey], Keys.UsuarioIDKey, Request[Keys.UsuarioIDKey]));
            //else
            //    Response.Redirect(string.Format("ficha.aspx?{0}={1}&{2}={3}&{4}={5}&{6}={7}", Keys.IDKeyOld, id, Keys.ClienteIDKey, cli.ID, Keys.EmpresaIDKey, Request[Keys.EmpresaIDKey], Keys.UsuarioIDKey, Request[Keys.UsuarioIDKey]));
        }
        else if (e.CommandName.Equals("Log"))
        {
        }
    }

    protected void grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grid.PageIndex = e.NewPageIndex;
        this.carregarClientes();
    }
}
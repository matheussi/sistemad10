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

public partial class fichas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if(!string.IsNullOrEmpty(Request[Keys.ClienteIDKey])) this.carregarFichasDoCliente();
        }
    }

    void carregarFichasDoCliente()
    {
        //string empresa = Request[Keys.EmpresaIDKey];
        //if (string.IsNullOrEmpty(empresa)) empresa = "1";

        string clienteId = Request[Keys.ClienteIDKey];

        Cliente cli = new Cliente();
        cli.ID = clienteId;
        cli.Carregar();

        var fichas = Ficha.CarregarPorCliente(Request[Keys.ClienteIDKey]);

        IList<Ficha> tratadas = new List<Ficha>();

        if (fichas != null)
        {
            //var temp = fichas.OrderByDescending(f => f.ID);

            foreach (Ficha _fi in fichas)
            {
                if (!existe(_fi.ID_CLIENTE_Old,_fi.TIPO_CLIENTE, tratadas)) //if (!existe(_fi.ID_TRATADO, tratadas))
                {
                    tratadas.Add(_fi);
                }
            }
        }


        grid.DataSource = tratadas;
        grid.DataBind();

        string aviso = "";
        if (fichas == null || fichas.Count == 0) aviso = " <i>(nenhuma)</i>";

        if(!string.IsNullOrEmpty(cli.NOME))
            litTitulo.Text = "FICHAS DE " + cli.NOME.ToUpper() + aviso;
    }

    bool existe(object  id, object tipo, IList<Ficha> fichas)
    {
        foreach (var fi in fichas)
        {
            if (Convert.ToString(fi.ID_CLIENTE_Old) == Convert.ToString(id) &&
                Convert.ToString(fi.TIPO_CLIENTE) == Convert.ToString(tipo)) 
                return true;
        }

        return false;
    }

    protected void cmdVoltar_click(object sender, EventArgs e)
    {
        Response.Redirect(string.Format("clientes.aspx?{0}={1}&{2}={3}", Keys.EmpresaIDKey, Request[Keys.EmpresaIDKey], Keys.UsuarioIDKey, Request[Keys.UsuarioIDKey]));
    }

    protected void lnkNovo_Click(object sender, EventArgs e)
    {
        //Response.Redirect("ficha.aspx?EMPRESA=" + Request["EMPRESA"]);
        Response.Redirect(string.Format("ficha.aspx?{0}={1}&{2}={3}&{4}={5}&novo=1", Keys.ClienteIDKey, Request[Keys.ClienteIDKey], Keys.EmpresaIDKey, Request[Keys.EmpresaIDKey], Keys.UsuarioIDKey, Request[Keys.UsuarioIDKey]));
    }

    protected void cmdProcurar_Click(object sender, EventArgs e)
    {
        //this.carregarFichas();
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
            string idCli = Geral.ObterDataKeyValDoGrid<string>(grid, e, 2);
            string idCliOld = Geral.ObterDataKeyValDoGrid<string>(grid, e, 3);

            if (id == "-1")
            {
                id = Geral.ObterDataKeyValDoGrid<string>(grid, e, 1); //ficha old
                idCli = Request[Keys.ClienteIDKey];

                //Response.Redirect(string.Format("ficha.aspx?{0}={1}&{2}={3}&{4}={5}&{6}={7}", Keys.IDKeyOld, id, Keys.ClienteIDKey, idCli, Keys.EmpresaIDKey, Request[Keys.EmpresaIDKey], Keys.UsuarioIDKey, Request[Keys.UsuarioIDKey]));
                Response.Redirect(string.Format("ficha.aspx?{0}={1}&{2}={3}&{4}={5}&{6}={7}&{8}={9}", Keys.IDKeyOld, id, Keys.ClienteIDKey, idCli, Keys.EmpresaIDKey, Request[Keys.EmpresaIDKey], Keys.UsuarioIDKey, Request[Keys.UsuarioIDKey], Keys.ClienteIDKeyOld, idCliOld));
                return;
            }

            Response.Redirect(string.Format("ficha.aspx?{0}={1}&{2}={3}&{4}={5}&{6}={7}&{8}={9}", Keys.IDKey, id, Keys.ClienteIDKey, idCli, Keys.EmpresaIDKey, Request[Keys.EmpresaIDKey], Keys.UsuarioIDKey, Request[Keys.UsuarioIDKey], Keys.ClienteIDKeyOld, idCliOld));
            //Geral.Alerta(this, string.Format("ficha.aspx?{0}={1}&{2}={3}&{4}={5}&{6}={7}", Keys.IDKey, id, Keys.ClienteIDKey, idCli, Keys.EmpresaIDKey, Request[Keys.EmpresaIDKey], Keys.UsuarioIDKey, Request[Keys.UsuarioIDKey]));
        }
        //else if (e.CommandName.Equals("ficha"))
        //{
        //    string id = Geral.ObterDataKeyValDoGrid<string>(grid, e, 0);
        //    Response.Redirect(string.Format("ficha.aspx?{0}={1}&{2}={3}", "ID", id, "EMPRESA", Request["EMPRESA"]));
        //}
        else if (e.CommandName.Equals("Log"))
        {
        }
    }

    protected void grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grid.PageIndex = e.NewPageIndex;
        this.carregarFichasDoCliente(); //this.carregarFichas();
    }
}
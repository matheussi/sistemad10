using Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cliente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtFone1.Attributes.Add("onkeyup", "mascara_cel9(this, event)");
        txtFone2.Attributes.Add("onkeyup", "mascara_cel9(this, event)");
        txtCelular.Attributes.Add("onkeyup", "mascara_cel9(this, event)");
        txtCPF.Attributes.Add("onkeypress", "mascara_CPF(this, event);");

        if (!IsPostBack)
        {
            this.carregarComoChegou();
            this.carregarPromotores();
            if (!string.IsNullOrEmpty(Request[Keys.IDKey])) this.carregar();
        }
    }

    void carregarComoChegou()
    {
        cboIndicacao.Items.Clear();
        cboIndicacao.DataValueField = "ID";
        cboIndicacao.DataTextField = "COMO_CHEGOU";

        cboIndicacao.DataSource = Helper.Instancia.CarregarTipoIndicacao();
        cboIndicacao.DataBind();

        cboIndicacao.Items.Insert(0, new ListItem("selecione", "0"));
        cboIndicacao.SelectedIndex = 0;
    }

    void carregarPromotores()
    {
        cboPromotor.Items.Clear();
        cboPromotor.DataValueField = "ID";
        cboPromotor.DataTextField = "NOME";

        cboPromotor.DataSource = Helper.Instancia.CarregarPromotores(Request[Keys.EmpresaIDKey]);
        cboPromotor.DataBind();

        cboPromotor.Items.Insert(0, new ListItem("selecione", "0"));
        cboPromotor.SelectedIndex = 0;
    }

    void carregar()
    {
        Cliente cli = new Cliente();
        cli.ID = Request[Keys.IDKey];
        cli.Carregar();

        txtBairro.Text = cli.BAIRRO;
        txtCelular.Text = cli.CELULAR;
        //cboCelularOperadora.SelectedValue = cli.ID_OPERADORA.ToString();
        txtCEP.Text = cli.CEP;
        txtCidade.Text = cli.CIDADE;
        txtComplemento.Text = cli.COMPLEMENTO;
        txtCPF.Text = cli.CPF;

        if(cli.NASCIMENTO != DateTime.MinValue)
            txtDataNascimento.Text = cli.NASCIMENTO.ToString("dd/MM/yyyy");
        
        if(!string.IsNullOrEmpty(cli.DDD_F))
            txtDDD1.Text = cli.DDD_F.Trim();
        txtDDDCelular.Text = cli.DDD_C;
        txtEmail.Text = cli.EMAIL;
        txtFone1.Text = cli.TEL_FIXO;
        txtLogradouro.Text = cli.ENDERECO;
        txtNome.Text = cli.NOME;
        txtNumero.Text = cli.NUMERO;
        txtUF.Text = cli.ESTADO;

        if (cli.ID_COMO != null)
            cboIndicacao.SelectedValue = Convert.ToString(cli.ID_COMO);
        else
            cboIndicacao.SelectedIndex = 0;

        chkStatus.Checked = cli.ATIVO;

        if (cli.ID_Promotor > 0)
        {
            pnlPromotor.Visible = true;

            if (cboPromotor.Items.FindByValue(cli.ID_Promotor.ToString()) != null)
                cboPromotor.SelectedValue = cli.ID_Promotor.ToString();
        }

        litDataCadastro.Text = cli.DT_CRIACAO.ToString("dd/MM/yyyy");
        if (cli.DT_ALTERACAO > DateTime.MinValue) litDataCadastroAlteracao.Text = cli.DT_ALTERACAO.ToString("dd/MM/yyyy");
    }

    protected void cmdBuscaEndereco_Click(object sender, EventArgs e)
    {

    }

    protected void cmdVoltar_click(object sender, EventArgs e)
    {
        //Response.Redirect("clientes.aspx?" + Keys.EmpresaIDKey + "=" + Request[Keys.EmpresaIDKey]);
        Response.Redirect(string.Format("clientes.aspx?{0}={1}&{2}={3}", Keys.EmpresaIDKey, Request[Keys.EmpresaIDKey], Keys.UsuarioIDKey, Request[Keys.UsuarioIDKey]));
    }

    protected void cmdSalvar_click(object sender, EventArgs e)
    {
        if (txtNome.Text.Trim() == "")
        {
            Geral.Alerta(this, "Informe por favor o nome.");
            return;
        }

        bool cpfOk = Cliente.ValidaCpf(txtCPF.Text);

        if (!cpfOk)
        {
            Geral.Alerta(this, "CPF inválido.");
            return;
        }

        bool resultado = Cliente.ChecaCpfEmUso(Request[Keys.IDKey], txtCPF.Text);
        if (!resultado)
        {
            Geral.Alerta(this, "CPF já cadastrado.");
            return;
        }

        if (txtEmail.Text.Trim().Length <= 6 && txtFone1.Text.Trim().Length < 7 && txtCelular.Text.Length < 7)
        {
            Geral.Alerta(this, "Deve ser informado um meio de contato: Telefone fixo, celular ou e-mail.");
            return;
        }

        if (pnlPromotor.Visible)
        {
            if (cboPromotor.SelectedIndex <= 0)
            {
                Geral.Alerta(this, "Deve ser informado um promotor.");
                return;
            }
        }

        bool clienteNovo = true;

        Cliente cli = new Cliente();
        cli.DT_CRIACAO = DateTime.Now;

        if (!string.IsNullOrEmpty(Request[Keys.IDKey]))
        {
            cli.ID = Request[Keys.IDKey];
            cli.Carregar();
            cli.DT_ALTERACAO = DateTime.Now;
            if (cli.DT_CRIACAO == DateTime.MinValue) cli.DT_CRIACAO = DateTime.Now;
            clienteNovo = false;
        }

        if (pnlPromotor.Visible)
            cli.ID_Promotor = CTipos.CToInt(cboPromotor.SelectedValue);
        else
            cli.ID_Promotor = 0;

        cli.BAIRRO = txtBairro.Text;
        cli.CELULAR = txtCelular.Text;
        //cli.ID_OPERADORA = CTipos.CToInt(cboCelularOperadora.SelectedValue);
        cli.CEP = txtCEP.Text;
        cli.CIDADE = txtCidade.Text;
        cli.COMPLEMENTO = txtComplemento.Text;
        cli.CPF = txtCPF.Text.Replace(".", "").Replace("-", "");
        cli.NASCIMENTO = CTipos.CStringToDateTime(txtDataNascimento.Text);
        cli.DDD_F = txtDDD1.Text;
        cli.DDD_C = txtDDDCelular.Text;
        cli.EMAIL = txtEmail.Text;
        cli.TEL_FIXO = txtFone1.Text;
        cli.ENDERECO = txtLogradouro.Text;
        cli.NOME = txtNome.Text;
        cli.NUMERO = txtNumero.Text;
        cli.ESTADO = txtUF.Text;

        if (cboIndicacao.SelectedIndex > 0)
            cli.ID_COMO = CTipos.CToInt(cboIndicacao.SelectedValue);
        else
            cli.ID_COMO = null;

        cli.ATIVO = chkStatus.Checked;
        cli.ID_EMPRESA = CTipos.CToInt(Request[Keys.EmpresaIDKey]);

        cli.Salvar();

        //Response.Redirect("clientes.aspx?" + Keys.EmpresaIDKey + "=" + Request[Keys.EmpresaIDKey]);

        if(!clienteNovo)
            Response.Redirect(string.Format("clientes.aspx?{0}={1}&{2}={3}", Keys.EmpresaIDKey, Request[Keys.EmpresaIDKey], Keys.UsuarioIDKey, Request[Keys.UsuarioIDKey]));
        else
            Response.Redirect(string.Format("ficha.aspx?{0}=1&{1}={2}&{3}={4}&{5}={6}", Keys.NovoKey, Keys.EmpresaIDKey, Request[Keys.EmpresaIDKey], Keys.UsuarioIDKey, Request[Keys.UsuarioIDKey], Keys.ClienteIDKey, cli.ID));
          //Response.Redirect(string.Format("fichas.aspx?{0}={1}&{2}={3}&{4}={5}", Keys.ClienteIDKey, id, Keys.EmpresaIDKey, Request[Keys.EmpresaIDKey], Keys.UsuarioIDKey, Request[Keys.UsuarioIDKey]));
    }
    protected void cboIndicacao_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cboIndicacao.SelectedItem.Text.ToUpper().IndexOf("PROMOTOR") > -1)
        {
            pnlPromotor.Visible = true;
        }
        else
        {
            pnlPromotor.Visible = false;
        }
    }
}
using System;
using System.Web;
using System.Linq;
using System.Web.UI;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Collections.Generic;

using Entidade;
using System.Data;
using System.Data.SqlClient;

public partial class ficha : System.Web.UI.Page
{
    IList<FichaPagto> Pagtos
    {
        get { return ViewState["_pagtos"] as List<FichaPagto>; }
        set { ViewState["_pagtos"] = value; }
    }

    string IdTipoPagtoSel
    {
        get { return ViewState["_tipo_pag_id_sel"] as string; }
        set { ViewState["_tipo_pag_id_sel"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.Write("<hr>");
        //cmdAdicionarTipoPagto.Attributes.Add("onclick", "window.parent.resizeIframe2();"); //resizeIframe2();
        txtValorTotal.Attributes.Add("onkeyup", "mascara('" + txtValorTotal.ClientID + "')");
        txtTotalOrcado.Attributes.Add("onkeyup", "mascara('" + txtTotalOrcado.ClientID + "')");
        txtValorTipoPagto.Attributes.Add("onkeyup", "mascara('" + txtValorTipoPagto.ClientID + "')");
        txtSaldoDevedor.Attributes.Add("onkeyup", "mascara('" + txtSaldoDevedor.ClientID + "')");
        txtCPFPagador.Attributes.Add("onkeypress", "filtro_SoNumeros(event);mascara_CPF(this, event);");

        if (!IsPostBack)
        {
            txtNovoData.Text = DateTime.Now.ToString("dd/MM/yyyy");

            Usuario u = new Usuario();
            u.ID = Request[Keys.UsuarioIDKey];
            u.Carregar();
            if (u.Admin > 0)
            {
                txtNovoData.ReadOnly = false;
                //txtHistPagtoData.ReadOnly = false;
            }
            else
            {
                txtNovoData.ReadOnly = true;
                //txtHistPagtoData.ReadOnly = false;
            }

            txtHistPagtoData.Text = DateTime.Now.ToString("dd/MM/yyyy");

            this.CarregarTipos();
            this.CarregarDentistas();
            this.CarregarFormasPagto();
            this.CarregarEspecialidades();

            if (!string.IsNullOrEmpty(Request[Keys.IDKeyOld]))
            {
                this.carregarFicha_Old();
            }
            else if (!string.IsNullOrEmpty(Request[Keys.IDKey])) 
            {
                this.carregarCliente();
                this.carregarFicha();
            }
            else if (!string.IsNullOrEmpty(Request[Keys.ClienteIDKey]))
            {
                this.carregarCliente();
                //cboEspecialidade.SelectedValue = "1";
                //cboEspecialidade.Enabled = false;

                if (!string.IsNullOrEmpty(Request["novo"]) && Request["novo"] == "1")
                    chkNovaFichaClinica.Visible = true;
                else
                    chkNovaFichaClinica.Visible = false;
            }

            this.setupNovo();
        }

        this.registraEventosCamposValor();
    }

    void setupNovo()
    {
        if (string.IsNullOrEmpty(Request[Keys.NovoKey]) || Convert.ToString(Request[Keys.NovoKey]) != "1") return;

        cboTipo.SelectedIndex = 3; //4
    }

    void CarregarDentistas()
    {
        cboDentista.Items.Clear();
        cboDentista.Items.Add(new ListItem("selecione", "0"));

        DataTable dt = Entidade.Helper.Instancia.CarregarDentistas(Request[Keys.EmpresaIDKey]);

        if (dt != null && dt.Rows != null)
        {
            foreach (DataRow row in dt.Rows)
            {
                cboDentista.Items.Add(new ListItem
                (
                    CTipos.CToString(row["NOME"]),
                    CTipos.CToString(row["ID"]))
                );
            }
        }
    }

    void CarregarEspecialidades()
    {
        cboEspecialidade.Items.Clear();
        cboEspecialidade.Items.Add(new ListItem("selecione", "0"));

        DataTable dt = Entidade.Helper.Instancia.CarregarEspecialidades();

        foreach (DataRow row in dt.Rows)
        {
            cboEspecialidade.Items.Add(new ListItem
            (
                CTipos.CToString(row["NOME"]),
                CTipos.CToString(row["ID"]))
            );
        }
    }

    void CarregarTipos()
    {
        cboTipo.Items.Clear();
        chklTipo.Items.Clear();

        cboTipo.Items.Add(new ListItem("selecione", "0"));

        DataTable dt = Entidade.Helper.Instancia.CarregarTipos();

        foreach (DataRow row in dt.Rows)
        {
            chklTipo.Items.Add(new ListItem
            (
                CTipos.CToString(row["NOME"]),
                CTipos.CToString(row["ID"]))
            );

            cboTipo.Items.Add((new ListItem(CTipos.CToString(row["NOME"]), CTipos.CToString(row["ID"]))));
        }
    }

    void CarregarFormasPagto()
    {
        //chklPagamento.Items.Clear();

        DataTable dt = Entidade.Helper.Instancia.CarregarFormasPagamento();
        dlFormaPagto.DataSource = dt;
        dlFormaPagto.DataBind();

        cboTipoPagto.Items.Clear();
        foreach (DataRow row in dt.Rows)
        {
            cboTipoPagto.Items.Add(new ListItem
            (
                CTipos.CToString(row["NOME"]),
                CTipos.CToString(row["ID"]))
            );
        }

        //foreach (DataRow row in dt.Rows)
        //{
        //    chklPagamento.Items.Add(new ListItem
        //    (
        //        CTipos.CToString(row["NOME"]),
        //        CTipos.CToString(row["ID"]))
        //    );
        //}
    }

    void carregarCliente()
    {
        Cliente cli = new Cliente();
        cli.ID = Request[Keys.ClienteIDKey];
        cli.Carregar();

        //if (!string.IsNullOrEmpty(cli.CELULAR))
        //{
        //    if (!string.IsNullOrEmpty(cli.DDD_C))
        //        lblCel.Text = string.Concat("(", cli.DDD_C, ") ", cli.CELULAR);
        //    else
        //        lblCel.Text = cli.CELULAR;
        //}
        //else
        //    lblCel.Text = "";

        if (!string.IsNullOrEmpty(cli.EMAIL))
            litMail.Text = cli.EMAIL;
        else
            litMail.Text = "";

        //lblEndereco.Text = cli.ENDERECO;
        //if (!string.IsNullOrEmpty(cli.NUMERO)) { lblEndereco.Text += ", " + cli.NUMERO; }

        //lblBairro.Text = cli.BAIRRO;
        //lblCidade.Text = cli.CIDADE;

        //if (!string.IsNullOrEmpty(cli.ESTADO)) lblCidade.Text += " - " + cli.ESTADO;
        
        //lblCEP.Text = cli.CEP;

        lblNome.Text = cli.NOME;

        lblCPF.Text = cli.CPF;

        if (cli.NASCIMENTO != DateTime.MinValue)
            lblDataNascimento.Text = cli.NASCIMENTO.ToString("dd/MM/yyyy");
        else
            lblDataNascimento.Text = "";


        if (!string.IsNullOrEmpty(cli.TEL_FIXO))
        {
            if (!string.IsNullOrEmpty(cli.DDD_F))
                lblTelefone.Text = string.Concat("(", cli.DDD_F, ") ", cli.TEL_FIXO);
            else
                lblTelefone.Text = cli.TEL_FIXO;
        }
        else
            lblTelefone.Text = "";

        if (!string.IsNullOrEmpty(cli.CELULAR))
        {
            if (!string.IsNullOrEmpty(cli.DDD_C))
            {
                if (string.IsNullOrEmpty(lblTelefone.Text))
                    lblTelefone.Text = string.Concat("(", cli.DDD_C, ") ", cli.CELULAR);
                else
                    lblTelefone.Text += string.Concat(" - (", cli.DDD_C, ") ", cli.CELULAR);
            }
            else
            {
                if (string.IsNullOrEmpty(lblTelefone.Text))
                    lblTelefone.Text = cli.CELULAR;
                else
                    lblTelefone.Text += " - " + cli.CELULAR;
            }
        }

        //Response.Write(cli.ID);
    }

    void carregarFicha()
    {
        Ficha nova = new Ficha();
        nova.ID = Request[Keys.IDKey];
        nova.Carregar();

        lblNumero.Text = CTipos.CToString(nova.ID_CLIENTE_Old); //CTipos.CToString(nova.ID_Old);

        FichaAntiga ficha = new FichaAntiga();

        if (nova.ID_Old == null)
        {
            ficha.DATA = nova.DATA;
            ficha.TIPO_CLIENTE = nova.TIPO_CLIENTE;
            ficha.ID_DENTISTA = nova.ID_DENTISTA;
            ficha.TOTAL_ORCADO = nova.TOTAL_ORCADO;
            ficha.TOTAL = nova.TOTAL;
            ficha.CPF_PAGADOR = nova.CPF_PAGADOR;
        }
        else
        {
            ficha.ID = nova.ID_Old;
            ficha.Carregar();
        }

        txtNovoData.Text = ficha.DATA.ToString("dd/MM/yyyy");
        cboEspecialidade.SelectedValue = CTipos.CToString(ficha.TIPO_CLIENTE);
        cboDentista.SelectedValue = CTipos.CToString(ficha.ID_DENTISTA);
        txtTotalOrcado.Text = ficha.TOTAL_ORCADO.ToString("N2");
        txtValorTotal.Text = ficha.TOTAL.ToString("N2");
        txtObs.Text = nova.OBS;
        txtCPFPagador.Text = ficha.CPF_PAGADOR;

        if (ficha.ID != null)
        {
            //tipo e forma pagto
            IList<FichaTipo> tipos = Ficha.CarregarTipoPorIdOld(ficha.ID);
            if (tipos != null && tipos.Count > 0) cboTipo.SelectedValue = CTipos.CToString(tipos[0].CODIGO);

            var pagtos = FichaPagto.Carregar(
                Convert.ToInt32(ficha.ID_CLIENTE), Convert.ToInt32(ficha.TIPO_CLIENTE));
            this.Pagtos = pagtos;
            gridTipoPagto.DataSource = pagtos;
            gridTipoPagto.DataBind();
        }

        this.calculaTotal();

        //this.carregarFichasPagto(ficha.ID, ficha.DATA);
        ////IList<FichaPagto> pagtos = Ficha.CarregarPagtoPorIdOld(ficha.ID_Old);
        ////this.Pagtos = pagtos;
        ////if (pagtos != null)
        ////{
        ////    gridTipoPagto.DataSource = pagtos;
        ////    gridTipoPagto.DataBind();
        ////    //string pgtoId = "";
        ////    //for (int i = 0; i < dlFormaPagto.Items.Count; i++)
        ////    //{
        ////    //    pgtoId = ((TextBox)dlFormaPagto.Items[i].FindControl("txtID")).Text;

        ////    //    foreach (var pgto in pagtos)
        ////    //    {
        ////    //        if (pgtoId == CTipos.CToString(pgto.ID_FORMA))
        ////    //        {
        ////    //            ((TextBox)dlFormaPagto.Items[i].FindControl("txtValor")).Text = pgto.VALOR.ToString("N2");
        ////    //            break;
        ////    //        }
        ////    //    }
        ////    //}
        ////}
    }

    /// <summary>
    /// Carrega tb o cliente old
    /// </summary>
    void carregarFicha_Old()
    {
        cboEspecialidade.Enabled = false;

        FichaAntiga fichaAntiga = new FichaAntiga();
        fichaAntiga.ID = Request[Keys.IDKeyOld];
        fichaAntiga.Carregar();

        var pagtos = FichaPagto.Carregar(
            Convert.ToInt32(fichaAntiga.ID_CLIENTE), Convert.ToInt32(fichaAntiga.TIPO_CLIENTE));
        this.Pagtos = pagtos;

        Cliente cli = new Cliente();
        cli.ID = Request[Keys.ClienteIDKey];
        cli.Carregar();

        if (pagtos != null)
        {
            this.calculaTotal();

            foreach (var p in pagtos)
            {
                if (p.DATA == DateTime.MinValue) p.DATA = p.FICHA_DATA_USUARIO;
                if (p.DATA == DateTime.MinValue) p.DATA = DateTime.Now;
            }

            gridTipoPagto.DataSource = pagtos;
            gridTipoPagto.DataBind();
        }


        //FichaAntiga ficha = new FichaAntiga();
        //ficha.ID = Request[Keys.IDKeyOld];
        //ficha.Carregar();

        var fichaItens = FichaAntiga.Carregar(//cli.IDImportado, cli.TipoImportado);
            Convert.ToInt32(fichaAntiga.ID_CLIENTE), Convert.ToInt32(fichaAntiga.TIPO_CLIENTE));

        if (fichaItens != null && fichaItens.Count > 0)
        {
            FichaAntiga ficha = fichaItens[fichaItens.Count - 1];

            IList<FichaTipo> tipos = Ficha.CarregarTipoPorIdOld(ficha.ID);
            if (tipos != null && tipos.Count > 0) cboTipo.SelectedValue = CTipos.CToString(tipos[0].CODIGO);

            txtTotalOrcado.Text = ficha.TOTAL_ORCADO.ToString("N2");

            lblNumero.Text = Convert.ToString(ficha.ID_CLIENTE); //cli.IDImportado.ToString(); //CTipos.CToString(ficha.ID);

            txtNovoData.Text = ficha.DATA_USUARIO.ToString("dd/MM/yyyy");
            cboEspecialidade.SelectedValue = CTipos.CToString(ficha.TIPO_CLIENTE);
            cboDentista.SelectedValue = CTipos.CToString(ficha.ID_DENTISTA);

            txtCPFPagador.Text = ficha.CPF_PAGADOR;

            if (cboDentista.SelectedIndex == 0)
            {
                Usuario u = new Usuario();
                u.ID = ficha.ID_DENTISTA;
                try
                {
                    u.Carregar();
                    cboDentista.Items.Add(new ListItem(u.Nome, Convert.ToString(u.ID)));
                    cboDentista.SelectedValue = Convert.ToString(ficha.ID_DENTISTA);
                }
                catch { }
            }

            //txtTotalOrcado.Text = ficha.TOTAL_ORCADO.ToString("N2");
            //txtValorTotal.Text = ficha.TOTAL.ToString("N2");
        }

        #region comentado 
        //txtObs.Text = ficha.OBS;

        ////tipo e forma pagto
        //IList<FichaTipo> tipos = Ficha.CarregarTipoPorIdOld(ficha.ID);
        //if (tipos != null && tipos.Count > 0) cboTipo.SelectedValue = CTipos.CToString(tipos[0].CODIGO);

        //this.carregarFichasPagto(ficha.ID, ficha.DATA);

        //IList<FichaPagto> pagtos = Ficha.CarregarPagtoPorIdOld(ficha.ID);
        //this.Pagtos = pagtos;
        //if (pagtos != null)
        //{
        //    gridTipoPagto.DataSource = pagtos;
        //    gridTipoPagto.DataBind();

        //    //string pgtoId = "";
        //    //for (int i = 0; i < dlFormaPagto.Items.Count; i++)
        //    //{
        //    //    pgtoId = ((TextBox)dlFormaPagto.Items[i].FindControl("txtID")).Text;

        //    //    foreach (var pgto in pagtos)
        //    //    {
        //    //        if (pgtoId == CTipos.CToString(pgto.ID_FORMA))
        //    //        {
        //    //            ((TextBox)dlFormaPagto.Items[i].FindControl("txtValor")).Text = pgto.VALOR.ToString("N2");
        //    //            break;
        //    //        }
        //    //    }
        //    //}
        //}

        ////carrega cliente
        //IClienteAntigo cli = null;
        //switch (Convert.ToString(ficha.TIPO_CLIENTE))
        //{
        //    #region case 

        //    case "1":
        //    {
        //        cli = new Cliente1(ficha.ID_CLIENTE);
        //        break;
        //    }
        //    case "2":
        //    {
        //        cli = new Cliente2(ficha.ID_CLIENTE);
        //        break;
        //    }
        //    case "3":
        //    {
        //        cli = new Cliente3(ficha.ID_CLIENTE);
        //        break;
        //    }
        //    case "4":
        //    {
        //        cli = new Cliente4(ficha.ID_CLIENTE);
        //        break;
        //    }
        //    case "5":
        //    {
        //        cli = new Cliente5(ficha.ID_CLIENTE);
        //        break;
        //    }
        //    #endregion
        //}

        //cli.Carregar();
        #endregion

        if (!string.IsNullOrEmpty(cli.EMAIL))
            litMail.Text = cli.EMAIL;
        else
            litMail.Text = "";

        lblNome.Text = cli.NOME;
        lblCPF.Text = cli.CPF;

        if (cli.NASCIMENTO != DateTime.MinValue)
            lblDataNascimento.Text = cli.NASCIMENTO.ToString("dd/MM/yyyy");
        else
            lblDataNascimento.Text = "";

        if (!string.IsNullOrEmpty(cli.TEL_FIXO))
        {
            if (!string.IsNullOrEmpty(cli.DDD_F))
                lblTelefone.Text = string.Concat("(", cli.DDD_F, ") ", cli.TEL_FIXO);
            else
                lblTelefone.Text = cli.TEL_FIXO;
        }
        else
            lblTelefone.Text = "";

        if (!string.IsNullOrEmpty(cli.CELULAR))
        {
            if (!string.IsNullOrEmpty(cli.DDD_C))
            {
                if (string.IsNullOrEmpty(lblTelefone.Text))
                    lblTelefone.Text = string.Concat("(", cli.DDD_C, ") ", cli.CELULAR);
                else
                    lblTelefone.Text += string.Concat(" - (", cli.DDD_C, ") ", cli.CELULAR);
            }
            else
            {
                if (string.IsNullOrEmpty(lblTelefone.Text))
                    lblTelefone.Text = cli.CELULAR;
                else
                    lblTelefone.Text += " - " + cli.CELULAR;
            }
        }

        calculaTotal();
    }
    void carregarFicha_Old_BKP()
    {
        cboEspecialidade.Enabled = false;

        Cliente cli = new Cliente();
        cli.ID = Request[Keys.IDKeyOld];
        cli.Carregar();

        var pagtos = FichaPagto.Carregar(cli.IDImportado, cli.TipoImportado);
        this.Pagtos = pagtos;

        if (pagtos != null)
        {
            this.calculaTotal();

            foreach (var p in pagtos)
            {
                if (p.DATA == DateTime.MinValue) p.DATA = p.FICHA_DATA_USUARIO;
                if (p.DATA == DateTime.MinValue) p.DATA = DateTime.Now;
            }

            gridTipoPagto.DataSource = pagtos;
            gridTipoPagto.DataBind();
        }


        //FichaAntiga ficha = new FichaAntiga();
        //ficha.ID = Request[Keys.IDKeyOld];
        //ficha.Carregar();

        var fichaItens = FichaAntiga.Carregar(cli.IDImportado, cli.TipoImportado);

        if (fichaItens != null && fichaItens.Count > 0)
        {
            FichaAntiga ficha = fichaItens[fichaItens.Count - 1];

            lblNumero.Text = cli.IDImportado.ToString(); //CTipos.CToString(ficha.ID);

            txtNovoData.Text = ficha.DATA_USUARIO.ToString("dd/MM/yyyy");
            cboEspecialidade.SelectedValue = CTipos.CToString(ficha.TIPO_CLIENTE);
            cboDentista.SelectedValue = CTipos.CToString(ficha.ID_DENTISTA);

            txtCPFPagador.Text = ficha.CPF_PAGADOR;

            if (cboDentista.SelectedIndex == 0)
            {
                Usuario u = new Usuario();
                u.ID = ficha.ID_DENTISTA;
                try
                {
                    u.Carregar();
                    cboDentista.Items.Add(new ListItem(u.Nome, Convert.ToString(u.ID)));
                    cboDentista.SelectedValue = Convert.ToString(ficha.ID_DENTISTA);
                }
                catch { }
            }

            //txtTotalOrcado.Text = ficha.TOTAL_ORCADO.ToString("N2");
            //txtValorTotal.Text = ficha.TOTAL.ToString("N2");
        }

        #region comentado
        //txtObs.Text = ficha.OBS;

        ////tipo e forma pagto
        //IList<FichaTipo> tipos = Ficha.CarregarTipoPorIdOld(ficha.ID);
        //if (tipos != null && tipos.Count > 0) cboTipo.SelectedValue = CTipos.CToString(tipos[0].CODIGO);

        //this.carregarFichasPagto(ficha.ID, ficha.DATA);

        //IList<FichaPagto> pagtos = Ficha.CarregarPagtoPorIdOld(ficha.ID);
        //this.Pagtos = pagtos;
        //if (pagtos != null)
        //{
        //    gridTipoPagto.DataSource = pagtos;
        //    gridTipoPagto.DataBind();

        //    //string pgtoId = "";
        //    //for (int i = 0; i < dlFormaPagto.Items.Count; i++)
        //    //{
        //    //    pgtoId = ((TextBox)dlFormaPagto.Items[i].FindControl("txtID")).Text;

        //    //    foreach (var pgto in pagtos)
        //    //    {
        //    //        if (pgtoId == CTipos.CToString(pgto.ID_FORMA))
        //    //        {
        //    //            ((TextBox)dlFormaPagto.Items[i].FindControl("txtValor")).Text = pgto.VALOR.ToString("N2");
        //    //            break;
        //    //        }
        //    //    }
        //    //}
        //}

        ////carrega cliente
        //IClienteAntigo cli = null;
        //switch (Convert.ToString(ficha.TIPO_CLIENTE))
        //{
        //    #region case 

        //    case "1":
        //    {
        //        cli = new Cliente1(ficha.ID_CLIENTE);
        //        break;
        //    }
        //    case "2":
        //    {
        //        cli = new Cliente2(ficha.ID_CLIENTE);
        //        break;
        //    }
        //    case "3":
        //    {
        //        cli = new Cliente3(ficha.ID_CLIENTE);
        //        break;
        //    }
        //    case "4":
        //    {
        //        cli = new Cliente4(ficha.ID_CLIENTE);
        //        break;
        //    }
        //    case "5":
        //    {
        //        cli = new Cliente5(ficha.ID_CLIENTE);
        //        break;
        //    }
        //    #endregion
        //}

        //cli.Carregar();
        #endregion

        if (!string.IsNullOrEmpty(cli.EMAIL))
            litMail.Text = cli.EMAIL;
        else
            litMail.Text = "";

        lblNome.Text = cli.NOME;
        lblCPF.Text = cli.CPF;

        if (cli.NASCIMENTO != DateTime.MinValue)
            lblDataNascimento.Text = cli.NASCIMENTO.ToString("dd/MM/yyyy");
        else
            lblDataNascimento.Text = "";

        if (!string.IsNullOrEmpty(cli.TEL_FIXO))
        {
            if (!string.IsNullOrEmpty(cli.DDD_F))
                lblTelefone.Text = string.Concat("(", cli.DDD_F, ") ", cli.TEL_FIXO);
            else
                lblTelefone.Text = cli.TEL_FIXO;
        }
        else
            lblTelefone.Text = "";

        if (!string.IsNullOrEmpty(cli.CELULAR))
        {
            if (!string.IsNullOrEmpty(cli.DDD_C))
            {
                if (string.IsNullOrEmpty(lblTelefone.Text))
                    lblTelefone.Text = string.Concat("(", cli.DDD_C, ") ", cli.CELULAR);
                else
                    lblTelefone.Text += string.Concat(" - (", cli.DDD_C, ") ", cli.CELULAR);
            }
            else
            {
                if (string.IsNullOrEmpty(lblTelefone.Text))
                    lblTelefone.Text = cli.CELULAR;
                else
                    lblTelefone.Text += " - " + cli.CELULAR;
            }
        }
    }

    void carregarFichasPagto(object fichaId, DateTime fichaData)
    {
        IList<FichaPagto> pagtos = Ficha.CarregarPagtoPorIdOld(fichaId);
        this.Pagtos = pagtos;
        if (pagtos != null)
        {
            foreach (var p in pagtos)
            {
                if (p.DATA == DateTime.MinValue) p.DATA = fichaData;
                if (p.DATA == DateTime.MinValue) p.DATA = DateTime.Now;
            }

            gridTipoPagto.DataSource = pagtos;
            gridTipoPagto.DataBind();

            //string pgtoId = "";
            //for (int i = 0; i < dlFormaPagto.Items.Count; i++)
            //{
            //    pgtoId = ((TextBox)dlFormaPagto.Items[i].FindControl("txtID")).Text;

            //    foreach (var pgto in pagtos)
            //    {
            //        if (pgtoId == CTipos.CToString(pgto.ID_FORMA))
            //        {
            //            ((TextBox)dlFormaPagto.Items[i].FindControl("txtValor")).Text = pgto.VALOR.ToString("N2");
            //            break;
            //        }
            //    }
            //}
        }

        this.calculaTotal();
    }


    void salvarFichaNova(IList<FichaPagto> pagtos)
    {
        Ficha ficha = new Ficha();
        ficha.ID_CLIENTE_Old = null;///////////
        ficha.ID_Old = null;///////////
        ficha.ATENDIDO = false;

        if (!string.IsNullOrEmpty(Request[Keys.IDKey]))
        {
            ficha.ID = Request[Keys.IDKey];
            ficha.Carregar();
        }

        ficha.DATA = CTipos.CStringToDateTime(txtNovoData.Text);
        ficha.ID_CLIENTE = Request[Keys.ClienteIDKey];
        ficha.ID_DENTISTA = cboDentista.SelectedValue;
        ficha.ID_EMPRESA = Request[Keys.EmpresaIDKey];
        ficha.ID_USUARIO = Request[Keys.UsuarioIDKey];
        ficha.TIPO_CLIENTE = cboEspecialidade.SelectedValue;
        ////ficha.TIPO_FICHA = cboTipo.SelectedValue;
        ficha.TOTAL = CTipos.ToDecimal(txtValorTotal.Text);
        ficha.TOTAL_ORCADO = CTipos.ToDecimal(txtTotalOrcado.Text);
        ficha.OBS = txtObs.Text;
        ficha.CPF_PAGADOR = txtCPFPagador.Text;

        FichaTipo tipo = new FichaTipo();
        tipo.CODIGO = cboTipo.SelectedValue;

        ////if (pagtos != null)
        ////{
        ////    ficha.TOTAL = 0;
        ////    foreach (var pagto in pagtos)
        ////    {
        ////        if (pagto.ID == null)
        ////        {
        ////            if (pagto.ID == null || (pagto.DATA.Day == ficha.DATA.Day && pagto.DATA.Month == ficha.DATA.Month && pagto.DATA.Year == ficha.DATA.Year))
        ////                ficha.TOTAL += pagto.VALOR;
        ////        }
        ////    }
        ////}

        bool novo = chkNovaFichaClinica.Visible && chkNovaFichaClinica.Checked;

        ficha.Salvar(tipo, pagtos, novo);
    }

    void salvarFichaAntiga(IList<FichaPagto> pagtos)
    {
        FichaAntiga fichaAntiga = new FichaAntiga();
        Ficha nova = new Ficha();

        ///////////////////////////////////////
        if (string.IsNullOrEmpty( Request[Keys.IDKeyOld]))
        {
            nova.ID = Request[Keys.IDKey];
            nova.Carregar();

            fichaAntiga.ID = nova.ID_Old;
        }
        ///////////////////////////////////////
        else
            fichaAntiga.ID = Request[Keys.IDKeyOld];

        if(fichaAntiga.ID != null)
            fichaAntiga.Carregar();

        ////Cliente cli = new Cliente();
        ////cli.ID = Request[Keys.IDKeyOld];
        ////cli.Carregar();

        IList<FichaAntiga> fichaItens = null;

        if (fichaAntiga.ID_CLIENTE != null && fichaAntiga.TIPO_CLIENTE != null)
            fichaItens = FichaAntiga.Carregar(Convert.ToInt32(fichaAntiga.ID_CLIENTE), Convert.ToInt32(fichaAntiga.TIPO_CLIENTE));
        else
        {
            fichaAntiga.ID_CLIENTE = nova.ID_CLIENTE_Old;
            fichaAntiga.TIPO_CLIENTE = nova.TIPO_CLIENTE;
            fichaAntiga.DATA = nova.DATA;
            fichaAntiga.DATA_USUARIO = nova.DATA;
            fichaAntiga.TOTAL = nova.TOTAL;
            fichaAntiga.TOTAL_ORCADO = nova.TOTAL_ORCADO;
        }

        if (fichaAntiga.ID_CLIENTE == null || fichaAntiga.TIPO_CLIENTE == null) return;

        FichaAntiga ficha = null;

        if (fichaItens != null && fichaItens.Count > 0)
            ficha = fichaItens[0]; //FichaAntiga ficha = fichaItens[fichaItens.Count - 1];
        else
        {
            ficha = new FichaAntiga();
            ficha.ID_CLIENTE = nova.ID_CLIENTE_Old;
            ficha.TIPO_CLIENTE = nova.TIPO_CLIENTE;
            ficha.DATA = nova.DATA;
            ficha.DATA_USUARIO = nova.DATA;
            ficha.TOTAL = nova.TOTAL;
            ficha.TOTAL_ORCADO = nova.TOTAL_ORCADO;
            ficha.ID_DENTISTA = nova.ID_DENTISTA;
        }

        ficha.ID_EMPRESA = Request[Keys.EmpresaIDKey];
        ficha.CPF_PAGADOR = txtCPFPagador.Text;
        ficha.TOTAL = CTipos.ToDecimal(txtValorTotal.Text);
        ficha.TOTAL_ORCADO = CTipos.ToDecimal(txtTotalOrcado.Text);
        ////ficha.DATA = CTipos.CStringToDateTime(txtHistPagtoData.Text);
        ////ficha.DATA_USUARIO = CTipos.CStringToDateTime(txtHistPagtoData.Text);
        ficha.ID_USUARIO = Request[Keys.UsuarioIDKey];
        ficha.ID_DENTISTA = cboDentista.SelectedValue;

        FichaTipo tipo = new FichaTipo();
        tipo.CODIGO = cboTipo.SelectedValue;


        if (pagtos != null)
        {
            ficha.TOTAL = 0;

            foreach (var pagto in pagtos) { if (pagto.ID == null) ficha.ID = null; }

            foreach (var pagto in pagtos.OrderBy(p => p.DATA))
            {
                if (pagto.ID == null)
                {
                    ficha.ID = null; //força criar uma nova "ficha antiga" para nao quebrar os relatorios atuais
                    
                    ////ficha.DATA_USUARIO = DateTime.Now;
                    ficha.DATA_USUARIO = new DateTime(pagto.DATA.Year, pagto.DATA.Month, pagto.DATA.Day,
                        DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                    ficha.DATA = ficha.DATA_USUARIO;

                    ////ficha.DATA = pagto.DATA;
                    tipo.ID = null;

                    if (pagto.ID == null || (pagto.DATA.Day == ficha.DATA_USUARIO.Day && pagto.DATA.Month == ficha.DATA_USUARIO.Month && pagto.DATA.Year == ficha.DATA_USUARIO.Year))
                        ficha.TOTAL += pagto.VALOR;
                    else if(Convert.ToString(ficha.ID) == Convert.ToString(pagto.ID_FICHA))
                        ficha.TOTAL += pagto.VALOR;
                }
                else if (Convert.ToString(ficha.ID) == Convert.ToString(pagto.ID_FICHA))
                    ficha.TOTAL += pagto.VALOR;
            }
        }

        ficha.Salvar(tipo, pagtos);

        if (!string.IsNullOrEmpty(Request[Keys.IDKey]))
        {
            Ficha.AtualizarIDOld(Request[Keys.IDKey], ficha.ID);
        }
    }

    protected void cmdSalvar_Click(object sender, EventArgs e)
    {
        #region validacoes 

        if (cboEspecialidade.SelectedIndex <= 0)
        {
            Geral.Alerta(this, "Selecione por favor a especialidade");
            cboEspecialidade.Focus();
            return;
        }

        if (cboDentista.SelectedIndex <= 0)
        {
            Geral.Alerta(this, "Selecione por favor o dentista");
            cboDentista.Focus();
            return;
        }

        if (cboTipo.SelectedValue == "1" && CTipos.ToDecimal(txtTotalOrcado.Text) == decimal.Zero && cboEspecialidade.SelectedValue != "3") //exceto para orto
        {
            Geral.Alerta(this, "Para orçamentos contratados é necessário informar o total orçado.");
            txtTotalOrcado.Focus();
            return;
        }

        if (cboTipo.SelectedValue == "0")
        {
            Geral.Alerta(this, "Selecione por favor um tipo de ficha.");
            cboTipo.Focus();
            return;
        }

        if (cboTipo.SelectedIndex == 0)
        {
            Geral.Alerta(this, "Selecione por favor um tipo de ficha.");
            cboTipo.Focus();
            return;
        }

        //TODO: regras quanto ao tipo de ficha...

        IList<FichaPagto> pagtos = new List<FichaPagto>();
        pagtos = this.Pagtos;

        //decimal valor = 0;
        //string pgtoId = "";
        //for (int i = 0; i < dlFormaPagto.Items.Count; i++)
        //{
        //    valor = CTipos.ToDecimal(((TextBox)dlFormaPagto.Items[i].FindControl("txtValor")).Text);

        //    if (valor > decimal.Zero)
        //    {
        //        pgtoId = ((TextBox)dlFormaPagto.Items[i].FindControl("txtID")).Text;

        //        pagtos.Add(new FichaPagto
        //        {
        //            ID_FORMA = pgtoId,
        //            VALOR = valor
        //        });
        //    }
        //}

        if (pagtos == null || pagtos.Count == 0)
        {
            //todo: ???
        }

        #endregion

        //return;//////////////////////

        if(string.IsNullOrEmpty(Request[Keys.IDKeyOld]) && string.IsNullOrEmpty( Request[Keys.IDKey]))
        {
            this.salvarFichaNova(pagtos);
            Response.Redirect(string.Format("fichas.aspx?msg=salvo&{0}={1}&{2}={3}&{4}={5}", Keys.EmpresaIDKey, Request[Keys.EmpresaIDKey], Keys.UsuarioIDKey, Request[Keys.UsuarioIDKey], Keys.ClienteIDKey, Request[Keys.ClienteIDKey]));
        }
        else if (string.IsNullOrEmpty(Request[Keys.IDKeyOld]))
        {
            this.salvarFichaAntiga(pagtos); //this.salvarFichaNova(pagtos);
            Response.Redirect(string.Format("fichas.aspx?msg=salvo&{0}={1}&{2}={3}&{4}={5}", Keys.EmpresaIDKey, Request[Keys.EmpresaIDKey], Keys.UsuarioIDKey, Request[Keys.UsuarioIDKey], Keys.ClienteIDKey, Request[Keys.ClienteIDKey]));
        }
        else
        {
            this.salvarFichaAntiga(pagtos);
            Response.Redirect(string.Format("fichas.aspx?msg=salvo&{0}={1}&{2}={3}&{4}={5}", Keys.EmpresaIDKey, Request[Keys.EmpresaIDKey], Keys.UsuarioIDKey, Request[Keys.UsuarioIDKey], Keys.ClienteIDKey, Request[Keys.ClienteIDKey])); //Response.Redirect(string.Format("clientes.aspx?{0}={1}&{2}={3}", Keys.EmpresaIDKey, Request[Keys.EmpresaIDKey], Keys.UsuarioIDKey, Request[Keys.UsuarioIDKey]));
        }

        //Response.Redirect("ficha.aspx?msg=salvo&" + Keys.UsuarioIDKey + "=" + Request[Keys.UsuarioIDKey] + "&" + Keys.EmpresaIDKey + "=" + Request[Keys.EmpresaIDKey]);
        
    }
    protected void cmdVoltar_Click(object sender, EventArgs e)
    {
        //if (string.IsNullOrEmpty(Request[Keys.IDKeyOld]))
        Response.Redirect(string.Format("fichas.aspx?{0}={1}&{2}={3}&{4}={5}", Keys.ClienteIDKey, Request[Keys.ClienteIDKey], Keys.EmpresaIDKey, Request[Keys.EmpresaIDKey], Keys.UsuarioIDKey, Request[Keys.UsuarioIDKey]));
        //else
        //    Response.Redirect(string.Format("clientes.aspx?{0}={1}&{2}={3}", Keys.EmpresaIDKey, Request[Keys.EmpresaIDKey], Keys.UsuarioIDKey, Request[Keys.UsuarioIDKey]));
    }

    protected void dlFormaPagto_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            TextBox txtValor = e.Item.FindControl("txtValor") as TextBox;
            if (txtValor != null)
            {
                txtValor.Attributes.Add("onkeyup", "mascara('" + txtValor.ClientID + "')");
                txtValor.Attributes.Add("onblur", "atualizaTotal();");
            }
        }
    }
    protected void dlFormaPagto_ItemCreated(object sender, DataListItemEventArgs e)
    {
        //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //{
        //    TextBox txtValor = e.Item.FindControl("txtValor") as TextBox;
        //    if (txtValor != null)
        //    {
        //        txtValor.Attributes.Add("onkeyup", "mascara('" + txtValor.ClientID + "')");
        //    }
        //}
    }

    void registraEventosCamposValor()
    {
        string campos = "";

        for (int i = 0; i < dlFormaPagto.Items.Count; i++)
        {
            if (campos != "") campos += "|";

            campos += ((TextBox)dlFormaPagto.Items[i].FindControl("txtValor")).ClientID;
        }

        litScript.Text = string.Concat("<script>",
            "function atualizaTotal() { ",
            "var campos = '", campos, "'; ",
            "var arrCampos = campos.split('|'); ",
            "var total = 0; ",
            "for (i = 0; i < arrCampos.length; i++) { ",
            "total += parseFloat(document.getElementById(arrCampos[i]).value.replace(',','.'));",
            "} ",
            "document.getElementById('", txtValorTotal.ClientID, "').value = total.toFixed(2).replace(\".\", \",\").replace(/(\\d)(?=(\\d{3})+(?!\\d))/g, \"$1,\");",
            "}</script>");
        
    }

    protected void gridTipoPagto_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Geral.grid_RowDataBound_Confirmacao(sender, e, 5, "Deseja realmente excluir?\\nEssa operação não poderá ser desfeita.");
        }
    }
    protected void gridTipoPagto_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("editar"))
        {
            string id = Geral.ObterDataKeyValDoGrid<string>(gridTipoPagto, e, 0);

            FichaPagto pagto = null;

            if (id != null)
            {
                pagto = new FichaPagto();
                this.IdTipoPagtoSel = id;
                pagto.ID = id;
                pagto.Carregar();

                Usuario u = new Usuario();
                u.ID = Request[Keys.UsuarioIDKey];
                u.Carregar();
                if (u.Admin != 1)
                {
                    if (pagto.DATA.Day  != DateTime.Now.Day ||
                       pagto.DATA.Month != DateTime.Now.Month ||
                       pagto.DATA.Year  != DateTime.Now.Year)
                    {
                        //txtHistPagtoData.ReadOnly = false;

                        Geral.Alerta(this, "Apenas administradores podem alterar este lançamento.");
                        return;
                    }
                }
            }
            else
            {
                pagto = this.Pagtos[CTipos.CToInt(e.CommandArgument)];
            }

            cmdAdicionarTipoPagto.Text = "alterar";

            cboTipoPagto.SelectedValue = Convert.ToString(pagto.ID_FORMA);
            txtValorTipoPagto.Text = pagto.VALOR.ToString("N2");
            //txtCPFPagador.Text = pagto.CPF;

            if (pagto.DATA == DateTime.MinValue)
            {
                FichaAntiga ficha = new FichaAntiga();
                ficha.ID = pagto.ID_FICHA;
                ficha.Carregar();
                pagto.DATA = ficha.DATA;
            }

            if (pagto.DATA == DateTime.MinValue) pagto.DATA = DateTime.Now;
            txtHistPagtoData.Text = pagto.DATA.ToString("dd/MM/yyyy");

            txtTipoPagtoAutorizacao.Text = pagto.AUTORIZACAO;
            gridTipoPagto.SelectedIndex = CTipos.CToInt(e.CommandArgument);

            //Usuario u = new Usuario();
            //u.ID = Request[Keys.UsuarioIDKey];
            //u.Carregar();
            //if (u.Admin > 0)
            //    txtHistPagtoData.ReadOnly = false;
            //else
            //{
            //    if (pagto.DATA.Day  == DateTime.Now.Day &&
            //       pagto.DATA.Month == DateTime.Now.Month &&
            //       pagto.DATA.Year  == DateTime.Now.Year)
            //    {
            //        txtHistPagtoData.ReadOnly = false;
            //    }
            //    else
            //        txtHistPagtoData.ReadOnly = true;
            //}

            cboTipoPagto_SelectedIndexChanged(null, null);
        }
        else if (e.CommandName.Equals("excluir"))
        {
            #region excluir 

            this.IdTipoPagtoSel = null;
            gridTipoPagto.SelectedIndex = -1;

            string id = Geral.ObterDataKeyValDoGrid<string>(gridTipoPagto, e, 0);
            FichaPagto pagto = new FichaPagto();

            if (id != null)
            {
                pagto.ID = id;
                pagto.Carregar();

                Usuario u = new Usuario();
                u.ID = Request[Keys.UsuarioIDKey];
                u.Carregar();
                if (u.Admin <= 0) //nao é admin
                {
                    if (pagto.DATA.Day != DateTime.Now.Day ||
                        pagto.DATA.Month != DateTime.Now.Month ||
                        pagto.DATA.Year != DateTime.Now.Year)
                    {
                        Geral.Alerta(this, "Apenas administradores do sistema podem excluir este lançamento.");
                        return;
                    }
                }

                pagto.Remover();

                //if (string.IsNullOrEmpty(Request[Keys.IDKeyOld]))
                //    this.carregarFichasPagto(pagto.ID_FICHA, DateTime.Now); //todo: tem que ser a data da ficha
                //else
                //{
                    FichaAntiga fichaAntiga = new FichaAntiga();
                    fichaAntiga.ID = pagto.ID_FICHA; //Request[Keys.IDKeyOld];
                    fichaAntiga.Carregar();

                    var pagtos = FichaPagto.Carregar(
                        Convert.ToInt32(fichaAntiga.ID_CLIENTE), Convert.ToInt32(fichaAntiga.TIPO_CLIENTE));
                    this.Pagtos = pagtos;
                    gridTipoPagto.DataBind();
                    this.calculaTotal();

                    fichaAntiga.TOTAL = 0;

                    if (pagtos != null)
                    {
                        this.calculaTotal();

                        foreach (var p in pagtos)
                        {
                            if (p.DATA == DateTime.MinValue) p.DATA = p.FICHA_DATA_USUARIO;
                            if (p.DATA == DateTime.MinValue) p.DATA = DateTime.Now;


                            if(Convert.ToString(p.ID_FICHA) == Convert.ToString(fichaAntiga.ID))
                                fichaAntiga.TOTAL += p.VALOR;
                        }

                        gridTipoPagto.DataSource = pagtos;
                        gridTipoPagto.DataBind();
                    }

                    fichaAntiga.Salvar();
                //}
            }
            else
            {
                this.Pagtos.RemoveAt(CTipos.CToInt(e.CommandArgument));
                gridTipoPagto.DataSource = this.Pagtos;
                gridTipoPagto.DataBind();
            }

            this.calculaTotal();

            #endregion
        }
    }

    /// <summary>
    /// Não salva no banco, apenas no viewstate
    /// </summary>
    protected void cmdAdicionarTipoPagto_Click(object sender, EventArgs e)
    {
        decimal valor = CTipos.ToDecimal(txtValorTipoPagto.Text);
        if (valor == decimal.Zero)
        {
            Geral.Alerta(this, "Deve ser informado um valor maior que zero no campo de valor.");
            return;
        }

        if (pnlTipoPagtoComplemento.Visible)  //if (txtTipoPagtoAutorizacao.Visible)
        {
            if (txtTipoPagtoAutorizacao.Text == "número de autorização" || txtTipoPagtoAutorizacao.Text.Trim() == "")
            {
                Geral.Alerta(this, "Deve ser informado o número de autorização.");
                return;
            }
        }

        FichaPagto pagto = null;

        if (cmdAdicionarTipoPagto.Text.Equals("alterar"))
            pagto = this.Pagtos[gridTipoPagto.SelectedIndex];
        else
            pagto = new FichaPagto();

        pagto.AUTORIZACAO = txtTipoPagtoAutorizacao.Text;
        //pagto.CPF = txtTipoPagtoCPF.Text;
        pagto.DESCR_FORMA = cboTipoPagto.SelectedItem.Text;
        pagto.ID_FORMA = cboTipoPagto.SelectedValue;
        pagto.VALOR = valor;
        pagto.DATA = CTipos.CStringToDateTime(txtHistPagtoData.Text);

        if (cmdAdicionarTipoPagto.Text.Equals("alterar"))
        {
            if (pagto.ID != null) 
            { 
                pagto.Salvar();///////////////////////////

                FichaAntiga antiga = new FichaAntiga();
                antiga.ID = pagto.ID_FICHA;
                antiga.Carregar();
                antiga.DATA_USUARIO = new DateTime(pagto.DATA.Year, pagto.DATA.Month, pagto.DATA.Day,
                    antiga.DATA_USUARIO.Hour, antiga.DATA_USUARIO.Minute, antiga.DATA_USUARIO.Second);

                IList<FichaPagto> pagtos = FichaPagto.Carregar(
                    Convert.ToInt32(antiga.ID_CLIENTE), Convert.ToInt32(antiga.TIPO_CLIENTE));

                antiga.TOTAL = 0;

                antiga.TOTAL += pagto.VALOR;

                foreach (var _pagto in pagtos)
                {
                    if (Convert.ToInt32(_pagto.ID) == Convert.ToInt32(pagto.ID)) { continue; }
                    if (Convert.ToInt32(_pagto.ID_FICHA) != Convert.ToInt32(pagto.ID_FICHA)) continue;

                    _pagto.DATA = pagto.DATA;
                    _pagto.Salvar();
                    antiga.TOTAL += _pagto.VALOR;
                }

                antiga.Salvar();///////////////////////////
            }

            this.Pagtos[gridTipoPagto.SelectedIndex] = pagto;
        }
        else
        {
            if (this.Pagtos == null) this.Pagtos = new List<FichaPagto>();
            this.Pagtos.Add(pagto);
        }

        this.IdTipoPagtoSel = null;
        gridTipoPagto.SelectedIndex = -1;
        cmdAdicionarTipoPagto.Text = "adicionar";

        gridTipoPagto.DataSource = this.Pagtos;
        gridTipoPagto.DataBind();

        txtTipoPagtoAutorizacao.Text = "";
        //txtTipoPagtoCPF.Text = "";
        txtValorTipoPagto.Text = "0,00";
        txtHistPagtoData.Text = DateTime.Now.ToString("dd/MM/yyyy");

        this.calculaTotal();

        Geral.JSScriptResizeIFrame(this);
    }

    void calculaTotal()
    {
        decimal total = 0;
        decimal orcado = CTipos.ToDecimal(txtTotalOrcado.Text);
        if (this.Pagtos != null)
        {
            foreach (var p in this.Pagtos) total += p.VALOR;
        }

        txtValorTotal.Text = total.ToString("N2");

        decimal saldo = (orcado - total);
        if (saldo < decimal.Zero) saldo = decimal.Zero;
        txtSaldoDevedor.Text = saldo.ToString("N2");
    }
    protected void cboTipoPagto_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cboTipoPagto.SelectedItem.Text.ToLower().IndexOf("crédito") > -1 ||
            cboTipoPagto.SelectedItem.Text.ToLower().IndexOf("débito") > -1)
            pnlTipoPagtoComplemento.Visible = true;
        else
            pnlTipoPagtoComplemento.Visible = false;
    }
    protected void txtTotalOrcado_TextChanged(object sender, EventArgs e)
    {
        this.calculaTotal();
    }
    protected void txtValorTotal_TextChanged(object sender, EventArgs e)
    {
        this.calculaTotal();
    }
    protected void chkNovaFichaClinica_CheckedChanged(object sender, EventArgs e)
    {
        if (chkNovaFichaClinica.Checked)
        {
            cboEspecialidade.SelectedValue = "1";
            cboEspecialidade.Enabled = false;
        }
        else
            cboEspecialidade.Enabled = true;
    }
}
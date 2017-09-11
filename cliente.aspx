<%@ Page Theme="padrao" Language="C#" MasterPageFile="~/layout.master" AutoEventWireup="true" CodeFile="cliente.aspx.cs" Inherits="cliente" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="Scripts/jquery-1.10.2.min.js"" type="text/javascript"></script>
    <script src="Scripts/bootsrap/bootstrap.js" type="text/javascript"></script>

    <script src="Scripts/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="Scripts/bootsrap/bootstrap.js" type="text/javascript"></script>

    <script src="Scripts/waypoints.min.js" type="text/javascript"></script>
    <script src="Scripts/application.js"></script>
    <script src="Scripts/jquery.countTo.js"></script>
    <script src="Scripts/skycons.js"></script>
    <script src="Scripts/jquery.flot.min.js"></script>
    <script src="Scripts/jquery.flot.resize.min.js"></script>
    <script src="Scripts/jquery.flot.canvas.min.js"></script>
    <script src="Scripts/jquery.flot.image.min.js"></script>
    <script src="Scripts/jquery.flot.categories.min.js"></script>
    <script src="Scripts/jquery.flot.crosshair.min.js"></script>
    <script src="Scripts/jquery.flot.errorbars.min.js"></script>
    <script src="Scripts/jquery.flot.fillbetween.min.js"></script>
    <script src="Scripts/jquery.flot.navigate.min.js"></script>
    <script src="Scripts/jquery.flot.pie.min.js"></script>
    <script src="Scripts/jquery.flot.selection.min.js"></script>
    <script src="Scripts/jquery.flot.stack.min.js"></script>
    <script src="Scripts/jquery.flot.symbol.min.js"></script>
    <script src="Scripts/jquery.flot.threshold.min.js"></script>
    <script src="Scripts/jquery.colorhelpers.min.js"></script>
    <script src="Scripts/jquery.flot.time.min.js"></script>
    <script src="Scripts/jquery.flot.example.js"></script>
    <script src="Scripts/morris.min.js"></script>
    <script src="Scripts/raphael.2.1.0.min.js"></script>
    <script src="Scripts/jquery-jvectormap-1.2.2.min.js"></script>
    <script src="Scripts/jquery-jvectormap-world-mill-en.js"></script>
    <script src="Scripts/todos.js"></script>

    <script src="Scripts/jquery.click-calendario-1.0-min.js"></script>
    <script src="Scripts/jquery.click-calendario-1.0.js"></script>

    <script src="Scripts/common.js"></script>
    <script src="Scripts/jquery-ui-1.10.4.custom.js"></script>
    <link href="Scripts/jquery-ui-1.10.4.custom.css" rel='stylesheet' type='text/css'>

    <!-- Fonts -->
    <link href='http://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,900,300italic,400italic,600italic,700italic,900italic' rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:400,700' rel='stylesheet' type='text/css'>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <div class="panel panel-default" style="background-color:white">
                <div class="panel-heading">
                    <h3 class="panel-title">Cliente</h3>
                </div>
                <div class="panel-body" style="background-color:white">

                    <!-- Nav tabs -->
                    <ul class="nav nav-tabs" role="tablist">
                        <li role="presentation" class="active"><a href="#agent-01" aria-controls="agent-01" role="tab" data-toggle="tab">Dados comuns</a></li>
                        <%--<li role="presentation"><a href="#agent-02" aria-controls="agent-02" role="tab" data-toggle="tab">Dados de contato</a></li>--%>
                        <li role="presentation"><a href="#agent-03" aria-controls="agent-03" role="tab" data-toggle="tab">Dados de Endereço</a></li>
                    </ul>

                    <!-- Tab panes -->
                    <div class="tab-content">
                        <div role="tabpanel" class="tab-pane fade in active" id="agent-01" style='padding:40px;border-bottom:1px #DDDDDD solid;border-right:1px #DDDDDD solid;border-left:1px #DDDDDD solid'>
                            <div class="form-group">
                                <label class="col-xs-2 control-label">Nome</label>
                                <div class="col-xs-10"><asp:TextBox runat="server" SkinID="txtPadrao" ID="txtNome" Width="100%" /></div>
                            </div>

                            <div class="clearfix" style="margin-bottom:15px"></div>

                            <div class="form-group">
                                <label class="col-xs-2 control-label"><asp:Literal ID="lblDataNasc_Data" Text="Nascimento" runat="server"/></label>
                                <div class="col-xs-2">
                                    <asp:TextBox runat="server" SkinID="txtPadrao" ID="txtDataNascimento" Width="80%" onkeypress="filtro_SoNumeros(event); mascara_DATA(this, event);" Style="float:left;" MaxLength="10" />
                                    <asp:Image ID="imgCalendar" ToolTip="calendário" CssClass="Float" Style="cursor:pointer; margin-left:5px; margin-top:5px;" ImageUrl="~/Images/calendar.png" runat="server" EnableViewState="false" />
                                    <asp:CalendarExtender ID="cetDataNasc" TargetControlID="txtDataNascimento" PopupButtonID="imgCalendar" runat="server" TodaysDateFormat="dd/MM/yyyy" Format="dd/MM/yyyy" EnableViewState="false"></asp:CalendarExtender>
                                </div>

                                <label class="col-xs-1 control-label"><asp:Literal ID="lblCPF_CNPJ" Text="CPF" runat="server" /></label>
                                <div class="col-xs-2">
                                    <asp:TextBox runat="server" SkinID="txtPadrao" ID="txtCPF" Width="100%" onkeypress="filtro_SoNumeros(event);" MaxLength="14" />
                                </div>
                            </div>
                            <%--
                            <div class="clearfix" style="margin-bottom:15px"></div>

                            
                            <div class="form-group">
                                <label class="col-xs-2 control-label"><asp:Literal ID="lblRG_IE" Text="RG" runat="server" /></label>
                                <div class="col-xs-2"><asp:TextBox runat="server" SkinID="txtPadrao" ID="txtRG" Width="100%" MaxLength="15" /></div>

                            </div>
                            --%>

                            <div class="clearfix" style="margin-bottom:15px"></div>

                            <div class="form-group">
                                <label class="col-xs-2 control-label">DDD</label>
                                <div class="col-xs-2">
                                    <asp:TextBox SkinID="txtPadrao" runat="server" ID="txtDDD1" Width="100%" MaxLength="2" Text="21"  onkeypress="filtro_SoNumeros(event);" />
                                </div>

                                <label class="col-xs-1 control-label">Fone</label>
                                <div class="col-xs-2">
                                    <asp:TextBox SkinID="txtPadrao" runat="server" ID="txtFone1" Width="100%" MaxLength="9" />
                                </div>

                                <%--<label class="col-xs-1 control-label">ramal</label>
                                <div class="col-xs-2"><asp:TextBox SkinID="txtPadrao" runat="server" ID="txtRamal1" Width="100%" MaxLength="5" /></div>--%>
                            </div>

                            <div class="clearfix" style="margin-bottom:15px"></div>

                            <div class="form-group">
                                <label class="col-xs-2 control-label">DDD</label>
                                <div class="col-xs-2">
                                   <asp:TextBox SkinID="txtPadrao" runat="server" ID="txtDDDCelular" Width="100%" MaxLength="2" Text="21"  onkeypress="filtro_SoNumeros(event);" />
                                </div>

                                <label class="col-xs-1 control-label">Celular</label>
                                <div class="col-xs-2">
                                    <asp:TextBox SkinID="txtPadrao" runat="server" ID="txtCelular" Width="100%" MaxLength="10" />
                                </div>
                                <%--<label class="col-xs-1 control-label">Oper.</label>
                                <div class="col-xs-4">
                                    <asp:DropDownList SkinID="comboPadrao1" runat="server" ID="cboCelularOperadora" Width="100%">
                                        <asp:ListItem Text="selecione" Value="0" />
                                        <asp:ListItem Text="Claro" Value="3" />
                                        <asp:ListItem Text="Nextel" Value="2" />
                                        <asp:ListItem Text="Oi" Value="5" />
                                        <asp:ListItem Text="Outra" Value="6" />
                                        <asp:ListItem Text="Tim" Value="1" />
                                        <asp:ListItem Text="Vivo" Value="4" />
                                    </asp:DropDownList>
                                </div>--%>
                            </div>

                            <div class="clearfix" style="margin-bottom:15px"></div>

                            <div class="form-group">
                                <label class="col-xs-2 control-label">E-mail</label>
                                <div class="col-xs-10">
                                    <asp:TextBox SkinID="txtPadrao" Width="100%" runat="server" ID="txtEmail" MaxLength="85" />
                                </div>
                            </div>

                            <div class="clearfix" style="margin-bottom:15px"></div>

                            <div class="form-group">
                                <label class="col-xs-2 control-label">Como chegou</label>
                                <div class="col-xs-6">
                                    <asp:DropDownList runat="server" SkinID="comboPadrao1" ID="cboIndicacao" Width="100%">
                                        <%----%><asp:ListItem Text="selecione" Value="0" Selected="True" />
                                        <asp:ListItem Text="Bairro" Value="3" />
                                        <asp:ListItem Text="Indicado" Value="2" />
                                        <asp:ListItem Text="Indicado Clínica" Value="4" />
                                        <asp:ListItem Text="Placa" Value="5" />
                                        <asp:ListItem Text="Porta" Value="6"/>
                                        <asp:ListItem Text="Telemarketing" Value="8" />
                                    </asp:DropDownList>
                                </div>

                                <div class="clearfix" style="margin-bottom:15px"></div>

                                <label class="col-xs-2 control-label">Status</label>
                                <div class="col-xs-2">
                                    <asp:CheckBox runat="server" ID="chkStatus" Text="Ativo" Checked="true" />
                                </div>
                            </div>
                            
                            <div class="clearfix" style="margin-bottom:15px"></div>

                            <div class="form-group">
                                <label class="col-xs-2 control-label">Cadastro</label>
                                <div class="col-xs-4"><asp:Literal runat="server" ID="litDataCadastro" /></div>
                            </div>

                            <div class="clearfix" style="margin-bottom:15px"></div>

                            <div class="form-group">
                                <label class="col-xs-2 control-label">Alteração</label>
                                <div class="col-xs-4"><asp:Literal runat="server" ID="litDataCadastroAlteracao" /></div>
                            </div>

                        </div>
                        <div role="tabpanel" class="tab-pane fade" id="agent-02" style='padding:40px;border-bottom:1px #DDDDDD solid;border-right:1px #DDDDDD solid;border-left:1px #DDDDDD solid'>
                            
                            <div class="form-group" runat="server" visible="false" enableviewstate="false">
                                <label class="col-xs-1 control-label">DDD</label>
                                <div class="col-xs-2">
                                    <asp:TextBox SkinID="txtPadrao" runat="server" ID="txtDDD2" Width="100%" MaxLength="2" Text="21" onkeypress="filtro_SoNumeros(event);" />
                                </div>

                                <label class="col-xs-1 control-label">Fone</label>
                                <div class="col-xs-2">
                                    <asp:TextBox SkinID="txtPadrao" runat="server" ID="txtFone2" Width="100%" MaxLength="9" />
                                </div>
                                <label class="col-xs-1 control-label">ramal</label>
                                <div class="col-xs-2"><asp:TextBox SkinID="txtPadrao" runat="server" ID="txtRamal2" Width="100%" MaxLength="5" /></div>
                            </div>

                        </div>
                        <div role="tabpanel" class="tab-pane fade" id="agent-03" style='padding:40px;border-bottom:1px #DDDDDD solid;border-right:1px #DDDDDD solid;border-left:1px #DDDDDD solid'>

                            <div class="form-group">
                                <label class="col-xs-2 control-label" >CEP</label>
                                <div class="col-xs-2">
                                    <asp:TextBox SkinID="txtPadrao" runat="server" ID="txtCEP" Width="100%" MaxLength="9" />
                                </div>
                                <div class="col-xs-1"><asp:ImageButton Visible="false" runat="server" EnableViewState="false" ToolTip="checar CEP" ImageUrl="~/images/endereco.png" ID="cmdBuscaEndereco" OnClick="cmdBuscaEndereco_Click" />&nbsp;</div>
                            </div>

                            <div class="clearfix" style="margin-bottom:15px"></div>

                            <div class="form-group">
                                <label class="col-xs-2 control-label">Logradouro</label>
                                <div class="col-xs-4"><asp:TextBox SkinID="txtPadrao" runat="server" ID="txtLogradouro" Width="100%" MaxLength="300" /></div>
                                <label class="col-xs-2 control-label">Número</label>
                                <div class="col-xs-2"><asp:TextBox SkinID="txtPadrao" runat="server" ID="txtNumero" Width="100%" MaxLength="9" /></div>
                            </div>

                            <div class="clearfix" style="margin-bottom:15px"></div>

                            <div class="form-group">
                                <label class="col-xs-2 control-label" >Complemento</label>
                                <div class="col-xs-4"><asp:TextBox SkinID="txtPadrao" runat="server" ID="txtComplemento" Width="100%" MaxLength="250" /></div>
                                <label class="col-xs-2 control-label">Bairro</label>
                                <div class="col-xs-2"><asp:TextBox SkinID="txtPadrao" runat="server" ID="txtBairro" Width="100%" MaxLength="300" /></div>
                            </div>

                            <div class="clearfix" style="margin-bottom:15px"></div>

                            <div class="form-group">
                                <label class="col-xs-2 control-label">Cidade</label>
                                <div class="col-xs-4"><asp:TextBox SkinID="txtPadrao" runat="server" ID="txtCidade" Width="200px" MaxLength="300" /></div>
                                <label class="col-xs-2 control-label">UF</label>
                                <div class="col-xs-2"><asp:TextBox SkinID="txtPadrao" runat="server" ID="txtUF" Width="40px" MaxLength="2" /></div>
                            </div>

                        </div>
                    </div>

                    <div class="clearfix" style="margin-bottom:15px"></div>

                    <div class="alert alert-info" role="alert" style="height:60px">
                        <div class="form-group">
                            <div class="col-xs-6 text-center">
                                <asp:Button ID="cmdVoltar" runat="server" Text="Voltar" SkinID="botaoPadraoINFO" OnClick="cmdVoltar_click"  />
                            </div>
                            <div class="col-xs-6 text-center">
                                <asp:Button ID="cmdSalvar" runat="server" Text="Gravar" SkinID="botaoPadraoINFO" OnClick="cmdSalvar_click" />
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <script type="text/javascript">

        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(configScript);

            configScript(null, null);
        });

        function configScript(sender, args)
        {
            //$('#ContentPlaceHolder1_imgCalendar').click(function () {
            //    $(this).calendario({
            //        target: '#ContentPlaceHolder1_txtDataNascimento'
            //    });
            //});
        }


        /*
        http://www.tidbits.com.br/click-calendario-plugin-de-jquery-para-calendarios-em-portugues
        */
    </script>

<script>
    $('#myTabs a').click(function (e) {
        e.preventDefault()
        $(this).tab('show')
    })

    $('#myTabs a[href="#profile"]').tab('show') // Select tab by name
    $('#myTabs a:first').tab('show') // Select first tab
    $('#myTabs a:last').tab('show') // Select last tab
    $('#myTabs li:eq(2) a').tab('show') // Select third tab (0-indexed)

</script>
</asp:Content>


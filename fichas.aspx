<%@ Page Theme="padrao" Language="C#" MasterPageFile="~/layout.master" AutoEventWireup="true" CodeFile="fichas.aspx.cs" Inherits="fichas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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

    <script src="Scripts/common.js"></script>
    <script src="Scripts/jquery-ui-1.10.4.custom.js"></script>
    <link href="Scripts/jquery-ui-1.10.4.custom.css" rel='stylesheet' type='text/css'/>

    <!-- Fonts -->
    <link href='http://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,900,300italic,400italic,600italic,700italic,900italic' rel='stylesheet' type='text/css'/>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:400,700' rel='stylesheet' type='text/css'/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>

            <div class="panel panel-default">
                <div class="panel-heading text-right" style="position:relative;">
                    <%--<div style="position:absolute; right:0; top:0px;"><asp:Button ID="lnkNovo" Text="Novo" runat="server" EnableViewState="false" SkinID="botaoPadrao1" OnClick="lnkNovo_Click" /></div>--%>
                    <div class="col-xs-12">
                        <div class="row">
                            <%--<label class="col-xs-5 text-left">Nome:</label>
                            <label class="col-xs-4 text-left">CPF:</label>--%>
                        </div>
                        <div class="clearfix"></div>    
                        <div class="row">
                            <div class="col-xs-12">
                                <div class="col-xs-5 text-left"  style="padding-left:0px;">
                                    <strong>
                                    <asp:Literal ID="litTitulo" Text="Ficha" runat="server" />
                                    </strong>
                                    <%--<asp:TextBox ID="txtNome" Width="100%" SkinID="txtPadrao" runat="server" />--%>
                                </div>
                                <div class="col-xs-4">
                                    <%--<asp:TextBox ID="txtCPF" Width="100%" SkinID="txtPadrao" runat="server" />--%>
                                </div>
                                <div class="col-xs-2">
                                    <%--<asp:Button ID="cmdProcurar" Text="Procurar" SkinID="botaoPadrao1" EnableViewState="false" runat="server" OnClick="cmdProcurar_Click" />--%>
                                </div>
                                <div class="col-xs-1">
                                    
                                </div>
                            </div>

                        </div><%----%>
                    </div><%----%>
                    <div class="clearfix"></div>
                </div>
                <div class="panel-body">
                    <div class="clearfix"></div>
                    <asp:GridView  ID="grid" Width="100%" SkinID="gridPadrao"
                        runat="server" AllowPaging="True" AutoGenerateColumns="False"  
                        DataKeyNames="ID,ID_Old,ID_CLIENTE,ID_CLIENTE_Old" onrowcommand="grid_RowCommand" 
                        onrowdatabound="grid_RowDataBound" PageSize="14"
                        OnPageIndexChanging="grid_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="DATA" HeaderText="Data" DataFormatString="{0:dd/MM/yyyy}" >
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PacienteNome" HeaderText="Nome">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ID_TRATADO" HeaderText="Ficha">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Especialidade" HeaderText="Especialidade">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>

                            <asp:BoundField DataField="DentistaNome" HeaderText="Dentista">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>

                            <asp:BoundField DataField="TipoFicha" HeaderText="Status">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>

                            <%--<asp:ButtonField Text="<img src='Images/detail2.png' title='ficha' alt='ficha' border='0' />" CommandName="ficha" >
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:ButtonField>--%>

                            <asp:ButtonField Text="<img src='Images/dollar.png' title='ver' alt='ver' border='0' />" CommandName="editar" HeaderText="Ver" >
                                <ItemStyle HorizontalAlign="Center" Width="1%" />
                                <ControlStyle Width="16px" Height="16px" />
                            </asp:ButtonField>

                        </Columns>
                    </asp:GridView>
                    <asp:Literal ID="litAviso" runat="server" EnableViewState="false" />

                    <div class="clearfix" style="margin-bottom:15px"></div>

                    
                        <div class="form-group">
                            <div class="col-xs-6 text-center">
                                <asp:Button ID="cmdVoltar" runat="server" Text="Voltar" SkinID="botaoPadraoWarning" OnClick="cmdVoltar_click"  />
                            </div>
                            <div class="col-xs-6 text-center">
                                <asp:Button ID="cmdNovo" Text="Nova" SkinID="botaoPadraoSUCCESSVerde" EnableViewState="false" runat="server" OnClick="lnkNovo_Click" />
                            </div>
                        </div>
                </div>
            </div>


        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
<%@ Page Theme="padrao" Language="C#" MasterPageFile="~/layout.master" AutoEventWireup="true" CodeFile="clientes.aspx.cs" Inherits="clientes" %>

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
    <script>


        function keepTextBoxFucused(id, clientId)
        {
            document.getElementById(clientId).value = id;
        }

        function focusOnTheEnd(clientId)
        {
            var textbox = document.getElementById(clientId);
            textbox.focus();
            textbox.value = textbox.value;

            textbox.selectionStart = textbox.selectionEnd = textbox.value.length;
        }

        function button_click(objTextBox, objBtnID, objTextBoxID, hiddenId)
        {
            document.getElementById(hiddenId).value = objTextBoxID;

            var key;
            if (window.event)
                key = window.event.keyCode;     //IE
            else
                key = e.which;                  //firefox

            //if (window.event.keyCode == 13)
            if (key == 13)
            {
                alert();
                //document.getElementById(objBtnID).focus();
                //document.getElementById(objBtnID).click();
                //event.keyCode = 0
                
                //document.getElementById(objTextBoxID).focus();
                myVar = window.setTimeout(setFocusOn, 1500);
                clearTimeout(myVar);
            }
        }

        function setFocusOn()
        {
            var textboxid = document.getElementById('ContentPlaceHolder1_txtTextBoxId').value;
            document.getElementById(textboxid).focus();
            document.getElementById('ContentPlaceHolder1_txtTextBoxId').value = '';
        }
    </script>
    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <input type="hidden" runat="server" id="txtTextBoxId" />
            <div class="panel panel-default">
                <div class="panel-heading text-right" style="position:relative;">
                    <%--<div style="position:absolute; right:0; top:0px;"><asp:Button ID="lnkNovo" Text="Novo" runat="server" EnableViewState="false" SkinID="botaoPadrao1" OnClick="lnkNovo_Click" /></div>--%>
                    <div class="col-xs-12">
                        <div class="row">
                            <label class="col-xs-2 text-left">Ficha:</label>
                            <label class="col-xs-4 text-left">Nome:</label>
                            <label class="col-xs-3 text-left">CPF:</label>
                        </div>
                        <div class="clearfix"></div>    
                        <div class="row">
                            <div class="col-xs-12">
                                <div class="col-xs-2"  style="padding-left:0px;">
                                      <asp:TextBox ID="txtFicha" onkeypress="filtro_SoNumeros(event);" Width="100%" SkinID="txtPadrao" MaxLength="20" runat="server" />
                                </div>
                                <div class="col-xs-4"  style="padding-left:0px;">
                                      <asp:TextBox ID="txtNome" Width="100%" SkinID="txtPadrao" runat="server" />
                                </div>
                                <div class="col-xs-3">
                                    <asp:TextBox ID="txtCPF" Width="100%" SkinID="txtPadrao" runat="server" />
                                </div>
                                <div class="col-xs-2">
                                    <asp:Button ID="cmdProcurar" Text="Procurar" SkinID="botaoPadrao1" EnableViewState="false" runat="server" OnClick="cmdProcurar_Click" />
                                </div>
                                <div class="col-xs-1">
                                    <asp:Button ID="cmdNovo" Text="Novo" SkinID="botaoPadraoSUCCESSVerde" EnableViewState="false" runat="server" OnClick="lnkNovo_Click" />
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
                        DataKeyNames="ID" onrowcommand="grid_RowCommand" 
                        onrowdatabound="grid_RowDataBound" PageSize="14"
                        OnPageIndexChanging="grid_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="Código" Visible="false">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NOME" HeaderText="Nome">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CPF" HeaderText="CPF">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>

                            <%--<asp:BoundField DataField="DT_TRAT_CONCLUIDO" HeaderText="Dt.Conclusão">
                                <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                            </asp:BoundField>--%>

                            <asp:ButtonField Text="<img src='Images/detail2.png' title='ficha' alt='ficha' border='0' />" CommandName="ficha" HeaderText="Fichas" >
                                <ItemStyle HorizontalAlign="Center" Width="1%" />
                                <HeaderStyle HorizontalAlign="Center" />
                                <ControlStyle Width="16px" Height="16px" />
                            </asp:ButtonField>

                            <asp:ButtonField Text="<img src='Images/edit.png' title='editar' alt='editar' border='0' />" CommandName="editar" HeaderText="Cadastro" >
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" Width="1%"/>
                                <ControlStyle Width="16px" Height="16px" />
                            </asp:ButtonField>

                            <%--<asp:ButtonField Text="<img src='../../images/edit.png' title='editar' alt='editar' border='0' />" CommandName="Editar" >
                                <ItemStyle Height="16px" Width="16px" />
                                <ControlStyle Height="16px" Width="16px" />
                            </asp:ButtonField>
                            <asp:ButtonField Text="<img src='../../images/delete.png' title='excluir' alt='excluir' border='0' />" CommandName="excluir" >
                                <ItemStyle Height="16px" Width="16px" />
                                <ControlStyle Height="16px" Width="16px" /> 
                            </asp:ButtonField>--%>
                        </Columns>
                    </asp:GridView>
                    <asp:Literal ID="litAviso" runat="server" EnableViewState="false" />
                </div>
            </div>


        </ContentTemplate>
    </asp:UpdatePanel>

<%--<span class="label label-default">Default</span>
<span class= "label label-primary">Primary</span>
<span class="label label-success">Success</span>
<span class="label label-info">Info</span>
<span class="label label-warning">Warning</span>
<span class="label label-danger">Danger</span>--%>
                        

</asp:Content>


<%@ Page Theme="padrao" Language="C#" MasterPageFile="~/layout.master" AutoEventWireup="true" CodeFile="ficha.aspx.cs" Inherits="ficha" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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

    <script src="Scripts/jquery.click-calendario-1.0-min.js"></script>
    <script src="Scripts/jquery.click-calendario-1.0.js"></script>

    <script src="Scripts/common.js"></script>
    <script src="Scripts/jquery-ui-1.10.4.custom.js"></script>
    <link href="Scripts/jquery-ui-1.10.4.custom.css" rel='stylesheet' type='text/css'/>


    <!-- Fonts -->
    <link href='http://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,900,300italic,400italic,600italic,700italic,900italic' rel='stylesheet' type='text/css'/>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:400,700' rel='stylesheet' type='text/css'/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:Literal runat="server" ID="litScript" />

    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>

            <div class="panel panel-default">
                <div class="panel-heading text-right" style="position:relative;">
                    <%--<div style="position:absolute; right:0; top:0px;"><asp:Button ID="lnkNovo" Text="Novo" runat="server" EnableViewState="false" SkinID="botaoPadrao1" OnClick="lnkNovo_Click" /></div>--%>

                    <div class="form-group">
                        <label class="col-xs-2 control-label">Nome: </label>
                        <div class="col-xs-4 text-left">
                            <asp:Literal ID="lblNome" Text="[]" runat="server"/>
                        </div>
                        <label class="col-xs-2 control-label">Ficha: </label>
                        <div class="col-xs-4 text-left">
                            <strong><asp:Literal ID="lblNumero" Text="[]" runat="server"/></strong>
                        </div>
                    </div>

                    <div class="clearfix"></div>

                    <%--<div class="form-group">
                        <label class="col-xs-2 control-label">Endereço: </label>
                        <div class="col-xs-4 text-left">
                            <asp:Literal ID="lblEndereco" Text="[]" runat="server"/>
                        </div>

                        <label class="col-xs-2 control-label">Bairro: </label>
                        <div class="col-xs-4 text-left">
                            <asp:Literal ID="lblBairro" Text="[]" runat="server"/>
                        </div>
                    </div>

                    <div class="clearfix"></div>

                    <div class="form-group">
                        <label class="col-xs-2 control-label">Cidade: </label>
                        <div class="col-xs-4 text-left">
                            <asp:Literal ID="lblCidade" Text="[]" runat="server"/>
                        </div>

                        <label class="col-xs-2 control-label">CEP: </label>
                        <div class="col-xs-4 text-left">
                            <asp:Literal ID="lblCEP" Text="[]" runat="server"/>
                        </div>
                    </div>

                    <div class="clearfix"></div>--%>

                    <div class="form-group">
                        <label class="col-xs-2 control-label">CPF: </label>
                        <div class="col-xs-4 text-left">
                            <asp:Literal ID="lblCPF" Text="[]" runat="server"/>
                        </div>

                        <label class="col-xs-2 control-label">DT NASC: </label>
                        <div class="col-xs-4 text-left">
                            <asp:Literal ID="lblDataNascimento" Text="[]" runat="server"/>
                        </div>
                    </div>

                    <div class="clearfix"></div>

                    <div class="form-group">
                        <label class="col-xs-2 control-label">Telefone: </label>
                        <div class="col-xs-4 text-left">
                            <asp:Literal ID="lblTelefone" Text="[]" runat="server"/>
                        </div>
                        <%--<label class="col-xs-2 control-label">Celular: </label>
                        <div class="col-xs-2 text-left">
                            <asp:Literal ID="lblCel" Text="[]" runat="server"/>
                        </div>--%>

                        <label class="col-xs-2 control-label">E-mail: </label>
                        <div class="col-xs-4 text-left">
                            <asp:Literal ID="litMail" Text="[]" runat="server"/>
                        </div>
                    </div>

                    <%--<div class="clearfix"></div>

                    <div class="form-group">
                        <label class="col-xs-2 control-label">E-mail: </label>
                        <div class="col-xs-6 text-left">
                            <asp:Literal ID="litMail" Text="[]" runat="server"/>
                        </div>
                    </div>--%>
                    <%--<div class="col-xs-12">

                        <div class="row">
                            <div class="col-xs-12">
                                <div class="col-xs-5"  style="padding-left:0px;">
                                      <asp:TextBox ID="txtNome" Width="100%" SkinID="txtPadrao" runat="server" />
                                </div>
                                <div class="col-xs-4">
                                    <asp:TextBox ID="txtCPF" Width="100%" SkinID="txtPadrao" runat="server" />
                                </div>
                                <div class="col-xs-2">
                                    <asp:Button ID="cmdProcurar" Text="Procurar" SkinID="botaoPadrao1" EnableViewState="false" runat="server" />
                                </div>
                                <div class="col-xs-1">
                                    <asp:Button ID="cmdNovo" Text="Novo" SkinID="botaoPadraoSUCCESSVerde" EnableViewState="false" runat="server" />
                                </div>
                            </div>

                        </div>
                    </div>--%>
                    <div class="clearfix"></div>
                </div>
                <div class="panel-body">
                    <%--<div class="clearfix"></div>--%>

                    <div class="form-group" runat="server" enableviewstate="false" visible="false">
                        <div class="col-xs-6 text-center">
                            <asp:Button SkinID="botaoPadraoWarning" ID="Button1" Text="Voltar" Width="80px" runat="server" OnClick="cmdVoltar_Click"/>
                        </div>
                        <div class="col-xs-6 text-center">
                            <asp:Button SkinID="botaoPadrao1" ID="Button2" Text="Gravar" Width="80px" runat="server" OnClick="cmdSalvar_Click"/>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                    <div class="clearfix"></div>

                    <div class="alert alert-success" role="alert">
                        <asp:Panel ID="pnlHideDate" runat="server" EnableViewState="false" Visible="false">
                            <div class="form-group">
                                <label class="col-xs-2 control-label text-left">Data: </label>
                                <div class="col-xs-3 text-left" style="top:-2px">
                                    <asp:TextBox SkinID="txtPadrao" ID="txtNovoData" Width="90" onkeypress="filtro_SoNumeros(event); mascara_DATA(this, event);" MaxLength="10" runat="server"/>
                                </div>
                            </div>

                            <div class="clearfix"></div>
                        </asp:Panel>

                        <div class="form-group">
                            <label class="col-xs-2 control-label text-left" style="top:4px">Especialidade: </label>
                            <div class="col-xs-2 text-left" style="top:-2px">
                                <asp:DropDownList SkinID="comboPadrao1" ID="cboEspecialidade" Width="98%" runat="server"/>
                            </div>
                            <div class="col-xs-3 text-left" style="top:4px">
                                <asp:CheckBox ID="chkNovaFichaClinica" Visible="false" AutoPostBack="true" OnCheckedChanged="chkNovaFichaClinica_CheckedChanged" ForeColor="Red" runat="server" Text="Nova ficha clínica" />
                            </div>
                            <label class="col-xs-1 control-label text-left" style="top:4px">Dentista</label>
                            <div class="col-xs-3 text-left" style="top:-2px">
                                <asp:DropDownList SkinID="comboPadrao1" ID="cboDentista" Width="100%" runat="server"/>
                            </div>
                        </div>

                        <div class="clearfix"></div>

                        <%--<div class="form-group">
                            <label class="col-xs-2 control-label text-left">Tratamento: </label>
                            <div class="col-xs-4 text-left" style="top:-2px">
                                <asp:TextBox SkinID="txtPadrao" ID="txtTratamento" Width="100%" MaxLength="500" runat="server"/>
                            </div>

                            <label class="col-xs-1 control-label text-left">Valor: </label>
                            <div class="col-xs-2 text-left" style="top:-2px">
                                <asp:TextBox SkinID="txtPadrao" ID="txtValor" Width="100%" MaxLength="15" runat="server"/>
                            </div>

                            <label class="col-xs-1 control-label text-left">QTD: </label>
                            <div class="col-xs-1 text-left" style="top:-2px">
                                <asp:TextBox SkinID="txtPadrao" ID="txtQTD" Width="100%" onkeypress="filtro_SoNumeros(event); " MaxLength="2" runat="server"/>
                            </div>
                        </div>
                        <div class="clearfix"></div>

                        <div class="form-group">
                            <label class="col-xs-2 control-label text-left">Valor Pago: </label>
                            <div class="col-xs-4 text-left" style="top:-2px">
                                <asp:TextBox SkinID="txtPadrao" ID="txtValorPago" Width="80px" MaxLength="15" runat="server"/>
                            </div>

                            <label class="col-xs-1 control-label text-left">Dentista</label>
                            <div class="col-xs-4 text-left" style="top:-2px">
                                <asp:DropDownList SkinID="comboPadrao1" ID="cboDentista" Width="100%" runat="server"/>
                            </div>
                        </div>--%>
                        <div class="clearfix"></div>

                        <%--<div class="form-group">
                            <div class="col-xs-12 text-center">
                                
                            </div>
                        </div>
                        <div class="clearfix"></div>--%>
                    </div>

                    <div class="alert alert-success" role="alert">
                        <div class="form-group">
                            <label class="col-xs-2 control-label text-left">Tipo:</label>
                            <div class="col-xs-5 text-left" style="top:-2px">
                                <asp:DropDownList ID="cboTipo" runat="server" SkinID="comboPadrao1" />
                                <asp:CheckBoxList ID="chklTipo" runat="server" Visible="false" EnableViewState="false" />
                            </div>
                        </div>

                        <div class="clearfix"></div>
                        <div class="form-group">
                            <label class="col-xs-2 control-label text-left">CPF do Pagador</label>
                            <div class="col-xs-2 text-left" >
                                <asp:TextBox ID="txtCPFPagador" SkinID="txtPadrao" MaxLength="14" Width="100%" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                    </div>

                    <div class="alert alert-success" role="alert">
                        
                        <!--Pagamento-->
                        <div class="form-group">
                            <label class="col-xs-2 control-label text-left">Pagamento:</label>

                            <div class="col-xs-1 text-right" style="margin-top:5px">Data</div>
                            <div class="col-xs-2 text-left">
                                <asp:TextBox SkinID="txtPadrao" ID="txtHistPagtoData" Width="90" onkeypress="filtro_SoNumeros(event); mascara_DATA(this, event);" Style="float:left;" MaxLength="10" runat="server"/>
                                <asp:Image ID="imgCalendar" ToolTip="calendário" CssClass="Float" Style="cursor:pointer; margin-left:5px; margin-top:5px;" ImageUrl="~/Images/calendar.png" runat="server" EnableViewState="false" />
                                <asp:CalendarExtender ID="ceDataPagto" TargetControlID="txtHistPagtoData" PopupButtonID="imgCalendar" runat="server" TodaysDateFormat="dd/MM/yyyy" Format="dd/MM/yyyy" EnableViewState="false"></asp:CalendarExtender>
                            </div>

                            <div class="col-xs-1 text-right" style="margin-top:2px">Forma</div>
                            <div class="col-xs-2 text-left">
                                <asp:DropDownList ID="cboTipoPagto" runat="server" SkinID="comboPadrao1" width="100%" AutoPostBack="true" OnSelectedIndexChanged="cboTipoPagto_SelectedIndexChanged" />
                            </div>

                            <div class="col-xs-1 text-right" style="margin-top:2px">R$</div>
                            <div class="col-xs-1 text-left">
                                <asp:TextBox ID="txtValorTipoPagto"  SkinID="txtPadrao" Text="0,00" MaxLength="20" Width="65px" runat="server"></asp:TextBox>
                            </div>

                            <div class="col-xs-2 text-left" style="margin-top:-3px">
                                <asp:Button ID="cmdAdicionarTipoPagto" Text="adicionar" SkinID="botaoPadraoSUCCESSVerde" runat="server" OnClick="cmdAdicionarTipoPagto_Click" />
                            </div>
                            
                        </div>

                        <asp:Panel ID="pnlTipoPagtoComplemento" runat="server" Visible="false">
                            <div class="form-group">
                                <label class="col-xs-2 control-label text-left"></label>
                                <div class="col-xs-1 text-right" style="margin-top:2px">Autorização</div>
                                <div class="col-xs-3 text-left">
                                    <asp:TextBox ID="txtTipoPagtoAutorizacao" onKeyPress="filtro_SoNumeros(event);" SkinID="txtPadrao" MaxLength="200" Width="100%" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </asp:Panel>
                        <div class="clearfix"></div>
                    </div>

                    <div class="alert alert-success" role="alert"> <!--Sumario-->
                        <asp:Panel ID="pnlPagamentoVerAntiga" runat="server" EnableViewState="false" Visible="false">
                        <div class="form-group">
                            <label class="col-xs-2 control-label text-left">Pagamento:</label>
                            <div class="col-xs-5 text-left" style="top:-2px">
                                <asp:DataList ID="dlFormaPagto" runat="server" OnItemDataBound="dlFormaPagto_ItemDataBound" OnItemCreated="dlFormaPagto_ItemCreated" >
                                    <HeaderTemplate>
                                        <table width="100%">
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td width="150px">
                                                <asp:Literal Text='<%# Eval("NOME") %>' runat="server"></asp:Literal>
                                                <asp:TextBox ID="txtID" Text='<%# Eval("ID") %>' Visible="false" runat="server"></asp:TextBox>
                                            </td>
                                            <td>R$ <asp:TextBox ID="txtValor"  SkinID="textboxSkin" Text="0,00" MaxLength="20" Width="85px" runat="server"></asp:TextBox></td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </table>
                                    </FooterTemplate>
                                </asp:DataList>
                            </div>
                            <div class="clearfix"></div>
                        </div>
                        </asp:Panel>

                        <div class="form-group">
                            <label class="col-xs-2 control-label text-left">Total Orçado:</label>
                            <div class="col-xs-2 text-left" style="top:-2px">
                                <asp:TextBox ID="txtTotalOrcado" runat="server" SkinID="txtPadrao" Width="85px" MaxLength="14" AutoPostBack="true" OnTextChanged="txtTotalOrcado_TextChanged" />
                            </div>

                            <label class="col-xs-2 control-label text-left">Valor Total:</label>
                            <div class="col-xs-2 text-left" style="top:-2px">
                                <asp:TextBox ID="txtValorTotal" runat="server" SkinID="txtPadrao" Width="85px" MaxLength="14" AutoPostBack="true" OnTextChanged="txtValorTotal_TextChanged" />
                            </div>

                            <label class="col-xs-2 control-label text-left">Saldo Devedor:</label>
                            <div class="col-xs-2 text-left" style="top:-2px">
                                <asp:TextBox ID="txtSaldoDevedor" ReadOnly="true" runat="server" SkinID="txtPadrao" Width="85px" MaxLength="14" />
                            </div>
                            <div class="clearfix"></div>
                        </div>

                        <div class="form-group" runat="server" enableviewstate="false" visible="false">
                            <label class="col-xs-2 control-label text-left">Observaçao:</label>
                            <div class="col-xs-10 text-left" style="top:-2px">
                                <asp:TextBox ID="txtObs" TextMode="MultiLine" runat="server" SkinID="txtPadrao" Width="100%" Rows="5" />
                            </div>
                        </div>
                        <%--<div style="clear:both;"></div>--%>
                    </div>

                    <div class="alert alert-success" role="alert"> <!--Historico de pagamento-->
                        
                        <div class="form-group">
                            <label class="col-xs-2 control-label text-left">Histórico de pagto.:</label>
                            <div class="col-xs-10 text-left" >
                                <asp:GridView  ID="gridTipoPagto" Style="margin-bottom:0px !important;" Width="100%" SkinID="gridPadrao"
                                    runat="server" AllowPaging="False" AutoGenerateColumns="False"  
                                    DataKeyNames="ID" OnRowDataBound="gridTipoPagto_RowDataBound" OnRowCommand="gridTipoPagto_RowCommand">
                                    <Columns>
                                        <asp:BoundField DataField="DESCR_FORMA" HeaderText="Forma" >
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="VALOR" HeaderText="Valor" DataFormatString="{0:N2}">
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="AUTORIZACAO" HeaderText="Autorização">
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="NOME_DENTISTA" HeaderText="Dentista" >
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="DATA" HeaderText="Data" DataFormatString="{0:dd/MM/yyyy}">
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:BoundField>

                                        <asp:ButtonField HeaderText="excluir" Text="<img src='Images/delete.png' title='excluir' width='16px' alt='ficha' border='0' />" CommandName="excluir" >
                                            <ItemStyle HorizontalAlign="Center" Width="1%" />
                                            <ControlStyle Width="16px" Height="16px" />
                                        </asp:ButtonField><%----%>

                                        <asp:ButtonField HeaderText="alterar" Text="<img src='Images/edit.png' title='editar' width='16px' alt='editar' border='0' />" CommandName="editar" >
                                            <ItemStyle HorizontalAlign="Center" Width="1%"/>
                                            <ControlStyle Width="16px" Height="16px" />
                                        </asp:ButtonField>

                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        <div style="clear:both;"></div>
                    </div>

                    <div class="form-group">
                        <div class="col-xs-6 text-center">
                            <asp:Button SkinID="botaoPadraoWarning" ID="cmdVoltar" OnClientClick="parent.window.scrollTo(0, 0);" Text="Voltar" Width="80px" runat="server" OnClick="cmdVoltar_Click"/>
                        </div>
                        <div class="col-xs-6 text-center">
                            <asp:Button SkinID="botaoPadrao1" ID="cmdSalvar" OnClientClick="parent.window.scrollTo(0, 0);" Text="Gravar" Width="80px" runat="server" OnClick="cmdSalvar_Click"/>
                        </div>
                    </div>
                    <div class="clearfix"></div>

                    <asp:GridView ID="grid" Width="100%" SkinID="gridPadrao"
                        runat="server" AllowPaging="True" AutoGenerateColumns="False"  
                        DataKeyNames="ID" PageSize="14">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="Código">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NOME" HeaderText="Nome">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CPF" HeaderText="CPF">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>

                            <asp:BoundField DataField="DT_TRAT_CONCLUIDO" HeaderText="Dt.Conclusão">
                                <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                            </asp:BoundField>

                            <asp:ButtonField Text="<img src='Images/detail2.png' title='ficha' alt='ficha' border='0' />" CommandName="ficha" >
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:ButtonField>

                            <asp:ButtonField Text="<img src='Images/edit.png' title='editar' alt='editar' border='0' />" CommandName="editar" >
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:ButtonField>

                        </Columns>
                    </asp:GridView>
                    <asp:Literal ID="litAviso" runat="server" EnableViewState="false" />
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
            //        target: '#ContentPlaceHolder1_txtHistPagtoData'
            //    });
            //});
        }


    /*
    http://www.tidbits.com.br/click-calendario-plugin-de-jquery-para-calendarios-em-portugues
    */
    </script>
</asp:Content>


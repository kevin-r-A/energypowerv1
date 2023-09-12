<%@ Page Title="Title" Language="C#" MasterPageFile="~/Site/Activos/cay.master" AutoEventWireup="true" CodeFile="AutorizaBaja.aspx.cs" Inherits="Site.Activos.AutorizaBaja" EnableEventValidation="false"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="../../Ctrl/Wait/wait.ascx" TagName="wait" TagPrefix="uc1" %>
<%@ Register Src="../../Ctrl/Msg/messbox.ascx" TagName="messbox" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        
        .auto-style1 {
            width: 76px;
        }
        .auto-style2 {
            width: 255px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="cph1">
    <asp:Panel ID="pancus" runat="server" CssClass="panmar"
                       GroupingText="Aprobación activos para la baja">
                <table cellspacing="0" class="panmar" width="100%">
                    <tr>
                        <td class="aatl" width="100%">
                            <asp:GridView ID="rgitems" runat="server"
                                          AlternatingRowStyle-CssClass="alt" CssClass="mGrid table table-hover"
                                          PagerStyle-CssClass="pgr" Font-Names="Arial Narrow" Font-Size="10pt" OnRowDataBound="rgitems_OnRowDataBound">
                                <HeaderStyle HorizontalAlign="Left"/>
                                <PagerStyle CssClass="pgr"/>
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ibaceptar" runat="server" CssClass="aacc" Height="30px"
                                                             ImageUrl="~/Img/m_s.png"
                                                             ToolTip="Aprobar" Width="30px" OnClick="ibaceptar_OnClick"/>
                                            <asp:ImageButton ID="ibrechazar" runat="server" CssClass="aacc" Height="30px"
                                                             ImageUrl="~/Img/m_e.png"
                                                             ToolTip="Rechazar" Width="30px" OnClick="ibrechazar_OnClick"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
    <uc2:messbox ID="messbox1" runat="server"/>
    <asp:ValidationSummary ID="vs" runat="server" ShowMessageBox="True"
                           ShowSummary="False"/>
    
    <asp:Label ID="Label2" runat="server"></asp:Label>
        <asp:ModalPopupExtender ID="mp2" runat="server"
            BackgroundCssClass="modalBackground" DynamicServicePath="" Enabled="True"
            PopupControlID="pan2" TargetControlID="Label2">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pan2" runat="server" Height="240px"
            Width="40%" Style="display: none">
            <%--style="display:none"--%>
            <asp:UpdatePanel ID="upbaja" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <table style="background-color: white; width: 100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="mess">
                                <table cellpadding="0" cellspacing="0" class="style1">
                                    <tr>
                                        <td width="10">&nbsp;</td>
                                        <td>
                                            <asp:Label ID="lblmp2" runat="server" ForeColor="White"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="panmar2">
                                    <table cellspacing="0" width="100%">
                                        <%--<tr>
                                            <td width="100">
                                                <h6>Id:</h6>
                                            </td>
                                            <td>
                                                <h6>
                                                    <asp:Label ID="lblid" runat="server"></asp:Label></h6>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="100">
                                                <h6>Tipo:</h6>
                                            </td>
                                            <td>
                                                <h6>
                                                    <asp:Label ID="lbltipo" runat="server"></asp:Label></h6>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h6>Razón Baja:<asp:RequiredFieldValidator ID="rfvtipo32" runat="server"
                                                    ControlToValidate="ddTipoBaja" ErrorMessage="Seleccione Razón de Baja"
                                                    ForeColor="Red" ValidationGroup="22">*</asp:RequiredFieldValidator></h6>
                                            </td>
                                            <td>
                                                <div class="form-group">
                                                    <asp:DropDownList ID="ddTipoBaja" runat="server" CssClass="txtdd" Width="110px">
                                                    </asp:DropDownList>
                                                    <asp:CascadingDropDown ID="cddTipoBaja" runat="server" Category="tbaja"
                                                        ContextKey="4" Enabled="True" LoadingText="[Cargando Tipo Baja...]"
                                                        PromptText="• Seleccione •" ServiceMethod="GetTipoBaja" ServicePath="ws.asmx"
                                                        TargetControlID="ddTipoBaja">
                                                    </asp:CascadingDropDown>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h6>Observaciones:</h6>
                                            </td>
                                            <td>
    
                                                <div class="form-group">
                                                    <telerik:RadTextBox ID="txtobsbaja" runat="server" Font-Names="Arial" CssClass="form-control"
                                                        Font-Size="9pt" MaxLength="150" Rows="5" TextMode="MultiLine" Width="100%">
    
                                                        <EmptyMessageStyle Font-Italic="True" />
                                                    </telerik:RadTextBox>
                                                </div>
                                            </td>
                                        </tr>--%>
                                        <tr>
                                            <td width="100">Adjunto:</td>
                                            <td>
                                                <asp:FileUpload ID="FileUpload1" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblmensaje" runat="server"></asp:Label>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td class="aatr">
                                                <asp:ImageButton ID="ibcancel" runat="server" Height="28px"
                                                    ImageUrl="~/Img/c1.png" OnClick="ibcancel_Click" Width="102px" />
                                                &nbsp;<asp:ImageButton ID="ibsave" runat="server" Height="28px"
                                                    ImageUrl="~/Img/s1.png" OnClick="ibsave_Click" ValidationGroup="22"
                                                    Width="102px" />
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>&nbsp;</td>
                                            <td class="aatr"></td>
                                        </tr>

                                    </table>
                                </div>
                            </td>
                        </tr>
                         <tr>
<td>
    <table cellpadding="0" cellspacing="0" class="style1">
        <thead>
        <tr>
            <th>Descripción</th>
            <th>Cuenta</th>
            <th>Oficina</th>
            <th>Centro de costo</th>
            <th>Debito</th>
            <th>Credito</th>
        </tr>
        </thead>
        <tbody>
        <tr>
            <td>Cuenta Baja</td>
            <td>
                <asp:Label runat="server" ID="lblCuentaBaja"></asp:Label>
            </td>
            <td>
                <asp:Label runat="server" ID="lblOficina1"></asp:Label>
            </td>
            <td>
                <asp:Label runat="server" ID="lblCentroCosto1"></asp:Label>
            </td>
            <td>
                <asp:Label runat="server" ID="lblDebito1"></asp:Label>
            </td>
            <td>
                <asp:Label runat="server" ID="lblCredito1"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Cuenta Activo</td>
            <td>
                <asp:Label runat="server" ID="lblCuentaActivo"></asp:Label>
            </td>
            <td>
                <asp:Label runat="server" ID="lblOficina2"></asp:Label>
            </td>
            <td>
                <asp:Label runat="server" ID="lblCentroCosto2"></asp:Label>
            </td>
            <td>
                <asp:Label runat="server" ID="lblDebito2"></asp:Label>
            </td>
            <td>
                <asp:Label runat="server" ID="lblCredito2"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Cuenta Depreciación</td>
            <td>
                <asp:Label runat="server" ID="lblCuentaDepre"></asp:Label>
            </td>
            <td>
                <asp:Label runat="server" ID="lblOficinaDepre1"></asp:Label>
            </td>
            <td>
                <asp:Label runat="server" ID="lblCentroCostoDepre1"></asp:Label>
            </td>
            <td>
                <asp:Label runat="server" ID="lblDebitoDepre1"></asp:Label>
            </td>
            <td>
                <asp:Label runat="server" ID="lblCreditoDepre1"></asp:Label>
            </td>
        </tr>
        </tbody>
    </table>
</td>        
    </tr>
                        <tr>
                            <td class="mess">&nbsp;</td>
                        </tr>
                    </table>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="ibsave" />
                </Triggers>
            </asp:UpdatePanel>
            <br />
        </asp:Panel>
    <script type="text/javascript">
    
        function OpenWindows(url) {
            window.open(url, " Reporte Ingreso Activo", "directories=no, location=no, menubar=no, scrollbars=yes, statusbar=no, tittlebar=no, width=300");
            window.focus();
        }

        function windowOpener(url, name, args) {
            if (typeof (popupWin) != "object") {
                popupWin = window.open(url, name, args);
            } else {
                if (!popupWin.closed) {
                    popupWin.location.href = url;
                } else {
                    popupWin = window.open(url, name, args);
                }
            }
            popupWin.focus();
        }
    </script>
</asp:Content>
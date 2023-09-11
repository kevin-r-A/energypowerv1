<%@ Page Title="" Language="C#" MasterPageFile="~/Site/Activos/cay.master" AutoEventWireup="true" CodeFile="Eliminar.aspx.cs" Inherits="Site_EliminaActivo_Eliminar" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="../../Ctrl/Wait/wait.ascx" TagName="wait" TagPrefix="uc1" %>
<%@ Register Src="../../Ctrl/Msg/messbox.ascx" TagName="messbox" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 147px;
        }
        .auto-style2 {
            width: 87px;
        }
        .auto-style5 {
            width: 122px;
        }
        .auto-style6 {
            width: 293px;
        }
        .auto-style7 {
            width: 125px;
        }
        .auto-style8 {
            width: 128px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="cph1">
    <script type="text/javascript">
        function KeyPress(sender, args) {
            var regexp = new RegExp("[0-9]{1}|[\b]|\t|\r");
            if (!args.get_keyCharacter().match(regexp))
                args.set_cancel(true);
        }
    </script>

    <asp:Panel ID="panbus0" runat="server" CssClass="panmar"
        GroupingText="Buscar Activo - Eliminar">
        <table cellpadding="0" cellspacing="0" class="panmar2">
            <tr>
                <td class="aatl">
                    <table cellspacing="0" class="style1">
                        <tr>
                            <td class="auto-style1">
                                <h5>Código Barras:<asp:RequiredFieldValidator
                                    ID="rfv1" runat="server" ControlToValidate="txtbuscb"
                                    ErrorMessage="Ingrese Código Barras" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="rfv1_ValidatorCalloutExtender" runat="server"
                                        Enabled="True" TargetControlID="rfv1" PopupPosition="BottomRight" WarningIconImageUrl="~/Img/warning.png">
                                    </asp:ValidatorCalloutExtender>
                                </h5>
                            </td>
                            <td width="160">
                                <div class="form-group">
                                    <telerik:RadTextBox ID="txtbuscb" runat="server" MaxLength="40" Width="150px" Height="25px" CssClass="form-control">

                                        <ClientEvents OnKeyPress="KeyPress" />
                                        <EmptyMessageStyle Font-Italic="True" />
                                    </telerik:RadTextBox>
                                </div>
                            </td>
                            <td width="22" valign="top">
                                <asp:ImageButton ID="ibbus1" runat="server" CssClass="relo" Height="35px"
                                    ImageUrl="~/Img/buscarblue.png" TabIndex="99"
                                    ToolTip="Buscar Código de Barras" ValidationGroup="1" Width="35px" OnClick="ibbus1_Click" />
                            </td>
                            <td class="aacr">
                                <asp:Label ID="lblmsg" runat="server" ForeColor="#009933"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <h5>Código Secundario:<asp:RequiredFieldValidator ID="rfv2" runat="server"
                                    ControlToValidate="txtbusid" ErrorMessage="Ingrese Código Secundario" ForeColor="Red"
                                    ValidationGroup="2">*</asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="rfv2_ValidatorCalloutExtender" runat="server"
                                        Enabled="True" TargetControlID="rfv2" PopupPosition="BottomRight" WarningIconImageUrl="~/Img/warning.png">
                                    </asp:ValidatorCalloutExtender>
                                </h5>
                            </td>
                            <td>
                                <div class="form-group">
                                    <telerik:RadTextBox ID="txtbusid" runat="server" MaxLength="50" Width="150px" Height="25px" CssClass="form-control">

                                        <%--<clientevents onkeypress="KeyPress" />--%>
                                        <EmptyMessageStyle Font-Italic="True" />
                                    </telerik:RadTextBox>
                                </div>
                            </td>
                            <td valign="top">
                                <asp:ImageButton ID="ibbus3" runat="server" CssClass="relo" Height="35px"
                                    ImageUrl="~/Img/buscarblue.png" TabIndex="99"
                                    ToolTip="Buscar Cod Secundario" ValidationGroup="2" Width="35px" OnClick="ibbus3_Click" />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <asp:Panel ID="Datos" runat="server" GroupingText="Información del Activo" CssClass="panmar" Visible="False">
        <div style="margin: 10px">
            <table>
                <tr>
                    <td style="font-weight: bold"><h5>Id:</h5></td>
                    <td>
                        <h5>&nbsp;&nbsp; <asp:Label ID="lbl_Id" runat="server" Text="[ID]"></asp:Label></h5>
                    </td>

                </tr>
                <tr>
                    <td style="font-weight: bold"><h5>Código de Barras:</h5></td>
                    <td>
                        <h5>&nbsp;&nbsp; <asp:Label ID="lbl_CodBarras" runat="server" Text="[Cod. Barras]"></asp:Label></h5>
                    </td>

                </tr>
            </table>
        </div>
    </asp:Panel>
    <br />

    <asp:Panel ID="Panel23" runat="server" GroupingText="Información Técnica y Ubicación" CssClass="panmar" Visible="False">
        <div style="margin: 10px">
            <table cellpadding="1" cellspacing="1" class="style1">
                <tr>
                    <td class="auto-style6">
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Img/a2.png" />
                    </td>
                    <td class="style3" width="310">
                        <asp:Image ID="Image3" runat="server" ImageUrl="~/Img/a3.png" />
                    </td>
                    <td width="310">
                        <asp:Image ID="Image4" runat="server" ImageUrl="~/Img/a4.png" />
                    </td>
                </tr>

                <tr>

                    <td class="auto-style6">
                        <asp:Panel ID="PanelTipo" runat="server" Width="100%">
                            <table>

                                <tr>
                                    <td class="auto-style2"><h5><strong>Grupo:</strong></h5></td>
                                    <td style="font-weight: bold">
                                        <h5><asp:Label ID="lbl_Grupo" runat="server" Text="[Grupo]"></asp:Label></h5>
                                    </td>
                                </tr>

                                <tr>
                                    <td class="auto-style2"><h5><strong>Subgrupo:</strong></h5></td>
                                    <td style="font-weight: bold">
                                        <h5><asp:Label ID="lbl_Subgrupo" runat="server" Text="[SubGrupo]"></asp:Label></h5>
                                    </td>
                                </tr>

                                <tr>
                                    <td class="auto-style2"><h5><strong>Descripción:</strong></h5></td>
                                    <td style="font-weight: bold">
                                        <h5><asp:Label ID="lbl_Descripcion" runat="server" Text="[Descripcion]"></asp:Label></h5>
                                    </td>



                                </tr>

                            </table>
                        </asp:Panel>
                    </td>

                    <td class="style4">
                        <asp:Panel ID="Panel_Ubi" runat="server" Width="100%">
                            <table>

                                <tr>
                                    <td class="auto-style8"><h5><strong>Geográfica 1:</strong></h5></td>
                                    <td style="font-weight: bold">
                                        <h5><asp:Label ID="lbl_UbGeo1" runat="server" Text="[Ubicación Geografica 1]"></asp:Label></h5>
                                    </td>
                                </tr>

                                <tr>
                                    <td class="auto-style8"><h5><strong>Ub. Geográfica 2:</strong></h5></td>
                                    <td style="font-weight: bold">
                                        <h5><asp:Label ID="lbl_UbiGeo2" runat="server" Text="[Ubicación Geografica 2]"></asp:Label></h5>
                                    </td>
                                </tr>

                                <tr>
                                    <td class="auto-style8"><h5><strong>Ub. Geográfica 3:</strong></h5></td>
                                    <td style="font-weight: bold">
                                        <h5><asp:Label ID="lbl_UbiGeo3" runat="server" Text="[Ubicación Geografica 3]"></asp:Label></h5>
                                    </td>
                                </tr>
                            </table>

                        </asp:Panel>


                    </td>



                    <td class="style4">
                        <asp:Panel ID="PanelUbiOrg" runat="server" Width="100%">
                            <table>
                                <tr>
                                    <td class="auto-style7"><h5><strong>Centro de costo:</strong></h5></td>
                                    <td style="font-weight: bold">
                                        <h5><asp:Label ID="lbl_ceCosto" runat="server" Text="[Centro de costo]"></asp:Label></h5>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style7"><h5><strong>Ubi. Orgánica 2:</strong></h5></td>
                                    <td style="font-weight: bold">
                                        <h5><asp:Label ID="lbl_UbiOrg" runat="server" Text="[Ubi. Organica]"></asp:Label></h5>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style7"><h5><strong>Custodio:</strong></h5></td>
                                    <td style="font-weight: bold">
                                        <h5><asp:Label ID="lbl_custodio" runat="server" Text="[Custodio]"></asp:Label></h5>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>

            </table>
        </div>
    </asp:Panel>
    <br />
    <asp:Panel ID="panCommand" runat="server" CssClass="aabrpan"
        Height="33px" Width="100%">
        <div class="panmar3">
            &nbsp;&nbsp;<asp:ImageButton ID="ibcancel" runat="server" CausesValidation="False"
                Height="28px" ImageUrl="~/Img/c1.png" OnClick="ibcancel_Click" Width="102px" />
            &nbsp;<asp:ImageButton ID="ibsave" runat="server" Height="28px"
                ImageUrl="~/Img/elimina2.png" OnClick="ibsave_Click" Width="102px" />
        </div>
    </asp:Panel>
    <asp:AlwaysVisibleControlExtender ID="avcePanCommand" runat="server"
        Enabled="True" TargetControlID="panCommand" VerticalSide="Bottom">
    </asp:AlwaysVisibleControlExtender>
    <uc2:messbox ID="messbox1" runat="server" />

</asp:Content>

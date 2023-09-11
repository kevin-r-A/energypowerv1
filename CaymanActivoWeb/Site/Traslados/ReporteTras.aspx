<%@ Page Title="" Language="C#" MasterPageFile="~/Site/Activos/cay.master" AutoEventWireup="true" CodeFile="ReporteTras.aspx.cs" Inherits="ReporteTras" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="../../Ctrl/Wait/wait.ascx" TagName="wait" TagPrefix="uc1" %>
<%@ Register Src="../../Ctrl/Msg/messbox.ascx" TagName="messbox" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .relo {
        }

        .auto-style2 {
            width: 139px;
        }
        .auto-style3 {
            width: 176px;
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
    <asp:Panel ID="panbus" runat="server" CssClass="panmar"
        GroupingText="Buscar Activo - Traslados">
        <table cellpadding="0" cellspacing="0" class="panmar2">
            <tr>
                <td class="aatl">
                    <table cellspacing="0" width="100%">
                        <tr>
                            <td class="auto-style3">
                                <h4>Código de Barras:<asp:RequiredFieldValidator
                                    ID="rfv1" runat="server" ControlToValidate="txtbuscb"
                                    ErrorMessage="Ingrese Código de Barras" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="rfv1_ValidatorCalloutExtender" runat="server"
                                        Enabled="True" TargetControlID="rfv1" PopupPosition="BottomRight" WarningIconImageUrl="~/Img/warning.png">
                                    </asp:ValidatorCalloutExtender>
                                </h4>
                            </td>
                            <td width="160">
                                <div class="form-group">
                                    <telerik:RadTextBox ID="txtbuscb" runat="server"
                                        MaxLength="40" Width="150px" CssClass="form-control" Height="25px">

                                        <ClientEvents OnKeyPress="KeyPress" />
                                        <EmptyMessageStyle Font-Italic="True" />
                                    </telerik:RadTextBox>
                                </div>
                            </td>
                            <td>
                                <asp:ImageButton ID="ibbus1" runat="server"
                                    CssClass="relo" Height="35px"
                                    ImageUrl="~/Img/buscarblue.png" OnClick="ibbus1_Click" TabIndex="99"
                                    ToolTip="Buscar Código de Barras" ValidationGroup="1" Width="35px" /></td>
                        </tr>
                        <tr>
                            <td class="auto-style3">
                                <h4>Código Secundario:<asp:RequiredFieldValidator ID="rfv2" runat="server"
                                ControlToValidate="txtbusid" ErrorMessage="Ingrese Codigo Secundario" ForeColor="Red" 
                                ValidationGroup="2">*</asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="rfv2_ValidatorCalloutExtender" runat="server"
                                    Enabled="True" TargetControlID="rfv2" PopupPosition="BottomRight" WarningIconImageUrl="~/Img/warning.png">
                                </asp:ValidatorCalloutExtender>
                                    </h4>
                            </td>
                            <td>
                                <telerik:RadTextBox ID="txtbusid" runat="server" MaxLength="40" Width="150px" Height="25px">
                                   
                                    <%--<ClientEvents OnKeyPress="KeyPress" />--%>
                                    <EmptyMessageStyle Font-Italic="True" />
                                </telerik:RadTextBox></td>
                            <td>
                                <asp:ImageButton ID="ibbus3" runat="server" CssClass="relo" Height="35px"
                                    ImageUrl="~/Img/buscarblue.png" TabIndex="99" ToolTip="Buscar Cod Secundario" ValidationGroup="2"
                                    Width="35px" OnClick="ibbus3_Click" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pantras" runat="server" CssClass="panmar"
        GroupingText="Reporte de Traslados" Visible="False">
        <table cellspacing="0" width="100%">
            <tr>
                <td>
                    <asp:ImageButton ID="ibxls1" runat="server" CssClass="style29" Height="30px"
                        ImageUrl="~/Img/xls1.png" OnClick="ibxls1_Click" Width="122px" />
                </td>
            </tr>
            <tr>
                <td width="100%">
                    <asp:UpdatePanel ID="uptras" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div id="id_grid" style="overflow: scroll; height: 700px; width:100%">
                                <asp:GridView ID="rgtras" runat="server"
                                    AlternatingRowStyle-CssClass="alt" CssClass="mGrid" GridLines="None"
                                    PagerStyle-CssClass="pgr" Font-Names="Arial" Font-Size="9pt" Width="150%">
                                    <AlternatingRowStyle CssClass="alt" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <PagerSettings FirstPageText="Primera" LastPageText="Ultima"
                                        PageButtonCount="30" />
                                    <PagerStyle CssClass="pgr" />
                                </asp:GridView>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <uc2:messbox ID="messbox1" runat="server" />
</asp:Content>



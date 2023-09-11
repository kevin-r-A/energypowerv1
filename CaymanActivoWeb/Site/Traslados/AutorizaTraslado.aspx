<%@ Page Title="Title" Language="C#" MasterPageFile="~/Site/Activos/cay.master" AutoEventWireup="true" CodeFile="AutorizaTraslado.aspx.cs" Inherits="Site.Traslados.AutorizaTraslado" EnableEventValidation="false"%>


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

    <script type="text/javascript">
        function OpenWindows(url) {
            window.open(url, " Reporte Modifica Activo", "directories=no, location=no, menubar=no, scrollbars=yes, statusbar=no, tittlebar=no");
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
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="cph1">
    <asp:Panel ID="pancus" runat="server" CssClass="panmar"
                       GroupingText="Aprobación activos para el traslado">
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

</asp:Content>
<%@ Page Title="" Language="C#" MasterPageFile="~/Site/Activos/cay.master" AutoEventWireup="true" CodeFile="ReporteInv.aspx.cs" Inherits="ReporteInv" EnableEventValidation="false" %>

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

    <asp:UpdatePanel ID="upGrillaItems" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="pancus" runat="server" CssClass="panmar"
                GroupingText="Items de Inventario Movil">
                <table cellspacing="0" class="panmar" width="100%">
                    <tr>
                        <td class="aatl" width="100%">
                            <table style="width: 100%">
                                <tr>
                                    <td valign="top">
                                        <asp:ImageButton ID="ibpdf1" runat="server" Height="30px" ImageUrl="~/Img/pdf1.png" OnClick="ibpdf1_Click" Width="122px"  />
                                    </td>
                                </tr>
                            </table>
                            <table cellspacing="0" class="style1">
                                <tr>
                                    <td align="left">
                                        <asp:ImageButton ID="ibxls1" runat="server" Height="30px"
                                            ImageUrl="~/Img/xls1.png" OnClick="ibxls1_Click" Width="122px"/>
                                        &nbsp;&nbsp;<asp:Label ID="lblerrorpdf" runat="server"></asp:Label>
                                    </td>
                                    <td style="width: 90%">
                                        <div style="text-align:center">
                                            <h3>Total: Conciliados: <asp:Label ID="lblConcil" runat="server" Text="0"></asp:Label> Faltantes: <asp:Label ID="lblFalt" runat="server" Text="0"></asp:Label> Sobrantes: <asp:Label ID="lblSobrantes" runat="server" Text="0"></asp:Label> </h3>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                            <asp:UpdatePanel ID="upgrid" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:GridView ID="rgitems" runat="server"
                                        AlternatingRowStyle-CssClass="alt" CssClass="mGrid table table-hover"
                                        PagerStyle-CssClass="pgr" Font-Names="Arial Narrow" Font-Size="10pt" OnRowDataBound="rgitems_RowDataBound">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <PagerStyle CssClass="pgr" />
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="ibxls1" />
        </Triggers>
    </asp:UpdatePanel>

    <uc2:messbox ID="messbox1" runat="server" />
    <asp:ValidationSummary ID="vs" runat="server" ShowMessageBox="True"
        ShowSummary="False" />

</asp:Content>



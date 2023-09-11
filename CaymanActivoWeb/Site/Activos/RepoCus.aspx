<%@ Page Title="" Language="C#" MasterPageFile="~/Site/Activos/cay.master" AutoEventWireup="true" CodeFile="RepoCus.aspx.cs" Inherits="RepoCus" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="../../Ctrl/Wait/wait.ascx" TagName="wait" TagPrefix="uc1" %>
<%@ Register Src="../../Ctrl/Msg/messbox.ascx" TagName="messbox" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style22 {
            width: 116px;
        }

        .style23 {
            width: 109px;
        }

        .auto-style1 {
            width: 116px;
            height: 57px;
        }

        .auto-style2 {
            height: 57px;
        }
    </style>

    <script type="text/javascript">
        function OpenWindows(url, name, args) {
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
    <asp:Panel ID="panbus" runat="server" CssClass="panmar" GroupingText="Seleccionar Custodios">
        <table cellspacing="0" width="100%">
            <tr>
                <td class="style22" style="font-weight: bold">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="style22" style="font-weight: bold">Fecha de Ingreso:</td>
                <td>
                    <telerik:RadDatePicker ID="datefechaingreso" runat="server" EnableTyping="False" MaxDate="2099-01-01" MinDate="1940-01-01" Width="120px" ZIndex="0">
                        <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                        </Calendar>
                        <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" ReadOnly="True">
                        </DateInput>
                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                    </telerik:RadDatePicker>
                    <asp:CheckBox ID="chboxTodos" runat="server" Text="Por Fecha" AutoPostBack="True" OnCheckedChanged="chboxTodos_CheckedChanged" />
                </td>
            </tr>
            <tr>
                <td class="style22" style="font-weight: bold">Custodio:</td>
                <td>
                    <asp:DropDownList ID="ddCustodio" runat="server" AutoPostBack="True" CssClass="txtdd" OnSelectedIndexChanged="ddCustodio_SelectedIndexChanged" Width="280px" EnableViewState="true" ClientIDMode="Static" AppendDataBoundItems="true">
                    </asp:DropDownList>
                    <asp:CascadingDropDown ID="cddCustodio" runat="server" Category="cus" Enabled="True" LoadingText="[Cargando Custodios...]" PromptText="• Todos •" ServiceMethod="GetCustodio" ServicePath="ws.asmx" TargetControlID="ddCustodio">
                    </asp:CascadingDropDown>
                </td>
            </tr>
            <tr>
                <td class="style22">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblDatosReporte" runat="server" Text="Datos Acta:" Font-Bold="True" Width="100%"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table style="width: 100%">
                        <tr>
                            <td class="style23">
                                <asp:Label ID="Ubigeo1" runat="server"
                                    Text="Ub. Geográfica 1:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddUge1" runat="server" CssClass="txtdd" Width="25%">
                                </asp:DropDownList>
                                <asp:CascadingDropDown ID="cddgeo1" runat="server" Category="uge1"
                                    Enabled="True" LoadingText="[Cargando Geo1...]" PromptText="• Seleccione •"
                                    ServiceMethod="GetUge1" ServicePath="ws.asmx" TargetControlID="ddUge1">
                                </asp:CascadingDropDown>
                            </td>
                        </tr>
                        <tr>
                            <td class="style23">
                                <asp:Label ID="lblUbigeo2" runat="server" Text="Ub. Geográfica 2:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddUge2" runat="server" CssClass="txtdd" Width="25%">
                                </asp:DropDownList>
                                <asp:CascadingDropDown ID="cddgeo2" runat="server" Category="uge2"
                                    Enabled="True" LoadingText="[Cargando Geo2...]" ParentControlID="ddUge1"
                                    PromptText="• Seleccione •" ServiceMethod="GetUge2" ServicePath="ws.asmx"
                                    TargetControlID="ddUge2">
                                </asp:CascadingDropDown>
                            </td>
                        </tr>
                        <tr>
                            <td class="style23">
                                <asp:Label ID="lblUbigeo3" runat="server" Text="Ub. Geográfica 3:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddUge3" runat="server" CssClass="txtdd" Width="25%">
                                </asp:DropDownList>
                                <asp:CascadingDropDown ID="cddgeo3" runat="server" Category="uge3"
                                    Enabled="True" LoadingText="[Cargando Geo3...]" ParentControlID="ddUge2"
                                    PromptText="• Seleccione •" ServiceMethod="GetUge3" ServicePath="ws.asmx"
                                    TargetControlID="ddUge3">
                                </asp:CascadingDropDown>
                            </td>
                        </tr>
                        <tr>
                            <td class="style23">
                                <asp:Label ID="lblpiso" runat="server" Text="Piso/Nivel:">
                                </asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddPiso" runat="server" CssClass="txtdd" Width="25%">
                                </asp:DropDownList>
                                <asp:CascadingDropDown ID="cddpiso" runat="server" Category="pis_id"
                                    Enabled="True" LoadingText="[Cargando Piso...]" ParentControlID="ddUge3"
                                    PromptText="• Seleccione •" ServiceMethod="GetUge4" ServicePath="ws.asmx"
                                    TargetControlID="ddPiso">
                                </asp:CascadingDropDown>
                            </td>
                        </tr>
                        <tr>
                            <td class="style23">Centro Costo:</td>
                            <td>
                                <asp:DropDownList ID="ddCcosto" runat="server"
                                    CssClass="txtdd" Width="25%">
                                </asp:DropDownList>
                                <asp:CascadingDropDown ID="cddccosto" runat="server" Category="cco"
                                    Enabled="True" LoadingText="[Cargando Centro de Costo...]" PromptText="• Seleccione •"
                                    ServicePath="ws.asmx" TargetControlID="ddCcosto">
                                </asp:CascadingDropDown>
                            </td>
                        </tr>
                        <%--<tr>
                                                <td class="style23">
                                                    Ub. Orgánica 1:</td>
                                                <td>
                                                    <asp:DropDownList ID="ddUor1" runat="server" ClientIDMode="Static" 
                                                        CssClass="txtdd" Width="25%">
                                                    </asp:DropDownList>
                                                    <asp:CascadingDropDown ID="cdduor1" runat="server" Category="uor1" 
                                                        Enabled="True" LoadingText="[Cargando Dep1...]" PromptText="• Seleccione •" 
                                                        ServicePath="ws.asmx" TargetControlID="ddUor1">
                                                    </asp:CascadingDropDown>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style23">
                                                    Ub. Orgánica 2:</td>
                                                <td>
                                                    <asp:DropDownList ID="ddUor2" runat="server" ClientIDMode="Static" 
                                                        CssClass="txtdd" Width="25%">
                                                    </asp:DropDownList>
                                                    <asp:CascadingDropDown ID="cdduor2" runat="server" Category="uor2" 
                                                        Enabled="True" LoadingText="[Cargando Dep2...]" ParentControlID="ddUor1" 
                                                        PromptText="• Seleccione •" ServiceMethod="GetUor2" ServicePath="ws.asmx" 
                                                        TargetControlID="ddUor2">
                                                    </asp:CascadingDropDown>
                                                </td>
                                            </tr>--%>
                        <tr>
                            <td class="style23">Ub. Orgánica 1:</td>
                            <td>
                                <asp:DropDownList ID="ddUor1" runat="server" CssClass="txtdd"
                                    Width="25%">
                                </asp:DropDownList>
                                <asp:CascadingDropDown ID="cdduor1" runat="server" Category="uor1"
                                    Enabled="True" LoadingText="[Cargando Dep1...]" PromptText="• Seleccione •"
                                    ServicePath="ws.asmx" TargetControlID="ddUor1">
                                </asp:CascadingDropDown>
                            </td>
                        </tr>
                        <tr>
                            <td class="style23">Ub. Orgánica 2:</td>
                            <td>
                                <asp:DropDownList ID="ddUor2" runat="server"
                                    CssClass="txtdd"
                                    Width="25%">
                                </asp:DropDownList>
                                <asp:CascadingDropDown ID="cdduor2" runat="server" Category="uor2"
                                    Enabled="True" LoadingText="[Cargando Dep2...]" ParentControlID="ddUor1"
                                    PromptText="• Seleccione •" ServiceMethod="GetUor2" ServicePath="ws.asmx"
                                    TargetControlID="ddUor2">
                                </asp:CascadingDropDown>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>

    <asp:UpdatePanel ID="upGrillaItems" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="pancus" runat="server" CssClass="panmar"
                GroupingText="Items bajo su cargo" Visible="False">
                <table cellspacing="0" class="panmar" width="100%">
                    <tr>
                        <td class="aatl" width="100%">
                            <table cellspacing="0" class="style1">
                                <tr>
                                    <td class="aatr">
                                        <asp:ImageButton ID="ibxls1" runat="server" Height="30px"
                                            ImageUrl="~/Img/xls1.png" OnClick="ibxls1_Click" Width="122px" />
                                        &nbsp;<asp:ImageButton ID="ibpdf1" runat="server" Height="30px"
                                            ImageUrl="~/Img/pdf1.png" OnClick="ibpdf1_Click" Width="112px" />
                                        <%--&nbsp;<asp:ImageButton ID="ibcorreo" runat="server" Height="30px" 
                                    ImageUrl="~/Img/cor1.png" Width="144px" />--%>
                                &nbsp;
                                <%--&nbsp;<asp:Label ID="lblerrorpdf" runat="server"></asp:Label>--%>
                                    </td>
                                </tr>
                            </table>
                            <asp:UpdatePanel ID="upgrid" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:GridView ID="rgitems" runat="server"
                                        AlternatingRowStyle-CssClass="alt" CssClass="mGrid"
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
            <asp:AsyncPostBackTrigger ControlID="ddCustodio" EventName="SelectedIndexChanged" />

        </Triggers>
    </asp:UpdatePanel>

    <uc2:messbox ID="messbox1" runat="server" />
    <asp:ValidationSummary ID="vs" runat="server" ShowMessageBox="True"
        ShowSummary="False" />

</asp:Content>



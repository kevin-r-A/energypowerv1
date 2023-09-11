<%@ Page Title="" Language="C#" MasterPageFile="~/Site/Activos/cay.master" AutoEventWireup="true" CodeFile="RepoInclusion.aspx.cs" Inherits="RepoCus" EnableEventValidation="false" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register src="../../Ctrl/Wait/wait.ascx" tagname="wait" tagprefix="uc1" %>
<%@ Register src="../../Ctrl/Msg/messbox.ascx" tagname="messbox" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style23
        {
            width: 109px;
        }
        .style25
        {
            width: 217px;
        }
        .style27
        {
            width: 144px;
        }
        .style28
        {
            width: 183px;
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
<asp:Content ID="Content2" runat="server" contentplaceholderid="cph1">
    <asp:Panel ID="panbus" runat="server" CssClass="panmar" 
        GroupingText="Reporte Inclusión de Seguros">
                           <%-- <asp:UpdatePanel ID = "upCus" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>--%>
                            <table cellspacing="0" width="100%">
                                <tr>
                                    <td style="font-weight:bold">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <table style="width:100%">
                                            <tr>
                                                <td class="style23">
                                                    &nbsp;</td>
                                                <td class="style28">
                                                    <asp:Label ID="lblf0" runat="server" Font-Bold="True" Text="Desde"></asp:Label>
                                                </td>
                                                <td class="style27">
                                                    <asp:Label ID="lblf1" runat="server" Font-Bold="True" Text="Hasta"></asp:Label>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="style23">
                                                    <asp:Label ID="lblf" runat="server" Font-Bold="True" Text="Fechas:"></asp:Label>
                                                </td>
                                                <td class="style28">
                                                    <telerik:RadDatePicker ID="rdp_Desde" Runat="server">
                                                    </telerik:RadDatePicker>
                                                </td>
                                                <td class="style27">
                                                    <telerik:RadDatePicker ID="rdp_Hasta" Runat="server">
                                                    </telerik:RadDatePicker>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="style23">
                                                    &nbsp;</td>
                                                <td class="style28">
                                                    &nbsp;</td>
                                                <td class="style27">
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="style23">
                                                    &nbsp;</td>
                                                <td class="style28">
                                                    <asp:ImageButton ID="btnBuscar" runat="server" Height="29px" 
                                                        ImageUrl="~/Img/btnbuscar11.png" onclick="btnBuscar_Click" Width="86px" />
                                                </td>
                                                <td class="style27">
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="style23">
                                                    &nbsp;</td>
                                                <td class="style28">
                                                    &nbsp;</td>
                                                <td class="style27">
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
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
                                                <td class="style23">
                                                    &nbsp;</td>
                                                <td class="style28">
                                                    &nbsp;</td>
                                                <td class="style27">
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="style23">
                                                    &nbsp;</td>
                                                <td class="style28">
                                                    &nbsp;</td>
                                                <td class="style27">
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>

                            <%--<table cellspacing="0" width="400" class="panmar2">
                                <tr>
                                    <td class="style21">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style21">
                                        <asp:Label ID="lblDatosReporte" runat="server" Font-Bold="True" 
                                            Text="Datos Acta:"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style21">
                                        <asp:Label ID="Ubigeo1" runat="server" Text="Ub. Geográfica 1:"></asp:Label>
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
                                    <td class="style21">
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
                                    <td class="style21">
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
                                    <td class="style21">Piso/Nivel:</td>
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
                                    <td class="style21">
                                        Centro de Costo:</td>
                                    <td>
                                        <asp:DropDownList ID="ddCcosto" runat="server" CssClass="txtdd" Width="100%">
                                        </asp:DropDownList>
                                        <asp:CascadingDropDown ID="cddccosto" runat="server" Category="cco" 
                                            Enabled="True" LoadingText="[Cargando Centro de Costo...]" 
                                            PromptText="• Seleccione •" ServicePath="ws.asmx" TargetControlID="ddCcosto">
                                        </asp:CascadingDropDown>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style21">
                                        Ub. Orgánica 1:</td>
                                    <td >
                                        <asp:DropDownList ID="ddUor1" runat="server" CssClass="txtdd" Height="21px" 
                                            Width="25%">
                                        </asp:DropDownList>
                                        <asp:CascadingDropDown ID="cdduor1" runat="server" Category="uor1" 
                                            Enabled="True" LoadingText="[Cargando Dep1...]" PromptText="• Seleccione •" 
                                            ServicePath="ws.asmx" TargetControlID="ddUor1">
                                        </asp:CascadingDropDown>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style21">
                                        Ub. Orgánica 2:</td>
                                    <td >
                                        <asp:DropDownList ID="ddUor2" runat="server" CssClass="txtdd" Height="21px" 
                                            Width="25%" onselectedindexchanged="ddUor2_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>
                                        <asp:CascadingDropDown ID="cdduor2" runat="server" Category="uor2" 
                                            Enabled="True" LoadingText="[Cargando Dep2...]" ParentControlID="ddUor1" 
                                            PromptText="• Seleccione •" ServiceMethod="GetUor2" ServicePath="ws.asmx" 
                                            TargetControlID="ddUor2">
                                        </asp:CascadingDropDown>
                                        <asp:CheckBox ID="chktodosU" runat="server" 
                                            oncheckedchanged="chktodosU_CheckedChanged" 
                                            Text="Todos los bienes que tenga registrados "  AutoPostBack="true"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style21">
                                        Custodio:</td>
                                    <td>
                                        <asp:DropDownList ID="ddCustodio" runat="server" AutoPostBack="true" 
                                            CssClass="txtdd" onselectedindexchanged="ddCustodio_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:CascadingDropDown ID="ddCustodio_CascadingDropDown" runat="server" 
                                            Category="cus" Enabled="True" LoadingText="[Cargando Custodios...]" 
                                            ParentControlID="ddUor1" PromptText="• Todos •" ServiceMethod="GetCusUorg1" 
                                            ServicePath="ws.asmx" TargetControlID="ddCustodio">
                                        </asp:CascadingDropDown>
                                        <asp:RequiredFieldValidator ID="rfvtipo11" runat="server" ControlToValidate="ddCustodio" ErrorMessage="Seleccione Custodio" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="vceCus" TargetControlID="rfvtipo11" runat="server"></asp:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style21">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>--%>

                            <%--</ContentTemplate>
                            </asp:UpdatePanel>--%>
                            
    </asp:Panel>

        <asp:UpdatePanel ID = "upGrillaItems" runat="server" UpdateMode="Conditional">
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
                                    ImageUrl="~/Img/xls1.png" onclick="ibxls1_Click" Width="122px" 
                                    Visible="False" />
                                &nbsp;<asp:ImageButton ID="ibpdf1" runat="server" Height="30px" 
                                    ImageUrl="~/Img/pdf1.png" onclick="ibpdf1_Click" Width="112px" />
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
                                PagerStyle-CssClass="pgr" Font-Names="Arial Narrow" Font-Size="10pt">
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
        <%--<Triggers>
            <asp:PostBackTrigger ControlID="ibxls1" />
            <asp:AsyncPostBackTrigger ControlID="ddCustodio" EventName="SelectedIndexChanged" />
        </Triggers>--%>
        </asp:UpdatePanel> 
    
    <uc2:messbox ID="messbox1" runat="server" />
    <asp:ValidationSummary ID="vs" runat="server" ShowMessageBox="True" 
        ShowSummary="False" />
    
</asp:Content>



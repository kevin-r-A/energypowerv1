<%@ Page Title="" Language="C#" MasterPageFile="~/Site/Activos/cay.master" AutoEventWireup="true" CodeFile="AsignarPpc.aspx.cs" Inherits="AsignarPpc" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="../../Ctrl/Wait/wait.ascx" TagName="wait" TagPrefix="uc1" %>
<%@ Register Src="../../Ctrl/Msg/messbox.ascx" TagName="messbox" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <asp:Panel ID="Panel1" runat="server" CssClass="panmar"
        GroupingText="Filtrar y Asignar Activos a Dispositivo Movil">
        <table class="panmar">
            <tr>
                <td>
                    <table cellspacing="0" class="style1">
                        <tr>
                            <td>
                                <table cellpadding="0" cellspacing="0" class="style1">
                                    <tr>
                                        <td align="right" class="ba3" height="30">
                                            <asp:ImageButton ID="ibgr2" runat="server" CausesValidation="False"
                                                CssClass="relo" Height="18px" ImageUrl="~/Img/rl1.png" TabIndex="99"
                                                ToolTip="Actualizar Clasificación" Width="21px" />
                                        </td>
                                        <td align="right" class="ba4">
                                            <asp:ImageButton ID="ibgr3" runat="server" CausesValidation="False"
                                                CssClass="relo" Height="18px" ImageUrl="~/Img/rl1.png" TabIndex="99"
                                                ToolTip="Actualizar Clasificación" Width="21px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="aatl" width="40%">
                                            <div class="divv">
                                                <asp:UpdatePanel ID="upgeo" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <table cellpadding="2" cellspacing="0" class="style1">
                                                            <tr>
                                                                <td class="style2" width="100">Ub. Geográfica 1:</td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddUge1" runat="server" CssClass="txtdd" Width="100%">
                                                                    </asp:DropDownList>
                                                                    <asp:CascadingDropDown ID="cddgeo1" runat="server" Category="uge1"
                                                                        Enabled="True" LoadingText="[Cargando Geo1...]" PromptText="• Seleccione •"
                                                                        ServiceMethod="GetUge1" ServicePath="ws.asmx" TargetControlID="ddUge1">
                                                                    </asp:CascadingDropDown>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style2">Ub. Geográfica 2:</td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddUge2" runat="server" CssClass="txtdd" Width="100%">
                                                                    </asp:DropDownList>
                                                                    <asp:CascadingDropDown ID="cddgeo2" runat="server" Category="uge2"
                                                                        Enabled="True" LoadingText="[Cargando Geo2...]" ParentControlID="ddUge1"
                                                                        PromptText="• Seleccione •" ServiceMethod="GetUge2" ServicePath="ws.asmx"
                                                                        TargetControlID="ddUge2">
                                                                    </asp:CascadingDropDown>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style2">Ub. Geográfica 3:</td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddUge3" runat="server" CssClass="txtdd" Width="100%">
                                                                    </asp:DropDownList>
                                                                    <asp:CascadingDropDown ID="cddgeo3" runat="server" Category="uge3"
                                                                        Enabled="True" LoadingText="[Cargando Geo3...]" ParentControlID="ddUge2"
                                                                        PromptText="• Seleccione •" ServiceMethod="GetUge3" ServicePath="ws.asmx"
                                                                        TargetControlID="ddUge3">
                                                                    </asp:CascadingDropDown>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <span class="style2">Piso/Nivel:<asp:RequiredFieldValidator ID="rfvtipo2"
                                                                        runat="server" ControlToValidate="ddPiso" ErrorMessage="Seleccione Piso/Nivel"
                                                                        ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                                    </span>
                                                                    <asp:ValidatorCalloutExtender ID="rfvtipo2_vce" runat="server" Enabled="True"
                                                                        TargetControlID="rfvtipo2">
                                                                    </asp:ValidatorCalloutExtender>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddPiso" runat="server" CssClass="txtdd" Width="175px">
                                                                    </asp:DropDownList>
                                                                    <asp:CascadingDropDown ID="cddpiso" runat="server" Category="pis_id"
                                                                        Enabled="True" LoadingText="[Cargando Piso...]" ParentControlID="ddUge3"
                                                                        PromptText="• Seleccione •" ServiceMethod="GetUge4" ServicePath="ws.asmx"
                                                                        TargetControlID="ddPiso">
                                                                    </asp:CascadingDropDown>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ibgr2" EventName="Click" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </div>
                                        </td>
                                        <td class="aatl" width="40%">
                                            <div class="divv">
                                                <asp:UpdatePanel ID="upuor" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <table cellpadding="2" cellspacing="0" class="style1">
                                                            <tr>
                                                                <td class="style2" width="98">Centro de Costo:</td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddCcosto" runat="server" CssClass="txtdd" Width="100%">
                                                                    </asp:DropDownList>
                                                                    <asp:CascadingDropDown ID="cddccosto" runat="server" Category="cco"
                                                                        Enabled="True" LoadingText="[Cargando Centro de Costo...]"
                                                                        ParentControlID="ddUge3" PromptText="• Seleccione •"
                                                                        ServiceMethod="GetCcostoUge3" ServicePath="ws.asmx" TargetControlID="ddCcosto">
                                                                    </asp:CascadingDropDown>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style2">Ub. Orgánica 1:</td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddUor1" runat="server" CssClass="txtdd" Width="100%">
                                                                    </asp:DropDownList>
                                                                    <asp:CascadingDropDown ID="cdduor1" runat="server" Category="uor1"
                                                                        Enabled="True" LoadingText="[Cargando Dep1...]" ParentControlID="ddCcosto"
                                                                        PromptText="• Seleccione •" ServiceMethod="GetUor1Cco" ServicePath="ws.asmx"
                                                                        TargetControlID="ddUor1">
                                                                    </asp:CascadingDropDown>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <span class="style2">Ub. Orgánica 2:<asp:RequiredFieldValidator ID="rfvtipo4"
                                                                        runat="server" ControlToValidate="ddUor2"
                                                                        ErrorMessage="Seleccione Ubicación Orgánica 2" ValidationGroup="1"
                                                                        ForeColor="Red">*</asp:RequiredFieldValidator>
                                                                    </span>
                                                                    <asp:ValidatorCalloutExtender ID="rfvtipo4_vce" runat="server" Enabled="True"
                                                                        TargetControlID="rfvtipo4">
                                                                    </asp:ValidatorCalloutExtender>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddUor2" runat="server" CssClass="txtdd" Width="100%">
                                                                    </asp:DropDownList>
                                                                    <asp:CascadingDropDown ID="cdduor2" runat="server" Category="uor2"
                                                                        Enabled="True" LoadingText="[Cargando Dep2...]" ParentControlID="ddUor1"
                                                                        PromptText="• Seleccione •" ServiceMethod="GetUor2" ServicePath="ws.asmx"
                                                                        TargetControlID="ddUor2">
                                                                    </asp:CascadingDropDown>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <span class="style2">Custodio:<asp:RequiredFieldValidator ID="rfvtipo3"
                                                                        runat="server" ControlToValidate="ddCustodio"
                                                                        ErrorMessage="Seleccione Custodio" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                                    </span>
                                                                    <asp:ValidatorCalloutExtender ID="rfvtipo3_vce" runat="server" Enabled="True"
                                                                        TargetControlID="rfvtipo3">
                                                                    </asp:ValidatorCalloutExtender>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddCustodio" runat="server" CssClass="txtdd" Width="100%">
                                                                    </asp:DropDownList>
                                                                    <asp:CascadingDropDown ID="cddcus" runat="server" Category="cus" ContextKey=""
                                                                        Enabled="True" LoadingText="[Cargando Custodios...]" ParentControlID="ddUor1"
                                                                        PromptText="• Seleccione •" ServiceMethod="GetCusUor1" ServicePath="ws.asmx"
                                                                        TargetControlID="ddCustodio">
                                                                    </asp:CascadingDropDown>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ibgr3" EventName="Click" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="aatl">
                                <table style="margin-left: 20px">
                                    <tr style="height: 12px">
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnFiltrar" runat="server" CssClass="btn btn-primary" OnClick="Button1_Click" Text="Filtrar" ValidationGroup="2" Width="130px" />
                                            &nbsp;&nbsp;&nbsp<asp:Button ID="btnIniInventario" runat="server" CssClass="btn btn-default" Text="Iniciar Inventario" ValidationGroup="2" Width="130px" OnClick="btnIniInventario_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>


                        </tr>
                    </table>
                    <table style="width:99%; margin-left:27px">
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div id ="div1" class="alert alert-danger" runat="server" visible="false">
                                    <strong>Aviso!</strong><asp:Label ID="lblInventario" runat="server"></asp:Label>
                                </div>
                                <div id="div2" class="alert alert-success" runat="server" visible="false">
                                    <strong>Aviso!</strong><asp:Label ID="lblmsg2" runat="server"></asp:Label>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <h4>Items por Asignar a Dispositivo Movil </h4>
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadGrid ID="rgactivos1" runat="server" CellSpacing="0" GridLines="None"
                        AllowMultiRowSelection="True" AllowSorting="True" Width="100%" CssClass="table table-hover"
                        Culture="en-US">
                        <MasterTableView>
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridClientSelectColumn UniqueName="ClientSelectColumn" />
                            </Columns>
                            <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                </EditColumn>
                            </EditFormSettings>
                        </MasterTableView>
                        <ClientSettings EnableRowHoverStyle="true">
                            <Selecting AllowRowSelect="True" />
                            <Scrolling AllowScroll="true" SaveScrollPosition="true" UseStaticHeaders="true" />
                        </ClientSettings>
                        <FilterMenu EnableImageSprites="False">
                        </FilterMenu>
                        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                        </HeaderContextMenu>
                    </telerik:RadGrid>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <h4>Items Asignados a Dispositivo Movil</h4>
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadGrid ID="rgactivos2" runat="server" AllowMultiRowSelection="True"
                        AllowSorting="True" CellSpacing="0" GridLines="None" Width="100%" CssClass="table table-hover"
                        Culture="en-US">
                        <MasterTableView>
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridClientSelectColumn UniqueName="ClientSelectColumn" />
                            </Columns>
                            <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                </EditColumn>
                            </EditFormSettings>
                        </MasterTableView>
                        <ClientSettings EnableRowHoverStyle="true">
                            <Selecting AllowRowSelect="True" />
                            <Scrolling AllowScroll="true" SaveScrollPosition="true" UseStaticHeaders="true" />
                        </ClientSettings>
                        <FilterMenu EnableImageSprites="False">
                        </FilterMenu>
                        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                        </HeaderContextMenu>
                    </telerik:RadGrid>
                </td>
            </tr>
            <tr style="height: 30px">
                <td></td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnborrarasig" runat="server" OnClick="btnborrarasig_Click" CssClass="btn btn-danger"
                        Text="Borrar Asignación" ValidationGroup="3" CausesValidation="False" Width="130px" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="font-weight: 700">
                    <table cellspacing="0" class="style3">
                        <tr>
                            <td class="style2" width="90">
                                <h5><strong>Disp. Movil:<asp:RequiredFieldValidator ID="rfvtipo5"
                                    runat="server" ControlToValidate="ddPpc" ErrorMessage="Seleccione PocketPc"
                                    ValidationGroup="3" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="rfvtipo5_ValidatorCalloutExtender"
                                        runat="server" Enabled="True" TargetControlID="rfvtipo5">
                                    </asp:ValidatorCalloutExtender>
                                </strong></h5>
                            </td>
                            <td width="100">
                                <asp:DropDownList ID="ddPpc" runat="server" CssClass="txtdd" Width="90px">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button ID="btnasignar" runat="server" CssClass="btn btn-success" OnClick="btnasignar_Click"
                                    Text="Asignar" ValidationGroup="3" Width="130px" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <uc2:messbox ID="messbox1" runat="server" />
</asp:Content>


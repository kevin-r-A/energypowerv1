<%@ Page Title="" Language="C#" MasterPageFile="~/Site/Activos/cay.master" AutoEventWireup="true" CodeFile="TrasladosMas.aspx.cs" Inherits="TrasladosMas" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="../../Ctrl/Wait/wait.ascx" TagName="wait" TagPrefix="uc1" %>
<%@ Register Src="../../Ctrl/Msg/messbox.ascx" TagName="messbox" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style4 {
            width: 98px;
        }

        .auto-style5 {
            width: 100px;
        }
    </style>
    <!-- jQuery library -->
    <script type="text/javascript" src="https://code.jquery.com/jquery-2.2.4.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="cph1">
    <script type="text/javascript">
        function ClientResized(sender, eventArgs) {
            $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest('ChangePageSize');
        }

        function OpenWindows(url) {
            window.open(url, " Reporte Traslado Masivo", "directories=no, location=no, menubar=no, scrollbars=yes, statusbar=no, tittlebar=no, width=300");
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
            //popupWin.focus();
        }

        function MsgMostrar(op) {
            //alert("la opcion es==>>>>>" + op)
            if (op == 1) {
                $("#msg").html("Realizando Traslado, un momento por favor...");
                $("#waitTras").show();
            }
            else {
                $("#waitTras").hide();
            }
        }
    </script>
    <br />
    <div id="div_Repo" runat="server" style="height: 90%; width:100%">
        <telerik:RadSplitter ID="Radsplitter1" runat="server"
            Height="100%" Width="100%">
            <telerik:RadPane ID="Radpane1" runat="server" Width="400px" Height="800px">
                <div style="padding:12px">
                    <asp:UpdatePanel ID="upFiltro" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table cellpadding="2" cellspacing="0" style="width: 100%">
                                <tr>
                                    <td class="auto-style5"></td>
                                    <td>
                                        <asp:CheckBox ID="chk1" runat="server" AutoPostBack="True" Checked="True"
                                            OnCheckedChanged="chk1_CheckedChanged" Text="Habilitar Dependencias" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style5">Tipo:</td>
                                    <td>
                                        <asp:DropDownList ID="ddtipo" runat="server" CssClass="txtdd" Width="100%">
                                            <asp:ListItem>• Todos •</asp:ListItem>
                                            <asp:ListItem>Activo Fijo</asp:ListItem>
                                            <asp:ListItem>Bien de Control</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                            <table cellpadding="2" cellspacing="0" class="style1">
                                <tr>
                                    <td width="100">Ub. Geográfica 1:</td>
                                    <td>
                                        <asp:DropDownList ID="ddUge1" runat="server" CssClass="txtdd" Width="100%">
                                        </asp:DropDownList>
                                        <asp:CascadingDropDown ID="cddgeo1" runat="server" Category="uge1"
                                            Enabled="True" LoadingText="[Cargando Geo1...]" PromptText="• Todos •"
                                            ServiceMethod="GetUge1" ServicePath="ws.asmx" TargetControlID="ddUge1">
                                        </asp:CascadingDropDown>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Ub. Geográfica 2:</td>
                                    <td>
                                        <asp:DropDownList ID="ddUge2" runat="server" CssClass="txtdd" Width="100%">
                                        </asp:DropDownList>
                                        <asp:CascadingDropDown ID="cddgeo2" runat="server" Category="uge2"
                                            Enabled="True" LoadingText="[Cargando Geo2...]" ParentControlID="ddUge1"
                                            PromptText="• Todos •" ServiceMethod="GetUge2" ServicePath="ws.asmx"
                                            TargetControlID="ddUge2">
                                        </asp:CascadingDropDown>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Ub. Geográfica 3:</td>
                                    <td>
                                        <asp:DropDownList ID="ddUge3" runat="server" CssClass="txtdd" Width="100%">
                                        </asp:DropDownList>
                                        <asp:CascadingDropDown ID="cddgeo3" runat="server" Category="uge3"
                                            Enabled="True" LoadingText="[Cargando Geo3...]" ParentControlID="ddUge2"
                                            PromptText="• Todos •" ServiceMethod="GetUge3" ServicePath="ws.asmx"
                                            TargetControlID="ddUge3">
                                        </asp:CascadingDropDown>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Piso/Nivel:</td>
                                    <td>
                                        <asp:DropDownList ID="ddPiso" runat="server" CssClass="txtdd" Width="175px">
                                        </asp:DropDownList>
                                        <asp:CascadingDropDown ID="cddpiso" runat="server" Category="pis_id"
                                            Enabled="True" LoadingText="[Cargando Piso...]" ParentControlID="ddUge3"
                                            PromptText="• Todos •" ServiceMethod="GetUge4" ServicePath="ws.asmx"
                                            TargetControlID="ddPiso">
                                        </asp:CascadingDropDown>
                                    </td>
                                </tr>
                            </table>
                            <table cellpadding="2" cellspacing="0" class="style1">
                                <tr>
                                    <td width="100">Centro de Costo:</td>
                                    <td>
                                        <asp:DropDownList ID="ddCcosto" runat="server" CssClass="txtdd" Width="100%">
                                        </asp:DropDownList>
                                        <asp:CascadingDropDown ID="cddccosto" runat="server" Category="cco"
                                            Enabled="True" LoadingText="[Cargando Centro de Costo...]" PromptText="• Todos •"
                                            ServicePath="ws.asmx" TargetControlID="ddCcosto">
                                        </asp:CascadingDropDown>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Ub. Orgánica 1:</td>
                                    <td>
                                        <asp:DropDownList ID="ddUor1" runat="server" CssClass="txtdd" Width="100%">
                                        </asp:DropDownList>
                                        <asp:CascadingDropDown ID="cdduor1" runat="server" Category="uor1"
                                            Enabled="True" LoadingText="[Cargando Dep1...]"
                                            PromptText="• Todos •" ServicePath="ws.asmx"
                                            TargetControlID="ddUor1">
                                        </asp:CascadingDropDown>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Ub. Orgánica 2:</td>
                                    <td>
                                        <asp:DropDownList ID="ddUor2" runat="server" CssClass="txtdd" Width="100%">
                                        </asp:DropDownList>
                                        <asp:CascadingDropDown ID="cdduor2" runat="server" Category="uor2"
                                            Enabled="True" LoadingText="[Cargando Dep2...]" ParentControlID="ddUor1"
                                            PromptText="• Todos •" ServiceMethod="GetUor2" ServicePath="ws.asmx"
                                            TargetControlID="ddUor2">
                                        </asp:CascadingDropDown>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Custodio:</td>
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
                                <tr style="height: 20px">
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td class="aacr">
                                        <asp:ImageButton ID="ibcancel" runat="server" CausesValidation="False"
                                            Height="28px" ImageUrl="~/Img/d1.png" OnClick="ibcancel_Click" Width="102px" />
                                        &nbsp;<asp:ImageButton ID="ibsave" runat="server" CausesValidation="False"
                                            Height="28px" ImageUrl="~/Img/t1.png" OnClick="ibsave_Click" Width="102px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td class="aacr">&nbsp;</td>
                                </tr>
                            </table>
                            <table cellpadding="2" cellspacing="0" class="style1">
                                <tr>
                                    <td width="100">Ub. Geográfica 1:</td>
                                    <td>
                                        <asp:DropDownList ID="ddUge11" runat="server" CssClass="txtdd" Width="100%">
                                        </asp:DropDownList>
                                        <asp:CascadingDropDown ID="ddUge11_CascadingDropDown" runat="server"
                                            Category="uge1" Enabled="True" LoadingText="[Cargando Geo1...]"
                                            PromptText="• Todos •" ServiceMethod="GetUge1" ServicePath="ws.asmx"
                                            TargetControlID="ddUge11">
                                        </asp:CascadingDropDown>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Ub. Geográfica 2:</td>
                                    <td>
                                        <asp:DropDownList ID="ddUge22" runat="server" CssClass="txtdd" Width="100%">
                                        </asp:DropDownList>
                                        <asp:CascadingDropDown ID="ddUge22_CascadingDropDown" runat="server"
                                            Category="uge2" Enabled="True" LoadingText="[Cargando Geo2...]"
                                            ParentControlID="ddUge11" PromptText="• Todos •" ServiceMethod="GetUge2"
                                            ServicePath="ws.asmx" TargetControlID="ddUge22">
                                        </asp:CascadingDropDown>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Ub. Geográfica 3:</td>
                                    <td>
                                        <asp:DropDownList ID="ddUge33" runat="server" CssClass="txtdd" Width="100%">
                                        </asp:DropDownList>
                                        <asp:CascadingDropDown ID="ddUge33_CascadingDropDown" runat="server"
                                            Category="uge3" Enabled="True" LoadingText="[Cargando Geo3...]"
                                            ParentControlID="ddUge22" PromptText="• Todos •" ServiceMethod="GetUge3"
                                            ServicePath="ws.asmx" TargetControlID="ddUge33">
                                        </asp:CascadingDropDown>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Piso/Nivel:<asp:RequiredFieldValidator ID="rfvtipo2" runat="server"
                                        ControlToValidate="ddPiso44" ErrorMessage="Seleccione Piso/Nivel"
                                        ValidationGroup="11" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="rfvtipo2_vce" runat="server" Enabled="True"
                                            TargetControlID="rfvtipo2" PopupPosition="BottomRight">
                                        </asp:ValidatorCalloutExtender>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddPiso44" runat="server" CssClass="txtdd" Width="175px">
                                        </asp:DropDownList>
                                        <asp:CascadingDropDown ID="ddPiso44_CascadingDropDown" runat="server"
                                            Category="pis_id" Enabled="True" LoadingText="[Cargando Piso...]"
                                            ParentControlID="ddUge33" PromptText="• Todos •" ServiceMethod="GetUge4"
                                            ServicePath="ws.asmx" TargetControlID="ddPiso44">
                                        </asp:CascadingDropDown>
                                    </td>
                                </tr>
                            </table>
                            <table cellpadding="2" cellspacing="0" class="style1">
                                <tr>
                                    <td width="100">Centro de Costo:</td>
                                    <td>
                                        <asp:DropDownList ID="ddCcosto11" runat="server" CssClass="txtdd" Width="100%">
                                        </asp:DropDownList>
                                        <asp:CascadingDropDown ID="ddCcosto11_CascadingDropDown" runat="server"
                                            Category="cco" Enabled="True" LoadingText="[Cargando Centro de Costo...]" PromptText="• Todos •"
                                            ServicePath="ws.asmx" TargetControlID="ddCcosto11">
                                        </asp:CascadingDropDown>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Ub. Orgánica 1:</td>
                                    <td>
                                        <asp:DropDownList ID="ddUor22" runat="server" CssClass="txtdd" Width="100%">
                                        </asp:DropDownList>
                                        <asp:CascadingDropDown ID="ddUor22_CascadingDropDown" runat="server"
                                            Category="uor1" Enabled="True" LoadingText="[Cargando Dep1...]" PromptText="• Todos •"
                                            ServicePath="ws.asmx" TargetControlID="ddUor22">
                                        </asp:CascadingDropDown>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Ub. Orgánica 2:<asp:RequiredFieldValidator ID="rfvtipo4" runat="server"
                                        ControlToValidate="ddUor33" ErrorMessage="Seleccione Ubicación Orgánica 2"
                                        ValidationGroup="11" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="rfvtipo4_vce" runat="server" Enabled="True"
                                            TargetControlID="rfvtipo4" PopupPosition="BottomRight">
                                        </asp:ValidatorCalloutExtender>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddUor33" runat="server" CssClass="txtdd" Width="100%">
                                        </asp:DropDownList>
                                        <asp:CascadingDropDown ID="ddUor33_CascadingDropDown" runat="server"
                                            Category="uor2" Enabled="True" LoadingText="[Cargando Dep2...]"
                                            ParentControlID="ddUor22" PromptText="• Todos •" ServiceMethod="GetUor2"
                                            ServicePath="ws.asmx" TargetControlID="ddUor33">
                                        </asp:CascadingDropDown>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Custodio:<asp:RequiredFieldValidator ID="rfvtipo3" runat="server"
                                        ControlToValidate="ddCustodio44" ErrorMessage="Seleccione Custodio"
                                        ValidationGroup="11" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="rfvtipo3_vce" runat="server" Enabled="True"
                                            TargetControlID="rfvtipo3" PopupPosition="BottomRight">
                                        </asp:ValidatorCalloutExtender>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddCustodio44" runat="server" CssClass="txtdd"
                                            Width="100%">
                                        </asp:DropDownList>
                                        <asp:CascadingDropDown ID="ddCustodio44_CascadingDropDown" runat="server"
                                            Category="cus" ContextKey="" Enabled="True"
                                            LoadingText="[Cargando Custodios...]"
                                            PromptText="• Todos •" ServicePath="ws.asmx"
                                            TargetControlID="ddCustodio44" ParentControlID="ddUor22"
                                            ServiceMethod="GetCusUor1">
                                        </asp:CascadingDropDown>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Transferencia:<asp:RequiredFieldValidator ID="rfvtipo7" runat="server"
                                        ControlToValidate="ddTrasnfer33" ErrorMessage="Seleccione Transferencia"
                                        ForeColor="Red" ValidationGroup="11">*</asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="rfvtipo7_ValidatorCalloutExtender"
                                            runat="server" Enabled="True" PopupPosition="BottomRight"
                                            TargetControlID="rfvtipo7">
                                        </asp:ValidatorCalloutExtender>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddTrasnfer33" runat="server" CssClass="txtdd"
                                            Width="110px">
                                        </asp:DropDownList>
                                        <asp:CascadingDropDown ID="cddest3" runat="server" Category="est3"
                                            ContextKey="3" Enabled="True" LoadingText="[Cargando Estado 3...]"
                                            PromptText="• Todos •" ServiceMethod="GetEstado" ServicePath="ws.asmx"
                                            TargetControlID="ddTrasnfer33">
                                        </asp:CascadingDropDown>
                                    </td>
                                </tr>
                                <tr style="height: 20px">
                                    <td>&nbsp;</td>
                                    <td class="aacr">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td class="aacr">
                                        <asp:ImageButton ID="ibtrans" runat="server" Height="28px" ImageUrl="~/Img/e1.png" OnClick="ibtrans_Click" OnClientClick="MsgMostrar(1)" ValidationGroup="11" Width="102px" />
                                    </td>
                                </tr>
                            </table>
                            <uc2:messbox ID="messbox1" runat="server" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </telerik:RadPane>
            <telerik:RadSplitBar ID="rsb" runat="server" CollapseMode="Forward"
                CollapseExpandPaneText="Mostrar/Ocultar Botones" Width="20px">
            </telerik:RadSplitBar>
            <telerik:RadPane ID="Radpane2" runat="server" Height="800px">
                <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server"
                    DefaultLoadingPanelID="RadAjaxLoadingPanel1" EnablePageHeadUpdate="False">
                    <AjaxSettings>
                        <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="rgactivos" />
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="rgactivos">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="rgactivos" />
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="ibsave">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="rgactivos" />
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                    </AjaxSettings>
                </telerik:RadAjaxManager>
                <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server"
                    Skin="Default">
                </telerik:RadAjaxLoadingPanel>
                <asp:UpdatePanel ID="upgrid" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <telerik:RadGrid ID="rgactivos" runat="server" AllowMultiRowSelection="True"
                            AllowSorting="True" CellSpacing="0" Culture="en-US" GridLines="None" 
                            Width="100%" Height="900px">
                            <MasterTableView DataKeyNames="Id">
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
                                <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                            </ClientSettings>
                            <FilterMenu EnableImageSprites="False">
                            </FilterMenu>
                            <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                            </HeaderContextMenu>
                        </telerik:RadGrid>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </telerik:RadPane>
        </telerik:RadSplitter>
    </div>
    <div id="waitTras" style="display:none">
        <div style="position: absolute; left: 0px; top: 0px; right: 0px; bottom: 0px; z-index: 10002; background-color: Gray; filter: alpha(opacity=70); opacity: 0.7;"></div>
        <table style="position: absolute; width: 100%; height: 100%; z-index: 10003; top: 0px; left: 0px;">
            <tr>
                <td align="center" valign="middle">
                    <div style="border: 1px solid #333333; color: Black; font-weight: bolder; background-color: White; padding: 15px; width: 200px; height: auto">
                        <asp:Image ID="imgw" runat="server" ImageUrl="~/Img/lo1.gif" Height="31px"
                            Width="31px" />
                        <br />
                        <h5><span id="msg"></span></h5>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>



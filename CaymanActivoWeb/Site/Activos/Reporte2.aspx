<%@ Page Title="" Language="C#" MasterPageFile="~/Site/Activos/cay.master" AutoEventWireup="true" CodeFile="Reporte2.aspx.cs" Inherits="Reporte2" EnableEventValidation="false" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register src="../../Ctrl/Msg/messbox.ascx" tagname="messbox" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="cph1">
        
        <asp:Panel ID="Panel1" runat="server" CssClass="panmar" 
                GroupingText="Reporte Global">
            <asp:Panel ID="Panel2" runat="server" CssClass="panmar" GroupingText="Filtro">
                <table cellspacing="1" class="panmar">
                    <tr>
                        <td class="aatl">
                            <telerik:RadFilter ID="rf1" runat="server" ApplyButtonText="Aplicar" 
                                CssClass="RadFilter RadFilter_Default RadFilter RadFilter_Default " 
                                Culture="en-US" FilterContainerID="rgactivos" onprerender="rf1_PreRender" 
                                ShowApplyButton="False">
                                <Localization FilterFunctionBetween="Entre" FilterFunctionContains="Contiene" 
                                    FilterFunctionDoesNotContain="NoContiene" FilterFunctionEndsWith="TerminaCon" 
                                    FilterFunctionEqualTo="Igual" FilterFunctionGreaterThan="Mayor" 
                                    FilterFunctionGreaterThanOrEqualTo="MayorIgual" FilterFunctionIsEmpty="Vacío" 
                                    FilterFunctionIsNull="Nulo" FilterFunctionLessThan="Menor" 
                                    FilterFunctionLessThanOrEqualTo="MenorIgual" FilterFunctionNotBetween="NoEntre" 
                                    FilterFunctionNotEqualTo="NoIgual" FilterFunctionNotIsEmpty="NoVacío" 
                                    FilterFunctionNotIsNull="NoNulo" FilterFunctionStartsWith="EmpiezaCon" 
                                    GroupOperationAnd="Y" GroupOperationNotAnd="no Y" GroupOperationNotOr="No O" 
                                    GroupOperationOr="O" />
                            </telerik:RadFilter>
                            <br />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="panitems" runat="server" CssClass="panmar" GroupingText="Items">
                <table cellspacing="1" class="panmar">
                    <tr>
                        <td class="aatl">
                            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" 
                                DefaultLoadingPanelID="RadAjaxLoadingPanel1" EnablePageHeadUpdate="False">
                                <AjaxSettings>
                                    <telerik:AjaxSetting AjaxControlID="rf1">
                                        <UpdatedControls>
                                            <telerik:AjaxUpdatedControl ControlID="rf1" />
                                        </UpdatedControls>
                                    </telerik:AjaxSetting>
                                    <telerik:AjaxSetting AjaxControlID="rgactivos">
                                        <UpdatedControls>
                                            <telerik:AjaxUpdatedControl ControlID="rgactivos" />
                                        </UpdatedControls>
                                    </telerik:AjaxSetting>
                                </AjaxSettings>
                            </telerik:RadAjaxManager>
                            <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" Runat="server" 
                                Skin="Default">
                            </telerik:RadAjaxLoadingPanel>
                            <br />
                            <asp:Panel ID="Panel3" runat="server" Height="600px" ScrollBars="Auto" 
                                Width="1200px">
                                <telerik:RadGrid ID="rgactivos" runat="server" AllowPaging="True" 
                                    AllowSorting="True" AutoGenerateColumns="False" CellSpacing="0" 
                                    CssClass="panmar" Culture="en-US" DataSourceID="SqlDataSource1" 
                                    GridLines="Horizontal" Height="600px" OnItemCommand="RadGrid1_ItemCommand" 
                                    Width="12000px">
                                    <GroupingSettings CaseSensitive="False" />
                                    <ClientSettings>
                                        <Selecting AllowRowSelect="True" />
                                        <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                                    </ClientSettings>
                                    <MasterTableView AutoGenerateColumns="True" CommandItemDisplay="Top" 
                                        Font-Names="Arial Narrow" Font-Size="10pt" IsFilterItemExpanded="false">
                                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                        </RowIndicatorColumn>
                                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                        </ExpandCollapseColumn>
                                        <EditFormSettings>
                                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                            </EditColumn>
                                        </EditFormSettings>
                                        <ItemStyle Font-Names="Arial Narrow" Font-Size="10pt" />
                                        <AlternatingItemStyle Font-Names="Arial Narrow" Font-Size="10pt" />
                                        <PagerStyle Font-Names="Arial Narrow" Font-Size="10pt" />
                                        <HeaderStyle Font-Names="Arial Narrow" Font-Size="10pt" />
                                        <CommandItemStyle Font-Names="Arial Narrow" Font-Size="10pt" />
                                        <FooterStyle Font-Names="Arial Narrow" Font-Size="10pt" />
                                        <CommandItemTemplate>
                                            <telerik:RadToolBar ID="RadToolBar1" runat="server" 
                                                OnButtonClick="RadToolBar1_ButtonClick">
                                                <Items>
                                                    <telerik:RadToolBarButton CommandName="FilterRadGrid" ImagePosition="Right" 
                                                        Text="Applicar Filtro" />
                                                </Items>
                                            </telerik:RadToolBar>
                                        </CommandItemTemplate>
                                    </MasterTableView>
                                    <FilterMenu EnableImageSprites="False">
                                    </FilterMenu>
                                    <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                                    </HeaderContextMenu>
                                </telerik:RadGrid>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </asp:Panel>
            <uc2:messbox ID="messbox1" runat="server" />

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:base %>" 
                SelectCommand="usp_ReporteGlobalACTIVO" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:Parameter DefaultValue=" " Name="where" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
        </asp:Content>



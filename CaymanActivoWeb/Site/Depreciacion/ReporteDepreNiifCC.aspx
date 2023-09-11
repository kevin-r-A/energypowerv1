﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site/Activos/cay.master" AutoEventWireup="true" CodeFile="ReporteDepreNiifCC.aspx.cs" Inherits="ReporteDepreNiifCC" EnableEventValidation="false" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Register src="../../Ctrl/Wait/wait.ascx" tagname="wait" tagprefix="uc1" %>

<%@ Register src="../../Ctrl/Msg/messbox.ascx" tagname="messbox" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="cph1">
    <script type="text/javascript">
    function KeyPress(sender, args) {
        var regexp = new RegExp("[0-9]{1}|[\b]|\t|\r");
        if (!args.get_keyCharacter().match(regexp))
            args.set_cancel(true);
    }  
</script>
                        <asp:Panel ID="panbus" runat="server" CssClass="panmar" 
        GroupingText="Seleccione Periodo">
                            <table cellspacing="0" class="panmar2">
                                <tr>
                                    <td width="50">
                                        Periodo:</td>
                                    <td class="aacl" width="180">
                                        &nbsp;<asp:DropDownList ID="ddmeses" runat="server" Width="170px" 
                                            AutoPostBack="True" onselectedindexchanged="ddmeses_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="aacl">
                                        &nbsp;</td>
                                </tr>
                            </table>
                            <br />
                            <asp:UpdatePanel ID="upperiodo" runat="server" UpdateMode="Conditional">
                            </asp:UpdatePanel>
    </asp:Panel>
    <asp:Panel ID="pantras" runat="server" CssClass="panmar" 
        GroupingText="Reporte de Depreciación para el Periodo">
        <table cellspacing="0" class="panmar">
            <tr>
                <td class="aatl" width="100%">
                    <table class="style3">
                        <tr>
                            <td class="aatr">
                                <asp:Button ID="btnExcel" runat="server" CausesValidation="False" 
                                    onclick="btnExcel_Click" Text="Exportar a Excel" />
                            </td>
                        </tr>
                        <tr>
                            <td class="aatl">
                                <telerik:RadGrid ID="rgdepre" runat="server" 
                                    AutoGenerateColumns="False" CellSpacing="0" Culture="en-US" 
                                    GridLines="None" ShowFooter="True" 
                                    DataSourceID="SqlDataSource1" 
                                    onexcelmlexportrowcreated="rgdepre_ExcelMLExportRowCreated">
                                    <GroupingSettings CollapseTooltip="Juntar Grupo" ExpandTooltip="Expandir Grupo" 
                                        GroupContinuedFormatString="... el grupo continúa de la página anterior." 
                                        GroupContinuesFormatString="El grupo continúa en la siguiente página" 
                                        GroupSplitDisplayFormat="Mostrando {0} de {1} items." 
                                        UnGroupButtonTooltip="Click aquí para desagrupar" UnGroupTooltip="" />
                                    <HierarchySettings CollapseTooltip="Agrupar" ExpandTooltip="Expandir" />
                                    <ExportSettings FileName="" ExportOnlyData="True" IgnorePaging="True" 
                                        OpenInNewWindow="True">
                                        <Pdf PageHeight="297mm" PageWidth="210mm" PaperSize="A4" 
                                            Author="Cayman Activo V3" Creator="Cayman Activo V3" />
                                        <Excel Format="ExcelML" />
                                    </ExportSettings>
                                    <ClientSettings>
                                        <Selecting AllowRowSelect="True" />
                                    </ClientSettings>
                                    <GroupPanel Text="Arrastre el encabezado de una columna aquí para agrupar los items por esa columna">
                                    </GroupPanel>
                                    <MasterTableView DataKeyNames="Id" 
                                        NoDetailRecordsText="No hay registros hijos para mostrar." 
                                        NoMasterRecordsText="No hay registros para mostrar." PageSize="200" 
                                        DataSourceID="SqlDataSource1" ShowGroupFooter="True">
                                        <CommandItemSettings AddNewRecordText="Agregar Registro" 
                                            ExportToCsvText="Exportar a CSV" ExportToExcelText="Exportar a Excel" 
                                            ExportToPdfText="Exportar a PDF" ExportToWordText="Exportar a Word" 
                                            ShowExportToExcelButton="True" ShowExportToPdfButton="True" 
                                            ShowExportToWordButton="True" />
                                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                        </RowIndicatorColumn>
                                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                        </ExpandCollapseColumn>
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="Cta" 
                                                FilterControlAltText="Filter Cuenta column" HeaderText="Cuenta" 
                                                UniqueName="Cuenta">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Grupo" 
                                                FilterControlAltText="Filter Grupo column" HeaderText="Grupo" 
                                                UniqueName="Grupo">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridNumericColumn DataField="Sd" DataFormatString="{0:C}" 
                                                DecimalDigits="2" FilterControlAltText="Filter Sd column" 
                                                HeaderText="SaldoXDeper" UniqueName="Sd" Visible="False">
                                            </telerik:GridNumericColumn>
                                            <telerik:GridNumericColumn DataField="Vres" DecimalDigits="2" 
                                                FilterControlAltText="Filter Vres column" HeaderText="VRes" 
                                                UniqueName="Vres" DataFormatString="{0:C}" Visible="False">
                                            </telerik:GridNumericColumn>
                                            <telerik:GridNumericColumn DataField="Deper" DecimalDigits="2" 
                                                FilterControlAltText="Filter Depper column" HeaderText="Dep.Per" 
                                                UniqueName="Depper" DataFormatString="{0:C}">
                                            </telerik:GridNumericColumn>
                                            <telerik:GridNumericColumn DataField="Saldo" DecimalDigits="2" 
                                                FilterControlAltText="Filter Saldo column" HeaderText="Saldo" 
                                                UniqueName="Saldo" DataFormatString="{0:C}">
                                            </telerik:GridNumericColumn>
                                        </Columns>
                                        
                                        <EditFormSettings>
                                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                            </EditColumn>
                                        </EditFormSettings>
                                        <PagerStyle AlwaysVisible="True" FirstPageToolTip="Primera Página" 
                                            HorizontalAlign="Left" LastPageToolTip="Última Página" 
                                            NextPagesToolTip="Siguientes Páginas" NextPageToolTip="Siguiente Página" 
                                            PagerTextFormat="Cambiar Página: {4} &amp;nbsp;Página &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;, items &lt;strong&gt;{2}&lt;/strong&gt; al &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." 
                                            PageSizeLabelText="Registros por Página:" Position="Bottom" 
                                            PrevPagesToolTip="Páginas Anteriores" PrevPageToolTip="Página Anterior" />
                                    </MasterTableView>
                                    <PagerStyle AlwaysVisible="False" FirstPageToolTip="Primera Página" 
                                        LastPageToolTip="Última Página" NextPagesToolTip="Siguientes Páginas" 
                                        NextPageToolTip="Siguiente Página" 
                                        PagerTextFormat="Cambiar Página: {4} &amp;nbsp;Página &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;, items &lt;strong&gt;{2}&lt;/strong&gt; al &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." 
                                        PageSizeLabelText="Registros por Página:" PrevPagesToolTip="Páginas Anteriores" 
                                        PrevPageToolTip="Página Anterior" />
                                    <StatusBarSettings LoadingText="Cargando..." ReadyText="Listo" />
                                    <FilterMenu EnableImageSprites="False">
                                    </FilterMenu>
                                    <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                                    </HeaderContextMenu>
                                </telerik:RadGrid>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:base %>" 
                                    SelectCommand="usp_getDepreciacionGeneradaCCNiif" 
                                    SelectCommandType="StoredProcedure">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddmeses" DefaultValue="" Name="fecha" 
                                            PropertyName="SelectedValue" Type="DateTime" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <uc2:messbox ID="messbox1" runat="server" />
</asp:Content>



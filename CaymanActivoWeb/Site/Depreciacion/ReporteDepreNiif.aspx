<%@ Page Title="" Language="C#" MasterPageFile="~/Site/Activos/cay.master" AutoEventWireup="true" CodeFile="ReporteDepreNiif.aspx.cs" Inherits="ReporteDepreNiif" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Src="../../Ctrl/Wait/wait.ascx" TagName="wait" TagPrefix="uc1" %>

<%@ Register Src="../../Ctrl/Msg/messbox.ascx" TagName="messbox" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 62px;
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
        GroupingText="Seleccione Periodo">
        <table cellspacing="0" class="panmar2">
            <tr>
                <td class="auto-style1"><h5>Periodo:</h5></td>
                <td><asp:DropDownList ID="ddmeses" runat="server"  CssClass="txtdd" Width="170px"
                    AutoPostBack="True" OnSelectedIndexChanged="ddmeses_SelectedIndexChanged">
                </asp:DropDownList>
                </td>
                <td></td>
            </tr>
        </table>
        <br />
        <asp:UpdatePanel ID="upperiodo" runat="server" UpdateMode="Conditional">
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:Panel ID="pantras" runat="server" CssClass="panmar"
        GroupingText="Reporte de Depreciación NIIF para el Periodo">
        <table cellspacing="0" class="panmar">
            <tr>
                <td class="aatl" width="100%">
                    <table class="style3">
                        <tr>
                            <td class="aatr">
                                <asp:Button ID="btnExcel" runat="server" CausesValidation="False" CssClass="btn btn-success"
                                    OnClick="btnExcel_Click" Text="Exportar a Excel" />
                            </td>
                        </tr>
                        <tr style="width:20px">
                            <td class="aatr">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="aatl">
                                <telerik:RadGrid ID="rgdepre" runat="server" AllowSorting="True"
                                    AutoGenerateColumns="False" CellSpacing="0" Culture="en-US"
                                    DataSourceID="SqlDataSource1" GridLines="None" CssClass="table table-hover"
                                    OnExcelMLExportRowCreated="rgdepre_ExcelMLExportRowCreated" ShowFooter="True"
                                    ShowGroupPanel="True">
                                    <GroupingSettings CollapseTooltip="Juntar Grupo" ExpandTooltip="Expandir Grupo"
                                        GroupContinuedFormatString="... el grupo continúa de la página anterior."
                                        GroupContinuesFormatString="El grupo continúa en la siguiente página"
                                        GroupSplitDisplayFormat="Mostrando {0} de {1} items."
                                        UnGroupButtonTooltip="Click aquí para desagrupar" UnGroupTooltip="" />
                                    <HierarchySettings CollapseTooltip="Agrupar" ExpandTooltip="Expandir" />
                                    <ExportSettings ExportOnlyData="True" FileName="" IgnorePaging="True"
                                        OpenInNewWindow="True">
                                        <Pdf Author="Cayman Activo V3" Creator="Cayman Activo V3" PageHeight="297mm"
                                            PageWidth="210mm" PaperSize="A4" />
                                        <Excel Format="ExcelML" />
                                    </ExportSettings>
                                    <ClientSettings AllowDragToGroup="True">
                                        <Selecting AllowRowSelect="True" />
                                    </ClientSettings>
                                    <GroupPanel Text="Arrastre el encabezado de una columna aquí para agrupar los items por esa columna">
                                    </GroupPanel>
                                    <MasterTableView DataKeyNames="Id" DataSourceID="SqlDataSource1"
                                        NoDetailRecordsText="No hay registros hijos para mostrar."
                                        NoMasterRecordsText="No hay registros para mostrar." PageSize="200"
                                        ShowGroupFooter="True">
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
                                            <telerik:GridNumericColumn Aggregate="Count" DataField="Id"
                                                DataType="System.Int32" DecimalDigits="2"
                                                FilterControlAltText="Filter Id column" FooterAggregateFormatString="{0}"
                                                HeaderText="Id" SortExpression="Id" UniqueName="Id">
                                                <HeaderStyle Width="48px" />
                                            </telerik:GridNumericColumn>
                                            <telerik:GridBoundColumn DataField="CodBarras"
                                                FilterControlAltText="Filter CodBarras column" HeaderText="CodBarras"
                                                SortExpression="CodBarras" UniqueName="CodBarras">
                                                <HeaderStyle Width="110px" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="CentroDeCosto"
                                                FilterControlAltText="Filter CentroDeCosto column" HeaderText="CentroDeCosto"
                                                SortExpression="CentroDeCosto" UniqueName="CentroDeCosto">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Grupo"
                                                FilterControlAltText="Filter Grupo column" HeaderText="Grupo"
                                                SortExpression="Grupo" UniqueName="Grupo">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Descripción"
                                                FilterControlAltText="Filter Descripción column" HeaderText="Descripción"
                                                SortExpression="Descripción" UniqueName="Descripción">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Fecha"
                                                FilterControlAltText="Filter Fecha column" HeaderText="Ini. Oper."
                                                SortExpression="Fecha" UniqueName="Fecha">
                                                <HeaderStyle Width="70px" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridNumericColumn Aggregate="Sum" DataField="ValorCompra"
                                                DataFormatString="{0:C}" DataType="System.Decimal" DecimalDigits="2"
                                                FilterControlAltText="Filter ValorCompra column"
                                                FooterAggregateFormatString="ValorCompra: $ {0}" HeaderText="ValorCompra"
                                                SortExpression="ValorCompra" UniqueName="ValorCompra">
                                                <ItemStyle HorizontalAlign="Right" />
                                            </telerik:GridNumericColumn>
                                            <telerik:GridNumericColumn Aggregate="Sum" DataField="ValorResidual"
                                                DataType="System.Decimal" DecimalDigits="2"
                                                FilterControlAltText="Filter ValorResidual column"
                                                FooterAggregateFormatString="ValorResidual: $ {0}" HeaderText="ValorResidual"
                                                SortExpression="ValorResidual" UniqueName="ValorResidual">
                                                <ItemStyle HorizontalAlign="Right" />
                                            </telerik:GridNumericColumn>
                                            <telerik:GridNumericColumn DataField="VidaUtil" DataType="System.Int32"
                                                DecimalDigits="2" FilterControlAltText="Filter VidaUtil column"
                                                HeaderText="VidaUtil" SortExpression="VidaUtil" UniqueName="VidaUtil">
                                                <HeaderStyle Width="58px" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </telerik:GridNumericColumn>
                                            <telerik:GridNumericColumn DataField="PT" DataType="System.Int32"
                                                DecimalDigits="2" FilterControlAltText="Filter PT column" HeaderText="PT"
                                                SortExpression="PT" UniqueName="PT">
                                                <HeaderStyle Width="44px" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </telerik:GridNumericColumn>
                                            <telerik:GridNumericColumn DataField="PR" DataType="System.Int32"
                                                DecimalDigits="2" FilterControlAltText="Filter PR column" HeaderText="PR"
                                                SortExpression="PR" UniqueName="PR">
                                                <HeaderStyle Width="44px" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </telerik:GridNumericColumn>
                                            <telerik:GridNumericColumn Aggregate="Sum" DataField="DepPeriodo"
                                                DataFormatString="{0:C}" DataType="System.Decimal" DecimalDigits="2"
                                                FilterControlAltText="Filter DepPeriodo column"
                                                FooterAggregateFormatString="DepPeriodo: $ {0}" HeaderText="DepPeriodo"
                                                SortExpression="DepPeriodo" UniqueName="DepPeriodo">
                                                <FooterStyle HorizontalAlign="Right" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </telerik:GridNumericColumn>
                                            <telerik:GridNumericColumn Aggregate="Sum" DataField="DepAcumulada"
                                                DataFormatString="{0:C}" DataType="System.Decimal" DecimalDigits="2"
                                                FilterControlAltText="Filter DepAcumulada column"
                                                FooterAggregateFormatString="DepAcumulada: $ {0}" HeaderText="DepAcumulada"
                                                SortExpression="DepAcumulada" UniqueName="DepAcumulada">
                                                <FooterStyle HorizontalAlign="Right" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </telerik:GridNumericColumn>
                                            <telerik:GridNumericColumn Aggregate="Sum" DataField="SaldoDepreciar"
                                                DataFormatString="{0:C}" DataType="System.Decimal" DecimalDigits="2"
                                                FilterControlAltText="Filter SaldoDepreciar column"
                                                FooterAggregateFormatString="SaldoDepreciar: $ {0}" HeaderText="SaldoDepreciar"
                                                SortExpression="SaldoDepreciar" UniqueName="SaldoDepreciar">
                                                <FooterStyle HorizontalAlign="Right" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </telerik:GridNumericColumn>
                                           <%-- <telerik:GridBoundColumn DataField="UltimaDep"
                                                FilterControlAltText="Filter UltimaDep column" HeaderText="UltimaDep"
                                                SortExpression="UltimaDep" UniqueName="UltimaDep" Visible="False">
                                            </telerik:GridBoundColumn>--%>
                                        </Columns>
                                        <EditFormSettings>
                                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                            </EditColumn>
                                        </EditFormSettings>
                                        <ItemStyle Font-Names="Arial Narrow" Font-Size="10pt" />
                                        <GroupHeaderItemStyle Font-Names="Arial" Font-Size="10pt" />
                                        <AlternatingItemStyle Font-Names="Arial Narrow" Font-Size="10pt" />
                                        <PagerStyle AlwaysVisible="True" FirstPageToolTip="Primera Página"
                                            HorizontalAlign="Left" LastPageToolTip="Última Página"
                                            NextPagesToolTip="Siguientes Páginas" NextPageToolTip="Siguiente Página"
                                            PagerTextFormat="Cambiar Página: {4} &amp;nbsp;Página &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;, items &lt;strong&gt;{2}&lt;/strong&gt; al &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;."
                                            PageSizeLabelText="Registros por Página:" Position="Bottom"
                                            PrevPagesToolTip="Páginas Anteriores" PrevPageToolTip="Página Anterior" />
                                        <HeaderStyle Font-Names="Arial Narrow" Font-Size="10pt" />
                                        <FooterStyle Font-Names="Arial Narrow" Font-Size="10pt" />
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
                                    SelectCommand="usp_getDepreciacionGeneradaNiif"
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



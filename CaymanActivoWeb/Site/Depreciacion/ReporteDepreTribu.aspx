<%@ Page Title="" Language="C#" MasterPageFile="~/Site/Activos/cay.master" AutoEventWireup="true" CodeFile="ReporteDepreTribu.aspx.cs" Inherits="ReporteDepreNiif" EnableEventValidation="false" %>

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
                <h5>Periodo:</h5>
            </td>
            <td class="aacl" width="180">
                &nbsp;
                <asp:DropDownList ID="ddmeses" runat="server" Width="170px" CssClass="txtdd"
                                  AutoPostBack="True" onselectedindexchanged="ddmeses_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td class="aacl">
                &nbsp;
            </td>
        </tr>
    </table>
    <br/>
    <asp:UpdatePanel ID="upperiodo" runat="server" UpdateMode="Conditional">
    </asp:UpdatePanel>
</asp:Panel>
<asp:Panel ID="pantras" runat="server" CssClass="panmar"
           GroupingText="Reporte de Depreciación TRIBUTARIA para el Periodo">
<table cellspacing="0" class="panmar">
<tr>
    <td class="aatl" width="100%">
        <table class="style3">
            <tr>
                <td class="aatr">
                    <asp:Button ID="btnExcel" runat="server" CausesValidation="False" CssClass="btn btn-success"
                                onclick="btnExcel_Click" Text="Exportar a Excel"/>
                </td>
            </tr>
            <tr style="height:20px">
                <td class="aatr">&nbsp;</td>
            </tr>
            <tr>
                <td class="aatl">
                    <telerik:RadGrid ID="rgdepre" runat="server"
                                     AutoGenerateColumns="False" CellSpacing="0" Culture="en-US" GridLines="None"
                                     ShowGroupPanel="True" ShowFooter="True" CssClass="table table-hover"
                                     DataSourceID="SqlDataSource1" AllowSorting="True"
                                     onexcelmlexportrowcreated="rgdepre_ExcelMLExportRowCreated">
                        <GroupingSettings CollapseTooltip="Juntar Grupo" ExpandTooltip="Expandir Grupo"
                                          GroupContinuedFormatString="... el grupo continúa de la página anterior."
                                          GroupContinuesFormatString="El grupo continúa en la siguiente página"
                                          GroupSplitDisplayFormat="Mostrando {0} de {1} items."
                                          UnGroupButtonTooltip="Click aquí para desagrupar" UnGroupTooltip=""/>
                        <HierarchySettings CollapseTooltip="Agrupar" ExpandTooltip="Expandir"/>
                        <ExportSettings FileName="" ExportOnlyData="True" IgnorePaging="True"
                                        OpenInNewWindow="True">
                            <Pdf PageHeight="297mm" PageWidth="210mm" PaperSize="A4"
                                 Author="Cayman Activo V3" Creator="Cayman Activo V3"/>
                            <Excel Format="ExcelML"/>
                        </ExportSettings>
                        <ClientSettings AllowDragToGroup="True">
                            <Selecting AllowRowSelect="True"/>
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
                                                 ShowExportToWordButton="True"/>
                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridNumericColumn Aggregate="Count" DataField="Id"
                                                           DataType="System.Int32" DecimalDigits="2"
                                                           FilterControlAltText="Filter Id column" HeaderText="Id" SortExpression="Id"
                                                           UniqueName="Id" FooterAggregateFormatString="{0}">
                                    <HeaderStyle Width="48px"/>
                                </telerik:GridNumericColumn>
                                <telerik:GridBoundColumn DataField="CodBarras"
                                                         FilterControlAltText="Filter CodBarras column" HeaderText="CodBarras"
                                                         SortExpression="CodBarras" UniqueName="CodBarras">
                                    <HeaderStyle Width="110px"/>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Ubigeo2"
                                                         FilterControlAltText="Filter Ubigeo2 column" HeaderText="Oficina"
                                                         SortExpression="Ubigeo2" UniqueName="Ubigeo2">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Ubiorg1"
                                                         FilterControlAltText="Filter Ubiorg1 column" HeaderText="CentroDeCosto"
                                                         SortExpression="Ubiorg1" UniqueName="Ubiorg1">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Custodio"
                                                         FilterControlAltText="Filter Custodio column" HeaderText="Custodio"
                                                         SortExpression="Custodio" UniqueName="Custodio">
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
                                    <HeaderStyle Width="70px"/>
                                    <ItemStyle HorizontalAlign="Center"/>
                                </telerik:GridBoundColumn>
                                <telerik:GridNumericColumn DataField="ValorCompra" DataFormatString="{0:C4}"
                                                           DataType="System.Decimal" DecimalDigits="4"
                                                           FilterControlAltText="Filter ValorCompra column" HeaderText="ValorCompra"
                                                           SortExpression="ValorCompra" UniqueName="ValorCompra" Aggregate="Sum"
                                                           FooterAggregateFormatString="ValorCompra: $ {0}">
                                    <ItemStyle HorizontalAlign="Right"/>
                                </telerik:GridNumericColumn>
                                <telerik:GridNumericColumn DataField="ValorResidual" DataType="System.Decimal"
                                                           DataFormatString="{0:C4}" DecimalDigits="2" FilterControlAltText="Filter ValorResidual column"
                                                           HeaderText="ValorResidual" SortExpression="ValorResidual"
                                                           UniqueName="ValorResidual" Aggregate="Sum"
                                                           FooterAggregateFormatString="ValorResidual: $ {0}">
                                    <ItemStyle HorizontalAlign="Right"/>
                                </telerik:GridNumericColumn>
                                <telerik:GridNumericColumn DataField="VidaUtil" DataType="System.Int32"
                                                           DecimalDigits="2" FilterControlAltText="Filter VidaUtil column"
                                                           HeaderText="VidaUtil" SortExpression="VidaUtil" UniqueName="VidaUtil">
                                    <HeaderStyle Width="58px"/>
                                    <ItemStyle HorizontalAlign="Center"/>
                                </telerik:GridNumericColumn>
                                <telerik:GridNumericColumn DataField="PT" DataType="System.Int32"
                                                           DecimalDigits="2" FilterControlAltText="Filter PT column"
                                                           HeaderText="PT" SortExpression="PT"
                                                           UniqueName="PT">
                                    <HeaderStyle Width="44px"/>
                                    <ItemStyle HorizontalAlign="Center"/>
                                </telerik:GridNumericColumn>
                                <telerik:GridNumericColumn DataField="PR" DataType="System.Int32"
                                                           DecimalDigits="2" FilterControlAltText="Filter PR column"
                                                           HeaderText="PR" SortExpression="PR" UniqueName="PR">
                                    <HeaderStyle Width="44px"/>
                                    <ItemStyle HorizontalAlign="Center"/>
                                </telerik:GridNumericColumn>
                                <telerik:GridNumericColumn Aggregate="Sum" DataField="DepPeriodo"
                                                           DataFormatString="{0:C4}" DataType="System.Decimal" DecimalDigits="2"
                                                           FilterControlAltText="Filter DepPeriodo column" HeaderText="DepPeriodo"
                                                           SortExpression="DepPeriodo" UniqueName="DepPeriodo"
                                                           FooterAggregateFormatString="DepPeriodo: $ {0}">
                                    <FooterStyle HorizontalAlign="Right"/>
                                    <ItemStyle HorizontalAlign="Right"/>
                                </telerik:GridNumericColumn>
                                <telerik:GridNumericColumn Aggregate="Sum" DataField="DepAcumulada"
                                                           DataFormatString="{0:C4}" DataType="System.Decimal" DecimalDigits="2"
                                                           FilterControlAltText="Filter DepAcumulada column" HeaderText="DepAcumulada"
                                                           SortExpression="DepAcumulada" UniqueName="DepAcumulada"
                                                           FooterAggregateFormatString="DepAcumulada: $ {0}">
                                    <FooterStyle HorizontalAlign="Right"/>
                                    <ItemStyle HorizontalAlign="Right"/>
                                </telerik:GridNumericColumn>
                                <telerik:GridNumericColumn Aggregate="Sum" DataField="SaldoDepreciar"
                                                           DataFormatString="{0:C4}" DataType="System.Decimal" DecimalDigits="2"
                                                           FilterControlAltText="Filter SaldoDepreciar column" HeaderText="SaldoDepreciar"
                                                           SortExpression="SaldoDepreciar" UniqueName="SaldoDepreciar"
                                                           FooterAggregateFormatString="SaldoDepreciar: $ {0}">
                                    <FooterStyle HorizontalAlign="Right"/>
                                    <ItemStyle HorizontalAlign="Right"/>
                                </telerik:GridNumericColumn>
                                <telerik:GridNumericColumn Aggregate="Sum" DataField="SaldoLibros"
                                                           DataFormatString="{0:C4}" DataType="System.Decimal" DecimalDigits="2"
                                                           FilterControlAltText="Filter SaldoLibros column" HeaderText="Saldo Libros"
                                                           SortExpression="SaldoLibros" UniqueName="SaldoLibros"
                                                           FooterAggregateFormatString="SaldoLibros: $ {0}">
                                    <FooterStyle HorizontalAlign="Right"/>
                                    <ItemStyle HorizontalAlign="Right"/>
                                </telerik:GridNumericColumn>
                                <%--<telerik:GridBoundColumn DataField="UltimaDep" 
                                                FilterControlAltText="Filter UltimaDep column" HeaderText="UltimaDep" 
                                                SortExpression="UltimaDep" UniqueName="UltimaDep" Visible="False">
                                            </telerik:GridBoundColumn>--%>
                            </Columns>

                            <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                </EditColumn>
                            </EditFormSettings>
                            <ItemStyle Font-Names="Arial Narrow" Font-Size="10pt"/>
                            <GroupHeaderItemStyle Font-Names="Arial" Font-Size="10pt"/>
                            <AlternatingItemStyle Font-Names="Arial Narrow" Font-Size="10pt"/>
                            <PagerStyle AlwaysVisible="True" FirstPageToolTip="Primera Página"
                                        HorizontalAlign="Left" LastPageToolTip="Última Página"
                                        NextPagesToolTip="Siguientes Páginas" NextPageToolTip="Siguiente Página"
                                        PagerTextFormat="Cambiar Página: {4} &amp;nbsp;Página &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;, items &lt;strong&gt;{2}&lt;/strong&gt; al &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;."
                                        PageSizeLabelText="Registros por Página:" Position="Bottom"
                                        PrevPagesToolTip="Páginas Anteriores" PrevPageToolTip="Página Anterior"/>
                            <HeaderStyle Font-Names="Arial Narrow" Font-Size="10pt"/>
                            <FooterStyle Font-Names="Arial Narrow" Font-Size="10pt"/>
                        </MasterTableView>
                        <PagerStyle AlwaysVisible="False" FirstPageToolTip="Primera Página"
                                    LastPageToolTip="Última Página" NextPagesToolTip="Siguientes Páginas"
                                    NextPageToolTip="Siguiente Página"
                                    PagerTextFormat="Cambiar Página: {4} &amp;nbsp;Página &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;, items &lt;strong&gt;{2}&lt;/strong&gt; al &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;."
                                    PageSizeLabelText="Registros por Página:" PrevPagesToolTip="Páginas Anteriores"
                                    PrevPageToolTip="Página Anterior"/>
                        <StatusBarSettings LoadingText="Cargando..." ReadyText="Listo"/>
                        <FilterMenu EnableImageSprites="False">
                        </FilterMenu>
                        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                        </HeaderContextMenu>
                    </telerik:RadGrid>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                                       ConnectionString="<%$ ConnectionStrings:base %>"
                                       SelectCommand="usp_getDepreciacionGeneradaTribu2"
                                       SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddmeses" DefaultValue="" Name="fecha"
                                                  PropertyName="SelectedValue" Type="DateTime"/>
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
        </table>
    </td>
</tr>
</table>
</asp:Panel>
<uc2:messbox ID="messbox1" runat="server"/>
</asp:Content>
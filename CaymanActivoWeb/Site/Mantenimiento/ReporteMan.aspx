<%@ Page Language="C#" MasterPageFile="~/Site/Activos/cay.master" AutoEventWireup="true" CodeFile="ReporteMan.aspx.cs" Inherits="ReporteMan" EnableEventValidation="false" %>
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
        GroupingText="Buscar Activo - Mantenimientos"><table cellpadding="0" cellspacing="0" class="panmar2"><tr>
                                <td class="aatl" width="280"><table cellspacing="0" width="400"><tr><td width="115">Código de Barras:<asp:RequiredFieldValidator 
                                        ID="rfv1" runat="server" ControlToValidate="txtbuscb" 
                                        ErrorMessage="Ingrese Código de Barras" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="rfv1_ValidatorCalloutExtender" runat="server" 
                                        Enabled="True" TargetControlID="rfv1" PopupPosition="BottomRight">
                                    </asp:ValidatorCalloutExtender>
                                    </td>
                                    <td width="150">
                                        <telerik:RadTextBox ID="txtbuscb" runat="server" 
                                                    MaxLength="20" Width="128px" ValidationGroup="1"><PasswordStrengthSettings CalculationWeightings="50;15;15;20" 
                                                            IndicatorElementBaseStyle="riStrengthBar" IndicatorElementID="" 
                                                            MinimumLowerCaseCharacters="2" MinimumNumericCharacters="2" 
                                                            MinimumSymbolCharacters="2" MinimumUpperCaseCharacters="2" 
                                                            OnClientPasswordStrengthCalculating="" PreferredPasswordLength="10" 
                                                            RequiresUpperAndLowerCaseCharacters="True" ShowIndicator="False" 
                                                            TextStrengthDescriptions="Very Weak;Weak;Medium;Strong;Very Strong" 
                                                            
                                                        
                                                TextStrengthDescriptionStyles="riStrengthBarL0;riStrengthBarL1;riStrengthBarL2;riStrengthBarL3;riStrengthBarL4;riStrengthBarL5;" />
                                            <ClientEvents OnKeyPress="KeyPress" /><EmptyMessageStyle Font-Italic="True" /></telerik:RadTextBox></td>
                                            <td><asp:ImageButton ID="ibbus1" runat="server" 
                                                    CssClass="relo" Height="20px" 
                                                        ImageUrl="~/Img/bus.png" onclick="ibbus1_Click" TabIndex="99" 
                                                        ToolTip="Buscar Código de Barras" ValidationGroup="1" Width="20px" /></td></tr>
                                    <tr>
                                            <td>Id:<asp:RequiredFieldValidator ID="rfv2" runat="server" 
                                                    ControlToValidate="txtbusid" ErrorMessage="Ingrese ID" ForeColor="Red" 
                                                    ValidationGroup="2">*</asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="rfv2_ValidatorCalloutExtender" runat="server" 
                                                    Enabled="True" TargetControlID="rfv2" PopupPosition="BottomRight">
                                                </asp:ValidatorCalloutExtender>
                                            </td><td>
                                            <telerik:RadTextBox ID="txtbusid" runat="server" MaxLength="20" Width="70px" 
                                                    ValidationGroup="2"><PasswordStrengthSettings CalculationWeightings="50;15;15;20" 
                                                            IndicatorElementBaseStyle="riStrengthBar" IndicatorElementID="" 
                                                            MinimumLowerCaseCharacters="2" MinimumNumericCharacters="2" 
                                                            MinimumSymbolCharacters="2" MinimumUpperCaseCharacters="2" 
                                                            OnClientPasswordStrengthCalculating="" PreferredPasswordLength="10" 
                                                            RequiresUpperAndLowerCaseCharacters="True" ShowIndicator="False" 
                                                            TextStrengthDescriptions="Very Weak;Weak;Medium;Strong;Very Strong" 
                                                            
                                                    
                                                    TextStrengthDescriptionStyles="riStrengthBarL0;riStrengthBarL1;riStrengthBarL2;riStrengthBarL3;riStrengthBarL4;riStrengthBarL5;" />
                                                <ClientEvents OnKeyPress="KeyPress" /><EmptyMessageStyle Font-Italic="True" /></telerik:RadTextBox></td>
                                            <td>
                                    <asp:ImageButton ID="ibbus3" runat="server" CssClass="relo" Height="20px" 
                                                        ImageUrl="~/Img/bus.png" TabIndex="99" ToolTip="Buscar Id" ValidationGroup="2" 
                                                        Width="20px" onclick="ibbus3_Click" /></td></tr></table></td></tr></table></asp:Panel>
    <asp:Panel ID="pantras" runat="server" CssClass="panmar" 
        GroupingText="Reporte de Mantenimiento" Visible="False">
        <table cellspacing="0" class="panmar">
            <tr>
                <td class="aatl" width="100%">
                    <asp:UpdatePanel ID="upman" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <telerik:RadGrid ID="rgtras" runat="server" AllowPaging="True" 
                                AutoGenerateColumns="False" CellSpacing="0" Culture="en-US" GridLines="None" 
                                Width="1200px" Height="400px">
                                <GroupingSettings CollapseTooltip="Juntar Grupo" ExpandTooltip="Expandir Grupo" 
                                    GroupContinuedFormatString="... el grupo continúa de la página anterior." 
                                    GroupContinuesFormatString="El grupo continúa en la siguiente página" 
                                    GroupSplitDisplayFormat="Mostrando {0} de {1} items." 
                                    UnGroupButtonTooltip="Click aquí para desagrupar" UnGroupTooltip="" />
                                <HierarchySettings CollapseTooltip="Agrupar" ExpandTooltip="Expandir" />
                                <ExportSettings FileName="CaymanFile">
                                    <Pdf PageHeight="297mm" PageWidth="210mm" PaperSize="A4" />
                                </ExportSettings>
                                <ClientSettings>
                                    <Selecting AllowRowSelect="True" />
                                    <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                                </ClientSettings>
                                <GroupPanel Text="Arrastre el encabezado de una columna aquí para agrupar los items por esa columna">
                                </GroupPanel>
                                <MasterTableView AllowFilteringByColumn="False" AllowSorting="False" 
                                    AutoGenerateColumns="True" 
                                    NoDetailRecordsText="No hay registros hijos para mostrar." 
                                    NoMasterRecordsText="No hay registros para mostrar." PageSize="25" 
                                    Font-Names="Arial Narrow" Font-Size="9pt">
                                    <CommandItemSettings AddNewRecordText="Agregar Registro" 
                                        ExportToCsvText="Exportar a CSV" ExportToExcelText="Exportar a Excel" 
                                        ExportToPdfText="Exportar a PDF" ExportToWordText="Exportar a Word" 
                                        ShowExportToExcelButton="True" ShowExportToPdfButton="True" 
                                        ShowExportToWordButton="True" />
                                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                    </RowIndicatorColumn>
                                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                    </ExpandCollapseColumn>
                                    <EditFormSettings>
                                        <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                        </EditColumn>
                                    </EditFormSettings>
                                    <ItemStyle Font-Names="Arial Narrow" Font-Size="9pt" />
                                    <AlternatingItemStyle Font-Names="Arial Narrow" Font-Size="9pt" />
                                    <PagerStyle AlwaysVisible="True" FirstPageToolTip="Primera Página" 
                                        HorizontalAlign="Left" LastPageToolTip="Última Página" 
                                        NextPagesToolTip="Siguientes Páginas" NextPageToolTip="Siguiente Página" 
                                        PagerTextFormat="Cambiar Página: {4} &amp;nbsp;Página &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;, items &lt;strong&gt;{2}&lt;/strong&gt; al &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." 
                                        PageSizeLabelText="Registros por Página:" Position="Bottom" 
                                        PrevPagesToolTip="Páginas Anteriores" PrevPageToolTip="Página Anterior" />
                                    <HeaderStyle Font-Names="Arial Narrow" Font-Size="9pt" />
                                </MasterTableView>
                                <PagerStyle AlwaysVisible="True" FirstPageToolTip="Primera Página" 
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
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <uc2:messbox ID="messbox1" runat="server" />
</asp:Content>



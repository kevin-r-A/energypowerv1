<%@ Page Title="" Language="C#" MasterPageFile="~/Site/Activos/cay.master" AutoEventWireup="true" CodeFile="ZProveedor.aspx.cs" Inherits="ZProveedor" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Src="../../Ctrl/Msg/messbox.ascx" TagName="messbox" TagPrefix="uc1" %>

<%@ Register Src="../../Ctrl/Wait/wait.ascx" TagName="wait" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function KeyPress(sender, args) {
            var regexp = new RegExp("[0-9]{1}|[\b]|\t|\r");
            if (!args.get_keyCharacter().match(regexp))
                args.set_cancel(true);
        }
        function RowDblClick(sender, eventArgs) {
            sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <asp:Panel ID="Panel1" runat="server" CssClass="panmar"
        GroupingText="Gestión de Proveedores">
        <table cellspacing="0" class="panmar">
            <tr>
                <td class="aatl" style="width:100%">
                    <asp:Panel ID="Panel5" runat="server" CssClass="panmar2"
                        GroupingText="Proveedores">
                        <asp:Panel ID="pangru1" runat="server" CssClass="panmar2">
                            <asp:UpdatePanel ID="upcmd" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:ImageButton ID="ibgr7" runat="server" CausesValidation="False"
                                        CssClass="relo" Height="20px" ImageUrl="~/Img/add.png" OnClick="ibgr7_Click"
                                        TabIndex="99" ToolTip="Agregar Proveedor" Width="21px" />
                                    &nbsp;<asp:ImageButton ID="ibgr8" runat="server" CausesValidation="False"
                                        CssClass="relo" Height="21px" ImageUrl="~/Img/pen.png" OnClick="ibgr8_Click"
                                        TabIndex="99" ToolTip="Editar Proveedor" Width="21px" />
                                    &nbsp;<asp:ImageButton ID="ibgr9" runat="server" CausesValidation="False"
                                        CssClass="relo" Height="19px" ImageUrl="~/Img/del.png" OnClick="ibgr9_Click"
                                        TabIndex="99" ToolTip="Eliminar Proveedor" Width="20px" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </asp:Panel>
                        <asp:UpdatePanel ID="upgrid" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="divv">
                                    <telerik:RadGrid ID="rgproveedor" runat="server" AllowFilteringByColumn="True"
                                        AllowPaging="True" AllowSorting="True" CellSpacing="0" Culture="en-US"
                                        DataSourceID="SqlDataSource1" GridLines="None" ShowGroupPanel="True"
                                        Width="99%">
                                        <GroupingSettings CollapseTooltip="Juntar Grupo" ExpandTooltip="Expandir Grupo"
                                            GroupContinuedFormatString="... el grupo continúa de la página anterior."
                                            GroupContinuesFormatString="El grupo continúa en la siguiente página"
                                            GroupSplitDisplayFormat="Mostrando {0} de {1} items."
                                            UnGroupButtonTooltip="Click aquí para desagrupar" UnGroupTooltip="" />
                                        <HierarchySettings CollapseTooltip="Agrupar" ExpandTooltip="Expandir" />
                                        <ExportSettings FileName="CaymanFile">
                                            <Pdf PageHeight="297mm" PageWidth="210mm" PaperSize="A4" />
                                        </ExportSettings>
                                        <ClientSettings AllowDragToGroup="True">
                                            <Selecting AllowRowSelect="True" />
                                            <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                                        </ClientSettings>
                                        <GroupPanel Text="Arrastre el encabezado de una columna aquí para agrupar los items por esa columna">
                                        </GroupPanel>
                                        <MasterTableView AutoGenerateColumns="False" DataKeyNames="ID"
                                            DataSourceID="SqlDataSource1"
                                            NoDetailRecordsText="No hay registros hijos para mostrar."
                                            NoMasterRecordsText="No hay registros para mostrar." PageSize="25">
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
                                                <telerik:GridBoundColumn DataField="ID" DataType="System.Int32"
                                                    FilterControlAltText="Filter ID column" HeaderText="ID" ReadOnly="True"
                                                    SortExpression="ID" UniqueName="ID">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="GRUPO"
                                                    FilterControlAltText="Filter GRUPO column" HeaderText="GRUPO"
                                                    SortExpression="GRUPO" UniqueName="GRUPO">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="NOMBRE"
                                                    FilterControlAltText="Filter NOMBRE column" HeaderText="NOMBRE"
                                                    SortExpression="NOMBRE" UniqueName="NOMBRE">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="RAZON"
                                                    FilterControlAltText="Filter RAZON column" HeaderText="RAZON"
                                                    SortExpression="RAZON" UniqueName="RAZON">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="RUC"
                                                    FilterControlAltText="Filter RUC column" HeaderText="RUC" SortExpression="RUC"
                                                    UniqueName="RUC">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="CONTACTO"
                                                    FilterControlAltText="Filter CONTACTO column" HeaderText="CONTACTO"
                                                    SortExpression="CONTACTO" UniqueName="CONTACTO">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="PAIS"
                                                    FilterControlAltText="Filter PAIS column" HeaderText="PAIS"
                                                    SortExpression="PAIS" UniqueName="PAIS">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="CIUDAD"
                                                    FilterControlAltText="Filter CIUDAD column" HeaderText="CIUDAD"
                                                    SortExpression="CIUDAD" UniqueName="CIUDAD">
                                                </telerik:GridBoundColumn>
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
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                            ConnectionString="<%$ ConnectionStrings:base %>"
                            SelectCommand="SELECT PROVEEDOR.PRO_ID AS ID, PROVEEDOR.PRO_NOMBRE AS NOMBRE, PROVEEDOR.PRO_RAZON AS RAZON, PROVEEDOR.PRO_RUC AS RUC, PROVEEDOR.PRO_CONTACTO AS CONTACTO, PROVEEDOR.PRO_CREDITO AS CREDITO, PAIS.PAI_NOMBRE AS PAIS, PAIS_1.PAI_NOMBRE AS ESTADO, PAIS_2.PAI_NOMBRE AS CIUDAD, GRUPO.GRU_NOMBRE AS GRUPO FROM PROVEEDOR INNER JOIN GRUPO ON PROVEEDOR.GRU_ID = GRUPO.GRU_ID INNER JOIN PAIS ON PROVEEDOR.PAI_ID1 = PAIS.PAI_ID INNER JOIN PAIS AS PAIS_1 ON PROVEEDOR.PAI_ID2 = PAIS_1.PAI_ID INNER JOIN PAIS AS PAIS_2 ON PROVEEDOR.PAI_ID3 = PAIS_2.PAI_ID"></asp:SqlDataSource>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Label ID="Label2" runat="server"></asp:Label>
    <asp:ModalPopupExtender ID="mp2" runat="server" Y="20"
        BackgroundCssClass="modalBackground" DynamicServicePath="" Enabled="True"
        PopupControlID="pan2" TargetControlID="Label2">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pan2" runat="server" Height="500px"
        Width="550px" style="display:none">
        <%--style="display:none"--%>
        <asp:UpdatePanel ID="upnuevo2" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table style="background-color: white; margin-left:0px" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="style2">
                            <table cellpadding="0" cellspacing="0" class="mess" width="100%">
                                <tr>
                                    <td class="style4" width="15">&nbsp;</td>
                                    <td>
                                        <asp:Label ID="lblmp2" runat="server" ForeColor="White"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="1" cellspacing="1" class="panmar2" width="409">
                                <tr>
                                    <td width="95">
                                        <h6>Grupo:<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                            ControlToValidate="ddGrupo" ErrorMessage="Seleccione Grupo"
                                            ValidationGroup="22" ForeColor="Red">*</asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="RequiredFieldValidator7_ValidatorCalloutExtender"
                                                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator7">
                                            </asp:ValidatorCalloutExtender>
                                        </h6>
                                    </td>
                                    <td>
                                        <div class="form-group small">
                                            <asp:DropDownList ID="ddGrupo" runat="server" CssClass="txtdd">
                                            </asp:DropDownList>
                                            <asp:CascadingDropDown ID="cddgru1" runat="server" Category="gru1"
                                                Enabled="True" LoadingText="[Cargando Grupo...]" PromptText="• Seleccione •"
                                                ServiceMethod="GetGru1" ServicePath="ws.asmx" TargetControlID="ddGrupo">
                                            </asp:CascadingDropDown>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="95">Razón Social:</td>
                                    <td>
                                        <div class="form-group small">
                                            <telerik:RadTextBox ID="txtrazon" runat="server" MaxLength="150" Width="415px" CssClass="form-control">
                                            </telerik:RadTextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <h6>Nombre:
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                            ControlToValidate="txtnombre" ErrorMessage="Ingrese Nombre"
                                            ValidationGroup="22" ForeColor="Red">*</asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="vce2" runat="server" Enabled="True"
                                                TargetControlID="RequiredFieldValidator3">
                                            </asp:ValidatorCalloutExtender>
                                        </h6>
                                    </td>
                                    <td>
                                        <div class="form-group small">
                                            <telerik:RadTextBox ID="txtnombre" runat="server" MaxLength="150" Width="415px" CssClass="form-control">
                                            </telerik:RadTextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <h6>RUC:</h6>
                                    </td>
                                    <td>
                                        <div class="form-group small">
                                            <telerik:RadTextBox ID="txtruc" runat="server"
                                                MaxLength="20" Width="120px" CssClass="form-control">
                                            </telerik:RadTextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <h6>Contacto:<asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                                            runat="server" ControlToValidate="txtcontacto" ErrorMessage="Ingrese Contacto"
                                            ValidationGroup="22" ForeColor="Red">*</asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="RequiredFieldValidator4_ValidatorCalloutExtender"
                                                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator4">
                                            </asp:ValidatorCalloutExtender>
                                        </h6>
                                    </td>
                                    <td>
                                        <div class="form-group small">
                                            <telerik:RadTextBox ID="txtcontacto" runat="server" MaxLength="150"
                                                Width="415px" CssClass="form-control">
                                            </telerik:RadTextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="aacl">
                                        <h6>Dirección:</h6>
                                    </td>
                                    <td>
                                        <div class="form-group small">
                                            <telerik:RadTextBox ID="txtdireccion" runat="server" MaxLength="150"
                                                TextMode="MultiLine" Width="415px" CssClass="form-control">
                                            </telerik:RadTextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>

                                    </td>
                                    <td>
                                        <table style="width: 100%">
                                            <tr>
                                                <td>
                                                    <div class="form-group small">
                                                        Teléfono
                                                        <telerik:RadTextBox ID="txttelefono" runat="server" MaxLength="150"
                                                            Width="200px" CssClass="form-control">
                                                        </telerik:RadTextBox>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="form-group small">
                                                        Celular
                                                        <telerik:RadTextBox ID="txtcelular" runat="server"
                                                            MaxLength="9" Width="100px" CssClass="form-control">
                                                        </telerik:RadTextBox>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="form-group small">
                                                        Fax
                                                        <telerik:RadTextBox ID="txtfax" runat="server" CssClass="form-control"
                                                            MaxLength="9" Width="100px">
                                                        </telerik:RadTextBox>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>

                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <h6>Email:</h6>
                                    </td>
                                    <td>
                                        <div class="form-group small">
                                            <telerik:RadTextBox ID="txtemail" runat="server" MaxLength="150" Width="415px" CssClass="form-control">
                                            </telerik:RadTextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <h6>Crédito:<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                            ControlToValidate="txtcredito" ErrorMessage="Ingrese Crédito"
                                            ValidationGroup="22" ForeColor="Red">*</asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="RequiredFieldValidator5_ValidatorCalloutExtender"
                                                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator5">
                                            </asp:ValidatorCalloutExtender>
                                        </h6>
                                    </td>
                                    <td>
                                        <div class="form-group small">
                                            Dias
                                        <telerik:RadTextBox ID="txtcredito" runat="server" CssClass="form-control"
                                            MaxLength="4" Width="50px">
                                        </telerik:RadTextBox>
                                            </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <h6>País:</h6>
                                    </td>
                                    <td>
                                        <div class="form-group small">
                                            <asp:DropDownList ID="ddUge1" runat="server" CssClass="txtdd">
                                            </asp:DropDownList>
                                            <asp:CascadingDropDown ID="cddgeo1" runat="server" Category="pai1"
                                                Enabled="True" LoadingText="[Cargando País...]" PromptText="• Seleccione •"
                                                ServiceMethod="GetPai1" ServicePath="ws.asmx" TargetControlID="ddUge1">
                                            </asp:CascadingDropDown>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <h6>Estado:</h6>
                                    </td>
                                    <td>
                                        <div class="form-group small">
                                            <asp:DropDownList ID="ddUge2" runat="server" CssClass="txtdd">
                                            </asp:DropDownList>
                                            <asp:CascadingDropDown ID="cddgeo2" runat="server" Category="pai2"
                                                Enabled="True" LoadingText="[Cargando Estado...]" ParentControlID="ddUge1"
                                                PromptText="• Seleccione •" ServiceMethod="GetPai2" ServicePath="ws.asmx"
                                                TargetControlID="ddUge2">
                                            </asp:CascadingDropDown>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <h6>Ciudad:<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                            ControlToValidate="ddUge3" ErrorMessage="Seleccione Ciudad"
                                            ValidationGroup="22">*</asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="RequiredFieldValidator6_ValidatorCalloutExtender"
                                                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator6">
                                            </asp:ValidatorCalloutExtender>
                                        </h6>
                                    </td>
                                    <td>
                                        <div class="form-group small">
                                            <asp:DropDownList ID="ddUge3" runat="server" CssClass="txtdd">
                                            </asp:DropDownList>
                                            <asp:CascadingDropDown ID="cddgeo3" runat="server" Category="pai3"
                                                Enabled="True" LoadingText="[Cargando Ciudad...]" ParentControlID="ddUge2"
                                                PromptText="• Seleccione •" ServiceMethod="GetPai3" ServicePath="ws.asmx"
                                                TargetControlID="ddUge3">
                                            </asp:CascadingDropDown>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="aacl">
                                        <h6>Observaciones:</h6>
                                    </td>
                                    <td>
                                        <div class="form-group small">
                                            <telerik:RadTextBox ID="txtobs" runat="server" MaxLength="150" Rows="3" CssClass="form-control"
                                                TextMode="MultiLine" Width="415px">
                                            </telerik:RadTextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td class="aatr">
                                        <asp:Button ID="btncerrar2" runat="server" CausesValidation="False" CssClass="btn btn-danger"
                                            OnClick="btncerrar2_Click" Text="Cerrar" />
                                        &nbsp;<asp:Button ID="btnsave2" runat="server" OnClick="btnsave2_Click" CssClass="btn btn-primary"
                                            Text="Guardar" ValidationGroup="22" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="mess">&nbsp;</td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
    </asp:Panel>

    <br />
    <uc1:messbox ID="messbox1" runat="server" />
</asp:Content>


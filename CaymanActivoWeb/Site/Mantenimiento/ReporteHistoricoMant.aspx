<%@ Page Language="C#" MasterPageFile="~/Site/Activos/cay.master" AutoEventWireup="true" CodeFile="ReporteHistoricoMant.aspx.cs" Inherits="Site_Mantenimiento_ReporteHistoricoMant" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Ctrl/Wait/wait.ascx" TagName="wait" TagPrefix="uc1" %>
<%@ Register Src="~/Ctrl/Msg/messbox.ascx" TagName="messbox" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style10 {
            width: 165px;
        }

        .style14 {
            width: 117px;
        }

        .style15 {
            width: 158px;
        }

        .style16 {
            width: 122px;
        }

        .style17 {
            width: 174px;
        }

        .style18 {
            width: 34px;
        }

        .style19 {
            width: 104px;
        }

        .auto-style1 {
            width: 140px;
        }

        .auto-style2 {
            width: 145px;
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
    <asp:Panel ID="panbus0" runat="server" CssClass="panmar"
        GroupingText="Buscar Activo - Mantenimientos Realizados">
        <table cellpadding="0" cellspacing="0" class="panmar2">
            <tr>
                <td>
                    <table cellspacing="0" class="style1">

                        <tr>
                            <td colspan="4">
                                <table class="style1">
                                    <tr>
                                        <td colspan="6">
                                            <table class="style1">
                                                <tr>
                                                    <td class="auto-style1">
                                                        <h5>Código de Barras:<asp:RequiredFieldValidator ID="rfv2" runat="server"
                                                            ControlToValidate="txtbuscb" ErrorMessage="Ingrese Código de Barras"
                                                            ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="rfv2_ValidatorCalloutExtender" runat="server"
                                                                Enabled="True" PopupPosition="BottomRight" TargetControlID="rfv2">
                                                            </asp:ValidatorCalloutExtender>
                                                        </h5>
                                                    </td>
                                                    <td class="style15">
                                                        <div class="form-group">
                                                            <telerik:RadTextBox ID="txtbuscb" runat="server" MaxLength="20" Width="150px" CssClass="form-control">
                                                                <ClientEvents OnKeyPress="KeyPress" />
                                                                <EmptyMessageStyle Font-Italic="True" />
                                                            </telerik:RadTextBox>
                                                        </div>
                                                    </td>
                                                    <td class="style18">
                                                        <asp:ImageButton ID="ibbus1" runat="server" CssClass="relo" Height="35px"
                                                            ImageUrl="~/Img/buscarblue.png" OnClick="ibbus1_Click" TabIndex="99"
                                                            ToolTip="Buscar Código de Barras" ValidationGroup="1" Width="35px" />
                                                    </td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style1">
                                                        <h5>Serie:
                                                                    <asp:RequiredFieldValidator ID="rfv_Serie" runat="server"
                                                                        ControlToValidate="txtbusid" ErrorMessage="Ingrese N° Serie"
                                                                        ForeColor="Red" ValidationGroup="2">*</asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server"
                                                                Enabled="True" PopupPosition="BottomRight" TargetControlID="rfv_Serie">
                                                            </asp:ValidatorCalloutExtender>
                                                        </h5>
                                                    </td>
                                                    <td class="style15">
                                                        <div class="form-group">
                                                            <telerik:RadTextBox ID="txtbusid" runat="server" MaxLength="40" Width="150px" CssClass="form-control">
                                                                <EmptyMessageStyle Font-Italic="True" />
                                                            </telerik:RadTextBox>
                                                        </div>
                                                    </td>
                                                    <td class="style18">
                                                        <asp:ImageButton ID="ibbus2" runat="server" Height="35px"
                                                            ImageUrl="~/Img/buscarblue.png" TabIndex="99"
                                                            ToolTip="Buscar N° Serie" ValidationGroup="2" Width="35px"
                                                            OnClick="ibbus2_Click" />
                                                    </td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style1">
                                                        <h5>Código Secundario:<asp:RequiredFieldValidator ID="rfv3" runat="server"
                                                            ControlToValidate="txtbusbnf" ErrorMessage="Ingrese Código Secundario"
                                                            ForeColor="Red" ValidationGroup="3">*</asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server"
                                                                Enabled="True" PopupPosition="BottomRight" TargetControlID="rfv3">
                                                            </asp:ValidatorCalloutExtender>
                                                        </h5>
                                                    </td>
                                                    <td class="style15">
                                                        <div class="form-group">
                                                            <telerik:RadTextBox ID="txtbusbnf" runat="server" MaxLength="40" Width="150px" CssClass="form-control">

                                                                <EmptyMessageStyle Font-Italic="True" />
                                                            </telerik:RadTextBox>
                                                        </div>
                                                    </td>
                                                    <td class="style18">
                                                        <asp:ImageButton ID="btnbusbnf" runat="server" CssClass="relo" Height="35px"
                                                            ImageUrl="~/Img/buscarblue.png" OnClick="btnbusbnf_Click" TabIndex="99"
                                                            ToolTip="Buscar BNF" ValidationGroup="3" Width="35px" />
                                                    </td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style2">&nbsp;&nbsp;<h5>&nbsp;&nbsp; Buscar Todos:</h5>
                                        </td>
                                        <td class="style17">
                                            <asp:CheckBox ID="chboxTodos" runat="server" AutoPostBack="True"
                                                OnCheckedChanged="chbpxTodos_CheckedChanged" Text="TODOS" />
                                        </td>
                                        <td class="style19">&nbsp;</td>
                                        <td class="style10">&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style2">&nbsp;</td>
                                        <td class="style17">&nbsp;</td>
                                        <td class="style19">&nbsp;</td>
                                        <td class="style10">&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="panReporte" runat="server" CssClass="panmar"
        GroupingText="Reporte Historico Mantenimientos - Activos" Visible="False">
        <div style="margin: 5px; overflow: scroll">

            <table width="100%">
                <tr>
                    <td>
                        <telerik:RadGrid ID="gv_ES" runat="server"
                            AutoGenerateColumns="true" CellSpacing="0" Font-Names="Century Gothic"
                            Font-Size="12px" GridLines="Horizontal"
                            PagerStyle-Mode="NumericPages"
                            Width="100%" Skin="Office2007" OnItemCommand="gv_ES_ItemCommand">
                            <ExportSettings HideStructureColumns="false">
                            </ExportSettings>
                            <MasterTableView CommandItemDisplay="Top" DataKeyNames="Código de Barras"
                                Font-Names="Century Gothic" NoMasterRecordsText="No Existen Registros....!!!!" Width="100%">
                                <CommandItemSettings ExportToExcelText="Exportar a Excel"
                                    ShowAddNewRecordButton="false" ShowExportToExcelButton="true"
                                    ShowRefreshButton="False" />
                                <CommandItemSettings ExportToExcelText="Exportar a Excel"
                                    ExportToPdfText="Export to PDF" RefreshText="Actualizar"
                                    ShowAddNewRecordButton="False" ShowExportToExcelButton="True" />
                                <CommandItemSettings ExportToExcelText="Exportar a Excel"
                                    ExportToPdfText="Export to PDF" ShowAddNewRecordButton="False"
                                    ShowExportToExcelButton="True" ShowRefreshButton="False" />
                                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                </ExpandCollapseColumn>
                                <%--<Columns>
                                                        <telerik:GridBoundColumn DataField="CodigoBarras" 
                                                            FilterControlAltText="Filter column column" HeaderText="Código Barras" 
                                                            UniqueName="column">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="Empresa" 
                                                            FilterControlAltText="Filter column1 column" HeaderText="Empresa" 
                                                            UniqueName="column1">
                                                            <HeaderStyle Width = "190px" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="Movimiento" 
                                                            FilterControlAltText="Filter Movimiento column" HeaderText="Movimiento" 
                                                            ReadOnly="True" SortExpression="Movimiento" UniqueName="Movimiento">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="Tipo" 
                                                            FilterControlAltText="Filter column2 column" HeaderText="Tipo Activo" 
                                                            UniqueName="column2">
                                                            <HeaderStyle Width = "90px" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="Descripcion" 
                                                            FilterControlAltText="Filter Descripcion column" HeaderText="Descripción" 
                                                            ReadOnly="True" SortExpression="Descripción" UniqueName="Descripcion">
                                                            <HeaderStyle Width = "300px" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="Marca" 
                                                            FilterControlAltText="Filter Marca column" 
                                                            HeaderText="Marca" ReadOnly="True" 
                                                            SortExpression="Marca" UniqueName="Marca">
                                                            <HeaderStyle Width = "150px" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="Modelo" 
                                                            FilterControlAltText="Filter Modelo column" HeaderText="Modelo" 
                                                            ReadOnly="True" SortExpression="Modelo" UniqueName="Modelo">
                                                        <HeaderStyle Width = "150px" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="Serie" 
                                                            FilterControlAltText="Filter Serie column" HeaderText="Serie" 
                                                            ReadOnly="True" SortExpression="Serie" UniqueName="Serie">
                                                        <HeaderStyle Width = "150px" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="act_fecharegistro" 
                                                            FilterControlAltText="Filter act_fecharegistro column" HeaderText="Fecha de Registro Movimiento" 
                                                            ReadOnly="True" SortExpression="Fecha Movimiento" UniqueName="act_fecharegistro">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="act_hora" 
                                                            FilterControlAltText="Filter act_hora column" HeaderText="Hora de Registro de Movimiento" 
                                                            SortExpression="Hora Movimiento" UniqueName="act_hora">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="act_usuario" 
                                                            FilterControlAltText="Filter act_usuario column" 
                                                            HeaderText="Usuario Registro Movimiento" ReadOnly="True" 
                                                            SortExpression="usuario" UniqueName="act_usuario">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="Observacion" 
                                                            FilterControlAltText="Filter column3 column" HeaderText="Observaciones" 
                                                            UniqueName="column3">
                                                        </telerik:GridBoundColumn>
                                                    </Columns>--%>
                                <EditFormSettings>
                                    <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                    </EditColumn>
                                </EditFormSettings>
                            </MasterTableView>
                            <%--<ClientSettings>
                                                <Scrolling AllowScroll = "true"  SaveScrollPosition = "true" UseStaticHeaders = "true"/>
                                                </ClientSettings>--%>
                            <PagerStyle Mode="NumericPages" />
                            <FilterMenu EnableImageSprites="False">
                            </FilterMenu>
                            <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Office2007">
                            </HeaderContextMenu>
                        </telerik:RadGrid>
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <br />
    <br />

    <uc2:messbox ID="messbox1" runat="server" />
    <asp:ValidationSummary ID="vs1" runat="server" ShowMessageBox="True"
        ShowSummary="False" />
</asp:Content>




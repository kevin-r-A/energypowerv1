<%@ Page Title="" Language="C#" MasterPageFile="~/Site/Activos/cay.master" AutoEventWireup="true" CodeFile="WF_RepoGlobal.aspx.cs" Inherits="WF_RepoGlobal" EnableEventValidation="false" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Register src="../../Ctrl/Msg/messbox.ascx" tagname="messbox" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
    function KeyPress(sender, args) {
        var regexp = new RegExp("[0-9]{1}|[\b]|\t|\r");
        if (!args.get_keyCharacter().match(regexp))
            args.set_cancel(true);
    }  
    </script>
    <style type="text/css">
        .style3
        {
            height: 18px;
        }
        .style7
        {
            width: 69px;
            height: 26px;
        }
        .style8
        {
            width: 152px;
            height: 26px;
        }
        .style9
        {
            width: 96px;
            height: 26px;
            margin-left: 40px;
        }
        .style10
        {
            height: 26px;
        }
        .style11
        {
            width: 96px;
        }
        .style12
        {
            width: 152px;
        }
        .style13
        {
            width: 737px;
        }
        .style14
        {
            width: 417px;
        }
        .style15
        {
            width: 474px;
        }
        .style16
        {
            width: 690px;
        }
        .style17
        {
            width: 100%;
        }
        .style18
        {
            width: 67px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" CssClass="panmar" 
        GroupingText="Reporte Lectura RFID" Font-Names="Century Gothic">
        <table cellspacing="0" class="panmar">
            <tr>
                <td class="aatl" width="100%">
                    <asp:Panel ID="Panel5" runat="server" CssClass="panmar">
                        <%--<asp:UpdatePanel ID="upcol" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>--%>
                                <table width = "100%">
                                <tr>
                                    <td class="style7">
                                        Tipo:</td>
                                    <td class="style8">
                                        <telerik:RadComboBox ID="cmbTipoBien" Runat="server" AutoPostBack="True" 
                                            Width="152px">
                                        </telerik:RadComboBox>
                                    </td>
                                    <td class="style9">
                                        <asp:CheckBox ID="chboxTodos" runat="server" AutoPostBack="True" 
                                            Font-Bold="True" oncheckedchanged="chboxTodos_CheckedChanged" Text="TODOS" Width = "85px" />
                                    </td>
                                    <td class="style10">
                                        &nbsp;</td>
                                </tr>
                                    <tr>
                                        <td>
                                            Código:</td>
                                        <td valign = "bottom" class="style12">
                                            <asp:TextBox ID="txtCodigo" runat="server" Width="142px" MaxLength="20"></asp:TextBox>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                        <td valign="bottom">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Fecha:</td>
                                        <td class="style12" valign="bottom">
                                            <telerik:RadDatePicker ID="rdp_Desde" Runat="server">
                                            </telerik:RadDatePicker>
                                        </td>
                                        <td class="style11" valign="bottom">
                                            <telerik:RadDatePicker ID="rdp_Hasta" Runat="server">
                                            </telerik:RadDatePicker>
                                        </td>
                                        <td valign="bottom">
                                            <asp:CheckBox ID="chboxTodosFechas" runat="server" AutoPostBack="True" 
                                                Font-Bold="True" Text="Por Fechas" 
                                                Width="106px" oncheckedchanged="chboxTodosFechas_CheckedChanged" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <table class="style17">
                                                <tr>
                                                    <td class="style18">
                                                        &nbsp;</td>
                                                    <td class="style11">
                                                        <asp:ImageButton ID="btnBuscar" runat="server" Height="29px" 
                                                            ImageUrl="~/Img/btnbuscar11.png" onclick="btnBuscar_Click" Width="86px" />
                                                    </td>
                                                    <td>
                                                        <asp:ImageButton ID="ibxls1" runat="server" Height="29px" 
                                                            ImageUrl="~/Img/xls1.png" onclick="ibxls1_Click" Width="110px" />
                                                    </td>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                
                               
                            <%--</ContentTemplate>
                            
                        </asp:UpdatePanel>--%>
                        <table width = "100%">
        <tr>
            <td class="style16">
                &nbsp;</td>
            <td class="style13">
            
                &nbsp;</td>
            <td class="style15">
                &nbsp;</td>
            <td class="style14">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
                        <table width = "100%">
                                    <tr>
                                        <td align = "center" colspan="2">
                                            <telerik:RadGrid ID="gv_Activos" runat="server" Width = "100%" 
                                                AllowMultiRowSelection="True" AutoGenerateColumns="False" CellSpacing="0" 
                                                GridLines="Horizontal"  
                                                Skin="Office2007" onneeddatasource="gv_Activos_NeedDataSource" 
                                                AllowPaging="True" PageSize = "20" PagerStyle-AlwaysVisible = "false"
                                                onpageindexchanged="gv_Activos_PageIndexChanged" 
                                                onpagesizechanged="gv_Activos_PageSizeChanged">
                                                <MasterTableView>
                                                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                                                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                                    </RowIndicatorColumn>
                                                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                                    </ExpandCollapseColumn>
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="ID" 
                                                            FilterControlAltText="Filter column column" HeaderText="ID" UniqueName="ID">
                                                            <ItemStyle Width = "50px" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="Codigo de Barras" 
                                                            FilterControlAltText="Filter column1 column" HeaderText="Código de Barras" 
                                                            UniqueName="Codigo">
                                                            <ItemStyle Width = "90px" />
                                                        </telerik:GridBoundColumn>
                                                       <telerik:GridBoundColumn DataField="Codigo Secundario" 
                                                            FilterControlAltText="Filter column1 column" HeaderText="Código Secundario" 
                                                            UniqueName="CodigoLogikard">
                                                            <ItemStyle Width = "100px" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="Grupo" 
                                                            FilterControlAltText="Filter column column" HeaderText="Grupo/Cuenta" 
                                                            UniqueName="column">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="Nombre Bien" 
                                                            FilterControlAltText="Filter column2 column" HeaderText="Descripcion" 
                                                            UniqueName="column2">
                                                        
                                                            <ItemStyle Width = "170px" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="custodio" 
                                                            FilterControlAltText="Filter column12 column" HeaderText="Custodio" 
                                                            UniqueName="column12">
                                                        
                                                            <ItemStyle Width = "150px" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="Tipo" 
                                                            FilterControlAltText="Filter column3 column" HeaderText="Tipo Bien" 
                                                            UniqueName="column3">
                                                  <ItemStyle Width = "100px" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="Estado" 
                                                            FilterControlAltText="Filter column4 column" HeaderText="Estado Lectura" 
                                                            UniqueName="column4">
                                                <ItemStyle Width = "100px" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="Fecha" 
                                                            FilterControlAltText="Filter column4 column" HeaderText="Fecha Lectura" 
                                                            UniqueName="column5">
                                                            <ItemStyle Width = "120px" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="Hora" 
                                                            FilterControlAltText="Filter column4 column" HeaderText="Hora Lectura" 
                                                            UniqueName="column6">
                                                            
                                                            <ItemStyle Width = "80px" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="Portal" 
                                                            FilterControlAltText="Filter column4 column" HeaderText="Portal RFID" 
                                                            UniqueName="column7">
                                                          <ItemStyle Width = "100px" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="Antena" 
                                                            FilterControlAltText="Filter column column" HeaderText="Antena RFID" 
                                                            UniqueName="antena">
                                                   <ItemStyle Width = "80px" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="Movimiento" Visible = "false" 
                                                            FilterControlAltText="Filter column column" HeaderText="Movimiento" 
                                                            UniqueName="mov">
                                                   <ItemStyle Width = "80px" />
                                                        </telerik:GridBoundColumn>
                                                    </Columns>
                                                    <EditFormSettings>
                                                        <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                                        </EditColumn>
                                                    </EditFormSettings>
                                                  </MasterTableView>
                                                <FilterMenu EnableImageSprites="False">
                                                </FilterMenu>
                                                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                                                </HeaderContextMenu>
                                            </telerik:RadGrid>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3">
                                            &nbsp;</td>
                                        <td class="style3">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align = "center" colspan="2">
                                            <asp:GridView ID="rgreportexls" runat="server" 
                                                AlternatingRowStyle-CssClass="alt" CssClass="mGrid" DataKeyNames="Id" 
                                                EmptyDataText="No se encontraron registros que coincidan con la busqueda." 
                                                PagerStyle-CssClass="pgr" Width="859px">
                                                <AlternatingRowStyle BackColor="#F8FBFE" />
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <PagerSettings FirstPageText="Primera" LastPageText="Ultima" 
                                                    PageButtonCount="30" />
                                                <PagerStyle CssClass="pgr" />
                                                <SelectedRowStyle BackColor="#FFFF99" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                        <%--<asp:UpdateProgress AssociatedUpdatePanelID ="upcol" runat = "server">
                        
                         <ProgressTemplate>
        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
            <span style="border-width: 0px; position: fixed; padding: 50px; background-color: #FFFFFF; font-size: 36px; left: 40%; top: 40%;">Cargado ...</span>
        </div>
    </ProgressTemplate>
                        </asp:UpdateProgress>--%>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <uc1:messbox ID="messbox1" runat="server" />
</asp:Content>


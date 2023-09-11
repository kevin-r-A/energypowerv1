<%@ Page Title="" Language="C#" MasterPageFile="~/Site/Activos/cay.master" AutoEventWireup="true" CodeFile="ReportePadreHijo.aspx.cs" Inherits="ReportePadreHijo" EnableEventValidation="false" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register src="../../Ctrl/Wait/wait.ascx" tagname="wait" tagprefix="uc1" %>
<%@ Register src="../../Ctrl/Msg/messbox.ascx" tagname="messbox" tagprefix="uc2" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="cph1">
    <asp:Panel ID="pancus" runat="server" CssClass="panmar" Visible="True">
        <table cellspacing="0" class="panmar" width="100%">
            <tr>
                <td class="aatl" width="100%">
                    <table cellspacing="0" class="style1">
                        <tr>
                            <td class="aatr">
                                &nbsp;&nbsp;</td>
                        </tr>
                    </table>
                    <asp:UpdatePanel ID="upgrid" runat="server" UpdateMode="Conditional">

                        <ContentTemplate>
                            <telerik:RadTreeList ID="RadTreeList1" runat="server"  OnNeedDataSource="RadTreeList1_NeedDataSource"
                                AutoGenerateColumns="False" ParentDataKeyNames="parentID" 
                                AllowMultiItemSelection="True" AllowPaging="True" PageSize="30" 
                                DataKeyNames="codigosbarras" AllowSorting="True" BorderColor="#404040" 
                                Skin="Office2007"  Height="794px">
                                <Columns>
                                    <telerik:TreeListTemplateColumn UniqueName="Editar" HeaderStyle-Width="40" DataField="ID"  >
                                        <ItemTemplate>
                                        
                                           <asp:HyperLink ID="hk2" runat="server" ImageUrl="~/Img/editar.gif" DataField="ID" 
                                            Target="_blank" ToolTip="Editar Item"  
                                            NavigateUrl ='<%# string.Concat("Modificar.aspx?id=" ,DataBinder.Eval(Container, "DataItem.ID")) %>'  ></asp:HyperLink>
                                        </ItemTemplate>
                                     </telerik:TreeListTemplateColumn>
                                    <telerik:TreeListBoundColumn DataField="Codigosbarras" UniqueName="Código de barras" HeaderText="Código de barras">
                                    </telerik:TreeListBoundColumn>
                                    <telerik:TreeListBoundColumn DataField="Descripcion" UniqueName="Descripción" HeaderText="Descripción">
                                    </telerik:TreeListBoundColumn>
                                    <telerik:TreeListBoundColumn DataField="Valor" UniqueName="Valor" HeaderText="Valor">
                                    </telerik:TreeListBoundColumn>
<%--                                    <telerik:TreeListCalculatedColumn UniqueName="CalculatedColumn" HeaderText="Valor total"
                                    DataFields="Price, Discount" DataType="System.Double" Expression='{0}-{1}' DataFormatString="{0:C}"
                                     HeaderStyle-Width="100px">
                                    </telerik:TreeListCalculatedColumn>--%>
                                </Columns>
                                <ItemStyle ForeColor="#404040" />
                            </telerik:RadTreeList>
                            
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <uc2:messbox ID="messbox1" runat="server" />
    <telerik:RadAjaxManager runat="server">
    </telerik:RadAjaxManager>
</asp:Content>



<%@ Page Title="" Language="C#" MasterPageFile="~/Site/Activos/cay.master" AutoEventWireup="true" CodeFile="ExplorerPdf_Baja.aspx.cs" Inherits="ExplorerPdf_Baja" EnableEventValidation="false" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register src="../../Ctrl/Wait/wait.ascx" tagname="wait" tagprefix="uc1" %>
<%@ Register src="../../Ctrl/Msg/messbox.ascx" tagname="messbox" tagprefix="uc2" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="cph1">

    <asp:Panel ID="pantras" runat="server" CssClass="panmar" 
        GroupingText="Documentos Adjuntos de Activos Dados de Baja">
        <table cellspacing="0" class="panmar" width="100%">
            <tr>
                <td class="aatl" width="100%">
                    <asp:UpdatePanel ID="uptras" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:GridView ID="rgtras" runat="server" 
                                AlternatingRowStyle-CssClass="alt" CssClass="mGrid table table-hover" GridLines="None" 
                                PagerStyle-CssClass="pgr" Font-Names="Arial" Font-Size="9pt" 
                                AutoGenerateColumns="False">
                                <AlternatingRowStyle CssClass="alt" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:HyperLink ID="systemLink" runat="server" 
                                                NavigateUrl='<%# string.Concat("adjuntos_baja/" , DataBinder.Eval(Container, "DataItem.Name") ) %>' 
                                                Target="_blank">Abrir Archivo &gt;&gt;</asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Name" HeaderText="Archivo Generado" />
                                    <asp:BoundField DataField="CreationTime" HeaderText="Fecha de Creación" />
                                </Columns>
                                <HeaderStyle HorizontalAlign="Left" />
                                <PagerStyle CssClass="pgr" />
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <uc2:messbox ID="messbox1" runat="server" />
    </asp:Content>



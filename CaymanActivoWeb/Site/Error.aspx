<%@ Page Title="" Language="C#" MasterPageFile="~/Site/Activos/cay.master" AutoEventWireup="true" CodeFile="Error.aspx.cs" Inherits="Error" EnableEventValidation="false" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Register src="../Ctrl/Wait/wait.ascx" tagname="wait" tagprefix="uc1" %>

<%@ Register src="../Ctrl/Msg/messbox.ascx" tagname="messbox" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="cph1">
<asp:Panel ID="panbus" runat="server" CssClass="panmar" GroupingText="Problemas en la Aplicación">
    <table cellspacing="0" class="panmar">
        <tr>
            <td>
                <asp:Label ID="lblerror" runat="server" CssClass="panmar" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Panel>
    </asp:Content>



<%@ Page Language="C#" MasterPageFile="~/Site/Activos/cay.master" AutoEventWireup="true" CodeFile="RolesUsuarios.aspx.cs" Inherits="RolesUsuarios" EnableEventValidation="false" %>
<%@ Register src="../../Ctrl/Msg/messbox.ascx" tagname="messbox" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            width: 370px;
            height: 17px;
        }
        .auto-style3 {
            width: 370px;
        }
        .auto-style4 {
            width: 142px
        }
        .auto-style5 {
            width: 142px;
            height: 35px;
        }
        .auto-style6 {
            height: 35px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" Runat="Server">
    <asp:Panel ID="panus" runat="server" CssClass="panmar" 
        GroupingText="Gestionar Roles por Usuario">
        <table cellspacing="0" class="panmar">
            <tr>
                <td>
                    <table style="width:100%">
                        <tr>
                            <td class="auto-style5">
                                <h5>Seleccione Usuario:</h5></td>
                            <td class="auto-style6">
                                <asp:DropDownList ID="UserList" runat="server" AutoPostBack="True" Width="20%"
                                    CssClass="txtdd" DataTextField="UserName" DataValueField="UserName" 
                                    onselectedindexchanged="UserList_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style4">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style12" colspan="2">
                                <table class="style11">
                                    <tr>
                                        <td class="auto-style3">
                                            <h5><b>ROLES ASIGNADOS</b></h5></td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style2">
                                            </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style3">
                                            <asp:Repeater ID="UsersRoleList" runat="server">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="RoleCheckBox" runat="server" AutoPostBack="true" 
                                                        OnCheckedChanged="RoleCheckBox_CheckChanged" Text="<%# Container.DataItem %>" />
                                                    <br />
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <uc1:messbox ID="messbox1" runat="server" />
</asp:Content>


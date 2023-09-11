<%@ Page Language="C#" MasterPageFile="~/Site/Activos/cay.master" AutoEventWireup="true" CodeFile="EliminarUsuarios.aspx.cs" Inherits="EliminarUsuarios" EnableEventValidation="false" %>
<%@ Register src="../../Ctrl/Msg/messbox.ascx" tagname="messbox" tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 133px;
        }
        .auto-style2 {
            width: 177px;
        }
        .auto-style3 {
            width: 3px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" Runat="Server">
    <asp:Panel ID="panus" runat="server" CssClass="panmar" 
        GroupingText="Eliminar Usuarios">
        <table cellspacing="0" class="panmar">
            <tr>
                <td>
                    <table width="100%">
                        <tr>
                            <td class="auto-style1" valign="bottom">
                                <h5>Seleccione Usuario:</h5></td>
                            <td>
                                <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td class="auto-style2">
                                            <asp:DropDownList ID="UserList" runat="server" AutoPostBack="True" 
                                                CssClass="txtdd" DataTextField="UserName" DataValueField="UserName">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="auto-style3">
                                            &nbsp;</td>
                                        <td>
                                            <asp:ImageButton ID="ibtnDelUsu" runat="server" Height="28px" 
                                                ImageUrl="~/Img/delUsu.png" onclick="ibtnDelUsu_Click" Width="102px" />
                                            <asp:ConfirmButtonExtender ID="cbeDelusu" runat="server" 
                                                ConfirmText="Está seguro que quiere eliminar el usuario seleccionado?" 
                                                Enabled="True" TargetControlID="ibtnDelUsu">
                                            </asp:ConfirmButtonExtender>
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


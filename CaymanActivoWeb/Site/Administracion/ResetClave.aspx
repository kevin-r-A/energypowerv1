<%@ Page Language="C#" MasterPageFile="~/Site/Activos/cay.master" AutoEventWireup="true" CodeFile="ResetClave.aspx.cs" Inherits="ResetClave" EnableEventValidation="false" %>
<%@ Register src="../../Ctrl/Msg/messbox.ascx" tagname="messbox" tagprefix="uc1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <style type="text/css">
        .auto-style1 {
            width: 145px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" Runat="Server">
    <asp:Panel ID="panus" runat="server" CssClass="panmar" 
        GroupingText="Cambiar Contraseña de Usuario">
        <table cellspacing="0" class="panmar">
            <tr>
                <td>
                    <table class="style11">
                        <tr>
                            <td>
                                <h5>Seleccione Usuario:</h5></td>
                            <td>
                                <div class="form-group">
                                <asp:DropDownList ID="UserList" runat="server" AutoPostBack="True" 
                                    CssClass="txtdd" DataTextField="UserName" DataValueField="UserName">
                                </asp:DropDownList>
                                    </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <h5>Nueva Contraseña:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                                    runat="server" ControlToValidate="txtnuevaclave" 
                                    ErrorMessage="Ingrese Nueva Clave" ForeColor="Red">*</asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="vce1" runat="server" Enabled="True" 
                                    TargetControlID="RequiredFieldValidator1">
                                </asp:ValidatorCalloutExtender>
                                    </h5>
                            </td>
                            <td>
                                <asp:TextBox ID="txtnuevaclave" runat="server" CssClass="form-control" MaxLength="12" 
                                    Width="150px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style1">
                                &nbsp;</td>
                            <td class="atd">
                                <asp:ImageButton ID="ibCambiar" runat="server" Height="27px" 
                                    ImageUrl="~/Img/uc1.png" onclick="ibCambiar_Click" Width="164px" />
                                <asp:ConfirmButtonExtender ID="cbe1" runat="server" 
                                    ConfirmText="Está seguro que quiere cambiar la contraseña del usuario?" 
                                    Enabled="True" TargetControlID="ibCambiar">
                                </asp:ConfirmButtonExtender>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <uc1:messbox ID="messbox1" runat="server" />
</asp:Content>


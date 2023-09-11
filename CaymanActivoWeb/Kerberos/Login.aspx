<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Kerberos_Login" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Src="../Ctrl/Msg/messbox.ascx" TagName="messbox" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>INGRESO AL SISTEMA</title>
    <link href="../App_Themes/Theme1/css.css" rel="stylesheet" type="text/css" />
    <link rel="Stylesheet" type="text/css" href="<%=ResolveClientUrl("~/Bootstrap/css/bootstrap.min.css")%>" />
    <script type="text/javascript" src="../Bootstrap/js/bootstrap.js"></script>
</head>
<body style="background-image: url('../Img/FondoCayman.png'); background-position: center; background-repeat: no-repeat; background-attachment: fixed; background-size: cover;">
    <form id="form1" runat="server">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"
            EnableScriptGlobalization="True">
        </asp:ToolkitScriptManager>
        <div class="container">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                ShowMessageBox="True" ShowSummary="False" ValidationGroup="Login1" />
            <div class="panel panel-primary" style="margin-top: 15%; width: 50%; margin-left: 25%; margin-right: 30%; margin-bottom: 0%">
                <div class="panel-heading">INICIO DE SESION</div>
                <br />
                <div class="panel-body">
                    <div class="row">
                        <div class="col-xs-12 col-sm-12 col-md-6 col-lg-5">
                            <br />
                            <img src="<%=ResolveUrl("~/Img/logoLogin.png")%>" class="img-responsive" style="max-width: 100%; height: auto; text-align: center" />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-6 col-lg-7">
                            <asp:Panel ID="Panel3" runat="server" GroupingText="CAYMAN ACTIVO WEB">

                                <asp:Login ID="Login1" runat="server"
                                    DestinationPageUrl="~/Site/Principal.aspx"
                                    FailureText="Usuario y/o contraseña no validos."
                                    LoginButtonText="Ingresar al Sistema" PasswordLabelText="Contraseña:"
                                    RememberMeText="Recuerde mis datos en este equipo" TitleText=""
                                    UserNameLabelText="Usuario:" Width="95%" OnLoggedIn="Login1_LoggedIn"
                                    OnLoginError="Login1_LoginError">
                                    <LayoutTemplate>
                                        <table style="width: 100%">
                                            <tr>
                                                <td>
                                                    <div class="form-group">
                                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server"
                                                            ControlToValidate="UserName" ErrorMessage="Ingrese Usuario!"
                                                            ToolTip="Nombre de Usuario requerido!" ValidationGroup="Login1" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="input-group">
                                                        <span class="input-group-addon transparent"><span class="glyphicon glyphicon-user"></span></span>
                                                        <asp:TextBox ID="UserName" runat="server" Width="100%" CssClass="form-control" placeholder="USUARIO"></asp:TextBox>
                                                    </div>
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div class="form-group">
                                                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server"
                                                            ControlToValidate="Password" ErrorMessage="Ingrese Contraseña"
                                                            ToolTip="Contraseña Requerida!" ValidationGroup="Login1" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="input-group">
                                                        <span class="input-group-addon transparent"><span class="glyphicon glyphicon-lock"></span></span>
                                                        <asp:TextBox ID="Password" runat="server" TextMode="Password" Width="100%" CssClass="form-control" placeholder="CONTRASEÑA">123</asp:TextBox>
                                                    </div>
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="font-family: 'Century Gothic'">
                                                    <div class="form-group">
                                                        <asp:RequiredFieldValidator ID="PasswordRequired0" runat="server"
                                                            ControlToValidate="ddEmpresa" ErrorMessage="Seleccione Empresa"
                                                            ToolTip="Empresa Requerida" ValidationGroup="Login1" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    </div>
                                                </td>

                                                <td>
                                                    <div class="form-group">
                                                        <asp:DropDownList ID="ddEmpresa" runat="server" CssClass="form-control" Font-Names="Century Gothic" Width="100%">
                                                        </asp:DropDownList>
                                                        <asp:CascadingDropDown ID="cddempresa" runat="server" Category="esa"
                                                            Enabled="True" LoadingText="[Cargando Empresa]"
                                                            PromptText="• Seleccione Empresa •" ServiceMethod="GetEmpresas"
                                                            ServicePath="ws.asmx" TargetControlID="ddEmpresa" UseContextKey="True">
                                                        </asp:CascadingDropDown>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" class="aacc" style="font-family: 'Century Gothic'">
                                                    <div class="form-group">
                                                        <asp:CheckBox ID="RememberMe" runat="server"
                                                            Text="Recuerde mis datos en este equipo" />
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="color: Red; font-family: 'Century Gothic'" class="aacc">
                                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" colspan="2">
                                                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" Width="130px"
                                                        Text="INGRESAR" ValidationGroup="Login1" CssClass="btn btn-primary" />
                                                </td>
                                            </tr>
                                        </table>
                                    </LayoutTemplate>
                                </asp:Login>

                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <uc1:messbox ID="messbox1" runat="server" />
    </form>
</body>

</html>
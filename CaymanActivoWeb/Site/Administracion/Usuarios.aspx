<%@ Page Language="C#" MasterPageFile="~/Site/Activos/cay.master" AutoEventWireup="true" CodeFile="Usuarios.aspx.cs" Inherits="Site_Administracion_Usuarios" EnableEventValidation="false" UICulture="es" Culture="es-EC" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Src="../../Ctrl/Msg/messbox.ascx" TagName="messbox" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     <script type="text/javascript">
         function OpenWindows(msg) {
             if (msg == 1)
                 alert("La Constraseña debe contener una Letra Mayuscula")
             else if (msg == 2) {
                 alert("La Constraseña debe contener una Un Numero")
             }
             else if (msg == 3) {
                 alert("Error, Comuniquese con el Proveedor")
             }
             else if (msg == 4) {
                 alert("Contraseña ya Fue utilizada, Intente con Otra...")
             }
         }
         </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <asp:Panel ID="panus" runat="server" CssClass="panmar"
        GroupingText="Crear Usuarios del Sistema">
        <table cellspacing="0" class="panmar">
            <tr>
                <td>
                    <div style="background-image: url('../../Img/usw.png'); background-repeat: no-repeat;">
                        <asp:CreateUserWizard ID="CreateUserWizard1" runat="server"
                            CancelButtonText="Cancelar" CompleteSuccessText="Cuenta Creada!."
                            ConfirmPasswordCompareErrorMessage="Ambas contraseñas deben ser iguales."
                            ConfirmPasswordLabelText="Confirme Contraseña"
                            ConfirmPasswordRequiredErrorMessage="Confirme la Contraseña"
                            ContinueButtonText="Continuar"
                            ContinueDestinationPageUrl="~/Site/Administracion/Usuarios.aspx"
                            CreateUserButtonText="Crear Usuario"
                            DuplicateEmailErrorMessage="Ingrese un email diferente"
                            DuplicateUserNameErrorMessage="Ingrese un usuario diferente"
                            EmailRegularExpressionErrorMessage="Ingrese un email diferente"
                            EmailRequiredErrorMessage="E-mail requerido" FinishPreviousButtonText="Atrás"
                            InvalidEmailErrorMessage="Ingrese un E-Mail válido"
                            InvalidPasswordErrorMessage="Longitud de contraseña mínima {0} caracteres."
                            LoginCreatedUser="False"
                            OnActiveStepChanged="CreateUserWizard1_ActiveStepChanged"
                            PasswordLabelText="Contraseña:"
                            PasswordRegularExpressionErrorMessage="Ingrese una clave diferente"
                            PasswordRequiredErrorMessage="Contraseña Requerida"
                            StartNextButtonText="Siguiente" StepNextButtonText="Siguiente"
                            StepPreviousButtonText="Atrás"
                            UnknownErrorMessage="Cuenta no creada. Inténtelo nuevamente!"
                            UserNameLabelText="Usuario:" UserNameRequiredErrorMessage="Usuario Requerido"
                            Width="340px" OnCreatingUser="CreateUserWizard1_CreatingUser">
                            <WizardSteps>
                                <asp:CreateUserWizardStep runat="server">
                                    <ContentTemplate>
                                        <table style="font-size: 100%; width: 340px;">
                                            <tr>
                                                <td align="center" colspan="3">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="3"></td>
                                            </tr>
                                            <tr>
                                                <td class="aacr">&nbsp;</td>
                                                <td width="14">&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="aacr">
                                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Usuario:</asp:Label>
                                                </td>
                                                <td width="14">
                                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server"
                                                        ControlToValidate="UserName" ErrorMessage="Usuario Requerido" ForeColor="Red"
                                                        ToolTip="Usuario Requerido" ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="vce1" runat="server" Enabled="True"
                                                        TargetControlID="UserNameRequired" WarningIconImageUrl="~/Img/warning.png">
                                                    </asp:ValidatorCalloutExtender>
                                                </td>
                                                <td>
                                                    <div class="form-group">
                                                        <asp:TextBox ID="UserName" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="aacr">
                                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Contraseña:</asp:Label>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server"
                                                        ControlToValidate="Password" ErrorMessage="Contraseña Requerida"
                                                        ForeColor="Red" ToolTip="Contraseña Requerida"
                                                        ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="vce2" runat="server" Enabled="True"
                                                        TargetControlID="PasswordRequired" WarningIconImageUrl="~/Img/warning.png">
                                                    </asp:ValidatorCalloutExtender>
                                                </td>
                                                <td>
                                                    <div class="form-group">
                                                        <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="aacr">
                                                    <asp:Label ID="ConfirmPasswordLabel" runat="server"
                                                        AssociatedControlID="ConfirmPassword">Confirme Contraseña:</asp:Label>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server"
                                                        ControlToValidate="ConfirmPassword" ErrorMessage="Confirme la Contraseña"
                                                        ForeColor="Red" ToolTip="Confirme la Contraseña"
                                                        ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="vce3" runat="server" Enabled="True"
                                                        TargetControlID="ConfirmPasswordRequired" WarningIconImageUrl="~/Img/warning.png">
                                                    </asp:ValidatorCalloutExtender>
                                                </td>
                                                <td>
                                                    <div class="form-group">
                                                        <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="aacr">
                                                    <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail:</asp:Label>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="EmailRequired" runat="server"
                                                        ControlToValidate="Email" ErrorMessage="E-mail requerido" ForeColor="Red"
                                                        ToolTip="E-mail requerido" ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="vce4" runat="server" Enabled="True"
                                                        TargetControlID="EmailRequired" WarningIconImageUrl="~/Img/warning.png">
                                                    </asp:ValidatorCalloutExtender>
                                                    <asp:RegularExpressionValidator ID="rfvemail" runat="server"
                                                        ControlToValidate="Email" ErrorMessage="Email Inválido" ForeColor="Red"
                                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                        ValidationGroup="CreateUserWizard1">*</asp:RegularExpressionValidator>
                                                    <asp:ValidatorCalloutExtender ID="vcemail" runat="server" Enabled="True"
                                                        TargetControlID="rfvemail" WarningIconImageUrl="~/Img/warning.png">
                                                    </asp:ValidatorCalloutExtender>
                                                </td>
                                                <td>
                                                    <div class="form-group">
                                                        <asp:TextBox ID="Email" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="3">
                                                    <asp:CompareValidator ID="PasswordCompare" runat="server"
                                                        ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                                                        Display="Dynamic" ErrorMessage="Ambas contraseñas deben ser iguales."
                                                        ForeColor="Red" ValidationGroup="CreateUserWizard1"></asp:CompareValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="3" style="color: Red;">
                                                    <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr style="height:20px">
                                                <td>

                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:CreateUserWizardStep>
                                <asp:WizardStep ID="SpecifyRolesStep" runat="server" AllowReturn="False"
                                    StepType="Step" Title="Asignar Roles">
                                    <asp:CheckBoxList ID="RoleList" runat="server">
                                    </asp:CheckBoxList>
                                </asp:WizardStep>
                                <asp:CompleteWizardStep runat="server" />
                            </WizardSteps>
                        </asp:CreateUserWizard>
                        <br />
                        <br />
                        <br />
                    </div>
                    <uc1:messbox ID="messbox1" runat="server" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>


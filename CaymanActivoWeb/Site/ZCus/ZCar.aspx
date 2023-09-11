<%@ Page Title="" Language="C#" MasterPageFile="~/Site/Activos/cay.master" AutoEventWireup="true" CodeFile="ZCar.aspx.cs" Inherits="ZCar" EnableEventValidation="false" %>

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
        .auto-style1 {
            width: 55px;
        }
        .auto-style2 {
            height: 17px;
        }
        .auto-style3 {
            width: 10px;
            height: 17px;
        }
        .auto-style4 {
            width: 10px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" CssClass="panmar" 
        GroupingText="Gestión de Cargos">
        <table cellspacing="0" class="panmar">
            <tr>
                <td class="aatl" width="100%">
                    <asp:Panel ID="Panel5" runat="server" CssClass="panmar" GroupingText="Cargo">
                        <asp:UpdatePanel ID="upcargo" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:Panel ID="pangru1" runat="server" CssClass="panmar2">
                                    <asp:ImageButton ID="ibgr7" runat="server" CausesValidation="False" 
                                        CssClass="relo" Height="20px" ImageUrl="~/Img/add.png" onclick="ibgr7_Click" 
                                        TabIndex="99" ToolTip="Agregar Cargo" Width="21px" />
                                    &nbsp;<asp:ImageButton ID="ibgr8" runat="server" CausesValidation="False" 
                                        CssClass="relo" Height="21px" ImageUrl="~/Img/pen.png" onclick="ibgr8_Click" 
                                        TabIndex="99" ToolTip="Editar Cargo" Width="21px" />
                                    &nbsp;<asp:ImageButton ID="ibgr9" runat="server" CausesValidation="False" 
                                        CssClass="relo" Height="19px" ImageUrl="~/Img/del.png" onclick="ibgr9_Click" 
                                        TabIndex="99" ToolTip="Eliminar Cargo" Width="20px" />
                                </asp:Panel>
                                <telerik:RadListBox ID="rlbcargo" runat="server" AutoPostBack="True" 
                                    CssClass="panmar" EmptyMessage="Cargos no Disponibles" Height="500px" 
                                    Width="95%">
                                    <ButtonSettings TransferButtons="All" />
                                    <EmptyMessageTemplate>
                                        Descripciones no disponibles
                                    </EmptyMessageTemplate>
                                </telerik:RadListBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Label ID="Label2" runat="server"></asp:Label>
    <asp:ModalPopupExtender ID="mp2" runat="server" 
        BackgroundCssClass="modalBackground" DynamicServicePath="" Enabled="True" 
        PopupControlID="pan2" TargetControlID="Label2">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pan2" runat="server" Height="142px" 
        Width="430px" style="display:none">
        <%--style="display:none"--%>
        <asp:UpdatePanel ID="upnuevo2" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table style="background-color:white" cellpadding="0" cellspacing="0" class="style1">
                    <tr>
                        <td class="mess">
                            <table cellpadding="0" cellspacing="0" class="style1">
                                <tr>
                                    <td width="10">
                                        &nbsp;</td>
                                    <td>
                                        <asp:Label ID="lblmp2" runat="server" ForeColor="White"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="panmar2">
                                <table cellspacing="0" width="409">
                                    <tr>
                                        <td width="55">
                                            <h6>Nombre:</h6></td>
                                        <td class="auto-style4">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtnombre2" ErrorMessage="Ingrese Nombre" ValidationGroup="22" ForeColor="Red">*</asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="vce2" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator3">
                                            </asp:ValidatorCalloutExtender>
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtnombre2" Runat="server" MaxLength="150" CssClass="form-control"
                                                Width="100%">
                                                <PasswordStrengthSettings CalculationWeightings="50;15;15;20" 
                                                    IndicatorElementBaseStyle="riStrengthBar" IndicatorElementID="" 
                                                    MinimumLowerCaseCharacters="2" MinimumNumericCharacters="2" 
                                                    MinimumSymbolCharacters="2" MinimumUpperCaseCharacters="2" 
                                                    OnClientPasswordStrengthCalculating="" PreferredPasswordLength="10" 
                                                    RequiresUpperAndLowerCaseCharacters="True" ShowIndicator="False" 
                                                    TextStrengthDescriptions="Very Weak;Weak;Medium;Strong;Very Strong" 
                                                    TextStrengthDescriptionStyles="riStrengthBarL0;riStrengthBarL1;riStrengthBarL2;riStrengthBarL3;riStrengthBarL4;riStrengthBarL5;" />
                                                <EmptyMessageStyle Font-Italic="True" />
                                            </telerik:RadTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style2">
                                            </td>
                                        <td class="auto-style3"></td>
                                        <td class="auto-style2">
                                            </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td class="auto-style4">&nbsp;</td>
                                        <td class="aatr">
                                            <asp:Button ID="btncerrar2" runat="server" CausesValidation="False" CssClass="btn btn-danger"
                                                onclick="btncerrar2_Click" Text="Cerrar" />
                                            &nbsp;<asp:Button ID="btnsave2" runat="server" onclick="btnsave2_Click"  CssClass="btn btn-primary"
                                                Text="Guardar" ValidationGroup="22" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="mess">
                            &nbsp;</td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
    </asp:Panel>
    <uc1:messbox ID="messbox1" runat="server" />
</asp:Content>


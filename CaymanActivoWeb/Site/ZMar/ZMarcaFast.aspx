<%@ Page Title="" Language="C#" MasterPageFile="~/Site/Activos/cay.master" AutoEventWireup="true" CodeFile="ZMarcaFast.aspx.cs" Inherits="ZMarcaFast" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Src="../../Ctrl/Msg/messbox.ascx" TagName="messbox" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function KeyPress(sender, args) {
            var regexp = new RegExp("[0-9]{1}|[\b]|\t|\r");
            if (!args.get_keyCharacter().match(regexp))
                args.set_cancel(true);
        }
    </script>
    <style type="text/css">
        .auto-style1 {
            width: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <asp:Panel ID="Panel1" runat="server" CssClass="panmar"
        GroupingText="Gestión de Marcas y Modelos">
        <table cellspacing="0" class="panmar">
            <tr>
                <td class="aatl" width="50%">
                    <asp:Panel ID="Panel4" runat="server" CssClass="panmar"
                        GroupingText="Marca">
                        <asp:UpdatePanel ID="upmar" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:Panel ID="pansgru" runat="server" CssClass="panmar2">
                                    <asp:ImageButton ID="ibgr4" runat="server" CausesValidation="False"
                                        CssClass="relo" Height="20px" ImageUrl="~/Img/add.png" TabIndex="99"
                                        ToolTip="Agregar Marca" Width="21px" OnClick="ibgr4_Click" />
                                    &nbsp;<asp:ImageButton ID="ibgr5" runat="server" CausesValidation="False"
                                        CssClass="relo" Height="21px" ImageUrl="~/Img/pen.png" TabIndex="99"
                                        ToolTip="Editar Marca" Width="21px" OnClick="ibgr5_Click" />
                                    &nbsp;<asp:ImageButton ID="ibgr6" runat="server" CausesValidation="False"
                                        CssClass="relo" Height="19px" ImageUrl="~/Img/del.png" TabIndex="99"
                                        ToolTip="Eliminar Marca" Width="20px" OnClick="ibgr6_Click" />
                                </asp:Panel>
                                <div>
                                    <asp:DropDownList ID="ddMarca" runat="server" CssClass="txtdd" Width="100%">
                                    </asp:DropDownList>
                                </div>
                                <asp:CascadingDropDown ID="cddmarca" runat="server" Category="marca"
                                    Enabled="True" LoadingText="[Cargando Marca...]" PromptText="• Seleccione •"
                                    ServiceMethod="GetMarca" ServicePath="ws.asmx" TargetControlID="ddMarca">
                                </asp:CascadingDropDown>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:Panel>
                </td>
                <td class="aatl" width="50%">
                    <asp:Panel ID="Panel5" runat="server" CssClass="panmar"
                        GroupingText="Modelo">
                        <asp:UpdatePanel ID="upmod" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:Panel ID="pangru1" runat="server" CssClass="panmar2">
                                    <asp:ImageButton ID="ibgr7" runat="server" CausesValidation="False"
                                        CssClass="relo" Height="20px" ImageUrl="~/Img/add.png" TabIndex="99"
                                        ToolTip="Agregar Modelo" Width="21px" OnClick="ibgr7_Click" />
                                    &nbsp;<asp:ImageButton ID="ibgr8" runat="server" CausesValidation="False"
                                        CssClass="relo" Height="21px" ImageUrl="~/Img/pen.png" TabIndex="99"
                                        ToolTip="Editar Modelo" Width="21px" OnClick="ibgr8_Click" />
                                    &nbsp;<asp:ImageButton ID="ibgr9" runat="server" CausesValidation="False"
                                        CssClass="relo" Height="19px" ImageUrl="~/Img/del.png" TabIndex="99"
                                        ToolTip="Eliminar Modelo" Width="20px" OnClick="ibgr9_Click" />
                                </asp:Panel>
                                <div class="panmar2">
                                    <asp:DropDownList ID="ddModelo" runat="server" CssClass="txtdd" Width="100%">
                                    </asp:DropDownList>
                                </div>
                                <asp:CascadingDropDown ID="cddModelo" runat="server" Category="modelo"
                                    Enabled="True" LoadingText="[Cargando Modelo...]" ParentControlID="ddMarca"
                                    PromptText="• Seleccione •" ServiceMethod="GetModelo" ServicePath="ws.asmx"
                                    TargetControlID="ddModelo">
                                </asp:CascadingDropDown>
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
                <table style="background-color: white" cellpadding="0" cellspacing="0" class="style2">
                    <tr>
                        <td class="mess">
                            <table cellpadding="0" cellspacing="0" class="style2">
                                <tr>
                                    <td width="10">&nbsp;</td>
                                    <td>
                                        <h6><asp:Label ID="lblmp2" runat="server" ForeColor="White"></asp:Label></h6>
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
                                        <td width="55">Nombre:</td>
                                        <td class="auto-style1">
                                            <h6>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                                    ControlToValidate="txtnombre2" ErrorMessage="Ingrese Nombre"
                                                    ValidationGroup="22" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="vce2" runat="server" Enabled="True"
                                                    TargetControlID="RequiredFieldValidator3">
                                                </asp:ValidatorCalloutExtender>
                                            </h6>
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtnombre2" runat="server" MaxLength="150" Width="100%">
                                                <PasswordStrengthSettings CalculationWeightings="50;15;15;20" IndicatorElementBaseStyle="riStrengthBar" IndicatorElementID="" MinimumLowerCaseCharacters="2" MinimumNumericCharacters="2" MinimumSymbolCharacters="2" MinimumUpperCaseCharacters="2" OnClientPasswordStrengthCalculating="" PreferredPasswordLength="10" RequiresUpperAndLowerCaseCharacters="True" ShowIndicator="False" TextStrengthDescriptions="Very Weak;Weak;Medium;Strong;Very Strong" TextStrengthDescriptionStyles="riStrengthBarL0;riStrengthBarL1;riStrengthBarL2;riStrengthBarL3;riStrengthBarL4;riStrengthBarL5;" />
                                                <EmptyMessageStyle Font-Italic="True" />
                                            </telerik:RadTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td class="auto-style1">&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td class="auto-style1">&nbsp;</td>
                                        <td class="aatr">
                                            <asp:Button ID="btncerrar2" runat="server" CausesValidation="False"
                                                OnClick="btncerrar2_Click" Text="Cerrar" CssClass="btn btn-danger"/>
                                            &nbsp;<asp:Button ID="btnsave2" runat="server" OnClick="btnsave2_Click" CssClass="btn btn-primary"
                                                Text="Guardar" ValidationGroup="22" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="mess">&nbsp;</td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
    </asp:Panel>
    <uc1:messbox ID="messbox1" runat="server" />
</asp:Content>


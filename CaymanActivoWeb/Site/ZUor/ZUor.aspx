<%@ Page Title="" Language="C#" MasterPageFile="~/Site/Activos/cay.master" AutoEventWireup="true" CodeFile="ZUor.aspx.cs" Inherits="ZUor" EnableEventValidation="false" %>

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
            width: 6px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
<asp:Panel ID="Panel1" runat="server" CssClass="panmar"
           GroupingText="Gestión de Centros de Costo y Ubicaciones Orgánicas">
    <table cellspacing="0" class="panmar">
        <tr>
            <td class="aatl" width="100%">
                <asp:Panel ID="Panel9" runat="server" CssClass="panmar"
                           GroupingText="Ubicación Geográfica 3">
                    <asp:UpdatePanel ID="upgeo3" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <telerik:RadListBox ID="rlbgeo3" runat="server" AutoPostBack="True"
                                                CssClass="panmar2" EmptyMessage="Geo3 no Disponible"
                                                OnSelectedIndexChanged="rlbgeo1_SelectedIndexChanged" Width="95%">
                                <ButtonSettings TransferButtons="All"/>
                                <EmptyMessageTemplate>
                                    Subgrupos no disponibles
                                </EmptyMessageTemplate>
                            </telerik:RadListBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
                <asp:Panel ID="Panel5" runat="server" CssClass="panmar"
                           GroupingText="Centro de Costo/Ubicación Orgánica">
                    <asp:UpdatePanel ID="upgeo" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table cellspacing="0" class="panmar">
                                <tr>
                                    <td class="aatl" width="32%">
                                        <asp:Panel ID="Panel6" runat="server" CssClass="panmar"
                                                   GroupingText="Centro de Costo">
                                            <asp:UpdatePanel ID="upmod" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:Panel ID="pangru1" runat="server" CssClass="panmar2">
                                                        <asp:ImageButton ID="ibgr7" runat="server" CausesValidation="False"
                                                                         CssClass="relo" Height="20px" ImageUrl="~/Img/add.png" OnClick="ibgr7_Click"
                                                                         TabIndex="99" ToolTip="Agregar Centro de Costo" Width="21px"/>
                                                        &nbsp;
                                                        <asp:ImageButton ID="ibgr8" runat="server" CausesValidation="False"
                                                                         CssClass="relo" Height="21px" ImageUrl="~/Img/pen.png" OnClick="ibgr8_Click"
                                                                         TabIndex="99" ToolTip="Editar Centro de Costo" Width="21px"/>
                                                        &nbsp;
                                                        <asp:ImageButton ID="ibgr9" runat="server" CausesValidation="False"
                                                                         CssClass="relo" Height="19px" ImageUrl="~/Img/del.png" OnClick="ibgr9_Click"
                                                                         TabIndex="99" ToolTip="Eliminar Centro de Costo" Width="20px"/>
                                                    </asp:Panel>
                                                    <telerik:RadListBox ID="rlbccosto" runat="server" AutoPostBack="True"
                                                                        CssClass="panmar2" EmptyMessage="Centro de Costo no Disponible" Height="400px"
                                                                        OnSelectedIndexChanged="rlbgeo2_SelectedIndexChanged">
                                                        <ButtonSettings TransferButtons="All"/>
                                                        <EmptyMessageTemplate>
                                                            Descripciones no disponibles
                                                        </EmptyMessageTemplate>
                                                    </telerik:RadListBox>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </asp:Panel>
                                    </td>
                                    <td class="aatl" width="32%">
                                        <asp:Panel ID="Panel7" runat="server" CssClass="panmar"
                                                   GroupingText="Ubicación Orgánica 1">
                                            <asp:UpdatePanel ID="upmod0" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:Panel ID="pangru2" runat="server" CssClass="panmar2">
                                                        <asp:ImageButton ID="ibgr10" runat="server" CausesValidation="False"
                                                                         CssClass="relo" Height="20px" ImageUrl="~/Img/add.png" OnClick="ibgr10_Click"
                                                                         TabIndex="99" ToolTip="Agregar Orgánica 1" Width="21px"/>
                                                        &nbsp;
                                                        <asp:ImageButton ID="ibgr11" runat="server" CausesValidation="False"
                                                                         CssClass="relo" Height="21px" ImageUrl="~/Img/pen.png" OnClick="ibgr11_Click"
                                                                         TabIndex="99" ToolTip="Editar Orgánica 1" Width="21px"/>
                                                        &nbsp;
                                                        <asp:ImageButton ID="ibgr12" runat="server" CausesValidation="False"
                                                                         CssClass="relo" Height="19px" ImageUrl="~/Img/del.png" OnClick="ibgr12_Click"
                                                                         TabIndex="99" ToolTip="Eliminar Orgánica 1" Width="20px"/>
                                                    </asp:Panel>
                                                    <telerik:RadListBox ID="rlbuor1" runat="server" AutoPostBack="True"
                                                                        CssClass="panmar2" EmptyMessage="Orgánica 1 no Disponible" Height="400px"
                                                                        OnSelectedIndexChanged="rlbgeo3_SelectedIndexChanged">
                                                        <ButtonSettings TransferButtons="All"/>
                                                        <EmptyMessageTemplate>
                                                            Descripciones no disponibles
                                                        </EmptyMessageTemplate>
                                                    </telerik:RadListBox>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </asp:Panel>
                                    </td>
                                    <td class="aatl" width="32%">
                                        <asp:Panel ID="Panel8" runat="server" CssClass="panmar"
                                                   GroupingText="Ubicación Orgánica 2">
                                            <asp:UpdatePanel ID="upmod1" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:Panel ID="pangru3" runat="server" CssClass="panmar2">
                                                        <asp:ImageButton ID="ibgr13" runat="server" CausesValidation="False"
                                                                         CssClass="relo" Height="20px" ImageUrl="~/Img/add.png" OnClick="ibgr13_Click"
                                                                         TabIndex="99" ToolTip="Agregar Orgánica 2" Width="21px"/>
                                                        &nbsp;
                                                        <asp:ImageButton ID="ibgr14" runat="server" CausesValidation="False"
                                                                         CssClass="relo" Height="21px" ImageUrl="~/Img/pen.png" OnClick="ibgr14_Click"
                                                                         TabIndex="99" ToolTip="Editar Orgánica 2" Width="21px"/>
                                                        &nbsp;
                                                        <asp:ImageButton ID="ibgr15" runat="server" CausesValidation="False"
                                                                         CssClass="relo" Height="19px" ImageUrl="~/Img/del.png" OnClick="ibgr15_Click"
                                                                         TabIndex="99" ToolTip="Eliminar Orgánica 2" Width="20px"/>
                                                    </asp:Panel>
                                                    <telerik:RadListBox ID="rlbuor2" runat="server" AutoPostBack="True"
                                                                        CssClass="panmar2" EmptyMessage="Orgánica 2 no Disponible" Height="400px">
                                                        <ButtonSettings TransferButtons="All"/>
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
           Width="430px" style="display:table-row">
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
                                        <h6>Nombre:</h6>
                                    </td>
                                    <td class="auto-style1">
                                        <h6>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                                                        ControlToValidate="txtnombre2" ErrorMessage="Ingrese Nombre"
                                                                        ValidationGroup="22" ForeColor="Red">
                                                *
                                            </asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="vce2" runat="server" Enabled="True"
                                                                          TargetControlID="RequiredFieldValidator3">
                                            </asp:ValidatorCalloutExtender>
                                        </h6>
                                    </td>
                                    <td>
                                        <telerik:RadTextBox ID="txtnombre2" runat="server" MaxLength="150" Width="100%" CssClass="form-control">
                                            <PasswordStrengthSettings CalculationWeightings="50;15;15;20" IndicatorElementBaseStyle="riStrengthBar" IndicatorElementID="" MinimumLowerCaseCharacters="2" MinimumNumericCharacters="2" MinimumSymbolCharacters="2" MinimumUpperCaseCharacters="2" OnClientPasswordStrengthCalculating="" PreferredPasswordLength="10" RequiresUpperAndLowerCaseCharacters="True" ShowIndicator="False" TextStrengthDescriptions="Very Weak;Weak;Medium;Strong;Very Strong" TextStrengthDescriptionStyles="riStrengthBarL0;riStrengthBarL1;riStrengthBarL2;riStrengthBarL3;riStrengthBarL4;riStrengthBarL5;"/>
                                            <EmptyMessageStyle Font-Italic="True"/>
                                        </telerik:RadTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <h6>Codigo:</h6>
                                    </td>
                                    <td class="auto-style1">&nbsp;</td>
                                    <td>
                                        <telerik:RadTextBox ID="txtCodigo" runat="server" MaxLength="150" Width="100%" CssClass="form-control">
                                            
                                        </telerik:RadTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td class="auto-style1">&nbsp;</td>
                                    <td class="aatr">
                                        <asp:Button ID="btncerrar2" runat="server" CausesValidation="False"
                                                    OnClick="btncerrar2_Click" Text="Cerrar" CssClass="btn btn-danger"/>
                                        &nbsp;
                                        <asp:Button ID="btnsave2" runat="server" OnClick="btnsave2_Click"
                                                    Text="Guardar" ValidationGroup="22" CssClass="btn btn-primary"/>
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
    <br/>
</asp:Panel>

<br/>
<uc1:messbox ID="messbox1" runat="server"/>
</asp:Content>
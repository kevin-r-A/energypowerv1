<%@ Page Title="" Language="C#" MasterPageFile="~/Site/Activos/cay.master" AutoEventWireup="true" CodeFile="ZGruposCar.aspx.cs" Inherits="ZGruposCar" EnableEventValidation="false" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Register src="../../Ctrl/Msg/messbox.ascx" tagname="messbox" tagprefix="uc1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit.HTMLEditor" tagprefix="cc1" %>

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
            width: 28px;
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
        GroupingText="Gestión de Características por Grupo">
        <table cellspacing="0" class="panmar">
            <tr>
                <td class="aatl" width="34%">
                    <asp:Panel ID="Panel2" runat="server" CssClass="panmar" GroupingText="Grupos">
                        <asp:UpdatePanel ID="upgru" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <telerik:RadListBox ID="rlbgrupos" runat="server" AutoPostBack="True" 
                                    CssClass="panmar" onselectedindexchanged="rlbgrupos_SelectedIndexChanged" 
                                    Width="95%">
                                </telerik:RadListBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </asp:Panel>
                    <asp:Panel ID="Panel4" runat="server" CssClass="panmar" 
                        GroupingText="Características">
                        <asp:UpdatePanel ID="upcar" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:Panel ID="pansgru" runat="server" CssClass="panmar2">
                                    <asp:ImageButton ID="ibgr4" runat="server" CausesValidation="False" 
                                        CssClass="relo" Height="20px" ImageUrl="~/Img/add.png" onclick="ibgr4_Click" 
                                        TabIndex="99" ToolTip="Agregar SubGrupo" Width="21px" />
                                    &nbsp;<asp:ImageButton ID="ibgr5" runat="server" CausesValidation="False" 
                                        CssClass="relo" Height="21px" ImageUrl="~/Img/pen.png" onclick="ibgr5_Click" 
                                        TabIndex="99" ToolTip="Editar SubGrupo" Width="21px" />
                                    &nbsp;<asp:ImageButton ID="ibgr6" runat="server" CausesValidation="False" 
                                        CssClass="relo" Height="19px" ImageUrl="~/Img/del.png" onclick="ibgr6_Click" 
                                        TabIndex="99" ToolTip="Eliminar SubGrupo" Width="20px" />
                                </asp:Panel>
                                <telerik:RadListBox ID="rlbcaract" runat="server" 
                                    AutoPostBack="True" CssClass="panmar" 
                                    EmptyMessage="Características no disponibles" Height="180px" Width="95%">
                                    <ButtonSettings TransferButtons="All" />
                                    <EmptyMessageTemplate>
                                        Subgrupos no disponibles
                                    </EmptyMessageTemplate>
                                </telerik:RadListBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:Panel>
                </td>
                <td class="aatl" width="32%">
                    <asp:Panel ID="Panel6" runat="server" CssClass="panmar" 
                        GroupingText="Características No Asociadas">
                        <asp:UpdatePanel ID="upcarna" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <telerik:RadListBox ID="rlbcaractna" runat="server" AutoPostBack="True" CssClass="panmar" 
                                    EmptyMessage="Sin Características No Asociadas" Height="485px" Width="95%">
                                    <EmptyMessageTemplate>
                                        Subgrupos no disponibles
                                    </EmptyMessageTemplate>
                                </telerik:RadListBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:Panel>
                    <br />
                </td>

                <td class="aacc" width="35">
                    <asp:UpdatePanel ID="up1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table cellpadding="3" cellspacing="1" class="style2">
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="ibgr7" runat="server" CausesValidation="False" 
                                            CssClass="relo" Height="20px" ImageUrl="~/Img/f1.png" onclick="ibgr7_Click" 
                                            TabIndex="99" ToolTip="Asociar Característica" Width="23px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="ibgr8" runat="server" CausesValidation="False" 
                                            CssClass="relo" Height="20px" ImageUrl="~/Img/f2.png" onclick="ibgr8_Click" 
                                            TabIndex="99" ToolTip="Desasociar Característica" Width="23px" />
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>

                <td class="aatl" width="32%">
                    <asp:Panel ID="Panel5" runat="server" CssClass="panmar" 
                        GroupingText="Características Asociadas y Unidades">
                        <asp:UpdatePanel ID="upcara" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <telerik:RadListBox ID="rlbcaracta" runat="server" AutoPostBack="True" 
                                    CssClass="panmar" Width="95%" EmptyMessage="Sin Características Asociadas" 
                                    Height="485px" CheckBoxes="True" onitemcheck="rlbcaracta_ItemCheck">
                                    <EmptyMessageTemplate>
                                        Descripciones no disponibles
                                    </EmptyMessageTemplate>
                                </telerik:RadListBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:Panel>
                </td>
                <td class="aacc" width="35">
                    <asp:UpdatePanel ID="up2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table cellpadding="3" cellspacing="1" class="style2">
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="ibgr9" runat="server" CausesValidation="False" 
                                            CssClass="relo" Height="21px" ImageUrl="~/Img/f4.png" onclick="ibgr9_Click" 
                                            TabIndex="99" ToolTip="Asociar Característica" Width="21px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="ibgr10" runat="server" CausesValidation="False" 
                                            CssClass="relo" Height="21px" ImageUrl="~/Img/f3.png" onclick="ibgr10_Click" 
                                            TabIndex="99" ToolTip="Desasociar Característica" Width="21px" />
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <uc1:messbox ID="messbox1" runat="server" />
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
                            <table cellpadding="0" cellspacing="0" class="style2">
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
                                            <h6><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtnombre2" ErrorMessage="Ingrese Nombre" ValidationGroup="22" ForeColor="Red">*</asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="vce2" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator3">
                                            </asp:ValidatorCalloutExtender></h6>
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtnombre2" Runat="server" MaxLength="150" 
                                                Width="100%" CssClass="form-control">
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
                                            <asp:Button ID="btncerrar2" runat="server" CssClass="btn btn-danger" CausesValidation="False"  
                                                onclick="btncerrar2_Click" Text="Cerrar" />
                                            &nbsp;<asp:Button ID="btnsave2" runat="server" CssClass="btn btn-primary" onclick="btnsave2_Click"  
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
    </asp:Panel>
    </asp:Content>


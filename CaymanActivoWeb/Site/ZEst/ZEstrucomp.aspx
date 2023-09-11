<%@ Page Title="" Language="C#" MasterPageFile="~/Site/Activos/cay.master" AutoEventWireup="true" CodeFile="ZEstrucomp.aspx.cs" Inherits="ZEstrucomp" EnableEventValidation="false" %>

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

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <asp:Panel ID="Panel1" runat="server" CssClass="panmar"
        GroupingText="Gestión de Estructuras y Componentes">
        <table cellspacing="0" class="panmar">
            <tr>
                <td class="aatl" width="100%">
                    <asp:Panel ID="Panel5" runat="server" CssClass="panmar"
                        GroupingText="Estructura y Componente">
                        <asp:UpdatePanel ID="upcol" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:Panel ID="pangru1" runat="server" CssClass="panmar2">
                                    <asp:ImageButton ID="ibgr7" runat="server" CausesValidation="False"
                                        CssClass="relo" Height="20px" ImageUrl="~/Img/add.png" OnClick="ibgr7_Click"
                                        TabIndex="99" ToolTip="Agregar Estructura/Componente" Width="21px" />
                                    &nbsp;<asp:ImageButton ID="ibgr8" runat="server" CausesValidation="False"
                                        CssClass="relo" Height="21px" ImageUrl="~/Img/pen.png" OnClick="ibgr8_Click"
                                        TabIndex="99" ToolTip="Editar Estructura/Componente" Width="21px" />
                                    &nbsp;<asp:ImageButton ID="ibgr9" runat="server" CausesValidation="False"
                                        CssClass="relo" Height="19px" ImageUrl="~/Img/del.png" OnClick="ibgr9_Click"
                                        TabIndex="99" ToolTip="Eliminar Estructura/Componente" Width="20px" />
                                </asp:Panel>
                                <telerik:RadListBox ID="rlbestruc" runat="server" AutoPostBack="True"
                                    CssClass="panmar" EmptyMessage="Estructuras/Componentes no Disponibles" Height="500px"
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
                <table style="background-color: white" cellpadding="0" cellspacing="0" class="style1">
                    <tr>
                        <td class="mess">
                            <table cellpadding="0" cellspacing="0" class="style1">
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
                                        <td>
                                            <h6>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtnombre2" ErrorMessage="Ingrese Nombre" ValidationGroup="22" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="vce2" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator3">
                                                </asp:ValidatorCalloutExtender>
                                            </h6>
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtnombre2" runat="server" MaxLength="150" Width="100%">
                                            </telerik:RadTextBox>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td class="aatr">&nbsp;</td>
                                        <td class="aatr">
                                            <asp:Button ID="btncerrar2" runat="server" CausesValidation="False" OnClick="btncerrar2_Click" Text="Cerrar" CssClass="btn btn-danger"/>
                                            &nbsp;<asp:Button ID="btnsave2" runat="server" OnClick="btnsave2_Click" Text="Guardar" ValidationGroup="22" CssClass="btn btn-primary"/>
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


<%@ Page Language="C#" MasterPageFile="~/Site/Activos/cay.master" AutoEventWireup="true" CodeFile="ZPpc.aspx.cs" Inherits="ZPpc" EnableEventValidation="false" %>

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
        GroupingText="Gestión de PocketPc">
        <table cellspacing="0" class="panmar">
            <tr>
                <td class="aatl" width="26%">
                    <asp:Panel ID="Panel2" runat="server" CssClass="panmar"
                        GroupingText="PocketPc's Habilitadas en el Sistema">
                        <asp:UpdatePanel ID="upgru" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:Panel ID="pangru" runat="server" CssClass="panmar2">
                                    <asp:ImageButton ID="ibgr1" runat="server" CausesValidation="False"
                                        CssClass="relo" Height="20px" ImageUrl="~/Img/add.png" OnClick="ibgr1_Click"
                                        TabIndex="99" ToolTip="Agregar PocketPc" Width="21px" />
                                    &nbsp;<asp:ImageButton ID="ibgr2" runat="server" CausesValidation="False"
                                        CssClass="relo" Height="21px" ImageUrl="~/Img/pen.png" OnClick="ibgr2_Click"
                                        TabIndex="99" ToolTip="Editar PocketPc" Width="21px" />
                                    &nbsp;<asp:ImageButton ID="ibgr3" runat="server" CausesValidation="False"
                                        CssClass="relo" Height="19px" ImageUrl="~/Img/del.png" TabIndex="99"
                                        ToolTip="Eliminar PocketPc" Width="20px" OnClick="ibgr3_Click" />
                                    <asp:ConfirmButtonExtender ID="cbegru" runat="server"
                                        ConfirmText="Desea realmente eliminar la PocketPc?" Enabled="True"
                                        TargetControlID="ibgr3">
                                    </asp:ConfirmButtonExtender>
                                </asp:Panel>
                                <telerik:RadGrid ID="rgppc" runat="server" CellSpacing="0" GridLines="None">
                                    <ClientSettings>
                                        <Selecting AllowRowSelect="True" />
                                    </ClientSettings>
                                    <MasterTableView DataKeyNames="Id">
                                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                            <HeaderStyle Width="20px" />
                                        </RowIndicatorColumn>
                                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                            <HeaderStyle Width="20px" />
                                        </ExpandCollapseColumn>
                                        <EditFormSettings>
                                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                            </EditColumn>
                                        </EditFormSettings>
                                    </MasterTableView>
                                    <FilterMenu EnableImageSprites="False">
                                    </FilterMenu>
                                    <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                                    </HeaderContextMenu>
                                </telerik:RadGrid>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </asp:Panel>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Label ID="Label1" runat="server"></asp:Label>
    <asp:ModalPopupExtender ID="mpnuevo" runat="server"
        BackgroundCssClass="modalBackground" DynamicServicePath="" Enabled="True"
        PopupControlID="pan" TargetControlID="Label1">
    </asp:ModalPopupExtender>
    <br />
    <asp:Panel ID="pan" runat="server" Height="142px"
        Width="430px" style="display:none">
        <%--style="display:none"--%>
        <asp:UpdatePanel ID="upnuevo" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table style="background-color: white" cellpadding="0" cellspacing="0" class="style1">
                    <tr>
                        <td class="mess">
                            <table cellpadding="0" cellspacing="0" class="style2">
                                <tr>
                                    <td width="10">&nbsp;</td>
                                    <td>
                                        <asp:Label ID="lblmp" runat="server" ForeColor="White"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="panmar2">
                                <table cellspacing="0" style="width: 409px">
                                    <tr>
                                        <td width="90">
                                            <h6>PPC Número:<asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                                runat="server" ControlToValidate="txtppcnumero"
                                                ErrorMessage="Ingrese PPC Número" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="RequiredFieldValidator2_ValidatorCalloutExtender"
                                                    runat="server" Enabled="True" TargetControlID="RequiredFieldValidator2" WarningIconImageUrl="~/Img/warning.png">
                                                </asp:ValidatorCalloutExtender>
                                            </h6>
                                        </td>
                                        <td>
                                            <div class="form-group">
                                                <telerik:RadTextBox ID="txtppcnumero" runat="server" MaxLength="4" Width="60px" CssClass="form-control">
                                                    <ClientEvents OnKeyPress="KeyPress" />
                                                    <EmptyMessageStyle Font-Italic="True" />
                                                </telerik:RadTextBox>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h6>Serie:</h6>
                                        </td>
                                        <td>
                                            <div class="form-group">
                                                <telerik:RadTextBox ID="txtserie" runat="server"
                                                    MaxLength="150" Width="300px" CssClass="form-control">
                                                    <EmptyMessageStyle Font-Italic="True" />
                                                </telerik:RadTextBox>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td class="aatr">
                                            <asp:ImageButton ID="ibcancel" runat="server" Height="28px"
                                                ImageUrl="~/Img/c1.png" OnClick="ibcancel_Click" Width="102px" />
                                            &nbsp;<asp:ImageButton ID="ibsave" runat="server" Height="28px"
                                                ImageUrl="~/Img/s1.png" OnClick="ibsave_Click" ValidationGroup="1"
                                                Width="102px" />
                                            &nbsp;</td>
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


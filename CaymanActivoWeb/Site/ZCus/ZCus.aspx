<%@ Page Title="" Language="C#" MasterPageFile="~/Site/Activos/cay.master" AutoEventWireup="true" CodeFile="ZCus.aspx.cs" Inherits="ZCus" EnableEventValidation="false" %>

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
                                    <ButtonSettings TransferButtons="All" />
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
                                                        <telerik:RadListBox ID="rlbccosto" runat="server" AutoPostBack="True"
                                                            CssClass="panmar2" EmptyMessage="Centro de Costo no Disponible" Height="400px"
                                                            OnSelectedIndexChanged="rlbgeo2_SelectedIndexChanged">
                                                            <ButtonSettings TransferButtons="All" />
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
                                                        <telerik:RadListBox ID="rlbuor1" runat="server" AutoPostBack="True"
                                                            CssClass="panmar2" EmptyMessage="Orgánica 1 no Disponible" Height="400px"
                                                            OnSelectedIndexChanged="rlbgeo3_SelectedIndexChanged">
                                                            <ButtonSettings TransferButtons="All" />
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
                                                GroupingText="Custodio">
                                                <asp:UpdatePanel ID="upmod1" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:Panel ID="pangru3" runat="server" CssClass="panmar2">
                                                            <asp:ImageButton ID="ibgr13" runat="server" CausesValidation="False"
                                                                CssClass="relo" Height="20px" ImageUrl="~/Img/add.png" OnClick="ibgr13_Click"
                                                                TabIndex="99" ToolTip="Agregar Custodio" Width="21px" />
                                                            &nbsp;<asp:ImageButton ID="ibgr14" runat="server" CausesValidation="False"
                                                                CssClass="relo" Height="21px" ImageUrl="~/Img/pen.png" OnClick="ibgr14_Click"
                                                                TabIndex="99" ToolTip="Editar Custodio" Width="21px" />
                                                            &nbsp;<asp:ImageButton ID="ibgr15" runat="server" CausesValidation="False"
                                                                CssClass="relo" Height="19px" ImageUrl="~/Img/del.png" OnClick="ibgr15_Click"
                                                                TabIndex="99" ToolTip="Eliminar Custodio" Width="20px" />
                                                        </asp:Panel>
                                                        <telerik:RadListBox ID="rlbcustodio" runat="server" AutoPostBack="True"
                                                            CssClass="panmar2" EmptyMessage="Custodios no Disponible" Height="360px"
                                                            OnItemCheck="rlbcustodio_ItemCheck">
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
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Label ID="Label2" runat="server"></asp:Label>
    <asp:ModalPopupExtender ID="mp2" runat="server" Y="130"
        BackgroundCssClass="modalBackground" DynamicServicePath="" Enabled="True"
        PopupControlID="pan2" TargetControlID="Label2">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pan2" runat="server" Height="335px " CssClass="margenTop"
        Width="430px" style="display:none; margin-top:4px">
        <%--style="display:none"--%>
        <asp:UpdatePanel ID="upnuevo2" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table style="background-color:white" cellpadding="0" cellspacing="0" class="style1">
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
                                        <td width="65">
                                            <h6>Código:</h6>
                                        </td>
                                        <td>
                                            <div class="form-group">
                                            <telerik:RadTextBox ID="txtcodigo" runat="server" MaxLength="50" Width="100px" CssClass="form-control">
                                                
                                                <EmptyMessageStyle Font-Italic="True" />
                                            </telerik:RadTextBox>
                                                </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="55">
                                            <h6>Apellidos:<asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                                                runat="server" ControlToValidate="txtapellidos"
                                                ErrorMessage="Ingrese Apellidos" ValidationGroup="22" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="vce_apellidos" TargetControlID="RequiredFieldValidator4" runat="server"></asp:ValidatorCalloutExtender>
                                            </h6>
                                        </td>
                                        <td>
                                            <div class="form-group">
                                            <telerik:RadTextBox ID="txtapellidos" runat="server" MaxLength="200"
                                                Width="330px" CssClass="form-control">
                                                
                                                <EmptyMessageStyle Font-Italic="True" />
                                            </telerik:RadTextBox>
                                                </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="55">
                                            <h6>Nombres:<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                                ControlToValidate="txtnombres" ErrorMessage="Ingrese Nombre"
                                                ValidationGroup="22" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" TargetControlID="RequiredFieldValidator3" runat="server"></asp:ValidatorCalloutExtender>
                                            </h6>
                                        </td>
                                        <td>
                                            <div class="form-group">
                                            <telerik:RadTextBox ID="txtnombres" runat="server" MaxLength="200"
                                                Width="330px" CssClass="form-control">
                                                
                                                <EmptyMessageStyle Font-Italic="True" />
                                            </telerik:RadTextBox>
                                                </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="55">
                                            <h6>Cédula:<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                                ControlToValidate="txtcedula" ErrorMessage="Ingrese Cédula"
                                                ValidationGroup="22" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" TargetControlID="RequiredFieldValidator5" runat="server"></asp:ValidatorCalloutExtender>
                                            </h6>
                                        </td>
                                        <td>
                                            <div class="form-group">
                                            <telerik:RadTextBox ID="txtcedula" runat="server" MaxLength="20" Width="100px" CssClass="form-control">
                                                
                                                <ClientEvents OnKeyPress="KeyPress" />
                                                <EmptyMessageStyle Font-Italic="True" />
                                            </telerik:RadTextBox>
                                                </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="55">
                                            <h6>Teléfono:</h6>
                                        </td>
                                        <td>
                                            <div class="form-group">
                                            <telerik:RadTextBox ID="txttelefono" runat="server" MaxLength="20"
                                                Width="100px" CssClass="form-control">
                                                
                                                <EmptyMessageStyle Font-Italic="True" />
                                            </telerik:RadTextBox>
                                                </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1" width="55">
                                            <h6>Extensión:</h6>
                                        </td>
                                        <td class="style1">
                                            <div class="form-group">
                                            <telerik:RadTextBox ID="txtext" runat="server" MaxLength="8" Width="100px" CssClass="form-control">
                                                
                                                <EmptyMessageStyle Font-Italic="True" />
                                            </telerik:RadTextBox>
                                                </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="55">
                                            <h6>Celular:</h6>
                                        </td>
                                        <td>
                                            <div class="form-group">
                                            <telerik:RadTextBox ID="txtcelular" runat="server" MaxLength="20" Width="100px" CssClass="form-control">
                                                
                                                <ClientEvents OnKeyPress="KeyPress" />
                                                <EmptyMessageStyle Font-Italic="True" />
                                            </telerik:RadTextBox>
                                                </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="55">
                                            <h6>Email:<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                                ControlToValidate="txtemail" ErrorMessage="Ingrese Email" ValidationGroup="22" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" TargetControlID="RequiredFieldValidator6" runat="server"></asp:ValidatorCalloutExtender>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                                    ControlToValidate="txtemail" ErrorMessage="Email no válido"
                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator></h6>
                                        </td>
                                        <td>
                                            <div class="form-group">
                                            <telerik:RadTextBox ID="txtemail" runat="server" MaxLength="150" Width="330px" CssClass="form-control">
                                                
                                                <EmptyMessageStyle Font-Italic="True" />
                                            </telerik:RadTextBox>
                                                </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h6>Cargo:<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                                ControlToValidate="ddcargo" ErrorMessage="Seleccione Cargo"
                                                ValidationGroup="22" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" TargetControlID="RequiredFieldValidator7" runat="server"></asp:ValidatorCalloutExtender>
                                            </h6>
                                        </td>
                                        <td>
                                            <div class="form-group">
                                            <asp:DropDownList ID="ddcargo" runat="server" CssClass="txtdd">
                                            </asp:DropDownList>
                                            <asp:CascadingDropDown ID="cddcargo" runat="server" Category="car"
                                                EmptyText="Cargos no disponibles" Enabled="True" LoadingText="Cargando Cargos"
                                                PromptText="Seleccione Cargo" ServiceMethod="GetCargos" ServicePath="ws.asmx"
                                                TargetControlID="ddcargo">
                                            </asp:CascadingDropDown>
                                                </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td><h6>Estado:</h6></td>
                                        <td>
                                            <div class="form-group">
                                            <asp:DropDownList ID="ddestado" runat="server" CssClass="txtdd">
                                                <asp:ListItem>Activo</asp:ListItem>
                                                <asp:ListItem>Inactivo</asp:ListItem>
                                            </asp:DropDownList>
                                                </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td class="aatr">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td class="aatr">
                                            <asp:Button ID="btncerrar2" runat="server" CausesValidation="False" CssClass="btn btn-danger" OnClick="btncerrar2_Click" Text="Cerrar" />
                                            &nbsp;<asp:Button ID="btnsave2" runat="server" CssClass="btn btn-primary" OnClick="btnsave2_Click" Text="Guardar" ValidationGroup="22" />
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

    <br />
    <uc1:messbox ID="messbox1" runat="server" />
</asp:Content>


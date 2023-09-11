<%@ Page Title="" Language="C#" MasterPageFile="~/Site/Activos/cay.master" AutoEventWireup="true" CodeFile="ZGrupos.aspx.cs" Inherits="ZGrupos" EnableEventValidation="false" %>

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
            width: 10px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
<asp:Panel ID="Panel1" runat="server" CssClass="panmar"
           GroupingText="Gestión de Grupos, Subgrupos y Descripción">
    <table cellspacing="0" class="panmar">
        <tr>
            <td class="aatl" width="26%">
                <asp:Panel ID="Panel2" runat="server" CssClass="panmar" GroupingText="Grupos">
                    <asp:UpdatePanel ID="upgru" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Panel ID="pangru" runat="server" CssClass="panmar2">
                                <asp:ImageButton ID="ibgr1" runat="server" CausesValidation="False"
                                                 CssClass="relo" Height="20px" ImageUrl="~/Img/add.png" OnClick="ibgr1_Click"
                                                 TabIndex="99" ToolTip="Agregar Grupo" Width="21px"/>
                                &nbsp;
                                <asp:ImageButton ID="ibgr2" runat="server" CausesValidation="False"
                                                 CssClass="relo" Height="21px" ImageUrl="~/Img/pen.png" OnClick="ibgr2_Click"
                                                 TabIndex="99" ToolTip="Editar Grupo" Width="21px"/>
                                &nbsp;
                                <asp:ImageButton ID="ibgr3" runat="server" CausesValidation="False"
                                                 CssClass="relo" Height="19px" ImageUrl="~/Img/del.png" TabIndex="99"
                                                 ToolTip="Eliminar Grupo" Width="20px" OnClick="ibgr3_Click"/>
                                <asp:ConfirmButtonExtender ID="cbegru" runat="server"
                                                           ConfirmText="Desea realmente eliminar el Grupo?" Enabled="True"
                                                           TargetControlID="ibgr3">
                                </asp:ConfirmButtonExtender>
                            </asp:Panel>
                            <telerik:RadListBox ID="rlbgrupos" runat="server" AutoPostBack="True"
                                                CssClass="panmar" OnSelectedIndexChanged="rlbgrupos_SelectedIndexChanged"
                                                Width="95%">
                            </telerik:RadListBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    
        <asp:Panel ID="PanelTrasladoGru" runat="server" CssClass="panmar"
                   GroupingText="Aprobadores Traslados">
             <asp:UpdatePanel ID="uptrasladosGru" runat="server" UpdateMode="Conditional">
                       <ContentTemplate>    
                  <asp:Panel ID="panstrasladosGru" runat="server" CssClass="panmar2">
                      <asp:ImageButton ID="ibgr4trasladosGru" runat="server" CausesValidation="False"
                                         CssClass="relo" Height="20px" ImageUrl="~/Img/add.png" onclick="ibgr4trasladosGru_Click"
                                         TabIndex="99" ToolTip="Agregar Aprobador" Width="21px"/>
                        &nbsp;
                      <asp:ImageButton ID="ibgr5trasladosGru" runat="server" CausesValidation="False"
                                         CssClass="relo" Height="21px" ImageUrl="~/Img/pen.png" onclick="ibgr5trasladosGru_Click"
                                         TabIndex="99" ToolTip="Editar Aprobador" Width="21px"/>
                        &nbsp;
                      <asp:ImageButton ID="ibgr6trasladosGru" runat="server" CausesValidation="False"
                                         CssClass="relo" Height="19px" ImageUrl="~/Img/del.png" onclick="ibgr6trasladosGru_Click"
                                         TabIndex="99" ToolTip="Eliminar Aprobador" Width="20px"/>
                    </asp:Panel>

                                      <telerik:RadListBox ID="rblTrasladoGru" runat="server" AutoPostBack="True"
                                        CssClass="panmar" Width="95%" EmptyMessage="Sin Usuarios Asociadas"
                                        Height="155px">
                        <EmptyMessageTemplate>
                            Usuarios no disponibles
                        </EmptyMessageTemplate>
                    </telerik:RadListBox>
                       </ContentTemplate>

            </asp:UpdatePanel>
            </asp:Panel>
<asp:Panel ID="PanelBajaGru" runat="server" CssClass="panmar"
                   GroupingText="Aprobadores Bajas">
            <asp:UpdatePanel ID="upbajasGru" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Panel ID="pansbajasGru" runat="server" CssClass="panmar2">
                        <asp:ImageButton ID="ibgr4bajasGru" runat="server" CausesValidation="False"
                                         CssClass="relo" Height="20px" ImageUrl="~/Img/add.png" onclick="ibgr4bajasGru_Click"
                                         TabIndex="99" ToolTip="Agregar Aprobador" Width="21px"/>
                        &nbsp;
                        <asp:ImageButton ID="ibgr5bajasGru" runat="server" CausesValidation="False"
                                         CssClass="relo" Height="21px" ImageUrl="~/Img/pen.png" onclick="ibgr5bajasGru_Click"
                                         TabIndex="99" ToolTip="Editar Aprobador" Width="21px"/>
                        &nbsp;
                        <asp:ImageButton ID="ibgr6bajasGru" runat="server" CausesValidation="False"
                                         CssClass="relo" Height="19px" ImageUrl="~/Img/del.png" onclick="ibgr6bajasGru_Click"
                                         TabIndex="99" ToolTip="Eliminar Aprobador" Width="20px"/>
                    </asp:Panel>
                    <telerik:RadListBox ID="rblBajaGru" runat="server" AutoPostBack="True"
                                        CssClass="panmar" Width="95%" EmptyMessage="Sin Usuarios Asociadas"
                                        Height="155px">
                        <EmptyMessageTemplate>
                            Usuarios no disponibles
                        </EmptyMessageTemplate>
                    </telerik:RadListBox>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>


                </asp:Panel>
            </td>
            <td class="aatl" width="30%">
                <asp:Panel ID="Panel4" runat="server" CssClass="panmar"
                           GroupingText="SubGrupos">
                    <asp:UpdatePanel ID="upsub" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Panel ID="pansgru" runat="server" CssClass="panmar2">
                                <asp:ImageButton ID="ibgr4" runat="server" CausesValidation="False"
                                                 CssClass="relo" Height="20px" ImageUrl="~/Img/add.png" TabIndex="99"
                                                 ToolTip="Agregar SubGrupo" Width="21px" OnClick="ibgr4_Click"/>
                                &nbsp;
                                <asp:ImageButton ID="ibgr5" runat="server" CausesValidation="False"
                                                 CssClass="relo" Height="21px" ImageUrl="~/Img/pen.png" TabIndex="99"
                                                 ToolTip="Editar SubGrupo" Width="21px" OnClick="ibgr5_Click"/>
                                &nbsp;
                                <asp:ImageButton ID="ibgr6" runat="server" CausesValidation="False"
                                                 CssClass="relo" Height="19px" ImageUrl="~/Img/del.png" TabIndex="99"
                                                 ToolTip="Eliminar SubGrupo" Width="20px" OnClick="ibgr6_Click"/>
                                <asp:ConfirmButtonExtender ID="cbe2" runat="server"
                                                           ConfirmText="Desea realmente eliminar el SubGrupo?" Enabled="True"
                                                           TargetControlID="ibgr6">
                                </asp:ConfirmButtonExtender>
                            </asp:Panel>
                            <telerik:RadListBox ID="rlbsubgrupo" runat="server" AutoPostBack="True"
                                                CssClass="panmar" OnSelectedIndexChanged="rlbsubgrupo_SelectedIndexChanged"
                                                Width="95%" EmptyMessage="Subgrupos no disponibles" Height="450px">
                                <ButtonSettings TransferButtons="All"/>
                                <EmptyMessageTemplate>
                                    Subgrupos no disponibles
                                </EmptyMessageTemplate>
                            </telerik:RadListBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                      <asp:Panel ID="PanelTrasladoSubGru" runat="server" CssClass="panmar"
                   GroupingText="Aprobadores Traslados">
            <asp:UpdatePanel ID="uptrasladosSubGru" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Panel ID="panstrasladosSubGru" runat="server" CssClass="panmar2">
                        <asp:ImageButton ID="ibgr4trasladosSubGru" runat="server" CausesValidation="False"
                                         CssClass="relo" Height="20px" ImageUrl="~/Img/add.png" onclick="ibgr4trasladosSubGru_Click"
                                         TabIndex="99" ToolTip="Agregar Aprobador" Width="21px"/>
                        &nbsp;
                        <asp:ImageButton ID="ibgr5trasladosSubGru" runat="server" CausesValidation="False"
                                         CssClass="relo" Height="21px" ImageUrl="~/Img/pen.png" onclick="ibgr5trasladosSubGru_Click"
                                         TabIndex="99" ToolTip="Editar Aprobador" Width="21px"/>
                        &nbsp;
                        <asp:ImageButton ID="ibgr6trasladosSubGru" runat="server" CausesValidation="False"
                                         CssClass="relo" Height="19px" ImageUrl="~/Img/del.png" onclick="ibgr6trasladosSubGru_Click"
                                         TabIndex="99" ToolTip="Eliminar Aprobador" Width="20px"/>
                    </asp:Panel>
                    <telerik:RadListBox ID="rblTrasladoSubGru" runat="server" AutoPostBack="True"
                                        CssClass="panmar" Width="95%" EmptyMessage="Sin Usuarios Asociadas"
                                        Height="155px">
                        <EmptyMessageTemplate>
                            Usuarios no disponibles
                        </EmptyMessageTemplate>
                    </telerik:RadListBox>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>

        <asp:Panel ID="PanelBajaSubGru" runat="server" CssClass="panmar"
                   GroupingText="Aprobadores Bajas">
            <asp:UpdatePanel ID="upbajasSubGru" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Panel ID="pansbajasSubGru" runat="server" CssClass="panmar2">
                        <asp:ImageButton ID="ibgr4bajasSubGru" runat="server" CausesValidation="False"
                                         CssClass="relo" Height="20px" ImageUrl="~/Img/add.png" onclick="ibgr4bajasSubGru_Click"
                                         TabIndex="99" ToolTip="Agregar Aprobador" Width="21px"/>
                        &nbsp;
                        <asp:ImageButton ID="ibgr5bajasSubGru" runat="server" CausesValidation="False"
                                         CssClass="relo" Height="21px" ImageUrl="~/Img/pen.png" onclick="ibgr5bajasSubGru_Click"
                                         TabIndex="99" ToolTip="Editar Aprobador" Width="21px"/>
                        &nbsp;
                        <asp:ImageButton ID="ibgr6bajasSubGru" runat="server" CausesValidation="False"
                                         CssClass="relo" Height="19px" ImageUrl="~/Img/del.png" onclick="ibgr6bajasSubGru_Click"
                                         TabIndex="99" ToolTip="Eliminar Aprobador" Width="20px"/>
                    </asp:Panel>
                    <telerik:RadListBox ID="rblBajaSubGru" runat="server" AutoPostBack="True"
                                        CssClass="panmar" Width="95%" EmptyMessage="Sin Usuarios Asociadas"
                                        Height="155px">
                        <EmptyMessageTemplate>
                            Usuarios no disponibles
                        </EmptyMessageTemplate>
                    </telerik:RadListBox>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
                </asp:Panel>
            </td>
            <td class="aatl" width="44%">
                <asp:Panel ID="Panel5" runat="server" CssClass="panmar"
                           GroupingText="Descripción">
                    <asp:UpdatePanel ID="updes" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Panel ID="pangru1" runat="server" CssClass="panmar2">
                                <asp:ImageButton ID="ibgr7" runat="server" CausesValidation="False"
                                                 CssClass="relo" Height="20px" ImageUrl="~/Img/add.png" TabIndex="99"
                                                 ToolTip="Agregar Descripción" Width="21px" OnClick="ibgr7_Click"/>
                                &nbsp;
                                <asp:ImageButton ID="ibgr8" runat="server" CausesValidation="False"
                                                 CssClass="relo" Height="21px" ImageUrl="~/Img/pen.png" TabIndex="99"
                                                 ToolTip="Editar Descripción" Width="21px" OnClick="ibgr8_Click"/>
                                &nbsp;
                                <asp:ImageButton ID="ibgr9" runat="server" CausesValidation="False"
                                                 CssClass="relo" Height="19px" ImageUrl="~/Img/del.png" TabIndex="99"
                                                 ToolTip="Eliminar Descripción" Width="20px" OnClick="ibgr9_Click"/>
                                <asp:ConfirmButtonExtender ID="cbe3" runat="server"
                                                           ConfirmText="Desea realmente eliminar la Descripción?" Enabled="True"
                                                           TargetControlID="ibgr9">
                                </asp:ConfirmButtonExtender>
                            </asp:Panel>
                            <telerik:RadListBox ID="rlbdescripcion" runat="server" AutoPostBack="True"
                                                CssClass="panmar" Width="95%" EmptyMessage="Descripciones no disponibles"
                                          Height="450px" OnSelectedIndexChanged="rlbdescripcion_SelectedIndexChanged">

                                <ButtonSettings TransferButtons="All"/>
                                <EmptyMessageTemplate>
                                    Descripciones no disponibles
                                </EmptyMessageTemplate>
                            </telerik:RadListBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                     <asp:Panel ID="PanelTrasladoDesc" runat="server" CssClass="panmar"
                   GroupingText="Aprobadores Traslados">
            <asp:UpdatePanel ID="uptrasladosDesc" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Panel ID="panstrasladosDesc" runat="server" CssClass="panmar2">
                        <asp:ImageButton ID="ibgr4trasladosDesc" runat="server" CausesValidation="False"
                                         CssClass="relo" Height="20px" ImageUrl="~/Img/add.png" onclick="ibgr4trasladosDesc_Click"
                                         TabIndex="99" ToolTip="Agregar Aprobador" Width="21px"/>
                        &nbsp;
                        <asp:ImageButton ID="ibgr5trasladosDesc" runat="server" CausesValidation="False"
                                         CssClass="relo" Height="21px" ImageUrl="~/Img/pen.png" onclick="ibgr5trasladosDesc_Click"
                                         TabIndex="99" ToolTip="Editar Aprobador" Width="21px"/>
                        &nbsp;
                        <asp:ImageButton ID="ibgr6trasladosDesc" runat="server" CausesValidation="False"
                                         CssClass="relo" Height="19px" ImageUrl="~/Img/del.png" onclick="ibgr6trasladosDesc_Click"
                                         TabIndex="99" ToolTip="Eliminar Aprobador" Width="20px"/>
                    </asp:Panel>
                    <telerik:RadListBox ID="rblTrasladoDesc" runat="server" AutoPostBack="True"
                                        CssClass="panmar" Width="95%" EmptyMessage="Sin Usuarios Asociadas"
                                        Height="155px">
                        <EmptyMessageTemplate>
                            Usuarios no disponibles
                        </EmptyMessageTemplate>
                    </telerik:RadListBox>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>

        <asp:Panel ID="PanelBajaDesc" runat="server" CssClass="panmar"
                   GroupingText="Aprobadores Bajas">
            <asp:UpdatePanel ID="upbajasDesc" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Panel ID="pansbajasDesc" runat="server" CssClass="panmar2">
                        <asp:ImageButton ID="ibgr4bajasDesc" runat="server" CausesValidation="False"
                                         CssClass="relo" Height="20px" ImageUrl="~/Img/add.png" onclick="ibgr4bajasDesc_Click"
                                         TabIndex="99" ToolTip="Agregar Aprobador" Width="21px"/>
                        &nbsp;
                        <asp:ImageButton ID="ibgr5bajasDesc" runat="server" CausesValidation="False"
                                         CssClass="relo" Height="21px" ImageUrl="~/Img/pen.png" onclick="ibgr5bajasDesc_Click"
                                         TabIndex="99" ToolTip="Editar Aprobador" Width="21px"/>
                        &nbsp;
                        <asp:ImageButton ID="ibgr6bajasDesc" runat="server" CausesValidation="False"
                                         CssClass="relo" Height="19px" ImageUrl="~/Img/del.png" onclick="ibgr6bajasDesc_Click"
                                         TabIndex="99" ToolTip="Eliminar Aprobador" Width="20px"/>
                    </asp:Panel>
                    <telerik:RadListBox ID="rblBajaDesc" runat="server" AutoPostBack="True"
                                        CssClass="panmar" Width="95%" EmptyMessage="Sin Usuarios Asociadas"
                                        Height="155px">
                        <EmptyMessageTemplate>
                            Usuarios no disponibles
                        </EmptyMessageTemplate>
                    </telerik:RadListBox>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
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
           Width="430px" style="display: none">
    <%--style="display: none"--%>
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
                                        <h6>
                                            Nombre:
                                        </h6>
                                    </td>
                                    <td class="auto-style1">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                                                    ControlToValidate="txtnombre2" ErrorMessage="Ingrese Nombre"
                                                                    ValidationGroup="22" ForeColor="Red">
                                            *
                                        </asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="vce2" runat="server" Enabled="True"
                                                                      TargetControlID="RequiredFieldValidator3">
                                        </asp:ValidatorCalloutExtender>
                                    </td>
                                    <td>
                                        <telerik:RadTextBox ID="txtnombre2" runat="server"
                                                            Width="100%" CssClass="form-control">
                                            <EmptyMessageStyle Font-Italic="True"/>
                                        </telerik:RadTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td class="auto-style1">&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                           <td width="115">
                                        <h6>
                                            Codigo:
                                        </h6>
                                    </td>
                                    <td class="auto-style1">

                                    </td>
                                    <td>
                                        <div class="form-group">
                                            <telerik:RadTextBox ID="txtcodigo2" runat="server" Width="100%" CssClass="form-control">
                                                <EmptyMessageStyle Font-Italic="True"/>
                                            </telerik:RadTextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td class="auto-style1">&nbsp;</td>
                                    <td class="aatr">
                                        <asp:Button ID="btncerrar2" runat="server" CssClass="btn btn-danger" CausesValidation="False"
                                                    OnClick="btncerrar2_Click" Text="Cerrar"/>
                                        &nbsp;
                                        <asp:Button ID="btnsave2" runat="server" CssClass="btn btn-primary" OnClick="btnsave2_Click"
                                                    Text="Guardar" ValidationGroup="22"/>
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
<asp:Label ID="Label1" runat="server"></asp:Label>
<asp:ModalPopupExtender ID="mpnuevo" runat="server"
                        BackgroundCssClass="modalBackground" DynamicServicePath="" Enabled="True"
                        PopupControlID="pan" TargetControlID="Label1">
</asp:ModalPopupExtender>
<br/>
<asp:Panel ID="pan" runat="server" Height="142px"
           Width="430px">
    <%--style="display:none"--%>
    <asp:UpdatePanel ID="upnuevo" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table style="background-color: white" cellpadding="0" cellspacing="0" class="style1">
                <tr>
                    <td class="mess">
                        <table cellpadding="0" cellspacing="0" class="style1">
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
                                <div class="form-group">
                                     <tr>
                                        <td width="115">
                                            <h6>
                                                Nombre:
                                            </h6>
                                            <asp:ValidatorCalloutExtender ID="vce" runat="server" Enabled="True"
                                                                          TargetControlID="RequiredFieldValidator1">
                                            </asp:ValidatorCalloutExtender>
                                        </td>
                                        <td class="auto-style1">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtnombre" ErrorMessage="Ingrese Nombre" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <div class="form-group">
                                                <telerik:RadTextBox ID="txtnombre" runat="server" Width="100%" CssClass="form-control">
                                                    <EmptyMessageStyle Font-Italic="True"/>
                                                </telerik:RadTextBox>
                                            </div>
                                        </td>
                                    </tr>
                                   
                                    <tr>
                                        <td width="115">
                                            <h6>
                                                Codigo:
                                            </h6>
                                        </td>
                                        <td class="auto-style1">

                                        </td>
                                        <td>
                                            <div class="form-group">
                                                <telerik:RadTextBox ID="txtcodigo" runat="server" Width="100%" CssClass="form-control">
                                                    <EmptyMessageStyle Font-Italic="True"/>
                                                </telerik:RadTextBox>
                                            </div>
                                        </td>
                                    </tr>
                                         <tr>
                                        <td>
                                            <h6>
                                                Cuenta Categoria:
                                            </h6>
                                            <asp:ValidatorCalloutExtender ID="RequiredFieldValidator6_ValidatorCalloutExtender"
                                                                          runat="server" Enabled="True" TargetControlID="RequiredFieldValidator6">
                                            </asp:ValidatorCalloutExtender>
                                        </td>
                                        <td class="auto-style1">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtcta1" ErrorMessage="Ingrese Cuenta" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtcta1" runat="server" EmptyMessage="Ingrese Cuenta"
                                                                Width="100%" CssClass="form-control">
                                                <ClientEvents OnKeyPress="KeyPress"/>
                                                <EmptyMessageStyle Font-Italic="True"/>
                                            </telerik:RadTextBox>
                                        </td>
                                    </tr>
                                        
                                   <tr>
                    <td>
                        <h6>
                            Cuenta Depreciación Gasto:
                        </h6>
                         <td class="auto-style1">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                            runat="server" ControlToValidate="txtcta2" ErrorMessage="Ingrese Cuenta" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                             <telerik:RadTextBox ID="txtcta2" runat="server" EmptyMessage="Ingrese Cuenta" Width="100%" CssClass="form-control">
                            <ClientEvents OnKeyPress="KeyPress"/>
                            <EmptyMessageStyle Font-Italic="True"/>
                        </telerik:RadTextBox>
                    </td>
                        </td>
                </tr>
                                     <tr>
                                        <td>
                                            <h6>
                                                Cuenta Depreciación Acumulada:
                                            </h6>
                                            <asp:ValidatorCalloutExtender ID="RequiredFieldValidator5_ValidatorCalloutExtender"
                                                                          runat="server" Enabled="True" TargetControlID="RequiredFieldValidator5">
                                            </asp:ValidatorCalloutExtender>
                                        </td>
                                        <td class="auto-style1">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"  Width="100%" ControlToValidate="txtcta3" ErrorMessage="Ingrese Cuenta" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtcta3" runat="server" EmptyMessage="Ingrese Cuenta"
                                                                Width="100%" CssClass="form-control">
                                                <ClientEvents OnKeyPress="KeyPress"/>
                                                <EmptyMessageStyle Font-Italic="True"/>
                                            </telerik:RadTextBox>
                                        </td>
                                    </tr>
                <tr>
                    <td>
                        <h6>
                            Vida Util Tributaria:
                        </h6>
                        <td class="auto-style1">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtvu"  ErrorMessage="Ingrese Vida Util" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                            <td>
                        <telerik:RadTextBox ID="txtvu" runat="server" EmptyMessage="Ingrese Vida Util" MaxLength="4" Width="100%" CssClass="form-control">
                            <ClientEvents OnKeyPress="KeyPress"/>
                            <EmptyMessageStyle Font-Italic="True"/>
                        </telerik:RadTextBox>
                   </td>
                    </td>
                </tr>
                               
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td class="auto-style1">&nbsp;</td>
                                        <td class="aatr">
                                            <asp:Button ID="btncerrar" runat="server" CssClass="btn btn-danger" CausesValidation="False"
                                                        OnClick="btncerrar_Click" Text="Cerrar"/>
                                            &nbsp;
                                            <asp:Button ID="btnsave" runat="server" CssClass="btn btn-primary" OnClick="btnsave_Click" Text="Guardar"
                                                        ValidationGroup="1"/>
                                        </td>
                                    </tr>
                                </div>
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
    <asp:Label ID="Label3" runat="server"></asp:Label>
<asp:ModalPopupExtender ID="mp3" runat="server"
                        BackgroundCssClass="modalBackground" DynamicServicePath="" Enabled="True"
                        PopupControlID="pan3" TargetControlID="Label3">
</asp:ModalPopupExtender>
<asp:Panel ID="pan3" runat="server" Height="142px"
           Width="430px" style="display:none">
    <%--style="display:none"--%>
    <asp:UpdatePanel ID="upnuevo3" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table style="background-color:white" cellpadding="0" cellspacing="0" class="style1">
                <tr>
                    <td class="mess">
                        <table cellpadding="0" cellspacing="0" class="style2">
                            <tr>
                                <td width="10">
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="lblmp3" runat="server" ForeColor="White"></asp:Label>
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
                                    <td class="auto-style4">
                                        <h6>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddUsuario" ErrorMessage="Seleccione Usuario" ValidationGroup="23" ForeColor="Red">*</asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="vce3" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator4">
                                            </asp:ValidatorCalloutExtender>
                                        </h6>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddUsuario" runat="server" CssClass="txtdd" Width="110px">
                                        </asp:DropDownList>
                                        <asp:CascadingDropDown ID="cddUsuario" runat="server" Category="tbaja"
                                                               ContextKey="4" Enabled="True" LoadingText="[Cargando Usuarios...]"
                                                               PromptText="• Seleccione •" ServiceMethod="GetUsuarios" ServicePath="ws.asmx"
                                                               TargetControlID="ddUsuario">
                                        </asp:CascadingDropDown>
                                        <asp:HiddenField ID="ugeIdSelected" runat="server"/>
                                        <asp:HiddenField ID="tipoSelected" runat="server"/>
                                        <asp:HiddenField ID="nivelSelected" runat="server"/>
                                        <asp:HiddenField ID="idSelected" runat="server"/>
                                        <asp:HiddenField ID="ordenSelected" runat="server"/>
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
                                        &nbsp;
                                    </td>
                                    <td class="auto-style4">&nbsp;</td>
                                    <td class="aatr">
                                        <asp:Button ID="btncerrar3" runat="server" CssClass="btn btn-danger" CausesValidation="False"
                                                    onclick="btncerrar3_Click" Text="Cerrar"/>
                                        &nbsp;
                                        <asp:Button ID="btnsave3" runat="server" CssClass="btn btn-primary" onclick="btnsave3_Click"
                                                    Text="Guardar" ValidationGroup="23"/>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="mess">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>


<uc1:messbox ID="messbox1" runat="server"/>
</asp:Content>
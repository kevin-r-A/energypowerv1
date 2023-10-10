<%@ Page Title="" Language="C#" MasterPageFile="~/Site/Activos/cay.master" AutoEventWireup="true" CodeFile="TrasladosInd.aspx.cs" Inherits="TrasladosInd" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="../../Ctrl/Wait/wait.ascx" TagName="wait" TagPrefix="uc1" %>
<%@ Register Src="../../Ctrl/Msg/messbox.ascx" TagName="messbox" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        
        .auto-style3 {
            width: 336px;
            background-image: url('../../Img/a1.png');
            background-repeat: no-repeat;
            background-position: left top;
        }

        .auto-style4 {
            vertical-align: top;
            text-align: left;
            width: 336px;
        }

        .auto-style6 {
            width: 152px;
        }

        .auto-style8 {
            width: 110px;
        }
        .auto-style9 {
            width: 99px;
        }
        .auto-style10 {
            height: 17px;
        }
        .auto-style11 {
            height: 17px;
            width: 140px;
        }
        .auto-style12 {
            width: 140px;
        }
        .auto-style14 {
            width: 195px;
        }
        .auto-style15 {
            width: 173px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="cph1">
<script type="text/javascript">
        function KeyPress(sender, args) {
            var regexp = new RegExp("[0-9]{1}|[\b]|\t|\r");
            if (!args.get_keyCharacter().match(regexp))
                args.set_cancel(true);
        }

        function OpenWindows(url) {
            window.open(url, " Reporte Traslado Individual", "directories=no, location=no, menubar=no, scrollbars=yes, statusbar=no, tittlebar=no, width=300");
            window.focus();
        }

        function windowOpener(url, name, args) {
            if (typeof (popupWin) != "object") {
                popupWin = window.open(url, name, args);
            } else {
                if (!popupWin.closed) {
                    popupWin.location.href = url;
                } else {
                    popupWin = window.open(url, name, args);
                }
            }
            popupWin.focus();
        }
    </script>
<asp:Panel ID="panbus" runat="server" CssClass="panmar"
           GroupingText="Buscar Activo - Traslados Individuales">
    <table cellpadding="0" cellspacing="0" class="panmar2">
        <tr>
            <td class="aatl">
                <table cellspacing="0" width="100%">
                    <tr>
                        <td class="auto-style15">
                            <h4>
                                Código de Barras:
                                <asp:ValidatorCalloutExtender
                                    ID="rfv1_ValidatorCalloutExtender0" runat="server"
                                    Enabled="True" TargetControlID="rfv1" PopupPosition="BottomRight" WarningIconImageUrl="~/Img/warning.png">
                                </asp:ValidatorCalloutExtender>
                                <asp:RequiredFieldValidator ID="rfv1" runat="server"
                                                            ControlToValidate="txtbuscb" ErrorMessage="Ingrese Código de Barras"
                                                            ForeColor="Red" ValidationGroup="1">
                                    *
                                </asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="rfv1_ValidatorCalloutExtender" runat="server"
                                                              Enabled="True" PopupPosition="BottomRight" TargetControlID="rfv1" WarningIconImageUrl="~/Img/warning.png">
                                </asp:ValidatorCalloutExtender>
                            </h4>
                        </td>
                        <td width="150">
                            <div class="form-group">
                                <telerik:RadTextBox ID="txtbuscb" runat="server" MaxLength="40"
                                                    OnTextChanged="txtbuscb_TextChanged" Width="150px" Height="25px" CssClass="form-control">

                                    <EmptyMessageStyle Font-Italic="True"/>
                                </telerik:RadTextBox>
                            </div>
                        </td>
                        <td valign="top">
                            <asp:ImageButton ID="ibbus1" runat="server" CssClass="relo" Height="35px"
                                             ImageUrl="~/Img/buscarblue.png" OnClick="ibbus1_Click" TabIndex="99"
                                             ToolTip="Buscar Código de Barras" ValidationGroup="1" Width="35px"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style15">
                            <h4>
                                Código Secundario:
                                <asp:ValidatorCalloutExtender ID="rfv2_ValidatorCalloutExtender0" runat="server"
                                                              Enabled="True" TargetControlID="rfv2" PopupPosition="BottomRight" WarningIconImageUrl="~/Img/warning.png">
                                </asp:ValidatorCalloutExtender>
                                <asp:RequiredFieldValidator ID="rfv2" runat="server"
                                                            ControlToValidate="txtbusid" ErrorMessage="Ingrese Código Secundario" ForeColor="Red"
                                                            ValidationGroup="2">
                                    *
                                </asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="rfv2_ValidatorCalloutExtender" runat="server"
                                                              Enabled="True" PopupPosition="BottomRight" TargetControlID="rfv2" WarningIconImageUrl="~/Img/warning.png">
                                </asp:ValidatorCalloutExtender>
                            </h4>
                        </td>
                        <td>
                            <div class="form-group">
                                <telerik:RadTextBox ID="txtbusid" runat="server" MaxLength="150" Width="150px" Height="25px" CssClass="form-control">

                                    <%--<ClientEvents OnKeyPress="KeyPress" />--%>
                                    <EmptyMessageStyle Font-Italic="True"/>
                                </telerik:RadTextBox>
                            </div>
                        </td>
                        <td valign="top">
                            <asp:ImageButton ID="ibbus3" runat="server" CssClass="relo" Height="35px"
                                             ImageUrl="~/Img/buscarblue.png" OnClick="ibbus3_Click" TabIndex="99"
                                             ToolTip="Buscar Cod Secundario" ValidationGroup="2" Width="35px"/>
                        </td>
                    </tr>
                     <tr>
                        <td class="auto-style15">
                            <h4>
                                Serie:
                                <asp:ValidatorCalloutExtender ID="rfv3_ValidatorCalloutExtender0" runat="server"
                                                              Enabled="True" TargetControlID="rfv3" PopupPosition="BottomRight" WarningIconImageUrl="~/Img/warning.png">
                                </asp:ValidatorCalloutExtender>
                                <asp:RequiredFieldValidator ID="rfv3" runat="server"
                                                            ControlToValidate="txtbuss" ErrorMessage="Ingrese Serie" ForeColor="Red"
                                                            ValidationGroup="3">
                                    *
                                </asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="rfv3_ValidatorCalloutExtender" runat="server"
                                                              Enabled="True" PopupPosition="BottomRight" TargetControlID="rfv3" WarningIconImageUrl="~/Img/warning.png">
                                </asp:ValidatorCalloutExtender>
                            </h4>
                        </td>
                        <td>
                            <div class="form-group">
                                <telerik:RadTextBox ID="txtbuss" runat="server" MaxLength="150" Width="150px" Height="25px" CssClass="form-control">

                                    <%--<ClientEvents OnKeyPress="KeyPress" />--%>
                                    <EmptyMessageStyle Font-Italic="True"/>
                                </telerik:RadTextBox>
                            </div>
                        </td>
                        <td valign="top">
                            <asp:ImageButton ID="ibbus4" runat="server" CssClass="relo" Height="35px"
                                             ImageUrl="~/Img/buscarblue.png" OnClick="ibbus4_Click" TabIndex="99"
                                             ToolTip="Serie" ValidationGroup="3" Width="35px"/>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:Panel ID="panuevo" runat="server" CssClass="panmar"
           GroupingText="Información del Activo" Visible="False">
<div style="margin: 5px">
<table cellpadding="0"
       cellspacing="0" class="style1">
    <tr>
        <td class="auto-style3" height="30">&#160;</td>
        <td align="right"
            class="ba2" width="40%">
            &nbsp;
        </td>
        <td rowspan="2" width="226">
            <table cellspacing="0"
                   class="style3">
                <tr>
                    <td>
                        <table cellspacing="0" class="style2">
                            <tr>
                                <td width="30">
                                    <table cellspacing="0" class="style2">
                                        <tr>
                                            <td>
                                                <asp:HyperLink ID="hk1" runat="server" BorderStyle="None" BorderWidth="0px"
                                                               Height="20px" ImageUrl="~/Img/img.png" Style="text-decoration: none"
                                                               Target="_blank" ToolTip="Ver Foto 1" Width="30px">
                                                </asp:HyperLink>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:HyperLink ID="hk2" runat="server" CssClass="ima" Height="20px"
                                                               ImageUrl="~/Img/img.png" Target="_blank" ToolTip="Ver Foto 2" Width="30px">
                                                </asp:HyperLink>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:HyperLink ID="hk3" runat="server" CssClass="ima" Height="20px"
                                                               ImageUrl="~/Img/fac.png" Target="_blank" ToolTip="Ver Factura" Width="26px">
                                                </asp:HyperLink>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:HyperLink ID="hk4" runat="server" CssClass="ima" Height="20px"
                                                               ImageUrl="~/Img/man.png" Target="_blank" ToolTip="Ver Manual" Width="26px">
                                                </asp:HyperLink>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:HyperLink ID="hk5" runat="server" CssClass="ima" Height="20px"
                                                               ImageUrl="~/Img/cam.png" Target="_blank" ToolTip="Ver Historial Fotográfico"
                                                               Width="26px">
                                                </asp:HyperLink>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="194">
                                    <asp:Image ID="Image1" runat="server" BorderColor="#CCCCCC" BorderWidth="3px"
                                               CssClass="immarg" Height="119px" ImageUrl="~/Site/Activos/imgact/nofoto.gif"
                                               Width="180px"/>
                                    <asp:SlideShowExtender ID="sse" runat="server" AutoPlay="True" Enabled="True"
                                                           Loop="True" NextButtonID="Image1" PlayInterval="10000"
                                                           SlideShowServiceMethod="getSlides2" SlideShowServicePath="ws.asmx"
                                                           TargetControlID="Image1">
                                    </asp:SlideShowExtender>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="auto-style4">
            <div class="divv">
                <script type="text/javascript">










                                function KeyPress(sender, args) {
                                    var regexp = new RegExp("[0-9]{1}|[\b]|\t|\r");
                                    if (!args.get_keyCharacter().match(regexp))
                                        args.set_cancel(true);
                                }
                            </script>
                <asp:UpdatePanel ID="upcb" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table cellpadding="2" cellspacing="0" style="width: 100%">
                            <tr>
                                <td class="auto-style6">
                                    <h5>Tipo:</h5>
                                </td>
                                <td>
                                    <h5>
                                        <asp:Label ID="lbltipo" runat="server"></asp:Label>
                                    </h5>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style6">
                                    <h5>Código Barras:</h5>
                                </td>
                                <td>
                                    <h5>
                                        <asp:Label ID="lblcb" runat="server"></asp:Label>
                                    </h5>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style6">
                                    <h5>Código Barras Padre:</h5>
                                </td>
                                <td>
                                    <h5>
                                        <asp:Label
                                            ID="lblcbp" runat="server">
                                        </asp:Label>
                                    </h5>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style6">
                                    <h5>Código Secundario:</h5>
                                </td>
                                <td>
                                    <h5>
                                        <asp:Label
                                            ID="lblcod1" runat="server">
                                        </asp:Label>
                                    </h5>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </td>
        <td class="aatl">
            <div class="divv">
                <table cellpadding="2" cellspacing="0" class="style1">
                    <tr>
                        <td class="auto-style8">
                            <h5>Id:</h5>
                        </td>
                        <td>
                            <h5>
                                <asp:Label ID="lblid" runat="server"></asp:Label>
                            </h5>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style8">
                            <h5>Grupo/Cuenta:</h5>
                        </td>
                        <td>
                            <h5>
                                <asp:Label ID="lblgru" runat="server"></asp:Label>
                            </h5>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style8">
                            <h5>Subgrupo:</h5>
                        </td>
                        <td>
                            <h5>
                                <asp:Label ID="lblsgru" runat="server"></asp:Label>
                            </h5>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style8">
                            <h5>Descripción:</h5>
                        </td>
                        <td>
                            <h5>
                                <asp:Label ID="lbldesc" runat="server"></asp:Label>
                            </h5>
                        </td>
                    </tr>
                </table>
            </div>
        </td>
    </tr>
</table>
<table cellpadding="0" cellspacing="0"
       class="style1">
<tr>
    <td width="40%">&nbsp;</td>
    <td width="40%">&#160;</td>
    <td>&#160;</td>
</tr>
<tr>
    <td align="right" class="ba3" height="30">
        <table cellspacing="0" class="style2">
            <tr>
                <td width="210">&nbsp;</td>
                <td class="aacl">
                    <asp:ImageButton ID="ibgr2" runat="server" CausesValidation="False"
                                     CssClass="relo" Height="18px" ImageUrl="~/Img/rl1.png" TabIndex="99"
                                     ToolTip="Actualizar Clasificación" Width="21px"/>
                </td>
            </tr>
        </table>
    </td>
    <td align="right" class="ba4">
        <table cellspacing="0" class="style2">
            <tr>
                <td width="194">&nbsp;</td>
                <td class="aacl">
                    <asp:ImageButton ID="ibgr3" runat="server" CausesValidation="False"
                                     CssClass="relo" Height="18px" ImageUrl="~/Img/rl1.png" TabIndex="99"
                                     ToolTip="Actualizar Clasificación" Width="21px"/>
                </td>
            </tr>
        </table>
    </td>
    <td align="right" class="ba5">&#160;</td>
</tr>
<tr>
<td class="aatl" width="40%">
    <div
        class="divv">
        <asp:UpdatePanel ID="upgeo" runat="server"
                         UpdateMode="Conditional">
            <ContentTemplate>
                <table cellpadding="2" cellspacing="0"
                       class="style1">
                    <tr>
                        <td width="100">Ub. Geográfica 1:</td>
                        <td>
                            <div class="form-group">
                                <asp:DropDownList
                                    ID="ddUge1" runat="server" CssClass="txtdd" Width="100%">
                                </asp:DropDownList>
                                <asp:CascadingDropDown
                                    ID="cddgeo1" runat="server" Category="uge1" Enabled="True"
                                    LoadingText="[Cargando Geo1...]" PromptText="• Seleccione •"
                                    ServiceMethod="GetUge1" ServicePath="ws.asmx" TargetControlID="ddUge1">
                                </asp:CascadingDropDown>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>Ub. Geográfica 2:</td>
                        <td>
                            <div class="form-group">
                                <asp:DropDownList
                                    ID="ddUge2" runat="server" CssClass="txtdd" Width="100%">
                                </asp:DropDownList>
                                <asp:CascadingDropDown
                                    ID="cddgeo2" runat="server" Category="uge2" Enabled="True"
                                    LoadingText="[Cargando Geo2...]" ParentControlID="ddUge1"
                                    PromptText="• Seleccione •" ServiceMethod="GetUge2" ServicePath="ws.asmx"
                                    TargetControlID="ddUge2">
                                </asp:CascadingDropDown>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>Ub. Geográfica 3:</td>
                        <td>
                            <div class="form-group">
                                <asp:DropDownList
                                    ID="ddUge3" runat="server" CssClass="txtdd" Width="100%">
                                </asp:DropDownList>
                                <asp:CascadingDropDown
                                    ID="cddgeo3" runat="server" Category="uge3" Enabled="True"
                                    LoadingText="[Cargando Geo3...]" ParentControlID="ddUge2"
                                    PromptText="• Seleccione •" ServiceMethod="GetUge3" ServicePath="ws.asmx"
                                    TargetControlID="ddUge3">
                                </asp:CascadingDropDown>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Piso/Nivel:
                            <asp:RequiredFieldValidator
                                ID="rfvtipo2" runat="server" ControlToValidate="ddPiso"
                                ErrorMessage="Seleccione Piso/Nivel">
                                *
                            </asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender
                                ID="rfvtipo2_vce" runat="server" Enabled="True" TargetControlID="rfvtipo2">
                            </asp:ValidatorCalloutExtender>
                        </td>
                        <td>
                            <div class="form-group">
                                <asp:DropDownList
                                    ID="ddPiso" runat="server" CssClass="txtdd" Width="175px">
                                </asp:DropDownList>
                                <asp:CascadingDropDown
                                    ID="cddpiso" runat="server" Category="pis_id" Enabled="True"
                                    LoadingText="[Cargando Piso...]" ParentControlID="ddUge3"
                                    PromptText="• Seleccione •" ServiceMethod="GetUge4" ServicePath="ws.asmx"
                                    TargetControlID="ddPiso">
                                </asp:CascadingDropDown>
                            </div>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger
                    ControlID="ibgr2" EventName="Click"/>
            </Triggers>
        </asp:UpdatePanel>
    </div>
</td>
<td class="aatl" width="40%">
    <div class="divv">
        <asp:UpdatePanel
            ID="upuor0" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table cellpadding="2" cellspacing="0"
                       class="style1">
                    <tr>
                        <td width="98">Centro de Costo:</td>
                        <td>
                            <div class="form-group">
                                <asp:DropDownList
                                    ID="ddCcosto" runat="server" CssClass="txtdd" Width="100%">
                                </asp:DropDownList>
                                <asp:CascadingDropDown
                                    ID="cddccosto" runat="server" Category="cco" Enabled="True"
                                    LoadingText="[Cargando Centro de Costo...]"
                                    PromptText="• Seleccione •" ServicePath="ws.asmx"
                                    TargetControlID="ddCcosto">
                                </asp:CascadingDropDown>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>Ub. Orgánica 1:</td>
                        <td>
                            <div class="form-group">
                                <asp:DropDownList
                                    ID="ddUor1" runat="server" CssClass="txtdd" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddUor1_OnSelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:CascadingDropDown
                                    ID="cdduor1" runat="server" Category="uor1" Enabled="True"
                                    LoadingText="[Cargando Dep1...]"
                                    PromptText="• Seleccione •" ServicePath="ws.asmx"
                                    TargetControlID="ddUor1">
                                </asp:CascadingDropDown>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Ub. Orgánica 2:
                            <asp:RequiredFieldValidator
                                ID="rfvtipo4" runat="server" ControlToValidate="ddUor2"
                                ErrorMessage="Seleccione Ubicación Orgánica 2">
                                *
                            </asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender
                                ID="rfvtipo4_vce" runat="server" Enabled="True" TargetControlID="rfvtipo4">
                            </asp:ValidatorCalloutExtender>
                        </td>
                        <td>
                            <div class="form-group">
                                <asp:DropDownList
                                    ID="ddUor2" runat="server" CssClass="txtdd" Width="100%">
                                </asp:DropDownList>
                                <asp:CascadingDropDown
                                    ID="cdduor2" runat="server" Category="uor2" Enabled="True"
                                    LoadingText="[Cargando Dep2...]" ParentControlID="ddUor1"
                                    PromptText="• Seleccione •" ServiceMethod="GetUor2" ServicePath="ws.asmx"
                                    TargetControlID="ddUor2">
                                </asp:CascadingDropDown>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Custodio:
                            <asp:RequiredFieldValidator
                                ID="rfvtipo3" runat="server" ControlToValidate="ddCustodio"
                                ErrorMessage="Seleccione Custodio">
                                *
                            </asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender
                                ID="rfvtipo3_vce" runat="server" Enabled="True" TargetControlID="rfvtipo3">
                            </asp:ValidatorCalloutExtender>
                        </td>
                        <td>
                            <div class="form-group">
                                <asp:DropDownList ID="ddCustodio" runat="server" CssClass="txtdd" Width="100%">
                                </asp:DropDownList>
                                <asp:CascadingDropDown ID="cddcus" runat="server" Category="cus" ContextKey=""
                                                       Enabled="True" LoadingText="[Cargando Custodios...]" ParentControlID="ddUor1"
                                                       PromptText="• Seleccione •" ServiceMethod="GetCusUor1" ServicePath="ws.asmx"
                                                       TargetControlID="ddCustodio">
                                </asp:CascadingDropDown>
                            </div>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger
                    ControlID="ibgr3" EventName="Click"/>
            </Triggers>
        </asp:UpdatePanel>
    </div>
</td>
<td class="aatl">
    <div class="divv">
        <table cellpadding="2" cellspacing="0" class="style1">
            <tr>
                <td width="90">Estado:</td>
                <td>
                    <div class="form-group">
                        <asp:DropDownList ID="ddEstado" runat="server" CssClass="txtdd" Width="110px">
                        </asp:DropDownList>
                        <asp:CascadingDropDown ID="cddest1" runat="server" Category="est1"
                                               ContextKey="1" Enabled="True" LoadingText="[Cargando Estado 1...]"
                                               PromptText="• Seleccione •" ServiceMethod="GetEstado" ServicePath="ws.asmx"
                                               TargetControlID="ddEstado">
                        </asp:CascadingDropDown>
                    </div>
                </td>
            </tr>
            <tr>
                <td>Fase:</td>
                <td>
                    <div class="form-group">
                        <asp:DropDownList ID="ddFase" runat="server" CssClass="txtdd" Width="110px">
                        </asp:DropDownList>
                        <asp:CascadingDropDown ID="cddest2" runat="server" Category="est2"
                                               ContextKey="2" Enabled="True" LoadingText="[Cargando Estado 2...]"
                                               PromptText="• Seleccione •" ServiceMethod="GetEstado2" ServicePath="ws.asmx"
                                               TargetControlID="ddFase">
                        </asp:CascadingDropDown>
                    </div>
                </td>
            </tr>
            <tr>
                <td>Transferencia:</td>
                <td>
                    <div class="form-group">
                        <asp:DropDownList ID="ddTrasnfer" runat="server" CssClass="txtdd" Width="110px">
                        </asp:DropDownList>
                        <asp:CascadingDropDown ID="cddest3" runat="server" Category="est3"
                                               ContextKey="3" Enabled="True" LoadingText="[Cargando Estado 3...]"
                                               PromptText="• Seleccione •" ServiceMethod="GetEstado" ServicePath="ws.asmx"
                                               TargetControlID="ddTrasnfer">
                        </asp:CascadingDropDown>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</td>
</tr>
</table>
<table cellpadding="0" cellspacing="0"
       class="style1">
<tr>
    <td width="40%">
        <br/>
        <br/>
    </td>
    <td width="40%">&#160;</td>
    <td>&#160;</td>
</tr>
<tr>
    <td align="right" class="ba6" height="30">&#160;</td>
    <td align="right" class="ba7">&#160;</td>
    <td align="right" class="ba8"></td>
</tr>
<tr>
<td class="aatl">
    <div class="divv">
        <table cellpadding="2" cellspacing="0" class="style1">
            <tr>
                <td class="auto-style9">
                    <h5>Marca:</h5>
                </td>
                <td>
                    <h5>
                        <asp:Label ID="lblmarca" runat="server"></asp:Label>
                    </h5>
                </td>
            </tr>
            <tr>
                <td class="auto-style9">
                    <h5>Modelo:</h5>
                </td>
                <td>
                    <h5>
                        <asp:Label ID="lblmodelo" runat="server"></asp:Label>
                    </h5>
                </td>
            </tr>
            <tr>
                <td class="auto-style9">
                    <h5>Serie:</h5>
                </td>
                <td>
                    <h5>
                        <asp:Label ID="lblserie" runat="server"></asp:Label>
                    </h5>
                </td>
            </tr>
            <tr>
                <td class="auto-style9">
                    <h5>Color:</h5>
                </td>
                <td>
                    <h5>
                        <asp:Label ID="lblcolor" runat="server"></asp:Label>
                    </h5>
                </td>
            </tr>
            <tr>
                <td class="auto-style9">
                    <h5>Año Fab.</h5>
                </td>
                <td>
                    <h5>
                        <asp:Label ID="lblaño" runat="server"></asp:Label>
                    </h5>
                </td>
            </tr>
            <tr>
                <td class="auto-style9">
                    <h5>Estructura:</h5>
                </td>
                <td>
                    <h5>
                        <asp:Label ID="lblestructura" runat="server"></asp:Label>
                    </h5>
                </td>
            </tr>
            <tr>
                <td class="auto-style9">
                    <h5>Componente:</h5>
                </td>
                <td>
                    <h5>
                        <asp:Label ID="lblcomponente" runat="server"></asp:Label>
                    </h5>
                </td>
            </tr>
            <tr>
                <td class="auto-style9">
                    <h5>Proveedor:</h5>
                </td>
                <td>
                    <h5>
                        <asp:Label ID="lblproveedor" runat="server"></asp:Label>
                    </h5>
                </td>
            </tr>
        </table>
    </div>
</td>
<td class="aatl">
    <div class="divv">
        <table cellpadding="2" cellspacing="0" class="style1">
            <tr>
                <td class="auto-style11">
                    <h5>Ingreso:</h5>
                </td>
                <td class="auto-style10">
                    <h5>
                        <asp:Label ID="lblingreso" runat="server"></asp:Label>
                    </h5>
                </td>
            </tr>
            <tr>
                <td class="auto-style12">
                    <h5>Factura No.:</h5>
                </td>
                <td>
                    <h5>
                        <asp:Label ID="lblnumfact" runat="server"></asp:Label>
                    </h5>
                </td>
            </tr>
            <tr>
                <td class="auto-style12">
                    <h5>Fecha de Compra:</h5>
                </td>
                <td>
                    <h5>
                        <asp:Label ID="lblfechacompra" runat="server"></asp:Label>
                    </h5>
                </td>
            </tr>
            <tr>
                <td class="auto-style12">
                    <h5>Valor de Compra:</h5>
                </td>
                <td>
                    <h5>
                        <asp:Label ID="lblvalorcompra" runat="server"></asp:Label>
                    </h5>
                </td>
            </tr>
            <tr>
                <td class="auto-style12">
                    <h5>Vida Util:</h5>
                </td>
                <td>
                    <h5>
                        <asp:Label ID="lblvidautil" runat="server"></asp:Label>
                        &nbsp;Meses
                    </h5>
                </td>
            </tr>
            <tr>
                <td class="auto-style12">
                    <h5>Vida Util NIIF:</h5>
                </td>
                <td>
                    <h5>
                        <asp:Label ID="lblvuniif" runat="server"></asp:Label>
                        &nbsp;Meses
                    </h5>
                </td>
            </tr>
            <tr>
                <td class="auto-style12">
                    <h5>Valor Res. NIIF:</h5>
                </td>
                <td>
                    <h5>
                        <asp:Label ID="lblvalresniif" runat="server"></asp:Label>
                    </h5>
                </td>
            </tr>
            <tr>
                <td class="auto-style12">
                    <h5>Inicio de Operación:</h5>
                </td>
                <td>
                    <h5>
                        <asp:Label ID="lblfechainioper" runat="server"></asp:Label>
                    </h5>
                </td>
            </tr>
             <tr>
                        <td height="18">
                            Valor Razonable:
                        </h5>
                        </td>
                        <td>
                            <h5>
                        <asp:Label ID="lblvalorrazonable" runat="server"></asp:Label>
                    </h5>
                            
                        </td>
                    </tr>
        </table>
    </div>
</td>
<td class="aatl">
    <div
        class="divv">
        <table cellpadding="2" cellspacing="0" class="style1">
            <tr>
                <td
                    width="50">
                    <h5>Garantía:</h5>
                </td>
                <td width="40">
                    <h5>
                        <asp:Label ID="lblgarantia"
                                   runat="server">
                        </asp:Label>
                    </h5>
                </td>
            </tr>
            <tr>
                <td width="50">
                    <h5>Vence:</h5>
                </td>
                <td
                    width="40">
                    <h5>
                        <asp:Label ID="lblfechavencegar" runat="server"></asp:Label>
                    </h5>
                </td>
            </tr>
        </table>
    </div>
</td>
</tr>
</table>
<table cellpadding="0" cellspacing="0" class="style1">
    <tr>
        <td height="20">&nbsp;</td>
    </tr>
    <tr>
        <td align="right" class="ba9"
            height="30">
            &#160;
        </td>
    </tr>
    <tr>
        <td class="aatl">
            <div class="divv">
                <asp:Label ID="lblobservaciones" runat="server"></asp:Label>
            </div>
        </td>
    </tr>
</table>
<table cellpadding="0" cellspacing="0"
       class="style1">
    <tr>
        <td height="20">&nbsp;</td>
    </tr>
    <tr>
        <td align="right" class="ba10"
            height="30">
        </td>
    </tr>
    <tr>
        <td width="40%">
            <asp:UpdatePanel ID="upcar" runat="server"
                             UpdateMode="Conditional">
                <ContentTemplate>
                    <table cellpadding="0" cellspacing="0"
                           class="style1">
                        <tr>
                            <td>
                                <div class="divv">
                                    <table cellpadding="2" cellspacing="0" class="style1">
                                        <tr>
                                            <td>
                                                <asp:Label ID="l1"
                                                           runat="server">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="l2"
                                                           runat="server">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="l3"
                                                           runat="server">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="l4"
                                                           runat="server">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="l5"
                                                           runat="server">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="l6"
                                                           runat="server">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="l7"
                                                           runat="server">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="l8"
                                                           runat="server">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                            <td width="40">&#160;</td>
                            <td>
                                <div class="divv">
                                    <table cellpadding="2" cellspacing="0"
                                           class="style1">
                                        <tr>
                                            <td>
                                                <asp:Label ID="l9" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="l10"
                                                           runat="server">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="l11"
                                                           runat="server">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="l12"
                                                           runat="server">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="l13"
                                                           runat="server">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="l14"
                                                           runat="server">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="l15"
                                                           runat="server">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="l16"
                                                           runat="server">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
</table>
<table cellpadding="0" cellspacing="0" class="style1" style="margin-bottom: 45px">
    <tr>
        <td class="ba6" height="30">
            <table cellpadding="0" cellspacing="0" class="style1">
                <tr>
                    <td width="168">&nbsp;</td>
                    <td>

                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <asp:UpdatePanel ID="upAsiento" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <table cellpadding="0" cellspacing="0" class="style1">
                        <thead>
                        <tr>
                            <th>Descripción</th>
                            <th>Cuenta</th>
                            <th>Oficina</th>
                            <th>Centro de costo</th>
                            <th>Debito</th>
                            <th>Credito</th>
                        </tr>
                        </thead>
                        <tbody>
                        <tr>
                            <td>Cuenta Activo Origen</td>
                            <td>
                                <asp:Label runat="server" ID="lblCuentaOrigen"></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblOficina1"></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblCentroCosto1"></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblDebito1"></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblCredito1"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Cuenta Activo Destino</td>
                            <td>
                                <asp:Label runat="server" ID="lblCuentaDestino"></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblOficina2"></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblCentroCosto2"></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblDebito2"></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblCredito2"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Cuenta Depreciación Origen</td>
                            <td>
                                <asp:Label runat="server" ID="lblCuentaDepreOrigen"></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblOficinaDepre1"></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblCentroCostoDepre1"></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblDebitoDepre1"></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblCreditoDepre1"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Cuenta Depreciación Destino</td>
                            <td>
                                <asp:Label runat="server" ID="lblCuentaDepreDestino"></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblOficinaDepre2"></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblCentroCostoDepre2"></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblDebitoDepre2"></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblCreditoDepre2"></asp:Label>
                            </td>
                        </tr>
                        </tbody>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
</table>
</div>
</asp:Panel>
<asp:Panel ID="panCommand" runat="server" BackColor="White" CssClass="aabrpan"
           Height="32px" Width="100%">
    <div class="panmar3">
        <asp:ImageButton ID="ibcancel" runat="server" CausesValidation="False"
                         Height="28px" ImageUrl="~/Img/c1.png" OnClick="ibcancel_Click" TabIndex="97"
                         Width="102px"/>
        &nbsp;
        <asp:ImageButton ID="ibsave" runat="server" Height="28px"
                         ImageUrl="~/Img/s1.png" OnClick="ibsave_Click" TabIndex="98" Width="102px"/>
    </div>
    &nbsp;
</asp:Panel>
<asp:AlwaysVisibleControlExtender ID="avcePanCommand" runat="server"
                                  Enabled="True" TargetControlID="panCommand" VerticalSide="Bottom">
</asp:AlwaysVisibleControlExtender>
<uc2:messbox ID="messbox1" runat="server"/>
</asp:Content>
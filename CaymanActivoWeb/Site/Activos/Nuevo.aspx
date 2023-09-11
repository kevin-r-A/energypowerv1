<%@ Page Title="" Language="C#" MasterPageFile="~/Site/Activos/cay.master" AutoEventWireup="true" CodeFile="Nuevo.aspx.cs" Inherits="Site_Activos_Nuevo" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Src="../../Ctrl/Wait/wait.ascx" TagName="wait" TagPrefix="uc1" %>

<%@ Register Src="../../Ctrl/Msg/messbox.ascx" TagName="messbox" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function OpenWindows(url) {
            window.open(url, " Reporte Ingreso Activo", "directories=no, location=no, menubar=no, scrollbars=yes, statusbar=no, tittlebar=no, width=500, heigth=800");
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
    <style type="text/css">
        .auto-style1 {
            height: 17px;
        }

        .auto-style3 {
            width: 10px;
        }

        .auto-style6 {
            width: 189px;
        }

        .auto-style12 {
            width: 165px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="cph1">
<asp:Panel ID="panuevo" runat="server" CssClass="panmar" GroupingText="Nuevo Activo">

<div style="margin: 5px">
<table cellpadding="0" cellspacing="0" class="style1">
    <tr>
        <td class="ba1" height="30" width="340">&nbsp;</td>
        <td class="ba2">
            <table cellpadding="0" cellspacing="0" class="style1">
                <tr>
                    <td width="150">&nbsp;</td>
                    <td>
                        <asp:ImageButton ID="ibgr1" runat="server" CausesValidation="False"
                                         CssClass="relo" Height="18px" ImageUrl="~/Img/rl1.png" TabIndex="99"
                                         ToolTip="Actualizar Clasificación" Width="21px"/>
                    </td>
                </tr>
            </table>
        </td>
        <td rowspan="2" width="200">
            <asp:Image ID="Image1" runat="server" BorderColor="#CCCCCC" BorderWidth="3px"
                       CssClass="immarg" Height="119px" ImageUrl="~/Site/Activos/imgact/nofoto.gif"
                       Width="180px"/>
        </td>
    </tr>
    <tr>
        <td class="aatl" width="280">
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
                        <div class="form-group-sm">
                            <table cellpadding="2" cellspacing="0" width="320">
                                <tr>
                                    <td width="130">
                                        <div class="form-group">
                                            <h6>Tipo:</h6>
                                        </div>
                                    </td>
                                    <td>
                                        <div class="form-group">
                                            <asp:DropDownList ID="ddtipo" runat="server" CssClass="txtdd" Width="175px"
                                                              OnSelectedIndexChanged="ddtipo_SelectedIndexChanged" AutoPostBack="True">
                                            </asp:DropDownList>
                                            <br/>
                                            <asp:RequiredFieldValidator ID="rfvtipo" runat="server"
                                                                        ControlToValidate="ddtipo" ForeColor="#E91E63" Display="Dynamic" ErrorMessage="Seleccione Tipo" SetFocusOnError="true" Text="<img src='../../Img/warning.png' /> Seleccione Tipo">
                                            </asp:RequiredFieldValidator>
                                        </div>
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <h6>Código:</h6>
                                    </td>
                                    <td>
                                        <div class="form-group">
                                            <telerik:RadTextBox ID="txtcb" runat="server" EmptyMessage="Ingrese Código"
                                                                MaxLength="40" Width="175px">
                                                <ClientEvents OnKeyPress="KeyPress"/>
                                                <EmptyMessageStyle Font-Italic="True"/>
                                            </telerik:RadTextBox>
                                            <asp:RequiredFieldValidator ID="rfvtipo0" runat="server"
                                                                        ControlToValidate="txtcb" ErrorMessage="Ingrese Código"
                                                                        ForeColor="#E91E63" Display="Dynamic" SetFocusOnError="true" Text="<img src='../../Img/warning.png' /> Ingrese Código de Barras">
                                            </asp:RequiredFieldValidator>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <h6>Código Barras Padre:</h6>
                                    </td>
                                    <td>
                                        <div class="form-group">
                                            <telerik:RadTextBox ID="txtcbpadre" runat="server" MaxLength="20" Width="175px">
                                                <ClientEvents OnKeyPress="KeyPress"/>
                                                <EmptyMessageStyle Font-Italic="True"/>
                                            </telerik:RadTextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <h6>
                                            Código Secundario:
                                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                                        ControlToValidate="txtcod1" ErrorMessage="Ingrese Código Secundario"
                                                                        ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                        </h6>
                                    </td>
                                    <td>
                                        <div class="form-group">
                                            <telerik:RadTextBox ID="txtcod1" runat="server" MaxLength="100" Width="175px">
                                            </telerik:RadTextBox>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </td>
        <td class="aatl">
            <div class="divv">
                <asp:UpdatePanel ID="upid" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table cellpadding="2" cellspacing="0" class="style1">
                            <tr>
                                <td width="90">
                                    <h6 style="display: none">Id:</h6>
                                </td>
                                <td>
                                    <asp:Label ID="lblid" runat="server" ViewStateMode="Disabled" style="display: none"></asp:Label>
                                </h5>
                                </td>
                                <td width="100">
                                    <h6>Fecha Creación:</h6>
                                </td>
                                <td>
                                    <asp:Label ID="lblFechacreacion" runat="server" ViewStateMode="Disabled"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="upgru" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="form-group">
                            <table cellpadding="2" cellspacing="0" class="style1">
                                <tr>
                                    <td width="90">
                                        <h6>Grupo/Cuenta:</h6>
                                    </td>
                                    <td>
                                        <div class="form-group">
                                            <asp:DropDownList ID="ddGrupo" runat="server" AutoPostBack="True" 
                                                              CssClass="txtdd" OnSelectedIndexChanged="ddGrupo_SelectedIndexChanged"
                                                              Width="100%">
                                            </asp:DropDownList>
                                            <asp:CascadingDropDown ID="cddgru1" runat="server" Category="gru1"
                                                                   Enabled="True" LoadingText="[Cargando Grupo...]" PromptText="• Seleccione •"
                                                                   ServiceMethod="GetGru1" ServicePath="ws.asmx" TargetControlID="ddGrupo">
                                            </asp:CascadingDropDown>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <h6>Subgrupo:</h6>
                                    </td>
                                    <td>
                                        <div class="form-group">
                                            <asp:DropDownList ID="ddSubgrupo" runat="server" CssClass="txtdd" Width="100%">
                                            </asp:DropDownList>
                                            <asp:CascadingDropDown ID="cddgru2" runat="server" Category="gru2"
                                                                   Enabled="True" LoadingText="[Cargando Subgrupo...]" ParentControlID="ddGrupo"
                                                                   PromptText="• Seleccione •" ServiceMethod="GetGru2" ServicePath="ws.asmx"
                                                                   TargetControlID="ddSubgrupo">
                                            </asp:CascadingDropDown>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <h6>
                                            Descripción:
                                        </h6>
                                    </td>
                                    <td>
                                        <div class="form-group">
                                            <asp:DropDownList ID="ddDescripcion" runat="server" CssClass="txtdd"
                                                              Width="100%">
                                            </asp:DropDownList>
                                            <asp:CascadingDropDown ID="cddDescrip" runat="server" Category="gru3"
                                                                   Enabled="True" LoadingText="[Cargando Descripción...]"
                                                                   ParentControlID="ddSubgrupo" PromptText="• Seleccione •"
                                                                   ServiceMethod="GetGru3" ServicePath="ws.asmx"
                                                                   TargetControlID="ddDescripcion">
                                            </asp:CascadingDropDown>
                                            <br/>
                                            <asp:RequiredFieldValidator ID="rfvtipo1" runat="server"
                                                                        ControlToValidate="ddDescripcion" ErrorMessage="Seleccione Descripción" Text="<img src='../../Img/warning.png' /> Seleccione Descripción" Display="Dynamic" SetFocusOnError="true"
                                                                        ForeColor="#E91E63">
                                            </asp:RequiredFieldValidator>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ibgr1" EventName="Click"/>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </td>
    </tr>
</table>
<table cellpadding="0" cellspacing="0" class="style1">
<tr>
    <td width="40%">&nbsp;</td>
    <td width="40%">&nbsp;</td>
    <td>&nbsp;</td>
</tr>
<tr>
    <td class="ba3" height="30">
        <table cellpadding="0" cellspacing="0" class="style1">
            <tr>
                <td width="210">&nbsp;</td>
                <td>
                    <asp:ImageButton ID="ibgr2" runat="server" CausesValidation="False"
                                     CssClass="relo" Height="18px" ImageUrl="~/Img/rl1.png" TabIndex="99"
                                     ToolTip="Actualizar Clasificación" Width="21px"/>
                    &nbsp;
                    <asp:CheckBox ID="chk0" runat="server" CssClass="mr" TabIndex="99"
                                  ToolTip="Mantener Ubi. Geográfica"/>
                </td>
            </tr>
        </table>
    </td>
    <td class="ba4">
        <table cellpadding="0" cellspacing="0" class="style1">
            <tr>
                <td width="194">&nbsp;</td>
                <td>
                    <asp:ImageButton ID="ibgr3" runat="server" CausesValidation="False"
                                     CssClass="relo" Height="18px" ImageUrl="~/Img/rl1.png" TabIndex="99"
                                     ToolTip="Actualizar Clasificación" Width="21px"/>
                    <asp:CheckBox ID="chk1" runat="server" CssClass="mr" TabIndex="99"
                                  ToolTip="Mantener Ubi. Orgánica"/>
                </td>
            </tr>
        </table>
    </td>
    <td class="ba5">
        <table cellpadding="0" cellspacing="0" class="style1">
            <tr>
                <td width="102">&nbsp;</td>
                <td>
                    <asp:CheckBox ID="chk2" runat="server" CssClass="mr" TabIndex="99"
                                  ToolTip="Mantener Ubi. Orgánica"/>
                </td>
            </tr>
        </table>
    </td>
</tr>
<tr>
<td class="aatl" width="40%">
    <div class="divv">
        <asp:UpdatePanel ID="upgeo" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table cellpadding="2" cellspacing="0" class="style1">
                    <tr>
                        <td>
                            <h6>Ub. Geográfica 1:</h6>
                        </td>
                        <td>
                            <div class="form-group">

                                <asp:DropDownList ID="ddUge1" runat="server" CssClass="txtdd" Width="80%">
                                </asp:DropDownList>
                                <asp:CascadingDropDown ID="cddgeo1" runat="server" Category="uge1"
                                                       Enabled="True" LoadingText="[Cargando Geo1...]" PromptText="• Seleccione •"
                                                       ServiceMethod="GetUge1" ServicePath="ws.asmx" TargetControlID="ddUge1">
                                </asp:CascadingDropDown>
                            </div>
                        </td>
                        <td width="15">&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <h6>Ub. Geográfica 2:</h6>
                        </td>
                        <td>
                            <div class="form-group">
                                <asp:DropDownList ID="ddUge2" runat="server" CssClass="txtdd" Width="80%" OnSelectedIndexChanged="ddUge2_OnSelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:CascadingDropDown ID="cddgeo2" runat="server" Category="uge2"
                                                       Enabled="True" LoadingText="[Cargando Geo2...]" ParentControlID="ddUge1"
                                                       PromptText="• Seleccione •" ServiceMethod="GetUge2" ServicePath="ws.asmx"
                                                       TargetControlID="ddUge2">
                                </asp:CascadingDropDown>
                            </div>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <h6>Ub. Geográfica 3:</h6>
                        </td>
                        <td>
                            <div class="form-group">
                                <asp:DropDownList ID="ddUge3" runat="server" CssClass="txtdd" Width="80%">
                                </asp:DropDownList>
                                <asp:CascadingDropDown ID="cddgeo3" runat="server" Category="uge3"
                                                       Enabled="True" LoadingText="[Cargando Geo3...]" ParentControlID="ddUge2"
                                                       PromptText="• Seleccione •" ServiceMethod="GetUge3" ServicePath="ws.asmx"
                                                       TargetControlID="ddUge3">
                                </asp:CascadingDropDown>
                            </div>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <h6>Piso/Nivel:</h6>
                        </td>
                        <td>
                            <div class="form-group">
                                <asp:DropDownList ID="ddPiso" runat="server" CssClass="txtdd" Width="175px">
                                </asp:DropDownList>
                                <asp:CascadingDropDown ID="cddpiso" runat="server" Category="pis_id"
                                                       Enabled="True" LoadingText="[Cargando Piso...]" ParentControlID="ddUge3"
                                                       PromptText="• Seleccione •" ServiceMethod="GetUge4" ServicePath="ws.asmx"
                                                       TargetControlID="ddPiso">
                                </asp:CascadingDropDown>
                                <br/>
                                <asp:RequiredFieldValidator ID="rfvtipo2" runat="server"
                                                            ControlToValidate="ddPiso" ErrorMessage="Seleccione Piso/Nivel" Text="<img src='../../Img/warning.png' /> Seleccione Piso/Nivel"
                                                            ForeColor="#E91E63" Display="Dynamic" SetFocusOnError="true">
                                </asp:RequiredFieldValidator>
                            </div>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ibgr2" EventName="Click"/>
            </Triggers>
        </asp:UpdatePanel>
    </div>
</td>
<td class="aatl" width="40%">
    <div class="divv">
        <asp:UpdatePanel ID="upuor" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="False">
            <ContentTemplate>
                <table cellpadding="2" cellspacing="0" class="style1">
                    <tr>
                        <td width="98">
                            <h6>Centro de Costo:</h6>
                        </td>
                        <td>
                            <div class="form-group">
                                <asp:DropDownList ID="ddCcosto" runat="server" CssClass="txtdd" Width="100%">
                                </asp:DropDownList>
                                <asp:CascadingDropDown ID="cddccosto" runat="server" Category="cco"
                                                       Enabled="True" LoadingText="[Cargando Centro de Costo...]"
                                                       PromptText="• Seleccione •" ServicePath="ws.asmx"
                                                       TargetControlID="ddCcosto">
                                </asp:CascadingDropDown>
                            </div>
                        </td>
                        <td width="15">&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <h6>Ub. Orgánica 1:</h6>
                        </td>
                        <td>
                            <div class="form-group">
                                <asp:DropDownList ID="ddUor1" runat="server" CssClass="txtdd" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddUor1_OnSelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:CascadingDropDown ID="cdduor1" runat="server" Category="uor1"
                                                       Enabled="True" LoadingText="[Cargando Dep1...]"
                                                       PromptText="• Seleccione •" ServicePath="ws.asmx"
                                                       TargetControlID="ddUor1">
                                </asp:CascadingDropDown>
                            </div>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <h6>Ub. Orgánica 2:</h6>
                        </td>
                        <td>
                            <div class="form-group">
                                <asp:DropDownList ID="ddUor2" runat="server" CssClass="txtdd" Width="100%">
                                </asp:DropDownList>
                                <asp:CascadingDropDown ID="cdduor2" runat="server" Category="uor2"
                                                       Enabled="True" LoadingText="[Cargando Dep2...]" ParentControlID="ddUor1"
                                                       PromptText="• Seleccione •" ServiceMethod="GetUor2" ServicePath="ws.asmx"
                                                       TargetControlID="ddUor2">
                                </asp:CascadingDropDown>
                                <asp:RequiredFieldValidator ID="rfvtipo4" runat="server"
                                                            ControlToValidate="ddUor2" ErrorMessage="Seleccione Ubicación Orgánica 2" Text="<img src='../../Img/warning.png' /> Seleccione Ubicación Orgánica 2"
                                                            ForeColor="#E91E63" Display="Dynamic" SetFocusOnError="true">
                                </asp:RequiredFieldValidator>
                            </div>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <asp:UpdatePanel ID="upuor3" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="False">
                            <ContentTemplate>
                                <td>
                                    <h6>Custodio:</h6>
                                </td>
                                <td>
                                    <div class="form-group">
                                        <asp:DropDownList ID="ddCustodio" runat="server" CssClass="txtdd" Width="100%" OnSelectedIndexChanged="ddCustodio_Change" AutoPostBack="True">
                                        </asp:DropDownList>
                                        <asp:CascadingDropDown ID="cddcus" runat="server" Category="cus" ContextKey=""
                                                               Enabled="True" LoadingText="[Cargando Custodios...]"
                                                               PromptText="• Seleccione •" ServicePath="ws.asmx"
                                                               TargetControlID="ddCustodio" ParentControlID="ddUor1"
                                                               ServiceMethod="GetCusUor1">
                                        </asp:CascadingDropDown>
                                        <asp:RequiredFieldValidator ID="rfvtipo3" runat="server"
                                                                    ControlToValidate="ddCustodio" ErrorMessage="Seleccione Custodio" Text="<img src='../../Img/warning.png' /> Seleccione Custodio"
                                                                    ForeColor="#E91E63" Display="Dynamic" SetFocusOnError="true">
                                        </asp:RequiredFieldValidator>
                                        <asp:UpdatePanel ID="upcedula" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:Label ID="txtCedulaCustodio"
                                                           Text="Cedula:"
                                                           AssociatedControlID="ddCustodio"
                                                           runat="server">
                                                </asp:Label>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ibgr3" EventName="Click"/>
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </td>
                                <td>&nbsp;</td>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ibgr3" EventName="Click"/>
                            </Triggers>
                        </asp:UpdatePanel>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ibgr3" EventName="Click"/>
            </Triggers>
        </asp:UpdatePanel>
    </div>
</td>
<td class="aatl">
    <div class="divv">
        <asp:UpdatePanel ID="upestado" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table cellpadding="2" cellspacing="0" class="style1">
                    <tr>
                        <td width="90">
                            <h6>Estado:</h6>
                        </td>
                        <td>
                            <div class="form-group">
                                <asp:DropDownList ID="ddEstado" runat="server" CssClass="txtdd" Width="110px">
                                </asp:DropDownList>
                                <asp:CascadingDropDown ID="cddest1" runat="server" Category="est1"
                                                       ContextKey="1" Enabled="True" LoadingText="[Cargando Estado 1...]"
                                                       PromptText="• Seleccione •" ServiceMethod="GetEstado" ServicePath="ws.asmx"
                                                       TargetControlID="ddEstado">
                                </asp:CascadingDropDown>
                                <br/>
                                <asp:RequiredFieldValidator ID="rfvtipo5" runat="server"
                                                            ControlToValidate="ddEstado" ErrorMessage="Seleccione Estado" Display="Dynamic" SetFocusOnError="true"
                                                            ForeColor="#E91E63" Text="<img src='../../Img/warning.png' /> Seleccione Estado">
                                </asp:RequiredFieldValidator>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <h6>Fase:<h6>
                        </td>
                        <td>
                            <div class="form-group">
                                <asp:DropDownList ID="ddFase" runat="server" CssClass="txtdd" Width="110px">
                                </asp:DropDownList>
                                <asp:CascadingDropDown ID="cddest2" runat="server" Category="est2"
                                                       ContextKey="2" Enabled="True" LoadingText="[Cargando Estado 2...]"
                                                       PromptText="• Seleccione •" ServiceMethod="GetEstado2" ServicePath="ws.asmx"
                                                       TargetControlID="ddFase">
                                </asp:CascadingDropDown>
                                <br/>
                                <asp:RequiredFieldValidator ID="rfvtipo6" runat="server"
                                                            ControlToValidate="ddFase" ErrorMessage="Seleccione Fase" ForeColor="#E91E63" Display="Dynamic" SetFocusOnError="true" Text="<img src='../../Img/warning.png' /> Seleccione Fase">
                                </asp:RequiredFieldValidator>
                            </div>
                        </td>
                    </tr>
                </table>
                <table cellpadding="2" cellspacing="0" class="style1">
                    <tr>
                        <td width="90">
                            <h6>Transferencia:</h6>
                        </td>
                        <td>
                            <div class="form-group">
                                <asp:DropDownList ID="ddTrasnfer" runat="server" CssClass="txtdd" Width="110px">
                                </asp:DropDownList>
                                <asp:CascadingDropDown ID="cddest3" runat="server" Category="est3"
                                                       ContextKey="3" Enabled="True" LoadingText="[Cargando Estado 3...]"
                                                       PromptText="• Seleccione •" ServiceMethod="GetEstado" ServicePath="ws.asmx"
                                                       TargetControlID="ddTrasnfer">
                                </asp:CascadingDropDown>
                                <br/>
                                <asp:RequiredFieldValidator ID="rfvtipo25" runat="server" Display="Dynamic" SetFocusOnError="true"
                                                            ControlToValidate="ddTrasnfer" ErrorMessage="Seleccione Transferencia" Text="<img src='../../Img/warning.png' /> Seleccione Transferencia"
                                                            ForeColor="#E91E63">
                                </asp:RequiredFieldValidator>
                            </div>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</td>
</tr>
</table>
<table cellpadding="0" cellspacing="0" class="style1">
<tr>
    <td>&nbsp;</td>
    <td width="285">&nbsp;</td>
    <td width="300">&nbsp;</td>
</tr>
<tr>
    <td class="ba6" height="30">
        <table cellpadding="0" cellspacing="0" class="style1">
            <tr>
                <td width="168">&nbsp;</td>
                <td>
                    <asp:ImageButton ID="ibgr4" runat="server" CausesValidation="False"
                                     CssClass="relo" Height="18px" ImageUrl="~/Img/rl1.png" TabIndex="99"
                                     ToolTip="Actualizar Clasificación" Width="21px"/>
                    <asp:CheckBox ID="chk3" runat="server" CssClass="mr" TabIndex="99"
                                  ToolTip="Mantener Características"/>
                </td>
            </tr>
        </table>
    </td>
    <td class="ba7">
        <table cellpadding="0" cellspacing="0" class="style1">
            <tr>
                <td width="180">&nbsp;</td>
                <td>
                    <asp:CheckBox ID="chk4" runat="server" CssClass="mr" TabIndex="99"
                                  ToolTip="Mantener Características"/>
                </td>
            </tr>
        </table>
    </td>
    <td class="ba8">
        <table cellpadding="0" cellspacing="0" class="style1">
            <tr>
                <td width="118">&nbsp;</td>
                <td>
                    <asp:CheckBox ID="chk5" runat="server" CssClass="mr" TabIndex="99"
                                  ToolTip="Mantener Observaciones"/>
                </td>
            </tr>
        </table>
    </td>
</tr>
<tr>
<td class="aatl" style="width: 40%">
    <div class="divv">
        <asp:UpdatePanel ID="upmar" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table cellpadding="2" cellspacing="0" class="style1">
                    <tr>
                        <td width="82">
                            <h6>Marca:</h6>
                        </td>
                        <td>
                            <div class="form-group">
                                <asp:DropDownList ID="ddMarca" runat="server" CssClass="txtdd" Width="95%">
                                </asp:DropDownList>
                                <asp:CascadingDropDown ID="cddmarca" runat="server" Category="marca"
                                                       Enabled="True" LoadingText="[Cargando Marca...]" PromptText="• Seleccione •"
                                                       ServiceMethod="GetMarca" ServicePath="ws.asmx" TargetControlID="ddMarca">
                                </asp:CascadingDropDown>
                            </div>
                        </td>
                        <td width="15">&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <h6>Modelo:</h6>
                        </td>
                        <td>
                            <div class="form-group">
                                <asp:DropDownList ID="ddModelo" runat="server" CssClass="txtdd" Width="95%">
                                </asp:DropDownList>
                                <asp:CascadingDropDown ID="cddModelo" runat="server" Category="modelo"
                                                       Enabled="True" LoadingText="[Cargando Modelo...]" ParentControlID="ddMarca"
                                                       PromptText="• Seleccione •" ServiceMethod="GetModelo" ServicePath="ws.asmx"
                                                       TargetControlID="ddModelo">
                                </asp:CascadingDropDown>
                                <br/>
                                <asp:RequiredFieldValidator ID="rfvtipo8" runat="server" Display="Static" SetFocusOnError="true"
                                                            ControlToValidate="ddModelo" ErrorMessage="Seleccione Modelo" ForeColor="#E91E63" Text="<img src='../../Img/warning.png' /> Seleccione Modelo">
                                </asp:RequiredFieldValidator>
                            </div>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <h6>Serie:</h6>
                        </td>
                        <td>
                            <telerik:RadTextBox ID="txtserie" runat="server" MaxLength="150" Width="250px">
                                <PasswordStrengthSettings CalculationWeightings="50;15;15;20"
                                                          IndicatorElementBaseStyle="riStrengthBar" IndicatorElementID=""
                                                          MinimumLowerCaseCharacters="2" MinimumNumericCharacters="2"
                                                          MinimumSymbolCharacters="2" MinimumUpperCaseCharacters="2"
                                                          OnClientPasswordStrengthCalculating="" PreferredPasswordLength="10"
                                                          RequiresUpperAndLowerCaseCharacters="True" ShowIndicator="False"
                                                          TextStrengthDescriptions="Very Weak;Weak;Medium;Strong;Very Strong"
                                                          TextStrengthDescriptionStyles="riStrengthBarL0;riStrengthBarL1;riStrengthBarL2;riStrengthBarL3;riStrengthBarL4;riStrengthBarL5;"/>
                                <EmptyMessageStyle Font-Italic="True"/>
                            </telerik:RadTextBox>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <h6>Color:</h6>
                        </td>
                        <td>
                            <div class="form-group">
                                <asp:DropDownList ID="ddColor" runat="server" CssClass="txtdd" Width="80%">
                                </asp:DropDownList>
                                <asp:CascadingDropDown ID="cddcolor" runat="server" Category="color"
                                                       Enabled="True" LoadingText="[Cargando Color...]" PromptText="• Seleccione •"
                                                       ServiceMethod="GetColor" ServicePath="ws.asmx" TargetControlID="ddColor">
                                </asp:CascadingDropDown>
                            </div>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <h6>Año Fab.:</h6>
                        </td>
                        <td>
                            <div class="form-group">
                                <asp:DropDownList ID="ddAnio" runat="server" CssClass="txtdd" Width="80%">
                                </asp:DropDownList>
                                <asp:CascadingDropDown ID="cddAnio" runat="server" Category="anio"
                                                       Enabled="True" LoadingText="[Cargando Año...]" PromptText="• Seleccione •"
                                                       ServiceMethod="GetAnio" ServicePath="ws.asmx" TargetControlID="ddAnio">
                                </asp:CascadingDropDown>
                                <br/>
                                <asp:RequiredFieldValidator ID="rfvtipo31" runat="server"
                                                            ControlToValidate="ddAnio" ErrorMessage="Seleccione Año Fab." ForeColor="#E91E63" Display="Dynamic" SetFocusOnError="true" Text="<img src='../../Img/warning.png' /> Seleccione Año Fab.">
                                </asp:RequiredFieldValidator>
                            </div>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <h6>Estructura:</h6>
                        </td>
                        <td>
                            <div class="form-group">
                                <asp:DropDownList ID="ddEstructura" runat="server" CssClass="txtdd" Width="80%">
                                </asp:DropDownList>
                                <asp:CascadingDropDown ID="cddestruc1" runat="server" Category="eco1"
                                                       Enabled="True" LoadingText="[Cargando Estructura 1...]"
                                                       PromptText="• Seleccione •" ServiceMethod="GetEstruc1" ServicePath="ws.asmx"
                                                       TargetControlID="ddEstructura">
                                </asp:CascadingDropDown>
                            </div>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <h6>Componente:</h6>
                        </td>
                        <td>
                            <div class="form-group">
                                <asp:DropDownList ID="ddComponente" runat="server" CssClass="txtdd" Width="80%">
                                </asp:DropDownList>
                                <asp:CascadingDropDown ID="cddcompo1" runat="server" Category="comp1"
                                                       Enabled="True" LoadingText="[Cargando Componente 1...]"
                                                       ParentControlID="ddEstructura" PromptText="• Seleccione •"
                                                       ServiceMethod="GetEstruc2" ServicePath="ws.asmx" TargetControlID="ddComponente">
                                </asp:CascadingDropDown>
                            </div>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <h6>Proveedor:</h6>
                        </td>
                        <td>
                            <div class="form-group">
                                <asp:DropDownList ID="ddProveedor" runat="server" CssClass="txtdd" Width="95%">
                                </asp:DropDownList>
                                <asp:CascadingDropDown ID="cddProveedor" runat="server" Category="provee"
                                                       Enabled="True" LoadingText="[Cargando Proveedor...]"
                                                       PromptText="• Seleccione •" ServiceMethod="GetPro" ServicePath="ws.asmx"
                                                       TargetControlID="ddProveedor">
                                </asp:CascadingDropDown>
                                <br/>
                                <asp:RequiredFieldValidator ID="rfvtipo23" runat="server"
                                                            ControlToValidate="ddProveedor" ErrorMessage="Seleccione Proveedor"
                                                            ForeColor="#E91E63" Display="Dynamic" SetFocusOnError="true" Text="<img src='../../Img/warning.png' /> Seleccione Proveedor">
                                </asp:RequiredFieldValidator>
                            </div>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ibgr4" EventName="Click"/>
            </Triggers>
        </asp:UpdatePanel>
    </div>
</td>
<td class="aatl" style="width: 30%">
    <div class="divv">
        <asp:Panel ID="panDetContable" runat="server">
            <asp:UpdatePanel ID="upcontable" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <table cellpadding="2" cellspacing="0">
                        <tr>
                            <td width="115">
                                <h6>Ingreso:</h6>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:DropDownList ID="ddingreso" runat="server" CssClass="txtdd" Width="120px">
                                        <asp:ListItem Selected="True">Compra</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </td>
                            <td width="15">&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <h6>Documento No.:</h6>
                            </td>
                            <td>
                                <telerik:RadTextBox ID="txtnumfact" CssClass="form-control" runat="server" EmptyMessage="Ingrese"
                                                    MaxLength="16" Width="120px">
                                    <ClientEvents OnKeyPress="KeyPress"/>
                                    <EmptyMessageStyle Font-Italic="True"/>
                                </telerik:RadTextBox>
                                <br/>
                                <asp:RequiredFieldValidator ID="rfvtipo10" runat="server" Font-Size="X-Small"
                                                            ControlToValidate="txtnumfact" ErrorMessage="Ingrese Documento de Compra" ForeColor="#E91E63" Display="Dynamic" SetFocusOnError="true" Text="<img src='../../Img/warning.png' /> Ingrese Doc. Compra">
                                </asp:RequiredFieldValidator>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <h6>Fecha de Compra:</h6>
                            </td>
                            <td>
                                <telerik:RadDatePicker ID="datefechacompra" runat="server"
                                                       EnableTyping="False" MaxDate="2099-01-01" MinDate="1940-01-01" Width="120px"
                                                       ZIndex="0">
                                    <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                              ViewSelectorText="x">
                                    </Calendar>
                                    <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy"
                                               ReadOnly="True">
                                    </DateInput>
                                    <DatePopupButton HoverImageUrl="" ImageUrl=""/>
                                </telerik:RadDatePicker>
                                <br/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                            ControlToValidate="datefechacompra" ErrorMessage="Ingrese Fecha de Compra" Font-Size="X-Small"
                                                            ForeColor="#E91E63" Display="Dynamic" SetFocusOnError="true" Text="<img src='../../Img/warning.png' /> Ingrese Fecha Compra">
                                </asp:RequiredFieldValidator>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <h6>Valor de Compra:</h6>
                            </td>
                            <td>
                                <telerik:RadNumericTextBox ID="txtvalorcompra" runat="server" Culture="en-US" AutoPostBack="True"
                                                           EmptyMessage="Ingrese Valor" MaxValue="999999999" MinValue="0.01"
                                                           Type="Currency" Width="120px" OnTextChanged="txtvalorcompra_OnTextChanged">
                                    <NumberFormat GroupSeparator=""/>
                                    <EmptyMessageStyle Font-Italic="True"/>
                                </telerik:RadNumericTextBox>
                                <br/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Font-Size="X-Small"
                                                            ControlToValidate="txtvalorcompra" ErrorMessage="Ingrese Valor de Compra"
                                                            ForeColor="#E91E63" Display="Dynamic" SetFocusOnError="true" Text="<img src='../../Img/warning.png' /> Ingrese Valor Compra">
                                </asp:RequiredFieldValidator>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    <asp:Panel ID="panNiif" runat="server">
                        <table cellpadding="2" cellspacing="0">
                            <tr>
                                <td width="115">
                                    <h6>Vida Util:</h6>
                                </td>
                                <td>
                                    <asp:Label ID="lblvidautil" runat="server"></asp:Label>
                                    &nbsp;Meses
                                </td>
                                <td width="15">&nbsp;</td>
                            </tr>
                            <tr style="display: none">
                                <td>
                                    <h6>Vida Util NIIF:</h6>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txtvidautilniif" runat="server" EmptyMessage="Ingrese"
                                                        MaxLength="4" Width="80px" Enabled="False">
                                        <ClientEvents OnKeyPress="KeyPress"/>
                                        <EmptyMessageStyle Font-Italic="True"/>
                                    </telerik:RadTextBox>&nbsp;Meses
                                    <br/>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                                                ControlToValidate="txtvidautilniif" ErrorMessage="Ingrese Vida Util NIIF" Font-Size="X-Small"
                                                                ForeColor="#E91E63" Display="Dynamic" SetFocusOnError="true" Text="<img src='../../Img/warning.png' /> Ingrese Vida Util NIIF">
                                    </asp:RequiredFieldValidator>--%>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr style="display: none">
                                <td>
                                    <h6>Valor Res. NIIF:</h6>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="txtvalorresniif" runat="server" Culture="en-US"
                                                               EmptyMessage="Ingrese Valor" MaxValue="999999999" MinValue="0" Type="Currency"
                                                               Width="120px" Enabled="False">
                                        <EmptyMessageStyle Font-Italic="True"/>
                                    </telerik:RadNumericTextBox>
                                    <br/>
                                    <%--<asp:RequiredFieldValidator ID="rfvtipo16" runat="server"
                                                                ControlToValidate="txtvalorresniif" ErrorMessage="Ingrese Valor Residual NIIF"
                                                                Font-Size="X-Small"
                                                                ForeColor="#E91E63" Display="Dynamic" SetFocusOnError="true" Text="<img src='../../Img/warning.png' /> Ingrese Valor Residual NIIF">
                                    </asp:RequiredFieldValidator>--%>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <h6>Inicio de Operación:</h6>
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="dateInicioNiif" runat="server" EnableTyping="False"
                                                           MaxDate="2050-01-01" MinDate="" Width="120px" ZIndex="0">
                                        <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                                  ViewSelectorText="x">
                                        </Calendar>
                                        <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy"
                                                   ReadOnly="True">
                                        </DateInput>
                                        <DatePopupButton HoverImageUrl="" ImageUrl=""/>
                                    </telerik:RadDatePicker>
                                    <br/>
                                    <%--<asp:RequiredFieldValidator ID="rfvtipo32" runat="server"
                                                                ControlToValidate="dateInicioNiif"
                                                                ErrorMessage="Ingrese Fecha de Inicio de Operación" Font-Size="X-Small"
                                                                ForeColor="#E91E63" Display="Dynamic" SetFocusOnError="true" Text="<img src='../../Img/warning.png' /> Ingrese Fecha de Inicio de Operación">
                                    </asp:RequiredFieldValidator>--%>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
    </div>
</td>
<td class="aatl" style="width: 30%">
<div class="divv">
    <table cellpadding="2" cellspacing="0" width="100%">
        <tr>
            <td width="50">
                <h6>Garantía:</h6>
            </td>
            <td width="40">
                <div class="form-group">
                    <asp:DropDownList ID="ddgarantia" runat="server" AutoPostBack="True" Width="50px"
                                      CssClass="txtdd" OnSelectedIndexChanged="ddgarantia_SelectedIndexChanged">
                        <asp:ListItem>SI</asp:ListItem>
                        <asp:ListItem Selected="True">NO</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="pangar" runat="server" Visible="False" Width="100%">
                            <table cellpadding="2" cellspacing="0" class="style1" width="100%">
                                <tr>
                                    <td width="50">
                                        <h6>&nbsp;Vence:</h6>
                                    </td>
                                    <td>
                                        <telerik:RadDatePicker ID="dategarantiavence" runat="server"
                                                               EnableTyping="False" MaxDate="2050-01-01" MinDate="1900-01-01" Width="120px">
                                            <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                                      ViewSelectorText="x">
                                            </Calendar>
                                            <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy"
                                                       ReadOnly="True">
                                            </DateInput>
                                            <DatePopupButton HoverImageUrl="" ImageUrl=""/>
                                        </telerik:RadDatePicker>
                                        <br/>
                                        <asp:RequiredFieldValidator ID="rfvtipo17" runat="server" ControlToValidate="dategarantiavence" ErrorMessage="Seleccione Fecha Vencimiento de Garantía" ForeColor="#E91E63" Display="Dynamic" SetFocusOnError="true" Text="<img src='../../Img/warning.png' /> Seleccione Fecha Vencimiento de Garantía" Font-Size="X-Small"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddgarantia"
                                                  EventName="SelectedIndexChanged"/>
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <h6>Asegurado:</h6>
            </td>
            <td>
                <div class="form-group">
                    <asp:DropDownList ID="ddSeguro" runat="server" AutoPostBack="True" Width="50px"
                                      CssClass="txtdd" OnSelectedIndexChanged="ddSeguro_SelectedIndexChanged">
                        <asp:ListItem>SI</asp:ListItem>
                        <asp:ListItem Selected="True">NO</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </td>
            <td></td>
        </tr>
        <tr>
            <td class="auto-style1" colspan="3">
                <asp:UpdatePanel ID="UpTipoSeg" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="panAseg" runat="server" Visible="False">
                            <table cellpadding="2" cellspacing="0" width="80%">
                                <tr>
                                    <td class="auto-style12">
                                        <h6>Compañia de Seguros:</h6>
                                    </td>
                                    <td>
                                        <div class="form-group">
                                            <asp:DropDownList ID="ddRamo" runat="server" Width="100%"
                                                              CssClass="txtdd">
                                            </asp:DropDownList>
                                            <asp:CascadingDropDown ID="cddRamo" runat="server" Category="tseg"
                                                                   Enabled="True" LoadingText="[Cargando Seguro...]"
                                                                   PromptText="• Seleccione •" ServiceMethod="GetTipoSeg" ServicePath="ws.asmx"
                                                                   TargetControlID="ddRamo">
                                            </asp:CascadingDropDown>
                                            <br/>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddRamo" ErrorMessage="Compañia de Seguros" ForeColor="#E91E63" Display="Dynamic" SetFocusOnError="true" Text="<img src='../../Img/warning.png' /> Compañia de Seguros" Font-Size="X-Small"></asp:RequiredFieldValidator>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style12">Número de Póliza:</td>
                                    <td>
                                        <div class="form-group">
                                            <telerik:RadTextBox ID="txtNumPoliza" runat="server" Width="120px">
                                            </telerik:RadTextBox>
                                            <br/>
                                            <asp:RequiredFieldValidator ID="rfv_NumPoliza" runat="server"
                                                                        ControlToValidate="txtNumPoliza"
                                                                        ErrorMessage="Ingrese Número de Póliza" ForeColor="#E91E63" Display="Dynamic" SetFocusOnError="true" Text="<img src='../../Img/warning.png' /> Ingrese Número de Póliza" Font-Size="X-Small">
                                            </asp:RequiredFieldValidator>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style12">Fecha Emisión:</td>
                                    <td>
                                        <div class="form-group">
                                            <telerik:RadDatePicker ID="rdpFechaEmision" runat="server" EnableTyping="False" MaxDate="2099-01-01" MinDate="1940-01-01" Width="120px"
                                                                   ZIndex="0">
                                                <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                                          ViewSelectorText="x">
                                                </Calendar>
                                                <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy"
                                                           ReadOnly="True">
                                                </DateInput>
                                                <DatePopupButton HoverImageUrl="" ImageUrl=""/>
                                            </telerik:RadDatePicker>
                                            <br/>
                                            <asp:RequiredFieldValidator ID="rfv_FechaEmision" runat="server"
                                                                        ControlToValidate="rdpFechaEmision"
                                                                        ErrorMessage="Ingrese Fecha de Emisión" ForeColor="#E91E63" Display="Dynamic" SetFocusOnError="true" Text="<img src='../../Img/warning.png' /> Ingrese Fecha de Emisión" Font-Size="X-Small">
                                            </asp:RequiredFieldValidator>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style12">Fecha de Vencimiento:</td>
                                    <td>
                                        <div class="form-group">
                                            <telerik:RadDatePicker ID="rdpFechaVencimiento" runat="server" EnableTyping="False" MaxDate="2099-01-01" MinDate="1940-01-01" Width="120px"
                                                                   ZIndex="0">
                                                <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                                          ViewSelectorText="x">
                                                </Calendar>
                                                <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy"
                                                           ReadOnly="True">
                                                </DateInput>
                                                <DatePopupButton HoverImageUrl="" ImageUrl=""/>
                                            </telerik:RadDatePicker>
                                            <br/>
                                            <asp:RequiredFieldValidator ID="rfv_FechaVence" runat="server"
                                                                        ControlToValidate="rdpFechaVencimiento"
                                                                        ErrorMessage="Ingrese Fecha de Vencimiento" ForeColor="#E91E63" Display="Dynamic" SetFocusOnError="true" Text="<img src='../../Img/warning.png' /> Ingrese Fecha de Vencimiento" Font-Size="X-Small">
                                            </asp:RequiredFieldValidator>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style12">Valor Asegurado:</td>
                                    <td>
                                        <div class="form-group">
                                            <telerik:RadNumericTextBox ID="txtValorAsegurado" runat="server" Culture="en-US"
                                                                       EmptyMessage="Ingrese Valor" MaxValue="999999999" MinValue="0.01"
                                                                       Type="Currency" Width="120px">
                                                <NumberFormat GroupSeparator=""/>
                                                <EmptyMessageStyle Font-Italic="True"/>
                                            </telerik:RadNumericTextBox>
                                            <br/>
                                            <asp:RequiredFieldValidator ID="rfv_ValorAseg" runat="server"
                                                                        ControlToValidate="txtValorAsegurado"
                                                                        ErrorMessage="Ingrese Valor Asegurado" ForeColor="#E91E63" Display="Dynamic" SetFocusOnError="true" Text="<img src='../../Img/warning.png' /> Ingrese Valor Asegurado" Font-Size="X-Small">
                                            </asp:RequiredFieldValidator>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddSeguro"
                                                  EventName="SelectedIndexChanged"/>
                        <asp:AsyncPostBackTrigger ControlID="ddRamo" EventName="SelectedIndexChanged"/>
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</div>
<table cellpadding="0" cellspacing="0" width="250">
    <tr>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="ba11" height="30">&nbsp;</td>
    </tr>
</table>
<div class="divv">
    <table cellpadding="1" cellspacing="0">
        <tr>
            <td width="105">
                <h6>Fotografía 1:</h6>
            </td>
            <td>
                <telerik:RadAsyncUpload ID="rau1" runat="server" Culture="en-US" InputSize="15"
                                        MaxFileInputsCount="1" OnFileUploaded="rau1_FileUploaded"
                                        TargetFolder="~/Site/Activos/imgact" Width="200px" AllowedFileExtensions="jpg,jpeg,png,gif">
                    <Localization Cancel="Cancelar" Remove="Eliminar" Select="Buscar"/>

                </telerik:RadAsyncUpload>
            </td>
        </tr>
        <tr>
            <td>
                <h6>Fotografía 2:</h6>
            </td>
            <td>
                <telerik:RadAsyncUpload ID="rau2" runat="server" Culture="en-US" InputSize="15"
                                        MaxFileInputsCount="1" OnFileUploaded="rau2_FileUploaded"
                                        TargetFolder="~/Site/Activos/imgact" Width="200px" AllowedFileExtensions="jpg,jpeg,png,gif">
                    <Localization Cancel="Cancelar" Remove="Eliminar" Select="Buscar"/>
                </telerik:RadAsyncUpload>
            </td>
        </tr>
        <tr>
            <td>
                <h6>Factura:</h6>
            </td>
            <td>
                <telerik:RadAsyncUpload ID="rau3" runat="server" Culture="en-US" InputSize="15"
                                        MaxFileInputsCount="1" OnFileUploaded="rau3_FileUploaded"
                                        TargetFolder="~/Site/Activos/imgact" Width="200px">
                    <Localization Cancel="Cancelar" Remove="Eliminar" Select="Buscar"/>
                </telerik:RadAsyncUpload>
            </td>
        </tr>
        <tr>
            <td>
                <h6>Manual:</h6>
            </td>
            <td>
                <telerik:RadAsyncUpload ID="rau4" runat="server" Culture="en-US" InputSize="15"
                                        MaxFileInputsCount="1" OnFileUploaded="rau4_FileUploaded"
                                        TargetFolder="~/Site/Activos/imgact" Width="200px">
                    <Localization Cancel="Cancelar" Remove="Eliminar" Select="Buscar"/>
                </telerik:RadAsyncUpload>
            </td>
        </tr>
    </table>
</div>
</td>
</tr>
</table>
<table cellpadding="0" cellspacing="0" class="style1">
    <tr>
        <td height="16"></td>
    </tr>
    <tr>
        <td class="ba9" height="30">
            <table cellpadding="0" cellspacing="0" class="style1">
                <tr>
                    <td width="152">&nbsp;</td>
                    <td>
                        <asp:CheckBox ID="chk6" runat="server" CssClass="mr" TabIndex="99"
                                      ToolTip="Mantener Características"/>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="aatl">
            <div class="divv">
                <asp:UpdatePanel ID="upobs" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table cellpadding="2" cellspacing="0" class="style1">
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtObservaciones" runat="server" Rows="7" TextMode="MultiLine"
                                                 Width="99%" CssClass="txtdd" Font-Names="Arial" Font-Size="9pt">
                                    </asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </td>
    </tr>
</table>
<table cellpadding="0" cellspacing="0" class="style1">
<tr>
    <td>&nbsp;</td>
</tr>
<tr>
    <td class="ba10" height="30">
        <table cellpadding="0" cellspacing="0" class="style1">
            <tr>
                <td width="196">&nbsp;</td>
                <td>
                    <asp:ImageButton ID="ibgr7" runat="server" CausesValidation="False"
                                     CssClass="relo" Height="18px" ImageUrl="~/Img/rl1.png" OnClick="ibgr7_Click"
                                     TabIndex="99" ToolTip="Actualizar Clasificación" Width="21px"/>
                    <asp:CheckBox ID="chk7" runat="server" CssClass="mr" TabIndex="99"
                                  ToolTip="Mantener Info. Técnica"/>
                </td>
            </tr>
        </table>
    </td>
</tr>
<tr>
<td width="40%">
<asp:UpdatePanel ID="upcar" runat="server" UpdateMode="Conditional">
<ContentTemplate>
<table cellpadding="0" cellspacing="0" class="style1">
<tr>
<td class="aatl">
    <div class="divv">
        <table cellpadding="2" cellspacing="0" class="style1">
            <tr>
                <td width="26%">
                    <h6>
                        <asp:Label ID="l1" runat="server"></asp:Label>
                    </h6>
                </td>
                <td>
                    <telerik:RadTextBox ID="t1" runat="server" Width="100%" MaxLength="150">
                    </telerik:RadTextBox>
                </td>
                <td width="5">&nbsp;</td>
                <td width="50">
                    <asp:DropDownList ID="d1" runat="server" CssClass="txtdd">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <h6>
                        <asp:Label ID="l2" runat="server"></asp:Label>
                    </h6>
                </td>
                <td>
                    <telerik:RadTextBox ID="t2" runat="server" MaxLength="150" Width="100%">
                    </telerik:RadTextBox>
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:DropDownList ID="d2" runat="server" CssClass="txtdd">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <h6>
                        <asp:Label ID="l3" runat="server"></asp:Label>
                    </h6>
                </td>
                <td>
                    <telerik:RadTextBox ID="t3" runat="server" MaxLength="150" Width="100%">
                    </telerik:RadTextBox>
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:DropDownList ID="d3" runat="server" CssClass="txtdd">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <h6>
                        <asp:Label ID="l4" runat="server"></asp:Label>
                    </h6>
                </td>
                <td>
                    <telerik:RadTextBox ID="t4" runat="server" MaxLength="150" Width="100%">
                    </telerik:RadTextBox>
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:DropDownList ID="d4" runat="server" CssClass="txtdd">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <h6>
                        <asp:Label ID="l5" runat="server"></asp:Label>
                    </h6>
                </td>
                <td>
                    <telerik:RadTextBox ID="t5" runat="server" MaxLength="150" Width="100%">
                    </telerik:RadTextBox>
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:DropDownList ID="d5" runat="server" CssClass="txtdd">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <h6>
                        <asp:Label ID="l6" runat="server"></asp:Label>
                    </h6>
                </td>
                <td>
                    <telerik:RadTextBox ID="t6" runat="server" MaxLength="150" Width="100%">
                    </telerik:RadTextBox>
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:DropDownList ID="d6" runat="server" CssClass="txtdd">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <h6>
                        <asp:Label ID="l7" runat="server"></asp:Label>
                    </h6>
                </td>
                <td>
                    <telerik:RadTextBox ID="t7" runat="server" MaxLength="150" Width="100%">
                    </telerik:RadTextBox>
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:DropDownList ID="d7" runat="server" CssClass="txtdd">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <h6>
                        <asp:Label ID="l8" runat="server"></asp:Label>
                    </h6>
                </td>
                <td>
                    <telerik:RadTextBox ID="t8" runat="server" MaxLength="150" Width="100%">
                    </telerik:RadTextBox>
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:DropDownList ID="d8" runat="server" CssClass="txtdd">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    </div>
</td>
<td width="6">&nbsp;</td>
<td bgcolor="Silver" width="3">&nbsp;</td>
<td width="6">&nbsp;</td>
<td class="aatl">
    <div class="divv">
        <table cellpadding="2" cellspacing="0" class="style1">
            <tr>
                <td width="26%">
                    <h6>
                        <asp:Label ID="l9" runat="server"></asp:Label>
                    </h6>
                </td>
                <td>
                    <telerik:RadTextBox ID="t9" runat="server" MaxLength="150" Width="100%">
                    </telerik:RadTextBox>
                </td>
                <td width="5">&nbsp;</td>
                <td width="50">
                    <asp:DropDownList ID="d9" runat="server" CssClass="txtdd">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <h6>
                        <asp:Label ID="l10" runat="server"></asp:Label>
                    </h6>
                </td>
                <td>
                    <telerik:RadTextBox ID="t10" runat="server" MaxLength="150" Width="100%">
                    </telerik:RadTextBox>
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:DropDownList ID="d10" runat="server" CssClass="txtdd">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <h6>
                        <asp:Label ID="l11" runat="server"></asp:Label>
                    </h6>
                </td>
                <td>
                    <telerik:RadTextBox ID="t11" runat="server" MaxLength="150" Width="100%">
                    </telerik:RadTextBox>
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:DropDownList ID="d11" runat="server" CssClass="txtdd">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <h6>
                        <asp:Label ID="l12" runat="server"></asp:Label>
                    </h6>
                </td>
                <td>
                    <telerik:RadTextBox ID="t12" runat="server" MaxLength="150" Width="100%">
                    </telerik:RadTextBox>
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:DropDownList ID="d12" runat="server" CssClass="txtdd">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <h6>
                        <asp:Label ID="l13" runat="server"></asp:Label>
                    </h6>
                </td>
                <td>
                    <telerik:RadTextBox ID="t13" runat="server" MaxLength="150" Width="100%">
                    </telerik:RadTextBox>
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:DropDownList ID="d13" runat="server" CssClass="txtdd">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <h6>
                        <asp:Label ID="l14" runat="server"></asp:Label>
                    </h6>
                </td>
                <td>
                    <telerik:RadTextBox ID="t14" runat="server" MaxLength="150" Width="100%">
                    </telerik:RadTextBox>
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:DropDownList ID="d14" runat="server" CssClass="txtdd">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <h6>
                        <asp:Label ID="l15" runat="server"></asp:Label>
                    </h6>
                </td>
                <td>
                    <telerik:RadTextBox ID="t15" runat="server" MaxLength="150" Width="100%">
                    </telerik:RadTextBox>
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:DropDownList ID="d15" runat="server" CssClass="txtdd">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <h6>
                        <asp:Label ID="l16" runat="server"></asp:Label>
                    </h6>
                </td>
                <td>
                    <telerik:RadTextBox ID="t16" runat="server" MaxLength="150" Width="100%">
                    </telerik:RadTextBox>
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:DropDownList ID="d16" runat="server" CssClass="txtdd">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    </div>
</td>
</tr>
</table>
</ContentTemplate>
<Triggers>
    <asp:AsyncPostBackTrigger ControlID="ibgr7" EventName="Click"/>
</Triggers>
</asp:UpdatePanel>
</td>
</tr>
</table>
<table cellpadding="0" cellspacing="0" class="style1">
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
                            <td>Cuenta Transitoria</td>
                            <td>
                                <asp:Label runat="server" ID="lblCuentaTransitoria"></asp:Label>
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
                            <td>Cuenta Activo</td>
                            <td>
                                <asp:Label runat="server" ID="lblCuentaActivo"></asp:Label>
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
                        </tbody>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
</table>
</div>
</asp:Panel>
<br/>
<br/>

<asp:Panel ID="panCommand" runat="server" CssClass="aabrpan"
           Height="33px" Width="100%">
    <div class="panmar3">
        <asp:ImageButton ID="ibcancel" runat="server" CausesValidation="False"
                         Height="28px" ImageUrl="~/Img/c1.png" OnClick="ibcancel_Click" Width="102px"/>
        &nbsp;
        <asp:ImageButton ID="ibsave" runat="server" Height="28px"
                         ImageUrl="~/Img/s1.png" OnClick="ibsave_Click" Width="102px"/>
        &nbsp;
    </div>
</asp:Panel>
<asp:AlwaysVisibleControlExtender ID="avcePanCommand" runat="server"
                                  Enabled="True" TargetControlID="panCommand" VerticalSide="Bottom">
</asp:AlwaysVisibleControlExtender>
<asp:Label ID="Label2" runat="server"></asp:Label>
<asp:ModalPopupExtender ID="mp2" runat="server"
                        BackgroundCssClass="modalBackground" DynamicServicePath="" Enabled="True"
                        PopupControlID="pan2" TargetControlID="Label2" Y="250">
</asp:ModalPopupExtender>
<asp:Panel ID="pan2" runat="server" Height="142px"
           Width="430px" Style="display: none">
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
                                    <td class="auto-style6">
                                        <h6>Fecha de Recepción:</h6>
                                    </td>
                                    <td class="auto-style3">&nbsp;</td>
                                    <td>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtFechaRecep" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender1" runat="server"
                                                                  TargetControlID="txtFechaRecep" Format="yyyy/MM/dd" TodaysDateFormat="yyyy/MM/dd">
                                            </asp:CalendarExtender>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style6">
                                        <h6>Contrato Nº:</h6>
                                    </td>
                                    <td class="auto-style3">&nbsp;</td>
                                    <td>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtContrato" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style6">Solicitud de Compra Nº:</td>
                                    <td class="auto-style3">&nbsp;</td>
                                    <td>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtSolicitudCompra" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style6">O/C Catálogo Nº:</td>
                                    <td class="auto-style3">&nbsp;</td>
                                    <td>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtCatalogo" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style6">Certificación Presupuestaria Nº:</td>
                                    <td class="auto-style3">&nbsp;</td>
                                    <td>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtCertificacion" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style6">&nbsp;</td>
                                    <td class="auto-style3">&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style6">&nbsp;</td>
                                    <td class="auto-style3">&nbsp;</td>
                                    <td class="aatr">
                                        <asp:Button ID="btncerrar2" runat="server" CausesValidation="False" OnClick="btncerrar2_Click" Text="Cerrar" CssClass="btn btn-danger"/>
                                        &nbsp;<asp:Button ID="btnsave2" runat="server" Text="Imprimir" ValidationGroup="22" CssClass="btn btn-primary"/>
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
<uc2:messbox ID="messbox1" runat="server"/>
<asp:ValidationSummary ID="vs" runat="server" ShowMessageBox="True"
                       ShowSummary="false"/>
</asp:Content>
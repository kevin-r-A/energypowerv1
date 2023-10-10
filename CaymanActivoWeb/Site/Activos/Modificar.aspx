<%@ Page Title="" Language="C#" MasterPageFile="~/Site/Activos/cay.master" AutoEventWireup="true" CodeFile="Modificar.aspx.cs" Inherits="Site_Activos_Modificar" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="../../Ctrl/Wait/wait.ascx" TagName="wait" TagPrefix="uc1" %>
<%@ Register Src="../../Ctrl/Msg/messbox.ascx" TagName="messbox" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style2 {
            width: 90px;
        }

        .auto-style11 {
            width: 60px;
        }

        .auto-style17 {
            width: 134px;
        }

        .auto-style20 {
            width: 170px;
        }
        .auto-style21 {
            width: 152px;
        }
        .auto-style22 {
            width: 187px;
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
            window.open(url, " Reporte Ingreso Activo", "directories=no, location=no, menubar=no, scrollbars=yes, statusbar=no, tittlebar=no, width=300");
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
<asp:Panel ID="panbus0" runat="server" CssClass="panmar"
           GroupingText="Buscar Activo - Modificar">
    <table cellpadding="0" cellspacing="0" class="panmar2">
        <tr>
            <td class="aatl">
                <table cellspacing="0" class="style1">
                    <tr>
                        <td class="auto-style20">
                            <h4>
                                Código Barras:
                            </h4>
                        </td>
                        <td class="auto-style22">
                            <div class="form-group">
                                <telerik:RadTextBox ID="txtbuscb" runat="server" MaxLength="40" Width="150px" Height="25px" CssClass="form-control">
                                </telerik:RadTextBox>
                                <asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtbuscb"
                                    ErrorMessage="Ingrese Código Barras" ValidationGroup="1" ForeColor="#E91E63" Display="Dynamic" SetFocusOnError="true" Text="<img src='../../Img/warning.png' /> Ingrese Código Barras">
                                </asp:RequiredFieldValidator>
                            </div>
                        </td>
                        <td class="auto-style21">
                            <div class="form-group">
                                <div class="botonBuscar">
                                    <asp:ImageButton ID="ibbus1" runat="server" Height="25px"
                                                     ImageUrl="~/Img/buscarblue.png" OnClick="ibbus1_Click" TabIndex="99"
                                                     ToolTip="Buscar Código de Barras" ValidationGroup="1" Width="25px" ImageAlign="AbsMiddle"/>
                                    <span style="vertical-align: bottom">Buscar</span>
                                </div>

                            </div>
                        </td>
                        <td class="aacr">
                            <h4>
                                <asp:Label ID="lblmsg" runat="server" ForeColor="#009933"></asp:Label>
                            </h4>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style20">
                            <h4>
                                Código Secundario:
                            </h4>
                        </td>
                        <td class="auto-style22">
                            <div class="form-group">
                                <telerik:RadTextBox ID="txtbusid" runat="server" MaxLength="50" Width="150px" Height="25px" CssClass="form-control">
                                    <%--<clientevents onkeypress="KeyPress" />--%>
                                </telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Width="300px" runat="server" ControlToValidate="txtbusid" ErrorMessage="Ingrese Código Secundario" ValidationGroup="2" ForeColor="#E91E63" Display="Dynamic" SetFocusOnError="true" Text="<img src='../../Img/warning.png' /> Ingrese Código Secundario"></asp:RequiredFieldValidator>
                            </div>
                        </td>
                        <td valign="top" class="auto-style21">
                            <div class="form-group">
                                <div class="botonBuscar">
                                    <asp:ImageButton ID="ibbus3" runat="server" CssClass="relo" Height="25px"
                                                     ImageUrl="~/Img/buscarblue.png" OnClick="ibbus3_Click" TabIndex="99"
                                                     ToolTip="Buscar Cod Secundario" ValidationGroup="2" Width="25px" ImageAlign="Middle"/>
                                    <span style="vertical-align: bottom">Buscar</span>
                                </div>
                            </div>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style20">
                            <h4>
                                Código Serie:
                            </h4>
                        </td>
                        <td class="auto-style22">
                            <div class="form-group">
                                <telerik:RadTextBox ID="txtbussr" runat="server" MaxLength="50" Width="150px" Height="25px" CssClass="form-control">
                                    <%--<clientevents onkeypress="KeyPress" />--%>
                                </telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Width="300px" runat="server" ControlToValidate="txtbussr" ErrorMessage="Ingrese Serie" ValidationGroup="3" ForeColor="#E91E63" Display="Dynamic" SetFocusOnError="true" Text="<img src='../../Img/warning.png' /> Ingrese Serie"></asp:RequiredFieldValidator>
                            </div>
                        </td>
                        <td valign="top" class="auto-style21">
                            <div class="form-group">
                                <div class="botonBuscar">
                                    <asp:ImageButton ID="ibbus4" runat="server" CssClass="relo" Height="25px"
                                                     ImageUrl="~/Img/buscarblue.png" OnClick="ibbus4_Click" TabIndex="99"
                                                     ToolTip="Buscar Serie" ValidationGroup="3" Width="25px" ImageAlign="Middle"/>
                                    <span style="vertical-align: bottom">Buscar</span>
                                </div>
                            </div>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:Panel ID="panuevo" runat="server" CssClass="panmar"
           GroupingText="Información del Activo" Visible="False">
<div style="margin: 5px">
<table
    cellpadding="0" cellspacing="0" class="style1">
<tr>
    <td class="ba1" height="30"
        width="320">
        &#160;
    </td>
    <td class="ba2">
        <table cellpadding="0" cellspacing="0"
               class="style1">
            <tr>
                <td width="150">&#160;</td>
                <td>
                    <asp:ImageButton ID="ibgr1"
                                     runat="server" CausesValidation="False" CssClass="relo" Height="18px"
                                     ImageUrl="~/Img/rl1.png" TabIndex="99" ToolTip="Actualizar Clasificación"
                                     Width="21px"/>
                </td>
            </tr>
        </table>
    </td>
    <td rowspan="2" width="240">
        <table cellspacing="0">
            <tr>
                <td width="30">
                    <table cellspacing="0" class="style1">
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
<tr>
    <td
        class="aatl" width="280">
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
                    <table
                        cellpadding="2" cellspacing="0" width="310">
                        <tr>
                            <td width="120">
                                <h6>Tipo:</h6>
                            </td>
                            <td>
                                <h6>
                                    <asp:Label
                                        ID="lbltipoactivo" runat="server">
                                    </asp:Label>
                                </h6>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <h6>Código:</h6>
                            </td>
                            <td>
                                <asp:Label
                                    ID="lblcb" runat="server">
                                </asp:Label>
                            </td>
                        </tr>
                        <tr style="display: none">
                            <td>
                                <h6>
                                    Tipo Tag RFID:
                                    <asp:RequiredFieldValidator ID="rfvTipoTag" runat="server"
                                                                ControlToValidate="ddTipoTag" ErrorMessage="Ingrese Tipo de Tag"
                                                                ForeColor="Red">
                                        *
                                    </asp:RequiredFieldValidator>
                                </h6>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:DropDownList ID="ddTipoTag" runat="server" CssClass="txtdd">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem Selected="True">24 Bits</asp:ListItem>
                                        <asp:ListItem>32 Bits</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <h6>Código Barras Padre:</h6>
                            </td>
                            <td>
                                <div class="form-group">
                                    <telerik:RadTextBox
                                        ID="txtcbpadre" runat="server" MaxLength="20" Width="175px" Height="30px" CssClass="form-control">
                                        <ClientEvents OnKeyPress="KeyPress"/>
                                        <EmptyMessageStyle Font-Italic="True"/>
                                    </telerik:RadTextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <h6>Código Secundario:</h6>
                            </td>
                            <td>
                                <div class="form-group">
                                    <telerik:RadTextBox
                                        ID="txtcod1" runat="server" MaxLength="100" Width="175px" Height="30px" CssClass="form-control">
                                    </telerik:RadTextBox>
                                </div>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </td>
    <td class="aatl">
        <div class="divv">
            <asp:UpdatePanel ID="upgru" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <table
                        cellpadding="2" cellspacing="0" class="style1">
                        <tr>
                            <td class="style2">Id:</td>
                            <td>
                                <asp:Label
                                    ID="lblid" runat="server">
                                </asp:Label>
                            </td>

                            <td width="100">
                                <h6>Fecha Creación:</h6>
                            </td>
                            <td>
                                <asp:Label ID="lblFechacreacion" runat="server" ViewStateMode="Disabled"></asp:Label>
                                &nbsp;

                            </td>
                            <td>
                                <asp:ImageButton ID="ibpdf1" runat="server" Height="30px" Visible="False"
                                                 ImageUrl="~/Img/pdf1.png" OnClick="ibpdf1_Click" Width="112px"/>
                            </td>
                            <td width="10">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style2">Grupo/Cuenta:</td>
                            <td colspan="4">
                                <h5>
                                    <asp:Label ID="lblgru" runat="server"></asp:Label>
                                </h5>
                                <div class="form-group" style="display: none">
                                    <asp:DropDownList
                                        ID="ddGrupo" runat="server" CssClass="txtdd" Width="100%" Enabled="False">
                                    </asp:DropDownList>
                                    <asp:CascadingDropDown ID="cddgru1" runat="server"
                                                           BehaviorID="cddl" Category="gru1" Enabled="True"
                                                           LoadingText="[Cargando Grupo...]" PromptText="• Seleccione •"
                                                           ServiceMethod="GetGru1" ServicePath="ws.asmx" TargetControlID="ddGrupo">
                                    </asp:CascadingDropDown>
                                </div>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style2">Subgrupo:</td>
                            <td colspan="4">
                                <h5>
                                    <asp:Label ID="lblsgru" runat="server"></asp:Label>
                                </h5>
                                <div class="form-group" style="display: none">
                                    <asp:DropDownList
                                        ID="ddSubgrupo" runat="server" CssClass="txtdd" Width="100%">
                                    </asp:DropDownList>
                                    <asp:CascadingDropDown ID="cddgru2" runat="server"
                                                           Category="gru2" Enabled="True" LoadingText="[Cargando Subgrupo...]"
                                                           ParentControlID="ddGrupo" PromptText="• Seleccione •" ServiceMethod="GetGru2"
                                                           ServicePath="ws.asmx" TargetControlID="ddSubgrupo">
                                    </asp:CascadingDropDown>
                                </div>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style2">
                                Descripción:
                                <asp:RequiredFieldValidator
                                    ID="rfvtipo1" runat="server" ControlToValidate="ddDescripcion"
                                    ErrorMessage="Seleccione Descripción" ForeColor="Red">
                                    *
                                </asp:RequiredFieldValidator>
                            </td>
                            <td colspan="4">
                                <h5>
                                    <asp:Label ID="lbldesc" runat="server"></asp:Label>
                                </h5>
                                <div class="form-group" style="display: none">
                                    <asp:DropDownList
                                        ID="ddDescripcion" runat="server" CssClass="txtdd" Width="100%">
                                    </asp:DropDownList>
                                    <asp:CascadingDropDown ID="cddDescrip" runat="server"
                                                           Category="gru3" Enabled="True" LoadingText="[Cargando Descripción...]"
                                                           ParentControlID="ddSubgrupo" PromptText="• Seleccione •"
                                                           ServiceMethod="GetGru3" ServicePath="ws.asmx" TargetControlID="ddDescripcion">
                                    </asp:CascadingDropDown>
                                </div>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
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
    <td width="40%">&#160;</td>
    <td width="40%">&#160;</td>
    <td>&#160;</td>
</tr>
<tr>
    <td align="right"
        class="ba3" height="30">
        &#160;
    </td>
    <td align="right"
        class="ba4">
        &#160;
    </td>
    <td
        align="right" class="ba5">
        &#160;
    </td>
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
                            <h5>
                                <asp:Label ID="lbluge1" runat="server"></asp:Label>
                            </h5>
                            <div class="form-group" style="display: none">
                                <asp:DropDownList
                                    ID="ddUge1" runat="server" CssClass="txtdd" Width="100%" Enabled="False">
                                </asp:DropDownList>
                                <asp:CascadingDropDown ID="cddgeo1" runat="server" Category="uge1"
                                                       Enabled="True" LoadingText="[Cargando Geo1...]" PromptText="• Seleccione •"
                                                       ServiceMethod="GetUge1" ServicePath="ws.asmx" TargetControlID="ddUge1">
                                </asp:CascadingDropDown>
                            </div>
                        </td>
                        <td width="15">&#160;</td>
                    </tr>
                    <tr>
                        <td>Ub. Geográfica 2:</td>
                        <td>
                            <h5>
                                <asp:Label ID="lbluge2" runat="server"></asp:Label>
                            </h5>
                            <div class="form-group" style="display: none">
                                <asp:DropDownList ID="ddUge2"
                                                  runat="server" CssClass="txtdd" Width="100%">
                                </asp:DropDownList>
                                <asp:CascadingDropDown ID="cddgeo2" runat="server" Category="uge2"
                                                       Enabled="True" LoadingText="[Cargando Geo2...]" ParentControlID="ddUge1"
                                                       PromptText="• Seleccione •" ServiceMethod="GetUge2" ServicePath="ws.asmx"
                                                       TargetControlID="ddUge2">
                                </asp:CascadingDropDown>
                            </div>
                        </td>
                        <td>&#160;</td>
                    </tr>
                    <tr>

                        <td>Ub. Geográfica 3:</td>
                        <td>
                            <h5>
                                <asp:Label ID="lbluge3" runat="server"></asp:Label>
                            </h5>
                            <div class="form-group" style="display: none">
                                <asp:DropDownList ID="ddUge3"
                                                  runat="server" CssClass="txtdd" Width="100%">
                                </asp:DropDownList>
                                <asp:CascadingDropDown ID="cddgeo3" runat="server" Category="uge3"
                                                       Enabled="True" LoadingText="[Cargando Geo3...]" ParentControlID="ddUge2"
                                                       PromptText="• Seleccione •" ServiceMethod="GetUge3" ServicePath="ws.asmx"
                                                       TargetControlID="ddUge3">
                                </asp:CascadingDropDown>
                            </div>
                        </td>
                        <td>&#160;</td>
                    </tr>
                    <tr>
                        <td>
                            Piso/Nivel:
                            <asp:RequiredFieldValidator ID="rfvtipo2"
                                                        runat="server" ControlToValidate="ddPiso" ErrorMessage="Seleccione Piso/Nivel"
                                                        ForeColor="Red">
                                *
                            </asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <h5>
                                <asp:Label ID="lbluge4" runat="server"></asp:Label>
                            </h5>
                            <div class="form-group" style="display: none">
                                <asp:DropDownList ID="ddPiso" runat="server" CssClass="txtdd" Width="175px">
                                </asp:DropDownList>
                                <asp:CascadingDropDown ID="cddpiso" runat="server" Category="pis_id"
                                                       Enabled="True" LoadingText="[Cargando Piso...]" ParentControlID="ddUge3"
                                                       PromptText="• Seleccione •" ServiceMethod="GetUge4" ServicePath="ws.asmx"
                                                       TargetControlID="ddPiso">
                                </asp:CascadingDropDown>
                            </div>
                        </td>
                        <td>&#160;</td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</td>
<td class="aatl" width="40%">
    <div class="divv">
        <asp:UpdatePanel
            ID="upuor" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="False">
            <ContentTemplate>
                <table
                    cellpadding="2" cellspacing="0" class="style1">
                    <tr>
                        <td width="98">Centro de Costo:</td>
                        <td>
                            <h5>
                                <asp:Label ID="lblccosto" runat="server"></asp:Label>
                            </h5>
                            <div class="form-group" style="display: none">
                                <asp:DropDownList
                                    ID="ddCcosto" runat="server" CssClass="txtdd" Width="100%">
                                </asp:DropDownList>
                                <asp:CascadingDropDown ID="cddccosto" runat="server" Category="cco"
                                                       Enabled="True" LoadingText="[Cargando Centro de Costo...]"
                                                       PromptText="• Seleccione •" ServicePath="ws.asmx" TargetControlID="ddCcosto">
                                </asp:CascadingDropDown>
                            </div>
                        </td>
                        <td width="15">&#160;</td>
                    </tr>
                    <tr>
                        <td>Ub. Orgánica 1:</td>
                        <td>
                            <h5>
                                <asp:Label ID="lbluor1" runat="server"></asp:Label>
                            </h5>
                            <div class="form-group" style="display: none">
                                <asp:DropDownList ID="ddUor1"
                                                  runat="server" CssClass="txtdd" Width="100%">
                                </asp:DropDownList>
                                <asp:CascadingDropDown ID="cdduor1" runat="server" Category="uor1"
                                                       Enabled="True" LoadingText="[Cargando Dep1...]" PromptText="• Seleccione •"
                                                       ServicePath="ws.asmx" TargetControlID="ddUor1">
                                </asp:CascadingDropDown>
                            </div>
                        </td>
                        <td>&#160;</td>
                    </tr>
                    <tr>
                        <td>
                            Ub. Orgánica 2:
                            <asp:RequiredFieldValidator ID="rfvtipo4"
                                                        runat="server" ControlToValidate="ddUor2"
                                                        ErrorMessage="Seleccione Ubicación Orgánica 2" ForeColor="Red">
                                *
                            </asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <h5>
                                <asp:Label ID="lbluor2" runat="server"></asp:Label>
                            </h5>
                            <div class="form-group" style="display: none">
                                <asp:DropDownList ID="ddUor2" runat="server" CssClass="txtdd" Width="100%">
                                </asp:DropDownList>
                                <asp:CascadingDropDown ID="cdduor2" runat="server" Category="uor2"
                                                       Enabled="True" LoadingText="[Cargando Dep2...]" ParentControlID="ddUor1"
                                                       PromptText="• Seleccione •" ServiceMethod="GetUor2" ServicePath="ws.asmx"
                                                       TargetControlID="ddUor2">
                                </asp:CascadingDropDown>
                            </div>
                        </td>
                        <td>&#160;</td>
                    </tr>
                    <tr>
                        <asp:UpdatePanel ID="upuor3" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="False">
                            <ContentTemplate>
                                <td>
                                    Custodio:
                                    <asp:RequiredFieldValidator ID="rfvtipo3"
                                                                runat="server" ControlToValidate="ddCustodio"
                                                                ErrorMessage="Seleccione Custodio" ForeColor="Red">
                                        *
                                    </asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <div class="form-group">
                                        <asp:DropDownList ID="ddCustodio" runat="server" CssClass="txtdd" Width="100%" OnSelectedIndexChanged="ddCustodio_Change" AutoPostBack="True">
                                        </asp:DropDownList>
                                        <asp:CascadingDropDown ID="cddcus" runat="server" Category="cus" ContextKey=""
                                                               Enabled="True" LoadingText="[Cargando Custodios...]" ParentControlID="ddUor1"
                                                               PromptText="• Seleccione •" ServiceMethod="GetCusUor1" ServicePath="ws.asmx"
                                                               TargetControlID="ddCustodio">
                                        </asp:CascadingDropDown>
                                        <asp:UpdatePanel ID="upcedula" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:Label ID="txtCedulaCustodio"
                                                           Text="Cedula:"
                                                           AssociatedControlID="ddCustodio"
                                                           runat="server">
                                                </asp:Label>
                                            </ContentTemplate>

                                        </asp:UpdatePanel>
                                    </div>
                                </td>
                                <td>&#160;</td>
                            </ContentTemplate>

                        </asp:UpdatePanel>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</td>
<td class="aatl">
    <div class="divv">
        <asp:UpdatePanel
            ID="upestado" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table
                    cellpadding="2" cellspacing="0" class="style1">
                    <tr>
                        <td width="90">
                            Estado:
                            <asp:RequiredFieldValidator
                                ID="rfvtipo33" runat="server" ControlToValidate="ddEstado"
                                ErrorMessage="Seleccione Estado" ForeColor="Red">
                                *
                            </asp:RequiredFieldValidator>
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
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Fase:
                            <asp:RequiredFieldValidator
                                ID="rfvtipo34" runat="server" ControlToValidate="ddFase"
                                ErrorMessage="Seleccione Fase" ForeColor="Red">
                                *
                            </asp:RequiredFieldValidator>
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
                            </div>
                        </td>
                    </tr>
                </table>
                <table cellpadding="2" cellspacing="0" class="style1">
                    <tr>
                        <td width="90">
                            Transferencia:
                            <asp:RequiredFieldValidator ID="rfvtipo35" runat="server"
                                                        ControlToValidate="ddTrasnfer" ErrorMessage="Seleccione Transferencia"
                                                        ForeColor="Red">
                                *
                            </asp:RequiredFieldValidator>
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
<table cellpadding="0"
       cellspacing="0" class="style1">
<tr>
    <td>&nbsp;</td>
    <td width="285">&#160;</td>
    <td width="300">&#160;</td>
</tr>
<tr>
    <td
        class="ba6" height="30">
        <table cellpadding="0" cellspacing="0"
               class="style1">
            <tr>
                <td width="168">&#160;</td>
                <td>
                    <asp:ImageButton ID="ibgr4"
                                     runat="server" CausesValidation="False" CssClass="relo" Height="18px"
                                     ImageUrl="~/Img/rl1.png" TabIndex="99" ToolTip="Actualizar Clasificación"
                                     Width="21px"/>
                </td>
            </tr>
        </table>
    </td>
    <td align="right" class="ba7">&#160;</td>
    <td
        align="right" class="ba8">
    </td>
</tr>
<tr>
<td class="aatl" style="width: 40%">
    <div class="divv">
        <asp:UpdatePanel
            ID="upmar" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table
                    cellpadding="2" cellspacing="0" class="style1">
                    <tr>
                        <td width="82">Marca:</td>
                        <td>
                            <div class="form-group">
                                <asp:DropDownList
                                    ID="ddMarca" runat="server" CssClass="txtdd" Width="90%">
                                </asp:DropDownList>
                                <asp:CascadingDropDown ID="cddmarca" runat="server"
                                                       Category="marca" Enabled="True" LoadingText="[Cargando Marca...]"
                                                       PromptText="• Seleccione •" ServiceMethod="GetMarca" ServicePath="ws.asmx"
                                                       TargetControlID="ddMarca">
                                </asp:CascadingDropDown>
                            </div>
                        </td>
                        <td width="10">&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            Modelo:
                            <asp:RequiredFieldValidator
                                ID="rfvtipo8" runat="server" ControlToValidate="ddModelo"
                                ErrorMessage="Seleccione Modelo" ForeColor="Red">
                                *
                            </asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <div class="form-group">
                                <asp:DropDownList
                                    ID="ddModelo" runat="server" CssClass="txtdd" Width="90%">
                                </asp:DropDownList>
                                <asp:CascadingDropDown ID="cddModelo" runat="server"
                                                       Category="modelo" Enabled="True" LoadingText="[Cargando Modelo...]"
                                                       ParentControlID="ddMarca" PromptText="• Seleccione •" ServiceMethod="GetModelo"
                                                       ServicePath="ws.asmx" TargetControlID="ddModelo">
                                </asp:CascadingDropDown>
                            </div>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>Serie:</td>
                        <td>
                            <div class="form-group">
                                <telerik:RadTextBox
                                    ID="txtserie" runat="server" MaxLength="150" Width="250px">

                                    <EmptyMessageStyle
                                        Font-Italic="True"/>
                                </telerik:RadTextBox>
                            </div>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>Color:</td>
                        <td>
                            <div class="form-group">
                                <asp:DropDownList
                                    ID="ddColor" runat="server" CssClass="txtdd" Width="90%">
                                </asp:DropDownList>
                                <asp:CascadingDropDown ID="cddcolor" runat="server"
                                                       Category="color" Enabled="True" LoadingText="[Cargando Color...]"
                                                       PromptText="• Seleccione •" ServiceMethod="GetColor" ServicePath="ws.asmx"
                                                       TargetControlID="ddColor">
                                </asp:CascadingDropDown>
                            </div>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            Año
                            Fab.:
                            <asp:RequiredFieldValidator ID="rfvtipo31" runat="server"
                                                        ControlToValidate="ddAnio" ErrorMessage="Seleccione Año" ForeColor="Red">
                                *
                            </asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <div class="form-group">
                                <asp:DropDownList ID="ddAnio" runat="server" CssClass="txtdd" Width="90%">
                                </asp:DropDownList>
                                <asp:CascadingDropDown ID="cddAnio" runat="server" Category="anio"
                                                       Enabled="True" LoadingText="[Cargando Año...]" PromptText="• Seleccione •"
                                                       ServiceMethod="GetAnio" ServicePath="ws.asmx" TargetControlID="ddAnio">
                                </asp:CascadingDropDown>
                            </div>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>Estructura:</td>
                        <td>
                            <div class="form-group">
                                <asp:DropDownList
                                    ID="ddEstructura" runat="server" CssClass="txtdd" Width="90%">
                                </asp:DropDownList>
                                <asp:CascadingDropDown ID="cddestruc1" runat="server"
                                                       Category="eco1" Enabled="True" LoadingText="[Cargando Estructura 1...]"
                                                       PromptText="• Seleccione •" ServiceMethod="GetEstruc1" ServicePath="ws.asmx"
                                                       TargetControlID="ddEstructura">
                                </asp:CascadingDropDown>
                            </div>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>Componente:</td>
                        <td>
                            <div class="form-group">
                                <asp:DropDownList
                                    ID="ddComponente" runat="server" CssClass="txtdd" Width="90%">
                                </asp:DropDownList>
                                <asp:CascadingDropDown ID="cddcompo1" runat="server"
                                                       Category="comp1" Enabled="True" LoadingText="[Cargando Componente 1...]"
                                                       ParentControlID="ddEstructura" PromptText="• Seleccione •"
                                                       ServiceMethod="GetEstruc2" ServicePath="ws.asmx" TargetControlID="ddComponente">
                                </asp:CascadingDropDown>
                            </div>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            Proveedor:
                            <asp:RequiredFieldValidator
                                ID="rfvtipo23" runat="server" ControlToValidate="ddProveedor"
                                ErrorMessage="Seleccione Proveedor" ForeColor="Red">
                                *
                            </asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <div class="form-group">
                                <asp:DropDownList
                                    ID="ddProveedor" runat="server" CssClass="txtdd" Width="90%">
                                </asp:DropDownList>
                                <asp:CascadingDropDown ID="cddProveedor" runat="server"
                                                       Category="provee" Enabled="True" LoadingText="[Cargando Proveedor...]"
                                                       PromptText="• Seleccione •" ServiceMethod="GetPro" ServicePath="ws.asmx"
                                                       TargetControlID="ddProveedor">
                                </asp:CascadingDropDown>
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
        <asp:UpdatePanel
            ID="upcontable" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table
                    cellpadding="2" cellspacing="0" class="style1">
                    <tr>
                        <td width="115" height="18">
                            Ingreso:
                        </h5>
                        </td>
                        <td>
                            <div style="padding: 15px">
                                <asp:Label
                                    ID="lblingreso" runat="server">
                                </asp:Label>
                            </div>
                        </h5>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Factura No.:
                        </h5>
                        </td>
                        <td>
                            <div class="form-group">
                                <telerik:RadTextBox
                                    ID="txtnumfact" runat="server" EmptyMessage="Ingrese" MaxLength="16"
                                    Width="119px">
                                    <ClientEvents
                                        OnKeyPress="KeyPress"/>
                                    <EmptyMessageStyle Font-Italic="True"/>
                                </telerik:RadTextBox>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Fecha de Compra:
                        </h5>
                        </td>
                        <td>
                            <div class="form-group">
                                <telerik:RadDatePicker
                                    ID="datefechacompra" runat="server" EnableTyping="False" MaxDate="2099-01-01"
                                    MinDate="" Width="120px" Enabled="False">
                                    <Calendar
                                        UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                        ViewSelectorText="x">
                                    </Calendar>
                                    <DateInput DateFormat="dd/MM/yyyy"
                                               DisplayDateFormat="dd/MM/yyyy" ReadOnly="True">
                                    </DateInput>
                                    <DatePopupButton
                                        HoverImageUrl="" ImageUrl=""/>
                                </telerik:RadDatePicker>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td height="18">
                            Valor de Compra:
                        </h5>
                        </td>
                        <td>
                            <div class="form-group">
                                <telerik:RadNumericTextBox ID="lblvalorcompra" runat="server" Culture="en-US"
                                                           EmptyMessage="Ingrese Valor" MaxValue="999999999" MinValue="0.01"
                                                           Type="Currency" Width="119px" Enabled="False">
                                    <NumberFormat GroupSeparator=""/>
                                    <EmptyMessageStyle Font-Italic="True"/>
                                </telerik:RadNumericTextBox>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td height="18">
                            Valor Razonable:
                        </h5>
                        </td>
                        <td>
                            <div class="form-group">
                                <telerik:RadNumericTextBox ID="lblvalorrazonable" runat="server" Culture="en-US"
                                                           EmptyMessage="Ingrese Valor" MaxValue="999999999" MinValue="0.00"
                                                           Type="Currency" Width="119px" Enabled="False">
                                    <NumberFormat GroupSeparator=""/>
                                    <EmptyMessageStyle Font-Italic="True"/>
                                </telerik:RadNumericTextBox>
                            </div>
                        </td>
                    </tr>
                </table>
                <asp:Panel
                    ID="panNiif" runat="server">
                    <table cellpadding="2" cellspacing="0"
                           class="style1">
                        <tr>
                            <td width="115" height="18">
                                Vida Util:
                            </h5>
                            </td>
                            <td>
                                <asp:Label ID="lblvidautil"
                                           runat="server">
                                </asp:Label>
                            </td>
                            <td>&#160;</td>
                        </tr>
                        <tr style="display: none">
                            <td height="18">
                                Vida Util NIIF:
                            </h5>
                            </td>
                            <td>
                                <asp:Label ID="lblvidautilniif" runat="server"></asp:Label>
                            </td>
                            <td>&#160;</td>
                        </tr>
                        <tr style="display: none">
                            <td height="18">
                                Valor Res. NIIF:
                            </h5>
                            </td>
                            <td>
                                <asp:Label ID="lblvalresniif" runat="server"></asp:Label>
                            </td>
                            <td>&#160;</td>
                        </tr>
                        <tr>
                            <td height="18">
                                Inicio de Operación:
                            </h5>
                            </td>
                            <td>
                                <asp:Label ID="lbldateininiif" runat="server"></asp:Label>
                            </td>
                            <td>&#160;</td>
                        </tr>
                        <tr>
                            <td height="18">
                                Depreciado Trib.:
                            </h5>
                            </td>
                            <td>
                                <table cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbldepresri" runat="server"></asp:Label>
                                        </td>
                                        <td width="18">
                                            &nbsp;
                                            <asp:HyperLink ID="hksri" runat="server" Height="16px" ImageUrl="~/Img/op2.png"
                                                           Target="_blank" Width="16px" ToolTip="Detalle Trib.">
                                            </asp:HyperLink>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>&#160;</td>
                        </tr>
                        <tr style="display: none">
                            <td height="18">
                                Depreciado NIIF:
                            </h5>
                            </td>
                            <td>
                                <table cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbldepreniif" runat="server"></asp:Label>
                                        </td>
                                        <td width="18">
                                            &nbsp;
                                            <asp:HyperLink ID="hkniif" runat="server" Height="15px"
                                                           ImageUrl="~/Img/op2.png" Target="_blank" Width="15px"
                                                           ToolTip="Detalle Niif">
                                            </asp:HyperLink>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>&#160;</td>
                        </tr>
                    </table>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</td>
<td class="aatl" style="width: 30%">
<div class="divv">
    <table cellpadding="2" cellspacing="0">
        <tr>
            <td class="auto-style11">Garantía: </td>
            <td width="60">
                <div class="form-group">
                    <asp:DropDownList ID="ddgarantia" runat="server" AutoPostBack="True" Width="60px"
                                      CssClass="txtdd" OnSelectedIndexChanged="ddgarantia_SelectedIndexChanged" Font-Size="X-Small">
                        <asp:ListItem>SI</asp:ListItem>
                        <asp:ListItem Selected="True">NO</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="pangar" runat="server" Visible="False">
                            <table cellpadding="2" cellspacing="0" class="style1">
                                <tr>
                                    <td width="50" valign="middle">
                                        Vence:
                                        <asp:RequiredFieldValidator ID="rfvtipo17" runat="server"
                                                                    ControlToValidate="dategarantiavence"
                                                                    ErrorMessage="Seleccione Fecha Vencimiento de Garantía" ForeColor="Red">
                                            *
                                        </asp:RequiredFieldValidator>
                                    </h5>
                                    </td>
                                    <td valign="top">
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
    </table>
</div>
<div class="divv">
    <table cellpadding="2" cellspacing="0" width="100%">
        <tr>
            <td width="50">
                <h6>Asegurado:</h6>
            </td>
            <td>
                <div class="form-group">
                    <asp:DropDownList ID="ddSeguro" runat="server" AutoPostBack="True" Width="60px" Font-Size="X-Small"
                                      CssClass="txtdd" OnSelectedIndexChanged="ddSeguro_SelectedIndexChanged">
                        <asp:ListItem>SI</asp:ListItem>
                        <asp:ListItem Selected="True">NO</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </td>
        </tr>
    </table>
</div>
<div class="divv">
    <asp:UpdatePanel ID="UpTipoSeg" runat="server">
        <ContentTemplate>
            <asp:Panel ID="panAseg" runat="server" Visible="False">
                <table cellpadding="2" cellspacing="0" width="100%">
                    <tr>
                        <td class="auto-style17">
                            Tipo:
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                        ControlToValidate="ddRamo"
                                                        ErrorMessage="Seleccione Tipo de Seguro" ForeColor="Red">
                                *
                            </asp:RequiredFieldValidator>
                        </h5>
                        </td>
                        <td>
                            <div class="form-group">
                                <asp:DropDownList ID="ddRamo" runat="server" Width="85%"
                                                  CssClass="txtdd">
                                </asp:DropDownList>
                                <asp:CascadingDropDown ID="cddRamo" runat="server" Category="tseg"
                                                       Enabled="True" LoadingText="[Cargando Seguro...]"
                                                       PromptText="• Seleccione •" ServiceMethod="GetTipoSeg" ServicePath="ws.asmx"
                                                       TargetControlID="ddRamo">
                                </asp:CascadingDropDown>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style17">
                            Número de Póliza:
                            <asp:RequiredFieldValidator ID="rfv_NumPoliza" runat="server"
                                                        ControlToValidate="txtNumPoliza"
                                                        ErrorMessage="Ingrese Número de Póliza" ForeColor="Red">
                                *
                            </asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <div class="form-group">
                                <telerik:RadTextBox ID="txtNumPoliza" runat="server">
                                </telerik:RadTextBox>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style17">
                            Fecha Emisión:
                            <asp:RequiredFieldValidator ID="rfvFechaEmision" runat="server"
                                                        ControlToValidate="rdpFechaEmision" ErrorMessage="Ingrese Fecha de Emisión Póliza"
                                                        ForeColor="Red">
                                *
                            </asp:RequiredFieldValidator>
                        </td>
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
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style17">
                            Fecha de Vencimiento:
                            <asp:RequiredFieldValidator ID="rfvFechaVencePoliza" runat="server"
                                                        ControlToValidate="rdpFechaVencimiento" ErrorMessage="Ingrese Fecha de Vencimiento Póliza"
                                                        ForeColor="Red">
                                *
                            </asp:RequiredFieldValidator>
                        </td>
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
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style17">
                            Valor Asegurado:
                            <asp:RequiredFieldValidator ID="rfv_Valorpoliza" runat="server"
                                                        ControlToValidate="txtValorAsegurado"
                                                        ErrorMessage="Ingrese Valor Asegurado" ForeColor="Red">
                                *
                            </asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <div class="form-group">
                                <telerik:RadNumericTextBox ID="txtValorAsegurado" runat="server" Culture="en-US"
                                                           EmptyMessage="Ingrese Valor" MaxValue="999999999" MinValue="0.01"
                                                           Type="Currency" Width="119px">
                                    <NumberFormat GroupSeparator=""/>
                                    <EmptyMessageStyle Font-Italic="True"/>
                                </telerik:RadNumericTextBox>
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
            <td width="105">Fotografía 1:</td>
            <td>
                <telerik:RadAsyncUpload ID="rau1" runat="server" Culture="en-US" InputSize="15"
                                        MaxFileInputsCount="1" OnFileUploaded="rau1_FileUploaded"
                                        TargetFolder="~/Site/Activos/imgact" Width="200px" AllowedFileExtensions="jpg,jpeg,png,gif">
                    <Localization Cancel="Cancelar" Remove="Eliminar" Select="Buscar"/>
                </telerik:RadAsyncUpload>
            </td>
        </tr>
        <tr>
            <td>Fotografía 2:</td>
            <td>
                <telerik:RadAsyncUpload ID="rau2" runat="server" Culture="en-US" InputSize="15"
                                        MaxFileInputsCount="1" OnFileUploaded="rau2_FileUploaded"
                                        TargetFolder="~/Site/Activos/imgact" Width="200px" AllowedFileExtensions="jpg,jpeg,png,gif">
                    <Localization Cancel="Cancelar" Remove="Eliminar" Select="Buscar"/>
                </telerik:RadAsyncUpload>
            </td>
        </tr>
        <tr>
            <td>Factura:</td>
            <td>
                <telerik:RadAsyncUpload ID="rau3" runat="server" Culture="en-US" InputSize="15"
                                        MaxFileInputsCount="1" OnFileUploaded="rau3_FileUploaded"
                                        TargetFolder="~/Site/Activos/imgact" Width="200px">
                    <Localization Cancel="Cancelar" Remove="Eliminar" Select="Buscar"/>
                </telerik:RadAsyncUpload>
            </td>
        </tr>
        <tr>
            <td>Manual:</td>
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
<table
    cellpadding="0" cellspacing="0" class="style1">
    <tr>
        <td
            align="right" class="ba9" height="30">
            &#160;
        </td>
    </tr>
    <tr>
        <td class="aatl">
            <div
                class="divv">
                <asp:UpdatePanel ID="upobs" runat="server"
                                 UpdateMode="Conditional">
                    <ContentTemplate>
                        <table cellpadding="2" cellspacing="0"
                               class="style1">
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtObservaciones" runat="server" CssClass="form-control"
                                                 Rows="7" TextMode="MultiLine" Width="99%" Font-Names="Arial" Font-Size="9pt">
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
<table cellpadding="0"
       cellspacing="0" class="style1">
<tr>
    <td height="20">
        <asp:Panel ID="panbaja" runat="server" CssClass="panmar"
                   GroupingText="Información de la Baja" Visible="False">
            <table cellspacing="0" class="panmar">
                <tr>
                    <td width="120">Razón de Baja:</td>
                    <td>
                        <asp:Label ID="lblbaja" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Observaciones Baja:</td>
                    <td>
                        <asp:Literal ID="litbaja" runat="server"></asp:Literal>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </td>
</tr>
<tr>
    <td
        class="ba10" height="30">
        <table cellpadding="0" cellspacing="0"
               class="style1">
            <tr>
                <td width="196">&#160;</td>
                <td>
                    <asp:ImageButton ID="ibgr7"
                                     runat="server" CausesValidation="False" CssClass="relo" Height="18px"
                                     ImageUrl="~/Img/rl1.png" OnClick="ibgr7_Click" TabIndex="99"
                                     ToolTip="Actualizar Clasificación" Width="21px"/>
                </td>
            </tr>
        </table>
    </td>
</tr>
<tr>
<td
    width="40%">
<asp:UpdatePanel ID="upcar" runat="server"
                 UpdateMode="Conditional">
<ContentTemplate>
<table cellpadding="0" cellspacing="0"
       class="style1">
<tr>
<td class="aatl">
    <div class="divv">
        <table cellpadding="2"
               cellspacing="0" class="style1">
            <tr>
                <td width="26%">
                    <asp:Label ID="l1"
                               runat="server">
                    </asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="t1" runat="server"
                                        Width="100%">
                    </telerik:RadTextBox>
                </td>
                <td width="5">&#160;</td>
                <td
                    width="50">
                    <asp:DropDownList ID="d1" runat="server" CssClass="txtdd">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="l2" runat="server"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox
                        ID="t2" runat="server" MaxLength="150" Width="100%">
                    </telerik:RadTextBox>
                </td>
                <td>&#160;</td>
                <td>
                    <asp:DropDownList
                        ID="d2" runat="server" CssClass="txtdd">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="l3" runat="server"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox
                        ID="t3" runat="server" MaxLength="150" Width="100%">
                    </telerik:RadTextBox>
                </td>
                <td>&#160;</td>
                <td>
                    <asp:DropDownList
                        ID="d3" runat="server" CssClass="txtdd">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="l4" runat="server"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox
                        ID="t4" runat="server" MaxLength="150" Width="100%">
                    </telerik:RadTextBox>
                </td>
                <td>&#160;</td>
                <td>
                    <asp:DropDownList
                        ID="d4" runat="server" CssClass="txtdd">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="l5" runat="server"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox
                        ID="t5" runat="server" MaxLength="150" Width="100%">
                    </telerik:RadTextBox>
                </td>
                <td>&#160;</td>
                <td>
                    <asp:DropDownList
                        ID="d5" runat="server" CssClass="txtdd">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="l6" runat="server"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox
                        ID="t6" runat="server" MaxLength="150" Width="100%">
                    </telerik:RadTextBox>
                </td>
                <td>&#160;</td>
                <td>
                    <asp:DropDownList
                        ID="d6" runat="server" CssClass="txtdd">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="l7" runat="server"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox
                        ID="t7" runat="server" MaxLength="150" Width="100%">
                    </telerik:RadTextBox>
                </td>
                <td>&#160;</td>
                <td>
                    <asp:DropDownList
                        ID="d7" runat="server" CssClass="txtdd">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="l8" runat="server"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox
                        ID="t8" runat="server" MaxLength="150" Width="100%">
                    </telerik:RadTextBox>
                </td>
                <td>&#160;</td>
                <td>
                    <asp:DropDownList
                        ID="d8" runat="server" CssClass="txtdd">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    </div>
</td>
<td width="6">&#160;</td>
<td
    bgcolor="Silver" width="3">
    &#160;
</td>
<td width="6">&#160;</td>
<td class="aatl">
    <div
        class="divv">
        <table cellpadding="2" cellspacing="0" class="style1">
            <tr>
                <td
                    width="26%">
                    <asp:Label ID="l9" runat="server"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox
                        ID="t9" runat="server" MaxLength="150" Width="100%">
                    </telerik:RadTextBox>
                </td>
                <td
                    width="5">
                    &#160;
                </td>
                <td width="50">
                    <asp:DropDownList ID="d9" runat="server"
                                      CssClass="txtdd">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="l10" runat="server"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox
                        ID="t10" runat="server" MaxLength="150" Width="100%">
                    </telerik:RadTextBox>
                </td>
                <td>&#160;</td>
                <td>
                    <asp:DropDownList
                        ID="d10" runat="server" CssClass="txtdd">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="l11" runat="server"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox
                        ID="t11" runat="server" MaxLength="150" Width="100%">
                    </telerik:RadTextBox>
                </td>
                <td>&#160;</td>
                <td>
                    <asp:DropDownList
                        ID="d11" runat="server" CssClass="txtdd">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="l12" runat="server"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox
                        ID="t12" runat="server" MaxLength="150" Width="100%">
                    </telerik:RadTextBox>
                </td>
                <td>&#160;</td>
                <td>
                    <asp:DropDownList
                        ID="d12" runat="server" CssClass="txtdd">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="l13" runat="server"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox
                        ID="t13" runat="server" MaxLength="150" Width="100%">
                    </telerik:RadTextBox>
                </td>
                <td>&#160;</td>
                <td>
                    <asp:DropDownList
                        ID="d13" runat="server" CssClass="txtdd">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="l14" runat="server"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox
                        ID="t14" runat="server" MaxLength="150" Width="100%">
                    </telerik:RadTextBox>
                </td>
                <td>&#160;</td>
                <td>
                    <asp:DropDownList
                        ID="d14" runat="server" CssClass="txtdd">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="l15" runat="server"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox
                        ID="t15" runat="server" MaxLength="150" Width="100%">
                    </telerik:RadTextBox>
                </td>
                <td>&#160;</td>
                <td>
                    <asp:DropDownList
                        ID="d15" runat="server" CssClass="txtdd">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="l16" runat="server"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox
                        ID="t16" runat="server" MaxLength="150" Width="100%">
                    </telerik:RadTextBox>
                </td>
                <td>&#160;</td>
                <td>
                    <asp:DropDownList
                        ID="d16" runat="server" CssClass="txtdd">
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
</div>
</asp:Panel>
<br/>
<br/>
<asp:Panel ID="panCommand" runat="server" CssClass="aabrpan"
           Height="33px" Width="100%">
    <div class="panmar3">
        &nbsp;&nbsp;
        <asp:ImageButton ID="ibcancel" runat="server" CausesValidation="False"
                         Height="28px" ImageUrl="~/Img/c1.png" OnClick="ibcancel_Click" Width="102px"/>
        &nbsp;
        <asp:ImageButton ID="ibsave" runat="server" Height="28px"
                         ImageUrl="~/Img/s1.png" OnClick="ibsave_Click" Width="102px"/>
    </div>
</asp:Panel>
<asp:AlwaysVisibleControlExtender ID="avcePanCommand" runat="server"
                                  Enabled="True" TargetControlID="panCommand" VerticalSide="Bottom">
</asp:AlwaysVisibleControlExtender>
<uc2:messbox ID="messbox1" runat="server"/>
<asp:ValidationSummary ID="vs1" runat="server" ShowMessageBox="True"
                       ShowSummary="False"/>
</asp:Content>
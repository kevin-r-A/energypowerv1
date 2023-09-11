<%@ Page Language="C#" MasterPageFile="~/Site/Activos/cay.master" AutoEventWireup="true" CodeFile="IngresadeMantenimiento.aspx.cs" Inherits="Site_Mantenimiento_IngresadeMant_IngresodeMantenimiento" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register src="../../../Ctrl/Wait/wait.ascx" tagname="wait" tagprefix="uc1" %>
<%@ Register src="../../../Ctrl/Msg/messbox.ascx" tagname="messbox" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <uc1:wait ID="wait1" runat="server" />
    <style type="text/css">
        
.RadInput_Default
{
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput
{
	vertical-align:middle;
}

.RadInput_Default
{
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput
{
	vertical-align:middle;
}

.RadInput_Default
{
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput
{
	vertical-align:middle;
}

.RadInput_Default
{
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput
{
	vertical-align:middle;
}

.RadInput_Default
{
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput
{
	vertical-align:middle;
}

.RadInput_Default
{
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput
{
	vertical-align:middle;
}

.RadInput_Default
{
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput
{
	vertical-align:middle;
}

.RadInput_Default
{
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput
{
	vertical-align:middle;
}

.RadInput_Default
{
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput
{
	vertical-align:middle;
}

.RadInput_Default
{
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput
{
	vertical-align:middle;
}

.RadInput_Default
{
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput
{
	vertical-align:middle;
}

.RadInput_Default
{
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput
{
	vertical-align:middle;
}

.RadInput_Default
{
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput
{
	vertical-align:middle;
}

.RadInput_Default
{
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput
{
	vertical-align:middle;
}

.RadInput_Default
{
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput
{
	vertical-align:middle;
}

.RadInput_Default
{
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput
{
	vertical-align:middle;
}

.RadInput_Default
{
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput
{
	vertical-align:middle;
}

.RadInput_Default
{
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput
{
	vertical-align:middle;
}

.RadInput_Default
{
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput
{
	vertical-align:middle;
}

.RadInput_Default
{
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput
{
	vertical-align:middle;
}

.RadInput_Default
{
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput
{
	vertical-align:middle;
}

.RadInput_Default
{
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput
{
	vertical-align:middle;
}

.RadInput_Default
{
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput
{
	vertical-align:middle;
}

        .style17
        {
            width: 69px;
        }
        .style19
        {
            vertical-align: top;
            text-align: left;
            width: 129%;
        }

        .style21
        {
            width: 100%;
        }
        
        .style26
        {
            width: 229px;
        }

        .style29
        {
            margin-left: 0px;
        }
        .style30
        {
            width: 115px;
        }
        .style32
        {
            width: 33px;
        }

        .style33
        {
            width: 114px;
        }

        .style34
        {
            width: 70px;
        }

        .style35
        {
            width: 297px;
        }

        .style36
        {
            width: 311px;
        }

        .auto-style4 {
            width: 88px;
        }

        .auto-style5 {
            width: 333px;
        }
        .auto-style6 {
            width: 51px;
        }

        </style>
        <script type="text/javascript">

            function KeyPress(sender, args) {
                var regexp = new RegExp("[0-9]{1}|[\b]|\t|\r");
                if (!args.get_keyCharacter().match(regexp))
                    args.set_cancel(true);
            }  
            </script>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="cph1">
<asp:Panel ID="panGeneral" runat="server" CssClass="panmar" 
                            GroupingText="Activa Items en Mantenimieto" >       
    <table cellspacing="0" class="style1">
        <tr>
            <td class="style19">
                <div class="divv">
                            <asp:UpdatePanel ID="upFiltro" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>

                                <table class="style1">
                                   <%-- <tr>
                                        <td class="style17">
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>--%>
                                    <tr>
                                        <td class="style17">
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                </table>
                                <asp:Panel GroupingText = "Filtros" runat ="server" ID = "panFiltros" Visible = "false">
                                    <table cellpadding="2" cellspacing="0" class="style1" id="tblFiltros" runat="server">
                                        <tr>
                                            <td width="70">
                                                &nbsp;</td>
                                            <td class="aatl">
                                                <asp:CheckBox ID="chk1" runat="server" AutoPostBack="True" Checked="True" 
                                                    oncheckedchanged="chk1_CheckedChanged" Text="Habilitar Dependencias" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Tipo:</td>
                                            <td>
                                                <asp:DropDownList ID="ddtipoitem" runat="server" CssClass="txtdd" 
                                                    Enabled="False" Width="100%">
                                                </asp:DropDownList>
                                                <asp:CascadingDropDown ID="cddtipoitem" runat="server" 
                                                    Category="tip" Enabled="True" LoadingText="[Cargando Tipos...]" 
                                                    PromptText="• Todos •" ServiceMethod="GetTipoItem" ServicePath="~/Site/Activos/ws.asmx"
                                                    TargetControlID="ddtipoitem">
                                                </asp:CascadingDropDown>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Grupo/Cta:</td>
                                            <td>
                                                <asp:DropDownList ID="ddGrupo" runat="server" CssClass="txtdd" Width="100%">
                                                </asp:DropDownList>
                                                <asp:CascadingDropDown ID="cddgru1" runat="server" Category="gru1" 
                                                    Enabled="True" LoadingText="[Cargando Grupo...]" PromptText="• Todos •" 
                                                    ServiceMethod="GetGru1" ServicePath="~/Site/Activos/ws.asmx" TargetControlID="ddGrupo">
                                                </asp:CascadingDropDown>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Subgrupo:</td>
                                            <td>
                                                <asp:DropDownList ID="ddSubgrupo" runat="server" CssClass="txtdd" Width="100%">
                                                </asp:DropDownList>
                                                <asp:CascadingDropDown ID="cddgru2" runat="server" Category="gru2" 
                                                    Enabled="True" LoadingText="[Cargando Subgrupo...]" ParentControlID="ddGrupo" 
                                                    PromptText="• Todos •" ServiceMethod="GetGru2" ServicePath="~/Site/Activos/ws.asmx" 
                                                    TargetControlID="ddSubgrupo">
                                                </asp:CascadingDropDown>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Descripción:</td>
                                            <td>
                                                <asp:DropDownList ID="ddDescripcion" runat="server" CssClass="txtdd" 
                                                    Width="100%">
                                                </asp:DropDownList>
                                                <asp:CascadingDropDown ID="cddDescrip" runat="server" Category="gru3" 
                                                    Enabled="True" LoadingText="[Cargando Descripción...]" 
                                                    ParentControlID="ddSubgrupo" PromptText="• Todos •" ServiceMethod="GetGru3" 
                                                    ServicePath="~/Site/Activos/ws.asmx" TargetControlID="ddDescripcion">
                                                </asp:CascadingDropDown>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Ub. Geo1:</td>
                                            <td>
                                                <asp:DropDownList ID="ddUge1" runat="server" CssClass="txtdd" Width="100%">
                                                </asp:DropDownList>
                                                <asp:CascadingDropDown ID="cddgeo1" runat="server" Category="uge1" 
                                                    Enabled="True" LoadingText="[Cargando Geo1...]" PromptText="• Todos •" 
                                                    ServiceMethod="GetUge1" ServicePath="~/Site/Activos/ws.asmx" TargetControlID="ddUge1">
                                                </asp:CascadingDropDown>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Ub. Geo2:</td>
                                            <td>
                                                <asp:DropDownList ID="ddUge2" runat="server" CssClass="txtdd" Width="100%">
                                                </asp:DropDownList>
                                                <asp:CascadingDropDown ID="cddgeo2" runat="server" Category="uge2" 
                                                    Enabled="True" LoadingText="[Cargando Geo2...]" ParentControlID="ddUge1" 
                                                    PromptText="• Todos •" ServiceMethod="GetUge2" ServicePath="~/Site/Activos/ws.asmx" 
                                                    TargetControlID="ddUge2">
                                                </asp:CascadingDropDown>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Ub. Geo3:</td>
                                            <td>
                                                <asp:DropDownList ID="ddUge3" runat="server" CssClass="txtdd" Width="100%">
                                                </asp:DropDownList>
                                                <asp:CascadingDropDown ID="cddgeo3" runat="server" Category="uge3" 
                                                    Enabled="True" LoadingText="[Cargando Geo3...]" ParentControlID="ddUge2" 
                                                    PromptText="• Todos •" ServiceMethod="GetUge3" ServicePath="~/Site/Activos/ws.asmx" 
                                                    TargetControlID="ddUge3">
                                                </asp:CascadingDropDown>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Piso/Nivel:</td>
                                            <td>
                                                <asp:DropDownList ID="ddPiso" runat="server" CssClass="txtdd" Width="175px">
                                                </asp:DropDownList>
                                                <asp:CascadingDropDown ID="cddpiso" runat="server" Category="pis_id" 
                                                    Enabled="True" LoadingText="[Cargando Piso...]" ParentControlID="ddUge3" 
                                                    PromptText="• Todos •" ServiceMethod="GetUge4" ServicePath="~/Site/Activos/ws.asmx" 
                                                    TargetControlID="ddPiso">
                                                </asp:CascadingDropDown>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Cent.Costo:</td>
                                            <td>
                                                <asp:DropDownList ID="ddCcosto" runat="server" CssClass="txtdd" Width="100%">
                                                </asp:DropDownList>
                                                <asp:CascadingDropDown ID="cddccosto" runat="server" Category="cco" 
                                                    Enabled="True" LoadingText="[Cargando Centro de Costo...]" 
                                                    ParentControlID="ddUge2" PromptText="• Todos •" ServiceMethod="GetCcostoUge2" 
                                                    ServicePath="~/Site/Activos/ws.asmx" TargetControlID="ddCcosto">
                                                </asp:CascadingDropDown>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Ub. Org1:</td>
                                            <td>
                                                <asp:DropDownList ID="ddUor1" runat="server" CssClass="txtdd" Width="100%">
                                                </asp:DropDownList>
                                                <asp:CascadingDropDown ID="cdduor1" runat="server" Category="uor1" 
                                                    Enabled="True" LoadingText="[Cargando Dep1...]" ParentControlID="ddCcosto" 
                                                    PromptText="• Todos •" ServiceMethod="GetUor1Cco" ServicePath="~/Site/Activos/ws.asmx" 
                                                    TargetControlID="ddUor1">
                                                </asp:CascadingDropDown>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Ub. Org2:</td>
                                            <td>
                                                <asp:DropDownList ID="ddUor2" runat="server" CssClass="txtdd" Width="100%">
                                                </asp:DropDownList>
                                                <asp:CascadingDropDown ID="cdduor2" runat="server" Category="uor2" 
                                                    Enabled="True" LoadingText="[Cargando Dep2...]" ParentControlID="ddUor1" 
                                                    PromptText="• Todos •" ServiceMethod="GetUor2" ServicePath="~/Site/Activos/ws.asmx" 
                                                    TargetControlID="ddUor2">
                                                </asp:CascadingDropDown>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Custodio:</td>
                                            <td>
                                                <asp:DropDownList ID="ddCustodio" runat="server" CssClass="txtdd" Width="100%">
                                                </asp:DropDownList>
                                                <asp:CascadingDropDown ID="cddcus" runat="server" Category="cus" ContextKey="" 
                                                    Enabled="True" LoadingText="[Cargando Custodios...]" ParentControlID="ddUor1" 
                                                    PromptText="• Todos •" ServiceMethod="GetCusUor1" ServicePath="~/Site/Activos/ws.asmx" 
                                                    TargetControlID="ddCustodio">
                                                </asp:CascadingDropDown>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Estado:</td>
                                            <td>
                                                <asp:DropDownList ID="ddEstado" runat="server" CssClass="txtdd" Width="110px">
                                                </asp:DropDownList>
                                                <asp:CascadingDropDown ID="cddest1" runat="server" Category="est1" 
                                                    ContextKey="1" Enabled="True" LoadingText="[Cargando Estado 1...]" 
                                                    PromptText="• Todos •" ServiceMethod="GetEstadoRepoMant" ServicePath="~/Site/Activos/ws.asmx" 
                                                    TargetControlID="ddEstado">
                                                </asp:CascadingDropDown>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Fase:</td>
                                            <td>
                                                <asp:DropDownList ID="ddFase" runat="server" CssClass="txtdd" Width="110px">
                                                </asp:DropDownList>
                                                <asp:CascadingDropDown ID="cddest2" runat="server" Category="est2" 
                                                    ContextKey="2" Enabled="True" LoadingText="[Cargando Estado 2...]" 
                                                    PromptText="• Todos •" ServiceMethod="GetEstadoRepoMant" ServicePath="~/Site/Activos/ws.asmx" 
                                                    TargetControlID="ddFase">
                                                </asp:CascadingDropDown>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Transferen.:</td>
                                            <td>
                                                <asp:DropDownList ID="ddTrasnfer" runat="server" CssClass="txtdd" Width="110px">
                                                </asp:DropDownList>
                                                <asp:CascadingDropDown ID="cddest3" runat="server" Category="est3" 
                                                    ContextKey="3" Enabled="True" LoadingText="[Cargando Estado 3...]" 
                                                    PromptText="• Todos •" ServiceMethod="GetEstadoRepoMant" ServicePath="~/Site/Activos/ws.asmx" 
                                                    TargetControlID="ddTrasnfer">
                                                </asp:CascadingDropDown>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Marca:</td>
                                            <td>
                                                <asp:DropDownList ID="ddMarca" runat="server" CssClass="txtdd" Width="100%">
                                                </asp:DropDownList>
                                                <asp:CascadingDropDown ID="cddmarca" runat="server" Category="marca" 
                                                    Enabled="True" LoadingText="[Cargando Marca...]" PromptText="• Todos •" 
                                                    ServiceMethod="GetMarca" ServicePath="~/Site/Activos/ws.asmx" TargetControlID="ddMarca">
                                                </asp:CascadingDropDown>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Modelo:</td>
                                            <td>
                                                <asp:DropDownList ID="ddModelo" runat="server" CssClass="txtdd" Width="100%">
                                                </asp:DropDownList>
                                                <asp:CascadingDropDown ID="cddModelo" runat="server" Category="modelo" 
                                                    Enabled="True" LoadingText="[Cargando Modelo...]" ParentControlID="ddMarca" 
                                                    PromptText="• Todos •" ServiceMethod="GetModelo" ServicePath="~/Site/Activos/ws.asmx" 
                                                    TargetControlID="ddModelo">
                                                </asp:CascadingDropDown>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Proveedor:</td>
                                            <td>
                                                <asp:DropDownList ID="ddProveedor" runat="server" CssClass="txtdd" Width="100%">
                                                </asp:DropDownList>
                                                <asp:CascadingDropDown ID="cddProveedor" runat="server" Category="provee" 
                                                    Enabled="True" LoadingText="[Cargando Proveedor...]" PromptText="• Todos •" 
                                                    ServiceMethod="GetPro" ServicePath="~/Site/Activos/ws.asmx" TargetControlID="ddProveedor">
                                                </asp:CascadingDropDown>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Ingreso:</td>
                                            <td>
                                                <asp:DropDownList ID="ddtipoing" runat="server" CssClass="txtdd" Width="100%">
                                                </asp:DropDownList>
                                                <asp:CascadingDropDown ID="cddtipoing" runat="server" 
                                                    Category="tiping" Enabled="True" LoadingText="[Cargando Tipos...]" 
                                                    PromptText="• Todos •" ServiceMethod="GetTipoIng" ServicePath="~/Site/Activos/ws.asmx" 
                                                    TargetControlID="ddtipoing">
                                                </asp:CascadingDropDown>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Garantía:</td>
                                            <td>
                                                <asp:DropDownList ID="ddgarantia" runat="server" CssClass="txtdd" Width="100%">
                                                    <asp:ListItem Selected="True">• Todos •</asp:ListItem>
                                                    <asp:ListItem Value="1">SI</asp:ListItem>
                                                    <asp:ListItem Value="0">NO</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                    <table cellspacing="1" class="style1">
                                        <tr>
                                            <td class="aatr" height="36">
                                                <asp:UpdatePanel ID="upconsult" runat="server" UpdateMode="Conditional" Visible ="false">
                                                    <ContentTemplate>
                                                        <asp:ImageButton ID="ibcancel" runat="server" CausesValidation="False" 
                                                            Height="28px" ImageUrl="~/Img/d1.png" onclick="ibcancel_Click" Width="102px" />
                                                        &nbsp;<asp:ImageButton ID="ibsave" runat="server" Height="28px" 
                                                            ImageUrl="~/Img/t1.png" onclick="ibsave_Click" Width="102px" />
                                                        
                                                        
                                                        <br>
                                                        <br></br>
                                                        <div class="form-group">
                                                            <asp:Button ID="btnActivar" runat="server" CssClass="btn btn-primary" Font-Bold="True" Height="28px" onclick="btnActivar_Click" Text="Activar Items" Width="122px" />
                                                        </div>
                                                        <br>
                                                        <br></br>
                                                        <br>
                                                        <br></br>
                                                        <br>
                                                        <br></br>
                                                        </br>
                                                        </br>
                                                        </br>
                                                        
                                                        
                                                        </br>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                
                                            </td>
                                        </tr>
                                    </table>
                                    </asp:Panel>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
            </td>
            
            <td class="aatl">
                <div class="divv">
                    <table cellspacing="1" class="style1">
                        <tr>
                            <td class="aatl">
                                        <table cellspacing="0" class="style1">
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <table class="style21">
                                                        <tr>
                                                            <td>
                                                                <table class="style21">
                                                                    <tr>
                                                                        <td class="auto-style4" >
                                                                            <asp:Label ID="Label2" runat="server" Text="Buscar Por:" Font-Bold="true"></asp:Label>
                                                                        </td>
                                                                        <td class="style26">
                                            <asp:RadioButtonList ID="rblBuscar" runat="server" AutoPostBack="True" 
                                                onselectedindexchanged="rblBuscar_SelectedIndexChanged" 
                                                RepeatDirection="Horizontal" Font-Bold="True" Width="354px">
                                                <asp:ListItem Selected="True" Value="CB">Código de Barras</asp:ListItem>
                                                <asp:ListItem Value="CS">Código Secundario</asp:ListItem>
                                                <asp:ListItem Value="F">Filtros</asp:ListItem>
                                            </asp:RadioButtonList>
                                                                        </td>
                                                                        <td>
                                                                            &nbsp;</td>
                                                                        <td>
                                                                            &nbsp;</td>
                                                                        <td>
                                                                            &nbsp;</td>
                                                                        <td>
                                                                            &nbsp;</td>
                                                                        <td>
                                                                            &nbsp;</td>
                                                                        <td>
                                                                            &nbsp;</td>
                                                                        <td>
                                                                            &nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4">
                                                                            <table class="style21">
                                                                                <tr>
                                                                                    <td class="style30">
                                                                                        <h5>
                                                                                        <asp:Label ID="Label1" runat="server" Font-Bold="False" Font-Size="9pt" 
                                                                                            Text="Código de Barras"></asp:Label>
                                                                                        <asp:RequiredFieldValidator ID="rfv_codbarras" runat="server" 
                                                                                            ControlToValidate="txtbuscb" ErrorMessage="Ingrese Código de Barras" 
                                                                                            ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                                                                        <asp:ValidatorCalloutExtender ID="rfv1_ValidatorCalloutExtender" runat="server" 
                                                                                            Enabled="True" PopupPosition="BottomRight" TargetControlID="rfv_codbarras">
                                                                                        </asp:ValidatorCalloutExtender>
                                                                                            </h5>
                                                                                    </td>
                                                                                    <td class="style33" valign="middle">
                                                                                        <div class="form-group">
                                                                                        <telerik:RadTextBox ID="txtbuscb" runat="server" MaxLength="20" Width="150px" CssClass="form-control">
                                                                                            <clientevents onkeypress="KeyPress" />
                                                                                            <emptymessagestyle font-italic="True" />
                                                                                        </telerik:RadTextBox>
                                                                                            </div>
                                                                                    </td>
                                                                                    <td class="auto-style6" valign="middle">
                                                                                        <asp:ImageButton ID="ibbus1" runat="server" CssClass="relo" Height="35px" 
                                                                                            ImageUrl="~/Img/buscarblue.png" onclick="ibbus1_Click" TabIndex="99" 
                                                                                            ToolTip="Buscar Código de Barras" ValidationGroup="1" Width="35px" />
                                                                                    </td>
                                                                                    <td valign="middle">
                                                                                        &nbsp;</td>
                                                                                    <td>
                                                                                        &nbsp;</td>
                                                                                    <td>
                                                                                        &nbsp;</td>
                                                                                    <td>
                                                                                        &nbsp;</td>
                                                                                    <td>
                                                                                        &nbsp;</td>
                                                                                    <td>
                                                                                        &nbsp;</td>
                                                                                    <td>
                                                                                        &nbsp;</td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="style30">
                                                                                        <h5>
                                                                                        <asp:Label ID="Label3" runat="server" Font-Bold="False" Font-Size="9pt" 
                                                                                            Text="Código Secundario"></asp:Label>
                                                                                        <asp:RequiredFieldValidator ID="rfv_codbarras0" runat="server" 
                                                                                            ControlToValidate="txtbusbnf" ErrorMessage="Ingrese Código Secundario" 
                                                                                            ForeColor="Red" ValidationGroup="2">*</asp:RequiredFieldValidator>
                                                                                        <asp:ValidatorCalloutExtender ID="rfv1_ValidatorCalloutExtender0" 
                                                                                            runat="server" Enabled="True" PopupPosition="BottomRight" 
                                                                                            TargetControlID="rfv_codbarras0">
                                                                                        </asp:ValidatorCalloutExtender>
                                                                                            </h5>
                                                                                    </td>
                                                                                    <td class="style33" valign="middle">
                                                                                        <div class="form-group">
                                                                                        <telerik:RadTextBox ID="txtbusbnf" runat="server" MaxLength="40" Width="150px" CssClass="form-control">
                                                                                            
                                                                                            <emptymessagestyle font-italic="True" />
                                                                                        </telerik:RadTextBox>
                                                                                            </div>
                                                                                    </td>
                                                                                    <td class="auto-style6" valign="middle">
                                                                                        <asp:ImageButton ID="ibbus2" runat="server" CssClass="relo" Height="35px" 
                                                                                            ImageUrl="~/Img/buscarblue.png" onclick="ibbus2_Click" TabIndex="99" 
                                                                                            ToolTip="Buscar Código Secundario" ValidationGroup="2" Width="35px" />
                                                                                    </td>
                                                                                    <td valign="middle">
                                                                                        <asp:ImageButton ID="ibxls1" runat="server" CssClass="style29" Height="30px" 
                                                                                            ImageUrl="~/Img/xls1.png" onclick="ibxls1_Click" Width="122px" />
                                                                                    </td>
                                                                                    <td>
                                                                                        &nbsp;</td>
                                                                                    <td>
                                                                                        &nbsp;</td>
                                                                                    <td>
                                                                                        &nbsp;</td>
                                                                                    <td>
                                                                                        &nbsp;</td>
                                                                                    <td>
                                                                                        &nbsp;</td>
                                                                                    <td>
                                                                                        &nbsp;</td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td>
                                                                            &nbsp;</td>
                                                                        <td>
                                                                            &nbsp;</td>
                                                                        <td>
                                                                            &nbsp;</td>
                                                                        <td>
                                                                            &nbsp;</td>
                                                                        <td>
                                                                            &nbsp;</td>
                                                                    </tr>
                                                                    </table>
                                                            </td>
                                                            <td>
                                                                &nbsp;</td>
                                                        </tr>
                                                        </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="50%" colspan="2">
                                        
                                                    <table class="style1">
                                                        <tr>
                                                            <td class="auto-style5">
                                                                &nbsp;</td>
                                                            <td>
                                                                <div class="form-group">
                                                                <asp:Button ID="btnActivarItem" runat="server" CssClass="btn btn-primary"
                                                                    Font-Bold="True" Height="30px" Text="Activar Item" 
                                                                    Width="122px" onclick="btnActivarItem_Click" />
                                                                    </div>
                                                            </td>
                                                            <td>
                                                                &nbsp;</td>
                                                            <td>
                                                                &nbsp;</td>
                                                            <td>
                                                                &nbsp;</td>
                                                            <td>
                                                                &nbsp;</td>
                                                            <td>
                                                                &nbsp;</td>
                                                            <td>
                                                                &nbsp;</td>
                                                            <td>
                                                                &nbsp;</td>
                                                            <td>
                                                                &nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="130" colspan="2">
                                        
                                                    <asp:UpdatePanel ID="upres" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <asp:Label ID="lblResumen" runat="server" ForeColor="#003366"></asp:Label>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                        
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                        </tr>
                    </table>
                </div>
                
                <asp:Panel ID="panGrid" runat="server" CssClass="panmar6" ScrollBars="Both" Height="500px">
                    <asp:UpdatePanel ID="upgrid" runat="server" UpdateMode="Conditional">
                    
                        <ContentTemplate>
                        <asp:GridView ID = "rgreporte" runat="server" CssClass="mGrid" AlternatingRowStyle-CssClass="alt"
                        EmptyDataText="No se encontraron registros que coincidan con la busqueda." GridLines="None"
                        onrowdatabound="rgutil_RowDataBound" onsorting="rgreporte_Sorting" Width="4000px"
                        >
                        <AlternatingRowStyle CssClass="alt" BackColor="#F8FBFE" />

                        <Columns>
                                    <asp:TemplateField Visible = "false">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hk2" runat="server" ImageUrl="~/Img/editar.gif" 
                                            Target="_blank" ToolTip="Editar Item"></asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField ControlStyle-Width ="1px" HeaderText = "Activacion">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chboxAutTodos" runat="server" AutoPostBack="true" 
                                                oncheckedchanged="chboxAutTodos_CheckedChanged" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="check_autoriza" runat="server" 
                                                ToolTip = "Activar Item" AutoPostBack="true" 
                                                />
                                        </ItemTemplate>
                                        <ControlStyle Width="1px" />
                                    </asp:TemplateField>

                                </Columns>
                                 <HeaderStyle HorizontalAlign="Left" />
                                 <SelectedRowStyle BackColor="#FFFF99" />
                </asp:GridView>
                            <%--<asp:GridView ID="rgreporte" runat="server" AllowPaging="True" 
                            AllowSorting="True" AlternatingRowStyle-CssClass="alt" CssClass="mGrid" 
                            EmptyDataText="No se encontraron registros que coincidan con la busqueda." 
                            GridLines="None" onpageindexchanging="rgreporte_PageIndexChanging" 
                            onrowdatabound="rgutil_RowDataBound" onsorting="rgreporte_Sorting" 
                            PagerStyle-CssClass="pgr" PageSize="20" Width="5000px" DataKeyNames="Id" 
                                onpageindexchanged="rgreporte_PageIndexChanged" 
                                ondatabound="rgreporte_DataBound">
                                <AlternatingRowStyle CssClass="alt" BackColor="#F8FBFE" />
                                <Columns>
                                    <asp:TemplateField Visible = "false">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hk2" runat="server" ImageUrl="~/Img/editar.gif" 
                                            Target="_blank" ToolTip="Editar Item"></asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle HorizontalAlign="Left" />
                                <PagerSettings FirstPageText="Primera" LastPageText="Ultima" 
                                PageButtonCount="30" />
                                <PagerStyle CssClass="pgr" />
                                <SelectedRowStyle BackColor="#FFFF99" />
                            </asp:GridView>--%>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <asp:GridView ID="rgreportexls" runat="server" AlternatingRowStyle-CssClass="alt" CssClass="mGrid" 
    EmptyDataText="No se encontraron registros que coincidan con la busqueda." 
    PagerStyle-CssClass="pgr">
        <AlternatingRowStyle BackColor="#F8FBFE" />
        <HeaderStyle HorizontalAlign="Left" />
        <PagerSettings FirstPageText="Primera" LastPageText="Ultima" PageButtonCount="30" />
        <PagerStyle CssClass="pgr" />
        <SelectedRowStyle BackColor="#FFFF99" />
    </asp:GridView>
    </asp:Panel>
    <uc2:messbox ID="messbox1" runat="server" />
    </asp:Content>




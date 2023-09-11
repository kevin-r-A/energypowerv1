<%@ Page Title="" Language="C#" MasterPageFile="~/Site/Activos/cay.master" AutoEventWireup="true" CodeFile="RepoPer.aspx.cs" Inherits="RepoPer" EnableEventValidation="false" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register src="../../Ctrl/Wait/wait.ascx" tagname="wait" tagprefix="uc1" %>
<%@ Register src="../../Ctrl/Msg/messbox.ascx" tagname="messbox" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <uc1:wait ID="wait1" runat="server"/>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="cph1">
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
<table cellspacing="0" class="style1">
<tr>
<td class="aatl" width="27%">
<div class="divv">
<asp:UpdatePanel ID="upFiltro" runat="server" UpdateMode="Conditional">
<ContentTemplate>
<table cellpadding="2" cellspacing="0" class="style1">
<tr>
    <td width="70">
        &nbsp;
    </td>
    <td class="aatl">
        <asp:CheckBox ID="chk1" runat="server" AutoPostBack="True" Checked="True"
                      oncheckedchanged="chk1_CheckedChanged" Text="Habilitar Dependencias"/>
    </td>
</tr>
<tr>
    <td>
        Tipo:
    </td>
    <td>
        <asp:DropDownList ID="ddtipoitem" runat="server" CssClass="txtdd" Width="100%">
        </asp:DropDownList>
        <asp:CascadingDropDown ID="cddtipoitem" runat="server"
                               Category="tip" Enabled="True" LoadingText="[Cargando Tipos...]"
                               PromptText="• Todos •" ServiceMethod="GetTipoItem" ServicePath="ws.asmx"
                               TargetControlID="ddtipoitem">
        </asp:CascadingDropDown>
    </td>
</tr>
<tr>
    <td>
        Grupo/Cta:
    </td>
    <td>
        <asp:DropDownList ID="ddGrupo" runat="server" CssClass="txtdd" Width="100%">
        </asp:DropDownList>
        <asp:CascadingDropDown ID="cddgru1" runat="server" Category="gru1"
                               Enabled="True" LoadingText="[Cargando Grupo...]" PromptText="• Todos •"
                               ServiceMethod="GetGru1" ServicePath="ws.asmx" TargetControlID="ddGrupo">
        </asp:CascadingDropDown>
    </td>
</tr>
<tr>
    <td>
        Subgrupo:
    </td>
    <td>
        <asp:DropDownList ID="ddSubgrupo" runat="server" CssClass="txtdd" Width="100%">
        </asp:DropDownList>
        <asp:CascadingDropDown ID="cddgru2" runat="server" Category="gru2"
                               Enabled="True" LoadingText="[Cargando Subgrupo...]" ParentControlID="ddGrupo"
                               PromptText="• Todos •" ServiceMethod="GetGru2" ServicePath="ws.asmx"
                               TargetControlID="ddSubgrupo">
        </asp:CascadingDropDown>
    </td>
</tr>
<tr>
    <td>
        Descripción:
    </td>
    <td>
        <asp:DropDownList ID="ddDescripcion" runat="server" CssClass="txtdd"
                          Width="100%">
        </asp:DropDownList>
        <asp:CascadingDropDown ID="cddDescrip" runat="server" Category="gru3"
                               Enabled="True" LoadingText="[Cargando Descripción...]"
                               ParentControlID="ddSubgrupo" PromptText="• Todos •" ServiceMethod="GetGru3"
                               ServicePath="ws.asmx" TargetControlID="ddDescripcion">
        </asp:CascadingDropDown>
    </td>
</tr>
<tr>
    <td>
        Ub. Geo1:
    </td>
    <td>
        <asp:DropDownList ID="ddUge1" runat="server" CssClass="txtdd" Width="100%">
        </asp:DropDownList>
        <asp:CascadingDropDown ID="cddgeo1" runat="server" Category="uge1"
                               Enabled="True" LoadingText="[Cargando Geo1...]" PromptText="• Todos •"
                               ServiceMethod="GetUge1" ServicePath="ws.asmx" TargetControlID="ddUge1">
        </asp:CascadingDropDown>
    </td>
</tr>
<tr>
    <td>
        Ub. Geo2:
    </td>
    <td>
        <asp:DropDownList ID="ddUge2" runat="server" CssClass="txtdd" Width="100%">
        </asp:DropDownList>
        <asp:CascadingDropDown ID="cddgeo2" runat="server" Category="uge2"
                               Enabled="True" LoadingText="[Cargando Geo2...]" ParentControlID="ddUge1"
                               PromptText="• Todos •" ServiceMethod="GetUge2" ServicePath="ws.asmx"
                               TargetControlID="ddUge2">
        </asp:CascadingDropDown>
    </td>
</tr>
<tr>
    <td>
        Ub. Geo3:
    </td>
    <td>
        <asp:DropDownList ID="ddUge3" runat="server" CssClass="txtdd" Width="100%">
        </asp:DropDownList>
        <asp:CascadingDropDown ID="cddgeo3" runat="server" Category="uge3"
                               Enabled="True" LoadingText="[Cargando Geo3...]" ParentControlID="ddUge2"
                               PromptText="• Todos •" ServiceMethod="GetUge3" ServicePath="ws.asmx"
                               TargetControlID="ddUge3">
        </asp:CascadingDropDown>
    </td>
</tr>
<tr>
    <td>
        Piso/Nivel:
    </td>
    <td>
        <asp:DropDownList ID="ddPiso" runat="server" CssClass="txtdd" Width="175px">
        </asp:DropDownList>
        <asp:CascadingDropDown ID="cddpiso" runat="server" Category="pis_id"
                               Enabled="True" LoadingText="[Cargando Piso...]" ParentControlID="ddUge3"
                               PromptText="• Todos •" ServiceMethod="GetUge4" ServicePath="ws.asmx"
                               TargetControlID="ddPiso">
        </asp:CascadingDropDown>
    </td>
</tr>
<tr>
    <td>
        Cent.Costo:
    </td>
    <td>
        <asp:DropDownList ID="ddCcosto" runat="server" CssClass="txtdd" Width="100%">
        </asp:DropDownList>
        <asp:CascadingDropDown ID="cddccosto" runat="server" Category="cco"
                               Enabled="True" LoadingText="[Cargando Centro de Costo...]"
                               ParentControlID="ddUge2" PromptText="• Todos •" ServiceMethod="GetCcostoUge2"
                               ServicePath="ws.asmx" TargetControlID="ddCcosto">
        </asp:CascadingDropDown>
    </td>
</tr>
<tr>
    <td>
        Ub. Org1:
    </td>
    <td>
        <asp:DropDownList ID="ddUor1" runat="server" CssClass="txtdd" Width="100%">
        </asp:DropDownList>
        <asp:CascadingDropDown ID="cdduor1" runat="server" Category="uor1"
                               Enabled="True" LoadingText="[Cargando Dep1...]" ParentControlID="ddCcosto"
                               PromptText="• Todos •" ServiceMethod="GetUor1Cco" ServicePath="ws.asmx"
                               TargetControlID="ddUor1">
        </asp:CascadingDropDown>
    </td>
</tr>
<tr>
    <td>
        Ub. Org2:
    </td>
    <td>
        <asp:DropDownList ID="ddUor2" runat="server" CssClass="txtdd" Width="100%">
        </asp:DropDownList>
        <asp:CascadingDropDown ID="cdduor2" runat="server" Category="uor2"
                               Enabled="True" LoadingText="[Cargando Dep2...]" ParentControlID="ddUor1"
                               PromptText="• Todos •" ServiceMethod="GetUor2" ServicePath="ws.asmx"
                               TargetControlID="ddUor2">
        </asp:CascadingDropDown>
    </td>
</tr>
<tr>
    <td>
        Custodio:
    </td>
    <td>
        <asp:DropDownList ID="ddCustodio" runat="server" CssClass="txtdd" Width="100%">
        </asp:DropDownList>
        <asp:CascadingDropDown ID="cddcus" runat="server" Category="cus" ContextKey=""
                               Enabled="True" LoadingText="[Cargando Custodios...]" ParentControlID="ddUor1"
                               PromptText="• Todos •" ServiceMethod="GetCusUor1" ServicePath="ws.asmx"
                               TargetControlID="ddCustodio">
        </asp:CascadingDropDown>
    </td>
</tr>
<tr>
    <td>
        Estado:
    </td>
    <td>
        <asp:DropDownList ID="ddEstado" runat="server" CssClass="txtdd" Width="110px">
        </asp:DropDownList>
        <asp:CascadingDropDown ID="cddest1" runat="server" Category="est1"
                               ContextKey="1" Enabled="True" LoadingText="[Cargando Estado 1...]"
                               PromptText="• Todos •" ServiceMethod="GetEstado" ServicePath="ws.asmx"
                               TargetControlID="ddEstado">
        </asp:CascadingDropDown>
    </td>
</tr>
<tr>
    <td>
        Fase:
    </td>
    <td>
        <asp:DropDownList ID="ddFase" runat="server" CssClass="txtdd" Width="110px">
        </asp:DropDownList>
        <asp:CascadingDropDown ID="cddest2" runat="server" Category="est2"
                               ContextKey="2" Enabled="True" LoadingText="[Cargando Estado 2...]"
                               PromptText="• Todos •" ServiceMethod="GetEstado" ServicePath="ws.asmx"
                               TargetControlID="ddFase">
        </asp:CascadingDropDown>
    </td>
</tr>
<tr>
    <td>
        Transferen.:
    </td>
    <td>
        <asp:DropDownList ID="ddTrasnfer" runat="server" CssClass="txtdd" Width="110px">
        </asp:DropDownList>
        <asp:CascadingDropDown ID="cddest3" runat="server" Category="est3"
                               ContextKey="3" Enabled="True" LoadingText="[Cargando Estado 3...]"
                               PromptText="• Todos •" ServiceMethod="GetEstado" ServicePath="ws.asmx"
                               TargetControlID="ddTrasnfer">
        </asp:CascadingDropDown>
    </td>
</tr>
<tr>
    <td>
        Marca:
    </td>
    <td>
        <asp:DropDownList ID="ddMarca" runat="server" CssClass="txtdd" Width="100%">
        </asp:DropDownList>
        <asp:CascadingDropDown ID="cddmarca" runat="server" Category="marca"
                               Enabled="True" LoadingText="[Cargando Marca...]" PromptText="• Todos •"
                               ServiceMethod="GetMarca" ServicePath="ws.asmx" TargetControlID="ddMarca">
        </asp:CascadingDropDown>
    </td>
</tr>
<tr>
    <td>
        Modelo:
    </td>
    <td>
        <asp:DropDownList ID="ddModelo" runat="server" CssClass="txtdd" Width="100%">
        </asp:DropDownList>
        <asp:CascadingDropDown ID="cddModelo" runat="server" Category="modelo"
                               Enabled="True" LoadingText="[Cargando Modelo...]" ParentControlID="ddMarca"
                               PromptText="• Todos •" ServiceMethod="GetModelo" ServicePath="ws.asmx"
                               TargetControlID="ddModelo">
        </asp:CascadingDropDown>
    </td>
</tr>
<tr>
    <td>
        Proveedor:
    </td>
    <td>
        <asp:DropDownList ID="ddProveedor" runat="server" CssClass="txtdd" Width="100%">
        </asp:DropDownList>
        <asp:CascadingDropDown ID="cddProveedor" runat="server" Category="provee"
                               Enabled="True" LoadingText="[Cargando Proveedor...]" PromptText="• Todos •"
                               ServiceMethod="GetPro" ServicePath="ws.asmx" TargetControlID="ddProveedor">
        </asp:CascadingDropDown>
    </td>
</tr>
<tr>
    <td>
        Ingreso:
    </td>
    <td>
        <asp:DropDownList ID="ddtipoing" runat="server" CssClass="txtdd" Width="100%">
        </asp:DropDownList>
        <asp:CascadingDropDown ID="cddtipoing" runat="server"
                               Category="tiping" Enabled="True" LoadingText="[Cargando Tipos...]"
                               PromptText="• Todos •" ServiceMethod="GetTipoIng" ServicePath="ws.asmx"
                               TargetControlID="ddtipoing">
        </asp:CascadingDropDown>
    </td>
</tr>
<tr>
    <td>
        Garantía:
    </td>
    <td>
        <asp:DropDownList ID="ddgarantia" runat="server" CssClass="txtdd" Width="100%">
            <asp:ListItem Selected="True">• Todos •</asp:ListItem>
            <asp:ListItem Value="1">SI</asp:ListItem>
            <asp:ListItem Value="0">NO</asp:ListItem>
        </asp:DropDownList>
    </td>
</tr>
<tr>
    <td>Seguro:</td>
    <td>
        <asp:DropDownList ID="ddSeguro" runat="server" CssClass="txtdd" Width="75px">
            <asp:ListItem Selected="True">• Todos •</asp:ListItem>
            <asp:ListItem Value="S">SI</asp:ListItem>
            <asp:ListItem Value="N">NO</asp:ListItem>
        </asp:DropDownList>
    </td>
</tr>
</table>
<table cellspacing="1" class="style1">
    <tr>
        <td height="30"></td>
    </tr>
    <tr>
        <td class="aatr" height="36">
            <asp:UpdatePanel ID="upconsult" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:ImageButton ID="ibcancel" runat="server" CausesValidation="False"
                                     Height="28px" ImageUrl="~/Img/d1.png" onclick="ibcancel_Click" Width="102px"/>
                    &nbsp;
                    <asp:ImageButton ID="ibsave" runat="server" Height="28px"
                                     ImageUrl="~/Img/t1.png" onclick="ibsave_Click" Width="102px"/>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
</table>
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
                            <td width="130">
                                <asp:ImageButton ID="ibxls1" runat="server" Height="30px"
                                                 ImageUrl="~/Img/xls1.png" onclick="ibxls1_Click" Width="122px"/>
                            </td>
                            <td>
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
    <asp:Panel ID="panGrid" runat="server" CssClass="panmar6" ScrollBars="Auto">
        <asp:UpdatePanel ID="upgrid" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:GridView ID="rgreporte" runat="server" AllowPaging="True"
                              AllowSorting="True" AlternatingRowStyle-CssClass="alt" CssClass="mGrid"
                              EmptyDataText="No se encontraron registros que coincidan con la busqueda."
                              GridLines="None" onpageindexchanging="rgreporte_PageIndexChanging"
                              onrowdatabound="rgutil_RowDataBound" onsorting="rgreporte_Sorting"
                              PagerStyle-CssClass="pgr" PageSize="18" Width="8000px" DataKeyNames="Id">
                    <AlternatingRowStyle CssClass="alt" BackColor="#F8FBFE"/>
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HyperLink ID="hk2" runat="server" ImageUrl="~/Img/editar.gif"
                                               Target="_blank" ToolTip="Editar Item">
                                </asp:HyperLink>
                                <asp:ImageButton ID="ibpdf1" runat="server" Height="30px"
                                                                                 ImageUrl="~/Img/pdf1.png" OnClick="ibpdf1_Click" Width="112px"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle HorizontalAlign="Left"/>
                    <PagerSettings FirstPageText="Primera" LastPageText="Ultima"
                                   PageButtonCount="30"/>
                    <PagerStyle CssClass="pgr"/>
                    <SelectedRowStyle BackColor="#FFFF99"/>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
</td>
</tr>
</table>
<asp:GridView ID="rgreportexls" runat="server" AlternatingRowStyle-CssClass="alt" CssClass="mGrid"
              EmptyDataText="No se encontraron registros que coincidan con la busqueda."
              PagerStyle-CssClass="pgr" DataKeyNames="Id" OnRowDataBound="rgreportexls_RowDataBound">
    <AlternatingRowStyle BackColor="#F8FBFE"/>
    <HeaderStyle HorizontalAlign="Left"/>
    <PagerSettings FirstPageText="Primera" LastPageText="Ultima" PageButtonCount="30"/>
    <PagerStyle CssClass="pgr"/>
    <SelectedRowStyle BackColor="#FFFF99"/>
</asp:GridView>
<uc2:messbox ID="messbox1" runat="server"/>
</asp:Content>
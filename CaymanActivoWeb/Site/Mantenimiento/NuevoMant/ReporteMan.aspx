<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReporteMan.aspx.cs" Inherits="Site_Mantenimiento_NuevoMant_ReporteMan" %>--%>

<%@ Page Language="C#" MasterPageFile="~/Site/Activos/cay.master" AutoEventWireup="true" CodeFile="ReporteMan.aspx.cs" Inherits="ReporteMan" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Ctrl/Wait/wait.ascx" TagName="wait" TagPrefix="uc1" %>
<%@ Register Src="~/Ctrl/Msg/messbox.ascx" TagName="messbox" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .RadPicker {
            vertical-align: middle;
        }

        .RadPicker {
            vertical-align: middle;
        }

            .RadPicker .rcTable {
                table-layout: auto;
            }

            .RadPicker .rcTable {
                table-layout: auto;
            }

        .style9 {
            height: 27px;
        }

        .style52 {
            width: 102px;
        }

        .style53 {
            width: 103px;
        }

        .style59 {
            width: 100%;
        }

        .style68 {
            width: 111%;
        }

        .RadUpload_Default {
            font: normal 11px/10px "Segoe UI", Arial, sans-serif;
        }

        .RadUpload {
            width: 430px; /*default*/
            text-align: left;
        }

        .RadUpload_Default {
            font: normal 11px/10px "Segoe UI", Arial, sans-serif;
        }

        .RadUpload {
            width: 430px; /*default*/
            text-align: left;
        }

        .RadUpload_Default {
            font: normal 11px/10px "Segoe UI", Arial, sans-serif;
        }

        .RadUpload {
            width: 430px; /*default*/
            text-align: left;
        }

            .RadUpload .ruInputs {
                list-style: none;
                margin: 0;
                padding: 0;
            }

            .RadUpload .ruInputs {
                zoom: 1; /*IE fix - removing items on the client*/
            }

            .RadUpload .ruInputs {
                list-style: none;
                margin: 0;
                padding: 0;
            }

            .RadUpload .ruInputs {
                zoom: 1; /*IE fix - removing items on the client*/
            }

            .RadUpload .ruInputs {
                list-style: none;
                margin: 0;
                padding: 0;
            }

            .RadUpload .ruInputs {
                zoom: 1; /*IE fix - removing items on the client*/
            }

            .RadUpload .ruFileWrap {
                position: relative;
                white-space: nowrap;
                display: inline-block;
                vertical-align: top;
                padding-right: 0.8em;
                line-height: 20px;
                zoom: 1;
            }

            .RadUpload .ruFileWrap {
                position: relative;
                white-space: nowrap;
                display: inline-block;
                vertical-align: top;
                padding-right: 0.8em;
                line-height: 20px;
                zoom: 1;
            }

            .RadUpload .ruFileWrap {
                position: relative;
                white-space: nowrap;
                display: inline-block;
                vertical-align: top;
                padding-right: 0.8em;
                line-height: 20px;
                zoom: 1;
            }

        .RadUpload_Default .ruFakeInput {
            border-color: #abadb3 #dbdfe6 #e3e9ef #e2e3ea;
            color: #333;
        }

        .RadUpload .ruFakeInput {
            height: 16px;
            margin-right: -1px;
            vertical-align: middle;
            background-position: 0 -93px;
            background-repeat: repeat-x;
            background-color: #fff;
            line-height /*\**/: 20px\9; /* IE8 Standards still broken + old hacks don't work */
            height /*\**/: 20px\9;
            padding-top /*\**/: 0\9;
        }

        .RadUpload .ruFakeInput {
            float: none;
            vertical-align: top;
        }

        .RadUpload .ruFakeInput {
            border-width: 1px;
            border-style: solid;
            line-height: 18px;
            padding: 4px 4px 0 4px;
            -moz-box-sizing: content-box; /* Quirksmode height fix */
            -webkit-box-sizing: content-box;
            box-sizing: content-box;
        }

        .RadUpload_Default .ruFakeInput {
            border-color: #abadb3 #dbdfe6 #e3e9ef #e2e3ea;
            color: #333;
        }

        .RadUpload .ruFakeInput {
            height: 16px;
            margin-right: -1px;
            vertical-align: middle;
            background-position: 0 -93px;
            background-repeat: repeat-x;
            background-color: #fff;
            line-height /*\**/: 20px\9; /* IE8 Standards still broken + old hacks don't work */
            height /*\**/: 20px\9;
            padding-top /*\**/: 0\9;
        }

        .RadUpload .ruFakeInput {
            float: none;
            vertical-align: top;
        }

        .RadUpload .ruFakeInput {
            border-width: 1px;
            border-style: solid;
            line-height: 18px;
            padding: 4px 4px 0 4px;
            -moz-box-sizing: content-box; /* Quirksmode height fix */
            -webkit-box-sizing: content-box;
            box-sizing: content-box;
        }

        .RadUpload_Default .ruFakeInput {
            border-color: #abadb3 #dbdfe6 #e3e9ef #e2e3ea;
            color: #333;
        }

        .RadUpload .ruFakeInput {
            height: 16px;
            margin-right: -1px;
            vertical-align: middle;
            background-position: 0 -93px;
            background-repeat: repeat-x;
            background-color: #fff;
            line-height /*\**/: 20px\9; /* IE8 Standards still broken + old hacks don't work */
            height /*\**/: 20px\9;
            padding-top /*\**/: 0\9;
        }

        .RadUpload .ruFakeInput {
            float: none;
            vertical-align: top;
        }

        .RadUpload .ruFakeInput {
            border-width: 1px;
            border-style: solid;
            line-height: 18px;
            padding: 4px 4px 0 4px;
            -moz-box-sizing: content-box; /* Quirksmode height fix */
            -webkit-box-sizing: content-box;
            box-sizing: content-box;
        }

        .RadUpload_Default .ruButton {
            background-image: url('mvwres://Telerik.Web.UI, Version=2011.2.712.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Upload.ruSprite.png');
            color: #000;
        }

        .RadUpload .ruBrowse {
            width: 65px;
            margin-left: 4px;
            background-position: 0 0;
        }

        .RadUpload .ruButton {
            width: 79px;
            height: 22px;
            border: 0;
            padding-bottom: 2px;
            background-position: 0 -23px;
            background-repeat: no-repeat;
            background-color: transparent;
            text-align: center;
        }

        .RadUpload .ruButton {
            float: none;
            vertical-align: top;
        }

        .RadUpload_Default .ruButton {
            background-image: url('mvwres://Telerik.Web.UI, Version=2011.2.712.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Upload.ruSprite.png');
            color: #000;
        }

        .RadUpload .ruBrowse {
            width: 65px;
            margin-left: 4px;
            background-position: 0 0;
        }

        .RadUpload .ruButton {
            width: 79px;
            height: 22px;
            border: 0;
            padding-bottom: 2px;
            background-position: 0 -23px;
            background-repeat: no-repeat;
            background-color: transparent;
            text-align: center;
        }

        .RadUpload .ruButton {
            float: none;
            vertical-align: top;
        }

        .RadUpload_Default .ruButton {
            background-image: url('mvwres://Telerik.Web.UI, Version=2011.2.712.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Upload.ruSprite.png');
            color: #000;
        }

        .RadUpload .ruBrowse {
            width: 65px;
            margin-left: 4px;
            background-position: 0 0;
        }

        .RadUpload .ruButton {
            width: 79px;
            height: 22px;
            border: 0;
            padding-bottom: 2px;
            background-position: 0 -23px;
            background-repeat: no-repeat;
            background-color: transparent;
            text-align: center;
        }

        .RadUpload .ruButton {
            float: none;
            vertical-align: top;
        }

        .style70 {
            width: 275px;
        }

        .style72 {
            width: 79px;
        }

        .style78 {
            width: 518px;
        }

        .style90 {
            width: 58px;
        }

        .style91 {
            height: 27px;
            width: 58px;
        }

        .style97 {
            height: 27px;
            width: 121px;
        }

        .style98 {
            width: 121px;
        }

        .style101 {
            width: 23px;
        }

        .style102 {
            width: 59px;
        }

        .style104 {
            width: 112px;
        }

        .style106 {
            width: 100px;
        }

        .style111 {
            width: 126px;
        }

        .style112 {
            width: 136px;
        }

        .style113 {
            width: 160px;
        }

        .style114 {
            width: 123px;
        }

        .style118 {
            width: 216px;
        }

        .style119 {
            width: 217px;
        }

        .style123 {
            width: 213px;
        }

        .style124 {
            width: 140px;
        }

        .style125 {
            width: 150px;
        }

        .style126 {
            width: 125px;
        }

        .style127 {
            width: 14px;
        }

        .style128 {
            width: 15px;
        }

        .style129 {
            width: 74px;
        }

        .style135 {
            width: 165px;
        }

        .auto-style4 {
            width: 91px;
        }
        .auto-style6 {
            width: 154px;
        }
        .auto-style7 {
            width: 172px;
        }
        .auto-style8 {
            width: 119px;
        }
        .auto-style9 {
            width: 85px;
        }
        .auto-style10 {
            width: 108px;
        }
        .auto-style11 {
            width: 134px;
        }
        .auto-style12 {
            width: 131px;
        }
        .auto-style15 {
            width: 247px;
        }
        .auto-style18 {
            width: 139px;
        }
        .auto-style19 {
            width: 219px;
        }
        .auto-style21 {
            width: 249px;
        }
        .auto-style22 {
            width: 94px;
        }
        .auto-style23 {
            width: 176px;
        }
        .auto-style28 {
            width: 252px;
        }
        .auto-style29 {
            width: 237px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="cph1">
    <script type="text/javascript">

        function cargarutlimatix() {

            API.CodigoUltimatix($("#<%=txtCodUltimatix.ClientID%>").val(), function (result) {

                if (result != null) {
                    for (var index in result) {
                        //alert("ENTRO FOR");

                        $("#<%=lblUltimatix.ClientID%>").val(result[index].nombrecus);
                        $("#<%=txtcodcus.ClientID%>").val(result[index].codcus);

                    }
                }
                else {
                    $("#<%=lblUltimatix.ClientID%>").val("No existe Custodio");
                    $("#<%=txtcodcus.ClientID%>").val("0");
                }

            });


        }

        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }

        function OpenWindows(url) {
            window.open(url, " Reporte Modifica Activo", "directories=no, location=no, menubar=no, scrollbars=yes, statusbar=no, tittlebar=no");
        }

        function KeyPress(sender, args) {
            var regexp = new RegExp("[0-9]{1}|[\b]|\t|\r");
            if (!args.get_keyCharacter().match(regexp))
                args.set_cancel(true);
        }
            </script>
            <asp:Panel ID="panbus" runat="server" CssClass="panmar" GroupingText="Buscar Activo - Mantenimientos">
        <asp:UpdatePanel ID="upBuscar" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td width="100%">
                            <table cellspacing="0" width="100%">
                                <%-- <tr>
                                        <td width="115">&nbsp;</td>
                                    <td width="150">
                                        &nbsp;</td>
                                            <td>&nbsp;</td>
                                    </tr>--%>
                                <tr>
                                    <td colspan="3">
                                        <table class="style1">
                                            <%--<tr>
                                                    <td class="style129">
                                                        &nbsp;</td>
                                                    <td class="style113">
                                                        &nbsp;</td>
                                                    <td class="style135">
                                                        &nbsp;</td>
                                                    <td class="style124">
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
                                                </tr>--%>
                                            <tr>
                                                <td class="auto-style4">
                                                    <h5>Buscar Por:</h5>
                                                </td>
                                                <td class="auto-style7">
                                                    <h5>
                                                        <asp:RadioButton ID="rbCodigoBarras" runat="server" AutoPostBack="True"
                                                            OnCheckedChanged="RadioButton1_CheckedChanged" Text="Código de Barras" />
                                                        &nbsp;<asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="txtbuscb" ErrorMessage="Ingrese Código de Barras" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                                        <asp:ValidatorCalloutExtender ID="rfv1_ValidatorCalloutExtender" runat="server" Enabled="True" PopupPosition="Left" TargetControlID="rfv1">
                                                        </asp:ValidatorCalloutExtender>
                                                    </h5>
                                                </td>
                                                <td class="auto-style6">
                                                    <div class="form-group">
                                                    <telerik:RadTextBox ID="txtbuscb" runat="server" MaxLength="40"
                                                        ValidationGroup="1" Width="147px" CssClass="form-control">
                                                        <ClientEvents OnKeyPress="KeyPress" />
                                                        <EmptyMessageStyle Font-Italic="True" />
                                                    </telerik:RadTextBox>
                                                        </div>
                                                        
                                                </td>
                                                <td valign="top">
                                                    <asp:ImageButton ID="ibbus1" runat="server" CssClass="relo" Height="35px"
                                                        ImageUrl="~/Img/buscarblue.png" OnClick="ibbus1_Click" TabIndex="99"
                                                        ToolTip="Buscar Código de Barras" ValidationGroup="1" Width="35px" />
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style4">&nbsp;</td>
                                                <td class="auto-style7">
                                                    <h5>
                                                        <asp:RadioButton ID="rbSerie" runat="server" Text="Serie" AutoPostBack="True"
                                                            OnCheckedChanged="rbSerie_CheckedChanged" />
                                                        &nbsp;<asp:RequiredFieldValidator ID="rfv25" runat="server" ControlToValidate="txtserie" ErrorMessage="Ingrese Numero de Serie" ForeColor="Red" ValidationGroup="2">*</asp:RequiredFieldValidator>
                                                        <asp:ValidatorCalloutExtender ID="rfv25_ValidatorCalloutExtender" runat="server" Enabled="True" PopupPosition="Left" TargetControlID="rfv25">
                                                        </asp:ValidatorCalloutExtender>
                                                    </h5>
                                                </td>
                                                <td class="auto-style6">
                                                    <div class="form-group">
                                                    <telerik:RadTextBox ID="txtserie" runat="server"
                                                        ValidationGroup="2" Width="147px" CssClass="form-control">

                                                        <EmptyMessageStyle Font-Italic="True" />
                                                    </telerik:RadTextBox>
                                                        </div>
                                                </td>
                                                <td valign="top">
                                                    <asp:ImageButton ID="ibbus4" runat="server" CssClass="relo" Height="35px"
                                                        ImageUrl="~/Img/buscarblue.png" TabIndex="99"
                                                        ToolTip="Buscar Código de Barras" ValidationGroup="2" Width="35px"
                                                        OnClick="ibbus4_Click" />
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style4">&nbsp;</td>
                                                <td class="auto-style7">
                                                    <h5>
                                                        <asp:RadioButton ID="rbCodSecundario" runat="server" Text="Código Secundario"
                                                            AutoPostBack="True" OnCheckedChanged="rbCodSecundario_CheckedChanged" />
                                                        &nbsp;<asp:RequiredFieldValidator ID="rfv26" runat="server"
                                                        ControlToValidate="txtcodSecundario" ErrorMessage="Ingrese Código Secundario"
                                                        ForeColor="Red" ValidationGroup="3">*</asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="rfv26_ValidatorCalloutExtender"
                                                        runat="server" Enabled="True" PopupPosition="Left" TargetControlID="rfv26" Width="40px">
                                                    </asp:ValidatorCalloutExtender>
                                                    </h5>
                                                </td>
                                                <td class="auto-style6">
                                                    <div class="form-group">
                                                    <telerik:RadTextBox ID="txtcodSecundario" runat="server" ValidationGroup="3"
                                                        Width="147px" CssClass="form-control">
                                                        <EmptyMessageStyle Font-Italic="True" />
                                                    </telerik:RadTextBox>
                                                    </div>
                                                </td>
                                                <td valign="top">
                                                    <%--<asp:RequiredFieldValidator ID="rfv26" runat="server" 
                                                            ControlToValidate="ddMarca" ErrorMessage="Seleccione Marca" 
                                                            ForeColor="Red" ValidationGroup="3">*</asp:RequiredFieldValidator>
                                                        <asp:ValidatorCalloutExtender ID="rfv26_ValidatorCalloutExtender" 
                                                            runat="server" Enabled="True" PopupPosition="Left"
                                                            TargetControlID="rfv26">
                                                        </asp:ValidatorCalloutExtender>--%>
                                                        &nbsp;<asp:ImageButton ID="ibbus6" runat="server" CssClass="relo" Height="35px"
                                                            ImageUrl="~/Img/buscarblue.png" TabIndex="99"
                                                            ToolTip="Buscar Código Secundario" ValidationGroup="3" Width="35px"
                                                            OnClick="ibbus6_Click" />
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr style="display: none">
                                                <td class="auto-style4">&nbsp;</td>
                                                <td class="auto-style7">
                                                    <h5>
                                                        <asp:RadioButton ID="rbMarcaModelo" runat="server" AutoPostBack="True"
                                                            OnCheckedChanged="rbMarcaModelo_CheckedChanged" Text="Marca/Modelo" />
                                                    </h5>
                                                </td>
                                                <td class="auto-style6">
                                                    <asp:DropDownList ID="ddMarca" runat="server" CssClass="txtdd" Width="100%">
                                                    </asp:DropDownList>
                                                    <asp:CascadingDropDown ID="cddmarca" runat="server" Category="marca"
                                                        Enabled="True" LoadingText="[Cargando Marca...]" PromptText="• Seleccione •"
                                                        ServiceMethod="GetMarca" ServicePath="ws.asmx" TargetControlID="ddMarca">
                                                    </asp:CascadingDropDown>
                                                </td>
                                                <td class="style124">
                                                    <%--<asp:RequiredFieldValidator ID="rfv26" runat="server" 
                                                            ControlToValidate="ddMarca" ErrorMessage="Seleccione Marca" 
                                                            ForeColor="Red" ValidationGroup="3">*</asp:RequiredFieldValidator>
                                                        <asp:ValidatorCalloutExtender ID="rfv26_ValidatorCalloutExtender" 
                                                            runat="server" Enabled="True" PopupPosition="Left"
                                                            TargetControlID="rfv26">
                                                        </asp:ValidatorCalloutExtender>--%>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr style="display: none">
                                                <td class="auto-style4">&nbsp;</td>
                                                <td class="auto-style7">&nbsp;</td>
                                                <td class="auto-style6">
                                                    <asp:DropDownList ID="ddModelo" runat="server" CssClass="txtdd" Width="100%">
                                                    </asp:DropDownList>
                                                    <asp:CascadingDropDown ID="cddModelo" runat="server" Category="modelo"
                                                        Enabled="True" LoadingText="[Cargando Modelo...]"
                                                        PromptText="• Seleccione •" ServiceMethod="GetModeloTATA" ServicePath="ws.asmx"
                                                        TargetControlID="ddModelo">
                                                    </asp:CascadingDropDown>
                                                </td>
                                                <td class="style124">
                                                    <asp:ImageButton ID="ibbus5" runat="server" CssClass="relo" Height="20px"
                                                        ImageUrl="~/Img/bus.png" TabIndex="99"
                                                        ToolTip="Buscar Marca/Modelo" ValidationGroup="3" Width="20px" OnClick="ibbus5_Click" />
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>

                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">

                                        <telerik:RadGrid ID="rgItems" runat="server" AutoGenerateColumns="False" Visible="false"
                                            CellSpacing="0" GridLines="None">
                                            <MasterTableView>
                                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                                    <HeaderStyle Width="20px" />
                                                </RowIndicatorColumn>
                                                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                                    <HeaderStyle Width="20px" />
                                                </ExpandCollapseColumn>
                                                <Columns>
                                                    <telerik:GridBoundColumn DataField="Código de Barras"
                                                        FilterControlAltText="Filter codbarras column" HeaderText="Código de Barras"
                                                        UniqueName="codbarras">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="N° Serie"
                                                        FilterControlAltText="Filter column1 column" HeaderText="N° Serie"
                                                        UniqueName="column1">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="Marca"
                                                        FilterControlAltText="Filter column2 column" HeaderText="Marca"
                                                        UniqueName="column2">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="Modelo"
                                                        FilterControlAltText="Filter column3 column" HeaderText="Modelo"
                                                        UniqueName="column3">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="Grupo/Cuenta"
                                                        FilterControlAltText="Filter column4 column" HeaderText="Grupo/Cuenta"
                                                        UniqueName="column4">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="Subgrupo"
                                                        FilterControlAltText="Filter column5 column" HeaderText="Subgrupo"
                                                        UniqueName="column5">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="Descripción"
                                                        FilterControlAltText="Filter column6 column" HeaderText="Descripción"
                                                        UniqueName="column6">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="Centro de Costo"
                                                        FilterControlAltText="Filter column7 column" HeaderText="Centro de Costo"
                                                        UniqueName="column7">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="Custodio"
                                                        FilterControlAltText="Filter column8 column" HeaderText="Custodio"
                                                        UniqueName="column8">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="EstadoM"
                                                        FilterControlAltText="Filter column8 column" HeaderText="Estado Mantenimiento"
                                                        UniqueName="column8">
                                                    </telerik:GridBoundColumn>
                                                </Columns>
                                                <EditFormSettings>
                                                    <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                                    </EditColumn>
                                                </EditFormSettings>
                                            </MasterTableView>
                                            <FilterMenu EnableImageSprites="False">
                                            </FilterMenu>
                                            <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                                            </HeaderContextMenu>
                                            <ClientSettings>
                                                <Scrolling AllowScroll="true" />
                                            </ClientSettings>
                                        </telerik:RadGrid>

                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="ibbus1" />
                <asp:PostBackTrigger ControlID="ibbus4" />
                <asp:PostBackTrigger ControlID="ibbus6" />
            </Triggers>
        </asp:UpdatePanel>

    </asp:Panel>


    <asp:Panel ID="Pan_UgeUor" runat="server" GroupingText="Información Técnica y Ubicación" CssClass="panmar">
        <table cellpadding="1" cellspacing="1" class="style1">
            <tr>
                <td class="style4" width="310">
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Img/a2.png" />
                </td>
                <td class="style70">
                    <asp:Image ID="Image3" runat="server" ImageUrl="~/Img/a3.png" />
                </td>
                <td width="310">
                    <asp:Image ID="Image4" runat="server" ImageUrl="~/Img/a4.png" />
                </td>
            </tr>

            <tr>

                <td class="style4" width="310">
                    <asp:Panel ID="PanelTipo" runat="server">
                        <table class="style68">
                            <tr>
                                <td class="auto-style9">Grupo:</td>
                                <td>
                                    <asp:Label ID="lbl_Grupo" runat="server" Font-Bold="True"
                                        Font-Names="Century Gothic" Text="[Grupo]"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style9">Subgrupo:</td>
                                <td>
                                    <asp:Label ID="lbl_Subgrupo" runat="server" Font-Bold="True"
                                        Font-Names="Century Gothic" Text="[SubGrupo]"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style9">Descripción:</td>
                                <td>
                                    <asp:Label ID="lbl_Descripcion" runat="server" Font-Bold="True"
                                        Font-Names="Century Gothic" Text="[Descripcion]"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>

                <td class="style70">
                    <asp:Panel ID="Panel_Ubi" runat="server" Width="351px">
                        <table width="100%">

                            <tr>
                                <td class="auto-style8">Ub. Geográfica 1:</td>
                                <td>
                                    <asp:Label ID="lbl_UbGeo1" runat="server" Text="[Ubicación Geografica 1]"
                                        Font-Bold="True" Font-Names="Century Gothic"></asp:Label>
                                </td>
                            </tr>

                            <tr>
                                <td class="auto-style8">Ub. Geográfica 2:</td>
                                <td>
                                    <asp:Label ID="lbl_UbiGeo2" runat="server" Text="[Ubicación Geografica 2]"
                                        Font-Bold="True" Font-Names="Century Gothic"></asp:Label>
                                </td>
                            </tr>

                            <tr>
                                <td class="auto-style8">Ub. Geográfica 3:</td>
                                <td>
                                    <asp:Label ID="lbl_UbiGeo3" runat="server" Text="[Ubicación Geografica 3]"
                                        Font-Bold="True" Font-Names="Century Gothic"></asp:Label>
                                </td>
                            </tr>
                        </table>

                    </asp:Panel>


                </td>



                <td class="style4" width="310">
                    <asp:Panel ID="PanelUbiOrg" runat="server" Width="323px">
                        <table width="100%">
                            <tr>
                                <td class="auto-style10">Ubi. Orgánica 1:</td>
                                <td>
                                    <asp:Label ID="lbl_ceCosto" runat="server" Text="[Ubi. Orgnanica1]"
                                        Font-Bold="True" Font-Names="Century Gothic"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style10">Ubi. Orgánica 2:</td>
                                <td>
                                    <asp:Label ID="lbl_UbiOrg" runat="server" Text="[Ubi. Organica 2]"
                                        Font-Bold="True" Font-Names="Century Gothic"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style10">Custodio:</td>
                                <td>
                                    <asp:Label ID="lbl_custodio" runat="server" Text="[Custodio]" Font-Bold="True"
                                        Font-Names="Century Gothic"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>

        </table>
    </asp:Panel>
    <asp:Panel ID="pnl_Mantenimiento" runat="server"
        GroupingText="Datos Mantenimiento" CssClass="panmar" Font-Bold="False">
        <br />




        <table width="100%">
            <tr>
                <td>
                    <table class="style59">
                        <tr>
                            <td class="style128">&nbsp;</td>
                            <td class="style101">Id:</td>
                            <td class="style102">
                                <asp:Label ID="lblid" runat="server"></asp:Label>
                            </td>
                            <td class="auto-style12">Código de Barras:</td>
                            <td class="style111">
                                <asp:Label ID="lblCodBarras" runat="server"></asp:Label>
                            </td>
                            <td class="style111">Valor de Compra:</td>
                            <td>
                                <asp:Label ID="lblValorCompra" runat="server" Font-Bold="True"
                                    ForeColor="#CC3300"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
                <td class="style90">
                    <asp:Label ID="lblCodEmpresa" runat="server" Visible="false"></asp:Label>
                </td>
                <td class="style98">&nbsp;</td>
                <td>
                    <asp:Label ID="lblTipo" runat="server" Visible="false"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblCus" runat="server" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <table width="100%">
                        <tr>
                            <td class="style127">&nbsp;</td>
                            <td class="auto-style11" valign="bottom">Tipo Mantenimiento:</td>
                            <td valign="bottom">
                                <br />
                                <asp:CheckBoxList ID="chboxTipoMant" runat="server" AutoPostBack="True"
                                    Font-Bold="True" OnSelectedIndexChanged="chboxTipoMant_SelectedIndexChanged"
                                    RepeatDirection="Horizontal" Width="25%">
                                    <asp:ListItem Value="1">Correctivo</asp:ListItem>
                                    <asp:ListItem Value="2">Preventivo</asp:ListItem>
                                </asp:CheckBoxList>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID="panFechaMantCorrect" runat="server" CssClass="panmar"
                        GroupingText="Mantenimiento Correctivo" Visible="false">
                        <asp:UpdatePanel ID="upFechaMantCorrect" runat="server"
                            UpdateMode="Conditional">
                            <ContentTemplate>
                                <table width="100%">
                                    <tr>
                                        <td class="auto-style15">&nbsp;</td>
                                        <td class="style78">&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <table width="100%">
                                                <tr>
                                                    <td class="auto-style29">Fecha de Envío:<asp:RequiredFieldValidator ID="rfv24" runat="server"
                                                        ControlToValidate="dp_FechaRealizacion"
                                                        ErrorMessage="Ingrese Fecha de Envio" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                                        <asp:ValidatorCalloutExtender ID="rfv24_ValidatorCalloutExtender"
                                                            runat="server" Enabled="True"
                                                            TargetControlID="rfv24">
                                                        </asp:ValidatorCalloutExtender>
                                                    </td>
                                                    <td class="auto-style19">
                                                        <%--<telerik:RadDatePicker ID="dp_FechaRealizacion" Runat="server" 
                                                                                                                EnableTyping="False" MaxDate="2050-01-01" MinDate="1900-01-01" Width="120px">
                                                                                                                <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" 
                                                                                                                    ViewSelectorText="x">
                                                                                                                </Calendar>
                                                                                                                <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" 
                                                                                                                    ReadOnly="True">
                                                                                                                </DateInput>
                                                                                                                <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                                                                            </telerik:RadDatePicker>--%>
                                                        <asp:TextBox ID="dp_FechaRealizacion" runat="server" CssClass="form-control" Width="90%"></asp:TextBox>
                                                        <br />
                                                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="dp_FechaRealizacion">
                                                        </asp:CalendarExtender>
                                                    </td>
                                                    <td class="auto-style18">Fecha de Devolución:<%--<asp:RequiredFieldValidator ID="rfv25" runat="server" 
                                                                                                                ControlToValidate="dp_FechaRealizacion" 
                                                                                                                ErrorMessage="Ingrese Fecha Realización" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>--%><%--<asp:ValidatorCalloutExtender ID="rfv25_ValidatorCalloutExtender" 
                                                                                                                runat="server" Enabled="True" PopupPosition="BottomRight" 
                                                                                                                TargetControlID="rfv25">
                                                                                                            </asp:ValidatorCalloutExtender>--%></td>
                                                    <td>
                                                        <%--<telerik:RadDatePicker ID="dp_FechaReIngreso" Runat="server" 
                                                                                                                EnableTyping="False" MaxDate="2050-01-01" MinDate="1900-01-01" Width="120px">
                                                                                                                <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" 
                                                                                                                    ViewSelectorText="x">
                                                                                                                </Calendar>
                                                                                                                <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" 
                                                                                                                    ReadOnly="True">
                                                                                                                </DateInput>
                                                                                                                <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                                                                            </telerik:RadDatePicker>--%>
                                                        <asp:TextBox ID="dp_FechaReIngreso" runat="server" CssClass="form-control" Width="53%"></asp:TextBox>
                                                        <br />
                                                        <asp:CalendarExtender ID="fecha" runat="server" TargetControlID="dp_FechaReIngreso">
                                                        </asp:CalendarExtender>
                                                    </td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style15">Mantenimiento Correctivo Realizado:<asp:RequiredFieldValidator ID="rfv9"
                                            runat="server" ControlToValidate="txtDescripMantCorrectivo"
                                            ErrorMessage="Ingrese Mantenimiento Correctivo" ForeColor="Red"
                                            ValidationGroup="1">*</asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="rfv9_ValidatorCalloutExtender" runat="server"
                                                Enabled="True" PopupPosition="BottomRight" TargetControlID="rfv9">
                                            </asp:ValidatorCalloutExtender>
                                        </td>
                                        <td colspan="2">
                                            <div class="form-group">
                                            <asp:TextBox ID="txtDescripMantCorrectivo" runat="server" Height="62px"
                                                TextMode="MultiLine" Width="74%" CssClass="form-control"></asp:TextBox>
                                                </div>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:Panel>
                </td>
                <td class="style91">&nbsp;</td>
                <td class="style97">&nbsp;</td>
                <td class="style9">&nbsp;</td>
                <td class="style9">&nbsp;</td>
            </tr>
            <tr>
                <td class="style9">
                    <asp:Panel ID="panFechaProx" runat="server" Visible="false"
                        GroupingText="Mantenimiento Preventivo" CssClass="panmar">
                        <asp:UpdatePanel ID="upFechaProx" runat="server"
                            UpdateMode="Conditional">
                            <ContentTemplate>
                                <table width="100%">
                                    <tr>
                                        <td class="auto-style21">
                                            Fecha de Mantenimiento:
                                        </td>
                                        <td>
                                            <table class="style59">
                                                <tr>
                                                    <td class="auto-style22">
                                                        <%--<telerik:RadDatePicker ID="dp_ProxMantIni" Runat="server" EnableTyping="False" 
                                                                                                                MaxDate="2050-01-01" MinDate="1900-01-01" Width="120px">
                                                                                                                <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" 
                                                                                                                    ViewSelectorText="x">
                                                                                                                </Calendar>
                                                                                                                <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" 
                                                                                                                    ReadOnly="True">
                                                                                                                </DateInput>
                                                                                                                <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                                                                            </telerik:RadDatePicker>--%>
                                                        <asp:Label ID="lblFechaIniMant" runat="server" Text="Label"></asp:Label>
                                                    </td>
                                                    <td class="auto-style23">Fecha Real Mantenimiento:</td>
                                                    <td class="style114">
                                                        <telerik:RadDatePicker ID="dp_FechaRealMant" runat="server" Enabled="false"
                                                            EnableTyping="False" MaxDate="2050-01-01" MinDate="1900-01-01" Width="120px">
                                                            <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                                                ViewSelectorText="x">
                                                            </Calendar>
                                                            <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy"
                                                                ReadOnly="True">
                                                            </DateInput>
                                                            <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                        </telerik:RadDatePicker>
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="chboxFechaRealMant" runat="server" AutoPostBack="True"
                                                            OnCheckedChanged="chboxFechaRealMant_CheckedChanged"
                                                            Text="Mantenimiento Preventivo" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style21">Fecha Próximo Mantenimiento:<%--<asp:RequiredFieldValidator ID="rfv16" 
                                                                                                    runat="server" ControlToValidate="dp_ProxMant" 
                                                                                                    ErrorMessage="Ingrese Fecha Prox. Mantenimiento" ForeColor="Red" 
                                                                                                    ValidationGroup="1">*</asp:RequiredFieldValidator>
                                                                                                <asp:ValidatorCalloutExtender ID="rfv16_ValidatorCalloutExtender" 
                                                                                                    runat="server" Enabled="True" PopupPosition="BottomRight" 
                                                                                                    TargetControlID="rfv16">
                                                                                                </asp:ValidatorCalloutExtender>--%></td>
                                        <td>
                                            <%--<telerik:RadDatePicker ID="dp_ProxMant" Runat="server" EnableTyping="False" 
                                                                                                    MaxDate="2050-01-01" MinDate="1900-01-01" Width="120px">
                                                                                                    <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" 
                                                                                                        ViewSelectorText="x">
                                                                                                    </Calendar>
                                                                                                    <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" 
                                                                                                        ReadOnly="True">
                                                                                                    </DateInput>
                                                                                                    <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                                                                </telerik:RadDatePicker>--%>&nbsp; <asp:Label ID="lblFechaFinMant" runat="server"
                                                                                                    Font-Bold="True" Font-Names="Century Gothic" ForeColor="#CC3300" Text="Label"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style21">Mantenimiento Preventivo Realizado:</td>
                                        <td>
                                            <div class="form-group">
                                                &nbsp;&nbsp;
                                            <asp:TextBox ID="txtDescripMantPreventivo" runat="server" Height="62px"
                                                TextMode="MultiLine" Width="74%" CssClass="form-control"></asp:TextBox>
                                                </div>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:Panel>
                </td>
                <td class="style91">&nbsp;</td>
                <td class="style97">&nbsp;</td>
                <td class="style9">&nbsp;</td>
                <td class="style9">&nbsp;</td>
            </tr>
            <tr>
                <td class="style9">
                    <asp:Panel ID="panValores" runat="server" CssClass="panmar" GroupingText="Adicionales y Datos del Acta">
                        <table class="style59">
                            <tr>
                                <td class="auto-style28">Valor Mantenimiento:<asp:RequiredFieldValidator ID="rfv23" runat="server"
                                    ControlToValidate="txtvalorMant" ErrorMessage="Ingrese Valor Mantenimiento"
                                    ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="rfv23_ValidatorCalloutExtender"
                                        runat="server" Enabled="True" PopupPosition="BottomRight"
                                        TargetControlID="rfv23">
                                    </asp:ValidatorCalloutExtender>
                                </td>
                                <td>
                                    <div class="form-group">
                                    <telerik:RadNumericTextBox ID="txtvalorMant" runat="server" Culture="en-US"
                                        EmptyMessage="Ingrese Valor" MaxValue="999999999" MinValue="0.00"
                                        Type="Currency" Value="0" Width="119px" CssClass="form-control">
                                        <NumberFormat GroupSeparator="" />
                                        <EmptyMessageStyle Font-Italic="True" />
                                    </telerik:RadNumericTextBox>
                                        </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style28">Documento Adjunto:</td>
                                <td>
                                    <div class="form-group">
                                    <telerik:RadAsyncUpload ID="rau3" runat="server" Culture="en-US" InputSize="15"
                                        MaxFileInputsCount="1" OnFileUploaded="rau3_FileUploaded"
                                        TargetFolder="~/Site/Activos/imgact" Width="259px">
                                        <Localization Cancel="Cancelar" Remove="Eliminar" Select="Buscar" />
                                    </telerik:RadAsyncUpload>
                                        </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style28">Observaciones:</td>
                                <td>
                                    <div class="form-group">
                                    <asp:TextBox ID="txtObs" runat="server" Height="62px" TextMode="MultiLine" CssClass="form-control"
                                        Width="74%"></asp:TextBox>
                                        </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style28">Proveedor:<asp:RequiredFieldValidator ID="rfvProv" runat="server"
                                    ControlToValidate="ddProveedor" ErrorMessage="Seleccione Proveedor"
                                    ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server"
                                        Enabled="True" TargetControlID="rfvProv">
                                    </asp:ValidatorCalloutExtender>
                                </td>
                                <td>
                                    <div class="form-group">
                                    <asp:DropDownList ID="ddProveedor" runat="server" CssClass="txtdd" Width="40%">
                                    </asp:DropDownList>
                                    <asp:CascadingDropDown ID="cddProveedor" runat="server" Category="provee"
                                        Enabled="True" LoadingText="[Cargando Proveedor...]"
                                        PromptText="• Seleccione •" ServiceMethod="GetPro" ServicePath="ws.asmx"
                                        TargetControlID="ddProveedor">
                                    </asp:CascadingDropDown>
                                        </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style28">Ciudad:
                                                                                    <asp:RequiredFieldValidator ID="rfvciudad0" runat="server"
                                                                                        ControlToValidate="ddCiudad" ErrorMessage="Seleccione Ciudad" ForeColor="Red"
                                                                                        ValidationGroup="1">*</asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="rfvciudad0_ValidatorCalloutExtender"
                                        runat="server" Enabled="True" TargetControlID="rfvciudad0">
                                    </asp:ValidatorCalloutExtender>
                                </td>
                                <td>
                                    <div class="form-group">
                                    <asp:DropDownList ID="ddCiudad" runat="server" CssClass="txtdd" Width="40%">
                                    </asp:DropDownList>
                                    <asp:CascadingDropDown ID="cddCiudad" runat="server" Category="uge1"
                                        Enabled="True" LoadingText="[Cargando Ciudad...]" PromptText="• Seleccione •"
                                        ServiceMethod="GetCiudadTATA" ServicePath="ws.asmx" TargetControlID="ddCiudad">
                                    </asp:CascadingDropDown>
                                        </div>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
                <td class="style91">&nbsp;</td>
                <td class="style97">&nbsp;</td>
                <td class="style9">&nbsp;</td>
                <td class="style9">&nbsp;</td>
            </tr>
            <tr>
                <td class="style9">
                    <asp:Panel ID="panDatosActa" runat="server" CssClass="panmar" GroupingText="Datos Acta" Visible="false">
                        <table class="style59">
                            <tr>
                                <td class="style119">Guia de Remision:<asp:RequiredFieldValidator ID="rfvGuiaRem" runat="server"
                                    ControlToValidate="txtGuiaRemision" ErrorMessage="Ingrese Guia de Remisión"
                                    ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="rfvProv0_ValidatorCalloutExtender"
                                        runat="server" Enabled="True"
                                        TargetControlID="rfvGuiaRem">
                                    </asp:ValidatorCalloutExtender>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtGuiaRemision" runat="server" ValidationGroup="1"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style119">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style119">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style119">Ultimatix Custodio Transitorio:</td>
                                <td>
                                    <input id="txtCodUltimatix" runat="server" onkeyup="cargarutlimatix()" />
                                    <input id="txtcodcus" runat="server" type="text" class="style35" style="display: none" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style119">&nbsp;</td>
                                <td>
                                    <input id="lblUltimatix" runat="server"
                                        readonly style="font-weight: bold; font-family: Century Gothic; width: 74%" type="text" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style119">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
                <td class="style91">&nbsp;</td>
                <td class="style97">&nbsp;</td>
                <td class="style9">&nbsp;</td>
                <td class="style9">&nbsp;</td>
            </tr>
        </table>

    </asp:Panel>
    <asp:Panel ID="pantras" runat="server" CssClass="panmar"
        GroupingText="Reporte de Mantenimiento" Visible="False">
        <table cellspacing="0" width="100%">
            <tr>
                <td>
                    <table class="style59">
                        <%--<tr>
                            <td class="style60">
                                Ultimo Mantenimiento:</td>
                            <td>
                                <asp:Label ID="lblUltMantenimiento" runat="server" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>--%>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID="panReporte" runat="server" ScrollBars="Both" Font-Names="Century Gothic">
                        <asp:UpdatePanel ID="upman" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <telerik:RadGrid ID="rgtras" runat="server" AllowPaging="false"
                                                AutoGenerateColumns="False" CellSpacing="0" Culture="en-US" GridLines="None"
                                                Width="100%" Height="400px" Font-Names="Century Gothic">
                                                <GroupingSettings CollapseTooltip="Juntar Grupo" ExpandTooltip="Expandir Grupo"
                                                    GroupContinuedFormatString="... el grupo continúa de la página anterior."
                                                    GroupContinuesFormatString="El grupo continúa en la siguiente página"
                                                    GroupSplitDisplayFormat="Mostrando {0} de {1} items."
                                                    UnGroupButtonTooltip="Click aquí para desagrupar" UnGroupTooltip="" />
                                                <HierarchySettings CollapseTooltip="Agrupar" ExpandTooltip="Expandir" />
                                                <ExportSettings FileName="CaymanFile">
                                                    <Pdf PageHeight="297mm" PageWidth="210mm" PaperSize="A4" />
                                                </ExportSettings>
                                                <ClientSettings>
                                                    <Selecting AllowRowSelect="True" />
                                                    <%--<Scrolling AllowScroll="True" UseStaticHeaders="True" />--%>
                                                </ClientSettings>
                                                <GroupPanel Text="Arrastre el encabezado de una columna aquí para agrupar los items por esa columna">
                                                </GroupPanel>
                                                <MasterTableView AllowFilteringByColumn="False" AllowSorting="False"
                                                    AutoGenerateColumns="True"
                                                    NoDetailRecordsText="No hay registros hijos para mostrar."
                                                    NoMasterRecordsText="No hay registros para mostrar." PageSize="25"
                                                    Font-Names="Arial Narrow" Font-Size="9pt">
                                                    <CommandItemSettings AddNewRecordText="Agregar Registro"
                                                        ExportToCsvText="Exportar a CSV" ExportToExcelText="Exportar a Excel"
                                                        ExportToPdfText="Exportar a PDF" ExportToWordText="Exportar a Word"
                                                        ShowExportToExcelButton="True" ShowExportToPdfButton="True"
                                                        ShowExportToWordButton="True" />
                                                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                                    </RowIndicatorColumn>
                                                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                                    </ExpandCollapseColumn>
                                                    <EditFormSettings>
                                                        <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                                        </EditColumn>
                                                    </EditFormSettings>
                                                    <ItemStyle Font-Names="Arial Narrow" Font-Size="9pt" />
                                                    <AlternatingItemStyle Font-Names="Arial Narrow" Font-Size="9pt" />
                                                    <PagerStyle AlwaysVisible="True" FirstPageToolTip="Primera Página"
                                                        HorizontalAlign="Left" LastPageToolTip="Última Página"
                                                        NextPagesToolTip="Siguientes Páginas" NextPageToolTip="Siguiente Página"
                                                        PagerTextFormat="Cambiar Página: {4} &amp;nbsp;Página &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;, items &lt;strong&gt;{2}&lt;/strong&gt; al &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;."
                                                        PageSizeLabelText="Registros por Página:" Position="Bottom"
                                                        PrevPagesToolTip="Páginas Anteriores" PrevPageToolTip="Página Anterior" />
                                                    <HeaderStyle Font-Names="Arial Narrow" Font-Size="9pt" />


                                                </MasterTableView>
                                                <PagerStyle AlwaysVisible="True" FirstPageToolTip="Primera Página"
                                                    LastPageToolTip="Última Página" NextPagesToolTip="Siguientes Páginas"
                                                    NextPageToolTip="Siguiente Página"
                                                    PagerTextFormat="Cambiar Página: {4} &amp;nbsp;Página &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;, items &lt;strong&gt;{2}&lt;/strong&gt; al &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;."
                                                    PageSizeLabelText="Registros por Página:" PrevPagesToolTip="Páginas Anteriores"
                                                    PrevPageToolTip="Página Anterior" />
                                                <StatusBarSettings LoadingText="Cargando..." ReadyText="Listo" />
                                                <FilterMenu EnableImageSprites="False">
                                                </FilterMenu>
                                                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                                                </HeaderContextMenu>
                                            </telerik:RadGrid>
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
    <br />
    <br />
    <asp:Panel ID="panCommand" runat="server" CssClass="aabrpan"
        Height="33px" Width="100%">
        <div class="panmar3">
            <asp:ImageButton ID="ibcancel" runat="server" CausesValidation="False"
                Height="28px" ImageUrl="~/Img/c1.png" Width="102px"
                OnClick="ibcancel_Click" />
            &nbsp;<asp:ImageButton ID="ibsave" runat="server" Height="28px"
                ImageUrl="~/Img/s1.png" Width="102px" OnClick="ibsave_Click" ValidationGroup="1" />
            &nbsp;
        </div>
    </asp:Panel>
    <asp:AlwaysVisibleControlExtender ID="avcePanCommand" runat="server"
        Enabled="True" TargetControlID="panCommand" VerticalSide="Bottom">
    </asp:AlwaysVisibleControlExtender>
    <uc2:messbox ID="messbox1" runat="server" />
    <asp:ValidationSummary ID="vs" runat="server" ShowMessageBox="True"
        ShowSummary="False" />
</asp:Content>
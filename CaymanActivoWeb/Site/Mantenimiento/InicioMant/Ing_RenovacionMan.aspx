<%@ Page Language="C#" MasterPageFile="~/Site/Activos/cay.master" AutoEventWireup="true" CodeFile="Ing_RenovacionMan.aspx.cs" Inherits="Ing_RenovacionMan" EnableEventValidation="false" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register src="~/Ctrl/Wait/wait.ascx" tagname="wait" tagprefix="uc1" %>
<%@ Register src="~/Ctrl/Msg/messbox.ascx" tagname="messbox" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
                    
.RadPicker
{
	vertical-align:middle;
}

.RadPicker
{
	vertical-align:middle;
}

.RadPicker .rcTable
{
	table-layout:auto;
}

.RadPicker .rcTable
{
	table-layout:auto;
}

        .style52
        {
            width: 102px;
        }
        .style53
        {
            width: 103px;
        }
        .style68
        {
            width: 111%;
        }

.RadUpload_Default
{
    font: normal 11px/10px "Segoe UI", Arial, sans-serif;
}

.RadUpload
{
	width: 430px; /*default*/
	text-align: left;
}

.RadUpload_Default
{
    font: normal 11px/10px "Segoe UI", Arial, sans-serif;
}

.RadUpload
{
	width: 430px; /*default*/
	text-align: left;
}

.RadUpload_Default
{
    font: normal 11px/10px "Segoe UI", Arial, sans-serif;
}

.RadUpload
{
	width: 430px; /*default*/
	text-align: left;
}

.RadUpload .ruInputs
{
	list-style:none;
	margin:0;
	padding:0;
}

.RadUpload .ruInputs
{
	zoom:1;/*IE fix - removing items on the client*/
}

.RadUpload .ruInputs
{
	list-style:none;
	margin:0;
	padding:0;
}

.RadUpload .ruInputs
{
	zoom:1;/*IE fix - removing items on the client*/
}

.RadUpload .ruInputs
{
	list-style:none;
	margin:0;
	padding:0;
}

.RadUpload .ruInputs
{
	zoom:1;/*IE fix - removing items on the client*/
}

.RadUpload .ruFileWrap
{
	position: relative;
	white-space:nowrap;
	display: inline-block;
	vertical-align: top;
    padding-right: 0.8em;
    line-height: 20px;
    zoom: 1;
}

.RadUpload .ruFileWrap
{
	position: relative;
	white-space:nowrap;
	display: inline-block;
	vertical-align: top;
    padding-right: 0.8em;
    line-height: 20px;
    zoom: 1;
}

.RadUpload .ruFileWrap
{
	position: relative;
	white-space:nowrap;
	display: inline-block;
	vertical-align: top;
    padding-right: 0.8em;
    line-height: 20px;
    zoom: 1;
}

.RadUpload_Default .ruFakeInput
{
    border-color: #abadb3 #dbdfe6 #e3e9ef #e2e3ea;
    color: #333;
}

.RadUpload .ruFakeInput
{
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

.RadUpload .ruFakeInput
{
	float: none;
	vertical-align:top;
}

.RadUpload .ruFakeInput
{
    border-width: 1px;
    border-style: solid;
    line-height: 18px;
    padding: 4px 4px 0 4px;

    -moz-box-sizing: content-box; /* Quirksmode height fix */
    -webkit-box-sizing: content-box;
    box-sizing: content-box;
}

.RadUpload_Default .ruFakeInput
{
    border-color: #abadb3 #dbdfe6 #e3e9ef #e2e3ea;
    color: #333;
}

.RadUpload .ruFakeInput
{
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

.RadUpload .ruFakeInput
{
	float: none;
	vertical-align:top;
}

.RadUpload .ruFakeInput
{
    border-width: 1px;
    border-style: solid;
    line-height: 18px;
    padding: 4px 4px 0 4px;

    -moz-box-sizing: content-box; /* Quirksmode height fix */
    -webkit-box-sizing: content-box;
    box-sizing: content-box;
}

.RadUpload_Default .ruFakeInput
{
    border-color: #abadb3 #dbdfe6 #e3e9ef #e2e3ea;
    color: #333;
}

.RadUpload .ruFakeInput
{
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

.RadUpload .ruFakeInput
{
	float: none;
	vertical-align:top;
}

.RadUpload .ruFakeInput
{
    border-width: 1px;
    border-style: solid;
    line-height: 18px;
    padding: 4px 4px 0 4px;

    -moz-box-sizing: content-box; /* Quirksmode height fix */
    -webkit-box-sizing: content-box;
    box-sizing: content-box;
}

.RadUpload_Default .ruButton
{
    background-image: url('mvwres://Telerik.Web.UI, Version=2011.2.712.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Upload.ruSprite.png');
    color: #000;
}

.RadUpload .ruBrowse
{
    width: 65px;
    margin-left: 4px;
    background-position: 0 0;
}

.RadUpload .ruButton
{
    width: 79px;
    height: 22px;
    border: 0;
    padding-bottom: 2px;
    background-position: 0 -23px;
    background-repeat: no-repeat;
    background-color: transparent;
    text-align: center;
}

.RadUpload .ruButton
{
	float: none;
	vertical-align:top;
}

.RadUpload_Default .ruButton
{
    background-image: url('mvwres://Telerik.Web.UI, Version=2011.2.712.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Upload.ruSprite.png');
    color: #000;
}

.RadUpload .ruBrowse
{
    width: 65px;
    margin-left: 4px;
    background-position: 0 0;
}

.RadUpload .ruButton
{
    width: 79px;
    height: 22px;
    border: 0;
    padding-bottom: 2px;
    background-position: 0 -23px;
    background-repeat: no-repeat;
    background-color: transparent;
    text-align: center;
}

.RadUpload .ruButton
{
	float: none;
	vertical-align:top;
}

.RadUpload_Default .ruButton
{
    background-image: url('mvwres://Telerik.Web.UI, Version=2011.2.712.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Upload.ruSprite.png');
    color: #000;
}

.RadUpload .ruBrowse
{
    width: 65px;
    margin-left: 4px;
    background-position: 0 0;
}

.RadUpload .ruButton
{
    width: 79px;
    height: 22px;
    border: 0;
    padding-bottom: 2px;
    background-position: 0 -23px;
    background-repeat: no-repeat;
    background-color: transparent;
    text-align: center;
}

.RadUpload .ruButton
{
	float: none;
	vertical-align:top;
}

        .style70
        {
            width: 275px;
        }

        .style72
        {
            width: 79px;
        }

        .style76
        {
            width: 12px;
        }
        .style77
        {
            width: 135px;
        }
        .style78
        {
            width: 100%;
        }

        .RadPicker table.rcTable .rcInputCell
{
	padding:0 4px 0 0;
}

.RadPicker table.rcTable .rcInputCell
{
	padding:0 4px 0 0;
}

.RadPicker table.rcTable .rcInputCell
{
	padding:0 4px 0 0;
}

        .style81
        {
            width: 115px;
        }
        
        .style83
        {
            width: 9px;
        }
        .style84
        {
            width: 20px;
        }
        .style89
        {
            width: 143px;
        }

        .style90
        {
            width: 86px;
        }

        .style93
        {
            width: 278px;
        }

        .style94
        {
            width: 249px;
        }

        .auto-style4 {
            width: 151px;
        }

        .auto-style5 {
            width: 116px;
        }
        .auto-style6 {
            width: 82px;
        }
        .auto-style7 {
            width: 107px;
        }
        .auto-style9 {
            width: 155px;
        }
        .auto-style11 {
            width: 120px;
        }
        .auto-style12 {
            width: 124px;
        }

        .auto-style13 {
            width: 160px;
        }

        .auto-style14 {
            width: 110px;
        }

        </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="cph1">
    <script type="text/javascript">
        function KeyPress(sender, args) {
            var regexp = new RegExp("[0-9]{1}|[\b]|\t|\r");
            if (!args.get_keyCharacter().match(regexp))
                args.set_cancel(true);
        }  
</script>
                        <asp:Panel ID="panbus" runat="server" CssClass="panmar" 
        GroupingText="Buscar Activo - Registro de Mantenimientos">
                            <table cellpadding="0" cellspacing="0" class="panmar2"><tr>
                                <td class="aatl">
                                    <table cellspacing="0" width="100%">
                                    <tr>
                                        <td class="auto-style4">
                                            <h5>Código de Barras:<asp:RequiredFieldValidator ID="rfv1" runat="server" 
                                                ControlToValidate="txtbuscb" ErrorMessage="Ingrese Código de Barras" 
                                                ForeColor="Red" ValidationGroup="2">*</asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="rfv1_ValidatorCalloutExtender" runat="server" 
                                                Enabled="True" PopupPosition="BottomRight" TargetControlID="rfv1">
                                            </asp:ValidatorCalloutExtender>
                                                </h5>
                                        </td>
                                        <td width="150">
                                            <div class="form-group">
                                            <telerik:RadTextBox ID="txtbuscb" runat="server" MaxLength="20" CssClass="form-control" 
                                                ValidationGroup="1" Width="150px">
                                                <ClientEvents OnKeyPress="KeyPress" />
                                                <emptymessagestyle font-italic="True" />
                                            </telerik:RadTextBox>
                                                </div>
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="ibbus1" runat="server" CssClass="relo" Height="35px" 
                                                ImageUrl="~/Img/buscarblue.png" onclick="ibbus1_Click" TabIndex="99" 
                                                ToolTip="Buscar Código de Barras" ValidationGroup="2" Width="35px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style4">
                                            <h5>
                                            N° Serie:<asp:RequiredFieldValidator ID="rfv2" runat="server" 
                                                ControlToValidate="txtbusid" ErrorMessage="Ingrese Serie" ForeColor="Red" 
                                                ValidationGroup="3">*</asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="rfv2_ValidatorCalloutExtender" runat="server" 
                                                Enabled="True" PopupPosition="BottomRight" TargetControlID="rfv2">
                                            </asp:ValidatorCalloutExtender>
                                                </h5>
                                        </td>
                                        <td>
                                            <%--<telerik:RadTextBox ID="txtbusid" runat="server" MaxLength="20" Width="70px" Visible="false"
                                                    ValidationGroup="2"><PasswordStrengthSettings CalculationWeightings="50;15;15;20" 
                                                            IndicatorElementBaseStyle="riStrengthBar" IndicatorElementID="" 
                                                            MinimumLowerCaseCharacters="2" MinimumNumericCharacters="2" 
                                                            MinimumSymbolCharacters="2" MinimumUpperCaseCharacters="2" 
                                                            OnClientPasswordStrengthCalculating="" PreferredPasswordLength="10" 
                                                            RequiresUpperAndLowerCaseCharacters="True" ShowIndicator="False" 
                                                            TextStrengthDescriptions="Very Weak;Weak;Medium;Strong;Very Strong" 
                                                            
                                                    
                                                    TextStrengthDescriptionStyles="riStrengthBarL0;riStrengthBarL1;riStrengthBarL2;riStrengthBarL3;riStrengthBarL4;riStrengthBarL5;" />
                                                <ClientEvents OnKeyPress="KeyPress" /><EmptyMessageStyle Font-Italic="True" /></telerik:RadTextBox>--%>
                                            <div class="form-group">
                                            <telerik:RadTextBox ID="txtbusid" runat="server" MaxLength="40" Width="150px" CssClass="form-control">
                                                
                                                <emptymessagestyle font-italic="True" />
                                            </telerik:RadTextBox>
                                                </div>
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="ibbus3" runat="server" CssClass="relo" Height="35px" 
                                                ImageUrl="~/Img/buscarblue.png" onclick="ibbus3_Click" TabIndex="99" 
                                                ToolTip="Buscar Id" ValidationGroup="3" Width="35px" />
                                        </td>
                                    </tr>
                                    </table></td></tr></table></asp:Panel>
                        <asp:Panel ID="Pan_UgeUor" runat="server" GroupingText="Información Técnica y Ubicación" CssClass="panmar">
           <table  cellpadding="1" cellspacing="1" class="style1">
           <tr>
               <td class="style4" width="310">
                   <asp:Image ID="Image2" runat="server" ImageUrl="~/Img/a2.png" />
               </td>
           <td class="style70" >
               <asp:Image ID="Image3" runat="server" ImageUrl="~/Img/a3.png" />
               </td>
               <td width="310" >
               <asp:Image ID="Image4" runat="server" ImageUrl="~/Img/a4.png" />
               </td>
           </tr>

           <tr>

                      <td class="style4" width="310">
                          <asp:Panel ID="PanelTipo" runat="server">
                              <table class="style68">
                                  <tr>
                                      <td class="auto-style6">
                                          Grupo:</td>
                                      <td>
                                          <asp:Label ID="lbl_Grupo" runat="server" Font-Bold="True" 
                                              Font-Names="Century Gothic" Text="[Grupo]"></asp:Label>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td class="auto-style6">
                                          Subgrupo:</td>
                                      <td>
                                          <asp:Label ID="lbl_Subgrupo" runat="server" Font-Bold="True" 
                                              Font-Names="Century Gothic" Text="[SubGrupo]"></asp:Label>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td class="auto-style6">
                                          Descripción:</td>
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
           <td class="auto-style5">Ub. Geográfica 1:</td>
           <td>
               <asp:Label ID="lbl_UbGeo1" runat="server" Text="[Ubicación Geografica 1]" 
                   Font-Bold="True" Font-Names="Century Gothic"></asp:Label>
               </td>
           </tr>

           <tr>
           <td class="auto-style5">Ub. Geográfica 2:</td>
           <td>
               <asp:Label ID="lbl_UbiGeo2" runat="server" Text="[Ubicación Geografica 2]" 
                   Font-Bold="True" Font-Names="Century Gothic"></asp:Label>
               </td>
           </tr>

           <tr>
           <td class="auto-style5">Ub. Geográfica 3:</td>
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
           <td class="auto-style7">Ubi. Orgánica 1:</td>
           <td>
               <asp:Label ID="lbl_ceCosto" runat="server" Text="[Ubi. Orgnanica1]" 
                   Font-Bold="True" Font-Names="Century Gothic"></asp:Label>
               </td>
           </tr>
           <tr>
           <td class="auto-style7">Ubi. Orgánica 2:</td>
           <td>
               <asp:Label ID="lbl_UbiOrg" runat="server" Text="[Ubi. Organica 2]" 
                   Font-Bold="True" Font-Names="Century Gothic"></asp:Label>
               </td>
           </tr>
           <tr>
           <td class="auto-style7">Custodio:</td>
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
                        <asp:Panel ID = "pnl_Mantenimiento" runat = "server" 
        GroupingText = "Mantenimiento" CssClass="panmar" Font-Bold="False">
                  <table width="100%">
                    <tr>
                        <td colspan="6">
                            <table width="100%">
                                <tr>
                                    <td class="style83">
                                        &nbsp;</td>
                                    <td class="style84">
                                        Id:</td>
                                    <td class="style90">
                                        <asp:Label ID="lblid" runat="server"></asp:Label>
                                    </td>
                                    <td class="auto-style12">
                                        Código de Barras:</td>
                                    <td class="auto-style9">
                                        <asp:Label ID="lblCodBarras" runat="server"></asp:Label>
                                    </td>
                                    <td class="auto-style11">
                                        Valor de Compra:</td>
                                    <td>
                                        <asp:Label ID="lblValorCompra" runat="server" Font-Bold="True" 
                                            ForeColor="#CC3300"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style83">
                                        &nbsp;</td>
                                    <td class="style84">
                                        &nbsp;</td>
                                    <td class="style90">
                                        &nbsp;</td>
                                    <td class="auto-style12">
                                        &nbsp;</td>
                                    <td class="auto-style9">
                                        &nbsp;</td>
                                    <td class="auto-style11">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                      <tr>
                          <td class="style76">
                          </td>
                          <td class="auto-style13">
                              Forma Mantenimiento:</td>
                          <td class="style93">
                              <div class="form-group">
                                  &nbsp;
                              <asp:DropDownList ID="ddFormaMant" runat="server" AutoPostBack="True" 
                                  Width="80%">
                                  <asp:ListItem></asp:ListItem>
                                  <asp:ListItem Value="I">Interno</asp:ListItem>
                                  <asp:ListItem Value="CS">Contrato Servicio Terceros</asp:ListItem>
                              </asp:DropDownList>
                              <asp:RequiredFieldValidator ID="rfv_FormaMant" runat="server" 
                                  ControlToValidate="ddFormaMant" 
                                  ErrorMessage="Seleccione Forma de Mantenimiento" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                  <asp:ValidatorCalloutExtender ID="vceFormaMant" TargetControlID = "rfv_FormaMant" runat="server"></asp:ValidatorCalloutExtender>
                                  </div>
                          </td>
                          
                          <td rowspan="4" valign="top">
                          <asp:Panel ID = "panFechaMant" runat = "server">
                          <asp:UpdatePanel ID ="upFechaMant" runat ="server" UpdateMode="Conditional">
                          <ContentTemplate>
                              <table width="100%">
                                  <tr>
                                      <td class="auto-style14">
                                          Fecha Mant.:
                                      </td>
                                      <td>
                                          <telerik:RadDatePicker ID="rdpFechaMant" Runat="server" EnableTyping="False" 
                                              MaxDate="2050-01-01" MinDate="1900-01-01" Width="120px">
                                              <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" 
                                                  ViewSelectorText="x">
                                              </Calendar>
                                              <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" 
                                                  ReadOnly="True">
                                              </DateInput>
                                              <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                          </telerik:RadDatePicker>
                                          <asp:RequiredFieldValidator ID="rfvtipo33" runat="server" 
                                              ControlToValidate="rdpFechaMant" ErrorMessage="Ingrese Fecha de Mantenimiento" 
                                              ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                              <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" TargetControlID = "rfvtipo33" runat="server"></asp:ValidatorCalloutExtender>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td class="auto-style14">
                                          <asp:RadioButtonList ID="rblPorMeses" runat="server">
                                              <asp:ListItem Value="M">Mensual</asp:ListItem>
                                              <asp:ListItem Value="T">Trimestral</asp:ListItem>
                                              <asp:ListItem Value="S">Semestral</asp:ListItem>
                                              <asp:ListItem Value="A">Anual</asp:ListItem>
                                          </asp:RadioButtonList>
                                      </td>
                                      <td>
                                          &nbsp;</td>
                                  </tr>
                              </table>
                            </ContentTemplate>
                          </asp:UpdatePanel>
                          </asp:Panel>
                          </td>
                          <td>
                              &nbsp;</td>
                          
                          <td rowspan="4">
                              
                          </td>
                      </tr>
                    <tr>
                        <td class="style76">
                        </td>
                        <td class="auto-style13">
                            Tipo Mantenimiento:</td>
                        <td class="style93">
                            <asp:CheckBoxList ID="chboxTipoMant" runat="server" AutoPostBack="True" 
                               
                                RepeatDirection="Horizontal" Width="60%" 
                                onselectedindexchanged="chboxTipoMant_SelectedIndexChanged">
                                <asp:ListItem Value="1">Correctivo</asp:ListItem>
                                <asp:ListItem Value="2">Preventivo</asp:ListItem>
                            </asp:CheckBoxList>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td class="style76">
                        </td>
                        <td class="auto-style13">
                            Cobertura:</td>
                        <td class="style93">
                            <div class="form-group">
                                &nbsp;
                            <asp:DropDownList ID="ddCobertura" runat="server" AutoPostBack="True" 
                                Width="36%">
                                <asp:ListItem Selected="True" Value="1">1 año</asp:ListItem>
                                <asp:ListItem Value="2">2 años</asp:ListItem>
                                <asp:ListItem Value="3">3 años</asp:ListItem>
                                <asp:ListItem Value="4">5 años</asp:ListItem>
                            </asp:DropDownList>
                                </div>
                        </td>
                        <td>
                        </td>
                    </tr>
                      <tr>
                          <td class="style76">
                              &nbsp;</td>
                          <td class="auto-style13">
                              Modalidad:</td>
                          <td class="style93">
                              <table width="100%">
                                  <tr>
                                      <td class="style81">
                                          <div class="form-group">
                                          <asp:DropDownList ID="ddModalidad" runat="server" AutoPostBack="True" 
                                               Width="88%" onselectedindexchanged="ddModalidad_SelectedIndexChanged">
                                              <asp:ListItem Selected="True" Value="1">5x8</asp:ListItem>
                                              <asp:ListItem Value="2">7x24</asp:ListItem>
                                              <asp:ListItem Value="3">otros</asp:ListItem>
                                          </asp:DropDownList>
                                              </div>
                                      </td>
                                      <td>
                                          <div class="form-group">
                                          <telerik:RadTextBox ID="txtModalidad" Runat="server" Visible="false" CssClass="form-control"
                                              Width="60px">
                                          </telerik:RadTextBox>
                                              </div>
                                      </td>
                                  </tr>
                              </table>
                          </td>
                          <td>
                              &nbsp;</td>
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
                onclick="ibcancel_Click" />
            &nbsp;<asp:ImageButton ID="ibsave" runat="server" Height="28px" 
                ImageUrl="~/Img/s1.png" Width="102px" onclick="ibsave_Click" ValidationGroup="1" />
            &nbsp;</div>
        </asp:Panel>
    <asp:AlwaysVisibleControlExtender ID="avcePanCommand" runat="server" 
        Enabled="True" TargetControlID="panCommand" VerticalSide="Bottom">
    </asp:AlwaysVisibleControlExtender>
    <uc2:messbox ID="messbox1" runat="server" />
    <asp:ValidationSummary ID="vs" runat="server" ShowMessageBox="True" 
        ShowSummary="False" />
</asp:Content>



<%@ Page Title="" Language="C#" MasterPageFile="~/Site/Activos/cay.master" AutoEventWireup="true" CodeFile="Baja.aspx.cs" Inherits="Baja" EnableEventValidation="false" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register src="../../Ctrl/Wait/wait.ascx" tagname="wait" tagprefix="uc1" %>
<%@ Register src="../../Ctrl/Msg/messbox.ascx" tagname="messbox" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
            
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
	/*default*/
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

        .auto-style3 {
            width: 176px;
        }
        .auto-style4 {
            width: 185px;
        }

        </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="cph1">
<script type="text/javascript">

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

	function KeyPress(sender, args) {
		var regexp = new RegExp("[0-9]{1}|[\b]|\t|\r");
		if (!args.get_keyCharacter().match(regexp))
			args.set_cancel(true);
	}  
</script>
<asp:Panel ID="panbus" runat="server" CssClass="panmar" GroupingText="Buscar Activo - Dar de Baja">
    <table cellpadding="0" cellspacing="0" width="8000px">
        <tr>
            <td class="aatl" width="280">
                <table cellspacing="0" style="width: 688px">
                    <tr>
                        <td class="auto-style4">
                            <h4>Código de Barras:</h4>
                            <asp:RequiredFieldValidator
                                ID="rfv1" runat="server" ControlToValidate="txtbuscb"
                                ErrorMessage="Ingrese Código de Barras" ForeColor="Red" ValidationGroup="1">
                                *
                            </asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="rfv1_ValidatorCalloutExtender" runat="server"
                                                          Enabled="True" TargetControlID="rfv1" PopupPosition="BottomRight" WarningIconImageUrl="~/Img/warning.png">
                            </asp:ValidatorCalloutExtender>

                        </td>
                        <td width="160">
                            <div class="form-group">
                                <telerik:RadTextBox ID="txtbuscb" runat="server"
                                                    MaxLength="70" Width="150px" Height="25px" CssClass="form-control">
                                    <ClientEvents OnKeyPress="KeyPress"/>
                                    <EmptyMessageStyle Font-Italic="True"/>
                                </telerik:RadTextBox>
                            </div>
                        </td>
                        <td valign="top">
                            <asp:ImageButton ID="ibbus1" runat="server" Height="35px"
                                             ImageUrl="~/Img/buscarblue.png" onclick="ibbus1_Click" TabIndex="99"
                                             ToolTip="Buscar Código de Barras" ValidationGroup="1" Width="35px"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4">
                            <h4>Código Secundario:</h4>
                            <asp:RequiredFieldValidator ID="rfv2" runat="server"
                                                        ControlToValidate="txtbusid" ErrorMessage="Ingrese Codigo Secundario" ForeColor="Red"
                                                        ValidationGroup="2">
                                *
                            </asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="rfv2_ValidatorCalloutExtender" runat="server"
                                                          Enabled="True" TargetControlID="rfv2" PopupPosition="BottomRight" WarningIconImageUrl="~/Img/warning.png">
                            </asp:ValidatorCalloutExtender>

                        </td>
                        <td>
                            <div class="form-group">
                                <telerik:RadTextBox ID="txtbusid" runat="server" MaxLength="20" Width="150px" Height="25px" CssClass="form-control">
                                    <%--<ClientEvents OnKeyPress="KeyPress" />--%>
                                    <EmptyMessageStyle Font-Italic="True"/>
                                </telerik:RadTextBox>
                            </div>
                        </td>
                        <td valign="top">
                            <asp:ImageButton ID="ibbus3" runat="server" Height="35px"
                                             ImageUrl="~/Img/buscarblue.png" TabIndex="99" ToolTip="Buscar Id" ValidationGroup="2"
                                             Width="35px" onclick="ibbus3_Click"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4">
                            &nbsp;
                        </td>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                </table>

            </td>
        </tr>
    </table>
</asp:Panel>

<asp:Panel ID="panGrid" runat="server" GroupingText="Item Buscado" CssClass="panmar" ScrollBars="Horizontal">

    <asp:GridView ID="rgbaja" runat="server" AlternatingRowStyle-CssClass="alt"
                  CssClass="mGrid" Font-Names="Arial" Font-Size="9pt" GridLines="None"
                  onrowdatabound="rgbaja_RowDataBound1" PagerStyle-CssClass="pgr" Width="8000px">
        <AlternatingRowStyle CssClass="alt"/>
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="ibbaja" runat="server" CssClass="aacc" Height="30px"
                                     ImageUrl="~/Img/baj1.png" onclick="ibbaja_Click"
                                     ToolTip="Dar de Baja este Item" Width="112px"/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <HeaderStyle HorizontalAlign="Left"/>
        <PagerStyle CssClass="pgr"/>
    </asp:GridView>

</asp:Panel>
<br/>
<asp:Panel ID="panhijos" runat="server" CssClass="panmar"
           GroupingText="Items hijos" Visible="False" ScrollBars="Horizontal">

    <asp:GridView ID="rghijos" runat="server" CssClass="mGrid" Width="200%">
    </asp:GridView>

</asp:Panel>
<%--<asp:UpdatePanel ID="uprepo1" runat="server" UpdateMode="Conditional">
		<ContentTemplate>
			<asp:Panel ID="pantras" runat="server" CssClass="panmar" Width="100%" 
				GroupingText="Item buscado" Visible="False">
				<table cellspacing="0" width="100%">
					<tr>
						<td>
									<asp:Panel ID="panbaja" runat="server" ScrollBars="Auto" Width="50%">
										<asp:GridView ID="rgbaja" runat="server" AlternatingRowStyle-CssClass="alt" 
											CssClass="mGrid" Font-Names="Arial" Font-Size="9pt" GridLines="None" 
											onrowdatabound="rgbaja_RowDataBound1" PagerStyle-CssClass="pgr" Width="50%">
											<AlternatingRowStyle CssClass="alt" />
											<Columns>
												<asp:TemplateField>
													<ItemTemplate>
														<asp:ImageButton ID="ibbaja" runat="server" CssClass="aacc" Height="30px" 
															ImageUrl="~/Img/baj1.png" onclick="ibbaja_Click" 
															ToolTip="Dar de Baja este Item" Width="112px" />
													</ItemTemplate>
												</asp:TemplateField>
											</Columns>
											<HeaderStyle HorizontalAlign="Left" />
											<PagerStyle CssClass="pgr" />
										</asp:GridView>
									</asp:Panel>
									<asp:Panel ID="panhijos" runat="server" CssClass="panmar" 
										GroupingText="Items hijos" Visible="False">
										<asp:Panel ID="Panel" runat="server" CssClass="panmar" ScrollBars="Auto" 
											Width="100%">
											<asp:GridView ID="rghijos" runat="server" CssClass="mGrid" Width="100%">
											</asp:GridView>
										</asp:Panel>
									</asp:Panel>
						</td>
					</tr>
				</table>
			</asp:Panel>
		</ContentTemplate>
	</asp:UpdatePanel>--%>


<asp:Label ID="Label2" runat="server"></asp:Label>
<asp:ModalPopupExtender ID="mp2" runat="server"
                        BackgroundCssClass="modalBackground" DynamicServicePath="" Enabled="True"
                        PopupControlID="pan2" TargetControlID="Label2">
</asp:ModalPopupExtender>
<asp:Panel ID="pan2" runat="server" Height="240px"
           Width="500px" style="display:none">
<%--style="display:none"--%>
<asp:UpdatePanel ID="upbaja" runat="server" UpdateMode="Conditional">
<ContentTemplate>
<table style="background-color:white; width:100%" cellpadding="0" cellspacing="0">
    <tr>
        <td class="mess">
            <table cellpadding="0" cellspacing="0" class="style1">
                <tr>
                    <td width="10">
                        &nbsp;
                    </td>
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
                <table cellspacing="0" width="100%">
                    <tr>
                        <td width="100">
                            <h6>Id:</h6>
                        </td>
                        <td>
                            <h6>
                                <asp:Label ID="lblid" runat="server"></asp:Label>
                            </h6>
                        </td>
                    </tr>
                    <tr>
                        <td width="100">
                            <h6>Tipo:</h6>
                        </td>
                        <td>
                            <h6>
                                <asp:Label ID="lbltipo" runat="server"></asp:Label>
                            </h6>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <h6>
                                Razón Baja:
                                <asp:RequiredFieldValidator ID="rfvtipo32" runat="server"
                                                            ControlToValidate="ddTipoBaja" ErrorMessage="Seleccione Razón de Baja"
                                                            ForeColor="Red" ValidationGroup="22">
                                    *
                                </asp:RequiredFieldValidator>
                            </h6>
                        </td>
                        <td>
                            <div class="form-group">
                                <asp:DropDownList ID="ddTipoBaja" runat="server" CssClass="txtdd" Width="110px">
                                </asp:DropDownList>
                                <asp:CascadingDropDown ID="cddTipoBaja" runat="server" Category="tbaja"
                                                       ContextKey="4" Enabled="True" LoadingText="[Cargando Tipo Baja...]"
                                                       PromptText="• Seleccione •" ServiceMethod="GetTipoBaja" ServicePath="ws.asmx"
                                                       TargetControlID="ddTipoBaja">
                                </asp:CascadingDropDown>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <h6>Observaciones:</h6>
                        </td>
                        <td>

                            <div class="form-group">
                                <telerik:RadTextBox ID="txtobsbaja" Runat="server" Font-Names="Arial" CssClass="form-control"
                                                    Font-Size="9pt" MaxLength="150" Rows="5" TextMode="MultiLine" Width="100%">

                                    <EmptyMessageStyle Font-Italic="True"/>
                                </telerik:RadTextBox>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td width="100">
                            Adjunto:
                        </td>
                        <td>
                            <%-- <asp:AsyncFileUpload ID="FileUpload" runat="server" 
                                               ThrobberID="loader" Width="400px" onuploadedcomplete="FileUpload_UploadedComplete" 
                                                />
                                                <asp:Image ID="loader" runat="server" 
                                                ImageUrl ="~/Img/wait.gif" 
                                                />--%>
                            <%-- <asp:AsyncFileUpload ID="FileUpload" runat="server" 
                                               ThrobberID="loader" Width="400px" onuploadedcomplete="FileUpload_UploadedComplete" 
                                                />
                                                <asp:Image ID="loader" runat="server" 
                                                ImageUrl ="~/Img/wait.gif" 
                                                />--%>
                            <asp:FileUpload ID="FileUpload1" runat="server"/>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblmensaje" runat="server"></asp:Label>
                        </td>
                        <td>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td class="aatr">
                            <asp:ImageButton ID="ibcancel" runat="server" Height="28px"
                                             ImageUrl="~/Img/c1.png" onclick="ibcancel_Click" Width="102px"/>
                            &nbsp;
                            <asp:ImageButton ID="ibsave" runat="server" Height="28px"
                                             ImageUrl="~/Img/s1.png" onclick="ibsave_Click" ValidationGroup="22"
                                             Width="102px"/>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td class="aatr">

                        </td>
                    </tr>
                </table>
            </div>
        </td>
    </tr>
    <tr>
<td>
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
            <td>Cuenta Baja</td>
            <td>
                <asp:Label runat="server" ID="lblCuentaBaja"></asp:Label>
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
        <tr>
            <td>Cuenta Depreciación</td>
            <td>
                <asp:Label runat="server" ID="lblCuentaDepre"></asp:Label>
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
        </tbody>
    </table>
</td>        
    </tr>
    <tr>
        <td class="mess">
            &nbsp;
        </td>
    </tr>
</table>

</ContentTemplate>
<Triggers>
    <asp:PostBackTrigger ControlID="ibsave"/>
</Triggers>
</asp:UpdatePanel>
<br/>
</asp:Panel>

<uc2:messbox ID="messbox1" runat="server"/>
</asp:Content>
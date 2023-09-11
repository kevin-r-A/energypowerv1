<%@ Page Title="" Language="C#" MasterPageFile="~/Site/Activos/cay.master" AutoEventWireup="true" CodeFile="ZUge.aspx.cs" Inherits="ZUge" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Src="../../Ctrl/Msg/messbox.ascx" TagName="messbox" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript">
        function KeyPress(sender, args) {
            var regexp = new RegExp("[0-9]{1}|[\b]|\t|\r|[.]");
            if (!args.get_keyCharacter().match(regexp))
                args.set_cancel(true);
        }
    </script>

    <style type="text/css">
        .style4 {
            width: 93px;
        }

        .auto-style2 {
            width: 61px;
        }

        .auto-style3 {
            width: 12px;
        }

        .auto-style4 {
            width: 5px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
<asp:Panel ID="Panel1" runat="server" CssClass="panmar"
           GroupingText="Gestión de Ubicación Geográfica">
    <table cellspacing="0" class="panmar">
        <tr>
            <td class="aatl" width="100%">
                <asp:Panel ID="Panel5" runat="server" CssClass="panmar"
                           GroupingText="Ubicación Geográfica">
                    <asp:UpdatePanel ID="upgeo" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table cellspacing="0" class="panmar">
                                <tr>
                                    <td class="aatl" width="24%">
                                        <asp:Panel ID="Panel4" runat="server" CssClass="panmar"
                                                   GroupingText="Ubicación Geo1">
                                            <asp:UpdatePanel ID="upmar" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:Panel ID="pansgru" runat="server" CssClass="panmar2">
                                                        <asp:ImageButton ID="ibgr4" runat="server" CausesValidation="False"
                                                                         CssClass="relo" Height="20px" ImageUrl="~/Img/add.png" TabIndex="99"
                                                                         ToolTip="Agregar Geo1" Width="21px" OnClick="ibgr4_Click"/>
                                                        &nbsp;
                                                        <asp:ImageButton ID="ibgr5" runat="server" CausesValidation="False"
                                                                         CssClass="relo" Height="21px" ImageUrl="~/Img/pen.png" TabIndex="99"
                                                                         ToolTip="Editar Geo1" Width="21px" OnClick="ibgr5_Click"/>
                                                        &nbsp;
                                                        <asp:ImageButton ID="ibgr6" runat="server" CausesValidation="False"
                                                                         CssClass="relo" Height="19px" ImageUrl="~/Img/del.png" TabIndex="99"
                                                                         ToolTip="Eliminar Geo1" Width="20px" OnClick="ibgr6_Click"/>
                                                    </asp:Panel>
                                                    <telerik:RadListBox ID="rlbgeo1" runat="server" AutoPostBack="True"
                                                                        CssClass="panmar2" EmptyMessage="Geo1 no Disponible" Height="400px"
                                                                        Width="95%" OnSelectedIndexChanged="rlbgeo1_SelectedIndexChanged">
                                                        <ButtonSettings TransferButtons="All"/>
                                                        <EmptyMessageTemplate>
                                                            Subgrupos no disponibles
                                                        </EmptyMessageTemplate>
                                                    </telerik:RadListBox>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </asp:Panel>
                                    </td>
                                    <td class="aatl" width="24%">
                                        <asp:Panel ID="Panel6" runat="server" CssClass="panmar"
                                                   GroupingText="Ubicación Geo2">
                                            <asp:UpdatePanel ID="upmod" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:Panel ID="pangru1" runat="server" CssClass="panmar2">
                                                        <asp:ImageButton ID="ibgr7" runat="server" CausesValidation="False"
                                                                         CssClass="relo" Height="20px" ImageUrl="~/Img/add.png" TabIndex="99"
                                                                         ToolTip="Agregar Geo2" Width="21px" OnClick="ibgr7_Click"/>
                                                        &nbsp;
                                                        <asp:ImageButton ID="ibgr8" runat="server" CausesValidation="False"
                                                                         CssClass="relo" Height="21px" ImageUrl="~/Img/pen.png" TabIndex="99"
                                                                         ToolTip="Editar Geo2" Width="21px" OnClick="ibgr8_Click"/>
                                                        &nbsp;
                                                        <asp:ImageButton ID="ibgr9" runat="server" CausesValidation="False"
                                                                         CssClass="relo" Height="19px" ImageUrl="~/Img/del.png" TabIndex="99"
                                                                         ToolTip="Eliminar Geo2" Width="20px" OnClick="ibgr9_Click"/>
                                                    </asp:Panel>
                                                    <telerik:RadListBox ID="rlbgeo2" runat="server" AutoPostBack="True"
                                                                        CssClass="panmar2" EmptyMessage="Geo2 no Disponible" Height="400px"
                                                                        OnSelectedIndexChanged="rlbgeo2_SelectedIndexChanged">
                                                        <ButtonSettings TransferButtons="All"/>
                                                        <EmptyMessageTemplate>
                                                            Descripciones no disponibles
                                                        </EmptyMessageTemplate>
                                                    </telerik:RadListBox>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </asp:Panel>
                                    </td>
                                    <td class="aatl" width="24%">
                                        <asp:Panel ID="Panel7" runat="server" CssClass="panmar"
                                                   GroupingText="Ubicación Geo3">
                                            <asp:UpdatePanel ID="upmod0" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:Panel ID="pangru2" runat="server" CssClass="panmar2">
                                                        <asp:ImageButton ID="ibgr10" runat="server" CausesValidation="False"
                                                                         CssClass="relo" Height="20px" ImageUrl="~/Img/add.png" TabIndex="99"
                                                                         ToolTip="Agregar Geo3" Width="21px" OnClick="ibgr10_Click"/>
                                                        &nbsp;
                                                        <asp:ImageButton ID="ibgr11" runat="server" CausesValidation="False"
                                                                         CssClass="relo" Height="21px" ImageUrl="~/Img/pen.png" TabIndex="99"
                                                                         ToolTip="Editar Geo3" Width="21px" OnClick="ibgr11_Click"/>
                                                        &nbsp;
                                                        <asp:ImageButton ID="ibgr12" runat="server" CausesValidation="False"
                                                                         CssClass="relo" Height="19px" ImageUrl="~/Img/del.png" TabIndex="99"
                                                                         ToolTip="Eliminar Geo3" Width="20px" OnClick="ibgr12_Click"/>
                                                    </asp:Panel>
                                                    <telerik:RadListBox ID="rlbgeo3" runat="server" AutoPostBack="True"
                                                                        CssClass="panmar2" EmptyMessage="Geo3 no Disponible" Height="400px"
                                                                        OnSelectedIndexChanged="rlbgeo3_SelectedIndexChanged">
                                                        <ButtonSettings TransferButtons="All"/>
                                                        <EmptyMessageTemplate>
                                                            Descripciones no disponibles
                                                        </EmptyMessageTemplate>
                                                    </telerik:RadListBox>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </asp:Panel>
                                    </td>
                                    <td class="aatl" width="24%">
                                        <asp:Panel ID="Panel8" runat="server" CssClass="panmar"
                                                   GroupingText="Piso/Nivel">
                                            <asp:UpdatePanel ID="upmod1" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:Panel ID="pangru3" runat="server" CssClass="panmar2">
                                                        <asp:ImageButton ID="ibgr13" runat="server" CausesValidation="False"
                                                                         CssClass="relo" Height="20px" ImageUrl="~/Img/add.png" TabIndex="99"
                                                                         ToolTip="Agregar Piso/Nivel" Width="21px" OnClick="ibgr13_Click"/>
                                                        &nbsp;
                                                        <asp:ImageButton ID="ibgr14" runat="server" CausesValidation="False"
                                                                         CssClass="relo" Height="21px" ImageUrl="~/Img/pen.png" TabIndex="99"
                                                                         ToolTip="Editar Piso/Nivel" Width="21px" OnClick="ibgr14_Click"/>
                                                        &nbsp;
                                                        <asp:ImageButton ID="ibgr15" runat="server" CausesValidation="False"
                                                                         CssClass="relo" Height="19px" ImageUrl="~/Img/del.png" TabIndex="99"
                                                                         ToolTip="Eliminar Piso/Nivel" Width="20px" OnClick="ibgr15_Click"/>
                                                    </asp:Panel>
                                                    <telerik:RadListBox ID="rlbgeo4" runat="server" AutoPostBack="True"
                                                                        CssClass="panmar2" EmptyMessage="Dirección no Disponible" Height="400px"
                                                                        OnSelectedIndexChanged="rlbgeo4_SelectedIndexChanged">
                                                        <ButtonSettings TransferButtons="All"/>
                                                        <EmptyMessageTemplate>
                                                            Descripciones no disponibles
                                                        </EmptyMessageTemplate>
                                                    </telerik:RadListBox>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </asp:Panel>
                                    </td>

                                </tr>
                                <tr style="display:none">

                                    <td colspan="4">
                                        <asp:Panel ID="PanPuertaPasillo" runat="server" CssClass="panmar"
                                                   GroupingText="Puerta/Pasillo">
                                            <asp:UpdatePanel ID="UpPuertaPasillo" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:Panel ID="PanBotones" runat="server" CssClass="panmar2">
                                                        <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False"
                                                                         CssClass="relo" Height="20px" ImageUrl="~/Img/add.png" TabIndex="99"
                                                                         ToolTip="Agregar Puerta/Pasillo" Width="21px" OnClick="ImageButton1_Click"/>
                                                        &nbsp;
                                                        <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False"
                                                                         CssClass="relo" Height="21px" ImageUrl="~/Img/pen.png" TabIndex="99"
                                                                         ToolTip="Editar Puerta/Pasillo" Width="21px" OnClick="ImageButton2_Click"/>
                                                        &nbsp;
                                                        <asp:ImageButton ID="ImageButton3" runat="server" CausesValidation="False"
                                                                         CssClass="relo" Height="19px" ImageUrl="~/Img/del.png" TabIndex="99"
                                                                         ToolTip="Eliminar Puerta/Pasillo" Width="20px" OnClick="ImageButton3_Click"/>
                                                    </asp:Panel>
                                                    <telerik:RadListBox ID="rlbgeo5" runat="server" AutoPostBack="True"
                                                                        CssClass="panmar2" EmptyMessage="Puerta/Pasillo no Disponible" Height="300px"
                                                                        OnSelectedIndexChanged="rlbgeo5_SelectedIndexChanged">
                                                        <ButtonSettings TransferButtons="All"/>
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
<%--<asp:Label ID="Label2" runat="server"></asp:Label>
	<asp:ModalPopupExtender ID="mp2" runat="server" 
		BackgroundCssClass="modalBackground" DynamicServicePath="" Enabled="True" 
		PopupControlID="pan2" TargetControlID="Label2">
	</asp:ModalPopupExtender>
	<asp:Panel ID="pan2" runat="server" Height="142px" 
		Width="430px"  style="display:none">
		<asp:UpdatePanel ID="upnuevo2" runat="server" UpdateMode="Conditional">
			<ContentTemplate>
				<table bgcolor="White" cellpadding="0" cellspacing="0" class="style2">
					<tr>
						<td class="mess">
							<table cellpadding="0" cellspacing="0" class="style2">
								<tr>
									<td width="10">
										&nbsp;</td>
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
											Nombre:</td>
										<td>
											<telerik:RadTextBox ID="txtnombre2" Runat="server" MaxLength="150" 
												Width="330px">
												<PasswordStrengthSettings CalculationWeightings="50;15;15;20" 
													IndicatorElementBaseStyle="riStrengthBar" IndicatorElementID="" 
													MinimumLowerCaseCharacters="2" MinimumNumericCharacters="2" 
													MinimumSymbolCharacters="2" MinimumUpperCaseCharacters="2" 
													OnClientPasswordStrengthCalculating="" PreferredPasswordLength="10" 
													RequiresUpperAndLowerCaseCharacters="True" ShowIndicator="False" 
													TextStrengthDescriptions="Very Weak;Weak;Medium;Strong;Very Strong" 
													TextStrengthDescriptionStyles="riStrengthBarL0;riStrengthBarL1;riStrengthBarL2;riStrengthBarL3;riStrengthBarL4;riStrengthBarL5;" />
												<EmptyMessageStyle Font-Italic="True" />
											</telerik:RadTextBox>
											<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
												ControlToValidate="txtnombre2" ErrorMessage="Ingrese Nombre" 
												ValidationGroup="22">*</asp:RequiredFieldValidator>
											<asp:ValidatorCalloutExtender ID="vce2" runat="server" Enabled="True" 
												TargetControlID="RequiredFieldValidator3">
											</asp:ValidatorCalloutExtender>
										</td>
									</tr>
									<tr>
										<td>
											&nbsp;</td>
										<td>
											&nbsp;</td>
									</tr>
									<tr>
										<td>
											&nbsp;</td>
										<td class="aatr">
											<asp:Button ID="btncerrar2" runat="server" CausesValidation="False" 
												onclick="btncerrar2_Click" Text="Cerrar" />
											&nbsp;<asp:Button ID="btnsave2" runat="server" onclick="btnsave2_Click" 
												Text="Guardar" ValidationGroup="22" />
										</td>
									</tr>
								</table>
							</div>
						</td>
					</tr>
					<tr>
						<td class="mess">
							&nbsp;</td>
					</tr>
				</table>
			</ContentTemplate>
		</asp:UpdatePanel>
		<br />
	</asp:Panel>--%>
<asp:Label ID="Label2" runat="server"></asp:Label>
<asp:ModalPopupExtender ID="mp2" runat="server"
                        BackgroundCssClass="modalBackground" DynamicServicePath="" Enabled="True"
                        PopupControlID="pan2" TargetControlID="Label2">
</asp:ModalPopupExtender>
<asp:Panel ID="pan2" runat="server" Height="142px"
           Width="430px" style="display:none">
    <%--style="display:none"--%>
    <asp:UpdatePanel ID="upnuevo2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table style="background-color: white" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td class="mess">
                        <table cellpadding="0" cellspacing="0" width="100%">
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
                                    <td style="font-weight: bold" class="auto-style2">&nbsp;</td>
                                    <td class="auto-style4" style="font-weight: bold">&nbsp;</td>
                                    <td>
                                        <asp:Label ID="lblmsgerror" runat="server" Font-Size="8pt" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style2" style="font-weight: bold">
                                        <h6>
                                            <asp:Label ID="lblNombrereader" runat="server" Text="Nombre:"></asp:Label>
                                        </h6>
                                    </td>
                                    <td class="auto-style4">
                                        <h6>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                                                        ControlToValidate="txtnombre2" ErrorMessage="Ingrese Nombre" ForeColor="Red"
                                                                        ValidationGroup="22">
                                                *
                                            </asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="vce2" runat="server" Enabled="True"
                                                                          TargetControlID="RequiredFieldValidator3">
                                            </asp:ValidatorCalloutExtender>
                                        </h6>
                                    </td>
                                    <td>
                                        <div class="form-group">
                                            <telerik:RadTextBox ID="txtnombre2" runat="server" MaxLength="150" TextMode="MultiLine" Width="100%" CssClass="form-control">
                                                <PasswordStrengthSettings CalculationWeightings="50;15;15;20" IndicatorElementBaseStyle="riStrengthBar" IndicatorElementID="" MinimumLowerCaseCharacters="2" MinimumNumericCharacters="2" MinimumSymbolCharacters="2" MinimumUpperCaseCharacters="2" OnClientPasswordStrengthCalculating="" PreferredPasswordLength="10" RequiresUpperAndLowerCaseCharacters="True" ShowIndicator="False" TextStrengthDescriptions="Very Weak;Weak;Medium;Strong;Very Strong" TextStrengthDescriptionStyles="riStrengthBarL0;riStrengthBarL1;riStrengthBarL2;riStrengthBarL3;riStrengthBarL4;riStrengthBarL5;"/>
                                                <EmptyMessageStyle Font-Italic="True"/>
                                            </telerik:RadTextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style2" style="font-weight: bold">
                                        <h6>
                                            <asp:Label ID="lblCodigo" runat="server" Text="Codigo:"></asp:Label>
                                        </h6>
                                    </td>
                                    <td></td>
                                    <td>
                                        <div class="form-group">
                                            <telerik:RadTextBox ID="txtCodigo" runat="server" MaxLength="150" Width="100%" CssClass="form-control">
                                                <EmptyMessageStyle Font-Italic="True"/>
                                            </telerik:RadTextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style2">
                                        <h6>
                                            <asp:Label ID="lblIpReader" runat="server" Text="Reader Ip:"></asp:Label>
                                        </h6>
                                    </td>
                                    <td class="auto-style4">&nbsp;</td>
                                    <td>
                                        <telerik:RadTextBox ID="txtIpReader" runat="server" MaxLength="100" Width="70%" CssClass="form-control">
                                            <EmptyMessageStyle Font-Italic="True"/>
                                            <ClientEvents OnKeyPress="KeyPress"/>
                                        </telerik:RadTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style2">&nbsp;</td>
                                    <td class="auto-style4">&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style2">&nbsp;</td>
                                    <td class="auto-style4">&nbsp;</td>
                                    <td class="aatr">
                                        <asp:Button ID="btncerrar2" runat="server" CausesValidation="False"
                                                    OnClick="btncerrar2_Click" Text="Cancelar" CssClass="btn btn-danger"/>
                                        &nbsp;
                                        <asp:Button ID="btnsave2" runat="server" OnClick="btnsave2_Click" CssClass="btn btn-primary"
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
<br/>
<uc1:messbox ID="messbox1" runat="server"/>
</asp:Content>
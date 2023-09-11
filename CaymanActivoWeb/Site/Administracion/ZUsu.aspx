<%@ Page Language="C#" MasterPageFile="~/Site/Activos/cay.master" AutoEventWireup="true" CodeFile="ZUsu.aspx.cs" Inherits="ZUsu" EnableEventValidation="false" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register src="../../Ctrl/Msg/messbox.ascx" tagname="messbox" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	<script type="text/javascript">
		function KeyPress(sender, args) {
			var regexp = new RegExp("[0-9]{1}|[\b]|\t|\r");
			if (!args.get_keyCharacter().match(regexp))
				args.set_cancel(true);
		}  
	 </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" Runat="Server">
	<asp:Panel ID="Panel1" runat="server" CssClass="panmar" 
		GroupingText="Gestión de Usuarios PocketPc y Roles PocketPc">
		<table cellspacing="0" class="panmar">
			<tr>
				<td class="aatl">
					<asp:Panel ID="Panel2" runat="server" CssClass="panmar" 
						GroupingText="Usuarios PocketPc">
						<asp:UpdatePanel ID="upusu" runat="server" UpdateMode="Conditional">
							<ContentTemplate>
								<asp:Panel ID="pangru" runat="server" CssClass="panmar2">
									<asp:ImageButton ID="ibgr1" runat="server" CausesValidation="False" 
										CssClass="relo" Height="20px" ImageUrl="~/Img/add.png" onclick="ibgr1_Click" 
										TabIndex="99" ToolTip="Agregar Usuario PocketPc" Width="21px" />
									&nbsp;<asp:ImageButton ID="ibgr2" runat="server" CausesValidation="False" 
										CssClass="relo" Height="21px" ImageUrl="~/Img/pen.png" onclick="ibgr2_Click" 
										TabIndex="99" ToolTip="Editar Usuario PocketPc" Width="21px" />
									&nbsp;<asp:ImageButton ID="ibgr3" runat="server" CausesValidation="False" 
										CssClass="relo" Height="19px" ImageUrl="~/Img/del.png" TabIndex="99" 
										ToolTip="Eliminar Usuario PocketPc" Width="20px" onclick="ibgr3_Click" />
									<asp:ConfirmButtonExtender ID="cbeDel" runat="server" ConfirmText="Está seguro que quiere eliminar el usuario seleccionado?" 
										Enabled="True" TargetControlID="ibgr3">
									</asp:ConfirmButtonExtender>
								</asp:Panel>
								<telerik:RadListBox ID="rlbusu" runat="server" AutoPostBack="True" 
									CssClass="panmar" EmptyMessage="Usuarios PPC No Disponibles" 
									onselectedindexchanged="rlbusu_SelectedIndexChanged" Width="95%" Height="156px">
									<ButtonSettings TransferButtons="All" />
									<EmptyMessageTemplate>
										No existen usuarios PocketPc
									</EmptyMessageTemplate>
								</telerik:RadListBox>
							</ContentTemplate>
						</asp:UpdatePanel>

					</asp:Panel>
				</td>
				<td class="aatl">
					<asp:Panel ID="Panel3" runat="server" CssClass="panmar" 
						GroupingText="Roles PocketPc">
						<asp:UpdatePanel ID="uprol" runat="server" UpdateMode="Conditional">
							<ContentTemplate>
								<asp:Panel ID="pangru0" runat="server" CssClass="panmar2" Height="24px">
									Seleccione el Usuario y asigne el(los) role(s).</asp:Panel>
								<telerik:RadListBox ID="rlbroles" runat="server" AutoPostBack="True" 
									CssClass="panmar" EmptyMessage="Roles PPC No Disponibles" 
									Width="95%" onitemcheck="rlbroles_ItemCheck">
									<ButtonSettings TransferButtons="All" />
									<EmptyMessageTemplate>
										Roles No Disponibles
									</EmptyMessageTemplate>
								</telerik:RadListBox>
							</ContentTemplate>
						</asp:UpdatePanel>
					</asp:Panel>
				</td>
			</tr>
		</table>
	</asp:Panel>
	<asp:Label ID="Label1" runat="server"></asp:Label>
	<asp:ModalPopupExtender ID="mpnuevo" runat="server" 
		BackgroundCssClass="modalBackground" DynamicServicePath="" Enabled="True" 
		PopupControlID="pan" TargetControlID="Label1">
	</asp:ModalPopupExtender>
	<br />
	<asp:Panel ID="pan" runat="server" Height="142px" 
		Width="430px">
        <%--style="display:none"--%>
		<asp:UpdatePanel ID="upnuevo" runat="server" UpdateMode="Conditional">
			<ContentTemplate>
				<table style="background-color:white" cellpadding="0" cellspacing="0" class="style1">
					<tr>
						<td class="mess">
							<table cellpadding="0" cellspacing="0" class="style2">
								<tr>
									<td width="10">
										&nbsp;</td>
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
									<tr>
										<td width="60">
											<h6>Usuario:<asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
												runat="server" ControlToValidate="txtusuario" 
												ErrorMessage="Ingrese Usuario" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>
											<asp:ValidatorCalloutExtender ID="RequiredFieldValidator2_ValidatorCalloutExtender" 
												runat="server" Enabled="True" TargetControlID="RequiredFieldValidator2" WarningIconImageUrl="~/Img/warning.png">
											</asp:ValidatorCalloutExtender>
                                                </h6>
										</td>
										<td>
                                            <div class="form-group">
											<telerik:RadTextBox ID="txtusuario" runat="server" MaxLength="150" CssClass="form-control" 
												Width="300px">
												<EmptyMessageStyle Font-Italic="True" />
											</telerik:RadTextBox>
                                                </div>
										</td>
									</tr>
									<tr>
										<td>
											<h6>Clave:<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
												ControlToValidate="txtclave" ErrorMessage="Ingrese Clave" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>
											<asp:ValidatorCalloutExtender ID="RequiredFieldValidator3_ValidatorCalloutExtender" 
												runat="server" Enabled="True" TargetControlID="RequiredFieldValidator3" WarningIconImageUrl="~/Img/warning.png">
											</asp:ValidatorCalloutExtender>
                                                </h6>
										</td>
										<td>
                                            <div class="form-group">
											<telerik:RadTextBox ID="txtclave" runat="server" CssClass="form-control"
												MaxLength="150" Width="300px">
												<EmptyMessageStyle Font-Italic="True" />
											</telerik:RadTextBox>
                                                </div>
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
											<asp:ImageButton ID="ibcancel" runat="server" Height="28px" 
												ImageUrl="~/Img/c1.png" onclick="ibcancel_Click" Width="102px" />
											<asp:ImageButton ID="ibsave" runat="server" Height="28px" 
												ImageUrl="~/Img/s1.png" onclick="ibsave_Click" ValidationGroup="1" 
												Width="102px" />
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
	</asp:Panel>
	<uc1:messbox ID="messbox1" runat="server" />
</asp:Content>


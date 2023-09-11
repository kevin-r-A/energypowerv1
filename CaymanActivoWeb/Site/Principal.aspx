<%@ Page Title="" Language="C#" MasterPageFile="~/Site/Activos/cay.master" AutoEventWireup="true" CodeFile="Principal.aspx.cs" Inherits="Site_Principal" %>
<%@ Register src="~/Ctrl/Msg/messbox.ascx" tagname="messbox" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" Runat="Server">
    <style type="text/css">
		body
{
	background-image: url(../Img/wp3.jpg);
}
	</style>
	<table cellspacing="0" class="style1">
	<tr>
		<td>
			&nbsp;</td>
		<td width="235">
			&nbsp;</td>
		<td width="235">
					&nbsp;</td>
		<td width="235">
			&nbsp;</td>
		<td>
			&nbsp;</td>
	</tr>
	<tr>
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
		<td class="atd">
			&nbsp;</td>
		<td class="aatc">
			<asp:ImageButton ID="ibtn1" runat="server" Height="180px" 
								ImageUrl="~/Img/mnu11.png" 
				Width="217px" ToolTip="Manual del Sistema" Enabled="False" />
		</td>
		<td class="aatc" width="280">
			<asp:ImageButton ID="ibtn2" runat="server" Height="180px" 
						ImageUrl="~/Img/mnu12.png" Width="217px" ToolTip="Manual del Sistema" Enabled="False" />
		</td>
		<td class="aatc">
			<asp:ImageButton ID="ibtn3" runat="server" Height="180px" 
						ImageUrl="~/Img/mnu13.png" Width="217px" ToolTip="Manual del Sistema" Enabled="False" />
		</td>
		<td class="atl">
			&nbsp;</td>
	</tr>
	<tr>
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
		<td class="atd">
			&nbsp;</td>
		<td class="aatc">
			<asp:ImageButton ID="ibtn4" runat="server" Height="180px" 
						ImageUrl="~/Img/mnu14.png" Width="217px" ToolTip="Manual del Sistema" Enabled="False" />
		</td>
		<td class="aatc">
			<asp:ImageButton ID="ibtn5" runat="server" Height="180px" 
						ImageUrl="~/Img/mnu15.png" Width="217px" ToolTip="Manual del Sistema" Enabled="False" />
		</td>
		<td class="aatc">
			<asp:ImageButton ID="ibtn6" runat="server" Height="180px" 
						ImageUrl="~/Img/mnu16.png" Width="217px" ToolTip="Manual del Sistema" Enabled="False" />
		</td>
		<td class="atl">
			&nbsp;</td>
	</tr>
</table>
<uc2:messbox ID="messbox1" runat="server" />
</asp:Content>


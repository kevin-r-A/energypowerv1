<%@ Control Language="C#" AutoEventWireup="true" CodeFile="messbox.ascx.cs" Inherits="Ctrl_Msg_messbox" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<link href="../../App_Themes/Theme1/css.css" rel="stylesheet" type="text/css" />

<asp:Panel ID="pm" runat="server" Height="164px" Width="400px" 
    BorderColor="#333333" BorderStyle="Solid" BorderWidth="1px" 
    BackColor="White" style="display:none; border-radius:4px" >
    <table style="background-color: #006699; border-collapse:separate; border-spacing:1px; margin-left:0px; width:100%">
        <tr>
            <td style="width:360px">
                <asp:UpdatePanel ID="uptitu" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Label ID="lbltitu" runat="server" Font-Bold="True" Font-Italic="False" 
                            Font-Names="Arial" ForeColor="White"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="aacc">
                <asp:ImageButton ID="ibtnx" runat="server" Height="17px" 
                    ImageUrl="~/Img/x.gif" Width="31px" CausesValidation="False" 
                    ToolTip="Cerrar Mensaje"/>
                </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="upmsg" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table style="border-collapse:separate; border-spacing:1px; width:368px" class="bor2">
                <tr>
                    <td class="aatl" style="width:40px">
                        <span id="icono" runat="server" aria-hidden="true" style="font-size:30px"></span>
                    </td>
                    <td class="aatl">
                        <asp:Panel ID="Panel1" runat="server" Height="100px" ScrollBars="Auto" 
                            Width="320px">
                            <asp:Literal ID="lblMsg" runat="server"></asp:Literal>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>

<asp:Label ID="Label1" runat="server"></asp:Label>
<asp:ModalPopupExtender ID="mp" runat="server" 
    BackgroundCssClass="modalBackground" CancelControlID="ibtnx" 
    DynamicServicePath="" Enabled="True" PopupControlID="pm" RepositionMode="None" 
    TargetControlID="Label1">
</asp:ModalPopupExtender>



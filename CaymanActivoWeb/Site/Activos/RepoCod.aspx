<%@ Page Title="" Language="C#" MasterPageFile="~/Site/Activos/cay.master" AutoEventWireup="true" CodeFile="RepoCod.aspx.cs" Inherits="RepoCod" %>

<%@ Register src="../../Ctrl/Msg/messbox.ascx" tagname="messbox" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" Runat="Server">
        <asp:Panel ID="Panel1" runat="server" CssClass="panmar" GroupingText="Códigos">
            <table cellspacing="0" class="style1">
                <tr>
                    <td class="aatl" width="70%">
                        <asp:Panel ID="panutil" runat="server" CssClass="panmar" 
                            GroupingText="Códigos Utilizados">
                            <div id="divutil" style="overflow:scroll; height:700px">
                            <table cellspacing="0" class="panmar">
                                <tr>
                                    <td class="aatr">
                                        <asp:ImageButton ID="ibxls1" runat="server" Height="30px" 
                                            ImageUrl="~/Img/xls1.png" onclick="ibxls1_Click" Width="122px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="rgutil" runat="server" AlternatingRowStyle-CssClass="alt" 
                                            CssClass="mGrid" Font-Names="Arial" Font-Size="9pt" GridLines="None" 
                                            onrowdatabound="rgutil_RowDataBound" PagerStyle-CssClass="pgr">
                                            <AlternatingRowStyle CssClass="alt" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:HyperLink ID="hk1" runat="server" ImageUrl="~/Img/editar.gif" 
                                                            Target="_blank" ToolTip="Editar Item"></asp:HyperLink>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <PagerStyle CssClass="pgr" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                            </div>
                        </asp:Panel>
                    </td>
                    <td class="aatl" width="30%">
                        <asp:Panel ID="pannoutil" runat="server" CssClass="panmar" 
                            GroupingText="Códigos No Utilizados">
                            <div id="dicnoutil" style="overflow:scroll; height:700px">
                            <table cellspacing="0" class="panmar">
                                <tr>
                                    <td class="aatr">
                                        <asp:ImageButton ID="ibxls2" runat="server" Height="30px" 
                                            ImageUrl="~/Img/xls1.png" onclick="ibxls2_Click" Width="122px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="rgnoutil" runat="server" AlternatingRowStyle-CssClass="alt" 
                                            CssClass="mGrid" Font-Names="Arial" Font-Size="9pt" GridLines="None" 
                                            PagerStyle-CssClass="pgr">
                                            <AlternatingRowStyle CssClass="alt" />
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <PagerStyle CssClass="pgr" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                            </div>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <uc1:messbox ID="messbox1" runat="server" />
</asp:Content>


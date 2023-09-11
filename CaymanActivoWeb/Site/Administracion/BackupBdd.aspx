<%@ Page Language="C#" MasterPageFile="~/Site/Activos/cay.master" AutoEventWireup="true" CodeFile="BackupBdd.aspx.cs" Inherits="BackupBdd" EnableEventValidation="false" %>
<%@ Register src="../../Ctrl/Msg/messbox.ascx" tagname="messbox" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" Runat="Server">
    <asp:Panel ID="panus" runat="server" CssClass="panmar" 
        GroupingText="Respaldo de Información">
        <div class="divv">
            <asp:Panel ID="Panel1" runat="server" CssClass="pmarg" 
                GroupingText="Respaldo de la Base de Datos">
                <asp:ImageButton ID="ibtnBackup" runat="server" CssClass="bor2" Height="28px" 
                    ImageUrl="~/Img/bdd1.png" onclick="ibtnBackup_Click" Width="182px" />
            </asp:Panel>
            <br />
            <asp:Panel ID="Panel2" runat="server" CssClass="pmarg" 
                GroupingText="Respaldos Realizados">
                <div class="divv">
                    <telerik:RadGrid ID="gvDeprec" runat="server" 
                        CellSpacing="0" Font-Names="Arial" Font-Size="9pt" Width="100%" 
                        GridLines="None">
                        <ClientSettings>
                            <Selecting AllowRowSelect="True" />
                            <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                        </ClientSettings>
                        <MasterTableView Font-Names="Arial Narrow" Font-Size="9pt">
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                <HeaderStyle Width="20px" />
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                <HeaderStyle Width="20px" />
                            </ExpandCollapseColumn>
                            <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                </EditColumn>
                            </EditFormSettings>
                            <ItemStyle Font-Names="Arial Narrow" Font-Size="9pt" />
                            <AlternatingItemStyle Font-Names="Arial Narrow" Font-Size="9pt" />
                            <HeaderStyle Font-Names="Arial Narrow" Font-Size="9pt" />
                        </MasterTableView>
                        <HeaderStyle Font-Names="Arial" Font-Size="9pt" />
                        <ItemStyle Font-Names="Arial" Font-Size="9pt" />
                        <FilterMenu EnableImageSprites="False">
                        </FilterMenu>
                        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                        </HeaderContextMenu>
                    </telerik:RadGrid>
                </div>
            </asp:Panel>
            <br />
        </div>
    </asp:Panel>
    <uc1:messbox ID="messbox1" runat="server" />
</asp:Content>


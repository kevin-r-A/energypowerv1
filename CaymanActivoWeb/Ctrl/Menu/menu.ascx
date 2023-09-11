<%@ Control Language="C#" AutoEventWireup="true" CodeFile="menu.ascx.cs" Inherits="Ctrl_Menu_menu" %>

<asp:SiteMapDataSource ID="smap" runat="server" ShowStartingNode="False" />
<telerik:RadMenu ID="RadMenu1" runat="server" DataSourceID="smap"
    Skin="Office2010Blue">
</telerik:RadMenu>



<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Hfotos.aspx.cs" Inherits="Hfotos" %>

<%@ Register src="../../Ctrl/Msg/messbox.ascx" tagname="messbox" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../App_Themes/Theme1/css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style2
        {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <div>
    
                                        <table cellspacing="0" class="style2">
                                            <tr>
                                                <td class="aatr">
    
                                        <asp:ImageButton ID="ibxls1" runat="server" Height="30px" 
                                            ImageUrl="~/Img/pdf1.png" onclick="ibxls1_Click" 
                    Width="112px" />
    
                                                </td>
                                            </tr>
                                        </table>
    
        <telerik:RadGrid ID="rgdepre" runat="server" CellSpacing="0" 
            DataSourceID="SqlDataSource1" Width="100%" Culture="en-US" GridLines="None" CssClass="MyGridClass" 
                                            Height="90%">
            <ExportSettings IgnorePaging="True" 
                OpenInNewWindow="True" FileName="">
                <Pdf AllowCopy="True" FontType="Link" PageBottomMargin="0.4in" 
                    PageHeight="297mm" PageLeftMargin="0.8in" PageRightMargin="0.4in" 
                    PageTitle="Historial Fotográfico" PageTopMargin="0.4in" PageWidth="210mm" 
                    PaperSize="A4" Subject="Historial Fotográfico" Title="Historial Fotográfico" />
            </ExportSettings>
            <ClientSettings>
                <Scrolling AllowScroll="True" UseStaticHeaders="True" />
            </ClientSettings>
<MasterTableView AutoGenerateColumns="False" DataSourceID="SqlDataSource1" 
                Font-Names="Arial Narrow" Font-Size="11pt">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
</RowIndicatorColumn>

<ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridBoundColumn DataField="ACT_ID" 
            FilterControlAltText="Filter ACT_ID column" HeaderText="Id" 
            SortExpression="ACT_ID" UniqueName="ACT_ID" DataType="System.Int32">
            <HeaderStyle Width="50px" />
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="USERNAME" 
            FilterControlAltText="Filter USERNAME column" HeaderText="Usuario" 
            SortExpression="USERNAME" UniqueName="USERNAME">
        </telerik:GridBoundColumn>
        <telerik:GridDateTimeColumn DataField="HFO_FECHA" DataFormatString="{0:d}" 
            FilterControlAltText="Filter column4 column" HeaderText="Fecha" 
            UniqueName="column4">
        </telerik:GridDateTimeColumn>
        <telerik:GridBoundColumn DataField="cus_id1" FilterControlAltText="Filter cus_id1 column" 
            HeaderText="Custodio" ReadOnly="True" SortExpression="cus_id1" 
            UniqueName="cus_id1">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="cus_id2" 
            FilterControlAltText="Filter cus_id2 column" 
            HeaderText="Responsable" SortExpression="cus_id2" 
            UniqueName="cus_id2" ReadOnly="True" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridHyperLinkColumn DataNavigateUrlFields="HFO_FOTO1" 
            DataNavigateUrlFormatString="imgact/{0}" DataTextField="HFO_FOTO1" 
            DataTextFormatString="Ver Foto 1" FilterControlAltText="Filter column2 column" 
            ImageUrl="~/img/bus.png" Target="_blank" UniqueName="column2" Text="Link">
            <HeaderStyle Width="28px" />
            <ItemStyle Width="28px" />
        </telerik:GridHyperLinkColumn>
        <telerik:GridImageColumn DataImageUrlFields="HFO_FOTO1" 
            DataImageUrlFormatString="imgact/{0}" 
            FilterControlAltText="Filter column column" HeaderText="Foto 1" 
            ImageHeight="150px" ImageWidth="215px" UniqueName="column">
            <ItemStyle Width="220px" />
        </telerik:GridImageColumn>
        <telerik:GridHyperLinkColumn DataNavigateUrlFields="HFO_FOTO2" 
            DataNavigateUrlFormatString="imgact/{0}" DataTextField="HFO_FOTO1" 
            DataTextFormatString="Ver Foto 2" FilterControlAltText="Filter column3 column" 
            Target="_blank" UniqueName="column3" ImageUrl="~/img/bus.png" Text="Link">
            <HeaderStyle Width="28px" />
            <ItemStyle Width="28px" />
        </telerik:GridHyperLinkColumn>
        <telerik:GridImageColumn DataImageUrlFields="HFO_FOTO2" 
            DataImageUrlFormatString="imgact/{0}" 
            FilterControlAltText="Filter column1 column" HeaderText="Foto 2" 
            ImageHeight="150px" ImageWidth="215px" UniqueName="column1">
            <ItemStyle Width="220px" />
        </telerik:GridImageColumn>
    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
    <ItemStyle Font-Names="Arial Narrow" Font-Size="11pt" />
    <AlternatingItemStyle Font-Names="Arial Narrow" Font-Size="11pt" />
    <HeaderStyle Font-Names="Arial Narrow" Font-Size="11pt" 
        HorizontalAlign="Left" />
</MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>

<HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
        </telerik:RadGrid>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:base %>" 
            
            SelectCommand="SELECT HFOTO.ACT_ID, HFOTO.USERNAME, HFOTO.HFO_FECHA, C.CUS_APELLIDOS + ' ' + C.CUS_NOMBRES AS cus_id1, CC.CUS_APELLIDOS + ' ' + CC.CUS_NOMBRES AS cus_id2, HFOTO.HFO_FOTO1, HFOTO.HFO_FOTO2 FROM HFOTO INNER JOIN CUSTODIO AS C ON HFOTO.CUS_ID1 = C.CUS_ID LEFT OUTER JOIN CUSTODIO AS CC ON HFOTO.CUS_ID2 = CC.CUS_ID where act_id=@act_id order by hfo_id">
            <SelectParameters>
                <asp:Parameter Name="act_id" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    <uc1:messbox ID="messbox1" runat="server" />
    </form>
</body>
</html>

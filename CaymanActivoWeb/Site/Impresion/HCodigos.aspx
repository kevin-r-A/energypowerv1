<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HCodigos.aspx.cs" Inherits="HCodigos" %>
<%@ Register src="../../Ctrl/Msg/messbox.ascx" tagname="messbox" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../App_Themes/Theme1/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <div class="divv">
    
        <table width="98%">
            <tr>
                <td class="aatr">
                <asp:ImageButton ID="ibxls1" runat="server" Height="30px" ImageUrl="~/Img/xls1.png" onclick="ibxls1_Click" 
                        Width="122px" />
                </td>
            </tr>
            <tr>
                <td>
    
        <telerik:RadGrid ID="rgdepre" runat="server" CellSpacing="0" 
            DataSourceID="SqlDataSource1" Culture="en-US" GridLines="None" 
                        CssClass="MyGridClass">
            <ExportSettings ExportOnlyData="True" IgnorePaging="True" 
                OpenInNewWindow="True">
            </ExportSettings>
            <ClientSettings>
                <Selecting AllowRowSelect="True" />
                <Scrolling AllowScroll="True" UseStaticHeaders="True" />
            </ClientSettings>
<MasterTableView AutoGenerateColumns="False" DataSourceID="SqlDataSource1" 
                DataKeyNames="EMPRESA,PREFIJO,SUFIJO,SECUENCIAL,VERIFICADOR">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
</RowIndicatorColumn>

<ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridBoundColumn DataField="EMPRESA" 
            FilterControlAltText="Filter EMPRESA column" HeaderText="EMPRESA" 
            SortExpression="EMPRESA" UniqueName="EMPRESA" ReadOnly="True">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="CODIGO" 
            FilterControlAltText="Filter CODIGO column" HeaderText="CODIGO" 
            SortExpression="CODIGO" UniqueName="CODIGO" ReadOnly="True" 
            DataFormatString="'{0}">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="PREFIJO" FilterControlAltText="Filter PREFIJO column" 
            HeaderText="PREFIJO" ReadOnly="True" SortExpression="PREFIJO" 
            UniqueName="PREFIJO" DataFormatString="'{0}">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="SUFIJO" 
            FilterControlAltText="Filter SUFIJO column" 
            HeaderText="SUFIJO" SortExpression="SUFIJO" 
            UniqueName="SUFIJO" ReadOnly="True" DataFormatString="'{0}">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="SECUENCIAL" DataType="System.Int32" 
            FilterControlAltText="Filter SECUENCIAL column" HeaderText="SECUENCIAL" 
            ReadOnly="True" SortExpression="SECUENCIAL" UniqueName="SECUENCIAL">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="VERIFICADOR" DataType="System.Int32" 
            FilterControlAltText="Filter VERIFICADOR column" HeaderText="VERIFICADOR" 
            ReadOnly="True" SortExpression="VERIFICADOR" UniqueName="VERIFICADOR">
        </telerik:GridBoundColumn>
    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>

<HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
        </telerik:RadGrid>
                    <uc1:messbox ID="messbox1" runat="server" />
                </td>
            </tr>
        </table>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:base %>" 
            
            
            SelectCommand="SELECT EMP_ID AS EMPRESA, COD_PREFIJO + COD_SUFIJO AS CODIGO, COD_PREFIJO AS PREFIJO, COD_SUFIJO AS SUFIJO, COD_SECUENCIAL AS SECUENCIAL, COD_VERIFICADOR AS VERIFICADOR FROM CODIGO order by SECUENCIAL asc">
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>

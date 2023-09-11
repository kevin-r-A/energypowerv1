<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Depre.aspx.cs" Inherits="Depre" %>

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
    <table cellpadding="2" cellspacing="4" width="100%">
        <tr>
            <td style="text-align: right">
    
                                        <asp:ImageButton ID="ibxls1" runat="server" Height="30px" 
                                            ImageUrl="~/Img/xls1.png" onclick="ibxls1_Click" 
                    Width="122px" />
            </td>
        </tr>
    </table>
    <div>
    
        <telerik:RadGrid ID="rgdepre" runat="server" CellSpacing="0" 
            DataSourceID="SqlDataSource1" GridLines="None" Width="100%" 
            Culture="en-US">
            <ExportSettings ExportOnlyData="True" OpenInNewWindow="True">
                <Excel Format="ExcelML" />
            </ExportSettings>
            <ClientSettings>
                <Selecting AllowRowSelect="True" />
                <Scrolling AllowScroll="True" UseStaticHeaders="True" />
            </ClientSettings>
<MasterTableView AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridBoundColumn DataField="DEP_CCOSTO" 
            FilterControlAltText="Filter DEP_CCOSTO column" HeaderText="CentroCosto" 
            SortExpression="DEP_CCOSTO" UniqueName="DEP_CCOSTO">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="DEP_GRUPO" 
            FilterControlAltText="Filter DEP_GRUPO column" HeaderText="Grupo" 
            SortExpression="DEP_GRUPO" UniqueName="DEP_GRUPO">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="DEP_VIDAUTIL" DataType="System.Int32" 
            FilterControlAltText="Filter DEP_VIDAUTIL column" HeaderText="VidaUtil" 
            SortExpression="DEP_VIDAUTIL" UniqueName="DEP_VIDAUTIL">
        </telerik:GridBoundColumn>
        <telerik:GridNumericColumn DataField="valor" DataFormatString="{0:C}" 
            DataType="System.Decimal" DecimalDigits="2" 
            FilterControlAltText="Filter valorcompra column" HeaderText="ValorCompra" 
            ReadOnly="True" SortExpression="valorcompra" UniqueName="valorcompra">
        </telerik:GridNumericColumn>
        <telerik:GridBoundColumn DataField="DEP_VALORRESIDUAL" DataFormatString="{0:C}" 
            DataType="System.Decimal" FilterControlAltText="Filter DEP_VALORRESIDUAL column" 
            HeaderText="ValorResidual" SortExpression="DEP_VALORRESIDUAL" 
            UniqueName="DEP_VALORRESIDUAL">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="DEP_SALDOXDEPRE" DataFormatString="{0:C}" 
            DataType="System.Decimal" 
            FilterControlAltText="Filter DEP_SALDOXDEPRE column" 
            HeaderText="SaldoDepreciar" SortExpression="DEP_SALDOXDEPRE" 
            UniqueName="DEP_SALDOXDEPRE">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="DEP_PERTRANS" DataType="System.Int32" 
            FilterControlAltText="Filter DEP_PERTRANS column" HeaderText="PerTrans" 
            SortExpression="DEP_PERTRANS" UniqueName="DEP_PERTRANS">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="DEP_PERREMA" DataType="System.Int32" 
            FilterControlAltText="Filter DEP_PERREMA column" HeaderText="PerRema" 
            SortExpression="DEP_PERREMA" UniqueName="DEP_PERREMA">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="DEP_DEPREPERIODO" DataFormatString="{0:C}" 
            DataType="System.Decimal" FilterControlAltText="Filter DEP_DEPREPERIODO column" 
            HeaderText="DepPeriodo" SortExpression="DEP_DEPREPERIODO" 
            UniqueName="DEP_DEPREPERIODO">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="DEP_DEPREACUM" DataFormatString="{0:C}" 
            DataType="System.Decimal" FilterControlAltText="Filter DEP_DEPREACUM column" 
            HeaderText="DepAcumulada" SortExpression="DEP_DEPREACUM" 
            UniqueName="DEP_DEPREACUM">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="fecha" FilterControlAltText="Filter fecha column" 
            HeaderText="Periodo" SortExpression="fecha" 
            UniqueName="fecha" ReadOnly="True">
        </telerik:GridBoundColumn>
    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
    <ItemStyle Font-Names="Arial Narrow" Font-Size="10pt" />
    <AlternatingItemStyle Font-Names="Arial Narrow" Font-Size="10pt" />
    <HeaderStyle Font-Names="Arial Narrow" Font-Size="10pt" />
</MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>

<HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
        </telerik:RadGrid>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:base %>" SelectCommand="SELECT 
  DEP_CCOSTO
 ,DEP_GRUPO
 ,DEP_VIDAUTIL
 ,DEP_VALORRESIDUAL+DEP_SALDOXDEPRE+DEP_DEPREACUM as valor
 ,DEP_VALORRESIDUAL
 ,DEP_SALDOXDEPRE
 ,DEP_DEPREACUM
 ,DEP_PERTRANS
 ,DEP_PERREMA
 ,DEP_DEPREPERIODO
 ,DATENAME(year,(dateadd(day,-1, DEP_FECHAPROX)))+' '+DATENAME(month,(dateadd(day,-1, DEP_FECHAPROX))) as fecha

 FROM DEPRECIACION
 where act_id=@id
 order by DEP_ID">
            <SelectParameters>
                <asp:Parameter Name="id" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    <uc1:messbox ID="messbox1" runat="server" />
    </form>
</body>
</html>

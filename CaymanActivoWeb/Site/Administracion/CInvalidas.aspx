<%@ Page Language="C#" MasterPageFile="~/Site/Activos/cay.master" AutoEventWireup="true" CodeFile="CInvalidas.aspx.cs" Inherits="Site_Administracion_CInvalidas" %>

<%@ Register src="../../Ctrl/Msg/messbox.ascx" tagname="messbox" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" Runat="Server">
    <div align="center">
        <asp:SqlDataSource ID="UserNameBreakDownDataSource"
            runat="server" ConnectionString="<%$ ConnectionStrings:base %>" SelectCommand="SELECT UserName, COUNT(*)&#13;&#10;FROM InvalidCredentialsLog&#13;&#10;GROUP BY UserName">
        </asp:SqlDataSource>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <br />
                <strong>Reporte de Autenticación Fallida</strong><br /> <br />
                <asp:FormView ID="SummaryReport" runat="server" DataSourceID="SummaryDataSource"
                    Width="650px">
                    <ItemTemplate>
                        <table id="TABLE1" border="0" cellpadding="3" cellspacing="0" 
                            style="border-right: #333 1px solid;
                            border-top: #333 1px solid; border-left: #333 1px solid; width: 650px; border-bottom: #333 1px solid; font-size: 9pt; font-family: Arial;">
                            <tr>
                                <td align="right" class="txtOk" colspan="5" style="color: white; background-color: #597aa4;
                                    text-align: left">
                                    Intentos Fallidos</td>
                            </tr>
                            <tr>
                                <td align="right" class="txtOk" style="width: 158px">
                                    En las pasadas 24 horas:</td>
                                <td style="width: 73px; text-align: left;">
                                    <asp:Label ID="Ultimas24H" runat="server" Text='<%# Eval("Ultimas24H", "{0:n0}") %>' CssClass="txtOk"></asp:Label></td>
                                <td style="width: 11px">
                                    &nbsp;</td>
                                <td colspan="2" rowspan="4">
                                    <br />
                                    <asp:GridView ID="UserNameBreakdown" runat="server" AllowPaging="True" AllowSorting="True"
                                        AutoGenerateColumns="False" CellPadding="1" DataSourceID="UserNameBreakDownDataSource"
                                        EnableViewState="False" ForeColor="#333333" PageSize="5" CssClass="txtOk" 
                                        Font-Names="Arial" Font-Size="9pt" Width="293px">
                                        <FooterStyle BackColor="#E0E0E0" Font-Bold="False" ForeColor="White" Font-Names="Arial" Font-Size="9pt" Height="30px" />
                                        <Columns>
                                            <asp:BoundField DataField="UserName" HeaderText="Usuario" SortExpression="UserName" />
                                            <asp:BoundField DataField="Column1" HeaderText="Intentos Fallidos" ReadOnly="True"
                                                SortExpression="Column1" />
                                        </Columns>
                                        <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True" />
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <EditRowStyle BackColor="#999999" />
                                    </asp:GridView>
                                    &nbsp;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="txtOk" style="width: 158px">
                                    En la semana pasada:</td>
                                <td style="width: 73px; text-align: left;">
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("UltimaSemana", "{0:n0}") %>' CssClass="txtOk"></asp:Label></td>
                                <td style="width: 11px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" class="txtOk" style="width: 158px">
                                    En el pasado mes:</td>
                                <td style="width: 73px; text-align: left;">
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("UltimoMes", "{0:n0}") %>' CssClass="txtOk"></asp:Label></td>
                                <td style="width: 11px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" class="txtOk" style="width: 158px">
                                    Total:</td>
                                <td style="width: 73px; text-align: left;">
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("Total", "{0:n0}") %>' CssClass="txtOk"></asp:Label></td>
                                <td style="width: 11px">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:FormView>
                <table cellspacing="0">
                    <tr>
                        <td width="140">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td align="right" width="110">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td width="140">
                            Usuarios Bloqueados:</td>
                        <td>
                            <asp:DropDownList ID="ddbloqueados" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td width="15">
                            &nbsp;</td>
                        <td align="right" width="110">
                            <asp:ImageButton ID="ibDesbl" runat="server" Height="27px" 
                                ImageUrl="~/Img/ub1.png" onclick="ibDesbl_Click" Width="164px" />
                        </td>
                    </tr>
                    <tr>
                        <td width="140">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td align="right" width="110">
                            &nbsp;</td>
                    </tr>
                </table>
                <asp:GridView ID="DetailedReport" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" CellPadding="1" DataSourceID="DetailReportDataSource"
                    EnableViewState="False" ForeColor="#333333" 
                    CssClass="txtOk" Font-Names="Arial" Font-Size="9pt" Width="750px" PageSize="15" 
                    DataKeyNames="UserName">
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="False" ForeColor="White" Font-Names="Arial" Font-Size="9pt" Height="30px" />
                    <Columns>
                        <asp:BoundField DataField="UserName" HeaderText="Usuario" SortExpression="UserName" />
                        <asp:BoundField DataField="Password" HeaderText="Contrase&#241;a" SortExpression="Password" />
                        <asp:CheckBoxField DataField="IsApproved" HeaderText="Aprobado?" SortExpression="IsApproved" />
                        <asp:CheckBoxField DataField="IsLockedOut" HeaderText="Bloqueado?" SortExpression="IsLockedOut" />
                        <asp:BoundField DataField="IPAddress" HeaderText="Direccion IP" SortExpression="IPAddress" />
                        <asp:BoundField DataField="LoginAttemptDate" HeaderText="Fecha" SortExpression="LoginAttemptDate" />
                    </Columns>
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <EditRowStyle BackColor="#999999" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
    
    </div>
        <asp:SqlDataSource ID="SummaryDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:base %>" SelectCommand="usp_SummaryLoginS"
            SelectCommandType="StoredProcedure"></asp:SqlDataSource>
        <asp:SqlDataSource ID="DetailReportDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:base %>" SelectCommand="SELECT [UserName], [Password], [IsApproved], [IsLockedOut], [IPAddress], [LoginAttemptDate] FROM [InvalidCredentialsLog] ORDER BY [LoginAttemptDate] DESC">
        </asp:SqlDataSource>

    <uc1:messbox ID="messbox1" runat="server" />

</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Site/Activos/cay.master" AutoEventWireup="true" CodeFile="ImprimirCod.aspx.cs" Inherits="Site_Activos_ImprimirCod" EnableEventValidation="false" %>

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
        GroupingText="Generación de Código de Barras">
        <table class="panmar">
            <tr>
                <td>
                    <table cellspacing="0" class="style1">
                        <tr>
                            <td width="160" height="18">
                                <h5>Empresa:</h5></td>
                            <td>
                                <h5><asp:Label ID="lblEmpresa" runat="server"></asp:Label></h5>
                            </td>
                        </tr>
                        <tr>
                            <td width="160" height="18">
                                <h5>Tipo de Código de Barras:</h5></td>
                            <td>
                                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="txtdd" Width="20%">
                                    <asp:ListItem Selected="True" Value="N">Normal (5.7 x 1.9 cm)</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td height="18">
                                <h5>Último Secuencial Impreso:</h5></td>
                            <td>
                                <asp:UpdatePanel ID="upult" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <telerik:RadTextBox ID="txtultimocod" runat="server" MaxLength="4" 
                                            Width="50px" Enabled="False" CssClass="form-control">
                                            <ClientEvents OnKeyPress="KeyPress" />
                                            <EmptyMessageStyle Font-Italic="True" />
                                        </telerik:RadTextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <h5>Número de Códigos:
                                <asp:RequiredFieldValidator ID="rfvtipo3" runat="server" 
                                    ControlToValidate="txtnumcodigos" 
                                    ErrorMessage="Ingrese Número de Códigos a Imprimir" ValidationGroup="1" 
                                    ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </h5>
                            </td>
                            <td class="aacl">
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="94">
                                            <telerik:RadTextBox ID="txtnumcodigos" runat="server" MaxLength="4"  CssClass="form-control"
                                                Width="50px">
                                                <ClientEvents OnKeyPress="KeyPress" />
                                                <EmptyMessageStyle Font-Italic="True" />
                                            </telerik:RadTextBox>
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="ibimp1" runat="server" Height="30px" 
                                                ImageUrl="~/Img/imp1.png" onclick="ibxls1_Click" ValidationGroup="1" 
                                                Width="92px" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:HyperLink ID="hk5" runat="server" CssClass="ima" Height="29px" 
                        ImageUrl="~/Img/cod1.png" NavigateUrl="~/Site/Impresion/HCodigos.aspx" 
                        Target="_blank" ToolTip="Ver Códigos Generados" Width="167px"></asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadGrid ID="rgcodigos" runat="server" CellSpacing="0" GridLines="None" CssClass="table table-hover">
                    </telerik:RadGrid>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:ValidationSummary ID="vs1" runat="server" ShowMessageBox="True" 
        ShowSummary="False" ValidationGroup="1" />
    <uc1:messbox ID="messbox1" runat="server" />
</asp:Content>


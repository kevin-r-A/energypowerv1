<%@ Page Language="C#" MasterPageFile="~/Site/Activos/cay.master" AutoEventWireup="true" CodeFile="DetContable.aspx.cs" Inherits="Site_Activos_DetContable" EnableEventValidation="false"  %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register src="../../Ctrl/Wait/wait.ascx" tagname="wait" tagprefix="uc1" %>
<%@ Register src="../../Ctrl/Msg/messbox.ascx" tagname="messbox" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            height: 19px;
        }
        .relo
        {}
        .style3
        {
            width: 36%;
        }
        .style4
        {
            width: 32%;
        }
        .style5
        {
            width: 227px;
        }
        .style6
        {
            height: 19px;
            width: 227px;
        }
        .style7
        {
            width: 28%;
        }
    </style>
    </asp:Content>

    <asp:Content ID="PanelGeneral" runat="server" contentplaceholderid="cph1">
        <script type="text/javascript">
        function KeyPress(sender, args) {
            var regexp = new RegExp("[0-9]{1}|[\b]|\t|\r");
            if (!args.get_keyCharacter().match(regexp))
                args.set_cancel(true);
        }

</script>

        <asp:Panel ID="panbus0" runat="server" CssClass="panmar" 
        GroupingText="Buscar Activo - Modificar">
        <table cellpadding="0" cellspacing="0" class="panmar2"><tr>
                                <td class="aatl"><table cellspacing="0" class="style1"><tr><td width="115">Código de Barras:<asp:RequiredFieldValidator 
                                        ID="rfv1" runat="server" ControlToValidate="txtbuscb" 
                                        ErrorMessage="Ingrese Código de Barras" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="rfv1_ValidatorCalloutExtender" runat="server" 
                                        Enabled="True" TargetControlID="rfv1" PopupPosition="BottomRight">
                                    </asp:ValidatorCalloutExtender>
                                    </td>
                                    <td width="160">
                                        <telerik:RadTextBox ID="txtbuscb" runat="server" MaxLength="20" Width="150px">
                                            <passwordstrengthsettings calculationweightings="50;15;15;20" 
                                                indicatorelementbasestyle="riStrengthBar" indicatorelementid="" 
                                                minimumlowercasecharacters="2" minimumnumericcharacters="2" 
                                                minimumsymbolcharacters="2" minimumuppercasecharacters="2" 
                                                onclientpasswordstrengthcalculating="" preferredpasswordlength="10" 
                                                requiresupperandlowercasecharacters="True" showindicator="False" 
                                                textstrengthdescriptions="Very Weak;Weak;Medium;Strong;Very Strong" 
                                                textstrengthdescriptionstyles="riStrengthBarL0;riStrengthBarL1;riStrengthBarL2;riStrengthBarL3;riStrengthBarL4;riStrengthBarL5;" />
                                            <clientevents onkeypress="KeyPress" />
                                            <emptymessagestyle font-italic="True" />
                                        </telerik:RadTextBox>
                                    </td>
                                            <td width="22">
                                                <asp:ImageButton ID="ibbus1" runat="server" CssClass="relo" Height="20px" 
                                                    ImageUrl="~/Img/bus.png" onclick="ibbus1_Click" TabIndex="99" 
                                                    ToolTip="Buscar Código de Barras" ValidationGroup="1" Width="20px" />
                                    </td>
                                    <td class="aacr">
                                        <asp:Label ID="lblmsg" runat="server" ForeColor="#009933"></asp:Label>
                                    </td>
                                    </tr>
                                    <tr>
                                            <td>Id:<asp:RequiredFieldValidator ID="rfv2" runat="server" 
                                                    ControlToValidate="txtbusid" ErrorMessage="Ingrese ID" ForeColor="Red" 
                                                    ValidationGroup="2">*</asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="rfv2_ValidatorCalloutExtender" runat="server" 
                                                    Enabled="True" TargetControlID="rfv2" PopupPosition="BottomRight">
                                                </asp:ValidatorCalloutExtender>
                                            </td><td>
                                                <telerik:RadTextBox ID="txtbusid" runat="server" MaxLength="20" Width="70px">
                                                    <passwordstrengthsettings calculationweightings="50;15;15;20" 
                                                        indicatorelementbasestyle="riStrengthBar" indicatorelementid="" 
                                                        minimumlowercasecharacters="2" minimumnumericcharacters="2" 
                                                        minimumsymbolcharacters="2" minimumuppercasecharacters="2" 
                                                        onclientpasswordstrengthcalculating="" preferredpasswordlength="10" 
                                                        requiresupperandlowercasecharacters="True" showindicator="False" 
                                                        textstrengthdescriptions="Very Weak;Weak;Medium;Strong;Very Strong" 
                                                        textstrengthdescriptionstyles="riStrengthBarL0;riStrengthBarL1;riStrengthBarL2;riStrengthBarL3;riStrengthBarL4;riStrengthBarL5;" />
                                                    <clientevents onkeypress="KeyPress" />
                                                    <emptymessagestyle font-italic="True" />
                                                </telerik:RadTextBox>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ibbus3" runat="server" CssClass="relo" Height="20px" 
                                                    ImageUrl="~/Img/bus.png" onclick="ibbus3_Click" TabIndex="99" 
                                                    ToolTip="Buscar Id" ValidationGroup="2" Width="20px" />
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                    </tr></table></td></tr></table>
                                    </asp:Panel>


 
    
    
           <asp:Panel ID="Panel1" runat="server" Visible="false" CssClass="panmar" GroupingText="Ingresar detalle contable">
           
           <asp:Panel ID="PanelInfor" runat="server">
           <table>
           <tr>
           <td class="style1" width="510">
           <asp:Panel ID="Datos" runat="server" GroupingText="Identificación" Width="1300">
           <table>
           <tr>
           <td>Id:</td>
           <td>
               <asp:Label ID="lbl_Id" runat="server" Text="[ID]"></asp:Label>
               </td>

           </tr>
           <tr>
           <td>Código de barras:</td>
           <td>
               <asp:Label ID="lbl_CodBarras" runat="server" Text="[Cod. Barras]"></asp:Label>
               </td>

           </tr>
           </table>
           </asp:Panel>
           </td>
           </tr>
           </table>

                      <asp:Panel ID="Panel23" runat="server" GroupingText="Información técnica y ubicación">
           <table  cellpadding="1" cellspacing="1" class="style1">
           <tr>
           <td class="style4" width="310" >
               <asp:Image ID="Image2" runat="server" ImageUrl="~/Img/a2.png" />
               </td>
           <td class="style3" width="310" >
               <asp:Image ID="Image3" runat="server" ImageUrl="~/Img/a3.png" />
               </td>
               <td width="310" >
               <asp:Image ID="Image4" runat="server" ImageUrl="~/Img/a4.png" />
               </td>
           </tr>

           <tr>

                      <td class="style4" width="310" >
                      <asp:Panel ID="PanelTipo" runat="server">
           <table>

           <tr>
           <td>Grupo:</td>
           <td>
               <asp:Label ID="lbl_Grupo" runat="server" Text="[Grupo]"></asp:Label>
               </td>
           </tr>

                      <tr>
           <td>Subgrupo:</td>
           <td>
               <asp:Label ID="lbl_Subgrupo" runat="server" Text="[SubGrupo]"></asp:Label>
                          </td>
           </tr>

                      <tr>
           <td>Cuenta:</td>
           <td>
               <asp:Label ID="lbl_Descripcion" runat="server" Text="[Descripcion]"></asp:Label>
                          </td>
           
           
           
           </tr>

           </table>
           </asp:Panel>
           </td>

           <td class="style4" width="310">
           <asp:Panel ID="Panel_Ubi" runat="server" Width="273px">
           <table>
           
           <tr>
           <td>Ub. Geográfica 1:</td>
           <td>
               <asp:Label ID="lbl_UbGeo1" runat="server" Text="[Ubicación Geografica 1]"></asp:Label>
               </td>
           </tr>

           <tr>
           <td>Ub. Geográfica 2:</td>
           <td>
               <asp:Label ID="bl_UbiGeo2" runat="server" Text="[Ubicación Geografica 2]"></asp:Label>
               </td>
           </tr>

           <tr>
           <td>Ub. Geográfica 3:</td>
           <td>
               <asp:Label ID="lbl_UbiGeo3" runat="server" Text="[Ubicación Geografica 3]"></asp:Label>
               </td>
           </tr>
           </table>
           
           </asp:Panel>


           </td>



           <td class="style4" width="310">
           <asp:Panel ID="PanelUbiOrg" runat="server">
           <table>
           <tr>
           <td>Centro de costo:</td>
           <td>
               <asp:Label ID="lbl_ceCosto" runat="server" Text="[Centro de costo]"></asp:Label>
               </td>
           </tr>
           <tr>
           <td>Ubi. Orgánica 2:</td>
           <td>
               <asp:Label ID="lbl_UbiOrg" runat="server" Text="[Ubi. Organica]"></asp:Label>
               </td>
           </tr>
           <tr>
           <td>Custodio:</td>
           <td>
               <asp:Label ID="lbl_custodio" runat="server" Text="[Custodio]"></asp:Label>
               </td>
           </tr>
           </table>
           </asp:Panel>
           </td>
           </tr>

           </table>
           </asp:Panel>

           </asp:Panel>
           

           <asp:Panel ID="PanelDetContable" runat="server" GroupingText="Información Contable">
        <table>
        <tr>
        <td height="30"></td>
        <td height="30"></td>
        <td height="30"></td>
        </tr>

        <tr>

        <td class="style7"></td>
        
        <td width="100%">
        
        <table>
        <tr>
        <td align="center" width="100%">

            <asp:Image ID="Image1" runat="server" ImageUrl="~/Img/a7.png" />
        </td>
        </tr>

        <tr>
        <td align="center">
        
        <table>
        <tr>
        <td align="left">Ingreso:</td>
        <td align="left" class="style5">
            <asp:DropDownList ID="ddIngreso" runat="server" CssClass="txtdd">
            <asp:ListItem Selected="True">Compra</asp:ListItem>
            </asp:DropDownList>
            </td>
        </tr>
        
        <tr>
        <td align="left">Factura N°:</td>
        <td align="left" class="style5">
            <telerik:RadTextBox ID="txtFactura" Runat="server" EmptyMessage="Ingrese" MaxLength="10" Width="75px">
            <passwordstrengthsettings calculationweightings="50;15;15;20" 
                                                        indicatorelementbasestyle="riStrengthBar" indicatorelementid="" 
                                                        minimumlowercasecharacters="2" minimumnumericcharacters="2" 
                                                        minimumsymbolcharacters="2" minimumuppercasecharacters="2" 
                                                        onclientpasswordstrengthcalculating="" preferredpasswordlength="10" 
                                                        requiresupperandlowercasecharacters="True" showindicator="False" 
                                                        textstrengthdescriptions="Very Weak;Weak;Medium;Strong;Very Strong" 
                                                        
                                                            
                                                            textstrengthdescriptionstyles="riStrengthBarL0;riStrengthBarL1;riStrengthBarL2;riStrengthBarL3;riStrengthBarL4;riStrengthBarL5;" />
                                                        <clientevents 
                                                        onkeypress="KeyPress" />
                                                        <emptymessagestyle font-italic="True" />
            
            </telerik:RadTextBox>
            </td>
        </tr>
        <tr>
        <td align="left">Fecha de compra:</td>
        <td align="left" class="style5">
            <telerik:RadDatePicker ID="dtp_Compra" Runat="server">
            </telerik:RadDatePicker>
            </td>
        </tr>

        <tr>
        <td align="left">Valor de compra:</td>
        <td align="left" class="style5">
            <asp:TextBox ID="txtValCompra" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
        <td class="style2" align="left">Vida útil:</td>
        <td class="style6" align="left">
            <asp:Label ID="Lbl_Vidautil" runat="server" Text="[Vida Útil]"></asp:Label>
            </td>
        </tr>


        <tr>
        <td align="left">Vida útil NIFF:</td>
        <td align="left" class="style5">
            <asp:TextBox ID="txt_VidautilNiff" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
        
        <td align="left">Valor Residual NIFF:</td>
        <td align="left" class="style5">
            <asp:TextBox ID="txt_ValResNIFF" runat="server"></asp:TextBox>
            </td>
        </tr>


        <tr>
        <td align="left">Inicio de operaciones:</td>
        <td align="left" class="style5">
            <telerik:RadDatePicker ID="dtp_Inicio" Runat="server">
            </telerik:RadDatePicker>
        </td>
        </tr>
        </table>
        
        </td>
        </tr>

        </table>
        
        </td>
        <td width="25%"></td>


        </tr>

        </table>

        </asp:Panel>

        <asp:Panel ID="Panel_Botones" runat="server">
        <table>
                <tr>
                <td Width="310"></td>
        <td class="style1" align="right" width="310">
            <asp:ImageButton ID="ibcancel" runat="server" ImageUrl="~/Img/c1.png" 
                onclick="ibcancel_Click" />
            <asp:ImageButton ID="ibsave" runat="server" ImageUrl="~/Img/s1.png" 
                onclick="ImageButton2_Click" />
         </td>

        </tr>
        </table>
        
        </asp:Panel>

        </asp:Panel>

        
        
    <uc2:messbox ID="messbox1" runat="server" />
    
    </asp:Content>

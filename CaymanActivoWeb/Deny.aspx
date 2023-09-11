<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Deny.aspx.cs" Inherits="Deny" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ACCESO DENEGADO</title>
    <link href="App_Themes/Theme1/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="aacc">
    
        &nbsp;<table cellspacing="0" class="style1">
            <tr>
                <td>
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Img/m_e.png" 
                        ToolTip="Acceso Denegado" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
&nbsp;Usted no está autorizado para ingresar a esta página, solicite su rol de acceso al 
        Administrador del Sistema.</div>
    </form>
</body>
</html>

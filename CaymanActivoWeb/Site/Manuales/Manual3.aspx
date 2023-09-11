<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Manual3.aspx.cs" Inherits="Site_Manuales_Manual3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../App_Themes/Theme1/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <object id="VIDEO" classid="CLSID:6BF52A52-394A-11d3-B153-00C04F79FAA6" type="application/x-oleobject" width="800" height="600">
   <param name="URL" value="Videos/inventarios.asf" />
   <param name="enabled" value="True" />
   <param name="AutoStart" value="True" />
   <param name="PlayCount" value="3" />
   <param name="Volume" value="50" />
   <param name="balance" value="0" />
   <param name="Rate" value="1.0" />
   <param name="Mute" value="False" />
   <param name="fullScreen" value="False" />
   <param name="uiMode" value="full" />
</object>
    </div>
    </form>
</body>
</html>

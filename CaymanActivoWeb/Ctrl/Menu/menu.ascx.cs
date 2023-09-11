using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Ctrl_Menu_menu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void RadMenu1_ItemDataBound(object sender, Telerik.Web.UI.RadMenuEventArgs e)
    {
        //habilitar imagenes del archivo sitemap en el menu
        e.Item.ImageUrl = ((SiteMapNode)e.Item.DataItem)["image"];
    }
}
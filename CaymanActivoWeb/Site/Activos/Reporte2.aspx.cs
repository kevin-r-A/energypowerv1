using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Services;
using Telerik.Web.UI;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;


public partial class Reporte2 : System.Web.UI.Page
{    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if ((string)(Session["emid"]) == null)
            {
                Session.Abandon();
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }
        catch
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

        if (!IsPostBack)
        {
            this.Title = ConfigurationManager.AppSettings["Titulo"] + " Reporte de Activos";
            Unit u = new Unit(Convert.ToDouble(ConfigurationManager.AppSettings["Rgalto2"]), UnitType.Pixel);
            rgactivos.Height = u;
        }       
    }
    protected void RadGrid1_ItemCommand(object source, GridCommandEventArgs e)
    {
        if (e.CommandName == "FilterRadGrid")
        {
            rf1.FireApplyCommand();
        }
    }
    protected void RadToolBar1_ButtonClick(object sender, RadToolBarEventArgs e)
    {
        //
    }

    protected void rf1_PreRender(object sender, EventArgs e)
    {
        var menu = rf1.FindControl("rfContextMenu") as RadContextMenu;
        menu.DefaultGroupSettings.Height = Unit.Pixel(450);
        menu.EnableAutoScroll = true;
    }
}

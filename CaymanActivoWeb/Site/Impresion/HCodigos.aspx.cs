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
using System.Globalization;
using System.Web.Security;
using System.Drawing;
using System.Web.UI.HtmlControls;
using iTextSharp;
using iTextSharp.text.pdf;

public partial class HCodigos : System.Web.UI.Page
{
    ErrorTrapper errtrap;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = ConfigurationManager.AppSettings["Titulo"] + " Códigos Generados";

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
    }

    protected void ibxls1_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            rgdepre.ExportSettings.FileName = "CodigosGenerados_" + DateTime.Now.ToShortDateString().Replace('/', '_');
            foreach (GridItem commandItem in this.rgdepre.MasterTableView.GetItems(GridItemType.CommandItem))
            {
                commandItem.Visible = false;
            }
            rgdepre.MasterTableView.ExportToExcel();
        }
        catch (Exception ex)
        {
            errtrap = new ErrorTrapper();
            errtrap.SetOnError("Usuario:" + Membership.GetUser().UserName + "<< " + ex.Message, 0);
            messbox1.Mensaje = "Error: " + ex.Message;
            messbox1.Tipo = "E";
            messbox1.showMess();
        }
    }
}
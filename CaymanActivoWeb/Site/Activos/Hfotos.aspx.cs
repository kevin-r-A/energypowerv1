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

public partial class Hfotos : System.Web.UI.Page
{
    ErrorTrapper errtrap;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = ConfigurationManager.AppSettings["Titulo"] + " Historial Fotográfico";
        ibxls1.Attributes.Add("onmouseout", "this.src='../../Img/pdf1.png'");
        ibxls1.Attributes.Add("onmouseover", "this.src='../../Img/pdf2.png'");

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

        try
        {
            string ide = Request["id"];
            if (ide != null)
            {
                SqlDataSource1.SelectParameters["act_id"].DefaultValue = ide;
                rgdepre.DataBind();
            }
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
    protected void ibxls1_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            //rgdepre.Columns[4].Visible = false; //responsable
            rgdepre.Columns[5].Visible = false; //link 1
            rgdepre.Columns[7].Visible = false; //link 2
            rgdepre.ExportSettings.FileName = "fotos_id_" + Request["id"];
            rgdepre.MasterTableView.ExportToPdf();
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
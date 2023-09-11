using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Configuration;

public partial class Depre : System.Web.UI.Page
{
    ErrorTrapper errtrap;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = ConfigurationManager.AppSettings["Titulo"] + " Detalle de Depreciación NIIF";
        ibxls1.Attributes.Add("onmouseout", "this.src='../../Img/xls1.png'");
        ibxls1.Attributes.Add("onmouseover", "this.src='../../Img/xls2.png'");

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
                SqlDataSource1.SelectParameters["id"].DefaultValue = ide;
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
            rgdepre.ExportSettings.FileName = "depNIIF_id_" + Request["id"];
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
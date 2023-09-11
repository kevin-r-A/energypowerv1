using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using System.Drawing;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;
using System.Configuration;

public partial class BackupBdd : System.Web.UI.Page
{
    ErrorTrapper errtrap;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = ConfigurationManager.AppSettings["Titulo"] + " Respaldo de Información";
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
            ibtnBackup.Attributes.Add("onmouseout", "this.src='../../Img/bdd1.png'");
            ibtnBackup.Attributes.Add("onmouseover", "this.src='../../Img/bdd2.png'");
        }        

        cargarRespaldos();
    }

    private void cargarRespaldos()
    {
        try
        {
            string folderToBrowse = Server.MapPath(".") + "/Backup";
            DirectoryInfo DirInfo = new DirectoryInfo(folderToBrowse);
            gvDeprec.DataSource = DirInfo.GetFileSystemInfos("*.bak");
            gvDeprec.DataBind();
            Cache["Dinfo"] = DirInfo;
        }
        catch (Exception ex)
        {
            errtrap = new ErrorTrapper();
            errtrap.SetOnError("Usuario:" + Membership.GetUser().UserName + "<< " + ex.Message, 0);
            messbox1.Mensaje = "Error. " + ex.Message;
            messbox1.Tipo = "E";
            messbox1.showMess();
        }
    }

    protected void ibtnBackup_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            Logica.HELPER.backbdd(Server.MapPath(".") + @"\Backup");

            messbox1.Mensaje = "Base de Datos Respaldada con éxito!.";
            messbox1.Tipo = "S";
            messbox1.showMess();
        }
        catch (Exception ex)
        {
            errtrap = new ErrorTrapper();
            errtrap.SetOnError("Usuario:" + Membership.GetUser().UserName + "<< " + ex.Message, 0);
            messbox1.Mensaje = "Error: " + ex.Message;
            messbox1.Tipo = "E";
            messbox1.showMess();
        }
        finally
        {
            cargarRespaldos();
        }
    }
}
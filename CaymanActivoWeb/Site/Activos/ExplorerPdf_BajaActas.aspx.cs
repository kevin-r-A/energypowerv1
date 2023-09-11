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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Site_Activos_ExplorerPdf_BajaActas : System.Web.UI.Page
{
    ErrorTrapper errtrap;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            this.Title = ConfigurationManager.AppSettings["Titulo"] + " Actas Generadas de Activos Dados de Baja";
            string folderToBrowse = Server.MapPath("./PDF_ACTBAJA/");
            DirectoryInfo DirInfo = new DirectoryInfo(folderToBrowse);
            FileSystemInfo[] files = DirInfo.GetFileSystemInfos();
            Array.Sort<FileSystemInfo>(files, delegate(FileSystemInfo b, FileSystemInfo a)
            {
                return a.LastWriteTime.CompareTo(b.LastWriteTime);
            });
            rgtras.DataSource = files;
            rgtras.DataBind();
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
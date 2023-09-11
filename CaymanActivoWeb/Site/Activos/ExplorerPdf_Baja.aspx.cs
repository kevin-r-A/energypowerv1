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

public partial class ExplorerPdf_Baja : System.Web.UI.Page
{
    ErrorTrapper errtrap;

    private void Page_Load(object sender, System.EventArgs e)
    {
        try
        {
            this.Title = ConfigurationManager.AppSettings["Titulo"] + " Reporte de Activos Dados de Baja";
            string folderToBrowse = Server.MapPath("./adjuntos_baja/");
            DirectoryInfo DirInfo = new DirectoryInfo(folderToBrowse);
            FileSystemInfo[] files = DirInfo.GetFileSystemInfos();
            Array.Sort<FileSystemInfo>(files, delegate(FileSystemInfo a, FileSystemInfo b) 
            { 
                return b.LastWriteTime.CompareTo(a.LastWriteTime); 
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
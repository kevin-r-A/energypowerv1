using System;
using System.Configuration;
using System.IO;
using System.Web.Security;

public partial class Site_Mantenimiento_ExplorerPdf_Actas : System.Web.UI.Page
{
    ErrorTrapper errtrap;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            this.Title = ConfigurationManager.AppSettings["Titulo"] + " Documentos Adjuntos Mantenimientos";
            string folderToBrowse = Server.MapPath("./NuevoMant/PDF/");
            DirectoryInfo DirInfo = new DirectoryInfo(folderToBrowse);
            FileSystemInfo[] files = DirInfo.GetFileSystemInfos();
            Array.Sort<FileSystemInfo>(files, delegate(FileSystemInfo a, FileSystemInfo b)
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
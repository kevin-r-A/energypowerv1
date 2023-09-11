using System;
using System.Configuration;
using System.IO;
using System.Web.Security;


public partial class ExplorerPdf : System.Web.UI.Page
{
    ErrorTrapper errtrap;

    private void Page_Load(object sender, System.EventArgs e)
    {
        try
        {
            this.Title = ConfigurationManager.AppSettings["Titulo"] + " Reporte de Inventario Movil - Actas Generadas";
            string folderToBrowse = Server.MapPath("./PDF/");
            DirectoryInfo DirInfo = new DirectoryInfo(folderToBrowse);
            FileSystemInfo[] files = DirInfo.GetFileSystemInfos("*.PDF");
            Array.Sort<FileSystemInfo>(files, delegate(FileSystemInfo a, FileSystemInfo b) { return b.LastWriteTime.CompareTo(a.LastWriteTime); });
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
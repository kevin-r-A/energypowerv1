using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Drawing;
using System.IO;
using System.Configuration;



[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class TransPpc : System.Web.Services.WebService
{

    string rutafotos = ConfigurationManager.AppSettings["DIRFOTO"];

   // string rutafotos = "~/Site/Activos/im/";
    public TransPpc()
    {
        //InitializeComponent(); 
        AppDomain.CurrentDomain.SetData("SQLServerCompactEditionUnderWebHosting", true);
    }

    private TransferFile transferFile = new TransferFile();

    [WebMethod(Description = "Web service provides mothed,return the array of byte")]
    public byte[] DownloadFile(string fileName)
    {
        return transferFile.ReadBinaryFile(rutafotos, fileName);
    }

    [WebMethod(Description = "Web service provides mothed，if upload file successfully。")]
    public string UploadFile(byte[] fs, string fileName)
    {
        return transferFile.WriteBinarFile(fs, rutafotos, fileName);
    }

    [WebMethod]
    public String[] GetName()
    {
        return transferFile.getImg();
    }

    class TransferFile
    {
        string rutafotos = ConfigurationManager.AppSettings["DIRFOTO"];
       // string rutafotos = "~/Site/Activos/im/";

        public TransferFile() { }

        public string WriteBinarFile(byte[] fs, string path, string fileName)
        {
            try
            {
                MemoryStream memoryStream = new MemoryStream(fs);
                FileStream fileStream = new FileStream(path + fileName, FileMode.Create);
                memoryStream.WriteTo(fileStream);
                memoryStream.Close();
                fileStream.Close();
                fileStream = null;
                memoryStream = null;
                return "File has already uploaded successfully。";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public byte[] ReadBinaryFile(string path, string fileName)
        {

            if (File.Exists(path + fileName))
            {
                try
                {
                    //FileStream fileStream = new FileStream(path + fileName, FileMode.Open, FileAccess., FileShare.Read);

                    ///Open and read a file。

                    FileStream fileStream = File.OpenRead(path + fileName);
                    return ConvertStreamToByteBuffer(fileStream);

                }
                catch (Exception ex)
                {
                    return new byte[0];
                }
                finally
                {
                    //fileStream.Close();
                    //fileStream.Dispose();                
                }
            }
            else
            {
                return new byte[0];
            }


        }

        public byte[] ConvertStreamToByteBuffer(System.IO.Stream theStream)
        {
            int b1;
            System.IO.MemoryStream tempStream = new System.IO.MemoryStream();
            while ((b1 = theStream.ReadByte()) != -1)
            {
                tempStream.WriteByte(((byte)b1));
            }
            return tempStream.ToArray();
        }

        public String[] getImg()
        {

            DirectoryInfo di = new DirectoryInfo(rutafotos);
            //FileInfo[] rgFiles = di.GetFiles("*.jpg");
            FileInfo[] rgFiles = di.GetFiles();
            String[] files = new String[rgFiles.Length];
            int cont = 0;
            foreach (FileInfo fi in rgFiles)
            {
                files[cont] = fi.Name;
                cont++;
            }
            return files;
        }
    }

}

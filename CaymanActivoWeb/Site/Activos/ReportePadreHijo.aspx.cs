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
using iTextSharp.text;
using iTextSharp.text.pdf;

public partial class ReportePadreHijo : System.Web.UI.Page
{
    ErrorTrapper errtrap;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = ConfigurationManager.AppSettings["Titulo"] + " Reporte Unidad Funcional - Componente";

        try
        {
            if (!Page.IsPostBack)
            {
                RadTreeList1.ExpandToLevel(1);
                upgrid.Update();
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
    protected void RadTreeList1_NeedDataSource(object sender, TreeListNeedDataSourceEventArgs e)
    {
        RadTreeList1.DataSource = MyData.GetData();
    }
    protected void ib_Excel_Click(object sender, ImageClickEventArgs e)
    {
    
    }
}
   
public class MyData
    {
    ErrorTrapper errtrap;

        public static List<MyItem> GetData()
        {
                List<MyItem> list = new List<MyItem>();

                DataTable dt = Logica.HELPER.getActivosPadre();
                foreach (DataRow row in dt.Rows)
                {
                    string[] arr = new string[5];
                    for (int i = 0; i < 5; i++)
                    {
                        arr[i] = row[i].ToString();
                    }

                    list.Add(new MyItem(arr[0], arr[1], arr[2], arr[3], arr[4]));

                }
            return list;            
        }
    }
    public class MyItem
    {
        public string id { get; set; }
        public string codigosbarras { get; set; }
        public string descripcion { get; set; }
        public string valor { get; set; }
        public string parentID { get; set; }

        public MyItem(string ID, string Codigosbarras, string Descripcion, string Valor, string ParentID)
        {
            id = ID;
            codigosbarras = Codigosbarras;
            descripcion = Descripcion;
            valor = Valor;
            parentID = ParentID;

        }
    }
    

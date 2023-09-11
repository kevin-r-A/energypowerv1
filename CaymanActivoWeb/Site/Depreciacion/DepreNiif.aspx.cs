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

public partial class DepreNiif : System.Web.UI.Page
{
    ErrorTrapper errtrap;

    protected void Page_Load(object sender, EventArgs e)
    {
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
            this.Title = ConfigurationManager.AppSettings["Titulo"] + " Generar Depreciación NIIF";
            cargarmeses();
        }
    }

    private string mesLastDepre(DateTime nextDepre)
    {
        string mes = "";

        if (nextDepre.Month == 1)
            mes = "ENERO " + nextDepre.Year;
        else if (nextDepre.Month == 2)
            mes = "FEBRERO " + nextDepre.Year;
        else if (nextDepre.Month == 3)
            mes = "MARZO " + nextDepre.Year;
        else if (nextDepre.Month == 4)
            mes = "ABRIL " + nextDepre.Year;
        else if (nextDepre.Month == 5)
            mes = "MAYO " + nextDepre.Year;
        else if (nextDepre.Month == 6)
            mes = "JUNIO " + nextDepre.Year;
        else if (nextDepre.Month == 7)
            mes = "JULIO " + nextDepre.Year;
        else if (nextDepre.Month == 8)
            mes = "AGOSTO " + nextDepre.Year;
        else if (nextDepre.Month == 9)
            mes = "SEPTIEMBRE " + nextDepre.Year;
        else if (nextDepre.Month == 10)
            mes = "OCTUBRE " + nextDepre.Year;
        else if (nextDepre.Month == 11)
            mes = "NOVIEMBRE " + nextDepre.Year;
        else if (nextDepre.Month == 12)
            mes = "DICIEMBRE " + nextDepre.Year;

        return mes;
    }

    private void cargarmeses()
    {
        ddmeses.Items.Clear();
        DateTime nextDepre = Logica.HELPER.getMesDepre("NIIF");

        ListItem li = new ListItem(mesLastDepre(nextDepre), nextDepre.ToShortDateString());
        ddmeses.Items.Add(li);

        DateTime oldDate = nextDepre;
        DateTime newDate = DateTime.Now;
        TimeSpan ts = newDate - oldDate;

        //deshabilitar generacion si la fecha es mayor y el dia esta entre el 1 y 16
        if (ts.TotalDays>20)
        {
            ibbus1.Visible = true;
            ddmeses.Enabled = true;
        }
        else
        {
            ibbus1.Visible = false;
            ddmeses.Enabled = false;
        }
    }

    protected void ibbus1_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            DateTime nextDepre = Logica.HELPER.getMesDepre("NIIF");
            if (mesLastDepre(nextDepre) != ddmeses.SelectedItem.Text) //Si ya se ha generado la depreciacion en otra pestañas o explorador
            {
                //no se puede poner un redirect luego de un mensaje modalpopup, no aparece el mensaje
                //messbox1.Mensaje = "La depreciación que desea iniciar ya se generó con anterioridad";
                //messbox1.Tipo = "I";
                //messbox1.showMess();

                Response.Redirect("DepreNiif.aspx");
            }
            else
            {
                if (Logica.HELPER.getEstadoDepreciacion("NIIF") == "OUT") //SI NO HAY PROCESOS EN OTRA PAGINA WEB DEPRECIANDO LOS ACTIVOS
                {
                    Logica.HELPER.insDepreciacion(Convert.ToDateTime(ddmeses.SelectedValue), "NIIF", Membership.GetUser().UserName.ToLower());
                    SqlDataSource1.DataBind();
                    rgdepre.DataBind();
                    cargarmeses();

                    messbox1.Mensaje = "Depreciación generada con éxito!";
                    messbox1.Tipo = "S";
                    messbox1.showMess();
                }
                else
                {
                    messbox1.Mensaje = "Actualmente se encuentra realizando un proceso de depreciación pendiente";
                    messbox1.Tipo = "I";
                    messbox1.showMess();
                }
            }
        }
        catch (Exception ex)
        {
            errtrap = new ErrorTrapper();
            errtrap.SetOnError("Usuario:" + Membership.GetUser().UserName + "<< " + ex.Message, 0); //1 enviar mail

            messbox1.Mensaje = "Error. " + ex.Message;
            messbox1.Tipo = "E";
            messbox1.showMess();
        }

    }    

    protected void btnExcel_Click(object sender, EventArgs e)
    {
        rgdepre.ExportSettings.FileName = "NIIF_"+ddmeses.SelectedItem.Text.Replace(" ","");

        foreach (GridItem commandItem in this.rgdepre.MasterTableView.GetItems(GridItemType.CommandItem))
        {
            commandItem.Visible = false;
        }

        rgdepre.MasterTableView.ExportToExcel();    
    }
    protected void rgdepre_ExcelMLExportRowCreated(object sender, Telerik.Web.UI.GridExcelBuilder.GridExportExcelMLRowCreatedArgs e)
    {

    }
}

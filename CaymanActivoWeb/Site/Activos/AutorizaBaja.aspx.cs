using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using CustomEditors;

namespace Site.Activos
{
    public partial class AutorizaBaja : Page
    {
        private BajaDepre _depre = new BajaDepre();

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }
        private void CargarDatos()
        {
            DataTable dataTable = _depre.GetBajasPendientes();
            rgitems.DataSource = dataTable;
            rgitems.DataBind();

        }
        protected void rgitems_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.DataItem != null)
            {
                if ((bool)((DataRowView)e.Row.DataItem).Row.ItemArray[12])
                {
                    e.Row.FindControl("ibaceptar").Visible = true;
                    e.Row.FindControl("ibrechazar").Visible = true;
                }
                else
                {
                    e.Row.FindControl("ibaceptar").Visible = false;
                    e.Row.FindControl("ibrechazar").Visible = false;
                }
            }
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[8].Visible = false;
            e.Row.Cells[9].Visible = false;
            e.Row.Cells[13].Visible = false;
            e.Row.Cells[14].Visible = false;
        }
        protected void ibaceptar_OnClick(object sender, ImageClickEventArgs e)
        {
            ImageButton ib = sender as ImageButton;
            GridViewRow row = (GridViewRow)ib.NamingContainer;
            Session["rowBaja"] = row;
            int index = row.RowIndex;
            Boolean valido = true;
            Session["_codbarras"] = row.Cells[10].Text.Trim();

            if (row.Cells[3].Text.ToUpper() == "ACTIVO FIJO" || row.Cells[3].Text.ToUpper() == "Activo Fijo")
            {
                //Si los activos se someten a depreciacion antes de procesar la baja
                if (ConfigurationManager.AppSettings["BajaDepre"] == "SI")
                {
                    if (getMesesDepreBaja(row.Cells[2].Text))
                    {
                        valido = true;
                    }
                    else
                    {
                        valido = false;
                    }
                }
            }

            if (valido)
            {
                //chequear si tiene hijos
                int numhijos = Logica.HELPER.getNumHijos(row.Cells[1].Text);

                if (numhijos == 0)
                {
                    Logica.ACTIVO activo = new Logica.ACTIVO(int.Parse(row.Cells[2].Text));

                    //si no tiene hijos procesar la baja

                    Session["ruta_archivo"] = "";
                    /*Asiento*/
                    Logica.UGEOGRAFICA uge2 = Logica.UGEOGRAFICA.GetUGEOGRAFICA(activo.UGE_ID2);
                    Logica.UORGANICA uor1 = Logica.UORGANICA.GetUORGANICA(activo.UOR_ID2);
                    Logica.GRUPO gru1 = Logica.GRUPO.GetGRUPO(activo.GRU_ID1);
                    lblCuentaBaja.Text = ConfigurationManager.AppSettings["CUENTABAJA"];
                    lblOficina1.Text = "1";
                    lblCentroCosto1.Text = "22";
                    lblOficina2.Text = uge2.UGE_CODIGO;
                    lblCentroCosto2.Text = uor1.UOR_CODIGO;
                    lblOficinaDepre1.Text = uge2.UGE_CODIGO;
                    lblCentroCostoDepre1.Text = uor1.UOR_CODIGO;
                    lblCuentaActivo.Text = gru1.GRU_CTA1;
                    lblCuentaDepre.Text = gru1.GRU_CTA3;
                    lblDebito1.Text = (activo.ACT_VALORCOMPRA - activo.ACT_DEPREACUMULADA).ToString("#0.00");
                    lblDebito2.Text = "0.00";
                    lblDebitoDepre1.Text = activo.ACT_DEPREACUMULADA.ToString("#0.00");
                    lblCredito1.Text = "0.00";
                    lblCredito2.Text = activo.ACT_VALORCOMPRA.ToString("#0.00");
                    lblCreditoDepre1.Text = "0.00";
                    upbaja.Update();
                    mp2.Show();
                }
                else
                {
                   
                    messbox1.Mensaje = "No puede darlo de baja ya que es un item padre, primero debe dar de baja todos los items hijos de este activo.";
                    messbox1.Tipo = "W";
                    messbox1.showMess();
             
                }
            }
        

        }
        protected void ibrechazar_OnClick(object sender, ImageClickEventArgs e)
        {
            ImageButton ib = sender as ImageButton;
            GridViewRow row = (GridViewRow)ib.NamingContainer;
            int index = row.RowIndex;
            int APRACT_ID, ACTBAJ_ID, act_Id;
            string motivobaja, motivobajadesc;
            APRACT_ID = int.Parse(row.Cells[14].Text);
            ACTBAJ_ID = int.Parse(row.Cells[1].Text);
            act_Id = int.Parse(row.Cells[2].Text);
            motivobaja = row.Cells[6].Text;
            motivobajadesc = row.Cells[7].Text;
            var procesado = _depre.AprobarRechazar(APRACT_ID, 0, ACTBAJ_ID, act_Id, motivobaja, motivobajadesc, "");
            CargarDatos();
        }
        private void abreVentana(string ventana)
        {
            string funcion = "windowOpener('" + ventana + "')";

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "SIFEL", funcion, true);
        }

        protected void ibsave_Click(object sender, ImageClickEventArgs e)
        {
            GridViewRow row = (GridViewRow)Session["rowBaja"];
            int index = row.RowIndex;
            int APRACT_ID, ACTBAJ_ID, act_Id;
            string motivobaja, motivobajadesc;
            APRACT_ID = int.Parse(row.Cells[14].Text);
            ACTBAJ_ID = int.Parse(row.Cells[1].Text);
            act_Id = int.Parse(row.Cells[2].Text);
            motivobaja = row.Cells[6].Text;
            motivobajadesc = row.Cells[7].Text;
            var codbarras = row.Cells[10].Text;
            string nombreok = "";
            if (FileUpload1.HasFile)
            {
                try
                {
                    nombreok = "~/Site/Activos/adjuntos_baja/" + codbarras + "_" + FileUpload1.FileName;
                    FileUpload1.SaveAs(Server.MapPath(nombreok));
                }
                catch (System.Exception ex)
                {
                    //mensaje += " , </br> Documento no fue cargado: " + ex.Message;
                }
            }

            var procesado = _depre.AprobarRechazar(APRACT_ID, 1, ACTBAJ_ID, act_Id, motivobaja, motivobajadesc, nombreok);
            if (procesado)
            {
                Logica.ACTIVO activo = Logica.ACTIVO.GetACTIVO(act_Id);
                activo.CuentaOrigen = lblCuentaBaja.Text;
                activo.CuentaDestino = lblCuentaActivo.Text;
                activo.CuentaDepreOrigen = lblCuentaDepre.Text;
                activo.Oficina1 = lblOficina1.Text;
                activo.Oficina2 = lblOficina2.Text;
                activo.OficinaDepre1 = lblOficinaDepre1.Text;
                activo.CentroCosto1 = lblCentroCosto1.Text;
                activo.CentroCosto2 = lblCentroCosto2.Text;
                activo.CentroCostoDepre1 = lblCentroCostoDepre1.Text;
                Asientos.BajaActivo(activo);
                Datos.SqlService sql = new Datos.SqlService();
                Session["actId"] = act_Id;
                Session["reportName"] = "Acta Baja BA - " + System.DateTime.Now.ToString("ddMMyyyyHHmmss") + " - " + Session["actId"];
              
                //Session["MICORREOBAJA"] = sql.ExecuteSqlObject("select CUS_EMAIL from CUSTODIO INNER JOIN ACTIVO ON CUSTODIO.CUS_ID = ACTIVO.CUS_ID1 WHERE ACTIVO.ACT_ID = '" + act_Id + "'");
                //string asas = Session["MICORREOBAJA"].ToString();
                abreVentana("DexReport.aspx?reporte=baja");
            }

            CargarDatos();
            upbaja.Update();
            mp2.Hide();


        }

        protected void ibcancel_Click(object sender, ImageClickEventArgs e)
        {
            mp2.Hide();
        }
        private bool getMesesDepreBaja(string actid)
        {
            try
            {
                int dif = 0;
                dif = Logica.HELPER.getDifDepreBaja(actid);
                if (dif > 0)
                {
                    messbox1.Mensaje = "No puede dar de baja al activo, primero debe generar la depreciacion NIIF de todos los periodos anteriores. Periodos pendientes: [" + dif + "]";
                    messbox1.Tipo = "E";
                    messbox1.showMess();
                    return false;
                }
                else
                {
                    int dif2 = 0;
                    dif2 = Logica.HELPER.getDifDepreBajaTribu(actid);
                    if (dif2 > 0)
                    {
                        messbox1.Mensaje = "No puede dar de baja al activo, primero debe generar la depreciacion TRIBUTARIA de todos los periodos anteriores. Periodos pendientes: [" + dif2 + "]";
                        messbox1.Tipo = "E";
                        messbox1.showMess();
                        return false;
                    }
                    else
                        return true;
                }
            }
            catch (Exception ex)
            {
            
                messbox1.Mensaje = "Error: " + ex.Message;
                messbox1.Tipo = "E";
                messbox1.showMess();
                return false;
            }
        }
  
    }
    
}
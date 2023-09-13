using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CustomEditors;

namespace Site.Traslados
{
    public partial class AutorizaTraslado : Page
    {
        private Traslado _traslado = new Traslado();

        protected void Page_Load(object sender, EventArgs e)
        {
            CargaDatos();

        }
        private void CargaDatos()
        {
            rgitems.DataSource = _traslado.GetBajasPendientes();
            rgitems.DataBind();
        }
        protected void ibaceptar_OnClick(object sender, ImageClickEventArgs e)
        {
            ImageButton ib = sender as ImageButton;
            GridViewRow row = (GridViewRow)ib.NamingContainer;
            int APRACT_ID, ACTTRA_ID;
            Guid guid;
            APRACT_ID = int.Parse(row.Cells[22].Text);
            ACTTRA_ID = int.Parse(row.Cells[1].Text);
            guid = Guid.Parse(row.Cells[17].Text);
            DataTable activos = _traslado.GetAllActivos(guid);
            var procesado = _traslado.AprobarRechazarTraslados(APRACT_ID, 1, ACTTRA_ID);
            if (procesado)
            {
                var nuevosActivos = _traslado.GetAllActivos(guid);
                Datos.SqlService sql = new Datos.SqlService();
                Object uge1 = sql.ExecuteSqlObject("select UGE_NOMBRE from UGEOGRAFICA where UGE_ID='" + activos.Rows[0]["UGE_ID1"].ToString() + "'");
                Object uge2 = sql.ExecuteSqlObject("select UGE_NOMBRE from UGEOGRAFICA where UGE_ID='" + activos.Rows[0]["UGE_ID2"].ToString() + "'");
                Object uge3 = sql.ExecuteSqlObject("select UGE_NOMBRE from UGEOGRAFICA where UGE_ID='" + activos.Rows[0]["UGE_ID3"].ToString() + "'");
                Object uge4 = sql.ExecuteSqlObject("select UGE_NOMBRE from UGEOGRAFICA where UGE_ID='" + activos.Rows[0]["UGE_ID4"].ToString() + "'");

                Object uor1 = sql.ExecuteSqlObject("select UOR_NOMBRE from UORGANICA where UOR_ID='" + activos.Rows[0]["UOR_ID1"].ToString() + "'");
                Object uor2 = sql.ExecuteSqlObject("select UOR_NOMBRE from UORGANICA where UOR_ID='" + activos.Rows[0]["UOR_ID2"].ToString() + "'");
                Object uor3 = sql.ExecuteSqlObject("select UOR_NOMBRE from UORGANICA where UOR_ID='" + activos.Rows[0]["UOR_ID3"].ToString() + "'");

                Object nuevoCus = sql.ExecuteSqlObject("select (cus_nombres +' '+ CUS_apellidos) from CUSTODIO where cus_id='" +
                                                       nuevosActivos.Rows[0]["CUS_ID1"].ToString() + "'");

                Session["uge1"] = uge1;
                Session["uge2"] = uge2;
                Session["uge3"] = uge3;
                Session["uge4"] = uge4;
                Session["uor1"] = uor1;
                Session["uor2"] = uor2;
                Session["uor3"] = uor3;


                if (activos.Rows.Count == 1)
                {
                    Session["actId"] = activos.Rows[0]["ACT_ID"].ToString();
                    Object anteriorCus = sql.ExecuteSqlObject("select (cus_nombres +' '+ CUS_apellidos) from CUSTODIO where cus_id='" +
                                                              activos.Rows[0]["CUS_ID1"].ToString() + "'");
                    Logica.ACTIVO _act1 = new Logica.ACTIVO(int.Parse(Session["actId"].ToString()));
                    Logica.UGEOGRAFICA ugeOrigen = new Logica.UGEOGRAFICA(_act1.UGE_ID2);
                    Logica.UGEOGRAFICA ugeDestino = new Logica.UGEOGRAFICA(int.Parse(activos.Rows[0]["UGE_ID2"].ToString()));
                    Logica.UORGANICA uorOrigen = new Logica.UORGANICA(_act1.UOR_ID2);
                    Logica.UORGANICA uorDestino = new Logica.UORGANICA(int.Parse(activos.Rows[0]["UOR_ID1"].ToString()));
                    Logica.GRUPO gruOrigen = new Logica.GRUPO(_act1.GRU_ID1);
                    _act1.CuentaOrigen = gruOrigen.GRU_CTA1;
                    _act1.CuentaDestino = gruOrigen.GRU_CTA1;
                    _act1.Oficina1 = ugeOrigen.UGE_CODIGO;
                    _act1.Oficina2 = ugeDestino.UGE_CODIGO;
                    _act1.CentroCosto1 = uorOrigen.UOR_CODIGO;
                    _act1.CentroCosto2 = uorDestino.UOR_CODIGO;
                    _act1.CuentaDepreOrigen = gruOrigen.GRU_CTA3;
                    _act1.CuentaDepreDestino = gruOrigen.GRU_CTA3;
                    _act1.CentroCostoDepre1 = uorOrigen.UOR_CODIGO;
                    _act1.CentroCostoDepre2 = uorDestino.UOR_CODIGO;
                    _act1.OficinaDepre1 = ugeOrigen.UGE_CODIGO;
                    _act1.OficinaDepre2 = ugeDestino.UGE_CODIGO;
                    _act1.DebitoDepre1 = _act1.ACT_DEPREACUMULADA.ToString("0.00");
                    _act1.CreditoDepre1 = "0";
                    _act1.DebitoDepre2 = "0";
                    _act1.CreditoDepre2 = _act1.ACT_DEPREACUMULADA.ToString("0.00");
                    Asientos.TransferenciaActivo(_act1);

                    Session["fechareporte"] = System.DateTime.Now.ToString("ddMMyyyyHHmmss");
                    Session["pdfFileName"] = "PDF//Acta Entrega TI - " + nuevoCus +" "+ Session["fechareporte"].ToString()+".pdf";
                    Session["cusIni"] = anteriorCus;
                    
                    Session["cusId"] = nuevosActivos.Rows[0]["CUS_ID1"].ToString();
                    //Session["MICORREOTRASLADO"] = sql.ExecuteSqlObject("select CUS_EMAIL from CUSTODIO where CUS_ID='" + Session["cusId"] + "'");
                }
                else if (activos.Rows.Count > 1)
                {
                    List<string> actIds = new List<string>();
                    List<string> cusIds = new List<string>();
                    foreach (DataRow antiguosActivosRow in activos.Rows)
                    {
                        actIds.Add(antiguosActivosRow["ACT_ID"].ToString());
                        cusIds.Add(antiguosActivosRow["CUS_ID1"].ToString());
                        //ExternalWebService.UpdateActivos(int.Parse(antiguosActivosRow["ACT_ID"].ToString()));
                    }

                    var distCus = cusIds.Distinct().ToList();
                    if (distCus.Count() == 1)
                    {
                        Object anteriorCus = sql.ExecuteSqlObject("select (cus_nombres +' '+ CUS_apellidos) from CUSTODIO where cus_id='" +
                                                                  activos.Rows[0]["CUS_ID1"].ToString() + "'");
                        Session["cusIni"] = anteriorCus;
                    }
                    else
                    {
                        Session["cusIni"] = "SIN CUSTODIO";
                    }

                    Session["actId"] = string.Join(";", actIds);
                    Session["fechareporte"] = System.DateTime.Now.ToString("ddMMyyyyHHmmss");
                    Session["pdfFileName"] = "PDF//Acta Entrega TM - " + nuevoCus + " " + Session["fechareporte"].ToString() + ".pdf";
                    
                }


                _traslado.CreaPdf(guid, Server, activos, Session["fechareporte"].ToString());
                var nombreacta = Session["pdfFileName"].ToString();
                string asunto = "Traslado de activos y/o bienes de control";
                string cuerpo = "Estimada(o), se adjunta Acta de Traslado de activos y/o bienes de control administrativo.\r\n\r\n\r\n\r\n";
                string rutaPDF = Server.MapPath(nombreacta);
                Correos correos = new Correos();
                correos.envioCorreosEnergyPower(asunto, cuerpo, rutaPDF);
                abreVentana("VisualizaPDF.aspx?pdf=yes");

            }

            CargaDatos();
        }
        protected void ibrechazar_OnClick(object sender, ImageClickEventArgs e)
        {
            ImageButton ib = sender as ImageButton;
            GridViewRow row = (GridViewRow)ib.NamingContainer;
            int APRACT_ID, ACTTRA_ID;
            Guid guid;
            APRACT_ID = int.Parse(row.Cells[22].Text);
            ACTTRA_ID = int.Parse(row.Cells[1].Text);
            guid = Guid.Parse(row.Cells[17].Text);
            var procesado = _traslado.AprobarRechazarTraslados(APRACT_ID, 0, ACTTRA_ID);
            CargaDatos();
        }
        private void abreVentana(string ventana)
        {
            string funcion = "OpenWindows('" + ventana + "')";

            string f = "windowOpener('" + ventana + "')";

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "DICE", f, true);
        }
        protected void rgitems_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
        }
    }
}

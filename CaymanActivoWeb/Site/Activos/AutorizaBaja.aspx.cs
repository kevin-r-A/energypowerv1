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
using iTextSharp.text.pdf;
using iTextSharp.text;

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
            string mensaje = "";
            if (FileUpload1.HasFile)
            {
                try
                {
                    nombreok = "~/Site/Activos/adjuntos_baja/" + codbarras + "_" + FileUpload1.FileName;
                    FileUpload1.SaveAs(Server.MapPath(nombreok));
                }
                catch (System.Exception ex)
                {
                    mensaje += " , </br> Documento no fue cargado: " + ex.Message;
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
                mensaje += " Item dado de Baja con éxito";
                //Session["MICORREOBAJA"] = sql.ExecuteSqlObject("select CUS_EMAIL from CUSTODIO INNER JOIN ACTIVO ON CUSTODIO.CUS_ID = ACTIVO.CUS_ID1 WHERE ACTIVO.ACT_ID = '" + act_Id + "'");
                //string asas = Session["MICORREOBAJA"].ToString();
                N_PDF(act_Id);
            }
            else
            {
                messbox1.Mensaje = "No se pudo realizar la Baja";
                messbox1.Tipo = "E";
                messbox1.showMess();
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
        private void N_PDF(int act)
        {
            try
            {
                ACTIVO ACT = new ACTIVO();
                using (C5ALIANZAVALLE23102015Entities ent = new C5ALIANZAVALLE23102015Entities())
                {
                    ent.Configuration.ProxyCreationEnabled = true;
                    ACT = ent.ACTIVO.Where(x => x.ACT_ID == act).FirstOrDefault();
                    Datos.SqlService sql = new Datos.SqlService();
                    string TituloReporte = ConfigurationManager.AppSettings["TituloReportes"].ToString();

                    //descripcion
                    Object factura = sql.ExecuteSqlObject(
                       "  select ISNULL(act_numfact,0) as Factura from activo where ACT_ID='" + act + "'");
                    Object descrip = sql.ExecuteSqlObject(
                        "select g3.gru_nombre AS DESCRIPCION from (ACTIVO left join GRUPO as g3 on activo.gru_id3= g3.gru_id) WHERE ACTIVO.ACT_ID='" + act + "'");

                    Object codigoBarras = sql.ExecuteSqlObject("select ACT_CODBARRAS as CODIGO from ACTIVO WHERE ACTIVO.ACT_ID='" + act + "'");
                    Object grupo = sql.ExecuteSqlObject(
                        "select g1.gru_nombre AS SUBTIPO from (ACTIVO  left join GRUPO as g1 on activo.gru_id1= g1.gru_id) WHERE ACTIVO.ACT_ID='" + act + "'");
                    Object subGrupo = sql.ExecuteSqlObject("select g2.gru_nombre AS CLASE from (ACTIVO left join GRUPO as g2 on activo.gru_id2= g2.gru_id) WHERE ACTIVO.ACT_ID='" +
                                                         act + "'");
                    Object detalle = sql.ExecuteSqlObject(
                        "select DETALLE=stuff((select ', '+(SELECT CFA_NOMBRE FROM CFAMILIA CF WHERE CF.CFA_ID =  A.CFA_ID)+': '+A.CAR_VALOR+ISNULL(U.UNI_SIMBOLO,'') From (caracteristica A LEFT JOIN UNIDAD AS U ON A.UNI_ID= U.UNI_ID) where A.ACT_ID=ACTIVO.act_id for xml path('')),1,1,'') from ACTIVO  WHERE ACTIVO.ACT_ID='" +
                        act + "'");
                    Object estado = sql.ExecuteSqlObject("select e.est_nombre AS ESTADO from (ACTIVO  left join estado as e on activo.est_id1=e.est_id) WHERE ACTIVO.ACT_ID='" +
                                                         act + "'");
                    Object marca = sql.ExecuteSqlObject(
                        "select mar.mar_nombre AS MARCA  from (ACTIVO  left join marca as mar on activo.mar_id=mar.mar_id) WHERE ACTIVO.ACT_ID='" + act + "'");
                    Object serie = sql.ExecuteSqlObject("select act_serie1 AS SERIE from (ACTIVO  left join marca as mar on activo.mar_id=mar.mar_id)WHERE ACTIVO.ACT_ID='" +
                                                         act + "'");
                    Object modelo = sql.ExecuteSqlObject(
                        "select mode.mod_nombre AS MODELO from (ACTIVO left join modelo as mode on activo.mod_id=mode.mod_id)WHERE ACTIVO.ACT_ID='" + act + "'");
                    Object observaciones = sql.ExecuteSqlObject("select act_observaciones AS OBSERVACIONES from ACTIVO  WHERE ACTIVO.ACT_ID='" + act + "'");
                    Object tipoActivo = sql.ExecuteSqlObject("select ACT_TIPO as TIPO_activo from ACTIVO WHERE ACTIVO.ACT_ID='" + act + "'");
                    Object fechacompra = sql.ExecuteSqlObject("select act_fechacompra from activo where act_id=" + act);
                    Object proveedor = sql.ExecuteSqlObject(
                        "select isnull(PROVEEDOR.PRO_NOMBRE,'Sin Proveedor')  from ACTIVO inner join PROVEEDOR on ACTIVO.PRO_ID=PROVEEDOR.PRO_ID where ACTIVO.ACT_ID='" + act + "'");
                    Object sxd = sql.ExecuteSqlObject(
                  "SELECT COALESCE(d.DEP_SALDOXDEPRE, '0') AS DEP_SALDOXDEPRE FROM ACTIVO AS a LEFT JOIN DEPRECIACIONSRI AS d ON d.ACT_ID = a.ACT_ID\r\nWHERE a.ACT_ID ='" + act + "'and DEP_FECHAPROX=(SELECT CONVERT(DATE, EOMONTH(DATEADD(MONTH, -1, GETDATE()))) AS UltimoDiaDelMesAnterior)");
                    //EMPIEZA PDF
                    Document document = new Document(new RectangleReadOnly(842f, 595f), 50, 30, 15, 5);
                    document.AddCreationDate();

                    //...título
                    document.AddTitle("ACTA DE INGRESO ACTIVOS FIJOS/BIENES DE CONTROL");

                    //... el asunto
                    document.AddSubject("ACTA DE INGRESO");

                    //string Path = "c:/" + System.DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss") + "ACTA DE ENTREGA RECEPCIÓN.pdf";
                    string Path = Server.MapPath("./PDF_ACTBAJA/") + "ActaBaja" + " " + System.DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf";

                    //creamos un instancia del objeto escritor de documento
                    PdfWriter writer = PdfWriter.GetInstance(document, new System.IO.FileStream(Path, System.IO.FileMode.Create));

                    //definimos la manera de inicialización de abierto del documento.
                    //esto, hará que veamos al inicio, todas la páginas del documento
                    //en la parte izquierda
                    writer.ViewerPreferences = PdfWriter.PageModeUseThumbs;

                    //con esto conseguiremos que el documento sea presentada de dos en dos 
                    writer.ViewerPreferences = PdfWriter.PageLayoutTwoColumnLeft;

                    //abrimos el documento para agregarle contenido
                    document.Open();

                    //creamos la fuente
                    iTextSharp.text.Font myfont = new iTextSharp.text.Font(
                        FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL));
                    iTextSharp.text.Font myfont2 = new iTextSharp.text.Font(
                        FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD));
                    iTextSharp.text.Font myfont3 = new iTextSharp.text.Font(
                        FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD));
                    iTextSharp.text.Font myfontLabel = new iTextSharp.text.Font(
                        FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD));
                    iTextSharp.text.Font myfontLabelNormal = new iTextSharp.text.Font(
                        FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL));
                    iTextSharp.text.Font myfontbold = new iTextSharp.text.Font(
                        FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD));
                    iTextSharp.text.Font myfontTabla = new iTextSharp.text.Font(
                        FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.NORMAL));
                    iTextSharp.text.Font myfontTitulo = new iTextSharp.text.Font(
                        FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD));
                    string ServerPath;
                    ServerPath = Server.MapPath("");
                    string ruta = ServerPath + "\\Logo\\logo.png";

                    iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(ruta);
                    jpg.ScalePercent(30f); //tamaño de imagen en porcentaje
                    jpg.Alignment = iTextSharp.text.Image.ALIGN_LEFT;

                    document.Add(jpg);//inserta logo
                    document.Add(new Paragraph("\n"));

                    document.Add(new Paragraph("\n"));
                    Paragraph P1 = new Paragraph("COOPERATIVA DE AHORRO Y CREDITO ALIANZA DEL VALLE LTDA. ");
                    P1.Alignment = Element.ALIGN_CENTER;

                    document.Add(P1);
                    document.Add(new Paragraph("\n"));
                    Paragraph P = new Paragraph("ACTA BAJA DE ACTIVOS FIJOS Y ACTIVOS DE CONTROL ");

                    P.Alignment = Element.ALIGN_CENTER;

                    document.Add(P);
                    document.Add(new Paragraph("\n"));
                    document.Add(new Paragraph("\n"));
                    document.Add(new Paragraph("\n"));
                    document.Add(new Paragraph("\n"));


                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-ES");


                    Paragraph P02 = new Paragraph("En la ciudad de QUITO, con fecha: " + DateTime.Now.Day + " de " + DateTime.Now.ToString("MMMM") + " del " + DateTime.Now.Year + ", comparecen los responsables del Control de Activos Fijos Asistente Contable," +
                        "director Financiero y Contador General, a fin de constatar la de los activos fijos y activos de control por daño, deterioro y/o pérdida debidamente comprobada y que han dejado de ser utilizados" +
                        "por la Cooperativa, conforme al siguiente detalle:", myfont);
                    P02.Alignment = Element.ALIGN_JUSTIFIED;
                    document.Add(P02);

                    document.Add(new Paragraph("\n"));
                    //    PdfPTable tblDatos3 = new PdfPTable(3);
                    //    tblDatos3.DefaultCell.BorderWidth = 0;
                    decimal _depreIni = 0;
                    decimal _depreFin = 0;
                    decimal _depreAcum = 0;

                    if (ACT.ACT_FECHAINIDEPRE != null)
                    {
                        if (ACT.DEPRECIACIONSRI.Count > 1)
                        {
                            DEPRECIACIONSRI depreini = ent.DEPRECIACIONSRI.Where(x => x.ACT_ID == act).OrderBy(x => x.DEP_FECHAPROX).Take(1).FirstOrDefault();
                            DEPRECIACIONSRI deprefin = ent.DEPRECIACIONSRI.Where(x => x.ACT_ID == act).OrderByDescending(x => x.DEP_FECHAPROX).Skip(1).Take(1)
                                .FirstOrDefault();
                            _depreIni = depreini.DEP_DEPREPERIODO;
                            _depreFin = deprefin.DEP_DEPREPERIODO;
                            _depreAcum = deprefin.DEP_DEPREACUM;
                        }
                        else
                        {
                            _depreIni = 0;
                            _depreFin = 0;
                            _depreAcum = 0;
                        }
                    }
                    //    Chunk lblProveedor = new Chunk("Proveedor: ", myfontLabel);
                    //    Chunk lblProveedorval = new Chunk(ACT.PROVEEDOR!=null?ACT.PROVEEDOR.PRO_NOMBRE:"(Sin Proveedor)", myfontLabelNormal);


                    //    //Chunk lblFechaInicio = new Chunk("Fecha de Incio: ", myfontLabel);
                    //    //Chunk lblFechaInicioval = new Chunk(ACT.ACT_FECHAINIDEPRE != null ? ACT.ACT_FECHAINIDEPRE.Value.ToString("dd/MM/yyyy") : "No Genera Depreciación", myfontLabelNormal);
                    //    //Chunk lblDepreInicial = new Chunk("Depreciación Incial: ", myfontLabel);
                    //    //Chunk lblDepreInival = new Chunk(_depreIni.ToString("#0.00"), myfontLabelNormal);
                    //    Chunk lblValorActivo = new Chunk("Valor del Activo: ", myfontLabel);
                    //    Chunk lblValorActivoval = new Chunk(ACT.ACT_VALORCOMPRA.Value.ToString("#0.00"), myfontLabelNormal);
                    //    Chunk lblDepreUltima = new Chunk("Depreciación (última): ", myfontLabel);
                    //    Chunk lblDepreUltimaval = new Chunk(_depreFin.ToString("#0.00"), myfontLabelNormal); 
                    //    Chunk lblVidaUtil = new Chunk("Vida Útil: ", myfontLabel);
                    //    Chunk lblVidaUtilval = new Chunk(ACT.ACT_VIDAUTIL.ToString(), myfontLabelNormal);
                    //    Chunk lblDepreAcum = new Chunk("Depreciación Acumulada: ", myfontLabel);
                    //    Chunk lblDepreAcumval = new Chunk(_depreAcum.ToString("#0.00"), myfontLabelNormal);
                    //    Chunk lblAvaluosAcum = new Chunk("Avalúos (acum): ", myfontLabel);
                    //    Chunk lblAvaluosAcumval = new Chunk("0", myfontLabelNormal);
                    //    Chunk lblValResidual = new Chunk("Valor Residual: ", myfontLabel);
                    //    Chunk lblValResidualval = new Chunk("1.00", myfontLabelNormal);

                    //    Phrase frase16 = new Phrase();
                    //    frase16.Add(lblProveedor);

                    //    frase16.Add(lblProveedorval);
                    //    //frase16.Add(lblFechaInicio);
                    //    //frase16.Add(lblFechaInicioval);
                    //    Phrase frase17 = new Phrase();
                    //    //frase17.Add(lblDepreInicial);
                    //    //frase17.Add(lblDepreInival);
                    //    tblDatos3.AddCell(frase16);
                    //    tblDatos3.AddCell("");
                    //    tblDatos3.AddCell(frase17);

                    //    Phrase frase18 = new Phrase();
                    //    frase18.Add(lblValorActivo);
                    //    frase18.Add(lblValorActivoval);
                    //    Phrase frase19 = new Phrase();
                    //    frase19.Add(lblDepreUltima);
                    //    frase19.Add(lblDepreUltimaval);
                    //    Phrase frase20 = new Phrase();
                    //    frase20.Add(lblVidaUtil);
                    //    frase20.Add(lblVidaUtilval);
                    //    tblDatos3.AddCell(frase18);
                    //    tblDatos3.AddCell(frase19);
                    //    tblDatos3.AddCell(frase20);

                    //    Phrase frase21 = new Phrase();
                    //    frase21.Add(lblDepreAcum);
                    //    frase21.Add(lblDepreAcumval);
                    //    Phrase frase22 = new Phrase();
                    //    frase22.Add(lblAvaluosAcum);
                    //    frase22.Add(lblAvaluosAcumval);
                    //    Phrase frase23 = new Phrase();
                    //    frase23.Add(lblValResidual);
                    //    frase23.Add(lblValResidualval);
                    //    tblDatos3.AddCell(frase21);
                    //    tblDatos3.AddCell(frase22);
                    //    tblDatos3.AddCell(frase23);
                    //    tblDatos3.WidthPercentage = 100;
                    //tblDatos3.SetWidths(new Single[] { 100, 100, 100 });
                    //document.Add(tblDatos3);

                    //document.Add(new Paragraph("\n"));
                    document.Add(new Paragraph("\n"));
                    ////Agregar tabla a Pdf
                    //PdfPTable table = new PdfPTable(12);
                    //PdfPCell cell = new PdfPCell(new Phrase("N° Factura", myfont3));
                    //PdfPCell cell1 = new PdfPCell(new Phrase("Código de Barras", myfont3));
                    //PdfPCell cell2 = new PdfPCell(new Phrase("Tipo de Bien", myfont3));
                    //PdfPCell cell3 = new PdfPCell(new Phrase("Grupo/Cuenta", myfont3));
                    //PdfPCell cell4 = new PdfPCell(new Phrase("Subgrupo", myfont3));
                    //PdfPCell cell5 = new PdfPCell(new Phrase("Descripcion", myfont3));
                    //PdfPCell cell6 = new PdfPCell(new Phrase("Detalle", myfont3));
                    //PdfPCell cell7 = new PdfPCell(new Phrase("Estado", myfont3));
                    //PdfPCell cell8 = new PdfPCell(new Phrase("Marca", myfont3));
                    //PdfPCell cell9 = new PdfPCell(new Phrase("Serie", myfont3));
                    //PdfPCell cell10 = new PdfPCell(new Phrase("Modelo", myfont3));
                    //PdfPCell cell11 = new PdfPCell(new Phrase("Observaciones", myfont3));

                    //cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    //cell1.HorizontalAlignment = 1;
                    //cell2.HorizontalAlignment = 1;
                    //cell3.HorizontalAlignment = 1;
                    //cell4.HorizontalAlignment = 1;
                    //cell5.HorizontalAlignment = 1;
                    //cell6.HorizontalAlignment = 1;
                    //cell7.HorizontalAlignment = 1;
                    //cell8.HorizontalAlignment = 1;
                    //cell9.HorizontalAlignment = 1;
                    //cell10.HorizontalAlignment = 1;
                    //cell11.HorizontalAlignment = 1;

                    //table.AddCell(cell);
                    //table.AddCell(cell1);
                    //table.AddCell(cell2);
                    //table.AddCell(cell3);
                    //table.AddCell(cell4);
                    //table.AddCell(cell5);
                    //table.AddCell(cell6);
                    //table.AddCell(cell7);
                    //table.AddCell(cell8);
                    //table.AddCell(cell9);
                    //table.AddCell(cell10);
                    //table.AddCell(cell11);
                    //table.AddCell(new Paragraph(factura.ToString(), myfontTabla));
                    //table.AddCell(new Paragraph(codigoBarras.ToString(), myfontTabla));
                    //table.AddCell(new Paragraph(tipoActivo.ToString(), myfontTabla));
                    //table.AddCell(new Paragraph(grupo.ToString(), myfontTabla));
                    //table.AddCell(new Paragraph(subGrupo.ToString(), myfontTabla));
                    //table.AddCell(new Paragraph(descrip.ToString(), myfontTabla));
                    //table.AddCell(new Paragraph(detalle.ToString(), myfont));
                    //table.AddCell(new Paragraph(estado.ToString(), myfontTabla));
                    //table.AddCell(new Paragraph(marca.ToString(), myfontTabla));
                    //table.AddCell(new Paragraph(serie.ToString(), myfontTabla));
                    //table.AddCell(new Paragraph(modelo.ToString(), myfontTabla));
                    //table.AddCell(new Paragraph(observaciones.ToString(), myfontTabla));
                    //table.WidthPercentage = 100;
                    //table.SetWidths(new Single[] { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100 });

                    PdfPTable tableDatos = new PdfPTable(15);

                    Phrase phead1 = new Phrase();
                    phead1.Add(new Chunk("N° Comprobante", myfontLabel));
                    PdfPCell cell1head = new PdfPCell(phead1);
                    tableDatos.AddCell(cell1head);

                    Phrase phead2 = new Phrase();
                    phead2.Add(new Chunk("N° Factura", myfontLabel));
                    PdfPCell cell2head = new PdfPCell(phead2);
                    tableDatos.AddCell(cell2head);

                    Phrase phead3 = new Phrase();
                    phead3.Add(new Chunk("Proveedor", myfontLabel));
                    PdfPCell cell3head = new PdfPCell(phead3);
                    tableDatos.AddCell(cell3head);

                    Phrase phead4 = new Phrase();
                    phead4.Add(new Chunk("Código Barras", myfontLabel));
                    PdfPCell cell4head = new PdfPCell(phead4);
                    tableDatos.AddCell(cell4head);

                    Phrase phead5 = new Phrase();
                    phead5.Add(new Chunk("Tipo Activo", myfontLabel));
                    PdfPCell cell5head = new PdfPCell(phead5);
                    tableDatos.AddCell(cell5head);

                    Phrase phead6 = new Phrase();
                    phead6.Add(new Chunk("Grupo", myfontLabel));
                    PdfPCell cell6head = new PdfPCell(phead6);
                    tableDatos.AddCell(cell6head);

                    Phrase phead7 = new Phrase();
                    phead7.Add(new Chunk("Descripción", myfontLabel));
                    PdfPCell cell7head = new PdfPCell(phead7);
                    tableDatos.AddCell(cell7head);

                    Phrase phead8 = new Phrase();
                    phead8.Add(new Chunk("Estado", myfontLabel));
                    PdfPCell cell8head = new PdfPCell(phead8);
                    tableDatos.AddCell(cell8head);

                    Phrase phead9 = new Phrase();
                    phead9.Add(new Chunk("Marca", myfontLabel));
                    PdfPCell cell9head = new PdfPCell(phead9);
                    tableDatos.AddCell(cell9head);

                    Phrase phead10 = new Phrase();
                    phead10.Add(new Chunk("Serie", myfontLabel));
                    PdfPCell cell10head = new PdfPCell(phead10);
                    tableDatos.AddCell(cell10head);

                    Phrase phead11 = new Phrase();
                    phead11.Add(new Chunk("Modelo", myfontLabel));
                    PdfPCell cell11head = new PdfPCell(phead11);
                    tableDatos.AddCell(cell11head);

                    Phrase phead12 = new Phrase();
                    phead12.Add(new Chunk("Observaciones", myfontLabel));
                    PdfPCell cell12head = new PdfPCell(phead12);
                    tableDatos.AddCell(cell12head);

                    Phrase phead13 = new Phrase();
                    phead13.Add(new Chunk("Valor Compra", myfontLabel));
                    PdfPCell cell13head = new PdfPCell(phead13);
                    tableDatos.AddCell(cell13head);


                    Phrase phead14 = new Phrase();
                    phead14.Add(new Chunk("Depreciación Acumulada", myfontLabel));
                    PdfPCell cell14head = new PdfPCell(phead14);
                    tableDatos.AddCell(cell14head);


                    Phrase phead15 = new Phrase();
                    phead15.Add(new Chunk("Valor en Libros", myfontLabel));
                    PdfPCell cell15head = new PdfPCell(phead15);
                    tableDatos.AddCell(cell15head);


                    Phrase phead111 = new Phrase();
                    phead111.Add(new Chunk("".ToString(), myfontLabel));
                    PdfPCell cell111head = new PdfPCell(phead111);
                    tableDatos.AddCell(cell111head);


                    Phrase phead211 = new Phrase();
                    phead211.Add(new Chunk(factura.ToString(), myfontLabel));
                    PdfPCell cell211head = new PdfPCell(phead211);
                    tableDatos.AddCell(cell211head);

                    Phrase phead311 = new Phrase();
                    phead311.Add(new Chunk(ACT.PROVEEDOR != null ? ACT.PROVEEDOR.PRO_NOMBRE : "(Sin Proveedor)", myfontLabel));
                    PdfPCell cell311head = new PdfPCell(phead311);
                    tableDatos.AddCell(cell311head);

                    Phrase phead411 = new Phrase();
                    phead411.Add(new Chunk(codigoBarras.ToString(), myfontLabel));
                    PdfPCell cell411head = new PdfPCell(phead411);
                    tableDatos.AddCell(cell411head);

                    Phrase phead511 = new Phrase();
                    phead511.Add(new Chunk(tipoActivo.ToString(), myfontLabel));
                    PdfPCell cell511head = new PdfPCell(phead511);
                    tableDatos.AddCell(cell511head);

                    Phrase phead611 = new Phrase();
                    phead611.Add(new Chunk(grupo.ToString(), myfontLabel));
                    PdfPCell cell611head = new PdfPCell(phead611);
                    tableDatos.AddCell(cell611head);

                    Phrase phead711 = new Phrase();
                    phead711.Add(new Chunk(descrip.ToString(), myfontLabel));
                    PdfPCell cell711head = new PdfPCell(phead711);
                    tableDatos.AddCell(cell711head);

                    Phrase phead811 = new Phrase();
                    phead811.Add(new Chunk(estado.ToString(), myfontLabel));
                    PdfPCell cell811head = new PdfPCell(phead811);
                    tableDatos.AddCell(cell811head);

                    Phrase phead911 = new Phrase();
                    phead911.Add(new Chunk(marca.ToString(), myfontLabel));
                    PdfPCell cell911head = new PdfPCell(phead911);
                    tableDatos.AddCell(cell911head);

                    Phrase phead1011 = new Phrase();
                    phead1011.Add(new Chunk(serie.ToString(), myfontLabel));
                    PdfPCell cell1011head = new PdfPCell(phead1011);
                    tableDatos.AddCell(cell1011head);

                    Phrase phead1111 = new Phrase();
                    phead1111.Add(new Chunk(modelo.ToString(), myfontLabel));
                    PdfPCell cell1111head = new PdfPCell(phead1111);
                    tableDatos.AddCell(cell1111head);


                    Phrase phead1211 = new Phrase();
                    phead1211.Add(new Chunk(observaciones.ToString(), myfontLabel));
                    PdfPCell cell1211head = new PdfPCell(phead1211);
                    tableDatos.AddCell(cell1211head);

                    Phrase phead1311 = new Phrase();
                    phead1311.Add(new Chunk(ACT.ACT_VALORCOMPRA.Value.ToString("#0.00"), myfontLabel));
                    PdfPCell cell1311head = new PdfPCell(phead1311);
                    tableDatos.AddCell(cell1311head);


                    Phrase phead1411 = new Phrase();
                    phead1411.Add(new Chunk(_depreAcum.ToString("#0.00"), myfontLabel));
                    PdfPCell cell1411head = new PdfPCell(phead1411);
                    tableDatos.AddCell(cell1411head);

                    Phrase phead1511 = new Phrase();
                    //phead1511.Add(new Chunk((sxd != null) ? sxd.ToString() : "0.00", myfontLabel));
                    phead1511.Add(new Chunk("0.00", myfontLabel));
                    PdfPCell cell1511head = new PdfPCell(phead1511);
                    tableDatos.AddCell(cell1511head);

                    tableDatos.WidthPercentage = 100;
                    document.Add(tableDatos);

                    document.Add(new Paragraph("\n")); document.Add(new Paragraph("\n")); document.Add(new Paragraph("\n"));


                    Paragraph P41 = new Paragraph("Para Constancia de lo actuado y en fe de conformidad y aceptación, suscriben la presente acta entrega-recepción en 3ejemplares de igual tenor y efecto las personas que intervienen en esta diligencia. \n", myfont);
                    P41.Alignment = Element.ALIGN_JUSTIFIED;
                    document.Add(P41);

                    document.Add(new Paragraph("\n")); document.Add(new Paragraph("\n")); document.Add(new Paragraph("\n")); document.Add(new Paragraph("\n")); document.Add(new Paragraph("\n")); document.Add(new Paragraph("\n")); document.Add(new Paragraph("\n"));

                    PdfPTable tableFirma = new PdfPTable(3);

                    PdfPCell cellEntrega = new PdfPCell(new Phrase("DIRECTOR FINANCIERO", myfont));
                    PdfPCell cellRecibe = new PdfPCell(new Phrase("CONTADORA GENERAL", myfont));
                    PdfPCell cellAutorizado = new PdfPCell(new Phrase("ASISTENTE CONTABLE", myfont));
                    PdfPCell cellEntrega1 = new PdfPCell(new Phrase("", myfont));
                    PdfPCell cellRecibe1 = new PdfPCell(new Phrase("", myfont));
                    PdfPCell cellAutorizado1 = new PdfPCell(new Phrase("", myfont));
                    PdfPCell cellEntrega2 = new PdfPCell(new Phrase("ECO. DANIEL MOSQUERA", myfont2));
                    PdfPCell cellRecibe2 = new PdfPCell(new Phrase("DRA. KARINA OÑA", myfont2));
                    PdfPCell cellAutorizado2 = new PdfPCell(new Phrase("PAOLA GALLARDO", myfont2));

                    cellEntrega.BorderWidth = 0;
                    cellEntrega.HorizontalAlignment = 1;
                    cellEntrega1.BorderWidth = 0;
                    cellEntrega1.HorizontalAlignment = 1;
                    cellEntrega2.BorderWidth = 0;
                    cellEntrega2.HorizontalAlignment = 1;
                    cellRecibe.BorderWidth = 0;
                    cellRecibe.HorizontalAlignment = 1;
                    cellRecibe1.BorderWidth = 0;
                    cellRecibe1.HorizontalAlignment = 1;
                    cellRecibe2.BorderWidth = 0;
                    cellRecibe2.HorizontalAlignment = 1;
                    cellAutorizado.BorderWidth = 0;
                    cellAutorizado.HorizontalAlignment = 1;
                    cellAutorizado1.BorderWidth = 0;
                    cellAutorizado1.HorizontalAlignment = 1;
                    cellAutorizado2.BorderWidth = 0;
                    cellAutorizado2.HorizontalAlignment = 1;

                    tableFirma.AddCell(cellEntrega);
                    tableFirma.AddCell(cellRecibe);
                    tableFirma.AddCell(cellAutorizado);
                    tableFirma.AddCell(cellEntrega1);
                    tableFirma.AddCell(cellRecibe1);
                    tableFirma.AddCell(cellAutorizado1);
                    tableFirma.AddCell(cellEntrega2);
                    tableFirma.AddCell(cellRecibe2);
                    tableFirma.AddCell(cellAutorizado2);


                    tableFirma.WidthPercentage = 100;

                    document.Add(tableFirma);

                    //esto es importante, pues si no cerramos el document entonces no se creara el pdf.
                    document.Close();

                    string filePath = Path;

                    Session["pdfFileName"] = filePath;
                }
                abreVentana("VisualizaPDF.aspx?pdf=yes"); //envio pdf para abrirlo en nueva pestaña
            }

            catch (Exception e)
            {

                throw;
            }
        }

    }

}
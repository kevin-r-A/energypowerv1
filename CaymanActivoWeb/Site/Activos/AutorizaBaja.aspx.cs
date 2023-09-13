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

            if (!Logica.HELPER.itemDadoDeBajaCb(row.Cells[10].Text.Trim()))
            {
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
            else
            {
                messbox1.Mensaje = "El item con Código de Barras = " + row.Cells[10].Text.Trim() + " ya fue dado de baja anterioremente...";
                messbox1.Tipo = "I";
                messbox1.showMess();

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
                F_CrearPdf(act_Id, motivobaja);
                var nombreacta = Session["nombredelacta"].ToString();
                string asunto = "Baja de activos y/o bienes de control";
                string cuerpo = "Estimada(o), se adjunta Acta de Baja de activos y/o bienes de control administrativo.\r\n\r\n\r\n\r\nSaludos cordiales, Activos Fijos";
                string rutaPDF = Server.MapPath("./PDF_ACTBAJA/" + nombreacta + ".pdf");
                Correos correos = new Correos();
                correos.envioCorreosEnergyPower(asunto, cuerpo, rutaPDF);
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
        private void F_CrearPdf(int id, string motivobaja)
        {
            try
            {

                ACTIVO ACT = new ACTIVO();
                using (C5ALIANZAVALLE23102015Entities ent = new C5ALIANZAVALLE23102015Entities())
                {
                    ent.Configuration.ProxyCreationEnabled = true;
                    ACT = ent.ACTIVO.Where(x => x.ACT_ID == id).FirstOrDefault();

                    //EMPIEZA PDF

                    //creamos el documento
                    //...ahora configuramos para que el tamaño de hoja sea A4
                    //Document document = new Document(iTextSharp.text.PageSize.A4);
                    Document document = new Document(iTextSharp.text.PageSize.A4, 50, 30, 15, 5);
                    //document.PageSize.Rotate();

                    //hacemos que se inserte la fecha de creación para el documento
                    document.AddCreationDate();

                    //...título
                    document.AddTitle("ACTA DE INGRESO ACTIVOS FIJOS/BIENES DE CONTROL");

                    //... el asunto
                    document.AddSubject("ACTA DE INGRESO");

                    var nombreactual = "ActaBaja" + " " + System.DateTime.Now.ToString("ddMMyyyyHHmmss");
                    string Path = Server.MapPath("./PDF_ACTBAJA/") + nombreactual + ".pdf";

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
                    iTextSharp.text.Font myfontbold = new iTextSharp.text.Font(
                    FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD));

                    iTextSharp.text.Font myfont2 = new iTextSharp.text.Font(
                    FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD));
                    iTextSharp.text.Font myfont3 = new iTextSharp.text.Font(
                    FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL));
                    iTextSharp.text.Font myfontLabel = new iTextSharp.text.Font(
                    FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD));
                    iTextSharp.text.Font myfontLabelNormal = new iTextSharp.text.Font(
                    FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL));
                    iTextSharp.text.Font myfontLabelCab = new iTextSharp.text.Font(
                    FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.NORMAL));

                    iTextSharp.text.Font myfontTitulo = new iTextSharp.text.Font(
                    FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD));


                    //agregar todo el paquete de texto
                    string ServerPath;
                    ServerPath = Server.MapPath("");
                    string ruta = ServerPath + "\\Logo\\logo.png";

                    iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(ruta);
                    jpg.ScalePercent(30f); //tamaño de imagen en porcentaje
                    jpg.Alignment = iTextSharp.text.Image.ALIGN_LEFT;

                    document.Add(jpg);//inserta logo

                    document.Add(new Paragraph("\n"));
                    Paragraph UserName = new Paragraph("Usuario: " + Membership.GetUser().UserName.Trim() + "   Fecha: " + System.DateTime.Now.ToString("dd/MM/yyyy HH:mm"), myfontLabelCab);
                    document.Add(UserName);

                    document.Add(new Paragraph("\n"));

                    Paragraph P = new Paragraph("ACTA BAJA DE " + ACT.ACT_TIPO.ToUpper() + "\n", myfontTitulo);
                    P.Alignment = Element.ALIGN_CENTER;

                    document.Add(P);
                    document.Add(new Paragraph("\n"));

                    //Agregar tablas a Pdf
                    PdfPTable tblDatos = new PdfPTable(3);
                    tblDatos.DefaultCell.BorderWidth = 0;

                    Chunk lblCodigo = new Chunk("Código: ", myfontLabel);
                    Chunk lblCodigoval = new Chunk(ACT.ACT_CODBARRAS.ToString(), myfontLabelNormal);
                    Chunk lblEstado = new Chunk("Estado: ", myfontLabel);
                    Chunk lblEstadoval = new Chunk("BAJA", myfontLabelNormal);

                    Chunk lblTipo = new Chunk("Tipo: ", myfontLabel);
                    Chunk lblTipoval = new Chunk(ACT.GRUPO1.GRU_NOMBRE.Trim(), myfontLabelNormal);
                    //Chunk lblUso = new Chunk("Uso: ", myfontLabel);
                    //Chunk lblUsoval = new Chunk("CAPITALIZABLES (>=100 USD)", myfontLabelNormal);

                    Chunk lblDescrip = new Chunk("Descripción: ", myfontLabel);
                    Chunk lblDescripval = new Chunk(ACT.GRUPO.GRU_NOMBRE.Trim(), myfontLabelNormal);

                    Chunk lblMarca = new Chunk("Marca: ", myfontLabel);
                    Chunk lblMarcaval = new Chunk(ACT.MARCA.MAR_NOMBRE.Trim(), myfontLabelNormal);
                    Chunk lblModelo = new Chunk("Modelo: ", myfontLabel);
                    Chunk lblModeloval = new Chunk(ACT.MODELO.MOD_NOMBRE.Trim(), myfontLabelNormal);
                    //Chunk lblSerie = new Chunk("#Serie: ", myfontLabel);
                    //Chunk lblSerieval = new Chunk(ACT.ACT_SERIE1!=null?ACT.ACT_SERIE1.Trim():"N/A", myfontLabelNormal);

                    Chunk lblColor = new Chunk("Color: ", myfontLabel);
                    Chunk lblColorval = new Chunk(ACT.COLOR != null ? ACT.COLOR.COL_NOMBRE.Trim() : "(Sin Color)", myfontLabelNormal);
                    Chunk lblMotivoBaja = new Chunk("Motivo Baja: ", myfontLabel);
                    Chunk lblMotivoBajaval = new Chunk(motivobaja.Trim(), myfontLabelNormal);

                    Phrase frase1 = new Phrase();
                    frase1.Add(lblCodigo);
                    frase1.Add(lblCodigoval);
                    Phrase frase2 = new Phrase();
                    frase2.Add(lblEstado);
                    frase2.Add(lblEstadoval);
                    tblDatos.AddCell(frase1);
                    tblDatos.AddCell("");
                    tblDatos.AddCell(frase2);
                    Phrase frase3 = new Phrase();
                    frase3.Add(lblTipo);
                    frase3.Add(lblTipoval);
                    Phrase frase4 = new Phrase();
                    //frase4.Add(lblUso);
                    //frase4.Add(lblUsoval);
                    tblDatos.AddCell(frase3);
                    tblDatos.AddCell("");
                    tblDatos.AddCell("");
                    Phrase frase5 = new Phrase();
                    frase5.Add(lblMarca);
                    frase5.Add(lblMarcaval);
                    Phrase frase6 = new Phrase();
                    frase6.Add(lblModelo);
                    frase6.Add(lblModeloval);
                    Phrase frase7 = new Phrase();
                    //frase7.Add(lblSerie);
                    //frase7.Add(lblSerieval);
                    tblDatos.AddCell(frase5);
                    tblDatos.AddCell(frase6);
                    tblDatos.AddCell(frase7);
                    Phrase fraseColor = new Phrase();
                    fraseColor.Add(lblColor);
                    fraseColor.Add(lblColorval);
                    Phrase fraseBaja = new Phrase();
                    fraseBaja.Add(lblMotivoBaja);
                    fraseBaja.Add(lblMotivoBajaval);
                    tblDatos.AddCell(fraseColor);
                    tblDatos.AddCell(fraseBaja);
                    tblDatos.AddCell("");


                    tblDatos.WidthPercentage = 100;
                    tblDatos.SetWidths(new Single[] { 95, 65, 100 });
                    document.Add(tblDatos);

                    document.Add(new Paragraph("\n"));

                    PdfPTable tblDatos1 = new PdfPTable(3);
                    tblDatos1.DefaultCell.BorderWidth = 0;

                    Chunk lblOficina = new Chunk("Oficina: ", myfontLabel);
                    Chunk lblOficinaval = new Chunk(ACT.UGEOGRAFICA3.UGE_NOMBRE.Trim(), myfontLabelNormal);
                    Chunk lblNumpartes = new Chunk("Número de Partes: ", myfontLabel);
                    Chunk lblNumPartesval = new Chunk("", myfontLabelNormal);
                    Chunk lblCustodio = new Chunk("Custodio: ", myfontLabel);
                    Chunk lblCustodioaval = new Chunk(ACT.CUSTODIO.CUS_APELLIDOS.Trim() + " " + ACT.CUSTODIO.CUS_NOMBRES.Trim(), myfontLabelNormal);
                    Chunk lblCustodioCedula = new Chunk("CI: ", myfontLabel);
                    Chunk lblCustodioCedulaaval = new Chunk(ACT.CUSTODIO.CUS_CEDULA, myfontLabelNormal);
                    Chunk lblCentroCosto = new Chunk("Centro de Costos: ", myfontLabel);
                    Chunk lblCentroCostoaval = new Chunk(ACT.UORGANICA1.UOR_NOMBRE.Trim(), myfontLabelNormal);

                    Phrase frase8 = new Phrase();
                    frase8.Add(lblOficina);
                    frase8.Add(lblOficinaval);
                    Phrase frase9 = new Phrase();
                    frase9.Add(lblNumpartes);
                    frase9.Add(lblNumPartesval);
                    tblDatos1.AddCell(frase8);
                    tblDatos1.AddCell("");
                    tblDatos1.AddCell(frase9);
                    Phrase frase10 = new Phrase();
                    frase10.Add(lblCustodio);
                    frase10.Add(lblCustodioaval);
                    Phrase frase11 = new Phrase();
                    frase11.Add(lblCentroCosto);
                    frase11.Add(lblCentroCostoaval);
                    tblDatos1.AddCell(frase10);
                    tblDatos1.AddCell("");
                    tblDatos1.AddCell(frase11);
                    Phrase fraseCedula = new Phrase();
                    fraseCedula.Add(lblCustodioCedula);
                    fraseCedula.Add(lblCustodioCedulaaval);
                    tblDatos1.AddCell(fraseCedula);
                    tblDatos1.AddCell("");
                    tblDatos1.AddCell("");

                    tblDatos1.WidthPercentage = 100;
                    tblDatos1.SetWidths(new Single[] { 150, 10, 100 });
                    document.Add(tblDatos1);

                    document.Add(new Paragraph("\n"));

                    PdfPTable tblDatos2 = new PdfPTable(3);
                    tblDatos2.DefaultCell.BorderWidth = 0;

                    Chunk lblProveedor = new Chunk("Proveedor: ", myfontLabel);
                    //Chunk lblProveedorval = new Chunk(ACT.PROVEEDOR!=null?ACT.PROVEEDOR.PRO_NOMBRE:"(Sin Proveedor)", myfontLabelNormal);
                    Chunk lblFechaCompra = new Chunk("Fecha de Compra: ", myfontLabel);
                    Chunk lblFechaCompraval = new Chunk(ACT.ACT_FECHACOMPRA.Value.ToString("dd/MM/yyyy"), myfontLabelNormal);
                    Chunk lblValorCompra = new Chunk("Valor Compra: ", myfontLabel);
                    Chunk lblValorCompraval = new Chunk(ACT.ACT_VALORCOMPRA.Value.ToString(), myfontLabelNormal);
                    Chunk lblTiempoGarantia = new Chunk("Tiempo de Garantía: ", myfontLabel);
                    Chunk lblTiempoGarantiaval = new Chunk(ACT.ACT_GARANTIA != null && ACT.ACT_GARANTIA.Value && ACT.ACT_FECHAGARANTIAVENCE != null
                        ? ACT.ACT_FECHAGARANTIAVENCE.Value.ToString("dd/MM/yyyy")
                        : "Sin Garantía", myfontLabelNormal);

                    Phrase frase12 = new Phrase();
                    frase12.Add(lblProveedor);
                    //frase12.Add(lblProveedorval);
                    tblDatos2.AddCell(frase12);
                    tblDatos2.AddCell("");
                    tblDatos2.AddCell("");

                    Phrase frase13 = new Phrase();
                    frase13.Add(lblFechaCompra);
                    frase13.Add(lblFechaCompraval);
                    Phrase frase14 = new Phrase();
                    frase14.Add(lblValorCompra);
                    frase14.Add(lblValorCompraval);
                    tblDatos2.AddCell(frase13);
                    tblDatos2.AddCell("");
                    tblDatos2.AddCell(frase14);

                    Phrase frase15 = new Phrase();
                    frase15.Add(lblTiempoGarantia);
                    frase15.Add(lblTiempoGarantiaval);
                    tblDatos2.AddCell(frase15);
                    tblDatos2.AddCell("");
                    tblDatos2.AddCell("");

                    tblDatos2.WidthPercentage = 100;
                    tblDatos2.SetWidths(new Single[] { 150, 10, 100 });
                    document.Add(tblDatos2);

                    document.Add(new Paragraph("\n"));

                    PdfPTable tblDatos3 = new PdfPTable(3);
                    tblDatos3.DefaultCell.BorderWidth = 0;


                    //depreciacion

                    decimal _depreIni = 0;
                    decimal _depreFin = 0;
                    decimal _depreAcum = 0;

                    if (ACT.ACT_FECHAINIDEPRE != null)
                    {
                        if (ACT.DEPRECIACIONSRI.Count > 1)
                        {
                            DEPRECIACIONSRI depreini = ent.DEPRECIACIONSRI.Where(x => x.ACT_ID == id).OrderBy(x => x.DEP_FECHAPROX).Take(1).FirstOrDefault();
                            DEPRECIACIONSRI deprefin = ent.DEPRECIACIONSRI.Where(x => x.ACT_ID == id).OrderByDescending(x => x.DEP_FECHAPROX).Skip(1).Take(1)
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

                    Chunk lblFechaInicio = new Chunk("Fecha de Incio: ", myfontLabel);
                    Chunk lblFechaInicioval = new Chunk(ACT.ACT_FECHAINIDEPRE != null ? ACT.ACT_FECHAINIDEPRE.Value.ToString("dd/MM/yyyy") : "No Genera Depreciación", myfontLabelNormal);
                    ////Chunk lblDepreInicial = new Chunk("Depreciación Incial: ", myfontLabel);
                    //Chunk lblDepreInival = new Chunk(_depreIni.ToString("#0.00"), myfontLabelNormal);
                    Chunk lblValorActivo = new Chunk("Valor del Activo: ", myfontLabel);
                    Chunk lblValorActivoval = new Chunk(ACT.ACT_VALORCOMPRA.Value.ToString("#0.00"), myfontLabelNormal);
                    //Chunk lblDepreUltima = new Chunk("Depreciación (última): ", myfontLabel);
                    //Chunk lblDepreUltimaval = new Chunk(_depreFin.ToString("#0.00"), myfontLabelNormal);*/
                    //Chunk lblVidaUtil = new Chunk("Vida Útil: ", myfontLabel);
                    //Chunk lblVidaUtilval = new Chunk(ACT.ACT_VIDAUTIL.ToString(), myfontLabelNormal);
                    //Chunk lblDepreAcum = new Chunk("Depreciación Acumulada: ", myfontLabel);
                    //Chunk lblDepreAcumval = new Chunk(_depreAcum.ToString("#0.00"), myfontLabelNormal);
                    //Chunk lblAvaluosAcum = new Chunk("Avalúos (acum): ", myfontLabel);
                    //Chunk lblAvaluosAcumval = new Chunk("0", myfontLabelNormal);
                    //Chunk lblValResidual = new Chunk("Valor Residual: ", myfontLabel);
                    //Chunk lblValResidualval = new Chunk("1.00", myfontLabelNormal);

                    Phrase frase16 = new Phrase();
                    frase16.Add(lblFechaInicio);
                    frase16.Add(lblFechaInicioval);
                    Phrase frase17 = new Phrase();
                    //frase17.Add(lblDepreInicial);
                    //frase17.Add(lblDepreInival);
                    tblDatos3.AddCell(frase16);
                    tblDatos3.AddCell("");
                    tblDatos3.AddCell(frase17);

                    Phrase frase18 = new Phrase();
                    frase18.Add(lblValorActivo);
                    frase18.Add(lblValorActivoval);
                    Phrase frase19 = new Phrase();
                    //frase19.Add(lblDepreUltima);
                    //frase19.Add(lblDepreUltimaval);
                    Phrase frase20 = new Phrase();
                    //frase20.Add(lblVidaUtil);
                    //frase20.Add(lblVidaUtilval);
                    tblDatos3.AddCell(frase18);
                    tblDatos3.AddCell(frase19);
                    tblDatos3.AddCell(frase20);

                    Phrase frase21 = new Phrase();
                    //frase21.Add(lblDepreAcum);
                    //frase21.Add(lblDepreAcumval);
                    Phrase frase22 = new Phrase();
                    //frase22.Add(lblAvaluosAcum);
                    //frase22.Add(lblAvaluosAcumval);
                    Phrase frase23 = new Phrase();
                    //frase23.Add(lblValResidual);
                    //frase23.Add(lblValResidualval);
                    tblDatos3.AddCell(frase21);
                    tblDatos3.AddCell(frase22);
                    tblDatos3.AddCell(frase23);

                    tblDatos3.WidthPercentage = 100;
                    tblDatos3.SetWidths(new Single[] { 140, 100, 100 });
                    document.Add(tblDatos3);

                    document.Add(new Paragraph("\n"));

                    //PdfPTable tblDatosPol = new PdfPTable(3);
                    //tblDatosPol.DefaultCell.BorderWidth = 0;

                    //Chunk lblCompaniaSeg = new Chunk("Compañia Seguros: ", myfontLabel);
                    //Chunk lblCompaniaSegval = new Chunk(ACT.TIPO_SEGURO!=null?ACT.TIPO_SEGURO.SEG_NOMBRE.Trim():"(Sin Seguro)", myfontLabelNormal);
                    //Chunk lblNumPoliza = new Chunk("Número Póliza: ", myfontLabel);
                    //Chunk lblNumPolizaval = new Chunk(ACT.ACT_NUMPOLIZA!=null?ACT.ACT_NUMPOLIZA.Trim():"N/A", myfontLabelNormal);
                    //Chunk lblVigenciaPoliza = new Chunk("Vigencia Póliza: ", myfontLabel);
                    //Chunk lblVigenciaPolizaval = new Chunk(ACT.ACT_VIGENCIAPOLIZAMESES!=null?ACT.ACT_VIGENCIAPOLIZAMESES.ToString():"N/A", myfontLabelNormal);
                    //Chunk lblFechaEmision = new Chunk("Fecha de Emisión: ", myfontLabel);
                    //Chunk lblFechaEmisionval = new Chunk(ACT.ACT_FECHAEMISIONPOLIZA!=null?ACT.ACT_FECHAEMISIONPOLIZA.Value.ToString("dd/MM/yyyy"):"", myfontLabelNormal);
                    //Chunk lblFechaVence = new Chunk("Fecha de Vencimiento: ", myfontLabel);
                    //Chunk lblFechaVenceval = new Chunk(ACT.ACT_FECHAVENCEPOLIZA != null ? ACT.ACT_FECHAVENCEPOLIZA.Value.ToString("dd/MM/yyyy") : "", myfontLabelNormal);
                    //Chunk lblValorAseg = new Chunk("Valor Asegurado: ", myfontLabel);
                    //Chunk lblValorAsegval = new Chunk(ACT.ACT_VALORASEGURADO!=null?ACT.ACT_VALORASEGURADO.Value.ToString("#0.00"):"0", myfontLabelNormal);

                    //Phrase pol = new Phrase();
                    //pol.Add(lblCompaniaSeg);
                    //pol.Add(lblCompaniaSegval);
                    //Phrase pol1 = new Phrase();
                    //pol1.Add(lblNumPoliza);
                    //pol1.Add(lblNumPolizaval);
                    //Phrase pol2 = new Phrase();
                    //pol2.Add(lblVigenciaPoliza);
                    //pol2.Add(lblVigenciaPolizaval);
                    //tblDatosPol.AddCell(pol);
                    //tblDatosPol.AddCell(pol1);
                    //tblDatosPol.AddCell(pol2);

                    //Phrase pol3 = new Phrase();
                    //pol3.Add(lblFechaEmision);
                    //pol3.Add(lblFechaEmisionval);
                    //Phrase pol4 = new Phrase();
                    //pol4.Add(lblFechaVence);
                    //pol4.Add(lblFechaVenceval);
                    //tblDatosPol.AddCell(pol3);
                    //tblDatosPol.AddCell(pol4);
                    //tblDatosPol.AddCell("");

                    //Phrase pol5 = new Phrase();
                    //pol5.Add(lblValorAseg);
                    //pol5.Add(lblValorAsegval);
                    //tblDatosPol.AddCell(pol5);
                    //tblDatosPol.AddCell("");
                    //tblDatosPol.AddCell("");

                    //tblDatosPol.WidthPercentage = 100;
                    //tblDatosPol.SetWidths(new Single[] { 140, 100, 100 });
                    //document.Add(tblDatosPol);

                    //document.Add(new Paragraph("\n"));

                    //Observaciones
                    PdfPTable tblobservaciones = new PdfPTable(1);
                    tblobservaciones.DefaultCell.BorderWidth = 0;
                    Chunk lblObservaciones = new Chunk("Observaciones Activo: ", myfontLabel);
                    Chunk lblObservacionesval = new Chunk(ACT.ACT_OBSERVACIONES != null ? ACT.ACT_OBSERVACIONES.ToString() : "", myfontLabelNormal);
                    Phrase pol6 = new Phrase();
                    pol6.Add(lblObservaciones);
                    pol6.Add(lblObservacionesval);
                    tblobservaciones.AddCell(pol6);

                    Chunk lblObservacionesBaja = new Chunk("Observaciones Baja: ", myfontLabel);
                    Chunk lblObservacionesBajaval = new Chunk(motivobaja, myfontLabelNormal);
                    Phrase pol7 = new Phrase();
                    pol7.Add(lblObservacionesBaja);
                    pol7.Add(lblObservacionesBajaval);
                    tblobservaciones.AddCell(pol7);

                    tblobservaciones.WidthPercentage = 100;
                    tblobservaciones.SetWidths(new Single[] { 100 });
                    document.Add(tblobservaciones);

                    document.Add(new Paragraph("\n"));



                    Paragraph P2 = new Paragraph("NOTA: \n ", myfontbold);
                    P2.Alignment = Element.ALIGN_JUSTIFIED;
                    document.Add(P2);

                    Paragraph P3 = new Paragraph("A partir de la firma de la presente acta, soy responsable del uso, manejo, control y custodia del equipo  asignado y de sus accesorios y responderé por este equipo en caso de pérdida, robo, daño o destrucción  entregando un equipo y accesorios de las mismas características en perfecto estado.", myfont);
                    P3.Alignment = Element.ALIGN_JUSTIFIED;
                    document.Add(P3);

                    document.Add(new Paragraph("\n"));

                    Paragraph P41 = new Paragraph("Conozco que es mi obligación  devolver al Área Administrativa el Activo asignado, en caso de cambio de funciones o desvinculación de la institución. De no hacerlo autorizo para que  todos los valores en los que se incurra sean descontados completamente de mi rol de pagos, liquidación, utilidades con esta autorización que ratifico al firmar este documento. \n", myfont);
                    P41.Alignment = Element.ALIGN_JUSTIFIED;
                    document.Add(P41);

                    document.Add(new Paragraph("\n"));

                    Paragraph P5 = new Paragraph("Adicional, autorizo de forma expresa y voluntaria a que se debite de mi rol de pagos mensual o liquidación de haberes, el valor del equipo a mi asignado, en caso de pérdida total, parcial o daño del mismo.", myfont);
                    P5.Alignment = Element.ALIGN_JUSTIFIED;
                    document.Add(P5);

                    document.Add(new Paragraph("\n\n\n\n"));
                    //Tabla para poner firmas
                    string cusActivoFijo = ConfigurationManager.AppSettings["AreaActivosFijosIngreso"];

                    PdfPTable tableFirma = new PdfPTable(2);

                    PdfPCell cellEntrega = new PdfPCell(new Phrase(cusActivoFijo, myfont));
                    PdfPCell cellRecibe = new PdfPCell(new Phrase(ACT.CUSTODIO.CUS_APELLIDOS.Trim() + " " + ACT.CUSTODIO.CUS_NOMBRES.Trim(), myfont));
                    PdfPCell cellEntrega1 = new PdfPCell(new Phrase(new Chunk("ANALISTA DE ACTIVOS FIJOS", myfont2)));
                    PdfPCell cellRecibe1 = new PdfPCell(new Phrase(new Chunk("CUSTODIO RESPONSABLE", myfont2)));
                    PdfPCell cellEntrega2 = new PdfPCell(new Phrase("", myfont));
                    PdfPCell cellRecibe2 = new PdfPCell(new Phrase("", myfont));

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

                    tableFirma.AddCell(cellEntrega);
                    tableFirma.AddCell(cellRecibe);
                    tableFirma.AddCell(cellEntrega1);
                    tableFirma.AddCell(cellRecibe1);
                    tableFirma.AddCell(cellEntrega2);
                    tableFirma.AddCell(cellRecibe2);

                    tableFirma.WidthPercentage = 100;
                    document.Add(tableFirma);

                    Session["ruta_archivo"] = "";
                    Session["motivobaja"] = "";
                    Session["motivobajadesc"] = "";

                    //esto es importante, pues si no cerramos el document entonces no se creara el pdf.
                    document.Close();


                    string filePath = Path;

                    Session["pdfFileName"] = filePath;
                    Session["nombredelacta"] = nombreactual;
                }

                abreVentana("VisualizaPDF.aspx?pdf=yes");//envio pdf para abrirlo en nueva pestaña
            }
            catch (Exception ex)
            {
                //errtrap = new ErrorTrapper();
               // errtrap.SetOnError("Usuario:" + Membership.GetUser().UserName + "<< " + ex.Message, 0);
                messbox1.Mensaje = "Error. " + ex.Message;
                messbox1.Tipo = "E";
                messbox1.showMess();
            }
        }

    }

}
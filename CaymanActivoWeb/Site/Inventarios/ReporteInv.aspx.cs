using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.IO;
using System.Text;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;

public partial class ReporteInv : System.Web.UI.Page
{
    ErrorTrapper errtrap;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = ConfigurationManager.AppSettings["Titulo"] + " Reporte Inventario Movil";

        ibpdf1.Attributes.Add("onmouseout", "this.src='../../Img/pdf1.png'");
        ibpdf1.Attributes.Add("onmouseover", "this.src='../../Img/pdf2.png'");

        ibxls1.Attributes.Add("onmouseout", "this.src='../../Img/xls1.png'");
        ibxls1.Attributes.Add("onmouseover", "this.src='../../Img/xls2.png'");

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
            F_CargarReporte();
        }
    }

    public void F_CargarReporte()
    {
    DataTable dtconcil = new DataTable();
        DataTable dtfaltan = new DataTable();
        DataTable dtsobran = new DataTable();

        DataTable dtfinal = new DataTable();

        dtconcil = Logica.HELPER.getReporteInventarioMovilWeb(1); //CONCILIADOS    
        dtfaltan = Logica.HELPER.getReporteInventarioMovilWeb(2); //FALTANTES
        dtsobran = Logica.HELPER.getReporteInventarioMovilWeb(3); //SOBRANTES


        if (dtconcil.Rows.Count > 0)
        {
            lblConcil.Text = dtconcil.Rows.Count.ToString();
            dtfinal.Merge(dtconcil);
        }
        if (dtfaltan.Rows.Count > 0)
        {
            lblFalt.Text = dtfaltan.Rows.Count.ToString();
            dtfinal.Merge(dtfaltan);
        }
        if (dtsobran.Rows.Count > 0)
        {
            lblSobrantes.Text = dtsobran.Rows.Count.ToString();
            dtfinal.Merge(dtsobran);
        }
        
        //reporte final
        if (dtfinal.Rows.Count > 0)
        {
            rgitems.DataSource = dtfinal;
            rgitems.DataBind();
            Cache["Repodt"] = dtfinal;
        }

        else
        {
            messbox1.Mensaje = "No hay datos...!!!";
            messbox1.Tipo = "W";
            messbox1.showMess();
        }
    }

    protected void ibxls1_Click(object sender, ImageClickEventArgs e)
    {
        if (rgitems.Rows.Count > 0)
        {                
            exportarExcel(rgitems, "ReporteInventario");
        }
        else
        {
            messbox1.Mensaje = "No hay datos para exportar.";
            messbox1.Tipo = "W";
            messbox1.showMess();
        }
    }

    public DataTable setExport(DataTable dt)
    {
        try
        {
            foreach (DataRow row in dt.Rows)
            {
                //para poder exportar a excel
                if (row["Serie"].ToString().Length != 0)
                    row["Serie"] = "'" + row["Serie"].ToString();
                //if (row["CódigoBarras"].ToString().Length != 0)
                //    row["CódigoBarras"] = "'" + row["CódigoBarras"].ToString();
                //if (row["CódigoBarrasPadre"].ToString().Length != 0)
                //    row["CódigoBarrasPadre"] = "'" + row["CódigoBarrasPadre"].ToString();
            }
            return dt;
        }
        catch (Exception ex)
        {
            errtrap = new ErrorTrapper();
            errtrap.SetOnError("Usuario:" + Membership.GetUser().UserName + "<< " + ex.Message, 0);
            messbox1.Mensaje = "Error: " + ex.Message;
            messbox1.Tipo = "E";
            messbox1.showMess();
            return null;
        }
    }

    public void exportarExcel(GridView grid, string nombre)
    {
        try
        {
            string date = DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString();

            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            System.Web.UI.Page page = new System.Web.UI.Page();
            HtmlForm form = new HtmlForm();

            grid.EnableViewState = false;

            // Deshabilitar la validación de eventos, sólo asp.net 2
            page.EnableEventValidation = false;

            // Realiza las inicializaciones de la instancia de la clase Page que requieran los diseñadores RAD.
            page.DesignerInitialize();

            page.Controls.Add(form);
            form.Controls.Add(grid);

            page.RenderControl(htw);

            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + nombre + "_" + date + ".xls");
            Response.Charset = "UTF-8";
            Response.ContentEncoding = Encoding.Default;
            Response.Write(sb.ToString());
            Response.End();
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
    protected void ibpdf1_Click(object sender, ImageClickEventArgs e)
    {
        if (rgitems.Rows.Count > 0)
        {
            try
            {
                exportarPdf(rgitems, "Reporte de Inventario");
                messbox1.Mensaje = "Reporte Generado con Éxito...!!!";
                messbox1.Tipo = "S";
                messbox1.showMess();
            }
            catch (System.Exception ex)
            {
                messbox1.Mensaje = ex.Message + ", Comuniquese con el Administrador...!!!";
                messbox1.Tipo = "E";
                messbox1.showMess();
            }
        }
        else
        {
            messbox1.Mensaje = "No hay datos para exportar.";
            messbox1.Tipo = "W";
            messbox1.showMess();
        }
    }

    //2012-03-01 Andrea.- Exportar a Pdf reporte de total de activos por custodio
    public void exportarPdf(GridView grid, string nombre)
    {
        try
        {
            //2012-03-31 GB
            //comentada ya que no se podia generar 2 veces el informe ya que el grid pierde sus datos
            //grid.EnableViewState = false;

            //Sql para sacar el total de activos
            Datos.SqlService sql = new Datos.SqlService();
            Object Total = sql.ExecuteSqlObject("select count(*) from Activo");
            //EMPIEZA PDF
            string cusActivoFijo = ConfigurationManager.AppSettings["AreaActivosFijosIngreso"];
            //creamos el documento
            //...ahora configuramos para que el tamaño de hoja sea A4
            //Document document = new Document(iTextSharp.text.PageSize.A4_LANDSCAPE);
            Document document = new Document(iTextSharp.text.PageSize.A4, 50, 30, 15, 5);

            //Agregar tabla a Pdf
            PdfPTable table = new PdfPTable(7);
            int noOfColumns = 0, noOfRows = 0;
            DataTable tbl = null;

            if (grid.AutoGenerateColumns)
            {
                tbl = (DataTable)Cache["Repodt"];
                //tbl = grid.DataSource as DataTable; // Gets the DataSource of the GridView Control.
                noOfColumns = tbl.Columns.Count;
                noOfRows = tbl.Rows.Count;
            }
            else
            {
                noOfColumns = grid.Columns.Count;
                noOfRows = grid.Rows.Count;
            }


            float HeaderTextSize = 8;
            float ReportNameSize = 10;
            float ReportTextSize = 7;


            // Creates a PdfPTable with column count of the table equal to no of columns of the gridview or gridview datasource.
            iTextSharp.text.pdf.PdfPTable mainTable = new iTextSharp.text.pdf.PdfPTable(noOfColumns);

            // Sets the first 4 rows of the table as the header rows which will be repeated in all the pages.
            mainTable.HeaderRows = 4;

            // Creates a PdfPTable with 2 columns to hold the header in the exported PDF.
            iTextSharp.text.pdf.PdfPTable headerTable = new iTextSharp.text.pdf.PdfPTable(2);

            // Creates a PdfPCell that accepts the headerTable as a parameter and then adds that cell to the main PdfPTable.
            PdfPCell cellHeader = new PdfPCell(headerTable);
            cellHeader.Border = PdfPCell.NO_BORDER;
            // Sets the column span of the header cell to noOfColumns.
            cellHeader.Colspan = noOfColumns;
            // Adds the above header cell to the table.
            mainTable.AddCell(cellHeader);

            // Creates a phrase for a new line.
            Phrase phSpace = new Phrase("\n");
            PdfPCell clSpace = new PdfPCell(phSpace);
            clSpace.Border = PdfPCell.NO_BORDER;
            clSpace.Colspan = noOfColumns;
            mainTable.AddCell(clSpace);
            

            // Sets the gridview column names as table headers.
            for (int i = 0; i < noOfColumns; i++)
            {
                Phrase ph = null;

                if (grid.AutoGenerateColumns)
                {
                    ph = new Phrase(tbl.Columns[i].ColumnName, FontFactory.GetFont("Arial", HeaderTextSize, iTextSharp.text.Font.BOLD));
                }
                else
                {
                    ph = new Phrase(grid.Columns[i].HeaderText, FontFactory.GetFont("Arial", HeaderTextSize, iTextSharp.text.Font.BOLD));
                }

                mainTable.AddCell(ph);
                
            }

            // Reads the gridview rows and adds them to the mainTable
            for (int rowNo = 0; rowNo < noOfRows; rowNo++)
            {
                for (int columnNo = 0; columnNo < noOfColumns; columnNo++)
                {
                    if (grid.AutoGenerateColumns)
                    {
                        string s = grid.Rows[rowNo].Cells[columnNo].Text.Trim();
                        if (s != "&nbsp;")
                        {
                            //GB. reemplazo caracteres en ASCII
                            s = s.Replace("&#209;", "Ñ");
                            s = s.Replace("&gt;", ">");
                            s = s.Replace("&#39;", "");
                            s = s.Replace("&#241;", "ñ");

                            s = s.Replace("&#193;", "Á");
                            s = s.Replace("&#201;", "É");
                            s = s.Replace("&#205;", "Í");
                            s = s.Replace("&#211;", "Ó");
                            s = s.Replace("&#218;", "Ú");

                            s = s.Replace("&#225;", "á");
                            s = s.Replace("&#233;", "é");
                            s = s.Replace("&#237;", "í");
                            s = s.Replace("&#243;", "ó");
                            s = s.Replace("&#250;", "ú");


                            Phrase ph = new Phrase(s, FontFactory.GetFont("Arial", ReportTextSize, iTextSharp.text.Font.NORMAL));
                            mainTable.AddCell(ph);
                        }

                        if (s == "&nbsp;")
                        {
                            Phrase ph = new Phrase(" ", FontFactory.GetFont("Arial", ReportTextSize, iTextSharp.text.Font.NORMAL));
                            mainTable.AddCell(ph);
                        }
                    }
                    else
                    {
                        if (grid.Columns[columnNo] is TemplateField)
                        {
                            DataBoundLiteralControl lc = grid.Rows[rowNo].Cells[columnNo].Controls[0] as DataBoundLiteralControl;
                            string s = lc.Text.Trim();
                            if (s != "&nbsp;")
                            {
                                //GB. reemplazo caracteres en ASCII
                                s = s.Replace("&#209;", "Ñ");
                                s = s.Replace("&#241;", "ñ");
                                s = s.Replace("&gt;", ">");
                                s = s.Replace("&#39;", "");

                                s = s.Replace("&#193;", "Á");
                                s = s.Replace("&#201;", "É");
                                s = s.Replace("&#205;", "Í");
                                s = s.Replace("&#211;", "Ó");
                                s = s.Replace("&#218;", "Ú");

                                s = s.Replace("&#225;", "á");
                                s = s.Replace("&#233;", "é");
                                s = s.Replace("&#237;", "í");
                                s = s.Replace("&#243;", "ó");
                                s = s.Replace("&#250;", "ú");


                                Phrase ph = new Phrase(s, FontFactory.GetFont("Arial", ReportTextSize, iTextSharp.text.Font.NORMAL));
                                mainTable.AddCell(ph);
                            }
                        }
                        else
                        {
                            string s = grid.Rows[rowNo].Cells[columnNo].Text.Trim();
                            if (s != "&nbsp;")
                            {
                                //GB. reemplazo caracteres en ASCII
                                s = s.Replace("&#209;", "Ñ");
                                s = s.Replace("&#241;", "ñ");
                                s = s.Replace("&gt;", ">");
                                s = s.Replace("&#39;", "");

                                s = s.Replace("&#193;", "Á");
                                s = s.Replace("&#201;", "É");
                                s = s.Replace("&#205;", "Í");
                                s = s.Replace("&#211;", "Ó");
                                s = s.Replace("&#218;", "Ú");

                                s = s.Replace("&#225;", "á");
                                s = s.Replace("&#233;", "é");
                                s = s.Replace("&#237;", "í");
                                s = s.Replace("&#243;", "ó");
                                s = s.Replace("&#250;", "ú");


                                Phrase ph = new Phrase(s, FontFactory.GetFont("Arial", ReportTextSize, iTextSharp.text.Font.NORMAL));
                                mainTable.AddCell(ph);
                            }
                        }
                    }
                }

                // Tells the mainTable to complete the row even if any cell is left incomplete.
                mainTable.CompleteRow();
                mainTable.SetWidths(new Single[] { 100, 100, 80, 150, 130, 70, 70,70,120,90});
            }


            document.AddTitle("REPORTE DE INVENTARIO MOVIL");
            //... el asunto+

            document.AddSubject("INVENTARIO MOVIL");


            //string Path = "c:/" + System.DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss") + "REPORTE DE ACTIVOS DESIGNADOS POR CUSTODIO.pdf";
            string Path = Server.MapPath("./PDF/") + nombre + " " + System.DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf";

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

            iTextSharp.text.Font myfont = new iTextSharp.text.Font(FontFactory.GetFont(FontFactory.TIMES_ROMAN, 8, iTextSharp.text.Font.NORMAL));
            iTextSharp.text.Font myfont2 = new iTextSharp.text.Font(FontFactory.GetFont(FontFactory.TIMES_ROMAN, 12, iTextSharp.text.Font.NORMAL));
            iTextSharp.text.Font myfont3 = new iTextSharp.text.Font(FontFactory.GetFont(FontFactory.TIMES_ROMAN, 8, iTextSharp.text.Font.BOLD));

            //agregar todo el paquete de texto


            DataTable dt = new DataTable();
            string cus_id = "";

            dt = sql.ExecuteSqlDataTable("select * from reporte where REP_ESTADO = 'M'");
            if (dt.Rows.Count > 0)
            {
                cus_id = dt.Rows[0][2].ToString();
            }

            //Object Custodio = sql.ExecuteSqlObject("select (cus_nombres +' '+ CUS_apellidos) from CUSTODIO where cus_id='" + cus_id + "'");
            //Object cusdepart = sql.ExecuteSqlObject("select CUS_DEPARTAMENTO from custodio where cus_id = '" + cus_id + "'");
            //Object cusUltimatix = sql.ExecuteSqlObject("select CUS_ULTIMATIX from custodio where cus_id = '" + cus_id + "'");
            //Object cusedifini = sql.ExecuteSqlObject("select uor_nombre from uorganica where uor_id = '" + Session["ccini"].ToString() + "'");


            int numPDF = F_TotalPDF() + 1;
            string PDFnum = F_llenaceros(Convert.ToString(numPDF), 4, "0");

            string ServerPath;
            ServerPath = Server.MapPath("");
            string ruta = ServerPath + "\\Logo\\logo.png";

            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(ruta);
            jpg.ScalePercent(30f); //tamaño de imagen en porcentaje
            jpg.Alignment = iTextSharp.text.Image.RIGHT_ALIGN;


            Paragraph P = new Paragraph("INVENTARIO FISICO DE ITEMS" + "\n", myfont2);
            Paragraph Pt = new Paragraph("LISTADO DE ITEMS", myfont2);
            Paragraph Pl = new Paragraph("________________________________________________________________________________________________________________________________" , myfont);
            P.Alignment = Element.ALIGN_CENTER;
            Pt.Alignment = Element.ALIGN_CENTER;
            Pl.Alignment = Element.ALIGN_CENTER;
            document.Add(jpg);
            document.Add(P);
            document.Add(Pt);
            document.Add(Pl);

            //Paragraph P5 = new Paragraph("Acta de Constatación Física N° ACF " + PDFnum + " - " + System.DateTime.Now.Year.ToString() + " \n", myfont2);
            //P5.Alignment = Element.ALIGN_CENTER;
            //document.Add(P5);

            //document.Add(new Paragraph("\n"));

            //Paragraph P2 = new Paragraph("En la ciudad de Sangolquí, el " + System.DateTime.Now.Day.ToString() + " " + F_Mes(System.DateTime.Now.Month) + " " + System.DateTime.Now.Year.ToString() + ", se realiza la presente Acta de Constatación Física de Bienes Muebles, Equipos, partes, piezas, y accesorios de propiedad del GADMUR, interviniendo las siguientes personas Sr(a)(ita). " + ddCustodio.SelectedItem.Text + " en su calidad de usuario constatado, servidor de " + ddCargo.SelectedItem.Text + ", " + ConfigurationManager.AppSettings["DelegadoActivosFijos"] + " delegado de la Dirección; " + ConfigurationManager.AppSettings["AreaActivosFijosIngreso"] + " Jéfe(a) de Bienes y Seguros, verificando los bienes muebles que a continuación se detallan:", myfont);
            //P2.Alignment = Element.ALIGN_JUSTIFIED; 
            //document.Add(P2);

            //Paragraph P3 = new Paragraph(" \n ", myfont);
            //P3.Alignment = Element.ALIGN_JUSTIFIED;
            //document.Add(P3);

            /*se añade tabla con todos los activos*/
            mainTable.WidthPercentage = 100;
            document.Add(mainTable);

            //if (noOfRows )
            document.Add(new Paragraph("\n"));


            Paragraph P13 = new Paragraph("Para constancia, firman las partes en dos ejemplares de idéntico valor y contenido.", myfont);
            P13.Alignment = Element.ALIGN_JUSTIFIED;
            document.Add(P13);

            document.Add(new Paragraph("\n"));
            document.Add(new Paragraph("\n"));

            //Tabla para poner firmas
            PdfPTable tableFirma = new PdfPTable(2);

            PdfPCell cellEntrega = new PdfPCell(new Phrase("_____________________________", myfont));
            PdfPCell cellRecibe = new PdfPCell(new Phrase("_____________________________", myfont));
            //PdfPCell cellAutorizado = new PdfPCell(new Phrase("_____________________________C", myfont));
            PdfPCell cellEntrega1 = new PdfPCell(new Phrase(cusActivoFijo, myfont));
            PdfPCell cellRecibe1 = new PdfPCell(new Phrase("", myfont));
            //PdfPCell cellAutorizado1 = new PdfPCell(new Phrase(ConfigurationManager.AppSettings["DelegadoActivosFijos"].ToString(), myfont));
            PdfPCell cellEntrega2 = new PdfPCell(new Phrase("CONTROL ACTIVOS FIJOS", myfont));
            PdfPCell cellRecibe2 = new PdfPCell(new Phrase("CUSTODIO", myfont));
            //PdfPCell cellAutorizado2 = new PdfPCell(new Phrase("Delegado de Dirección", myfont));


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
            //cellAutorizado.BorderWidth = 0;
            //cellAutorizado.HorizontalAlignment = 1;
            //cellAutorizado1.BorderWidth = 0;
            //cellAutorizado1.HorizontalAlignment = 1;
            //cellAutorizado2.BorderWidth = 0;
            //cellAutorizado2.HorizontalAlignment = 1;

            tableFirma.AddCell(cellEntrega);
            tableFirma.AddCell(cellRecibe);
            //tableFirma.AddCell(cellAutorizado);
            tableFirma.AddCell(cellEntrega1);
            tableFirma.AddCell(cellRecibe1);
            //tableFirma.AddCell(cellAutorizado1);
            tableFirma.AddCell(cellEntrega2);
            tableFirma.AddCell(cellRecibe2);
            //tableFirma.AddCell(cellAutorizado2);


            tableFirma.WidthPercentage = 100;

            document.Add(tableFirma);

            //esto es importante, pues si no cerramos el document entonces no se creara el pdf.
            document.Close();

            //esto es para abrir el documento y verlo inmediatamente después de su creación

            //System.Diagnostics.Process.Start(Path.ToString());

            string filePath = Path;

            Session["pdfFileName"] = filePath;

            abreVentana("VisualizaPDF.aspx?pdf=yes");//envio pdf para abrirlo en nueva pestaña
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

    private void abreVentana(string ventana)
    {

        string funcion = "windowOpener('" + ventana + "')";

        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "SIFEL", funcion, true);

    }
    public string F_Mes(int m)
    {
        string mes = "";

        if (m == 1)
        {
            mes = "Enero";
        }
        else if (m == 2)
        {
            mes = "Febrero";
        }
        else if (m == 3)
        {
            mes = "Marzo";
        }
        else if (m == 4)
        {
            mes = "Abril";
        }
        else if (m == 5)
        {
            mes = "Mayo";
        }
        else if (m == 6)
        {
            mes = "Junio";
        }
        else if (m == 7)
        {
            mes = "Julio";
        }
        else if (m == 8)
        {
            mes = "Agosto";
        }
        else if (m == 9)
        {
            mes = "Septiembre";
        }
        else if (m == 10)
        {
            mes = "Octubre";
        }
        else if (m == 11)
        {
            mes = "Noviembre";
        }
        else if (m == 12)
        {
            mes = "Diciembre";
        }

        return mes;

    }
    public int F_TotalPDF()
    {

        string folderToBrowse = Server.MapPath("./PDF/");
        DirectoryInfo DirInfo = new DirectoryInfo(folderToBrowse);
        FileSystemInfo[] files = DirInfo.GetFileSystemInfos("*.PDF");
        Array.Sort<FileSystemInfo>(files, delegate(FileSystemInfo a, FileSystemInfo b) { return a.LastWriteTime.CompareTo(b.LastWriteTime); });

        DataGrid dt = new DataGrid();

        dt.DataSource = files;
        dt.DataBind();

        int filas = dt.Items.Count;

        return filas;
    }
    public string F_llenaceros(String Valor, Int32 MaxVal, String relleno)
    {
        /*-------------------------------------------------------------------
         *AUTOR: DICE
         *FECHA: 2013/03/13
         *OBJETIVO: FUNCION LLENA CEROS A LA IZQUIERDA ENVIA: EL VALOR, EL TAMAÑO (length) Y EL RELLENO ("0")
        */
        if (relleno.Length > 1)
        {

            Valor = "ERROR####";

        }
        else
        {
            Valor = Valor.Trim();
            MaxVal = MaxVal - Valor.Length;

            for (int n = 0; n < MaxVal; n++)
            {
                Valor = relleno + Valor;
            }

        }
        return Valor;
    }

    protected void btn_Items_Click(object sender, EventArgs e)
    {
        try
        {
            string query = "";
            string codigoCustodio = "";
            string nombreCustodio = "";


            codigoCustodio = Logica.HELPER.getCodigoCustodio("n/a");
            nombreCustodio = Logica.HELPER.getNombreCustodio("n/a");

            //if (codigoCustodio != "")
            //{

                query = query + " AND cus_id1='" + codigoCustodio + "'";
                query = query + " AND act_fechabaja is null";
            //}


            //if (nombreCustodio != "")
            //{
            //    lblNombreCustodio.Text = nombreCustodio;

            //}
            //else
            //{
            //    lblNombreCustodio.Text = "Custodio No Existe";
            //}


            DataTable dt = Logica.HELPER.getReporteActivosPdf(query,1);
            if (dt.Rows.Count > 0)
            {
                Cache["Repodt"] = dt;
                rgitems.DataSource = setExport(dt);
                rgitems.DataBind();
                upgrid.Update();
                pancus.Visible = true;
                pancus.GroupingText = "Items bajo su cargo [ " + dt.Rows.Count.ToString() + " Items ]";

                upGrillaItems.Update();
            }
            else
            {
                messbox1.Mensaje = "No existen Items...!!!";
                messbox1.Tipo = "W";
                messbox1.showMess();
                pancus.Visible = false;
                upGrillaItems.Update();
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

    protected void rgitems_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //e.Row.Attributes.Add("style", "vnd.ms-excel.numberformat:@"); //Para todo el documento
        e.Row.Cells[0].Attributes.Add("style", "vnd.ms-excel.numberformat:0"); //para columna especifica
                                                                               //vnd.ms-excel.numberformat:0 formato sin ceros
                                                                               //vnd.ms-excel.numberformat:0\\.00 formato con decimales
                                                                               //vnd.ms - excel.numberformat:@ formato texto

        e.Row.Cells[7].Attributes.Add("style", "vnd.ms-excel.numberformat:0");

    }
}


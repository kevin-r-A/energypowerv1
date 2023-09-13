using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

public partial class RepoCus : System.Web.UI.Page
{
    ErrorTrapper errtrap;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = ConfigurationManager.AppSettings["Titulo"] + " Reporte Items por Custodio";

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

            datefechaingreso.SelectedDate = System.DateTime.Now;
            datefechaingreso.Enabled = false;

            if (ConfigurationManager.AppSettings["CCOUGE"] == "0")
            {
                cddccosto.ParentControlID = "";
                cddccosto.ServiceMethod = "GetCcosto";
            }

            else if (ConfigurationManager.AppSettings["CCOUGE"] == "1")
            {
                cddccosto.ParentControlID = "ddUge1";
                cddccosto.ServiceMethod = "GetCcostoUge1";
            }
            else if (ConfigurationManager.AppSettings["CCOUGE"] == "2")
            {
                cddccosto.ParentControlID = "ddUge2";
                cddccosto.ServiceMethod = "GetCcostoUge2";
            }
            else if (ConfigurationManager.AppSettings["CCOUGE"] == "3")
            {
                cddccosto.ParentControlID = "ddUge3";
                cddccosto.ServiceMethod = "GetCcostoUge3";
            }
            if (ConfigurationManager.AppSettings["UORCCO"] == "0")
            {
                cdduor1.ParentControlID = "";
                cdduor1.ServiceMethod = "GetUor1";
            }
            else if (ConfigurationManager.AppSettings["UORCCO"] == "1")
            {
                cdduor1.ParentControlID = "ddCcosto";
                cdduor1.ServiceMethod = "GetUor1Cco";
            }

        }
    }

    protected void ibxls1_Click(object sender, ImageClickEventArgs e)
    {
        if (rgitems.Rows.Count > 0)
        {
            exportarExcel(rgitems, "ItemsCustodio");
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

        int i = 1;
        try
        {
            foreach (DataRow row in dt.Rows)
            {
                //para poder exportar a excel

                //if (row["N°"].ToString() == "")
                //{
                //    row["N°"] = i++;
                //}
                //if (row["Descripción"].ToString() != "")
                //{
                    //row["Descripción"] = row["Descripción"].ToString().ToUpper();
                //}
                //if (row["MARCA"].ToString() != "")
                //{
                //    row["MARCA"] = row["MARCA"].ToString().ToUpper();
                //}
                //if (row["MODELO"].ToString() != "")
                //{
                //    row["MODELO"] = row["MODELO"].ToString().ToUpper();
                //}

                //if (row["CódigoBarras"].ToString() != "")
                //{
                    //row["CódigoBarras"] = "'" + row["CódigoBarras"].ToString().ToUpper();
                //}
                //else
                //{
                    //row["VALOR COMPRA"] = "  ";
                //}
                //if (row["Serie"].ToString() != "")
                //{
                    //row["Serie"] = row["Serie"].ToString().ToUpper();
                //}
                //else
                //{
                    //row["Serie"] = "S/N";
                //}
                //if (row["Estado"].ToString() != "")
                //{
                    //row["Estado"] = row["Estado"].ToString().ToUpper();
                //}
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

    public bool ValidaPDF()
    {
        /*if (ddUor2.SelectedItem.Text != "")
        {
            return true;
        }
        else
        {
            return false;
        }*/
        return true;
    }

    protected void ibpdf1_Click(object sender, ImageClickEventArgs e)
    {
        if (rgitems.Rows.Count > 0)
        {
            try
            {
                if (ValidaPDF())
                {
                    exportarPdf(rgitems, "");
                    messbox1.Mensaje = "Reporte Generado con Éxito...!!!";
                    messbox1.Tipo = "S";
                    messbox1.showMess();
                }
                else
                {
                    messbox1.Mensaje = "Seleccion Ubicación Orgánica 2...!!!";
                    messbox1.Tipo = "W";
                    messbox1.showMess();
                }
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

    public void exportarPdf(GridView grid, string nombre)
    {
        try
        {

            //int numPDF = F_TotalPDF() + 1;
            //string PDFnum = F_llenaceros(Convert.ToString(numPDF), 4, "0");

            //2012-03-31 GB
            //comentada ya que no se podia generar 2 veces el informe ya que el grid pierde sus datos
            //grid.EnableViewState = false;

            //Sql para sacar el total de activos
            Datos.SqlService sql = new Datos.SqlService();
            Object Total = sql.ExecuteSqlObject("select count(*) from Activo");
            //EMPIEZA PDF

            //creamos el documento
            //...ahora configuramos para que el tamaño de hoja sea A4
            //Document document = new Document(iTextSharp.text.PageSize.A4_LANDSCAPE);
            Document document = new Document(new RectangleReadOnly(842f, 595f), 50, 30, 15, 5);


            //Agregar tabla a Pdf
            PdfPTable table = new PdfPTable(8);
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


            float HeaderTextSize = 7;
            float ReportNameSize = 7;
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

            // Creates a phrase which holds the file name.
            Phrase phHeader = new Phrase("", FontFactory.GetFont("Arial", ReportNameSize, iTextSharp.text.Font.BOLD));
            PdfPCell clHeader = new PdfPCell(phHeader);
            clHeader.Colspan = noOfColumns;
            clHeader.Border = PdfPCell.NO_BORDER;
            clHeader.HorizontalAlignment = Element.ALIGN_CENTER;
            mainTable.AddCell(clHeader);

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
                            s = s.Replace("&#241;", "ñ");

                            Phrase ph = new Phrase(s, FontFactory.GetFont("Arial", ReportTextSize, iTextSharp.text.Font.NORMAL));
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
                                s = s.Replace("&#241;", "ñ");

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
                                s = s.Replace("&#241;", "ñ");

                                Phrase ph = new Phrase(s, FontFactory.GetFont("Arial", ReportTextSize, iTextSharp.text.Font.NORMAL));
                                mainTable.AddCell(ph);
                            }
                        }
                    }
                }

                // Tells the mainTable to complete the row even if any cell is left incomplete.
                mainTable.CompleteRow();
                mainTable.SetWidths(new Single[] { 45, 90, 100, 70, 70, 120, 120, 100, 150, 100, 60 });
            }


            document.AddTitle("REPORTE DE ITEMS ASIGNADOS POR CUSTODIO");
            //... el asunto

            document.AddSubject("ITEMS POR CUSTODIO ");

            string cusActivoFijo = ConfigurationManager.AppSettings["AreaActivosFijosIngreso"];
            string CUSTODIO = ddCustodio.SelectedItem.ToString();
            if (CUSTODIO == "")
            {
                CUSTODIO = "Todos [" + Total + "]";
            }


            string cust1 = "";
            if (CUSTODIO.Contains('['))
            {
                string[] cust = CUSTODIO.Split('[');
                cust1 = cust[0];
            }
            else
            {
                cust1 = CUSTODIO;
            }

            //string Path = "c:/" + System.DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss") + "REPORTE DE ACTIVOS DESIGNADOS POR CUSTODIO.pdf";
            string Path = Server.MapPath("./PDF/") + cust1 + " " + System.DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf";

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

            iTextSharp.text.Font myfont = new iTextSharp.text.Font(FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL));
            iTextSharp.text.Font myfont2 = new iTextSharp.text.Font(FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL));
            iTextSharp.text.Font myfont3 = new iTextSharp.text.Font(FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD));
            iTextSharp.text.Font myfontLabelCab = new iTextSharp.text.Font(FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.NORMAL));
            iTextSharp.text.Font myfontTitulo = new iTextSharp.text.Font(FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD));
            iTextSharp.text.Font myfontLabelNormal = new iTextSharp.text.Font(FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL));
            iTextSharp.text.Font myfontLabel = new iTextSharp.text.Font(FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD));
            iTextSharp.text.Font myfontbold = new iTextSharp.text.Font(FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD));

            //agregar todo el paquete de texto

            string ServerPath;
            ServerPath = Server.MapPath("");
            string ruta = ServerPath + "\\Logo\\logo.png";


            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(ruta);
            jpg.ScalePercent(30f); //tamaño de imagen en porcentaje
            jpg.Alignment = iTextSharp.text.Image.ALIGN_RIGHT;
            document.Add(jpg);

            document.Add(new Paragraph("\n"));

            /*Paragraph UserName = new Paragraph("Usuario: " + Membership.GetUser().UserName.Trim() + "   Fecha: " + System.DateTime.Now.ToString("dd/MM/yyyy HH:mm"), myfontLabelCab);
            document.Add(UserName);

            document.Add(Chunk.NEWLINE);

            Chunk lblRespon = new Chunk("Responsable: ", myfontLabel);
            Chunk lblResponval = new Chunk(ddCustodio.SelectedItem.Text.Trim(), myfontLabelNormal);
            Phrase resp = new Phrase();
            resp.Add(lblRespon);
            resp.Add(lblResponval);
            document.Add(resp);
            document.Add(Chunk.NEWLINE);

            Chunk lblOfi = new Chunk("Oficina: ", myfontLabel);
            Chunk lblOfival = new Chunk(ddUge3.SelectedItem.Text.Trim(), myfontLabelNormal);
            Phrase Ofi = new Phrase();
            Ofi.Add(lblOfi);
            Ofi.Add(lblOfival);
            document.Add(Ofi);
            document.Add(Chunk.NEWLINE);

            Chunk lblCCosto = new Chunk("Centro de Costos: ", myfontLabel);
            Chunk lblCostosval = new Chunk(ddCcosto.SelectedItem.Text.Trim(), myfontLabelNormal);
            Phrase cCosto = new Phrase();
            cCosto.Add(lblCCosto);
            cCosto.Add(lblCostosval);
            document.Add(cCosto);

            document.Add(new Paragraph("\n"));*/

            Paragraph P = new Paragraph("ACTA DE LOS ACTIVOS FIJOS Y BIENES SUJETOS DE CONTROL ASIGNADOS POR CUSTODIO" + "\n", myfontTitulo);
            P.Alignment = Element.ALIGN_CENTER;
            document.Add(P);
            document.Add(new Paragraph("\n"));
            Paragraph P01 = new Paragraph("ACTA DE LOS ACTIVOS FIJOS Y BIENES SUJETOS DE CONTROL DE LA UNIDAD ADMINISTRATIVA; ENTRE EL SEÑOR(a). " +
                                          cusActivoFijo + ", REPRESENTANTE DE ACTIVOS FIJOS, Y EL(la) SEÑOR(a) " + cust1 + ", CUSTODIO, AL " + DateTime.Now.ToString("dd-MM-yyyy"), myfont);
            P01.Alignment = Element.ALIGN_JUSTIFIED;
            document.Add(P01);
            document.Add(new Paragraph("\n"));
            Paragraph P02 = new Paragraph("En la ciudad de QUITO, los suscritos señores(a) " + cusActivoFijo +
                                          ", quien entrega los bienes, señor(a) " + cust1 + ", quien recibe los bienes, con el objeto de realizar la diligencia de entrega – recepción correspondiente. Al efecto con la presencia de las personas mencionadas anteriormente se procede con la constatación física y entrega-recepción de los activos fijos y bienes sujetos de control administrativo, de acuerdo con el siguiente detalle: \n", myfont);
            P02.Alignment = Element.ALIGN_JUSTIFIED;
            document.Add(P02);
            document.Add(new Paragraph("\n"));

            Paragraph P03 = new Paragraph("Lista del inventario de bienes constatados físicamente: \n", myfont);
            P03.Alignment = Element.ALIGN_JUSTIFIED;
            document.Add(P03);

            /*se añade tabla con todos los activos*/
            mainTable.WidthPercentage = 100;
            document.Add(mainTable);

            document.Add(new Paragraph("\n"));

            Paragraph P3 = new Paragraph("Se deja constancia que el custodio entrante recibe a satisfacción y se encargará de velar por el buen uso, conservación, administración, utilización, así como que las condiciones sean adecuadas y no se encuentren en riesgo de deterioro de los bienes antes mencionados y confiados a su guarda, de acuerdo con lo que estipula el manual de activos fijos referente al control y administración.", myfont);
            P3.Alignment = Element.ALIGN_JUSTIFIED;
            document.Add(P3);

            document.Add(new Paragraph("\n"));

            Paragraph P41 = new Paragraph("Para Constancia de lo actuado y en fe de conformidad y aceptación, suscriben la presente acta entrega-recepción en tres ejemplares de igual tenor y efecto las personas que intervienen en esta diligencia. \n", myfont);
            P41.Alignment = Element.ALIGN_JUSTIFIED;
            document.Add(P41);

            document.Add(new Paragraph("\n"));

            //di

            document.Add(new Paragraph("\n\n", myfont));
            //Tabla para poner firmas
            PdfPTable tableFirma = new PdfPTable(2);

            PdfPCell cellEntrega = new PdfPCell(new Phrase(cusActivoFijo, myfont));
            PdfPCell cellRecibe = new PdfPCell(new Phrase(cust1, myfont));
            PdfPCell cellEntrega1 = new PdfPCell(new Phrase(new Chunk("CONTROL DE ACTIVOS FIJOS.", myfont)));
            PdfPCell cellRecibe1 = new PdfPCell(new Phrase(new Chunk("Recibí Conforme", myfontbold)));
            PdfPCell cellEntrega2 = new PdfPCell(new Phrase("Entregue Conforme", myfontbold));
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


            //esto es importante, pues si no cerramos el document entonces no se creara el pdf.
            document.Close();

            //esto es para abrir el documento y verlo inmediatamente después de su creación
            //string ubicacion = ddUge1.SelectedItem.ToString() + " " + ddUge2.SelectedItem.ToString() + " " + ddUge3.SelectedItem.ToString() + " " + ddUor1.SelectedItem.ToString() + " " + ddUor2.SelectedItem.ToString();
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
        string funcion = "OpenWindows('" + ventana + "')";
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
        string folderToBrowse = Server.MapPath("./PDF_ACTING/");
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


            codigoCustodio = Logica.HELPER.getCodigoCustodio("");

            nombreCustodio = Logica.HELPER.getNombreCustodio("");

            //if (codigoCustodio != "")
            //{

            query = query + " AND cus_id1='" + codigoCustodio + "'";
            query = query + " AND act_fechabaja is null";
            //}


            if (nombreCustodio != "")
            {
                //lblNombreCustodio.Text = nombreCustodio;

            }
            else
            {
                //lblNombreCustodio.Text = "Custodio No Existe";
            }


            DataTable dt = Logica.HELPER.getReporteActivosPdf(query);
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
    protected void ibcorreo_Click(object sender, ImageClickEventArgs e)
    {
        if (rgitems.Rows.Count > 0)
        {
            try
            {
                string err = "";
                exportarPdf(rgitems, "");
                err = EnviaMail();


                messbox1.Mensaje = err;
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
    public string EnviaMail()
    {
        string codigoCustodio = Logica.HELPER.getCodigoCustodio("");

        string msgCorreo = "";
        string msgMaildestino = "";
        string err = "";

        string maildestino = Logica.HELPER.getMailCustodio(codigoCustodio);
        if (maildestino == "" || maildestino == null)
        {
            msgMaildestino = " [No se pudo enviar E-mail, custodio no tiene registrado correo electronico.]";
        }
        else
        {
            string nameFile;
            string sde = ConfigurationManager.AppSettings["CORREO_ADMINISTRADOR"].ToString();
            string spara = maildestino.ToString();
            string sasunto = "Detalle de Items entregado a Custodio";
            string scuerpo = "Favor verificar archivo adjunto en el cual se detalla(n) el(los) item(s) que ha(n) sido puestos a su custodia. si el(los) Items no le pertenece(n), notificar al Administrador.";
            nameFile = Session["PathPDFmail"].ToString();

            if (!Correos.EnviarCorreo(sde, spara, "", sasunto, scuerpo, nameFile, "PDF"))
            {
                msgCorreo = " [Error al Enviar E-mail, revise las credenciales.]";
            }
            else
            {
                err = "E-Mial enviado con éxito...!!!";
            }
        }

        return err + msgMaildestino + msgCorreo;
    }
    protected void ddCustodio_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string query = "";
            if (ddCustodio.SelectedValue != "")
            {
                if (ddCustodio.SelectedValue != "")
                {
                    query = query + " AND cus_id1='" + ddCustodio.SelectedValue + "'";
                }
                if (chboxTodos.Checked)
                {
                    //query = query + " and ACT_FECHACREACION = '" + Convert.ToDateTime(datefechaingreso.SelectedDate.ToString()).ToString("yyyy-MM-dd") + "'";
                    query = query + " and ACT_FECHACREACION = '" + Convert.ToDateTime(datefechaingreso.SelectedDate) + "'";
                }

                query = query + " AND act_fechabaja is null";

                DataTable dt = Logica.HELPER.getReporteActivosPdf(query);
                Cache["Repodt"] = dt;
                rgitems.DataSource = setExport(dt);
                rgitems.DataBind();


                if (dt.Rows.Count > 0)
                {

                    pancus.Visible = true;
                    pancus.GroupingText = "Items bajo su cargo [ " + dt.Rows.Count.ToString() + " Items ]";
                }
                else
                {
                    pancus.Visible = false;
                    cddCustodio.SelectedValue = "";

                    messbox1.Mensaje = "No Existen Datos";
                    messbox1.Tipo = "W";
                    messbox1.showMess();
                }

            }
            else
            {
                pancus.Visible = false;
            }

            upgrid.Update();
            upGrillaItems.Update();

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

    protected void chboxTodos_CheckedChanged(object sender, EventArgs e)
    {
        if (chboxTodos.Checked)
        {
            datefechaingreso.Enabled = true;     
            cddCustodio.SelectedValue = "";
            pancus.Visible = false;

            upgrid.Update();
            upGrillaItems.Update();
            ddCustodio.SelectedIndexChanged +=ddCustodio_SelectedIndexChanged;
        }
        else
        {
            datefechaingreso.Enabled = false;
            try
            {
                string query = "";

                if (ddCustodio.SelectedValue != "")
                {

                    if (ddCustodio.SelectedValue != "")
                    {
                        query = query + " AND cus_id1='" + ddCustodio.SelectedValue + "'";
                    }

                    query = query + " AND act_fechabaja is null";

                    DataTable dt = Logica.HELPER.getReporteActivosPdf(query);
                    Cache["Repodt"] = dt;
                    rgitems.DataSource = setExport(dt);
                    rgitems.DataBind();

                    if (dt.Rows.Count > 0)
                    {

                        pancus.Visible = true;
                        pancus.GroupingText = "Items bajo su cargo [ " + dt.Rows.Count.ToString() + " Items ]";

                    }
                    else
                    {
                        cddCustodio.SelectedValue = "";
                        pancus.Visible = false;
                        messbox1.Mensaje = "No Existen Datos";
                        messbox1.Tipo = "W";
                        messbox1.showMess();

                    }
                    
                }
                else
                {
                    pancus.Visible = false;
                }

                upgrid.Update();
                upGrillaItems.Update();
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

    protected void rgitems_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            //e.Row.Attributes.Add("style", "vnd.ms-excel.numberformat:@"); //Para todo el documento
            e.Row.Cells[1].Attributes.Add("style", "vnd.ms-excel.numberformat:0"); //para columna especifica
            //vnd.ms-excel.numberformat:0 formato sin ceros
            //vnd.ms-excel.numberformat:0\\.00 formato con decimales
            //vnd.ms - excel.numberformat:@ formato texto

        }
    }
}

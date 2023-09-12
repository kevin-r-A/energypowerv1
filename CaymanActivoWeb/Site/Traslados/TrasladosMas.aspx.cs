using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Web.Security;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using UGEOGRAFICA = Logica.UGEOGRAFICA;
using Logica;
using DevExpress.XtraReports.Templates;
using System.Globalization;
using CustomEditors;
using System.Collections.Generic;
using System.Linq;

public partial class TrasladosMas : System.Web.UI.Page
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
            div_Repo.Attributes.Add("heigth", "800px");

            try
            {
                if (ConfigurationManager.AppSettings["CCOUGE"] == "0")
                {
                    cddccosto.ParentControlID = "";
                    cddccosto.ServiceMethod = "GetCcosto";

                    ddCcosto11_CascadingDropDown.ParentControlID = "";
                    ddCcosto11_CascadingDropDown.ServiceMethod = "GetCcosto";
                }
                else if (ConfigurationManager.AppSettings["CCOUGE"] == "1")
                {
                    cddccosto.ParentControlID = "ddUge1";
                    cddccosto.ServiceMethod = "GetCcostoUge1";

                    ddCcosto11_CascadingDropDown.ParentControlID = "ddUge11";
                    ddCcosto11_CascadingDropDown.ServiceMethod = "GetCcostoUge1";
                }
                else if (ConfigurationManager.AppSettings["CCOUGE"] == "2")
                {
                    cddccosto.ParentControlID = "ddUge2";
                    cddccosto.ServiceMethod = "GetCcostoUge2";

                    ddCcosto11_CascadingDropDown.ParentControlID = "ddUge22";
                    ddCcosto11_CascadingDropDown.ServiceMethod = "GetCcostoUge2";
                }
                else if (ConfigurationManager.AppSettings["CCOUGE"] == "3")
                {
                    cddccosto.ParentControlID = "ddUge3";
                    cddccosto.ServiceMethod = "GetCcostoUge3";

                    ddCcosto11_CascadingDropDown.ParentControlID = "ddUge33";
                    ddCcosto11_CascadingDropDown.ServiceMethod = "GetCcostoUge3";
                }

                if (ConfigurationManager.AppSettings["UORCCO"] == "0")
                {
                    cdduor1.ParentControlID = "";
                    cdduor1.ServiceMethod = "GetUor1";

                    ddUor22_CascadingDropDown.ParentControlID = "";
                    ddUor22_CascadingDropDown.ServiceMethod = "GetUor1";
                }
                else if (ConfigurationManager.AppSettings["UORCCO"] == "1")
                {
                    cdduor1.ParentControlID = "ddCcosto";
                    cdduor1.ServiceMethod = "GetUor1Cco";

                    ddUor22_CascadingDropDown.ParentControlID = "ddCcosto11";
                    ddUor22_CascadingDropDown.ServiceMethod = "GetUor1Cco";
                }

                this.Title = ConfigurationManager.AppSettings["Titulo"] + " Reporte de Activos";

                ibsave.Attributes.Add("onmouseout", "this.src='../../Img/t1.png'");
                ibsave.Attributes.Add("onmouseover", "this.src='../../Img/t2.png'");

                ibcancel.Attributes.Add("onmouseout", "this.src='../../Img/d1.png'");
                ibcancel.Attributes.Add("onmouseover", "this.src='../../Img/d2.png'");

                ibtrans.Attributes.Add("onmouseout", "this.src='../../Img/e1.png'");
                ibtrans.Attributes.Add("onmouseover", "this.src='../../Img/e2.png'");

                Unit u = new Unit(Convert.ToDouble(ConfigurationManager.AppSettings["Rgalto3"]), UnitType.Pixel);
                rgactivos.Height = u;
            }
            catch (Exception ex)
            {
                errtrap = new ErrorTrapper();
                errtrap.SetOnError("Usuario:" + Membership.GetUser().UserName + "<< " + ex.Message, 0);
                messbox1.Mensaje = "Error. " + ex.Message;
                messbox1.Tipo = "E";
                messbox1.showMess();
            }
        }
    }

    private void reset()
    {
        try
        {
            chk1.Checked = true;
            ddtipo.SelectedIndex = 0;
            cddgeo1.SelectedValue = "";
            cddccosto.SelectedValue = "";
            cddcus.SelectedValue = "";
            upFiltro.Update();
        }
        catch (Exception ex)
        {
            errtrap = new ErrorTrapper();
            errtrap.SetOnError("Usuario:" + Membership.GetUser().UserName + "<< " + ex.Message, 0);
            messbox1.Mensaje = "Error. " + ex.Message;
            messbox1.Tipo = "E";
            messbox1.showMess();
        }
    }

    protected void ibcancel_Click(object sender, ImageClickEventArgs e)
    {
        reset();
    }

    protected void ibsave_Click(object sender, ImageClickEventArgs e)
    {
        cargarGrid();
    }

    private void cargarGrid()
    {
        try
        {
            string query = "";

            if (ddtipo.SelectedIndex != 0)
            {
                query = query + " and ACT_TIPO='" + ddtipo.SelectedValue + "'";
            }

            if (ddUge1.SelectedValue != "")
            {
                query = query + " and UG1.UGE_NOMBRE='" + ddUge1.SelectedItem.Text + "'";
            }

            if (ddUge2.SelectedValue != "")
            {
                query = query + " and UG2.UGE_NOMBRE='" + ddUge2.SelectedItem.Text + "'";
            }

            if (ddUge3.SelectedValue != "")
            {
                query = query + " and UG3.UGE_NOMBRE='" + ddUge3.SelectedItem.Text + "'";
            }

            if (ddPiso.SelectedValue != "")
            {
                query = query + " and UG4.UGE_NOMBRE='" + ddPiso.SelectedItem.Text + "'";
            }

            if (ddCcosto.SelectedValue != "")
            {
                query = query + " and UO1.UOR_NOMBRE='" + ddCcosto.SelectedItem.Text + "'";
            }

            if (ddUor1.SelectedValue != "")
            {
                query = query + " and UO2.UOR_NOMBRE='" + ddUor1.SelectedItem.Text + "'";
            }

            if (ddUor2.SelectedValue != "")
            {
                query = query + " and UO3.UOR_NOMBRE='" + ddUor2.SelectedItem.Text + "'";
            }

            if (ddCustodio.SelectedValue != "")
            {
                query = query + " and ACTIVO.CUS_ID1=" + ddCustodio.SelectedValue + "";
            }

            query = query + " and act_fechabaja is null";

            DataTable dt = Logica.HELPER.getReporteGlobalTras(query);
            rgactivos.DataSource = dt;
            rgactivos.DataBind();
        }
        catch (Exception ex)
        {
            errtrap = new ErrorTrapper();
            errtrap.SetOnError("Usuario:" + Membership.GetUser().UserName + "<< " + ex.Message, 0);
            messbox1.Mensaje = "Error. " + ex.Message;
            messbox1.Tipo = "E";
            messbox1.showMess();
        }
    }

    protected void chk1_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (!chk1.Checked)
            {
                //cddccosto.ParentControlID = "";
                //cddccosto.ServiceMethod = "GetCcosto";

                cddcus.ParentControlID = "";
                cddcus.ServiceMethod = "GetCus";
                upFiltro.Update();
            }
            else
            {
                //cddccosto.ParentControlID = "ddUge2";
                //cddccosto.ServiceMethod = "GetCcostoUge2";

                cddcus.ParentControlID = "ddUor1";
                cddcus.ServiceMethod = "GetCusUor1";
                upFiltro.Update();
            }
        }
        catch (Exception ex)
        {
            errtrap = new ErrorTrapper();
            errtrap.SetOnError("Usuario:" + Membership.GetUser().UserName + "<< " + ex.Message, 0);
            messbox1.Mensaje = "Error. " + ex.Message;
            messbox1.Tipo = "E";
            messbox1.showMess();
        }
    }

    protected void ibtrans_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            int contador = 0;
            int contadort = 0;
            int contadore = 0;

            string ubigrid = "";

            string error = "";

            string erroractivos = "";

            string ubicdd = ddUge11.SelectedItem + ";" +
                            ddUge22.SelectedItem + ";" +
                            ddUge33.SelectedItem + ";" +
                            ddPiso44.SelectedItem + ";" +
                            ddCcosto11.SelectedItem + ";" +
                            ddUor22.SelectedItem + ";" +
                            ddUor33.SelectedItem + ";" +
                            ddCustodio44.SelectedItem + ";" +
                            //ddEstado11.SelectedItem + ";" +
                            //ddFase22.SelectedItem + ";" +
                            ddTrasnfer33.SelectedItem;

            int cuentaItems = rgactivos.SelectedItems.Count;

            string[] Arr = new string[cuentaItems];
            string[] custodio = new string[cuentaItems];
            string newCus = ddCustodio44.SelectedValue.ToString();
            string NuevaCiu = ddUge22.SelectedValue.ToString();
            Guid guid = Guid.NewGuid();
            var procesado = true;
            string antGeo2 = rgactivos.SelectedItems.Count > 0 ? rgactivos.SelectedItems[0].Cells[7].Text : "0";
            string antUor = rgactivos.SelectedItems.Count > 0 ? rgactivos.SelectedItems[0].Cells[10].Text : "0";

            string antUor2 = rgactivos.SelectedItems.Count > 0 ? rgactivos.SelectedItems[0].Cells[11].Text : "0";
            string antCus = rgactivos.SelectedItems.Count > 0 ? rgactivos.SelectedItems[0].Cells[13].Text : "( SIN CUSTODIO )";

            foreach (Telerik.Web.UI.GridDataItem item in rgactivos.SelectedItems)
            {
                ubigrid = item.Cells[5].Text + ";" +
                          item.Cells[6].Text + ";" +
                          item.Cells[7].Text + ";" +
                          item.Cells[8].Text + ";" +
                          item.Cells[9].Text + ";" +
                          item.Cells[10].Text + ";" +
                          item.Cells[11].Text + ";" +
                          item.Cells[12].Text + ";" +
                          //item.Cells[13].Text + ";" + //responsable
                          //item.Cells[15].Text + ";" + //estado1
                          //item.Cells[16].Text + ";" + //estado2
                          item.Cells[17].Text;

                //comparo ubicacion anterior vs actual, si son diferentes actualizo e inserto
                if (ubigrid.Trim().Replace(" ", "").ToUpper() != ubicdd.Trim().Replace(" ", "").ToUpper())
                {
                    //actualizao e inserto
                    //error = Logica.HELPER.iniTransfer(
                    var result1 = Logica.HELPER.creaTransfer(int.Parse(item.Cells[3].Text),
                        Membership.GetUser().UserName.ToLower(),
                        int.Parse(ddUge11.SelectedValue),
                        int.Parse(ddUge22.SelectedValue),
                         int.Parse(ddUge33.SelectedValue),
                         int.Parse(ddPiso44.SelectedValue),
                         int.Parse(ddCcosto11.SelectedValue),
                        int.Parse(ddUor22.SelectedValue),
                        int.Parse(ddUor33.SelectedValue),
                        int.Parse(ddCustodio44.SelectedValue),
                        //int.Parse(ddEstado11.SelectedValue),
                        //int.Parse(ddFase22.SelectedValue),
                        Logica.HELPER.getEstado(int.Parse(item.Cells[3].Text), "est_id1"),
                        Logica.HELPER.getEstado(int.Parse(item.Cells[3].Text), "est_id2"),
                        int.Parse(ddTrasnfer33.SelectedValue), "TM", guid, 1);
                    procesado = procesado && result1;
                    Logica.ACTIVO _act1 = new Logica.ACTIVO(int.Parse(item.Cells[3].Text));

                    if (error != "")
                    {
                        erroractivos = item.Cells[1].Text + ";" + erroractivos;
                        contadore++;
                    }
                    else
                    {
                        if (_act1.ACT_TIPO == "Activo Fijo")
                        {
                            /*Asiento*/
                            Logica.UGEOGRAFICA ugeOrigen = new Logica.UGEOGRAFICA(_act1.UGE_ID2);
                            Logica.UGEOGRAFICA ugeDestino = new Logica.UGEOGRAFICA(int.Parse(ddUge22.SelectedValue));
                            Logica.UORGANICA uorOrigen = new Logica.UORGANICA(_act1.UOR_ID2);
                            Logica.UORGANICA uorDestino = new Logica.UORGANICA(int.Parse(ddUor22.SelectedValue));
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
                        }

                        Arr[contadort] = Arr[contadort] + item.Cells[3].Text;
                        custodio[contadort] = item.Cells[13].Text;
                        contadort++;
                    }
                }
                else
                {
                    //nada
                    contador++;
                }
            }

            //2012-02-15_Andrea.- Llamar para crear PDF
            if (contadort != 0 && procesado)
            {
                    
                    CrearPdf(contadort, Arr, custodio, newCus, NuevaCiu, "Acta Entrega TM - " + ddCustodio44.SelectedItem.Text, antGeo2, antUor2, antCus, antUor);
             }
                else
                {
                    errtrap = new ErrorTrapper();
                    errtrap.SetOnError(
                        "Usuario:" + Membership.GetUser().UserName + "<< Uno o mas activos no se pudieron trasnferir ",
                        0);
                    messbox1.Mensaje = "Error. " + "Uno o mas activos no se pudieron trasnferir";
                    messbox1.Tipo = "E";
                    messbox1.showMess();
                }

                messbox1.Mensaje = "Resumen de la Transferencia: <br/><br/> Transferido(s): [ " + contadort +
                                   " ]<br/>Ya constaba(n) en la ubicación: [ " + contador +
                                   " ]<br/>Error(es) en la transferencia: [ " + contadore + " " + erroractivos + " ]";

                messbox1.Tipo = "I";
                messbox1.showMess();

                //quito mensaje de espera
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "DICE2", "MsgMostrar('0');", true);

                cargarGrid();
                upgrid.Update();
            }
        
        catch (Exception ex)
        {
            errtrap = new ErrorTrapper();
            errtrap.SetOnError("Usuario:" + Membership.GetUser().UserName + "<< " + ex.Message, 0);
            messbox1.Mensaje = "Error. " + ex.Message;
            messbox1.Tipo = "E";
            messbox1.showMess();
        }
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
            Valor = "La variable de relleno no puede tener nada más que un carácter";
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


    private void CrearPdf(int contadort, string[] actId, string[] custodio, string newCus, string NuevaCiu, string nombre, string antGeo2, string antUor2, string antCus,string antUor)
    {
        try
        {
            //int numPDF = F_TotalPDF() + 1;
            //string PDFnum = F_llenaceros(Convert.ToString(numPDF), 5, "0");

            //2012-02-15_Andrea.- Llamar para crear PDF

            Datos.SqlService sql1 = new Datos.SqlService();
            Object AreaActivos = Membership.GetUser().UserName.ToString();
            Object NuevoCus = sql1.ExecuteSqlObject("select (cus_nombres +' '+ CUS_apellidos) from CUSTODIO where cus_id='" + newCus + "'");
            Object NewCiu = sql1.ExecuteSqlObject("select uge_nombre from ugeografica where uge_id='" + NuevaCiu + "'");
            string TituloReporte = ConfigurationManager.AppSettings["TituloReportes"].ToString();
            Object AnteriorCus = antCus;
            /*
             Object AnteriorCus = sql1.ExecuteSqlObject("select (cus_nombres +' '+ CUS_apellidos) from CUSTODIO where cus_id=(select cus_id1 from activo where act_id=" +
             actId[0] + ")");
             Object Ugeo2 = sql1.ExecuteSqlObject("select uge_nombre from ugeografica where uge_id=(select Uge_id2 from activo where act_id=" + antGeo2 + ")");
            Object Uorg2 = sql1.ExecuteSqlObject("select uor_nombre from uorganica where uor_id=(select Uor_id2 from activo where act_id=" + antUor2 + ")");*/
            //Object Uorg1 = sql1.ExecuteSqlObject("select uor_nombre from uorganica where uor_id=(select Uor_id1 from activo where act_id=" + antUor + ")");
            Object Ugeo2 = antGeo2;
            Object Uorg2 = antUor2;

            //EMPIEZA PDF

            //creamos el documento
            //...ahora configuramos para que el tamaño de hoja sea A4
            //Document document = new Document(iTextSharp.text.PageSize.A4);
            Document document = new Document(new RectangleReadOnly(842f, 595f), 50, 30, 15, 5);
            //document.PageSize.Rotate();

            //hacemos que se inserte la fecha de creación para el documento
            document.AddCreationDate();

            //...título
            document.AddTitle("ACTA DE ENTREGA RECEPCIÓN POR TRANSFERENCIA MASIVA");

            //... el asunto
            document.AddSubject("ACTA DE ENTREGA RECEPCIÓN");

            //string Path = "c:/" + System.DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss") + "ACTA DE ENTREGA RECEPCIÓN TRANSFERENCIA MASIVA.pdf";
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

            //agregar todo el paquete de texto


            string ServerPath;
            ServerPath = Server.MapPath("");
            string ruta = ServerPath + "\\Logo\\logo.png";


            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(ruta);
            jpg.ScalePercent(30f); //tamaño de imagen en porcentaje
            jpg.Alignment = iTextSharp.text.Image.LEFT_ALIGN;
            document.Add(jpg);
            document.Add(new Paragraph("\n"));
            Paragraph P1 = new Paragraph("COOPERATIVA DE AHORRO Y CREDITO ALIANZA DEL VALLE LTDA. ");
            P1.Alignment = Element.ALIGN_CENTER;

            document.Add(P1);
            document.Add(new Paragraph("\n"));


            Paragraph P = new Paragraph("ACTA DE TRANSFERENCIAS INTERNAS DE ACTIVOS FIJOS Y ACTIVOS DE CONTROL" + "\n", myfontTitulo);
            P.Alignment = Element.ALIGN_CENTER;
            document.Add(P);
            document.Add(new Paragraph("\n"));

            //Paragraph P = new Paragraph("TRANSFERENCIAS INTERNAS DE ACTIVOS FIJOS" + "\n", myfontTitulo);
            //P.Alignment = Element.ALIGN_CENTER;
            //document.Add(P);

            //document.Add(new Paragraph("\n"));


            //Paragraph P01 = new Paragraph("ACTA DE TRASLADO DE LOS ACTIVOS FIJOS Y BIENES DE CONTROL DE LA UNIDAD ADMINISTRATIVA; ENTRE EL SEÑOR(a). " +
            //                              AnteriorCus + ", Y SEÑOR(a) " + NuevoCus.ToString() +
            //                              ", CUSTODIOS QUIENES ENTREGAN Y RECEPTAN LOS ACTIVOS RESPECTIVAMENTE, AL " + DateTime.Now.ToString("dd-MM-yyyy"), myfont);
            //P01.Alignment = Element.ALIGN_JUSTIFIED;
            //document.Add(P01);

            //document.Add(new Paragraph("\n"));

            //Paragraph P02 = new Paragraph("En la ciudad de QUITO, los suscritos señores(a) " + AnteriorCus +
            //                              ", quien entrega los bienes, señor(a) " + NuevoCus.ToString() +
            //                              ", quien recibe los bienes, con el objeto de realizar la diligencia de entrega – recepción correspondiente. Al efecto con la presencia de las personas mencionadas anteriormente se procede con la constatación física y entrega-recepción de los activos fijos y bienes sujetos de control administrativo, de acuerdo con el siguiente detalle: \n",
            //    myfont);
            //P02.Alignment = Element.ALIGN_JUSTIFIED;
            //document.Add(P02);
            CultureInfo culturaEspañol = new CultureInfo("es-ES");
            Paragraph P02 = new Paragraph("En la ciudad de QUITO, a los " + DateTime.Now.Day + " del mes de " + DateTime.Now.ToString("MMMM", culturaEspañol) + " del " + DateTime.Now.Year + ", Sr(a) " + AnteriorCus +
                          " Oficial de crédito de la Agencia " + antUor.ToString() + ", realiza la entrega formal de los Activos Fijos y Activos de Control a Sr(a). " + NuevoCus.ToString() + " Oficial de crédito de la Agencia  " + ddCcosto11.SelectedItem.Text.Trim() + ", de acuerdo con el siguiente detalle:", myfont);
            P02.Alignment = Element.ALIGN_JUSTIFIED;
            document.Add(P02);

            document.Add(new Paragraph("\n"));

            //de - para
            //PdfPTable tblDe_A = new PdfPTable(3);
            //tblDe_A.DefaultCell.BorderWidth = 0;
            //tblDe_A.AddCell("ENTREGA:");
            //tblDe_A.AddCell("");
            //tblDe_A.AddCell("RECEPTA:");

            //tblDe_A.WidthPercentage = 100;
            //tblDe_A.SetWidths(new Single[] { 50, 80, 100 });

            //document.Add(tblDe_A);

            //PdfPTable tblDe_ADatos = new PdfPTable(3);

            //PdfPCell DeCustodio = new PdfPCell(new Phrase("Custodio: " + AnteriorCus.ToString(), myfont));
            //DeCustodio.BorderWidth = 0;
            //PdfPCell ACustodio = new PdfPCell(new Phrase("Custodio: " + NuevoCus.ToString(), myfont));
            //ACustodio.BorderWidth = 0;

            //PdfPCell DeOfi = new PdfPCell(new Phrase("Oficina: " + Ugeo2.ToString(), myfont));
            //DeOfi.BorderWidth = 0;
            //PdfPCell AOfi = new PdfPCell(new Phrase("Oficina: " + ddUge22.SelectedItem.Text.Trim(), myfont));
            //AOfi.BorderWidth = 0;

            //PdfPCell DeCCosto = new PdfPCell(new Phrase("Centro Costo: " + Uorg2, myfont));
            //DeCCosto.BorderWidth = 0;
            //PdfPCell ACCosto = new PdfPCell(new Phrase("Centro Costo: " + ddUor22.SelectedItem.Text.Trim(), myfont));
            //ACCosto.BorderWidth = 0;

            //PdfPCell blanco1 = new PdfPCell(new Phrase("", myfont));
            //blanco1.BorderWidth = 0;
            //PdfPCell blanco2 = new PdfPCell(new Phrase("", myfont));
            //blanco2.BorderWidth = 0;
            //PdfPCell blanco3 = new PdfPCell(new Phrase("", myfont));
            //blanco3.BorderWidth = 0;


            //tblDe_ADatos.AddCell(DeCustodio);
            //tblDe_ADatos.AddCell(blanco1);
            //tblDe_ADatos.AddCell(ACustodio);
            //tblDe_ADatos.AddCell(DeOfi);
            //tblDe_ADatos.AddCell(blanco2);
            //tblDe_ADatos.AddCell(AOfi);
            //tblDe_ADatos.AddCell(DeCCosto);
            //tblDe_ADatos.AddCell(blanco3);
            //tblDe_ADatos.AddCell(ACCosto);


            //tblDe_ADatos.WidthPercentage = 100;
            //tblDe_ADatos.SetWidths(new Single[] { 120, 25, 100 });

            //document.Add(tblDe_ADatos);
            //document.Add(new Paragraph("\n"));
            document.Add(new Paragraph("\n"));

            //Agregar tabla a Pdf
            PdfPTable table = new PdfPTable(16);

            PdfPCell cell = new PdfPCell(new Phrase("item", myfont3));
            PdfPCell cell1 = new PdfPCell(new Phrase("N° Comprobante", myfont3));
            PdfPCell cell2 = new PdfPCell(new Phrase("N° Factura", myfont3));
            PdfPCell cell3 = new PdfPCell(new Phrase("Proveedor", myfont3));
            PdfPCell cell4 = new PdfPCell(new Phrase("Código Barras", myfont3));
            PdfPCell cell5 = new PdfPCell(new Phrase("Tipo Activo", myfont3));
            PdfPCell cell6 = new PdfPCell(new Phrase("Grupo", myfont3));
            PdfPCell cell7 = new PdfPCell(new Phrase("Descripción", myfont3));
            PdfPCell cell8 = new PdfPCell(new Phrase("Estado", myfont3));
            PdfPCell cell9 = new PdfPCell(new Phrase("Marca", myfont3));
            PdfPCell cell10 = new PdfPCell(new Phrase("Serie", myfont3));
            PdfPCell cell11 = new PdfPCell(new Phrase("Modelo", myfont3));
            PdfPCell cell12 = new PdfPCell(new Phrase("Observaciones", myfont3));
            PdfPCell cell13 = new PdfPCell(new Phrase("Valor Compra", myfont3));
            PdfPCell cell14 = new PdfPCell(new Phrase("Depreciación Acumulada", myfont3));
            PdfPCell cell15 = new PdfPCell(new Phrase("Valor en Libros", myfont3));

            cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
            cell1.HorizontalAlignment = 1;
            cell2.HorizontalAlignment = 1;
            cell3.HorizontalAlignment = 1;
            cell4.HorizontalAlignment = 1;
            cell5.HorizontalAlignment = 1;
            cell6.HorizontalAlignment = 1;
            cell7.HorizontalAlignment = 1;
            cell8.HorizontalAlignment = 1;
            cell9.HorizontalAlignment = 1;
            cell10.HorizontalAlignment = 1;
            cell11.HorizontalAlignment = 1;
            cell12.HorizontalAlignment = 1;
            cell13.HorizontalAlignment = 1;
            cell14.HorizontalAlignment = 1;
            cell15.HorizontalAlignment = 1;

            table.AddCell(cell);
            table.AddCell(cell1);
            table.AddCell(cell2);
            table.AddCell(cell3);
            table.AddCell(cell4);
            table.AddCell(cell5);
            table.AddCell(cell6);
            table.AddCell(cell7);
            table.AddCell(cell8);
            table.AddCell(cell9);
            table.AddCell(cell10);
            table.AddCell(cell11);
            table.AddCell(cell12);
            table.AddCell(cell13);
            table.AddCell(cell14);
            table.AddCell(cell15);

            table.WidthPercentage = 100;
            table.SetWidths(new Single[] { 40, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100,100,100,100, 100 });

            DataTable Tabla = new DataTable();

            for (int i = 0; i <= actId.Length - 1; i++)
            {
                table.AddCell(new Paragraph((i + 1).ToString(), myfontTabla)); //contador de Item
                int act_Id = int.Parse(actId[i]);
                table.AddCell(new Paragraph("".ToString(), myfontTabla));
                Datos.SqlService sql = new Datos.SqlService();
                sql.AddParameter("@actid", SqlDbType.Int, act_Id);

                Tabla = sql.ExecuteSPDataTable("usp_getDatosPdf");
                for (int j = 0; j < 14; j++)
                {
                    table.AddCell(new Paragraph(Tabla.Rows[0][j].ToString(), myfontTabla));
                }
                //table.AddCell(new Paragraph(custodio[i].ToString(), myfontTabla));//Antiguo Custodio este valor se pasa desde la grid desde la posicion del nombre del antiguo custodio
            }

            table.WidthPercentage = 100;
            document.Add(table);

            document.Add(new Paragraph("\n"));


            Paragraph P3 = new Paragraph("Se deja constancia que el custodio  el señor " + NuevoCus.ToString() + " recibe a entera satisfacción los activos fijos detallados y  se encargará de velar por el buen uso, administración, así como garantizar que las condiciones sean adecuadas para su funcionamiento y no se encuentren en riesgo de deterioro.  En caso de pérdida o mal uso se aplicará lo establecido en la normativa interna de la Cooperativa.", myfont);

            P3.Alignment = Element.ALIGN_JUSTIFIED;
            document.Add(P3);

            document.Add(new Paragraph("\n"));

            Paragraph P41 = new Paragraph(
                "Para Constancia de lo actuado y en fe de conformidad y aceptación, suscriben la presente acta entrega-recepción en "+ actId.Length + " ejemplares de igual tenor y efecto las personas que intervienen en esta diligencia. \n",
                myfont);
            P41.Alignment = Element.ALIGN_JUSTIFIED;
            document.Add(P41);

            document.Add(new Paragraph("\n"));

            document.Add(new Paragraph("\n\n\n\n"));


            //Tabla para poner firmas
            string cusActivoFijo = ConfigurationManager.AppSettings["AreaActivosFijosIngreso"];
            PdfPTable tableFirma = new PdfPTable(2);

            //PdfPCell cellUBI1 = new PdfPCell(new Phrase(Uorg2 , myfont);
            PdfPCell cellUBI1 = new PdfPCell(new Phrase(new Chunk(antUor.ToString(), myfont)));

            PdfPCell cellUBI2 = new PdfPCell(new Phrase(ddCcosto11.SelectedItem.Text.Trim(), myfont));
            PdfPCell cellEntrega = new PdfPCell(new Phrase("Sr(a) " + AnteriorCus.ToString(), myfont));
            PdfPCell cellRecibe = new PdfPCell(new Phrase("Sr(a) "+NuevoCus.ToString(), myfont));
            PdfPCell cellEntrega1 = new PdfPCell(new Phrase("", myfont));
            PdfPCell cellRecibe1 = new PdfPCell(new Phrase("", myfont));
            PdfPCell cellEntrega2 = new PdfPCell(new Phrase("ENTREGUÉ CONFORME", myfont2));
            PdfPCell cellRecibe2 = new PdfPCell(new Phrase("RECIBÍ CONFORME", myfont2));

            cellUBI1.BorderWidth = 0;
            cellUBI1.HorizontalAlignment = 1;
            cellUBI2.BorderWidth = 0;
            cellUBI2.HorizontalAlignment = 1;
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

            tableFirma.AddCell(cellUBI1);
            tableFirma.AddCell(cellUBI2);
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

            string filePath = Path;

            Session["pdfFileName"] = filePath;

            abreVentana("VisualizaPDF.aspx?pdf=yes"); //envio pdf para abrirlo en nueva pestaña
        }
        catch (Exception ex)
        {
            errtrap = new ErrorTrapper();
            errtrap.SetOnError("Usuario:" + Membership.GetUser().UserName + "<< " + ex.Message, 0);
            messbox1.Mensaje = "Error. " + ex.Message;
            messbox1.Tipo = "E";
            messbox1.showMess();
        }
    }

    //2012-02-15_Andrea.- Crear pdf en transferencia masiva
    //private void CrearPdf(int contadort, string[] actId, string[] custodio, string newCus, string NuevaCiu, string nombre)
    //{
    //    try
    //    {
    //        int numPDF = F_TotalPDF() + 1;
    //        string PDFnum = F_llenaceros(Convert.ToString(numPDF), 5, "0");

    //        //2012-02-15_Andrea.- Llamar para crear PDF

    //        Datos.SqlService sql1 = new Datos.SqlService();
    //        Object NuevoCus = sql1.ExecuteSqlObject("select (cus_nombres +' '+ CUS_apellidos) from CUSTODIO where cus_id='" + newCus + "'");
    //        Object NewCiu = sql1.ExecuteSqlObject("select uge_nombre from ugeografica where uge_id='" + NuevaCiu + "'");
    //        string TituloReporte = ConfigurationManager.AppSettings["TituloReportes"].ToString();

    //        Object NuevoCusCC = sql1.ExecuteSqlObject("select cus_cedula from CUSTODIO where cus_id='" + newCus + "'");
    //        String NuevoCi = "";

    //        if (NuevoCusCC != null)
    //        {
    //            NuevoCi = NuevoCusCC.ToString();
    //        }
    //        else
    //        {
    //            NuevoCi = " ";
    //        }

    //        String AnteriorCi = "";

    //        //EMPIEZA PDF

    //        //creamos el documento
    //        //...ahora configuramos para que el tamaño de hoja sea A4
    //        //Document document = new Document(iTextSharp.text.PageSize.A4);
    //        Document document = new Document(iTextSharp.text.PageSize.A4.Rotate(), 40, 30, 15, 5);
    //        document.PageSize.Rotate();

    //        //hacemos que se inserte la fecha de creación para el documento
    //        document.AddCreationDate();

    //        //...título
    //        document.AddTitle("ACTA DE ENTREGA RECEPCIÓN POR TRANSFERENCIA MASIVA");

    //        //... el asunto
    //        document.AddSubject("ACTA DE ENTREGA RECEPCIÓN");

    //        //string Path = "c:/" + System.DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss") + "ACTA DE ENTREGA RECEPCIÓN TRANSFERENCIA MASIVA.pdf";
    //        string Path = Server.MapPath("./PDF/") + nombre + " " + System.DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf";

    //        //creamos un instancia del objeto escritor de documento
    //        PdfWriter writer = PdfWriter.GetInstance(document, new System.IO.FileStream(Path, System.IO.FileMode.Create));

    //        //definimos la manera de inicialización de abierto del documento.
    //        //esto, hará que veamos al inicio, todas la páginas del documento
    //        //en la parte izquierda
    //        writer.ViewerPreferences = PdfWriter.PageModeUseThumbs;

    //        //con esto conseguiremos que el documento sea presentada de dos en dos 
    //        writer.ViewerPreferences = PdfWriter.PageLayoutTwoColumnLeft;

    //        //abrimos el documento para agregarle contenido
    //        document.Open();

    //        iTextSharp.text.Font myfont = new iTextSharp.text.Font(
    //        FontFactory.GetFont(FontFactory.TIMES_ROMAN, 8, iTextSharp.text.Font.NORMAL));
    //        iTextSharp.text.Font myfont2 = new iTextSharp.text.Font(
    //        FontFactory.GetFont(FontFactory.TIMES_ROMAN, 12, iTextSharp.text.Font.NORMAL));
    //        iTextSharp.text.Font myfont3 = new iTextSharp.text.Font(
    //        FontFactory.GetFont(FontFactory.TIMES_ROMAN, 8, iTextSharp.text.Font.BOLD));

    //        //agregar todo el paquete de texto


    //        string ServerPath;
    //        ServerPath = Server.MapPath("");
    //        string ruta = ServerPath + "\\Logo\\logo.png";


    //        string Anterior_Cus = ddCustodio.SelectedItem.Text;

    //        if (Anterior_Cus == "")
    //        {
    //            Anterior_Cus = "SIN CUSTODIO";
    //            AnteriorCi = " ";
    //        }
    //        else
    //        {
    //            Anterior_Cus = ddCustodio.SelectedItem.Text;

    //            Object AnteriorCusCC = sql1.ExecuteSqlObject("select  cus_cedula from CUSTODIO where cus_id='" + ddCustodio.SelectedValue.ToString() + "'");

    //            if (AnteriorCusCC != null)
    //            {
    //                AnteriorCi = AnteriorCusCC.ToString();
    //            }
    //            else
    //            {
    //                AnteriorCi = " ";
    //            }
    //        }


    //        iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(ruta);
    //        jpg.ScalePercent(55f); //tamaño de imagen en porcentaje
    //        jpg.Alignment = iTextSharp.text.Image.ALIGN_CENTER;

    //        Paragraph P = new Paragraph("TRASPASO INTERNO DE BIENES Nº " + PDFnum +  " - " +System.DateTime.Now.Year.ToString() + "\n", myfont2);
    //        P.Alignment = Element.ALIGN_CENTER;
    //        document.Add(jpg);
    //        document.Add(P);


    //        document.Add(new Paragraph("\n"));

    //        Paragraph P1 = new Paragraph("Sangolqui" + ", a los " + System.DateTime.Now.Day.ToString() + " dias del mes de " + F_Mes(System.DateTime.Now.Month) + " de " + System.DateTime.Now.Year.ToString() + "\n\n ", myfont);
    //        P1.Alignment = Element.ALIGN_CENTER;
    //        document.Add(P1);

    //        Paragraph P2 = new Paragraph("Dirección: _____________________________________ que entrega                          Dirección que recibe: _____________________________________ \n\n ", myfont);
    //        P2.Alignment = Element.ALIGN_CENTER;
    //        document.Add(P2);

    //        //Agregar tabla a Pdf
    //        PdfPTable table = new PdfPTable(12);
    //        PdfPCell cell = new PdfPCell(new Phrase("Código de Barras", myfont3));
    //        PdfPCell celllogikard = new PdfPCell(new Phrase("Código Secundario", myfont3));
    //        PdfPCell cell1 = new PdfPCell(new Phrase("Grupo/Cuenta", myfont3));
    //        PdfPCell cell2 = new PdfPCell(new Phrase("Subgrupo", myfont3));
    //        PdfPCell cellDESCRIP = new PdfPCell(new Phrase("Descripcion", myfont3));
    //        PdfPCell cell3 = new PdfPCell(new Phrase("Detalle", myfont3));
    //        PdfPCell cell4 = new PdfPCell(new Phrase("Estado", myfont3));
    //        PdfPCell cell5 = new PdfPCell(new Phrase("Marca", myfont3));
    //        PdfPCell cell6 = new PdfPCell(new Phrase("Serie", myfont3));
    //        PdfPCell cell7 = new PdfPCell(new Phrase("Modelo", myfont3));
    //        PdfPCell cell8 = new PdfPCell(new Phrase("Observaciones", myfont3));
    //        PdfPCell cell9 = new PdfPCell(new Phrase("Custodio Anterior", myfont3));
    //        cell8.Colspan = 1;
    //        cell.Colspan = 1;

    //        cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right

    //        table.AddCell(cell);
    //        table.AddCell(celllogikard);
    //        table.AddCell(cell1);
    //        table.AddCell(cell2);
    //        table.AddCell(cellDESCRIP);
    //        table.AddCell(cell3);
    //        table.AddCell(cell4);
    //        table.AddCell(cell5);
    //        table.AddCell(cell6);
    //        table.AddCell(cell7);
    //        table.AddCell(cell8);
    //        table.AddCell(cell9);
    //        table.SetWidths(new Single[] { 120, 120, 90, 130, 130, 130, 70, 70, 70, 70, 120, 120 });
    //        //Creamos un dataTable que guarde información sobre los activos trasladados
    //        DataTable Tabla = new DataTable();

    //        for (int i = 0; i <= actId.Length - 1; i++)
    //        {
    //            int act_Id = int.Parse(actId[i]);

    //            Datos.SqlService sql = new Datos.SqlService();
    //            sql.AddParameter("@actid", SqlDbType.Int, act_Id);

    //            Tabla = sql.ExecuteSPDataTable("usp_getDatosPdf");
    //            for (int j = 0; j < 11; j++)
    //            {
    //                table.AddCell(new Paragraph(Tabla.Rows[0][j].ToString(), myfont));
    //            }
    //            table.AddCell(new Paragraph(custodio[i].ToString(), myfont));
    //        }

    //        table.WidthPercentage = 100;
    //        document.Add(table);
    //        document.Add(new Paragraph("\n"));

    //        Paragraph P6 = new Paragraph("Nota: Debera darse cumplimiento a lo dispuesto en el Artículo 3 del Reglamento General para la Administración, Utilización y Control de los Bienes y Existencias de Sector Publico, que textualmente dice:", myfont);
    //        P6.Alignment = Element.ALIGN_JUSTIFIED;
    //        document.Add(P6);

    //        Paragraph P3 = new Paragraph("Art 3.-... La conservación y el buen uso de los bienes y existencias, sera de responsabilidad de los usuarios finales o custodios responsables que los han recibido, para el desempeño de sus funciones y labores oficiales.", myfont);
    //        P3.Alignment = Element.ALIGN_JUSTIFIED;
    //        document.Add(P3);
    //        Paragraph P4 = new Paragraph("...El daño, perdida, destrucción del bien, por negligencia o su mal uso comprobados por la autoridad competente, no imputable al deterioro normal del las cosas, será de responsabilidad del Usuario Final que lo tiene a su cargo y de los terceros que de cualquier manera tienen acceso al bien cuando realicen acciones de mantenimiento o reparación por requerimiento propio, salvo que se conozca o se compruebe la identidad de la persona causante de la afectación del bien.", myfont);
    //        P4.Alignment = Element.ALIGN_JUSTIFIED;
    //        document.Add(P4);

    //        Paragraph P5 = new Paragraph("Con esta disposición, está usted en la obligación de informar a esta unidad sobre cualquier tipo de cambio y/o novedad que se haya presentado o realizado con la utilización de los bienes.", myfont);
    //        P5.Alignment = Element.ALIGN_JUSTIFIED;
    //        document.Add(P5);

    //        document.Add(new Paragraph("\n\n"));


    //        //Tabla para poner firmas
    //        PdfPTable tableFirma = new PdfPTable(4);

    //        PdfPCell cellCab = new PdfPCell(new Phrase("", myfont));
    //        PdfPCell cellEntrega = new PdfPCell(new Phrase("Quien Entrega", myfont));
    //        PdfPCell cellRecibe = new PdfPCell(new Phrase("Quien Recibe", myfont));
    //        PdfPCell cellAutorizado = new PdfPCell(new Phrase("Administración de Bienes", myfont));

    //        PdfPCell cellCab1 = new PdfPCell(new Phrase("Firma:", myfont));
    //        PdfPCell cellEntrega1 = new PdfPCell(new Phrase("________________________________", myfont));
    //        PdfPCell cellRecibe1 = new PdfPCell(new Phrase("________________________________", myfont));
    //        PdfPCell cellAutorizado1 = new PdfPCell(new Phrase("________________________________", myfont));

    //        PdfPCell cellCab2 = new PdfPCell(new Phrase("Custodio:", myfont));
    //        PdfPCell cellEntrega2 = new PdfPCell(new Phrase(Anterior_Cus.ToString().ToUpper(), myfont));
    //        PdfPCell cellRecibe2 = new PdfPCell(new Phrase(NuevoCus.ToString().ToUpper(), myfont));
    //        PdfPCell cellAutorizado2 = new PdfPCell(new Phrase("________________________________", myfont));

    //        PdfPCell cellCab3 = new PdfPCell(new Phrase("C.I.:", myfont));
    //        PdfPCell cellEntrega3 = new PdfPCell(new Phrase(AnteriorCi, myfont));
    //        PdfPCell cellRecibe3 = new PdfPCell(new Phrase(NuevoCi.ToString().ToUpper(), myfont));
    //        PdfPCell cellAutorizado3 = new PdfPCell(new Phrase("________________________________", myfont));

    //        //0=Left, 1=Centre, 2=Right
    //        cellCab.BorderWidth = 0;
    //        cellCab.HorizontalAlignment = 1;
    //        cellCab1.BorderWidth = 0;
    //        cellCab1.HorizontalAlignment = 0;
    //        cellCab2.BorderWidth = 0;
    //        cellCab2.HorizontalAlignment = 0;
    //        cellCab3.BorderWidth = 0;
    //        cellCab3.HorizontalAlignment = 0;
    //        cellEntrega.BorderWidth = 0;
    //        cellEntrega.HorizontalAlignment = 1;
    //        cellEntrega.FixedHeight = 30;
    //        cellEntrega1.BorderWidth = 0;
    //        cellEntrega1.HorizontalAlignment = 1;
    //        cellEntrega1.FixedHeight = 30;
    //        cellEntrega2.BorderWidth = 0;
    //        cellEntrega2.HorizontalAlignment = 1;
    //        cellEntrega2.FixedHeight = 30;
    //        cellEntrega3.BorderWidth = 0;
    //        cellEntrega3.HorizontalAlignment = 1;
    //        cellEntrega3.FixedHeight = 30;
    //        cellRecibe.BorderWidth = 0;
    //        cellRecibe.HorizontalAlignment = 1;
    //        cellRecibe1.BorderWidth = 0;
    //        cellRecibe1.HorizontalAlignment = 1;
    //        cellRecibe2.BorderWidth = 0;
    //        cellRecibe2.HorizontalAlignment = 1;
    //        cellRecibe3.BorderWidth = 0;
    //        cellRecibe3.HorizontalAlignment = 1;
    //        cellAutorizado.BorderWidth = 0;
    //        cellAutorizado.HorizontalAlignment = 1;
    //        cellAutorizado1.BorderWidth = 0;
    //        cellAutorizado1.HorizontalAlignment = 1;
    //        cellAutorizado2.BorderWidth = 0;
    //        cellAutorizado2.HorizontalAlignment = 1;
    //        cellAutorizado3.BorderWidth = 0;
    //        cellAutorizado3.HorizontalAlignment = 1;

    //        tableFirma.AddCell(cellCab);
    //        tableFirma.AddCell(cellEntrega);
    //        tableFirma.AddCell(cellRecibe);
    //        tableFirma.AddCell(cellAutorizado);
    //        tableFirma.AddCell(cellCab1);
    //        tableFirma.AddCell(cellEntrega1);
    //        tableFirma.AddCell(cellRecibe1);
    //        tableFirma.AddCell(cellAutorizado1);
    //        tableFirma.AddCell(cellCab2);
    //        tableFirma.AddCell(cellEntrega2);
    //        tableFirma.AddCell(cellRecibe2);
    //        tableFirma.AddCell(cellAutorizado2);
    //        tableFirma.AddCell(cellCab3);
    //        tableFirma.AddCell(cellEntrega3);
    //        tableFirma.AddCell(cellRecibe3);
    //        tableFirma.AddCell(cellAutorizado3);


    //        tableFirma.WidthPercentage = 80;

    //        document.Add(tableFirma);


    //        //esto es importante, pues si no cerramos el document entonces no se creara el pdf.
    //        document.Close();

    //        string filePath = Path;

    //        Session["pdfFileName"] = filePath;

    //        abreVentana("VisualizaPDF.aspx?pdf=yes");//envio pdf para abrirlo en nueva pestaña
    //    }
    //    catch (Exception ex)
    //    {
    //        errtrap = new ErrorTrapper();
    //        errtrap.SetOnError("Usuario:" + Membership.GetUser().UserName + "<< " + ex.Message, 0);
    //        messbox1.Mensaje = "Error. " + ex.Message;
    //        messbox1.Tipo = "E";
    //        messbox1.showMess();
    //    }     
    //}

    private void abreVentana(string ventana)
    {
        string funcion = "OpenWindows('" + ventana + "')";
        string f = "windowOpener('" + ventana + "')";
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "DICE", f, true);
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
}
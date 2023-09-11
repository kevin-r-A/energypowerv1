using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace CustomEditors
{
    public class Traslado
    {
        Datos.SqlService sql = new Datos.SqlService();

        public Traslado()
        {
        }

        public DataTable GetBajasPendientes()
        {
            return Logica.HELPER.GetPendientesTraslado(Membership.GetUser().ProviderUserKey.ToString());
        }
        public DataTable GetAllActivos(Guid guid)
        {
            return sql.ExecuteSqlDataTable("Select A.*, APT.ACTTRA_APROBADO from ACTIVOS_PARA_TRASLADO APT inner join ACTIVO A on A.ACT_ID = APT.ACT_ID where APT.ACTTRA_UUID='" + guid + "'");
        }

        public bool AprobarRechazarTraslados(int apractId, int i, int acttraId)
        {
            var procesado = Logica.HELPER.AprobarRechazarTraslados(apractId, i, acttraId);
            return procesado;
        }


        public void CreaPdf(Guid guid, HttpServerUtility Server, DataTable antiguosActivos,string fecha)
        {
            var nuevosActivos = GetAllActivos(guid);
            if (antiguosActivos.Rows.Count == 1)
            {
                var ubigeo = antiguosActivos.Rows[0]["UGE_ID1"] + ";" +
                             antiguosActivos.Rows[0]["UGE_ID2"] + ";" +
                             antiguosActivos.Rows[0]["UGE_ID3"] + ";" +
                             antiguosActivos.Rows[0]["UGE_ID4"];
                var ubiorg = antiguosActivos.Rows[0]["UOR_ID1"] + ";" +
                             antiguosActivos.Rows[0]["UOR_ID2"] + ";" +
                             antiguosActivos.Rows[0]["UOR_ID3"];
                F_CrearPdfIndividual(guid, Server, antiguosActivos.Rows[0]["CUS_ID1"].ToString(), nuevosActivos.Rows[0]["CUS_ID1"].ToString(),
                    int.Parse(antiguosActivos.Rows[0]["ACT_ID"].ToString()), ubiorg, ubigeo, "Acta Entrega TI - ",fecha);
            }
            else if (antiguosActivos.Rows.Count > 1)
            {
                List<string> actIds = new List<string>();
                List<string> cusIds = new List<string>();
                foreach (DataRow antiguosActivosRow in antiguosActivos.Rows)
                {
                    actIds.Add(antiguosActivosRow["ACT_ID"].ToString());
                    cusIds.Add(antiguosActivosRow["CUS_ID1"].ToString());
                }

                CrearPdfMasivo(guid, Server, 0, actIds.ToArray(), cusIds.ToArray(), nuevosActivos.Rows[0]["CUS_ID1"].ToString(),
                    nuevosActivos.Rows[0]["UOR_ID2"].ToString(), "Acta Entrega TM - ", nuevosActivos.Rows[0]["UGE_ID1"].ToString(), nuevosActivos.Rows[0]["UGE_ID2"].ToString(),
                    nuevosActivos.Rows[0]["UGE_ID3"].ToString(), nuevosActivos.Rows[0]["UOR_ID2"].ToString(), fecha);
            }
        }

        public void F_CrearPdfIndividual(Guid guid, HttpServerUtility Server, string cusini, string cusfin, int act, string ubiorg, string ubigeo, string nombre, string fecha)
        {
            try
            {
                int numPDF = F_TotalPDF(Server) + 1;
                string PDFnum = F_llenaceros(Convert.ToString(numPDF), 5, "0");

                string[] ubiOrg = ubiorg.Split(';');
                string[] ubiGeo = ubigeo.Split(';');

                Datos.SqlService sql = new Datos.SqlService();
                Object AreaActivos = Membership.GetUser().UserName.ToString();
                Object NuevoCus = sql.ExecuteSqlObject("select (cus_nombres +' '+ CUS_apellidos) from CUSTODIO where cus_id='" + cusfin + "'");
                Object AnteriorCus = sql.ExecuteSqlObject("select (cus_nombres +' '+ CUS_apellidos) from CUSTODIO where cus_id='" + cusini + "'");

                Object NuevoCusCC = sql.ExecuteSqlObject("select cus_cedula from CUSTODIO where cus_id='" + cusfin + "'");
                Object AnteriorCusCC = sql.ExecuteSqlObject("select  cus_cedula from CUSTODIO where cus_id='" + cusini + "'");
                String NuevoCi = "";

                if (NuevoCus != null)
                {
                    nombre += NuevoCus;
                }

                if (NuevoCusCC != null)
                {
                    NuevoCi = NuevoCusCC.ToString();
                }
                else
                {
                    NuevoCi = " ";
                }

                String AnteriorCi = "";

                if (AnteriorCusCC != null)
                {
                    AnteriorCi = AnteriorCusCC.ToString();
                }
                else
                {
                    AnteriorCi = " ";
                }

                Object Uorg1 = sql.ExecuteSqlObject("select uor_nombre from uorganica where uor_id='" + ubiOrg[0] + "'");
                Object Ugeo1 = sql.ExecuteSqlObject("select uge_nombre from ugeografica where uge_id='" + ubiGeo[0] + "'");
                Object Ugeo2 = sql.ExecuteSqlObject("select uge_nombre from ugeografica where uge_id='" + ubiGeo[1] + "'");
                Object Ugeo3 = sql.ExecuteSqlObject("select uge_nombre from ugeografica where uge_id='" + ubiGeo[2] + "'");
                string TituloReporte = ConfigurationManager.AppSettings["TituloReportes"].ToString();

                //descripcion
                Object descrip = sql.ExecuteSqlObject(
                    "select g3.gru_nombre AS DESCRIPCION from (ACTIVO left join GRUPO as g3 on activo.gru_id3= g3.gru_id) WHERE ACTIVO.ACT_ID='" + act + "'");

                Object campo1 = sql.ExecuteSqlObject("select ACT_CODBARRAS as CODIGO from ACTIVO WHERE ACTIVO.ACT_ID='" + act + "'");
                Object campo2 = sql.ExecuteSqlObject(
                    "select g1.gru_nombre AS SUBTIPO from (ACTIVO  left join GRUPO as g1 on activo.gru_id1= g1.gru_id) WHERE ACTIVO.ACT_ID='" + act + "'");
                Object campo3 = sql.ExecuteSqlObject(
                    "select g2.gru_nombre AS CLASE from (ACTIVO left join GRUPO as g2 on activo.gru_id2= g2.gru_id) WHERE ACTIVO.ACT_ID='" +
                    act + "'");
                Object campo4 = sql.ExecuteSqlObject(
                    "select DETALLE=stuff((select ', '+(SELECT CFA_NOMBRE FROM CFAMILIA CF WHERE CF.CFA_ID =  A.CFA_ID)+': '+A.CAR_VALOR+ISNULL(U.UNI_SIMBOLO,'') From (caracteristica A LEFT JOIN UNIDAD AS U ON A.UNI_ID= U.UNI_ID) where A.ACT_ID=ACTIVO.act_id for xml path('')),1,1,'') from ACTIVO  WHERE ACTIVO.ACT_ID='" +
                    act + "'");
                Object campo5 = sql.ExecuteSqlObject(
                    "select e.est_nombre AS ESTADO from (ACTIVO  left join estado as e on activo.est_id1=e.est_id) WHERE ACTIVO.ACT_ID='" +
                    act + "'");
                Object campo6 = sql.ExecuteSqlObject(
                    "select mar.mar_nombre AS MARCA  from (ACTIVO  left join marca as mar on activo.mar_id=mar.mar_id) WHERE ACTIVO.ACT_ID='" + act + "'");
                Object campo7 = sql.ExecuteSqlObject("select act_serie1 AS SERIE from (ACTIVO  left join marca as mar on activo.mar_id=mar.mar_id)WHERE ACTIVO.ACT_ID='" +
                                                     act + "'");
                Object campo8 = sql.ExecuteSqlObject(
                    "select mode.mod_nombre AS MODELO from (ACTIVO left join modelo as mode on activo.mod_id=mode.mod_id)WHERE ACTIVO.ACT_ID='" + act + "'");
                Object campo9 = sql.ExecuteSqlObject("select act_observaciones AS OBSERVACIONES from ACTIVO  WHERE ACTIVO.ACT_ID='" + act + "'");
                Object campo10 = sql.ExecuteSqlObject("select ACT_TIPO as TIPO_activo from ACTIVO WHERE ACTIVO.ACT_ID='" + act + "'");

                //EMPIEZA PDF

                //creamos el documento
                //...ahora configuramos para que el tamaño de hoja sea A4
                //Document document = new Document(iTextSharp.text.PageSize.A4);
                Document document = new Document(iTextSharp.text.PageSize.A4.Rotate(), 50, 30, 15, 5);
                document.PageSize.Rotate();

                //hacemos que se inserte la fecha de creación para el documento
                document.AddCreationDate();

                //...título
                document.AddTitle("ACTA DE TRASLADO DE LOS ACTIVOS FIJOS Y BIENES SUJETOS DE CONTROL");

                //... el asunto
                document.AddSubject("ACTA DE TRASLADO");


                //string Path = "c:/" + System.DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss") + "ACTA DE ENTREGA RECEPCIÓN.pdf";
                string Path = Server.MapPath("./PDF/") + nombre + " " + fecha + ".pdf";

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
                    FontFactory.GetFont(FontFactory.TIMES_ROMAN, 8, iTextSharp.text.Font.NORMAL));
                iTextSharp.text.Font myfont2 = new iTextSharp.text.Font(
                    FontFactory.GetFont(FontFactory.TIMES_ROMAN, 12, iTextSharp.text.Font.NORMAL));
                iTextSharp.text.Font myfont3 = new iTextSharp.text.Font(
                    FontFactory.GetFont(FontFactory.TIMES_ROMAN, 8, iTextSharp.text.Font.BOLD));

                //Agregar tabla a Pdf
                PdfPTable table = new PdfPTable(11);

                PdfPCell cell = new PdfPCell(new Phrase("Código de Barras", myfont3));
                PdfPCell cell9 = new PdfPCell(new Phrase("Tipo de Bien", myfont3));
                PdfPCell cell1 = new PdfPCell(new Phrase("Grupo/Cuenta", myfont3));
                PdfPCell cell2 = new PdfPCell(new Phrase("Subgrupo", myfont3));
                PdfPCell cellDESCRIP = new PdfPCell(new Phrase("Descripcion", myfont3));
                PdfPCell cell3 = new PdfPCell(new Phrase("Detalle", myfont3));
                PdfPCell cell4 = new PdfPCell(new Phrase("Estado", myfont3));
                PdfPCell cell5 = new PdfPCell(new Phrase("Marca", myfont3));
                PdfPCell cell6 = new PdfPCell(new Phrase("Serie", myfont3));
                PdfPCell cell7 = new PdfPCell(new Phrase("Modelo", myfont3));
                PdfPCell cell8 = new PdfPCell(new Phrase("Observaciones", myfont3));

                cell.Colspan = 1;

                cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right

                table.AddCell(cell);
                table.AddCell(cell9);
                table.AddCell(cell1);
                table.AddCell(cell2);
                table.AddCell(cellDESCRIP);
                table.AddCell(cell3);
                table.AddCell(cell4);
                table.AddCell(cell5);
                table.AddCell(cell6);
                table.AddCell(cell7);
                table.AddCell(cell8);
                table.AddCell(new Paragraph(campo1.ToString(), myfont));
                table.AddCell(new Paragraph(campo10.ToString(), myfont));
                table.AddCell(new Paragraph(campo2.ToString(), myfont));
                table.AddCell(new Paragraph(campo3.ToString(), myfont));
                table.AddCell(new Paragraph(descrip.ToString(), myfont));
                table.AddCell(new Paragraph(campo4.ToString(), myfont));
                table.AddCell(new Paragraph(campo5.ToString(), myfont));
                table.AddCell(new Paragraph(campo6.ToString(), myfont));
                table.AddCell(new Paragraph(campo7.ToString(), myfont));
                table.AddCell(new Paragraph(campo8.ToString(), myfont));
                table.AddCell(new Paragraph(campo9.ToString(), myfont));
                table.WidthPercentage = 100;

                //table.SetWidths(new Single[] { 100, 115, 80, 70, 90, 130, 70, 70, 70, 70, 180 });
                table.SetWidths(new Single[] { 100, 90, 80, 70, 90, 130, 70, 70, 70, 70, 180 });

                //agregar todo el paquete de texto

                string ServerPath;
                ServerPath = Server.MapPath("");
                string ruta = ServerPath + "\\Logo\\logo.png";


                iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(ruta);
                jpg.ScalePercent(35f); //tamaño de imagen en porcentaje
                jpg.Alignment = iTextSharp.text.Image.ALIGN_RIGHT;

                //document.Add(new Paragraph("\n"));

                Paragraph P = new Paragraph("ACTA DE TRASLADO DE LOS ACTIVOS FIJOS Y BIENES SUJETOS DE CONTROL Nº " + PDFnum + "\n", myfont2);
                P.Alignment = Element.ALIGN_CENTER;
                document.Add(jpg);
                document.Add(P);

                Paragraph PFederacion = new Paragraph(TituloReporte + "\n", myfont2);
                PFederacion.Alignment = Element.ALIGN_CENTER;
                document.Add(PFederacion);


                document.Add(new Paragraph("\n\n"));

                Paragraph P1 = new Paragraph(
                    "ACTA DE TRASLADO DE LOS ACTIVOS FIJOS Y BIENES DE CONTROL DE  LA  UNIDAD ADMINISTRATIVA;  ENTRE  EL(LA) SEÑOR(a)  " + AnteriorCus.ToString() +
                    "  Y  SEÑOR(a) " + NuevoCus.ToString() + ",  CUSTODIOS QUIENES  ENTREGAN Y RECEPTAN  LOS ACTIVOS RESPECTIVAMENTE, AL " +
                    System.DateTime.Now.ToString("dd-MM-yyyy") + "\n\n ", myfont);
                P1.Alignment = Element.ALIGN_JUSTIFIED;
                document.Add(P1);

                Paragraph P2 = new Paragraph(
                    "En la ciudad de " + Ugeo2.ToString() + " ,los suscritos señor(a)  " + AnteriorCus.ToString() + ",  quien entrega los bienes,  señor(a)  " +
                    NuevoCus.ToString() + "  quien  recibe los bienes, nos constituimos en las oficinas administrativas de " + Uorg1.ToString() + ", ubicada en " +
                    Ugeo1.ToString() + "/" + Ugeo2.ToString() + "/" + Ugeo3.ToString() +
                    " (ubicación actual del bien),  con el objeto de realizar la diligencia de entrega – recepción  correspondiente. Al efecto con la presencia de las personas mencionadas anteriormente se procede con la constatación física y entrega-recepción de los activos fijos y bienes sujetos de control administrativo, de acuerdo al siguiente detalle: \n\n ",
                    myfont);
                P2.Alignment = Element.ALIGN_JUSTIFIED;
                document.Add(P2);

                document.Add(table);
                document.Add(new Paragraph("\n"));


                Paragraph P41 = new Paragraph(
                    "Se deja constancia que el custodio quien recepta el bien señor(a) " + NuevoCus.ToString() +
                    ",  se encargará de velar por  el buen uso,  conservación, administración,  utilización , así como que las condiciones sean adecuadas y no se encuentren en riesgo de deterioro de los bienes antes mencionados  y  confiados a su guarda, de acuerdo con lo que estipula el manual de activos fijos referente al control y administración. \n\n",
                    myfont);
                P41.Alignment = Element.ALIGN_JUSTIFIED;
                document.Add(P41);

                Paragraph P5 = new Paragraph(
                    "En consecuencia, por la demostración que antecede y de conformidad  el  señor(a) " + AnteriorCus.ToString() +
                    ", entrega a satisfacción al señor(a) " +
                    NuevoCus.ToString() + ", quien recibe a satisfacción los activos fijos y bienes sujetos de control administrativo.  ", myfont);
                P5.Alignment = Element.ALIGN_JUSTIFIED;
                document.Add(P5);

                Paragraph P6 = new Paragraph(
                    "Para Constancia de lo actuado y en fe de conformidad y aceptación, suscriben  la presente acta entrega-recepción en  3  ejemplares de igual tenor y efecto las personas que intervienen en esta diligencia. ",
                    myfont);
                P6.Alignment = Element.ALIGN_JUSTIFIED;
                document.Add(P6);

                document.Add(new Paragraph("\n\n"));
                document.Add(new Paragraph("\n\n"));

                //Tabla para poner firmas
                PdfPTable tableFirma = new PdfPTable(3);

                PdfPCell cellEntrega = new PdfPCell(new Phrase(AnteriorCus.ToString(), myfont));
                PdfPCell cellRecibe = new PdfPCell(new Phrase(NuevoCus.ToString(), myfont));
                PdfPCell cellAutorizado = new PdfPCell(new Phrase(AreaActivos.ToString(), myfont));
                PdfPCell cellEntrega1 = new PdfPCell(new Phrase("", myfont));
                PdfPCell cellRecibe1 = new PdfPCell(new Phrase("", myfont));
                PdfPCell cellAutorizado1 = new PdfPCell(new Phrase("", myfont));
                PdfPCell cellEntrega2 = new PdfPCell(new Phrase("ENTREGUÉ CONFORME", myfont));
                PdfPCell cellRecibe2 = new PdfPCell(new Phrase("RECIBÍ CONFORME ", myfont));
                PdfPCell cellAutorizado2 = new PdfPCell(new Phrase("CONTROL DE ACTIVOS FIJOS ", myfont));


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
        

            }
            catch (Exception ex)
            {
            }
        }
        private void CrearPdfMasivo(Guid guid, HttpServerUtility Server, int contadort, string[] actId, string[] custodio, string newCus, string NuevaCiu, string nombre,
            string uge1, string uge2, string uge3, string uor2, string fecha)
        {
            try
            {
                int numPDF = F_TotalPDF(Server) + 1;
                string PDFnum = F_llenaceros(Convert.ToString(numPDF), 5, "0");

                //2012-02-15_Andrea.- Llamar para crear PDF

                Datos.SqlService sql1 = new Datos.SqlService();
                Object AreaActivos = Membership.GetUser().UserName.ToString();
                Object NuevoCus = sql1.ExecuteSqlObject("select (cus_nombres +' '+ CUS_apellidos) from CUSTODIO where cus_id='" + newCus + "'");
                Object NewCiu = sql1.ExecuteSqlObject("select uge_nombre from ugeografica where uge_id='" + NuevaCiu + "'");
                Object ddUge11 = sql1.ExecuteSqlObject("select uge_nombre from ugeografica where uge_id='" + uge1 + "'");
                Object ddUge22 = sql1.ExecuteSqlObject("select uge_nombre from ugeografica where uge_id='" + uge2 + "'");
                Object ddUge33 = sql1.ExecuteSqlObject("select uge_nombre from ugeografica where uge_id='" + uge3 + "'");
                Object ddUor22 = sql1.ExecuteSqlObject("select UOR_NOMBRE from UORGANICA where uge_id='" + uor2 + "'");
                string TituloReporte = ConfigurationManager.AppSettings["TituloReportes"].ToString();

                if (NuevoCus != null)
                {
                    nombre += NuevoCus.ToString();
                }
                //EMPIEZA PDF

                //creamos el documento
                //...ahora configuramos para que el tamaño de hoja sea A4
                //Document document = new Document(iTextSharp.text.PageSize.A4);
                Document document = new Document(iTextSharp.text.PageSize.A4.Rotate(), 40, 30, 15, 5);
                document.PageSize.Rotate();

                //hacemos que se inserte la fecha de creación para el documento
                document.AddCreationDate();

                //...título
                document.AddTitle("ACTA DE ENTREGA RECEPCIÓN POR TRANSFERENCIA MASIVA");

                //... el asunto
                document.AddSubject("ACTA DE ENTREGA RECEPCIÓN");

                //string Path = "c:/" + System.DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss") + "ACTA DE ENTREGA RECEPCIÓN TRANSFERENCIA MASIVA.pdf";
                string Path = Server.MapPath("./PDF/") + nombre + " " +fecha + ".pdf";

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
                    FontFactory.GetFont(FontFactory.TIMES_ROMAN, 8, iTextSharp.text.Font.NORMAL));
                iTextSharp.text.Font myfont2 = new iTextSharp.text.Font(
                    FontFactory.GetFont(FontFactory.TIMES_ROMAN, 12, iTextSharp.text.Font.NORMAL));
                iTextSharp.text.Font myfont3 = new iTextSharp.text.Font(
                    FontFactory.GetFont(FontFactory.TIMES_ROMAN, 8, iTextSharp.text.Font.BOLD));

                //agregar todo el paquete de texto


                string ServerPath;
                ServerPath = Server.MapPath("");
                string ruta = ServerPath + "\\Logo\\logo.png";


                string Anterior_Cus = null;

                foreach (var s in custodio)
                {
                    if (Anterior_Cus == null)
                    {
                        Anterior_Cus = s;
                    }

                    if (Anterior_Cus != s)
                    {
                        Anterior_Cus = "";
                    }
                }

                if (Anterior_Cus == "")
                {
                    Anterior_Cus = "SIN CUSTODIO";
                }
                else
                {
                    Anterior_Cus = sql1.ExecuteSqlObject("select (cus_nombres +' '+ CUS_apellidos) from CUSTODIO where cus_id='" + Anterior_Cus + "'").ToString();
                }


                iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(ruta);
                jpg.ScalePercent(35f); //tamaño de imagen en porcentaje
                jpg.Alignment = iTextSharp.text.Image.ALIGN_RIGHT;

                Paragraph P = new Paragraph("ACTA DE TRASLADO DE LOS ACTIVOS FIJOS Y BIENES SUJETOS DE CONTROL Nº " + PDFnum + "\n", myfont2);
                P.Alignment = Element.ALIGN_CENTER;
                document.Add(jpg);
                document.Add(P);


                Paragraph PFederacion = new Paragraph(TituloReporte + "\n", myfont2);
                PFederacion.Alignment = Element.ALIGN_CENTER;
                document.Add(PFederacion);

                document.Add(new Paragraph("\n"));
                Paragraph P4 = new Paragraph(
                    "ACTA DE ENTREGA-RECEPCION DE LOS ACTIVOS FIJOS Y BIENES DE CONTROL DE  LA  UNIDAD ADMINISTRATIVA;  ENTRE EL SEÑOR(a) " + Anterior_Cus +
                    " Y EL SEÑOR(a) " + NuevoCus.ToString() + ", CUSTODIOS QUIENES  ENTREGAN Y RECEPTAN  LOS ACTIVOS RESPECTIVAMENTE " +
                    System.DateTime.Now.ToString("dd-MM-yyyy") + "\n\n ", myfont);
                P4.Alignment = Element.ALIGN_JUSTIFIED;
                document.Add(P4);

                Paragraph P5 = new Paragraph(
                    "En la ciudad de " + NewCiu.ToString() + ", los suscritos señor(a) " + Anterior_Cus + " , quien entrega los bien(es), al(la) señor(a) " +
                    NuevoCus.ToString() + "  quien  recibe los bien(es), nos constituimos en las oficinas administrativas de " + ddUor22 +
                    ", ubicada en " +
                    ddUge11 + "/" + ddUge22 + "/" + ddUge33 +
                    " (ubicación actual del(los) bien(es)),  con el objeto de realizar la diligencia de entrega – recepción  correspondiente. Al efecto con la presencia de las personas mencionadas anteriormente se procede con la constatación física y entrega-recepción de los activos fijos y bienes sujetos de control administrativo, de acuerdo al siguiente detalle: \n\n ",
                    myfont);
                P5.Alignment = Element.ALIGN_JUSTIFIED;
                document.Add(P5);


                //Agregar tabla a Pdf
                PdfPTable table = new PdfPTable(12);
                PdfPCell cell = new PdfPCell(new Phrase("Código de Barras", myfont3));
                PdfPCell celllogikard = new PdfPCell(new Phrase("Tipo de Bien", myfont3));
                PdfPCell cell1 = new PdfPCell(new Phrase("Grupo/Cuenta", myfont3));
                PdfPCell cell2 = new PdfPCell(new Phrase("Subgrupo", myfont3));
                PdfPCell cellDESCRIP = new PdfPCell(new Phrase("Descripción", myfont3));
                PdfPCell cell3 = new PdfPCell(new Phrase("Detalle", myfont3));
                PdfPCell cell4 = new PdfPCell(new Phrase("Estado", myfont3));
                PdfPCell cell5 = new PdfPCell(new Phrase("Marca", myfont3));
                PdfPCell cell6 = new PdfPCell(new Phrase("Serie", myfont3));
                PdfPCell cell7 = new PdfPCell(new Phrase("Modelo", myfont3));
                PdfPCell cell8 = new PdfPCell(new Phrase("Observaciones", myfont3));
                PdfPCell cell9 = new PdfPCell(new Phrase("Custodio Anterior", myfont3));
                cell8.Colspan = 1;
                cell.Colspan = 1;

                cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right

                table.AddCell(cell);
                table.AddCell(celllogikard);
                table.AddCell(cell1);
                table.AddCell(cell2);
                table.AddCell(cellDESCRIP);
                table.AddCell(cell3);
                table.AddCell(cell4);
                table.AddCell(cell5);
                table.AddCell(cell6);
                table.AddCell(cell7);
                table.AddCell(cell8);
                table.AddCell(cell9);
                table.SetWidths(new Single[] { 120, 120, 90, 130, 130, 130, 70, 70, 70, 70, 120, 120 });
                //Creamos un dataTable que guarde información sobre los activos trasladados
                DataTable Tabla = new DataTable();

                for (int i = 0; i <= actId.Length - 1; i++)
                {
                    int act_Id = int.Parse(actId[i]);

                    Datos.SqlService sql = new Datos.SqlService();
                    sql.AddParameter("@actid", SqlDbType.Int, act_Id);

                    Tabla = sql.ExecuteSPDataTable("usp_getDatosPdf");
                    for (int j = 0; j < 11; j++)
                    {
                        table.AddCell(new Paragraph(Tabla.Rows[0][j].ToString(), myfont));
                    }

                    table.AddCell(new Paragraph(custodio[i].ToString(), myfont));
                }

                table.WidthPercentage = 100;
                document.Add(table);


                document.Add(new Paragraph("\n"));
                Paragraph P41 = new Paragraph(
                    "Se deja constancia que el custodio quien recepta el bien señor(a) " + NuevoCus.ToString() +
                    ",  se encargará de velar por  el buen uso,  conservación, administración,  utilización , así como que las condiciones sean adecuadas y no se encuentren en riesgo de deterioro de los bienes antes mencionados y confiados a su guarda, de acuerdo con lo que estipula el manual de activos fijos referente al control y administración. \n\n",
                    myfont);
                P41.Alignment = Element.ALIGN_JUSTIFIED;
                document.Add(P41);

                Paragraph P2 = new Paragraph(
                    "En consecuencia, por la demostración que antecede y de conformidad el señor(a) " + Anterior_Cus + ", entrega a satisfacción al señor(a) " +
                    NuevoCus.ToString() + ", quien recibe a satisfacción los activos fijos y bienes sujetos de control administrativo.", myfont);
                P2.Alignment = Element.ALIGN_JUSTIFIED;
                document.Add(P2);

                Paragraph P3 = new Paragraph(
                    "Para constancia de lo actuado y en fe de conformidad y aceptación, suscriben la presente acta de entrega – recepción en 3 ejemplares de igual tenor y efecto las personas que intervienen en esta diligencia.",
                    myfont);
                P3.Alignment = Element.ALIGN_JUSTIFIED;
                document.Add(P3);

                document.Add(new Paragraph("\n\n"));

                //Tabla para poner firmas

                PdfPTable tableFirma = new PdfPTable(3);

                //string AnteriorCus1 = ddCustodio.SelectedItem.Text.ToString();

                PdfPCell cellEntrega = new PdfPCell(new Phrase(Anterior_Cus.ToString(), myfont));
                PdfPCell cellRecibe = new PdfPCell(new Phrase(NuevoCus.ToString(), myfont));
                PdfPCell cellAutorizado = new PdfPCell(new Phrase(AreaActivos.ToString(), myfont));
                PdfPCell cellEntrega1 = new PdfPCell(new Phrase("".ToString(), myfont));
                PdfPCell cellRecibe1 = new PdfPCell(new Phrase("".ToString(), myfont));
                PdfPCell cellAutorizado1 = new PdfPCell(new Phrase("", myfont));
                PdfPCell cellEntrega2 = new PdfPCell(new Phrase("ENTREGUÉ CONFORME", myfont));
                PdfPCell cellRecibe2 = new PdfPCell(new Phrase("RECIBÍ CONFORME ", myfont));
                PdfPCell cellAutorizado2 = new PdfPCell(new Phrase("CONTROL DE ACTIVOS FIJOS", myfont));

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

 
            }
            catch (Exception ex)
            {
            }

        }
        public int F_TotalPDF(HttpServerUtility Server)
        {
            string folderToBrowse = Server.MapPath("./PDF/");
            DirectoryInfo DirInfo = new DirectoryInfo(folderToBrowse);
            FileSystemInfo[] files = DirInfo.GetFileSystemInfos("*.PDF");
            Array.Sort<FileSystemInfo>(files, delegate (FileSystemInfo a, FileSystemInfo b) { return a.LastWriteTime.CompareTo(b.LastWriteTime); });

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
     
    }
}
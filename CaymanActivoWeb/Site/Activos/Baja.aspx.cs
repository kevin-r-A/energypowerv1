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
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.codec.wmf;
using Logica;
using System.Web.Services.Description;

public partial class Baja : System.Web.UI.Page
{
    ErrorTrapper errtrap;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = ConfigurationManager.AppSettings["Titulo"] + " Baja de Items";
        ibsave.Attributes.Add("onmouseout", "this.src='../../Img/s1.png'");
        ibsave.Attributes.Add("onmouseover", "this.src='../../Img/s2.png'");
        ibcancel.Attributes.Add("onmouseout", "this.src='../../Img/c1.png'");
        ibcancel.Attributes.Add("onmouseover", "this.src='../../Img/c2.png'");


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
            //Unit u = new Unit(Convert.ToDouble(ConfigurationManager.AppSettings["Rgalto3"]), UnitType.Pixel);
            //rgactivos.Height = u;

            panGrid.Visible = false;

            System.Web.HttpBrowserCapabilities navegador = Request.Browser;

            string nombre = navegador.Browser;



            if (nombre != "Chrome")
            {
                //Session["mensaje"] = "No se puede Generar baja en Navegador: " + nombre + ", Por favor intentelo con Google Chrome";
                //Response.Redirect("~/Site/Principal.aspx?msgPag=" + Session["mensaje"]);
            }

            Session["guardoImgBaja"] = "";
        }

        System.Web.HttpBrowserCapabilities navegador1 = Request.Browser;

        string nombre1 = navegador1.Browser;

        if (nombre1 != "Chrome")
        {
            //Session["mensaje"] = "No se puede Generar baja en Navegador: " + nombre1 + ", Por favor intentelo con Google Chrome";
            //Response.Redirect("~/Site/Principal.aspx?msgPag=" + Session["mensaje"]);
        }
    }
    private bool codigoCorrecto()
    {
        try
        {
            string codbar = "";

            if (txtbuscb.Text.Trim().Length < int.Parse(Session["emtd"].ToString()))
            {
                codbar = Session["empr"].ToString() + completarCodigo(txtbuscb.Text.Trim());
            }
            else if (txtbuscb.Text.Trim().Length == int.Parse(Session["emtd"].ToString()))
            {
                codbar = txtbuscb.Text.Trim();
            }
            else
            {
                return false;
            }

            if (Logica.HELPER.codigoValido(codbar))
            {
                txtbuscb.Text = codbar;
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            errtrap = new ErrorTrapper();
            errtrap.SetOnError("Usuario:" + Membership.GetUser().UserName + "<< " + ex.Message, 0);
            messbox1.Mensaje = "Error. " + ex.Message;
            messbox1.Tipo = "E";
            messbox1.showMess();
            return false;
        }
    }

    public string completarCodigo(string codbar)
    {
        try
        {
            //ceros es el numero de digitos disponibles para activos
            int ceros = 0;
            ceros = int.Parse(Session["emtd"].ToString()) - Session["empr"].ToString().Length;
            for (int i = codbar.Length; i < ceros; i++)
                codbar = "0" + codbar;
            return codbar;
        }
        catch (Exception ex)
        {
            errtrap = new ErrorTrapper();
            errtrap.SetOnError("Usuario:" + Membership.GetUser().UserName + "<< " + ex.Message, 0);
            messbox1.Mensaje = "Error. " + ex.Message;
            messbox1.Tipo = "E";
            messbox1.showMess();
            return "";
        }
    }


    protected void ibbus1_Click(object sender, ImageClickEventArgs e)
    {
        rghijos.DataSource = null;
        rghijos.DataBind();
        panhijos.Visible = false;

        try
        {
            txtbusid.Text = "";
            if (codigoCorrecto())
            {
                if (Logica.HELPER.comprobarCbIngresado(txtbuscb.Text))
                {
                    if (!Logica.HELPER.itemDadoDeBajaCb(txtbuscb.Text.Trim()))
                    {
                        if (Logica.Mantenimiento.verificaMantenimiento(txtbuscb.Text.Trim()))
                        {
                            panGrid.Visible = false;
                            messbox1.Mensaje = "El Activo actualmente esta en Mantenimiento, no se puede Dar de Baja, comuniquese con el Administrador...!!!";
                            messbox1.Tipo = "W";
                            messbox1.showMess();
                        }
                        else
                        {
                            //cargar datos
                            panGrid.Visible = true;
                            cargarActivo(txtbuscb.Text, "cb");
                        }


                        ////cargar datos
                        //panGrid.Visible = true;
                        //cargarActivo(txtbuscb.Text, "cb");
                    }
                    else
                    {
                        messbox1.Mensaje = "El item con Código de Barras = " + txtbuscb.Text.Trim() + " ya fue dado de baja anterioremente...";
                        messbox1.Tipo = "I";
                        messbox1.showMess();
                        rgbaja.DataSource = null;
                        rgbaja.DataBind();
                    }

                }
                else
                {
                    panGrid.Visible = false;
                    messbox1.Mensaje = "Código Válido, pero aún no ha sido ingresado!";
                    messbox1.Tipo = "I";
                    messbox1.showMess();
                    rgbaja.DataSource = null;
                    rgbaja.DataBind();
                }
            }
            else
            {
                messbox1.Mensaje = "El Código de Barras No Válido!";
                messbox1.Tipo = "W";
                messbox1.showMess();
                rgbaja.DataSource = null;
                rgbaja.DataBind();
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

    public void cargarActivo(string cod, string tipo)
    {
        try
        {
            string query = "";
            if (tipo == "cb")
                query = " and act_codbarras='" + cod + "'";
            else
                query = " and act_codigo1='" + cod + "'";

            rgbaja.DataSource = Logica.HELPER.getReporteTotalX(query);
            rgbaja.DataBind();
            //uprepo1.Update();
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
    public void cargarHijos(string id)
    {
        try
        {
            rghijos.DataSource = Logica.HELPER.getReporteTotalX(" and act_codbarraspadre in (select act_codbarras from activo where act_id=" + id + ")");
            rghijos.DataBind();
            //uprepo1.Update();
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
    protected void ibbus3_Click(object sender, ImageClickEventArgs e)
    {
        rghijos.DataSource = null;
        rghijos.DataBind();
        panhijos.Visible = false;

        try
        {
            txtbuscb.Text = "";


            //if (Logica.HELPER.comprobarIdIngresado(txtbusid.Text.Trim()))
            //{
            if (!Logica.HELPER.itemDadoDeBajaBNF(txtbusid.Text.Trim()))
            {
                if (Logica.Mantenimiento.verificaMantenimientoCodigoBNF(txtbusid.Text.Trim()))
                {
                    panGrid.Visible = false;
                    messbox1.Mensaje = "El Activo actualmente esta en Mantenimiento, no se puede realizar ningun cambio, comuniquese con el Administrador...!!!";
                    messbox1.Tipo = "W";
                    messbox1.showMess();
                }
                else
                {
                    //cargar datos
                    panGrid.Visible = true;
                    cargarActivo(txtbusid.Text, "cs");
                }
            }
            else
            {
                messbox1.Mensaje = "El item con Código = " + txtbusid.Text.Trim() + " ya fue dado de baja anterioremente...";
                messbox1.Tipo = "I";
                messbox1.showMess();
            }

            //}
            //else
            //{
            //    pantras.Visible = false;
            //    messbox1.Mensaje = "No se encontró ningún item con Id = " + txtbusid.Text.Trim();
            //    messbox1.Tipo = "I";
            //    messbox1.showMess();
            //    rgbaja.DataSource = null;
            //    rgbaja.DataBind();
            //}
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
    protected void rgbaja_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex >= 0)
        {
            ImageButton ib = (ImageButton)e.Row.Cells[0].FindControl("ibbaja");
            ib.Attributes.Add("onmouseout", "this.src='../../Img/baj1.png'");
            ib.Attributes.Add("onmouseover", "this.src='../../Img/baj2.png'");

        }
    }
    protected void ibbaja_Click(object sender, ImageClickEventArgs e)
    {
        rghijos.DataSource = null;
        rghijos.DataBind();
        panhijos.Visible = false;

        ImageButton ib = sender as ImageButton;
        GridViewRow row = (GridViewRow)ib.NamingContainer;

        int index = row.RowIndex;

        //rgbaja.SelectedIndex = index;

        Boolean valido = true;

        Session["_codbarras"] = row.Cells[4].Text.Trim();
        //chequear depreciaciones generadas al dia
        if (row.Cells[2].Text.ToUpper() == "ACTIVO FIJO" || row.Cells[2].Text.ToUpper() == "Activo Fijo")
        {
            //Si los activos se someten a depreciacion antes de procesar la baja
            if (ConfigurationManager.AppSettings["BajaDepre"] == "SI")
            {
                if (getMesesDepreBaja(row.Cells[1].Text))
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
                Logica.ACTIVO activo = new Logica.ACTIVO(int.Parse(row.Cells[1].Text));
                cddTipoBaja.SelectedValue = "";
                txtobsbaja.Text = "";
                //si no tiene hijos procesar la baja
                lblid.Text = row.Cells[1].Text;
                lbltipo.Text = row.Cells[2].Text;
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
                cargarHijos(row.Cells[1].Text);
                messbox1.Mensaje = "No puede darlo de baja ya que es un item padre, primero debe dar de baja todos los items hijos de este activo.";
                messbox1.Tipo = "W";
                messbox1.showMess();
                panhijos.Visible = true;
            }
        }
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
            errtrap = new ErrorTrapper();
            errtrap.SetOnError("Usuario:" + Membership.GetUser().UserName + "<< " + ex.Message, 0);
            messbox1.Mensaje = "Error: " + ex.Message;
            messbox1.Tipo = "E";
            messbox1.showMess();
            return false;
        }
    }
    protected void ibcancel_Click(object sender, ImageClickEventArgs e)
    {
        mp2.Hide();

        if (Session["guardoImgBaja"].ToString() == "S")
        {

            if (System.IO.File.Exists(Session["rutaImgBaja"].ToString()))
            {
                try
                {
                    System.IO.File.Delete(Session["rutaImgBaja"].ToString());
                }
                catch (System.IO.IOException ioex)
                {
                    messbox1.Mensaje = "Error: " + ioex.Message + "\n" + "No se pudo eliminar Archivo Adjunto en Directorio: " + Session["ruta_archivo"].ToString() + ", comuniquese con Administrador....!!!";
                    messbox1.Tipo = "W";
                    messbox1.showMess();
                }
            }
        }

        upbaja.Update();

    }
    protected void ibsave_Click(object sender, ImageClickEventArgs e)
    {
        BajaDepre objBaja = new BajaDepre();
        try
        {
            int id = int.Parse(lblid.Text);
            int bajaok = 0;
            //doy de baja el item
            Guid guid = Guid.NewGuid();
            bool result = objBaja.insBaja(int.Parse(lblid.Text), lbltipo.Text, Membership.GetUser().UserName, int.Parse(ddTipoBaja.SelectedValue), txtobsbaja.Text.Trim().ToUpper(), guid);


            string mensaje = "Item registrado con éxito.";

            if (FileUpload1.HasFile)
            {
                try
                {
                    string path = Server.MapPath("~/Site/Activos/adjuntos_baja/") + Session["_codbarras"].ToString() + "_" + FileUpload1.FileName;
                    string nombreok = "~/Site/Activos/adjuntos_baja/" + Session["_codbarras"].ToString() + "_" + FileUpload1.FileName;

                    FileUpload1.SaveAs(Server.MapPath(nombreok));
                }
                catch (System.Exception ex)
                {
                    mensaje += " , </br> Documento no fue cargado: " + ex.Message;
                }
            }
            if (result)
            {
                Logica.ACTIVO activo = Logica.ACTIVO.GetACTIVO(id);
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
                //objBaja.calcularFechaIniDepre(System.DateTime.Now);

                mensaje += " Item dado de Baja con éxito";

                mp2.Hide();
                messbox1.Mensaje = mensaje;
                messbox1.Tipo = "S";
                messbox1.showMess();

                rghijos.DataSource = null;
                rghijos.DataBind();
                panhijos.Visible = false;

                rgbaja.DataSource = null;
                rgbaja.DataBind();


                //pantras.Visible = false;

                Session["motivobaja"] = ddTipoBaja.SelectedItem.ToString();
                Session["motivobajadesc"] = txtobsbaja.Text;
                N_PDF(id);
                //F_CrearPdf(id);
                //uprepo1.Update();
            }


            //else
            //{
            //    messbox1.Mensaje = "No se pudo realizar la Baja";
            //    messbox1.Tipo = "E";
            //    messbox1.showMess();
            //}
        }
        catch (Exception ex)
        {
            mp2.Hide();
            errtrap = new ErrorTrapper();
            errtrap.SetOnError("Usuario:" + Membership.GetUser().UserName + "<< " + ex.Message, 0);
            messbox1.Mensaje = "Error: " + ex.Message;
            messbox1.Tipo = "E";
            messbox1.showMess();
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

    private void F_CrearPdf(int id)
    {
        try
        {

            ACTIVO ACT = new ACTIVO();
            using (C5ALIANZAVALLE23102015Entities ent = new C5ALIANZAVALLE23102015Entities())
            {
                ent.Configuration.ProxyCreationEnabled = true;
                ACT = ent.ACTIVO.Where(x => x.ACT_ID == id).FirstOrDefault();
                Datos.SqlService sql = new Datos.SqlService();
                Object descrip = sql.ExecuteSqlObject(
              "select g3.gru_nombre AS DESCRIPCION from (ACTIVO left join GRUPO as g3 on activo.gru_id3= g3.gru_id) WHERE ACTIVO.ACT_ID='" + id + "'");

                Object codigoBarras = sql.ExecuteSqlObject("select ACT_CODBARRAS as CODIGO from ACTIVO WHERE ACTIVO.ACT_ID='" + id + "'");
                Object grupo = sql.ExecuteSqlObject(
                    "select g1.gru_nombre AS SUBTIPO from (ACTIVO  left join GRUPO as g1 on activo.gru_id1= g1.gru_id) WHERE ACTIVO.ACT_ID='" + id + "'");
                Object subGrupo = sql.ExecuteSqlObject("select g2.gru_nombre AS CLASE from (ACTIVO left join GRUPO as g2 on activo.gru_id2= g2.gru_id) WHERE ACTIVO.ACT_ID='" +
                                                     id + "'");
                Object detalle = sql.ExecuteSqlObject(
                    "select DETALLE=stuff((select ', '+(SELECT CFA_NOMBRE FROM CFAMILIA CF WHERE CF.CFA_ID =  A.CFA_ID)+': '+A.CAR_VALOR+ISNULL(U.UNI_SIMBOLO,'') From (caracteristica A LEFT JOIN UNIDAD AS U ON A.UNI_ID= U.UNI_ID) where A.ACT_ID=ACTIVO.act_id for xml path('')),1,1,'') from ACTIVO  WHERE ACTIVO.ACT_ID='" +
                    id + "'");
                Object estado = sql.ExecuteSqlObject("select e.est_nombre AS ESTADO from (ACTIVO  left join estado as e on activo.est_id1=e.est_id) WHERE ACTIVO.ACT_ID='" +
                                                     id + "'");
                Object marca = sql.ExecuteSqlObject(
                    "select mar.mar_nombre AS MARCA  from (ACTIVO  left join marca as mar on activo.mar_id=mar.mar_id) WHERE ACTIVO.ACT_ID='" + id + "'");
                Object serie = sql.ExecuteSqlObject("select act_serie1 AS SERIE from (ACTIVO  left join marca as mar on activo.mar_id=mar.mar_id)WHERE ACTIVO.ACT_ID='" +
                                                     id + "'");
                Object modelo = sql.ExecuteSqlObject(
                    "select mode.mod_nombre AS MODELO from (ACTIVO left join modelo as mode on activo.mod_id=mode.mod_id)WHERE ACTIVO.ACT_ID='" + id + "'");
                Object observaciones = sql.ExecuteSqlObject("select act_observaciones AS OBSERVACIONES from ACTIVO  WHERE ACTIVO.ACT_ID='" + id + "'");
                Object tipoActivo = sql.ExecuteSqlObject("select ACT_TIPO as TIPO_activo from ACTIVO WHERE ACTIVO.ACT_ID='" + id + "'");
                object fechacompra = sql.ExecuteSqlObject("select act_fechacompra from activo where act_id=" + id);
                Object color = sql.ExecuteSqlObject(
                    "select isnull(col.col_nombre,'Sin Color') AS COLOR from (ACTIVO  left join COLOR as col on activo.col_id=col.col_id) WHERE ACTIVO.ACT_ID='" + id + "'");
                //EMPIEZA PDF

                //creamos el documento
                //...ahora configuramos para que el tamaño de hoja sea A4
                //Document document = new Document(iTextSharp.text.PageSize.A4);
                Document document = new Document(new RectangleReadOnly(842f, 595f), 50, 30, 15, 5);
                //document.PageSize.Rotate();

                //hacemos que se inserte la fecha de creación para el documento
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

                iTextSharp.text.Font myfontTabla = new iTextSharp.text.Font(
                FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.NORMAL));
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
                Chunk lblMotivoBajaval = new Chunk(ddTipoBaja.SelectedItem.Text.Trim(), myfontLabelNormal);

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
                tblDatos.SetWidths(new Single[] { 50, 80, 100 });
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
                tblDatos1.SetWidths(new Single[] { 50, 80, 100 });
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
                //Chunk lblProveedorval = new Chunk(ACT.PROVEEDOR!=null?ACT.PROVEEDOR.PRO_NOMBRE:"(Sin Proveedor)", myfontLabelNormal);

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
                tblDatos2.SetWidths(new Single[] { 50, 80, 100 });
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
                tblDatos3.SetWidths(new Single[] { 50, 80, 100 });
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
                Chunk lblObservacionesBajaval = new Chunk(txtobsbaja.Text, myfontLabelNormal);
                Phrase pol7 = new Phrase();
                pol7.Add(lblObservacionesBaja);
                pol7.Add(lblObservacionesBajaval);
                tblobservaciones.AddCell(pol7);

                tblobservaciones.WidthPercentage = 100;
                tblobservaciones.SetWidths(new Single[] { 100 });
                document.Add(tblobservaciones);

                document.Add(new Paragraph("\n"));
                //Agregar tabla a Pdf
                PdfPTable table = new PdfPTable(14);

                PdfPCell cell = new PdfPCell(new Phrase("Numero Factura", myfont3));
                PdfPCell cell1 = new PdfPCell(new Phrase("Valor Compra", myfont3));
                PdfPCell cell2 = new PdfPCell(new Phrase("Código de Barras", myfont3));
                PdfPCell cell3 = new PdfPCell(new Phrase("Tipo de Bien", myfont3));
                PdfPCell cell4 = new PdfPCell(new Phrase("Grupo/Cuenta", myfont3));
                PdfPCell cell5 = new PdfPCell(new Phrase("Subgrupo", myfont3));
                PdfPCell cell6 = new PdfPCell(new Phrase("Descripcion", myfont3));
                PdfPCell cell7 = new PdfPCell(new Phrase("Detalle", myfont3));
                PdfPCell cell8 = new PdfPCell(new Phrase("Estado", myfont3));
                PdfPCell cell9 = new PdfPCell(new Phrase("Marca", myfont3));
                PdfPCell cell10 = new PdfPCell(new Phrase("Serie", myfont3));
                PdfPCell cell11 = new PdfPCell(new Phrase("Modelo", myfont3));
                PdfPCell cell12 = new PdfPCell(new Phrase("Observaciones", myfont3));
                PdfPCell cell13 = new PdfPCell(new Phrase("Valor Compra", myfont3));
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
                table.AddCell(new Paragraph("1", myfontTabla));
                table.AddCell(new Paragraph(codigoBarras.ToString(), myfontTabla));
                table.AddCell(new Paragraph(codigoBarras.ToString(), myfontTabla));
                table.AddCell(new Paragraph(codigoBarras.ToString(), myfontTabla));
                table.AddCell(new Paragraph(tipoActivo.ToString(), myfontTabla));
                table.AddCell(new Paragraph(grupo.ToString(), myfontTabla));
                table.AddCell(new Paragraph(subGrupo.ToString(), myfontTabla));
                table.AddCell(new Paragraph(descrip.ToString(), myfontTabla));
                table.AddCell(new Paragraph(detalle.ToString(), myfont));
                table.AddCell(new Paragraph(estado.ToString(), myfontTabla));
                table.AddCell(new Paragraph(marca.ToString(), myfontTabla));
                table.AddCell(new Paragraph(serie.ToString(), myfontTabla));
                table.AddCell(new Paragraph(modelo.ToString(), myfontTabla));
                table.AddCell(new Paragraph(observaciones.ToString(), myfontTabla));
                table.WidthPercentage = 100;
                table.SetWidths(new Single[] { 40, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100 });


                document.Add(table);

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
            }

            abreVentana("VisualizaPDF.aspx?pdf=yes");//envio pdf para abrirlo en nueva pestaña
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


    public string F_caracteristicas(int op, int grupo, int id)
    {
        int opt = op;
        string val = "";
        Datos.SqlService objDatos = new Datos.SqlService();

        objDatos.AddParameter("@OPT", SqlDbType.Int, op);
        objDatos.AddParameter("@GRU_ID", SqlDbType.Int, grupo);
        objDatos.AddParameter("@ACT_ID", SqlDbType.Int, id);
        try
        {
            DataTable capacidad = objDatos.ExecuteSPDataTable("CAPACIDAD");
            val = capacidad.Rows[0]["valor"].ToString();
        }
        catch (System.Exception ex)
        {
            val = "s/n " + ex.Message;
        }

        return val;
    }

    private void abreVentana(string ventana)
    {
        string funcion = "windowOpener('" + ventana + "')";

        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "SIFEL", funcion, true);
    }

    public int F_TotalPDF()
    {

        string folderToBrowse = Server.MapPath("./PDF_ACTBAJA/");
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

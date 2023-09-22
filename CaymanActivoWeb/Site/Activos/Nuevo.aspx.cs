using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.IO;
using Telerik.Web.UI;
using System.Web.Security;
using System.Drawing;
using System.Drawing.Imaging;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Globalization;

public partial class Site_Activos_Nuevo : System.Web.UI.Page
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
            txtFechaRecep.Text = System.DateTime.Now.ToString("yyyy/MM/dd");
            datefechacompra.MaxDate = System.DateTime.Now;


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
            DateTime today = DateTime.Now;
            datefechacompra.MinDate = new DateTime(today.Year, today.Month, 1);
            datefechacompra.MaxDate = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));

            lblCuentaTransitoria.Text = ConfigurationManager.AppSettings["CUENTATRANSITORIA"];
            lblOficina1.Text = ConfigurationManager.AppSettings["OFICINAORIGEN"];
            lblCentroCosto1.Text = ConfigurationManager.AppSettings["AREAORIGEN"];

            Session["fupload1"] = "";
            Session["fupload2"] = "";
            Session["fupload3"] = "";
            Session["fupload4"] = "";

            Session["_cusini"] = "";
            Session["_cusfin"] = "";
            Session["_actidacta"] = "";
            Session["_ubiorg"] = "";
            Session["_ubigeo"] = "";
            Session["_seguro"] = "";
            Session["_nomseguro"] = "";
            Session["_factNum"] = "0";
            Session["_msgGActivo"] = "";
            Session["_codBarras"] = "";

            F_llenarcomboTipoActivo();

            try
            {
                Session["_actid"] = Logica.HELPER.getNextActid(Membership.GetUser().UserName.ToLower()).ToString();
                lblid.Text = Session["_actid"].ToString();
                lblFechacreacion.Text = DateTime.Now.ToString("dd/MM/yyyy");
                upid.Update();

                this.Title = ConfigurationManager.AppSettings["Titulo"] + " Nuevo Activo";
                cargarUnidades();
            }
            catch (Exception ex)
            {
                errtrap = new ErrorTrapper();
                errtrap.SetOnError("Usuario:" + Membership.GetUser().UserName + "<< " + ex.Message, 0);
                messbox1.Mensaje = "Error: " + ex.Message;
                messbox1.Tipo = "E";
                messbox1.showMess();
            }

            //cambio de imagen cuando mouser over sobre menu central de imagenes
            ibgr1.Attributes.Add("onmouseout", "this.src='../../Img/rl1.png'");
            ibgr1.Attributes.Add("onmouseover", "this.src='../../Img/rl2.png'");
            ibgr2.Attributes.Add("onmouseout", "this.src='../../Img/rl1.png'");
            ibgr2.Attributes.Add("onmouseover", "this.src='../../Img/rl2.png'");
            ibgr3.Attributes.Add("onmouseout", "this.src='../../Img/rl1.png'");
            ibgr3.Attributes.Add("onmouseover", "this.src='../../Img/rl2.png'");
            ibgr4.Attributes.Add("onmouseout", "this.src='../../Img/rl1.png'");
            ibgr4.Attributes.Add("onmouseover", "this.src='../../Img/rl2.png'");
            ibgr7.Attributes.Add("onmouseout", "this.src='../../Img/rl1.png'");
            ibgr7.Attributes.Add("onmouseover", "this.src='../../Img/rl2.png'");

            ibsave.Attributes.Add("onmouseout", "this.src='../../Img/s1.png'");
            ibsave.Attributes.Add("onmouseover", "this.src='../../Img/s2.png'");
            ibcancel.Attributes.Add("onmouseout", "this.src='../../Img/c1.png'");
            ibcancel.Attributes.Add("onmouseover", "this.src='../../Img/c2.png'");

            //datefechacompra.MaxDate = DateTime.Today;
        }
    }

    public void F_llenarcomboTipoActivo()
    {
        Logica.ACTIVO objActivo = new Logica.ACTIVO();

        this.ddtipo.DataSource = objActivo.CargaTipoActivo("TIPOACTIVO");
        this.ddtipo.DataValueField = "par_codigo";
        this.ddtipo.DataTextField = "par_valor";
        this.ddtipo.DataBind();
        this.ddtipo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("", ""));
    }

    private void cargarUnidades()
    {
        try
        {
            Datos.SqlService sql = new Datos.SqlService();
            DataTable dt = sql.ExecuteSqlDataTable("select uni_id, uni_simbolo from unidad order by uni_simbolo");
            loadUnidades(d1, dt);
            loadUnidades(d2, dt);
            loadUnidades(d3, dt);
            loadUnidades(d4, dt);
            loadUnidades(d5, dt);
            loadUnidades(d6, dt);
            loadUnidades(d7, dt);
            loadUnidades(d8, dt);
            loadUnidades(d9, dt);
            loadUnidades(d10, dt);
            loadUnidades(d11, dt);
            loadUnidades(d12, dt);
            loadUnidades(d13, dt);
            loadUnidades(d14, dt);
            loadUnidades(d15, dt);
            loadUnidades(d16, dt);
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

    private void loadUnidades(DropDownList ddl, DataTable dt)
    {
        ddl.DataSource = dt;
        ddl.DataTextField = "uni_simbolo";
        ddl.DataValueField = "uni_id";
        ddl.DataBind();
        ddl.Items.Insert(0, new System.Web.UI.WebControls.ListItem(String.Empty, String.Empty));
        ddl.SelectedIndex = 0;
    }

    private void cleanCar(int numcar)
    {
        try
        {
            for (int i = 1; i < 17; i++)
            {
                //enceramos info tecnica
                Label lab = (Label)upcar.FindControl("l" + i.ToString());
                lab.Text = "";
                Telerik.Web.UI.RadTextBox txt = (Telerik.Web.UI.RadTextBox)upcar.FindControl("t" + i.ToString());
                txt.Text = "";
                DropDownList ddl = (DropDownList)upcar.FindControl("d" + i.ToString());
                ddl.SelectedIndex = 0;

                //ocultamos excedentes
                if (numcar < i)
                {
                    lab.Visible = false;
                    txt.Visible = false;
                    ddl.Visible = false;
                }
                else
                {
                    lab.Visible = true;
                    txt.Visible = true;
                    ddl.Visible = true;
                }
            }

            upcar.Update();
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

    protected void ddGrupo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            String[] arrcfaid = new string[17];
            Session["arrcfaid"] = arrcfaid;
            Logica.GRUPO gr = new Logica.GRUPO(int.Parse(ddGrupo.SelectedValue));
            lblCuentaActivo.Text = gr.GRU_CTA1;


            DataTable dt = Logica.HELPER.getCar(ddGrupo.SelectedValue);

            cleanCar(dt.Rows.Count);

            int j = 1;
            foreach (DataRow row in dt.Rows)
            {
                Label lab = (Label)upcar.FindControl("l" + j.ToString());
                DropDownList ddl = (DropDownList)upcar.FindControl("d" + j.ToString());
                arrcfaid[j] = row["cfa_id"].ToString();

                lab.Text = row["cfa_nombre"].ToString() + ":";
                j++;
                if (row["cfa_unidades"].ToString() == "True")
                    ddl.Visible = true;
                else
                    ddl.Visible = false;
            }

            upcar.Update();
            upAsiento.Update();

            //get periodos respecto al grupo
            lblvidautil.Text = Logica.HELPER.getVuSriGrupo(ddGrupo.SelectedValue);
            upcontable.Update();
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

    protected void ddgarantia_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddgarantia.SelectedItem.ToString() == "NO")
        {
            pangar.Visible = false;
        }
        else
        {
            pangar.Visible = true;
        }
    }

    private void reset()
    {
        Session["fupload1"] = "";
        Session["fupload2"] = "";
        Session["fupload3"] = "";
        Session["fupload4"] = "";

        txtcb.Text = "";
        txtcbpadre.Text = "";
        txtcod1.Text = "";
        cddDescrip.SelectedValue = "";

        if (!chk0.Checked)
        {
            cddgeo1.SelectedValue = "";
        }

        if (!chk1.Checked)
        {
            cddccosto.SelectedValue = "";
            cdduor1.SelectedValue = "";
            // cddResponsable.SelectedValue = "";
        }

        if (!chk2.Checked)
        {
            cddest1.SelectedValue = "";
            cddest2.SelectedValue = "";
            cddest3.SelectedValue = "";
        }

        if (!chk3.Checked)
        {
            cddmarca.SelectedValue = "";
            cddModelo.SelectedValue = "";
            cddcolor.SelectedValue = "";
            cddestruc1.SelectedValue = "";
            cddcompo1.SelectedValue = "";
            cddProveedor.SelectedValue = "";
            txtserie.Text = "";
            cddAnio.SelectedValue = "";
        }

        if (!chk4.Checked)
        {
            txtnumfact.Text = "";
            datefechacompra.Clear();
            txtvalorcompra.Text = "";
            txtvidautilniif.Text = "";
            txtvalorresniif.Text = "";
            ddTrasnfer.ClearSelection();
            dateInicioNiif.Clear();
        }

        if (!chk5.Checked)
        {
            dategarantiavence.Clear();
            ddgarantia.SelectedValue = "NO";
            pangar.Visible = false;
            ddSeguro.SelectedValue = "NO";
            ddRamo.ClearSelection();
            panAseg.Visible = false;
        }

        if (!chk6.Checked)
        {
            txtObservaciones.Text = "";
        }

        if (!chk7.Checked)
        {
            resetcar();
        }
    }

    private void resetcar()
    {
        try
        {
            for (int i = 1; i < 17; i++)
            {
                Telerik.Web.UI.RadTextBox txt = (Telerik.Web.UI.RadTextBox)upcar.FindControl("t" + i.ToString());
                DropDownList ddl = (DropDownList)upcar.FindControl("d" + i.ToString());
                txt.Text = "";
                ddl.SelectedIndex = 0;
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

    protected void rau1_FileUploaded(object sender, FileUploadedEventArgs e)
    {
        try
        {
            foreach (UploadedFile file in rau1.UploadedFiles)
            {
                Session["fupload1"] = "";

                string nombreok = Session["_actid"].ToString();

                int i = 1;
                while (File.Exists(Server.MapPath("./im/") + nombreok + file.GetExtension()))
                {
                    nombreok = Session["_actid"].ToString() + "_" + i.ToString();
                    i++;
                }

                nombreok = nombreok + file.GetExtension();
                file.SaveAs(Server.MapPath("./im/") + nombreok, false);

                VaryQualityLevel(Server.MapPath("./im/") + nombreok, 80L, Server.MapPath("./imgact/") + nombreok);
                Session["fupload1"] = nombreok;
            }
        }
        catch (Exception ex)
        {
            errtrap = new ErrorTrapper();
            errtrap.SetOnError("Usuario:" + Membership.GetUser().UserName + "<< " + ex.Message, 0);
        }
    }

    protected void rau2_FileUploaded(object sender, FileUploadedEventArgs e)
    {
        try
        {
            foreach (UploadedFile file in rau2.UploadedFiles)
            {
                Session["fupload2"] = "";

                string nombreok = Session["_actid"].ToString();

                int i = 1;
                while (File.Exists(Server.MapPath("./im/") + nombreok + file.GetExtension()))
                {
                    nombreok = Session["_actid"].ToString() + "_" + i.ToString();
                    i++;
                }

                nombreok = nombreok + file.GetExtension();
                file.SaveAs(Server.MapPath("./im/") + nombreok, false);
                VaryQualityLevel(Server.MapPath("./im/") + nombreok, 80L, Server.MapPath("./imgact/") + nombreok);

                Session["fupload2"] = nombreok;
            }
        }
        catch (Exception ex)
        {
            errtrap = new ErrorTrapper();
            errtrap.SetOnError("Usuario:" + Membership.GetUser().UserName + "<< " + ex.Message, 0);
        }
    }

    protected void rau3_FileUploaded(object sender, FileUploadedEventArgs e)
    {
        try
        {
            foreach (UploadedFile file in rau3.UploadedFiles)
            {
                Session["fupload3"] = "";

                string nombreok = Session["_actid"].ToString();

                int i = 1;
                while (File.Exists(Server.MapPath("./imgact/") + nombreok + file.GetExtension()))
                {
                    nombreok = Session["_actid"].ToString() + "_" + i.ToString();
                    i++;
                }

                nombreok = nombreok + file.GetExtension();
                file.SaveAs(Server.MapPath("./imgact/") + nombreok, false);
                Session["fupload3"] = nombreok;
            }
        }
        catch (Exception ex)
        {
            errtrap = new ErrorTrapper();
            errtrap.SetOnError("Usuario:" + Membership.GetUser().UserName + "<< " + ex.Message, 0);
        }
    }

    protected void rau4_FileUploaded(object sender, FileUploadedEventArgs e)
    {
        try
        {
            foreach (UploadedFile file in rau4.UploadedFiles)
            {
                Session["fupload4"] = "";

                string nombreok = Session["_actid"].ToString();

                int i = 1;
                while (File.Exists(Server.MapPath("./imgact/") + nombreok + file.GetExtension()))
                {
                    nombreok = Session["_actid"].ToString() + "_" + i.ToString();
                    i++;
                }

                nombreok = nombreok + file.GetExtension();
                file.SaveAs(Server.MapPath("./imgact/") + nombreok, false);
                Session["fupload4"] = nombreok;
            }
        }
        catch (Exception ex)
        {
            errtrap = new ErrorTrapper();
            errtrap.SetOnError("Usuario:" + Membership.GetUser().UserName + "<< " + ex.Message, 0);
        }
    }

    private ImageCodecInfo GetEncoder(ImageFormat format)
    {
        try
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }

            return null;
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

    private void VaryQualityLevel(string path, Int64 calidad, string savepath)
    {
        try
        {
            // Get a bitmap.
            Bitmap bmp1 = new Bitmap(path);

            int width = 0;
            int height = 0;

            if (bmp1.Width > bmp1.Height)
            {
                width = 640;
                height = 480;
            }
            else
            {
                width = 480;
                height = 640;
            }

            System.Drawing.Image bmp2 = new Bitmap(bmp1, width, height);

            //Or you do can use buil-in method
            //ImageCodecInfo jgpEncoder GetEncoderInfo("image/gif");//"image/jpeg",...
            ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);

            // Create an Encoder object based on the GUID
            // for the Quality parameter category.
            System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;

            // Create an EncoderParameters object.
            // An EncoderParameters object has an array of EncoderParameter
            // objects. In this case, there is only one
            // EncoderParameter object in the array.
            EncoderParameters myEncoderParameters = new EncoderParameters(1);

            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, calidad);
            myEncoderParameters.Param[0] = myEncoderParameter;
            bmp2.Save(savepath, jgpEncoder, myEncoderParameters);

            if (File.Exists(path))
            {
                File.Delete(path);
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

    private bool codigoCorrecto()
    {
        try
        {
            string codbar = "";

            if (txtcb.Text.Trim().Length < int.Parse(Session["emtd"].ToString()))
            {
                codbar = Session["empr"].ToString() + completarCodigo(txtcb.Text.Trim());
            }
            else if (txtcb.Text.Trim().Length == int.Parse(Session["emtd"].ToString()))
            {
                codbar = txtcb.Text.Trim();
            }
            else
            {
                return false;
            }

            if (Logica.HELPER.codigoValido(codbar))
            {
                txtcb.Text = codbar;
                upcb.Update();
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
            messbox1.Mensaje = "Error: " + ex.Message;
            messbox1.Tipo = "E";
            messbox1.showMess();
            return false;
        }
    }

    private bool codigoNoIngresado()
    {
        try
        {
            //si es valido
            string codbar = "";

            if (txtcb.Text.Trim().Length < int.Parse(Session["emtd"].ToString()))
            {
                codbar = Session["empr"].ToString() + completarCodigo(txtcb.Text.Trim());
            }
            else if (txtcb.Text.Trim().Length == int.Parse(Session["emtd"].ToString()))
            {
                codbar = txtcb.Text.Trim();
            }

            if (Logica.HELPER.comprobarCbIngresado(codbar))
            {
                return false;
            }
            else
            {
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

    private bool F_ExisteCodigo()
    {
        if (Logica.HELPER.comprobarCodigoRFIDIngresado(txtcb.Text.Trim()))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private bool codigoPadreCorrecto()
    {
        try
        {
            string codbar = "";

            if (txtcbpadre.Text.Trim().Length == 0)
            {
                return true;
            }
            else
            {
                if (txtcbpadre.Text.Trim().Length < int.Parse(Session["emtd"].ToString()))
                {
                    codbar = Session["empr"].ToString() + completarCodigo(txtcbpadre.Text.Trim());
                }
                else if (txtcbpadre.Text.Trim().Length == int.Parse(Session["emtd"].ToString()))
                {
                    codbar = txtcbpadre.Text.Trim();
                }
                else
                {
                    return false;
                }

                if (Logica.HELPER.codigoValido(codbar))
                {
                    txtcbpadre.Text = codbar;
                    upcb.Update();
                    return true;
                }
                else
                {
                    return false;
                }
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

    private bool codigoPadreExiste()
    {
        try
        {
            if (txtcbpadre.Text.Trim().Length == 0)
            {
                return true;
            }
            else
            {
                if (Logica.HELPER.comprobarCbIngresado(txtcbpadre.Text.Trim()))
                    return true;
                else
                    return false;
            }
        }
        catch (Exception ex)
        {
            errtrap = new ErrorTrapper();
            errtrap.SetOnError("Usuario:" + Membership.GetUser().UserName + "<< " + ex.Message, 0);
            messbox1.Mensaje = "Error: " + ex.Message;
            messbox1.Tipo = "E";
            messbox1.showMess();
            return true;
        }
    }

    private bool EnFechaDepreciacion()
    {
        try
        {
            DateTime fechaDepre = Logica.HELPER.getMesDepre("TRIBUTARIA");
            if (fechaDepre.Year > 1900)
            {
                fechaDepre = fechaDepre.AddMonths(-1);
            }

            if (fechaDepre > dateInicioNiif.SelectedDate.Value)
            {
                return false;
            }

            return true;
        }
        catch (Exception ex)
        {
            errtrap = new ErrorTrapper();
            errtrap.SetOnError("Usuario:" + Membership.GetUser().UserName + "<< " + ex.Message, 0);
            messbox1.Mensaje = "Error: " + ex.Message;
            messbox1.Tipo = "E";
            messbox1.showMess();
            return true;
        }
    }

    private bool codigoLogiKardExiste()
    {
        try
        {
            if (txtcod1.Text.Trim().Length == 0)
            {
                return true;
            }
            else
            {
                if (Logica.HELPER.comprobarCodLogikard(txtcod1.Text.Trim()))
                    return false;
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
            return true;
        }
    }

    private bool codigoPadreDiffCodHijo()
    {
        if (txtcbpadre.Text.Trim() != txtcb.Text.Trim())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool verificarCostos()
    {
        try
        {
            if (txtvalorcompra.Text != "" && txtvalorresniif.Text != "")
            {
                if (decimal.Parse(txtvalorresniif.Text.Trim().Replace(",", "."), System.Globalization.NumberStyles.Currency,
                        new System.Globalization.CultureInfo("en-US")) < decimal.Parse(txtvalorcompra.Text.Trim().Replace(",", "."),
                        System.Globalization.NumberStyles.Currency, new System.Globalization.CultureInfo("en-US")))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
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
            messbox1.Mensaje = "Error: " + ex.Message;
            messbox1.Tipo = "E";
            messbox1.showMess();
            return "";
        }
    }

    protected void ibsave_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (codigoCorrecto())
            {
                if (codigoNoIngresado())
                {
                    if (codigoLogiKardExiste())
                    {
                        if (codigoPadreCorrecto())
                        {
                            if (codigoPadreExiste())
                            {
                                if (codigoPadreDiffCodHijo())
                                {
                                    if (EnFechaDepreciacion())
                                    {
                                        if ( ddtipo.SelectedValue=="Bien de Control" || dateInicioNiif.SelectedDate.Value >= datefechacompra.SelectedDate.Value)
                                        {
                                            if (verificarCostos())
                                            {
                                                Logica.ACTIVO act = new Logica.ACTIVO();

                                                if (Session["fupload1"] != null && Session["fupload1"].ToString().Contains('.'))
                                                    act.ACT_FOTO1 = Session["fupload1"].ToString();
                                                else
                                                    act.ACT_FOTO1 = "nofoto.gif";

                                                if (Session["fupload2"] != null && Session["fupload2"].ToString().Contains('.'))
                                                    act.ACT_FOTO2 = Session["fupload2"].ToString();
                                                else
                                                    act.ACT_FOTO2 = "nofoto.gif";

                                                if (Session["fupload3"] != null && Session["fupload3"].ToString().Contains('.'))
                                                    act.ACT_DOC1 = Session["fupload3"].ToString();

                                                if (Session["fupload4"] != null && Session["fupload4"].ToString().Contains('.'))
                                                    act.ACT_DOC2 = Session["fupload4"].ToString();

                                                act.Id = int.Parse(Logica.HELPER.getNextActid().ToString());
                                                //act.Id = int.Parse(Session["_actid"].ToString());
                                                act.EMP_ID = Session["emid"].ToString();


                                                if ((ddtipo.SelectedValue == "Activo Fijo" || ddtipo.SelectedValue == "ACTIVO FIJO") && lblvidautil.Text != "0")
                                                {
                                                    act.ACT_DEPRECIABLE = true;
                                                    act.ACT_FECHAINIDEPRE = act.calcularFechaIniDepre(dateInicioNiif.SelectedDate.Value);
                                                }
                                                else
                                                {
                                                    act.ACT_DEPRECIABLE = false;
                                                }


                                                act.USERNAME = Membership.GetUser().UserName.ToLower();
                                                act.ACT_TIPO = ddtipo.SelectedValue;
                                                act.ACT_CODBARRASPADRE = txtcbpadre.Text;
                                                act.ACT_CODIGO1 = txtcod1.Text.Trim();

                                                //grupos
                                                act.GRU_ID1 = int.Parse(ddGrupo.SelectedValue);
                                                act.GRU_ID2 = int.Parse(ddSubgrupo.SelectedValue);
                                                act.GRU_ID3 = int.Parse(ddDescripcion.SelectedValue);


                                                act.UGE_ID1 = int.Parse(ddUge1.SelectedValue);
                                                act.UGE_ID2 = int.Parse(ddUge2.SelectedValue);
                                                act.UGE_ID3 = int.Parse(ddUge3.SelectedValue);
                                                act.UGE_ID4 = int.Parse(ddPiso.SelectedValue);

                                                act.UOR_ID1 = int.Parse(ddCcosto.SelectedValue);
                                                act.UOR_ID2 = int.Parse(ddUor1.SelectedValue);
                                                act.UOR_ID3 = int.Parse(ddUor2.SelectedValue);

                                                act.CUS_ID1 = int.Parse(ddCustodio.SelectedValue);

                                                //////if (ddResponsable.SelectedValue == "")
                                                //////    act.CUS_ID2 = -1;
                                                //////else
                                                //////    act.CUS_ID2 = int.Parse(ddResponsable.SelectedValue);

                                                if (ddEstado.SelectedValue == "")
                                                    act.EST_ID1 = -1;
                                                else
                                                    act.EST_ID1 = int.Parse(ddEstado.SelectedValue);

                                                if (ddFase.SelectedValue == "")
                                                    act.EST_ID2 = -1;
                                                else
                                                    act.EST_ID2 = int.Parse(ddFase.SelectedValue);

                                                if (ddTrasnfer.SelectedValue == "")
                                                    act.EST_ID3 = -1;
                                                else
                                                    act.EST_ID3 = int.Parse(ddTrasnfer.SelectedValue);

                                                act.MAR_ID = int.Parse(ddMarca.SelectedValue);
                                                act.MOD_ID = int.Parse(ddModelo.SelectedValue);
                                                act.ACT_SERIE1 = txtserie.Text.Trim();

                                                if (ddColor.SelectedValue == "")
                                                    act.COL_ID = -1;
                                                else
                                                    act.COL_ID = int.Parse(ddColor.SelectedValue);

                                                if (ddEstructura.SelectedValue == "")
                                                    act.ECO_ID1 = -1;
                                                else
                                                    act.ECO_ID1 = int.Parse(ddEstructura.SelectedValue);

                                                if (ddComponente.SelectedValue == "")
                                                    act.ECO_ID2 = -1;
                                                else
                                                    act.ECO_ID2 = int.Parse(ddComponente.SelectedValue);

                                                act.PRO_ID = int.Parse(ddProveedor.SelectedValue);
                                                act.ACT_TIPOING = ddingreso.SelectedValue;
                                                act.ACT_NUMFACT = Int64.Parse(txtnumfact.Text.Trim());
                                                Session["_factNum"] = act.ACT_NUMFACT;
                                                act.ACT_FECHACOMPRA = datefechacompra.SelectedDate.Value;
                                                act.ACT_VALORCOMPRA = decimal.Parse(txtvalorcompra.Text.Replace(",", "."), System.Globalization.NumberStyles.Currency,
                                                    new System.Globalization.CultureInfo("en-US"));
                                                act.ACT_VIDAUTIL = int.Parse(lblvidautil.Text);
                                                act.ACT_VIDAUTILNIIF = int.Parse(lblvidautil.Text);
                                                act.ACT_VALORRESIDUALNIIF = decimal.Parse("0".Replace(",", "."), System.Globalization.NumberStyles.Currency,
                                                    new System.Globalization.CultureInfo("en-US"));
                                                if (panNiif.Visible)
                                                {
                                                    DateTime fechaSeleccionada = dateInicioNiif.SelectedDate.Value;
                                                    DateTime primerDiaDelSiguienteMes = fechaSeleccionada.AddMonths(1).Date;
                                                    primerDiaDelSiguienteMes = new DateTime(primerDiaDelSiguienteMes.Year, primerDiaDelSiguienteMes.Month, 1);

                                                    act.ACT_FECHAINIOPER = primerDiaDelSiguienteMes;
                                                    act.ACT_FECHAINIDEPRENIIF =act.ACT_FECHAINIDEPRE;
                                                }

                                                if (ddAnio.SelectedValue == "")
                                                    act.ACT_ANIO = -1;
                                                else
                                                    act.ACT_ANIO = int.Parse(ddAnio.SelectedValue);

                                                act.ACT_VIDAUTIL = int.Parse(lblvidautil.Text);

                                                if (ddgarantia.SelectedValue == "SI")
                                                {
                                                    act.ACT_GARANTIA = true;
                                                    act.ACT_FECHAGARANTIAVENCE = dategarantiavence.SelectedDate.Value;
                                                }
                                                else
                                                {
                                                    act.ACT_GARANTIA = false;
                                                }

                                                act.ACT_OBSERVACIONES = txtObservaciones.Text.Trim();
                                                act.ACT_CODBARRAS = txtcb.Text;
                                                Session["_codBarras"] = txtcb.Text;

                                                act.ACT_TIPRFID = 1;
                                                act.ACT_CODRFID = F_llenacerosRFID(act.ACT_CODBARRAS, 24, "0");

                                                if (ddSeguro.SelectedItem.Text == "SI")
                                                {
                                                    act.ACT_SEGURO = "S";
                                                    Session["_seguro"] = "SI";
                                                    act.ACT_TIPOSEGURO = int.Parse(ddRamo.SelectedValue);
                                                    Session["_nomseguro"] = ddRamo.SelectedItem.Text.Trim();

                                                    //polizas
                                                    act.ACT_NUMPOLIZA = txtNumPoliza.Text.Trim();
                                                    act.ACT_VIGENCIAPOLIZAMESES = F_TiempoMesesGarantia(rdpFechaEmision.SelectedDate.Value,
                                                        rdpFechaVencimiento.SelectedDate.Value);
                                                    act.ACT_FECHAEMISIONPOLIZA = rdpFechaEmision.SelectedDate.Value.Date;
                                                    act.ACT_FECHAVENCEPOLIZA = rdpFechaVencimiento.SelectedDate.Value.Date;
                                                    act.ACT_VALORASEGURADO = decimal.Parse(txtValorAsegurado.Text.Trim().Replace(",", "."),
                                                        System.Globalization.NumberStyles.Currency, new System.Globalization.CultureInfo("en-US"));
                                                }
                                                else
                                                {
                                                    act.ACT_SEGURO = "N";
                                                    Session["_seguro"] = "NO";
                                                    Session["_nomseguro"] = "";
                                                }

                                                act.CuentaOrigen = lblCuentaTransitoria.Text;
                                                act.CuentaDestino = lblCuentaActivo.Text;
                                                act.Oficina1 = lblOficina1.Text;
                                                act.Oficina2 = lblOficina2.Text;
                                                act.CentroCosto1 = lblCentroCosto1.Text;
                                                act.CentroCosto2 = lblCentroCosto2.Text;
                                                
                                                
                                                //PRIMERO CHEQUEO UNIDADES EN CARACTERISTICAS
                                                int validauni = 0;

                                                for (int i = 1; i < 17; i++)
                                                {
                                                    Telerik.Web.UI.RadTextBox txt = (Telerik.Web.UI.RadTextBox)upcar.FindControl("t" + i.ToString());
                                                    DropDownList ddl = (DropDownList)upcar.FindControl("d" + i.ToString());

                                                    if (txt.Text.Trim().Length > 0 && ddl.Visible && ddl.SelectedItem.Text.Trim().Length == 0)
                                                        validauni++;
                                                }

                                                if (validauni == 0) // si las caracteristicas tienen sus unidades
                                                {
                                                    //guardo activo
                                                    string err = "";
                                                    err = act.insActivo();

                                                    string _actid = act.Id.ToString();
                                                    //string _actid = Session["_actid"].ToString();

                                                    //data 0 = actid, data 1 = error msg

                                                    if (err != "")
                                                    {
                                                        errtrap = new ErrorTrapper();
                                                        errtrap.SetOnError("Usuario:" + Membership.GetUser().UserName + "<< " + err, 0); //1 enviar mail

                                                        messbox1.Mensaje = "Error al guardar el archivo. >> " + err;
                                                        messbox1.Tipo = "E";
                                                        messbox1.showMess();
                                                    }
                                                    else
                                                    {
                                                        if (act.ACT_TIPO == "Activo Fijo")
                                                        {
                                                            Asientos.InsertActivo(act);    
                                                        }
                                                        
                                                        Session["_actid"] = Logica.HELPER.getNextActid(Membership.GetUser().UserName.ToLower()).ToString();
                                                        lblid.Text = Session["_actid"].ToString();
                                                        upid.Update();

                                                        //GUARDO CARACTERISTICAS
                                                        String[] arrcfaid = new string[17];
                                                        arrcfaid = (string[])Session["arrcfaid"];

                                                        Logica.CARACTERISTICA car = new Logica.CARACTERISTICA();

                                                        for (int i = 1; i < 17; i++)
                                                        {
                                                            Label lab = (Label)upcar.FindControl("l" + i.ToString());
                                                            Telerik.Web.UI.RadTextBox txt = (Telerik.Web.UI.RadTextBox)upcar.FindControl("t" + i.ToString());
                                                            DropDownList ddl = (DropDownList)upcar.FindControl("d" + i.ToString());

                                                            if (lab.Visible && txt.Text.Trim().Length > 0)
                                                            {
                                                                car.ACT_ID = int.Parse(_actid);
                                                                car.CFA_ID = int.Parse(arrcfaid[i]);
                                                                car.CAR_VALOR = txt.Text.Trim();

                                                                if (!ddl.Visible)
                                                                    car.UNI_ID = -1;
                                                                else
                                                                    car.UNI_ID = int.Parse(ddl.SelectedItem.Value.ToString());

                                                                car.Create();
                                                            }
                                                        }

                                                        //guarda asiento contable

                                                        //Asientos.InsertActivo(act);

                                                        F_GeneraPDF(act, _actid);
                                                        var nombreacta = Session["nombredelacta"].ToString();
                                                        var asunto = "Ingreso de nuevo activo y/o bien de control";
                                                        var cuerpo = "Estimada(o), se adjunta Acta de Ingreso de nuevo activo y/o bien de control administrativo.\r\n\r\n\r\nSaludos cordiales, Activos Fijos";
                                                        var rutaPDF = Server.MapPath("PDF_ACTING/" + nombreacta + ".pdf");
                                                        Correos correos = new Correos();
                                                        correos.envioCorreosEnergyPower(asunto, cuerpo, rutaPDF);
                                                        //mensaje ok
                                                        messbox1.Mensaje = "Activo Guardado con éxito!";
                                                        messbox1.Tipo = "S";
                                                        messbox1.showMess();

                                                        //reset variables
                                                        reset();
                                                    }
                                                }
                                                else
                                                {
                                                    lblid.Text = Session["_actid"].ToString();
                                                    messbox1.Mensaje = "Antes de guardar complete las unidades de las características ingresadas";
                                                    messbox1.Tipo = "I";
                                                    messbox1.showMess();
                                                }
                                            }
                                            else
                                            {
                                                lblid.Text = Session["_actid"].ToString();
                                                messbox1.Mensaje = "El Valor Residual Niif no puede ser mayor al valor de compra, por favor corríjalo! para continuar";
                                                messbox1.Tipo = "W";
                                                messbox1.showMess();
                                            }
                                        }
                                        else
                                        {
                                            lblid.Text = Session["_actid"].ToString();
                                            messbox1.Mensaje = "La fecha de inicio de operacion no puede ser menor a la fecha de compra";
                                            messbox1.Tipo = "W";
                                            messbox1.showMess();
                                        }
                                    }
                                    else
                                    {
                                        lblid.Text = Session["_actid"].ToString();
                                        messbox1.Mensaje = "La fecha de inicio de operacion no puede ser menor a la fecha de la ultima depreciación";
                                        messbox1.Tipo = "W";
                                        messbox1.showMess();
                                    }
                                }
                                else
                                {
                                    lblid.Text = Session["_actid"].ToString();
                                    messbox1.Mensaje = "El Activo no puede ser su propio Padre";
                                    messbox1.Tipo = "I";
                                    messbox1.showMess();
                                }
                            }
                            else
                            {
                                lblid.Text = Session["_actid"].ToString();
                                messbox1.Mensaje = "Ingrese primero el Activo Padre antes de ingresar sus componentes, Código Padre aún no ha sido ingresado";
                                messbox1.Tipo = "I";
                                messbox1.showMess();
                            }
                        }
                        else
                        {
                            lblid.Text = Session["_actid"].ToString();
                            messbox1.Mensaje = "Codigo de Barras PADRE no válido, por favor corrijalo antes de continuar...";
                            messbox1.Tipo = "W";
                            messbox1.showMess();
                        }
                    }
                    else
                    {
                        lblid.Text = Session["_actid"].ToString();
                        messbox1.Mensaje = "El Codigo Secundario ya fue ingresado anteriormente, por favor corrijalo antes de continuar...";
                        messbox1.Tipo = "W";
                        messbox1.showMess();
                    }
                }
                else
                {
                    lblid.Text = Session["_actid"].ToString();
                    messbox1.Mensaje = "El Codigo de Barras ya fue ingresado anteriormente, por favor corrijalo antes de continuar...";
                    messbox1.Tipo = "W";
                    messbox1.showMess();
                }
            }
            else
            {
                lblid.Text = Session["_actid"].ToString();
                messbox1.Mensaje = "Codigo de Barras no válido, por favor corrijalo antes de continuar...";
                messbox1.Tipo = "W";
                messbox1.showMess();
            }
        }
        catch (Exception ex)
        {
            errtrap = new ErrorTrapper();
            errtrap.SetOnError("Usuario:" + Membership.GetUser().UserName + "Id: " + Session["_actid"].ToString() + "<< " + ex.Message, 0); //1 enviar mail

            messbox1.Mensaje = "Error. " + ex.Message;
            messbox1.Tipo = "E";
            messbox1.showMess();
        }
    }

    public string F_Dia(string dia)
    {
        if (dia.Trim() == "Monday" || dia.Trim() == "MONDAY")
        {
            dia = "Lunes";
        }
        else if (dia.Trim() == "Tuesday" || dia.Trim() == "TUESDAY")
        {
            dia = "Martes";
        }
        else if (dia.Trim() == "Wednesday" || dia.Trim() == "WEDNESDAY")
        {
            dia = "Miercoles";
        }
        else if (dia.Trim() == "Thursday" || dia.Trim() == "THURSDAY")
        {
            dia = "Jueves";
        }
        else if (dia.Trim() == "Friday" || dia.Trim() == "FRIDAY")
        {
            dia = "Viernes";
        }
        else if (dia.Trim() == "Saturday" || dia.Trim() == "SATURDAY")
        {
            dia = "Sábado";
        }
        else if (dia.Trim() == "Sunday" || dia.Trim() == "SUNDAY")
        {
            dia = "Domingo";
        }

        return dia;
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

    public string F_llenacerosRFID(String Valor, Int32 MaxVal, String relleno)
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
                Valor = Valor + relleno;
            }
        }

        return Valor;
    }
    public void F_GeneraPDF(Logica.ACTIVO act, string _actid)
    {
        //datos PDF
        string ubifin = "";
        string cusfin = "";
        string ubiorg = "";
        string ubigeo = "";

        ubifin = ddUge1.SelectedValue + ";" +
                 ddUge2.SelectedValue + ";" +
                 ddUge3.SelectedValue + ";" +
                 ddPiso.SelectedValue + ";" +
                 ddCcosto.SelectedValue + ";" +
                 ddUor1.SelectedValue + ";" +
                 ddUor2.SelectedValue + ";" +
                 ddCustodio.SelectedValue + ";" +
                 ddEstado.SelectedValue + ";" +
                 ddFase.SelectedValue + ";" +
                 ddTrasnfer.SelectedValue;

        cusfin = ddCustodio.SelectedValue;

        ubiorg = act.UOR_ID1.ToString() + ";" + act.UOR_ID2.ToString() + ";" + act.UOR_ID3.ToString();
        ubigeo = act.UGE_ID1.ToString() + ";" + act.UGE_ID2.ToString() + ";" + act.UGE_ID3.ToString() + ";" + act.UGE_ID4.ToString();

        string color = ddColor.SelectedItem.Text.Trim();
        string centrocosto = ddCcosto.SelectedItem.Text.Trim();
        string proveedor = ddProveedor.SelectedItem.Text.Trim();
        string fechacompra = act.ACT_FECHACOMPRA.ToString("dd/MM/yyyy");
        string valorcompra = act.ACT_VALORCOMPRA.ToString();
        string fechaIniDepre = act.ACT_FECHAINIDEPRE.ToString("dd/MM/yyyy");

        int mesesGarantia = 0;
        if (ddgarantia.SelectedItem.Text.Trim() == "SI")
            mesesGarantia = F_TiempoMesesGarantia(act.ACT_FECHACOMPRA, dategarantiavence.SelectedDate.Value);

        int mesesPoliza = 0;
        if (ddSeguro.SelectedItem.Text.Trim() == "SI")
            mesesPoliza = F_TiempoMesesGarantia(rdpFechaEmision.SelectedDate.Value, rdpFechaVencimiento.SelectedDate.Value);

        /*comentar para probar*/

        string mesg = "";

        CrearPdf(cusfin, int.Parse(_actid), ubiorg, ubigeo, "Acta de Ingreso - " + ddCustodio.SelectedItem.Text.Trim(), color, centrocosto, proveedor, fechacompra,
            valorcompra, mesesGarantia, fechaIniDepre, mesesPoliza, ref mesg);
    }

    private void CrearPdf(string cusfin, int act, string ubiorg, string ubigeo, string nombre, string color, string centrocosto, string proveedor, string fechacompra,
        string valcompra, int meseGarantiaVence, string fIniDepre, int mesesPoliza, ref string mesg)
    {
        try
        {
            int numPDF = F_TotalPDF() + 1;
            string PDFnum = F_llenaceros(Convert.ToString(numPDF), 5, "0");

            string[] ubiOrg = ubiorg.Split(';');
            string[] ubiGeo = ubigeo.Split(';');

            Datos.SqlService sql = new Datos.SqlService();
            Object NuevoCus = sql.ExecuteSqlObject("select (cus_nombres +' '+ CUS_apellidos) from CUSTODIO where cus_id='" + cusfin + "'");

            Object AreaActivos = ConfigurationManager.AppSettings["AreaActivosFijosIngreso"].ToString();
            string TituloReporte = ConfigurationManager.AppSettings["TituloReportes"].ToString();
            Object NuevoCusCC = sql.ExecuteSqlObject("select cus_cedula from CUSTODIO where cus_id='" + cusfin + "'");

            Object AnteriorCusCC = "";
            String NuevoCi = "";

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

            //descripcion
            Object descrip = sql.ExecuteSqlObject(
                "select g3.gru_nombre AS DESCRIPCION from (ACTIVO left join GRUPO as g3 on activo.gru_id3= g3.gru_id) WHERE ACTIVO.ACT_ID='" + act + "'");

            Object codigoBarras = sql.ExecuteSqlObject("select ACT_CODBARRAS as CODIGO from ACTIVO WHERE ACTIVO.ACT_ID='" + act + "'");
            Object grupo = sql.ExecuteSqlObject(
                "select g1.gru_nombre AS SUBTIPO from (ACTIVO  left join GRUPO as g1 on activo.gru_id1= g1.gru_id) WHERE ACTIVO.ACT_ID='" + act + "'");
            Object subGrupo = sql.ExecuteSqlObject("select g2.gru_nombre AS CLASE from (ACTIVO left join GRUPO as g2 on activo.gru_id2= g2.gru_id) WHERE ACTIVO.ACT_ID='" +
                                                 act + "'");
            Object detalleTecnico = sql.ExecuteSqlObject(
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

            var nuevovalor = nombre + " " + System.DateTime.Now.ToString("ddMMyyyyHHmmss");
            string Path = Server.MapPath("./PDF_ACTING/") + nuevovalor + ".pdf";
            string cusActivoFijo = ConfigurationManager.AppSettings["AreaActivosFijosIngreso"];

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
                FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.NORMAL));
            iTextSharp.text.Font myfontbold = new iTextSharp.text.Font(
                FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.BOLD));

            iTextSharp.text.Font myfont2 = new iTextSharp.text.Font(
                FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL));
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

            PdfPTable tableDatos = new PdfPTable(11);
            Phrase phead1 = new Phrase();
            phead1.Add(new Chunk("Código de Barras", myfontLabel));
            PdfPCell cell1head = new PdfPCell(phead1);
            tableDatos.AddCell(cell1head);

            Phrase phead2 = new Phrase();
            phead2.Add(new Chunk("Tipo de Bien", myfontLabel));
            PdfPCell cell2head = new PdfPCell(phead2);
            tableDatos.AddCell(cell2head);

            Phrase phead3 = new Phrase();
            phead3.Add(new Chunk("Grupo/Cuenta", myfontLabel));
            PdfPCell cell3head = new PdfPCell(phead3);
            tableDatos.AddCell(cell3head);

            Phrase phead4 = new Phrase();
            phead4.Add(new Chunk("Subgrupo", myfontLabel));
            PdfPCell cell4head = new PdfPCell(phead4);
            tableDatos.AddCell(cell4head);

            Phrase phead5 = new Phrase();
            phead5.Add(new Chunk("Descripción", myfontLabel));
            PdfPCell cell5head = new PdfPCell(phead5);
            tableDatos.AddCell(cell5head);

            Phrase phead6 = new Phrase();
            phead6.Add(new Chunk("Información Técnica", myfontLabel));
            PdfPCell cell6head = new PdfPCell(phead6);
            tableDatos.AddCell(cell6head);

            Phrase phead7 = new Phrase();
            phead7.Add(new Chunk("Estado", myfontLabel));
            PdfPCell cell7head = new PdfPCell(phead7);
            tableDatos.AddCell(cell7head);

            Phrase phead8 = new Phrase();
            phead8.Add(new Chunk("Marca", myfontLabel));
            PdfPCell cell8head = new PdfPCell(phead8);
            tableDatos.AddCell(cell8head);

            Phrase phead9 = new Phrase();
            phead9.Add(new Chunk("Serie", myfontLabel));
            PdfPCell cell9head = new PdfPCell(phead9);
            tableDatos.AddCell(cell9head);

            Phrase phead10 = new Phrase();
            phead10.Add(new Chunk("Modelo", myfontLabel));
            PdfPCell cell10head = new PdfPCell(phead10);
            tableDatos.AddCell(cell10head);

            Phrase phead11 = new Phrase();
            phead11.Add(new Chunk("Observaciones", myfontLabel));
            PdfPCell cell11head = new PdfPCell(phead11);
            tableDatos.AddCell(cell11head);


            Phrase phead111 = new Phrase();
            phead111.Add(new Chunk(codigoBarras.ToString(), myfontLabel));
            PdfPCell cell111head = new PdfPCell(phead111);
            tableDatos.AddCell(cell111head);

            Phrase phead211 = new Phrase();
            phead211.Add(new Chunk(tipoActivo.ToString(), myfontLabel));
            PdfPCell cell211head = new PdfPCell(phead211);
            tableDatos.AddCell(cell211head);

            Phrase phead311 = new Phrase();
            phead311.Add(new Chunk(grupo.ToString(), myfontLabel));
            PdfPCell cell311head = new PdfPCell(phead311);
            tableDatos.AddCell(cell311head);

            Phrase phead411 = new Phrase();
            phead411.Add(new Chunk(subGrupo.ToString(), myfontLabel));
            PdfPCell cell411head = new PdfPCell(phead411);
            tableDatos.AddCell(cell411head);

            Phrase phead511 = new Phrase();
            phead511.Add(new Chunk(descrip.ToString(), myfontLabel));
            PdfPCell cell511head = new PdfPCell(phead511);
            tableDatos.AddCell(cell511head);

            Phrase phead611 = new Phrase();
            phead611.Add(new Chunk(detalleTecnico.ToString(), myfontLabel));
            PdfPCell cell611head = new PdfPCell(phead611);
            tableDatos.AddCell(cell611head);

            Phrase phead711 = new Phrase();
            phead711.Add(new Chunk(estado.ToString(), myfontLabel));
            PdfPCell cell711head = new PdfPCell(phead711);
            tableDatos.AddCell(cell711head);

            Phrase phead811 = new Phrase();
            phead811.Add(new Chunk(marca.ToString(), myfontLabel));
            PdfPCell cell811head = new PdfPCell(phead811);
            tableDatos.AddCell(cell811head);

            Phrase phead911 = new Phrase();
            phead911.Add(new Chunk(serie.ToString(), myfontLabel));
            PdfPCell cell911head = new PdfPCell(phead911);
            tableDatos.AddCell(cell911head);

            Phrase phead1011 = new Phrase();
            phead1011.Add(new Chunk(modelo.ToString(), myfontLabel));
            PdfPCell cell1011head = new PdfPCell(phead1011);
            tableDatos.AddCell(cell1011head);

            Phrase phead1111 = new Phrase();
            phead1111.Add(new Chunk(observaciones.ToString(), myfontLabel));
            PdfPCell cell1111head = new PdfPCell(phead1111);
            tableDatos.AddCell(cell1111head);

            tableDatos.WidthPercentage = 100;

            //agregar todo el paquete de texto
            string ServerPath;
            ServerPath = Server.MapPath("");
            string ruta = ServerPath + "\\Logo\\logo.png";

            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(ruta);
            jpg.ScalePercent(30f); //tamaño de imagen en porcentaje
            jpg.Alignment = iTextSharp.text.Image.ALIGN_LEFT;

            document.Add(jpg); //inserta logo

            document.Add(new Paragraph("\n"));
            Paragraph UserName = new Paragraph("Usuario: " + Membership.GetUser().UserName.Trim() + "   Fecha: " + System.DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                myfontLabelCab);
            document.Add(UserName);

            document.Add(new Paragraph("\n"));
            Paragraph P = new Paragraph("ACTA DE INGRESO DE LOS ACTIVOS FIJOS Y BIENES SUJETOS DE CONTROL" + "\n", myfontTitulo);
            P.Alignment = Element.ALIGN_CENTER;

            document.Add(P);
            document.Add(new Paragraph("\n"));

            Paragraph P01 = new Paragraph("ACTA DE LOS ACTIVOS FIJOS Y BIENES SUJETOS DE CONTROL DE LA UNIDAD ADMINISTRATIVA; ENTRE EL SEÑOR(a). " +
                                          cusActivoFijo + ", REPRESENTANTE DE ACTIVOS FIJOS, Y EL(la) SEÑOR(a) " + NuevoCus.ToString() + ", CUSTODIO, AL " + DateTime.Now.ToString("dd-MM-yyyy"), myfont);
            P01.Alignment = Element.ALIGN_JUSTIFIED;
            document.Add(P01);
            document.Add(new Paragraph("\n"));
            Paragraph P02 = new Paragraph("En la ciudad de QUITO, los suscritos señores(a) " + cusActivoFijo +
                                          ", quien entrega los bienes, señor(a) " + NuevoCus.ToString() + ", quien recibe los bienes, con el objeto de realizar la diligencia de entrega – recepción correspondiente. Al efecto con la presencia de las personas mencionadas anteriormente se procede con la constatación física y entrega-recepción de los activos fijos y bienes sujetos de control administrativo, de acuerdo con el siguiente detalle: \n", myfont);
            P02.Alignment = Element.ALIGN_JUSTIFIED;
            document.Add(P02);
            document.Add(new Paragraph("\n"));

            Paragraph P03 = new Paragraph("Lista del inventario de bienes constatados físicamente: \n", myfont);
            P03.Alignment = Element.ALIGN_JUSTIFIED;
            document.Add(P03);

            document.Add(new Paragraph("\n"));

            document.Add(tableDatos);

            document.Add(new Paragraph("\n"));

            Paragraph P3 = new Paragraph("Se deja constancia que el custodio a quien se entrega a satisfacción los bienes se encargará de velar por el buen uso, conservación, administración, utilización, así como que las condiciones sean adecuadas y no se encuentren en riesgo de deterioro de los bienes antes mencionados y confiados a su guarda, de acuerdo con lo que estipula el manual de activos fijos referente al control y administración.", myfont);
            P3.Alignment = Element.ALIGN_JUSTIFIED;
            document.Add(P3);

            document.Add(new Paragraph("\n"));

            Paragraph P41 = new Paragraph("Para Constancia de lo actuado y en fe de conformidad y aceptación, suscriben la presente acta entrega-recepción en tres ejemplares de igual tenor y efecto las personas que intervienen en esta diligencia. \n", myfont);
            P41.Alignment = Element.ALIGN_JUSTIFIED;
            document.Add(P41);

            document.Add(new Paragraph("\n"));


            document.Add(new Paragraph("\n\n", myfont));
            //Tabla para poner firmas
            PdfPTable tableFirma = new PdfPTable(2);

            PdfPCell cellEntrega = new PdfPCell(new Phrase(cusActivoFijo, myfont));
            PdfPCell cellRecibe = new PdfPCell(new Phrase(NuevoCus.ToString(), myfont));
            PdfPCell cellEntrega1 = new PdfPCell(new Phrase(new Chunk("Analista de Activos Fijos.", myfont)));
            PdfPCell cellRecibe1 = new PdfPCell(new Phrase(new Chunk("", myfontbold)));
            PdfPCell cellEntrega2 = new PdfPCell(new Phrase("ENTREGUÉ CONFORME", myfontbold));
            PdfPCell cellRecibe2 = new PdfPCell(new Phrase("RECIBÍ CONFORME", myfont));

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

            mesg = "iok";

            //esto es importante, pues si no cerramos el document entonces no se creara el pdf.
            document.Close();

            string filePath = Path;
            Session["nombredelacta"] = nuevovalor;
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

            mesg = ex.Message;
        }
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

    private void abreVentana(string ventana)
    {
        string funcion = "OpenWindows('" + ventana + "')";
        //string f = "windowOpener('" + ventana + "')";

        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "DICE", funcion, true);
    }

    protected void ibcancel_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Nuevo.aspx");
    }

    protected void ibgr7_Click(object sender, ImageClickEventArgs e)
    {
        cargarUnidades();
        upcar.Update();
    }

    protected void ddtipo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddtipo.SelectedValue == "Activo Fijo" || ddtipo.SelectedValue == "ACTIVO FIJO")
        {
            panNiif.Visible = true;
        }
        else
        {
            panNiif.Visible = false;

            lblvidautil.Text = "0";
            txtvidautilniif.Text = "0";
            txtvalorresniif.Text = "0";
            dateInicioNiif.SelectedDate = null;
        }

        upcontable.Update();
    }

    protected void ddSeguro_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddSeguro.SelectedItem.ToString() == "NO")
        {
            panAseg.Visible = false;
            ddRamo.Items.Clear();
            //cddRamo.SelectedValue = "";
        }
        else
        {
            panAseg.Visible = true;
        }
    }

    protected void btncerrar2_Click(object sender, EventArgs e)
    {
        mp2.Hide();

        txtCatalogo.Text = "";
        txtFechaRecep.Text = "";
        txtSolicitudCompra.Text = "";
        txtCertificacion.Text = "";
        txtContrato.Text = "";

        Session["_cusini"] = "";
        Session["_cusfin"] = "";
        Session["_actidacta"] = "";
        Session["_ubiorg"] = "";
        Session["_ubigeo"] = "";
        Session["_seguro"] = "";
        Session["_nomseguro"] = "";
        Session["_factNum"] = "";
        Session["_msgGActivo"] = "";
    }

    public bool ValidaActa()
    {
        bool val = false;
        if (txtFechaRecep.Text != "" || txtContrato.Text != "" || txtSolicitudCompra.Text != "" || txtCatalogo.Text != "" || txtCertificacion.Text != "")
        {
            val = true;
        }
        else
        {
            val = false;
        }

        if (txtFechaRecep.Text == "")
            val = false;
        else
            val = true;

        return val;
    }


    protected void ddCustodio_Change(object sender, EventArgs e)
    {
        Datos.SqlService sql = new Datos.SqlService();
        DropDownList ddlistList = (DropDownList)sender;
        Object NuevoCusCC = sql.ExecuteSqlObject("select cus_cedula from CUSTODIO where cus_id='" + ddlistList.SelectedValue + "'");
        if (NuevoCusCC != null)
        {
            txtCedulaCustodio.Text = "Cedula: " + NuevoCusCC.ToString();
        }
        else
        {
            txtCedulaCustodio.Text = "Cedula:";
        }

        upcedula.Update();
    }

    protected void txtvalorcompra_OnTextChanged(object sender, EventArgs e)
    {
        lblDebito1.Text = "0.00";
        lblCredito1.Text = decimal.Parse(txtvalorcompra.Text).ToString("#0.00");

        lblCredito2.Text = "0.00";
        lblDebito2.Text = decimal.Parse(txtvalorcompra.Text).ToString("#0.00");

        upAsiento.Update();
    }

    protected void ddUge2_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        Logica.UGEOGRAFICA zet = new Logica.UGEOGRAFICA(Convert.ToInt32(ddUge2.SelectedValue));
        lblOficina2.Text = zet.UGE_CODIGO;
        upAsiento.Update();
    }

    protected void ddUor1_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        Logica.UORGANICA zet = new Logica.UORGANICA(Convert.ToInt32(ddUor1.SelectedValue));
        lblCentroCosto2.Text = zet.UOR_CODIGO;
        upAsiento.Update();
    }
    public int F_TiempoMesesGarantia(DateTime fechaIniGarantia, DateTime fechafinGarantia)
    {
        int meses = fechafinGarantia.Month - fechaIniGarantia.Month + (12 * (fechafinGarantia.Year - fechaIniGarantia.Year));
        return meses;
    }
}
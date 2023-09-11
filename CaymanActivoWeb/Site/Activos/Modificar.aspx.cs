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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using CustomEditors;

public partial class Site_Activos_Modificar : System.Web.UI.Page
{
    ErrorTrapper errtrap;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = ConfigurationManager.AppSettings["Titulo"] + " Buscar/Modificar Activo";
        lblmsg.Text = "";
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

        try
        {

            if (!IsPostBack)
            {
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

                Session["fupload11"] = "";
                Session["fupload22"] = "";
                Session["fupload33"] = "";
                Session["fupload44"] = "";

                ibsave.Attributes.Add("onmouseout", "this.src='../../Img/s1.png'");
                ibsave.Attributes.Add("onmouseover", "this.src='../../Img/s2.png'");
                ibcancel.Attributes.Add("onmouseout", "this.src='../../Img/c1.png'");
                ibcancel.Attributes.Add("onmouseover", "this.src='../../Img/c2.png'");

                cargarUnidades();
                datefechacompra.MaxDate = DateTime.Today;
                cddgru1.ReadOnly = "Si";

                string ide = "";
                ide = Request["id"];
                if (ide != "")
                {
                    if (Logica.HELPER.comprobarIdIngresadoLogikard(ide))
                    {
                        txtbusid.Text = ide;
                        panuevo.Visible = true;
                        cargarActivo("id");
                    }
                }

                string msg = "";
                msg = Request["msg"];
                if (msg == "1")
                {
                    lblmsg.Text = "Item Guardado con éxito!";
                    if (Session["pdfFileName"] != null)
                    {
                        abreVentana("VisualizaPDF.aspx?pdf=yes");//envio pdf para abrirlo en nueva pestaña
                    }
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
        }
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
    protected void rau1_FileUploaded(object sender, FileUploadedEventArgs e)
    {
        try
        {
            foreach (UploadedFile file in rau1.UploadedFiles)
            {
                string nombreok = lblid.Text;

                int i = 1;
                while (File.Exists(Server.MapPath("./imgact/") + nombreok + file.GetExtension()))
                {
                    nombreok = lblid.Text + "_" + i.ToString();
                    i++;
                }

                nombreok = nombreok + file.GetExtension();
                //file.SaveAs(Server.MapPath("./imgact/") + nombreok, false);
                file.SaveAs(Server.MapPath("./im/") + nombreok, false);
                VaryQualityLevel(Server.MapPath("./im/") + nombreok, 80L, Server.MapPath("./imgact/") + nombreok);

                Session["fupload11"] = nombreok;
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
                string nombreok = lblid.Text;

                int i = 1;
                while (File.Exists(Server.MapPath("./imgact/") + nombreok + file.GetExtension()))
                {
                    nombreok = lblid.Text + "_" + i.ToString();
                    i++;
                }

                nombreok = nombreok + file.GetExtension();
                //file.SaveAs(Server.MapPath("./imgact/") + nombreok, false);
                file.SaveAs(Server.MapPath("./im/") + nombreok, false);
                VaryQualityLevel(Server.MapPath("./im/") + nombreok, 80L, Server.MapPath("./imgact/") + nombreok);

                Session["fupload22"] = nombreok;
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
                string nombreok = lblid.Text;

                int i = 1;
                while (File.Exists(Server.MapPath("./imgact/") + nombreok + file.GetExtension()))
                {
                    nombreok = lblid.Text + "_" + i.ToString();
                    i++;
                }

                nombreok = nombreok + file.GetExtension();
                file.SaveAs(Server.MapPath("./imgact/") + nombreok, false);
                Session["fupload33"] = nombreok;
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
                string nombreok = lblid.Text;

                int i = 1;
                while (File.Exists(Server.MapPath("./imgact/") + nombreok + file.GetExtension()))
                {
                    nombreok = lblid.Text + "_" + i.ToString();
                    i++;
                }

                nombreok = nombreok + file.GetExtension();
                file.SaveAs(Server.MapPath("./imgact/") + nombreok, false);
                Session["fupload44"] = nombreok;
            }
        }
        catch (Exception ex)
        {
            errtrap = new ErrorTrapper();
            errtrap.SetOnError("Usuario:" + Membership.GetUser().UserName + "<< " + ex.Message, 0);
        }
    }
    private void abreVentana(string ventana)
    {

        string funcion = "OpenWindows('" + ventana + "')";
        string f = "windowOpener('" + ventana + "')";

        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "SIFEL", f, true);

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
                // upbus.Update();
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
    protected void ibbus1_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            lblmsg.Text = "";

            txtbusid.Text = "";

            if (codigoCorrecto())
            {
                if (Logica.HELPER.comprobarCbIngresado(txtbuscb.Text.Trim()))
                {
                    //cargar datos
                    if (Logica.Mantenimiento.verificaMantenimiento(txtbuscb.Text.Trim()))
                    {
                        panuevo.Visible = false;
                        messbox1.Mensaje = "El Activo actualmente esta en Mantenimiento, no se puede realizar ningun cambio, comuniquese con el Administrador...!!!";
                        messbox1.Tipo = "W";
                        messbox1.showMess();
                    }
                    else
                    {
                        panuevo.Visible = true;
                        cargarActivo("cb");
                    }
                }
                else
                {
                    panuevo.Visible = false;
                    messbox1.Mensaje = "No se puede encontrar Item, aún no ha sido ingresado!";
                    messbox1.Tipo = "I";
                    messbox1.showMess();
                }
            }
            else
            {
                panuevo.Visible = false;
                messbox1.Mensaje = "El Código de Barras No Válido!";
                messbox1.Tipo = "W";
                messbox1.showMess();
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

    public void cargarActivo(string tipo)
    {
        try
        {
            Session["fupload11"] = "";
            Session["fupload22"] = "";
            Session["fupload33"] = "";
            Session["fupload44"] = "";

            Session["ubiini2"] = "";
            Session["cusini2"] = "";
            Session["ubigeo2"] = "";
            Session["ubiorg2"] = "";

            Session["codigoLogikard"] = "";
            Session["_valorcompra"] = "";

            Logica.ACTIVO act = null;

            if (tipo == "cb")
                act = new Logica.ACTIVO(txtbuscb.Text.Trim(), tipo);
            else if (tipo == "cs")
                act = new Logica.ACTIVO(txtbusid.Text.Trim(), tipo);
            else if (tipo == "id")
                act = new Logica.ACTIVO(txtbusid.Text.Trim(), tipo);

            sse.ContextKey = act.Id.ToString();

            lbltipoactivo.Text = act.ACT_TIPO;

            if (act.ACT_TIPO == "Activo Fijo" || act.ACT_TIPO == "ACTIVO FIJO")
            {
                panNiif.Visible = true;
            }
            else
            {
                panNiif.Visible = false;
            }

            if (act.ACT_TIPOBAJA != 0) //SI SE DIO DE BAJA EL ACTIVO
            {
                //desactivo el ddown fase 2 de baja para que no puedan cambiar su estado
                cddest2.ServiceMethod = "GetEstado";
                cddest2.ReadOnly = "Si";

                ibsave.Enabled = false;
                ibsave.ImageUrl = "~/Img/s3.png";

                //habilito panel baja
                panbaja.Visible = true;
                //cargo info de baja
                litbaja.Text = act.ACT_OBSBAJA;
                lblbaja.Text = Logica.HELPER.getRazonBaja(act.ACT_TIPOBAJA);
            }
            else
            {
                cddest2.ServiceMethod = "GetEstado2";
                cddest2.ReadOnly = "";

                ibsave.Enabled = true;
                ibsave.ImageUrl = "~/Img/s1.png";

                //deshabilito panel baja
                panbaja.Visible = false;
                litbaja.Text = "";
                lblbaja.Text = "";
            }

            lblcb.Text = act.ACT_CODBARRAS;
            txtcbpadre.Text = act.ACT_CODBARRASPADRE;
            txtcod1.Text = act.ACT_CODIGO1;

            Session["codigoLogikard"] = act.ACT_CODIGO1;

            lblid.Text = act.Id.ToString();
            lblFechacreacion.Text = act.ACT_FECHACREACION.ToString("dd/MM/yyyy");
            cddgru1.SelectedValue = act.GRU_ID1.ToString();
            cddgru2.SelectedValue = act.GRU_ID2.ToString();
            cddDescrip.SelectedValue = act.GRU_ID3.ToString();

            if (act.ACT_TIPRFID == 1)
            {
                ddTipoTag.Text = "24 Bits";
            }
            else
            {
                ddTipoTag.Text = "32 Bits";
            }


            if (act.ACT_FOTO1 == "nofoto.gif")
            {
                hk1.ImageUrl = "~/Img/img2.png";
                hk1.NavigateUrl = "";
                hk1.ToolTip = "Imagen No Disponible";
            }
            else
            {
                hk1.ImageUrl = "~/Img/img.png";
                hk1.NavigateUrl = "~/Site/Activos/imgact/" + act.ACT_FOTO1;
                Image1.ImageUrl = "../../Site/Activos/imgact/" + act.ACT_FOTO1;
                hk1.ToolTip = "Ver Foto 1";
                Session["fupload11"] = act.ACT_FOTO1;
            }

            if (act.ACT_FOTO2 == "nofoto.gif")
            {
                hk2.ImageUrl = "~/Img/img2.png";
                hk2.NavigateUrl = "";
                hk2.ToolTip = "Imagen No Disponible";
            }
            else
            {
                hk2.ImageUrl = "~/Img/img.png";
                hk2.NavigateUrl = "~/Site/Activos/imgact/" + act.ACT_FOTO2;
                hk2.ToolTip = "Ver Foto 2";
                Session["fupload22"] = act.ACT_FOTO2;
            }

            if (act.ACT_DOC1 == "")
            {
                hk3.ImageUrl = "~/Img/fac2.png";
                hk3.NavigateUrl = "";
                hk3.ToolTip = "Factura No Disponible";
            }
            else
            {
                hk3.ImageUrl = "~/Img/fac.png";
                hk3.NavigateUrl = "~/Site/Activos/imgact/" + act.ACT_DOC1;
                hk3.ToolTip = "Ver Factura";
                Session["fupload33"] = act.ACT_DOC1;
            }

            if (act.ACT_DOC2 == "")
            {
                hk4.ImageUrl = "~/Img/man2.png";
                hk4.NavigateUrl = "";
                hk4.ToolTip = "Manual No Disponible";
            }
            else
            {
                hk4.ImageUrl = "~/Img/man.png";
                hk4.NavigateUrl = "~/Site/Activos/imgact/" + act.ACT_DOC2;
                hk4.ToolTip = "Ver Manual";
                Session["fupload44"] = act.ACT_DOC2;
            }

            hk5.NavigateUrl = "Hfotos.aspx?id=" + lblid.Text;

            cddgeo1.SelectedValue = act.UGE_ID1.ToString();
            cddgeo2.SelectedValue = act.UGE_ID2.ToString();
            cddgeo3.SelectedValue = act.UGE_ID3.ToString();
            cddpiso.SelectedValue = act.UGE_ID4.ToString();

            lblgru.Text = Logica.HELPER.getNombre("grupo", "gru_nombre", act.GRU_ID1.ToString(), "gru_id");
            lblsgru.Text = Logica.HELPER.getNombre("grupo", "gru_nombre", act.GRU_ID2.ToString(), "gru_id");
            lbldesc.Text = Logica.HELPER.getNombre("grupo", "gru_nombre", act.GRU_ID3.ToString(), "gru_id");
            
            lbluge1.Text = Logica.HELPER.getNombre("ugeografica", "uge_nombre", act.UGE_ID1.ToString(), "uge_id");
            lbluge2.Text = Logica.HELPER.getNombre("ugeografica", "uge_nombre", act.UGE_ID2.ToString(), "uge_id");
            lbluge3.Text = Logica.HELPER.getNombre("ugeografica", "uge_nombre", act.UGE_ID3.ToString(), "uge_id");
            lbluge4.Text = Logica.HELPER.getNombre("ugeografica", "uge_nombre", act.UGE_ID4.ToString(), "uge_id");
            
            

            
            cddccosto.SelectedValue = act.UOR_ID1.ToString();
            cdduor1.SelectedValue = act.UOR_ID2.ToString();
            cdduor2.SelectedValue = act.UOR_ID3.ToString();

            lblccosto.Text = Logica.HELPER.getNombre("uorganica", "uor_nombre", act.UOR_ID1.ToString(), "uor_id");
            lbluor1.Text = Logica.HELPER.getNombre("uorganica", "uor_nombre", act.UOR_ID2.ToString(), "uor_id");
            lbluor2.Text = Logica.HELPER.getNombre("uorganica", "uor_nombre", act.UOR_ID3.ToString(), "uor_id");
            
            cddcus.SelectedValue = act.CUS_ID1.ToString();
            //cddResponsable.SelectedValue = act.CUS_ID2.ToString();
            cddcus.ReadOnly = "true";
            cddest1.SelectedValue = act.EST_ID1.ToString();
            cddest2.SelectedValue = act.EST_ID2.ToString();
            cddest3.SelectedValue = act.EST_ID3.ToString();

            Session["ubiini2"] = act.UGE_ID1.ToString() + ";" +
                    act.UGE_ID2.ToString() + ";" +
                    act.UGE_ID3.ToString() + ";" +
                    act.UGE_ID4.ToString() + ";" +
                    act.UOR_ID1.ToString() + ";" +
                    act.UOR_ID2.ToString() + ";" +
                    act.UOR_ID3.ToString() + ";" +
                    act.CUS_ID1.ToString() + ";" +
                    act.EST_ID1.ToString() + ";" +
                    act.EST_ID2.ToString() + ";" +
                    act.EST_ID3.ToString();

            Session["cusini2"] = act.CUS_ID1.ToString();

            Session["ubigeo2"] = act.UGE_ID1.ToString() + ";" +
                act.UGE_ID2.ToString() + ";" +
                act.UGE_ID3.ToString() + ";" +
                act.UGE_ID4.ToString();

            Session["ubiorg2"] = act.UOR_ID1.ToString() + ";" +
                act.UOR_ID2.ToString() + ";" +
                act.UOR_ID3.ToString();

            cddmarca.SelectedValue = act.MAR_ID.ToString();
            cddModelo.SelectedValue = act.MOD_ID.ToString();
            txtserie.Text = act.ACT_SERIE1;
            cddcolor.SelectedValue = act.COL_ID.ToString();

            cddAnio.SelectedValue = act.ACT_ANIO.ToString();

            cddestruc1.SelectedValue = act.ECO_ID1.ToString();
            cddcompo1.SelectedValue = act.ECO_ID2.ToString();
            cddProveedor.SelectedValue = act.PRO_ID.ToString();

            lblingreso.Text = act.ACT_TIPOING;
            txtnumfact.Text = act.ACT_NUMFACT1.ToString();

            datefechacompra.SelectedDate = act.ACT_FECHACOMPRA;
            //lblvalorcompra.Text = "$ " + act.ACT_VALORCOMPRA.ToString().Replace(',', '.') + " USD"; //SI NO SE REQUIERE MODIFICAR VALOR DE COMPRA
            lblvalorcompra.Text = act.ACT_VALORCOMPRA.ToString().Replace(',', '.');
            Session["_valorcompra"] = act.ACT_VALORCOMPRA.ToString().Replace(',', '.');
            lblvidautil.Text = act.ACT_VIDAUTIL.ToString() + " Meses";

            lblvidautilniif.Text = act.ACT_VIDAUTILNIIF.ToString() + " Meses";
            //lblvalresniif.Text = "$ " + act.ACT_VALORRESIDUALNIIF.ToString().Replace(',', '.') + " USD"; //SI NO SE REQUIERE MODIFICAR VALOR DE COMPRA
            lblvalresniif.Text = act.ACT_VALORRESIDUALNIIF.ToString().Replace(',', '.');

            if (act.ACT_DEPRECIABLE) //SI ES DEPRECIABLE NIIF
            {
                if (act.ACT_FECHAINIOPER.Year != 1)
                {
                    lbldateininiif.Text = act.ACT_FECHAINIOPER.ToShortDateString();
                }
            }

            if (act.ACT_DEPRECIADOSRI)
            {
                lbldepresri.Text = "SI";
                hksri.NavigateUrl = "DepreTribu.aspx?id=" + lblid.Text;
                hksri.Visible = true;
                //txtvalorcompra.Enabled = false;
            }
            else
            {
                lbldepresri.Text = "NO";
                hksri.Visible = false;
                //txtvalorcompra.Enabled = true;
            }

            if (act.ACT_DEPRECIADONIIF)
            {
                lbldepreniif.Text = "SI";
                hkniif.NavigateUrl = "Depre.aspx?id=" + lblid.Text;
                hkniif.Visible = true;
                //txtvidautilniif.Enabled = false;
                //txtvalorresniif.Enabled = false;
                //dateInicioNiif.Enabled = false;
            }
            else
            {
                lbldepreniif.Text = "NO";
                hkniif.Visible = false;
                //txtvidautilniif.Enabled = true;
                //txtvalorresniif.Enabled = true;
                //dateInicioNiif.Enabled = true;            
            }

            upcontable.Update();

            if (act.ACT_GARANTIA)
            {
                pangar.Visible = true;
                ddgarantia.SelectedValue = "SI";
                dategarantiavence.SelectedDate = act.ACT_FECHAGARANTIAVENCE;
            }
            else
            {
                pangar.Visible = false;
                dategarantiavence.Clear();
                ddgarantia.SelectedValue = "NO";
            }

            if (act.ACT_SEGURO == "S")
            {
                panAseg.Visible = true;
                ddSeguro.SelectedValue = "SI";
                cddRamo.SelectedValue = act.ACT_TIPOSEGURO.ToString();

                txtNumPoliza.Text = act.ACT_NUMPOLIZA.Trim();
                rdpFechaEmision.SelectedDate = act.ACT_FECHAEMISIONPOLIZA;
                rdpFechaVencimiento.SelectedDate = act.ACT_FECHAVENCEPOLIZA;
                txtValorAsegurado.Text = act.ACT_VALORASEGURADO.ToString().Replace(",", ".");

            }
            else
            {
                panAseg.Visible = false;
                ddSeguro.SelectedValue = "NO";
            }
            
            txtObservaciones.Text = act.ACT_OBSERVACIONES;

            loadCar(act.GRU_ID1.ToString());

            //CARGO CARACTERISTICAS, VALORES Y UNIDADES
            DataSet dscar;

            Logica.CARACTERISTICA car2 = new Logica.CARACTERISTICA();
            dscar = car2.fgetCarXActid2(act.Id.ToString());

            String[] arrcfaid = new string[17];
            arrcfaid = (string[])Session["arrcfaid"];

            foreach (DataRow dsrow in dscar.Tables[0].Rows)
            {
                for (int i = 1; i < 17; i++)
                {
                    if (arrcfaid[i] == dsrow["cfa_id"].ToString())
                    {
                        Telerik.Web.UI.RadTextBox txt = (Telerik.Web.UI.RadTextBox)upcar.FindControl("t" + i.ToString());
                        DropDownList ddl = (DropDownList)upcar.FindControl("d" + i.ToString());

                        txt.Text = dsrow["car_valor"].ToString();
                        ddl.SelectedValue = dsrow["uni_id"].ToString();
                        break;
                    }
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
        }
    }
    private void loadCar(string gruid)
    {
        try
        {
            String[] arrcfaid = new string[17];
            Session["arrcfaid"] = arrcfaid;

            DataTable dt = Logica.HELPER.getCar(gruid);

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
            return false;
        }
    }
    private bool codigoPadreDiffCodHijo()
    {
        if (txtcbpadre.Text.Trim() != lblcb.Text.Trim())
        {
            return true;
        }
        else
        {
            return false;
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
                if (Session["codigoLogikard"].ToString().Trim() != txtcod1.Text.Trim())
                {
                    if (Logica.HELPER.comprobarCodLogikard(txtcod1.Text.Trim()))
                        return false;
                    else
                        return true;
                }
                else
                {
                    return true;
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
            return true;
        }
    }
    protected void ibsave_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (panuevo.Visible)
            {
                if (codigoLogiKardExiste())
                {
                    if (codigoPadreCorrecto())
                    {
                        if (codigoPadreExiste())
                        {
                            if (codigoPadreDiffCodHijo())
                            {
                                Logica.ACTIVO act = new Logica.ACTIVO(int.Parse(lblid.Text));

                                act.USERNAME = Membership.GetUser().UserName.ToLower();

                                act.ACT_CODBARRASPADRE = txtcbpadre.Text;
                                act.ACT_CODIGO1 = txtcod1.Text.Trim();

                                //grupos
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

                                if (Session["fupload11"].ToString().Contains('.'))
                                    act.ACT_FOTO1 = Session["fupload11"].ToString();

                                if (Session["fupload22"].ToString().Contains('.'))
                                    act.ACT_FOTO2 = Session["fupload22"].ToString();

                                if (Session["fupload33"].ToString().Contains('.'))
                                    act.ACT_DOC1 = Session["fupload33"].ToString();

                                if (Session["fupload44"].ToString().Contains('.'))
                                    act.ACT_DOC2 = Session["fupload44"].ToString();

                                if (ddEstado.SelectedValue == "")
                                    act.EST_ID1 = -1;
                                else
                                    act.EST_ID1 = int.Parse(ddEstado.SelectedValue);

                                if (ddFase.SelectedValue == "")
                                    act.EST_ID2 = -1;
                                else
                                {
                                    act.EST_ID2 = int.Parse(ddFase.SelectedValue);

                                    //if (panBaja.Visible)//dar de baja al activo
                                    //{
                                    //    act.ACT_FECHABAJA = DateTime.Now;
                                    //    act.ACT_TIPOBAJA = int.Parse(ddTipoBaja.SelectedValue);
                                    //    act.ACT_OBSBAJA = txtobsbaja.Text;
                                    //}
                                }

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

                                act.ACT_NUMFACT = Int64.Parse(txtnumfact.Text.Trim());

                                if (act.ACT_FECHACOMPRA > System.DateTime.Now)
                                {
                                    messbox1.Mensaje = "La FECHA DE COMPRA no puede ser Mayor que la Fecha Actual...!!!";
                                    messbox1.Tipo = "W";
                                    messbox1.showMess();
                                    return;
                                }
                                else
                                {
                                    act.ACT_FECHACOMPRA = datefechacompra.SelectedDate.Value;
                                }

                                if (ddAnio.SelectedValue == "")
                                    act.ACT_ANIO = -1;
                                else
                                    act.ACT_ANIO = int.Parse(ddAnio.SelectedValue);

                                if (!act.ACT_DEPRECIADONIIF) //SI NO ESTA DEPRECIADO NIIF
                                {

                                    //if (txtvidautilniif.Text.Length > 0)
                                    //{
                                    //    act.ACT_VIDAUTILNIIF = int.Parse(txtvidautilniif.Text);
                                    //}

                                    if (lblvalresniif.Text.Length > 0)
                                    {
                                        act.ACT_VALORRESIDUALNIIF = decimal.Parse(lblvalresniif.Text.Replace(",", "."), System.Globalization.NumberStyles.Currency, new System.Globalization.CultureInfo("en-US"));
                                    }

                                    //if (dateInicioNiif.SelectedDate != null)
                                    //{
                                    //    act.ACT_FECHAINIOPER = dateInicioNiif.SelectedDate.Value;
                                    //    act.ACT_FECHAINIDEPRENIIF = act.calcularFechaIniDepre(act.ACT_FECHAINIOPER);
                                    //}
                                }


                                if (!act.ACT_DEPRECIADOSRI)//SI NO ESTA DEPRECIADO SRI
                                {
                                    act.ACT_VALORCOMPRA = decimal.Parse(lblvalorcompra.Text.Replace(",", "."), System.Globalization.NumberStyles.Currency, new System.Globalization.CultureInfo("en-US"));
                                }
                                else
                                {
                                    if (decimal.Parse(Session["_valorcompra"].ToString().Replace(",", "."), System.Globalization.NumberStyles.Currency, new System.Globalization.CultureInfo("en-US")) != decimal.Parse(lblvalorcompra.Text.Replace(",", "."), System.Globalization.NumberStyles.Currency, new System.Globalization.CultureInfo("en-US")))
                                    {
                                        act.ACT_VALORCOMPRA = decimal.Parse(lblvalorcompra.Text.Replace(",", "."), System.Globalization.NumberStyles.Currency, new System.Globalization.CultureInfo("en-US"));
                                        messbox1.Mensaje = "No se puede cambiar el VALOR DE COMPRA ya que se han Generado Depreciaciones...!!!";
                                        messbox1.Tipo = "W";
                                        messbox1.showMess();
                                        return;
                                    }
                                }

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

                                if (ddSeguro.SelectedItem.Text == "SI")
                                {
                                    act.ACT_SEGURO = "S";
                                    act.ACT_TIPOSEGURO = int.Parse(ddRamo.SelectedValue);

                                    act.ACT_NUMPOLIZA = txtNumPoliza.Text.Trim();
                                    act.ACT_FECHAEMISIONPOLIZA = rdpFechaEmision.SelectedDate.Value;
                                    act.ACT_FECHAVENCEPOLIZA = rdpFechaVencimiento.SelectedDate.Value;
                                    act.ACT_VALORASEGURADO = decimal.Parse(txtValorAsegurado.Text.Replace(",", "."), System.Globalization.NumberStyles.Currency, new System.Globalization.CultureInfo("en-US"));

                                    act.ACT_VIGENCIAPOLIZAMESES = F_TiempoMesesGarantia(rdpFechaEmision.SelectedDate.Value, rdpFechaVencimiento.SelectedDate.Value);
                                }
                                else
                                {
                                    act.ACT_SEGURO = "N";

                                    act.ACT_NUMPOLIZA = "";
                                    act.ACT_FECHAEMISIONPOLIZA = null;
                                    act.ACT_FECHAVENCEPOLIZA = null;
                                    act.ACT_VALORASEGURADO = 0;
                                    act.ACT_VIGENCIAPOLIZAMESES = 0;
                                }

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
                                    Datos.SqlService sql = new Datos.SqlService();
                                    //actualizo
                                    err = act.updActivo();

                                    if (err != "")
                                    {
                                        errtrap = new ErrorTrapper();
                                        errtrap.SetOnError("Usuario:" + Membership.GetUser().UserName + "<< " + err, 0); //1 enviar mail

                                        messbox1.Mensaje = "Error al actualizar el activo. >> " + err;
                                        messbox1.Tipo = "E";
                                        messbox1.showMess();
                                    }
                                    else
                                    {
                                        //modifico inicio de depreciacion si no ha sido genera la depreciacionSRI
                                        if (!act.ACT_DEPRECIADOSRI)
                                        {
                                            //ModDepreciacion(act);
                                        }

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
                                                car.ACT_ID = int.Parse(lblid.Text);
                                                car.CFA_ID = int.Parse(arrcfaid[i]);
                                                car.CAR_VALOR = txt.Text.Trim();

                                                if (!ddl.Visible)
                                                    car.UNI_ID = -1;
                                                else
                                                    car.UNI_ID = int.Parse(ddl.SelectedItem.Value.ToString());

                                                car.Create();
                                            }
                                        }

                                        Object campo4 = sql.ExecuteSqlObject("select DETALLE=stuff((select ', '+(SELECT CFA_NOMBRE FROM CFAMILIA CF WHERE CF.CFA_ID =  A.CFA_ID)+': '+A.CAR_VALOR+ISNULL(U.UNI_SIMBOLO,'') From (caracteristica A LEFT JOIN UNIDAD AS U ON A.UNI_ID= U.UNI_ID) where A.ACT_ID=ACTIVO.act_id for xml path('')),1,1,'') from ACTIVO  WHERE ACTIVO.ACT_ID='" + act.Id + "'");
                                        //registro traslado del activo en historial
                                        string ubifin = "";
                                        string cusfin = "";

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

                                        if (Session["ubiini2"].ToString() != ubifin)
                                        {
                                            string error = "";

                                            //guardo nueva ubicacion y custodio
                                            error = Logica.HELPER.iniTransfer(int.Parse(lblid.Text), Membership.GetUser().UserName.ToLower(), int.Parse(ddUge1.SelectedValue),
                                                int.Parse(ddUge2.SelectedValue),
                                                int.Parse(ddUge3.SelectedValue),
                                                int.Parse(ddPiso.SelectedValue),
                                                int.Parse(ddCcosto.SelectedValue),
                                                int.Parse(ddUor1.SelectedValue),
                                                int.Parse(ddUor2.SelectedValue),
                                                int.Parse(ddCustodio.SelectedValue),
                                                int.Parse(ddEstado.SelectedValue),
                                                int.Parse(ddFase.SelectedValue),
                                                int.Parse(ddTrasnfer.SelectedValue), "TI");

                                            string ubigeo = Session["ubigeo2"].ToString();
                                            string ubiorg = Session["ubiorg2"].ToString();

                                            //guardo asiento contable
                                            //Asientos.TransferenciaActivo(act, ubifin, Session["ubiini2"].ToString());

                                            if (Session["cusini2"].ToString() != cusfin)
                                            {
                                                //2012-02-13 Andrea.-Llamar a función que cree el pdf
                                                CrearPdf(Session["cusini2"].ToString(), cusfin, int.Parse(lblid.Text), ubiorg, ubigeo, "Acta Entrega TI - " + ddCustodio.SelectedItem.Text, campo4);
                                            }
                                            if (error != "")
                                            {
                                                messbox1.Mensaje = "Error al guardar el archivo. >> " + error;
                                                messbox1.Tipo = "E";
                                                messbox1.showMess();
                                            }
                                        }

                                        Session["fupload11"] = "";
                                        Session["fupload22"] = "";
                                        Session["fupload33"] = "";
                                        Session["fupload44"] = "";

                                        Response.Redirect("Modificar.aspx?msg=1");
                                    }
                                }
                                else
                                {
                                    messbox1.Mensaje = "Antes de guardar complete las unidades de las características ingresadas";
                                    messbox1.Tipo = "I";
                                    messbox1.showMess();
                                }

                                //}
                                //else de baja: mensaje dado de baja incluido en la funcion
                            }
                            else
                            {
                                messbox1.Mensaje = "El Activo no puede ser su propio Padre";
                                messbox1.Tipo = "I";
                                messbox1.showMess();
                            }
                        }
                        else
                        {
                            messbox1.Mensaje = "Ingrese primero el Activo Padre antes de ingresar sus componentes, Código Padre aún no ha sido ingresado";
                            messbox1.Tipo = "I";
                            messbox1.showMess();
                        }
                    }
                    else
                    {
                        messbox1.Mensaje = "Codigo de Barras PADRE no válido, por favor corrijalo antes de continuar...";
                        messbox1.Tipo = "W";
                        messbox1.showMess();
                    }
                }
                else
                {
                    messbox1.Mensaje = "El Codigo Secundario ya fue ingresado anteriormente, por favor corrijalo antes de continuar...";
                    messbox1.Tipo = "W";
                    messbox1.showMess();
                }
            }
            else
            {
                messbox1.Mensaje = "No puede guardar el activo si no lo busca primero!";
                messbox1.Tipo = "E";
                messbox1.showMess();
            }
        }
        catch (Exception ex)
        {
            errtrap = new ErrorTrapper();
            errtrap.SetOnError("Usuario:" + Membership.GetUser().UserName + "<< " + ex.Message, 0); //1 enviar mail

            messbox1.Mensaje = "Error. " + ex.Message;
            messbox1.Tipo = "E";
            messbox1.showMess();
        }

    }
    public int F_TiempoMesesGarantia(DateTime fechaIniGarantia, DateTime fechafinGarantia)
    {
        int meses = fechafinGarantia.Month - fechaIniGarantia.Month + (12 * (fechafinGarantia.Year - fechaIniGarantia.Year));
        return meses;
    }
    public void ModDepreciacion(Logica.ACTIVO act)
    {
        using (C5ALIANZAVALLE23102015Entities ent = new C5ALIANZAVALLE23102015Entities())
        {
            var item = ent.DEPRECIACIONSRI.Where(x => x.ACT_ID == act.Id).FirstOrDefault();
            if (item != null)
            {
                item.DEP_SALDOXDEPRE = (act.ACT_VALORCOMPRA - 1) - ((act.ACT_VALORCOMPRA - 1) / act.ACT_VIDAUTIL);
                item.DEP_DEPREACUM = (act.ACT_VALORCOMPRA - 1) / act.ACT_VIDAUTIL;
                item.DEP_DEPREPERIODO = act.ACT_VALORCOMPRA / act.ACT_VIDAUTIL;
                try
                {
                    ent.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw new Exception("Se ha producido un error en el Metodo ModDepreciacion", ex);
                }
            }
        }
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
    protected void ibcancel_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Modificar.aspx");
    }
    protected void ibbus3_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            txtbuscb.Text = "";

            if (Logica.HELPER.comprobarIdIngresado(txtbusid.Text.Trim()))
            {
                //cargar datos
                if (Logica.Mantenimiento.verificaMantenimiento(txtbuscb.Text.Trim()))
                {
                    panuevo.Visible = false;
                    messbox1.Mensaje = "El Activo actualmente esta en Mantenimiento, no se puede realizar ningun cambio, comuniquese con el Administrador...!!!";
                    messbox1.Tipo = "W";
                    messbox1.showMess();
                }
                else
                {
                    panuevo.Visible = true;
                    cargarActivo("cs");
                }
            }
            else
            {
                panuevo.Visible = false;
                messbox1.Mensaje = "No se encontró ningún item con Código = " + txtbusid.Text.Trim();
                messbox1.Tipo = "I";
                messbox1.showMess();
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
    protected void ibgr7_Click(object sender, ImageClickEventArgs e)
    {
        cargarUnidades();
        upcar.Update();
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
    public int F_TotalPDF()
    {

        string folderToBrowse = Server.MapPath("../Traslados/PDF/");
        DirectoryInfo DirInfo = new DirectoryInfo(folderToBrowse);
        FileSystemInfo[] files = DirInfo.GetFileSystemInfos("*.PDF");
        Array.Sort<FileSystemInfo>(files, delegate (FileSystemInfo a, FileSystemInfo b) { return a.LastWriteTime.CompareTo(b.LastWriteTime); });

        DataGrid dt = new DataGrid();

        dt.DataSource = files;
        dt.DataBind();

        int filas = dt.Items.Count;

        return filas;
    }
    private void CrearPdf(string cusini, string cusfin, int act, string ubiorg, string ubigeo, string nombre, Object detalle)
    {
        try
        {
            //int numPDF = F_TotalPDF() + 1;
            //string PDFnum = F_llenaceros(Convert.ToString(numPDF), 4, "0");

            string[] ubiOrg = ubiorg.Split(';');
            string[] ubiGeo = ubigeo.Split(';');

            Datos.SqlService sql = new Datos.SqlService();
            Object NuevoCus = sql.ExecuteSqlObject("select (cus_nombres +' '+ CUS_apellidos) from CUSTODIO where cus_id='" + cusfin + "'");
            Object AnteriorCus = sql.ExecuteSqlObject("select (cus_nombres +' '+ CUS_apellidos) from CUSTODIO where cus_id='" + cusini + "'");
            string TituloReporte = ConfigurationManager.AppSettings["TituloReportes"].ToString();
            Object NuevoCusCC = sql.ExecuteSqlObject("select cus_cedula from CUSTODIO where cus_id='" + cusfin + "'");
            Object AnteriorCusCC = sql.ExecuteSqlObject("select  cus_cedula from CUSTODIO where cus_id='" + cusini + "'");
            String NuevoCi = "";
            object fechacompra = sql.ExecuteSqlObject("select act_fechacompra from activo where act_id=" + act);

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
            Object descrip = sql.ExecuteSqlObject("select g3.gru_nombre AS DESCRIPCION from (ACTIVO left join GRUPO as g3 on activo.gru_id3= g3.gru_id) WHERE ACTIVO.ACT_ID='" + act + "'");

            Object campo1 = sql.ExecuteSqlObject("select ACT_CODBARRAS as CODIGO from ACTIVO WHERE ACTIVO.ACT_ID='" + act + "'");
            Object campo2 = sql.ExecuteSqlObject("select g1.gru_nombre AS SUBTIPO from (ACTIVO  left join GRUPO as g1 on activo.gru_id1= g1.gru_id) WHERE ACTIVO.ACT_ID='" + act + "'");
            Object campo3 = sql.ExecuteSqlObject("select g2.gru_nombre AS CLASE from (ACTIVO left join GRUPO as g2 on activo.gru_id2= g2.gru_id) WHERE ACTIVO.ACT_ID='" + act + "'");

            Object campo5 = sql.ExecuteSqlObject("select e.est_nombre AS ESTADO from (ACTIVO  left join estado as e on activo.est_id1=e.est_id) WHERE ACTIVO.ACT_ID='" + act + "'");
            Object campo6 = sql.ExecuteSqlObject("select mar.mar_nombre AS MARCA  from (ACTIVO  left join marca as mar on activo.mar_id=mar.mar_id) WHERE ACTIVO.ACT_ID='" + act + "'");
            Object campo7 = sql.ExecuteSqlObject("select isnull(act_serie1,'s/n') AS SERIE from (ACTIVO  left join marca as mar on activo.mar_id=mar.mar_id)WHERE ACTIVO.ACT_ID='" + act + "'");
            Object campo8 = sql.ExecuteSqlObject("select mode.mod_nombre AS MODELO from (ACTIVO left join modelo as mode on activo.mod_id=mode.mod_id)WHERE ACTIVO.ACT_ID='" + act + "'");
            Object campo9 = sql.ExecuteSqlObject("select act_observaciones AS OBSERVACIONES from ACTIVO  WHERE ACTIVO.ACT_ID='" + act + "'");
            Object campo10 = sql.ExecuteSqlObject("select ACT_TIPO as TIPO_activo from ACTIVO WHERE ACTIVO.ACT_ID='" + act + "'");
            Object color = sql.ExecuteSqlObject("select isnull(col.col_nombre,'Sin Color') AS COLOR from (ACTIVO  left join COLOR as col on activo.col_id=col.col_id) WHERE ACTIVO.ACT_ID='" + act + "'");

            //EMPIEZA PDF

            //creamos el documento
            //...ahora configuramos para que el tamaño de hoja sea A4
            //Document document = new Document(iTextSharp.text.PageSize.A4);
            Document document = new Document(iTextSharp.text.PageSize.A4, 50, 30, 15, 5);
            //document.PageSize.Rotate();

            //hacemos que se inserte la fecha de creación para el documento
            document.AddCreationDate();

            //...título
            document.AddTitle("ACTA DE ENTREGA RECEPCIÓN POR CAMBIO DE REPONSABLE Y/O UBICACIÓN FÍSICA");

            //... el asunto
            document.AddSubject("ACTA DE ENTREGA RECEPCIÓN");


            //string Path = "c:/" + System.DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss") + "ACTA DE ENTREGA RECEPCIÓN.pdf";
            string Path = Server.MapPath("../TRASLADOS/PDF/") + nombre + " " + System.DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf";

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
            iTextSharp.text.Font myfontTabla = new iTextSharp.text.Font(
            FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.NORMAL));
            iTextSharp.text.Font myfont2 = new iTextSharp.text.Font(
            FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD));
            iTextSharp.text.Font myfont3 = new iTextSharp.text.Font(
            FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD));
            iTextSharp.text.Font myfontTitulo = new iTextSharp.text.Font(
            FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD));
            iTextSharp.text.Font myfontLabel = new iTextSharp.text.Font(
            FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD));
            iTextSharp.text.Font myfontLabelNormal = new iTextSharp.text.Font(
            FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL));
            iTextSharp.text.Font myfontbold = new iTextSharp.text.Font(
            FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD));

            
            //agregar todo el paquete de texto

            string ServerPath;
            ServerPath = Server.MapPath("");
            string ruta = ServerPath + "\\Logo\\logo.png";


            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(ruta);
            jpg.ScalePercent(30f); //tamaño de imagen en porcentaje
            jpg.Alignment = iTextSharp.text.Image.ALIGN_LEFT;
            document.Add(jpg);

            document.Add(new Paragraph("\n"));
            Paragraph P = new Paragraph("TRANSFERENCIAS INTERNAS DE ACTIVOS FIJOS" + "\n", myfontTitulo);
            P.Alignment = Element.ALIGN_CENTER;
            document.Add(P);
            
            document.Add(new Paragraph("\n"));

            PdfPTable tblDatos = new PdfPTable(3);
            tblDatos.DefaultCell.BorderWidth = 0;

            Chunk lblTipoTrans = new Chunk("Tipo Transacción: ", myfontLabel);
            Chunk lblTipoTransval = new Chunk("TRANSFERENCIAS", myfontLabelNormal);
            Chunk lblUsuario = new Chunk("Usuario: ", myfontLabel);
            Chunk lblUsuarioval = new Chunk(Membership.GetUser().UserName.Trim(), myfontLabelNormal);

            Chunk lblReferencia = new Chunk("Referencia: ", myfontLabel);
            Chunk lblReferenciaval = new Chunk(AnteriorCus.ToString().Trim(), myfontLabelNormal);
            Chunk lblOficina = new Chunk("Oficina: ", myfontLabel);
            Chunk lblOficinaval = new Chunk(Ugeo3.ToString().Trim(), myfontLabelNormal);

            Chunk lblFechaContable = new Chunk("Fecha Contable: ", myfontLabel);
            Chunk lblFechaContableval = new Chunk(fechacompra.ToString(), myfontLabelNormal);
            Chunk lblFechaHora = new Chunk("Fecha-Hora: ", myfontLabel);
            Chunk lblFechaHoraval = new Chunk(DateTime.Now.ToString("dd-MM-yyyy") + " " + DateTime.Now.ToString("HH:mm"), myfontLabelNormal);

            Phrase frase1 = new Phrase();
            frase1.Add(lblTipoTrans);
            frase1.Add(lblTipoTransval);
            Phrase frase2 = new Phrase();
            frase2.Add(lblUsuario);
            frase2.Add(lblUsuarioval);
            tblDatos.AddCell(frase1);
            tblDatos.AddCell("");
            tblDatos.AddCell(frase2);

            Phrase frase3 = new Phrase();
            frase3.Add(lblReferencia);
            frase3.Add(lblReferenciaval);
            Phrase frase4 = new Phrase();
            frase4.Add(lblOficina);
            frase4.Add(lblOficinaval);
            tblDatos.AddCell(frase3);
            tblDatos.AddCell("");
            tblDatos.AddCell(frase4);

            Phrase frase5 = new Phrase();
            frase5.Add(lblFechaContable);
            frase5.Add(lblFechaContableval);
            Phrase frase6 = new Phrase();
            frase6.Add(lblFechaHora);
            frase6.Add(lblFechaHoraval);
            tblDatos.AddCell(frase5);
            tblDatos.AddCell("");
            tblDatos.AddCell(frase6);

            tblDatos.WidthPercentage = 100;
            tblDatos.SetWidths(new Single[] { 150, 50, 130 });
            document.Add(tblDatos);

            document.Add(new Paragraph("\n"));

            //de - para
            PdfPTable tblDe_A = new PdfPTable(3);
            tblDe_A.DefaultCell.BorderWidth = 0;
            tblDe_A.AddCell("DE");
            tblDe_A.AddCell("");
            tblDe_A.AddCell("A");

            tblDe_A.WidthPercentage = 100;
            tblDe_A.SetWidths(new Single[] { 50,80,100 });

            document.Add(tblDe_A);

            PdfPTable tblDe_ADatos = new PdfPTable(3);
  
            PdfPCell DeCustodio = new PdfPCell(new Phrase("Custodio: " + AnteriorCus.ToString(), myfont));
            DeCustodio.BorderWidth = 0;
            PdfPCell ACustodio = new PdfPCell(new Phrase("Custodio: " + NuevoCus.ToString(), myfont));
            ACustodio.BorderWidth = 0;

            PdfPCell DeOfi = new PdfPCell(new Phrase("Oficina: " + Ugeo3.ToString(), myfont));
            DeOfi.BorderWidth = 0;
            PdfPCell AOfi = new PdfPCell(new Phrase("Oficina: " + ddUge3.SelectedItem.Text.Trim(), myfont));
            AOfi.BorderWidth = 0;

            PdfPCell DeCCosto = new PdfPCell(new Phrase("Centro Costo: " + Uorg1, myfont));
            DeCCosto.BorderWidth = 0;
            PdfPCell ACCosto = new PdfPCell(new Phrase("Centro Costo: " + ddCcosto.SelectedItem.Text.Trim(), myfont));
            ACCosto.BorderWidth = 0;

            PdfPCell blanco1 = new PdfPCell(new Phrase("", myfont));
            blanco1.BorderWidth = 0;
            PdfPCell blanco2 = new PdfPCell(new Phrase("", myfont));
            blanco2.BorderWidth = 0;
            PdfPCell blanco3 = new PdfPCell(new Phrase("", myfont));
            blanco3.BorderWidth = 0;



            tblDe_ADatos.AddCell(DeCustodio);
            tblDe_ADatos.AddCell(blanco1);
            tblDe_ADatos.AddCell(ACustodio);
            tblDe_ADatos.AddCell(DeOfi);
            tblDe_ADatos.AddCell(blanco2);
            tblDe_ADatos.AddCell(AOfi);
            tblDe_ADatos.AddCell(DeCCosto);
            tblDe_ADatos.AddCell(blanco3);
            tblDe_ADatos.AddCell(ACCosto);

            
            tblDe_ADatos.WidthPercentage = 100;
            tblDe_ADatos.SetWidths(new Single[] { 120, 25, 100 });

            document.Add(tblDe_ADatos);
            document.Add(new Paragraph("\n"));
            document.Add(new Paragraph("\n"));

            //Agregar tabla a Pdf
            PdfPTable table = new PdfPTable(8);

            PdfPCell cell = new PdfPCell(new Phrase("ITEM", myfont3));
            PdfPCell cell1 = new PdfPCell(new Phrase("CODIGO", myfont3));
            PdfPCell cell2 = new PdfPCell(new Phrase("DESCRIPCIÓN", myfont3));
            PdfPCell cell3 = new PdfPCell(new Phrase("TIPOS DE ACTIVO", myfont3));
            PdfPCell cell4 = new PdfPCell(new Phrase("MARCA", myfont3));
            PdfPCell cell5 = new PdfPCell(new Phrase("MODELO", myfont3));
            PdfPCell cell6 = new PdfPCell(new Phrase("SERIE", myfont3));
            PdfPCell cell7 = new PdfPCell(new Phrase("COLOR", myfont3));
            
            cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
            cell1.HorizontalAlignment = 1;
            cell2.HorizontalAlignment = 1;
            cell3.HorizontalAlignment = 1;
            cell4.HorizontalAlignment = 1;
            cell5.HorizontalAlignment = 1;
            cell6.HorizontalAlignment = 1;
            cell7.HorizontalAlignment = 1;

            table.AddCell(cell);
            table.AddCell(cell1);
            table.AddCell(cell2);
            table.AddCell(cell3);
            table.AddCell(cell4);
            table.AddCell(cell5);
            table.AddCell(cell6);
            table.AddCell(cell7);
            table.AddCell(new Paragraph("1", myfontTabla));
            table.AddCell(new Paragraph(campo1.ToString(), myfontTabla));
            table.AddCell(new Paragraph(descrip.ToString(), myfontTabla));
            table.AddCell(new Paragraph(campo2.ToString(), myfontTabla));
            table.AddCell(new Paragraph(campo6.ToString(), myfontTabla));
            table.AddCell(new Paragraph(campo8.ToString(), myfontTabla));
            table.AddCell(new Paragraph(campo7.ToString(), myfont));
            table.AddCell(new Paragraph(color.ToString(), myfontTabla));
            table.WidthPercentage = 100;
            table.SetWidths(new Single[] { 40, 100, 100, 100, 100, 100, 100, 100});


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
            PdfPTable tableFirma = new PdfPTable(3);

            PdfPCell cellEntrega = new PdfPCell(new Phrase("_________________________", myfont));
            PdfPCell cellRecibe = new PdfPCell(new Phrase(AnteriorCus.ToString(), myfont));
            PdfPCell cellAutorizado = new PdfPCell(new Phrase(NuevoCus.ToString(), myfont));
            PdfPCell cellEntrega1 = new PdfPCell(new Phrase("", myfont));
            PdfPCell cellRecibe1 = new PdfPCell(new Phrase("", myfont));
            PdfPCell cellAutorizado1 = new PdfPCell(new Phrase("", myfont));
            PdfPCell cellEntrega2 = new PdfPCell(new Phrase("ADMINISTRADOR DE A.F.", myfont2));
            PdfPCell cellRecibe2 = new PdfPCell(new Phrase("ENTREGADO", myfont2));
            PdfPCell cellAutorizado2 = new PdfPCell(new Phrase("RECIBIDO", myfont2));

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
        catch (Exception ex)
        {
            errtrap = new ErrorTrapper();
            errtrap.SetOnError("Usuario:" + Membership.GetUser().UserName + "<< " + ex.Message, 0);
            messbox1.Mensaje = "Error. " + ex.Message;
            messbox1.Tipo = "E";
            messbox1.showMess();
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
    protected void ddSeguro_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddSeguro.SelectedItem.ToString() == "NO")
        {
            panAseg.Visible = false;
        }
        else
        {
            panAseg.Visible = true;
        }
    }
    
    protected void ddCustodio_Change(object sender, EventArgs e)
    {
        Datos.SqlService sql = new Datos.SqlService();
        DropDownList ddlistList = (DropDownList)sender;
        Object NuevoCusCC = sql.ExecuteSqlObject("select cus_cedula from CUSTODIO where cus_id='" + ddlistList.SelectedValue + "'");
        if (NuevoCusCC != null)
        {
            txtCedulaCustodio.Text = "Cedula: "  + NuevoCusCC.ToString();    
        }
        else
        {
            txtCedulaCustodio.Text = "Cedula:";
        }
        
        upcedula.Update();
    }

    protected void ibpdf1_Click(object sender, ImageClickEventArgs e)
    {
        FichaActivo fichaActivo = new FichaActivo(Server);
        try
        {
            string nombreArchivo = fichaActivo.F_CrearPdf(int.Parse(lblid.Text));
            Session["pdfFileName"] = nombreArchivo;
            abreVentana("VisualizaPDF.aspx?pdf=yes");
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

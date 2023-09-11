using System;
using System.Web.UI;
using System.IO;
using System.Configuration;
using System.Data;
using Telerik.Web.UI;
using System.Web.Security;


public partial class Ing_RenovacionMan : System.Web.UI.Page
{
    ErrorTrapper errtrap;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = ConfigurationManager.AppSettings["Titulo"] + " Registro de Mantenimiento";

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

            ibsave.Attributes.Add("onmouseout", "this.src='../../../Img/s1.png'");
            ibsave.Attributes.Add("onmouseover", "this.src='../../../Img/s2.png'");
            ibcancel.Attributes.Add("onmouseout", "this.src='../../../Img/c1.png'");
            ibcancel.Attributes.Add("onmouseover", "this.src='../../../Img/c2.png'");

            pnl_Mantenimiento.Visible = false;
            panFechaMant.Visible = false;
            Pan_UgeUor.Visible = false;

        }

        string ide = Request["id"];
        if (ide != null)
        {
            //pantras.Visible = true;
            txtbusid.Text = ide;
            cargarActivo(ide, "id");
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
        Session["Mant"] = "";

        try
        {
            txtbusid.Text = "";
            DataTable dt = new DataTable();

            if (codigoCorrecto())
            {
                if (Logica.HELPER.comprobarCbIngresado(txtbuscb.Text))
                {

                    if (Logica.HELPER.VerificaTipoBien(txtbuscb.Text.Trim()))
                    {

                        //cargar datos

                        dt = Logica.HELPER.getVerificaExisteMantRegistrado(txtbuscb.Text.Trim(), "", 1);

                        if (dt.Rows.Count > 0)
                        {
                            messbox1.Mensaje = "No se puede Ingresar Mantenimiento ya fue Registrado...!!!";
                            messbox1.Tipo = "W";
                            messbox1.showMess();
                            Session["Mant"] = "si";
                        }
                        else
                        {
                            CargarUbiGEOUOR("", "cb");
                            pnl_Mantenimiento.Visible = true;
                            Pan_UgeUor.Visible = true;
                            chboxTipoMant.Items[0].Enabled = false;
                        }
                    }
                    else
                    {
                        messbox1.Mensaje = "No se puede Realizar Mantenimiento a un Bien de Control...!!!";
                        messbox1.Tipo = "W";
                        messbox1.showMess();

                        pnl_Mantenimiento.Visible = false;
                        Pan_UgeUor.Visible = false;
                    }
                }
                else
                {

                    pnl_Mantenimiento.Visible = false;
                    Pan_UgeUor.Visible = false;
                    messbox1.Mensaje = "Código Válido, pero aún no ha sido ingresado!";
                    messbox1.Tipo = "I";
                    messbox1.showMess();

                }
            }
            else
            {
                messbox1.Mensaje = "El Código de Barras No es Válido!";
                messbox1.Tipo = "W";
                messbox1.showMess();

                pnl_Mantenimiento.Visible = false;
                Pan_UgeUor.Visible = false;
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
    protected void ibbus3_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            txtbuscb.Text = "";
            DataTable dt = new DataTable();

            if (Logica.HELPER.VerificaTipoBienSerie(txtbusid.Text.Trim()))
            {
                dt = Logica.HELPER.getVerificaExisteMantRegistrado("", txtbusid.Text.Trim(), 2);

                if (dt.Rows.Count > 0)
                {
                    messbox1.Mensaje = "No se puede Ingresar Mantenimiento ya fue Registrado...!!!";
                    messbox1.Tipo = "W";
                    messbox1.showMess();
                    Session["Mant"] = "si";
                }
                else
                {
                    CargarUbiGEOUOR("", "s");
                    pnl_Mantenimiento.Visible = true;
                    Pan_UgeUor.Visible = true;
                    chboxTipoMant.Items[0].Enabled = false;
                }
            }
            else
            {
                messbox1.Mensaje = "No se puede Realizar Mantenimiento a un Bien de Control...!!!";
                messbox1.Tipo = "W";
                messbox1.showMess();

                pnl_Mantenimiento.Visible = false;
                Pan_UgeUor.Visible = false;

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
    public void CargarUbiGEOUOR(string cod, string tipo)
    {

        DataTable dtItem = new DataTable();

        if (tipo == "cb")
            dtItem = Logica.HELPER.getDescripItemMant(txtbuscb.Text.Trim(), "", 1);
        else if (tipo == "s")
            dtItem = Logica.HELPER.getDescripItemMant("", txtbusid.Text.Trim(), 2);

        if (dtItem.Rows.Count > 0)
        {
            lbl_Grupo.Text = dtItem.Rows[0][0].ToString();
            lbl_Subgrupo.Text = dtItem.Rows[0][1].ToString();
            lbl_Descripcion.Text = dtItem.Rows[0][2].ToString();
            lbl_UbGeo1.Text = dtItem.Rows[0][3].ToString();
            lbl_UbiGeo2.Text = dtItem.Rows[0][4].ToString();
            lbl_UbiGeo3.Text = dtItem.Rows[0][5].ToString();
            lbl_ceCosto.Text = dtItem.Rows[0][6].ToString();
            lbl_UbiOrg.Text = dtItem.Rows[0][7].ToString();
            lbl_custodio.Text = dtItem.Rows[0][9].ToString();

            lblid.Text = dtItem.Rows[0][10].ToString();
            lblCodBarras.Text = dtItem.Rows[0][11].ToString();
            lblValorCompra.Text = dtItem.Rows[0][12].ToString();

            Pan_UgeUor.Visible = true;
            pnl_Mantenimiento.Visible = true;

        }
        else
        {
            pnl_Mantenimiento.Visible = false;
            Pan_UgeUor.Visible = false;

        }
    }
    public void cargarActivo(string cod, string tipo)
    {
        try
        {
            //rgtras.DataSource = Logica.HELPER.getMantenimiento(cod, tipo);
            //rgtras.DataBind();


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
        Response.Redirect("~/Site/Mantenimiento/ReporteMan.aspx");
    }
    protected void ibsave_Click(object sender, ImageClickEventArgs e)
    {

        if (F_VerificaTipoMant())
        {
            if (Session["Mant"].ToString() == "si")
            {

                messbox1.Mensaje = "Mantenimiento ya fue Asignado...!!!";
                messbox1.Tipo = "W";
                messbox1.showMess();

            }

            else
            {

                if (Guardar())
                {
                    pnl_Mantenimiento.Visible = false;
                    Pan_UgeUor.Visible = false;

                    messbox1.Mensaje = "Mantenimiento Generado con Éxito...!!!";
                    messbox1.Tipo = "S";
                    messbox1.showMess();
                }
                else
                {
                    messbox1.Mensaje = "Error al Generar Mantenimiento, Comuniquese con el Administrador...!!!";
                    messbox1.Tipo = "E";
                    messbox1.showMess();
                }
            }
        }
        else
        {
            messbox1.Mensaje = "Por favor Seleccione un Tipo de Mantenimiento...!!!";
            messbox1.Tipo = "W";
            messbox1.showMess();
        }
    }
    public bool VerificaTipoMantenimiento()
    {
        bool x = true;

        if (chboxTipoMant.Items[0].Selected == false && chboxTipoMant.Items[1].Selected == false)
        {
            x = false;
        }
        else
        {
            x = true;
        }

        return x;
    }
    public void F_limpiar()
    {
        chboxTipoMant.ClearSelection();

        //panFechaProx.Enabled = false;

        pnl_Mantenimiento.Visible = false;
        Pan_UgeUor.Visible = false;


    }
    public DateTime F_CalculaFechaMant(DateTime fecha)
    {

        if (rblPorMeses.SelectedValue == "M")
        {
            fecha = rdpFechaMant.SelectedDate.Value.AddMonths(1);
        }
        else if (rblPorMeses.SelectedValue == "T")
        {
            fecha = rdpFechaMant.SelectedDate.Value.AddMonths(3);
        }
        else if (rblPorMeses.SelectedValue == "S")
        {
            fecha = rdpFechaMant.SelectedDate.Value.AddMonths(6);
        }
        else if (rblPorMeses.SelectedValue == "A")
        {
            fecha = rdpFechaMant.SelectedDate.Value.AddYears(1);
        }

        return fecha;

    }
    public bool Guardar()
    {

        bool guardar = false;

        try
        {

            string MAN_FORMA = "";
            int TIP_ID_CORRECTIVO = 0;
            int TIP_ID_PREVENTIVO = 0;
            DateTime MAN_FECHAPROXINI = new DateTime(1900, 01, 01);
            DateTime MAN_FECHAPROXFIN = new DateTime(1900, 01, 01);
            string MAN_PORMESES = "";
            int MAN_COBERTURA = 0;
            string MAN_MODALIDAD = "";

            MAN_FORMA = ddFormaMant.SelectedValue;

            if (chboxTipoMant.Items[0].Selected == true)
            {
                TIP_ID_CORRECTIVO = int.Parse(chboxTipoMant.Items[0].Value);
            }
            else
            {
                TIP_ID_CORRECTIVO = 0;
            }

            if (chboxTipoMant.Items[1].Selected == true)
            {
                TIP_ID_PREVENTIVO = int.Parse(chboxTipoMant.Items[1].Value);
                MAN_FECHAPROXINI = rdpFechaMant.SelectedDate.Value;

                MAN_FECHAPROXFIN = F_CalculaFechaMant(rdpFechaMant.SelectedDate.Value);

                MAN_PORMESES = rblPorMeses.SelectedValue;
            }
            else
            {
                TIP_ID_PREVENTIVO = 0;
            }


            MAN_COBERTURA = int.Parse(ddCobertura.SelectedValue);

            if (ddModalidad.SelectedValue == "3")
            {
                MAN_MODALIDAD = txtModalidad.Text.Trim();
            }
            else
            {
                MAN_MODALIDAD = ddModalidad.SelectedItem.Text.Trim();
            }

            DateTime fechamantcorrectivo = new DateTime(1900, 01, 01);
            DateTime fechamantreal = new DateTime(1900, 01, 01);
            DateTime fechaenviomant = new DateTime();
            DateTime fecharegresomant = new DateTime();


            Logica.HELPER.insMantenimientoIniPrevent(
                         "",
                         TIP_ID_CORRECTIVO,
                         TIP_ID_PREVENTIVO,
                         Membership.GetUser().UserName,
                         fechamantcorrectivo,
                         int.Parse(lblid.Text.Trim()),
                         1,
                         MAN_FECHAPROXINI,
                         0,
                         "",
                         MAN_FORMA,
                         MAN_COBERTURA,
                         MAN_MODALIDAD,
                         MAN_PORMESES,
                         "A",
                         MAN_FECHAPROXFIN,
                         fechamantreal
                         );

            guardar = true;
        }
        catch (System.Exception ex)
        {
            messbox1.Mensaje = ex.Message;
            messbox1.Tipo = "E";
            messbox1.showMess();

        }
        return guardar;

    }
    public DateTime F_CalculaFechaMant(string tipo, DateTime fecha)
    {

        if (tipo.Trim() == "M")
        {
            fecha = fecha.AddMonths(1);
        }
        else if (tipo.Trim() == "T")
        {
            fecha = fecha.AddMonths(3);
        }
        else if (tipo.Trim() == "S")
        {
            fecha = fecha.AddMonths(6);
        }
        else if (tipo.Trim() == "A")
        {
            fecha = fecha.AddYears(1);
        }

        return fecha;

    }
    public bool F_VerificaFechaGuardar()
    {
        bool x = false;

        Session["verificafecha"] = x;

        return x;

    }
    public bool F_VerificaTipoMant()
    {

        if (chboxTipoMant.Items[0].Selected == false && chboxTipoMant.Items[1].Selected == false)
        {
            return false;
        }
        else
        {
            return true;
        }


    }
    protected void chboxTipoMant_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (chboxTipoMant.Items[1].Selected == true)
        {
            panFechaMant.Visible = true;
        }
        else
        {
            panFechaMant.Visible = false;
            rblPorMeses.ClearSelection();
            rdpFechaMant.Clear();

        }

        upFechaMant.Update();
    }
    protected void ddModalidad_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddModalidad.SelectedValue == "3")
        {
            txtModalidad.Visible = true;
        }
        else
        {
            txtModalidad.Visible = false;
            txtModalidad.Text = "";
        }
    }
}

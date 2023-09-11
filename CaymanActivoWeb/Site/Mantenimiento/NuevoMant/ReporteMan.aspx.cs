using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using iTextSharp.text;
using iTextSharp.text.pdf;

public partial class ReporteMan : System.Web.UI.Page
{
    ErrorTrapper errtrap;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = ConfigurationManager.AppSettings["Titulo"] + " Reporte de Mantenimiento";

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

            txtCodUltimatix.Attributes.Add("onkeypress", "return isNumberKey(event);");

            pnl_Mantenimiento.Visible = false;
            Pan_UgeUor.Visible = false;

            rbCodigoBarras.Checked = true;
            txtserie.Visible = false;
            ibbus4.Visible = false;
            ddMarca.Visible = false;
            ddModelo.Visible = false;
            ibbus5.Visible = false;
            txtcodSecundario.Visible = false;
            ibbus6.Visible = false;
            //dp_FechaRealizacion.SelectedDate = System.DateTime.Now;
            dp_FechaRealizacion.Enabled = false;
            //dp_ProxMant.SelectedDate = System.DateTime.Now;

        }

        string ide = Request["id"];
        if (ide != null)
        {
            //pantras.Visible = true;
            //txtbusid.Text = ide;
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
        try
        {
            //txtbusid.Text = "";

            if (codigoCorrecto())
            {
                if (Logica.HELPER.comprobarCbIngresado(txtbuscb.Text))
                {
                    if (Logica.Mantenimiento.verificaMantenimiento(txtbuscb.Text.Trim()))
                    {
                        pnl_Mantenimiento.Visible = false;
                        Pan_UgeUor.Visible = false;
                        pantras.Visible = false;

                        panReporte.Visible = false;
                        upman.Visible = false;
                        messbox1.Mensaje = "El Activo actualmente esta en Mantenimiento, no se puede realizar ningun cambio, comuniquese con el Administrador...!!!";
                        messbox1.Tipo = "W";
                        messbox1.showMess();
                    }
                    else
                    {
                        if (Logica.HELPER.VerificaTipoBien(txtbuscb.Text))
                        {
                            //cargar datos

                            CargarUbiGEOUOR(txtbuscb.Text.Trim(), 1);

                            if (Logica.HELPER.VerificaDepreciaciones(int.Parse(lblid.Text.Trim()), "") == "iok")
                            {

                                messbox1.Mensaje = "No se puede Enviar a Mantenimiento a un Bien Dado de Baja...!!!";
                                messbox1.Tipo = "W";
                                messbox1.showMess();

                                pnl_Mantenimiento.Visible = false;
                                Pan_UgeUor.Visible = false;
                                pantras.Visible = false;

                                panReporte.Visible = false;
                                upman.Visible = false;
                            }

                            else
                            {
                                CargarUltimoMantenimiento(lblid.Text.Trim());

                                cargarActivo(txtbuscb.Text, "1");

                                panDatosActa.Visible = false;
                            }
                        }

                        else
                        {
                            messbox1.Mensaje = "No se puede Realizar Mantenimiento a un Bien de Control...!!!";
                            messbox1.Tipo = "W";
                            messbox1.showMess();

                            pnl_Mantenimiento.Visible = false;
                            Pan_UgeUor.Visible = false;
                            pantras.Visible = false;

                            panReporte.Visible = false;
                            upman.Visible = false;

                        }
                    }
                }
                else
                {
                    pantras.Visible = false;
                    pnl_Mantenimiento.Visible = false;
                    Pan_UgeUor.Visible = false;
                    messbox1.Mensaje = "Código Válido, pero aún no ha sido ingresado!";
                    messbox1.Tipo = "I";
                    messbox1.showMess();
                    rgtras.DataSource = null;
                    rgtras.DataBind();
                }
            }
            else
            {
                messbox1.Mensaje = "El Código de Barras No es Válido!";
                messbox1.Tipo = "W";
                messbox1.showMess();
                rgtras.DataSource = null;
                rgtras.DataBind();
                pantras.Visible = false;
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

    public void CargarUbiGEOUOR(string cod, int op)
    {

        DataTable dtItem = new DataTable();

        dtItem = Logica.HELPER.getDescripItemMant(cod, "", op);

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
            //lblCodEmpresa.Text = dtItem.Rows[0][13].ToString();
            lblCus.Text = dtItem.Rows[0][13].ToString();
            lblTipo.Text = dtItem.Rows[0][14].ToString();

            Pan_UgeUor.Visible = true;
            pnl_Mantenimiento.Visible = true;
            //pantras.Visible = true;
        }
        else
        {
            pnl_Mantenimiento.Visible = false;
            Pan_UgeUor.Visible = false;
            pantras.Visible = false;
        }
    }
    public void F_MantenimientoCorrectivo()
    {

        Datos.SqlService sql = new Datos.SqlService();
        DataTable dt = new DataTable();
        Session["errorCorrectivo"] = "";

        sql.AddParameter("@codigo", SqlDbType.Int, int.Parse(lblid.Text.Trim()));
        dt = sql.ExecuteSPDataTable("ArranqueMantCorrectivo");

        double valormant = 0;

        if (txtvalorMant.Text != "")
        {
            valormant = double.Parse(txtvalorMant.Text.Trim().Replace(",", "."));
        }
        else
        {
            valormant = 0;
        }

        if (dt.Rows.Count > 0)//existe ya ingresados mantenimiento correctivo
        {
            string tip_id_preventivo = dt.Rows[0][3].ToString();
            string man_fechaproxini = dt.Rows[0][8].ToString();
            if (man_fechaproxini == "" || man_fechaproxini == null)
            {
                man_fechaproxini = "01/01/0001";
            }
            string man_forma = dt.Rows[0][11].ToString();
            string man_cobertura = dt.Rows[0][12].ToString();
            if (man_cobertura == "" || man_cobertura == null)
            {
                man_cobertura = "0";
            }
            string man_modalidad = dt.Rows[0][13].ToString();
            string man_pormeses = dt.Rows[0][14].ToString();
            string man_fechaproxfin = dt.Rows[0][16].ToString();
            if (man_fechaproxfin == "" || man_fechaproxfin == null)
            {
                man_fechaproxfin = "01/01/0001";
            }
            string man_fecharealmant = dt.Rows[0][17].ToString();
            if (man_fecharealmant == "" || man_fecharealmant == null)
            {
                man_fecharealmant = "01/01/0001";
            }

            if (dp_FechaReIngreso.Text == "")
            {
                dp_FechaReIngreso.Text = "01/01/0001";
            }

            try
            {
                Logica.HELPER.insMantenimiento(txtDescripMantCorrectivo.Text.Trim(),
                    1,
                    int.Parse(tip_id_preventivo),
                    Membership.GetUser().UserName.ToString(),
                                               System.DateTime.Now,
                                               int.Parse(lblid.Text.Trim()),
                                               1,
                                               Convert.ToDateTime(man_fechaproxini),
                                               valormant,
                                               "",
                                               man_forma,
                                               int.Parse(man_cobertura),
                                               man_modalidad,
                                               man_pormeses,
                                               "M",
                                               Convert.ToDateTime(man_fechaproxfin),
                                               Convert.ToDateTime(man_fecharealmant),
                                               "M",
                                               Convert.ToDateTime(dp_FechaRealizacion.Text.Trim()),
                                               Convert.ToDateTime(dp_FechaReIngreso.Text.Trim()));

                F_EnviaHistoricoMovimientos("MC");

                CrearPdf(int.Parse(lblid.Text.Trim()), "EnvioMantenimiento - ");

                F_limpiar();

                messbox1.Mensaje = "Envio a Mantenimiento Correctivo, realizado con Éxito...!!!";
                messbox1.Tipo = "S";
                messbox1.showMess();

            }
            catch (System.Exception ex)
            {
                F_limpiar();
                messbox1.Mensaje = ex.Message + ", Comuniquese con el Administrador...!!!";
                messbox1.Tipo = "E";
                messbox1.showMess();
            }
        }
        else //si no existe ningun tipo de mantenimiento correctivo o preventivo
        {
            try
            {
                Logica.HELPER.insMantenimiento(txtDescripMantCorrectivo.Text.Trim(),
                    1,
                    0,
                    Membership.GetUser().UserName.ToString(),
                                               System.DateTime.Now,
                                               int.Parse(lblid.Text.Trim()),
                                               1,
                                               Convert.ToDateTime("01/01/0001"),
                                               valormant,
                                               "",
                                               "",
                                               0,
                                               "",
                                               "",
                                               "M",
                                               Convert.ToDateTime("01/01/0001"),
                                               Convert.ToDateTime("01/01/0001"),
                                               "M",
                                               Convert.ToDateTime(dp_FechaRealizacion.Text.Trim()),
                                               Convert.ToDateTime(dp_FechaReIngreso.Text.Trim()));

                F_EnviaHistoricoMovimientos("MC");

                CrearPdf(int.Parse(lblid.Text.Trim()), "EnvioMantenimiento - ");

                F_limpiar();

                messbox1.Mensaje = "Envio a Mantenimiento Correctivo, realizado con Éxito...!!!";
                messbox1.Tipo = "S";
                messbox1.showMess();
            }
            catch (System.Exception ex)
            {
                F_limpiar();

                messbox1.Mensaje = ex.Message + ", Comuniquese con el Administrador...!!!";
                messbox1.Tipo = "E";
                messbox1.showMess();
            }
        }
    }
    public void F_MantenimientoPreventivo()
    {


        if (chboxTipoMant.Items[1].Selected == true)
        {


            Datos.SqlService sql = new Datos.SqlService();
            DataTable dt = new DataTable();
            Session["errorCorrectivo"] = "";

            sql.AddParameter("@codigo", SqlDbType.Int, int.Parse(lblid.Text.Trim()));
            dt = sql.ExecuteSPDataTable("ArranqueMantPreventivo");

            double valormant = 0;

            if (txtvalorMant.Text != "")
            {
                valormant = double.Parse(txtvalorMant.Text.Trim().Replace(",", "."));
            }
            else
            {
                valormant = 0;
            }

            if (dt.Rows.Count > 0)//existe ya ingresados mantenimiento preventivo
            {
                if (dt.Rows[0][3].ToString() != "0")
                {

                    string tip_id_correctivo = dt.Rows[0][2].ToString();
                    string tip_id_preventivo = dt.Rows[0][3].ToString();
                    string man_fecha = dt.Rows[0][5].ToString();
                    string man_fechaproxini = lblFechaFinMant.Text;
                    if (man_fechaproxini == "" || man_fechaproxini == null)
                    {
                        man_fechaproxini = "01/01/0001";
                    }
                    string man_forma = dt.Rows[0][11].ToString();
                    string man_cobertura = dt.Rows[0][12].ToString();
                    if (man_cobertura == "" || man_cobertura == null)
                    {
                        man_cobertura = "0";
                    }
                    string man_modalidad = dt.Rows[0][13].ToString();
                    string man_pormeses = dt.Rows[0][14].ToString();
                    DateTime man_fechaproxfin = F_CalculaFechaMant(Session["PorMeses"].ToString(), Convert.ToDateTime(man_fechaproxini));
                    if (man_fechaproxfin == null)
                    {
                        man_fechaproxfin = Convert.ToDateTime("01/01/0001");
                    }
                    DateTime man_fecharealmant = new DateTime();
                    if (dp_FechaRealMant.Enabled == true)
                    {
                        man_fecharealmant = dp_FechaRealMant.SelectedDate.Value;
                    }
                    else
                    {
                        man_fecharealmant = Convert.ToDateTime("01/01/0001");
                    }

                    DateTime act_fechaenviomant = new DateTime();

                    if (dt.Rows[0][18].ToString() == "")
                        act_fechaenviomant = Convert.ToDateTime("01/01/0001");
                    else
                        act_fechaenviomant = Convert.ToDateTime(dt.Rows[0][18].ToString());



                    DateTime act_fecharegresomant = new DateTime();
                    if (dt.Rows[0][19].ToString() == "")
                        act_fecharegresomant = Convert.ToDateTime("01/01/0001");
                    else
                        act_fecharegresomant = Convert.ToDateTime(dt.Rows[0][19].ToString());


                    try
                    {
                        Logica.HELPER.insMantenimiento(txtDescripMantPreventivo.Text.Trim(),
                            int.Parse(tip_id_correctivo),
                            int.Parse(tip_id_preventivo),
                            Membership.GetUser().UserName.ToString(),
                                                       Convert.ToDateTime(man_fecha),
                                                       int.Parse(lblid.Text.Trim()),
                                                       1,
                                                       Convert.ToDateTime(man_fechaproxini),
                                                       valormant,
                                                       "",
                                                       man_forma,
                                                       int.Parse(man_cobertura),
                                                       man_modalidad,
                                                       man_pormeses,
                                                       "M",
                                                       Convert.ToDateTime(man_fechaproxfin),
                                                       Convert.ToDateTime(man_fecharealmant),
                                                       "M",
                                                       act_fechaenviomant,
                                                       act_fecharegresomant);

                        F_EnviaHistoricoMovimientos("MP");

                        F_limpiar();

                        messbox1.Mensaje = "Envio a Mantenimiento Preventivo, realizado con Éxito...!!!";
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
            }
        }

    }
    public void CargarUltimoMantenimiento(string cod)
    {
        DataTable dt = new DataTable();
        int mantpreventivo = 0;
        Session["PorMeses"] = "";
        Session["fechamantfin"] = "";
        Session["fecharealmant"] = "";
        Session["tip_id_preventivo"] = "";

        dt = Logica.HELPER.getArranqueMantenimientos(cod);

        if (dt.Rows.Count > 0)
        {
            mantpreventivo = int.Parse(dt.Rows[0][1].ToString());
            Session["tip_id_preventivo"] = mantpreventivo;
            Session["PorMeses"] = dt.Rows[0][2].ToString();


            if (mantpreventivo != 0)
            {
                chboxTipoMant.Items[1].Selected = true;
                chboxTipoMant.Items[1].Enabled = false;

                RadDatePicker dp_ProxMantIni = new RadDatePicker();
                dp_ProxMantIni.MinDate = Convert.ToDateTime("1900-01-01");
                RadDatePicker dp_ProxMantFin = new RadDatePicker();
                dp_ProxMantFin.MinDate = Convert.ToDateTime("1900-01-01");



                dp_ProxMantIni.SelectedDate = Convert.ToDateTime(dt.Rows[0][3].ToString());
                lblFechaIniMant.Text = dp_ProxMantIni.SelectedDate.Value.ToShortDateString();


                if (dt.Rows[0][11].ToString() != "")
                {
                    Session["fecharealmant"] = Convert.ToDateTime(dt.Rows[0][11].ToString());
                }
                else
                {
                    Session["fecharealmant"] = Convert.ToDateTime("1900-01-01");
                }

                if (lblFechaIniMant.Text.Trim() == System.DateTime.Now.ToShortDateString())
                {
                    chboxFechaRealMant.Checked = false;
                    chboxFechaRealMant.Enabled = false;
                }
                else
                {
                    chboxFechaRealMant.Enabled = true;
                }

                if (dt.Rows[0][2].ToString().Trim() == "M")
                {
                    dp_ProxMantFin.SelectedDate = dp_ProxMantIni.SelectedDate.Value.AddMonths(1);
                    lblFechaFinMant.Text = dp_ProxMantFin.SelectedDate.Value.ToShortDateString();

                }
                else if (dt.Rows[0][2].ToString().Trim() == "T")
                {
                    dp_ProxMantFin.SelectedDate = dp_ProxMantIni.SelectedDate.Value.AddMonths(3);
                    lblFechaFinMant.Text = dp_ProxMantFin.SelectedDate.Value.ToShortDateString();
                }
                else if (dt.Rows[0][2].ToString().Trim() == "S")
                {
                    dp_ProxMantFin.SelectedDate = dp_ProxMantIni.SelectedDate.Value.AddMonths(6);
                    lblFechaFinMant.Text = dp_ProxMantFin.SelectedDate.Value.ToShortDateString();
                }
                else if (dt.Rows[0][2].ToString().Trim() == "A")
                {
                    dp_ProxMantFin.SelectedDate = dp_ProxMantIni.SelectedDate.Value.AddYears(1);
                    lblFechaFinMant.Text = dp_ProxMantFin.SelectedDate.Value.ToShortDateString();
                }

                Session["fechamantfin"] = lblFechaFinMant.Text;
                Session["fechamantini"] = lblFechaIniMant.Text;

                //para guardar datos de mantenimiento
                Session["man_forma"] = dt.Rows[0][7].ToString();
                Session["man_cobertura"] = dt.Rows[0][8].ToString();
                Session["man_modalidad"] = dt.Rows[0][9].ToString();
                Session["man_pormeses"] = dt.Rows[0][10].ToString();


                /*AQUI PONGO RANGO DE FECHAS PARA MANTENIMIENTO REAL QUE NO SE PASE DEL ASIGNADO NI SEA MENOR*/
                dp_FechaRealMant.MinDate = Convert.ToDateTime(lblFechaIniMant.Text).AddDays(1);//AÑADO UN DIA MAS AL DIA ASIGNADO
                dp_FechaRealMant.MaxDate = Convert.ToDateTime(lblFechaFinMant.Text);

                panFechaProx.Visible = true;
                upFechaProx.Update();
            }
            else
            {
                Session["man_forma"] = "";
                Session["man_cobertura"] = "0";
                Session["man_modalidad"] = "";
                Session["man_pormeses"] = "";
            }


        }
        else
        {
            //no hay arranque para mantenimiento preventivo, solo quieren dar mantenimiento correctivo

            Session["fecharealmant"] = "1900-01-01";
            Session["fechamantini"] = "1900-01-01";
            Session["fechamantfin"] = "1900-01-01";
            Session["man_forma"] = "";
            Session["man_cobertura"] = "0";
            Session["man_modalidad"] = "";
            Session["man_pormeses"] = "";
            panFechaProx.Visible = false;
            chboxTipoMant.Items[1].Selected = false;
            chboxTipoMant.Items[1].Enabled = true;
            upFechaProx.Update();
        }

    }
    public void cargarActivo(string cod, string tipo)
    {
        try
        {
            rgtras.DataSource = Logica.HELPER.getMantenimiento(cod, int.Parse(tipo));
            rgtras.DataBind();

            panReporte.Visible = true;
            //pantras.Visible = true;
            upman.Update();
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
        try
        {
            txtbuscb.Text = "";

            if (Logica.HELPER.comprobarIdIngresado(""))
            {
                messbox1.Mensaje = "Activo encontrado";
                messbox1.Tipo = "S";
                messbox1.showMess();

                //cargar datos

                //pantras.Visible = true;
                //cargarActivo(txtbusid.Text, "id");
            }
            else
            {
                pantras.Visible = false;
                messbox1.Mensaje = "No se encontró ningún item con Id = " + "";
                messbox1.Tipo = "I";
                messbox1.showMess();
                rgtras.DataSource = null;
                rgtras.DataBind();
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
    protected void ibcancel_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Site/Mantenimiento/ReporteMan.aspx");
    }
    public bool F_VerificaUltimatixTran()
    {
        if (lblUltimatix.Value == "No existe Custodio" || txtCodUltimatix.Value == "")
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    protected void ibsave_Click(object sender, ImageClickEventArgs e)
    {

        //if (chboxTipoMant.Items[0].Selected == false || chboxTipoMant.Items[1].Selected == false)
        //{
        //    messbox1.Mensaje = "Seleccione Tipo de Mantenimiento, por favor corrijalo antes de continuar...";
        //    messbox1.Tipo = "W";
        //    messbox1.showMess();
        //}
        //else
        //{

        if (chboxTipoMant.Items[0].Selected == true)
        {
            //if (F_VerificaUltimatixTran())
            //{
            F_MantenimientoCorrectivo();
            //}
            //else
            //{
            //    messbox1.Mensaje = "Código Ultimatix no valido, por favor corrijalo antes de continuar...";
            //    messbox1.Tipo = "W";
            //    messbox1.showMess();
            //}
        }
        else if (chboxTipoMant.Items[1].Selected == true)
        {
            if (txtDescripMantPreventivo.Text != "")
            {
                if (F_VerificaFechaGuardar())
                {
                    F_MantenimientoPreventivo();
                }
                else
                {
                    txtDescripMantPreventivo.Text = "";
                    messbox1.Mensaje = "No se puede Generar Mantenimiento ya que todavia no es la FECHA ASIGNADA, por favor comuniquese con el Administrador...";
                    messbox1.Tipo = "W";
                    messbox1.showMess();
                }
            }
            else
            {
                messbox1.Mensaje = "Ingrese Descripción de Mantenimiento Preventivo, por favor corrijalo antes de continuar...";
                messbox1.Tipo = "W";
                messbox1.showMess();
            }

        }
        //}
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
        dp_FechaRealizacion.Text = "";
        dp_FechaReIngreso.Text = "";
        txtDescripMantCorrectivo.Text = "";
        lblFechaIniMant.Text = "";
        lblFechaFinMant.Text = "";
        txtDescripMantPreventivo.Text = "";
        txtvalorMant.Text = "0";
        txtGuiaRemision.Text = "";
        cddProveedor.SelectedValue = "";
        cddCiudad.SelectedValue = "";
        txtCodUltimatix.Value = "";
        lblUltimatix.Value = "";
        txtObs.Text = "";


        panFechaMantCorrect.Visible = false;
        upFechaMantCorrect.Update();


        //panFechaProx.Enabled = false;
        upFechaProx.Update();

        pnl_Mantenimiento.Visible = false;
        Pan_UgeUor.Visible = false;

        dp_FechaRealizacion.Enabled = false;


        panReporte.Visible = false;
        pantras.Visible = false;
        upman.Update();
    }
    public bool Guardar()
    {
        bool guardar = true;
        Session["MantPrevent"] = "";
        Session["msgPreventivoG"] = "";
        Session["msgPreventivo"] = "";

        try
        {

            int tipoMantcorrectivo = 0;
            int tipoMantpreventivo = 0;
            string descripmant = "";
            DateTime fechamantcorrectivo = new DateTime(1900, 01, 01);
            DateTime fechamantpreventivo = new DateTime(1900, 01, 01);
            DateTime fechaproxmantpreventivo = new DateTime(1900, 01, 01);
            DateTime fechamantreal = new DateTime(1900, 01, 01);

            DateTime fechaenviomant = new DateTime();
            DateTime fecharegresomant = new DateTime();

            string estadoMantenimiento = "";


            if (chboxTipoMant.Items[0].Selected == true)
            {
                tipoMantcorrectivo = 1;
                fechamantcorrectivo = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
                descripmant = txtDescripMantCorrectivo.Text.Trim();


                //tipoMantpreventivo = 2;
                //fechamantpreventivo = Convert.ToDateTime(lblFechaIniMant.Text);
                //fechaproxmantpreventivo = Convert.ToDateTime(lblFechaFinMant.Text);

                if (Session["tip_id_preventivo"].ToString() == "")
                {
                    tipoMantpreventivo = 0;
                }
                else
                {
                    tipoMantpreventivo = int.Parse(Session["tip_id_preventivo"].ToString());
                }

                fechamantpreventivo = Convert.ToDateTime(Session["fechamantini"].ToString());
                fechaproxmantpreventivo = Convert.ToDateTime(Session["fechamantfin"].ToString());

                estadoMantenimiento = "M";
                fechaenviomant = Convert.ToDateTime(dp_FechaRealizacion.Text.Trim());
                fecharegresomant = Convert.ToDateTime(dp_FechaReIngreso.Text.Trim());


                fechamantreal = Convert.ToDateTime(Session["fecharealmant"].ToString());


                //F_EnviaHistoricoMovimientos();

            }

            if (F_VerificaFechaGuardar())
            {
                if (chboxTipoMant.Items[1].Selected == true)
                {

                    if (txtDescripMantPreventivo.Text != "")
                    {
                        fechamantcorrectivo = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
                        tipoMantpreventivo = 2;
                        fechamantpreventivo = Convert.ToDateTime(lblFechaFinMant.Text);
                        descripmant = txtDescripMantPreventivo.Text.Trim();
                        fechaproxmantpreventivo = F_CalculaFechaMant(Session["PorMeses"].ToString(), fechamantpreventivo);

                        if (chboxFechaRealMant.Checked = true && dp_FechaRealMant.SelectedDate != null)
                        {
                            fechamantreal = dp_FechaRealMant.SelectedDate.Value;
                        }

                        //F_EnviaHistoricoMovimientos();
                        Session["msgPreventivoG"] = "Mantenimiento Generado con Éxito...!!!";

                    }
                    else
                    {
                        Session["MantPrevent"] = "NO";
                        Session["msgPreventivo"] = "";
                        messbox1.Mensaje = "Ingrese Descripción de Mantenimiento Preventivo, por favor corrijalo antes de continuar...";
                        messbox1.Tipo = "W";
                        messbox1.showMess();

                    }
                }
            }
            else
            {
                Session["msgPreventivo"] = "No se puede Generar Mantenimiento Preventivo ya que todavia no es la FECHA ASIGNADA, por favor comuniquese con el Administrador...!!!";
                Session["MantPrevent"] = "NO";
            }

            if (chboxTipoMant.SelectedValue == "1" || (Session["MantPrevent"].ToString() != "NO" && chboxTipoMant.SelectedValue == "2"))
            {

                Logica.HELPER.insMantenimiento(
                             descripmant,
                             tipoMantcorrectivo,
                             tipoMantpreventivo,
                             Membership.GetUser().UserName,
                             fechamantcorrectivo,
                             int.Parse(lblid.Text.Trim()),
                             1,
                             fechamantpreventivo,
                             Convert.ToDouble(txtvalorMant.Text.Trim().Replace(",", ".")),
                             "",
                             Session["man_forma"].ToString(),
                             int.Parse(Session["man_cobertura"].ToString()),
                             Session["man_modalidad"].ToString(),
                             Session["man_pormeses"].ToString(),
                             "M",
                             fechaproxmantpreventivo,
                             fechamantreal,
                             estadoMantenimiento,
                             fechaenviomant,
                             fecharegresomant
                             );

                if (chboxTipoMant.Items[0].Selected == true)
                {

                    CrearPdf(int.Parse(lblid.Text.Trim()), "Acta Mantenimiento TI - ");
                }


            }
        }
        catch (System.Exception ex)
        {
            guardar = false;
            Session["msgGuardar"] = ex.Message;
        }

        return guardar;

    }
    public void F_EnviaHistoricoMovimientos(string tipo_mant)
    {
        string error = "";

        Datos.SqlService sql = new Datos.SqlService();


        Object ddUge1 = sql.ExecuteSqlObject("select uge_id1 from ACTIVO WHERE ACTIVO.ACT_ID='" + lblid.Text.Trim() + "'");
        Object ddUge2 = sql.ExecuteSqlObject("select uge_id2 from ACTIVO WHERE ACTIVO.ACT_ID='" + lblid.Text.Trim() + "'");
        Object ddUge3 = sql.ExecuteSqlObject("select uge_id3 from ACTIVO WHERE ACTIVO.ACT_ID='" + lblid.Text.Trim() + "'");
        Object ddPiso = sql.ExecuteSqlObject("select uge_id4 from ACTIVO WHERE ACTIVO.ACT_ID='" + lblid.Text.Trim() + "'");
        Object ddCcosto = sql.ExecuteSqlObject("select uor_id1 from ACTIVO WHERE ACTIVO.ACT_ID='" + lblid.Text.Trim() + "'");
        Object ddUor1 = sql.ExecuteSqlObject("select uor_id2 from ACTIVO WHERE ACTIVO.ACT_ID='" + lblid.Text.Trim() + "'");
        Object ddUor2 = sql.ExecuteSqlObject("select uor_id3 from ACTIVO WHERE ACTIVO.ACT_ID='" + lblid.Text.Trim() + "'");
        Object txtcodcus = sql.ExecuteSqlObject("select cus_id1 from ACTIVO WHERE ACTIVO.ACT_ID='" + lblid.Text.Trim() + "'");
        Object ddFase = sql.ExecuteSqlObject("select EST_ID2 from ACTIVO WHERE ACTIVO.ACT_ID='" + lblid.Text.Trim() + "'");
        Object ddTrasnfer = sql.ExecuteSqlObject("select EST_ID3 from ACTIVO WHERE ACTIVO.ACT_ID='" + lblid.Text.Trim() + "'");

        Object ddEstado = sql.ExecuteSqlObject("select EST_ID1 from ACTIVO WHERE ACTIVO.ACT_ID= '" + lblid.Text.Trim() + "'");


        //guardo nueva ubicacion y custodio
        error = Logica.HELPER.iniTransfer(
            int.Parse(lblid.Text),
            Membership.GetUser().UserName.ToLower(),
            int.Parse(ddUge1.ToString()),
            int.Parse(ddUge2.ToString()),
            int.Parse(ddUge3.ToString()),
            int.Parse(ddPiso.ToString()),
            int.Parse(ddCcosto.ToString()),
            int.Parse(ddUor1.ToString()),
            int.Parse(ddUor2.ToString()),
            int.Parse(txtcodcus.ToString()),
            int.Parse(ddEstado.ToString()),
            int.Parse(ddFase.ToString()),
            int.Parse(ddTrasnfer.ToString()), tipo_mant);



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

    //2012-02-13 Andrea.-Llamar a función que cree el pdf
    private void CrearPdf(int act, string nombre)
    {

        try
        {
            int numPDF = F_TotalPDF() + 1;
            string PDFnum = F_llenaceros(Convert.ToString(numPDF), 4, "0");


            Datos.SqlService sql = new Datos.SqlService();
            Object NuevoCus = sql.ExecuteSqlObject("select isnull(cus_nombres,'') +' '+ isnull(CUS_apellidos,'') from CUSTODIO where cus_id='" + lblCus.Text.Trim() + "'");
            //Object AnteriorCus = sql.ExecuteSqlObject("select (cus_nombres +' '+ CUS_apellidos) from CUSTODIO where cus_id='" + Session["ccini"].ToString() + "'");


            //descripcion
            Object descrip = sql.ExecuteSqlObject("select g3.gru_nombre AS DESCRIPCION from (ACTIVO left join GRUPO as g3 on activo.gru_id3= g3.gru_id) WHERE ACTIVO.ACT_ID='" + act + "'");

            Object codbien = sql.ExecuteSqlObject("select ACT_CODBARRAS as CODIGO from ACTIVO WHERE ACTIVO.ACT_ID='" + act + "'");
            Object marca = sql.ExecuteSqlObject("select mar.mar_nombre AS MARCA  from (ACTIVO  left join marca as mar on activo.mar_id=mar.mar_id) WHERE ACTIVO.ACT_ID='" + act + "'");
            Object serie = sql.ExecuteSqlObject("select act_serie1 AS SERIE from (ACTIVO  left join marca as mar on activo.mar_id=mar.mar_id)WHERE ACTIVO.ACT_ID='" + act + "'");
            Object modelo = sql.ExecuteSqlObject("select mode.mod_nombre AS MODELO from (ACTIVO left join modelo as mode on activo.mod_id=mode.mod_id)WHERE ACTIVO.ACT_ID='" + act + "'");
            string cusActivoFijo = ConfigurationManager.AppSettings["AreaActivosFijosIngreso"];

            //EMPIEZA PDF

            //creamos el documento
            //...ahora configuramos para que el tamaño de hoja sea A4
            //Document document = new Document(iTextSharp.text.PageSize.A4);
            Document document = new Document(iTextSharp.text.PageSize.A4, 50, 30, 15, 5);


            //hacemos que se inserte la fecha de creación para el documento
            document.AddCreationDate();

            //...título
            document.AddTitle("ACTA DE MANTENIMIENTO");

            //... el asunto
            document.AddSubject("ACTA DE MANTENIMIENTO");

            nombre = nombre + NuevoCus;

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
            iTextSharp.text.Font myfont = new iTextSharp.text.Font(
            FontFactory.GetFont(FontFactory.TIMES_ROMAN, 8, iTextSharp.text.Font.NORMAL));
            iTextSharp.text.Font myfont2 = new iTextSharp.text.Font(
            FontFactory.GetFont(FontFactory.TIMES_ROMAN, 9, iTextSharp.text.Font.BOLD));
            iTextSharp.text.Font myfont3 = new iTextSharp.text.Font(
            FontFactory.GetFont(FontFactory.TIMES_ROMAN, 8, iTextSharp.text.Font.BOLD));



            //Agregar tabla a Pdf
            PdfPTable table = new PdfPTable(5);

            PdfPCell cellCODEMPRESA = new PdfPCell(new Phrase("Código de Barras", myfont3));
            PdfPCell cellDESCRIP = new PdfPCell(new Phrase("Descripcion del Bien", myfont3));
            PdfPCell cellMARCA = new PdfPCell(new Phrase("Marca", myfont3));
            PdfPCell cellMODELO = new PdfPCell(new Phrase("Modelo", myfont3));
            PdfPCell cellSERIE = new PdfPCell(new Phrase("Serie", myfont3));



            cellCODEMPRESA.Colspan = 1;

            cellCODEMPRESA.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right

            table.AddCell(cellCODEMPRESA);
            table.AddCell(cellDESCRIP);
            table.AddCell(cellMARCA);
            table.AddCell(cellMODELO);
            table.AddCell(cellSERIE);

            table.AddCell(new Paragraph(codbien.ToString(), myfont));
            table.AddCell(new Paragraph(descrip.ToString(), myfont));
            table.AddCell(new Paragraph(marca.ToString(), myfont));
            table.AddCell(new Paragraph(modelo.ToString(), myfont));
            table.AddCell(new Paragraph(serie.ToString(), myfont));


            table.WidthPercentage = 100;
            table.SetWidths(new Single[] { 110, 130, 100, 100, 130 });



            //Agregar tabla CUSTODIO ANTERIOR - ACTUAL

            DateTime fechadev = new DateTime();
            string fecha = "";
            if (dp_FechaReIngreso.Text.Trim() != "")
            {
                fechadev = Convert.ToDateTime(dp_FechaReIngreso.Text.Trim());
            }

            if (fechadev == Convert.ToDateTime("01/01/1900"))
            {
                fecha = "";
            }
            else
            {
                fecha = fechadev.ToString();
            }


            //tabla observaciones
            PdfPTable tableobs = new PdfPTable(1);

            PdfPCell cellOBS = new PdfPCell(new Phrase("Observaciones", myfont3));
            tableobs.AddCell(cellOBS);
            tableobs.AddCell(new Paragraph(txtObs.Text.Trim(), myfont));
            tableobs.WidthPercentage = 100;

            //agregar todo el paquete de texto

            string ServerPath;
            ServerPath = Server.MapPath("");
            string ruta = ServerPath + "\\Logo\\logo.png";

            document.Add(new Paragraph("\n"));

            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(ruta);
            jpg.ScalePercent(20f); //tamaño de imagen en porcentaje
            jpg.Alignment = iTextSharp.text.Image.ALIGN_RIGHT;


            Paragraph P = new Paragraph("ACTA DE ENVIO A MANTENIMIENTO " + "\n", myfont2);
            P.Alignment = Element.ALIGN_CENTER;
            document.Add(jpg);
            document.Add(P);

            document.Add(new Paragraph("\n"));
            string TituloReporte = ConfigurationManager.AppSettings["TituloReportes"].ToString();
            Paragraph PFederacion = new Paragraph(TituloReporte + "\n", myfont2);
            PFederacion.Alignment = Element.ALIGN_CENTER;
            document.Add(PFederacion);

            document.Add(new Paragraph("\n"));

            Paragraph P2 = new Paragraph(cusActivoFijo + " entrega al Proveedor (" + ddProveedor.SelectedItem.Text.Trim() + "), los bienes detallados en la presente acta, para su revisión y mantenimiento. \n ", myfont);
            P2.Alignment = Element.ALIGN_JUSTIFIED;
            document.Add(P2);


            document.Add(new Paragraph("\n"));

            Paragraph P5 = new Paragraph("CARACTERÍSTICAS DEL BIEN", myfont);
            P5.Alignment = Element.ALIGN_CENTER;
            document.Add(P5);

            document.Add(new Paragraph("\n"));

            document.Add(table);

            document.Add(new Paragraph("\n"));

            document.Add(tableobs);
            document.Add(new Paragraph("\n"));

            Paragraph P8 = new Paragraph("RESPONSABILIDADES DEL PROVEEDOR", myfont);
            P8.Alignment = Element.ALIGN_CENTER;
            document.Add(P8);

            document.Add(new Paragraph("\n"));

            Paragraph P9 = new Paragraph("1.- Todos los bienes descritos en la presente acta, estarán bajo la responsabilidad, uso y cuidado del Proveedor.", myfont);
            P9.Alignment = Element.ALIGN_JUSTIFIED;
            document.Add(P9);
            document.Add(new Paragraph("\n"));
            Paragraph P11 = new Paragraph("2.- En caso de sustracción, robo o pérdida de los bienes descritos en la presente acta, el Proveedor deberá entregar un bien de las mismas caracteristicas.", myfont);
            P11.Alignment = Element.ALIGN_JUSTIFIED;
            document.Add(P11);
            document.Add(new Paragraph("\n"));

            Paragraph P13 = new Paragraph("Para constancia, firman las partes en tres ejemplares de idéntico valor y contenido.", myfont);
            P13.Alignment = Element.ALIGN_LEFT;
            document.Add(P13);

            document.Add(new Paragraph("\n"));
            document.Add(new Paragraph("\n"));
            document.Add(new Paragraph("\n"));

            //Tabla Ciudad - Fecha
            PdfPTable tableCF = new PdfPTable(1);

            PdfPCell cellCiudad = new PdfPCell(new Phrase(ddCiudad.SelectedItem.Text.Trim() + " " + System.DateTime.Now.Day.ToString() + " de " + F_Mes(System.DateTime.Now.Month) + " del " + System.DateTime.Now.Year, myfont));
            // PdfPCell cellFecha = new PdfPCell(new Phrase(System.DateTime.Now.Day.ToString() + " de " + F_Mes(System.DateTime.Now.Month) + " del " + System.DateTime.Now.Year, myfont));

            cellCiudad.BorderWidth = 0;
            cellCiudad.HorizontalAlignment = 1;
            //cellFecha.BorderWidth = 0;
            //cellFecha.HorizontalAlignment = 1;

            tableCF.AddCell(cellCiudad);
            // tableCF.AddCell(cellFecha);

            tableCF.WidthPercentage = 70;
            tableCF.HorizontalAlignment = 1;

            document.Add(tableCF);



            document.Add(new Paragraph("\n"));


            document.Add(new Paragraph("\n"));
            document.Add(new Paragraph("\n"));


            PdfPTable tableFirma = new PdfPTable(3);


            PdfPCell cellEntrega = new PdfPCell(new Phrase("DEPARTAMENTO DE MANTENIMIENTO", myfont));
            PdfPCell cellRecibe = new PdfPCell(new Phrase("F. PROVEEDOR", myfont));
            PdfPCell cellAutorizado = new PdfPCell(new Phrase("_________________________", myfont));
            PdfPCell cellEntrega1 = new PdfPCell(new Phrase("".ToString(), myfont));
            PdfPCell cellRecibe1 = new PdfPCell(new Phrase("".ToString(), myfont));
            PdfPCell cellAutorizado1 = new PdfPCell(new Phrase("", myfont));
            PdfPCell cellEntrega2 = new PdfPCell(new Phrase("ENTREGUÉ CONFORME", myfont));
            PdfPCell cellRecibe2 = new PdfPCell(new Phrase("RECIBÍ CONFORME ", myfont));
            PdfPCell cellAutorizado2 = new PdfPCell(new Phrase("AUTORIZADO POR ", myfont));

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
            messbox1.Mensaje = "Error. " + ex.Message;
            messbox1.Tipo = "E";
            messbox1.showMess();
        }

    }
    private void abreVentana(string ventana)
    {

        string funcion = "OpenWindows('" + ventana + "')";

        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "SIFEL", funcion, true);

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


        if (Convert.ToDateTime(lblFechaIniMant.Text) > System.DateTime.Now)
        {
            x = false;
        }

        else if (Convert.ToDateTime(lblFechaIniMant.Text) < System.DateTime.Now && (chboxFechaRealMant.Checked && dp_FechaRealMant.SelectedDate != null))
        {
            x = true;
        }
        else if (lblFechaIniMant.Text.Trim() == System.DateTime.Now.ToShortDateString())
        {
            x = true;
        }

        else
        {
            x = false;
        }

        Session["verificafecha"] = x;

        return x;

    }
    protected void rau3_FileUploaded(object sender, Telerik.Web.UI.FileUploadedEventArgs e)
    {
        try
        {
            foreach (UploadedFile file in rau3.UploadedFiles)
            {
                Session["fupload3"] = "";

                //string nombreok = lblid.Text.Trim();
                string nombreok = lblCodBarras.Text.Trim();

                int i = 1;
                while (File.Exists(Server.MapPath("./docmant/") + nombreok + file.GetExtension()))
                {
                    nombreok = lblCodBarras.Text.Trim() + "_" + i.ToString();
                    i++;
                }

                string path = Server.MapPath("./docmant/");

                nombreok = nombreok + file.GetExtension();
                file.SaveAs(Server.MapPath("./docmant/") + nombreok, false);
                Session["fupload3"] = nombreok;
            }
        }
        catch (Exception ex)
        {
            errtrap = new ErrorTrapper();
            errtrap.SetOnError("Usuario:" + Membership.GetUser().UserName + "<< " + ex.Message, 0);
        }
    }
    public bool verificaSiMantPreventivo()
    {

        Logica.Mantenimiento mant = new Logica.Mantenimiento();

        if (mant.verificaSiMantPreventivo(lblid.Text.Trim()))
            return true;
        else

            return false;
    }
    protected void chboxTipoMant_SelectedIndexChanged(object sender, EventArgs e)
    {


        if (chboxTipoMant.Items[1].Selected == false)
        {
            panFechaProx.Visible = false;
            //dp_ProxMant.Clear();
            upFechaProx.Update();
            //panDescripMantPreventivo.Visible = false;
            //upDescripMantPreventivo.Update();
            lblFechaIniMant.Text = "1900-01-01";
            lblFechaFinMant.Text = "1900-01-01";
            txtDescripMantPreventivo.Text = "";
        }
        else
        {

            if (verificaSiMantPreventivo())
            {
                lblFechaFinMant.Text = Session["fechamantfin"].ToString();
                lblFechaIniMant.Text = Session["fechamantini"].ToString();

                panFechaProx.Visible = true;
                //dp_ProxMant.Clear();
                upFechaProx.Update();
                //panDescripMantPreventivo.Visible = true;
                //upDescripMantPreventivo.Update();
            }
            else
            {
                chboxTipoMant.Items[1].Selected = false;
                messbox1.Mensaje = "Debe primero Registrar Mantenimiento Preventivo, por favor corrijalo antes de continuar...";
                messbox1.Tipo = "W";
                messbox1.showMess();
            }
        }


        if (chboxTipoMant.Items[0].Selected == false)
        {
            dp_FechaRealizacion.Enabled = false;
            dp_FechaRealizacion.Text = "";
            panFechaMantCorrect.Visible = false;
            upFechaMantCorrect.Update();
            txtDescripMantCorrectivo.Text = "";
            //panDescripMantCorrectivo.Visible = false;
            //upDescripMantCorrectivo.Update();
            panDatosActa.Visible = false;
            txtObs.Text = "";
            ddCiudad.ClearSelection();
            ddProveedor.ClearSelection();

        }
        else
        {
            dp_FechaRealizacion.Enabled = true;
            panFechaMantCorrect.Visible = true;
            upFechaMantCorrect.Update();
            panDatosActa.Visible = true;

            panDatosActa.Visible = false;
            //panDescripMantCorrectivo.Visible = true;
            //upDescripMantCorrectivo.Update();
        }
    }
    protected void chboxFechaRealMant_CheckedChanged(object sender, EventArgs e)
    {
        if (chboxFechaRealMant.Checked == true)
        {
            dp_FechaRealMant.Enabled = true;
        }
        else
        {
            dp_FechaRealMant.Enabled = false;
            dp_FechaRealMant.Clear();
        }
    }
    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
        if (rbCodigoBarras.Checked)
        {
            rbSerie.Checked = false;
            rbMarcaModelo.Checked = false;
            rbCodSecundario.Checked = false;
            txtcodSecundario.Visible = false;
            ibbus6.Visible = false;
            txtcodSecundario.Text = "";
            rfv1.Enabled = true;
            rfv25.Enabled = false;
            txtbuscb.Text = "";
            txtbuscb.Visible = true;
            ibbus1.Visible = true;
            txtserie.Text = "";
            txtserie.Visible = false;
            ddMarca.Visible = false;
            ddModelo.Visible = false;
            ibbus4.Visible = false;
            ibbus5.Visible = false;
        }
    }
    protected void rbSerie_CheckedChanged(object sender, EventArgs e)
    {
        if (rbSerie.Checked)
        {
            rbCodigoBarras.Checked = false;
            rbMarcaModelo.Checked = false;
            rfv25.Enabled = true;
            txtbuscb.Text = "";
            txtbuscb.Visible = false;
            ibbus1.Visible = false;
            txtserie.Text = "";
            txtserie.Visible = true;
            ddMarca.Visible = false;
            ddModelo.Visible = false;
            ibbus4.Visible = true;
            ibbus5.Visible = false;
            rfv1.Enabled = false;
            rbCodSecundario.Checked = false;
            txtcodSecundario.Visible = false;
            ibbus6.Visible = false;
            txtcodSecundario.Text = "";

        }
    }
    protected void rbMarcaModelo_CheckedChanged(object sender, EventArgs e)
    {
        if (rbMarcaModelo.Checked)
        {
            rbCodigoBarras.Checked = false;
            rbSerie.Checked = false;
            rbCodSecundario.Checked = false;
            //rfv26.Enabled = true;
            txtbuscb.Text = "";
            txtbuscb.Visible = false;
            ibbus1.Visible = false;
            txtserie.Text = "";
            txtserie.Visible = false;
            ddMarca.Visible = true;
            ddModelo.Visible = true;
            ibbus4.Visible = false;
            ibbus5.Visible = true;
            rfv25.Enabled = false;
            rfv1.Enabled = false;
            txtcodSecundario.Visible = false;
            ibbus6.Visible = false;
            txtcodSecundario.Text = "";
        }
    }
    protected void ibbus4_Click(object sender, ImageClickEventArgs e)
    {
        Datos.SqlService sql = new Datos.SqlService();
        DataTable dt = new DataTable();
        string codbarras = "";

        sql.AddParameter("@OP", SqlDbType.Int, 2);
        sql.AddParameter("@CODIGOBARRAS", SqlDbType.VarChar, "");
        sql.AddParameter("@SERIE", SqlDbType.VarChar, txtserie.Text.Trim());
        sql.AddParameter("@MARCA", SqlDbType.Int, 0);
        sql.AddParameter("@MODELO", SqlDbType.Int, 0);

        dt = sql.ExecuteSPDataTable("MANTENIMIENTOPC05");

        if (dt.Rows.Count > 0)
        {

            rgItems.DataSource = dt;
            rgItems.DataBind();

            if (dt.Rows.Count == 1)
            {
                foreach (GridDataItem item in rgItems.MasterTableView.Items)
                {
                    codbarras = item["codbarras"].Text;
                }


                if (Logica.Mantenimiento.verificaMantenimientoSerie(txtserie.Text.Trim()))
                {
                    pnl_Mantenimiento.Visible = false;
                    Pan_UgeUor.Visible = false;
                    pantras.Visible = false;

                    panReporte.Visible = false;
                    upman.Visible = false;
                    messbox1.Mensaje = "El Activo actualmente esta en Mantenimiento, no se puede realizar ningun cambio, comuniquese con el Administrador...!!!";
                    messbox1.Tipo = "W";
                    messbox1.showMess();
                }
                else
                {
                    if (Logica.HELPER.VerificaTipoBien(codbarras.Trim()))
                    {
                        //cargar datos
                        CargarUbiGEOUOR(codbarras.Trim(), 1);

                        if (Logica.HELPER.VerificaDepreciaciones(int.Parse(lblid.Text.Trim()), "") == "iok")
                        {

                            messbox1.Mensaje = "No se puede Enviar a Mantenimiento a un Bien Dado de Baja...!!!";
                            messbox1.Tipo = "W";
                            messbox1.showMess();

                            pnl_Mantenimiento.Visible = false;
                            Pan_UgeUor.Visible = false;
                            pantras.Visible = false;

                            panReporte.Visible = false;
                            upman.Visible = false;
                        }

                        else
                        {
                            CargarUltimoMantenimiento(lblid.Text.Trim());

                            cargarActivo(codbarras.Trim(), "2");
                        }
                    }

                    else
                    {
                        messbox1.Mensaje = "No se puede Realizar Mantenimiento a un Bien de Control...!!!";
                        messbox1.Tipo = "W";
                        messbox1.showMess();

                        pnl_Mantenimiento.Visible = false;
                        Pan_UgeUor.Visible = false;
                        pantras.Visible = false;

                        panReporte.Visible = false;
                        upman.Visible = false;

                    }

                }
            }
        }
        else
        {
            messbox1.Mensaje = "No existen Datos!";
            messbox1.Tipo = "W";
            messbox1.showMess();

            rgItems.DataSource = null;
            rgItems.DataBind();
        }
    }
    protected void ibbus5_Click(object sender, ImageClickEventArgs e)
    {
        Datos.SqlService sql = new Datos.SqlService();
        DataTable dt = new DataTable();
        string codbarras = "";

        if (ddMarca.SelectedValue != null && (ddModelo.SelectedValue == null || ddModelo.SelectedValue == ""))
        {
            sql.AddParameter("@OP", SqlDbType.Int, 3);
            sql.AddParameter("@MARCA", SqlDbType.Int, ddMarca.SelectedValue);
            sql.AddParameter("@MODELO", SqlDbType.Int, 0);
        }
        else if (ddModelo.SelectedValue != null && ddMarca.SelectedValue != null)
        {
            sql.AddParameter("@OP", SqlDbType.Int, 4);
            sql.AddParameter("@MARCA", SqlDbType.Int, ddMarca.SelectedValue);
            sql.AddParameter("@MODELO", SqlDbType.Int, ddModelo.SelectedValue);
        }
        else if (ddModelo.SelectedValue != null && (ddMarca.SelectedValue == "" || ddMarca.SelectedValue == null))
        {
            sql.AddParameter("@OP", SqlDbType.Int, 5);
            sql.AddParameter("@MARCA", SqlDbType.Int, 0);
            sql.AddParameter("@MODELO", SqlDbType.Int, ddModelo.SelectedValue);
        }

        sql.AddParameter("@CODIGOBARRAS", SqlDbType.VarChar, "");
        sql.AddParameter("@SERIE", SqlDbType.VarChar, "");

        dt = sql.ExecuteSPDataTable("MANTENIMIENTOPC05");

        if (dt.Rows.Count > 0)
        {

            rgItems.DataSource = dt;
            rgItems.DataBind();

            if (dt.Rows.Count == 1)
            {
                foreach (GridDataItem item in rgItems.MasterTableView.Items)
                {
                    codbarras = item["codbarras"].Text;
                }

                if (Logica.Mantenimiento.verificaMantenimiento(txtbuscb.Text.Trim()))
                {
                    pnl_Mantenimiento.Visible = false;
                    Pan_UgeUor.Visible = false;
                    pantras.Visible = false;

                    panReporte.Visible = false;
                    upman.Visible = false;
                    messbox1.Mensaje = "El Activo actualmente esta en Mantenimiento, no se puede realizar ningun cambio, comuniquese con el Administrador...!!!";
                    messbox1.Tipo = "W";
                    messbox1.showMess();
                }
                else
                {
                    if (Logica.HELPER.VerificaTipoBien(codbarras.Trim()))
                    {
                        //cargar datos

                        CargarUbiGEOUOR(codbarras.Trim(), 1);

                        if (Logica.HELPER.VerificaDepreciaciones(int.Parse(lblid.Text.Trim()), "") == "iok")
                        {

                            messbox1.Mensaje = "No se puede Enviar a Mantenimiento a un Bien Dado de Baja...!!!";
                            messbox1.Tipo = "W";
                            messbox1.showMess();

                            pnl_Mantenimiento.Visible = false;
                            Pan_UgeUor.Visible = false;
                            pantras.Visible = false;

                            panReporte.Visible = false;
                            upman.Visible = false;
                        }
                        else
                        {
                            CargarUltimoMantenimiento(lblid.Text.Trim());

                            cargarActivo(codbarras.Trim(), "cb");
                        }
                    }

                    else
                    {
                        messbox1.Mensaje = "No se puede Realizar Mantenimiento a un Bien de Control...!!!";
                        messbox1.Tipo = "W";
                        messbox1.showMess();

                        pnl_Mantenimiento.Visible = false;
                        Pan_UgeUor.Visible = false;
                        pantras.Visible = false;

                        panReporte.Visible = false;
                        upman.Visible = false;
                    }
                }
            }
        }
        else
        {
            messbox1.Mensaje = "No existen Datos!";
            messbox1.Tipo = "W";
            messbox1.showMess();

            rgItems.DataSource = null;
            rgItems.DataBind();
        }
    }

    protected void ibbus6_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            //txtbusid.Text = "";

            //if (codigoCorrecto())
            //{
            if (Logica.HELPER.comprobarCodSecundarioIngresado(txtcodSecundario.Text.Trim()))
            {
                if (Logica.Mantenimiento.verificaMantenimientoCodigoBNF(txtcodSecundario.Text.Trim()))
                {
                    pnl_Mantenimiento.Visible = false;
                    Pan_UgeUor.Visible = false;
                    pantras.Visible = false;

                    panReporte.Visible = false;
                    upman.Visible = false;
                    messbox1.Mensaje = "El Activo actualmente esta en Mantenimiento, no se puede realizar ningun cambio, comuniquese con el Administrador...!!!";
                    messbox1.Tipo = "W";
                    messbox1.showMess();
                }
                else
                {
                    if (Logica.HELPER.VerificaTipoBienCodSec(txtcodSecundario.Text.Trim()))
                    {
                        //cargar datos

                        CargarUbiGEOUOR(txtcodSecundario.Text.Trim(), 3);

                        if (Logica.HELPER.VerificaDepreciaciones(int.Parse(lblid.Text.Trim()), "") == "iok")
                        {

                            messbox1.Mensaje = "No se puede Enviar a Mantenimiento a un Bien Dado de Baja...!!!";
                            messbox1.Tipo = "W";
                            messbox1.showMess();

                            pnl_Mantenimiento.Visible = false;
                            Pan_UgeUor.Visible = false;
                            pantras.Visible = false;

                            panReporte.Visible = false;
                            upman.Visible = false;
                        }

                        else
                        {
                            CargarUltimoMantenimiento(lblid.Text.Trim());

                            cargarActivo(txtcodSecundario.Text.Trim(), "4");

                            panDatosActa.Visible = false;
                        }
                    }

                    else
                    {
                        messbox1.Mensaje = "No se puede Realizar Mantenimiento a un Bien de Control...!!!";
                        messbox1.Tipo = "W";
                        messbox1.showMess();

                        pnl_Mantenimiento.Visible = false;
                        Pan_UgeUor.Visible = false;
                        pantras.Visible = false;

                        panReporte.Visible = false;
                        upman.Visible = false;

                    }

                }
            }
            else
            {
                pantras.Visible = false;
                pnl_Mantenimiento.Visible = false;
                Pan_UgeUor.Visible = false;
                messbox1.Mensaje = "Código Válido, pero aún no ha sido ingresado!";
                messbox1.Tipo = "I";
                messbox1.showMess();
                rgtras.DataSource = null;
                rgtras.DataBind();
            }

            //}
            //else
            //{
            //    messbox1.Mensaje = "El Código de Barras No es Válido!";
            //    messbox1.Tipo = "W";
            //    messbox1.showMess();
            //    rgtras.DataSource = null;
            //    rgtras.DataBind();
            //    pantras.Visible = false;
            //    pnl_Mantenimiento.Visible = false;
            //    Pan_UgeUor.Visible = false;
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
    protected void rbCodSecundario_CheckedChanged(object sender, EventArgs e)
    {
        if (rbCodSecundario.Checked)
        {
            rbSerie.Checked = false;
            rbMarcaModelo.Checked = false;
            rfv1.Enabled = true;
            rfv25.Enabled = false;
            txtbuscb.Text = "";
            txtbuscb.Visible = false;
            ibbus1.Visible = false;
            txtcodSecundario.Enabled = true;
            txtcodSecundario.Visible = true;
            ibbus6.Visible = true;
            txtserie.Text = "";
            txtserie.Visible = true;
            ddMarca.Visible = false;
            ddModelo.Visible = false;
            ibbus4.Visible = false;
            ibbus5.Visible = false;
            txtserie.Visible = false;
            rbCodigoBarras.Checked = false;
        }
    }
}

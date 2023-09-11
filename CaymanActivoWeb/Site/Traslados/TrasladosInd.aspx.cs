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
using ACTIVO = Logica.ACTIVO;
using GRUPO = Logica.GRUPO;
using Logica;
using DevExpress.XtraReports.Templates;
using System.Globalization;

public partial class TrasladosInd : System.Web.UI.Page
{
    ErrorTrapper errtrap;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = ConfigurationManager.AppSettings["Titulo"] + " Traslados Individuales";

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
            ibsave.Attributes.Add("onmouseout", "this.src='../../Img/s1.png'");
            ibsave.Attributes.Add("onmouseover", "this.src='../../Img/s2.png'");
            ibcancel.Attributes.Add("onmouseout", "this.src='../../Img/c1.png'");
            ibcancel.Attributes.Add("onmouseover", "this.src='../../Img/c2.png'");

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

    private void cleanCar()
    {
        try
        {
            for (int i = 1; i < 17; i++)
            {
                //enceramos info tecnica
                Label lab = (Label)upcar.FindControl("l" + i.ToString());
                lab.Text = "";
            }

            upcar.Update();
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

    protected void ibbus3_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            txtbuscb.Text = "";

            if (Logica.HELPER.comprobarCodLogikard(txtbusid.Text.Trim()))
            {
                if (Logica.Mantenimiento.verificaMantenimiento(txtbuscb.Text.Trim()))
                {
                    panuevo.Visible = false;
                    messbox1.Mensaje = "El Activo actualmente esta en Mantenimiento, no se puede realizar ningun cambio, comuniquese con el Administrador...!!!";
                    messbox1.Tipo = "W";
                    messbox1.showMess();
                }
                else
                {
                    //cargar datos
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
            errtrap.SetOnError("Usuario:" + Membership.GetUser().UserName + "<< " + ex.Message, 0); //1 enviar mail
            messbox1.Mensaje = "Error: " + ex.Message;
            messbox1.Tipo = "E";
            messbox1.showMess();
        }
    }

    protected void ibbus1_Click(object sender, ImageClickEventArgs e)
    {
        txtbusid.Text = "";
        if (Logica.Mantenimiento.verificaMantenimiento(txtbuscb.Text.Trim()))
        {
            panuevo.Visible = false;
            messbox1.Mensaje = "El Activo actualmente esta en Mantenimiento, no se puede realizar ningun cambio, comuniquese con el Administrador...!!!";
            messbox1.Tipo = "W";
            messbox1.showMess();
        }
        else
        {
            buscarCb();
        }
    }

    private void buscarCb()
    {
        try
        {
            txtbusid.Text = "";

            if (codigoCorrecto())
            {
                if (Logica.HELPER.comprobarCbIngresado(txtbuscb.Text))
                {
                    //cargar datos
                    panuevo.Visible = true;
                    cargarActivo("cb");
                }
                else
                {
                    panuevo.Visible = false;
                    messbox1.Mensaje = "Código Válido, pero aún no ha sido ingresado!";
                    messbox1.Tipo = "I";
                    messbox1.showMess();
                }
            }
            else
            {
                panuevo.Visible = false;
                messbox1.Mensaje = "Código de Barras No Válido!";
                messbox1.Tipo = "W";
                messbox1.showMess();
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

    public static Logica.ACTIVO _act = new Logica.ACTIVO();

    public void cargarActivo(string tipo)
    {
        try
        {
            Session["ubiini"] = "";
            Session["cusini"] = "";
            Session["ubigeo"] = "";
            Session["ubiorg"] = "";

            Logica.ACTIVO act = null;
            _act = null;

            if (tipo == "cb")
                act = new Logica.ACTIVO(txtbuscb.Text.Trim(), tipo);
            else if (tipo == "cs")
                act = new Logica.ACTIVO(txtbusid.Text.Trim(), tipo);

            _act = act;

            //si el activo no ha sido dado de baja act_fechabaja=null=01/01/0001
            if (act.ACT_FECHABAJA.Year == 1)
            {
                sse.ContextKey = act.Id.ToString();

                lbltipo.Text = act.ACT_TIPO;
                lblcb.Text = act.ACT_CODBARRAS;
                lblcbp.Text = act.ACT_CODBARRASPADRE;
                lblcod1.Text = act.ACT_CODIGO1;

                lblid.Text = act.Id.ToString();
                lblgru.Text = Logica.HELPER.getNombre("grupo", "gru_nombre", act.GRU_ID1.ToString(), "gru_id");
                lblsgru.Text = Logica.HELPER.getNombre("grupo", "gru_nombre", act.GRU_ID2.ToString(), "gru_id");
                lbldesc.Text = Logica.HELPER.getNombre("grupo", "gru_nombre", act.GRU_ID3.ToString(), "gru_id");

                /*Asiento Contable*/
                Logica.GRUPO grupo = new Logica.GRUPO(act.GRU_ID1);
                lblCuentaOrigen.Text = grupo.GRU_CTA1;
                lblCuentaDestino.Text = grupo.GRU_CTA1;
                lblCuentaDepreOrigen.Text = grupo.GRU_CTA3;
                lblCuentaDepreDestino.Text = grupo.GRU_CTA3;
                Logica.UGEOGRAFICA ugeografica = new Logica.UGEOGRAFICA(act.UGE_ID2);
                lblOficina1.Text = ugeografica.UGE_CODIGO;
                lblOficina2.Text = ugeografica.UGE_CODIGO;
                lblOficinaDepre1.Text = ugeografica.UGE_CODIGO;
                lblOficinaDepre2.Text = ugeografica.UGE_CODIGO;
                Logica.UORGANICA uorganica = new Logica.UORGANICA(act.UOR_ID2);
                lblCentroCosto1.Text = uorganica.UOR_CODIGO;
                lblCentroCosto2.Text = uorganica.UOR_CODIGO;
                lblCentroCostoDepre1.Text = uorganica.UOR_CODIGO;
                lblCentroCostoDepre2.Text = uorganica.UOR_CODIGO;
                lblDebito1.Text = "0.00";
                lblCredito2.Text = "0.00";
                lblCredito1.Text = act.ACT_VALORCOMPRA.ToString("#0.00");
                lblDebito2.Text = act.ACT_VALORCOMPRA.ToString("#0.00");
                lblDebitoDepre1.Text = act.ACT_DEPREACUMULADA.ToString("0.00");
                lblCreditoDepre1.Text = "0.00";
                lblCreditoDepre2.Text = act.ACT_DEPREACUMULADA.ToString("0.00");
                lblDebitoDepre2.Text = "0.00";

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
                    hk1.ToolTip = "Ver Foto 1";
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
                }

                hk5.NavigateUrl = "~/Site/Activos/Hfotos.aspx?id=" + lblid.Text;

                cddgeo1.SelectedValue = act.UGE_ID1.ToString();
                cddgeo2.SelectedValue = act.UGE_ID2.ToString();
                cddgeo3.SelectedValue = act.UGE_ID3.ToString();
                cddpiso.SelectedValue = act.UGE_ID4.ToString();

                cddccosto.SelectedValue = act.UOR_ID1.ToString();
                cdduor1.SelectedValue = act.UOR_ID2.ToString();
                cdduor2.SelectedValue = act.UOR_ID3.ToString();
                cddcus.SelectedValue = act.CUS_ID1.ToString();

                cddest1.SelectedValue = act.EST_ID1.ToString();
                cddest2.SelectedValue = act.EST_ID2.ToString();
                cddest3.SelectedValue = act.EST_ID3.ToString();

                Session["ubiini"] = act.UGE_ID1.ToString() + ";" +
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

                Session["cusini"] = act.CUS_ID1.ToString();

                Session["ubigeo"] = act.UGE_ID1.ToString() + ";" +
                                    act.UGE_ID2.ToString() + ";" +
                                    act.UGE_ID3.ToString() + ";" +
                                    act.UGE_ID4.ToString();

                Session["ubiorg"] = act.UOR_ID1.ToString() + ";" +
                                    act.UOR_ID2.ToString() + ";" +
                                    act.UOR_ID3.ToString();

                lblmarca.Text = Logica.HELPER.getNombre("marca", "mar_nombre", act.MAR_ID.ToString(), "mar_id");
                lblmodelo.Text = Logica.HELPER.getNombre("modelo", "mod_nombre", act.MOD_ID.ToString(), "mod_id");
                lblserie.Text = act.ACT_SERIE1;

                if (act.COL_ID.ToString() != "0")
                    lblcolor.Text = Logica.HELPER.getNombre("color", "col_nombre", act.COL_ID.ToString(), "col_id");

                if (act.ACT_ANIO.ToString() == "0")
                    lblaño.Text = "";
                else
                    lblaño.Text = act.ACT_ANIO.ToString();

                if (act.ECO_ID1.ToString() != "0")
                    lblestructura.Text = Logica.HELPER.getNombre("estrucomp", "eco_nombre", act.ECO_ID1.ToString(), "eco_id");

                if (act.ECO_ID2.ToString() != "0")
                    lblcomponente.Text = Logica.HELPER.getNombre("estrucomp", "eco_nombre", act.ECO_ID2.ToString(), "eco_id");

                lblproveedor.Text = Logica.HELPER.getNombre("proveedor", "pro_nombre", act.PRO_ID.ToString(), "pro_id");

                lblingreso.Text = act.ACT_TIPOING;
                lblnumfact.Text = act.ACT_NUMFACT.ToString();

                lblfechacompra.Text = act.ACT_FECHACOMPRA.ToShortDateString();
                lblvalorcompra.Text = "$ " + act.ACT_VALORCOMPRA.ToString("N") + " USD";
                lblvidautil.Text = act.ACT_VIDAUTIL.ToString();
                lblvuniif.Text = act.ACT_VIDAUTILNIIF.ToString();
                lblvalresniif.Text = "$ " + act.ACT_VALORRESIDUALNIIF.ToString("N") + " USD";
                lblfechainioper.Text = act.ACT_FECHAINIOPER.ToShortDateString();

                if (act.ACT_GARANTIA)
                {
                    lblgarantia.Text = "SI";
                    lblfechavencegar.Text = act.ACT_FECHAGARANTIAVENCE.ToShortDateString();
                }
                else
                {
                    lblgarantia.Text = "NO";
                    lblfechavencegar.Text = "No Aplica";
                }

                if (act.ACT_OBSERVACIONES.Length == 0)
                    lblobservaciones.Text = "No registra ninguna Observación...";
                else
                    lblobservaciones.Text = act.ACT_OBSERVACIONES;

                upAsiento.Update();
                //CARGO CARACTERISTICAS, VALORES Y UNIDADES
                DataSet dscar;

                Logica.CARACTERISTICA car2 = new Logica.CARACTERISTICA();
                dscar = car2.fgetCarXActid4(act.Id.ToString());

                int i = 1;

                if (dscar.Tables[0].Rows.Count == 0)
                {
                    cleanCar();
                }
                else
                {
                    foreach (DataRow dsrow in dscar.Tables[0].Rows)
                    {
                        Label lab = (Label)upcar.FindControl("l" + i.ToString());
                        lab.Text = dsrow["car"].ToString();
                        i++;
                    }
                }
            }
            else
            {
                messbox1.Mensaje = "No puede modificar el activo ya que anteriormente fue dado de baja";
                messbox1.Tipo = "W";
                messbox1.showMess();

                panuevo.Visible = false;
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

    protected void ibsave_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (panuevo.Visible)
            {
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

                //si se hizo algun cambio nuevo en la ubicacion o custodio del activo
                if (Session["ubiini"].ToString() != ubifin)
                {
                    string error = "";

                    //guardo nueva ubicacion y custodio
                    //error = Logica.HELPER.iniTransfer(
                    var procesado = Logica.HELPER.creaTransfer(
             int.Parse(lblid.Text),
            Membership.GetUser().UserName.ToLower(),
            int.Parse(ddUge1.SelectedValue),
            int.Parse(ddUge2.SelectedValue),
                    int.Parse(ddUge3.SelectedValue),
            int.Parse(ddPiso.SelectedValue),
                int.Parse(ddCcosto.SelectedValue),
            int.Parse(ddUor1.SelectedValue),
            int.Parse(ddUor2.SelectedValue),
            int.Parse(ddCustodio.SelectedValue),
            int.Parse(ddEstado.SelectedValue),
            int.Parse(ddFase.SelectedValue),
           int.Parse(ddTrasnfer.SelectedValue), "TI", Guid.NewGuid(), 0); //INSERTA CAMBIOS CUANDO CAMBIA UBI ORG O UBI GEO O CUSTODIO

                    string ubigeo = Session["ubigeo"].ToString();
                    string ubiorg = Session["ubiorg"].ToString();
                    if ((lblOficina1 != lblOficina2 || lblCentroCosto1 != lblCentroCosto2) && lbltipo.Text == "Activo Fijo")
                    {
                        Logica.ACTIVO _act1 = new Logica.ACTIVO(int.Parse(lblid.Text));
                        _act1.CuentaOrigen = lblCuentaOrigen.Text;
                        _act1.CuentaDestino = lblCuentaDestino.Text;
                        _act1.Oficina1 = lblOficina1.Text;
                        _act1.Oficina2 = lblOficina2.Text;
                        _act1.CentroCosto1 = lblCentroCosto1.Text;
                        _act1.CentroCosto2 = lblCentroCosto2.Text;
                        _act1.CuentaDepreOrigen = lblCuentaDepreOrigen.Text;
                        _act1.CuentaDepreDestino = lblCuentaDepreDestino.Text;
                        _act1.CentroCostoDepre1 = lblCentroCostoDepre1.Text;
                        _act1.CentroCostoDepre2 = lblCentroCostoDepre2.Text;
                        _act1.OficinaDepre1 = lblOficinaDepre1.Text;
                        _act1.OficinaDepre2 = lblOficinaDepre2.Text;
                        _act1.DebitoDepre1 = "0";
                        _act1.CreditoDepre1 = lblCreditoDepre1.Text;
                        _act1.DebitoDepre2 = lblDebitoDepre2.Text;
                        _act1.CreditoDepre2 = "0";
                        Asientos.TransferenciaActivo(_act1);
                    }
                    //guardo asiento contable
                    //Asientos.TransferenciaActivo(_act, ubifin, Session["ubiini"].ToString());


                    if (Session["cusini"].ToString() != cusfin && procesado) //SOLO GENERA PDF SI SE CAMBIO DE CUSTODIO
                    {
                        //2012-02-13 Andrea.-Llamar a función que cree el pdf
                        CrearPdf(Session["cusini"].ToString(), cusfin, int.Parse(lblid.Text), ubiorg, ubigeo, "Acta Entrega TI - " + ddCustodio.SelectedItem.Text);
                    }

                    if (error != "")
                    {
                        messbox1.Mensaje = "Error al guardar el archivo. >> " + error;
                        messbox1.Tipo = "E";
                        messbox1.showMess();
                    }
                    else
                    {
                        messbox1.Mensaje = "Transferencia efectuada con éxito!";
                        messbox1.Tipo = "S";
                        messbox1.showMess();
                        Session["ubiini"] = ubifin;
                        //Response.Redirect("TrasladosInd.aspx?msg=1&path=" + Session["RutaPdfTraslados"].ToString() + "&ide=" + lblid.Text);
                    }
                }
                else
                {
                    messbox1.Mensaje = "No se ha Transferido el activo ya que no se ha Modificado su Ubicación y/o Custodio actual.";
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
            errtrap.SetOnError("Usuario:" + Membership.GetUser().UserName + "<< " + ex.Message, 0);
            messbox1.Mensaje = "Error. " + ex.Message;
            messbox1.Tipo = "E";
            messbox1.showMess();
        }
    }

    protected void ibcancel_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("TrasladosInd.aspx");
    }

    public int F_TotalPDF()
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

    private void CrearPdf(string cusini, string cusfin, int act, string ubiorg, string ubigeo, string nombre)
    {
        try
        {
            //int numPDF = F_TotalPDF() + 1;
            //string PDFnum = F_llenaceros(Convert.ToString(numPDF), 5, "0");

            string[] ubiOrg = ubiorg.Split(';');
            string[] ubiGeo = ubigeo.Split(';');

            Datos.SqlService sql = new Datos.SqlService();
            Object AreaActivos = Membership.GetUser().UserName.ToString();
            Object NuevoCus = sql.ExecuteSqlObject("select (cus_nombres +' '+ CUS_apellidos) from CUSTODIO where cus_id='" + cusfin + "'");
            Object AnteriorCus = sql.ExecuteSqlObject("select (cus_nombres +' '+ CUS_apellidos) from CUSTODIO where cus_id='" + cusini + "'");

            Object NuevoCusCC = sql.ExecuteSqlObject("select cus_cedula from CUSTODIO where cus_id='" + cusfin + "'");
            Object AnteriorCusCC = sql.ExecuteSqlObject("select  cus_cedula from CUSTODIO where cus_id='" + cusini + "'");
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

            Object Uorg2 = sql.ExecuteSqlObject("select uor_nombre from uorganica where uor_id='" + ubiOrg[0] + "'");
            Object Ugeo1 = sql.ExecuteSqlObject("select uge_nombre from ugeografica where uge_id='" + ubiGeo[0] + "'");
            Object Ugeo2 = sql.ExecuteSqlObject("select uge_nombre from ugeografica where uge_id='" + ubiGeo[1] + "'");
            Object Ugeo3 = sql.ExecuteSqlObject("select uge_nombre from ugeografica where uge_id='" + ubiGeo[2] + "'");
            string TituloReporte = ConfigurationManager.AppSettings["TituloReportes"].ToString();

            //descripcion
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
            object fechacompra = sql.ExecuteSqlObject("select act_fechacompra from activo where act_id=" + act);
            Object color = sql.ExecuteSqlObject(

                "select isnull(col.col_nombre,'Sin Color') AS COLOR from (ACTIVO  left join COLOR as col on activo.col_id=col.col_id) WHERE ACTIVO.ACT_ID='" + act + "'");
            Object proveedor1 = sql.ExecuteSqlObject(
                "select isnull(PROVEEDOR.PRO_NOMBRE,'Sin Proveedor')  from ACTIVO inner join PROVEEDOR on ACTIVO.PRO_ID=PROVEEDOR.PRO_ID where ACTIVO.ACT_ID='" + act + "'");
            Object factura = sql.ExecuteSqlObject(
               "  select ISNULL(act_numfact,0) as Factura from activo where ACT_ID='" + act + "'");
            Object depreacumulada = sql.ExecuteSqlObject(
              "select ISNULL(a.ACT_DEPREACUMULADA, '0' ) as depreacumulada from activo as a  where act_id ='" + act + "'");

            Object valorcompra = sql.ExecuteSqlObject(
              "select ISNULL(a.ACT_VALORCOMPRA,'0' ) as compra from activo as a  where act_id ='" + act + "'");
            Object sxd = sql.ExecuteSqlObject(
              "SELECT COALESCE(d.DEP_SALDOXDEPRE, '0') AS DEP_SALDOXDEPRE FROM ACTIVO AS a LEFT JOIN DEPRECIACIONSRI AS d ON d.ACT_ID = a.ACT_ID\r\nWHERE a.ACT_ID ='" + act + "' and DEP_FECHAPROX=(SELECT CONVERT(DATE, EOMONTH(DATEADD(MONTH, -1, GETDATE()))) AS UltimoDiaDelMesAnterior)");
            //EMPIEZA PDF

            //creamos el documento
            //...ahora configuramos para que el tamaño de hoja sea A4
            //Document document = new Document(iTextSharp.text.PageSize.A4);
            Document document = new Document(new RectangleReadOnly(842f, 595f), 50, 30, 15, 5);
            //document.PageSize.Rotate();

            //hacemos que se inserte la fecha de creación para el documento
            document.AddCreationDate();


            //...título
            document.AddTitle("ACTA DE TRASLADO DE LOS ACTIVOS FIJOS Y BIENES SUJETOS DE CONTROL");

            //... el asunto
            document.AddSubject("ACTA DE TRASLADO");


            //string Path = "c:/" + System.DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss") + "ACTA DE ENTREGA RECEPCIÓN.pdf";
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
            jpg.Alignment = iTextSharp.text.Image.ALIGN_RIGHT;
            document.Add(jpg);

            Paragraph P1 = new Paragraph("COOPERATIVA DE AHORRO Y CREDITO ALIANZA DEL VALLE LTDA. ");
            P1.Alignment = Element.ALIGN_CENTER;

            document.Add(P1);
            document.Add(new Paragraph("\n"));


            Paragraph P = new Paragraph("ACTA DE TRANSFERENCIAS INTERNAS DE ACTIVOS FIJOS Y ACTIVOS DE CONTROL" + "\n", myfontTitulo);
            P.Alignment = Element.ALIGN_CENTER;
            document.Add(P);

            document.Add(new Paragraph("\n"));

            //Paragraph P01 = new Paragraph("ACTA DE TRASLADO DE LOS ACTIVOS FIJOS Y BIENES DE CONTROL DE LA UNIDAD ADMINISTRATIVA; ENTRE EL SEÑOR(a). " +  
            //                              AnteriorCus + ", Y SEÑOR(a) " + NuevoCus.ToString() + ", CUSTODIOS QUIENES ENTREGAN Y RECEPTAN LOS ACTIVOS RESPECTIVAMENTE, AL " + DateTime.Now.ToString("dd-MM-yyyy"), myfont);
            //P01.Alignment = Element.ALIGN_JUSTIFIED;
            //document.Add(P01);

            //document.Add(new Paragraph("\n"));
            CultureInfo culturaEspañol = new CultureInfo("es-ES");

            Paragraph P02 = new Paragraph("En la ciudad de QUITO, a los " + DateTime.Now.Day + " del mes de " + DateTime.Now.ToString("MMMM", culturaEspañol) + " del " + DateTime.Now.Year + ", Sr(a) " + AnteriorCus +
                          " Oficial de crédito de la Agencia " + Uorg2.ToString() + ", realiza la entrega formal de los Activos Fijos y Activos de Control a Sr(a). " + NuevoCus.ToString() + " Oficial de crédito de la Agencia  " + ddCcosto.SelectedItem.Text.Trim() + " , de acuerdo con el siguiente detalle:", myfont);
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
            //PdfPCell AOfi = new PdfPCell(new Phrase("Oficina: " + ddUge2.SelectedItem.Text.Trim(), myfont));
            //AOfi.BorderWidth = 0;

            //PdfPCell DeCCosto = new PdfPCell(new Phrase("Centro Costo: " + Uorg2, myfont));
            //DeCCosto.BorderWidth = 0;
            //PdfPCell ACCosto = new PdfPCell(new Phrase("Centro Costo: " + ddUor1.SelectedItem.Text.Trim(), myfont));
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
            phead311.Add(new Chunk(proveedor1.ToString(), myfontLabel));
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
            phead1311.Add(new Chunk(valorcompra.ToString(), myfontLabel));
            PdfPCell cell1311head = new PdfPCell(phead1311);
            tableDatos.AddCell(cell1311head);


            Phrase phead1411 = new Phrase();
            phead1411.Add(new Chunk(depreacumulada.ToString(), myfontLabel));
            PdfPCell cell1411head = new PdfPCell(phead1411);
            tableDatos.AddCell(cell1411head);

            Phrase phead1511 = new Phrase();
            phead1511.Add(new Chunk((sxd != null) ? sxd.ToString() : "0.00", myfontLabel));
            PdfPCell cell1511head = new PdfPCell(phead1511);
            tableDatos.AddCell(cell1511head);

            tableDatos.WidthPercentage = 100;
            document.Add(tableDatos);

            document.Add(new Paragraph("\n"));

            Paragraph P3 = new Paragraph("Se deja constancia que el custodio  el señor " + NuevoCus.ToString() + " recibe a entera satisfacción los activos fijos detallados y  se encargará de velar por el buen uso, administración, así como garantizar que las condiciones sean adecuadas para su funcionamiento y no se encuentren en riesgo de deterioro.  En caso de pérdida o mal uso se aplicará lo establecido en la normativa interna de la Cooperativa.", myfont);
            P3.Alignment = Element.ALIGN_JUSTIFIED;
            document.Add(P3);

            document.Add(new Paragraph("\n"));

            Paragraph P41 = new Paragraph("Para Constancia de lo actuado y en fe de conformidad y aceptación, suscriben la presente acta entrega-recepción en 1 ejemplares de igual tenor y efecto las personas que intervienen en esta diligencia. \n", myfont);
            P41.Alignment = Element.ALIGN_JUSTIFIED;
            document.Add(P41);

            document.Add(new Paragraph("\n"));

            document.Add(new Paragraph("\n\n"));
            document.Add(new Paragraph("\n\n"));

            //Tabla para poner firmas
            string cusActivoFijo = ConfigurationManager.AppSettings["AreaActivosFijosIngreso"];
            PdfPTable tableFirma = new PdfPTable(2);

            //PdfPCell cellUBI1 = new PdfPCell(new Phrase(Uorg2 , myfont);
            PdfPCell cellUBI1 = new PdfPCell(new Phrase(new Chunk(Uorg2.ToString(), myfont)));

            PdfPCell cellUBI2 = new PdfPCell(new Phrase(ddCcosto.SelectedItem.Text.Trim(), myfont));
            PdfPCell cellEntrega = new PdfPCell(new Phrase("Sr(a) " + AnteriorCus.ToString(), myfont));
            PdfPCell cellRecibe = new PdfPCell(new Phrase("Sr(a) " + NuevoCus.ToString(), myfont));
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

    private void abreVentana(string ventana)
    {
        string funcion = "OpenWindows('" + ventana + "')";

        string f = "windowOpener('" + ventana + "')";

        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "DICE", f, true);
    }

    protected void txtbuscb_TextChanged(object sender, EventArgs e)
    {
        buscarCb();
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

    protected void ddUor1_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        Logica.UORGANICA zet = new Logica.UORGANICA(Convert.ToInt32(ddUor1.SelectedValue));
        lblCentroCosto2.Text = zet.UOR_CODIGO;
        lblCentroCostoDepre2.Text = zet.UOR_CODIGO;
        Logica.UGEOGRAFICA uget = new Logica.UGEOGRAFICA(Convert.ToInt32(ddUge2.SelectedValue));
        lblOficina2.Text = uget.UGE_CODIGO;
        lblOficinaDepre2.Text = uget.UGE_CODIGO;
        upAsiento.Update();
    }
}
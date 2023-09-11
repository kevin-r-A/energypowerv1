using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Site_Activos_DetContable : System.Web.UI.Page
{
    ErrorTrapper errtrap;
    protected void Page_Load(object sender, EventArgs e)
    {
        
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
                



                ibsave.Attributes.Add("onmouseout", "this.src='../../Img/s1.png'");
                ibsave.Attributes.Add("onmouseover", "this.src='../../Img/s2.png'");
                ibcancel.Attributes.Add("onmouseout", "this.src='../../Img/c1.png'");
                ibcancel.Attributes.Add("onmouseover", "this.src='../../Img/c2.png'");



                string msg = "";
                msg = Request["msg"];
                if (msg == "1")
                {
                    lblmsg.Text = "Detalle contable guardado con éxito!";
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
                if (Logica.HELPER.comprobarCbIngresado(txtbuscb.Text))
                {
                    //cargar datos
                    Panel1.Visible = true;
                    cargarActivo("cb");
                }
                else
                {
                    Panel1.Visible = false;
                    messbox1.Mensaje = "Código Válido, pero aún no ha sido ingresado!";
                    messbox1.Tipo = "I";
                    messbox1.showMess();
                }
            }
            else
            {
                Panel1.Visible = false;
                messbox1.Mensaje = "El Código de Barras No Válido!";
                messbox1.Tipo = "W";
                messbox1.showMess();
            }
        }
        catch (Exception ex)
        {
            errtrap = new ErrorTrapper();
            messbox1.Mensaje = "Error: " + ex.Message;
            messbox1.Tipo = "E";
            messbox1.showMess();
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
            messbox1.Mensaje = "Error: " + ex.Message;
            messbox1.Tipo = "E";
            messbox1.showMess();
            return "";
        }
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
                Panel1.Visible = true;
                cargarActivo("id");
            }
            else
            {
                Panel1.Visible = false;
                messbox1.Mensaje = "No se encontró ningún item con Id = " + txtbusid.Text.Trim();
                messbox1.Tipo = "I";
                messbox1.showMess();
            }
        }
        catch (Exception ex)
        {
            errtrap = new ErrorTrapper();
            messbox1.Mensaje = "Error: " + ex.Message;
            messbox1.Tipo = "E";
            messbox1.showMess();
        }
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
        Logica.ACTIVO act = new Logica.ACTIVO(int.Parse(lbl_Id.Text));

        act.USERNAME = Membership.GetUser().UserName.ToLower();

        act.Id = int.Parse(lbl_Id.Text);
        act.ACT_NUMFACT = int.Parse(txtFactura.Text.Trim());
        act.ACT_FECHACOMPRA = dtp_Compra.SelectedDate.Value;
        act.ACT_VALORCOMPRA = decimal.Parse(txtValCompra.Text.Replace(",", "."), System.Globalization.NumberStyles.Currency, new System.Globalization.CultureInfo("en-US"));
        act.ACT_VIDAUTILNIIF = int.Parse(txt_VidautilNiff.Text.Trim());
        act.ACT_VALORRESIDUALNIIF = decimal.Parse(txt_ValResNIFF.Text.Replace(",", "."), System.Globalization.NumberStyles.Currency, new System.Globalization.CultureInfo("en-US"));
        act.ACT_FECHAINIOPER = dtp_Inicio.SelectedDate.Value;


        //guardo activo
        string err = "";

        //actualizo
        //err = act.updContable();

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


            Response.Redirect("DetContable.aspx?msg=1");
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

            
            string where="";

            if (tipo == "cb")

                where = "where act_codbarras= '" + txtbuscb.Text.Trim()+"'";

            else if (tipo == "id")
                where = "where act_id= " + txtbusid.Text.Trim();



            Datos.SqlService sql = new Datos.SqlService();
            Object Obj = sql.ExecuteSqlObject("select act_codbarras from activo " + where);
            lbl_CodBarras.Text = Obj.ToString();

            Obj = sql.ExecuteSqlObject("select act_id from activo " + where);
            lbl_Id.Text = Obj.ToString();



            Obj = sql.ExecuteSqlObject("select G.Gru_Nombre from activo INNER join GRUPO G on activo.GRU_ID1= G.GRU_ID " + where);
            lbl_Grupo.Text = Obj.ToString();
            Obj = sql.ExecuteSqlObject("select G.Gru_Nombre from activo INNER join GRUPO G on activo.GRU_ID2= G.GRU_ID " + where);
            lbl_Subgrupo.Text = Obj.ToString();
            Obj = sql.ExecuteSqlObject("select G.Gru_Nombre from activo INNER join GRUPO G on activo.GRU_ID3= G.GRU_ID " + where);
            lbl_Descripcion.Text = Obj.ToString();


            Obj = sql.ExecuteSqlObject("select UG.Uge_Nombre from activo INNER JOIN UGEOGRAFICA UG ON activo.UGE_ID1=UG.UGE_ID " + where);
            lbl_UbGeo1.Text = Obj.ToString();
            Obj = sql.ExecuteSqlObject("select UG.Uge_Nombre from activo INNER JOIN UGEOGRAFICA UG ON activo.UGE_ID2=UG.UGE_ID " + where);
            bl_UbiGeo2.Text = Obj.ToString();
            Obj = sql.ExecuteSqlObject("select UG.Uge_Nombre from activo INNER JOIN UGEOGRAFICA UG ON activo.UGE_ID3=UG.UGE_ID " + where);
            lbl_UbiGeo3.Text = Obj.ToString();


            Obj = sql.ExecuteSqlObject("select UO.UOR_Nombre from activo INNER JOIN UORGANICA UO ON activo.UOR_ID1=UO.UOR_ID " + where);
            lbl_ceCosto.Text = Obj.ToString();
            Obj = sql.ExecuteSqlObject("select UO.UOR_Nombre from activo INNER JOIN UORGANICA UO ON activo.UOR_ID2=UO.UOR_ID " + where);
            lbl_UbiOrg.Text = Obj.ToString();

            Obj = sql.ExecuteSqlObject("select CU.CUS_Nombres + ' '+CU.Cus_Apellidos from activo INNER JOIN CUSTODIO CU ON activo.CUS_ID1=CU.CUS_ID " + where);
            lbl_custodio.Text = Obj.ToString();


            Obj = sql.ExecuteSqlObject("select ACT_NUMFACT from activo " + where);
            txtFactura.Text = Obj.ToString();

            Obj = sql.ExecuteSqlObject("select ACT_FECHACOMPRA from activo " + where);
            dtp_Compra.SelectedDate = Convert.ToDateTime(Obj.ToString());

            Obj = sql.ExecuteSqlObject("select ACT_VALORCOMPRA from activo " + where);
            txtValCompra.Text = Obj.ToString();

            Obj = sql.ExecuteSqlObject("select ACT_VIDAUTIL from activo " + where);
            Lbl_Vidautil.Text = Obj.ToString();

            Obj = sql.ExecuteSqlObject("select ACT_VIDAUTILNIIF from activo " + where);
            txt_VidautilNiff.Text = Obj.ToString();

            Obj = sql.ExecuteSqlObject("select ACT_VALORRESIDUALNIIF from activo " + where);
            txt_ValResNIFF.Text = Obj.ToString();

            Obj = sql.ExecuteSqlObject("select ACT_FECHAINIOPER from activo " + where);

            if (Obj.ToString() != "")
            {
                dtp_Inicio.SelectedDate = Convert.ToDateTime(Obj.ToString());
            }
            


        }
        catch (Exception ex)
        {
            errtrap = new ErrorTrapper();
            messbox1.Mensaje = "Error: " + ex.Message;
            messbox1.Tipo = "E";
            messbox1.showMess();
        }
    }


    protected void ibcancel_Click(object sender, ImageClickEventArgs e)
    {

        Response.Redirect("DetContable.aspx");

    }
}
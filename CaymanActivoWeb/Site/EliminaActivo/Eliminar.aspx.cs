using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Security;
public partial class Site_EliminaActivo_Eliminar : System.Web.UI.Page
{

    C5ALIANZAVALLE23102015Entities ent = new C5ALIANZAVALLE23102015Entities();
   ErrorTrapper errtrap = new ErrorTrapper();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = ConfigurationManager.AppSettings["Titulo"] + " Buscar/Eliminar Activo";
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

        if (!IsPostBack)
        {
            ibsave.Attributes.Add("onmouseout", "this.src='../../Img/Elimina2.png'");
            ibsave.Attributes.Add("onmouseover", "this.src='../../Img/elimina1.png'");
            ibcancel.Attributes.Add("onmouseout", "this.src='../../Img/c1.png'");
            ibcancel.Attributes.Add("onmouseover", "this.src='../../Img/c2.png'");
        }
    }
    protected void ibbus1_Click(object sender, ImageClickEventArgs e)
    {
        lblmsg.Text = "";
        txtbusid.Text = "";

            if (codigoCorrecto())
            {
                if (Logica.HELPER.comprobarCbIngresado(txtbuscb.Text.Trim()))
                {

                    if (Logica.Mantenimiento.verificaMantenimiento(txtbuscb.Text.Trim()))
                    {
                        
                        messbox1.Mensaje = "El Activo actualmente esta en Mantenimiento, no se puede realizar ningun cambio, comuniquese con el Administrador...!!!";
                        messbox1.Tipo = "W";
                        messbox1.showMess();
                    }
                    else
                    {

                        var act = ent.ACTIVO.FirstOrDefault(y => y.ACT_CODBARRAS == txtbuscb.Text.Trim());

                        if (act.ACT_ID > 0)
                        {
                            lbl_Id.Text = act.ACT_ID.ToString();
                            lbl_CodBarras.Text = act.ACT_CODBARRAS;
                            lbl_Grupo.Text = ent.GRUPO.FirstOrDefault(y => y.GRU_ID == act.GRU_ID1).GRU_NOMBRE;
                            lbl_Subgrupo.Text = ent.GRUPO.FirstOrDefault(y => y.GRU_ID == act.GRU_ID2).GRU_NOMBRE;
                            lbl_Descripcion.Text = ent.GRUPO.FirstOrDefault(y => y.GRU_ID == act.GRU_ID3).GRU_NOMBRE;
                            lbl_UbGeo1.Text = ent.UGEOGRAFICA.FirstOrDefault(y => y.UGE_ID == act.UGE_ID1).UGE_NOMBRE;
                            lbl_UbiGeo2.Text = ent.UGEOGRAFICA.FirstOrDefault(y => y.UGE_ID == act.UGE_ID2).UGE_NOMBRE;
                            lbl_UbiGeo3.Text = ent.UGEOGRAFICA.FirstOrDefault(y => y.UGE_ID == act.UGE_ID3).UGE_NOMBRE;
                            lbl_ceCosto.Text = ent.UORGANICA.FirstOrDefault(y => y.UOR_ID == act.UOR_ID1).UOR_NOMBRE;
                            lbl_UbiOrg.Text = ent.UORGANICA.FirstOrDefault(y => y.UOR_ID == act.UOR_ID2).UOR_NOMBRE;
                            lbl_custodio.Text = ent.CUSTODIO.FirstOrDefault(y => y.CUS_ID == act.CUS_ID1).CUS_NOMBRES + " " + ent.CUSTODIO.FirstOrDefault(y => y.CUS_ID == act.CUS_ID1).CUS_APELLIDOS;

                            Datos.Visible = true;
                            Panel23.Visible = true;
                        }
                    }
                    
                }
                else
                {
                    messbox1.Mensaje = "No se puede encontrar Item, aún no ha sido ingresado!";
                    messbox1.Tipo = "I";
                    messbox1.showMess();
                    Datos.Visible = false;
                    Panel23.Visible = false;
                }

            }
            else
            {
                messbox1.Mensaje = "El Código de Barras No Válido!";
                messbox1.Tipo = "W";
                messbox1.showMess();
                Datos.Visible = false;
                Panel23.Visible = false;
            }
        
    }
    protected void ibcancel_Click(object sender, ImageClickEventArgs e)
    {
        Datos.Visible = false;
        Panel23.Visible = false;
        txtbuscb.Text = "";
        txtbusid.Text = "";
    }
    protected void ibsave_Click(object sender, ImageClickEventArgs e)
    {
        if (Datos.Visible == true && Panel23.Visible == true)
        {
            EliminaActivo el = new EliminaActivo();

            if (el.EliminaActivoId(int.Parse(lbl_Id.Text.Trim())))
            {
                messbox1.Mensaje = "Activo Eliminado con Éxito...!!!";
                messbox1.Tipo = "S";
                messbox1.showMess();

                txtbuscb.Text = "";

                Datos.Visible = false;
                Panel23.Visible = false;
            }
            else
            {
                messbox1.Mensaje = "No se pudo Eliminar el Activo..!!!";
                messbox1.Tipo = "E";
                messbox1.showMess();
            }
        }

        else
        {
            messbox1.Mensaje = "No se Puede Eliminar Activo, debe buscar un código!";
            messbox1.Tipo = "E";
            messbox1.showMess();
            Datos.Visible = false;
            Panel23.Visible = false;
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
    protected void ibbus3_Click(object sender, ImageClickEventArgs e)
    {
        lblmsg.Text = "";
        txtbuscb.Text = "";

        //if (codigoCorrecto())
        //{
            if (Logica.HELPER.comprobarCodLogikard(txtbusid.Text.Trim()))
            {
                if (Logica.Mantenimiento.verificaMantenimiento(txtbuscb.Text.Trim()))
                {

                    messbox1.Mensaje = "El Activo actualmente esta en Mantenimiento, no se puede realizar ningun cambio, comuniquese con el Administrador...!!!";
                    messbox1.Tipo = "W";
                    messbox1.showMess();
                }
                else
                {

                    ACTIVO a = ent.ACTIVO.FirstOrDefault(y => y.ACT_CODIGO1 == txtbusid.Text.Trim());

                    var act = ent.ACTIVO.FirstOrDefault(y => y.ACT_CODBARRAS == a.ACT_CODBARRAS.Trim());



                    if (act.ACT_ID > 0)
                    {
                        lbl_Id.Text = act.ACT_ID.ToString();
                        lbl_CodBarras.Text = act.ACT_CODBARRAS;
                        lbl_Grupo.Text = ent.GRUPO.FirstOrDefault(y => y.GRU_ID == act.GRU_ID1).GRU_NOMBRE;
                        lbl_Subgrupo.Text = ent.GRUPO.FirstOrDefault(y => y.GRU_ID == act.GRU_ID2).GRU_NOMBRE;
                        lbl_Descripcion.Text = ent.GRUPO.FirstOrDefault(y => y.GRU_ID == act.GRU_ID3).GRU_NOMBRE;
                        lbl_UbGeo1.Text = ent.UGEOGRAFICA.FirstOrDefault(y => y.UGE_ID == act.UGE_ID1).UGE_NOMBRE;
                        lbl_UbiGeo2.Text = ent.UGEOGRAFICA.FirstOrDefault(y => y.UGE_ID == act.UGE_ID2).UGE_NOMBRE;
                        lbl_UbiGeo3.Text = ent.UGEOGRAFICA.FirstOrDefault(y => y.UGE_ID == act.UGE_ID3).UGE_NOMBRE;
                        lbl_ceCosto.Text = ent.UORGANICA.FirstOrDefault(y => y.UOR_ID == act.UOR_ID1).UOR_NOMBRE;
                        lbl_UbiOrg.Text = ent.UORGANICA.FirstOrDefault(y => y.UOR_ID == act.UOR_ID2).UOR_NOMBRE;
                        lbl_custodio.Text = ent.CUSTODIO.FirstOrDefault(y => y.CUS_ID == act.CUS_ID1).CUS_NOMBRES + " " + ent.CUSTODIO.FirstOrDefault(y => y.CUS_ID == act.CUS_ID1).CUS_APELLIDOS;

                        Datos.Visible = true;
                        Panel23.Visible = true;
                    }
                }
            }
            else
            {
                messbox1.Mensaje = "No se puede encontrar Item, aún no ha sido ingresado!";
                messbox1.Tipo = "I";
                messbox1.showMess();
                Datos.Visible = false;
                Panel23.Visible = false;
            }

        //}
        //else
        //{
        //    messbox1.Mensaje = "El Código de Barras No Válido!";
        //    messbox1.Tipo = "W";
        //    messbox1.showMess();
        //    Datos.Visible = false;
        //    Panel23.Visible = false;
        //}
        
    }
}
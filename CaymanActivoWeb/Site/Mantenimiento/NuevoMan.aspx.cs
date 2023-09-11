using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Site_Mantenimiento_NuevoMan : System.Web.UI.Page
{
    ErrorTrapper errtrap;
    protected void Page_Load(object sender, EventArgs e)
    {

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
                    PanMan.Visible = true;
                    //cargarActivo("cb");
                }
                else
                {
                    PanMan.Visible = false;
                    messbox1.Mensaje = "Código Válido, pero aún no ha sido ingresado!";
                    messbox1.Tipo = "I";
                    messbox1.showMess();
                }
            }
            else
            {
                PanMan.Visible = false;
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
    protected void ibbus3_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            txtbuscb.Text = "";

            if (Logica.HELPER.comprobarIdIngresado(txtbusid.Text.Trim()))
            {
                //cargar datos
                PanMan.Visible = true;
               // cargarActivo("id");
            }
            else
            {
                PanMan.Visible = false;
                messbox1.Mensaje = "No se encontró ningún item con Id = " + txtbusid.Text.Trim();
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
}

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

        }

        string ide = Request["id"];
        if (ide != null)
        {
            pantras.Visible = true;
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
        try
        {
            txtbusid.Text = "";
            if (codigoCorrecto())
            {
                if (Logica.HELPER.comprobarCbIngresado(txtbuscb.Text))
                {
                    messbox1.Mensaje = "Activo encontrado";
                    messbox1.Tipo = "S";
                    messbox1.showMess();
                    //cargar datos
                    pantras.Visible = true;
                    cargarActivo(txtbuscb.Text, "cb");
                }
                else
                {
                    pantras.Visible = false;
                    messbox1.Mensaje = "Código Válido, pero aún no ha sido ingresado!";
                    messbox1.Tipo = "I";
                    messbox1.showMess();
                    rgtras.DataSource = null;
                    rgtras.DataBind();
                }
            }
            else
            {
                messbox1.Mensaje = "El Código de Barras No Válido!";
                messbox1.Tipo = "W";
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

    public void cargarActivo(string cod, string tipo)
    {
        try
        {
            rgtras.DataSource = Logica.HELPER.getMantenimiento(cod, tipo);
            rgtras.DataBind();
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

            if (Logica.HELPER.comprobarIdIngresado(txtbusid.Text.Trim()))
            {
                messbox1.Mensaje = "Activo encontrado";
                messbox1.Tipo = "S";
                messbox1.showMess();
                //cargar datos
                pantras.Visible = true;
                cargarActivo(txtbusid.Text, "id");
            }
            else
            {
                pantras.Visible = false;
                messbox1.Mensaje = "No se encontró ningún item con Id = " + txtbusid.Text.Trim();
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
}

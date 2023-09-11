using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Security;


public partial class ZCar : System.Web.UI.Page
{
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
            cargarCargo();
            this.Title = ConfigurationManager.AppSettings["Titulo"] + " Catálogos - Cargos";
        }
    }
    private void cargarCargo()
    {
        Logica.CARGO zet = new Logica.CARGO();
        rlbcargo.DataSource = zet.getCargos();
        rlbcargo.DataTextField = "cgo_nombre";
        rlbcargo.DataValueField = "cgo_id";
        rlbcargo.DataBind();
        upcargo.Update();
    }

    protected void btncerrar2_Click(object sender, EventArgs e)
    {
        txtnombre2.Text = "";
        upnuevo2.Update();
        mp2.Hide();
    }

    protected void btnsave2_Click(object sender, EventArgs e)
    {        
            if (lblmp2.Text == "Editar Cargo")
            {
                Logica.CARGO zet = new Logica.CARGO();
                zet.CGO_NOMBRE = Logica.HELPER.capitalize(txtnombre2.Text);
                zet.Id = int.Parse(rlbcargo.SelectedValue);
                zet.Update();
                cargarCargo();
            }
            else if (lblmp2.Text == "Nuevo Cargo")
            {
                if (!Logica.HELPER.existeCargoIng(Logica.HELPER.capitalize(txtnombre2.Text)))
                {
                    Logica.CARGO zet = new Logica.CARGO();
                    zet.CGO_NOMBRE = Logica.HELPER.capitalize(txtnombre2.Text);
                    zet.Create();
                    cargarCargo();
                }
            }
         
            txtnombre2.Text = "";
            upnuevo2.Update();
            mp2.Hide();
    }
    protected void ibgr7_Click(object sender, ImageClickEventArgs e)
    {
            lblmp2.Text = "Nuevo Cargo";
            upnuevo2.Update();
            mp2.Show();
    }
    protected void ibgr8_Click(object sender, ImageClickEventArgs e)
    {
        if (rlbcargo.SelectedItem != null)
        {
            lblmp2.Text = "Editar Cargo";
            txtnombre2.Text = rlbcargo.SelectedItem.Text;
            upnuevo2.Update();
            mp2.Show();
        }
    }
    protected void ibgr9_Click(object sender, ImageClickEventArgs e)
    {
        if (rlbcargo.SelectedItem != null)
        {
            if (!Logica.CARGO.valRelActivo(rlbcargo.SelectedValue))
            {
                Logica.CARGO.Delete(int.Parse(rlbcargo.SelectedValue));
                cargarCargo();
            }
            else
            {
                messbox1.Mensaje = "No pudo ser eliminado ya que activamente se relaciona con activos";
                messbox1.Tipo = "E";
                messbox1.showMess();
            }
        }
    }
}
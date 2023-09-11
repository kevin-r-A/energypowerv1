using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;


public partial class ZEstrucomp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cargarEstructura(); 
            this.Title = ConfigurationManager.AppSettings["Titulo"] + " Catálogos - Estructura/Componente";
        }
    }
    private void cargarEstructura()
    {
        Logica.ESTRUCOMP est = new Logica.ESTRUCOMP();
        rlbestruc.DataSource = est.getEstructuras();
        rlbestruc.DataTextField = "eco_nombre";
        rlbestruc.DataValueField = "eco_id";
        rlbestruc.DataBind();
        upcol.Update();
    }

    protected void btncerrar2_Click(object sender, EventArgs e)
    {
        txtnombre2.Text = "";
        upnuevo2.Update();
        mp2.Hide();
    }

    protected void btnsave2_Click(object sender, EventArgs e)
    {
        if (lblmp2.Text == "Editar Estructura/Componente")
        {
            Logica.ESTRUCOMP est = new Logica.ESTRUCOMP();
            est.ECO_NOMBRE = Logica.HELPER.capitalize(txtnombre2.Text);
            est.Id = int.Parse(rlbestruc.SelectedValue);
            est.Update();
        }
        else if (lblmp2.Text == "Nueva Estructura/Componente")
        {
            if (!Logica.HELPER.existeEstrucIng(Logica.HELPER.capitalize(txtnombre2.Text)))
            {
                Logica.ESTRUCOMP est = new Logica.ESTRUCOMP();
                est.ECO_NOMBRE = Logica.HELPER.capitalize(txtnombre2.Text);
                est.Create();
            }
        }
        mp2.Hide();
        cargarEstructura();
        txtnombre2.Text = "";
        upnuevo2.Update();           
    }
    protected void ibgr7_Click(object sender, ImageClickEventArgs e)
    {
            lblmp2.Text = "Nueva Estructura/Componente";
            upnuevo2.Update();
            mp2.Show();
    }
    protected void ibgr8_Click(object sender, ImageClickEventArgs e)
    {
        if (rlbestruc.SelectedItem != null)
        {
            lblmp2.Text = "Editar Estructura/Componente";
            txtnombre2.Text = rlbestruc.SelectedItem.Text;
            upnuevo2.Update();
            mp2.Show();
        }
    }
    protected void ibgr9_Click(object sender, ImageClickEventArgs e)
    {
        if (rlbestruc.SelectedItem != null)
        {
            if (!Logica.ESTRUCOMP.valRelActivo(rlbestruc.SelectedValue))
            {
                Logica.ESTRUCOMP.Delete(int.Parse(rlbestruc.SelectedValue));
                cargarEstructura();
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
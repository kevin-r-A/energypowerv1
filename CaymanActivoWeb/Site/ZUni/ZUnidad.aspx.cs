using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class ZUnidad : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cargarUnidad();
            this.Title = ConfigurationManager.AppSettings["Titulo"] + " Catálogos - Unidades";
        }
    }
    private void cargarUnidad()
    {
        Logica.UNIDAD tri = new Logica.UNIDAD();

        rlbunidad.DataSource = tri.getUnidades();
        rlbunidad.DataTextField = "uni_simbolo";
        rlbunidad.DataValueField = "uni_id";
        rlbunidad.DataBind();
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
        if (lblmp2.Text == "Editar Unidad")
        {
            Logica.UNIDAD tri = new Logica.UNIDAD();
            tri.UNI_SIMBOLO = Logica.HELPER.capitalize(txtnombre2.Text);
            tri.Id = int.Parse(rlbunidad.SelectedValue);
            tri.Update();            
        }
        else if (lblmp2.Text == "Nueva Unidad")
        {
            if (!Logica.UNIDAD.fgetUniIng(Logica.HELPER.capitalize(txtnombre2.Text)))
            {
                Logica.UNIDAD tri = new Logica.UNIDAD();
                tri.UNI_SIMBOLO = Logica.HELPER.capitalize(txtnombre2.Text);
                tri.Create();
            }
        }
        
        cargarUnidad();
        mp2.Hide();        
        txtnombre2.Text = "";
        upnuevo2.Update();         
    }
    protected void ibgr7_Click(object sender, ImageClickEventArgs e)
    {
            lblmp2.Text = "Nueva Unidad";
            upnuevo2.Update();
            mp2.Show();
    }
    protected void ibgr8_Click(object sender, ImageClickEventArgs e)
    {
        if (rlbunidad.SelectedItem != null)
        {
            lblmp2.Text = "Editar Unidad";
            txtnombre2.Text = rlbunidad.SelectedItem.Text;
            upnuevo2.Update();
            mp2.Show();
        }
    }
    protected void ibgr9_Click(object sender, ImageClickEventArgs e)
    {
        if (rlbunidad.SelectedItem != null)
        {
            if (!Logica.UNIDAD.valRelActivo(rlbunidad.SelectedValue))
            {
                Logica.UNIDAD.Delete(int.Parse(rlbunidad.SelectedValue));
                cargarUnidad();
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
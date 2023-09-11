using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class ZTSeg : System.Web.UI.Page
{
    TipoSeguro tseg = new TipoSeguro();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            cargarColores();
            this.Title = ConfigurationManager.AppSettings["Titulo"] + " Catálogos - Tipo Seguro";
        }
    }
    private void cargarColores()
    {
        
        rlbcolor.DataSource = tseg.CargarTipoSeguro();
        rlbcolor.DataValueField = "SEG_ID";
        rlbcolor.DataTextField = "SEG_NOMBRE";
        rlbcolor.DataBind();
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
        if (lblmp2.Text == "Editar Tipo Seguro")
        {
            //Logica.COLOR col = new Logica.COLOR();
            //col.COL_NOMBRE = Logica.HELPER.capitalize(txtnombre2.Text);
            //col.Id = int.Parse(rlbcolor.SelectedValue);

            tseg.Modificar(int.Parse(rlbcolor.SelectedValue), Logica.HELPER.capitalize(txtnombre2.Text));

            //col.Update();                
        }
        else if (lblmp2.Text == "Nuevo Tipo Seguro")
        {
            if (!tseg.existeSeguroIng(Logica.HELPER.capitalize(txtnombre2.Text)))
            {
                tseg.Guardar(Logica.HELPER.capitalize(txtnombre2.Text));
            }
        }
        cargarColores();
        mp2.Hide();        
        txtnombre2.Text = "";
        upnuevo2.Update();         
    }
    protected void ibgr7_Click(object sender, ImageClickEventArgs e)
    {
        lblmp2.Text = "Nuevo Tipo Seguro";
        upnuevo2.Update();
        mp2.Show();
    }
    protected void ibgr8_Click(object sender, ImageClickEventArgs e)
    {
        if (rlbcolor.SelectedItem != null)
        {
            lblmp2.Text = "Editar Tipo Seguro";
            txtnombre2.Text = rlbcolor.SelectedItem.Text;
            upnuevo2.Update();
            mp2.Show();
        }
    }
    protected void ibgr9_Click(object sender, ImageClickEventArgs e)
    {
        if (rlbcolor.SelectedItem != null)
        {
            if (!tseg.valRelActivo(int.Parse(rlbcolor.SelectedValue)))
            {
                tseg.Eliminar(int.Parse(rlbcolor.SelectedValue));
                cargarColores();
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
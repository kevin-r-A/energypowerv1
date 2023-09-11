using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class ZColor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            cargarColores();
            this.Title = ConfigurationManager.AppSettings["Titulo"] + " Catálogos - Color";
        }
    }
    private void cargarColores()
    {
        Logica.COLOR col = new Logica.COLOR();
        rlbcolor.DataSource = col.getColores();
        rlbcolor.DataTextField = "col_nombre";
        rlbcolor.DataValueField = "col_id";
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
        if (lblmp2.Text == "Editar Color")
        {
            Logica.COLOR col = new Logica.COLOR();
            col.COL_NOMBRE = Logica.HELPER.capitalize(txtnombre2.Text);
            col.Id = int.Parse(rlbcolor.SelectedValue);
            col.Update();                
        }
        else if (lblmp2.Text == "Nuevo Color")
        {
            if (!Logica.HELPER.existeColorIng(Logica.HELPER.capitalize(txtnombre2.Text)))
            {
                Logica.COLOR col = new Logica.COLOR();
                col.COL_NOMBRE=Logica.HELPER.capitalize(txtnombre2.Text);
                col.Create();
            }
        }
        cargarColores();
        mp2.Hide();        
        txtnombre2.Text = "";
        upnuevo2.Update();         
    }
    protected void ibgr7_Click(object sender, ImageClickEventArgs e)
    {
        lblmp2.Text = "Nuevo Color";
        upnuevo2.Update();
        mp2.Show();
    }
    protected void ibgr8_Click(object sender, ImageClickEventArgs e)
    {
        if (rlbcolor.SelectedItem != null)
        {
            lblmp2.Text = "Editar Color";
            txtnombre2.Text = rlbcolor.SelectedItem.Text;
            upnuevo2.Update();
            mp2.Show();
        }
    }
    protected void ibgr9_Click(object sender, ImageClickEventArgs e)
    {
        if (rlbcolor.SelectedItem != null)
        {
            if (!Logica.COLOR.valRelActivo(rlbcolor.SelectedValue))
            {
                Logica.COLOR.Delete(int.Parse(rlbcolor.SelectedValue));
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
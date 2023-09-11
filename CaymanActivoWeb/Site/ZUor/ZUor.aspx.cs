using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Security;

public partial class ZUor : System.Web.UI.Page
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
            if (ConfigurationManager.AppSettings["CCOUGE"] == "0")
            {
                Panel9.Visible = false;
            }
            else if (ConfigurationManager.AppSettings["CCOUGE"] == "1")
            {
                Panel9.Visible = true;
                cargarUge("usp_getUgeAll3Level1");
            }
            else if (ConfigurationManager.AppSettings["CCOUGE"] == "2")
            {
                Panel9.Visible = true;
                cargarUge("usp_getUgeAll3Level2");
            }
            else if (ConfigurationManager.AppSettings["CCOUGE"] == "3")
            {
                Panel9.Visible = true;
                cargarUge("usp_getUgeAll3Level3");
            }            
            this.Title = ConfigurationManager.AppSettings["Titulo"] + " Catálogos - Ubicación Orgánica";
        }
    }

    private void cargarUge(string sp)
    {
        Logica.UGEOGRAFICA zet = new Logica.UGEOGRAFICA();

        rlbgeo3.DataSource = zet.fGetUgeAll3Level(sp);
        rlbgeo3.DataTextField = "uge_nombre";
        rlbgeo3.DataValueField = "uge_id";
        rlbgeo3.DataBind();
        upgeo.Update();
    }

    private void cargarCcosto()
    {
        if (ConfigurationManager.AppSettings["CCOUGE"] == "0")
        {
            Logica.UORGANICA zet = new Logica.UORGANICA();
            rlbccosto.DataSource = zet.getUorAll(1, 0);
            rlbccosto.DataTextField = "uor_nombre";
            rlbccosto.DataValueField = "uor_id";
            rlbccosto.DataBind();
            upgeo.Update();
        }
        else
        {
            Logica.UORGANICA zet = new Logica.UORGANICA();
            rlbccosto.DataSource = zet.getUorAll1(1, 0, int.Parse(rlbgeo3.SelectedValue));
            rlbccosto.DataTextField = "uor_nombre";
            rlbccosto.DataValueField = "uor_id";
            rlbccosto.DataBind();
            upgeo.Update();
        }      
    }

    private void cargarUor1()
    {
        if (ConfigurationManager.AppSettings["UORCCO"] == "0")
        {
            Logica.UORGANICA zet = new Logica.UORGANICA();
            rlbuor1.DataSource = zet.getUorAll(2);
            rlbuor1.DataTextField = "uor_nombre";
            rlbuor1.DataValueField = "uor_id";
            rlbuor1.DataBind();
            upgeo.Update();
        }
        else
        {
            Logica.UORGANICA zet = new Logica.UORGANICA();
            rlbuor1.DataSource = zet.getUorAll(2, int.Parse(rlbccosto.SelectedValue));
            rlbuor1.DataTextField = "uor_nombre";
            rlbuor1.DataValueField = "uor_id";
            rlbuor1.DataBind();
            upgeo.Update();
        }    
    }

    private void cargarUor2()
    {
        Logica.UORGANICA zet = new Logica.UORGANICA();

        rlbuor2.DataSource = zet.getUorAll(3, int.Parse(rlbuor1.SelectedValue));
        rlbuor2.DataTextField = "uor_nombre";
        rlbuor2.DataValueField = "uor_id";
        rlbuor2.DataBind();
        upgeo.Update();
    }

    protected void rlbgeo1_SelectedIndexChanged(object sender, EventArgs e)
    {
        rlbuor1.Items.Clear();
        rlbuor2.Items.Clear();
        upgeo.Update();
        cargarCcosto();
    }

    protected void rlbgeo2_SelectedIndexChanged(object sender, EventArgs e)
    {
        rlbuor2.Items.Clear();
        upgeo.Update();
        cargarUor1();
    }

    protected void rlbgeo3_SelectedIndexChanged(object sender, EventArgs e)
    {
        cargarUor2();
    }
    
    protected void btncerrar2_Click(object sender, EventArgs e)
    {
        txtnombre2.Text = "";
        txtCodigo.Text = "";
        upnuevo2.Update();
        mp2.Hide();
    }

    protected void btnsave2_Click(object sender, EventArgs e)
    {
        if (lblmp2.Text == "Editar Centro de Costo")
        {
            Logica.UORGANICA zet = new Logica.UORGANICA();
            zet.UOR_NOMBRE = Logica.HELPER.capitalize(txtnombre2.Text);
            zet.UOR_CODIGO = txtCodigo.Text;
            zet.Id = int.Parse(rlbccosto.SelectedValue);
            zet.Update();
            cargarCcosto();
            rlbccosto.SelectedValue = zet.Id.ToString();
        }
        else if (lblmp2.Text == "Nuevo Centro de Costo")
        {
            if (Panel9.Visible)
            {
                Logica.UORGANICA zet = new Logica.UORGANICA();
                zet.UOR_NOMBRE = Logica.HELPER.capitalize(txtnombre2.Text);
                zet.UOR_CODIGO = txtCodigo.Text;
                zet.UOR_PADRE = 0;
                zet.UOR_NIVEL = 1;
                zet.UGE_ID = int.Parse(rlbgeo3.SelectedValue);
                zet.Create(txtCodigo.Text.Trim());
                cargarCcosto();
                rlbuor1.Items.Clear();
                rlbuor2.Items.Clear();
            }
            else
            {
                Logica.UORGANICA zet = new Logica.UORGANICA();
                zet.UOR_NOMBRE = Logica.HELPER.capitalize(txtnombre2.Text);
                zet.UOR_CODIGO = txtCodigo.Text;
                zet.UOR_PADRE = 0;
                zet.UOR_NIVEL = 1;
                zet.UGE_ID = 0;
                zet.Create(txtCodigo.Text.Trim());
                cargarCcosto();
                rlbuor1.Items.Clear();
                rlbuor2.Items.Clear();
            }
        }
        if (lblmp2.Text == "Editar Orgánica 1")
        {
            Logica.UORGANICA zet = new Logica.UORGANICA();
            zet.UOR_NOMBRE = Logica.HELPER.capitalize(txtnombre2.Text);
            zet.UOR_CODIGO = txtCodigo.Text;
            zet.Id = int.Parse(rlbuor1.SelectedValue);
            zet.Update();
            cargarUor1();
            rlbuor1.SelectedValue = zet.Id.ToString();
        }
        else if (lblmp2.Text == "Nueva Orgánica 1")
        {
            if (ConfigurationManager.AppSettings["UORCCO"] == "0")
            {
                Logica.UORGANICA zet = new Logica.UORGANICA();
                zet.UOR_NOMBRE = Logica.HELPER.capitalize(txtnombre2.Text);
                zet.UOR_CODIGO = txtCodigo.Text;
                zet.UOR_PADRE = 0;
                zet.UOR_NIVEL = 2;
                zet.Create(txtCodigo.Text.Trim());
                cargarUor1();
                rlbuor2.Items.Clear();  
            }
            else
            {
                Logica.UORGANICA zet = new Logica.UORGANICA();
                zet.UOR_NOMBRE = Logica.HELPER.capitalize(txtnombre2.Text);
                zet.UOR_PADRE = int.Parse(rlbccosto.SelectedValue);
                zet.UOR_NIVEL = 2;
                zet.Create(txtCodigo.Text.Trim());
                cargarUor1();
                rlbuor2.Items.Clear();            
            }
        }
        if (lblmp2.Text == "Editar Orgánica 2")
        {
            Logica.UORGANICA zet = new Logica.UORGANICA();
            zet.UOR_NOMBRE = Logica.HELPER.capitalize(txtnombre2.Text);
            zet.UOR_CODIGO = txtCodigo.Text;
            zet.Id = int.Parse(rlbuor2.SelectedValue);
            zet.Update();
            cargarUor2();
        }
        else if (lblmp2.Text == "Nueva Orgánica 2")
        {
            Logica.UORGANICA zet = new Logica.UORGANICA();
            zet.UOR_NOMBRE = Logica.HELPER.capitalize(txtnombre2.Text);
            zet.UOR_CODIGO = txtCodigo.Text;
            zet.UOR_PADRE = int.Parse(rlbuor1.SelectedValue);
            zet.UOR_NIVEL = 3;
            zet.Create(txtCodigo.Text.Trim());
            cargarUor2();
        }

        txtnombre2.Text = "";
        upnuevo2.Update();
        mp2.Hide();        
    }

    protected void ibgr7_Click(object sender, ImageClickEventArgs e)
    {
        if (rlbgeo3.SelectedItem != null && Panel9.Visible)
        {
            lblmp2.Text = "Nuevo Centro de Costo";
            upnuevo2.Update();
            mp2.Show();
        }
        else if (!Panel9.Visible)
        {
            lblmp2.Text = "Nuevo Centro de Costo";
            upnuevo2.Update();
            mp2.Show();
        }
    }
    protected void ibgr10_Click(object sender, ImageClickEventArgs e)
    {
        if (rlbccosto.SelectedItem != null && ConfigurationManager.AppSettings["UORCCO"] != "0")
        {
            lblmp2.Text = "Nueva Orgánica 1";
            upnuevo2.Update();
            mp2.Show();
        }
        else if (ConfigurationManager.AppSettings["UORCCO"] == "0")
        {
            lblmp2.Text = "Nueva Orgánica 1";
            upnuevo2.Update();
            mp2.Show();
        }
    }
    protected void ibgr13_Click(object sender, ImageClickEventArgs e)
    {
        if (rlbuor1.SelectedItem != null)
        {
            lblmp2.Text = "Nueva Orgánica 2";
            upnuevo2.Update();
            mp2.Show();
        }
    }
    protected void ibgr8_Click(object sender, ImageClickEventArgs e)
    {
        if (rlbccosto.SelectedItem != null)
        {
            Logica.UORGANICA zet = new Logica.UORGANICA(int.Parse(rlbccosto.SelectedValue));
            lblmp2.Text = "Editar Centro de Costo";
            txtnombre2.Text = rlbccosto.SelectedItem.Text;
            txtCodigo.Text = zet.UOR_CODIGO;
            upnuevo2.Update();
            mp2.Show();
        }
    }
    protected void ibgr11_Click(object sender, ImageClickEventArgs e)
    {
        if (rlbuor1.SelectedItem != null)
        {
            Logica.UORGANICA zet = new Logica.UORGANICA(int.Parse(rlbuor1.SelectedValue));
            lblmp2.Text = "Editar Orgánica 1";
            txtnombre2.Text = rlbuor1.SelectedItem.Text;
            txtCodigo.Text = zet.UOR_CODIGO;
            upnuevo2.Update();
            mp2.Show();
        }
    }
    protected void ibgr14_Click(object sender, ImageClickEventArgs e)
    {
        if (rlbuor2.SelectedItem != null)
        {
            Logica.UORGANICA zet = new Logica.UORGANICA(int.Parse(rlbuor1.SelectedValue));
            lblmp2.Text = "Editar Orgánica 2";
            txtCodigo.Text = zet.UOR_CODIGO;
            txtnombre2.Text = rlbuor2.SelectedItem.Text;
            upnuevo2.Update();
            mp2.Show();
        }
    }
    protected void ibgr9_Click(object sender, ImageClickEventArgs e)
    {
        if (rlbccosto.SelectedItem != null)
        {
            if (!Logica.UORGANICA.valRelActivo(rlbccosto.SelectedValue) && !Logica.UORGANICA.valRelActivoH(rlbccosto.SelectedValue))
            {
                Logica.UORGANICA.fDelUor2(int.Parse(rlbccosto.SelectedValue));
                cargarCcosto();
                rlbuor1.Items.Clear();
                rlbuor2.Items.Clear();
                upgeo.Update();
            }
            else
            {
                messbox1.Mensaje = "No pudo ser eliminado ya que actualmente se relaciona con activos";
                messbox1.Tipo = "E";
                messbox1.showMess();
            }
        }
    }
    protected void ibgr12_Click(object sender, ImageClickEventArgs e)
    {
        if (rlbuor1.SelectedItem != null)
        {
            if (!Logica.UORGANICA.valRelActivo(rlbuor1.SelectedValue) && !Logica.UORGANICA.valRelActivoH(rlbuor1.SelectedValue))
            {
                Logica.UORGANICA.fDelUor3(int.Parse(rlbuor1.SelectedValue));

                if (rlbccosto.SelectedItem != null)
                    cargarUor1();
                else
                    rlbuor1.Items.Clear();
                rlbuor2.Items.Clear();
                upgeo.Update();
            }
            else
            {
                messbox1.Mensaje = "No pudo ser eliminado ya que actualmente se relaciona con activos";
                messbox1.Tipo = "E";
                messbox1.showMess();
            }
        }
    }
    protected void ibgr15_Click(object sender, ImageClickEventArgs e)
    {
        if (rlbuor2.SelectedItem != null)
        {
            if (!Logica.UORGANICA.valRelActivo(rlbuor2.SelectedValue) && !Logica.UORGANICA.valRelActivoH(rlbuor2.SelectedValue))
            {
                Logica.UORGANICA.fDelUor4(int.Parse(rlbuor2.SelectedValue));

                if (rlbuor1.SelectedItem != null)
                    cargarUor2();
                else
                    rlbuor2.Items.Clear();
            }
            else
            {
                messbox1.Mensaje = "No pudo ser eliminado ya que actualmente se relaciona con activos";
                messbox1.Tipo = "E";
                messbox1.showMess();
            }
        }
    }
}
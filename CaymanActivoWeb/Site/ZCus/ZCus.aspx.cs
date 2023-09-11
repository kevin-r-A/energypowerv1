using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Web.Security;

public partial class ZCus : System.Web.UI.Page
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
                rlbcustodio.CheckBoxes = false;
                rlbuor1.Items.Clear();
                upgeo.Update();
                cargarCcosto();
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

            if (ConfigurationManager.AppSettings["UORCCO"] == "0")
            {
                rlbcustodio.CheckBoxes = false;
                cargarUor1();
            }

            cargarCustodios();
            this.Title = ConfigurationManager.AppSettings["Titulo"] + " Catálogos - Custodios";
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
            rlbccosto.DataSource = zet.getUorAll(1);
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

    private void cargarCustodios()
    {
        Logica.CUSTODIO zet = new Logica.CUSTODIO();
        rlbcustodio.DataSource = zet.getCustodiosAll();
        rlbcustodio.DataTextField = "nom";
        rlbcustodio.DataValueField = "id";
        rlbcustodio.DataBind();
        upgeo.Update();
    }

    protected void rlbgeo1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ConfigurationManager.AppSettings["CCOUGE"] != "0")
        {
            rlbcustodio.CheckBoxes = false;
            rlbuor1.Items.Clear();
            upgeo.Update();
            cargarCcosto();
        }
    }

    protected void rlbgeo2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ConfigurationManager.AppSettings["UORCCO"] == "1")
        {
            rlbcustodio.CheckBoxes = false;
            cargarUor1();
        }
    }

    protected void rlbgeo3_SelectedIndexChanged(object sender, EventArgs e)
    {
        cargarCustodioCheck();
    }

    private void cargarCustodioCheck()
    {
        rlbcustodio.CheckBoxes = true;

        Logica.CUSTODIO zet = new Logica.CUSTODIO();
        DataTable dt = zet.getCustodiosRel(int.Parse(rlbuor1.SelectedValue));

        if (dt.Rows.Count == 0)
        {
            for (int i = 0; i < rlbcustodio.Items.Count; i++)
            {
                rlbcustodio.Items[i].Checked = false;
            }
        }
        else
        {

            for (int i = 0; i < rlbcustodio.Items.Count; i++)
            {
                foreach (DataRow row in dt.Rows)
                {

                    if (row["id"].ToString() == rlbcustodio.Items[i].Value)
                    {
                        rlbcustodio.Items[i].Checked = true;
                        break;
                    }
                    else
                        rlbcustodio.Items[i].Checked = false;
                }
            }
        }
        upgeo.Update();
    }

    protected void btncerrar2_Click(object sender, EventArgs e)
    {
        txtcodigo.Text = "";
        txtapellidos.Text = "";
        txtnombres.Text = "";
        txtcedula.Text = "";
        txttelefono.Text = "";
        txtext.Text = "";
        txtcelular.Text = "";
        txtemail.Text = "";
        cddcargo.SelectedValue = "";
        ddestado.SelectedItem.Text = "Activo";
        upnuevo2.Update();
        upnuevo2.Update();
        mp2.Hide();
    }

    protected void btnsave2_Click(object sender, EventArgs e)
    {
        if (lblmp2.Text == "Editar Custodio")
        {
            Logica.CUSTODIO zet = new Logica.CUSTODIO(int.Parse(rlbcustodio.SelectedValue));
            zet.CUS_CODIGO = txtcodigo.Text.ToUpper();
            zet.CUS_APELLIDOS = Logica.HELPER.capitalize(txtapellidos.Text);
            zet.CUS_NOMBRES = Logica.HELPER.capitalize(txtnombres.Text);
            zet.CUS_CEDULA = txtcedula.Text;
            zet.CUS_TELEFONOFIJO = txttelefono.Text;
            zet.CUS_EXT = txtext.Text;
            zet.CUS_CELULAR = txtcelular.Text;
            zet.CUS_EMAIL = txtemail.Text.ToLower();
            zet.CGO_ID = int.Parse(ddcargo.SelectedValue);
            zet.CUS_ESTADO = ddestado.SelectedItem.Text;
            zet.Id = int.Parse(rlbcustodio.SelectedValue);
            zet.Update();

            if (rlbuor1.SelectedItem != null)
            {
                cargarCustodios();
                cargarCustodioCheck();
            }
            else
            {
                cargarCustodios();
            }
        }
        else if (lblmp2.Text == "Nuevo Custodio")
        {
            if (!Logica.HELPER.existeCustodioIng(txtnombres.Text.Trim().ToUpper(), txtapellidos.Text.Trim().ToUpper()))
            {
                Logica.CUSTODIO zet = new Logica.CUSTODIO();
                zet.CUS_CODIGO = txtcodigo.Text;
                zet.CUS_APELLIDOS = Logica.HELPER.capitalize(txtapellidos.Text);
                zet.CUS_NOMBRES = Logica.HELPER.capitalize(txtnombres.Text);
                zet.CUS_CEDULA = txtcedula.Text;
                zet.CUS_TELEFONOFIJO = txttelefono.Text;
                zet.CUS_EXT = txtext.Text;
                zet.CUS_CELULAR = txtcelular.Text;
                zet.CUS_EMAIL = txtemail.Text.ToLower();
                zet.CGO_ID = int.Parse(ddcargo.SelectedValue);
                zet.CUS_ESTADO = ddestado.SelectedItem.Text;
                zet.Create();

                if (rlbuor1.SelectedItem != null)
                {
                    cargarCustodios();
                    cargarCustodioCheck();
                }
                else
                {
                    cargarCustodios();
                }
            }
        }

        txtcodigo.Text = "";
        txtapellidos.Text = "";
        txtnombres.Text = "";
        txtcedula.Text = "";
        txttelefono.Text = "";
        txtext.Text = "";
        txtcelular.Text = "";
        txtemail.Text = "";
        cddcargo.SelectedValue = "";
        ddestado.SelectedItem.Text = "Activo";
        upnuevo2.Update();
        mp2.Hide();
    }

    protected void ibgr13_Click(object sender, ImageClickEventArgs e)
    {
        lblmp2.Text = "Nuevo Custodio";
        txtcodigo.Text = "";
        txtapellidos.Text = "";
        txtnombres.Text = "";
        txtcedula.Text = "";
        txttelefono.Text = "";
        txtext.Text = "";
        txtcelular.Text = "";
        txtemail.Text = "";
        cddcargo.SelectedValue = "";
        ddestado.SelectedItem.Text = "Activo";
        upnuevo2.Update();
        mp2.Show();
    }

    protected void ibgr14_Click(object sender, ImageClickEventArgs e)
    {
        if (rlbcustodio.SelectedItem != null)
        {
            lblmp2.Text = "Editar Custodio";
            Logica.CUSTODIO zet = new Logica.CUSTODIO(int.Parse(rlbcustodio.SelectedValue));
            txtcodigo.Text = zet.CUS_CODIGO;
            txtapellidos.Text = zet.CUS_APELLIDOS;
            txtnombres.Text = zet.CUS_NOMBRES;
            txtcedula.Text = zet.CUS_CEDULA;
            txttelefono.Text = zet.CUS_TELEFONOFIJO;
            txtext.Text = zet.CUS_EXT;
            txtcelular.Text = zet.CUS_CELULAR;
            txtemail.Text = zet.CUS_EMAIL;
            cddcargo.SelectedValue = zet.CGO_ID.ToString();
            ddestado.SelectedItem.Text = zet.CUS_ESTADO;
            upnuevo2.Update();
            mp2.Show();
        }
    }
    protected void ibgr15_Click(object sender, ImageClickEventArgs e)
    {
        if (rlbcustodio.SelectedItem != null)
        {
            if (!Logica.HELPER.valRelCustodio(int.Parse(rlbcustodio.SelectedValue)) && !Logica.HELPER.valRelCustodioH(int.Parse(rlbcustodio.SelectedValue)))
            {
                Logica.CUSTODIO.Delete2(int.Parse(rlbcustodio.SelectedValue));

                if (rlbuor1.SelectedItem != null)
                {
                    cargarCustodios();
                    cargarCustodioCheck();
                }
                else
                {
                    cargarCustodios();
                }
            }
            else
            {
                messbox1.Mensaje = "No pudo ser eliminado ya que actualmente se relaciona con activos";
                messbox1.Tipo = "E";
                messbox1.showMess();
            }
        }
    }
    protected void rlbcustodio_ItemCheck(object sender, Telerik.Web.UI.RadListBoxItemEventArgs e)
    {
        if (e.Item.Checked)
        {
            Logica.HELPER.checkCustodios(int.Parse(e.Item.Value), int.Parse(rlbuor1.SelectedValue), 1);
        }
        else
        {
            if (!Logica.HELPER.valRelCustodio(int.Parse(e.Item.Value), int.Parse(rlbuor1.SelectedValue)) && !Logica.HELPER.valRelCustodioH(int.Parse(e.Item.Value), int.Parse(rlbuor1.SelectedValue)))
            {
                Logica.HELPER.checkCustodios(int.Parse(e.Item.Value), int.Parse(rlbuor1.SelectedValue), 0);
            }
            else
            {
                messbox1.Mensaje = "No pudo ser desvinculado ya que actualmente se relaciona con activos";
                messbox1.Tipo = "E";
                messbox1.showMess();
                e.Item.Checked = true;
            }
        }
    }
}
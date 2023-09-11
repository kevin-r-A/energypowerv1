using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Web.Security;

public partial class ZProveedor : System.Web.UI.Page
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
            this.Title = ConfigurationManager.AppSettings["Titulo"].ToString() + " - PROVEEDORES";
        }
    }

    protected void ibgr8_Click(object sender, ImageClickEventArgs e)
    {
        if (rgproveedor.SelectedValue!=null)
        {
            lblmp2.Text = "Editar Proveedor";
            Logica.PROVEEDOR zet = new Logica.PROVEEDOR(int.Parse(rgproveedor.SelectedValue.ToString()));
            txtrazon.Text=zet.PRO_RAZON;
            txtnombre.Text=zet.PRO_NOMBRE;
            txtruc.Text=zet.PRO_RUC;
            txtcontacto.Text=zet.PRO_CONTACTO;
            txtdireccion.Text=zet.PRO_DIRECCION;
            txttelefono.Text=zet.PRO_TELEFONOF;
            txtcelular.Text=zet.PRO_CELULAR;
            txtfax.Text=zet.PRO_FAX;
            txtemail.Text=zet.PRO_EMAIL;
            txtcredito.Text=zet.PRO_CREDITO.ToString();
            txtobs.Text=zet.PRO_OBSERVACIONES;
            cddgru1.SelectedValue=zet.GRU_ID.ToString();
            cddgeo1.SelectedValue = zet.PAI_ID1.ToString();
            cddgeo2.SelectedValue = zet.PAI_ID2.ToString();
            cddgeo3.SelectedValue = zet.PAI_ID3.ToString();
            upnuevo2.Update();
            mp2.Show();
        }
    }
    protected void ibgr7_Click(object sender, ImageClickEventArgs e)
    {
        lblmp2.Text = "Nuevo Proveedor";
        upnuevo2.Update();
        mp2.Show();
    }
    protected void ibgr9_Click(object sender, ImageClickEventArgs e)
    {
        if (rgproveedor.SelectedValue != null)
        {
            if (!Logica.PROVEEDOR.valRelActivo(int.Parse(rgproveedor.SelectedValue.ToString())))
            {
                Logica.PROVEEDOR.Delete(int.Parse(rgproveedor.SelectedValue.ToString()));
                SqlDataSource1.DataBind();
                rgproveedor.DataBind();
                upgrid.Update();
            }
            else
            {
                messbox1.Mensaje = "No pudo ser eliminado ya que activamente se relaciona con activos";
                messbox1.Tipo = "E";
                messbox1.showMess();
            }           
        }
    }
    protected void btncerrar2_Click(object sender, EventArgs e)
    {
        txtrazon.Text = "";
        txtnombre.Text = "";
        txtruc.Text = "";
        txtcontacto.Text = "";
        txtdireccion.Text = "";
        txttelefono.Text = "";
        txtcelular.Text = "";
        txtfax.Text = "";
        txtemail.Text = "";
        txtcredito.Text = "";
        txtobs.Text = "";
        cddgru1.SelectedValue = "";
        cddgeo1.SelectedValue = "";
        cddgeo2.SelectedValue = "";
        cddgeo3.SelectedValue = "";

        upnuevo2.Update();
        mp2.Hide();
    }
    protected void btnsave2_Click(object sender, EventArgs e)
    {
        if (lblmp2.Text == "Editar Proveedor")
        {
            Logica.PROVEEDOR zet = new Logica.PROVEEDOR();
            zet.PRO_RAZON=txtrazon.Text;
            zet.PRO_NOMBRE=txtnombre.Text;
            zet.PRO_RUC=txtruc.Text;
            zet.PRO_CONTACTO=txtcontacto.Text;
            zet.PRO_DIRECCION=txtdireccion.Text;
            zet.PRO_TELEFONOF=txttelefono.Text;
            zet.PRO_CELULAR=txtcelular.Text ;
            zet.PRO_FAX=txtfax.Text;
            zet.PRO_EMAIL=txtemail.Text ;
            zet.PRO_CREDITO=int.Parse(txtcredito.Text);
            zet.PRO_OBSERVACIONES=txtobs.Text;
            zet.GRU_ID = int.Parse(ddGrupo.SelectedValue);
            zet.PAI_ID1 = int.Parse(ddUge1.SelectedValue);
            zet.PAI_ID2 = int.Parse(ddUge2.SelectedValue);
            zet.PAI_ID3 = int.Parse(ddUge3.SelectedValue);
            zet.Id=int.Parse(rgproveedor.SelectedValue.ToString());
            zet.Update();

            mp2.Hide();

            SqlDataSource1.DataBind();
            rgproveedor.DataBind();            

            txtrazon.Text="";
            txtnombre.Text="";
            txtruc.Text="";
            txtcontacto.Text="";
            txtdireccion.Text="";
            txttelefono.Text="";
            txtcelular.Text="";
            txtfax.Text="";
            txtemail.Text="";
            txtcredito.Text="";
            txtobs.Text="";
            cddgru1.SelectedValue="";
            cddgeo1.SelectedValue="";
            cddgeo2.SelectedValue="";
            cddgeo3.SelectedValue="";
            upgrid.Update();
            upnuevo2.Update();
        }
        else if (lblmp2.Text == "Nuevo Proveedor")
        {
            if (!Logica.HELPER.existeProveedorIng(Logica.HELPER.capitalize(txtnombre.Text)))
            {
                Logica.PROVEEDOR zet = new Logica.PROVEEDOR();
                zet.PRO_RAZON = txtrazon.Text;
                zet.PRO_NOMBRE = txtnombre.Text;
                zet.PRO_RUC = txtruc.Text;
                zet.PRO_CONTACTO = txtcontacto.Text;
                zet.PRO_DIRECCION = txtdireccion.Text;
                zet.PRO_TELEFONOF = txttelefono.Text;
                zet.PRO_CELULAR = txtcelular.Text;
                zet.PRO_FAX = txtfax.Text;
                zet.PRO_EMAIL = txtemail.Text;
                zet.PRO_CREDITO = int.Parse(txtcredito.Text);
                zet.PRO_OBSERVACIONES = txtobs.Text;
                zet.GRU_ID = int.Parse(ddGrupo.SelectedValue);
                zet.PAI_ID1 = int.Parse(ddUge1.SelectedValue);
                zet.PAI_ID2 = int.Parse(ddUge2.SelectedValue);
                zet.PAI_ID3 = int.Parse(ddUge3.SelectedValue);
                zet.Create();

                SqlDataSource1.DataBind();
                rgproveedor.DataBind();

                txtrazon.Text = "";
                txtnombre.Text = "";
                txtruc.Text = "";
                txtcontacto.Text = "";
                txtdireccion.Text = "";
                txttelefono.Text = "";
                txtcelular.Text = "";
                txtfax.Text = "";
                txtemail.Text = "";
                txtcredito.Text = "";
                txtobs.Text = "";
                cddgru1.SelectedValue = "";
                cddgeo1.SelectedValue = "";
                cddgeo2.SelectedValue = "";
                cddgeo3.SelectedValue = "";
                upnuevo2.Update();
                upgrid.Update();
                mp2.Hide();
            }
            else
            {
                txtrazon.Text = "";
                txtnombre.Text = "";
                txtruc.Text = "";
                txtcontacto.Text = "";
                txtdireccion.Text = "";
                txttelefono.Text = "";
                txtcelular.Text = "";
                txtfax.Text = "";
                txtemail.Text = "";
                txtcredito.Text = "";
                txtobs.Text = "";
                cddgru1.SelectedValue = "";
                cddgeo1.SelectedValue = "";
                cddgeo2.SelectedValue = "";
                cddgeo3.SelectedValue = "";
                upnuevo2.Update();
                upgrid.Update();
                mp2.Hide();
            }
        }
        //upgrid.Update();
    }
}
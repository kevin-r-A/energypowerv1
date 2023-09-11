using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Configuration;

public partial class ZPpc : System.Web.UI.Page
{
    ErrorTrapper errtrap;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = ConfigurationManager.AppSettings["Titulo"] + " Gestionar PocketPc's";

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
            ibsave.Attributes.Add("onmouseout", "this.src='../../Img/s1.png'");
            ibsave.Attributes.Add("onmouseover", "this.src='../../Img/s2.png'");
            ibcancel.Attributes.Add("onmouseout", "this.src='../../Img/c1.png'");
            ibcancel.Attributes.Add("onmouseover", "this.src='../../Img/c2.png'");
            cargarPocket();
        }
    }

    private void cargarPocket()
    {
        try
        {
            Logica.PPC zet = new Logica.PPC();
            rgppc.DataSource = zet.fGetPpc();
            rgppc.DataBind();
            upgru.Update();
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

    protected void ibgr1_Click(object sender, ImageClickEventArgs e)
    {
        lblmp.Text = "Nueva PPC";
        upnuevo.Update();
        mpnuevo.Show();
    }

    protected void ibgr2_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (rgppc.SelectedValue != null)
            {
                lblmp.Text = "Editar PPC";

                if (rgppc.SelectedItems[0].Cells[3].Text != "&nbsp;")
                    txtserie.Text = rgppc.SelectedItems[0].Cells[3].Text;
                else
                    txtserie.Text = "";

                txtppcnumero.Text = rgppc.SelectedValue.ToString();
                txtppcnumero.Enabled = false;
                upnuevo.Update();
                mpnuevo.Show();
            }
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

    protected void ibgr3_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (rgppc.SelectedValue != null)
            {
                Logica.PPC zet = new Logica.PPC();
                if (!Logica.PPC.valRelActivo(rgppc.SelectedValue.ToString()))
                {
                    zet.Id = int.Parse(rgppc.SelectedValue.ToString());
                    zet.Delete();
                    cargarPocket();
                }
                else
                {
                    messbox1.Mensaje = "No se pudo eliminar el item ya que tiene Activos vinculados";
                    messbox1.Tipo = "E";
                    messbox1.showMess();
                }
            }
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
    protected void ibcancel_Click(object sender, ImageClickEventArgs e)
    {
        txtserie.Text = "";
        txtppcnumero.Text = "";
        txtppcnumero.Enabled = true;
        upnuevo.Update();
        mpnuevo.Hide();
    }
    protected void ibsave_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (lblmp.Text == "Editar PPC")
            {
                Logica.PPC zet = new Logica.PPC();
                zet.PPC_SERIAL = txtserie.Text.Trim().ToUpper();
                zet.Id = int.Parse(rgppc.SelectedValue.ToString());
                zet.Update();
            }
            else if (lblmp.Text == "Nueva PPC")
            {
                if (!Logica.HELPER.existePpcIng(txtppcnumero.Text.Trim()))
                {
                    Logica.PPC zet = new Logica.PPC();
                    zet.PPC_SERIAL = txtserie.Text.Trim().ToUpper();
                    zet.Id = int.Parse(txtppcnumero.Text.Trim());
                    zet.Create();
                }
            }

            cargarPocket();
            txtserie.Text = "";
            txtppcnumero.Text = "";
            txtppcnumero.Enabled = true;
            upnuevo.Update();
            mpnuevo.Hide();
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
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;
using System.Configuration;

public partial class ZUsu : System.Web.UI.Page
{
    ErrorTrapper errtrap;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = ConfigurationManager.AppSettings["Titulo"] + " Gestionar Usuarios PocketPc";

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

            cargarUsuarios();
            cargarRoles();
        }
    }

    private void cargarUsuarios()
    {
        try
        {
            rlbusu.DataSource = Logica.USUPPC.Cargar();
            rlbusu.DataTextField = "Clave";
            rlbusu.DataValueField = "Id";
            rlbusu.DataBind();
            upusu.Update();
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

    private void cargarRoles()
    {
        try
        {
            rlbroles.DataSource = Logica.HELPER.getRolesPpc();
            rlbroles.DataTextField = "rpp_nombre";
            rlbroles.DataValueField = "rpp_id";
            rlbroles.DataBind();
            uprol.Update();
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
        lblmp.Text = "Nuevo Usuario";
        upnuevo.Update();
        mpnuevo.Show();
    }

    protected void ibgr2_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (rlbusu.SelectedValue != null)
            {
                lblmp.Text = "Editar Usuario";
                string[] usuario = rlbusu.SelectedItem.Text.Split('-');
                txtusuario.Text = usuario[0].ToString().Trim();
                txtclave.Text = usuario[1].ToString().Trim().Substring(2, usuario[1].ToString().Length - 5);
                txtusuario.Enabled = false;
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
            if (rlbusu.SelectedValue != null)
            {
                Logica.USUPPC zet = new Logica.USUPPC();
                zet.Id = rlbusu.SelectedValue;
                zet.Delete();
                cargarUsuarios();
                rlbroles.CheckBoxes = false;
                uprol.Update();
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

    protected void rlbusu_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            rlbroles.CheckBoxes = true;
            DataTable dt = Logica.HELPER.getUsuRolPPc(rlbusu.SelectedValue);

            if (dt.Rows.Count == 0)
            {
                for (int i = 0; i < rlbroles.Items.Count; i++)
                {
                    rlbroles.Items[i].Checked = false;
                }
            }
            else
            {
                for (int i = 0; i < rlbroles.Items.Count; i++)
                {
                    foreach (DataRow row in dt.Rows)
                    {

                        if (row["rpp_id"].ToString() == rlbroles.Items[i].Value)
                        {
                            rlbroles.Items[i].Checked = true;
                            break;
                        }
                        else
                            rlbroles.Items[i].Checked = false;
                    }
                }
            }
            uprol.Update();
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
    protected void rlbroles_ItemCheck(object sender, Telerik.Web.UI.RadListBoxItemEventArgs e)
    {
        try
        {
            if (e.Item.Checked)
            {
                Logica.HELPER.insRolesPpc(rlbusu.SelectedValue, e.Item.Value);
            }
            else
            {
                Logica.HELPER.delRolesPpc(rlbusu.SelectedValue, e.Item.Value);
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
    protected void ibsave_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (lblmp.Text == "Editar Usuario")
            {
                Logica.USUPPC zet = new Logica.USUPPC();
                zet.UPP_CLAVE = txtclave.Text.Trim().ToLower();
                zet.Id = rlbusu.SelectedValue;
                zet.Update();
            }
            else if (lblmp.Text == "Nuevo Usuario")
            {
                if (!Logica.HELPER.existeUsuPpcIng(txtusuario.Text.Trim()))
                {
                    Logica.USUPPC zet = new Logica.USUPPC();
                    zet.UPP_CLAVE = txtclave.Text.Trim().ToLower();
                    zet.Id = txtusuario.Text.Trim().ToLower();
                    zet.Create();
                }
            }
            cargarUsuarios();
            txtclave.Text = "";
            txtusuario.Text = "";
            txtusuario.Enabled = true;
            upnuevo.Update();
            mpnuevo.Hide();
            rlbroles.CheckBoxes = false;
            uprol.Update();
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
        txtclave.Text = "";
        txtusuario.Text = "";
        txtusuario.Enabled = true;
        upnuevo.Update();
        mpnuevo.Hide();
    }
}
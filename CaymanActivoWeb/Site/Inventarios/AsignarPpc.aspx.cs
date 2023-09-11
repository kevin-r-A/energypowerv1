using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using System.ComponentModel;
using System.IO;
using System.Web.Security;
using System.Data;
using System.Configuration;


public partial class AsignarPpc : System.Web.UI.Page
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
            this.Title = ConfigurationManager.AppSettings["Titulo"] + " Filtrar y Asignar Activos";
            //ibtnBackup.Attributes.Add("onmouseout", "this.src='../../Img/bdd1.png'");
            //ibtnBackup.Attributes.Add("onmouseover", "this.src='../../Img/bdd2.png'");
            cargarPpc();
            Inventario();
        }        

       
    }

    private void cargarPpc()
    {
        ddPpc.DataSource= Logica.HELPER.getPpc();
        ddPpc.DataTextField = "ppc_numero";
        ddPpc.DataValueField = "ppc_numero";
        ddPpc.DataBind();
    }

    public void Inventario()
    {
        using (C5ALIANZAVALLE23102015Entities ent = new C5ALIANZAVALLE23102015Entities())
        {

            int inv = ent.ACTIVO.Where(x => x.ACT_PPC != null).ToList().Count;

            if (inv > 0)
            {
                lblInventario.Text = ", El Sistema ya tiene Asignado(s) " + inv.ToString() + " items para realizar el Inventario, haga clic en el boton INICIAR INVENTARIO para iniciar un nuevo Inventario, esta acción BORRARA todos los items anteriormente filtrados y sincronizados con el Dispositivo Movil";
                div1.Visible = true;
            }
            else
            {
                div1.Visible = false;
                div2.Visible = true;
                lblmsg2.Text = ", El Sistema est listo para Iniciar Inventarios, por favor aplique un filtro(s), para continuar y sincronizar con el Dispositivo Movil";
            }


        }
    }

    private void cargarActivosFiltro()
    {
        string query = "";

        if (ddUge1.SelectedValue != "")
        {
            query = query + " and UG1.UGE_NOMBRE='" + ddUge1.SelectedItem.Text + "'";
        }
        if (ddUge2.SelectedValue != "")
        {
            query = query + " and UG2.UGE_NOMBRE='" + ddUge2.SelectedItem.Text + "'";
        }
        if (ddUge3.SelectedValue != "")
        {
            query = query + " and UG3.UGE_NOMBRE='" + ddUge3.SelectedItem.Text + "'";
        }
        if (ddPiso.SelectedValue != "")
        {
            query = query + " and UG4.UGE_NOMBRE='" + ddPiso.SelectedItem.Text + "'";
        }
        if (ddCcosto.SelectedValue != "")
        {
            query = query + " and UO1.UOR_NOMBRE='" + ddCcosto.SelectedItem.Text + "'";
        }
        if (ddUor1.SelectedValue != "")
        {
            query = query + " and UO2.UOR_NOMBRE='" + ddUor1.SelectedItem.Text + "'";
        }
        if (ddUor2.SelectedValue != "")
        {
            query = query + " and UO3.UOR_NOMBRE='" + ddUor2.SelectedItem.Text + "'";
        }
        if (ddCustodio.SelectedValue != "")
        {
            query = query + " and ACTIVO.CUS_ID1=" + ddCustodio.SelectedValue + "";
        }

        DataTable dt = Logica.HELPER.getAsignadosPpc(query, "0");
        rgactivos1.DataSource = dt;
        rgactivos1.DataBind();

        if (dt.Rows.Count > 0)
        {
            div1.Visible = false;
            div2.Visible = true;

            lblmsg2.Text = ", por favor Asigne los items al Dispositivo Movil";
        }
        else
        {
            div1.Visible = false;
            div2.Visible = true;

            lblmsg2.Text = ", NO EXISTE ITEM(S) CON EL FILTRO APLICADO";
        }

        DataTable dt2 = Logica.HELPER.getAsignadosPpc(query, "1");
        rgactivos2.DataSource = dt2;
        rgactivos2.DataBind();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        cargarActivosFiltro();
    }


    protected void btnborrarasig_Click(object sender, EventArgs e)
    {
        foreach (Telerik.Web.UI.GridDataItem item in rgactivos2.SelectedItems)
        {
            Logica.HELPER.borrarAsignacionPpc(item.Cells[5].Text);
        }
        cargarActivosFiltro();
        div1.Visible = false;
        div2.Visible = false;
    }

    protected void btnasignar_Click(object sender, EventArgs e)
    {
        foreach (Telerik.Web.UI.GridDataItem item in rgactivos1.SelectedItems)
        {
            Logica.HELPER.asignarPpc(item.Cells[5].Text, ddPpc.SelectedValue);
        }
        cargarActivosFiltro();

        lblmsg2.Text = " Sistema listo, items Asignados " + rgactivos2.Items.Count.ToString() + ", por favor Sincronice con el Dispositvo Movil";
        div1.Visible = false;
        div2.Visible = true;
    }

    protected void btnIniInventario_Click(object sender, EventArgs e)
    {
        try
        {
            using (C5ALIANZAVALLE23102015Entities ent = new C5ALIANZAVALLE23102015Entities())
            {
                List<ACTIVO> aCTIVOs = new List<ACTIVO>();
                aCTIVOs = ent.ACTIVO.Where(x => x.ACT_PPC != null).ToList();

                if (aCTIVOs.Count > 0)
                {
                    aCTIVOs.ForEach(y => y.ACT_PPC = null);

                    int x = ent.SaveChanges();

                    if (x > 0)
                    {
                        div1.Visible = false;
                        div2.Visible = true;
                        lblmsg2.Text = ", El Sistema está listo, por favor aplique un filtro(s), y luego sincronice con el Dispositivo Movil";
                    }
                }
                else
                {
                    div1.Visible = false;
                    div2.Visible = true;

                    lblmsg2.Text = ", El Sistema está listo, por favor aplique un filtro(s), y luego sincronice con el Dispositivo Movil";
                }

            }

        }
        catch (Exception ex)
        {

            lblmsg2.Text = "ERROR: ==> " + ex.Message;
        }
    }
}
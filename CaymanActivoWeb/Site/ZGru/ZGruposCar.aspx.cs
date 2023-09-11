using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

public partial class ZGruposCar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cargarGrupos();
            cargarCaracteristicas();
            this.Title = ConfigurationManager.AppSettings["Titulo"] + " Catálogos - Características por Grupo";
        }
    }

    private void cargarGrupos()
    { 
        Logica.GRUPO gr= new Logica.GRUPO();
        rlbgrupos.DataSource = gr.fGetGrupos2();
        rlbgrupos.DataTextField = "nombre";
        rlbgrupos.DataValueField = "id";
        rlbgrupos.DataBind();
        upgru.Update();
    }

    private void cargarCaracteristicas()
    {
        rlbcaract.DataSource = Logica.HELPER.getCaractereisticas();
        rlbcaract.DataTextField = "cca_nombre";
        rlbcaract.DataValueField = "cca_id";
        rlbcaract.DataBind();
        upcar.Update();
    }

    protected void rlbgrupos_SelectedIndexChanged(object sender, EventArgs e)
    {
        cargarCarAso();
    }

    private void cargarCarAso()
    {
        rlbcaractna.DataSource = Logica.HELPER.getCaracteristicasNa(int.Parse(rlbgrupos.SelectedValue));
        rlbcaractna.DataTextField = "cca_nombre";
        rlbcaractna.DataValueField = "cca_id";
        rlbcaractna.DataBind();
        upcarna.Update();

        DataTable dt = Logica.HELPER.getCaracteristicasA(int.Parse(rlbgrupos.SelectedValue));

        rlbcaracta.DataSource = dt;
        rlbcaracta.DataTextField = "cfa_nombre";
        rlbcaracta.DataValueField = "cfa_id";
        rlbcaracta.DataBind();
        
        int i=0;
        foreach (DataRow row in dt.Rows)
        {
            if (row["cfa_unidades"].ToString() == "True")
            {
                rlbcaracta.Items[i].Checked = true;
            }
            else
            {
                rlbcaracta.Items[i].Checked = false;
            }
            i++;
        }        

        upcara.Update();
    }
 
    protected void btncerrar2_Click(object sender, EventArgs e)
    {
        txtnombre2.Text = "";
        upnuevo2.Update();
        mp2.Hide();  
    }
    protected void ibgr4_Click(object sender, ImageClickEventArgs e)
    {
        lblmp2.Text = "Nueva Característica";
        upnuevo2.Update();
        mp2.Show();
    }
    protected void ibgr5_Click(object sender, ImageClickEventArgs e)
    {
        if (rlbcaract.SelectedItem != null)
        {
            lblmp2.Text = "Editar Característica";
            txtnombre2.Text = rlbcaract.SelectedItem.Text;
            upnuevo2.Update();
            mp2.Show();
        }
    }
    protected void ibgr6_Click(object sender, ImageClickEventArgs e)
    {
        if (rlbcaract.SelectedItem != null)
        {
            Logica.GRUPO gr = new Logica.GRUPO();
            int activos = gr.fcheckActivo(rlbcaract.SelectedValue);
            if (!Logica.HELPER.comprobarCarCfamilia(rlbcaract.SelectedItem.Text))
            {
                Logica.HELPER.delCar(int.Parse(rlbcaract.SelectedValue));
                cargarCaracteristicas();
            }
            else
            {
                messbox1.Mensaje = "No se pudo eliminar la Característica ya que esta referenciada";
                messbox1.Tipo = "E";
                messbox1.showMess();
            }
        }
    }
    protected void btnsave2_Click(object sender, EventArgs e)
    {
        if (lblmp2.Text == "Editar Característica")
            {
                Logica.HELPER.updCar(Logica.HELPER.capitalize(txtnombre2.Text), int.Parse(rlbcaract.SelectedValue),rlbcaract.SelectedItem.Text);
            
                mp2.Hide();
                txtnombre2.Text = "";
                upnuevo2.Update();
                cargarCaracteristicas();
                if (rlbgrupos.SelectedItem != null)
                    cargarCarAso();

            }
            else if (lblmp2.Text == "Nueva Característica")
            {
                if (!Logica.HELPER.comprobarCarIng(Logica.HELPER.capitalize(txtnombre2.Text)))
                {
                    Logica.HELPER.insCaracteristicas(Logica.HELPER.capitalize(txtnombre2.Text));
                    txtnombre2.Text = "";
                    upnuevo2.Update();
                    mp2.Hide();
                    cargarCaracteristicas();
                    if (rlbgrupos.SelectedItem != null)
                        cargarCarAso();
                }
                else
                {
                    txtnombre2.Text = "";
                    upnuevo2.Update();
                    mp2.Hide();                 
                }
            }                 
    }
    protected void ibgr7_Click(object sender, ImageClickEventArgs e)
    {
        if (rlbcaractna.SelectedItem != null)
        {
            if (rlbcaracta.Items.Count < 16)
            {
                Logica.HELPER.insCaracteristicasCfa(rlbcaractna.SelectedItem.Text, int.Parse(rlbgrupos.SelectedValue));
                cargarCarAso();
            }
            else
            {
                messbox1.Mensaje = "Únicamente puede asociar hasta 16 características por Grupo";
                messbox1.Tipo = "W";
                messbox1.showMess();            
            }
        }
    }
    protected void ibgr8_Click(object sender, ImageClickEventArgs e)
    {
        
        if (rlbcaracta.SelectedItem != null)
        {
            if (!Logica.HELPER.comprobarCarCfa(int.Parse(rlbcaracta.SelectedValue),int.Parse(rlbgrupos.SelectedValue)))
            {
                Logica.HELPER.delCaracteristicasCfa(int.Parse(rlbcaracta.SelectedValue), int.Parse(rlbgrupos.SelectedValue));
                cargarCarAso();
            }
            else
            {
                messbox1.Mensaje = "No se pudo desasociar la Característica ya que esta referenciada en activos";
                messbox1.Tipo = "E";
                messbox1.showMess();
                upnuevo2.Update();
            }
        }
    }
    protected void rlbcaracta_ItemCheck(object sender, Telerik.Web.UI.RadListBoxItemEventArgs e)
    {

        //dice
        string nom = "";

        if (e.Item.Checked)
        {

            if (e.Item.Text.Contains('['))
            {

                string[] nombre1 = e.Item.Text.Split('[');

                nom = nombre1[0].Trim();
            }

            else
            {
                nom = e.Item.Text.Trim();
            }

            Logica.HELPER.checkUnidades(nom, int.Parse(rlbgrupos.SelectedValue), 1);
        }
        else
        {

            if (e.Item.Text.Contains('['))
            {

                string[] nombre1 = e.Item.Text.Split('[');

                nom = nombre1[0].Trim();
            }
            else
            {
                nom = e.Item.Text.Trim();
            }

            Logica.HELPER.checkUnidades(nom, int.Parse(rlbgrupos.SelectedValue), 0);
        }
        
        
        //if (e.Item.Checked)
        //{
        //    Logica.HELPER.checkUnidades(e.Item.Text, int.Parse(rlbgrupos.SelectedValue), 1);
        //}
        //else
        //{
        //    Logica.HELPER.checkUnidades(e.Item.Text, int.Parse(rlbgrupos.SelectedValue), 0);
        //}
    }
    protected void ibgr9_Click(object sender, ImageClickEventArgs e)
    {
        if (rlbcaracta.SelectedItem != null && rlbcaracta.SelectedIndex!=0)
        {
            int cfaidactual = int.Parse(rlbcaracta.SelectedValue);
            int ordenactual= Logica.HELPER.getOrden(cfaidactual);
            int cfaidcontiguo = int.Parse(rlbcaracta.Items[rlbcaracta.SelectedIndex - 1].Value);
            int ordennuevo = Logica.HELPER.getOrden(cfaidcontiguo);

            Logica.HELPER.updOrdenCar(cfaidactual, ordennuevo);
            Logica.HELPER.updOrdenCar(cfaidcontiguo, ordenactual);

            cargarCarAso();
        }
    }
    protected void ibgr10_Click(object sender, ImageClickEventArgs e)
    {
        if (rlbcaracta.SelectedItem != null && rlbcaracta.SelectedIndex != rlbcaracta.Items.Count-1)
        {
            int cfaidactual = int.Parse(rlbcaracta.SelectedValue);
            int ordenactual = Logica.HELPER.getOrden(cfaidactual);
            int cfaidcontiguo = int.Parse(rlbcaracta.Items[rlbcaracta.SelectedIndex + 1].Value);
            int ordennuevo = Logica.HELPER.getOrden(cfaidcontiguo);

            Logica.HELPER.updOrdenCar(cfaidactual, ordennuevo);
            Logica.HELPER.updOrdenCar(cfaidcontiguo, ordenactual);

            cargarCarAso();
        }
    }
    protected void rlbcaractna_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
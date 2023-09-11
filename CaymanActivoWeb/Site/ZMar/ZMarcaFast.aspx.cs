﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class ZMarcaFast : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //cargarMarcas();
            this.Title = ConfigurationManager.AppSettings["Titulo"] + " Catálogos - Marca/Modelo";
        }
    }

    //private void cargarMarcas()
    //{
    //    Logica.MARCA mar = new Logica.MARCA();
    //    rlbmarca.DataSource = mar.fGetMarcasAll();
    //    rlbmarca.DataTextField = "mar_nombre";
    //    rlbmarca.DataValueField = "mar_id";
    //    rlbmarca.DataBind();
    //    upmar.Update();
    //}
    
    //protected void rlbsubgrupo_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    cargarModelo();
    //}

    //private void cargarModelo()
    //{
    //    Logica.MODELO mod = new Logica.MODELO();
    //    rlbmodelo.DataSource = mod.fGetModeloMarid(int.Parse(rlbmarca.SelectedValue));
    //    rlbmodelo.DataTextField = "mod_nombre";
    //    rlbmodelo.DataValueField = "mod_id";
    //    rlbmodelo.DataBind();
    //    upmod.Update();
    //}

    protected void btncerrar2_Click(object sender, EventArgs e)
    {
        txtnombre2.Text = "";
        upnuevo2.Update();
        mp2.Hide();
    }

    protected void ibgr4_Click(object sender, ImageClickEventArgs e)
    {
            txtnombre2.Focus();
            lblmp2.Text = "Nueva Marca";
            upnuevo2.Update();
            mp2.Show();
    }

    protected void ibgr5_Click(object sender, ImageClickEventArgs e)
    {
        if (ddMarca.SelectedItem.Text != "")
        {
            txtnombre2.Focus();
            lblmp2.Text = "Editar Marca";
            txtnombre2.Text = ddMarca.SelectedItem.Text;
            upnuevo2.Update();
            mp2.Show();
        }
    }

    protected void ibgr6_Click(object sender, ImageClickEventArgs e)
    {
        if (ddMarca.SelectedItem.Text != "")
        {
            if (!Logica.MARCA.valRelActivo(ddMarca.SelectedValue))
            {
                Logica.MARCA.Delete(int.Parse(ddMarca.SelectedValue));
                upmar.Update();
                upmod.Update();
            }
            else
            {
                messbox1.Mensaje = "No pudo ser eliminada ya que actualmente se relaciona con activos";
                messbox1.Tipo = "E";
                messbox1.showMess();
            }
        }
    }
    protected void btnsave2_Click(object sender, EventArgs e)
    {        
            if (lblmp2.Text == "Editar Marca")
            {
                Logica.MARCA mar = new Logica.MARCA();
                mar.MAR_NOMBRE = Logica.HELPER.capitalize(txtnombre2.Text);
                mar.Id = int.Parse(ddMarca.SelectedValue);
                mar.Update();
                upmar.Update();             
            }
            else if (lblmp2.Text == "Nueva Marca")
            {
                if (!Logica.HELPER.existeMarcaIng(Logica.HELPER.capitalize(txtnombre2.Text)))
                {
                    Logica.MARCA mar = new Logica.MARCA();
                    int marid = mar.fAddMarca(Logica.HELPER.capitalize(txtnombre2.Text).ToUpper());

                    Logica.MODELO mod = new Logica.MODELO();
                    mod.MOD_NOMBRE = "(sin Modelo)";
                    mod.MAR_ID = marid;
                    mod.Create();
                    upmar.Update();
                    upmod.Update();
                }
            }
            else if (lblmp2.Text == "Editar Modelo")
            {
                Logica.MODELO mod = new Logica.MODELO();
                mod.MOD_NOMBRE = Logica.HELPER.capitalize(txtnombre2.Text);
                mod.Id = int.Parse(ddModelo.SelectedValue);
                mod.Update();
                upmod.Update();
            }

            else if (lblmp2.Text == "Nuevo Modelo")
            {
                if (!Logica.HELPER.existeModeloIng(Logica.HELPER.capitalize(txtnombre2.Text), int.Parse(ddMarca.SelectedValue)))
                {
                    Logica.MODELO mod = new Logica.MODELO();
                    mod.MOD_NOMBRE = Logica.HELPER.capitalize(txtnombre2.Text);
                    mod.MAR_ID = int.Parse(ddMarca.SelectedValue);
                    mod.Create();
                    upmod.Update();
                }
            }

            
            txtnombre2.Text = "";
            upnuevo2.Update();
            mp2.Hide();
    }

    protected void ibgr7_Click(object sender, ImageClickEventArgs e)
    {
        if (ddMarca.SelectedItem.Text != "")
        {
            txtnombre2.Focus();
            lblmp2.Text = "Nuevo Modelo";
            upnuevo2.Update();
            mp2.Show();
        }
    }
    protected void ibgr8_Click(object sender, ImageClickEventArgs e)
    {
        if (ddModelo.SelectedItem.Text != "")
        {
            txtnombre2.Focus();
            lblmp2.Text = "Editar Modelo";
            txtnombre2.Text = ddModelo.SelectedItem.Text;
            upnuevo2.Update();
            mp2.Show();
        }
    }
    protected void ibgr9_Click(object sender, ImageClickEventArgs e)
    {
        if (ddModelo.SelectedItem.Text != "")
        {
            if (!Logica.MODELO.valRelActivo(ddModelo.SelectedValue))
            {
                Logica.MODELO.Delete(int.Parse(ddModelo.SelectedValue));
                upmod.Update();
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
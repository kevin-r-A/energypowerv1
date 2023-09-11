using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Security;

public partial class Site_Principal : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = ConfigurationManager.AppSettings["Titulo"] + " Página Principal";

        ibtn1.Attributes.Add("onclick", "window.open('Manuales/Manual1.aspx','Manuales','width=815,height=615'); return false;");
        ibtn2.Attributes.Add("onclick", "window.open('Manuales/Manual2.aspx','Manuales','width=815,height=615'); return false;");
        ibtn3.Attributes.Add("onclick", "window.open('Manuales/Manual3.aspx','Manuales','width=815,height=615'); return false;");
        ibtn4.Attributes.Add("onclick", "window.open('Manuales/Manual4.aspx','Manuales','width=815,height=615'); return false;");
        ibtn5.Attributes.Add("onclick", "window.open('Manuales/Manual5.aspx','Manuales','width=815,height=615'); return false;");
        ibtn6.Attributes.Add("onclick", "window.open('Manuales/Manual6.aspx','Manuales','width=815,height=615'); return false;");
        
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

        this.Title = ConfigurationManager.AppSettings["Titulo"];

        //cambio de imagen cuando mouser over sobre menu central de imagenes
        ibtn1.Attributes.Add("onmouseover", "this.src='../Img/mnu11_1.png'");
        ibtn1.Attributes.Add("onmouseout", "this.src='../Img/mnu11.png'");

        ibtn2.Attributes.Add("onmouseover", "this.src='../Img/mnu12_1.png'");
        ibtn2.Attributes.Add("onmouseout", "this.src='../Img/mnu12.png'");

        ibtn3.Attributes.Add("onmouseover", "this.src='../Img/mnu13_1.png'");
        ibtn3.Attributes.Add("onmouseout", "this.src='../Img/mnu13.png'");

        ibtn4.Attributes.Add("onmouseover", "this.src='../Img/mnu14_1.png'");
        ibtn4.Attributes.Add("onmouseout", "this.src='../Img/mnu14.png'");

        ibtn5.Attributes.Add("onmouseover", "this.src='../Img/mnu15_1.png'");
        ibtn5.Attributes.Add("onmouseout", "this.src='../Img/mnu15.png'");

        ibtn6.Attributes.Add("onmouseover", "this.src='../Img/mnu16_1.png'");
        ibtn6.Attributes.Add("onmouseout", "this.src='../Img/mnu16.png'");
        
        P_MensajePagina();
    }

    public void P_MensajePagina()
    /*
     * AUTOR: DICE
     * FECHA: 2013/04/12
     * OBJETIVO: ENVIAR MENSAJE A OTRA PAGINA ASPX
     */
    {
        string mensajepag = Request.QueryString["msgPag"];

        if (mensajepag != null || mensajepag != "")
        {
            if (mensajepag == "" || mensajepag == null)
                mensajepag = "ok";
            else
            {
                messbox1.Mensaje = mensajepag;
                messbox1.Tipo = "I";
                messbox1.showMess();
            }
        }
    }

    protected void ibtn1_Click(object sender, ImageClickEventArgs e)
    {
       // Response.Redirect("./Activos/Menu.aspx");
    }
    protected void ibtn2_Click(object sender, ImageClickEventArgs e)
    {
       //Response.Redirect("./Traslados/Menu.aspx");
    }
    protected void ibtn3_Click(object sender, ImageClickEventArgs e)
    {
        //Response.Redirect("./Inventarios/Menu.aspx");
    }
    protected void ibtn4_Click(object sender, ImageClickEventArgs e)
    {
       // Response.Redirect("./Mantenimiento/Menu.aspx");
    }
    protected void ibtn5_Click(object sender, ImageClickEventArgs e)
    {
      // Response.Redirect("./Depreciacion/Menu.aspx");
    }
    protected void ibtn6_Click(object sender, ImageClickEventArgs e)
    {
       // Response.Redirect("./Administracion/Menu.aspx");
    }
}
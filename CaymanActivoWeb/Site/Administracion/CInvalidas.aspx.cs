using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Site_Administracion_CInvalidas : System.Web.UI.Page
{
    ErrorTrapper errtrap;
    HPassword hp = new HPassword();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = ConfigurationManager.AppSettings["Titulo"] + " Desbloquear Usuarios";

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
            ibDesbl.Attributes.Add("onmouseout", "this.src='../../Img/ub1.png'");
            ibDesbl.Attributes.Add("onmouseover", "this.src='../../Img/ub2.png'");
        }
        cargarBloqueados();
    }

    private void cargarBloqueados()
    {
        try
        {
            ddbloqueados.Items.Clear();

            MembershipUserCollection users = Membership.GetAllUsers();

            foreach (MembershipUser use in users)
            {
                if (use.IsLockedOut)
                {
                    ddbloqueados.Items.Add(use.ToString());
                }
            }
            if (ddbloqueados.Items.Count == 0)
            {
                ibDesbl.Enabled = false;
                ibDesbl.ImageUrl = "~/Img/ub3.png";
            }
            else
            {
                ibDesbl.Enabled = true;
                ibDesbl.ImageUrl = "~/Img/ub1.png";
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


    protected void ibDesbl_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            Membership.GetUser(ddbloqueados.SelectedItem.Text).UnlockUser();
            if (hp.EliminaBloqueo(ddbloqueados.SelectedItem.Text))
            { 
                
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
        cargarBloqueados();
        UpdatePanel1.Update();
    }
}
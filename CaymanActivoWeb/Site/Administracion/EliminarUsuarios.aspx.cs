using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class EliminarUsuarios : System.Web.UI.Page
{
    ErrorTrapper errtrap;
    HPassword hp = new HPassword();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = ConfigurationManager.AppSettings["Titulo"] + " Eliminar Usuarios del Sistema";

        try
        {
            if ((string)(Session["emid"]) == null)
            {
                Session.Abandon();
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }

            if (!Page.IsPostBack)
            {
                BindUsersToUserList();
                ibtnDelUsu.Attributes.Add("onmouseout", "this.src='../../Img/delUsu.png'");
                ibtnDelUsu.Attributes.Add("onmouseover", "this.src='../../Img/delUsu2.png'");
            }
        }
        catch (Exception ex)
        {
            errtrap = new ErrorTrapper();
            errtrap.SetOnError("Usuario:" + Membership.GetUser().UserName + "<< " + ex.Message, 0);

            Session.Abandon();
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

        if (!IsPostBack)
        {
        }
    }


    private void BindUsersToUserList()
    {
        try
        {
            // Get all of the user accounts
            MembershipUserCollection users = Membership.GetAllUsers();
            UserList.DataSource = users;
            UserList.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void ibtnDelUsu_Click(object sender, ImageClickEventArgs e)
    {
        try
        {                        
            if (Membership.DeleteUser(UserList.SelectedItem.Text))
            {
                hp.EliminaUsu(UserList.SelectedItem.Text);
                // Display a status message
                messbox1.Mensaje = string.Format("Usuario {0} ha sido Eliminado.", UserList.SelectedItem.Text);
                messbox1.Tipo = "S";
            }
            else
            {
                // Display a status message
                messbox1.Mensaje = string.Format("Usuario {0} no ha sido Eliminado.", UserList.SelectedItem.Text);
                messbox1.Tipo = "E";
            }

            messbox1.showMess();
            BindUsersToUserList();
        }        
        catch (Exception ex)
        {
            errtrap = new ErrorTrapper();
            errtrap.SetOnError("Usuario:" + Membership.GetUser().UserName + "<< " + ex.Message, 0);
            messbox1.Mensaje = "Error. "+ex.Message;
            messbox1.Tipo = "E";
            messbox1.showMess();
        }
    }
}

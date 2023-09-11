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

public partial class RolesUsuarios : System.Web.UI.Page
{
    ErrorTrapper errtrap;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = ConfigurationManager.AppSettings["Titulo"] + " Gestionar Roles por Usuario";

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

        if (!Page.IsPostBack)
        {
            // Bind the users and roles
            BindUsersToUserList();
            BindRolesToList();

            // Check the selected user's roles
            CheckRolesForSelectedUser();

            // Display those users belonging to the currently selected role
            //DisplayUsersBelongingToRole();
        }
    }

    private void BindRolesToList()
    {
        try
        {  
        // Get all of the roles
        string[] roles = Roles.GetAllRoles();
        UsersRoleList.DataSource = roles;
        UsersRoleList.DataBind();

        //RoleList.DataSource = roles;
        //RoleList.DataBind();
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
            errtrap = new ErrorTrapper();
            errtrap.SetOnError("Usuario:" + Membership.GetUser().UserName + "<< " + ex.Message, 0);
            messbox1.Mensaje = "Error. "+ex.Message;
            messbox1.Tipo = "E";
            messbox1.showMess();
        }
    }

    protected void UserList_SelectedIndexChanged(object sender, EventArgs e)
    {
        CheckRolesForSelectedUser();
    }

    private void CheckRolesForSelectedUser()
    {
        try
        {
            // Determine what roles the selected user belongs to
            string selectedUserName = UserList.SelectedValue;
            string[] selectedUsersRoles = Roles.GetRolesForUser(selectedUserName);

            // Loop through the Repeater's Items and check or uncheck the checkbox as needed
            foreach (RepeaterItem ri in UsersRoleList.Items)
            {
                // Programmatically reference the CheckBox
                CheckBox RoleCheckBox = ri.FindControl("RoleCheckBox") as CheckBox;

                // See if RoleCheckBox.Text is in selectedUsersRoles
                if (selectedUsersRoles.Contains<string>(RoleCheckBox.Text))
                    RoleCheckBox.Checked = true;
                else
                    RoleCheckBox.Checked = false;
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

    protected void RoleCheckBox_CheckChanged(object sender, EventArgs e)
    {
        try
        {
            // Reference the CheckBox that raised this event
            CheckBox RoleCheckBox = sender as CheckBox;

            // Get the currently selected user and role
            string selectedUserName = UserList.SelectedValue;
            string roleName = RoleCheckBox.Text;

            // Determine if we need to add or remove the user from this role
            if (RoleCheckBox.Checked)
            {
                // Add the user to the role
                Roles.AddUserToRole(selectedUserName, roleName);

                // Display a status message
                messbox1.Mensaje = string.Format("Usuario {0} ha sido agregado al Rol {1}.", selectedUserName, roleName);
                messbox1.Tipo = "S";
            }
            else
            {
                // Remove the user from the role
                Roles.RemoveUserFromRole(selectedUserName, roleName);

                // Display a status message
                messbox1.Mensaje = string.Format("Usuario {0} ha sido removido del Rol {1}.", selectedUserName, roleName);
                messbox1.Tipo = "I";
            }

            // Refresh the "by role" interface
            //DisplayUsersBelongingToRole();

            messbox1.showMess();
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

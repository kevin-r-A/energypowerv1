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

public partial class Site_Administracion_Usuarios : System.Web.UI.Page
{
    ErrorTrapper errtrap;
    HPassword psw = new HPassword();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = ConfigurationManager.AppSettings["Titulo"] + " Crear Usuarios del Sistema";

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


            // Reference the SpecifyRolesStep WizardStep
            WizardStep SpecifyRolesStep = CreateUserWizard1.FindControl("SpecifyRolesStep") as WizardStep;

            // Reference the RoleList CheckBoxList
            CheckBoxList RoleList = SpecifyRolesStep.FindControl("RoleList") as CheckBoxList;
            try
            {
                // Bind the set of roles to RoleList
                RoleList.DataSource = Roles.GetAllRoles();
                RoleList.DataBind();
            }
            catch (Exception ex)
            {
                errtrap = new ErrorTrapper();
                errtrap.SetOnError("Usuario:" + Membership.GetUser().UserName + "<< " + ex.Message, 0);
                messbox1.Mensaje = "Error. " + ex.Message;
                messbox1.Tipo = "E";
                messbox1.showMess();
            } 

            string msg = "";
                msg = Request["msg"];
                if (msg != "")
                {
                    abreVentana(msg);
                }
        }
    }
    protected void CreateUserWizard1_ActiveStepChanged(object sender, EventArgs e)
    {
       try
            {
                // Have we JUST reached the Complete step?
                if (CreateUserWizard1.ActiveStep.Title == "Complete" || CreateUserWizard1.ActiveStep.Title == "Completar")
                {
                    // Reference the SpecifyRolesStep WizardStep
                    WizardStep SpecifyRolesStep = CreateUserWizard1.FindControl("SpecifyRolesStep") as WizardStep;

                    // Reference the RoleList CheckBoxList
                    CheckBoxList RoleList = SpecifyRolesStep.FindControl("RoleList") as CheckBoxList;

                    // Add the checked roles to the just-added user
                    foreach (ListItem li in RoleList.Items)
                    {
                        if (li.Selected)
                            Roles.AddUserToRole(CreateUserWizard1.UserName, li.Text);
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
    protected void CreateUserWizard1_CreatingUser(object sender, LoginCancelEventArgs e)
    {
        string p = CreateUserWizard1.Password.ToString();
        bool tieneMayusculas = p.Any(c => char.IsUpper(c));
        bool tieneNumero = p.Any(x => char.IsDigit(x));

        if (!tieneMayusculas)
        {
            Response.Redirect("Usuarios.aspx?msg=1");  
        }

        if (!tieneNumero)
        {
            Response.Redirect("Usuarios.aspx?msg=2");  
        }

        if (tieneMayusculas && tieneNumero)
        {
            string usu = CreateUserWizard1.UserName.ToString();

                string msg = psw.Guardar(usu, p, System.DateTime.Now, 1);

                if (msg != "ok")
                {
                    Response.Redirect("Usuarios.aspx?msg=3");
                }
            
        }
    }
    private void abreVentana(string msg)
    {
        string f = "OpenWindows('" + msg +"')";

        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "DICE", f, true);

    }
}
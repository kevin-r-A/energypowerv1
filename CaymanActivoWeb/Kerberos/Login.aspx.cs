using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class Kerberos_Login : System.Web.UI.Page
{
    ErrorTrapper errtrap;
    HPassword hp = new HPassword();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                if (Request.IsAuthenticated && !string.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
                { // This is an unauthorized, authenticated request...
                    Response.Redirect("~/Deny.aspx");
                }
            }
        }
        catch (Exception ex)
        {
            errtrap = new ErrorTrapper();
            errtrap.SetOnError("Usuario:" + Membership.GetUser().UserName + "<< " + ex.Message, 0);
            messbox1.Mensaje = "Error: " + ex.Message;
            messbox1.Tipo = "E";
            messbox1.showMess();
        }
    }
    protected void Login1_LoggedIn(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddl1 = (DropDownList)Login1.FindControl("ddEmpresa");
            DataTable dt1 = Logica.HELPER.getEmpresas(ddl1.SelectedValue);

            if (dt1.Rows.Count > 0)
            {
                Session["emtd"] = dt1.Rows[0]["emp_totaldigitos"].ToString();
                Session["emid"] = ddl1.SelectedValue;
                Session["empr"] = dt1.Rows[0]["emp_prefijo"].ToString();
            }
            else
            {
                Session.Abandon();
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }
        catch (Exception ex)
        {
            errtrap = new ErrorTrapper();
            errtrap.SetOnError("Usuario:" + Membership.GetUser().UserName + "<< " + ex.Message, 0);
            messbox1.Mensaje = "Error: " + ex.Message;
            messbox1.Tipo = "E";
            messbox1.showMess();
        }
        
    }
    protected void Login1_LoginError(object sender, EventArgs e)
    {
        try
        {
            MembershipUser userInfo = Membership.GetUser(Login1.UserName);

            if (userInfo != null)
            {
                if (userInfo.IsLockedOut)
                    Login1.FailureText = "Tu cuenta ha sido bloqueada ya que excediste el número de intentos(5) para ingresar. Solicita desbloquear tu cuenta al administrador del sistema";
            }

            Logica.HELPER.insErrorLogin(Membership.ApplicationName, Login1.UserName, Login1.Password, Request.UserHostAddress);

        }
        catch (Exception ex)
        {
            errtrap = new ErrorTrapper();
            errtrap.SetOnError("Usuario:" + Membership.GetUser().UserName + "<< " + ex.Message, 0);
            messbox1.Mensaje = "Error: " + ex.Message;
            messbox1.Tipo = "E";
            messbox1.showMess();
        }
    }
}



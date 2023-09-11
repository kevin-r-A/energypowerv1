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

public partial class ResetClave : System.Web.UI.Page
{
    ErrorTrapper errtrap;
    HPassword psw = new HPassword(); 
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = ConfigurationManager.AppSettings["Titulo"] + " Cambiar Contraseña de Usuario";

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
            ibCambiar.Attributes.Add("onmouseout", "this.src='../../Img/uc1.png'");
            ibCambiar.Attributes.Add("onmouseover", "this.src='../../Img/uc2.png'");
            // Bind the users and roles
            BindUsersToUserList();

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
            messbox1.Mensaje = "Error. " + ex.Message;
            messbox1.Tipo = "E";
            messbox1.showMess();
        }
    }

    protected void ibCambiar_Click(object sender, ImageClickEventArgs e)
    {
        MembershipUser usuarioblock = Membership.GetUser(UserList.SelectedItem.ToString());
        if (usuarioblock.IsLockedOut)
        {
            messbox1.Mensaje = "No se puede cambiar la Contraseña al Usuario: " + usuarioblock.UserName.ToString() + " la cuanta esta <b>BLOQUEADA</b>, Tiene que <b>DESBLOQUEAR</b> para continuar";
            messbox1.Tipo = "E";  

        }
        else
        {

            try
            {
                if (txtnuevaclave.Text.Length >= 3 && !txtnuevaclave.Text.Contains(" "))
                {

                    string p = txtnuevaclave.Text.Trim();
                    bool tieneMayusculas = p.Any(c => char.IsUpper(c));
                    bool tieneNumero = p.Any(x => char.IsDigit(x));

                    if (tieneMayusculas && tieneNumero)
                    {

                        if (psw.PwdUsada(txtnuevaclave.Text.Trim(), UserList.SelectedItem.ToString().Trim()))
                        {
                            MembershipUser usuario = Membership.GetUser(UserList.SelectedItem.ToString());

                            usuario.UnlockUser();
                            usuario.IsApproved = true;

                            usuario.ChangePassword(usuario.ResetPassword(), txtnuevaclave.Text.Trim());


                            string msg = psw.Guardar(UserList.SelectedItem.ToString().Trim(), txtnuevaclave.Text.Trim(), System.DateTime.Now, 1);
                            if (msg == "ok")
                            {
                                txtnuevaclave.Text = "";
                                txtnuevaclave.Focus();
                                messbox1.Mensaje = "Contraseña actualizada con éxito";
                                messbox1.Tipo = "S";
                            }
                            else
                            {
                                messbox1.Mensaje = msg;
                                messbox1.Tipo = "E";
                            }
                        }
                        else
                        {
                            txtnuevaclave.Text = ""; ;
                            txtnuevaclave.Focus();
                            messbox1.Mensaje = "<h5>La Contraseña ya fue utilizada, intente con otra Diferente...</h5>";
                            messbox1.Tipo = "E";

                        }
                    }
                    else
                    {
                        if (!tieneMayusculas)
                        {
                            messbox1.Mensaje = "<h5>La Constraseña debe contener una Letra Mayuscula</h5>";
                            messbox1.Tipo = "E";
                        }
                        else if (!tieneNumero)
                        {
                            messbox1.Mensaje = "<h5>La Constraseña debe contener una Un Numero</h5>";
                            messbox1.Tipo = "E";
                        }
                    }
                }
                else
                {
                    messbox1.Mensaje = "Error, la Contraseña debe tener al menos 3 caracteres y no debe contener espacios en blanco";
                    messbox1.Tipo = "E";
                }

                
            }
            catch (Exception ex)
            {
                errtrap = new ErrorTrapper();
                errtrap.SetOnError("Usuario:" + Membership.GetUser().UserName + "<< " + ex.Message, 0);
                messbox1.Mensaje = "Error, " + ex.Message;
                messbox1.Tipo = "E";
                messbox1.showMess();
            }
        }

        messbox1.showMess();
    }
}
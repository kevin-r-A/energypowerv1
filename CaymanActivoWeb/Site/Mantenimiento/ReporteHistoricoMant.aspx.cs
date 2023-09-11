using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web.Security;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Drawing;
using System.Drawing.Imaging;


public partial class Site_Mantenimiento_ReporteHistoricoMant : System.Web.UI.Page
{
    ErrorTrapper errtrap;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = ConfigurationManager.AppSettings["Titulo"] + " Historicos Mantenimientos Activos";

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

        try
        {

            if (!IsPostBack)
            {


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

    public string completarCodigo(string codbar)
    {
        try
        {
            //ceros es el numero de digitos disponibles para activos
            int ceros = 0;
            ceros = int.Parse(Session["emtd"].ToString()) - Session["empr"].ToString().Length;
            for (int i = codbar.Length; i < ceros; i++)
                codbar = "0" + codbar;
            return codbar;
        }
        catch (Exception ex)
        {
            errtrap = new ErrorTrapper();
            errtrap.SetOnError("Usuario:" + Membership.GetUser().UserName + "<< " + ex.Message, 0);
            messbox1.Mensaje = "Error: " + ex.Message;
            messbox1.Tipo = "E";
            messbox1.showMess();
            return "";
        }
    }

    private bool codigoCorrecto()
    {
        try
        {
            string codbar = "";

            if (txtbuscb.Text.Trim().Length < int.Parse(Session["emtd"].ToString()))
            {
                codbar = Session["empr"].ToString() + completarCodigo(txtbuscb.Text.Trim());
            }
            else if (txtbuscb.Text.Trim().Length == int.Parse(Session["emtd"].ToString()))
            {
                codbar = txtbuscb.Text.Trim();
            }
            else
            {
                return false;
            }

            if (Logica.HELPER.codigoValido(codbar))
            {
                txtbuscb.Text = codbar;
                // upbus.Update();
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            errtrap = new ErrorTrapper();
            errtrap.SetOnError("Usuario:" + Membership.GetUser().UserName + "<< " + ex.Message, 0);
            messbox1.Mensaje = "Error: " + ex.Message;
            messbox1.Tipo = "E";
            messbox1.showMess();
            return false;
        }
    }



    protected void ibbus1_Click(object sender, ImageClickEventArgs e)
    {
        txtbusid.Text = "";
        try
        {
            if (codigoCorrecto())
            {
                if (Logica.HELPER.comprobarCbIngresado(txtbuscb.Text))
                {
                    //cargar datos
                    panReporte.Visible = true;
                    cargarActivo(txtbuscb.Text.Trim(), 1);

                }
                else
                {
                    panReporte.Visible = false;
                    messbox1.Mensaje = "Código Válido, pero aún no ha sido ingresado!";
                    messbox1.Tipo = "I";
                    messbox1.showMess();
                }
            }
            else
            {
                panReporte.Visible = false;
                messbox1.Mensaje = "El Código de Barras No Válido!";
                messbox1.Tipo = "W";
                messbox1.showMess();
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


    public void cargarActivo(string codigo, int op)
    {
        DataTable dt = new DataTable();
        try
        {
            //busca solo por codigo todo   
            dt = Logica.HELPER.getMantenimiento(codigo, op);

            if (dt.Rows.Count > 0)
            {
                gv_ES.DataSource = dt;
                Session["datos"] = dt;
                gv_ES.DataBind();
            }
            else
            {
                txtbuscb.Text = "";
                messbox1.Mensaje = "No se han Registrado Mantenimientos....!!!";
                messbox1.Tipo = "I";
                messbox1.showMess();

                gv_ES.DataSource = null;
                Session["datos"] = null;
                gv_ES.DataBind();
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

    protected void ibcancel_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Modificar.aspx");
    }

    protected void gv_ES_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        if (e.CommandName == Telerik.Web.UI.RadGrid.ExportToExcelCommandName)
        {
            F_ExportarExcel();
        }
    }

    public void F_ExportarExcel()
    {
        gv_ES.ExportSettings.IgnorePaging = true;
        gv_ES.ExportSettings.FileName = "ReporteHistoricoMantenimientos_" + System.DateTime.Now.ToString("ddMMyyyy");
        gv_ES.ExportSettings.ExportOnlyData = true;
        gv_ES.ExportSettings.OpenInNewWindow = true;
        gv_ES.MasterTableView.ExportToExcel();
    }
    protected void chbpxTodos_CheckedChanged(object sender, EventArgs e)
    {
        if (chboxTodos.Checked)
        {
            txtbuscb.Text = "";
            txtbusid.Text = "";
            txtbuscb.Enabled = false;
            txtbusid.Enabled = false;
            panReporte.Visible = true;

            cargarActivo("", 3);
        }

        else
        {
            txtbuscb.Enabled = true;
            txtbusid.Enabled = true;
            panReporte.Visible = false;
        }
    }


    protected void ibbus2_Click(object sender, ImageClickEventArgs e)
    {
        txtbuscb.Text = "";
        try
        {

            if (Logica.HELPER.comprobarIdIngresadoSerie(txtbusid.Text.Trim()))
            {
                //cargar datos
                panReporte.Visible = true;
                cargarActivo(txtbusid.Text.Trim(), 2);

            }
            else
            {
                panReporte.Visible = false;
                messbox1.Mensaje = "Item no ha sido ingresado!";
                messbox1.Tipo = "I";
                messbox1.showMess();
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
    protected void btnbusbnf_Click(object sender, ImageClickEventArgs e)
    {
        txtbuscb.Text = "";
        try
        {

            if (Logica.HELPER.comprobarCodSecundarioIngresado(txtbusbnf.Text.Trim()))
            {
                //cargar datos
                panReporte.Visible = true;
                cargarActivo(txtbusbnf.Text.Trim(), 4);

            }
            else
            {
                panReporte.Visible = false;
                messbox1.Mensaje = "Item no ha sido ingresado!";
                messbox1.Tipo = "I";
                messbox1.showMess();
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
}
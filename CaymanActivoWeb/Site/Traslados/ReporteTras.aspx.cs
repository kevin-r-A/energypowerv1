using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;
using System.Text;
using System.Web.Security;
using System.Web.UI.HtmlControls;

public partial class ReporteTras : System.Web.UI.Page
{
    ErrorTrapper errtrap;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = ConfigurationManager.AppSettings["Titulo"] + " Reporte de Traslados";

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
            messbox1.Mensaje = "Error. " + ex.Message;
            messbox1.Tipo = "E";
            messbox1.showMess();
            return false;
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
            messbox1.Mensaje = "Error. " + ex.Message;
            messbox1.Tipo = "E";
            messbox1.showMess();
            return "";
        }
    }


    protected void ibbus1_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            txtbusid.Text = "";
            if (codigoCorrecto())
            {
                if (Logica.HELPER.comprobarCbIngresado(txtbuscb.Text))
                {
                    //messbox1.Mensaje = "Activo encontrado";
                    //messbox1.Tipo = "S";
                    //messbox1.showMess();
                    //cargar datos
                    pantras.Visible = true;
                    cargarActivo(txtbuscb.Text, "cb");
                }
                else
                {
                    pantras.Visible = false;
                    messbox1.Mensaje = "Código Válido, pero aún no ha sido ingresado!";
                    messbox1.Tipo = "I";
                    messbox1.showMess();
                    rgtras.DataSource = null;
                    rgtras.DataBind();
                }
            }
            else
            {
                messbox1.Mensaje = "El Código de Barras No Válido!";
                messbox1.Tipo = "W";
                messbox1.showMess();
                rgtras.DataSource = null;
                rgtras.DataBind();
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

    public void cargarActivo(string cod, string tipo)
    {
        try
        {

            if (Logica.HELPER.getTraslados(cod, tipo).Rows.Count > 0)
            {
                pantras.Visible = true;
                rgtras.DataSource = Logica.HELPER.getTraslados(cod, tipo);
                rgtras.DataBind();
                uptras.Update();
            }
            else
            {
                messbox1.Mensaje = "No existen Traslados Registrados";
                messbox1.Tipo = "I";
                messbox1.showMess();
                rgtras.DataSource = null;
                rgtras.DataBind();
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

    protected void ibbus3_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            txtbuscb.Text = "";

            if (Logica.HELPER.comprobarCodLogikard(txtbusid.Text.Trim()))
            {
                //messbox1.Mensaje = "Activo encontrado";
                //messbox1.Tipo = "S";
                //messbox1.showMess();
                //cargar datos
               
                cargarActivo(txtbusid.Text, "cs");
            }
            else
            {
                pantras.Visible = false;
                messbox1.Mensaje = "No se encontró ningún item con Código = " + txtbusid.Text.Trim();
                messbox1.Tipo = "I";
                messbox1.showMess();
                rgtras.DataSource = null;
                rgtras.DataBind();
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
    //funcion para colorear la fila cuando pase el mouse, no funciona con grid css
    //protected void rgtras_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    { 
    //        e.Row.Attributes.Add("onmouseover",
    //        "this.originalcolor=this.style.backgroundColor;" +
    //        " this.style.backgroundColor='#F2E483'");
    //        e.Row.Attributes.Add("onmouseout",
    //        "this.style.backgroundColor=this.originalcolor;");
    //    }
    //}
    protected void ibxls1_Click(object sender, ImageClickEventArgs e)
    {
        if (rgtras.Rows.Count > 0)
        {
            exportarExcel(rgtras, "Reporte Historico Traslados");
        }
        else
        {
            messbox1.Mensaje = "No existen datos para Exportar...!!!";
            messbox1.Tipo = "W";
            messbox1.showMess();

        }
    }

    public void exportarExcel(GridView grid, string nombre)
    {
        try
        {
            string date = DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString();

            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            System.Web.UI.Page page = new System.Web.UI.Page();
            HtmlForm form = new HtmlForm();

            grid.EnableViewState = false;

            // Deshabilitar la validación de eventos, sólo asp.net 2
            page.EnableEventValidation = false;

            // Realiza las inicializaciones de la instancia de la clase Page que requieran los diseñadores RAD.
            page.DesignerInitialize();

            page.Controls.Add(form);
            form.Controls.Add(grid);

            page.RenderControl(htw);

            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + nombre + "_" + date + ".xls");
            Response.Charset = "UTF-8";
            Response.ContentEncoding = Encoding.Default;
            Response.Write(sb.ToString());
            Response.End();
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

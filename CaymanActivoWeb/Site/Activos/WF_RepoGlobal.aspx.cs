using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using Telerik.Web.UI;
using System.Web.Security;
using System.IO;
using System.Text;
using System.Web.UI.HtmlControls;

public partial class WF_RepoGlobal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //combos
        Combos ObjCombos = new Combos(); 

      
        if (!IsPostBack)
        {
            
            this.Title = ConfigurationManager.AppSettings["Titulo"] + " Autorización Items";
            ObjCombos.F_CargarComboTblParametros(cmbTipoBien, "PARAMETROSPC01");

            //btnBuscar.Attributes.Add("onmouseout", "this.src='../../Img/btnbuscar11.png'");
            //btnBuscar.Attributes.Add("onmouseover", "this.src='../../Img/btnbuscarout.png'");

            gv_Activos.Visible = false;

            rdp_Desde.SelectedDate = DateTime.Now;
            rdp_Hasta.SelectedDate = DateTime.Now;

            Session["Datos"] = "";
            Cache["Datos"] = "";
            ibxls1.Visible = false;


            rdp_Desde.Enabled = false;
            rdp_Hasta.Enabled = false;
        }
    }

    public DataTable F_CargarTabla(string tipo)
    {
        Logica.AccesoDatosBD ObjDatos = new Logica.AccesoDatosBD();
        DataTable dt = new DataTable();
        string msg ="";
        string[] ArrayParam = new string[5];


        if (txtCodigo.Text != "" && chboxTodosFechas.Checked == false)
        {
            ArrayParam[0] = "2";
            ArrayParam[1] = txtCodigo.Text.Trim();
            ArrayParam[2] = "";
            ArrayParam[3] = "";
            ArrayParam[4] = "";
        }
        else if (chboxTodos.Checked == true)
        {
            ArrayParam[0] = "1";
            ArrayParam[1] = "";
            ArrayParam[2] = "";
            ArrayParam[3] = "";
            ArrayParam[4] = "";
        }
        else if (chboxTodosFechas.Checked == true && txtCodigo.Text == "")
        {
            ArrayParam[0] = "4";
            ArrayParam[1] = "";
            ArrayParam[2] = "";

            /*para consultar en la base del registro propiedad --->> descomentar al publicar*/
            //ArrayParam[3] = rdp_Desde.SelectedDate.Value.Date.ToString("yyyy-dd-MM");
            //ArrayParam[4] = rdp_Hasta.SelectedDate.Value.ToString("yyyy-dd-MM");

            /*para consultar en la base de desarrollo --->> comentar al publicar*/
            ArrayParam[3] = rdp_Desde.SelectedDate.Value.Date.ToString("yyyy-MM-dd");
            ArrayParam[4] = rdp_Hasta.SelectedDate.Value.ToString("yyyy-MM-dd");
        }
        else if (txtCodigo.Text != "" && chboxTodosFechas.Checked == true)
        {
            ArrayParam[0] = "5";
            ArrayParam[1] = txtCodigo.Text.Trim();
            ArrayParam[2] = "";

            /*para consultar en la base del registro propiedad --->> descomentar al publicar*/
            //ArrayParam[3] = rdp_Desde.SelectedDate.Value.Date.ToString("yyyy-dd-MM");
            //ArrayParam[4] = rdp_Hasta.SelectedDate.Value.ToString("yyyy-dd-MM");

            /*para consultar en la base de desarrollo --->> comentar al publicar*/
            ArrayParam[3] = rdp_Desde.SelectedDate.Value.Date.ToString("yyyy-MM-dd");
            ArrayParam[4] = rdp_Hasta.SelectedDate.Value.ToString("yyyy-MM-dd");
        }
        else if (chboxTodos.Checked == false && chboxTodos.Checked == false)
        {
            ArrayParam[0] = "3";
            ArrayParam[1] = "";
            ArrayParam[2] = cmbTipoBien.SelectedItem.Text;
            ArrayParam[3] = "";
            ArrayParam[4] = "";
        }


        dt = ObjDatos.RetornaDT_ConParametros("LECTURA_MOVIMIENTOSPC01", ArrayParam, ref msg);

        if (msg == "iok")
        {
            ibxls1.Visible = true;
            Cache["Datos"] = dt;
            Session["Datos"] = dt;
            gv_Activos.Visible = true;
            return dt;
        }
        else
        {
            gv_Activos.Visible = false;
            ibxls1.Visible = false;
            Session["Datos"] = null;
            Cache["Datos"] = "";

            messbox1.Mensaje = "No existen datos....!!!";
            messbox1.Tipo = "W";
            messbox1.showMess();
            
            return dt = null;
            
        }
    }


    protected void btnNuevo_Click(object sender, EventArgs e)
    {

        gv_Activos.DataSource = F_CargarTabla(cmbTipoBien.SelectedItem.Text);
        gv_Activos.DataBind();

    }

    public string F_FechaBD()
    {
        string dia = Convert.ToString(System.DateTime.Now.Day);
        string mes = Convert.ToString(System.DateTime.Now.Month);
        string anio = Convert.ToString(System.DateTime.Now.Year);

        string fechafin = anio + "-" + mes + "-" + dia;

        return fechafin;
    }

    protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
    {
        gv_Activos.DataSource = F_CargarTabla(cmbTipoBien.SelectedItem.Text);
        gv_Activos.DataBind();
        Session["dato"] = F_CargarTabla(cmbTipoBien.SelectedItem.Text);
    }
    protected void chboxTodos_CheckedChanged(object sender, EventArgs e)
    {
        if (chboxTodos.Checked == true)
        {
            cmbTipoBien.Enabled = false;
            txtCodigo.Text = "";
            txtCodigo.Enabled = false;
            rdp_Desde.Enabled = false;
            rdp_Hasta.Enabled = false;

            chboxTodosFechas.Checked = false;
            chboxTodosFechas.Enabled = false;

        }
        else
        {
            cmbTipoBien.Enabled = true;
            txtCodigo.Text = "";
            txtCodigo.Enabled = true;
            txtCodigo.Focus();
            rdp_Desde.Enabled = false;
            rdp_Hasta.Enabled = false;
            chboxTodosFechas.Enabled = true;
        }
    }


    protected void gv_Activos_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        gv_Activos.DataSource = Session["Datos"];
        gv_Activos.DataBind();
    }
    protected void chboxTodosFechas_CheckedChanged(object sender, EventArgs e)
    {

        if (chboxTodosFechas.Checked == true)
        {
            rdp_Desde.Enabled = true;
            rdp_Hasta.Enabled = true;
        }
        else
        {
            rdp_Desde.Enabled = false;
            rdp_Hasta.Enabled = false;
        }

    }
    protected void gv_Activos_PageIndexChanged(object sender, GridPageChangedEventArgs e)
    {
        gv_Activos.DataSource = Session["Datos"];
            gv_Activos.DataBind();
    }
    protected void ibxls1_Click(object sender, ImageClickEventArgs e)
    {
        DataTable dt = (DataTable)Cache["Datos"];

        if (dt.Rows.Count > 0)
        {
            rgreportexls.DataSource = dt;
            rgreportexls.DataBind();
            exportarExcel(rgreportexls, "ReporteLecturaRFID");
            rgreportexls.DataSource = null;
            rgreportexls.DataBind();
            rgreportexls.Dispose();
        
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
           
            messbox1.Mensaje = "Error: " + ex.Message;
            messbox1.Tipo = "E";
            messbox1.showMess();
        }
    }

    protected void gv_Activos_PageSizeChanged(object sender, GridPageSizeChangedEventArgs e)
    {
        gv_Activos.DataSource = Session["dato"];
    }
}
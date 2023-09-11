using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Services;
using Telerik.Web.UI;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

public partial class RepoCod : System.Web.UI.Page
{
    ErrorTrapper errtrap;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = ConfigurationManager.AppSettings["Titulo"] + " Reporte Codificación";
        ibxls1.Attributes.Add("onmouseout", "this.src='../../Img/xls1.png'");
        ibxls1.Attributes.Add("onmouseover", "this.src='../../Img/xls2.png'");

        ibxls2.Attributes.Add("onmouseout", "this.src='../../Img/xls1.png'");
        ibxls2.Attributes.Add("onmouseover", "this.src='../../Img/xls2.png'");

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

        cargarCodigosNoUtilizados();       
    }

    private void cargarCodigosNoUtilizados()
    {
        DataTable dtutil = new DataTable();
        DataTable dtnoutil = new DataTable();

        int contadorsi = 0;
        dtutil.Columns.Add("Cont.");
        dtutil.Columns.Add("Id");
        dtutil.Columns.Add("Código");
        dtutil.Columns.Add("Descripción");


        int contadorno = 0;
        dtnoutil.Columns.Add("Cont.");
        dtnoutil.Columns.Add("Código");

        DataTable dtdeta;

        try
        {
            string codigo = "";
            int last = Logica.HELPER.getLastCb(int.Parse(Session["emtd"].ToString()));

            //CARGO IMPRESOS
            for (int i = 1; i <= last; i++)
            {
                codigo = Logica.HELPER.getVerificador(Session["empr"].ToString() + completarCodigo(i.ToString()), int.Parse(Session["emtd"].ToString()));
                //BUSCO EN LA BASE
                if (!Logica.HELPER.comprobarCbIngresado(codigo))
                {
                    contadorno++;
                    codigo = "'" + codigo;
                    dtnoutil.Rows.Add(contadorno,codigo);
                }
                else
                {
                    dtdeta= Logica.HELPER.getIdDescripcion(codigo);
                    contadorsi++;
                    codigo = "'" + codigo;
                    dtutil.Rows.Add(contadorsi,dtdeta.Rows[0][0].ToString(), codigo,dtdeta.Rows[0][1].ToString());
                }
            }

            rgnoutil.DataSource = dtnoutil;
            rgnoutil.DataBind();

            Cache["dtnoutil"] = dtnoutil;

            rgutil.DataSource = dtutil;
            rgutil.DataBind();

            panutil.GroupingText = "Códigos Utilizados [ " + contadorsi + " ] ";
            pannoutil.GroupingText = "Códigos No Utilizados [ " + contadorno + " ] ";
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

    public string completarCodigo(string cod)
    {
        try
        {
            //ceros es el numero de digitos disponibles para activos
            int ceros = int.Parse((string)(Session["emtd"])) - ((string)(Session["empr"])).Length - 1;
            for (int i = cod.Length; i < ceros; i++)
                cod = "0" + cod;
            return cod;
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

    protected void rgutil_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1)
        {
            HyperLink hk = (HyperLink)e.Row.Cells[0].FindControl("hk1");
            hk.NavigateUrl = "Modificar.aspx?id=" + e.Row.Cells[2].Text;
        }
    }
    protected void ibxls1_Click(object sender, ImageClickEventArgs e)
    {
        rgutil.Columns[0].Visible = false;
        exportarExcel(rgutil, "CodUtil");
    }
    protected void ibxls2_Click(object sender, ImageClickEventArgs e)
    {
        exportarExcel(rgnoutil,"CodNoUtil");
    }

    public void exportarExcel(GridView grid, string name)
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
        Response.AddHeader("Content-Disposition", "attachment;filename="+name+"_"+ date + ".xls");
        Response.Charset = "UTF-8";
        Response.ContentEncoding = Encoding.Default;
        Response.Write(sb.ToString());
        //string sStyle = @" .CssText { mso-number-format:\@; } ";
        //Response.Write(sStyle);
        Response.End();
    }
}
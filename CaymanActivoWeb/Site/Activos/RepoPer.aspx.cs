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
using CustomEditors;


public partial class RepoPer : System.Web.UI.Page
{
    ErrorTrapper errtrap;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = ConfigurationManager.AppSettings["Titulo"] + " Reporte Personalizado";

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
                panGrid.Width = Unit.Parse(ConfigurationManager.AppSettings["Rgancho3"]);

                if (ConfigurationManager.AppSettings["CCOUGE"] == "0")
                {
                    cddccosto.ParentControlID = "";
                    cddccosto.ServiceMethod = "GetCcosto";
                }
                else if (ConfigurationManager.AppSettings["CCOUGE"] == "1")
                {
                    cddccosto.ParentControlID = "ddUge1";
                    cddccosto.ServiceMethod = "GetCcostoUge1";
                }
                else if (ConfigurationManager.AppSettings["CCOUGE"] == "2")
                {
                    cddccosto.ParentControlID = "ddUge2";
                    cddccosto.ServiceMethod = "GetCcostoUge2";
                }
                else if (ConfigurationManager.AppSettings["CCOUGE"] == "3")
                {
                    cddccosto.ParentControlID = "ddUge3";
                    cddccosto.ServiceMethod = "GetCcostoUge3";
                }

                if (ConfigurationManager.AppSettings["UORCCO"] == "0")
                {
                    cdduor1.ParentControlID = "";
                    cdduor1.ServiceMethod = "GetUor1";
                }
                else if (ConfigurationManager.AppSettings["UORCCO"] == "1")
                {
                    cdduor1.ParentControlID = "ddCcosto";
                    cdduor1.ServiceMethod = "GetUor1Cco";
                }


                ibsave.Attributes.Add("onmouseout", "this.src='../../Img/t1.png'");
                ibsave.Attributes.Add("onmouseover", "this.src='../../Img/t2.png'");

                ibcancel.Attributes.Add("onmouseout", "this.src='../../Img/d1.png'");
                ibcancel.Attributes.Add("onmouseover", "this.src='../../Img/d2.png'");

                ibxls1.Attributes.Add("onmouseout", "this.src='../../Img/xls1.png'");
                ibxls1.Attributes.Add("onmouseover", "this.src='../../Img/xls2.png'");
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

    private void reset()
    {
        try
        {
            chk1.Checked = true;
            cddtipoitem.SelectedValue = "";
            cddgru1.SelectedValue = "";
            cddgeo1.SelectedValue = "";
            cddccosto.SelectedValue = "";
            cddcus.SelectedValue = "";
            cddest1.SelectedValue = "";
            cddest2.SelectedValue = "";
            cddest3.SelectedValue = "";
            cddmarca.SelectedValue = "";
            cddProveedor.SelectedValue = "";
            cddtipoing.SelectedValue = "";
            ddgarantia.SelectedIndex = 0;
            upFiltro.Update();

            rgreporte.DataSource = null;
            rgreporte.DataBind();
            upgrid.Update();

            cddcus.ParentControlID = "ddUor1";
            cddcus.ServiceMethod = "GetCusUor1";

            upFiltro.Update();

            rgreporte.SelectedIndex = -1;
            lblResumen.Text = "";
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
        reset();
    }

    protected void ibsave_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            rgreporte.SelectedIndex = -1;

            string query = "";

            if (ddtipoitem.SelectedValue != "")
            {
                query = query + " and ACT_TIPO='" + ddtipoitem.SelectedValue + "'";
            }

            if (ddGrupo.SelectedValue != "")
            {
                query = query + " and G.GRU_NOMBRE='" + ddGrupo.SelectedItem.Text + "'";
            }

            if (ddSubgrupo.SelectedValue != "")
            {
                query = query + " and GG.GRU_NOMBRE='" + ddSubgrupo.SelectedItem.Text + "'";
            }

            if (ddDescripcion.SelectedValue != "")
            {
                query = query + " and GGG.GRU_NOMBRE='" + ddDescripcion.SelectedItem.Text + "'";
            }

            if (ddUge1.SelectedValue != "")
            {
                query = query + " and UG1.UGE_NOMBRE='" + ddUge1.SelectedItem.Text + "'";
            }

            if (ddUge2.SelectedValue != "")
            {
                query = query + " and UG2.UGE_NOMBRE='" + ddUge2.SelectedItem.Text + "'";
            }

            if (ddUge3.SelectedValue != "")
            {
                query = query + " and UG3.UGE_NOMBRE='" + ddUge3.SelectedItem.Text + "'";
            }

            if (ddPiso.SelectedValue != "")
            {
                query = query + " and UG4.UGE_NOMBRE='" + ddPiso.SelectedItem.Text + "'";
            }

            if (ddCcosto.SelectedValue != "")
            {
                query = query + " and UO1.UOR_NOMBRE='" + ddCcosto.SelectedItem.Text + "'";
            }

            if (ddUor1.SelectedValue != "")
            {
                query = query + " and UO2.UOR_NOMBRE='" + ddUor1.SelectedItem.Text + "'";
            }

            if (ddUor2.SelectedValue != "")
            {
                query = query + " and UO3.UOR_NOMBRE='" + ddUor2.SelectedItem.Text + "'";
            }

            if (ddCustodio.SelectedValue != "")
            {
                query = query + " and ACTIVO.CUS_ID1=" + ddCustodio.SelectedValue + "";
            }

            //if (ddResponsable.SelectedValue != "")
            //{
            //    query = query + " and ACTIVO.CUS_ID2=" + ddResponsable.SelectedValue + "";
            //}

            if (ddEstado.SelectedValue != "")
            {
                query = query + " and E.EST_NOMBRE='" + ddEstado.SelectedItem.Text + "'";
            }

            if (ddFase.SelectedValue != "")
            {
                query = query + " and EE.EST_NOMBRE='" + ddFase.SelectedItem.Text + "'";
            }

            if (ddTrasnfer.SelectedValue != "")
            {
                query = query + " and EEE.EST_NOMBRE='" + ddTrasnfer.SelectedItem.Text + "'";
            }

            if (ddMarca.SelectedValue != "")
            {
                query = query + " and MAR_NOMBRE='" + ddMarca.SelectedItem.Text + "'";
            }

            if (ddModelo.SelectedValue != "")
            {
                query = query + " and MOD_NOMBRE='" + ddModelo.SelectedItem.Text + "'";
            }

            if (ddProveedor.SelectedValue != "")
            {
                query = query + " and ACTIVO.PRO_ID=" + ddProveedor.SelectedValue + "";
            }

            if (ddtipoing.SelectedValue != "")
            {
                query = query + " and ACT_TIPOING='" + ddtipoing.SelectedItem.Text + "'";
            }

            if (ddgarantia.SelectedIndex != 0)
            {
                query = query + " and ACT_GARANTIA = " + ddgarantia.SelectedValue;
            }

            if (ddSeguro.SelectedIndex != 0)
            {
                query = query + " and ACT_SEGURO = '" + ddSeguro.SelectedValue + "'";
            }

            DataTable dt = Logica.HELPER.getReporteTotalX(query);

            System.Threading.Thread.Sleep(10);

            rgreporte.DataSource = dt;
            rgreporte.DataBind();
            upgrid.Update();

            lblResumen.Text = "[ " + dt.Rows.Count.ToString() + " ] - Items Consultados";
            upres.Update();

            Cache["Repodt"] = dt;
            Cache["Repodtxls"] = dt;
            ViewState["Column_Name"] = "ID";
            ViewState["Sort_Order"] = "ASC";
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

    protected void chk1_CheckedChanged(object sender, EventArgs e)
    {
        if (!chk1.Checked)
        {
            //cddccosto.ParentControlID = "";
            //cddccosto.ServiceMethod = "GetCcosto";

            cddcus.ParentControlID = "";
            cddcus.ServiceMethod = "GetCus";

            upFiltro.Update();
        }
        else
        {
            //cddccosto.ParentControlID = "ddUge2";
            //cddccosto.ServiceMethod = "GetCcostoUge2";

            cddcus.ParentControlID = "ddUor1";
            cddcus.ServiceMethod = "GetCusUor1";

            upFiltro.Update();
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

    protected void rgutil_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowIndex != -1)
            {
                HyperLink hk = (HyperLink)e.Row.Cells[0].FindControl("hk2");
                ImageButton imageButton = (ImageButton)e.Row.Cells[0].FindControl("ibpdf1");
                hk.NavigateUrl = "Modificar.aspx?id=" + e.Row.Cells[1].Text;
                imageButton.Attributes.Add("value", e.Row.Cells[1].Text);
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.rgreporte, "Select$" + e.Row.RowIndex);
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

    protected void ibxls1_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            DataTable dtxls = (DataTable)Cache["Repodtxls"];
            if (dtxls != null && dtxls.Rows.Count > 0)
            {
                //rgreportexls.DataSource = setExport(dtxls);
                rgreportexls.DataSource = dtxls;
                rgreportexls.DataBind();
                exportarExcel(rgreportexls, "Reporte");
                rgreportexls.DataSource = null;
                rgreportexls.DataBind();
                rgreportexls.Dispose();
            }
            else
            {
                messbox1.Mensaje = "No hay datos para exportar.";
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

    public DataTable setExport(DataTable dt)
    {
        try
        {
            foreach (DataRow row in dt.Rows)
            {
                //para poder exportar a excel
                if (row["Serie"].ToString().Length != 0)
                    row["Serie"] = "'" + row["Serie"].ToString();
                if (row["CódigoBarras"].ToString().Length != 0)
                    row["CódigoBarras"] = "'" + row["CódigoBarras"].ToString();
                if (row["CódigoBarrasPadre"].ToString().Length != 0)
                    row["CódigoBarrasPadre"] = "'" + row["CódigoBarrasPadre"].ToString();
            }

            return dt;
        }
        catch (Exception ex)
        {
            errtrap = new ErrorTrapper();
            errtrap.SetOnError("Usuario:" + Membership.GetUser().UserName + "<< " + ex.Message, 0);
            messbox1.Mensaje = "Error: " + ex.Message;
            messbox1.Tipo = "E";
            messbox1.showMess();
            return null;
        }
    }

    protected void rgreporte_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            rgreporte.SelectedIndex = -1;
            rgreporte.PageIndex = e.NewPageIndex;
            rgreporte.DataSource = (DataTable)Cache["Repodt"];
            rgreporte.DataBind();
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

    protected void rgreporte_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            System.Threading.Thread.Sleep(1000);
            if (e.SortExpression == ViewState["Column_Name"].ToString())
            {
                if (ViewState["Sort_Order"].ToString() == "ASC")
                    RebindData(e.SortExpression, "DESC");
                else
                    RebindData(e.SortExpression, "ASC");
            }
            else
                RebindData(e.SortExpression, "DESC");
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

    private void RebindData(string sColimnName, string sSortOrder)
    {
        try
        {
            DataTable dt = (DataTable)Cache["Repodt"];
            dt.DefaultView.Sort = sColimnName + " " + sSortOrder;
            rgreporte.DataSource = dt;
            rgreporte.DataBind();
            ViewState["Column_Name"] = sColimnName;
            ViewState["Sort_Order"] = sSortOrder;
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

    protected void rgreportexls_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //e.Row.Attributes.Add("style", "vnd.ms-excel.numberformat:@"); //Para todo el documento
            e.Row.Cells[3].Attributes.Add("style", "vnd.ms-excel.numberformat:0"); //para columna especifica
            //vnd.ms-excel.numberformat:0 formato sin ceros
            //vnd.ms-excel.numberformat:0\\.00 formato con decimales
            //vnd.ms - excel.numberformat:@ formato texto

            e.Row.Cells[25].Attributes.Add("style", "vnd.ms-excel.numberformat:0");

            //decimal valor = Convert.ToDecimal(e.Row.Cells[42].Text); // Obtener el valor de la columna

            //string valorFormateado = valor.ToString(); // Realizar la transformación y formatear el número

            //valorFormateado = valorFormateado.Replace(".", ","); // Reemplazar el punto decimal por una coma

            //e.Row.Cells[42].Text = valorFormateado; // Asignar el valor formateado a la celda

            //decimal valor1 = Convert.ToDecimal(e.Row.Cells[44].Text); // Obtener el valor de la columna

            //string valorFormateado1 = valor1.ToString(); // Realizar la transformación y formatear el número

            //valorFormateado1 = valorFormateado1.Replace(".", ","); // Reemplazar el punto decimal por una coma

            //e.Row.Cells[44].Text = valorFormateado1; // Asignar el valor formateado a la celda

        }
    }

    protected void ibpdf1_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton button = (ImageButton)sender;
        FichaActivo fichaActivo = new FichaActivo(Server);
        try
        {
            string nombreArchivo = fichaActivo.F_CrearPdf(int.Parse(button.Attributes["value"]));
            Session["pdfFileName"] = nombreArchivo;
            abreVentana("VisualizaPDF.aspx?pdf=yes");
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

    private void abreVentana(string ventana)
    {
        string funcion = "OpenWindows('" + ventana + "')";
        string f = "windowOpener('" + ventana + "')";

        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "SIFEL", f, true);
    }
}
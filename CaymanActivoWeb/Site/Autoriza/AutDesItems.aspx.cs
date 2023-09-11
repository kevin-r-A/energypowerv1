using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Collections;
using System.Data;
using System.IO;
using System.Text;
using System.Web.Security;
using System.Web.UI.HtmlControls;


public partial class AutDesItems : System.Web.UI.Page
{
    ErrorTrapper errtrap;
    static ArrayList ArrayChecks = new ArrayList();

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

                btnActivarItem.Enabled = false;
                btnActivar0.Enabled = false;
                btnDesactiva.Enabled = false;
                btnDesactivaitem.Enabled = false;
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
        Session["query"] = "";

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


            DataTable dt = Logica.HELPER.getReporteAutorizadosRFID(query);

            if (dt.Rows.Count > 0)
            {
                btnActivar0.Enabled = true;
                btnDesactiva.Enabled = true;
            }

            Session["query"] = query;

            System.Threading.Thread.Sleep(10);

            rgreporte.DataSource = dt;
            rgreporte.DataBind();


            lblResumen.Text = "[ " + dt.Rows.Count.ToString() + " ] - Items Consultados";
            upgrid.Update();
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
                hk.NavigateUrl = "Modificar.aspx?id=" + e.Row.Cells[1].Text;
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
                rgreportexls.DataSource = setExport(dtxls);
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
                    if (row["Serie"].ToString().Contains("'"))
                        row["Serie"].ToString();
                    else
                        row["Serie"] = "'" + row["Serie"].ToString();

                if (row["CódigoBarras"].ToString().Length != 0)
                    if (row["CódigoBarras"].ToString().Contains("'"))
                        row["CódigoBarras"].ToString();
                    else
                        row["CódigoBarras"] = "'" + row["CódigoBarras"].ToString();

                if (row["CódigoBarrasPadre"].ToString().Length != 0)
                    if (row["CódigoBarrasPadre"].ToString().Contains("'"))
                        row["CódigoBarrasPadre"].ToString();
                    else
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
    protected void rblBuscar_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblBuscar.Items[0].Selected == true)
        { 
            panFiltros.Visible = false;
            upconsult.Visible = false;
            txtbuscb.Enabled = true;
            ibbus1.Enabled = true;
            rgreporte.DataSource = null;
            rgreporte.DataBind();
            btnActivarItem.Visible = true;
            btnDesactivaitem.Visible = true;

            Cache["Repodt"] = "";
            Cache["Repodtxls"] = "";

            lblResumen.Text = "[ 0 ] - Items Consultados";
            upres.Update();
        }
        else
        {
            btnActivarItem.Visible = false;
            btnDesactivaitem.Visible = false;
            ddtipoitem.Enabled = false;
            upFiltro.Update();
            panFiltros.Visible = true;
            upconsult.Visible = true;
            txtbuscb.Text = "";
            txtbuscb.Enabled = false;
            ibbus1.Enabled = false;
            reset();
            
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

    public void cargarActivo(string cb)
    {

        Logica.ACTIVO act = null;

        if (cb == "cb")
            act = new Logica.ACTIVO(txtbuscb.Text.Trim(), cb);

    }

    protected void ibbus1_Click(object sender, ImageClickEventArgs e)
    {
        try
        {

            if (codigoCorrecto())
            {
                if (Logica.HELPER.comprobarCbIngresado(txtbuscb.Text))
                {
                    //cargar datos
                    //panuevo.Visible = true;


                    DataTable dt = Logica.HELPER.getReporteAutorizadosRFID(" and ACT_CODBARRAS = '" + txtbuscb.Text.Trim() + "'");

                    System.Threading.Thread.Sleep(10);

                    rgreporte.DataSource = dt;
                    rgreporte.DataBind();


                    lblResumen.Text = "[ " + dt.Rows.Count.ToString() + " ] - Items Consultados";
                    upgrid.Update();
                    upres.Update();

                    Cache["Repodt"] = dt;
                    Cache["Repodtxls"] = dt;
                    ViewState["Column_Name"] = "ID";
                    ViewState["Sort_Order"] = "ASC";
                    btnActivarItem.Enabled = true;
                    btnDesactivaitem.Enabled = true;
                }
                else
                {
                    //panuevo.Visible = false;
                    messbox1.Mensaje = "Código Válido, pero aún no ha sido ingresado!";
                    messbox1.Tipo = "I";
                    messbox1.showMess();
                }
            }
            else
            {
                //panuevo.Visible = false;
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
  
    protected void chboxAutTodos_CheckedChanged(object sender, EventArgs e)
    {
       
        CheckBox chbox_cab = (CheckBox)(sender);

        if (chbox_cab.Checked)
        {

            foreach (GridViewRow gvr in rgreporte.Rows)
            {
                CheckBox chbox_item = (CheckBox)(gvr.FindControl("check_autoriza"));

                chbox_item.Checked = true;
            }
        }
        else
        {
            foreach (GridViewRow gvr in rgreporte.Rows)
            {
                CheckBox chbox_item = (CheckBox)(gvr.FindControl("check_autoriza"));

                chbox_item.Checked = false;
            }
        }
    }
    protected void rgreporte_PageIndexChanged(object sender, EventArgs e)
    {
        int cont = 0;
        
        for (int i = 0; i < ArrayChecks.Count; i++) //recorro array donde guardo todos los items marcados
        { 
            foreach (GridViewRow gvr in rgreporte.Rows) //recorro grilla 
            {
                CheckBox chbox_item = (CheckBox)(gvr.FindControl("check_autoriza"));

                if (ArrayChecks[i].ToString() == gvr.Cells[2].Text)//comparo si los items del array estan en la grilla, se mantienen marcados
                {
                    chbox_item.Checked = true;
                    cont++;
                }                
            }

            if (cont == 20 )//número de filas en el grid
            {
                CheckBox chbox_cab = (CheckBox)rgreporte.HeaderRow.FindControl("chboxAutTodos");
                chbox_cab.Checked = true;
            }
        }
    }
    protected void rgreporte_DataBound(object sender, EventArgs e)
    {
        foreach (GridViewRow gvr in rgreporte.Rows)
        {
            CheckBox chbox_item = (CheckBox)(gvr.FindControl("check_autoriza"));

            if (gvr.Cells[36].Text == "0")
            {
                chbox_item.Checked = false;
            }
            else
            {
                chbox_item.Checked = true;
            }
        }
    }
    protected void btnActivar_Click(object sender, EventArgs e)
    {

        if (verificaItemsSel())
        {

            string err = "";
            int conterr = 0;
            int contnoerr = 0;

            foreach (GridViewRow rw in rgreporte.Rows)
            {
                CheckBox check = rw.FindControl("check_autoriza") as CheckBox;
                if (check.Checked == true)
                {

                    err = Logica.HELPER.ActualizaAutorizacionRFID(rw.Cells[8].Text.Trim(), 1);
                    if (err != "")
                    {
                        conterr++;
                    }
                    else
                    {
                        contnoerr++;
                    }
                }
            }


            string msgerr = "";

            if (conterr > 0)
            {
                msgerr = ", " + contnoerr + " Items No Activados, comuniquese con el Administrador...!!!";
            }


            rgreporte.DataSource = null;
            rgreporte.DataBind();


            lblResumen.Text = "[0] - Items Consultados";
            upgrid.Update();
            upres.Update();

            txtbuscb.Text = "";

            messbox1.Mensaje = contnoerr + " Items Activados con Éxito" + msgerr;
            messbox1.Tipo = "S";
            messbox1.showMess();
        }
        else
        {
            messbox1.Mensaje = "Debe Seleccionar Items, corrijalo antes de continuar...!!!";
            messbox1.Tipo = "W";
            messbox1.showMess();
        }
    }
    protected void btnActivarItem_Click(object sender, EventArgs e)
    {
        if (verificaItemsSel())
        {

            string err = "";
            int conterr = 0;
            int contnoerr = 0;

            foreach (GridViewRow rw in rgreporte.Rows)
            {
                CheckBox check = rw.FindControl("check_autoriza") as CheckBox;
                if (check.Checked == true)
                {
                    err = Logica.HELPER.ActualizaAutorizacionRFID(rw.Cells[8].Text.Trim(), 1);

                    if (err != "")
                    {
                        conterr++;
                    }
                    else
                    {
                        contnoerr++;
                    }
                }
               
            }

            string msgerr = "";

            if (conterr > 0)
            {
                msgerr = ", " + contnoerr + " Items No Activados, comuniquese con el Administrador...!!!";
            }


            rgreporte.DataSource = null;
            rgreporte.DataBind();


            lblResumen.Text = "[0] - Items Consultados";
            upgrid.Update();
            upres.Update();

            txtbuscb.Text = "";

            messbox1.Mensaje = contnoerr + " Items Activados con Éxito" + msgerr;
            messbox1.Tipo = "S";
            messbox1.showMess();
        }
        else
        {
            messbox1.Mensaje = "Debe Seleccionar Items, corrijalo antes de continuar...!!!";
            messbox1.Tipo = "W";
            messbox1.showMess();
        }
    }


    private bool verificaItemsSel()
    {

        bool x = false;

        foreach (GridViewRow rw in rgreporte.Rows)
        {
            CheckBox check = rw.FindControl("check_autoriza") as CheckBox;
            if (check.Checked == true)
            {
                x = true;
                break;
            }
        }

        return x;
    }
    protected void btnDesactiva_Click(object sender, EventArgs e)
    {
        if (verificaItemsSel())
        {

            string err = "";
            int conterr = 0;
            int contnoerr = 0;

            foreach (GridViewRow rw in rgreporte.Rows)
            {
                CheckBox check = rw.FindControl("check_autoriza") as CheckBox;
                if (check.Checked == true)
                {

                    err = Logica.HELPER.ActualizaAutorizacionRFID(rw.Cells[8].Text.Trim(), 0);
                    if (err != "")
                    {
                        conterr++;
                    }
                    else
                    {
                        contnoerr++;
                    }
                }
            }


            string msgerr = "";

            if (conterr > 0)
            {
                msgerr = ", " + contnoerr + " Items No Activados, comuniquese con el Administrador...!!!";
            }


            rgreporte.DataSource = null;
            rgreporte.DataBind();


            lblResumen.Text = "[0] - Items Consultados";
            upgrid.Update();
            upres.Update();

            txtbuscb.Text = "";

            messbox1.Mensaje = contnoerr + " Items Activados con Éxito" + msgerr;
            messbox1.Tipo = "S";
            messbox1.showMess();
        }
        else
        {
            messbox1.Mensaje = "Debe Seleccionar Items, corrijalo antes de continuar...!!!";
            messbox1.Tipo = "W";
            messbox1.showMess();
        }
    }


    protected void btnDesactivaitem_Click(object sender, EventArgs e)
    {
        if (verificaItemsSel())
        {

            string err = "";
            int conterr = 0;
            int contnoerr = 0;

            foreach (GridViewRow rw in rgreporte.Rows)
            {
                CheckBox check = rw.FindControl("check_autoriza") as CheckBox;
                if (check.Checked == true)
                {
                    err = Logica.HELPER.ActualizaAutorizacionRFID(rw.Cells[8].Text.Trim(), 0);

                    if (err != "")
                    {
                        conterr++;
                    }
                    else
                    {
                        contnoerr++;
                    }
                }

            }

            string msgerr = "";

            if (conterr > 0)
            {
                msgerr = ", " + contnoerr + " Items No Activados, comuniquese con el Administrador...!!!";
            }


            rgreporte.DataSource = null;
            rgreporte.DataBind();


            lblResumen.Text = "[0] - Items Consultados";
            upgrid.Update();
            upres.Update();

            txtbuscb.Text = "";

            messbox1.Mensaje = contnoerr + " Items Activados con Éxito" + msgerr;
            messbox1.Tipo = "S";
            messbox1.showMess();
        }
        else
        {
            messbox1.Mensaje = "Debe Seleccionar Items, corrijalo antes de continuar...!!!";
            messbox1.Tipo = "W";
            messbox1.showMess();
        }
    }
}

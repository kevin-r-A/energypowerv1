using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class VisualizaPDF : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["pdf"] == "yes")
        {

            Response.ContentType = "application/pdf";

            Response.WriteFile(Session["pdfFileName"].ToString());
        }

        Session["pdfFileName"] = null;
    }

}
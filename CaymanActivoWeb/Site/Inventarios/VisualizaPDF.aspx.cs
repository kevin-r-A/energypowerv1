using System;

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
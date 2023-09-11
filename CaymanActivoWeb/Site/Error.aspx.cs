using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Configuration;

public partial class Error : System.Web.UI.Page
{
    ErrorTrapper errtrap;

    protected void Page_Load(object sender, EventArgs e)
    {
        lblerror.Text = Request["err"];

        if (!IsPostBack)
        {
            if (lblerror.Text != "")
            {
                errtrap = new ErrorTrapper();
                errtrap.SetOnError("Usuario:" + Membership.GetUser().UserName + "<< " + lblerror.Text, 0);
            }
        }
    }
}
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;

public partial class Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Redirect("./Site/Principal.aspx");
        SyncPpc obj = new SyncPpc();

        //obj.TimeTrashStr("1|80042000000011||20150420 01:00:00|20090101 02:42:28|IMP-RRH-001|1900|CDUY204095|2||0|1||0|XXXXXXX|Cayman|nofoto.gif|nofoto.gif|1|BUENO|6|EN USO|3||0|205||0|725||0|1||0|2||0|4||0|6||0|1||0|38||0|85||0|21|||0|31||0|126||0|1||0|0|M|8");
    }
}

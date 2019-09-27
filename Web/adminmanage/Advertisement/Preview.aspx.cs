using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class adminmanage_Advertisement_Preview : System.Web.UI.Page
{
    public int id = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdminManage();
        if (Request.QueryString["id"] != null)
        { id = Convert.ToInt32(Request.QueryString["id"]); }
    }
}

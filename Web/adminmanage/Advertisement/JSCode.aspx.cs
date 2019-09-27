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

public partial class adminmanage_Advertisement_JSCode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdminManage();
        if (Request.QueryString["id"] != null)
        {
            this.TextBox1.Text = "<script type=\"text/javascript\" src=\"" + Web.Model.PublicModel.XADJsFile + Request.QueryString["id"].ToString() + ".js\"></script>";
        }
    }
}

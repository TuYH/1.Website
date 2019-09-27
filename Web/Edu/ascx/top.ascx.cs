using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class edu_ascx_top : System.Web.UI.UserControl
{
    protected string Menuname = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdManage();

        Menuname = Session["AdminManage"].ToString();
    }
}
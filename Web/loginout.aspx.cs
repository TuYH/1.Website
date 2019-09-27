using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HXD.BLL;
using HXD.Model;
using HXD.Common;

public partial class loginout : System.Web.UI.Page
{
    protected string UserName;
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdminManage(null);
        UserName = Session["AdminManage"].ToString();
        Caches.RemoveCache("Admin_" + UserName);
        Session.Remove("AdminManage");
        Response.Write("<script>window.parent.location='Logine.aspx'</script>");
    }
}
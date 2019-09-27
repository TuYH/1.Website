using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using HXD.BLL;
using HXD.Model;
using HXD.Common;

public partial class adminmanage_Head : System.Web.UI.Page
{
    protected string UserName;
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdminManage(null);
        UserName = Session["AdminManage"].ToString();
        bChannel b = new bChannel();
        DBList.DataSource = b.GetChannelMenu(0, UserName)[0].Tables[0];
        DBList.DataBind();

        mAdmin mA = new mAdmin();
        bAdmin bA = new bAdmin();
        mA.UserName = UserName;
        if (!bA.GetAdminEditPwd(mA))
        {
            this.EditPwdId.Visible = false;
        }
    }
    /// <summary>
    /// 退出登陆
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void OutLoginBt_Click(object sender, EventArgs e)
    {
        Caches.RemoveCache("Admin_" + UserName);
        Session.Remove("AdminManage");
        Response.Write("<script>window.parent.location='Login.aspx'</script>");
    }
}

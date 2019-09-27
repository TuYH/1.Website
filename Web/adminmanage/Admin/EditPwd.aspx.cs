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
using HXD.Model;
using HXD.BLL;
using HXD.Common;

public partial class adminmanage_Admin_EditPwd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdminManage();
        if (IsPostBack)
        {
            mAdmin mA = new mAdmin();
            bAdmin bA = new bAdmin();
            mA.UserName = Session["AdminManage"].ToString();
            mA.UserPwd = Encryp.DESEncrypt(this.UserPwd.Text);
            if (bA.AdminPwdEdit(mA))
            {
                StringDeal.Alter("修改完成！");
            }
        }
    }
}

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

public partial class adminmanage_User_Inc_Validate_UserName : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        mUser mU = new mUser();
        bUser bU = new bUser();
        mU.UserName = Request["UserName"];
        if (bU.IsUserUserName(mU))
        {
            Response.Write("此用户名已存在！");
        }
    }
}

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
using System.Collections.Generic;
using HXD.Model;
using HXD.BLL;
using HXD.Common;

public partial class Adminmanage_User_User_manage : System.Web.UI.Page
{
    protected mUser mU = new mUser();
    protected bUser bU = new bUser();
    protected int Pages;
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdminManage();
        Pages = StringDeal.ToInt(Request.QueryString["Page"]);
        string Action = Request.QueryString["Action"];
        mU.Temp = Request.Params["Id"];
        mU.GroupId = StringDeal.ToInt(Request.QueryString["GroupId"]);
        this.InsertId.HRef = "User_Edit.aspx?GroupId=" + mU.GroupId;
        if (!IsPostBack)
        {
            if (Action == "del")
            {
                bU.UserDel(mU);
                Response.Redirect("User_Manage.aspx?GroupId=" + mU.GroupId + "&Page=" + Pages);
            }
            else if (Action == "lock")
            {
                mU.Id = StringDeal.ToInt(Request.QueryString["Id"]);
                if (bU.GetUserLock(mU))
                {
                    mU.IsLock = false;
                }
                else
                {
                    mU.IsLock = true;
                }
                bU.UserLock(mU);
                Response.Redirect("User_Manage.aspx?GroupId=" + mU.GroupId + "&Page=" + Pages);
            }
            mU.UserName = StringDeal.StrFormat(Request.QueryString["UserName"]);
            mU.Temp = StringDeal.StrFormat(Request.QueryString["IsLock"]);
            this.GroupTitle.Text = bU.GetUserGroupTitle(mU);
            UserBind();
        }
    }

    /// <summUry>
    /// 绑定用户列表
    /// </summUry>
    protected void UserBind()
    {
        SgqPage pg = new SgqPage();
        pg.PageIndex = Pages;
        pg.PageSize = 30;
        pg.dt = bU.UserList(mU).Tables[0];
        DBList.DataSource = pg.DataSource();
        DBList.DataBind();
        this.PageView.Text = pg.PageView1();
    }

    /// <summUry>
    /// 批量删除
    /// </summUry>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void DelBut_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(mU.Temp))
        {
            StringDeal.Alter("请选择要删除的对象！");
        }
        bU.UserDel(mU);
        Response.Redirect("User_Manage.aspx?GroupId=" + mU.GroupId + "&Page=" + Pages);
    }

    /// <summUry>
    /// 批量锁定
    /// </summUry>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LockBut_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(mU.Temp))
        {
            StringDeal.Alter("请选择要锁定的对象！");
        }
        mU.IsLock = true;
        bU.UserLock(mU);
        Response.Redirect("User_Manage.aspx?GroupId=" + mU.GroupId + "&Page=" + Pages);
    }

    /// <summUry>
    /// 批量解锁
    /// </summUry>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void unLockBut_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(mU.Temp))
        {
            StringDeal.Alter("请选择要解锁的对象！");
        }
        mU.IsLock = false;
        bU.UserLock(mU);
        Response.Redirect("User_Manage.aspx?GroupId=" + mU.GroupId + "&Page=" + Pages);
    }
}

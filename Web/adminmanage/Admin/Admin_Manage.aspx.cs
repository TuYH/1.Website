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

public partial class adminmanage_Admin_Admin_Manage : System.Web.UI.Page
{
    protected mAdmin mA = new mAdmin();
    protected bAdmin bA = new bAdmin();
    protected int Pages;
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdminManage();
        Pages = StringDeal.ToInt(Request.QueryString["Page"]);
        string Action = Request.QueryString["Action"];
        mA.Temp = Request.Params["Id"];
        if (Action == "del")
        {
            bA.AdminDel(mA);
            Response.Redirect("Admin_Manage.aspx?Page=" + Pages);
        }
        else if (Action == "lock")
        {
            mA.Id = StringDeal.ToInt(Request.QueryString["Id"]);
            if (bA.GetAdminLock(mA))
            {
                mA.IsLock = false;
            }
            else
            {
                mA.IsLock = true;
            }
            bA.AdminLock(mA);
            Response.Redirect("Admin_Manage.aspx?Page=" + Pages);
        }
        if (!IsPostBack)
        {
            AdminBind();
        }
    }

    /// <summary>
    /// 绑定管理员列表
    /// </summary>
    protected void AdminBind()
    {
        bAdmin bA = new bAdmin();
        SgqPage pg = new SgqPage();
        pg.PageIndex = Pages;
        pg.PageSize = 30;
        pg.dt = bA.AdminList().Tables[0];
        DBList.DataSource = pg.DataSource();
        DBList.DataBind();
        this.PageView.Text = pg.PageView1();
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void DelBut_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(mA.Temp))
        {
            StringDeal.Alter("请选择要删除的对象！");
        }
        bA.AdminDel(mA);
        Response.Redirect("Admin_Manage.aspx?Page=" + Pages);
    }

    /// <summary>
    /// 批量锁定
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LockBut_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(mA.Temp))
        {
            StringDeal.Alter("请选择要锁定的对象！");
        }
        mA.IsLock = true;
        bA.AdminLock(mA);
        Response.Redirect("Admin_Manage.aspx?Page=" + Pages);
    }

    /// <summary>
    /// 批量解锁
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void unLockBut_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(mA.Temp))
        {
            StringDeal.Alter("请选择要解锁的对象！");
        }
        mA.IsLock = false;
        bA.AdminLock(mA);
        Response.Redirect("Admin_Manage.aspx?Page=" + Pages);
    }
}

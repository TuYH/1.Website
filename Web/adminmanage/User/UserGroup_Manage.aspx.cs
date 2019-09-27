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

public partial class adminmanage_User_UserGroup_Manage : System.Web.UI.Page
{
    protected mUserGroup mUG = new mUserGroup();
    protected bUserGroup bUG = new bUserGroup();
    protected DataSet dsList;
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdminManage();
        string Action = Request.QueryString["Action"];
        mUG.Id = StringDeal.ToInt(Request.QueryString["Id"]);
        if (Action == "del")
        {
            bUG.UserGroupDel(mUG);
        }
        else if (Action == "lock")
        {
            bUG.UserGroupLock(mUG);
            Response.Redirect("UserGroup_Manage.aspx");
        }
        if (!IsPostBack)
        {
            mUG.ParentId = -1;
            dsList = (DataSet)bUG.UserGroupList(mUG);
        }
    }

    /// <summary>
    /// 后台频道列表
    /// </summary>
    protected void GetUserGroupList(int ParentId)
    {
        DataView dv = new DataView(dsList.Tables[0]);
        dv.RowFilter = "ParentId = " + ParentId;
        foreach (DataRowView dr in dv)
        {
            HttpContext.Current.Response.Write("<tr onMouseOver=\"over()\" onClick=\"change()\" onMouseOut=\"out()\" class=\"td_bg\">");
            HttpContext.Current.Response.Write("<td align=\"center\" nowrap=\"nowrap\">" + dr[0] + "</td>");
            HttpContext.Current.Response.Write("<td>");
            for (int i = 0; i < (int)dr[11]; i++)
            {
                HttpContext.Current.Response.Write("<img alt=\"\" src=\"../skin/01/ico/tree_treemiddle.gif\" width=\"18\" height=\"18\" align=\"absmiddle\">");
            }
            HttpContext.Current.Response.Write(bUG.GetUserGroupIsSub((int)dr[0]));
            HttpContext.Current.Response.Write(StringDeal.StrFormat(dr[2]) + "</td>");
            HttpContext.Current.Response.Write("<td align=\"center\">" + bUG.GetModelTitle(dr[4]) + "</td>");
            HttpContext.Current.Response.Write("<td align=\"center\">" + GetUserCount(dr[0]) + "</td>");
            HttpContext.Current.Response.Write("<td align=\"center\" nowrap=\"nowrap\">");
            HttpContext.Current.Response.Write(" <a href=\"User_Manage.aspx?GroupId="+dr[0]+"\">用户列表</a>");
            HttpContext.Current.Response.Write(" <a href=\"?Action=lock&Id=" + dr[0] + "\">" + StringDeal.GetLock(dr[10], "组") + "</a>");
            HttpContext.Current.Response.Write(" <a href=\"UserGroup_Edit.aspx?Id=" + dr[0] + "\">修改</a>");
            HttpContext.Current.Response.Write(" <a onClick=\"return confirm('确认删除')\" href=\"?Action=del&Id=" + dr[0] + "\">删除</a>");
            HttpContext.Current.Response.Write("</td></tr>");
            GetUserGroupList(StringDeal.ToInt(dr[0]));
        }
    }

    protected int GetUserCount(object GroupId)
    {
        bUser bU = new bUser();
        return bU.GetUserCount(StringDeal.ToInt(GroupId));
    }
}

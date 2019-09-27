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

public partial class adminmanage_Admin_AdminGroup_Manage : System.Web.UI.Page
{
    protected mAdminGroup mAG = new mAdminGroup();
    protected bAdminGroup bAG = new bAdminGroup();
    protected DataSet dsList;
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdminManage();
        string Action = Request.QueryString["Action"];
        mAG.Id = StringDeal.ToInt(Request.QueryString["Id"]);
        if (Action == "del")
        {
            bAG.AdminGroupDel(mAG);
        }
        else if (Action == "lock")
        {
            bAG.AdminGroupLock(mAG);
            Response.Redirect("AdminGroup_Manage.aspx");
        }
        if (!IsPostBack)
        {
            mAG.ParentId = -1;
            dsList = (DataSet)bAG.AdminGroupList(mAG);   
        }
    }

    /// <summary>
    /// 后台频道列表
    /// </summary>
    protected void GetAdminGroupList(int ParentId)
    {
        DataView dv = new DataView(dsList.Tables[0]);
        dv.RowFilter = "ParentId = " + ParentId;
        foreach (DataRowView dr in dv)
        {
            HttpContext.Current.Response.Write("<tr onMouseOver=\"over()\" onClick=\"change()\" onMouseOut=\"out()\" class=\"td_bg\">");
            HttpContext.Current.Response.Write("<td align=\"center\" nowrap=\"nowrap\">" + dr[0] + "</td>");
            HttpContext.Current.Response.Write("<td>");
            for (int i = 0; i < (int)dr[5]; i++)
            {
                HttpContext.Current.Response.Write("<img alt=\"\" src=\"../skin/01/ico/tree_treemiddle.gif\" width=\"18\" height=\"18\" align=\"absmiddle\">");
            }
            HttpContext.Current.Response.Write(bAG.GetAdminGroupIsSub((int)dr[0]));
            HttpContext.Current.Response.Write(StringDeal.StrFormat(dr[2]) + "</td>");
            HttpContext.Current.Response.Write("<td align=\"left\">" + StringDeal.StrFormat(dr[3]) + "</td>");
            HttpContext.Current.Response.Write("<td align=\"center\" nowrap=\"nowrap\">");
            HttpContext.Current.Response.Write(" <a href=\"?Action=lock&Id=" + dr[0] + "\">" + StringDeal.GetLock(dr[4], "组") + "</a>");
            HttpContext.Current.Response.Write(" <a href=\"AdminGroup_Edit.aspx?Id=" + dr[0] + "\">修改</a>");
            HttpContext.Current.Response.Write(" <a onClick=\"return confirm('确认删除')\" href=\"?Action=del&Id=" + dr[0] + "\">删除</a>");
            HttpContext.Current.Response.Write("</td></tr>");
            GetAdminGroupList(StringDeal.ToInt(dr[0]));
        }
    }
}

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

public partial class adminmanage_Channel_Channel_Manage : System.Web.UI.Page
{
    protected string List;
    protected DataSet dsList;
    protected bChannel bC = new bChannel();
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdminManage();
        AdminSetting.isPermissions("2", "5");
        string Action = Request.QueryString["Action"];
        int Id = StringDeal.ToInt(Request.QueryString["Id"]);
        if (Action == "del")
        {
            AdminSetting.isPermissions("2", "3");
            string Result = bC.ChannelDel(Id).ToString();
            if (Result == "1")
            {
                StringDeal.Alter("此频道下存在子频道，请先删除子频道！");
            }
        }
        else if (Action == "lock")
        {
            bC.ChannelLock(Id);
        }
        else if (Action == "down" || Action == "up")
        {
            bC.ChannelMove(Id, Action);
        }
        dsList = (DataSet)bC.ChannelList(-1);
    }

    /// <summary>
    /// 后台频道列表
    /// </summary>
    protected void GetChannelList(int ParentId)
    {
        DataView dv = new DataView(dsList.Tables[0]);
        dv.RowFilter = "ParentId = " + ParentId;
        foreach(DataRowView dr in dv)
        {
            HttpContext.Current.Response.Write("<tr onMouseOver=\"over()\" onClick=\"change()\" onMouseOut=\"out()\" class=\"td_bg\">");
            HttpContext.Current.Response.Write("<td align=\"center\" nowrap=\"nowrap\">" + dr[0] + "</td>");
            HttpContext.Current.Response.Write("<td>");
            for (int i = 0; i < (int)dr[5]; i++)
            {
                HttpContext.Current.Response.Write("<img alt=\"\" src=\"../skin/01/ico/tree_treemiddle.gif\" width=\"18\" height=\"18\" align=\"absmiddle\">");
            }
            HttpContext.Current.Response.Write(bC.GetChannelIsSub((int)dr[0]));
            HttpContext.Current.Response.Write(StringDeal.StrFormat(dr[2]) + "</td>");
            HttpContext.Current.Response.Write("<td align=\"left\">" + StringDeal.StrFormat(dr[3]) + "</td>");
            HttpContext.Current.Response.Write("<td align=\"center\" nowrap=\"nowrap\">");
            HttpContext.Current.Response.Write("<a href=\"?Action=up&Id=" + dr[0] + "\">上移</a>");
            HttpContext.Current.Response.Write(" <a href=\"?Action=down&Id=" + dr[0] + "\">下移</a>");
            HttpContext.Current.Response.Write(" <a href=\"?Action=lock&Id=" + dr[0] + "\">" + StringDeal.GetLock(dr[4], "频道") + "</a>");
            HttpContext.Current.Response.Write(" <a href=\"Channel_Edit.aspx?Id=" + dr[0] + "\">修改</a>");
            HttpContext.Current.Response.Write(" <a onClick=\"return confirm('确认删除')\" href=\"?Action=del&Id=" + dr[0] + "\">删除</a>");
            HttpContext.Current.Response.Write("</td></tr>");
            GetChannelList(StringDeal.ToInt(dr[0]));
        }
    }
}

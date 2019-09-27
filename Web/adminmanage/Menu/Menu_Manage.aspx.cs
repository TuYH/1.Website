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

public partial class adminmanage_Menu_Menu_Manage : System.Web.UI.Page
{
    protected int MenuId, Depth;
    protected string[] Arry;
    protected string MenuList,MenuTitle="栏目";
    protected DataSet dsList;
    protected mMenu mM = new mMenu();
    protected bMenu bM = new bMenu();
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdminManage();
        MenuId = StringDeal.ToInt(Request.QueryString["MenuId"]);
        if (MenuId == 0)
        {
            MenuTitle = "节点";
        }
        else
        {
            MenuTitle = bM.GetMenuTitle(MenuId);
        }
        mM.Temp = "Menu_List";
        Arry = bM.GetMenuField(mM, MenuId).Split('|');
        if (!Page.IsPostBack)
        {
            Operation();
            dsList = bM.MenuList();
            MenuListTitleBind();
            MenuListBind(MenuId,"");
            this.MenuListLabel.Text = MenuList;
        }
    }

    #region 栏目列表标题遍历
    /// <summary>
    /// 栏目列表标题遍历
    /// </summary>
    protected void MenuListTitleBind()
    {
        int i = 4;
        if (MenuId > 0)
        {
            i = Arry.Length+2;
        }
        MenuList = "<tr>\n";
        MenuList += "<td colspan=\"" + i + "\" class=\"redbold\">" + MenuTitle + "列表</td>\n";
        MenuList += "</tr>\n";
        MenuList += "<tr onMouseOver=\"over()\" onClick=\"change()\" onMouseOut=\"out()\" class=\"td_bg\">\n";
        MenuList += "<th width=\"10%\" align=\"center\">序号</th>\n";
        if (MenuId == 0)
        {
            MenuList += "<th>栏目名称</th>\n";
            MenuList += "<th width=\"15%\" align=\"center\" nowrap=\"nowrap\">模型设置</th>";
        }
        else if (String.IsNullOrEmpty(Arry[0]))
        {
            MenuList += "<th >栏目名称</th>\n";
        }
        else
        {
            foreach (string x in Arry)
            {
                string width="";
                if (StringDeal.ToInt(x.Split(',')[2]) > 0)
                {
                    width = " width='"+ x.Split(',')[2] +"%'";
                }
                
                MenuList += "<th" + width + ">" + StringDeal.StrFormat(x.Split(',')[1]) + "</th>\n";
            }
        }
        MenuList += "<th width=\"20%\" align=\"center\">操作</th>\n";
        MenuList += "</tr>\n";
    }
    #endregion

    #region 栏目列表信息遍历
    /// <summary>
    /// 栏目列表信息遍历
    /// </summary>
    /// <param name="ParentId"></param>
    /// <param name="Line"></param>
    protected void MenuListBind(int ParentId,string Line)
    {
        DataView dv = new DataView(dsList.Tables[0]);
        dv.RowFilter = "ParentId = " + ParentId;
        foreach (DataRowView dr in dv)
        {
            MenuList += "<tr onMouseOver=\"over()\" onClick=\"change()\" onMouseOut=\"out()\" class=\"td_bg\">\n";
            MenuList += "<td align=\"center\">" + dr[0] + "</td>\n";
            foreach(string j in GetField())
            {
                MenuList += "<td>";
                if (Getnext(Convert.ToInt32(dr[0])))
                {
                    MenuList += "<a href='../Model/Model_Manage.aspx?MenuId=" + dr[0] + "'>";
                }
                if (j == "Title")
                {
                    MenuList += Line + bM.GetMenuIsSub((int)dr[0]);
                }
                MenuList += StringDeal.StrFormat(dr[j]);
                if (Getnext(Convert.ToInt32(dr[0])))
                {
                    MenuList += "</a>";
                }
                MenuList += "</td>\n";
            }
            if (MenuId == 0)
            {
                MenuList += "<td align=\"center\" nowrap=\"nowrap\"><a href=\"MenuModel_Set.aspx?Id=" + dr[0] + "\" title=\"设置此栏目以及下属栏目的所需要字段\">栏目</a> <a href=\"Model_Set.aspx?Id=" + dr[0] + "\" title=\"设置此栏目以及下属栏目信息的所需要字段\">信息</a></td>";
            }
            MenuList += "<td align=\"center\" nowrap=\"nowrap\">";
            MenuList += "<a href=\"?MenuId=" + MenuId + "&Action=up&Id=" + dr[0] + "\">上移</a>";
            MenuList += " <a href=\"?MenuId=" + MenuId + "&Action=down&Id=" + dr[0] + "\">下移</a>";
            MenuList += " <a href=\"?MenuId=" + MenuId + "&Action=top&Id=" + dr[0] + "\">" + StringDeal.GetTop(StringDeal.ToBool(dr["IsTop"]), "栏目") + "</a>";
            MenuList += " <a href=\"?MenuId=" + MenuId + "&Action=lock&Id=" + dr[0] + "\">" + StringDeal.GetLock(StringDeal.ToBool(dr["IsLock"]), "栏目") + "</a>";
            MenuList += " <a href=\"Menu_Edit.aspx?MenuId="+MenuId+"&Id=" + dr[0] + "\">修改</a>";
            MenuList += " <a onClick=\"return confirm('确认删除')\" href=\"?MenuId=" + MenuId + "&Action=del&Id=" + dr[0] + "\">删除</a>";
            MenuList += "</td>\n</tr>\n";
            MenuListBind(StringDeal.ToInt(dr[0]), "<img alt=\"\" src=\"../skin/01/ico/tree_treemiddle.gif\" width=\"18\" height=\"18\" align=\"absmiddle\">" + Line);
        }
        Depth++;
    }
    #endregion

    #region 对栏目的操作（删除，锁定，置顶，排序）
    /// <summary>
    /// 对栏目的操作（删除，锁定，置顶，排序）
    /// </summary>
    protected void Operation()
    {
        mM.Id = StringDeal.ToInt(Request.QueryString["Id"]);
        if (mM.Id > 0)
        {
            string Action = Request.QueryString["Action"];
            if (Action == "del")
            {
                string Result = bM.MenuDel(mM).ToString();
                if (Result == "1")
                {
                    StringDeal.Alter("此栏目下存在子栏目，请先删除子栏目！");
                }
            }
            else if (Action == "lock")
            {
                bM.MenuLock(mM);
            }
            else if (Action == "top")
            {
                bM.MenuTop(mM);
            }
            else if (Action == "down" || Action == "up")
            {
                bM.MenuMove(mM, Action);
            }
            Response.Redirect("Menu_Manage.aspx?MenuId=" + MenuId + "", true);
        }
    }
    #endregion

    #region 获取列表字段名数组
    /// <summary>
    /// 获取列表字段名数组
    /// </summary>
    protected string[] GetField()
    {
        mMenuField mMF = new mMenuField();
        bMenuField bMF = new bMenuField();
        if (MenuId == 0 || String.IsNullOrEmpty(Arry[0]))
        {
            return "Title".Split(',');
        }
        else
        {
            string Field = "";
            foreach (string x in Arry)
            {
                mMF.Temp += x.Split(',')[0] + ",";
            }
            mMF.Temp = mMF.Temp.Trim(',');
            DataSet ds = bMF.MenuFieldList(mMF);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Field += ds.Tables[0].Rows[i][1].ToString() + ",";
            }
            return Field.Trim(',').Split(',');
        }
    }
    #endregion

    #region 判断是否有下级
    public bool Getnext(int cid)
    {
        DataView dv = new DataView(dsList.Tables[0]);
        dv.RowFilter = "ParentId = " + cid;
        if (dv.Count > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    #endregion
}

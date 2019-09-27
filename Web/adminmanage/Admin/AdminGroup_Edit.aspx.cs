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

public partial class adminmanage_Admin_AdminGroup_Edit : System.Web.UI.Page
{
    protected DataSet ag_dsList, c_dsList, t_dsList;
    protected bChannel bC = new bChannel();
    protected mAdminGroup mAG = new mAdminGroup();
    protected bAdminGroup bAG = new bAdminGroup();
    protected bSetType bST = new bSetType();
    protected mSetType mST = new mSetType();
    protected string GroupSetting, OtherSetting;
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdminManage();
        mAG.Id = StringDeal.ToInt(Request.QueryString["Id"]);
        mST.ParentId = 1;
        t_dsList = (DataSet)bST.GetSetTypeList(mST);
        if (!IsPostBack)
        {
            mAG.ParentId = -1;
            ag_dsList = (DataSet)bAG.AdminGroupList(mAG);
            c_dsList = (DataSet)bC.ChannelList(-1);
            AdminGroupBind(0, "┣");
            AdminGroupReader();
        }
        else
        {
            AdminGroupSave();
        }
    }

    /// <summary>
    /// 读取当前管理组信息
    /// </summary>
    protected void AdminGroupReader()
    {
        if (mAG.Id > 0)
        {
            IList<mAdminGroup> list = bAG.AdminGroupReader(mAG);
            this.Title.Text = list[0].Title;
            this.ParentId.SelectedValue = list[0].ParentId.ToString();
            this.Note.Text = list[0].Note;
            GroupSetting = list[0].GroupSetting;
            OtherSetting = list[0].OtherSetting;

        }
    }

    /// <summary>
    /// 保存频道修改/添加
    /// </summary>
    protected void AdminGroupSave()
    {
        mAG.Title = this.Title.Text;
        mAG.ParentId = StringDeal.ToInt(this.ParentId.Text);
        mAG.Note = this.Note.Text;
        mAG.GroupSetting = StringDeal.StrFormat(Request.Form["GroupSetting"]);
        mAG.OtherSetting = StringDeal.StrFormat(GetOtherValue(mAG.GroupSetting));
        if (mAG.Id > 0)
        {
            if (bAG.AdminGroupUpdate(mAG) == 1)
            {
                StringDeal.Alter("父级组不能为其本身！");
            }
        }
        else
        {
            bAG.AdminGroupInsert(mAG);
        }
        StringDeal.Alter("保存完成！", "AdminGroup_Manage.aspx");
    }

    /// <summary>
    /// 管理组绑定
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="Separator"></param>
    protected void AdminGroupBind(int Id, string Separator)
    {
        DataView dv = new DataView(ag_dsList.Tables[0]);
        dv.RowFilter = "ParentId = " + Id;
        foreach (DataRowView dr in dv)
        {
            ListItem li = new ListItem();
            li.Text = Separator + StringDeal.StrFormat(dr[2]);
            li.Value = dr[0].ToString();
            this.ParentId.Items.Add(li);
            AdminGroupBind(StringDeal.ToInt(dr[0]), "┃" + Separator);
        }
    }

    /// <summary>
    /// 频道绑定
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="Separator"></param>
    protected void ChannelBind(int Id, string Separator)
    {
        DataView dv = new DataView(c_dsList.Tables[0]);
        dv.RowFilter = "ParentId = " + Id;
        int item = 1;
        foreach (DataRowView dr in dv)
        {
            Response.Write(Separator);
            Response.Write("<img src=\"../skin/01/ico/tree_minusmiddle.gif\" width=\"18\" height=\"18\" align=\"absmiddle\" />");
            Response.Write("<input type=\"checkbox\" name=\"GroupSetting\" onclick=\"GroupChecked('" + "SetId_" + Id + "_" + item + "'," + dr[0] + ")\" id=\"SetId_" + Id + "_" + item + "\" value=\"" + dr[0].ToString() + "\"");
            if (!String.IsNullOrEmpty(GroupSetting))
            {
                string[] Ary = GroupSetting.Split(',');
                foreach (string k in Ary)
                {
                    if (k.ToString() == dr[0].ToString())
                    {
                        Response.Write(" checked");
                    }
                }
            }
            Response.Write(" />" + dr[2]);
            Response.Write("　　<span id=\"checkid_" + dr[0] + "\">" + GetOther(dr[0], dr[6]) + "</span>\r\n");
            Response.Write("<br />");
            ChannelBind(StringDeal.ToInt(dr[0]), "<img src=\"../skin/01/ico/tree_treemiddle.gif\" width=\"18\" height=\"18\" align=\"absmiddle\" />" + Separator);
            item++;
        }
    }

    /// <summary>
    /// 操作权限
    /// </summary>
    /// <param name="id"></param>
    /// <param name="obj"></param>
    /// <param name="val"></param>
    /// <returns></returns>
    private string GetOther(object id, object obj)
    {
        string temp = "";
        string Id = obj.ToString();
        if (Id.Length == 0)
        {
            Id = "0";
        }
        DataView dv = new DataView(t_dsList.Tables[0]);
        foreach (DataRowView dr in dv)
        {
            string[] Arry = Id.Split(',');
            for (int i = 0; i < Arry.Length; i++)
            {
                if (Arry[i].ToString() == dr[2].ToString())
                {
                    temp += "<input type=\"checkbox\" name=\"OtherSetting_" + dr[2] + "_" + id + "\" id=\"OtherSetting_" + dr[2] + "_" + id + "\" value=\"" + dr[2] + "\"";
                    temp += GetOtherChecked(Arry[i].ToString(), id);
                    temp += " /><label for=\"OtherSetting_" + dr[2] + "_" + id + "\">" + dr[1] + "</label>";
                }
            }
        }
        return temp;
    }

    /// <summary>
    /// 获取权限操作checked
    /// </summary>
    /// <param name="checkd">当前操作ID</param>
    /// <param name="id">当前权限组ID</param>
    /// <returns></returns>
    private string GetOtherChecked(string checkd,object id)
    {
        string Results = "";
        try
        {
            string[] Arry_g = GroupSetting.Split(',');
            string[] Arry_o = OtherSetting.Split(',');
            string Arry = "";
            for (int x = 0; x < Arry_g.Length; x++)
            {
                if (Arry_g[x] == id.ToString())
                {
                    Arry = Arry_o[x];
                }
            }
            foreach (string y in Arry.Split('|'))
            {
                if (checkd == y)
                {
                    Results = " checked=\"checked\"";
                }
            }
        }
        catch { }
        return Results;
    }

    /// <summary>
    /// 获取操作权限值
    /// </summary>
    /// <returns></returns>
    private string GetOtherValue(string GroupId)
    {
        DataView dv = new DataView(t_dsList.Tables[0]);
        string Form, FormValue = "";
        foreach (string x in GroupId.Split(','))
        {
            FormValue += ",";
            foreach (DataRowView dr in dv)
            {
                Form = "OtherSetting_" + dr[2] + "_" + x;
                if (!String.IsNullOrEmpty(Request.Form[Form]))
                {
                    FormValue += "|" + Request.Form[Form];
                }
            }
        }
        FormValue = FormValue.Substring(1, FormValue.Length - 1);
        return FormValue;
    }
}

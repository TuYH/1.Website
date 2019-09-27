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

public partial class adminmanage_User_UserGroup_Edit : System.Web.UI.Page
{
    protected DataSet ug_dsList;
    protected mUserGroup mUG = new mUserGroup();
    protected bUserGroup bUG = new bUserGroup();
    protected string GroupSetting;
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdminManage();
        mUG.Id = StringDeal.ToInt(Request.QueryString["Id"]);
        if (!IsPostBack)
        {
            mUG.ParentId = -1;
            ug_dsList = (DataSet)bUG.UserGroupList(mUG);
            UserGroupBind(0, "┣");
            ModelBind();
            UserGroupReader();
        }
        else
        {
            UserGroupSave();
        }
    }

    /// <summary>
    /// 读取当前管理组信息
    /// </summary>
    protected void UserGroupReader()
    {
        if (mUG.Id > 0)
        {
            
            IList<mUserGroup> list = bUG.UserGroupReader(mUG);
            this.Title.Text = list[0].Title;
            this.ParentId.SelectedValue = list[0].ParentId.ToString();
            this.Note.Text = list[0].Note;
            this.Model.SelectedValue = list[0].Model.ToString();
            this.RegIntegral.Text = list[0].RegIntegral.ToString();
            this.LoginIntegral.Text = list[0].LoginIntegral.ToString();
            this.Collection.Text = list[0].Collection.ToString();
            this.Invite.Text = list[0].Invite.ToString();
            this.RegState.SelectedValue = StringDeal.BoolToInt(list[0].RegState).ToString();
            GroupSetting = list[0].GroupSetting;
        }
    }

    /// <summary>
    /// 保存频道修改/添加
    /// </summary>
    protected void UserGroupSave()
    {
        mUG.Title = this.Title.Text;
        mUG.ParentId = StringDeal.ToInt(this.ParentId.Text);
        mUG.Note = this.Note.Text;
        mUG.Model = StringDeal.ToInt(this.Model.Text);
        mUG.RegIntegral = StringDeal.ToInt(this.RegIntegral.Text);
        mUG.LoginIntegral = StringDeal.ToInt(this.LoginIntegral.Text);
        mUG.Collection = StringDeal.ToInt(this.Collection.Text);
        mUG.Invite = StringDeal.ToInt(this.Invite.Text);
        mUG.RegState = StringDeal.ToBool(this.RegState.Text);
        mUG.GroupSetting = StringDeal.StrFormat(Request.Form["GroupSetting"]);
        if (mUG.Id > 0)
        {
            if (bUG.UserGroupUpdate(mUG) == 1)
            {
                StringDeal.Alter("父级用户组不能为其本身！");
            }
        }
        else
        {
            bUG.UserGroupInsert(mUG);
        }
        StringDeal.Alter("保存完成！", "UserGroup_Manage.aspx");
    }

    /// <summary>
    /// 用户组绑定
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="Separator"></param>
    protected void UserGroupBind(int Id, string Separator)
    {
        DataView dv = new DataView(ug_dsList.Tables[0]);
        dv.RowFilter = "ParentId = " + Id;
        foreach (DataRowView dr in dv)
        {
            ListItem li = new ListItem();
            li.Text = Separator + StringDeal.StrFormat(dr[2]);
            li.Value = dr[0].ToString();
            this.ParentId.Items.Add(li);
            UserGroupBind(StringDeal.ToInt(dr[0]), "┃" + Separator);
        }
    }

    /// <summary>
    /// 模型绑定
    /// </summary>
    protected void ModelBind()
    {
        bTable bT = new bTable();
        DataSet ds = bT.TableList();
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li = new ListItem();
            li.Text = StringDeal.StrFormat(ds.Tables[0].Rows[i][1]);
            li.Value = StringDeal.StrFormat(ds.Tables[0].Rows[i][0]);
            this.Model.Items.Add(li);
        }
    }
}

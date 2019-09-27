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

public partial class adminmanage_Admin_Admin_Edit : System.Web.UI.Page
{
    protected mAdmin mA = new mAdmin();
    protected bAdmin bA = new bAdmin();
    protected bAdminGroup bAG = new bAdminGroup();
    protected mAdminGroup mAG = new mAdminGroup();
    protected DataSet ag_dsList;
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdminManage();
        mA.Id = StringDeal.ToInt(Request.QueryString["Id"]);
        if (!IsPostBack)
        {
            mAG.ParentId = -1;
            ag_dsList = (DataSet)bAG.AdminGroupList(mAG);
            AdminGroupBind(0, "┣");
            this.IsModifyPassword.SelectedIndex = 0;
            this.IsMultiLogin.SelectedIndex = 0;
            AdminReader();
        }
        else
        {
            AdminSave();
        }
    }

    /// <summary>
    /// 保存管理员信息
    /// </summary>
    protected void AdminSave()
    {
        mA.GroupId = StringDeal.ToInt(this.GroupId.Text);
        mA.UserName = this.UserName.Text;
        mA.UserPwd = Encryp.DESEncrypt(this.UserPwd.Text);
        mA.TrueName = this.TrueName.Text;
        mA.Tel = this.Tel.Text;
        mA.Email = this.Email.Text;
        mA.IsModifyPassword = StringDeal.ToBool(this.IsModifyPassword.Text);
        mA.IsMultiLogin = StringDeal.ToBool(this.IsMultiLogin.Text);
        if (mA.Id == 0)
        {
            bA.AdminInsert(mA);
        }
        else
        {
           bA.AdminUpdate(mA);
        }
        StringDeal.Alter("保存完成！","Admin_Manage.aspx");
    }

    /// <summary>
    /// 读取单条管理员信息
    /// </summary>
    protected void AdminReader()
    {
        if (mA.Id > 0)
        {
            IList<mAdmin> list = bA.AdminReader(mA);
            this.GroupId.SelectedValue = list[0].GroupId.ToString();
            this.UserName.Text = list[0].UserName;
            this.UserName.Attributes.Add("class", "input1");
            this.UserName.Attributes.Add("readonly", "readonly");
            this.UserPwd.Attributes.Add("value", Encryp.DESDecrypt(list[0].UserPwd));
            this.UserPwd1.Attributes.Add("value", Encryp.DESDecrypt(list[0].UserPwd));
            this.TrueName.Text = list[0].TrueName;
            this.Tel.Text = list[0].Tel;
            this.Email.Text = list[0].Email;
            this.IsModifyPassword.SelectedValue = list[0].IsModifyPassword.ToString();
            this.IsMultiLogin.SelectedValue = list[0].IsMultiLogin.ToString();
        }
        else
        {
            this.UserName.Attributes.Add("class", "input1 required validate-length-range-4-20 validate-ajax-Inc/Validate_UserName.aspx");
        }
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
            this.GroupId.Items.Add(li);
            AdminGroupBind(StringDeal.ToInt(dr[0]), "┃" + Separator);
        }
    }
}

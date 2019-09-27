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

public partial class adminmanage_Channel_Channel_Edit : System.Web.UI.Page
{
    protected DataSet dsList;
    protected mChannel mC = new mChannel();
    protected bChannel bC = new bChannel();
    protected DataSet dsReader;
    protected mMenu mM = new mMenu();
    protected bMenu bM = new bMenu();
    protected int MenuId=0;
    protected DataSet menuListDataSet;
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdminManage();
        mC.Id = StringDeal.ToInt(Request.QueryString["Id"]);
        if (mC.Id == 0)
        { AdminSetting.isPermissions("2", "1"); }
        else
        { AdminSetting.isPermissions("2", "2"); }
        mM.Id = 0;
        mM.ParentId = 0;
        mM.Temp = "Menu_Field";
        if (!IsPostBack)
        {
            menuListDataSet = (DataSet)bM.MenuList();//说明
            dsReader = bM.MenuReader(mM);//说明
            BindMenuParent(0, "┣");//说明
            bSetType bST = new bSetType();//说明
            mSetType mST = new mSetType();//说明
            dsList = (DataSet)bC.ChannelList(-1);//说明
            BindClass(0, "┣");
            mST.ParentId = 1;
            Setting.DataSource = bST.GetSetTypeList(mST).Tables[0];
            Setting.DataTextField = "Title";
            Setting.DataValueField = "Value";
            Setting.DataBind();
            ChannelRead();
        }
        else
        {
            //ChannelSave();
        }
    }


    #region 节点栏目绑定
    /// <summary>
    /// 节点栏目绑定
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="Separator"></param>
    protected void BindMenuParent(int Id, string Separator)
    {
        DataView dv = new DataView(menuListDataSet.Tables[0]);
        dv.RowFilter = "ParentId = " + Id + " And Id <> " + mM.Id;
        //Response.Write(dv.RowFilter.Length.ToString());
        foreach (DataRowView dr in dv)
        {
            ListItem li = new ListItem();
            li.Text = Separator + StringDeal.StrFormat(dr["Title"]);
            li.Value = dr["Id"].ToString();
            this.MenuList.Items.Add(li);
            BindMenuParent(StringDeal.ToInt(dr[0]), "┃" + Separator);
        }
        this.MenuList.Items[0].Value = MenuId.ToString();
        //this.MenuList.SelectedValue = MenuReader("ParentId");
    }
    #endregion

    #region 根据字段名称读取要修改的信息
    /// <summary>
    /// 根据字段名称读取要修改的信息
    /// </summary>
    //protected string MenuReader(string Field)
    //{
    //    string value = "";
    //    if (!String.IsNullOrEmpty(Field))
    //    {
    //        if (dsReader.Tables[0].Rows.Count > 0)
    //        {

    //            value = dsReader.Tables[0].Rows[0][Field].ToString();
    //        }
    //    }
    //    return value;
    //}
    #endregion
    
    /// <summary>
    /// 读取要修改的频道信息
    /// </summary>
    protected void ChannelRead()
    {
        if (mC.Id > 0)
        {
            IList<mChannel> list = bC.ChannelRead(mC);
            this.Title.Text = list[0].Title;
            this.Url.Text = list[0].Url;
            this.Target.SelectedValue = list[0].Target;
            this.Note.Text = list[0].Note;
            this.ParentId.SelectedValue = list[0].ParentId.ToString();
            string[] Arry = list[0].Setting.Split(',');
            for(int i=0;i<Arry.Length;i++)
            {
                for (int j = 0; j < this.Setting.Items.Count; j++)
                {
                    if (this.Setting.Items[j].Value == Arry[i])
                    {
                        this.Setting.Items[j].Selected = true;
                    }
                }
            }
        }
    }

    /// <summary>
    /// 保存频道修改/添加
    /// </summary>
    protected void ChannelSave(object sender, EventArgs e)
    {
        mC.Title = this.Title.Text;
        mC.Url = this.Url.Text;
        mC.Target = this.Target.Text;
        mC.Note = this.Note.Text;
        mC.ParentId = StringDeal.ToInt(this.ParentId.Text);
        for (int s = 0; s < this.Setting.Items.Count; s++)
        {
            if (this.Setting.Items[s].Selected)
            {
                mC.Setting += this.Setting.Items[s].Value + ",";
            }
        }
        if (!String.IsNullOrEmpty(mC.Setting))
        {
            mC.Setting = mC.Setting.Trim(',');
        }
        else
        {
            mC.Setting = "";
        }
        if (mC.Id > 0)
        {
            if (bC.ChannelUpdate(mC) == 1)
            {
                StringDeal.Alter("父级菜单不能是其本身！");
            }
        }
        else
        {
            bC.ChannelInsert(mC);
        }
        StringDeal.Alter("保存完成！", "Channel_Manage.aspx");
    }

    /// <summary>
    /// 频道类别绑定
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="Separator"></param>
    protected void BindClass(int Id, string Separator)
    {
        DataView dv = new DataView(dsList.Tables[0]);
        dv.RowFilter = "ParentId = " + Id;
        foreach (DataRowView dr in dv)
        {
            ListItem li = new ListItem();
            li.Text = Separator + StringDeal.StrFormat(dr[2]);
            li.Value = dr[0].ToString();
            this.ParentId.Items.Add(li);
            BindClass(StringDeal.ToInt(dr[0]), "┃" + Separator); 
        }
    }


    protected void PageType_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (this.PageType.SelectedValue)
        {
            case "1":
                this.Url.Text = "Menu/Menu_Edit.aspx?Action=info&MenuId={MenuId}&Id={Id}";
                break;
            case "2":
                this.Url.Text = "Model/Model_Manage.aspx?MenuId={MenuId}";
                break;
            case "3":
                this.Url.Text = "Menu/Menu_Manage.aspx?MenuId={MenuId}";
                break;
            default:
                this.Url.Text = "javascript:void(null);";
                break;
        }
        this.MenuList.SelectedValue = "0";
    }
    protected void MenuList_SelectedIndexChanged(object sender, EventArgs e)
    {
        int MenuId = HXD.Common.StringDeal.ToInt(this.MenuList.SelectedValue);
        HXD.BLL.bMenu bll = new bMenu();
        int PId = bll.GetParentId(MenuId);

        switch (this.PageType.SelectedValue)
        {
            case "1":
                this.Url.Text = this.Url.Text.Replace("{MenuId}", PId.ToString()).Replace("{Id}",MenuId.ToString());
                break;
            case "2":
                this.Url.Text = this.Url.Text.Replace("{MenuId}", MenuId.ToString());
                break;
            case "3":
                this.Url.Text = this.Url.Text.Replace("{MenuId}", MenuId.ToString());
                break;
            default:
                this.Url.Text = "javascript:void(null);";
                break;
        }
    }
}

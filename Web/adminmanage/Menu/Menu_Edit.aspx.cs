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

public partial class adminmanage_Menu_Menu_Edit : System.Web.UI.Page
{
    protected DataSet dsList;
    protected DataSet dsReader;
    protected mMenu mM = new mMenu();
    protected bMenu bM = new bMenu();
    protected mMenuField mMF = new mMenuField();
    protected bMenuField bMF = new bMenuField();
    protected string[] Arry;
    protected int MenuId;
    protected string MenuTitle="栏目", Action;
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdminManage();
        MenuId = StringDeal.ToInt(Request.QueryString["MenuId"]);
        Action = Request.QueryString["Action"];
        mM.Id = StringDeal.ToInt(Request.QueryString["Id"]);
        mM.ParentId = StringDeal.ToInt(this.ParentId.Text);
        mM.Temp = "Menu_Field";
        Arry = bM.GetMenuField(mM,MenuId).Split('|');
        if (!IsPostBack)
        {
            //绑定模板和模板文件
            if (MenuId == 0)
            {
                MenuTitle = "节点";
            }
            else if (Action=="info")
            {
                MenuTitle = bM.GetMenuTitle(mM.Id);
            }
            if (Action == "info")
            {
                this.MenuTableId.Visible = false;
                this.ListLinkId.Visible = false;
            }
            #region 2010-05-25 mjh

            bSetType bST = new bSetType();
            mSetType mST = new mSetType();
            mST.ParentId = 1;
            Setting.DataSource = bST.GetSetTypeList(mST).Tables[0];
            Setting.DataTextField = "Title";
            Setting.DataValueField = "Value";
            Setting.DataBind();
            if (mM.Id != 0)
            {
                DataSet ds = bM.MenuReader(mM);
                if (ds.Tables[0].Rows.Count > 0)
                {
                   
                    string[] Arry2 = ds.Tables[0].Rows[0]["Sitting"].ToString().Split(',');
                    for (int i = 0; i < Arry2.Length; i++)
                    {
                        //Response.Write(i.ToString());
                        for (int j = 0; j < this.Setting.Items.Count; j++)
                        {
                            if (this.Setting.Items[j].Value == Arry2[i])
                            {
                                this.Setting.Items[j].Selected = true;
                                
                            }
                        }
                    }
                }
               
            }
            #endregion
            dsList = (DataSet)bM.MenuList();
            dsReader = bM.MenuReader(mM);
            BindMenuParent(MenuId, "┣");
            BindModel();
            MenuBind();
        }
        else
        {
            //MenuSave();
        }
    }

    #region 栏目模型绑定（获取栏目所需字段）
    /// <summary>
    /// 栏目模型绑定（获取栏目所需字段）
    /// </summary>
    protected void MenuBind()
    {
        GetFiledId();
        DataSet ds = bMF.MenuFieldList(mMF);//获取此栏目的模型字段
        DBList.DataSource = ds;
        DBList.DataBind();
    }
    #endregion

    #region 根据字段名称读取要修改的信息
    /// <summary>
    /// 根据字段名称读取要修改的信息
    /// </summary>
    protected string MenuReader(string Field)
    {
        string value = "";
        if (!String.IsNullOrEmpty(Field))
        {
            if(dsReader.Tables[0].Rows.Count>0)
            {
               
                value = dsReader.Tables[0].Rows[0][Field].ToString();
            }
        }
        return value;
    }
    #endregion

    #region 保存栏目信息
    /// <summary>
    /// 保存栏目信息
    /// </summary>
    protected void MenuSave(object sender,  EventArgs e )
    {
        GetFiledId();
        string Field = "Model,", Val = this.Model.SelectedValue + "{$split$}";
        DataSet ds = bMF.MenuFieldList(mMF);//获取此栏目的模型字段
        for(int i=0;i<ds.Tables[0].Rows.Count;i++)
        {
            Field += ds.Tables[0].Rows[i][1].ToString() + ",";
            Val += FieldType.FormatField(ds.Tables[0].Rows[i][4].ToString(), ds.Tables[0].Rows[i][1].ToString()) + "{$split$}";
        }

        //
        string mcSetting="";
        for (int s = 0; s < this.Setting.Items.Count; s++)
        {
            if (this.Setting.Items[s].Selected)
            {
                mcSetting += this.Setting.Items[s].Value + ",";
            }
        }
            if (!String.IsNullOrEmpty(mcSetting))
            {
                mcSetting = "'"+mcSetting.Trim(',')+"'";
            }
            else
            {
                mcSetting = "''";
            }
        Val += mcSetting + "{$split$}";
        Field += "Sitting,";
        ////////
        
        if (mM.Id == 0)
        {
            //Response.Write(Val.ToString());
            bM.MenuInsert(mM.ParentId, Field, Val);
        }
        else
        {
            bM.MenuUpdate(mM.Id, mM.ParentId, Field, Val);
        }
        if (Action == "info")
        {
            StringDeal.Alter("保存完成！", "Menu_Edit.aspx?Id=" + mM.Id + "&MenuId=" + MenuId + "&Action=info");
        }
        else
        {
            StringDeal.Alter("保存完成！", "Menu_Manage.aspx?MenuId=" + MenuId);
        }
        
    }
    #endregion

    #region 模型绑定
    /// <summary>
    /// 模型绑定
    /// </summary>
    protected void BindModel()
    {
        bTable bT = new bTable();
        this.Model.DataSource = bT.TableList();
        this.Model.DataTextField = "Title";
        this.Model.DataValueField = "Id";
        this.Model.DataBind();
        this.Model.SelectedValue = MenuReader("Model");
        if (MenuId > 0)
        {
            this.ModelId.Attributes.Add("style", "display:none;");
            if (mM.Id == 0)
            {
                mM.Temp = "Model";
                this.Model.SelectedValue = StringDeal.StrFormat(bM.GetMenuField(mM, MenuId));
            }
        }
    }
    #endregion

    #region 父级栏目类别绑定
    /// <summary>
    /// 父级栏目类别绑定
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="Separator"></param>
    protected void BindMenuParent(int Id, string Separator)
    {
        DataView dv = new DataView(dsList.Tables[0]);
        dv.RowFilter = "ParentId = " + Id + " And Id <> " + mM.Id;
        foreach (DataRowView dr in dv)
        {
            ListItem li = new ListItem();
            li.Text = Separator + StringDeal.StrFormat(dr["Title"]);
            li.Value = dr["Id"].ToString();
            this.ParentId.Items.Add(li);
            this.ToMenu.Items.Add(li);
            BindMenuParent(StringDeal.ToInt(dr[0]), "┃" + Separator);
        }
        this.ParentId.Items[0].Value = MenuId.ToString();
        this.ParentId.SelectedValue = MenuReader("ParentId");
    }
    #endregion

    #region 获取字段的标题
    /// <summary>
    /// 获取字段的标题
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="Title"></param>
    /// <returns></returns>
    protected string GetFieldTitle(object Id, object Title)
    {
        string Results = "";
        if (MenuId == 0 || String.IsNullOrEmpty(Arry[0]))
        {
            Results = StringDeal.StrFormat(Title);
        }
        else
        {
            foreach (string x in Arry)
            {
                if (x.Split(',')[0] == Id.ToString())
                {
                    Results = x.Split(',')[1];
                }
            }
        }
        return Results;
    }
    #endregion

    #region 获取字段的ID组合
    /// <summary>
    /// 获取字段的ID组合
    /// </summary>
    protected void GetFiledId()
    {    
        if (MenuId == 0 || String.IsNullOrEmpty(Arry[0]))
        {
            mMF.Temp = "0";
        }
        else
        {
            foreach (string x in Arry)
            {
                mMF.Temp += x.Split(',')[0] + ",";
            }
            mMF.Temp = mMF.Temp.Trim(',');
        }
    }
    #endregion
    protected void PageType_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (this.PageType.SelectedValue)
        {
            case "0":
                P_OutLink.Visible = false;
                P_ToMenu.Visible = false;
                P_Style.Visible = true;
                P_Formwork.Visible = true;
                break;
            case "1":
                P_OutLink.Visible = true;
                P_ToMenu.Visible = false;
                P_Style.Visible = false;
                P_Formwork.Visible = false;
                break;
            case "2":
                P_OutLink.Visible = false;
                P_ToMenu.Visible = true;
                P_Style.Visible = false;
                P_Formwork.Visible = false;
                break;
            default:
                P_OutLink.Visible = false;
                P_ToMenu.Visible = false;
                P_Style.Visible = true;
                P_Formwork.Visible = true;
                break;
        }
    }
}

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

public partial class adminmanage_Menu_MenuModel_Set : System.Web.UI.Page
{
    protected mMenuField mMF = new mMenuField();
    protected bMenuField bMF = new bMenuField();
    protected mMenu mM = new mMenu();
    protected bMenu bM = new bMenu();
    protected string[] Arry_Field;
    protected string[] Arry_List;
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdminManage();
        mM.Id = StringDeal.ToInt(Request.QueryString["Id"]);
        mM.Temp = "Menu_Field";
        Arry_Field = bM.GetMenuField(mM, mM.Id).Split('|');//获取此栏目所需字段
        mM.Temp = "Menu_List";
        Arry_List = bM.GetMenuField(mM, mM.Id).Split('|');//获取此栏目列表所显示字段
        if (!IsPostBack)
        {
            MenuSetBind();
        }
        else
        {
            MenuSetSave();
        }
    }

    #region 栏目模型绑定（获取栏目所需字段）
    /// <summary>
    /// 栏目模型绑定（获取栏目所需字段）
    /// </summary>
    protected void MenuSetBind()
    {
        mMF.Temp = "0";
        DataSet ds = bMF.MenuFieldList(mMF);//获取此栏目的模型字段
        DBList.DataSource = ds;
        DBList.DataBind();
    }
    #endregion

    #region 保存栏目信息
    /// <summary>
    /// 保存栏目信息
    /// </summary>
    protected void MenuSetSave()
    {
        string[] IsOpen = Request.Form.GetValues("IsOpen");
        string[] IsList = Request.Form.GetValues("IsList");
        string[] ListWidth = Request.Form.GetValues("ListWidth");
        string[] Title = Request.Form.GetValues("Title");
        string Menu_Field = "", Menu_List = "";
        if (StringDeal.StrFormat(IsOpen) != "")
        {
            for (int i = 0; i < IsOpen.Length; i++)
            {
                string _Title = Title[i].Replace(",", "&sbquo;").Replace("|", "│");
                if (String.IsNullOrEmpty(_Title))
                {
                    _Title = bMF.GetMenuFiledTitle(StringDeal.ToInt(IsOpen[i]));
                }
                Menu_Field += IsOpen[i] + "," + _Title + "|";
                if (StringDeal.StrFormat(IsList) != "")
                {
                    foreach (string j in IsList)
                    {
                        if (j == IsOpen[i])
                        {
                            Menu_List += j + "," + _Title + "," + ListWidth[i] + "|";
                        }
                    }
                }
                else
                {
                    StringDeal.Alter("至少选择一项列表显示");
                }
            }
        }
        else
        {
            StringDeal.Alter("至少选择一项开启状态");
        }
        mM.Menu_Field = Menu_Field.Trim('|');
        mM.Menu_List = Menu_List.Trim('|');

        bM.MenuSet(mM);
        Response.Redirect("Menu_Manage.aspx");
    }
    #endregion

    #region 根据字段ID，返回此字段所需的状态信息
    /// <summary>
    /// 根据字段ID，返回此字段所需的状态信息
    /// </summary>
    /// <param name="Id">ID</param>
    /// <param name="str">所需要返回的状态信息</param>
    /// <returns></returns>
    protected string GetMenuFieldState(object Id,string str)
    {
        string Results = "";
        if(!String.IsNullOrEmpty(Arry_Field[0]))
        {

            foreach(string i in Arry_Field)
            {
                if (i.Split(',')[0] == Id.ToString())
                {
                    if (!String.IsNullOrEmpty(str))
                    {
                        Results = str;
                    }
                    else
                    {
                        Results = i.Split(',')[1];
                    }
                }
            }
        }
        return Results;
    }
    #endregion

    #region 根据字段ID，返回此字段列表所需字段的状态信息
    /// <summary>
    /// 根据字段ID，返回此字段列表所需字段的状态信息
    /// </summary>
    /// <param name="Id">ID</param>
    /// <param name="str">所需要返回的状态信息</param>
    /// <returns></returns>
    protected string GetMenuListState(object Id, string str)
    {
        string Results = "";
        if (!String.IsNullOrEmpty(Arry_List[0]))
        {

            foreach (string i in Arry_List)
            {
                if (i.Split(',')[0] == Id.ToString())
                {
                    if (!String.IsNullOrEmpty(str))
                    {
                        Results = str;
                    }
                    else
                    {
                        Results = i.Split(',')[2];
                    }
                }
            }
        }
        return Results;
    }
    #endregion
}
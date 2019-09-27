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

public partial class adminmanage_Menu_Model_Set : System.Web.UI.Page
{
    protected mField mF = new mField();
    protected bField bF = new bField();
    protected mMenu mM = new mMenu();
    protected bMenu bM = new bMenu();
    protected bTable bT = new bTable();
    protected string[] Arry_Field;
    protected string[] Arry_List;
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdminManage();
        mM.Id = StringDeal.ToInt(Request.QueryString["Id"]);
        mM.Temp = "Model_Field";
        Arry_Field = bM.GetMenuField(mM, mM.Id).Split('|');//获取此信息编辑所需字段
        mM.Temp = "Model_List";
        Arry_List = bM.GetMenuField(mM, mM.Id).Split('|');//获取此信息列表所显示字段
        mM.Temp = "Model";
        mF.TableName = bT.GetTableName(StringDeal.ToInt(bM.GetMenuField(mM, mM.Id)));//获取模型表名
        if (!IsPostBack)
        {
            SetBind();
        }
        else
        {
            SetSave();
        }
    }

    #region 信息模型绑定（获取所需字段）
    /// <summary>
    /// 栏目模型绑定（获取所需字段）
    /// </summary>
    protected void SetBind()
    {
        DataSet ds = bF.FieldList(mF);//获取此信息模型字段
        DBList.DataSource = ds;
        DBList.DataBind();
    }
    #endregion

    #region 保存信息
    /// <summary>
    /// 保存信息
    /// </summary>
    protected void SetSave()
    {
        string[] IsOpen = Request.Form.GetValues("IsOpen");
        string[] IsList = Request.Form.GetValues("IsList");
        string[] ListWidth = Request.Form.GetValues("ListWidth");
        string[] Title = Request.Form.GetValues("Title");
        string Model_Field = "", Model_List = "";
        if (StringDeal.StrFormat(IsOpen) != "")
        {
            for (int i = 0; i < IsOpen.Length; i++ )
            {
                string _Title = Title[i].Replace(",", "&sbquo;").Replace("|", "│");
                if (String.IsNullOrEmpty(_Title))
                {
                    _Title = bF.GetFieldTitle(IsOpen[i], mF.TableName);
                }
                Model_Field += IsOpen[i] + "," + _Title + "|";
                if (StringDeal.StrFormat(IsList) != "")
                {
                    foreach(string j in IsList)
                    {
                        if (j == IsOpen[i])
                        {
                            Model_List += j + "," + _Title + "," + ListWidth[i] + "|";
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
        mM.Model_Field = Model_Field.Trim('|');
        mM.Model_List = Model_List.Trim('|');
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
    protected string GetFieldState(object Id,string str)
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
    protected string GetListState(object Id, string str)
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
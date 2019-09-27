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

public partial class adminmanage_User_User_Edit1 : System.Web.UI.Page
{
    protected mUser mU = new mUser();
    protected bUser bU = new bUser();
    protected HXD.ModelField.Model.Model mm = new HXD.ModelField.Model.Model();
    protected HXD.ModelField.BLL.Model bm = new HXD.ModelField.BLL.Model();
    protected DataSet dsReader;
    protected XmlDoc xml;
    protected string[] Arry;
    //protected DataSet ug_dsList;
    //protected bUserGroup bUG = new bUserGroup();
    //protected mUserGroup mUG = new mUserGroup();

    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdminManage();
        mU.Id = StringDeal.ToInt(Request.QueryString["Id"]);
        mU.GroupId = StringDeal.ToInt(Request.QueryString["GroupId"]);
        mm.Id = StringDeal.ToInt(Request.QueryString["Id"]);
        mm.TableName = bU.GetTableName(mU);
        if (!IsPostBack)
        {
            xml = new XmlDoc();
            xml.xmlfilePath = GetConfig.System("TableXmlPath") + mm.TableName + ".xml";
            dsReader = bm.ModelReader(mm);
            //mUG.ParentId = -1;
            //ug_dsList = (DataSet)bUG.UserGroupList(mUG);
            //UserGroupBind(0, "┣");
            UserReader();
            BindModel();
        }
        else
        {
            UserSave();
        }
    }

    /// <summary>
    /// 用户组绑定
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="Separator"></param>
    //protected void UserGroupBind(int Id, string Separator)
    //{
    //    DataView dv = new DataView(ag_dsList.Tables[0]);
    //    dv.RowFilter = "ParentId = " + Id;
    //    foreach (DataRowView dr in dv)
    //    {
    //        ListItem li = new ListItem();
    //        li.Text = Separator + StringDeal.StrFormat(dr[2]);
    //        li.Value = dr[0].ToString();
    //        this.GroupId.Items.Add(li);
    //        UserGroupBind(StringDeal.ToInt(dr[0]), "┃" + Separator);
    //    }
    //}

    /// <summary>
    /// 保存管理员信息
    /// </summary>
    protected void UserSave()
    {
        mU.UserName = this.UserName.Text;
        mU.UserPwd = Encryp.DESEncrypt(this.UserPwd.Text);
        mField mF = new mField();
        bField bF = new bField();
        mF.TableName = mm.TableName;
        DataSet ds = bF.FieldList(mF);
        string Field = "", Val = "";
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            Field += ds.Tables[0].Rows[i]["Field"].ToString() + ",";
            Val += HXD.ModelField.Common.FieldType.FormatField(ds.Tables[0].Rows[i]["Type"].ToString(), ds.Tables[0].Rows[i]["Field"].ToString()) + "{$split$}";
        }
        if (mU.Id == 0)
        {
            Field += "Id";
            Val += bU.UserInsert(mU).ToString();
            bm.ModelInsert(mm.TableName, Field, Val);
        }
        else
        {
            Field += "1";
            Val += "1";
            bU.UserUpdate(mU);
            bm.ModelUpdate(mm.Id, mm.TableName, Field.Trim(','), Val.Trim(','));
        }
        StringDeal.Alter("保存完成！", "User_Manage.aspx?GroupId=" + mU.GroupId + "");
    }

    /// <summary>
    /// 读取单条管理员信息
    /// </summary>
    protected void UserReader()
    {
        if (mU.Id > 0)
        {
            IList<mUser> list = bU.UserReader(mU);
            this.UserName.Text = list[0].UserName;
            this.UserName.Attributes.Add("class", "input1");
            this.UserName.Attributes.Add("readonly", "readonly");
            this.UserPwd.Attributes.Add("value", Encryp.DESDecrypt(list[0].UserPwd));
            this.UserPwd1.Attributes.Add("value", Encryp.DESDecrypt(list[0].UserPwd));
        }
        else
        {
            this.UserName.Attributes.Add("class", "input1 required validate-length-range-4-20 validate-ajax-Inc/Validate_UserName.aspx");
        }
    }

    #region 模型绑定
    /// <summary>
    /// 模型绑定
    /// </summary>
    private void BindModel()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Name", typeof(string));
        dt.Columns.Add("Title", typeof(string));
        dt.Columns.Add("Note", typeof(string));
        mField mF = new mField();
        bField bF = new bField();
        mF.TableName = mm.TableName;
        DataSet ds = bF.FieldList(mF);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            DataRow dr = dt.NewRow();
            dr["Name"] = ds.Tables[0].Rows[i]["Field"];
            dr["Title"] = ds.Tables[0].Rows[i]["Title"];
            dr["Note"] = ds.Tables[0].Rows[i]["Note"];
            dt.Rows.Add(dr);
        }
        this.DBList.DataSource = dt;
        this.DataBind();
    }
    #endregion

    #region 根据字段名称读取要修改的信息
    /// <summary>
    /// 根据字段名称读取要修改的信息
    /// </summary>
    protected string ModelReader(string Field)
    {
        string value = "";
        if (!String.IsNullOrEmpty(Field))
        {
            if (dsReader.Tables[0].Rows.Count > 0)
            {
                value = dsReader.Tables[0].Rows[0][Field].ToString();
            }
        }
        return value.Replace("\"", "&quot;");
    }
    #endregion

    #region 获取字段的标题
    /// <summary>
    /// 获取字段的标题
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="Title"></param>
    /// <returns></returns>
    protected string GetFieldTitle(object FieldName, object Title)
    {
        string Results = "";
        if (String.IsNullOrEmpty(Arry[0]))
        {
            Results = StringDeal.StrFormat(Title);
        }
        else
        {
            foreach (string x in Arry)
            {
                if (x.Split(',')[0] == FieldName.ToString())
                {
                    Results = x.Split(',')[1];
                }
            }
        }
        return Results;
    }
    #endregion
}

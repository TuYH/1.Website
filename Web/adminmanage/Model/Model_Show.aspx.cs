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
using HXD.Common;
using HXD.Model;
using HXD.BLL;

public partial class adminmanage_Model_Model_Show : System.Web.UI.Page
{
    protected DataSet dsList;
    protected DataSet dsReader;
    protected mMenu mM = new mMenu();
    protected bMenu bM = new bMenu();
    protected HXD.ModelField.Model.Model mm = new HXD.ModelField.Model.Model();
    protected HXD.ModelField.BLL.Model bm = new HXD.ModelField.BLL.Model();
    protected XmlDoc xml;
    protected int MenuId;
    protected string[] Arry;
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdminManage();
        MenuId = StringDeal.ToInt(Request.QueryString["MenuId"]);
        mm.Id = StringDeal.ToInt(Request.QueryString["Id"]);
        mm.TableName = bM.GetMenuTableName(MenuId);//模型表名
        if (!IsPostBack)
        {
            this.ClassId.SelectedItem.Value = MenuId.ToString();//顶级栏目的值
            xml = new XmlDoc();
            xml.xmlfilePath = GetConfig.System("TableXmlPath") + mm.TableName + ".xml";
            GetModelField(MenuId);//获取模型字段组合
            dsList = (DataSet)bM.MenuList();//栏目列表
            dsReader = bm.ModelReader(mm);
            BindMenu(MenuId, "┣");
            BindModel();
        }
        else
        {
            ModelSave();
        }
    }

    #region 栏目类别绑定
    /// <summary>
    /// 栏目类别绑定
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="Separator"></param>
    private void BindMenu(int Id, string Separator)
    {
        DataView dv = new DataView(dsList.Tables[0]);
        dv.RowFilter = "ParentId = " + Id;
        foreach (DataRowView dr in dv)
        {
            ListItem li = new ListItem();
            li.Text = Separator + StringDeal.StrFormat(dr["Title"]);
            li.Value = dr["Id"].ToString();
            this.ClassId.Items.Add(li);
            BindMenu(StringDeal.ToInt(dr[0]), "┃" + Separator);
        }
        //this.ClassId.Items[0].Value = MenuId.ToString();
        //this.ClassId.SelectedValue = MenuReader("ParentId");
    }
    #endregion

    #region 获取此栏目所需要的字段数组
    /// <summary>
    /// 获取此栏目所需要的字段数组
    /// </summary>
    /// <param name="Id"></param>
    private void GetModelField(int Id)
    {
        mM.Temp = "Model_Field";
        Arry = bM.GetMenuField(mM, Id).Split('|');
        if (Arry.Length < 1 || String.IsNullOrEmpty(Arry[0]))
        {
            mM.Temp = "ParentId";
            int ParentId = StringDeal.ToInt(bM.GetMenuField(mM, Id));
            GetModelField(ParentId);
        }
    }
    #endregion

    #region 模型绑定
    /// <summary>
    /// 模型绑定
    /// </summary>
    private void BindModel()
    {
        HXD.BLL.bField bll = new bField();

        DataTable dt = new DataTable();
        dt.Columns.Add("Name", typeof(string));
        dt.Columns.Add("Title", typeof(string));
        dt.Columns.Add("Sort",typeof(int));
        foreach (string x in Arry)
        {
            DataRow dr = dt.NewRow();
            dr["Name"] = x.Split(',')[0];
            dr["Title"] = x.Split(',')[1];
            //Response.Write(x.Split(',')[0]);
            dr["Sort"] = bll.GetFieldSort(x.Split(',')[0],mm.TableName);
            dt.Rows.Add(dr);
        }
        dt.DefaultView.Sort = "Sort ASC";
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
        return value.Replace("\"","&quot;");
    }
    #endregion

    #region 保存信息
    /// <summary>
    /// 保存信息
    /// </summary>
    protected void ModelSave()
    {
        string Field = "ClassId,", Val = this.ClassId.SelectedValue + "{$split$}";
        mField mF = new mField();
        bField bF = new bField();
        mF.TableName = mm.TableName;
        DataSet ds = bF.FieldList(mF);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            string ValTemp = System.Web.HttpContext.Current.Request.Form[ds.Tables[0].Rows[i]["Field"].ToString()];
            if (ValTemp != string.Empty && ValTemp != null)
            {
                Field += ds.Tables[0].Rows[i]["Field"].ToString() + ",";
                Val += HXD.ModelField.Common.FieldType.FormatField(ds.Tables[0].Rows[i]["Type"].ToString(), ds.Tables[0].Rows[i]["Field"].ToString()) + "{$split$}";
            }
        }
        if (mm.Id == 0)
        {
            bm.ModelInsert(mm.TableName, Field, Val);
        }
        else
        {
            bm.ModelUpdate(mm.Id, mm.TableName, Field, Val);
        }
        Response.Redirect("Model_Manage.aspx?MenuId=" + MenuId);
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

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
using HXD.BLL;
using HXD.Model;
using HXD.Common;

public partial class adminmanage_Model_Field_Manage : System.Web.UI.Page
{
    protected int TableId;
    protected mField mF = new mField();
    protected bField bF = new bField();
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdminManage();
        TableId = StringDeal.ToInt(Request.QueryString["TableId"]);
        bTable bT = new bTable();
        mF.TableName = bT.GetTableName(TableId);
        
        if (!IsPostBack)
        {
            Operation();
            DBList.DataSource = bF.FieldList(mF);
            DBList.DataBind();
        }
    }

    #region 删除和移动顺序操作
    /// <summary>
    /// 删除和移动顺序操作
    /// </summary>
    protected void Operation()
    {
        string Action = Request.QueryString["Action"];
        mF.Id = StringDeal.ToInt(Request.QueryString["Id"]);
        if (!String.IsNullOrEmpty(Action))
        {
            if (Action == "down" || Action == "up")
            {
                bF.FieldMove(mF, Action);
            }
            else if (Action == "del")
            {
                mF = bF.GetTableAndField(mF);//字段名与表名
                bF.FieldDel(mF);
                HXD.ModelField.BLL.Field bf = new HXD.ModelField.BLL.Field();
                HXD.ModelField.Model.Field mf = new HXD.ModelField.Model.Field();
                mf.TableName = mF.TableName;
                mf.Name = mF.Field;
                bf.Val = mf;
                bf.DeleteXml();
            }
            Response.Redirect("Field_Manage.aspx?TableId=" + TableId + "", true);
        }
    }
    #endregion
}

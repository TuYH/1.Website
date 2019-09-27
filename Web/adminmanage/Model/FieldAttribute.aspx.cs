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
using HXD.ModelField.BLL;
using HXD.BLL;
using HXD.Model;
using System.IO;

public partial class adminmanage_Model_FieldAttribute : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdminManage();
        bField bF = new bField();
        mField mF = new mField();
        bMenu bM = new bMenu();
        GetAttribute ga = new GetAttribute();
        mF.Id = StringDeal.ToInt(Request.QueryString["Id"]);//字段ID
        mF = bF.GetTableAndField(mF);//字段名与表名

        ga.FieldType = Request.QueryString["Type"];//字段类型
        ga.TableName = mF.TableName;
        ga.Field = mF.Field;
        ga.dsList = (DataSet)bM.MenuList();//.MenuList();
        ga.Attribute();//输入字段属性配置信息

    }
}

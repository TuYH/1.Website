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

public partial class adminmanage_Model_Table_Manage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdminManage();
        if (!IsPostBack)
        {
            bTable bT = new bTable();
            string Action = Request.QueryString["Action"];
            if (Action == "del")
            {
                mTable mT = new mTable();
                mT.Id = StringDeal.ToInt(Request.QueryString["Id"]);
                if (bT.GetIsSystem(mT))
                {
                    StringDeal.Alter("此模型为系统模型禁止删除！");
                }
                mT.TableName = bT.GetTableName(mT.Id);
                bT.TableDel(mT);
                HXD.ModelField.BLL.Table bt = new HXD.ModelField.BLL.Table();
                bt.DeleteXml(mT);
            }
            
            DBList.DataSource = bT.TableList();
            DBList.DataBind();
        }
    }
}
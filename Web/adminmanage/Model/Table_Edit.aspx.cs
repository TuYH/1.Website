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

public partial class adminmanage_Model_Table_Edit : System.Web.UI.Page
{
    protected mTable mT = new mTable();
    protected bTable bT = new bTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdminManage();
        mT.Id = StringDeal.ToInt(Request.QueryString["Id"]);
        if (!IsPostBack)
        {
            TableRead();
            if (mT.Id > 0)
            {
                this.TableName.ReadOnly = true;
            }
        }
        else
        {
            TableSave();
        }
    }

    #region 保存模型表
    /// <summary>
    /// 保存模型表
    /// </summary>
    protected void TableSave()
    {
        mT.Title = this.Title.Text;
        mT.TableName = "tb_" + this.TableName.Text;
        mT.Note = this.Note.Text;
        mT.Type = StringDeal.ToInt(this.Type.Text);
        if (mT.Id == 0)
        {
            if (bT.IsTable(mT))
            {
                StringDeal.Alter("此表名已经存在，请更换其他名称！");
            }
            bT.TableInsert(mT);
            HXD.ModelField.BLL.Table bt = new HXD.ModelField.BLL.Table();
            bt.CreateXml(mT);
        }
        else
        {
            bT.TableUpdate(mT);
        }
        Response.Redirect("Table_Manage.aspx",true);
    }
    #endregion

    #region 读取模型表信息
    /// <summary>
    /// 读取模型表信息
    /// </summary>
    protected void TableRead()
    {
        if (mT.Id > 0)
        {
            mTable mTa = bT.TableRead(mT);
            this.Title.Text = mTa.Title;
            this.TableName.Text = mTa.TableName.Replace("tb_U_", "");
            this.Note.Text = mTa.Note;
            this.Type.SelectedValue = mTa.Type.ToString();
            this.Type.Attributes.Add("disabled", "disabled");
        }
    }
    #endregion
}

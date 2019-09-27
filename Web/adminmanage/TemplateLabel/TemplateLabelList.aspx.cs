using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class adminmanage_TemplateLabel_TemplateLabelList : System.Web.UI.Page
{
    string type = string.Empty;
    int id = 0;
    protected int Pages;
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdminManage();
        this.DelBut.Attributes.Add("onclick", "return Exec();");//删除
        type = Request.QueryString["type"];
        Pages = HXD.Common.StringDeal.ToInt(Request.QueryString["Page"]);
        id = Convert.ToInt32(Request.QueryString["id"]);
        if (!IsPostBack)
        {
            switch (type)
            {
                case "del":
                    deletes(id.ToString());
                    break;
            }
            binder();
        }
    }

    #region 数据绑定
    /// <summary>
    /// 数据绑定
    /// </summary>
    public void binder()
    {
        HXD.Common.SgqPage pg = new HXD.Common.SgqPage();
        pg.PageIndex = Pages;
        pg.PageSize = 30;
        pg.dt = HXD.DBUtility.SQLHelper.ExecuteDataset("select id,labelHelp,labelname,labelfile,submittime from tb_U_Template_Label order by id desc").Tables[0];
        this.Repeater1.DataSource = pg.DataSource();
        this.Repeater1.DataBind();
        this.PageView.Text = pg.PageView1();
    }
    #endregion

    /// <summary>
    /// 真实删除
    /// </summary>
    public void deletes(string strID)
    {
        DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset("select counts from tb_U_Template_Label where ID in(" + strID.Trim() + ")");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)//删除内容中的图片
        { HXD.Common.FileOperate.GetImgTag(ds.Tables[0].Rows[i]["counts"].ToString().Trim()); }
        ds.Tables[0].Dispose();
        ds.Tables[0].Clear();
        HXD.DBUtility.SQLHelper.ExecuteNonQuery("delete from tb_U_Template_Label where ID in(" + strID + ")");
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void DelBut_Click(object sender, EventArgs e)
    {
        string strID = Request.Form["CK_ID"];
        deletes(strID);
        binder();
    }
}

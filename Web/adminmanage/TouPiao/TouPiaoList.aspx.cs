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

public partial class adminmanage_TouPiao_TouPiaoList : System.Web.UI.Page
{
    string type = string.Empty;
    int id = 0;
    protected int Pages;
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdminManage();
        this.DelBut.Attributes.Add("onclick", "return Exec();");//删除
        this.LinkButton1.Attributes.Add("onclick", "return Exec();");//审核
        this.LinkButton2.Attributes.Add("onclick", "return Exec();");//取消
        this.LinkButton3.Attributes.Add("onclick", "return Exec();");//推荐
        this.LinkButton4.Attributes.Add("onclick", "return Exec();");//取消

        type = Request.QueryString["type"];
        Pages = HXD.Common.StringDeal.ToInt(Request.QueryString["Page"]);
        id = HXD.Common.StringDeal.ToInt(Request.QueryString["id"]);
        if (!IsPostBack)
        {
            switch (type)
            {
                case "del":
                    deletevideo(id.ToString());
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
        pg.PageSize = 20;
        pg.dt = HXD.DBUtility.SQLHelper.ExecuteDataset("select id,title,ReleaseTime,dbo.admin_isyesorno(is_Examine) as is_Examine,dbo.admin_isyesorno(is_Recommendation) as is_Recommendation,end_time from tb_U_TouPiao order by id desc").Tables[0];
        this.Repeater1.DataSource = pg.DataSource();
        this.Repeater1.DataBind();
        this.PageView.Text = pg.PageView1();
    }
    #endregion

    #region 删除数据
    /// <summary>
    /// 删除数据
    /// </summary>
    /// <param name="id"></param>
    public void deletevideo(string id)
    {
        DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset("select from tb_U_TouPiao where ID in(" + id + ")");
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            { HXD.DBUtility.SQLHelper.ExecuteNonQuery("delete from tb_U_TouPiao1 where FatherId=" + ds.Tables[0].Rows[i]["id"].ToString().Trim()); }
        }
        ds.Tables[0].Dispose();
        ds.Tables[0].Clear();
        HXD.DBUtility.SQLHelper.ExecuteNonQuery("delete from tb_U_TouPiao where ID in(" + id + ")");
    }
    #endregion

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void DelBut_Click(object sender, EventArgs e)
    {
        string strID = Request.Form["CK_ID"];
        deletevideo(strID);
        binder();
    }
    /// <summary>
    /// 审核
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string strID = Request.Form["CK_ID"];
        HXD.DBUtility.SQLHelper.ExecuteNonQuery("update tb_U_TouPiao set is_Examine=1 where id in(" + strID + ")");
        binder();
    }
    /// <summary>
    /// 取消
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        string strID = Request.Form["CK_ID"];
        HXD.DBUtility.SQLHelper.ExecuteNonQuery("update tb_U_TouPiao set is_Examine=0 where id in(" + strID + ")");
        binder();
    }
    /// <summary>
    /// 推荐
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        string strID = Request.Form["CK_ID"];
        HXD.DBUtility.SQLHelper.ExecuteNonQuery("update tb_U_TouPiao set is_Recommendation=1 where id in(" + strID + ")");
        binder();
    }
    /// <summary>
    /// 取消
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        string strID = Request.Form["CK_ID"];
        HXD.DBUtility.SQLHelper.ExecuteNonQuery("update tb_U_TouPiao set is_Recommendation=0 where id in(" + strID + ")");
        binder();
    }
}
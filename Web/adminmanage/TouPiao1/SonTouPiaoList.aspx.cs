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

public partial class adminmanage_TouPiao1_SonTouPiaoList : System.Web.UI.Page
{
    protected int fid = 0, Pages = 0, id = 0;
    string type = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdminManage();
        this.DelBut.Attributes.Add("onclick", "return Exec();");//删除
        fid = HXD.Common.StringDeal.ToInt(Request.QueryString["fid"]);
        Pages = HXD.Common.StringDeal.ToInt(Request.QueryString["Page"]);
        id = HXD.Common.StringDeal.ToInt(Request.QueryString["id"]);
        type = Request.QueryString["type"];
        if (!IsPostBack)
        {
            if (type == "del")
            { deletevideo(id.ToString()); }
            binder(fid);
        }
    }

    #region 删除视频文件以及图片
    /// <summary>
    /// 删除视频文件以及图片
    /// </summary>
    /// <param name="id"></param>
    public void deletevideo(string id)
    {
        HXD.DBUtility.SQLHelper.ExecuteNonQuery("delete from tb_U_TouPiao1 where ID in(" + id + ")");
    }
    #endregion

    #region 数据绑定
    /// <summary>
    /// 数据绑定
    /// </summary>
    public void binder(int id)
    {
        this.Repeater1.DataSource = HXD.DBUtility.SQLHelper.ExecuteDataset("select id,title,AddTime from tb_U_TouPiao1 where FatherId=" + fid + " order by id desc").Tables[0];
        this.Repeater1.DataBind();
    }
    #endregion

    protected void DelBut_Click(object sender, EventArgs e)
    {
        string strID = Request.Form["CK_ID"];
        deletevideo(strID);
        binder(fid);
    }
}

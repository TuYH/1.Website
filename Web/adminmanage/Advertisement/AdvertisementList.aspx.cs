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
public partial class adminmanage_Advertisement_AdvertisementList : System.Web.UI.Page
{
    string type = string.Empty;
    int id = 0;
    protected int Pages;
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdminManage();
        this.DelBut.Attributes.Add("onclick", "return Exec();");//删除
        this.StatusBut.Attributes.Add("onclick", "return Exec();");//审核
        this.unStatusBut.Attributes.Add("onclick", "return Exec();");//关闭
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

    public string adtype(string type)
    {
        if (type != "")
        {
            switch (type)
            {
                case "1":
                    return "文字";
                case "2":
                    return "图片";
                case "3":
                    return "Flash";
                case "4":
                    return "脚本";
                case "5":
                    return "浮动";
                default:
                    return "未知";
            }
        }
        else
        { return "未知"; }
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
        pg.dt = HXD.DBUtility.SQLHelper.ExecuteDataset("select id,AdName,type,submittime,isqiyong from tb_U_Advertisement order by id desc").Tables[0];
        this.Repeater1.DataSource = pg.DataSource();
        this.Repeater1.DataBind();
        this.PageView.Text = pg.PageView2();
    }
    #endregion

    /// <summary>
    /// 真实删除
    /// </summary>
    public void deletes(string strID)
    {
        HXD.Common.FilesManage files = new HXD.Common.FilesManage();
        DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset("select id,Files,FileType from tb_U_Advertisement where id in(" + strID + ")");
        if (ds.Tables[0].Rows.Count == 1)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[0]["FileType"].ToString() != "1")
                {
                    files.WNdelfile("~" + ds.Tables[0].Rows[0]["Files"].ToString());//删除文件
                }
                files.WNdelfile(Web.Model.PublicModel.ADJsFile + ds.Tables[0].Rows[i][0] + ".js");//删除脚本
            }
        }
        ds.Tables[0].Dispose();
        ds.Tables[0].Clear();
        HXD.DBUtility.SQLHelper.ExecuteNonQuery("delete from tb_U_Advertisement where id in(" + strID + ")");
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
    /// <summary>
    /// 审核
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void StatusBut_Click(object sender, EventArgs e)
    {
        string strID = Request.Form["CK_ID"];
        HXD.DBUtility.SQLHelper.ExecuteNonQuery("update tb_U_Advertisement set isqiyong=1 where id in(" + strID + ")");
        binder();
    }
    /// <summary>
    /// 关闭
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void unStatusBut_Click(object sender, EventArgs e)
    {
        string strID = Request.Form["CK_ID"];
        HXD.DBUtility.SQLHelper.ExecuteNonQuery("update tb_U_Advertisement set isqiyong=0 where id in(" + strID + ")");
        binder();
    }
}

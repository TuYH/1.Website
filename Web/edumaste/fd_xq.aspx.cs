using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using HXD.Common;

public partial class edumaste_fd_xq : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         LoginCheck.AdManage(6);
         if (!IsPostBack)
         {
             string cid = Request.QueryString["cid"].ToString();
             string sql = "select uid,content,Replay from tb_U_Message where id=" + cid;
             DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
             string str = ds.Tables[0].Rows[0]["content"].ToString();
             string strid = ds.Tables[0].Rows[0]["uid"].ToString();
             string sql1 = "select name from tb_U_user where id=" + strid;
             string str_name = HXD.DBUtility.SQLHelper.ExecuteScalar(sql1).ToString();
             this.Label1.Text = str_name;
             this.Label2.Text = str;
             this.container.Value = ds.Tables[0].Rows[0]["Replay"].ToString();
         }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string cid = Request.QueryString["cid"].ToString();

        string sql = "update tb_U_Message set Replay='" + container.Value +"',state=1 where id=" + cid;
        HXD.DBUtility.SQLHelper.ExecuteScalar(sql);

        StringDeal.Alter("回复成功", "fd_gt.aspx");
    }
}
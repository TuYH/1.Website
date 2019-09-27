using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using HXD.Common;

public partial class User_fd_xq : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         LoginCheck.AdManage(5);
         if (!IsPostBack)
         {
             this.Panel1.Visible = true;
             string cid = Request.QueryString["cid"].ToString();
             string sql = "select uid,content,Replay,yy_time,state from tb_U_Message where id=" + cid;
             DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
             string str = ds.Tables[0].Rows[0]["content"].ToString();
             string strid = ds.Tables[0].Rows[0]["uid"].ToString();
             string sql1 = "select name from tb_U_user where id=" + strid;
             string str_name = HXD.DBUtility.SQLHelper.ExecuteScalar(sql1).ToString();
             this.Label1.Text = str_name;
             this.Label2.Text = str;
             this.Label3.Text = ds.Tables[0].Rows[0]["yy_time"].ToString();
             this.container.Value = ds.Tables[0].Rows[0]["Replay"].ToString();

             int icd = int.Parse(ds.Tables[0].Rows[0]["state"].ToString());
             if (icd == 2)
             {
                 this.Panel1.Visible = false;
             }
         }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string cid = Request.QueryString["cid"].ToString();


        string sql = "update tb_U_Message set Replay='" + container.Value + "',state=1,posttime='" + DateTime.Now.ToString()+"' where id=" + cid;
        HXD.DBUtility.SQLHelper.ExecuteScalar(sql);

        StringDeal.Alter("回复成功", "fd_gt.aspx");
    }
}
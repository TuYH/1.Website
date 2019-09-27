using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HXD.Common;
using System.Data;

public partial class reg : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        //string MenuId= Request.QueryString["MenuId"].ToString();
        string MenuId = LoginCheck.getadminid();
        string username = this.txtAdminName.Value.Trim();
        string userpwd = Encryp.DESEncrypt(this.TextBox2.Text.Trim());

        string email = this.TextBox4.Text.Trim();
        string tell = this.TextBox5.Text.Trim();
        string dw_name = this.TextBox6.Text.Trim();
        string sqls = "select * from tb_User where UserName='" + username + "'";
        DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sqls);
        if (ds.Tables[0].Rows.Count == 0)
        {
            string sql = "insert into tb_User(UserName,UserPwd,GroupId,classid,islock)values('" + username + "','" + userpwd + "',6,'" + MenuId + "',0)";
            HXD.DBUtility.SQLHelper.ExecuteScalar(sql);
            System.Threading.Thread.Sleep(1000);
            string sql2 = "select id from tb_User where UserName='" + username + "' ";
            string icd = HXD.DBUtility.SQLHelper.ExecuteScalar(sql2).ToString();
            string sql3 = "insert into tb_U_User (Id,Tel,msn,name,sc_id)values('" + icd + "','" + tell + "','" + email + "','" + dw_name + "','" + MenuId + "')";
            HXD.DBUtility.SQLHelper.ExecuteScalar(sql3);
            Response.Redirect("user/");
        }
        else
        {
            StringDeal.Alter("用户名已存在");
        }
         

    }
}
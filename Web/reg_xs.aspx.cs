using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HXD.Common;
using System.Data;

public partial class reg_xs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string MenuId = LoginCheck.getadminid();
        string username = this.TextBox1.Text.Trim();
        string userpwd = Encryp.DESEncrypt(this.TextBox2.Text.Trim());

        string tell = this.TextBox4.Text.Trim();
        string xuehao = this.TextBox5.Text.Trim();
        string xname= this.TextBox6.Text.Trim();

        string sqls = "select * from tb_User where UserName='" + username + "'";
        DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sqls);
        if (ds.Tables[0].Rows.Count == 0)
        {
            string sql = "insert into tb_User(UserName,UserPwd,GroupId,classid,islock)values('" + username + "','" + userpwd + "',1,'" + MenuId + "',0)";
            HXD.DBUtility.SQLHelper.ExecuteScalar(sql);
            Session["AdminManage"] = username;

            System.Threading.Thread.Sleep(1000);
            string sql2 = "select id from tb_User where UserName='" + username + "' and datediff(mi,RegTime,getdate())<=1";
            string icd = HXD.DBUtility.SQLHelper.ExecuteScalar(sql2).ToString();
            Session["userid"] = icd;
            string sql3 = "insert into tb_U_User (Id,Tel,msn,name)values('" + icd + "','" + tell + "','" + xuehao + "','" + xname + "')";
            HXD.DBUtility.SQLHelper.ExecuteScalar(sql3);
            Response.Redirect("user/twolist.aspx");
        }
        else
        {
            Response.Write("用户名已存在");
        }
    }
    protected string issta(string str)
    {

        return "";
    }

}
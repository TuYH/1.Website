using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using HXD.Common;

public partial class edumaste_From_upwd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdManage(6);
        if (!IsPostBack)
        {
            string userid = Session["userid"].ToString();
            this.TextBox1.Text = Session["AdminManage"].ToString();
            string sql = "select name from tb_u_user where id='" + userid + "'";
            this.cname.Text = HXD.DBUtility.SQLHelper.ExecuteScalar(sql).ToString();
            
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string userid = Session["userid"].ToString();
        string xx_name = this.TextBox1.Text;
        string cname = this.cname.Text;
        string xx_note = Encryp.DESEncrypt(this.TextBox2.Text.Trim());
        string sql_u = "update tb_user set userpwd ='" + xx_note + "' where id=" + userid;
        HXD.DBUtility.SQLHelper.ExecuteScalar(sql_u);
        string sql_c = "update tb_u_user set name ='" + cname + "' where id=" + userid;
        HXD.DBUtility.SQLHelper.ExecuteScalar(sql_c);
        StringDeal.Alter("密码更新成功！");


    }
}
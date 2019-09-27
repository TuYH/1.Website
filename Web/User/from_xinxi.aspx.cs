using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using HXD.Common;

public partial class user_from_xinxi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdManage(5);
        if (!IsPostBack)
        {
            string userid = Session["userid"].ToString();
            string sqlcl = "select name,tel from tb_u_user where id=" + userid;
          
            DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sqlcl);
            this.TextBox1.Text = ds.Tables[0].Rows[0]["name"].ToString();
            this.TextBox2.Text = ds.Tables[0].Rows[0]["tel"].ToString();
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string userid = Session["userid"].ToString();
        //string xx_name = this.TextBox1.Text;
        //string xx_note = this.TextBox2.Text;
        string xx_name = this.TextBox1.Text.Replace("'", "/'").Replace("\"", "/\"");
        string xx_note = this.TextBox2.Text.Replace("'", "/'").Replace("\"", "/\"");

        string sql_u = "update tb_u_user set name='" + xx_name + "',tel ='" + xx_note + "' where id=" + userid;
        HXD.DBUtility.SQLHelper.ExecuteScalar(sql_u);

        StringDeal.Alter("更新成功！");
    }
}
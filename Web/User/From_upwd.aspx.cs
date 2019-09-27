using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using HXD.Common;

public partial class user_From_upwd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdManage(5);
        if (!IsPostBack)
        {
            string userid = Session["userid"].ToString();

            this.TextBox1.Text = Session["AdminManage"].ToString();
            
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string userid = Session["userid"].ToString();
        string xx_name = this.TextBox1.Text;
        string xx_note = Encryp.DESEncrypt(this.TextBox2.Text.Trim());
        string sql_u = "update tb_user set userpwd ='" + xx_note + "' where id=" + userid;
        HXD.DBUtility.SQLHelper.ExecuteScalar(sql_u);
        StringDeal.Alter("密码更新成功！");


    }
}
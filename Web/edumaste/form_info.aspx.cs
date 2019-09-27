using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using HXD.Common;

public partial class edumaste_form_info : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         LoginCheck.AdManage(6);
         if (!IsPostBack)
         {
             string userid = Session["userid"].ToString();
             string sqlcl = "select Classid from tb_user where id=" + userid;
             string id = HXD.DBUtility.SQLHelper.ExecuteScalar(sqlcl).ToString();
             // LoginCheck.Sendmsg(id, "【教育局】" + s_name2 + "查看了学校的量表统计!");
             string sql = "select * from tb_U_school where id=" + id;
             DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
             this.TextBox1.Text = ds.Tables[0].Rows[0]["s_name"].ToString();
             this.TextBox2.Text = ds.Tables[0].Rows[0]["note"].ToString();
         }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string userid=Session["userid"].ToString();
        string sqlcl = "select Classid from tb_user where id=" + userid;
        string id = HXD.DBUtility.SQLHelper.ExecuteScalar(sqlcl).ToString();
        string xx_name = this.TextBox1.Text.Replace("'", "/'").Replace("\"", "/\"");
        string xx_note = this.TextBox2.Text.Replace("'", "/'").Replace("\"", "/\"");
        string sql_u = "update tb_U_school set s_name='" + xx_name + "',note ='" + xx_note + "' where id=" + id;
        HXD.DBUtility.SQLHelper.ExecuteScalar(sql_u);
        StringDeal.Alter("提交成功！", "../edumaste/form_info.aspx");


    }
}
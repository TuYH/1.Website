using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Edu_from_g : System.Web.UI.Page
{
    protected int userid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoginCheck.AdManage();

            string MenuId = Session["userid"].ToString();
            userid = int.Parse(MenuId);

            string sql = "select * from tb_U_User where id=" + userid;
            DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
            this.username.Text = ds.Tables[0].Rows[0]["name"].ToString();
            this.userphone.Text = ds.Tables[0].Rows[0]["tel"].ToString();


        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string username = this.username.Text;
        string userphone = this.userphone.Text;
        string content = this.usercontent.Text;

        string sql = "insert into tb_U_Message (Name,Tel,Content,classid)values('" + username + "','" + userphone + "','" + content + "','" + userid + "')";
        HXD.DBUtility.SQLHelper.ExecuteScalar(sql);

        Response.Write("留言成功");
    }
}
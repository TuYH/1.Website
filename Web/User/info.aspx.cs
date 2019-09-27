using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using HXD.Common;

public partial class user_info : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int id = int.Parse(Request.QueryString["id"].ToString());
            getinfo(id);
        }
    }
    protected void getinfo(int id)
    {
        string sql = "select * from tb_U_User where Id='"+id+"'";
        DataSet dt = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
        if (dt.Tables[0].Rows.Count > 0)
        {

            Textxh.Text = dt.Tables[0].Rows[0]["msn"].ToString(); ;//学号
            Textname.Text = dt.Tables[0].Rows[0]["name"].ToString(); ;//姓名
            string excl_sex = dt.Tables[0].Rows[0]["sex"].ToString(); ;//性别
            Textmz.Text = dt.Tables[0].Rows[0]["nationality"].ToString(); ;//民族
            Textnj.Text = dt.Tables[0].Rows[0]["banji"].ToString(); //年级
            TextBbj.Text = dt.Tables[0].Rows[0]["nianji"].ToString();//班级
        }

        string sql2 = "select id,Fresultid,FstudentNo,Fpaperid,Fscore,Fresult,postTime from t_exam_results where Fresultid ='" + id + "'";
        Repeater1.DataSource = HXD.DBUtility.SQLHelper.ExecuteDataset(sql2);
        Repeater1.DataBind();
    }
    protected string getname(string id)
    {
        string sql = "SELECT name from tb_U_User where id=" + id;
        string name = HXD.DBUtility.SQLHelper.ExecuteScalar(sql).ToString();
        return name;
    }
    protected string getlbname(string id)
    {
        string sql = "select Fpapername from t_exam_paper where Fpaperid=" + id;
        string name = HXD.DBUtility.SQLHelper.ExecuteScalar(sql).ToString();
        return name;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        int id = int.Parse(Request.QueryString["id"].ToString());
        string str_Textxh = this.Textxh.Text;
        string str_Textname = this.Textname.Text;
        //string str_excl_sex = this.excl_sex.Text;
        string str_Textmz = this.Textmz.Text;
        string str_Textnj = this.Textnj.Text;
        string str_TextBbj = this.TextBbj.Text;

        string sql = "update tb_u_user set Name='" + str_Textname + "',nationality='" + str_Textmz + "',banji='" + str_Textnj + "',nianji='" + str_TextBbj + "' where Id='" + id + "'";
        HXD.DBUtility.SQLHelper.ExecuteScalar(sql);
        StringDeal.Alter("个人数据更新成功！", "info.aspx?id=" + id + "&Action=lock");

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string psw = Encryp.DESEncrypt("123456");
        int id = int.Parse(Request.QueryString["id"].ToString());
        string sql = "update tb_user set UserPwd='" + psw + "' where Id=" + id;
        HXD.DBUtility.SQLHelper.ExecuteScalar(sql);
        StringDeal.Alter("密码初始化成功 - 默认密码：123456");

    }
}
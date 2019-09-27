using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class User_olist : System.Web.UI.Page
{
    protected string sc_name = "", sc_note = "";
    protected string c_xs = "", c_ls = "", c_xz = "", c_cp = "";
    protected string s_Fscore1 = "", s_Fscore2 = "", s_Fscore3 = "", s_Fscore4 = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdManage(6);
        if (!IsPostBack)
        {


                string uid = Session["userid"].ToString();
                string s_name2 = Session["AdminManage"].ToString();
                string sqlcl = "select Classid from tb_user where id=" + uid;
                string id = HXD.DBUtility.SQLHelper.ExecuteScalar(sqlcl).ToString();
               // LoginCheck.Sendmsg(id, "【教育局】" + s_name2 + "查看了学校的量表统计!");
                string sql = "select * from tb_U_school where id=" + id;
                DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
                sc_name = ds.Tables[0].Rows[0]["s_name"].ToString();
                sc_note = ds.Tables[0].Rows[0]["note"].ToString();

                string sql_xs = "select count(id) from tb_User where Classid='" + id + "' and GroupId=1";//学生
                string sql_ls = "select count(id) from tb_User where Classid='" + id + "' and GroupId=5";//老师
                string sql_xz = "select COUNT(id) from tb_U_Message where cid in(2,3) and zxs_id='" + uid + "'";//校长
                string sql_cp = "select COUNT(Fresultid) from t_exam_results where Fresultid in(select id from tb_User where Classid='" + id + "' and GroupId=1)";//测评数
                c_xs = HXD.DBUtility.SQLHelper.ExecuteScalar(sql_xs).ToString();
                c_ls = HXD.DBUtility.SQLHelper.ExecuteScalar(sql_ls).ToString();
                c_xz = HXD.DBUtility.SQLHelper.ExecuteScalar(sql_xz).ToString();
                c_cp = HXD.DBUtility.SQLHelper.ExecuteScalar(sql_cp).ToString();

                string df1 = "select COUNT(Fresultid) from t_exam_results where Fresultid in(select id from tb_User where Classid='" + id + "' and GroupId=1) and Fpaperid=1 and Fscore<161";
                string df2 = "select COUNT(Fresultid) from t_exam_results where Fresultid in(select id from tb_User where Classid='" + id + "' and GroupId=1) and Fpaperid=1 and Fscore>161 and Fscore<181";
                string df3 = "select COUNT(Fresultid) from t_exam_results where Fresultid in(select id from tb_User where Classid='" + id + "' and GroupId=1) and Fpaperid=1 and Fscore>181 and Fscore<201";
                string df4 = "select COUNT(Fresultid) from t_exam_results where Fresultid in(select id from tb_User where Classid='" + id + "' and GroupId=1) and Fpaperid=1 and Fscore>200";
                s_Fscore1 = HXD.DBUtility.SQLHelper.ExecuteScalar(df1).ToString();
                s_Fscore2 = HXD.DBUtility.SQLHelper.ExecuteScalar(df2).ToString();
                s_Fscore3 = HXD.DBUtility.SQLHelper.ExecuteScalar(df3).ToString();
                s_Fscore4 = HXD.DBUtility.SQLHelper.ExecuteScalar(df4).ToString();

                string sqldb = "select top 6 * from tb_User where Classid='" + id + "' and GroupId=1";
                Repeater1.DataSource = HXD.DBUtility.SQLHelper.ExecuteDataset(sqldb);
                Repeater1.DataBind();
            
        }
    }

    protected string getname(string id)
    {
        string sql = "SELECT name from tb_U_User where id=" + id;
        string name = HXD.DBUtility.SQLHelper.ExecuteScalar(sql).ToString();
        return name;
    }

    protected string gettime(string id)
    {
        string sql = "select COUNT(Fresultid) from t_exam_results where Fresultid=" + id;
        string name = HXD.DBUtility.SQLHelper.ExecuteScalar(sql).ToString();
        return name;
    }
    protected string gettime2(string id)
    {
        string sql = "SELECT COUNT(id) from tb_U_Message where ClassId =" + id;
        string name = HXD.DBUtility.SQLHelper.ExecuteScalar(sql).ToString();
        return name;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Edu_Ulist : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdManage(7);
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] == null)
            {
            }
            else
            {

                string id = Request.QueryString["id"].ToString();
                string s_name2 = Session["AdminManage"].ToString();
               
                //string sql = "select * from tb_U_school where id=" + id;
                //DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
                //sc_name = ds.Tables[0].Rows[0]["s_name"].ToString();
                //sc_note = ds.Tables[0].Rows[0]["note"].ToString();

                //string sql_xs = "select count(id) from tb_User where Classid='" + id + "' and GroupId=1";//学生
                //string sql_ls = "select count(id) from tb_User where Classid='" + id + "' and GroupId=5";//老师
                //string sql_xz = "select count(id) from tb_User where Classid='" + id + "' and GroupId=6";//校长
                //string sql_cp = "select COUNT(Fresultid) from t_exam_results where Fresultid in(select id from tb_User where Classid=19 and GroupId=1)";//测评数
                //c_xs = HXD.DBUtility.SQLHelper.ExecuteScalar(sql_xs).ToString();
                //c_ls = HXD.DBUtility.SQLHelper.ExecuteScalar(sql_ls).ToString();
                //c_xz = HXD.DBUtility.SQLHelper.ExecuteScalar(sql_xz).ToString();
                //c_cp = HXD.DBUtility.SQLHelper.ExecuteScalar(sql_cp).ToString();

                //string df1 = "select COUNT(Fresultid) from t_exam_results where Fresultid in(select id from tb_User where Classid=19 and GroupId=1) and Fpaperid=1 and Fscore<161";
                //string df2 = "select COUNT(Fresultid) from t_exam_results where Fresultid in(select id from tb_User where Classid=19 and GroupId=1) and Fpaperid=1 and Fscore>161 and Fscore<181";
                //string df3 = "select COUNT(Fresultid) from t_exam_results where Fresultid in(select id from tb_User where Classid=19 and GroupId=1) and Fpaperid=1 and Fscore>181 and Fscore<201";
                //string df4 = "select COUNT(Fresultid) from t_exam_results where Fresultid in(select id from tb_User where Classid=19 and GroupId=1) and Fpaperid=1 and Fscore>200";
                //s_Fscore1 = HXD.DBUtility.SQLHelper.ExecuteScalar(df1).ToString();
                //s_Fscore2 = HXD.DBUtility.SQLHelper.ExecuteScalar(df2).ToString();
                //s_Fscore3 = HXD.DBUtility.SQLHelper.ExecuteScalar(df3).ToString();
                //s_Fscore4 = HXD.DBUtility.SQLHelper.ExecuteScalar(df4).ToString();

                //string sqldb = "select top 6 * from tb_User where Classid='" + id + "' and GroupId=1";
                //Repeater1.DataSource = HXD.DBUtility.SQLHelper.ExecuteDataset(sqldb);
                //Repeater1.DataBind();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.SessionState;

public partial class User_twolist : System.Web.UI.Page
{
    protected string sc_name = "", u_name = "", cs_cun = "", yy_cun = "", tz_cun="";
    protected int userid=0;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdManage();
        if (!IsPostBack)
        {

            string sname = Session["AdminManage"].ToString();
            string MenuId = Session["userid"].ToString();
            userid = int.Parse(MenuId);
            string sql_mid = "select Classid from tb_User where id=" + userid;
            int scholl_id = int.Parse(HXD.DBUtility.SQLHelper.ExecuteScalar(sql_mid).ToString());

            string sql_school = "select s_name from tb_U_school where ID=" + scholl_id;
            sc_name = HXD.DBUtility.SQLHelper.ExecuteScalar(sql_school).ToString();
            string user_name = "select Name from tb_U_User where ID=" + MenuId;
            u_name = HXD.DBUtility.SQLHelper.ExecuteScalar(user_name).ToString();

            //string sql = "select * from tb_User where ID=" + MenuId;
            //DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
           
            //icd = ds.Tables[0].Rows[0]["id"].ToString();
            string cscun = "select COUNT(id) from t_exam_results where FstudentNo='" + sname + "'";

            cs_cun = HXD.DBUtility.SQLHelper.ExecuteScalar(cscun).ToString();
            //cid 1=测评  2=预约  3=辅导 4=消息
            string yycun = "select COUNT(id) from tb_U_Message where uid='" + MenuId + "' and cid=2";
            yy_cun = HXD.DBUtility.SQLHelper.ExecuteScalar(yycun).ToString();


            string tzcun = "select COUNT(id) from tb_U_Message where uid='" + MenuId + "' and cid=4";
            tz_cun = HXD.DBUtility.SQLHelper.ExecuteScalar(tzcun).ToString();

        }


    }
}
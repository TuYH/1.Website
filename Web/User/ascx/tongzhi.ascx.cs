using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_ascx_tongzhi : System.Web.UI.UserControl
{
    protected string Menuname = "";
    protected int Msgcun = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdManage();
        string MenuId = Session["userid"].ToString();
        string sql22 = "SELECT name from tb_U_user where id=" + MenuId;
        Menuname = HXD.DBUtility.SQLHelper.ExecuteScalar(sql22).ToString();

        
        string sql_mid = "select Classid from tb_User where id=" + MenuId;
        int scholl_id = int.Parse(HXD.DBUtility.SQLHelper.ExecuteScalar(sql_mid).ToString());
        //cid 1=测评  2=预约  3=辅导 4=消息
        string sql = "select COUNT(id) from tb_U_Message where ClassId=" + scholl_id + "and zxs_id='" + MenuId + "' and IsStatus=0 and cid=4";

        Msgcun = int.Parse(HXD.DBUtility.SQLHelper.ExecuteScalar(sql).ToString());
    }
}
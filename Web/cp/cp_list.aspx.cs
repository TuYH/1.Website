using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cp_cp_list : System.Web.UI.Page
{
    protected string wid = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdManage();
        //string uid = Session["userid"].ToString();
        //string setting = LoginCheck.LbManage(int.Parse(uid));
        //setting = setting.Substring(1);
        //setting = setting.Substring(0, setting.Length - 1);
        //setting = setting.Replace("m", "0");
        wid = Request.QueryString["wid"].ToString();
        string setting =Request.QueryString["set"].ToString();
        string sql = "select * from t_exam_paper where  Fpaperid in(" + setting + ")";
        Repeater1.DataSource = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
        Repeater1.DataBind();
    }
}
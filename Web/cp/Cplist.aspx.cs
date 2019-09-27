using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cp_Cplist : System.Web.UI.Page
{
    protected string wid = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdManage(1);
        string uid=Session["userid"].ToString();
       string setting= LoginCheck.LbManage(int.Parse(uid));
       wid = Request.QueryString["wid"].ToString();
       setting = setting.Substring(1);
       setting = setting.Substring(0,setting.Length-1);
       setting = setting.Replace("m","0");
       string sql = "select * from t_exam_paper where Fpapertype=1 and Fpaperid in(" + setting + ")";
        Repeater1.DataSource = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
        Repeater1.DataBind();
    }
}
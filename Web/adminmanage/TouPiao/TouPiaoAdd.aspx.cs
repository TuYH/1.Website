using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using HXD.Common;
public partial class adminmanage_TouPiao_TouPiaoAdd : System.Web.UI.Page
{
    protected int Pages = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdminManage();
        Pages = HXD.Common.StringDeal.ToInt(Request.QueryString["Page"]);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (this.TextBox1.Text.Trim() == string.Empty)
        { Jscript.Alert("投票信息标题不能为空！", this.Page); }
        else if (this.Text1.Value.Trim() == string.Empty)
        { Jscript.Alert("到期时间不能为空！", this.Page); }
        else
        {
            HXD.SQLServerDAL.tb_U_TouPiao toupiaodal = new HXD.SQLServerDAL.tb_U_TouPiao();//投票操作类
            HXD.Model.tb_U_TouPiao toupiaomodel = new HXD.Model.tb_U_TouPiao();//投票属性类
            toupiaomodel.title = this.TextBox1.Text.Trim();
            toupiaomodel.is_Examine = this.CheckBox1.Checked ? 1 : 0;
            toupiaomodel.is_Recommendation = this.CheckBox2.Checked ? 1 : 0;
            toupiaomodel.end_time = Convert.ToDateTime(this.Text1.Value);
            toupiaomodel.VoteType = this.RadioButton1.Checked ? 1 : 2;
            if (toupiaodal.Add(toupiaomodel))
            { Jscript.AlertAndRedirect("投票信息添加成功！", "TouPiaoList.aspx?Page=" + Pages); }
            else
            { Jscript.Alert("投票信息添加失败！", this.Page); }
        }
    }
}

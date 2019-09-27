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
public partial class adminmanage_TouPiao_TouPiaoUpDate : System.Web.UI.Page
{
    public int id = 0, Pages = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdminManage();
        Pages = HXD.Common.StringDeal.ToInt(Request.QueryString["Page"]);
        id = HXD.Common.StringDeal.ToInt(Request.QueryString["id"]);
        if (!IsPostBack)
        { databiner(); }
    }

    public void databiner()
    {
        HXD.SQLServerDAL.tb_U_TouPiao toupiaodal = new HXD.SQLServerDAL.tb_U_TouPiao();
        HXD.Model.tb_U_TouPiao toupiaomodel = new HXD.Model.tb_U_TouPiao();
        toupiaomodel = toupiaodal.GetModel(id);
        this.TextBox1.Text = toupiaomodel.title.Trim();
        this.CheckBox1.Checked = toupiaomodel.is_Examine == 1 ? true : false;
        this.CheckBox2.Checked = toupiaomodel.is_Recommendation == 1 ? true : false;
        this.Text1.Value = toupiaomodel.end_time.ToString("yyyy-MM-dd HH:mm:ss");
        this.RadioButton1.Checked = toupiaomodel.VoteType == 1 ? true : false;
        this.RadioButton2.Checked = toupiaomodel.VoteType == 2 ? true : false;
        this.Literal1.Text = toupiaomodel.ReleaseTime.ToString("yyyy-MM-dd HH:mm:ss");
    }

    public void update()
    {        
        if (this.TextBox1.Text.Trim() == string.Empty)
        { Jscript.Alert("投票信息标题不能为空！", this.Page); }
        else if (this.Text1.Value.Trim() == string.Empty)
        { Jscript.Alert("到期时间不能为空！", this.Page); }
        else
        {
            HXD.SQLServerDAL.tb_U_TouPiao toupiaodal = new HXD.SQLServerDAL.tb_U_TouPiao();//投票操作类
            HXD.Model.tb_U_TouPiao toupiaomodel = new HXD.Model.tb_U_TouPiao();//投票属性类
            toupiaomodel.id = id;
            toupiaomodel.title = this.TextBox1.Text.Trim();
            toupiaomodel.is_Examine = this.CheckBox1.Checked ? 1 : 0;//是否审核
            toupiaomodel.is_Recommendation = this.CheckBox2.Checked ? 1 : 0;//是否推荐
            toupiaomodel.end_time = Convert.ToDateTime(this.Text1.Value);
            toupiaomodel.VoteType = this.RadioButton1.Checked ? 1 : 2;
            if (toupiaodal.Update(toupiaomodel))
            { Jscript.AlertAndRedirect("投票信息修改成功！", "TouPiaoList.aspx?Page=" + Pages); }
            else
            { Jscript.Alert("投票信息修改失败！", Page); return; }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        update();
    }
}

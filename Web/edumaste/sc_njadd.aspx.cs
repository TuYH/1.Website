using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class edumaste_sc_njadd : System.Web.UI.Page
{
    protected string nian = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            nian = DateTime.Now.Year.ToString();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        nian = DateTime.Now.Year.ToString();
        string userid = Session["userid"].ToString();
        string sqlcl = "select classid from tb_user where id=" + userid;
        string MenuId = HXD.DBUtility.SQLHelper.ExecuteScalar(sqlcl).ToString();

        int text1 = int.Parse(this.TextBox1.Text);//7
        int a = int.Parse(this.s123.Value);

        
        string sql = "";
        for (int i = 0; i < a; i++)
        {
            int nian2 = int.Parse(nian) - i;
            int text2 = text1 + i;
             sql += "insert into tb_U_schoolfl (title,CreateUsers,Sid,Depth,menuid)values('" + text2 + "','" + nian2 + "','" + MenuId + "','0','2')";
            
        }
        HXD.DBUtility.SQLHelper.ExecuteScalar(sql);
      
      
        Response.Redirect("sc_nj.aspx");
    }
}
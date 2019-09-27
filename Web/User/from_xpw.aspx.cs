using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using HXD.Common;

public partial class User_from_xpw : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdManage(1);
        if (!IsPostBack)
        {
            //string sql = "select classid from tb_user where ID=" + Session["userid"].ToString();
            //string xz_id = HXD.DBUtility.SQLHelper.ExecuteScalar(sql).ToString();

         
            //bdinfo();
        }
    }
   
   
    protected void Button1_Click(object sender, EventArgs e)
    {
        string username = Session["AdminManage"].ToString();
        string MenuId = Session["userid"].ToString();

        string jiupwd = Encryp.DESEncrypt(this.jiupwd.Text);
        string xinpwd1 = this.xinpwd1.Text;
        string xinpwd2 = this.xinpwd2.Text;
        string sql2 = "select * from tb_User where UserPwd='" + jiupwd + "' and id='" + MenuId + "'";
        DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sql2);
         if (ds.Tables[0].Rows.Count > 0)
         {
             if (xinpwd1 != "")
             {
                 if (xinpwd1 == xinpwd2)
                 {
                     string sql = "update tb_User set UserPwd='" + Encryp.DESEncrypt(xinpwd1) + "' where id='" + MenuId + "'";
                     HXD.DBUtility.SQLHelper.ExecuteScalar(sql);
                     StringDeal.Alter("修改成功！", "twolist.aspx");
                 }
                 else
                 {
                     StringDeal.Alter("2次新密码不一致！");
                 }
             }
             else
             {
                 StringDeal.Alter("新密码不能为空！");
             }



           
         }
         else
         {
             StringDeal.Alter("原新密码错误！请重新输入");
         }
        
    }
}
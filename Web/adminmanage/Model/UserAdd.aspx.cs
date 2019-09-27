using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using HXD.BLL;
using HXD.Model;
using HXD.Common;
public partial class adminmanage_Model_UserAdd : System.Web.UI.Page
{
    protected mTable mT = new mTable();
    protected bTable bT = new bTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdminManage();
        
    }



    protected void Button2_Click(object sender, EventArgs e)
    {
        string MenuId = Request.QueryString["MenuId"].ToString();
        string username = this.username.Text.Trim();
        string userpwd = Encryp.DESEncrypt(this.userpwd.Text.Trim());

        string tell = this.Texttell.Text.Trim();
        string xname = this.Textname.Text.Trim();

        string sqls = "select * from tb_User where UserName='" + username + "'";
        DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sqls);
        if (ds.Tables[0].Rows.Count == 0)
        {
            string sql = "insert into tb_User(UserName,UserPwd,GroupId,classid,islock)values('" + username + "','" + userpwd + "',6,'" + MenuId + "',1)";
            HXD.DBUtility.SQLHelper.ExecuteScalar(sql);
            //Session["AdminManage"] = username;

            System.Threading.Thread.Sleep(1000);
            string sql2 = "select id from tb_User where UserName='" + username + "' and datediff(mi,RegTime,getdate())<=1";
            string icd = HXD.DBUtility.SQLHelper.ExecuteScalar(sql2).ToString();
            //Session["userid"] = icd;
            string sql3 = "insert into tb_U_User (Id,Tel,name)values('" + icd + "','" + tell + "','" + xname + "')";
            HXD.DBUtility.SQLHelper.ExecuteScalar(sql3);
            StringDeal.Alter("添加成功！");
        }
        else
        {
            Response.Write("用户名已存在");
        }
    }
    
}
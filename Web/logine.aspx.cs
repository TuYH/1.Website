using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HXD.Common;
using System.Data;
using System.Diagnostics;

public partial class logine : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoginCheck.AdminSq();
            /*           Process kbpr = System.Diagnostics.Process.Start("osk.exe"); // 打开系统键盘
                       if (kbpr.HasExited)
                       {
                           kbpr = System.Diagnostics.Process.Start("osk.exe");
                       }*/
        }
    }




    protected void Button1_Click1(object sender, EventArgs e)
    {
        string xsurl = "";

        // if((Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "")
        if (Request.QueryString["ReturnUrl"] != null)
        {

            xsurl = Request.QueryString["ReturnUrl"].ToString();
            xsurl = xsurl.Replace("[@]", "&");
        }
        else
        {
            xsurl = "user/twolist.aspx";
        }
        string url = "";

        string uname = this.username.Value;
        uname = uname.Replace("'", "");
        uname = HXD.Common.StringDeal.RemoveUnsafeHtml(uname);

        string userpsw = Encryp.DESEncrypt(this.pwd.Value);
        string classid = LoginCheck.getadminid();
        string sql = "select * from tb_User where UserName='" + uname + "' and UserPwd='" + userpsw + "' and classid='" + classid + "'";
        DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            bool stra = bool.Parse(ds.Tables[0].Rows[0]["islock"].ToString());

            if (stra == true)
            {
                Session["AdminManage"] = ds.Tables[0].Rows[0]["UserName"].ToString();
                Session["userid"] = ds.Tables[0].Rows[0]["id"].ToString();
                int groupid = int.Parse(ds.Tables[0].Rows[0]["GroupId"].ToString());

                switch (groupid)
                {
                    case 7://局长
                        url = "Edu/ulist.aspx";
                        break;
                    case 6://校长
                        url = "edumaste/olist.aspx";
                        break;
                    case 5://老师
                        url = "user/tlist.aspx";
                        break;
                    case 1://学生
                        url = xsurl;
                        break;
                    default:
                        break;
                }
                Response.Redirect(url);
            }
            else
            {
                Response.Redirect("user/");
            }

        }
        else
        {
            Response.Write("用户名或密码错误");
        }
    }
}
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
using ptw.FileManager.Web.Processor.Manage;
public partial class adminmanage_FileManager_Default : System.Web.UI.Page
{
    protected string loginResult = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdminManage();
        if (Request.QueryString["act"] == "check")
        {
            LoginProcessor login = new LoginProcessor();
            if (login.LoginState)
            {
                Response.Redirect("Manage/Main.aspx");
            }
            else
            {
                loginResult = login.Value;
            }
        }
    }
}

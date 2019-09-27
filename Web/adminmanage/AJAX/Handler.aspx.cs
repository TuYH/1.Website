using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class adminmanage_AJAX_Handler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdminManage();
        Response.ContentType = "text/plain";
        if (Request.QueryString["File"] != null)
        {
            string files = Request.QueryString["File"].ToString();
            if (files.IndexOf("/") == 0)
            {
                string imgico = files.Insert(files.LastIndexOf("/"), "/ico");
                HXD.Common.FileOperate.DeleteFile(files);
                HXD.Common.FileOperate.DeleteFile(imgico);
            }
        }
    }
}

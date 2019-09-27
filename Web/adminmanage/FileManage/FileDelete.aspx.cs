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
using HXD.Common;

public partial class adminmanage_FileManage_FileDelete : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdminManage();
        string UploadPath = Request.QueryString["UploadPath"];
        if (String.IsNullOrEmpty(UploadPath))
        {
            UploadPath = "../../Upload/";
        }
        string FileName = Request.QueryString["FileName"];
        Files.DeleteFile(UploadPath + FileName);
        Files.DeleteFile(UploadPath + "ico/" + FileName);
    }
}

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
using ptw.FileManager.Model;
using ptw.FileManager.Web.Processor;
using System.IO;
using System.Collections.Generic;
public partial class adminmanage_FileManager_Manage_Main : System.Web.UI.Page
{
    protected string backHtml;
    protected string folderPath = HttpContext.Current.Request.QueryString["path"];
    protected System.Text.StringBuilder currPath = new System.Text.StringBuilder("");
    protected int folderNum = 0;
    protected int fileNum = 0;
    protected System.Text.StringBuilder builder = new System.Text.StringBuilder("");
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdminManage();
        //if (Session["FileName"] == null)
        //{
        //    Response.Redirect("../Default.aspx");
        //}

        //// 注销
        //if (Request.QueryString["act"] == "logout")
        //{
        //    Session.Clear();
        //    Response.Redirect("../Default.aspx");
        //}

        // 操作处理
        FileManagerProcessor fileManage = new FileManagerProcessor(Request.QueryString["act"]);
        builder.Append(fileManage.Value);

        if (string.IsNullOrEmpty(folderPath))
        {
            folderPath = FileManagerProcessor.PagePath();
        }

        // 组合路径, 快速导航
        string comePath = "";
        foreach (string q in folderPath.Split('\\'))
        {
            comePath += q;
            currPath.AppendFormat("<a href=\"Main.aspx?path={1}\">{0}</a>", q + "\\", comePath);
            comePath += "\\";
        }

        // 返回上级
        if (new DirectoryInfo(folderPath).Root.ToString().Replace("\\", "") != folderPath.ToUpper())
        {
            string previousFolder = folderPath.Substring(0, folderPath.LastIndexOf("\\"));
            backHtml = "<tr class=\"m-row2\"><td colspan=\"5\"><a href=\"Main.aspx?path=" + Server.UrlEncode(previousFolder) + "\"><img src=\"../Images/IcoLeft.gif\" alt=\"返回上级\" align=\"absmiddle\" /> 返回上级</a></td></tr>";
        }
        else
        {
            folderPath += "\\";
        }

        // 绑定数据
        fileManage = new FileManagerProcessor();
        List<FileFolderInfo> files = fileManage.GetDirectories(folderPath.Replace(FileManagerProcessor.PagePath1(), ""));

        if (fileManage.Access)
        {
            folderNum = fileManage.FolderNum;
            fileNum = fileManage.FileNum;

            rptList.DataSource = files;
            rptList.DataBind();
        }
        else
        {
            builder.Append("无权限访问该目录. <a href='javascript:history.go(-1);' style='font-weight: normal'>后退</a>");
        }


        if (builder.ToString() != "")
        {
            string builderResult = builder.ToString();
            builder = new System.Text.StringBuilder("");
            builder.AppendFormat("<script type=\"text/javascript\">$(\"#tips\").show(); $(\"#tipsMsg\").html(\"{0}\"); </script>", builderResult.Replace(@"\", @"\\"));
        }
    }
}

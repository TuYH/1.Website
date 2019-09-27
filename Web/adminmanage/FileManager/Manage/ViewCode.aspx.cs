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
using ptw.FileManager.Web.Processor;
using System.IO;
public partial class adminmanage_FileManager_Manage_ViewCode : System.Web.UI.Page
{
    protected string highLighterJs;
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdminManage();
        string filePath = Request.QueryString["objfile"];
        if (File.Exists(filePath))
        {
            string fileContent;
            string getEncode;
            string highLighterType = "";
            switch (Path.GetExtension(filePath).ToLower())
            {
                case ".c":
                case ".cpp":
                    highLighterType = "cpp";
                    highLighterJs = "shBrushCpp.js";
                    break;
                case ".cs":
                    highLighterType = "csharp";
                    highLighterJs = "shBrushCSharp.js";
                    break;
                case ".css":
                    highLighterType = "css";
                    highLighterJs = "shBrushCss.js";
                    break;
                case ".java":
                case ".jsp":
                    highLighterType = "java";
                    highLighterJs = "shBrushJava.js";
                    break;
                case ".js":
                    highLighterType = "javascript";
                    highLighterJs = "shBrushJScript.js";
                    break;
                case ".php":
                    highLighterType = "php";
                    highLighterJs = "shBrushPhp.js";
                    break;
                case ".sql":
                    highLighterType = "sql";
                    highLighterJs = "shBrushSql.js";
                    break;
                case ".vb":
                    highLighterType = "vb";
                    highLighterJs = "shBrushVb.js";
                    break;
                case ".xml":
                case ".htm":
                case ".html":
                case ".aspx":
                    highLighterType = "xml";
                    highLighterJs = "shBrushXml.js";
                    break;
            }
            new FileManagerProcessor().ReadTextFile(filePath, out fileContent, out getEncode);
            txtHighLighter.Text = fileContent;
            txtHighLighter.CssClass = highLighterType;
        }
        else
        {
            Response.Clear();
            Response.StatusCode = 404;
            Response.StatusDescription = "Not Found";
            Response.Status = "404 Not Found";
            Response.Write("404 Not Found");
            Response.End();
        }
    }
}

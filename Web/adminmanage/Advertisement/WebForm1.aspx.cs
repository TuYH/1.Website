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
using System.Text;

public partial class adminmanage_Advertisement_WebForm1 : System.Web.UI.Page
{
    private string _path = "/Upload";
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdminManage();
        if (Request.QueryString["_path"] != null)
        { _path = Request.QueryString["_path"]; }
        if (!IsPostBack)
        { binder(); }
    }
    public void binder()
    {
        this.Literal1.Text = pathSplit(_path);
        this.DataList1.DataSource = HXD.Common.FileObj.GetFileDirAll("/Upload/", Server.MapPath("~" + _path + "/"));
        this.DataList1.DataBind();
    }

    private string pathSplit(string path)
    {
        string[] paths = path.Split('/');
        StringBuilder strs = new StringBuilder();
        string temp = "";
        for (int i = 0; i < paths.Length; i++)
        {
            if (paths[i] != "")
            {
                temp += "/" + paths[i];
                strs.Append("<a href=\"?_path=" + temp + "\">/" + paths[i] + "</a>");
            }
        }
        return strs.ToString();
    }

    public string fileinfos(string filename, string filetype)
    {
        if (filetype == "file")
        { return "<a href=\"javascript:void(0);\" onclick=\"send('" + filename + "')\"><img border=\"0\" id=\"img1\" src=\"" + filename + "\" alt=\"\" width=\"128px\" height=\"128px\"/></a>"; }
        else if (filetype == "dir")
        { return "<a href=\"?_path=" + filename + "\"><img border=\"0\" id=\"img2\" src=\"../Images/Png/文件夹图标下载14.png\" alt=\"\" width=\"128px\" height=\"128px\"/></a>"; }
        else
        { return ""; }
    }
}

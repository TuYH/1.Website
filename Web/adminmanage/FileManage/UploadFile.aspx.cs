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
using System.IO;
using Telerik.WebControls;

public partial class adminmanage_FileManage_UploadFile : System.Web.UI.Page
{
    protected string InputName, UploadFileType;
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdminManage();
        InputName = Request.QueryString["InputName"];
        UploadFileType = Request.QueryString["UploadFileType"];
        if (!IsPostBack)
        {
            GetConfigInfo();
        }
    }

    #region 提交后保存
    /// <summary>
    /// 提交后保存
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        string UploadFileName = "";
        string UploadType = Request.Form["Upload"];                          //文件方式
        int FileSize = StringDeal.ToInt(GetConfig.File("FileSize"));         //文件最大上传
        string UploadFilePath = GetConfig.File("UploadFilePath");            //文件上传路径          
        string SelectFile = Request.Form["SelectFile"];                      //选择服务器上的文件名
        string WebUrl = Request.Form["WebUrl"];                              //网络文件地址
        if (String.IsNullOrEmpty(UploadFilePath))
        {
            UploadFilePath = "../../Upload/File/";
        }
        if (FileSize == 0)
        {
            FileSize = 1020000;
        }
        else
        {
            FileSize = FileSize * 1024;
        }
        if (UploadType == "upload1")
        {
            UploadFilePath = UploadFilePath + DateTime.Today.ToString("yyyyMM") + "/";
            Files.CreateFolder(UploadFilePath);
            #region 大文件上传
            try
            {
                foreach (Telerik.WebControls.UploadedFile file in RadUploadContext.Current.UploadedFiles)
                {
                    if (file.FileName != "")
                    {
                        if (file.ContentLength > FileSize)
                        {
                            StringDeal.Alter("文件大小不能超过" + FileSize / 1024 + "KB");
                        }
                        else if (FormatUploadType(file.FileName))
                        {
                            string FileExt = file.GetExtension();
                            System.Threading.Thread.Sleep(1000);
                            string FileName = StringDeal.GetGuid() + FileExt;
                            file.SaveAs(this.Server.MapPath(UploadFilePath + FileName), true);
                            Response.StatusCode = 200;
                            UploadFileName = UploadFilePath + FileName;
                        }
                        else
                        {
                            StringDeal.Alter("上传文件格式不正确！");
                        }
                    }
                }
            }
            catch
            {

            }
            #endregion
        }
        else if (UploadType == "upload2")
        {
            #region 选择服务器上的保存
            UploadFileName = SelectFile;
            #endregion
        }
        else
        {
            #region 输入网络文件地址保存
            UploadFileName = WebUrl;
            #endregion
        }
        
        Response.Write("<script language='javascript' type='text/javascript'>window.parent.loadinndlg().document.getElementById('" + InputName + "').value='" + UploadFileName + "';window.parent.cancel();</script>");
    }
    #endregion

    #region 获取全局配置信息
    /// <summary>
    /// 获取全局配置信息
    /// </summary>
    protected void GetConfigInfo()
    {
        string temp = "";
        if (GetConfig.File("IsSelectFile") == "False")
        {
            temp += "UpLoadType('upload1');\n$('#IsSelectFile').hide();\n";
        }
        if (GetConfig.File("IsUploadFile") == "False")
        {
            temp += "UpLoadType('upload3');\n$('#IsUploadFile').hide();\n";
        }
        temp += "var parentval = window.parent.loadinndlg().document.getElementById('" + InputName + "').value;\n";
        temp += "if(parentval.length>0){\n";
        temp += "   if(parentval.substring(0,7).toLowerCase()=='http://'){\n";
        temp += "       UpLoadType('upload3');\n";
        temp += "       $('#WebUrl').val(parentval);\n";
        temp += "   }\n";
        temp += "   else{\n";
        temp += "       UpLoadType('upload2');\n";
        temp += "       $('#SelectFile').val(parentval);\n";
        temp += "       PreviewImg($('#SelectFile').val().replace('~',''));\n";
        temp += "   }\n";
        temp += "}\n";
        this.JavascriptServer.Text = temp;
    }
    #endregion

    #region 判断上传文件格式是否正确
    /// <summary>
    /// 判断上传文件格式是否正确
    /// </summary>
    /// <param name="UploadType">文件类型</param>
    /// <param name="FileExt">上传的文件扩展名</param>
    /// <returns></returns>
    protected bool FormatUploadType(string FileExt)
    {
        if (StringDeal.GetExtNameIsArry("asp,aspx,php,js,jsp".Split(','), FileExt))
        {
            return false;
        }
        else
        {
            string VideoType = GetConfig.File("VideoType");
            string AudioType = GetConfig.File("AudioType");
            string SoftType = GetConfig.File("SoftType");
            string OtherType = GetConfig.File("OtherType");                        //允许文件类型    
            if (UploadFileType == "VideoType")
            {
                return StringDeal.GetExtNameIsArry(VideoType.Split(','), FileExt);
            }
            else if (UploadFileType == "AudioType")
            {
                return StringDeal.GetExtNameIsArry(AudioType.Split(','), FileExt);
            }
            else if (UploadFileType == "SoftType")
            {
                return StringDeal.GetExtNameIsArry(SoftType.Split(','), FileExt);
            }
            else if (UploadFileType == "OtherType")
            {
                return StringDeal.GetExtNameIsArry(OtherType.Split(','), FileExt);
            }
            else
            {
                return true;
            }
        }
    }
    #endregion
}

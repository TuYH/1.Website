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

public partial class adminmanage_FileManage_Upload : System.Web.UI.Page
{
    protected string UploadPath, FileType, InputName;
    protected int FileSize;
    protected string ThumbnailSize;
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdminManage();
        LoadConfig();
        this.Files.Attributes.Add("class", "input validate-file-"+FileType.Replace("|","-"));
    }

    /// <summary>
    /// 上传
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnUpload_Click(object sender, EventArgs e)
    {
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
                    else if (StringDeal.GetExtNameIsArry(FileType.Split('|'), file.FileName))
                    {
                        string FileExt = file.GetExtension();
                        System.Threading.Thread.Sleep(1000);
                        string FileName = StringDeal.GetGuid() + FileExt;
                        file.SaveAs(this.Server.MapPath(UploadPath + FileName), true);
                        Response.StatusCode = 200;
                        #region 生成缩略图
                        if (!String.IsNullOrEmpty(ThumbnailSize) && StringDeal.GetExtNameIsArry("gif|jpg|jpeg|png|bmp".Split(','), FileName))
                        {
                            Thumbnail th = new Thumbnail();
                            th.FileName = FileName;
                            th.OriginalImagePath = UploadPath;
                            th.Width = StringDeal.ToInt(ThumbnailSize.Split('*')[0]);
                            th.Height = StringDeal.ToInt(ThumbnailSize.Split('*')[1]);
                            th.MakeThumbnail();
                        }
                        #endregion
                        this.uptd.Visible = false;
                        this.but_close.Visible = false;
                        this.but_over.Visible = true;
                        this.btnUpload.Visible = false;
                        Response.Write("<script language='javascript' type='text/javascript'>window.parent.$('" + InputName + "').value='" + FileName + "';window.parent.$('upid').innerHTML = '删除';</script>");
                    }
                }
            }
        }
        catch
        {
            
        }
    }

    #region 获取参数
    /// <summary>
    /// 获取参数
    /// </summary>
    protected void LoadConfig()
    {
        UploadPath = Request.QueryString["UploadPath"];//上路径
        FileSize = StringDeal.ToInt(Request.QueryString["FileSize"]);//文件大小
        FileType = Request.QueryString["FileType"];//文件类型,以|阁开
        ThumbnailSize = Request.QueryString["ThumbnailSize"];//如果是图片,缩略图尺寸(120*88)
        InputName = Request.QueryString["InputName"];
        if (String.IsNullOrEmpty(UploadPath))
        {
            UploadPath = "../../Upload/";
        }
        if (FileSize == 0)
        {
            FileSize = 1020000;
        }
        else
        {
            FileSize = FileSize * 1024;
        }
        if (String.IsNullOrEmpty(FileType))
        {
            FileType = "jpg|gif|png|bmp|jpeg|rar|zip|doc|xls|ppt|codx|xlsx|pptx";
        }
    }
    #endregion
}

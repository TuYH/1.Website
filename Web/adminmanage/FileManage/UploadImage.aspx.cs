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

public partial class adminmanage_FileManage_UploadImage : System.Web.UI.Page
{
    protected string InputName;
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdminManage();
        InputName = Request.QueryString["InputName"];
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
       // mapFilePath = HttpContext.Current.Server.MapPath(filePath);
        string UploadImageName = "";
        string UploadType = Request.Form["Upload"];                             //图片方式
        int ImageSize = StringDeal.ToInt(GetConfig.Image("ImageSize"));         //图片最大上传
        string UploadImagePath = GetConfig.Image("UploadImagePath");            //图片上传路径
        string ImageType = GetConfig.Image("ImageType");                        //允许图片类型
        bool IsThumbnail = StringDeal.ToBool(Request.Form["IsThumbnail"]);      //是否生成缩略图
        int ThumbWidth = StringDeal.ToInt(Request.Form["ThumbWidth"]);          //缩略图宽
        int ThumbHeight = StringDeal.ToInt(Request.Form["ThumbHeight"]);        //缩略图高
        string ThumbMode = Request.Form["ThumbMode"];
        bool IsWatermark = StringDeal.ToBool(Request.Form["IsWatermark"]);      //加水印
        string WatermarkImage = GetConfig.Image("WatermarkImage");              //水印图地址
        int WatermarkPos = StringDeal.ToInt(GetConfig.Image("WatermarkPos"));   //水印放置位置                 
        string SelectImage = Request.Form["SelectImage"];                       //选择服务器上的图片名
        string WebUrl = Request.Form["WebUrl"];                                 //网络图片地址
        if (String.IsNullOrEmpty(UploadImagePath))
        {
            UploadImagePath = "../../Upload/image/";
        }
        if (ImageSize == 0)
        {
            ImageSize = 1020000;
        }
        else
        {
            ImageSize = ImageSize * 1024;
        }
        if (String.IsNullOrEmpty(ImageType))
        {
            ImageType = "jpg,gif,png,bmp,jpeg";
        }
        if (UploadType == "upload1")
        {
            UploadImagePath = UploadImagePath + DateTime.Today.ToString("yyyyMM") + "/";
            Files.CreateFolder(UploadImagePath);
            #region 大文件上传
            try
            {
                foreach (Telerik.WebControls.UploadedFile file in RadUploadContext.Current.UploadedFiles)
                {
                    System.Drawing.Image image = System.Drawing.Image.FromStream(file.InputStream);
                    if (file.FileName != "")
                    {
                        if (file.ContentLength > ImageSize)
                        {
                            StringDeal.Alter("文件大小不能超过" + ImageSize / 1024 + "KB");
                        }
                        else if (StringDeal.GetExtNameIsArry(ImageType.Split(','), file.FileName))
                        {
                            string FileExt = file.GetExtension();
                            System.Threading.Thread.Sleep(1000);
                            string FileName = StringDeal.GetGuid() + FileExt;
                            file.SaveAs(this.Server.MapPath(UploadImagePath + FileName), true);
                            Response.StatusCode = 200;
                            #region 生成缩略图
                            if (IsThumbnail)
                            {
                                Thumbnail th = new Thumbnail();
                                th.Mode = ThumbMode;
                                th.FileName = FileName;
                                th.OriginalImagePath = UploadImagePath;
                                th.Width = ThumbWidth;
                                th.Height = ThumbHeight;
                                th.MakeThumbnail();
                            }
                            #endregion
                            UploadImageName = UploadImagePath + FileName;
                        }
                        else
                        {
                            StringDeal.Alter("上传图片格式不正确！");
                        }
                    }
                    image.Dispose();
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
            if (IsThumbnail)
            {
                if (SelectImage != string.Empty)
                {
                    if (!HXD.Common.Utils.IsUrl(SelectImage))
                    {
                        if (HXD.Common.Utils.isPhotoIco(SelectImage))
                        {
                            System.IO.File.Delete(Server.MapPath("~" + HXD.Common.Utils.PhotoIco(SelectImage)));
                        }
                        string FileName = string.Empty;
                        FileName = SelectImage.Substring(SelectImage.LastIndexOf('/') + 1);
                        UploadImagePath = SelectImage.Remove(SelectImage.LastIndexOf('/') + 1);
                        Thumbnail th = new Thumbnail();
                        th.Mode = ThumbMode;
                        th.FileName = FileName;
                        th.OriginalImagePath = UploadImagePath;
                        th.Width = ThumbWidth;
                        th.Height = ThumbHeight;
                        th.MakeThumbnail();
                    }
                }
            }
            UploadImageName = SelectImage;
            #endregion
        }
        else
        {
            #region 输入网络图片地址保存
            UploadImageName = WebUrl;
            #endregion
        }
        
        Response.Write("<script language='javascript' type='text/javascript'>window.parent.loadinndlg().document.getElementById('" + InputName + "').value='" + UploadImageName + "';window.parent.cancel();</script>");
    }
    #endregion

    #region 获取全局配置信息
    /// <summary>
    /// 获取全局配置信息
    /// </summary>
    protected void GetConfigInfo()
    {
        string temp = "";
        if (GetConfig.Image("IsSelectImage") == "False")
        {
            temp += "UpLoadType('upload1');\n$('#IsSelectImage').hide();\n";
        }
        if (GetConfig.Image("IsUploadImage") == "False")
        {
            temp += "UpLoadType('upload3');\n$('#IsUploadImage').hide();\n";
        }
        if (GetConfig.Image("IsWatermark") == "True")
        {
            temp += "$('#IsWatermark').attr('checked','checked');\n";
        }
        if (GetConfig.Image("IsThumbnail") == "True")
        {
            temp += "$('#IsThumbnail').attr('checked','checked');\n";
            try
            {
                string Width = "", Height = "";
                if (Request.QueryString["CID"].ToString() == "")
                {
                    Width = "0";
                    Height = "0";
                }
                else
                {
                    Width = GetConfig.Image("ThumbnailSize").Split('*')[0];
                    Height = GetConfig.Image("ThumbnailSize").Split('*')[1];
                }
                temp += "$('#ThumbWidth').val('" + Width + "');\n";
                temp += "$('#ThumbHeight').val('" + Height + "');\n";
            }
            catch { }
        }
        temp += "IsThumbnails('IsThumbnail');\n";
        temp += "var parentval = window.parent.loadinndlg().document.getElementById('" + InputName + "').value;\n";
        temp += "if(parentval.length>0){\n";
        temp += "   if(parentval.substring(0,7).toLowerCase()=='http://'){\n";
        temp += "       UpLoadType('upload3');\n";
        temp += "       $('#WebUrl').val(parentval);\n";
        temp += "   }\n";
        temp += "   else{\n";
        temp += "       UpLoadType('upload2');\n";
        temp += "       $('#SelectImage').val(parentval);\n";
        temp += "       PreviewImg($('#SelectImage').val().replace('~',''));\n";
        temp += "   }\n";
        temp += "}\n";
        this.JavascriptServer.Text = temp;
    }
    #endregion
}

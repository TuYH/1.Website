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
using HXD.Common;

public partial class adminmanage_Sys_SetConfig : System.Web.UI.Page
{
    XmlDoc xml = new XmlDoc();
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdminManage();
        string Action = Request.QueryString["Action"];
        if (!IsPostBack)
        {
            GetConfig(Action);
        }
        else
        {
            SetConfig(Action);
        }
    }

    protected void GetConfig(string Action)
    {
        DataSet ds;
        switch (Action)
        {
            case "file":
                #region 文件参数配置
                this.Title.Text = "文件参数配置";
                this.FileId.Visible = true;
                xml.xmlfilePath = "~/Config/fileConfig.config";
                ds = xml.GetDataSet();
                this.IsUploadFile.Text = ds.Tables[0].Rows[0]["IsUploadFile"].ToString();
                this.IsSelectFile.Text = ds.Tables[0].Rows[0]["IsSelectFile"].ToString();
                this.FileSize.Text = ds.Tables[0].Rows[0]["FileSize"].ToString();
                this.UploadFilePath.Text = ds.Tables[0].Rows[0]["UploadFilePath"].ToString();
                this.VideoType.Text = ds.Tables[0].Rows[0]["VideoType"].ToString();
                this.AudioType.Text = ds.Tables[0].Rows[0]["AudioType"].ToString();
                this.SoftType.Text = ds.Tables[0].Rows[0]["SoftType"].ToString();
                this.OtherType.Text = ds.Tables[0].Rows[0]["OtherType"].ToString();
                break;
                #endregion
            case "image":
                #region 图片参数配置
                this.Title.Text = "图片参数配置";
                this.ImageId.Visible = true;
                xml.xmlfilePath = "~/Config/ImageConfig.config";
                ds = xml.GetDataSet();
                this.IsUploadImage.Text = ds.Tables[0].Rows[0]["IsUploadImage"].ToString();
                this.IsSelectImage.Text = ds.Tables[0].Rows[0]["IsSelectImage"].ToString();
                this.ImageSize.Text = ds.Tables[0].Rows[0]["ImageSize"].ToString();
                this.UploadImagePath.Text = ds.Tables[0].Rows[0]["UploadImagePath"].ToString();
                this.ImageType.Text = ds.Tables[0].Rows[0]["ImageType"].ToString();
                this.IsWatermark.Text = ds.Tables[0].Rows[0]["IsWatermark"].ToString();
                this.WatermarkImage.Text = ds.Tables[0].Rows[0]["WatermarkImage"].ToString();
                this.WatermarkPos.Text = ds.Tables[0].Rows[0]["WatermarkPos"].ToString();
                this.IsThumbnail.Text = ds.Tables[0].Rows[0]["IsThumbnail"].ToString();
                this.ThumbnailSize.Text = ds.Tables[0].Rows[0]["ThumbnailSize"].ToString();
                break;
                #endregion
            case "email":
                #region 邮件参数配置
                this.Title.Text = "邮件参数配置";
                this.MailId.Visible = true;
                xml.xmlfilePath = "~/Config/MailConfig.config";
                ds = xml.GetDataSet();
                this.IsMail.Text = ds.Tables[0].Rows[0]["IsMail"].ToString();
                this.SendMailServer.Text = ds.Tables[0].Rows[0]["SendMailServer"].ToString();
                this.SendMailUserName.Text = ds.Tables[0].Rows[0]["SendMailUserName"].ToString();
                this.SendMailUserPwd.Attributes.Add("value", ds.Tables[0].Rows[0]["SendMailUserPwd"].ToString());
                this.ReceiveMail.Text = ds.Tables[0].Rows[0]["ReceiveMail"].ToString();
                this.MailSubject.Text = ds.Tables[0].Rows[0]["MailSubject"].ToString();
                this.MailTemplate.Text = ds.Tables[0].Rows[0]["MailTemplate"].ToString();
                break;
                #endregion
            case "user":
                #region 用户参数配置
                this.Title.Text = "用户参数配置";
                this.UserId.Visible = true;
                xml.xmlfilePath = "~/Config/UserConfig.config";
                ds = xml.GetDataSet();
                this.IsReg.Text = ds.Tables[0].Rows[0]["IsReg"].ToString();
                this.IsRegCode.Text = ds.Tables[0].Rows[0]["IsRegCode"].ToString();
                this.IsLoginCode.Text = ds.Tables[0].Rows[0]["IsLoginCode"].ToString();
                this.IsInvite.Text = ds.Tables[0].Rows[0]["IsInvite"].ToString();
                this.NotReg.Text = ds.Tables[0].Rows[0]["NotReg"].ToString();
                this.RegInfo.Text = ds.Tables[0].Rows[0]["RegInfo"].ToString();
                break;
                #endregion
            default:
                #region 网站参数配置
                this.Title.Text = "网站参数配置";
                this.SiteId.Visible = true;
                xml.xmlfilePath = "~/Config/SystemConfig.config";
                ds = xml.GetDataSet();
                this.SiteName.Text = ds.Tables[0].Rows[0]["SiteName"].ToString();
                this.SiteDomain.Text = ds.Tables[0].Rows[0]["SiteDomain"].ToString();
                this.ManagePath.Text = ds.Tables[0].Rows[0]["ManagePath"].ToString();
                this.IsManageCode.Text = ds.Tables[0].Rows[0]["IsManageCode"].ToString();
                this.CreateType.Text = ds.Tables[0].Rows[0]["CreateType"].ToString();
                this.HomeKeyWords.Text = ds.Tables[0].Rows[0]["HomeKeyWords"].ToString();
                this.HomeDescription.Text = ds.Tables[0].Rows[0]["HomeDescription"].ToString();
                this.CopyRight.Text = ds.Tables[0].Rows[0]["CopyRight"].ToString();
                this.ICP.Text = ds.Tables[0].Rows[0]["ICP"].ToString();
                this.ObstructCode.Text = ds.Tables[0].Rows[0]["ObstructCode"].ToString();
                this.TableXmlPath.Text = ds.Tables[0].Rows[0]["TableXmlPath"].ToString();
                break;
                #endregion
        }
    }

    protected void SetConfig(string Action)
    {
        string Field="", Val="";
        switch (Action)
        {
            case "file":
                #region 文件参数配置
                Field = "IsUploadFile,IsSelectFile,FileSize,UploadFilePath,VideoType,AudioType,SoftType,OtherType";
                Val = this.IsUploadFile.Text + "{$split$}";
                Val += this.IsSelectFile.Text + "{$split$}";
                Val += this.FileSize.Text + "{$split$}";
                Val += this.UploadFilePath.Text + "{$split$}";
                Val += this.VideoType.Text + "{$split$}";
                Val += this.AudioType.Text + "{$split$}";
                Val += this.SoftType.Text + "{$split$}";
                Val += this.OtherType.Text;
                xml.xmlfilePath = "~/Config/fileConfig.config";
                xml.DeleteNode("/File");
                xml.InsertNode("/File", Field.Split(','), Val.Split(new string[1] { "{$split$}" }, System.StringSplitOptions.None));

                break;
                #endregion
            case "image":
                #region 图片参数配置
                Field = "IsUploadImage,IsSelectImage,ImageSize,UploadImagePath,ImageType,IsWatermark,WatermarkImage,WatermarkPos,IsThumbnail,ThumbnailSize";
                Val = this.IsUploadImage.Text + "{$split$}";
                Val += this.IsSelectImage.Text + "{$split$}";
                Val += this.ImageSize.Text + "{$split$}";
                Val += this.UploadImagePath.Text + "{$split$}";
                Val += this.ImageType.Text + "{$split$}";
                Val += this.IsWatermark.Text + "{$split$}";
                Val += this.WatermarkImage.Text + "{$split$}";
                Val += this.WatermarkPos.Text + "{$split$}";
                Val += this.IsThumbnail.Text + "{$split$}";
                Val += this.ThumbnailSize.Text;
                xml.xmlfilePath = "~/Config/ImageConfig.config";
                xml.DeleteNode("/Image");
                xml.InsertNode("/Image", Field.Split(','), Val.Split(new string[1] { "{$split$}" }, System.StringSplitOptions.None));
                break;
                #endregion
            case "email":
                #region 邮件参数配置
                Field = "IsMail,SendMailServer,SendMailUserName,SendMailUserPwd,ReceiveMail,MailSubject,MailTemplate";
                Val = this.IsMail.Text + "{$split$}";
                Val += this.SendMailServer.Text + "{$split$}";
                Val += this.SendMailUserName.Text + "{$split$}";
                Val += this.SendMailUserPwd.Text + "{$split$}";
                Val += this.ReceiveMail.Text + "{$split$}";
                Val += this.MailSubject.Text + "{$split$}";
                Val += this.MailTemplate.Text;
                xml.xmlfilePath = "~/Config/MailConfig.config";
                xml.DeleteNode("/Mail");
                xml.InsertNode("/Mail", Field.Split(','), Val.Split(new string[1] { "{$split$}" }, System.StringSplitOptions.None));
                break;
                #endregion
            case "user":
                #region 用户参数配置
                Field = "IsReg,IsRegCode,IsLoginCode,IsInvite,NotReg,RegInfo";
                Val = this.IsReg.Text + "{$split$}";
                Val += this.IsRegCode.Text + "{$split$}";
                Val += this.IsLoginCode.Text + "{$split$}";
                Val += this.IsInvite.Text + "{$split$}";
                Val += this.NotReg.Text + "{$split$}";
                Val += this.RegInfo.Text;
                xml.xmlfilePath = "~/Config/UserConfig.config";
                xml.DeleteNode("/User");
                xml.InsertNode("/User", Field.Split(','), Val.Split(new string[1] { "{$split$}" }, System.StringSplitOptions.None));
                break;
                #endregion
            default:
                #region 网站参数配置
                Field = "SiteName,SiteDomain,ManagePath,IsManageCode,CreateType,HomeKeyWords,HomeDescription,CopyRight,ICP,ObstructCode,TableXmlPath";
                Val = this.SiteName.Text + "{$split$}";
                Val += this.SiteDomain.Text + "{$split$}";
                Val += this.ManagePath.Text + "{$split$}";
                Val += this.IsManageCode.Text + "{$split$}";
                Val += this.CreateType.Text + "{$split$}";
                Val += this.HomeKeyWords.Text + "{$split$}";
                Val += this.HomeDescription.Text + "{$split$}";
                Val += this.CopyRight.Text + "{$split$}";
                Val += this.ICP.Text + "{$split$}";
                Val += this.ObstructCode.Text + "{$split$}";
                Val += this.TableXmlPath.Text;
                xml.xmlfilePath = "~/Config/SystemConfig.config";
                xml.DeleteNode("/System");
                xml.InsertNode("/System", Field.Split(','), Val.Split(new string[1] { "{$split$}" }, System.StringSplitOptions.None));
                break;
                #endregion
        }
        if (Action.Length > 0)
        {
            foreach (string x in Field.Split(','))
            {
                Caches.RemoveCache(Action + "_" + x);
            }
        }
    }
}

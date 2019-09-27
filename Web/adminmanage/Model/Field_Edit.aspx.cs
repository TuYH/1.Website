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
using HXD.BLL;
using HXD.Model;
using HXD.Common;

public partial class adminmanage_Model_Field_Edit : System.Web.UI.Page
{
    protected int TableId, Id;
    protected mField mF = new mField();
    protected bField bF = new bField();
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdminManage();
        TableId = StringDeal.ToInt(Request.QueryString["TableId"]);
        Id = StringDeal.ToInt(Request.QueryString["Id"]);
        mF.Id = Id;
        bTable bT = new bTable();
        mF.TableName = bT.GetTableName(TableId);
        if (!IsPostBack)
        {
            this.TableName.Text = mF.TableName;
            FieldRead();
        }
        else
        {
            FieldSave();
        }
    }

    #region 字段信息保存
    /// <summary>
    /// 字段信息保存
    /// </summary>
    protected void FieldSave()
    {
        //获取入库的信息
        mF.Field = this.Field.Text;
        mF.Title = this.Title.Text;
        mF.Note = this.Note.Text;
        mF.Prompt = this.Prompt.Text;
        mF.Type = this.Type.SelectedValue;

        #region 获取要生成表及XML字段所有属性
        HXD.ModelField.Model.Field mf = new HXD.ModelField.Model.Field();
        mf.TableName = this.TableName.Text;
        mf.Type = this.Type.SelectedValue;
        mf.Name = this.Field.Text;
        mf.Title = this.Title.Text;
        mf.Note = this.Note.Text;
        mf.Prompt = this.Prompt.Text;
        mf.MaxLength = StringDeal.ToInt(Request.Form["MaxLength"]);
        mf.Size = StringDeal.ToInt(Request.Form["Size"]);
        mf.Default = Request.Form["Default"];
        mf.Width = StringDeal.ToInt(Request.Form["Width"]);
        mf.Height = StringDeal.ToInt(Request.Form["Height"]);
        mf.PwdMode = Request.Form["PwdMode"];
        mf.EditorType = StringDeal.ToInt(Request.Form["EditorType"]);
        mf.Options = Request.Form["Options"];
        mf.OptionsType = Request.Form["OptionsType"];
        mf.Bit = StringDeal.ToInt(Request.Form["Bit"]);
        mf.DateTime = Request.Form["DateTime"];
        mf.IsUploadPhoto = StringDeal.ToBool(Request.Form["IsUploadPhoto"]);
        mf.UploadPhotoSize = StringDeal.ToInt(Request.Form["UploadPhotoSize"]);
        mf.UploadPhotoType = Request.Form["UploadPhotoType"];
        mf.IsSelect = StringDeal.ToBool(Request.Form["IsSelect"]);
        mf.IsMark = StringDeal.ToBool(Request.Form["IsMark"]);
        mf.MarkImage = Request.Form["MarkImage"];
        mf.IsThumb = StringDeal.ToBool(Request.Form["IsThumb"]);
        mf.ThumbSize = Request.Form["ThumbSize"];
        mf.IsUploadFile = StringDeal.ToBool(Request.Form["IsUploadFile"]);
        mf.UploadFileSize = StringDeal.ToInt(Request.Form["UploadFileSize"]);
        mf.UploadFileType = Request.Form["UploadFileType"];
        mf.Validator = Request.Form["Validator"];
        #endregion
        if (mF.Id == 0)
        {
            if (bF.FieldInsert(mF))
            {
                StringDeal.Alter("此字段名已经存在，请更换其他名称！");
            }
            else
            {
                HXD.ModelField.BLL.Field bf = new HXD.ModelField.BLL.Field();
                bf.Val = mf;
                bf.InsertXml();
                bf.InsertField();
                Response.Redirect("Field_Manage.aspx?TableId=" + TableId + "");
            }
        }
        else
        {
            if (bF.FieldUpdate(mF))
            {
                StringDeal.Alter("此字段名已经存在，请更换其他名称！");
            }
            else
            {
                HXD.ModelField.BLL.Field bf = new HXD.ModelField.BLL.Field();
                bf.Val = mf;
                bf.UpdateXml();
                bf.UpdateField();
                Response.Redirect("Field_Manage.aspx?TableId=" + TableId + "");
            }
        }
    }
    #endregion

    #region 读取单条字段信息
    /// <summary>
    /// 读取单条字段信息
    /// </summary>
    protected void FieldRead()
    {
        if (mF.Id > 0)
        {
            mField mFi = bF.FieldRead(mF);
            this.TableName.Text = mFi.TableName;
            this.Field.Text = mFi.Field;
            this.Title.Text = mFi.Title;
            this.Note.Text = mFi.Note;
            this.Prompt.Text = mFi.Prompt;
            this.Type.SelectedValue = mFi.Type;
            this.OnloadJs.Text = "<script language=\"javascript\" type=\"text/javascript\">FiledAjax('" + mFi.Type.ToString() + "');</script>";
            this.Type.Attributes.Add("onchange", "this.value='" + mFi.Type + "';return false;FiledAjax(this.value);");
            this.Field.Attributes.Add("readonly", "readonly");
        }
        else
        {
            this.Type.Attributes.Add("onchange", "FiledAjax(this.value);");
        }
    }
    #endregion
}

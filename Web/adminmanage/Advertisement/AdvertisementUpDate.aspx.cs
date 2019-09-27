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
public partial class adminmanage_Advertisement_AdvertisementUpDate : System.Web.UI.Page
{
    public int id = 0;
    HXD.Common.FilesManage upfileui = new HXD.Common.FilesManage();
    protected int Pages = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdminManage();
        Pages = HXD.Common.StringDeal.ToInt(Request.QueryString["Page"]);
        if (Request.QueryString["id"] != null)
        { id = Convert.ToInt32(Request.QueryString["id"]); }
        this.DropDownList1.Attributes.Add("onchange", "selectvalue(this);");
        this.Button1.Attributes.Add("onmouseover", "this.className='button1'");
        this.Button1.Attributes.Add("onmouseout", "this.className='button'");
        if (!IsPostBack)
        { binder(); }
    }

    private void binder()
    {
        HXD.SQLServerDAL.tb_U_Advertisement dal = new HXD.SQLServerDAL.tb_U_Advertisement();
        HXD.Model.tb_U_Advertisement model = new HXD.Model.tb_U_Advertisement();
        model = dal.GetModel(id);
        this.ViewState["Files"] = model.Files;
        this.ViewState["FilesType"] = model.FileType;
        this.DropDownList1.SelectedIndex = this.DropDownList1.Items.IndexOf(this.DropDownList1.Items.FindByValue(model.type.ToString()));//类型
        this.TextBox1.Text = model.AdName;//名称
        this.TextBox2.Text = model.Width.ToString();
        this.TextBox3.Text = model.Height.ToString();
        this.TextBox4.Text = model.href;
        this.TextBox5.Text = model.Elucidation;
        this.TextBox6.Text = model.scripttext;
        this.Text1.Value = model.CloseTime.ToString("yyyy-MM-dd");
        this.CheckBox1.Checked = model.isqiyong;
        this.Literal2.Text = model.submittime.ToString();
        //if (model.FileType == 1)
        //{
        //    this.Radio1.Checked = true;
        //    this.Radio2.Checked = false;
        //    this.FileStr.Text = model.Files;
        //    this.filetable1.Style.Add("display", "block");
        //    this.filetable2.Style.Add("display", "none");
        //}
        //else if (model.FileType == 2)
        //{
        //    this.Radio1.Checked = false;
        //    this.Radio2.Checked = true;
        //    this.filetable1.Style.Add("display", "none");
        //    this.filetable2.Style.Add("display", "block");
        //}

        if (model.type == 2)//图片
        {
            this.adsize.Style.Add("display", "block");
            this.adfile.Style.Add("display", "block");
            this.adflash.Style.Add("display", "none");
            this.adlink.Style.Add("display", "block");
            this.adlinkstr.Style.Add("display", "block");
            this.adjs.Style.Add("display", "none");
        }
        else if (model.type == 3)//Flash
        {
            this.adsize.Style.Add("display", "block");
            this.adfile.Style.Add("display", "none");
            this.adflash.Style.Add("display", "block");
            this.adlink.Style.Add("display", "none");
            this.adlinkstr.Style.Add("display", "none");
            this.adjs.Style.Add("display", "none");
        }
        else if (model.type == 4)//脚本
        {
            this.adsize.Style.Add("display", "none");
            this.adfile.Style.Add("display", "none");
            this.adflash.Style.Add("display", "none");
            this.adlink.Style.Add("display", "none");
            this.adlinkstr.Style.Add("display", "none");
            this.adjs.Style.Add("display", "block");
        }
        else if (model.type == 5)//漂浮
        {
            this.adsize.Style.Add("display", "block");
            this.adfile.Style.Add("display", "block");
            this.adflash.Style.Add("display", "none");
            this.adlink.Style.Add("display", "block");
            this.adlinkstr.Style.Add("display", "block");
            this.adjs.Style.Add("display", "none");
        }
    }

    private void updata()
    {
        HXD.SQLServerDAL.tb_U_Advertisement dal = new HXD.SQLServerDAL.tb_U_Advertisement();
        HXD.Model.tb_U_Advertisement model = new HXD.Model.tb_U_Advertisement();
        model.id = id;
        model.type = int.Parse(this.DropDownList1.SelectedValue);
        model.AdName = this.TextBox1.Text.Trim();
        model.Width = this.TextBox2.Text.Trim() != "" ? int.Parse(this.TextBox2.Text) : 0;
        model.Height = this.TextBox3.Text.Trim() != "" ? int.Parse(this.TextBox3.Text) : 0;
        model.href = this.TextBox4.Text.Trim();
        model.Elucidation = this.TextBox5.Text.Trim();
        model.scripttext = this.TextBox6.Text.Trim();
        model.CloseTime = Convert.ToDateTime(this.Text1.Value);
        model.isqiyong = this.CheckBox1.Checked;
        string k = string.Empty;
        if (this.DropDownList1.SelectedValue == "2" || this.DropDownList1.SelectedValue == "5")//图片
        {
            //if (this.Radio1.Checked)
            //{
            //    model.Files = Request.Form["FileStr"].Trim();
            //    model.FileType = 1;
            //    deltype();
            //}
            //else
            //{
                string type = Web.Model.PublicModel.UpLoadFileImage;
                if (upfileui.SaveFile(this.File1, Web.Model.PublicModel.ADUpLoadFileImages, type, Web.Model.PublicModel.filesizes, out k))//上传文件并且返回信息
                {
                    model.Files = Web.Model.PublicModel.XADUpLoadFileImages + upfileui.file_name;
                    deltype();
                }
                else if (k == "请选择要上传的文件!")
                {
                    model.Files = this.ViewState["Files"].ToString(); model.FileType = Convert.ToInt32(this.ViewState["FilesType"]);
                }
                else
                {
                    Jscript.Alert(k, this.Page); binder(); return;
                }
                model.FileType = 2;
            //}
        }
        else if (this.DropDownList1.SelectedValue == "3")//Flash
        {
            if (upfileui.SaveFile(this.File2, Web.Model.PublicModel.ADUpLoadFileImages, "swf", Web.Model.PublicModel.filesizes, out k))//上传文件并且返回信息
            {
                model.Files = Web.Model.PublicModel.XADUpLoadFileImages + upfileui.file_name;
                deltype();
            }
            else if (k == "请选择要上传的文件!")
            {
                model.Files = this.ViewState["Files"].ToString(); model.FileType = Convert.ToInt32(this.ViewState["FilesType"]);
            }
            else
            {
                Jscript.Alert(k, this.Page); binder(); return;
            }
        }
        else if (this.DropDownList1.SelectedValue == "5")//浮动
        { deltype(); model.Files = ""; model.FileType = 0; }
        else
        {
            deltype();
            model.Files = "";
            model.FileType = 0;
            model.Height = 0;
            model.Width = 0;
        }
        if (dal.Update(model))
        { Jscript.AlertAndRedirect("广告修改成功！", "AdvertisementList.aspx?Page=" + Pages); }
        else
        { Jscript.Alert("广告修改失败！", this.Page); }
    }

    public void deltype()
    {
        if (this.ViewState["FilesType"].ToString() != "1")
        { upfileui.WNdelfile("~" + this.ViewState["Files"].ToString()); }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (this.TextBox1.Text.Trim() == "")
        { Jscript.Alert("请填写广告名称！", this.Page); binder(); }
        else
        { updata(); }
    }
}

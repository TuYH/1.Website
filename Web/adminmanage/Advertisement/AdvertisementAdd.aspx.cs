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
public partial class adminmanage_Advertisement_AdvertisementAdd : System.Web.UI.Page
{
    HXD.Common.FilesManage upfileui = new HXD.Common.FilesManage();
    protected int Pages = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdminManage();
        Pages = HXD.Common.StringDeal.ToInt(Request.QueryString["Page"]);
        this.DropDownList1.Attributes.Add("onchange", "selectvalue(this);");
        this.Button1.Attributes.Add("onmouseover", "this.className='button1'");
        this.Button1.Attributes.Add("onmouseout", "this.className='button'");
    }

    private void insert()
    {
        HXD.SQLServerDAL.tb_U_Advertisement dal = new HXD.SQLServerDAL.tb_U_Advertisement();
        HXD.Model.tb_U_Advertisement model = new HXD.Model.tb_U_Advertisement();
        model.type = int.Parse(this.DropDownList1.SelectedValue);
        model.AdName = this.TextBox1.Text.Trim();
        model.Width = this.TextBox2.Text.Trim() != "" ? int.Parse(this.TextBox2.Text) : 0;
        model.Height = this.TextBox3.Text.Trim() != "" ? int.Parse(this.TextBox3.Text) : 0;
        model.href = this.TextBox4.Text.Trim();
        model.Elucidation = this.TextBox5.Text.Trim();
        model.scripttext = this.TextBox6.Text.Trim();
        model.CloseTime = Convert.ToDateTime(this.Text1.Value);
        model.isqiyong = this.CheckBox1.Checked;

        if (this.DropDownList1.SelectedValue == "2" || this.DropDownList1.SelectedValue == "5")//图片
        {
            //if (this.Radio1.Checked)
            //{
            //    model.Files = Request.Form["FileStr"].Trim();
            //    model.FileType = 1;
            //}
            //else
            //{
                string type = Web.Model.PublicModel.UpLoadFileImage;
                string k = string.Empty;
                if (upfileui.SaveFile(this.File1, Web.Model.PublicModel.ADUpLoadFileImages, type, Web.Model.PublicModel.filesizes, out k))//上传文件并且返回信息
                {
                    model.Files = Web.Model.PublicModel.XADUpLoadFileImages + upfileui.file_name;
                }
                else
                {
                    Jscript.Alert(k, this.Page); return;
                }
                model.FileType = 2;
            //}
        }
        else if (this.DropDownList1.SelectedValue == "3")//Flash
        {
            string k = string.Empty;
            if (upfileui.SaveFile(this.File2, Web.Model.PublicModel.ADUpLoadFileImages, "swf", Web.Model.PublicModel.filesizes, out k))//上传文件并且返回信息
            {
                model.Files = Web.Model.PublicModel.XADUpLoadFileImages + upfileui.file_name;
            }
            else
            {
                Jscript.Alert(k, this.Page); return;
            }
        }
        else { model.Files = ""; model.FileType = 0; }
        if (dal.Add(model))
        { Jscript.AlertAndRedirect("广告添加成功！", "AdvertisementList.aspx?Page=" + Pages); }
        else
        { Jscript.Alert("广告添加失败！", this.Page); }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (this.TextBox1.Text.Trim() == "")
        {
            Jscript.Alert("请填写广告名称！", this.Page);
        }
        else
        {
            insert();
        }
    }
}
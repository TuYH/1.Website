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
public partial class adminmanage_TemplateLabel_TemplateLabelAdd : System.Web.UI.Page
{
    protected int Pages = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdminManage();
        Pages = HXD.Common.StringDeal.ToInt(Request.QueryString["Page"]);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (this.TextBox1.Text.Trim() == string.Empty)
        { Jscript.Alert("标签说明不能为空！", this.Page); }
        else if (this.TextBox2.Text.Trim() == string.Empty)
        { Jscript.Alert("标签名称不能为空！", this.Page); }
        else if (this.TextBox3.Text.Trim() == string.Empty)
        { Jscript.Alert("文件名称不能为空！", this.Page); }
        else if (this.Content.Value.Trim() == string.Empty)
        { Jscript.Alert("标签内容不能为空！", this.Page); }
        else
        {
            HXD.SQLServerDAL.tb_U_Template_Label DAL = new HXD.SQLServerDAL.tb_U_Template_Label();
            HXD.Model.tb_U_Template_Label Model = new HXD.Model.tb_U_Template_Label();
            Model.labelHelp = this.TextBox1.Text.Trim();
            Model.labelname = this.TextBox2.Text.Trim();
            Model.labelfile = this.TextBox3.Text.Trim();
            Model.counts = this.Content.Value.Trim();
            if (DAL.Add(Model))
            {
                //FilesManage.ReplaceFileNewContent(Server.MapPath("~/" + Model.labelfile), Model.labelname, Model.counts);//更新文件
                Jscript.AlertAndRedirect("标签添加成功！", "TemplateLabelList.aspx?Page=" + Pages);
            }
            else
            { Jscript.Alert("标签添加失败！", this.Page); }
        }
    }
}

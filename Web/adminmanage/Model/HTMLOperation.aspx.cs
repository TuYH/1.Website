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
using HXD.BLL;
public partial class adminmanage_Model_HTMLOperation : System.Web.UI.Page
{
    protected DataSet dsList;
    protected bMenu bM = new bMenu();
    private int MenuId = 36;
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdminManage();
        this.Button1.Attributes.Add("onmouseover", "this.className='button1'");
        this.Button1.Attributes.Add("onmouseout", "this.className='button'");
        this.Button2.Attributes.Add("onmouseover", "this.className='button1'");
        this.Button2.Attributes.Add("onmouseout", "this.className='button'");
        this.Button3.Attributes.Add("onmouseover", "this.className='button1'");
        this.Button3.Attributes.Add("onmouseout", "this.className='button'");
        if (!IsPostBack)
        {
            dsList = (DataSet)bM.MenuList();//栏目列表
            BindMenu(MenuId, "┣");
        }
    }

    #region 栏目类别绑定
    /// <summary>
    /// 栏目类别绑定
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="Separator"></param>
    private void BindMenu(int Id, string Separator)
    {
        DataView dv = new DataView(dsList.Tables[0]);
        dv.RowFilter = "ParentId = " + Id;
        foreach (DataRowView dr in dv)
        {
            ListItem li = new ListItem();
            li.Text = Separator + StringDeal.StrFormat(dr["Title"]);
            li.Value = dr["Id"].ToString();
            this.ClassId.Items.Add(li);
            BindMenu(StringDeal.ToInt(dr[0]), "┃" + Separator);
        }
        //this.ClassId.Items[0].Value = MenuId.ToString();
        //this.ClassId.SelectedValue = MenuReader("ParentId");
    }
    #endregion
    /// <summary>
    /// 更新全部
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        //HXD.Common.HtmlDal.ToHtmlNewsUpData(85, "htm");
        HXD.Common.HtmlDal.WToHtmlNewsUpData("where ClassId=" + MenuId, "html");
        Jscript.Alert("生成完毕", this.Page);
    }
    /// <summary>
    /// 生成全部
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button2_Click(object sender, EventArgs e)
    {
        HXD.Common.HtmlDal.WToHtmlNewsAdd("where ClassId=" + MenuId, "html");
        Jscript.Alert("生成完毕", this.Page);
    }
    /// <summary>
    /// 更新指定分类
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button3_Click(object sender, EventArgs e)
    {
        if (this.ClassId.SelectedValue == "-1")
        { HXD.Common.HtmlDal.WToHtmlNewsUpData("", "html"); }
        else
        { HXD.Common.HtmlDal.WToHtmlNewsUpData("where ClassId=" + this.ClassId.SelectedValue, "html"); }
        Jscript.Alert("生成完毕", this.Page);
    }
}

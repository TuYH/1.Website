using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using HXD.BLL;
using HXD.Model;
using HXD.Common;

public partial class adminmanage_Left : System.Web.UI.Page
{
    protected string Titles;
    bChannel b = new bChannel();
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdminManage(null);
        int Id = StringDeal.ToInt(Request.QueryString["Id"]);
        if (Id == 0)
            Id = b.GetChannelFirstParentId(Session["AdminManage"].ToString());
        Titles = b.GetChannelTitle(Id);
        DBList.DataSource = b.GetChannelMenu(Id, Session["AdminManage"].ToString())[0].Tables[0];
        DBList.DataBind();
    }

    /// <summary>
    /// 获取左侧频道子栏目绑定
    /// </summary>
    /// <param name="ParentId"></param>
    /// <returns></returns>
    protected DataSet SubList(object ParentId)
    {
        return b.GetChannelMenu(StringDeal.ToInt(ParentId), Session["AdminManage"].ToString())[0];
    }

    /// <summary>
    /// 获取当前频道前的ICO图片
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    protected string GetChannelIco(object Id)
    {
        if (b.GetChannelSubCount(StringDeal.ToInt(Id)) > 0)
        {
            return "fold";
        }
        else
        {
            return "open";
        }
    }
}

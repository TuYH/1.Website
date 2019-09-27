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

public partial class AJAX_TouPiao : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.CacheControl = "no-cache";
        Response.ContentType = "text/plain";

        if (Request.QueryString["radioid"] != null && Request.QueryString["radioid"] != string.Empty)
        { VoteCount(Request.QueryString["valuestr"], Request.QueryString["radioid"]); }
        if (Request.QueryString["checkboxid"] != null && Request.QueryString["checkboxid"] != string.Empty)
        { VoteCount1(Request.QueryString["valuestr"], Request.QueryString["checkboxid"]); }

        if (Request.QueryString["fid"] != null && Request.QueryString["fid"] != string.Empty)
        {
            HXD.Model.tb_U_TouPiao1 model = new HXD.Model.tb_U_TouPiao1();
            model.FatherId = Convert.ToInt32(Request.QueryString["fid"]);
            model.title = Request.QueryString["value"];
            DataSet ds = new HXD.SQLServerDAL.tb_U_TouPiao1().Add(model);
            if (ds.Tables[0].Rows.Count == 1)
            {
                Response.Write("<tr onmouseover=\"over()\" onclick=\"change()\" onmouseout=\"out()\" class=\"td_bg\"><td style=\"text-align:center;\"><input type=\"checkbox\" name=\"CK_ID\" id=\"CK_ID\" value=\"" + ds.Tables[0].Rows[0]["id"] + "\" /></td><td style=\"text-align:center;\" title=\"" + ds.Tables[0].Rows[0]["title"] + "\" id=\"title" + ds.Tables[0].Rows[0]["id"] + "\">" + HXD.Common.StringDeal.Substrings1(ds.Tables[0].Rows[0]["title"].ToString(), 70) + "</td><td style=\"text-align:center;\" title=\"" + Convert.ToDateTime(ds.Tables[0].Rows[0]["AddTime"]).ToString("yyyy-MM-dd HH:mm:ss") + "\">" + Convert.ToDateTime(ds.Tables[0].Rows[0]["AddTime"]).ToString("yyyy-MM-dd") + "</td><td style=\"text-align:center;\" ><a href=\"javascript:void(null);\" onclick=\"UpDateOpenWindow(" + ds.Tables[0].Rows[0]["id"] + ");\">编辑</a></td><td style=\"text-align:center;\" nowrap=\"nowrap\"><a onclick=\"javascript:return confirm(\'确定删除此投票吗？\')\" href=\"?type=del&id=" + ds.Tables[0].Rows[0]["id"] + "&fid=" + Request.QueryString["fid"] + "&Page=" + Request.QueryString["Page"] + "\">删除</a></td></tr>");
            }
        }

        if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
        {
            HXD.Model.tb_U_TouPiao1 model = new HXD.Model.tb_U_TouPiao1();
            model.id = Convert.ToInt32(Request.QueryString["id"]);
            model.title = Request.QueryString["value"];
            Response.Write(new HXD.SQLServerDAL.tb_U_TouPiao1().Update(model) ? "1" : "0"); 
        }

    }

    #region ---  文字(单选)投票  ---
    /// <summary>
    /// 文字单选投票
    /// </summary>
    /// <param name="id">投票选项的id，用来增加投票数量</param>
    /// <param name="votid">投票组的ID，如果此id存在表明已经在此组投过票</param>
    /// <returns></returns>
    public void VoteCount(string id, string votid)
    {
        if (toupiao("6623E33V" + votid)) { Response.Write("2"); Response.End(); }
        if (HXD.DBUtility.SQLHelper.ExecuteNonQuery("update tb_U_TouPiao1 set Click=Click+1 where id in(" + id + ")") > 0)
        {
            HttpCookie cook = new HttpCookie("6623E33V" + votid);//COOK名称
            cook.Value = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            cook.Expires = System.DateTime.Now.AddDays(1);
            System.Web.HttpContext.Current.Response.Cookies.Add(cook);
            Response.Write("1"); Response.End();
        }
        else { Response.Write("0"); Response.End(); }
    }
    #endregion

    #region ---  文字(多选)投票  ---
    /// <summary>
    /// 文字多选投票
    /// </summary>
    /// <param name="id">投票选项的id，用来增加投票数量</param>
    /// <param name="votid">投票组的ID，如果此id存在表明已经在此组投过票</param>
    /// <returns></returns>
    public void VoteCount1(string id, string votid)
    {
        if (toupiao("6623E33V" + votid)) { Response.Write("2"); Response.End(); }
        id = id.Remove(id.LastIndexOf(','));
        if (HXD.DBUtility.SQLHelper.ExecuteNonQuery("update tb_U_TouPiao1 set Click=Click+1 where id in(" + id + ")") > 0)
        {
            HttpCookie cook = new HttpCookie("6623E33V" + votid);//COOK名称
            cook.Value = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            cook.Expires = System.DateTime.Now.AddDays(1);
            System.Web.HttpContext.Current.Response.Cookies.Add(cook);
            Response.Write("1"); Response.End();
        }
        else { Response.Write("0"); Response.End(); }
    }
    #endregion

    #region ---  读取Cook  ---
    /// <summary>
    /// 读取Cook
    /// </summary>
    /// <param name="cookname">Cook名称</param>
    /// <param name="mem">用于获取用户名称和密码的类</param>
    /// <returns></returns>
    public bool toupiao(string name)
    {
        if (System.Web.HttpContext.Current.Request.Cookies[name] != null)//判断是否为空
        {
            System.Web.HttpCookie cook1 = System.Web.HttpContext.Current.Request.Cookies[name];//创建Cook对象
            return HXD.Common.Utils.IsTimeMax(cook1.Value.Trim());
        }
        else
        {
            return false;
        }
    }
    #endregion

}

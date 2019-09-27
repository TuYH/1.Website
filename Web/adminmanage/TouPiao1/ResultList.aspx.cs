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

public partial class adminmanage_TouPiao1_ResultList : System.Web.UI.Page
{
    public string dd;
    protected int id = 0, Pages = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdminManage();
        id = HXD.Common.StringDeal.ToInt(Request.QueryString["fid"]);
        Pages = HXD.Common.StringDeal.ToInt(Request.QueryString["Page"]);
        if (!IsPostBack)
        { databiner(id); }
    }

    public void databiner(int id)
    {
        int k = 0; double c = 0;
        DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset("select * from tb_U_TouPiao1 where FatherId=" + id);
        object click = HXD.DBUtility.SQLHelper.ExecuteScalar("select sum(click) from tb_U_TouPiao1 where FatherId=" + id);
        if (click != DBNull.Value) { k = Convert.ToInt32(click); }//总和
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            c = (double)(Convert.ToDouble(ds.Tables[0].Rows[i]["Click"]) / k) * 100;
            dd += "<tr onmouseover=\"over()\" onclick=\"change()\" onmouseout=\"out()\" class=\"td_bg\" title=\"共" + k + "票\n此选项占总投票数的" + c.ToString("f1") + "%\n此选项有" + ds.Tables[0].Rows[i]["Click"].ToString() + "人投票\">";
            dd += "<td align=\"right\" width=\"20%\">";
            dd += ds.Tables[0].Rows[i]["title"].ToString();
            dd += "</td>";
            dd += "<td align=\"left\">";//colspan=\"2\"

            dd += "<img src=\"../../Images/NewFolder1/left.gif\" width=\"4\" height=\"21\" border=\"0\" align=\"top\">";
            dd += "<img src=\"../../Images/NewFolder1/greenbar.gif\" width=\"" + (c * 2.5).ToString("f0") + "\" height=\"21\" align=\"absmiddle\">";//主进度
            dd += "<img src=\"../../Images/NewFolder1/mid.gif\" width=\"6\" height=\"21\" align=\"top\">";//指针
            int v = 0;
            if (c > 0)
            { v = 250 - int.Parse((c * 2.5).ToString("f0")); }
            else { v = 250; }
            dd += "<img src=\"../../Images/NewFolder1/whitebar.gif\" width=\"" + v + "\" height=\"21\" align=\"absmiddle\">";//剩余进度
            dd += "<img src=\"../../Images/NewFolder1/right.gif\" width=\"6\" height=\"21\" border=\"0\" align=\"top\">共" + ds.Tables[0].Rows[i]["Click"].ToString() + "票,占总投票的" + c.ToString("f1") + "%<br>";

            dd += "</td>";
            dd += "</tr>";
        }
        ds.Tables[0].Dispose();
        ds.Tables[0].Clear();
    }
}

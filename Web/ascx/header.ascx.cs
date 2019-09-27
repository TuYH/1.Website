using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using HXD.Common;

public partial class ascx_header : System.Web.UI.UserControl
{
    protected string strarm = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string m = "0";
            XmlDoc xml = new XmlDoc();
            xml.xmlfilePath = "~/Config/admin.config";
            DataSet ds = xml.GetDataSet();
            m = ds.Tables[0].Rows[0]["AdminID"].ToString();
            bdlhead(m);
        }
        
    }

    protected void bdlhead(string menid)
    {
        string sql = "select * from tb_U_schoolfl where depth=0 and menuid=1 and sid=" + menid;
        DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                strarm += "<li class=\"\"><a href=\"/list.aspx?c=" + ds.Tables[0].Rows[i]["id"].ToString() + "\" target=\"\">" + ds.Tables[0].Rows[i]["title"].ToString() + "</a>";


                string strid = ds.Tables[0].Rows[i]["id"].ToString();
                string sql2 = "select * from tb_U_schoolfl where classid=" + strid;
                DataSet dss = HXD.DBUtility.SQLHelper.ExecuteDataset(sql2);
                if (dss.Tables[0].Rows.Count > 0)
                {
                    string str = dss.Tables[0].Rows[0]["classid"].ToString();
                    bdclass(str);
                }
                strarm += "</li>";
            }
        }
    }
    protected void bdclass(string id)
    {
        string sql = "select * from tb_U_schoolfl where menuid=1 and classid=" + id;
        DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            strarm += "<dl style=\"display: none;\">";
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                strarm += "<dt><a href=\"/list.aspx?c=" + ds.Tables[0].Rows[i]["id"].ToString() + "\" target=\"\">" + ds.Tables[0].Rows[i]["title"].ToString() + "</a></dt>";


                string strid = ds.Tables[0].Rows[i]["id"].ToString();
                string sql2 = "select * from tb_U_schoolfl where classid=" + strid;
                DataSet dss = HXD.DBUtility.SQLHelper.ExecuteDataset(sql2);
                if (dss.Tables[0].Rows.Count > 0)
                {
                    string str = dss.Tables[0].Rows[0]["classid"].ToString();
                    bdclass(str);
                }
            }
            strarm += "</dl>";
        }
    }
}
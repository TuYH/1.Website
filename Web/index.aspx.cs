using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using HXD.Common;
using System.Configuration;

public partial class index : System.Web.UI.Page
{
    protected string strarm = "", str_tj = "", str_xydt = "", str_tz = "", str_new1 = "", str_new2 = "", str_new3 = "", str_new4 = "",str_dimg="",str_num="";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string m=LoginCheck.getadminid();//学校ID
            
            //string m = ConfigurationSettings.AppSettings["School_ID"].ToString();
            //ConfigurationSection.
            str_num = m;
            bdlhead(m);
            bdtw(m);
            bd_xydt(m);
            bd_tz(m);
            bd_new1(m);
            bd_new2(m);
            bd_new3(m);
            bd_new4(m);
            bd_tw(m);
        }
    }
    public HXD.Model.test test() {
        HXD.Model.test list = new HXD.Model.test();
        list.Id = 1;
        list.Name = "你好";
        return list;
    } 
    #region 绑定动态栏目
    /// <summary>
    /// 绑定动态栏目
    /// </summary>
    /// <param name="menid"></param>
    protected void bdlhead(string menid)
    {
        string sql = "select * from tb_U_schoolfl where depth=0 and menuid=1 and sid=" + menid;
        DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                strarm += "<li class=\"\"><a href=\"/news.aspx?id=" + ds.Tables[0].Rows[i]["id"].ToString() + "\" target=\"\">" + ds.Tables[0].Rows[i]["title"].ToString() + "</a>";


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

                strarm += "<dt><a href=\"/news.aspx?id=" + ds.Tables[0].Rows[i]["id"].ToString() + "\" target=\"\">" + ds.Tables[0].Rows[i]["title"].ToString() + "</a></dt>";
               

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
    #endregion
    /// <summary>
    /// 首页轮播图
    /// </summary>
    /// <param name="id"></param>
    protected void bdtw(string id)
    {
        string sql = "select top 4 * from tb_u_info where IsElite=1 and userid in(select id from tb_User where Classid=" + id + " and GroupId in(5,6)) order by id";
        DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                str_tj += "<a href=\"/news.aspx?id=" + ds.Tables[0].Rows[i]["id"].ToString() + "\" target=\"_blank\" style=\"display: none;\"><img src=\"" + ds.Tables[0].Rows[i]["photo"].ToString() + "\" alt=\"" + ds.Tables[0].Rows[i]["title"].ToString() + "\"></a>"; 
              
            }
        }
    }
    /// <summary>
    /// 首页-校园动态
    /// </summary>
    /// <param name="id"></param>
    protected void bd_xydt(string id)
    {
        //select top 4 * from tb_u_info where IsElite=1 and userid in(select id from tb_User where Classid=" + id + " and GroupId in(5,6)) order by id
        string sql = "select top 8 * from tb_u_info where ClassId=(select id from tb_U_schoolfl where Sid=" + id + " and mb_id=1) and userid in(select id from tb_User where  Classid=" + id + " and GroupId in(5,6))  order by id desc";
        DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            str_xydt += "<div class=\"headline\"><h3 style=\"text-align: center; font-family: Microsoft YaHei;\">";
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (i == 0)
                {

                    str_xydt += "<a target=\"_blank\" style=\"font-size: 18px; color: rgb(107, 41, 43);\" href=\"/news.aspx?id=" + ds.Tables[0].Rows[i]["id"].ToString() + "\">" + ds.Tables[0].Rows[i]["title"].ToString() + "</a></h3></div>";
                    str_xydt += "<div class=\"focusList\"><ul class=\"sidelist21\" style=\"font-size: 14px; color: rgb(51, 51, 51);\">";
                }
                else
                {
                    str_xydt += "<li style=\";\"><span class=\"label_datatime \" style=\"font-size: 14px; color: rgb(64, 64, 64);\">2016-03-18</span><a class=\"normal_title\" target=\"_blank\" title=\"" + ds.Tables[0].Rows[i]["title"].ToString() + "\" href=\"/news.aspx?id=" + ds.Tables[0].Rows[i]["id"].ToString() + "\">" + ds.Tables[0].Rows[i]["title"].ToString() + "</a></li>";
                }
            }
            str_xydt += "<li class=\"clear\"></li></ul>";
        }
    }

    /// <summary>
    /// 首页-通知
    /// </summary>
    /// <param name="id"></param>
    protected void bd_tz(string id)
    {
        //select top 4 * from tb_u_info where IsElite=1 and userid in(select id from tb_User where Classid=" + id + " and GroupId in(5,6)) order by id
        string sql = "select top 4 * from tb_u_info where ClassId=(select id from tb_U_schoolfl where Sid=" + id + " and mb_id=2) and userid in(select id from tb_User where  Classid=" + id + " and GroupId in(5,6))  order by id desc";
        DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            str_tz += "<ul class=\"label_list3_date\">";
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string yymm= StringDeal.GetDateTime(ds.Tables[0].Rows[i]["posttime"], "yyyy-MM");
                string dd = StringDeal.GetDateTime(ds.Tables[0].Rows[i]["posttime"], "dd");
             
                str_tz += "<li><div class=\"date3\">";
                str_tz += "<span class=\"ny\">" + yymm + "</span>";
                str_tz += "<span class=\"rq\">"+dd+"</span></div>";
                str_tz += "<div class=\"text3\"><h4><a href=\"/news.aspx?id=" + ds.Tables[0].Rows[i]["id"].ToString() + "\" title=\"" + ds.Tables[0].Rows[i]["title"].ToString() + "\" target=\"_blank\">" + ds.Tables[0].Rows[i]["title"].ToString() + "</a></h4></div></li>";

            }
            str_tz += "</ul>";
        }
    }

    /// <summary>
    /// 首页-新闻模块1
    /// </summary>
    /// <param name="id"></param>
    protected void bd_new1(string id)
    {
        string name = "";
        string nameid = "";
        //select top 4 * from tb_u_info where IsElite=1 and userid in(select id from tb_User where Classid=" + id + " and GroupId in(5,6)) order by id
        string sql2 = "select Id,title from tb_U_schoolfl where Sid="+id+" and mb_id=3";
        DataSet dm = HXD.DBUtility.SQLHelper.ExecuteDataset(sql2);
        if (dm.Tables[0].Rows.Count > 0)
        {
             name = dm.Tables[0].Rows[0]["title"].ToString();
             nameid = dm.Tables[0].Rows[0]["id"].ToString();
        }

        string sql = "select top 8 * from tb_u_info where ClassId=(select id from tb_U_schoolfl where Sid=" + id + " and mb_id=3) and userid in(select id from tb_User where  Classid=" + id + " and GroupId in(5,6))  order by id desc";
        DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            
            str_new1+="<div class=\"hd\">";
            str_new1 += "<h3 class=\"title\">" + name + "</h3>";
            str_new1 += "<div class=\"more\"><a href=\"list.aspx?c=" + nameid + "\">MORE</a></div></div>";
            str_new1+="<div class=\"bd\">";
            str_new1+="<div class=\"hot\"><h3 style=\"text-align: center; font-family: Microsoft YaHei;\">";
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string yymm = StringDeal.GetDateTime(ds.Tables[0].Rows[i]["posttime"], "yyyy-MM-dd");
                if (i == 0)
                {

                    str_new1 += "<a target=\"_blank\" style=\"font-size: 18px; color: rgb(107, 41, 43);\" href=\"/news.aspx?id=" + ds.Tables[0].Rows[i]["id"].ToString() + "\">" + ds.Tables[0].Rows[i]["title"].ToString() + "</a></h3></div>";
                    str_new1 += "<div class=\"focusList\"><ul class=\"sidelist22\">";
                }
                else
                {
                    str_new1 += "<li style=\";\"><span style=\"font-size: 14px; color: rgb(64, 64, 64);\">" + yymm + "</span><span class=\"spe\">|</span><a class=\"normal_title\" target=\"_blank\" title=\"" + ds.Tables[0].Rows[i]["title"].ToString() + "\" href=\"/news.aspx?id=" + ds.Tables[0].Rows[i]["id"].ToString() + "\">" + ds.Tables[0].Rows[i]["title"].ToString() + "</a></li>";
                }
            }
            str_new1 += "<li class=\"clear\"></li></ul>";
            str_new1+="<li class=\"clear\"></li></ul></div></div>";
        }
    }

    /// <summary>
    /// 首页-新闻模块2
    /// </summary>
    /// <param name="id"></param>
    protected void bd_new2(string id)
    {
        string name = "",nameid="";
        //select top 4 * from tb_u_info where IsElite=1 and userid in(select id from tb_User where Classid=" + id + " and GroupId in(5,6)) order by id
        string sql2 = "select Id,title from tb_U_schoolfl where Sid=" + id + " and mb_id=4";
        DataSet dm = HXD.DBUtility.SQLHelper.ExecuteDataset(sql2);
        if (dm.Tables[0].Rows.Count > 0)
        {
            name = dm.Tables[0].Rows[0]["title"].ToString();
            nameid = dm.Tables[0].Rows[0]["id"].ToString();
        }

        string sql = "select top 8 * from tb_u_info where ClassId=(select id from tb_U_schoolfl where Sid=" + id + " and mb_id=4) and userid in(select id from tb_User where  Classid=" + id + " and GroupId in(5,6))  order by id desc";
        DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {

            str_new2 += "<div class=\"hd\">";
            str_new2 += "<h3 class=\"title\">" + name + "</h3>";
            str_new2 += "<div class=\"more\"><a href=\"list.aspx?c=" + nameid + "\">MORE</a></div></div>";
            str_new2 += "<div class=\"bd\">";
            str_new2 += "<div class=\"hot\"><h3 style=\"text-align: center; font-family: Microsoft YaHei;\">";
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string yymm = StringDeal.GetDateTime(ds.Tables[0].Rows[i]["posttime"], "yyyy-MM-dd");
                if (i == 0)
                {

                    str_new2 += "<a target=\"_blank\" style=\"font-size: 18px; color: rgb(107, 41, 43);\" href=\"/news.aspx?id=" + ds.Tables[0].Rows[i]["id"].ToString() + "\">" + ds.Tables[0].Rows[i]["title"].ToString() + "</a></h3></div>";
                    str_new2 += "<div class=\"focusList\"><ul class=\"sidelist22\" >";
                }
                else
                {
                    str_new2 += "<li style=\";\"><span style=\"font-size: 14px; color: rgb(64, 64, 64);\">" + yymm + "</span><span class=\"spe\">|</span><a class=\"normal_title\" target=\"_blank\" title=\"" + ds.Tables[0].Rows[i]["title"].ToString() + "\" href=\"/news.aspx?id=" + ds.Tables[0].Rows[i]["id"].ToString() + "\">" + ds.Tables[0].Rows[i]["title"].ToString() + "</a></li>";
                }
            }
            str_new2 += "<li class=\"clear\"></li></ul></div></div>";
        }
    }

    /// <summary>
    /// 首页-新闻模块3
    /// </summary>
    /// <param name="id"></param>
    protected void bd_new3(string id)
    {
        string name = "", nameid="";
        //select top 4 * from tb_u_info where IsElite=1 and userid in(select id from tb_User where Classid=" + id + " and GroupId in(5,6)) order by id
        string sql2 = "select Id,title from tb_U_schoolfl where Sid=" + id + " and mb_id=5";
        DataSet dm = HXD.DBUtility.SQLHelper.ExecuteDataset(sql2);
        if (dm.Tables[0].Rows.Count > 0)
        {
            name = dm.Tables[0].Rows[0]["title"].ToString();
            nameid = dm.Tables[0].Rows[0]["id"].ToString();
        }

        string sql = "select top 8 * from tb_u_info where ClassId=(select id from tb_U_schoolfl where Sid=" + id + " and mb_id=5) and userid in(select id from tb_User where  Classid=" + id + " and GroupId in(5,6))  order by id desc";
        DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {

            str_new3 += "<div class=\"hd\">";
            str_new3 += "<h3 class=\"title\">" + name + "</h3>";
            str_new3 += "<div class=\"more\"><a href=\"list.aspx?c=" + nameid + "\">MORE</a></div></div>";
            str_new3 += "<div class=\"bd\">";
            str_new3 += "<div class=\"hot\"><h3 style=\"text-align: center; font-family: Microsoft YaHei;\">";
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string yymm = StringDeal.GetDateTime(ds.Tables[0].Rows[i]["posttime"], "yyyy-MM-dd");
                if (i == 0)
                {

                    str_new3 += "<a target=\"_blank\" style=\"font-size: 18px; color: rgb(107, 41, 43);\" href=\"/news.aspx?id=" + ds.Tables[0].Rows[i]["id"].ToString() + "\">" + ds.Tables[0].Rows[i]["title"].ToString() + "</a></h3></div>";
                    str_new3 += "<div class=\"focusList\"><ul class=\"sidelist22\" >";
                }
                else
                {
                    str_new3 += "<li style=\";\"><span style=\"font-size: 14px; color: rgb(64, 64, 64);\">" + yymm + "</span><span class=\"spe\">|</span><a class=\"normal_title\" target=\"_blank\" title=\"" + ds.Tables[0].Rows[i]["title"].ToString() + "\" href=\"/news.aspx?id=" + ds.Tables[0].Rows[i]["id"].ToString() + "\">" + ds.Tables[0].Rows[i]["title"].ToString() + "</a></li>";
                }
            }
            str_new3 += "<li class=\"clear\"></li></ul></div></div>";
        }
    }

    /// <summary>
    /// 首页-新闻模块4
    /// </summary>
    /// <param name="id"></param>
    protected void bd_new4(string id)
    {
        string name = "",nameid="";
        //select top 4 * from tb_u_info where IsElite=1 and userid in(select id from tb_User where Classid=" + id + " and GroupId in(5,6)) order by id
        string sql2 = "select Id,title from tb_U_schoolfl where Sid=" + id + " and mb_id=6";
        DataSet dm = HXD.DBUtility.SQLHelper.ExecuteDataset(sql2);
        if (dm.Tables[0].Rows.Count > 0)
        {
            name = dm.Tables[0].Rows[0]["title"].ToString();
            nameid = dm.Tables[0].Rows[0]["id"].ToString();
        }

        string sql = "select top 8 * from tb_u_info where ClassId=(select id from tb_U_schoolfl where Sid=" + id + " and mb_id=6) and userid in(select id from tb_User where  Classid=" + id + " and GroupId in(5,6))  order by id desc";
        DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {

            str_new4 += "<div class=\"hd\">";
            str_new4 += "<h3 class=\"title\">" + name + "</h3>";
            str_new4 += "<div class=\"more\"><a href=\"list.aspx?c=" + nameid + "\">MORE</a></div></div>";
            str_new4 += "<div class=\"bd\">";
            str_new4 += "<div class=\"hot\"><h3 style=\"text-align: center; font-family: Microsoft YaHei;\">";
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string yymm = StringDeal.GetDateTime(ds.Tables[0].Rows[i]["posttime"], "yyyy-MM-dd");
                if (i == 0)
                {

                    str_new4 += "<a target=\"_blank\" style=\"font-size: 18px; color: rgb(107, 41, 43);\" href=\"/news.aspx?id=" + ds.Tables[0].Rows[i]["id"].ToString() + "\">" + ds.Tables[0].Rows[i]["title"].ToString() + "</a></h3></div>";
                    str_new4 += "<div class=\"focusList\"><ul class=\"sidelist22\" >";
                }
                else
                {
                    str_new4 += "<li style=\";\"><span style=\"font-size: 14px; color: rgb(64, 64, 64);\">" + yymm + "</span><span class=\"spe\">|</span><a class=\"normal_title\" target=\"_blank\" title=\"" + ds.Tables[0].Rows[i]["title"].ToString() + "\" href=\"/news.aspx?id=" + ds.Tables[0].Rows[i]["id"].ToString() + "\">" + ds.Tables[0].Rows[i]["title"].ToString() + "</a></li>";
                }
            }
            str_new4 += "<li class=\"clear\"></li></ul></div></div>";
        }
    }

    /// <summary>
    /// 首页底部轮播图
    /// </summary>
    /// <param name="id"></param>
    protected void bd_tw(string id)
    {
        string sql = "select top 4 * from tb_u_info where IsElite=1 and userid in(select id from tb_User where Classid=" + id + " and GroupId in(5,6)) order by id desc";
        DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                str_dimg += "<li style=\"float: left; display: inline-block; margin: 0px 17px 0px 0px;\">";
                str_dimg += "<a href=\"/news.aspx?id=" + ds.Tables[0].Rows[i]["id"].ToString() + "\" target=\"_blank\" title=\"" + ds.Tables[0].Rows[i]["title"].ToString() + "\"><img src=\"" + ds.Tables[0].Rows[i]["photo"].ToString() + "\" height=\"154\" width=\"226\"></a>";
                str_dimg += "<p class=\"label_pic_title2 center\" style=\"height: 52px; line-height: 52px; font-size: 14px;\"><a href=\"/item-view-id-1135.shtml\" target=\"_blank\" title=\"" + ds.Tables[0].Rows[i]["title"].ToString() + "\">" + ds.Tables[0].Rows[i]["title"].ToString() + "</a></p></li>";
            }

      
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HXD.Common;
using System.Data;

public partial class edumaste_new_fl : System.Web.UI.Page
{
    protected string strm = "",strarm="";

    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdManage(6);
        if (!IsPostBack)
        {
            
            string sql = "select classid from tb_user where ID=" + Session["userid"].ToString();
            string menid = HXD.DBUtility.SQLHelper.ExecuteScalar(sql).ToString();
            //string sql = "select * from tb_U_schoolfl where sid=" + menid;
            //Repeater1.DataSource = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
            //Repeater1.DataBind();
            bdlist(menid);
            getztOperation();
        }
    }
    /// <summary>
    /// 绑定数据
    /// </summary>
    protected void bdlist(string menid)
    {
        string sql = "select * from tb_U_schoolfl where depth=0 and menuid=1 and sid=" + menid;
         DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
         if (ds.Tables[0].Rows.Count > 0)
         {
             for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
             {
                 strarm += "<tr>";
                 strarm += "<td><input type=\"checkbox\" name=\"Id\" value=\""+ds.Tables[0].Rows[i]["id"].ToString()+"\"></td>";
                 strarm += "<td>" + ds.Tables[0].Rows[i]["id"].ToString() + "</td>";
                 strarm += "<td>" + getc(ds.Tables[0].Rows[i]["depth"].ToString()) + "<img src=\"assets/img/tree_plusmiddle1.png\"/>&nbsp;" + ds.Tables[0].Rows[i]["title"].ToString() + "</td>";
                 strarm += "<td class=\"am-hide-sm-only\">" + getmbname(ds.Tables[0].Rows[i]["mb_id"].ToString()) + "</td>";
                 strarm += "<td>";
                 strarm += "<div class=\"am-btn-toolbar\">";
                 strarm += "<div class=\"am-btn-group am-btn-group-xs\"><a class=\"am-btn am-btn-default am-btn-xs am-text-danger am-hide-sm-only am-text-sdary\" href=\"new_fladd.aspx?id=" + ds.Tables[0].Rows[i]["id"].ToString() + "\"><span class=\"am-icon-trash-o\"></span> 修改</a>";
                 strarm += "<a onClick=\"return confirm('确认删除')\" class=\"am-btn am-btn-default am-btn-xs am-text-danger am-hide-sm-only am-text-sdary\" href=\"new_fl.aspx?id=" + ds.Tables[0].Rows[i]["id"].ToString() + "&Action=del\"><span class=\"am-icon-trash-o\"></span> 删除</a>";
                 strarm += "</div></div></td></tr>";

                 string strid = ds.Tables[0].Rows[i]["id"].ToString();
                 string sql2 = "select * from tb_U_schoolfl where classid=" +strid;
                 DataSet dss = HXD.DBUtility.SQLHelper.ExecuteDataset(sql2);
                 if (dss.Tables[0].Rows.Count > 0)
                 {
                     string str = dss.Tables[0].Rows[0]["classid"].ToString();
                     bdclass(str);
                 }
             }
         }
    }

    protected void bdclass(string id)
    {
        string sql = "select * from tb_U_schoolfl where menuid=1 and classid=" + id;
        DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                strarm += "<tr>";
                strarm += "<td><input type=\"checkbox\" name=\"Id\" value=\"" + ds.Tables[0].Rows[i]["id"].ToString() + "\"></td>";
                strarm += "<td>" + ds.Tables[0].Rows[i]["id"].ToString() + "</td>";
                strarm += "<td>" + getc(ds.Tables[0].Rows[i]["depth"].ToString()) + "<img src=\"assets/img/tree_plusmiddle1.png\"/>&nbsp;" + ds.Tables[0].Rows[i]["title"].ToString() + "</td>";
                strarm += "<td class=\"am-hide-sm-only\">" + getmbname(ds.Tables[0].Rows[i]["mb_id"].ToString()) + "</td>";
                strarm += "<td>";
                strarm += "<div class=\"am-btn-toolbar\">";
                strarm += "<div class=\"am-btn-group am-btn-group-xs\"><a class=\"am-btn am-btn-default am-btn-xs am-text-danger am-hide-sm-only am-text-sdary\" href=\"new_fladd.aspx?id=" + ds.Tables[0].Rows[i]["id"].ToString() + "\"><span class=\"am-icon-trash-o\"></span> 修改</a>";
                strarm += "<a class=\"am-btn am-btn-default am-btn-xs am-text-danger am-hide-sm-only am-text-sdary\" href=\"new_fl.aspx?id=" + ds.Tables[0].Rows[i]["id"].ToString() + "&Action=del\"><span class=\"am-icon-trash-o\"></span> 删除</a>";
                strarm += "</div></div></td></tr>";

                string strid = ds.Tables[0].Rows[i]["id"].ToString();
                string sql2 = "select * from tb_U_schoolfl where classid=" + strid;
                DataSet dss = HXD.DBUtility.SQLHelper.ExecuteDataset(sql2);
                if (dss.Tables[0].Rows.Count > 0)
                {
                    string str = dss.Tables[0].Rows[0]["classid"].ToString();
                    bdclass(str);
                }
            }
        }
    }

    /// <summUry>
    /// 批量删除
    /// </summUry>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button2_Click(object sender, EventArgs e)
    {
        strm = Request["Id"];
        if (String.IsNullOrEmpty(strm))
        {
            StringDeal.Alter("请选择要审核的对象！");
        }
        else
        {
            string[] sArray = strm.Split(',');
            foreach (string i in sArray)
            {
                string sql2 = "delete from tb_U_schoolfl where id='" + i + "'";
                HXD.DBUtility.SQLHelper.ExecuteScalar(sql2);
            }
        }
        Response.Redirect("new_fl.aspx", true);
    }
    protected string getc(string str)
    {
        string stm = "";
        int id = int.Parse(str);
        for (int i = 0; i < id; i++)
        {
            stm += "<img src=\"assets/img/tree_treemiddle.png\"/><img src=\"assets/img/tree_treemiddle.png\"/>";
        }
        return stm;
    }
    protected string getmbname(string str)
    {
        string name = "";
        int i = int.Parse(str);
        switch (i)
        {
            case 1:
                name = "校园动态";
                break;
            case 2:
                name = "通知公告";
                break;
            case 3:
                name = "新闻模块1";
                break;
            case 4:
                name = "新闻模块2";
                break;
            case 5:
                name = "新闻模块3";
                break;
            case 6:
                name = "新闻模块4";
                break;
            default:
                name = "";
                break;
        }
        return name;
        
    }
    protected void getztOperation()
    {
        int icd = StringDeal.ToInt(Request.QueryString["Id"]);
        if (icd > 0)
        {
            string Action = Request.QueryString["Action"];
            if (Action == "del")
            {
                string sql = "delete from tb_U_schoolfl where ID='" + icd + "';";
                HXD.DBUtility.SQLHelper.ExecuteScalar(sql);
            }
            else if (Action == "lock")
            {
                string sql2 = "SELECT IsLock from tb_User where id='" + icd + "'";
                bool stra = bool.Parse(HXD.DBUtility.SQLHelper.ExecuteScalar(sql2).ToString());
                if (stra == true)
                {
                    string sql = "UPDATE tb_User set IsLock=0 where id='" + icd + "'";
                    HXD.DBUtility.SQLHelper.ExecuteScalar(sql);
                }
                else
                {
                    string sql = "UPDATE tb_User set IsLock=1 where id='" + icd + "'";
                    HXD.DBUtility.SQLHelper.ExecuteScalar(sql);
                }
            }


            Response.Redirect("new_fl.aspx", true);
        }
    }
}
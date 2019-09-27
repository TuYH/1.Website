﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class user_sc_fladd : System.Web.UI.Page
{
    protected string menid = "";
    protected int demp = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdManage(6);
        
            this.Select1.Items.Add(new ListItem("顶级栏目", "0"));
           
            string sql = "select classid from tb_user where ID=" + Session["userid"].ToString();
            menid = HXD.DBUtility.SQLHelper.ExecuteScalar(sql).ToString();
            bd(menid);
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string clssid = Request.QueryString["cid"].ToString();
        string icd = Session["userid"].ToString();
        string title = this.TextBox1.Text;
        string str_se = this.Select1.Value;
        //判断有没有上级
        
        int sid = pdsj(str_se);
        string sql = "insert into tb_U_schoolfl (title,ClassId,Sid,Depth,menuid)values('" + title + "','" + str_se + "','" + menid + "','" + sid + "','" + clssid + "')";
        HXD.DBUtility.SQLHelper.ExecuteScalar(sql);
        Response.Redirect("sc_fl.aspx?cid=" + clssid);
    }
    /// <summary>
    /// 绑定数据到select
    /// </summary>
    /// <param name="id"></param>
    protected void bd(string id)
    {
        string clssid = Request.QueryString["cid"].ToString();
        string sql = "select id,ClassId,title,depth from tb_U_schoolfl where menuid='" + clssid + "' and sid=" + id;
        DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string demp = ds.Tables[0].Rows[i]["depth"].ToString();
                string stritem = ds.Tables[0].Rows[i]["id"].ToString();
                string strvalues = "├ "+ds.Tables[0].Rows[i]["title"].ToString();
                strvalues = getc(demp) + strvalues;
                this.Select1.Items.Add(new ListItem(strvalues, stritem));

                //<option value="a">-The.CC</option>
            }
        }


     
    }
    /// <summary>
    /// 判断有没有上级
    /// </summary>
    /// <param name="icd"></param>
    /// <returns></returns>
    protected int pdsj(string icd)
    {

        string sql = "select * from tb_U_schoolfl where menuid=2 and id=" + icd;
         DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
         if (ds.Tables[0].Rows.Count > 0)
         {
             demp = demp + 1;
             string str = ds.Tables[0].Rows[0]["classid"].ToString();
             pdsj(str);
         }
         return demp;
       
    }

    protected string getc(string str)
    {
        string stm = "";
        int id = int.Parse(str);
        for (int i = 0; i < id; i++)
        {
            stm += "││";
        }
        return stm;
    }
}
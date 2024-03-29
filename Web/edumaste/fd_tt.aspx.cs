﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HXD.Common;
using System.Data;

public partial class edumaste_fd_tt : System.Web.UI.Page
{
    protected string strm = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        LoginCheck.AdManage(6);


        if (!IsPostBack)
        {

            string userid = Session["userid"].ToString();
            //string sql = "select * from tb_U_info where classid=1 and Userid=" + userid;

            //Repeater1.DataSource = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
            //Repeater1.DataBind();

            HXD.ModelField.BLL.Model bll = new HXD.ModelField.BLL.Model();
            HXD.ModelField.Model.Model mod = new HXD.ModelField.Model.Model();
            mod.Condition = " Userid=" + userid + " and classid=1";
            mod.FieldList = "classid,IsStatus,posttime";
            mod.TableName = "tb_U_info";
            mod.Sort = "Sort desc";
            mod.PageSize = 20;
            mod.PageIndex = HXD.Common.StringDeal.ToInt(Request.QueryString["page"]);
            DataSet ds1 = bll.ModelList(mod);
            DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset("select top 20 classid,IsStatus,posttime from tb_U_info where Userid=" + userid + " and classid=1 order by Sort desc,id desc;");
            this.Repeater1.DataSource = ds1;
            this.Repeater1.DataBind();

            HXD.Common.SgqPage pg = new HXD.Common.SgqPage();
            pg.PageSize = mod.PageSize;
            pg.PageIndex = mod.PageIndex;
            pg.RecordCount = (int)ds1.Tables[1].Rows[0][0];
            this.Literal1.Text = pg.PageView2();
            if (pg.RecordCount == 0)
            { this.Literal1.Text = "暂无数据！"; }
            ds.Clear();
            ds.Dispose();
            ds1.Clear();
            ds1.Dispose();
        }
    }
    protected string getname(string id)
    {
        string name = "";
        if (id == "1")
        {
            name = "团体辅导";
        }
        if (id == "2")
        {
            name = "沙盘辅导";
        }
        //string sql = "SELECT name from tb_U_user where id=" + id;
        //string name = HXD.DBUtility.SQLHelper.ExecuteScalar(sql).ToString();
        return name;
    }
    protected string getzt(string str)
    {
        string name = "";

        string zt_yes = "<img src=\"assets/img/yes.png\">";
        string zt_no = "<img src=\"assets/img/no.png\">";
        bool sta = bool.Parse(str);
        if (sta == true)
        {
            name = zt_no;
        }
        else
        {
            name = zt_yes;
        }
        return name;

        
    }
    protected void getztOperation()
    {
        int icd = StringDeal.ToInt(Request.QueryString["Id"]);
        if (icd > 0)
        {
            string Action = Request.QueryString["Action"];
            if (Action == "end")
            {
                string sql = "update tb_U_Message set state=2 where ID='" + icd + "'";
                HXD.DBUtility.SQLHelper.ExecuteScalar(sql);
            }
            Response.Redirect("fd_tt.aspx", true);
        }
    }
    /// <summUry>
    /// 审核
    /// </summUry>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
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

                string sql2 = "SELECT IsStatus from tb_U_info where id='" + i + "'";
                bool sta = bool.Parse(HXD.DBUtility.SQLHelper.ExecuteScalar(sql2).ToString());
                if (sta == true)
                {
                    string sql = "UPDATE tb_U_info set IsStatus=0 where id='" + i + "'";
                    HXD.DBUtility.SQLHelper.ExecuteScalar(sql);
                }
                else
                {
                    string sql = "UPDATE tb_U_info set IsStatus=1 where id='" + i + "'";
                    HXD.DBUtility.SQLHelper.ExecuteScalar(sql);
                }


            }
            Response.Redirect("fd_tt.aspx", true);
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        strm = Request["Id"];
        if (String.IsNullOrEmpty(strm))
        {
            StringDeal.Alter("请选择要删除的对象！");
        }
        else
        {
            string[] sArray = strm.Split(',');
            foreach (string i in sArray)
            {
                string sql2 = "delete from tb_U_info where id='" + i + "'";
                HXD.DBUtility.SQLHelper.ExecuteScalar(sql2);
            }
        }
        Response.Redirect("fd_tt.aspx", true);
    }
}
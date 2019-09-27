using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using HXD.Common;

public partial class edumaste_fd_gt : System.Web.UI.Page
{
    protected string strm = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        LoginCheck.AdManage(6);

        
        if (!IsPostBack)
        {

            string userid = Session["userid"].ToString();
            //string sql = "select * from tb_U_Message where zxs_id=" + userid;

            //Repeater1.DataSource = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
            //Repeater1.DataBind();


            HXD.ModelField.BLL.Model bll = new HXD.ModelField.BLL.Model();
            HXD.ModelField.Model.Model mod = new HXD.ModelField.Model.Model();
            mod.Condition = " zxs_id=" + userid + "";
            mod.FieldList = "state,uid,state,yy_time";
            mod.TableName = "tb_U_Message";
            mod.Sort = "Sort desc";
            mod.PageSize = 20;
            mod.PageIndex = HXD.Common.StringDeal.ToInt(Request.QueryString["page"]);
            DataSet ds1 = bll.ModelList(mod);
            DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset("select top 20 state,uid,state,yy_time from tb_U_Message where zxs_id=" + userid + " order by Sort desc,id desc;");
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
        string sql = "SELECT name from tb_U_user where id=" + id;
        string name = HXD.DBUtility.SQLHelper.ExecuteScalar(sql).ToString();
        return name;
    }
    protected string getzt(string str)
    {
        string name = "";
        try
        {

            int id = int.Parse(str);

            switch (id)
            {
                case 0:
                    name = "<span class=\" hd_tag_jh\">等待中</span>";
                    break;
                case 1:
                    name = "<span>咨询中</span>";
                    break;
                case 2:
                    name = "<span class=\"hd_tag_js\">已完成</span>";
                    break;
                case 5:
                    name = "<span class=\"hd_tag_js\">主动辅导</span>";
                    break;
                default:
                    name = "";
                    break;
            }
        }
        catch
        {

        }
       
        return name;
    }
    protected string getzt2(string str)
    {
        string name = "";
        int id = int.Parse(str);

        switch (id)
        {
           
           
            case 5:
                name = "主动辅导：";
                break;
            default:
                name = "收到预约";
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
            if (Action == "end")
            {
                string sql = "update tb_U_Message set state=2 where ID='" + icd + "'";
                HXD.DBUtility.SQLHelper.ExecuteScalar(sql);
            }
            Response.Redirect("fd_gt.aspx", true);
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
            Response.Redirect("new_list.aspx", true);
        }
    }
    
}
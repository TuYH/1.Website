using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HXD.Common;
using System.Data;

public partial class edumaste_new_list : System.Web.UI.Page
{
    protected string strm = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        LoginCheck.AdManage(6);

        getztOperation();
        if (!IsPostBack)
        {
           
            string userid = Session["userid"].ToString();
            //string sql = "select * from tb_U_info where userid="+userid;

            //Repeater1.DataSource = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
            //Repeater1.DataBind();

            HXD.ModelField.BLL.Model bll = new HXD.ModelField.BLL.Model();
            HXD.ModelField.Model.Model mod = new HXD.ModelField.Model.Model();
            mod.Condition = " userid=" + userid + " and classid not in(1,2)";
            mod.FieldList = "Title,PostTime,classid";
            mod.TableName = "tb_U_Info";
            mod.Sort = "Sort desc";
            mod.PageSize = 20;
            mod.PageIndex = HXD.Common.StringDeal.ToInt(Request.QueryString["page"]);
            DataSet ds1 = bll.ModelList(mod);
            DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset("select top 20 id,Title,classid from tb_U_Info where userid=" + userid + " and classid not in(1,2) order by Sort desc,id desc;");
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
        try
        {
            string sql = "SELECT title from tb_U_schoolfl where id=" + id;
            name = HXD.DBUtility.SQLHelper.ExecuteScalar(sql).ToString();
        }
        catch
        {

        }
        return name;
        //return "";
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
    protected string gettj(string str)
    {
       


        string name = "";

        string zt_yes = "<span class=\"label label-sm label-success\">推荐</span>";

        bool sta = bool.Parse(str);
        if (sta == true)
        {
            name = zt_yes;
        }
        else
        {
            name = "";
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
                string sql = "delete from tb_U_info where ID='" + icd + "'";
                HXD.DBUtility.SQLHelper.ExecuteScalar(sql);
            }
            else if (Action == "lock")
            {
                string sql2 = "SELECT IsStatus from tb_U_info where id='" + icd + "'";
                bool sta = bool.Parse(HXD.DBUtility.SQLHelper.ExecuteScalar(sql2).ToString());
                if (sta == true)
                {
                    string sql = "UPDATE tb_U_info set IsStatus=0 where id='" + icd + "'";
                    HXD.DBUtility.SQLHelper.ExecuteScalar(sql);
                }
                else
                {
                    string sql = "UPDATE tb_U_info set IsStatus=1 where id='" + icd + "'";
                    HXD.DBUtility.SQLHelper.ExecuteScalar(sql);
                }
            }
          


            Response.Redirect("new_list.aspx", true);
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
        Response.Redirect("new_list.aspx", true);
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        strm = Request["Id"];
        if (String.IsNullOrEmpty(strm))
        {
            StringDeal.Alter("请选择要推荐的对象！");
        }
        else
        {
            string[] sArray = strm.Split(',');
            foreach (string i in sArray)
            {

                string sql2 = "SELECT IsElite from tb_U_info where id='" + i + "'";
                bool sta = bool.Parse(HXD.DBUtility.SQLHelper.ExecuteScalar(sql2).ToString());
                if (sta == true)
                {
                    string sql = "UPDATE tb_U_info set IsElite=0 where id='" + i + "'";
                    HXD.DBUtility.SQLHelper.ExecuteScalar(sql);
                }
                else
                {
                    string sql = "UPDATE tb_U_info set IsElite=1 where id='" + i + "'";
                    HXD.DBUtility.SQLHelper.ExecuteScalar(sql);
                }


            }
            Response.Redirect("new_list.aspx", true);
        }
    }
}
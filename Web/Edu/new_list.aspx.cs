using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HXD.Common;

public partial class Edu_new_list : System.Web.UI.Page
{
    protected string strm = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        LoginCheck.AdManage(7);

        getztOperation();
        if (!IsPostBack)
        {
           
            string userid = Session["userid"].ToString();
            string sql = "select * from tb_U_info where userid="+userid;

            Repeater1.DataSource = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
            Repeater1.DataBind();


        }
    }
    protected string getname(string id)
    {
        string sql = "SELECT title from tb_U_schoolfl where id=" + id;
        string name = HXD.DBUtility.SQLHelper.ExecuteScalar(sql).ToString();
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
}
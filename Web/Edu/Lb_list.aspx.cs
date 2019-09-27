using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HXD.Common;

public partial class Edu_Lb_list : System.Web.UI.Page
{
    protected string strm = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        LoginCheck.AdManage();

        getztOperation();
        if (!IsPostBack)
        {

            string MenuId = Session["userid"].ToString();
            string sql_group = "select GroupId from tb_User where id=" + MenuId;
            int groupid = int.Parse(HXD.DBUtility.SQLHelper.ExecuteScalar(sql_group).ToString());

            if (groupid == 7)
            {
                //string sql_mid = "select Classid from tb_User where id=" + MenuId;
                //int scholl_id = int.Parse(HXD.DBUtility.SQLHelper.ExecuteScalar(sql_mid).ToString());
                string sql = "select * from tb_U_school order by id";

                Repeater1.DataSource = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
                Repeater1.DataBind();
            }
            else
            {
                StringDeal.Alter("您没有这个权限！");
            }


        }
    }
    protected string getname(string id)
    {
        string sql = "SELECT name from tb_U_User where id=" + id;
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
                string sql = "delete from tb_User where ID='" + icd + "';delete from tb_U_User where ID='" + icd + "'";
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


            Response.Redirect("Font_list3.aspx", true);
        }
    }
    /// <summUry>
    /// 批量删除
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

                string sql2 = "SELECT IsLock from tb_User where id='" + i + "'";
                bool stra = bool.Parse(HXD.DBUtility.SQLHelper.ExecuteScalar(sql2).ToString());
                if (stra == true)
                {
                    string sql = "UPDATE tb_User set IsLock=0 where id='" + i + "'";
                    HXD.DBUtility.SQLHelper.ExecuteScalar(sql);
                }
                else
                {
                    string sql = "UPDATE tb_User set IsLock=1 where id='" + i + "'";
                    HXD.DBUtility.SQLHelper.ExecuteScalar(sql);
                }


            }
            Response.Redirect("Font_list3.aspx", true);
        }
    }
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
                string sql2 = "delete from tb_User where id='" + i + "'";
                HXD.DBUtility.SQLHelper.ExecuteScalar(sql2);
            }
        }
        Response.Redirect("Font_list3.aspx", true);
    }
}
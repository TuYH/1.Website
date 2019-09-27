using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HXD.Common;

public partial class user_Lb_list : System.Web.UI.Page
{
    protected string strm = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        LoginCheck.AdManage(6);


        if (!IsPostBack)
        {
            if (Request.QueryString["lbid"]!=null)
            {
                string sql = "";
                string lbid = Request.QueryString["lbid"].ToString();
                if (lbid == "1")
                {
                     sql = "select * from t_exam_paper where Fpapertype=" + lbid;
                }
                if (lbid == "2")
                {
                     sql = "select * from t_exam_paper where Fpapertype>1";
                }
                Repeater1.DataSource = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
                Repeater1.DataBind();
            }
          


        }
    }

    protected string getzt(string str)
    {
        string sql = "select usersetting from tb_user where id=" + Session["userid"].ToString();
        string setting = HXD.DBUtility.SQLHelper.ExecuteScalar(sql).ToString();
        string name = "";

        string zt_yes = "<img src=\"assets/img/yes.png\">";
        string zt_no = "<img src=\"assets/img/no.png\">";

        if (setting.IndexOf(str) > -1)
        {  //包含指定的字符串，执行相应的代码
            name = zt_yes;
        }
        else
        {
            name = zt_no;
        }


        //bool sta = bool.Parse(str);
        //if (sta == true)
        //{
        //    name = zt_no;
        //}
        //else
        //{
        //   name = zt_yes;
        //}
        return name;
    }

    /// <summUry>
    /// 批量审核
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
            string sqlset = "select usersetting from tb_user where id=" + Session["userid"].ToString();
            string setting = HXD.DBUtility.SQLHelper.ExecuteScalar(sqlset).ToString();
            int i=0,ii=0;
             //string str = "1,2,3,4,39,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,90,91,93,94,0,5,6,7,8,9,11,13,18,19,20,21,22,23,24,25,27,28,29,31,40,41,42,44,53,54,55,58,59,62,63,64,65,67,68,69,88,89,92,95,96";
             string lbid = Request.QueryString["lbid"].ToString();
             if (lbid == "2")
             {
                 i = setting.IndexOf(",0,") ;
                 setting = setting.Substring(0, i);//,0 后的字符串
                 strm = setting + ",0,"+strm;
             }
             if (lbid == "1")
             {
                  ii = setting.IndexOf(",0,");
                  setting = setting.Substring(i);//0， 前面的字符串
                  
                  strm = strm + setting;
             }
             
            //string stra = str.Substring(i);//0， 后面的字符串
            //string strb = setting.Substring(0,ii);//,0 前的字符串



             string sql = "update tb_user set usersetting='" + strm + "' where ID=" + Session["userid"].ToString();
            HXD.DBUtility.SQLHelper.ExecuteScalar(sql);
            //string[] sArray = strm.Split(',');
            //foreach (string i in sArray)
            //{

            //    string sql2 = "SELECT IsLock from tb_User where id='" + i + "'";
            //    bool stra = bool.Parse(HXD.DBUtility.SQLHelper.ExecuteScalar(sql2).ToString());
            //    if (stra == true)
            //    {
            //        string sql = "UPDATE tb_User set IsLock=0 where id='" + i + "'";
            //        HXD.DBUtility.SQLHelper.ExecuteScalar(sql);
            //    }
            //    else
            //    {
            //        string sql = "UPDATE tb_User set IsLock=1 where id='" + i + "'";
            //        HXD.DBUtility.SQLHelper.ExecuteScalar(sql);
            //    }


            //}
            Response.Redirect("Lb_list.aspx?lbid=1", true);
        }
    }
  
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HXD.Common;
using System.Data;

public partial class User_Add_cp : System.Web.UI.Page
{
    protected string strm = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        LoginCheck.AdManage(5);


        if (!IsPostBack)
        {
                //string sql = "select * from t_exam_paper where Fpapertype=1";
                //Repeater1.DataSource = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
                //Repeater1.DataBind();
                lb(Session["userid"].ToString());
        }
    }
    protected void lb(string userid)
    {
        string setting = LoginCheck.LbManage(int.Parse(Session["userid"].ToString()));
        //string sql1 = "select UserSetting from tb_User where id=" + userid;
        //string UserSetting = HXD.DBUtility.SQLHelper.ExecuteScalar(sql1).ToString();
        setting = setting.Substring(1);
        setting = setting.Substring(0, setting.Length - 1);
        setting = setting.Replace("m", "0");
        string sql = "select Fpaperid,Fpapername from t_exam_paper where Fpaperid in (" + setting + ")";
        DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                string stritem = ds.Tables[0].Rows[i]["Fpaperid"].ToString();
                string strvalues = ds.Tables[0].Rows[i]["Fpapername"].ToString();

                this.Select1.Items.Add(new ListItem(strvalues, stritem));

                //<option value="a">-The.CC</option>
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
        String[] readerId = Request.Form.GetValues("Select1");
        Session["readerIds"] = readerId;

        strm = this.Select1.Value;
        if (strm == "0")
        {
            StringDeal.Alter("请选择要测评的量表！");
        }
        else
        {
            //string sqlset = "select usersetting from tb_user where id=" + Session["userid"].ToString();
            //string setting = HXD.DBUtility.SQLHelper.ExecuteScalar(sqlset).ToString();
            //int i = 0, ii = 0;
            ////string str = "1,2,3,4,39,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,90,91,93,94,0,5,6,7,8,9,11,13,18,19,20,21,22,23,24,25,27,28,29,31,40,41,42,44,53,54,55,58,59,62,63,64,65,67,68,69,88,89,92,95,96";
            //string lbid = Request.QueryString["lbid"].ToString();
            //if (lbid == "2")
            //{
            //    i = setting.IndexOf(",0,");
            //    setting = setting.Substring(0, i);//,0 后的字符串
            //    strm = setting + ",0," + strm;
            //}
            //if (lbid == "1")
            //{
            //    ii = setting.IndexOf(",0,");
            //    setting = setting.Substring(i);//0， 前面的字符串

            //    strm = strm + setting;
            //}

            //string stra = str.Substring(i);//0， 后面的字符串
            //string strb = setting.Substring(0,ii);//,0 前的字符串



            //string sql = "update tb_user set usersetting='" + strm + "' where ID=" + Session["userid"].ToString();
            //HXD.DBUtility.SQLHelper.ExecuteScalar(sql);
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
            Response.Redirect("add_cp2.aspx?lbid=" + strm, true);
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        strm = this.Select1.Value;
         if (strm=="0")
         {
             StringDeal.Alter("请选择要测评的量表！");
         }
         else
         {
             Response.Redirect("add_cp3.aspx?lbid=" + strm, true);
         }
    }
}
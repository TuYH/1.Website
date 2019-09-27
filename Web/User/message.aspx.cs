using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using HXD.Common;

public partial class user_message : System.Web.UI.Page
{
    protected string strm = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdManage();
        getztOperation();
        if (!IsPostBack)
        {

            string MenuId = Session["userid"].ToString();
            string sql_mid = "select Classid from tb_User where id=" + MenuId;
            int scholl_id = int.Parse(HXD.DBUtility.SQLHelper.ExecuteScalar(sql_mid).ToString());

            //string sql = "SELECT * from tb_User where Classid='" + scholl_id + "' and GroupId=1 order by id";

            //Repeater1.DataSource = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
            //Repeater1.DataBind();
            //cid 1=测评  2=预约  3=辅导 4=消息
            HXD.ModelField.BLL.Model bll = new HXD.ModelField.BLL.Model();
            HXD.ModelField.Model.Model mod = new HXD.ModelField.Model.Model();
            mod.Condition = " Classid=" + scholl_id + " and cid=4 and zxs_id=" + MenuId + "";
            mod.FieldList = "Content,ClassId,PostTime,IsStatus";
            mod.TableName = "tb_U_Message";
            mod.Sort = "Sort desc";
            mod.PageSize = 20;
            mod.PageIndex = HXD.Common.StringDeal.ToInt(Request.QueryString["page"]);
            DataSet ds1 = bll.ModelList(mod);
            DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset("select top 20 Content,ClassId,PostTime,IsStatus from tb_U_Message where Classid=" + scholl_id + "  order by Sort desc,id desc;");
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

            //审核
            int icd = StringDeal.ToInt(Request.QueryString["Id"]);
            string Action = Request.QueryString["Action"];
            if (Action == "lock")
            {
                string sql2 = "SELECT IsStatus from tb_U_Message where id='" + icd + "'";
                bool stra = bool.Parse(HXD.DBUtility.SQLHelper.ExecuteScalar(sql2).ToString());
              
                    string sql = "UPDATE tb_U_Message set IsStatus=1 where id='" + icd + "'";
                    HXD.DBUtility.SQLHelper.ExecuteScalar(sql);
                
            }
        }
    }
    protected void getztOperation()
    {
        int icd = StringDeal.ToInt(Request.QueryString["Id"]);
        if (icd > 0)
        {
            string Action = Request.QueryString["Action"];
            if (Action == "del")
            {
                string sql = "delete from tb_U_Message where ID='" + icd + "';";
                HXD.DBUtility.SQLHelper.ExecuteScalar(sql);
            }
            else if (Action == "lock")
            {
                string sql2 = "SELECT IsStatus from tb_U_Message where id='" + icd + "'";
                bool stra = bool.Parse(HXD.DBUtility.SQLHelper.ExecuteScalar(sql2).ToString());
                if (stra == true)
                {
                    string sql = "UPDATE tb_U_Message set IsStatus=0 where id='" + icd + "'";
                    HXD.DBUtility.SQLHelper.ExecuteScalar(sql);
                }
                else
                {
                    string sql = "UPDATE tb_U_Message set IsStatus=1 where id='" + icd + "'";
                    HXD.DBUtility.SQLHelper.ExecuteScalar(sql);
                }
            }


            Response.Redirect("message.aspx", true);
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

                string sql2 = "SELECT IsStatus from tb_U_Message where id='" + i + "'";
                bool stra = bool.Parse(HXD.DBUtility.SQLHelper.ExecuteScalar(sql2).ToString());
                if (stra == true)
                {
                    string sql = "UPDATE tb_U_Message set IsStatus=0 where id='" + i + "'";
                    HXD.DBUtility.SQLHelper.ExecuteScalar(sql);
                }
                else
                {
                    string sql = "UPDATE tb_U_Message set IsStatus=1 where id='" + i + "'";
                    HXD.DBUtility.SQLHelper.ExecuteScalar(sql);
                }


            }
            Response.Redirect("message.aspx", true);
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
                string sql2 = "delete from tb_U_Message where id='" + i + "'";
                HXD.DBUtility.SQLHelper.ExecuteScalar(sql2);
            }
        }
        Response.Redirect("message.aspx", true);
    }
    protected string getzt(string str)
    {
        string name = "";

        string zt_yes = "<span class=\"label label-sm label-success\">未读</span>";

        bool sta = bool.Parse(str);
        if (sta == true)
        {
            name = ""; ;
        }
        else
        {
            name = zt_yes;
        }
        return name;
    }
}
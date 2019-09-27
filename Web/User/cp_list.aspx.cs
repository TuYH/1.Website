using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using HXD.Common;

public partial class User_cp_list : System.Web.UI.Page
{
    protected string strm = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        LoginCheck.AdManage(5);


        if (!IsPostBack)
        {
            
            //string sql = "select * from tb_U_Cplist where post_uid=" + Session["userid"] + " order by id desc";
            //Repeater1.DataSource = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
            //Repeater1.DataBind();
            getztOperation();
            HXD.ModelField.BLL.Model bll = new HXD.ModelField.BLL.Model();
            HXD.ModelField.Model.Model mod = new HXD.ModelField.Model.Model();
            mod.Condition = "post_uid=" + Session["userid"];
            mod.FieldList = "title,cp_set,PostTime,cp_id,CreateUsers";
            mod.TableName = "tb_U_Cplist";
            mod.Sort = "Sort desc";
            mod.PageSize = 20;
            mod.PageIndex = HXD.Common.StringDeal.ToInt(Request.QueryString["page"]);
            DataSet ds1 = bll.ModelList(mod);
            DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset("select top 20 title,cp_set,PostTime,cp_id,CreateUsers from tb_U_Cplist where  post_uid='" + Session["userid"].ToString() + "' order by id desc;");
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

    protected string getlbname(string id)
    {
        string sql = "select Fpapername from t_exam_paper where Fpaperid=" + id;
        string name = HXD.DBUtility.SQLHelper.ExecuteScalar(sql).ToString();
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
            StringDeal.Alter("请选择要测评的量表！");
        }
        else
        {
            Response.Redirect("add_cp2.aspx?lbid=" + strm, true);
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        strm = Request["Id"];
        if (String.IsNullOrEmpty(strm))
        {
            StringDeal.Alter("请选择要测评的量表！");
        }
        else
        {
            Response.Redirect("add_cp3.aspx?lbid=" + strm, true);
        }
    }
    protected void getztOperation()
    {
        if (Request.QueryString["rid"] != null)
        {
                string icd = Request.QueryString["rid"].ToString();
                string Action = Request.QueryString["Action"];
                if (Action == "del")
                {
                    string sql = "delete from tb_U_Cplist where cp_id='" + icd + "';delete from tb_U_Message where rid= '" + icd + "'";
                    HXD.DBUtility.SQLHelper.ExecuteScalar(sql);
                    Response.Redirect("cp_list.aspx", true);
                }
                if (Action == "dec")
                {

                }


            
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class list : System.Web.UI.Page
{
    protected string list_title = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["c"]!=""||Request.QueryString["c"]!=null)
        {
            int id = int.Parse(Request.QueryString["c"].ToString());
            //string sql = "select id,Title,PostTime from tb_U_info where ClassId="+id;

            string sql2 = "select title from tb_U_schoolfl where Id="+id;
            list_title = HXD.DBUtility.SQLHelper.ExecuteScalar(sql2).ToString();

            //Repeater1.DataSource = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
            //Repeater1.DataBind();



        
            HXD.ModelField.BLL.Model bll = new HXD.ModelField.BLL.Model();
            HXD.ModelField.Model.Model mod = new HXD.ModelField.Model.Model();
            mod.Condition = " Classid=" + id + " ";
            mod.FieldList = "Title,PostTime";
            mod.TableName = "tb_U_Info";
            mod.Sort = "Sort desc";
            mod.PageSize = 20;
            mod.PageIndex = HXD.Common.StringDeal.ToInt(Request.QueryString["page"]);
            DataSet ds1 = bll.ModelList(mod);
            DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset("select top 20 id,Title from tb_U_Info where Classid=" + id + "   order by Sort desc,id desc;");
            this.Repeater1.DataSource = ds1;
            this.Repeater1.DataBind();
           
            HXD.Common.SgqPage pg = new HXD.Common.SgqPage();
            pg.PageSize = mod.PageSize;
            pg.PageIndex = mod.PageIndex;
            pg.RecordCount = (int)ds1.Tables[1].Rows[0][0];
            this.Literal1.Text = pg.PageView1();
            if (pg.RecordCount == 0)
            { this.Literal1.Text = "暂无数据！"; }
            ds.Clear();
            ds.Dispose();
            ds1.Clear();
            ds1.Dispose();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class edumaste_Chartss : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdManage(6);
        if (!IsPostBack)
        {
  /*          string sql = "select classid from tb_user where id=" + Session["userid"].ToString();
            string classid = HXD.DBUtility.SQLHelper.ExecuteScalar(sql).ToString();*/
            bd();
/*            lb(Session["userid"].ToString());*/
     /*       getztOperation();*/
        }

    }
    /// <summary>
    /// 绑定量表
    /// </summary>
    /// <param name="id"></param>
/*    protected void lb(string userid)
    {
        string setting = LoginCheck.LbManage(int.Parse(Session["userid"].ToString()));
        //string sql1 = "select UserSetting from tb_User where id=" + userid;
        //string UserSetting = HXD.DBUtility.SQLHelper.ExecuteScalar(sql1).ToString();
        setting = setting.Substring(1);
        setting = setting.Substring(0, setting.Length - 1);
        setting = setting.Replace("m", "0");
        string sql = "select Fpaperid,Fpapername from t_exam_paper where [User_id] in (" + setting + ")";
        DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
       
    }*/
   protected void Button1_Click(object sender, EventArgs e)
    {
        string sex = "", tj = "", stj = "", str_lb="";
        if (this.option1.Checked == true)
        {
            tj += "and sex='男'";
        }
        if (this.option2.Checked == true)
        {
            tj += "and sex='女'";
        }
        string str_mz = this.se_mz.Value;//民族
        if (str_mz != "0")
        {
            tj += "and nationality='" + str_mz + "'";
        }
        string name = this.TextBox1.Text;//名字
        if (name != "")
        {
            tj += "and Name like '%" + name + "%'";
        }
        string a_time = ks_time.Value;//开始时间
        if (a_time != "")
        {
            str_lb += "and postTime>='" + a_time + "'";
        }
        string b_time = js_time.Value;//结束时间
        if (b_time != "")
        {
            str_lb += "and postTime<='" + b_time + "'";
        }

        string classid = LoginCheck.getadminid();
        string sqld = "select id from tb_User where Classid=" + classid + " and GroupId=1";

        string sql = "select id from tb_U_user  where id in(" + sqld + ")  " + tj + "";
        //string sql2 = "select id,Fresultid,FstudentNo,Fpaperid,Fscore,Fresult,postTime from t_exam_results where Fresultid in(" + sql + ")";
        //Repeater1.DataSource = HXD.DBUtility.SQLHelper.ExecuteDataset(sql2);
        //Repeater1.DataBind();


        HXD.ModelField.BLL.Model bll = new HXD.ModelField.BLL.Model();
        HXD.ModelField.Model.Model mod = new HXD.ModelField.Model.Model();
        mod.Condition = "  Fresultid in(" + sql + ")  " + str_lb + "";
        mod.FieldList = "Fresultid,FstudentNo,Fpaperid,Fscore,Fresult,postTime";
        mod.TableName = "t_exam_results";
        mod.Sort = "postTime desc";
        mod.PageSize = 20;
        mod.PageIndex = HXD.Common.StringDeal.ToInt(Request.QueryString["page"]);
        DataSet ds1 = bll.ModelList(mod);
        DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset("select top 20 id,Fresultid,FstudentNo,Fpaperid,Fscore,Fresult,postTime from t_exam_results where Fresultid in(" + sql + ") " + str_lb + " order by postTime desc,id desc;");
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

    protected void bd()
    {
        string classid = LoginCheck.getadminid();
        string sqld = "select id from tb_User where Classid=" + classid + " and GroupId=1";

        string sql = "select id from tb_U_user  where id in(" + sqld + ") ";
        //string sql2 = "select id,Fresultid,FstudentNo,Fpaperid,Fscore,Fresult,postTime from t_exam_results where Fresultid in(" + sql + ")";
        //Repeater1.DataSource = HXD.DBUtility.SQLHelper.ExecuteDataset(sql2);
        //Repeater1.DataBind();


        HXD.ModelField.BLL.Model bll = new HXD.ModelField.BLL.Model();
        HXD.ModelField.Model.Model mod = new HXD.ModelField.Model.Model();
        mod.Condition = "";
        mod.FieldList = "[User_id],Creation_time";
        mod.TableName = "tb_VortexDecompression";
        mod.Sort = "Creation_time desc";
        mod.PageSize = 20;
        mod.PageIndex = HXD.Common.StringDeal.ToInt(Request.QueryString["page"]);
        DataSet ds1 = bll.ModelList(mod);
        DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset("select top 20 id,Creation_time from tb_VortexDecompression order by Creation_time desc,id desc;");
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
    /* protected string getname(string id)
     {
         string sql = "SELECT name from tb_U_User where id=" + id;
         string name = HXD.DBUtility.SQLHelper.ExecuteScalar(sql).ToString();
         return name;
     }
     protected string getlbname(string id)
     {
         string sql = "select Fpapername from tb_VortexDecompression where User_id = " + id;
         string name = HXD.DBUtility.SQLHelper.ExecuteScalar(sql).ToString();
         return name;
     }
     protected string getyinzi(string id,string id2)
     {
         string sql = "select Fsubitemname,Fscore from t_exam_subitems_score as a,t_exam_subitems as b where a.Fsubitemid=b.Fsubitemid and a.FstudentNo='" + id + "' and a.wid='" + id2 + "' order by Fsortfield";
         string name = "";
         DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
         if (ds.Tables[0].Rows.Count > 0)
          {
              for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
              {
                  name += ds.Tables[0].Rows[i]["Fsubitemname"].ToString() + ":" + ds.Tables[0].Rows[i]["Fscore"].ToString()+"、";
              }
          }
         return name;
     }*/
     protected void Button2_Click(object sender, EventArgs e)
     {
         string sex = "", tj = "", stj = "", str_lb = "";
         if (this.option1.Checked == true)
         {
             tj += "and sex='男'";
         }
         if (this.option2.Checked == true)
         {
             tj += "and sex='女'";
         }
         string str_mz = this.se_mz.Value;//民族
         if (str_mz != "0")
         {
             tj += "and nationality='" + str_mz + "'";
         }
         string name = this.TextBox1.Text;//名字
         if (name != "")
         {
             tj += "and Name like '%" + name + "%'";
         }
         string a_time = ks_time.Value;//开始时间
         if (a_time != "")
         {
             str_lb += "and FtestTime>='" + a_time + "'";
         }
         string b_time = js_time.Value;//结束时间
         if (b_time != "")
         {
             str_lb += "and FtestTime<='" + b_time + "'";
         }

         /*string classid = LoginCheck.getadminid();
         string sqld = "select id from tb_User where Classid=" + classid + " and GroupId=1";
         string sql = "select id from tb_U_user  where id in(" + sqld + ")  " + tj + "";
         string sqlcc = "select FstudentNo,Name,nianji,banji,Fpaperid,Fscore,Fresult,FtestTime,Fresultid,wid from t_exam_results as a,tb_U_User as b where a.Fresultid=b.id and a.Fresultid in(" + sql + ")  " + str_lb + "";
         DataSet ds= HXD.DBUtility.SQLHelper.ExecuteDataset(sqlcc);

         DataTable dt = new DataTable();
         DataColumn col = new DataColumn("学号", System.Type.GetType("System.String"));
         DataColumn col1 = new DataColumn("姓名", System.Type.GetType("System.String"));
         DataColumn col2 = new DataColumn("年级", System.Type.GetType("System.String"));
         DataColumn col3 = new DataColumn("班级", System.Type.GetType("System.String"));
         DataColumn col4 = new DataColumn("量表名称", System.Type.GetType("System.String"));
         DataColumn col5 = new DataColumn("得分", System.Type.GetType("System.String"));
         DataColumn col6 = new DataColumn("结果", System.Type.GetType("System.String"));
         DataColumn col7 = new DataColumn("因子结果", System.Type.GetType("System.String"));
         DataColumn col8 = new DataColumn("发布时间", System.Type.GetType("System.String"));
         dt.Columns.Add(col);
         dt.Columns.Add(col1);
         dt.Columns.Add(col2);
         dt.Columns.Add(col3);
         dt.Columns.Add(col4);
         dt.Columns.Add(col5);
         dt.Columns.Add(col6);
         dt.Columns.Add(col7);
         dt.Columns.Add(col8);
         DataRow row = dt.NewRow();
         if (ds.Tables[0].Rows.Count > 0)
         {
             for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
             {
                 row = dt.NewRow();
                 string Fpaperid = ds.Tables[0].Rows[i]["Fpaperid"].ToString();
                 row[0] = ds.Tables[0].Rows[i]["FstudentNo"].ToString();
                 row[1] = ds.Tables[0].Rows[i]["Name"].ToString();
                 row[2] = ds.Tables[0].Rows[i]["nianji"].ToString();
                 row[3] = ds.Tables[0].Rows[i]["banji"].ToString();
                 row[4] = getlbname(Fpaperid);
                 row[5] = ds.Tables[0].Rows[i]["Fscore"].ToString();
                 row[6] = ds.Tables[0].Rows[i]["Fresult"].ToString();
                 row[7] = getyinzi(ds.Tables[0].Rows[i]["FstudentNo"].ToString(), ds.Tables[0].Rows[i]["wid"].ToString());
                 row[8] = ds.Tables[0].Rows[i]["FtestTime"].ToString();

                 dt.Rows.Add(row);
             }
         }

         System.Collections.SortedList List = new System.Collections.SortedList();
         List.Add(0, "学号");
         List.Add(1, "姓名");
         List.Add(2, "年级");
         List.Add(3, "班级");
         List.Add(4, "量表名称");
         List.Add(5, "得分");
         List.Add(6, "结果");
         List.Add(7, "因子结果");
         List.Add(8, "发布时间");

         HXD.DALFactory.ExcelHelper.ExportByWeb(dt, "测评结果", "报表.xls");
         // Excelout.ExportByWeb(dt, "excel导出", "报表.xls");
         string sds = "2017-09-04 17:22:31";
         DateTime sd = DateTime.Parse(sds);
         HXD.DALFactory.Timess.DateStringFromNow(sd);*/
     }
    /*
     protected string getsname(string id)
     {
         string sql = "select title from tb_U_schoolfl where id=" + id;
         string name = HXD.DBUtility.SQLHelper.ExecuteScalar(sql).ToString();
         return name;
     }


     protected void getztOperation()
     {
         if (Request.QueryString["id"] != null)
         {
             int icd = int.Parse(Request.QueryString["Id"].ToString());
             if (icd > 0)
             {
                 string Action = Request.QueryString["Action"];
                 if (Action == "del")
                 {
                     string sql = "delete from t_exam_results where ID='" + icd + "'";
                     HXD.DBUtility.SQLHelper.ExecuteScalar(sql);
                 }


                 Response.Redirect("charts.aspx", true);
             }
         }
     }

     private void MakeTable()
     {
         // Create a DataTable. 
         DataTable table = new DataTable("Product");

         // Create a DataColumn and set various properties. 
         DataColumn column = new DataColumn();
         column.DataType = System.Type.GetType("System.Decimal");
         column.AllowDBNull = false;
         column.Caption = "Price";
         column.ColumnName = "Price";
         column.DefaultValue = 25;

         // Add the column to the table. 
         table.Columns.Add(column);

         // Add 10 rows and set values. 
         DataRow row;
         for (int i = 0; i < 10; i++)
         {
             row = table.NewRow();
             row["Price"] = i + 1;

             // Be sure to add the new row to the 
             // DataRowCollection. 
             table.Rows.Add(row);
         }
     }
     */
     protected void Button3_Click(object sender, EventArgs e)
     {
         string sex = "", tj = "", stj = "", str_lb = "";
         if (this.option1.Checked == true)
         {
             tj += "and sex='男'";
         }
         if (this.option2.Checked == true)
         {
             tj += "and sex='女'";
         }
         string str_mz = this.se_mz.Value;//民族
         if (str_mz != "0")
         {
             tj += "and nationality='" + str_mz + "'";
         }
         string name = this.TextBox1.Text;//名字
         if (name != "")
         {
             tj += "and Name like '%" + name + "%'";
         }
         string a_time = ks_time.Value;//开始时间
         if (a_time != "")
         {
             str_lb += "and FtestTime>='" + a_time + "'";
         }
         string b_time = js_time.Value;//结束时间
         if (b_time != "")
         {
             str_lb += "and FtestTime<='" + b_time + "'";
         }

       /*  string classid = LoginCheck.getadminid();
         string sqld = "select id from tb_User where Classid=" + classid + " and GroupId=1";
         string sql = "select id from tb_U_user  where id in(" + sqld + ")  " + tj + "";
         string sqlcc = "select FstudentNo,Name,nianji,banji,Fpaperid,Fscore,Fresult,FtestTime,Fresultid,wid from t_exam_results as a,tb_U_User as b where a.Fresultid=b.id and a.Fresultid in(" + sql + ")  " + str_lb + "";
         DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sqlcc);

         DataTable dt = new DataTable();

         dt.Columns.Add("学号", System.Type.GetType("System.String"));
         dt.Columns.Add("姓名", System.Type.GetType("System.String"));
         dt.Columns.Add("年级", System.Type.GetType("System.String"));
         dt.Columns.Add("班级", System.Type.GetType("System.String"));
         dt.Columns.Add("量表名称", System.Type.GetType("System.String"));
         dt.Columns.Add("得分", System.Type.GetType("System.String"));
         dt.Columns.Add("结果", System.Type.GetType("System.String"));
         dt.Columns.Add("发布时间", System.Type.GetType("System.String"));

         DataRow row = dt.NewRow();
         if (ds.Tables[0].Rows.Count > 0)
         {
             for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
             {
                 row = dt.NewRow();
                 string Fpaperid = ds.Tables[0].Rows[i]["Fpaperid"].ToString();

                 row["学号"] = ds.Tables[0].Rows[i]["FstudentNo"].ToString();
                 row["姓名"] = ds.Tables[0].Rows[i]["Name"].ToString();
                 row["年级"] = ds.Tables[0].Rows[i]["nianji"].ToString();
                 row["班级"] = ds.Tables[0].Rows[i]["banji"].ToString();
                 row["量表名称"] = getlbname(Fpaperid);
                 row["得分"] = ds.Tables[0].Rows[i]["Fscore"].ToString();
                 row["结果"] = ds.Tables[0].Rows[i]["Fresult"].ToString();
                 //dt.Rows.Add(getyinzi(ds.Tables[0].Rows[i]["FstudentNo"].ToString(), ds.Tables[0].Rows[i]["wid"].ToString()));
                 string sqlsa = "select Fsubitemname,Fscore from t_exam_subitems_score as a,t_exam_subitems as b where a.Fsubitemid=b.Fsubitemid and a.FstudentNo='" + ds.Tables[0].Rows[i]["FstudentNo"].ToString() + "' and a.wid='" + ds.Tables[0].Rows[i]["wid"].ToString() + "' order by Fsortfield";
                 DataSet dsa = HXD.DBUtility.SQLHelper.ExecuteDataset(sqlsa);
                 if (dsa.Tables[0].Rows.Count > 0)
                 {
                     for (int ii = 0; ii < dsa.Tables[0].Rows.Count; ii++)
                     {
                         string Fsubitemname = dsa.Tables[0].Rows[ii]["Fsubitemname"].ToString();
                         row[Fsubitemname] = dsa.Tables[0].Rows[ii]["Fscore"].ToString();
                     }
                 }
                 row["发布时间"] = ds.Tables[0].Rows[i]["FtestTime"].ToString();

                 dt.Rows.Add(row);
             }
         }



         HXD.DALFactory.ExcelHelper.ExportByWeb(dt, "测评结果", "报表.xls");
         // Excelout.ExportByWeb(dt, "excel导出", "报表.xls");
         string sds = "2017-09-04 17:22:31";
         DateTime sd = DateTime.Parse(sds);
         HXD.DALFactory.Timess.DateStringFromNow(sd);*/
     }
}
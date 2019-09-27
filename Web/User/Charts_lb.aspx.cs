using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class User_Charts_lb : System.Web.UI.Page
{
    protected string sc_name = "", sc_note = "",lb_name="";
    protected string c_xs = "", c_ls = "", c_xz = "", c_cp = "";
    protected string s_Fscore1 = "", s_Fscore2 = "", s_Fscore3 = "", s_Fscore4 = "",s_count="",s_url="";
    protected int fscore = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdManage(5);
        if (!IsPostBack)
        {


            string uid = Session["userid"].ToString();
            string s_name2 = Session["AdminManage"].ToString();


            Int64 lb_id = Convert.ToInt64(Request.QueryString["id"].ToString());
            //int lb_id = int.Parse();
            string sql = "select cp_set,cp_umun,Posttime from tb_U_Cplist where cp_id=" + lb_id;
            DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                int csid = int.Parse(ds.Tables[0].Rows[0]["cp_set"].ToString());
                string sql2 = "select Fpapername from t_exam_paper where Fpaperid in (" + csid + ")";
                lb_name = HXD.DBUtility.SQLHelper.ExecuteScalar(sql2).ToString();
                sc_name = "量表：" + lb_name;
                sc_note = "发布时间：" + ds.Tables[0].Rows[0]["Posttime"].ToString();
                c_ls = ds.Tables[0].Rows[0]["cp_umun"].ToString();//总人数

                string sql_res = "select count(id) from t_exam_results where wid='" + lb_id + "'";
                int num_c = int.Parse(HXD.DBUtility.SQLHelper.ExecuteScalar(sql_res).ToString());//已测评人数
                c_xs = num_c.ToString();

                int a = num_c;
                int b = int.Parse(c_ls);
                double percent = (double)a / b;
                c_cp = percent.ToString("0.0%");//完成率
                fscore = 0;//预警分数
                double yzscore = 0;
                double yzscore_h = 0;

                switch (csid)
                {
                    case 1:
                        fscore = 160;
                        yzscore = 2.0;
                        break;

                    case 93:
                        fscore = 65;
                        yzscore = 8;
                        yzscore_h = 10;
                        break;

                    default:
                        break;
                }


                string sql_160 = "select COUNT(id) from t_exam_results where wid='" + lb_id + "' and Fscore>='" + fscore + "'";
                s_Fscore4 = HXD.DBUtility.SQLHelper.ExecuteScalar(sql_160).ToString();//预警
                string sql_150 = "select COUNT(id) from t_exam_results where wid='" + lb_id + "' and Fscore<'" + fscore + "'";
                s_Fscore2 = HXD.DBUtility.SQLHelper.ExecuteScalar(sql_150).ToString();//正常

                //string sql22 = "select * from t_exam_subitems where Fpaperid='" + csid + "'";
                //DataSet dsa = HXD.DBUtility.SQLHelper.ExecuteDataset(sql22);

                //if (dsa.Tables[0].Rows.Count > 0)//判断是否有因子
                //{

                //    for (int i = 0; i < dsa.Tables[0].Rows.Count; i++)
                //    {
                //        int Fsubitemid = int.Parse(dsa.Tables[0].Rows[i]["Fsubitemid"].ToString());
                //        string fsname = dsa.Tables[0].Rows[i]["Fsubitemname"].ToString();
                //        string sqla = "select count(distinct Fresultid)  from t_exam_subitems_score where Fsubitemid='" + Fsubitemid + "' and [Fscore] >='" + yzscore + "' and [wid] ='" + lb_id + "'";
                //        string sqlb = "select count(distinct Fresultid)  from t_exam_subitems_score where Fsubitemid='" + Fsubitemid + "' and [Fscore] <'" + yzscore + "' and [wid] ='" + lb_id + "'";
                //        string a_score = HXD.DBUtility.SQLHelper.ExecuteScalar(sqla).ToString();
                //        string b_score = HXD.DBUtility.SQLHelper.ExecuteScalar(sqlb).ToString();
                //        s_count += "<div class=\"row\"><div class=\"am-u-md-6 am-u-sm-12 row-mb\"><div class=\"tpl-portlet\"><div class=\"tpl-portlet-title\"><div class=\"tpl-caption font-green \"><i class=\"am-icon-cloud-download\"></i>";
                //        s_count += "<span> 因子：" + fsname + "结果汇总</span></div><div class=\"actions\"><ul class=\"actions-btn\"></ul></div></div>";
                //        s_count += "<div class=\"tpl-echarts\" id=\"sl_main" + i + "\"></div>";
                //        s_count += "<script type=\"text/javascript\">";
                //        s_count += "var myChart = echarts.init(document.getElementById('sl_main" + i + "'));";
                //        s_count += " option = {";
                //        s_count += "title: {";
                //        s_count += "text: '" + lb_name + "-" + fsname + "',";
                //        s_count += "subtext: '',";
                //        s_count += "x: 'center'";
                //        s_count += "},";
                //        s_count += "tooltip: {";
                //        s_count += "trigger: 'item', color: ['green', 'red'],";
                //        s_count += "formatter: \"{a} <br/>{b} : {c} ({d}%)\"";
                //        s_count += "},";
                //        s_count += "legend: {";
                //        s_count += "orient: 'vertical',";
                //        s_count += "left: 'left',";
                //        s_count += "data: ['" + fsname + ">=" + yzscore + "', '" + fsname + "<" + yzscore + "']";
                //        s_count += "},";
                //        s_count += "series: [";
                //        s_count += "{";
                //        s_count += "name: '测评结果',";
                //        s_count += " type: 'pie',";
                //        s_count += "radius: '55%',";
                //        s_count += "center: ['50%', '60%'],";
                //        s_count += "data: [";
                //        s_count += "{ value: " + a_score + ", name: '" + fsname + ">=" + yzscore + "' },{ value:" + b_score + ", name: '" + fsname + "<" + yzscore + "' }";
                //        s_count += " ],";
                //        s_count += "itemStyle: {";
                //        s_count += "emphasis: {";
                //        s_count += "shadowBlur: 10,";
                //        s_count += "shadowOffsetX: 0,";
                //        s_count += "shadowColor: 'rgba(223,42,27, 0.5)'}}}]};";
                //        s_count += "myChart.setOption(option);</script>";



                //        s_count += "</div></div>";
                //        s_count += "<div class=\"am-u-md-6 am-u-sm-12 row-mb\"><div class=\"tpl-portlet\"><div class=\"tpl-portlet-title\"><div class=\"tpl-caption font-red \"><i class=\"am-icon-bar-chart\"></i><span> 需干预学生资料</span></div>";
                //        s_count += "<div class=\"actions\"><ul class=\"actions-btn\"><li class=\"green\"></li></ul></div></div>";
                //        //s_count += "<div class=\"actions\"><ul class=\"actions-btn\"><li class=\"green\"><a href=\"font_list3.aspx?Fsubitemid=" + Fsubitemid + "&Fscore=" + yzscore + "&wid=" + lb_id + "\">更多</a></li></ul></div></div>";
                //        s_count += "<div class=\"tpl-scrollable\">";

                //        s_count += "<table class=\"am-table tpl-table\">";
                //        s_count += "<thead><tr class=\"tpl-table-uppercase\"><th>测试人</th><th>总分</th><th>" + fsname + "得分</th><th>测试时间</th><th>操作</th></tr></thead><tbody>";
                //        //string sqla = "select count(distinct Fresultid)  from t_exam_subitems_score where Fsubitemid='" + Fsubitemid + "' and [Fscore] >='" + yzscore + "' and [wid] ='" + lb_id + "'";
                //        string sqlc = "select top 8 id,FstudentNo,Fscore,posttime from t_exam_results where [Fresultid] in(select distinct Fresultid  from t_exam_subitems_score where Fsubitemid='" + Fsubitemid + "' and [Fscore] >='" + yzscore + "' and [wid] ='" + lb_id + "')";
                //        DataSet dsc = HXD.DBUtility.SQLHelper.ExecuteDataset(sqlc);
                //        for (int ii = 0; ii < dsc.Tables[0].Rows.Count; ii++)
                //        {
                //            s_count += "<tr><td>";
                //            s_count += "<img src=\"assets/img/user01.png\" alt=\"\" class=\"user-pic\">";
                //            s_count += "<a class=\"user-name\" href=\"###\">" + getname(dsc.Tables[0].Rows[ii]["FstudentNo"].ToString()) + "</a></td>";
                //            s_count += "<td class=\"font-green \">" + dsc.Tables[0].Rows[ii]["Fscore"].ToString() + "</td>";
                //            s_count += "<td class=\"font-red \">" + getscore(dsc.Tables[0].Rows[ii]["FstudentNo"].ToString(), Fsubitemid.ToString(), lb_id.ToString()) + "</td>";
                //            s_count += "<td>" + dsc.Tables[0].Rows[ii]["posttime"].ToString() + "</td><td>";
                //            s_count += "<a class=\"user-name\" href=\"/user/chart_scl.aspx?rid=" + dsc.Tables[0].Rows[ii]["id"].ToString() + "&Action=lock\">查看</a></td></tr>";
                //        }
                //        s_count += "</tbody></table></div></div></div></div>";

                //    }
                //}

                s_url = "<a href=\"font_list3.aspx?Fsubitemid=" + csid + "&Fscore=" + fscore + "&wid=" + lb_id + "\">更多</a>";

                string sqldb = "select top 8 FstudentNo,Fscore,posttime,id from t_exam_results where Fscore>='" + fscore + "' and wid='" + lb_id + "' order by id desc";
                Repeater1.DataSource = HXD.DBUtility.SQLHelper.ExecuteDataset(sqldb);
                Repeater1.DataBind();
            }
            else
            {

            }


        }
    }

    protected string getscore(string FstudentNo, string Fsubitemid, string wid)
    {
        string sql = "select [Fscore]  from t_exam_subitems_score where Fsubitemid='" + Fsubitemid + "'  and [wid] ='" + wid + "' and [FstudentNo] ='" + FstudentNo + "'";
        string name = HXD.DBUtility.SQLHelper.ExecuteScalar(sql).ToString();
        return name;
    }

    protected string getname(string id)
    {
        string sql = "select name from tb_U_User where Id in(select id from tb_User where UserName='" + id + "')";
        string name = HXD.DBUtility.SQLHelper.ExecuteScalar(sql).ToString();
        return name;
    }

    protected string gettime(string id)
    {
        string sql = "select COUNT(Fresultid) from t_exam_results where Fresultid=" + id;
        string name = HXD.DBUtility.SQLHelper.ExecuteScalar(sql).ToString();
        return name;
    }
    protected string gettime2(string id)
    {
        string sql = "SELECT COUNT(id) from tb_U_Message where ClassId =" + id;
        string name = HXD.DBUtility.SQLHelper.ExecuteScalar(sql).ToString();
        return name;
    }
}
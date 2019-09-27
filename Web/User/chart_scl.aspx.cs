using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing.Printing;
using System.Drawing;

public partial class User_chart_scl : System.Web.UI.Page
{
    protected string str_name = "", str_nianji = "", str_banji = "", str_jieguo = "", str_note = "", posttime = "", str_content = "", str_df = "", str_time = "", lb_name = "", resname = "", str_daan = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdManage();
       
        if (!IsPostBack)
        {
            stre();
        }
       
    }
    protected string jieguo(string id)
    {
        string str = "";
        switch (id)
        {
            case "0":
                str = "A";
                break;
            case "1":
                str = "B";
                break;
            case "2":
                str = "C";
                break;
            case "3":
                str = "D";
                break;
            case "4":
                str = "E";
                break;
            default: break;
        }

        return str;
    }
    protected void stre()
    {
        string icd=Request.QueryString["rid"];
       
        string userid = Session["userid"].ToString();
        string sql = "select * from t_exam_results where id="+icd;
        DataSet da = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
        str_jieguo = da.Tables[0].Rows[0]["fresult"].ToString();
        string posttime = Convert.ToDateTime(da.Tables[0].Rows[0]["posttime"].ToString()).ToString("yyyy-MM-dd");
        string stid = da.Tables[0].Rows[0]["Fresultid"].ToString();
        str_df=da.Tables[0].Rows[0]["Fscore"].ToString();
        str_time = da.Tables[0].Rows[0]["posttime"].ToString();
        str_name = getname(stid);
        str_banji = getbjname(stid);
        str_nianji = getnjname(stid);
        string wid = da.Tables[0].Rows[0]["wid"].ToString();
         string ssid=da.Tables[0].Rows[0]["Fpaperid"].ToString();
        string sqla2 = "select Fpapertype from t_exam_paper where Fpaperid='" + ssid + "'";
        int ccid = int.Parse(HXD.DBUtility.SQLHelper.ExecuteScalar(sqla2).ToString());

        string daan = da.Tables[0].Rows[0]["Fanswer"].ToString();
        string[] scoreArray = daan.Split('|');
        for (int i = 0; i < scoreArray.Length; i++)
        {
            int a = i + 1;
            str_daan += a + "." + jieguo(scoreArray[i]) + " ";
        }

        if (ccid > 1)
        {
            // string sqlscore = "select * from t_exam_result_ref where Fexampaperid=55";

            double totalScore = Math.Round(double.Parse(str_df), 2);
            string sqlscore = "select * from t_exam_result_ref where Fexampaperid='" + ssid + "'";
            DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sqlscore);
            if (ds.Tables[0].Rows.Count > 0)
            {

                for (int ii = 0; ii < ds.Tables[0].Rows.Count; ii++)
                {
                    //string dc_name = ds.Tables[0].Rows[ii]["Fsubitemname"].ToString();
                    string dc_score = ds.Tables[0].Rows[ii]["FscoreSpan"].ToString();
                    string dc_note = ds.Tables[0].Rows[ii]["FresultText"].ToString();

                    string[] sArray3 = dc_score.Split('|');
                    double option1 = Math.Round(double.Parse(sArray3[0]), 2);
                    double option2 = Math.Round(double.Parse(sArray3[1]), 2);
                    //int option1 = int.Parse(sArray3[0]);
                    //int option2 = int.Parse(sArray3[1]);

                    if (totalScore >= option1 && totalScore < option2)
                    {
                        str_jieguo = dc_note;
                    }
                }
            }

        }
        else
        {
            string lbname_sql = "select Fpapername from t_exam_paper where Fpaperid='" + da.Tables[0].Rows[0]["Fpaperid"].ToString() + "'";
            lb_name = HXD.DBUtility.SQLHelper.ExecuteScalar(lbname_sql).ToString();

            string sql2 = "select * from t_exam_subitems_score where Fresultid=" + stid + " and wid='" + wid + "'";
            DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sql2);
            if (ds.Tables[0].Rows.Count > 0)
            {
                str_content += "<table width=\"100%\" align=\"center\" class=\"tabler\">";
                str_content += "<tbody>";
                str_content += "<tr >";
                str_content += "<td width=\"20%\" style=\"text-align: center;background-color:#32c5d2;color:white;\" class=\"tabletd\">因子</td>";
                str_content += "<td width=\"10%\" style=\"text-align: center;background-color:#32c5d2;color:white;\" class=\"tabletd\">得分</td>";
                str_content += "<td width=\"70%\" style=\"text-align: center;background-color:#32c5d2;color:white;\" class=\"tabletd\">解释</td>";
                str_content += "</tr>";
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string re_name = getlbname(ds.Tables[0].Rows[i]["Fsubitemid"].ToString());
                    resname += "'" + re_name + "',";
                    double result = double.Parse(ds.Tables[0].Rows[i]["Fscore"].ToString());
                    if (i == 0)
                    {
                        str_note += ds.Tables[0].Rows[i]["Fscore"].ToString();
                    }
                    else
                    {
                        str_note += "," + ds.Tables[0].Rows[i]["Fscore"].ToString();
                    }

                    string sqll = "select * from t_exam_subitems_result_ref where Fsubitemname='" + re_name + "'";
                    DataSet dc = HXD.DBUtility.SQLHelper.ExecuteDataset(sqll);
                    if (dc.Tables[0].Rows.Count > 0)
                    {

                        for (int ii = 0; ii < dc.Tables[0].Rows.Count; ii++)
                        {
                            string dc_name = dc.Tables[0].Rows[ii]["Fsubitemname"].ToString();
                            string dc_score = dc.Tables[0].Rows[ii]["FscoreSpan"].ToString();
                            string dc_note = dc.Tables[0].Rows[ii]["FresultText"].ToString();

                            string[] sArray3 = dc_score.Split('|');
                            double option1 = Math.Round(double.Parse(sArray3[0]), 2);
                            double option2 = Math.Round(double.Parse(sArray3[1]), 2);

                            if (result >= option1 && result < option2)
                            {
                                //staa += dc_name + "分析:" + dc_note + "<br/><br/>";
                                //str_content += "";
                                //str_content += "<li>";
                                //str_content += "<div class=\"cosC\">" + re_name + ":" + result + "</div>";
                                //str_content += "<div class=\"cosA\"><span class=\"cosIco\"><i class=\"am-icon-bell-o\"></i></span>";
                                //str_content += "<span> " + dc_note + "";
                                //str_content += "</div></li>";

                                str_content += "<tr>";
                                str_content += "<td width=\"20%\" style=\"text-align: center\">" + re_name + "</td>";
                                str_content += "<td width=\"10%\" style=\"text-align: center\">" + result + "</td>";
                                str_content += "<td width=\"70%\">" + dc_note + "</td>";
                                str_content += "</tr>";
                            }
                        }

                    }
                }

                resname = resname.Substring(0, resname.Length - 1);
                str_content += "</tbody></table>";
            }
        }

    }
    protected string getlbname(string id)
    {
        string sql = "select Fsubitemname from t_exam_subitems where Fsubitemid=" + id;
        string name = HXD.DBUtility.SQLHelper.ExecuteScalar(sql).ToString();
        return name;
    }
    protected string getname(string id)
    {
        string sql = "SELECT name from tb_U_User where id=" + id;
        string name = HXD.DBUtility.SQLHelper.ExecuteScalar(sql).ToString();
        return name;
    }

    protected string getbjname(string id)
    {
        string sql = "SELECT banji from tb_U_User where id=" + id;
        string name = HXD.DBUtility.SQLHelper.ExecuteScalar(sql).ToString();
        return name;
    }
    protected string getnjname(string id)
    {
        string sql = "SELECT nianji from tb_U_User where id=" + id;
        string name = HXD.DBUtility.SQLHelper.ExecuteScalar(sql).ToString();
        return name;
    }

   



}
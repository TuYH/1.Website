using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class cp_cp : System.Web.UI.Page
{
    protected string cp_name = "", cp_note = "", questions = "", cp_id = "", cp_questioncun="";
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdManage();


        string cp_title = "select * from t_exam_paper where Fpaperid=1";//测评标题
        string cp_questions = "select * from t_exam_questions where Fexampaperid=1";//测评问题
        string cp_questions_score = "select * from t_exam_score_ref where Fexampaperid=1 order by Fquestionid";//测评答案分数
        string cp_questions_options = "select * from t_exam_options where Foptionid=9";//测评答案选项
        cp_questioncun = HXD.DBUtility.SQLHelper.ExecuteScalar("select COUNT(Fexampaperid) from t_exam_questions where Fexampaperid=1").ToString();
        DataSet cp = HXD.DBUtility.SQLHelper.ExecuteDataset(cp_title);
        if (cp.Tables[0].Rows.Count > 0)
        {
            cp_name = cp.Tables[0].Rows[0]["Fpapername"].ToString();//测评题目
            cp_note = cp.Tables[0].Rows[0]["Fdescription"].ToString();//测评简介
            cp_id = cp.Tables[0].Rows[0]["Fpaperid"].ToString();//测评简介
        }


        DataSet ques = HXD.DBUtility.SQLHelper.ExecuteDataset(cp_questions);
        for (int i = 0; i < ques.Tables[0].Rows.Count; i++)
        {
            int b = i + 1;
            string ques_title = ques.Tables[0].Rows[i]["Fquestion"].ToString();
            string sql22 = "select Fscoreref from t_exam_score_ref where Fexampaperid=1 and Fquestionid=" + b;
            string core = HXD.DBUtility.SQLHelper.ExecuteScalar(sql22).ToString();
            string[] sArray = core.Split('|');
            string option1 = sArray[0];
            string option2 = sArray[1];
            string option3 = sArray[2];
            string option4 = sArray[3];
            string option5 = sArray[4];

            questions +="<div id=\"panel2\" class=\"panel-body js_answer\" style=\"display: none;\">";
            questions +="<form action=\"#\" method=\"POST\"><a name=\"result\" href=\"javascript:void(0)\"></a>";
            questions +="<div class=\"form-group avatar text-center\"><label for=\"\" class=\"sr-only\">前言</label>";
            questions +="<a href=\"javascript:void(0)\" class=\"img-circle\" name=\"1\"><span style=\"float: left;text-align: center; width: 100%; padding-top: 18px;\"><img src=\"ks.jpg\"></span> </a></div>";
            questions += "<dl><dd>" + b + "." + ques_title + "</dd></dl>";
            questions +="<ul class=\"list-group  js_group\">";
            DataSet option = HXD.DBUtility.SQLHelper.ExecuteDataset(cp_questions_options);
              for (int ii = 0; ii < option.Tables[0].Rows.Count; ii++)
              {
                  string options = option.Tables[0].Rows[ii]["Foptionitemvalue"].ToString();
                  questions += "<li class=\"list-group-item\" onclick=\"return toggle(this);\">";
                  questions += "<input name=\"g\" type=\"radio\" class=\"\" value=\"" + sArray[ii] + "\" />" + options + "</li>";
              }
            questions += "</ul></form></div>";
        }

        
    }
    protected string stra()
    {
        string sta = "0|1|2|3|4|5|1|2|3|4|5|1|2|3|4|5|1|2|3|4|5|1|2|3|4|5|1|2|3|4|5|1|2|3|4|5|1|2|3|4|5|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1";
        sta = sta.Replace("0|", "");

        return "123";
    }
    #region 获取字段的标题
    /// <summary>
    /// 获取字段的标题
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="Title"></param>
    /// <returns></returns>
    protected string GetFieldTitle(string FieldName)
    {
        string Results = "";
       
        return Results;
    }
    #endregion

    #region 获取得分的报告
    /// <summary>
    /// 获取字段的标题
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="Title"></param>
    /// <returns></returns>

    protected string GetFieldNote(string sta)
    {
        string staa = "";
        //string sta = "5|4|4|4|4|4|2|2|3|2|3|2|2|2|3|2|2|2|3|3|3|3|2|3|3|2|4|3|3|3|4|2|2|2|2|2|2|2|2|2|2|2|2|2|2|3|3|3|4|4|3|3|4|4|3|3|3|3|3|3|3|3|3|3|3|3|3|3|3|3|3|3|3|3|3|3|3|3|3|3|3|3|3|3|3|4|2|2|1|1";
        sta = sta.Replace("0|", "");
        string[] sArray = sta.Split('|');


        //string sql = "select * from t_exam_subitems where Fsubitemid=1025";
        string sql = "select * from t_exam_subitems where Fpaperid=1 order by Fsortfield";
        DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {

            for (int ii = 0; ii < ds.Tables[0].Rows.Count; ii++)
            {
                int score = 0;
                string title = ds.Tables[0].Rows[ii]["Fsubitemname"].ToString();
                string questiongs = ds.Tables[0].Rows[ii]["Fquestions"].ToString();
                string[] sArray2 = questiongs.Split('|');
                foreach (string i in sArray2)
                {
                    int s = int.Parse(i.ToString()) - 1;
                    score += int.Parse(sArray[s].ToString());
                }
                //decimal str = score / sArray2.Count()*1.0;
                double result = Math.Round(((double)score / sArray2.Count() * 1.0), 2);
                staa += title + "得分：" + result.ToString() + "<br/>";

                string sql2 = "select * from t_exam_subitems_result_ref where Fsubitemname='" + title + "'";
                DataSet dc = HXD.DBUtility.SQLHelper.ExecuteDataset(sql2);
                if (dc.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dc.Tables[0].Rows.Count; i++)
                    {
                        string dc_name = dc.Tables[0].Rows[i]["Fsubitemname"].ToString();
                        string dc_score = dc.Tables[0].Rows[i]["FscoreSpan"].ToString();
                        string dc_note = dc.Tables[0].Rows[i]["FresultText"].ToString();

                        string[] sArray3 = dc_score.Split('|');
                        double option1 = Math.Round(double.Parse(sArray3[0]), 2);
                        double option2 = Math.Round(double.Parse(sArray3[1]), 2);

                        if (result >= option1 && result < option2)
                        {
                            staa += dc_name + "分析:" + dc_note + "<br/><br/>";
                        }
                    }
                }
            }
        }

        return staa;
    }
    #endregion
}
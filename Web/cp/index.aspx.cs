using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class cp_index : System.Web.UI.Page
{
    protected string cp_name = "", cp_note = "", questions = "", cp_id = "", cp_questioncun="";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["id"] != null)
        {
            string cp_id = Request.QueryString["id"].ToString();

            string cp_title = "select * from t_exam_paper where Fpaperid=" + cp_id;//测评标题
            string cp_questions = "select * from t_exam_questions where Fexampaperid=" + cp_id;//测评问题

            cp_questioncun = HXD.DBUtility.SQLHelper.ExecuteScalar("select COUNT(Fexampaperid) from t_exam_questions where Fexampaperid='" + cp_id + "'").ToString();
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
                string ques_title = ques.Tables[0].Rows[i]["Fquestion"].ToString();//问题
                string ques_options = ques.Tables[0].Rows[i]["Foptionid"].ToString();//问题答案选项
                string cp_questions_options = "select * from t_exam_options where Foptionid=" + ques_options + "";//测评答案选项

                string sql22 = "select Fscoreref from t_exam_score_ref where Fexampaperid='" + cp_id + "' and Fquestionid=" + b;//问题的答案分数
                string core = HXD.DBUtility.SQLHelper.ExecuteScalar(sql22).ToString();
                string[] sArray = core.Split('|');
                //string option1 = sArray[0];
                //string option2 = sArray[1];
                //string option3 = sArray[2];
                //string option4 = sArray[3];
                //string option5 = sArray[4];

                questions += "<div id=\"panel2\" class=\"panel-body js_answer\" style=\"display: none;\">";
                questions += "<form action=\"#\" method=\"POST\"><a name=\"result\" href=\"javascript:void(0)\"></a>";
                questions += "<div class=\"form-group avatar text-center\"><label for=\"\" class=\"sr-only\">前言</label>";
                questions += "<a href=\"javascript:void(0)\" class=\"img-circle\" name=\"1\"><span style=\"float: left;text-align: center; width: 100%; padding-top: 18px;\"><img src=\"ks.jpg\"></span> </a></div>";
                questions += "<dl><dd>" + b + "." + ques_title + "</dd></dl>";
                questions += "<ul class=\"list-group  js_group\">";
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

        
    }


}
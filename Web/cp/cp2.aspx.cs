using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using HXD.Common;

public partial class cp_cp2 : System.Web.UI.Page
{
    protected string cp_name = "", cp_note = "", questions = "", cp_id = "", cp_questioncun = "",wid="";
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdManage();
        string userid = Session["userid"].ToString();
        string username = Session["AdminManage"].ToString();
        cp_id = Request.QueryString["id"].ToString();
        wid = Request.QueryString["wid"].ToString();
        //string sql = "select COUNT(Fresultid) from t_exam_results where Fresultid='" + userid + "' and Fpaperid=" + cp_id+" and datediff(day,[postTime],getdate())=0";
        //int usercun = int.Parse(HXD.DBUtility.SQLHelper.ExecuteScalar(sql).ToString());
        //if (usercun == 0)
        //{
           

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
                    string cp_type = ques.Tables[0].Rows[i]["Fquestiontype"].ToString();//问题分类
                    questions += "<div id=\"panel2\" class=\"panel-body js_answer\" style=\"display: none;\">";
                    questions += "<form action=\"#\" method=\"POST\"><a name=\"result\" href=\"javascript:void(0)\"></a>";
                    questions += "<div class=\"form-group avatar text-center\"><label for=\"\" class=\"sr-only\">前言</label>";
                    questions += "<a href=\"javascript:void(0)\" class=\"img-circle\" name=\"1\"><span style=\"float: left;text-align: center; width: 100%; padding-top: 18px;\"><img src=\"ks.jpg\"></span> </a></div>";
                    questions += "<dl><dd>" + b + "." + ques_title + "</dd></dl>";
                    questions += "<ul class=\"list-group  js_group\">";
                    string crm = "crm" + b;
                    if (cp_type == "INPUT")
                    {
                        //string sql22 = "select * from t_exam_questions where Foptionid=0";
                        //questions += "<li class=\"list-group-item\" onclick=\"return toggle(this);\">较爱：<input name=\"g\" type=\"radio\" class=\"\" value=\"" + ii + "\" /></li>";
                        //questions += "<li class=\"list-group-item\" onclick=\"return toggle(this);\">次爱：<input name=\"g\" type=\"radio\" class=\"\" value=\"" + ii + "\" /></li>";


                        questions += "<li class=\"list-group-item\"><input name=\"g\" type=\"text\" class=\"\"  value=\"11\" id=\"" + crm + "\"/><a onclick=\"return toggle(this,"+crm+");\">下一步</a></li>";

                    }
                    else
                    {
                        string cp_questions_options = "select * from t_exam_options where Foptionid=" + ques_options + "";//测评答案选项
                        DataSet option = HXD.DBUtility.SQLHelper.ExecuteDataset(cp_questions_options);
                        for (int ii = 0; ii < option.Tables[0].Rows.Count; ii++)
                        {
                            string options = option.Tables[0].Rows[ii]["Foptionitemvalue"].ToString();
                            questions += "<li class=\"list-group-item\" onclick=\"return toggle(this,'0');\">";
                            questions += "<input name=\"g\" type=\"radio\" class=\"\" value=\"" + ii + "\" />" + options + "</li>";
                        }

                    }
                    questions += "</ul></form></div>";
                }


        //}
        //else
        //{
        //    StringDeal.Alter("您今天已经做过此量表的测试，请勿重复做。", "../User/twolist.aspx");
        //}
    }
    

}
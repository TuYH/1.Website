using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class APi_Get_answer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdManage();
        if (Request.QueryString["score"] != null)//Request.QueryString["MenuId"]
        {
            string str = Request.QueryString["score"].ToString();
            string iid = Request.QueryString["iid"].ToString();
            stre(str, iid);
            Response.Write(stra(str,iid));
            
        }
    }
    protected string stra(string sta,string iid)
    {
        
        //string staa = "";
        //string sta = "5|4|4|4|4|4|2|2|3|2|3|2|2|2|3|2|2|2|3|3|3|3|2|3|3|2|4|3|3|3|4|2|2|2|2|2|2|2|2|2|2|2|2|2|2|3|3|3|4|4|3|3|4|4|3|3|3|3|3|3|3|3|3|3|3|3|3|3|3|3|3|3|3|3|3|3|3|3|3|3|3|3|3|3|3|4|2|2|1|1";
        string resultText = "";
        sta = sta.Remove(0, 2);
        int totalScore = 0;
        string[] scoreArray = sta.Split('|');
        int count = 0;
        for (int i = 0; i < scoreArray.Length; i++)
        {
            if (int.Parse(scoreArray[i]) >= 2)
            {
                count++;
            }
            totalScore += int.Parse(scoreArray[i]);
        }
        string sqlc = "select COUNT(Fexampaperid) from t_exam_result_ref where Fexampaperid='" + iid + "'";
        int idc = int.Parse(HXD.DBUtility.SQLHelper.ExecuteScalar(sqlc).ToString());
        if (idc > 0)
        {
            resultText = "你的综合得分：" + totalScore;
          
        }
        else
        {

            bool exceed = false;

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
                        score += int.Parse(scoreArray[s].ToString());
                    }
                    //decimal str = score / sArray2.Count()*1.0;
                    double result = Math.Round(((double)score / sArray2.Count() * 1.0), 2);
                    //staa += title + "得分：" + result.ToString() + "<br/>";
                    if (result >= 2.5)
                    {
                        exceed = true;
                        break;
                    }
                }
            }

            
            if (totalScore > 168)
            {
                resultText += "总分超过160分，";
            }
            if (count > 43)
            {
                resultText += "阳性项目超过43项，";
            }
            if (exceed)
            {
                resultText += "有因子超过2.5分，详见报告，";
            }
            if (resultText != "")
            {
                resultText += "需进一步检查";
            }
            else
            {
                resultText = "正常";
            }
        }
        string userid = Session["userid"].ToString();
        string username = Session["AdminManage"].ToString();
        string sql_result = "insert into t_exam_results(Fresultid,FstudentNo,Fpaperid,Fscore4each,Fscore,Fresult,Ftestnum)values('" + userid + "','" + username + "','" + iid + "','" + sta + "','" + totalScore + "','" + resultText + "','1')";
        HXD.DBUtility.SQLHelper.ExecuteScalar(sql_result);

        return resultText;
    }
    protected void stre(string sta, string iid)
    {
        string staa = "";
        //string sta = "0|1|1|1|0|0|0|1|0|1|0|0|1|0|1|1|0|1|1|0|0|0|0|0|0|0|1|0|1|0|1|0|0|0|0|0|0|0|1|0|0|0|1|0|0|0|0|1|1|0|0|1|1|1|0|1|0|0|0|0|0";
        string sqla = "select COUNT(Fsortfield) from t_exam_subitems where Fpaperid='" + iid + "'";
        int ic = int.Parse(HXD.DBUtility.SQLHelper.ExecuteScalar(sqla).ToString());
        if (ic < 1)
        {
            //sta = sta.Replace("0|", "");
            int totalScore = 0;
            string[] scoreArray = sta.Split('|');
            int count = 0;
            for (int i = 0; i < scoreArray.Length; i++)
            {
                if (int.Parse(scoreArray[i]) >= 2)
                {
                    count++;
                }
                totalScore += int.Parse(scoreArray[i]);

            }

            string sqld = "select * from t_exam_result_ref where Fexampaperid='" + iid + "'";
            DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sqld);
            if (ds.Tables[0].Rows.Count > 0)
            {

                for (int ii = 0; ii < ds.Tables[0].Rows.Count; ii++)
                {
                    //string dc_name = ds.Tables[0].Rows[ii]["Fsubitemname"].ToString();
                    string dc_score = ds.Tables[0].Rows[ii]["FscoreSpan"].ToString();
                    string dc_note = ds.Tables[0].Rows[ii]["FresultText"].ToString();

                    string[] sArray3 = dc_score.Split('|');
                    //double option1 = Math.Round(double.Parse(sArray3[0]), 2);
                    //double option2 = Math.Round(double.Parse(sArray3[1]), 2);
                    int option1 = int.Parse(sArray3[0]);
                    int option2 = int.Parse(sArray3[1]);

                    if (totalScore >= option1 && totalScore < option2)
                    {
                        staa += "分析:" + dc_note + "<br/><br/>";
                    }
                }
            }
        }
        else
        {

            //sta = sta.Replace("0|", "");
            sta = sta.Remove(0, 2);
            string[] sArray = sta.Split('|');


            //string sql = "select * from t_exam_subitems where Fsubitemid=1025";
            string sql = "select * from t_exam_subitems where Fpaperid='" + iid + "' order by Fsortfield";
            DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {

                for (int ii = 0; ii < ds.Tables[0].Rows.Count; ii++)
                {
                    int score = 0;

                    string titleid = ds.Tables[0].Rows[ii]["Fsubitemid"].ToString();
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
                   

                    string userid = Session["userid"].ToString();
                    string username = Session["AdminManage"].ToString();

                    string sql33 = "insert into t_exam_subitems_score (FstudentNo,Fresultid,Fsubitemid,Fscore)values('" + username + "','" + userid + "','" + titleid + "','" + result + "')";
                    HXD.DBUtility.SQLHelper.ExecuteScalar(sql33);

                 
                }
            }
        }

       
    }
}
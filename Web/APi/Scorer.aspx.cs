using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HXD.Measure;


public partial class APi_Scorer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdManage();
        if (Request.QueryString["answers"] != null)//Request.QueryString["MenuId"]
        {
            string sc_id=LoginCheck.getadminid();//学校ID

            string answers = Request.QueryString["answers"].ToString();//答案
            string wid = Request.QueryString["wid"].ToString();//答案
            answers = answers.Remove(0, 2);
            int paperID2 = int.Parse(Request.QueryString["paperid"].ToString());//量表名称
            string UserName = Session["AdminManage"].ToString();//"maidi007";用户名
            string Userid = Session["userid"].ToString();
            //string answers = "0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|1|2|2|2|2|2|2|2|2|2|2|2|2|2|2|2";//scl-90
            //string answers = "0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|1|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0";
            //int paperID2 = 2;
            Scorer scorer = Scorer.CreateScorer(paperID2);
            string resultText;
            float totalScore;
            int[] scoreArray;
            scorer.Score(paperID2, answers, out resultText, out totalScore, out scoreArray);
            int[] subitemIds = null;
            float[] subitemScoreArray = null;
            bool seniorScoreResult = scorer.SeniorScore(paperID2, answers, scoreArray, UserName, ref resultText, out subitemIds, out subitemScoreArray);
            scorer.Diagnose(paperID2, answers, UserName, scoreArray, totalScore, subitemScoreArray, ref resultText);

            int resultid = int.Parse(Session["userid"].ToString());
            //string wid = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            SaveResult(resultid, UserName, paperID2, answers, scoreArray, totalScore, resultText, GetTestNum(paperID2), wid, sc_id);
            if (seniorScoreResult)
            {
                SaveSubItemResult(UserName, resultid, subitemIds, subitemScoreArray, wid, sc_id);
            }
            if (IsPCPaper(paperID2))
            {
                string sql = "update tb_U_Message set state=2 where rid='" + wid + "' and uid='" + Userid + "'";
                HXD.DBUtility.SQLHelper.ExecuteNonQuery(sql);
                Response.Write("结果已提交到服务器，谢谢你完成此调查所有问题。");
                //base.get_Response().Write("结果已提交到服务器，谢谢你完成此调查所有问题。");
            }
            else
            {
                string sql = "update tb_U_Message set state=2 where rid='" + wid + "' and uid='" + Userid + "'";
                HXD.DBUtility.SQLHelper.ExecuteNonQuery(sql);


                //Response.Write(resultText);
            }
          

        }
    }
    public bool IsPCPaper(int paperId)
    {
        string sql = "select Fpapertype from t_exam_paper where Fpaperid = " + paperId.ToString();
        //DataBase db = new DataBase();
        //object res = db.ExecuteSqlScalar(sql, null);
        object res = HXD.DBUtility.SQLHelper.ExecuteScalar(sql);
        return res != null && (int)res == 1;
    }
    public int GetTestNum(int id)
    {
        int name = 0;
        string sql = "select count(Fpapername) from t_exam_paper where Fpaperid = '"+id+"'";
        name = int.Parse(HXD.DBUtility.SQLHelper.ExecuteScalar(sql).ToString());
        return name;
    }
    public static int SaveResult(int resultid, string studentNo, int paperId, string answer, int[] score4each, float totalScore, string result, int testNum,string wid,string m)
    {
        string score4Each = "";
        for (int i = 0; i < score4each.Length; i++)
        {
            score4Each += score4each[i].ToString();
            if (i != score4each.Length - 1)
            {
                score4Each += "|";
            }
        }
        string sql = "insert into t_exam_results (Fresultid,FstudentNo, Fpaperid, Fanswer, Fscore4each, Fscore, Fresult, Ftesttime, Ftestnum,wid,sc_id)\r\n\t\t\t\t\t\tvalues ('{0}', '{1}', '{2}', '{3}', {4}, '{5}','{6}', getdate(), {7}, {8},{9}); \r\n\t\t\t\t\t\tselect max(@@IDENTITY) from t_exam_results";
        sql = string.Format(sql, new object[]
			{
                resultid,
				studentNo,
				paperId,
				answer,
				score4Each,
				totalScore,
				result,
				testNum,
                wid,
                m
			});
        int aa=HXD.DBUtility.SQLHelper.ExecuteNonQuery(sql);
        return aa;
        //DataBase db = new DataBase();
        //return int.Parse(db.ExecuteSqlScalar(sql, null).ToString());
    }
    public static void SaveSubItemResult(string studentNo, int resultid, int[] subitemids, float[] scores,string wid,string m)
    {
        if (subitemids != null && scores != null)
        {
            if (subitemids.Length == scores.Length)
            {
                string[] sqls = new string[subitemids.Length];
                for (int i = 0; i < subitemids.Length; i++)
                {
                    int subitemid = subitemids[i];
                    float score = scores[i];
                    string sql = "insert into t_exam_subitems_score (FstudentNo, Fresultid, Fsubitemid, Fscore,wid,sc_id) values ('{0}', {1}, {2}, {3}, {4},{5})";
                    sql = string.Format(sql, new object[]
						{
							studentNo,
							resultid,
							subitemid,
							score,
                            wid,
                            m
						});
                    sqls[i] = sql;
                }
                //HXD.DBUtility.SQLHelper.ExecuteNonQuery(sqls);
                DataBase db = new DataBase();
                db.ExecuteSql(sqls);
            }
        }
    }
   
}
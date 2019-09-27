using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class APi_Get_result : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdManage();
        if (Request.QueryString["para"] != null)//Request.QueryString["MenuId"]
        {
            string str = Request.QueryString["para"].ToString();
            string iid = Request.QueryString["iid"].ToString();

            Response.Write(stra(str,iid));
        }

    }
    protected string stra(string sta,string iid)
    {
        string staa = "";
        //string sta = "0|1|1|1|0|0|0|1|0|1|0|0|1|0|1|1|0|1|1|0|0|0|0|0|0|0|1|0|1|0|1|0|0|0|0|0|0|0|1|0|0|0|1|0|0|0|0|1|1|0|0|1|1|1|0|1|0|0|0|0|0";
        string sqla = "select COUNT(Fsortfield) from t_exam_subitems where Fpaperid='"+iid+"'";
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
                    staa += title + "得分：" + result.ToString() + "<br/>";

                    //string userid = Session["userid"].ToString();
                    //string username = Session["AdminManage"].ToString();

                    //string sql33 = "insert into t_exam_subitems_score (FstudentNo,Fresultid,Fsubitemid,Fscore)values('" + username + "','" + userid + "','" + titleid + "','" + result + "')";
                    //HXD.DBUtility.SQLHelper.ExecuteScalar(sql33);

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
        }

        return staa;
    }
}
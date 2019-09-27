using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class APi_Get_answers : System.Web.UI.Page
{
    protected int paperId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["paperId"] != null)
        {
            //paperId = int.Parse(Request.QueryString["paperId"].ToString());
            paperId = 6;
            //string str = Request.QueryString["paperId"].ToString();
            string str = "0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|1|1|1|1|1|1|1|0|0|1|1|1";
            Response.Write(getscorer(paperId, str));
        }
    }
    protected string getscorer(int paperId, string str)
    {
        //int paperId = int.Parse(Request.QueryString["paperId"].ToString());
        string scorer = "";
        switch (paperId)
        {
            case 1:
                scorer = ScorerSCL(str);
                break;
            case 2:
                scorer =  ScorerK16(str);
                break;
            case 3:
                scorer = ScorerUPI(str);
                break;
            default:
                if (paperId != 39)
                {
                    switch (paperId)
                    {
                        case 71:
                            scorer = ScorerTypeA(str);
                            return scorer;
                        case 73:
                            scorer = ScorerBAI(str);
                            return scorer;
                        case 76:
                            scorer = ScorerSuicide(str);
                            return scorer;
                        case 77:
                            scorer = ScorerCMIMale(str);
                            return scorer;
                        case 78:
                            scorer = ScorerCMIFemale(str);
                            return scorer;
                        case 79:
                            scorer = ScorerHLD(str);
                            return scorer;
                        case 80:
                            scorer = ScorerEPQ(str);
                            return scorer;
                        case 81:
                            scorer = ScorerMMPIMale(str);
                            return scorer;
                        case 82:
                            scorer = ScorerMMPIFemale(str);
                            return scorer;
                        case 83:
                            scorer = ScorerSAS(str);
                            return scorer;
                        case 86:
                            scorer = ScorerCPI(str);
                            return scorer;
                        case 89:
                            scorer = ScorerCareerVector2(str);
                            return scorer;
                        case 90:
                            scorer = ScorerTemperament(str);
                            return scorer;
                    }
                    scorer = Scorer(str);
                }
                else
                {
                    scorer = ScorerSDS(str);
                }
                break;
        }
        return scorer;
    }
    #region Scorer 算法
    /// <summary>
    /// SCL-90项自觉症状评定量表 算法
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    protected string Scorer(string sta)
    {
        string resultText = "";
     
        sta = sta.Replace("0|", "");
        int totalScore = 0;
        string[] scoreArray = sta.Split('|');
        for (int i = 0; i < scoreArray.Length; i++)
        {
            totalScore += int.Parse(scoreArray[i]);
        }

        string sql = "select * from t_exam_result_ref where Fexampaperid=6";//'" + paperId + "'";
         DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
         if (ds.Tables[0].Rows.Count > 0)
         {
             for (int ii = 0; ii < ds.Tables[0].Rows.Count; ii++)
             {
                 string FscoreSpan = ds.Tables[0].Rows[ii]["FscoreSpan"].ToString();
                 
                 string[] scoreArray2 = FscoreSpan.Split('|');
                 int score1 = int.Parse(scoreArray2[0]);   // sArray[0]
                 int score2 = int.Parse(scoreArray2[1]);
                 if (totalScore >= score1 && totalScore < score2)
                 {
                     resultText = ds.Tables[0].Rows[ii]["FresultText"].ToString();
                 }

             }
         }
       

        return resultText;
        
    }
    #endregion

    #region SCL-90项自觉症状评定量表 算法
    /// <summary>
    /// SCL-90项自觉症状评定量表 算法
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    protected string ScorerSCL(string sta)
    {
        sta = sta.Replace("0|", "");
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

        string resultText = "";
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

        return resultText;
    }
    #endregion

    #region K16 算法
    /// <summary>
    /// SCL-90项自觉症状评定量表 算法
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    protected string ScorerK16(string str)
    {
        return "";
    }
    #endregion

    #region UPI 算法
    /// <summary>
    /// SCL-90项自觉症状评定量表 算法
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    protected string ScorerUPI(string str)
    {
        return "";
    }
    #endregion

    #region TypeA 算法
    /// <summary>
    /// SCL-90项自觉症状评定量表 算法
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    protected string ScorerTypeA(string str)
    {
        return "";
    }
    #endregion

    #region BAI 算法
    /// <summary>
    /// SCL-90项自觉症状评定量表 算法
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    protected string ScorerBAI(string str)
    {
        return "";
    }
    #endregion

    #region Suicide 算法
    /// <summary>
    /// SCL-90项自觉症状评定量表 算法
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    protected string ScorerSuicide(string str)
    {
        return "";
    }
    #endregion

    #region CMIMale 算法
    /// <summary>
    /// SCL-90项自觉症状评定量表 算法
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    protected string ScorerCMIMale(string str)
    {
        return "";
    }
    #endregion

    #region CMIFemale 算法
    /// <summary>
    /// SCL-90项自觉症状评定量表 算法
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    protected string ScorerCMIFemale(string str)
    {
        return "";
    }
    #endregion

    #region HLD 算法
    /// <summary>
    /// SCL-90项自觉症状评定量表 算法
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    protected string ScorerHLD(string str)
    {
        return "";
    }
    #endregion

    #region EPQ 算法
    /// <summary>
    /// SCL-90项自觉症状评定量表 算法
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    protected string ScorerEPQ(string str)
    {
        return "";
    }
    #endregion

    #region MMPIMale 算法
    /// <summary>
    /// SCL-90项自觉症状评定量表 算法
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    protected string ScorerMMPIMale(string str)
    {
        return "";
    }
    #endregion

    #region MMPIFemale 算法
    /// <summary>
    /// SCL-90项自觉症状评定量表 算法
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    protected string ScorerMMPIFemale(string str)
    {
        return "";
    }
    #endregion

    #region SAS 算法
    /// <summary>
    /// SCL-90项自觉症状评定量表 算法
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    protected string ScorerSAS(string str)
    {
        return "";
    }
    #endregion

    #region CPI 算法
    /// <summary>
    /// SCL-90项自觉症状评定量表 算法
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    protected string ScorerCPI(string str)
    {
        return "";
    }
    #endregion


    #region CareerVector2 算法
    /// <summary>
    /// SCL-90项自觉症状评定量表 算法
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    protected string ScorerCareerVector2(string str)
    {
        return "";
    }
    #endregion

    #region Temperamen 算法
    /// <summary>
    /// SCL-90项自觉症状评定量表 算法
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    protected string ScorerTemperament(string str)
    {
        return "";
    }
    #endregion

    #region SDS 算法
    /// <summary>
    /// SCL-90项自觉症状评定量表 算法
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    protected string ScorerSDS(string str)
    {
        return "";
    }
    #endregion
}
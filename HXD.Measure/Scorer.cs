using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


using System.Collections;


namespace HXD.Measure
{
    public class Scorer
    {
        public static Scorer CreateScorer(int paperId)
        {
            Scorer scorer;
            switch (paperId)
            {
                case 1:
                    scorer = new ScorerSCL();
                    break;
                case 2:

                    scorer = new ScorerK16();
                    break;
                case 3:
                    //scorer = new ScorerSCL();
                    scorer = new ScorerUPI();
                    break;
                default:
                    if (paperId != 39)
                    {
                        switch (paperId)
                        {
                            case 71:
                                
                                scorer = new ScorerTypeA();
                                return scorer;
                            case 73:
                                scorer = new ScorerBAI();
                                return scorer;
                            case 76:
                                scorer = new ScorerSuicide();
                                return scorer;
                            case 77:
                                scorer = new ScorerCMIMale();
                                return scorer;
                            case 78:
                                scorer = new ScorerCMIFemale();
                                return scorer;
                            case 79:
                                scorer = new ScorerHLD();
                                return scorer;
                            case 80:
                                scorer = new ScorerEPQ();
                                return scorer;
                            case 81:
                                scorer = new ScorerMMPIMale();
                                return scorer;
                            case 82:
                                scorer = new ScorerMMPIFemale();
                                return scorer;
                            case 83:
                                scorer = new ScorerSAS();
                                return scorer;
                            case 86:
                                scorer = new ScorerCPI();
                                return scorer;
                            case 89:
                                scorer = new ScorerCareerVector2();
                                return scorer;
                            case 90:
                                scorer = new ScorerTemperament();
                                return scorer;
                        }
                        scorer = new Scorer();
                    }
                    else
                    {
                        scorer = new ScorerSDS();
                    }
                  
                    break;
            }
            return scorer;
        }
        public virtual void Score(int paperId, string answers, out string resultText, out float totalScore, out int[] scoreArray)
        {
            string[] answerArray = answers.Split(new char[]
			{
				'|'
			});
            scoreArray = new int[answerArray.Length];
            string sql = "select Fquestionid, Fscoreref from t_exam_score_ref where Fexampaperid = {0} order by Fquestionid";
            sql = string.Format(sql, paperId);
            //int sc=HXD.DBUtility.SQLHelper.ExecuteScalar
            //DataBase db = new DataBase();
            DataSet ds=HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
            //db.ExecuteSql(sql, null, out ds);
            if (ds.Tables[0].Rows.Count <= 0)
            {
                throw new ApplicationException("没有该试卷的评分标准");
            }
            totalScore = 0f;
            IEnumerator enumerator = ds.Tables[0].Rows.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    DataRow dr = (DataRow)enumerator.Current;
                    int questionid = (int)dr["Fquestionid"] - 1;
                    if (questionid >= answerArray.Length)
                    {
                        throw new ApplicationException("答案不完整");
                    }
                    string[] scorerefArray = dr["Fscoreref"].ToString().Split(new char[]
					{
						'|'
					});
                    string[] selectArray = answerArray[questionid].Split(new char[]
					{
						','
					});

                    scoreArray[questionid] = 0;
                    for (int i = 0; i < selectArray.Length; i++)
                    {
                        int select = int.Parse(selectArray[i]);
                        int[] array;
                        IntPtr intPtr;
                        (array = scoreArray)[(int)(intPtr = (IntPtr)questionid)] = array[(int)intPtr] + int.Parse(scorerefArray[select]);
                        totalScore += (float)scoreArray[questionid];
                    }
                }
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (disposable != null)
                {
                    disposable.Dispose();
                }
            }
            resultText = "您的得分是：" + totalScore + "<br/>";
        }
        public virtual bool SeniorScore(int paperId, string answers, int[] scoreArray, string userName, ref string resultText, out int[] subitemIds, out float[] subitemScoreArray)
        {
            return this.SubItemScore(paperId, scoreArray, false, ref resultText, out subitemIds, out subitemScoreArray);
        }
        public virtual bool Diagnose(int paperId, string answers, string userName, int[] scoreArray, float totalScore, float[] subitemScoreArray, ref string resultText)
        {
            bool result;
            try
            {
                string sql = "select FscoreSpan, FresultText from t_exam_result_ref where Fexampaperid = '" + paperId + "'";
                //sql = string.Format(sql, paperId);
                //DataBase db = new DataBase();
                //DataSet dsResultRef;
                //db.ExecuteSql(sql, null, out dsResultRef);
                //IEnumerator enumerator = dsResultRef.Tables[0].Rows.GetEnumerator();
                
                //try
                //{
                    //while (enumerator.MoveNext())
                    //{
                    DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        for (int ii = 0; ii < ds.Tables[0].Rows.Count; ii++)
                        {

                            string dc_score = ds.Tables[0].Rows[ii]["FscoreSpan"].ToString();
                            string dc_note = ds.Tables[0].Rows[ii]["FresultText"].ToString();
                                string[] scoreSpan = dc_score.Split(new char[]
					            {
						            '|'
					            });
                                float min = float.Parse(scoreSpan[0]);
                                float max = float.Parse(scoreSpan[1]);
                                if (totalScore >= min && totalScore < max)
                                {
                                    resultText = dc_note;
                                    result = true;
                                    return result;
                                }
                          }
                    }
            
                        
                //}
                //finally
                //{
                //    IDisposable disposable = enumerator as IDisposable;
                //    if (disposable != null)
                //    {
                //        disposable.Dispose();
                //    }
                //}
            }
            catch
            {
            }
            result = false;
            return result;
        }
        protected virtual bool SubItemScore(int paperId, int[] scoreArray, bool average, ref string resultText, out int[] subitemIds, out float[] subitemScoreArray)
        {
            DataSet ds = SubItem.GetPaperSubItems(paperId, 1);
            int subitemCount = ds.Tables[0].Rows.Count;
            bool result;
            if (subitemCount <= 0)
            {
                subitemIds = null;
                subitemScoreArray = null;
                result = false;
            }
            else
            {
                resultText = "";
                subitemIds = new int[subitemCount];
                subitemScoreArray = new float[subitemCount];
                for (int i = 0; i < subitemCount; i++)
                {
                    DataRow dr = ds.Tables[0].Rows[i];
                    //DataRow dr = ds.get_Tables().get_Item(0).get_Rows().get_Item(i);
                    subitemIds[i] = (int)dr["Fsubitemid"];
                    subitemScoreArray[i] = 0f;
                    string[] questionIds = dr["Fquestions"].ToString().Split(new char[]
					{
						'|'
					});
                    for (int j = 0; j < questionIds.Length; j++)
                    {
                        int questionId = int.Parse(questionIds[j]);
                        float[] array;
                        IntPtr intPtr;
                        (array = subitemScoreArray)[(int)(intPtr = (IntPtr)i)] = array[(int)intPtr] + (float)scoreArray[questionId - 1];
                    }
                    if (average)
                    {
                        subitemScoreArray[i] = (float)Math.Round((double)(subitemScoreArray[i] / (float)questionIds.Length), 2);
                    }
                    string subitemName = dr["Fsubitemname"].ToString();
                    resultText = resultText + subitemName + "的得分是：" + subitemScoreArray[i].ToString();
                    if (i != subitemCount - 1)
                    {
                        resultText += "<br/>";
                    }
                }
                result = true;
            }
            return result;
        }
        protected virtual bool SubItemTScore(int paperId, int[] scoreArray, string userName, ref string resultText, out int[] subitemIds, out float[] subitemScoreArray)
        {
            DataSet ds = SubItem.GetPaperSubItems(paperId, 1);
            int subitemCount = ds.Tables[0].Rows.Count;
            //int subitemCount = ds.Tables[0].Rows.Count;
            bool result;
            if (subitemCount <= 0)
            {
                subitemIds = null;
                subitemScoreArray = null;
                result = false;
            }
            else
            {
                resultText = "";
                subitemIds = new int[subitemCount];
                float[] T = new float[subitemCount];
                float[] X = new float[subitemCount];
                float[] M = new float[subitemCount];
                float[] S = new float[subitemCount];
                for (int i = 0; i < subitemCount; i++)
                {
                    DataRow dr = ds.Tables[0].Rows[i];
                    subitemIds[i] = (int)dr["Fsubitemid"];
                    X[i] = 0f;
                    string[] questionIds = dr["Fquestions"].ToString().Split(new char[]
					{
						'|'
					});
                    float[] tmpArray = new float[questionIds.Length];
                    for (int j = 0; j < questionIds.Length; j++)
                    {
                        int questionId = int.Parse(questionIds[j]);
                        float[] array;
                        IntPtr intPtr;
                        (array = X)[(int)(intPtr = (IntPtr)i)] = array[(int)intPtr] + (float)scoreArray[questionId - 1];
                        tmpArray[j] = (float)scoreArray[questionId - 1];
                    }
                    M[i] = X[i] / (float)questionIds.Length;
                    S[i] = this.computeStandardDeviation(tmpArray, M[i]);
                    if (S[i] != 0f)
                    {
                        T[i] = (float)Math.Round((double)(50f + 10f * (X[i] - M[i]) / S[i]), 2);
                    }
                    string subitemName = dr["Fsubitemname"].ToString();
                    resultText = resultText + subitemName + "的得分是：" + T[i].ToString();
                    if (i != subitemCount - 1)
                    {
                        resultText += "<br/>";
                    }
                }
                subitemScoreArray = T;
                result = true;
            }
            return result;
        }
        public float computeStandardDeviation(float[] array)
        {
            float avg = 0f;
            for (int i = 0; i < array.Length; i++)
            {
                avg += array[i];
            }
            avg /= (float)array.Length;
            return this.computeStandardDeviation(array, avg);
        }
        protected float computeStandardDeviation(float[] array, float avg)
        {
            float result = 0f;
            for (int i = 0; i < array.Length; i++)
            {
                result += (float)Math.Pow((double)(array[i] - avg), 2.0);
            }
            return (float)Math.Sqrt((double)(result / (float)array.Length));
        }


    }
}

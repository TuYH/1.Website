using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace HXD.Measure
{
    public class ScorerEPQ : Scorer
    {
        public override bool SeniorScore(int paperId, string answers, int[] scoreArray, string userName, ref string resultText, out int[] subitemIds, out float[] subitemScoreArray)
        {
            return this.SubItemTScore(paperId, scoreArray, userName, ref resultText, out subitemIds, out subitemScoreArray);
        }
        protected override bool SubItemTScore(int paperId, int[] scoreArray, string userName, ref string resultText, out int[] subitemIds, out float[] subitemScoreArray)
        {
            Hashtable M = new Hashtable();
            Hashtable S = new Hashtable();
            S.Add("男P", 2.86);
            M.Add("男P", 5.29);
            S.Add("男E", 4.33);
            M.Add("男E", 10.17);
            S.Add("男N", 4.18);
            M.Add("男N", 11.45);
            S.Add("男L", 3.64);
            M.Add("男L", 11.91);
            S.Add("女P", 2.88);
            M.Add("女P", 4.43);
            S.Add("女E", 4.44);
            M.Add("女E", 7.67);
            S.Add("女N", 4.6);
            M.Add("女N", 12.5);
            S.Add("女L", 3.67);
            M.Add("女L", 12.83);
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
                float[] T = new float[subitemCount];
                float[] X = new float[subitemCount];
                for (int i = 0; i < subitemCount; i++)
                {
                    DataRow dr = ds.Tables[0].Rows[i];
                    subitemIds[i] = (int)dr["Fsubitemid"];
                    X[i] = 0f;
                    string[] questionIds = dr["Fquestions"].ToString().Split(new char[]
					{
						'|'
					});
                    for (int j = 0; j < questionIds.Length; j++)
                    {
                        int questionId = int.Parse(questionIds[j]);
                        float[] array;
                        IntPtr intPtr;
                        (array = X)[(int)(intPtr = (IntPtr)i)] = array[(int)intPtr] + (float)scoreArray[questionId - 1];
                    }
                    string subitemName = dr["Fsubitemname"].ToString();
                   // DataRow drStu = SchoolDB.GetStudent(userName);
                    string key = SchoolDB.GetStudent(userName);
                    key += subitemName;
                    T[i] = (float)Math.Round((double)(50f + 10f * (X[i] - float.Parse(M[key].ToString())) / float.Parse(S[key].ToString())), 2);
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
    }
}

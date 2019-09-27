using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HXD.Measure
{
    public class ScorerTemperament : Scorer
    {
        public override bool SeniorScore(int paperId, string answers, int[] scoreArray, string userName, ref string resultText, out int[] subitemIds, out float[] subitemScoreArray)
        {
            bool res = base.SeniorScore(paperId, answers, scoreArray, userName, ref resultText, out subitemIds, out subitemScoreArray);
            if (res)
            {
                SubitemScoreEntry[] sses = new SubitemScoreEntry[subitemScoreArray.Length];
                for (int i = 0; i < subitemScoreArray.Length; i++)
                {
                    sses[i] = new SubitemScoreEntry(subitemIds[i], subitemScoreArray[i]);
                }
                Array.Sort(sses);
                string result = "";
                for (int j = sses.Length - 1; j >= 0; j--)
                {
                    string subitemName = SubItem.GetPaperSubItemName(paperId, sses[j].index);
                    result = result + subitemName.Substring(0, subitemName.Length - 1) + "-";
                    if (j > 0 && sses[j].score - sses[j - 1].score >= 4f)
                    {
                        break;
                    }
                }
                if (result.Length > 0)
                {
                    result = "您的气质类型为：" + result.Substring(0, result.Length - 1);
                }
                resultText = result;
            }
            return res;
        }
        public override bool Diagnose(int paperId, string answers, string userName, int[] scoreArray, float totalScore, float[] subitemScoreArray, ref string resultText)
        {
            //userName=20180101
            //DataRow drStu = SchoolDB.GetStudent(userName);

            string sex = SchoolDB.GetStudent(userName);
            resultText += "<br/>从总分来看：";
            if (sex == "男")
            {
                if (totalScore >= 0f && totalScore <= 10f)
                {
                    resultText += "您非常内向";
                }
                else
                {
                    if (totalScore >= 11f && totalScore <= 25f)
                    {
                        resultText += "您比较内向";
                    }
                    else
                    {
                        if (totalScore >= 26f && totalScore <= 35f)
                        {
                            resultText += "您介于内外向之间";
                        }
                        else
                        {
                            if (totalScore >= 36f && totalScore <= 50f)
                            {
                                resultText += "您比较外向";
                            }
                            else
                            {
                                if (totalScore >= 51f && totalScore <= 60f)
                                {
                                    resultText += "您非常外向";
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (sex == "女")
                {
                    if (totalScore >= 0f && totalScore <= 10f)
                    {
                        resultText += "您非常内向";
                    }
                    else
                    {
                        if (totalScore >= 11f && totalScore <= 21f)
                        {
                            resultText += "您比较内向";
                        }
                        else
                        {
                            if (totalScore >= 22f && totalScore <= 31f)
                            {
                                resultText += "您介于内外向之间";
                            }
                            else
                            {
                                if (totalScore >= 32f && totalScore <= 45f)
                                {
                                    resultText += "您比较外向";
                                }
                                else
                                {
                                    if (totalScore >= 46f && totalScore <= 60f)
                                    {
                                        resultText += "您非常外向";
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return true;
        }
    }
}

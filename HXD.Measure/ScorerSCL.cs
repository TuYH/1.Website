using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HXD.Measure
{
    public class ScorerSCL : Scorer
    {
        public override bool SeniorScore(int paperId, string answers, int[] scoreArray, string userName, ref string resultText, out int[] subitemIds, out float[] subitemScoreArray)
        {
            return base.SubItemScore(paperId, scoreArray, true, ref resultText, out subitemIds, out subitemScoreArray);
        }
        public override bool Diagnose(int paperId, string answers, string userName, int[] scoreArray, float totalScore, float[] subitemScoreArray, ref string resultText)
        {
            int count = 0;
            for (int i = 0; i < scoreArray.Length; i++)
            {
                if (scoreArray[i] >= 2)
                {
                    count++;
                }
            }
            bool exceed = false;
            for (int j = 0; j < subitemScoreArray.Length; j++)
            {
                if ((double)subitemScoreArray[j] >= 2.5)
                {
                    exceed = true;
                    break;
                }
            }
            resultText = "";
            if (totalScore > 168f)
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
            return true;
        }
    }
}

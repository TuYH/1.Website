using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HXD.Measure
{
    public class ScorerSuicide : Scorer
    {
        public override void Score(int paperId, string answers, out string resultText, out float totalScore, out int[] scoreArray)
        {
            base.Score(paperId, answers, out resultText, out totalScore, out scoreArray);
            totalScore /= (float)scoreArray.Length;
            resultText = "您的得分是：" + totalScore + "<br/>";
        }
        public override bool SeniorScore(int paperId, string answers, int[] scoreArray, string userName, ref string resultText, out int[] subitemIds, out float[] subitemScoreArray)
        {
            return base.SubItemScore(paperId, scoreArray, true, ref resultText, out subitemIds, out subitemScoreArray);
        }
    }
}

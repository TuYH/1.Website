using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HXD.Measure
{
    public class ScorerSAS : Scorer
    {
        public override void Score(int paperId, string answers, out string resultText, out float totalScore, out int[] scoreArray)
        {
            base.Score(paperId, answers, out resultText, out totalScore, out scoreArray);
            totalScore = (float)((int)Math.Floor(1.25 * (double)totalScore));
            resultText = "您的得分是：" + totalScore + "<br/>";
        }
    }
}

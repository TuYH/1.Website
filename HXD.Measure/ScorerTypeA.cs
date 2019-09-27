using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HXD.Measure
{
    public class ScorerTypeA : Scorer
    {
        public override bool Diagnose(int paperId, string answers, string userName, int[] scoreArray, float totalScore, float[] subitemScoreArray, ref string resultText)
        {
            bool result;
            if (subitemScoreArray.Length != 3)
            {
                result = false;
            }
            else
            {
                float TH = subitemScoreArray[0];
                float CH = subitemScoreArray[1];
                float TYPE = TH + CH;
                resultText = "";
                if (TYPE >= 36f)
                {
                    resultText += "A型行为者";
                }
                else
                {
                    if (TYPE >= 28f && TYPE < 35f)
                    {
                        resultText += "A-型行为者";
                    }
                    else
                    {
                        if (TYPE == 27f)
                        {
                            resultText += "M型行为者";
                        }
                        else
                        {
                            if (18f <= TYPE && TYPE < 27f)
                            {
                                resultText += "B-型行为者";
                            }
                            else
                            {
                                resultText += "B型行为者";
                            }
                        }
                    }
                }
                result = true;
            }
            return result;
        }
    }
}

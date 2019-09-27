using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace HXD.Measure
{
    public class ScorerCMIMale : Scorer
    {
        public override bool Diagnose(int paperId, string answers, string userName, int[] scoreArray, float totalScore, float[] subitemScoreArray, ref string resultText)
        {
            Hashtable subitemIndexMap = SubItem.GetPaperSubItemIndexMap(paperId, 1);
            bool result;
            if (subitemScoreArray.Length <= (int)subitemIndexMap["R"])
            {
                result = false;
            }
            else
            {
                char[] subItems = new char[]
				{
					'M',
					'N',
					'O',
					'P',
					'Q',
					'R'
				};
                float subItemSum = 0f;
                char[] array = subItems;
                for (int i = 0; i < array.Length; i++)
                {
                    char subitem = array[i];
                    subItemSum += subitemScoreArray[(int)subitemIndexMap[subitem.ToString()]];
                }
                if (totalScore >= 35f && subItemSum >= 15f)
                {
                    resultText = "您的健康有问题";
                }
                else
                {
                    resultText = "您的健康没有问题";
                }
                result = true;
            }
            return result;
        }
    }
}

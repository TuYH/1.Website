using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace HXD.Measure
{
    public class StandScorer
    {
        protected StandScoreItem[] standScoreItems;
        public static Hashtable CreateStandScorerK16()
        {
            Hashtable result = new Hashtable(16);
            StandScorer ss = new StandScorer(10);
            ss.standScoreItems[0] = new StandScoreItem(0f, 1f, 1f);
            ss.standScoreItems[1] = new StandScoreItem(2f, 3f, 2f);
            ss.standScoreItems[2] = new StandScoreItem(4f, 5f, 3f);
            ss.standScoreItems[3] = new StandScoreItem(6f, 6f, 4f);
            ss.standScoreItems[4] = new StandScoreItem(7f, 8f, 5f);
            ss.standScoreItems[5] = new StandScoreItem(9f, 11f, 6f);
            ss.standScoreItems[6] = new StandScoreItem(12f, 13f, 7f);
            ss.standScoreItems[7] = new StandScoreItem(14f, 14f, 8f);
            ss.standScoreItems[8] = new StandScoreItem(15f, 16f, 9f);
            ss.standScoreItems[9] = new StandScoreItem(17f, 20f, 10f);
            result.Add("A", ss);
            ss = new StandScorer(10);
            ss.standScoreItems[0] = new StandScoreItem(0f, 3f, 1f);
            ss.standScoreItems[1] = new StandScoreItem(4f, 4f, 2f);
            ss.standScoreItems[2] = new StandScoreItem(5f, 5f, 3f);
            ss.standScoreItems[3] = new StandScoreItem(6f, 6f, 4f);
            ss.standScoreItems[4] = new StandScoreItem(7f, 7f, 5f);
            ss.standScoreItems[5] = new StandScoreItem(8f, 8f, 6f);
            ss.standScoreItems[6] = new StandScoreItem(9f, 9f, 7f);
            ss.standScoreItems[7] = new StandScoreItem(10f, 10f, 8f);
            ss.standScoreItems[8] = new StandScoreItem(11f, 11f, 9f);
            ss.standScoreItems[9] = new StandScoreItem(12f, 13f, 10f);
            result.Add("B", ss);
            ss = new StandScorer(10);
            ss.standScoreItems[0] = new StandScoreItem(0f, 5f, 1f);
            ss.standScoreItems[1] = new StandScoreItem(6f, 7f, 2f);
            ss.standScoreItems[2] = new StandScoreItem(8f, 9f, 3f);
            ss.standScoreItems[3] = new StandScoreItem(10f, 11f, 4f);
            ss.standScoreItems[4] = new StandScoreItem(12f, 13f, 5f);
            ss.standScoreItems[5] = new StandScoreItem(14f, 16f, 6f);
            ss.standScoreItems[6] = new StandScoreItem(17f, 18f, 7f);
            ss.standScoreItems[7] = new StandScoreItem(19f, 20f, 8f);
            ss.standScoreItems[8] = new StandScoreItem(21f, 22f, 9f);
            ss.standScoreItems[9] = new StandScoreItem(23f, 26f, 10f);
            result.Add("C", ss);
            ss = new StandScorer(10);
            ss.standScoreItems[0] = new StandScoreItem(0f, 2f, 1f);
            ss.standScoreItems[1] = new StandScoreItem(3f, 4f, 2f);
            ss.standScoreItems[2] = new StandScoreItem(5f, 5f, 3f);
            ss.standScoreItems[3] = new StandScoreItem(6f, 7f, 4f);
            ss.standScoreItems[4] = new StandScoreItem(8f, 9f, 5f);
            ss.standScoreItems[5] = new StandScoreItem(10f, 12f, 6f);
            ss.standScoreItems[6] = new StandScoreItem(13f, 14f, 7f);
            ss.standScoreItems[7] = new StandScoreItem(15f, 16f, 8f);
            ss.standScoreItems[8] = new StandScoreItem(17f, 18f, 9f);
            ss.standScoreItems[9] = new StandScoreItem(19f, 26f, 10f);
            result.Add("E", ss);
            ss = new StandScorer(10);
            ss.standScoreItems[0] = new StandScoreItem(0f, 3f, 1f);
            ss.standScoreItems[1] = new StandScoreItem(4f, 4f, 2f);
            ss.standScoreItems[2] = new StandScoreItem(5f, 6f, 3f);
            ss.standScoreItems[3] = new StandScoreItem(7f, 7f, 4f);
            ss.standScoreItems[4] = new StandScoreItem(8f, 9f, 5f);
            ss.standScoreItems[5] = new StandScoreItem(10f, 12f, 6f);
            ss.standScoreItems[6] = new StandScoreItem(13f, 14f, 7f);
            ss.standScoreItems[7] = new StandScoreItem(15f, 16f, 8f);
            ss.standScoreItems[8] = new StandScoreItem(17f, 18f, 9f);
            ss.standScoreItems[9] = new StandScoreItem(19f, 26f, 10f);
            result.Add("F", ss);
            ss = new StandScorer(10);
            ss.standScoreItems[0] = new StandScoreItem(0f, 5f, 1f);
            ss.standScoreItems[1] = new StandScoreItem(6f, 7f, 2f);
            ss.standScoreItems[2] = new StandScoreItem(8f, 9f, 3f);
            ss.standScoreItems[3] = new StandScoreItem(10f, 10f, 4f);
            ss.standScoreItems[4] = new StandScoreItem(11f, 12f, 5f);
            ss.standScoreItems[5] = new StandScoreItem(13f, 14f, 6f);
            ss.standScoreItems[6] = new StandScoreItem(15f, 16f, 7f);
            ss.standScoreItems[7] = new StandScoreItem(17f, 17f, 8f);
            ss.standScoreItems[8] = new StandScoreItem(18f, 18f, 9f);
            ss.standScoreItems[9] = new StandScoreItem(19f, 20f, 10f);
            result.Add("G", ss);
            ss = new StandScorer(10);
            ss.standScoreItems[0] = new StandScoreItem(0f, 1f, 1f);
            ss.standScoreItems[1] = new StandScoreItem(2f, 2f, 2f);
            ss.standScoreItems[2] = new StandScoreItem(3f, 3f, 3f);
            ss.standScoreItems[3] = new StandScoreItem(4f, 6f, 4f);
            ss.standScoreItems[4] = new StandScoreItem(7f, 8f, 5f);
            ss.standScoreItems[5] = new StandScoreItem(9f, 11f, 6f);
            ss.standScoreItems[6] = new StandScoreItem(12f, 14f, 7f);
            ss.standScoreItems[7] = new StandScoreItem(15f, 16f, 8f);
            ss.standScoreItems[8] = new StandScoreItem(17f, 19f, 9f);
            ss.standScoreItems[9] = new StandScoreItem(20f, 26f, 10f);
            result.Add("H", ss);
            ss = new StandScorer(10);
            ss.standScoreItems[0] = new StandScoreItem(0f, 5f, 1f);
            ss.standScoreItems[1] = new StandScoreItem(6f, 6f, 2f);
            ss.standScoreItems[2] = new StandScoreItem(7f, 8f, 3f);
            ss.standScoreItems[3] = new StandScoreItem(9f, 9f, 4f);
            ss.standScoreItems[4] = new StandScoreItem(10f, 11f, 5f);
            ss.standScoreItems[5] = new StandScoreItem(12f, 13f, 6f);
            ss.standScoreItems[6] = new StandScoreItem(14f, 14f, 7f);
            ss.standScoreItems[7] = new StandScoreItem(15f, 16f, 8f);
            ss.standScoreItems[8] = new StandScoreItem(17f, 17f, 9f);
            ss.standScoreItems[9] = new StandScoreItem(18f, 19f, 10f);
            result.Add("I", ss);
            ss = new StandScorer(10);
            ss.standScoreItems[0] = new StandScoreItem(0f, 3f, 1f);
            ss.standScoreItems[1] = new StandScoreItem(4f, 5f, 2f);
            ss.standScoreItems[2] = new StandScoreItem(6f, 6f, 3f);
            ss.standScoreItems[3] = new StandScoreItem(7f, 8f, 4f);
            ss.standScoreItems[4] = new StandScoreItem(9f, 10f, 5f);
            ss.standScoreItems[5] = new StandScoreItem(11f, 12f, 6f);
            ss.standScoreItems[6] = new StandScoreItem(13f, 13f, 7f);
            ss.standScoreItems[7] = new StandScoreItem(14f, 15f, 8f);
            ss.standScoreItems[8] = new StandScoreItem(16f, 16f, 9f);
            ss.standScoreItems[9] = new StandScoreItem(17f, 20f, 10f);
            result.Add("L", ss);
            ss = new StandScorer(10);
            ss.standScoreItems[0] = new StandScoreItem(0f, 5f, 1f);
            ss.standScoreItems[1] = new StandScoreItem(6f, 7f, 2f);
            ss.standScoreItems[2] = new StandScoreItem(8f, 9f, 3f);
            ss.standScoreItems[3] = new StandScoreItem(10f, 11f, 4f);
            ss.standScoreItems[4] = new StandScoreItem(12f, 13f, 5f);
            ss.standScoreItems[5] = new StandScoreItem(14f, 15f, 6f);
            ss.standScoreItems[6] = new StandScoreItem(16f, 17f, 7f);
            ss.standScoreItems[7] = new StandScoreItem(18f, 19f, 8f);
            ss.standScoreItems[8] = new StandScoreItem(20f, 20f, 9f);
            ss.standScoreItems[9] = new StandScoreItem(21f, 26f, 10f);
            result.Add("M", ss);
            ss = new StandScorer(10);
            ss.standScoreItems[0] = new StandScoreItem(0f, 2f, 1f);
            ss.standScoreItems[1] = new StandScoreItem(3f, 3f, 2f);
            ss.standScoreItems[2] = new StandScoreItem(4f, 4f, 3f);
            ss.standScoreItems[3] = new StandScoreItem(5f, 6f, 4f);
            ss.standScoreItems[4] = new StandScoreItem(7f, 8f, 5f);
            ss.standScoreItems[5] = new StandScoreItem(9f, 10f, 6f);
            ss.standScoreItems[6] = new StandScoreItem(11f, 11f, 7f);
            ss.standScoreItems[7] = new StandScoreItem(12f, 13f, 8f);
            ss.standScoreItems[8] = new StandScoreItem(14f, 14f, 9f);
            ss.standScoreItems[9] = new StandScoreItem(15f, 20f, 10f);
            result.Add("N", ss);
            ss = new StandScorer(10);
            ss.standScoreItems[0] = new StandScoreItem(0f, 2f, 1f);
            ss.standScoreItems[1] = new StandScoreItem(3f, 4f, 2f);
            ss.standScoreItems[2] = new StandScoreItem(5f, 6f, 3f);
            ss.standScoreItems[3] = new StandScoreItem(7f, 8f, 4f);
            ss.standScoreItems[4] = new StandScoreItem(9f, 10f, 5f);
            ss.standScoreItems[5] = new StandScoreItem(11f, 12f, 6f);
            ss.standScoreItems[6] = new StandScoreItem(13f, 14f, 7f);
            ss.standScoreItems[7] = new StandScoreItem(15f, 16f, 8f);
            ss.standScoreItems[8] = new StandScoreItem(17f, 18f, 9f);
            ss.standScoreItems[9] = new StandScoreItem(19f, 26f, 10f);
            result.Add("O", ss);
            ss = new StandScorer(10);
            ss.standScoreItems[0] = new StandScoreItem(0f, 4f, 1f);
            ss.standScoreItems[1] = new StandScoreItem(5f, 5f, 2f);
            ss.standScoreItems[2] = new StandScoreItem(6f, 7f, 3f);
            ss.standScoreItems[3] = new StandScoreItem(8f, 8f, 4f);
            ss.standScoreItems[4] = new StandScoreItem(9f, 10f, 5f);
            ss.standScoreItems[5] = new StandScoreItem(11f, 12f, 6f);
            ss.standScoreItems[6] = new StandScoreItem(13f, 13f, 7f);
            ss.standScoreItems[7] = new StandScoreItem(14f, 14f, 8f);
            ss.standScoreItems[8] = new StandScoreItem(15f, 15f, 9f);
            ss.standScoreItems[9] = new StandScoreItem(16f, 20f, 10f);
            result.Add("Q1", ss);
            ss = new StandScorer(10);
            ss.standScoreItems[0] = new StandScoreItem(0f, 5f, 1f);
            ss.standScoreItems[1] = new StandScoreItem(6f, 7f, 2f);
            ss.standScoreItems[2] = new StandScoreItem(8f, 8f, 3f);
            ss.standScoreItems[3] = new StandScoreItem(9f, 10f, 4f);
            ss.standScoreItems[4] = new StandScoreItem(11f, 12f, 5f);
            ss.standScoreItems[5] = new StandScoreItem(13f, 14f, 6f);
            ss.standScoreItems[6] = new StandScoreItem(15f, 15f, 7f);
            ss.standScoreItems[7] = new StandScoreItem(16f, 17f, 8f);
            ss.standScoreItems[8] = new StandScoreItem(18f, 18f, 9f);
            ss.standScoreItems[9] = new StandScoreItem(19f, 20f, 10f);
            result.Add("Q2", ss);
            ss = new StandScorer(10);
            ss.standScoreItems[0] = new StandScoreItem(0f, 4f, 1f);
            ss.standScoreItems[1] = new StandScoreItem(5f, 6f, 2f);
            ss.standScoreItems[2] = new StandScoreItem(7f, 8f, 3f);
            ss.standScoreItems[3] = new StandScoreItem(9f, 10f, 4f);
            ss.standScoreItems[4] = new StandScoreItem(11f, 12f, 5f);
            ss.standScoreItems[5] = new StandScoreItem(13f, 14f, 6f);
            ss.standScoreItems[6] = new StandScoreItem(15f, 15f, 7f);
            ss.standScoreItems[7] = new StandScoreItem(16f, 17f, 8f);
            ss.standScoreItems[8] = new StandScoreItem(18f, 18f, 9f);
            ss.standScoreItems[9] = new StandScoreItem(19f, 20f, 10f);
            result.Add("Q3", ss);
            ss = new StandScorer(10);
            ss.standScoreItems[0] = new StandScoreItem(0f, 2f, 1f);
            ss.standScoreItems[1] = new StandScoreItem(3f, 4f, 2f);
            ss.standScoreItems[2] = new StandScoreItem(5f, 6f, 3f);
            ss.standScoreItems[3] = new StandScoreItem(7f, 8f, 4f);
            ss.standScoreItems[4] = new StandScoreItem(9f, 11f, 5f);
            ss.standScoreItems[5] = new StandScoreItem(12f, 14f, 6f);
            ss.standScoreItems[6] = new StandScoreItem(15f, 16f, 7f);
            ss.standScoreItems[7] = new StandScoreItem(17f, 19f, 8f);
            ss.standScoreItems[8] = new StandScoreItem(20f, 21f, 9f);
            ss.standScoreItems[9] = new StandScoreItem(22f, 26f, 10f);
            result.Add("Q4", ss);
            return result;
        }
        private StandScorer(int count)
        {
            this.standScoreItems = new StandScoreItem[count];
        }
        public float Translate(float score)
        {
            float result;
            for (int i = 0; i < this.standScoreItems.Length; i++)
            {
                if (score >= this.standScoreItems[i].lowerBound && score <= this.standScoreItems[i].upperBound)
                {
                    result = this.standScoreItems[i].standScore;
                    return result;
                }
            }
            result = 0f;
            return result;
        }
    }
}

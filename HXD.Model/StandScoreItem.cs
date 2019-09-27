using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HXD.Model
{
    public class StandScoreItem
    {
        public float lowerBound;
        public float upperBound;
        public float standScore;
        public StandScoreItem(float lowerBound, float upperBound, float standScore)
        {
            this.lowerBound = lowerBound;
            this.upperBound = upperBound;
            this.standScore = standScore;
        }
    }
}

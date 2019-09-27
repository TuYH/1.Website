using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HXD.Measure
{
    public class SubitemScoreEntry : IComparable
    {
        public int index;
        public float score;
        public SubitemScoreEntry(int index, float score)
        {
            this.index = index;
            this.score = score;
        }
        public int CompareTo(object obj)
        {
            SubitemScoreEntry sse = (SubitemScoreEntry)obj;
            return (int)(this.score - sse.score);
        }
    }
}

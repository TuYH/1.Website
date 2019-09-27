using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HXD.Measure
{
    public class ScorerUPI : Scorer
    {
        public override bool Diagnose(int paperId, string answers, string userName, int[] scoreArray, float totalScore, float[] subitemScoreArray, ref string resultText)
        {
            string[] answerArray = answers.Split(new char[]
			{
				'|'
			});
            int chooseYes61to64 = 0;
            for (int index = 60; index <= 63; index++)
            {
                if (answerArray[index] == "0")
                {
                    chooseYes61to64++;
                }
            }
            if (totalScore >= 25f || answerArray[24] == "0" || chooseYes61to64 >= 2)
            {
                resultText = "A、您的心理问题属于第一类学生，可能有较明显心理问题，如果自己无法摆脱，应尽快到学校心理咨询室进行心理咨询。需要进行进一步的诊断，通过进一步的诊断被认为确有心理卫生问题的学生称为A类学生，该类学生需要进行持续的心理咨询。 A类学生特征：各类神经症(恐怖症、强迫症、焦虑症、严重的神经衰弱等)，有精神分裂症倾向、悲观厌世、心理矛盾冲突激烈， 明显影响正常生活、学习者，这类学生可立即预约下次咨询时间， 每周或隔周面谈一次，直至症状减轻。";
            }
            else
            {
                if ((totalScore >= 20f && totalScore <= 24f) || answerArray[7] == "0" || answerArray[15] == "0" || answerArray[25] == "0" || chooseYes61to64 >= 1)
                {
                    resultText = "B、您的心理问题属于第二类学生，可能有轻微的心理问题，应引起自我重视，如有需要可到学校心理咨询室进行心理咨询。没有严重心理卫生问题的学生称为B类学生，该类学生可作为咨询机构今后关注的对象。B类学生特征：存在一般心理问题，如人际关系不协调，新环境不适应等。这类学生有种种烦恼，但仍能够维持正常学习和生活。对他们提供帮助的同时请他们有问题时，随时咨询。";
                }
                else
                {
                    resultText = "C、您的心理问题属于第三类学生，恭喜你现在没有心理问题。有心理问题寻求专业人士的帮助，是很普遍的事情，关键在于我们应该坦然面对并积极解决，这样才能给我们自己一个健康的心理和幸福的人生。没有任何心理卫生问题的学生称为C类学生。C类学生特征：对他们通过面谈可以起到预防的作用。他们的症状暂时不明显或已经解决，以后出现症状，学校咨询中心可以提供帮助。";
                }
            }
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HXD.Measure
{
    public class ScorerHLD : Scorer
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
                int maxSubitemId = sses[sses.Length - 1].index;
                string subitemName = SubItem.GetPaperSubItemName(paperId, maxSubitemId);
                string text;
                if ((text = subitemName) != null)
                {
                    text = string.IsInterned(text);
                    if (text != "R")
                    {
                        if (text != "I")
                        {
                            if (text != "A")
                            {
                                if (text != "S")
                                {
                                    if (text != "E")
                                    {
                                        if (text == "C")
                                        {
                                            resultText = "你的职业倾向为现实型（C型）。C型主要是指各类与文件档案、图书资料、统计报表之类相关的各类科室工作。主要特点：①喜欢按计划办事，习惯接受他人指挥和领导，自己不谋求领导职务；\v②不喜欢冒险和竞争；③工作踏实，忠诚可靠，遵守纪律。主要职业：会计、出纳、统计人员；打字员；办公室人员；秘书和文书；图书管理员；旅游、外贸职员、保管员、邮递员、审计人员、人事职员等。";
                                        }
                                    }
                                    else
                                    {
                                        resultText = "你的职业倾向为现实型（E型）。E型主要是指那些组织与影响他人共同完成组织目标的工作。主要特点：①精力充沛、自信、善交际，具有领导才能；②喜欢竞争，敢冒风险；③喜爱权力、地位和物质财富。主要职业：经理企业家、政府官员、商人、行业部门和单位的领导者、管理者等。";
                                    }
                                }
                                else
                                {
                                    resultText = "你的职业倾向为现实型（S型）。S型主要是指各种直接为他人服务的工作，如医疗服务、教育服务、生活服务等。主要特点：①喜欢从事为他人服务和教育他人的工作；②喜欢参与解决人们共同关心的社会问题，渴望发挥自己的社会作用；③比较看重社会义务和社会道德。主要职业：教师、保育员、行政人员；医护人员；衣食住行服务行业的经理、管理人员和服务人员；福利人员等。";
                                }
                            }
                            else
                            {
                                resultText = "你的职业倾向为现实型（A型）。A型主要是指各类艺术创作工作。主要特点：①喜欢以各种艺术形式的创作来表现自己的才能，实现自身的价值；②具有特殊艺术才能和个性；③乐于创造新颖的、与众不同的艺术成果，渴望表现自己的个性。主要职业：音乐、舞蹈、戏剧等方面的演员、艺术家编导、教师；文学、艺术方面的评论员；广播节目的主持人、编辑、作者；绘画、书法、摄影家；艺术、家具、珠宝、房屋装饰等行业的设计师等。";
                            }
                        }
                        else
                        {
                            resultText = "你的职业倾向为现实型（I型）。I型主要是指科学研究和科学实验工作。主要特点：①抽象思维能力强，求知欲强，肯动脑，善思考，不愿动手；②喜欢独立的和富有创造性的工作；③知识渊博，有学识才能，不善于领导他人。主要职业：自然科学和社会科学方面的研究人员、专家；化学、冶金、电子、无线电、电视、飞机等方面的工程师、技术人员；飞机驾驶员、计算机操作员等。";
                        }
                    }
                    else
                    {
                        resultText = "你的职业倾向为现实型（R型）。R型主要是指各类工程技术工作、农业工作，通常需要一定体力，需要运用工具或操作机器。主要特点：①愿意使用工具从事操作性工作；②动手能力强，做事手脚灵活，动作协调；③不善言辞，不善交际。主要职业有：工程师、技术员；机械操作、维修、安装工人，矿工、木工、电工、鞋匠等；司机，测绘员、描图员；农民、牧民、渔民等。";
                    }
                }
            }
            return res;
        }
    }
}

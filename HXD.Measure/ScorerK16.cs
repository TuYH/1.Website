using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace HXD.Measure
{
    public class ScorerK16 : Scorer
    {
        public override bool SeniorScore(int paperId, string answers, int[] scoreArray, string userName, ref string resultText, out int[] subitemIds, out float[] subitemScoreArray)
        {
            bool result;
            if (!base.SeniorScore(paperId, answers, scoreArray, userName, ref resultText, out subitemIds, out subitemScoreArray))
            {
                result = false;
            }
            else
            {
                if (subitemScoreArray.Length != 16)
                {
                    result = false;
                }
                else
                {
                    Hashtable standScorers = StandScorer.CreateStandScorerK16();
                    Hashtable subitemIndexMap = SubItem.GetPaperSubItemIndexMap(paperId, 1);
                    

                    subitemScoreArray[(int)subitemIndexMap["A"]] = ((StandScorer)standScorers["A"]).Translate(subitemScoreArray[(int)subitemIndexMap["A"]]);
                    subitemScoreArray[(int)subitemIndexMap["B"]] = ((StandScorer)standScorers["B"]).Translate(subitemScoreArray[(int)subitemIndexMap["B"]]);
                    subitemScoreArray[(int)subitemIndexMap["C"]] = ((StandScorer)standScorers["C"]).Translate(subitemScoreArray[(int)subitemIndexMap["C"]]);
                    subitemScoreArray[(int)subitemIndexMap["E"]] = ((StandScorer)standScorers["E"]).Translate(subitemScoreArray[(int)subitemIndexMap["E"]]);
                    subitemScoreArray[(int)subitemIndexMap["F"]] = ((StandScorer)standScorers["F"]).Translate(subitemScoreArray[(int)subitemIndexMap["F"]]);
                    subitemScoreArray[(int)subitemIndexMap["G"]] = ((StandScorer)standScorers["G"]).Translate(subitemScoreArray[(int)subitemIndexMap["G"]]);
                    subitemScoreArray[(int)subitemIndexMap["H"]] = ((StandScorer)standScorers["H"]).Translate(subitemScoreArray[(int)subitemIndexMap["H"]]);
                    subitemScoreArray[(int)subitemIndexMap["I"]] = ((StandScorer)standScorers["I"]).Translate(subitemScoreArray[(int)subitemIndexMap["I"]]);
                    subitemScoreArray[(int)subitemIndexMap["L"]] = ((StandScorer)standScorers["L"]).Translate(subitemScoreArray[(int)subitemIndexMap["L"]]);
                    subitemScoreArray[(int)subitemIndexMap["M"]] = ((StandScorer)standScorers["M"]).Translate(subitemScoreArray[(int)subitemIndexMap["M"]]);
                    subitemScoreArray[(int)subitemIndexMap["N"]] = ((StandScorer)standScorers["N"]).Translate(subitemScoreArray[(int)subitemIndexMap["N"]]);
                    subitemScoreArray[(int)subitemIndexMap["O"]] = ((StandScorer)standScorers["O"]).Translate(subitemScoreArray[(int)subitemIndexMap["O"]]);
                    subitemScoreArray[(int)subitemIndexMap["Q1"]] = ((StandScorer)standScorers["Q1"]).Translate(subitemScoreArray[(int)subitemIndexMap["Q1"]]);
                    subitemScoreArray[(int)subitemIndexMap["Q2"]] = ((StandScorer)standScorers["Q2"]).Translate(subitemScoreArray[(int)subitemIndexMap["Q2"]]);
                    subitemScoreArray[(int)subitemIndexMap["Q3"]] = ((StandScorer)standScorers["Q3"]).Translate(subitemScoreArray[(int)subitemIndexMap["Q3"]]);
                    subitemScoreArray[(int)subitemIndexMap["Q4"]] = ((StandScorer)standScorers["Q4"]).Translate(subitemScoreArray[(int)subitemIndexMap["Q4"]]);
                    if (subitemScoreArray.Length != 16)
                    {
                        result = false;
                    }
                    else
                    {
                        float A = subitemScoreArray[(int)subitemIndexMap["A"]];
                        float B = subitemScoreArray[(int)subitemIndexMap["B"]];
                        float C = subitemScoreArray[(int)subitemIndexMap["C"]];
                        float E = subitemScoreArray[(int)subitemIndexMap["E"]];
                        float F = subitemScoreArray[(int)subitemIndexMap["F"]];
                        float G = subitemScoreArray[(int)subitemIndexMap["G"]];
                        float H = subitemScoreArray[(int)subitemIndexMap["H"]];
                        float I = subitemScoreArray[(int)subitemIndexMap["I"]];
                        float L = subitemScoreArray[(int)subitemIndexMap["L"]];
                        float M = subitemScoreArray[(int)subitemIndexMap["M"]];
                        float N = subitemScoreArray[(int)subitemIndexMap["N"]];
                        float O = subitemScoreArray[(int)subitemIndexMap["O"]];
                        float Q = subitemScoreArray[(int)subitemIndexMap["Q1"]];
                        float Q2 = subitemScoreArray[(int)subitemIndexMap["Q2"]];
                        float Q3 = subitemScoreArray[(int)subitemIndexMap["Q3"]];
                        float Q4 = subitemScoreArray[(int)subitemIndexMap["Q4"]];
                        float X = (38f + 2f * L + 3f * O + 4f * Q4 - (2f * C + 2f * H + 2f * Q2)) / 10f;
                        float X2 = (2f * A + 3f * E + 4f * F + 5f * H - (2f * Q2 + 11f)) / 10f;
                        float X3 = (77f + 2f * C + 2f * E + 2f * F + 2f * N - (4f * A + 6f * I + 2f * M)) / 10f;
                        float X4 = (4f * E + 3f * M + 4f * Q + 4f * Q2 - (3f * A + 2f * G)) / 10f;
                        float Y = C + F + (11f - O) + (11f - Q4);
                        float Y2 = 2f * Q3 + G * 2f + C * 2f + E + N + Q2 + Q;
                        float Y3 = (11f - A) * 2f + B * 2f + E + (11f - F) * 2f + H + I * 2f + M + (11f - N) + Q + Q2 * 2f;
                        float Y4 = B + G + Q3 + (11f - F);
                        int[] newSubitemIds = new int[24];
                        float[] newSubitemScoreArray = new float[24];
                        for (int i = 0; i < subitemIds.Length; i++)
                        {
                            newSubitemIds[i] = subitemIds[i];
                            newSubitemScoreArray[i] = subitemScoreArray[i];
                        }
                        Hashtable subitemIdMap = SubItem.GetPaperSubItemIdMap(paperId, 2);
                        int Base = subitemIds.Length;
                        newSubitemIds[Base] = (int)subitemIdMap["X1"];
                        newSubitemIds[Base + 1] = (int)subitemIdMap["X2"];
                        newSubitemIds[Base + 2] = (int)subitemIdMap["X3"];
                        newSubitemIds[Base + 3] = (int)subitemIdMap["X4"];
                        newSubitemIds[Base + 4] = (int)subitemIdMap["Y1"];
                        newSubitemIds[Base + 5] = (int)subitemIdMap["Y2"];
                        newSubitemIds[Base + 6] = (int)subitemIdMap["Y3"];
                        newSubitemIds[Base + 7] = (int)subitemIdMap["Y4"];
                        newSubitemScoreArray[Base] = X;
                        newSubitemScoreArray[Base + 1] = X2;
                        newSubitemScoreArray[Base + 2] = X3;
                        newSubitemScoreArray[Base + 3] = X4;
                        newSubitemScoreArray[Base + 4] = Y;
                        newSubitemScoreArray[Base + 5] = Y2;
                        newSubitemScoreArray[Base + 6] = Y3;
                        newSubitemScoreArray[Base + 7] = Y4;
                        subitemIds = newSubitemIds;
                        subitemScoreArray = newSubitemScoreArray;
                        resultText = "A：乐群性得分：" + Math.Round((double)A, 2).ToString();
                        resultText = resultText + "<br/>B：聪慧性得分：" + Math.Round((double)B, 2).ToString();
                        resultText = resultText + "<br/>C：稳定性得分：" + Math.Round((double)C, 2).ToString();
                        resultText = resultText + "<br/>E：恃强性得分：" + Math.Round((double)E, 2).ToString();
                        resultText = resultText + "<br/>F：兴奋性得分：" + Math.Round((double)F, 2).ToString();
                        resultText = resultText + "<br/>G：有恒性得分：" + Math.Round((double)G, 2).ToString();
                        resultText = resultText + "<br/>H：敢为性得分：" + Math.Round((double)H, 2).ToString();
                        resultText = resultText + "<br/>I：敏感性得分：" + Math.Round((double)I, 2).ToString();
                        resultText = resultText + "<br/>L：怀疑性得分：" + Math.Round((double)L, 2).ToString();
                        resultText = resultText + "<br/>M：幻想性得分：" + Math.Round((double)M, 2).ToString();
                        resultText = resultText + "<br/>N：世故性得分：" + Math.Round((double)N, 2).ToString();
                        resultText = resultText + "<br/>O：忧虑性得分：" + Math.Round((double)O, 2).ToString();
                        resultText = resultText + "<br/>Q1：实验性得分：" + Math.Round((double)Q, 2).ToString();
                        resultText = resultText + "<br/>Q2：独立性得分：" + Math.Round((double)Q2, 2).ToString();
                        resultText = resultText + "<br/>Q3：自律性得分：" + Math.Round((double)Q3, 2).ToString();
                        resultText = resultText + "<br/>Q4：紧张性得分：" + Math.Round((double)Q4, 2).ToString();
                        resultText = resultText + "<br/>X1：适应与焦虑型得分：" + Math.Round((double)X, 2).ToString();
                        resultText = resultText + "<br/>X2：内向与外向型得分：" + Math.Round((double)X2, 2).ToString();
                        resultText = resultText + "<br/>X3：感情用事与安详机警型得分：" + Math.Round((double)X3, 2).ToString();
                        resultText = resultText + "<br/>X4：怯懦与果断型得分：" + Math.Round((double)X4, 2).ToString();
                        resultText = resultText + "<br/>Y1：心理健康因素得分：" + Math.Round((double)Y, 2).ToString();
                        resultText = resultText + "<br/>Y2：专业有成就者的个性因素得分：" + Math.Round((double)Y2, 2).ToString();
                        resultText = resultText + "<br/>Y3：创造能力个性因素得分：" + Math.Round((double)Y3, 2).ToString();
                        resultText = resultText + "<br/>Y4：在新环境中有成长能力的个性因素得分：" + Math.Round((double)Y4, 2).ToString();
                        result = true;
                    }
                }
            }
            return result;
        }
    }
}

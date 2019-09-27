using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace HXD.Measure
{
    public class ScorerMMPIFemale : Scorer
    {
        private Hashtable hsSpecialScoreRef = new Hashtable();
        public ScorerMMPIFemale()
        {
            this.hsSpecialScoreRef.Add("l15", new int[]
			{
				default(int),
				1
			});
            this.hsSpecialScoreRef.Add("si25", new int[]
			{
				default(int),
				1
			});
            this.hsSpecialScoreRef.Add("si33", new int[]
			{
				default(int),
				1
			});
            Hashtable arg_7C_0 = this.hsSpecialScoreRef;
            object arg_7C_1 = "ma64";
            int[] array = new int[2];
            array[0] = 1;
            arg_7C_0.Add(arg_7C_1, array);
            Hashtable arg_9B_0 = this.hsSpecialScoreRef;
            object arg_9B_1 = "si82";
            int[] array2 = new int[2];
            array2[0] = 1;
            arg_9B_0.Add(arg_9B_1, array2);
            this.hsSpecialScoreRef.Add("pd96", new int[]
			{
				default(int),
				1
			});
            Hashtable arg_D9_0 = this.hsSpecialScoreRef;
            object arg_D9_1 = "ma109";
            int[] array3 = new int[2];
            array3[0] = 1;
            arg_D9_0.Add(arg_D9_1, array3);
            Hashtable arg_F8_0 = this.hsSpecialScoreRef;
            object arg_F8_1 = "si111";
            int[] array4 = new int[2];
            array4[0] = 1;
            arg_F8_0.Add(arg_F8_1, array4);
            Hashtable arg_117_0 = this.hsSpecialScoreRef;
            object arg_117_1 = "si117";
            int[] array5 = new int[2];
            array5[0] = 1;
            arg_117_0.Add(arg_117_1, array5);
            Hashtable arg_136_0 = this.hsSpecialScoreRef;
            object arg_136_1 = "si124";
            int[] array6 = new int[2];
            array6[0] = 1;
            arg_136_0.Add(arg_136_1, array6);
            this.hsSpecialScoreRef.Add("si126", new int[]
			{
				default(int),
				1
			});
            this.hsSpecialScoreRef.Add("hs130", new int[]
			{
				default(int),
				1
			});
            Hashtable arg_193_0 = this.hsSpecialScoreRef;
            object arg_193_1 = "mf_m134";
            int[] array7 = new int[2];
            array7[0] = 1;
            arg_193_0.Add(arg_193_1, array7);
            Hashtable arg_1B2_0 = this.hsSpecialScoreRef;
            object arg_1B2_1 = "ma134";
            int[] array8 = new int[2];
            array8[0] = 1;
            arg_1B2_0.Add(arg_1B2_1, array8);
            this.hsSpecialScoreRef.Add("k138", new int[]
			{
				default(int),
				1
			});
            this.hsSpecialScoreRef.Add("k142", new int[]
			{
				default(int),
				1
			});
            this.hsSpecialScoreRef.Add("si143", new int[]
			{
				default(int),
				1
			});
            Hashtable arg_22E_0 = this.hsSpecialScoreRef;
            object arg_22E_1 = "si147";
            int[] array9 = new int[2];
            array9[0] = 1;
            arg_22E_0.Add(arg_22E_1, array9);
            Hashtable arg_24D_0 = this.hsSpecialScoreRef;
            object arg_24D_1 = "si171";
            int[] array10 = new int[2];
            array10[0] = 1;
            arg_24D_0.Add(arg_24D_1, array10);
            Hashtable arg_26C_0 = this.hsSpecialScoreRef;
            object arg_26C_1 = "si172";
            int[] array11 = new int[2];
            array11[0] = 1;
            arg_26C_0.Add(arg_26C_1, array11);
            Hashtable arg_28B_0 = this.hsSpecialScoreRef;
            object arg_28B_1 = "si180";
            int[] array12 = new int[2];
            array12[0] = 1;
            arg_28B_0.Add(arg_28B_1, array12);
            this.hsSpecialScoreRef.Add("sc187", new int[]
			{
				default(int),
				1
			});
            this.hsSpecialScoreRef.Add("si193", new int[]
			{
				default(int),
				1
			});
            Hashtable arg_2E8_0 = this.hsSpecialScoreRef;
            object arg_2E8_1 = "si201";
            int[] array13 = new int[2];
            array13[0] = 1;
            arg_2E8_0.Add(arg_2E8_1, array13);
            this.hsSpecialScoreRef.Add("k217", new int[]
			{
				default(int),
				1
			});
            Hashtable arg_326_0 = this.hsSpecialScoreRef;
            object arg_326_1 = "mf_m231";
            int[] array14 = new int[2];
            array14[0] = 1;
            arg_326_0.Add(arg_326_1, array14);
            this.hsSpecialScoreRef.Add("d233", new int[]
			{
				default(int),
				1
			});
            this.hsSpecialScoreRef.Add("d241", new int[]
			{
				default(int),
				1
			});
            this.hsSpecialScoreRef.Add("d263", new int[]
			{
				default(int),
				1
			});
            Hashtable arg_3A2_0 = this.hsSpecialScoreRef;
            object arg_3A2_1 = "si267";
            int[] array15 = new int[2];
            array15[0] = 1;
            arg_3A2_0.Add(arg_3A2_1, array15);
            Hashtable arg_3C1_0 = this.hsSpecialScoreRef;
            object arg_3C1_1 = "ma268";
            int[] array16 = new int[2];
            array16[0] = 1;
            arg_3C1_0.Add(arg_3C1_1, array16);
            this.hsSpecialScoreRef.Add("d271", new int[]
			{
				default(int),
				1
			});
            Hashtable arg_3FF_0 = this.hsSpecialScoreRef;
            object arg_3FF_1 = "ma279";
            int[] array17 = new int[2];
            array17[0] = 1;
            arg_3FF_0.Add(arg_3FF_1, array17);
            this.hsSpecialScoreRef.Add("hy292", new int[]
			{
				default(int),
				1
			});
            Hashtable arg_43D_0 = this.hsSpecialScoreRef;
            object arg_43D_1 = "si316";
            int[] array18 = new int[2];
            array18[0] = 1;
            arg_43D_0.Add(arg_43D_1, array18);
            this.hsSpecialScoreRef.Add("si359", new int[]
			{
				default(int),
				1
			});
            Hashtable arg_47B_0 = this.hsSpecialScoreRef;
            object arg_47B_1 = "si370";
            int[] array19 = new int[2];
            array19[0] = 1;
            arg_47B_0.Add(arg_47B_1, array19);
            Hashtable arg_49A_0 = this.hsSpecialScoreRef;
            object arg_49A_1 = "si373";
            int[] array20 = new int[2];
            array20[0] = 1;
            arg_49A_0.Add(arg_49A_1, array20);
        }
        private int GetScore(int questionId, string subitemName, int select, int[] scoreArray)
        {
            string key = subitemName + questionId.ToString();
            int result;
            if (this.hsSpecialScoreRef.Contains(key))
            {
                int[] scoreRef = (int[])this.hsSpecialScoreRef[key];
                result = scoreRef[select];
            }
            else
            {
                result = scoreArray[questionId - 1];
            }
            return result;
        }
        public override bool SeniorScore(int paperId, string answers, int[] scoreArray, string userName, ref string resultText, out int[] subitemIds, out float[] subitemScoreArray)
        {
            Hashtable M = new Hashtable();
            Hashtable S = new Hashtable();
            M.Add("女l", 4.12);
            M.Add("女f", 2.73);
            M.Add("女k", 12.37);
            M.Add("女hs", 12.95);
            M.Add("女d", 19.25);
            M.Add("女hy", 19.01);
            M.Add("女pd", 18.8);
            M.Add("女mf_m", 28.66);
            M.Add("女pa", 8.03);
            M.Add("女pt", 25.2);
            M.Add("女sc", 22.39);
            M.Add("女ma", 16.6);
            M.Add("女si", 24.62);
            S.Add("女l", 2.94);
            S.Add("女f", 4.55);
            S.Add("女k", 5.26);
            S.Add("女hs", 4.92);
            S.Add("女d", 5.15);
            S.Add("女hy", 5.63);
            S.Add("女pd", 4.24);
            S.Add("女mf_m", 4.81);
            S.Add("女pa", 3.49);
            S.Add("女pt", 6.08);
            S.Add("女sc", 6.52);
            S.Add("女ma", 4);
            S.Add("女si", 9.62);
            DataSet ds = SubItem.GetPaperSubItems(paperId, 1);
            int subitemCount = ds.Tables[0].Rows.Count;// ds.get_Tables().get_Item(0).get_Rows().get_Count();
            bool result;
            if (subitemCount <= 0)
            {
                subitemIds = null;
                subitemScoreArray = null;
                result = false;
            }
            else
            {
                resultText = "";
                subitemIds = new int[subitemCount];
                float[] T = new float[subitemCount];
                float[] X = new float[subitemCount];
                string[] answerArray = answers.Split(new char[]
				{
					'|'
				});
                for (int i = 0; i < subitemCount; i++)
                {
                    DataRow dr = ds.Tables[0].Rows[i];
                    subitemIds[i] = (int)dr["Fsubitemid"];
                    X[i] = 0f;
                    string[] questionIds = dr["Fquestions"].ToString().Split(new char[]
					{
						'|'
					});
                    for (int j = 0; j < questionIds.Length; j++)
                    {
                        int questionId = int.Parse(questionIds[j]);
                        int select = int.Parse(answerArray[questionId - 1]);
                        int score = this.GetScore(questionId, dr["Fsubitemname"].ToString(), select, scoreArray);
                        float[] array;
                        IntPtr intPtr;
                        (array = X)[(int)(intPtr = (IntPtr)i)] = array[(int)intPtr] + (float)score;
                    }
                }
                Hashtable subitemIndexMap = SubItem.GetPaperSubItemIndexMap(paperId, 1);
                float K = X[(int)subitemIndexMap["k"]];
                float[] array2;
                IntPtr intPtr2;
                (array2 = X)[(int)(intPtr2 = (IntPtr)((int)subitemIndexMap["hs"]))] = array2[(int)intPtr2] + 0.5f * K;
                float[] array3;
                IntPtr intPtr3;
                (array3 = X)[(int)(intPtr3 = (IntPtr)((int)subitemIndexMap["pd"]))] = array3[(int)intPtr3] + 0.4f * K;
                float[] array4;
                IntPtr intPtr4;
                (array4 = X)[(int)(intPtr4 = (IntPtr)((int)subitemIndexMap["pt"]))] = array4[(int)intPtr4] + 1f * K;
                float[] array5;
                IntPtr intPtr5;
                (array5 = X)[(int)(intPtr5 = (IntPtr)((int)subitemIndexMap["sc"]))] = array5[(int)intPtr5] + 1f * K;
                float[] array6;
                IntPtr intPtr6;
                (array6 = X)[(int)(intPtr6 = (IntPtr)((int)subitemIndexMap["ma"]))] = array6[(int)intPtr6] + 0.2f * K;
                for (int k = 0; k < subitemCount; k++)
                {
                    DataRow dr2 = ds.Tables[0].Rows[k];
                    string subitemName = dr2["Fsubitemname"].ToString();
                    string key = "女" + subitemName;
                    T[k] = (float)Math.Round((double)(50f + 10f * (X[k] - float.Parse(M[key].ToString())) / float.Parse(S[key].ToString())), 2);
                    resultText = resultText + subitemName + "的得分是：" + T[k].ToString();
                    if (k != subitemCount - 1)
                    {
                        resultText += "<br/>";
                    }
                }
                subitemScoreArray = T;
                result = true;
            }
            return result;
        }
    }
}

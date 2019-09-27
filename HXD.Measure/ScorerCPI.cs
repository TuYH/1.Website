using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace HXD.Measure
{
    public class ScorerCPI : Scorer
    {
        private Hashtable hsSpecialScoreRef = new Hashtable();
        public ScorerCPI()
        {
            Hashtable arg_28_0 = this.hsSpecialScoreRef;
            object arg_28_1 = "Fe28";
            int[] array = new int[2];
            array[0] = 1;
            arg_28_0.Add(arg_28_1, array);
            this.hsSpecialScoreRef.Add("Fx36", new int[]
			{
				default(int),
				1
			});
            this.hsSpecialScoreRef.Add("To47", new int[]
			{
				default(int),
				1
			});
            this.hsSpecialScoreRef.Add("Cm53", new int[]
			{
				default(int),
				1
			});
            this.hsSpecialScoreRef.Add("Ac58", new int[]
			{
				default(int),
				1
			});
            this.hsSpecialScoreRef.Add("To60", new int[]
			{
				default(int),
				1
			});
            Hashtable arg_D9_0 = this.hsSpecialScoreRef;
            object arg_D9_1 = "Sc64";
            int[] array2 = new int[2];
            array2[0] = 1;
            arg_D9_0.Add(arg_D9_1, array2);
            this.hsSpecialScoreRef.Add("Cm66", new int[]
			{
				default(int),
				1
			});
            Hashtable arg_117_0 = this.hsSpecialScoreRef;
            object arg_117_1 = "Fe73";
            int[] array3 = new int[2];
            array3[0] = 1;
            arg_117_0.Add(arg_117_1, array3);
            this.hsSpecialScoreRef.Add("Ie115", new int[]
			{
				default(int),
				1
			});
            Hashtable arg_155_0 = this.hsSpecialScoreRef;
            object arg_155_1 = "So132";
            int[] array4 = new int[2];
            array4[0] = 1;
            arg_155_0.Add(arg_155_1, array4);
            Hashtable arg_174_0 = this.hsSpecialScoreRef;
            object arg_174_1 = "Fe134";
            int[] array5 = new int[2];
            array5[0] = 1;
            arg_174_0.Add(arg_174_1, array5);
            Hashtable arg_193_0 = this.hsSpecialScoreRef;
            object arg_193_1 = "Fx155";
            int[] array6 = new int[2];
            array6[0] = 1;
            arg_193_0.Add(arg_193_1, array6);
            this.hsSpecialScoreRef.Add("So158", new int[]
			{
				default(int),
				1
			});
            this.hsSpecialScoreRef.Add("Fx164", new int[]
			{
				default(int),
				1
			});
            Hashtable arg_1F0_0 = this.hsSpecialScoreRef;
            object arg_1F0_1 = "Wb168";
            int[] array7 = new int[2];
            array7[0] = 1;
            arg_1F0_0.Add(arg_1F0_1, array7);
            this.hsSpecialScoreRef.Add("Fx203", new int[]
			{
				default(int),
				1
			});
            this.hsSpecialScoreRef.Add("Cm221", new int[]
			{
				default(int),
				1
			});
            this.hsSpecialScoreRef.Add("To230", new int[]
			{
				default(int),
				1
			});
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
            M.Add("男Do", 9.15);
            S.Add("男Do", 3.44);
            M.Add("男Cs", 6.11);
            S.Add("男Cs", 2.27);
            M.Add("男Sy", 9.2);
            S.Add("男Sy", 3.23);
            M.Add("男Sp", 8.64);
            S.Add("男Sp", 2.88);
            M.Add("男Sa", 4.75);
            S.Add("男Sa", 2.5);
            M.Add("男Wb", 14.64);
            S.Add("男Wb", 3.16);
            M.Add("男Re", 10.16);
            S.Add("男Re", 2.41);
            M.Add("男So", 13.44);
            S.Add("男So", 3.11);
            M.Add("男Sc", 15.8);
            S.Add("男Sc", 4.6);
            M.Add("男To", 9.7);
            S.Add("男To", 3);
            M.Add("男Gi", 10.5);
            S.Add("男Gi", 3.8);
            M.Add("男Cm", 9.88);
            S.Add("男Cm", 1.85);
            M.Add("男Ac", 8.91);
            S.Add("男Ac", 2.55);
            M.Add("男Ai", 6.9);
            S.Add("男Ai", 2.36);
            M.Add("男Ie", 10);
            S.Add("男Ie", 2.37);
            M.Add("男Py", 5.8);
            S.Add("男Py", 2);
            M.Add("男Fx", 5);
            S.Add("男Fx", 2.5);
            M.Add("男Fe", 7.23);
            S.Add("男Fe", 2.29);
            M.Add("女Do", 8.78);
            S.Add("女Do", 3.11);
            M.Add("女Cs", 5.61);
            S.Add("女Cs", 2.56);
            M.Add("女Sy", 9.24);
            S.Add("女Sy", 3.17);
            M.Add("女Sp", 8.53);
            S.Add("女Sp", 2.69);
            M.Add("女Sa", 4.52);
            S.Add("女Sa", 2.2);
            M.Add("女Wb", 14.52);
            S.Add("女Wb", 3.22);
            M.Add("女Re", 11.06);
            S.Add("女Re", 2.34);
            M.Add("女So", 13.77);
            S.Add("女So", 2.97);
            M.Add("女Sc", 16.19);
            S.Add("女Sc", 4.9);
            M.Add("女To", 10);
            S.Add("女To", 3.12);
            M.Add("女Gi", 10);
            S.Add("女Gi", 3.85);
            M.Add("女Cm", 10);
            S.Add("女Cm", 1.79);
            M.Add("女Ac", 9);
            S.Add("女Ac", 2.35);
            M.Add("女Ai", 6.8);
            S.Add("女Ai", 2.32);
            M.Add("女Ie", 9.76);
            S.Add("女Ie", 2.41);
            M.Add("女Py", 6);
            S.Add("女Py", 2);
            M.Add("女Fx", 5);
            S.Add("女Fx", 2.63);
            M.Add("女Fe", 9.16);
            S.Add("女Fe", 2.41);
            DataSet ds = SubItem.GetPaperSubItems(paperId, 1);
            int subitemCount = ds.Tables[0].Rows.Count;
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
                        float[] array;
                        IntPtr intPtr;
                        (array = X)[(int)(intPtr = (IntPtr)i)] = array[(int)intPtr] + (float)scoreArray[questionId - 1];
                    }
                    string subitemName = dr["Fsubitemname"].ToString();
                   // DataRow drStu = SchoolDB.GetStudent(userName);
                    string key = SchoolDB.GetStudent(userName);
                    key += subitemName;
                    T[i] = (float)Math.Round((double)(50f + 10f * (X[i] - float.Parse(M[key].ToString())) / float.Parse(S[key].ToString())), 2);
                    resultText = resultText + subitemName + "的得分是：" + T[i].ToString();
                    if (i != subitemCount - 1)
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

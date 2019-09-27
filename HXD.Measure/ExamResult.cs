using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HXD.Measure
{
    public class ExamResult
    {
        public static bool HasDoneThisPaper(string studentNo, int paperId, int testNum)
        {
            string sql = "select count(Fresultid) from t_exam_results where FstudentNo = '{0}' and Fpaperid = {1} and Ftestnum = {2}";
            sql = string.Format(sql, studentNo, paperId, testNum);
            DataBase db = new DataBase();
            int res = (int)db.ExecuteSqlScalar(sql, null);
            return res >= 1;
        }
        public static void SaveSubItemResult(string studentNo, int resultid, int[] subitemids, float[] scores)
        {
            if (subitemids != null && scores != null)
            {
                if (subitemids.Length == scores.Length)
                {
                    string[] sqls = new string[subitemids.Length];
                    for (int i = 0; i < subitemids.Length; i++)
                    {
                        int subitemid = subitemids[i];
                        float score = scores[i];
                        string sql = "insert into t_exam_subitems_score (FstudentNo, Fresultid, Fsubitemid, Fscore) values ('{0}', {1}, {2}, {3})";
                        sql = string.Format(sql, new object[]
						{
							studentNo,
							resultid,
							subitemid,
							score
						});
                        sqls[i] = sql;
                    }
                    DataBase db = new DataBase();
                    db.ExecuteSql(sqls);
                }
            }
        }
        public static int SaveResult(string studentNo, int paperId, string answer, int[] score4each, float totalScore, string result, int testNum)
        {
            string score4Each = "";
            for (int i = 0; i < score4each.Length; i++)
            {
                score4Each += score4each[i].ToString();
                if (i != score4each.Length - 1)
                {
                    score4Each += "|";
                }
            }
            string sql = "insert into t_exam_results (FstudentNo, Fpaperid, Fanswer, Fscore4each, Fscore, Fresult, Ftesttime, Ftestnum)\r\n\t\t\t\t\t\tvalues ('{0}', {1}, '{2}', '{3}', {4}, '{5}', getdate(), {6}); \r\n\t\t\t\t\t\tselect max(@@IDENTITY) from t_exam_results";
            sql = string.Format(sql, new object[]
			{
				studentNo,
				paperId,
				answer,
				score4Each,
				totalScore,
				result,
				testNum
			});
            DataBase db = new DataBase();
            return int.Parse(db.ExecuteSqlScalar(sql, null).ToString());
        }
        public static void DeleteResult(int resultid)
        {
            string sql = "delete from t_exam_results where Fresultid = {0}";
            sql = string.Format(sql, resultid);
            DataBase db = new DataBase();
            db.ExecuteSql(sql, null);
        }
        public static void DeleteResults(string studentFilter, string paperFilter)
        {
            string sql = "\r\n\t\t\t\tdelete from t_exam_results \r\n\t\t\t\twhere FstudentNo in (\r\n\t\t\t\t\tselect FstudentNo \r\n\t\t\t\t\tfrom t_Student, t_exam_results \r\n\t\t\t\t\twhere FstudentNo = StudentNo and {0}) \r\n\t\t\t\tand {1}";
            sql = string.Format(sql, studentFilter, paperFilter);
            DataBase db = new DataBase();
            db.ExecuteSql(sql, null);
        }
        public static void DeleteResultRef(int examPaperId)
        {
            string sql = "delete from t_exam_result_ref where Fexampaperid = {0}";
            sql = string.Format(sql, examPaperId);
            DataBase db = new DataBase();
            db.ExecuteSql(sql, null);
        }
        public static void AddResultRef(int examPaperId, string scoreSpan, string resultText)
        {
            string sql = "insert into t_exam_result_ref \r\n\t\t\t\t\t\t(Fexampaperid, FscoreSpan, FresultText) values ({0}, '{1}', '{2}')";
            sql = string.Format(sql, examPaperId, scoreSpan, resultText);
            DataBase db = new DataBase();
            db.ExecuteSql(sql, null);
        }
        public static DataTable GetResultList(string filter)
        {
            string sql = "select * from v_TestResults where " + filter + " order by Ftesttime desc";
            DataBase db = new DataBase();
            DataSet ds;
            db.ExecuteSql(sql, null, out ds);
            return ds.Tables[0];
        }
        public static DataTable GetResultList(int paperId)
        {
            string sql = "select * from t_exam_results where Fpaperid = {0}";
            sql = string.Format(sql, paperId);
            DataBase db = new DataBase();
            DataSet ds;
            db.ExecuteSql(sql, null, out ds);
            return ds.Tables[0];
        }
        public static DataTable GetResultListForExport(int paperId, string filter)
        {
            DataBase db = new DataBase();
            SqlParameter[] parms = new SqlParameter[]
			{
				db.MakeInParam("@paperid", 8, 0, paperId),
				db.MakeInParam("@filter", 12, 1000, filter)
			};
            DataSet ds;
            db.RunProc("upExamResultListExport", parms, out ds);
            return ds.Tables[0];
        }
        public static DataTable GetResultListGroupedForExport(int paperId, string groupby, string filter)
        {
            DataBase db = new DataBase();
            SqlParameter[] parms = new SqlParameter[]
			{
				db.MakeInParam("@paperid", 8, 0, paperId),
				db.MakeInParam("@groupby", 12, 20, groupby),
				db.MakeInParam("@filter", 12, 1000, filter)
			};
            DataSet ds;
            db.RunProc("upExamResultListGroupedExport", parms, out ds);
            return ds.Tables[0];
        }
        public static DataTable GetAbsenceForExport(int paperId, int testnum, string filter)
        {
            DataBase db = new DataBase();
            SqlParameter[] parms = new SqlParameter[]
			{
				db.MakeInParam("@paperid", 8, 0, paperId),
				db.MakeInParam("@testnum", 8, 0, testnum),
				db.MakeInParam("@filter", 12, 1000, filter)
			};
            DataSet ds;
            db.RunProc("upExamAbsenceExport", parms, out ds);
            return ds.Tables[0];
        }
        public static DataRow GetResult(string studentNo, int Fresultid)
        {
            string sql = "select * from t_exam_results where FstudentNo = '{0}' and Fresultid = {1}";
            sql = string.Format(sql, studentNo, Fresultid);
            DataBase db = new DataBase();
            DataSet ds;
            db.ExecuteSql(sql, null, out ds);
            DataRow result;
            if (ds.Tables[0].Rows.Count == 0)
            {
                result = null;
            }
            else
            {
                result = ds.Tables[0].Rows[0];
            }
            return result;
        }
        public static DataTable GetSubItemResult(string studentNo, int paperId, int resultId, int level)
        {
            DataBase db = new DataBase();
            SqlParameter[] parms = new SqlParameter[]
			{
				db.MakeInParam("@studentNo", 12, 50, studentNo),
				db.MakeInParam("@paperid", 8, 0, paperId),
				db.MakeInParam("@resultId", 8, 0, resultId),
				db.MakeInParam("@level", 8, 0, level)
			};
            DataSet ds;
            DataTable result;
            if (db.RunProc("upExamSubitemResultGet", parms, out ds) == 0)
            {
                result = ds.Tables[0];
            }
            else
            {
                result = new DataTable();
            }
            return result;
        }
        public static string GetSubItemResultExplain(int paperId, string subitemName, float subitemScore)
        {
            DataTable dt = SubItem.GetSubItemResultExplain(paperId, subitemName);
            int i = 0;
            string result;
            while (i < dt.Rows.Count)
            {
                string[] scoreSpans =dt.Rows[i]["FscoreSpan"].ToString().Split(new char[]
				{
					'|'
				});
                if (scoreSpans.Length != 2)
                {
                    result = "";
                }
                else
                {
                    float lowerScore = float.Parse(scoreSpans[0]);
                    float upperScore = float.Parse(scoreSpans[1]);
                    if (subitemScore < lowerScore || subitemScore >= upperScore)
                    {
                        i++;
                        continue;
                    }
                    result = dt.Rows[i]["FresultText"].ToString();
                }
                return result;
            }
            result = "";
            return result;
        }
        public static string GetSubItemResultExplain(int paperId, float[] subitemScores, int[] excludeIdxs, int count)
        {
            SubitemScoreEntry[] sses = new SubitemScoreEntry[subitemScores.Length];
            for (int i = 0; i < subitemScores.Length; i++)
            {
                sses[i] = new SubitemScoreEntry(i + 1, subitemScores[i]);
            }
            Array.Sort(sses);
            int[] subitemIdxs = new int[count];
            int j = sses.Length - 1;
            int idx = 0;
            while (j >= 0 && idx < count)
            {
                bool exclude = false;
                if (excludeIdxs != null)
                {
                    for (int k = 0; k < excludeIdxs.Length; k++)
                    {
                        if (sses[j].index == excludeIdxs[k])
                        {
                            exclude = true;
                            break;
                        }
                    }
                }
                if (!exclude)
                {
                    subitemIdxs[idx++] = sses[j].index;
                }
                j--;
            }
            string maxSubitemIds = "";
            for (int l = 0; l < subitemIdxs.Length; l++)
            {
                maxSubitemIds += subitemIdxs[l];
                if (l != subitemIdxs.Length - 1)
                {
                    maxSubitemIds += "|";
                }
            }
            DataTable dt = SubItem.GetSubItemResultExplain(paperId, "多点编码");
            string result;
            for (int m = 0; m < dt.Rows.Count; m++)
            {
                if (maxSubitemIds == dt.Rows[m]["FscoreSpan"].ToString())
                {
                    result = dt.Rows[m]["FresultText"].ToString();
                    return result;
                }
            }
            result = "";
            return result;
        }
    }
}

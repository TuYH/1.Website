using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HXD.Measure
{
    public class ExamPaper
    {
        private string paperTitle;
        private ExamItem[] examItems;
        public string PaperTitle
        {
            get
            {
                return this.paperTitle;
            }
        }
        public static bool IsPCPaper(int paperId)
        {
            string sql = "select Fpapertype from t_exam_paper where Fpaperid = " + paperId.ToString();
            DataBase db = new DataBase();
            object res = db.ExecuteSqlScalar(sql, null);
            return res != null && (int)res == 1;
        }
        public static void EnablePaper(int paperId, bool enable)
        {
            int flag = enable ? 1 : 0;
            string sql = "update t_exam_paper set Fenabled = {0} where Fpaperid = {1}";
            sql = string.Format(sql, flag, paperId);
            DataBase db = new DataBase();
            db.ExecuteSql(sql, null);
        }
        public static void SetHasSubItem(int paperId, bool val)
        {
            int flag = val ? 1 : 0;
            string sql = "update t_exam_paper set Fhassubitems = {0} where Fpaperid = {1}";
            sql = string.Format(sql, flag, paperId);
            DataBase db = new DataBase();
            db.ExecuteSql(sql, null);
        }
        public static bool HasSubItem(int paperId)
        {
            string sql = "select Fhassubitems from t_exam_paper where Fpaperid = {1}";
            sql = string.Format(sql, paperId);
            DataBase db = new DataBase();
            return (bool)db.ExecuteSqlScalar(sql, null);
        }
        public static void AddPaperQuestions(int paperid, string question, string questionType, int optionId)
        {
            string sql = "insert into t_exam_questions (Fexampaperid, Fquestion, Fquestiontype, Foptionid) values ({0}, '{1}', '{2}', {3})";
            sql = string.Format(sql, new object[]
			{
				paperid,
				question,
				questionType,
				optionId
			});
            DataBase db = new DataBase();
            db.ExecuteSql(sql, null);
        }
        public static void DeletePaperQuestions(int paperid)
        {
            string sql = "delete from t_exam_questions where Fexampaperid = {0}";
            sql = string.Format(sql, paperid);
            DataBase db = new DataBase();
            db.ExecuteSql(sql, null);
        }
        public static void AddPaperOptions(int optionId, int optionIndex, string optionValue)
        {
            string sql = "insert into t_exam_options (Foptionid, Foptionitemindex, Foptionitemvalue) values ({0}, {1}, '{2}')";
            sql = string.Format(sql, optionId, optionIndex, optionValue);
            DataBase db = new DataBase();
            db.ExecuteSql(sql, null);
        }
        public static void AddPaperScoreRefs(int paperId, int questionId, string scoreRef)
        {
            string sql = "insert into t_exam_score_ref (Fexampaperid, Fquestionid, Fscoreref) values ({0}, {1}, '{2}')";
            sql = string.Format(sql, paperId, questionId, scoreRef);
            DataBase db = new DataBase();
            db.ExecuteSql(sql, null);
        }
        public static void DeletePaperScoreRefs(int paperid)
        {
            string sql = "delete from t_exam_score_ref where Fexampaperid = {0}";
            sql = string.Format(sql, paperid);
            DataBase db = new DataBase();
            db.ExecuteSql(sql, null);
        }
        public static int GetMaxOptionId()
        {
            string sql = "select max(Foptionid) from t_exam_options";
            DataBase db = new DataBase();
            object res = db.ExecuteSqlScalar(sql, null);
            int result;
            if (res == null)
            {
                result = 0;
            }
            else
            {
                result = (int)res;
            }
            return result;
        }
        public static int GetPaperId(string paperName)
        {
            string sql = "select Fpaperid from t_exam_paper where Fpapername = '{0}'";
            sql = string.Format(sql, paperName);
            DataBase db = new DataBase();
            object res = db.ExecuteSqlScalar(sql, null);
            int result;
            if (res == null)
            {
                result = 0;
            }
            else
            {
                result = (int)res;
            }
            return result;
        }
        public static string GetPaperName(int paperID)
        {
            string sql = "select Fpapername from t_exam_paper where Fpaperid = {0}";
            sql = string.Format(sql, paperID);
            DataBase db = new DataBase();
            DataSet ds;
            db.ExecuteSql(sql, null, out ds);
            if (ds.get_Tables().get_Item(0).get_Rows().get_Count() <= 0)
            {
                throw new ApplicationException("没有这个试卷");
            }
            return ds.get_Tables().get_Item(0).get_Rows().get_Item(0).get_Item("Fpapername").ToString();
        }
        public static void GetPaperInfo(int paperID, out string paperName, out string paperDesc)
        {
            string sql = "select Fpapername, Fdescription from t_exam_paper where Fpaperid = {0}";
            sql = string.Format(sql, paperID);
            DataBase db = new DataBase();
            DataSet ds;
            db.ExecuteSql(sql, null, out ds);
            if (ds.get_Tables().get_Item(0).get_Rows().get_Count() <= 0)
            {
                throw new ApplicationException("没有这个试卷");
            }
            paperName = ds.get_Tables().get_Item(0).get_Rows().get_Item(0).get_Item("Fpapername").ToString();
            paperDesc = ds.get_Tables().get_Item(0).get_Rows().get_Item(0).get_Item("Fdescription").ToString();
        }
        public static DataTable GetPaperList(int paperType)
        {
            string sql = "select * from t_exam_paper where Fpapertype = {0}";
            sql = string.Format(sql, paperType);
            DataBase db = new DataBase();
            DataSet ds;
            db.ExecuteSql(sql, null, out ds);
            return ds.get_Tables().get_Item(0);
        }
        public static DataTable GetPaperList(int paperType, bool enabled)
        {
            string sql;
            if (paperType == 2)
            {
                sql = "select * from t_exam_paper where Fpapertype <> 1 and Fenabled = {0}";
                sql = string.Format(sql, enabled ? 1 : 0);
            }
            else
            {
                sql = "select * from t_exam_paper where Fpapertype = {0} and Fenabled = {1}";
                sql = string.Format(sql, paperType, enabled ? 1 : 0);
            }
            DataBase db = new DataBase();
            DataSet ds;
            db.ExecuteSql(sql, null, out ds);
            return ds.get_Tables().get_Item(0);
        }
        public static ExamPaper CreateExamPaper(int paperID)
        {
            string sql = "select Fquestion, Fquestiontype, Foptionid, Fextendvalue from t_exam_questions where Fexampaperid = {0}";
            sql = string.Format(sql, paperID);
            DataBase db = new DataBase();
            DataSet dsQuestions;
            db.ExecuteSql(sql, null, out dsQuestions);
            int questionCount = dsQuestions.get_Tables().get_Item(0).get_Rows().get_Count();
            if (questionCount <= 0)
            {
                throw new ApplicationException("该试卷还没有题目");
            }
            ExamPaper paper = new ExamPaper(questionCount);
            paper.paperTitle = ExamPaper.GetPaperName(paperID);
            for (int i = 0; i < questionCount; i++)
            {
                ExamItem examItem = paper.examItems[i];
                DataRow drQuestion = dsQuestions.get_Tables().get_Item(0).get_Rows().get_Item(i);
                examItem.question = drQuestion.get_Item("Fquestion").ToString();
                examItem.type = drQuestion.get_Item("Fquestiontype").ToString();
                examItem.extendValue = drQuestion.get_Item("Fextendvalue").ToString();
                if (examItem.type == "RADIO" || examItem.type == "CHECK")
                {
                    int optionid = int.Parse(drQuestion.get_Item("Foptionid").ToString());
                    sql = "select Foptionitemvalue from t_exam_options where Foptionid = {0} order by Foptionitemindex";
                    sql = string.Format(sql, optionid);
                    DataSet dsOptions;
                    db.ExecuteSql(sql, null, out dsOptions);
                    int optionCount = dsOptions.get_Tables().get_Item(0).get_Rows().get_Count();
                    if (optionCount <= 0)
                    {
                        throw new ApplicationException("找不到问题的选项");
                    }
                    examItem.options = new string[optionCount];
                    for (int j = 0; j < optionCount; j++)
                    {
                        DataRow drOption = dsOptions.get_Tables().get_Item(0).get_Rows().get_Item(j);
                        examItem.options[j] = drOption.get_Item("Foptionitemvalue").ToString();
                    }
                }
            }
            return paper;
        }
        public static int GetTestNum(int paperID)
        {
            string sql = "select Ftestnum from t_exam_paper where Fpaperid = " + paperID.ToString();
            DataBase db = new DataBase();
            return (int)db.ExecuteSqlScalar(sql, null);
        }
        public static void UpdateTestNum(int paperID, int testNum)
        {
            string sql = "update t_exam_paper set Ftestnum = {0} where Fpaperid = {1}";
            sql = string.Format(sql, testNum, paperID);
            DataBase db = new DataBase();
            db.ExecuteSql(sql, null);
        }
        public ExamPaper(int examItemCount)
        {
            this.examItems = new ExamItem[examItemCount];
            for (int i = 0; i < examItemCount; i++)
            {
                this.examItems[i] = new ExamItem();
            }
        }
        public string ToJSON()
        {
            string examItemsString = "";
            for (int i = 0; i < this.examItems.Length; i++)
            {
                ExamItem examItem = this.examItems[i];
                string optionsString = "";
                if (examItem.options != null)
                {
                    for (int j = 0; j < examItem.options.Length; j++)
                    {
                        string optionString = "'" + examItem.options[j] + "'";
                        if (j == 0)
                        {
                            optionsString = optionString;
                        }
                        else
                        {
                            optionsString = optionsString + "," + optionString;
                        }
                    }
                }
                optionsString = "[" + optionsString + "]";
                string examItemString = string.Format("question:'{0}',type:'{1}',options:{2},extendValue:'{3}'", new object[]
				{
					examItem.question,
					examItem.type,
					optionsString,
					examItem.extendValue
				});
                examItemString = "{" + examItemString + "}";
                if (i == 0)
                {
                    examItemsString = examItemString;
                }
                else
                {
                    examItemsString = examItemsString + "," + examItemString;
                }
            }
            examItemsString = "[" + examItemsString + "]";
            string examPaper = string.Format("paperTitle:'{0}',examItems:{1}", this.paperTitle, examItemsString);
            return "[{" + examPaper + "}]";
        }
    }
}

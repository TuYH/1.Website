using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace HXD.Measure
{
    public class SubItem
    {
        public static void AddPaperSubItem(int paperid, string subItem, string questions)
        {
            string sql = "insert into t_exam_subitems (Fpaperid, Fsubitemname, Fquestions)\r\n\t\t\t\t\t\t\tvalues ({0}, '{1}', '{2}')";
            sql = string.Format(sql, paperid, subItem, questions);
            DataBase db = new DataBase();
            db.ExecuteSql(sql, null);
        }
        public static void AddSubItemResultRef(int paperid, string subitemName, string scoreSpan, string resultText)
        {
            string sql = "insert into t_exam_subitems_result_ref (Fexampaperid, Fsubitemname, FscoreSpan, FresultText)\r\n\t\t\t\t\t\t\tvalues ({0}, '{1}', '{2}', '{3}')";
            sql = string.Format(sql, new object[]
			{
				paperid,
				subitemName,
				scoreSpan,
				resultText
			});
            DataBase db = new DataBase();
            db.ExecuteSql(sql, null);
        }
        public static void DeletePaperSubItems(int paperid)
        {
            string sql = "delete from t_exam_subitems where Fpaperid = {0}";
            sql = string.Format(sql, paperid);
            DataBase db = new DataBase();
            db.ExecuteSql(sql, null);
        }
        public static void DeleteSubItemResultRef(int paperid)
        {
            string sql = "delete from t_exam_subitems_result_ref where Fexampaperid = {0}";
            sql = string.Format(sql, paperid);
            DataBase db = new DataBase();
            db.ExecuteSql(sql, null);
        }
        public static DataSet GetPaperSubItems(int paperid)
        {
            string sql = "select * from t_exam_subitems where Fpaperid = {0} order by Fsortfield, Fsubitemname";
            sql = string.Format(sql, paperid);
            DataBase db = new DataBase();
            DataSet ds;
            db.ExecuteSql(sql, null, out ds);
            return ds;
        }
        public static DataSet GetPaperSubItems(int paperid, int level)
        {
            string sql = "select * from t_exam_subitems where Fpaperid = {0} and Flevel = {1} order by Fsortfield, Fsubitemname";
            sql = string.Format(sql, paperid, level);
            //DataBase db = new DataBase();
            DataSet ds;
            //db.ExecuteSql(sql, null, out ds);
            ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
            return ds;

            
        }
        public static DataTable GetSubItemResultExplain(int paperId, string subitemName)
        {
            string sql = "select FscoreSpan, FresultText from t_exam_subitems_result_ref where Fexampaperid = {0} and Fsubitemname = '{1}'";
            sql = string.Format(sql, paperId, subitemName);
            DataBase db = new DataBase();
            DataSet ds;
            db.ExecuteSql(sql, null, out ds);
            return ds.Tables[0];
            //return ds.get_Tables().get_Item(0);

            

        }
        public static Hashtable GetPaperSubItemIndexMap(int paperid, int level)
        {
            Hashtable result = new Hashtable();
            //DataTable dt = SubItem.GetPaperSubItems(paperid, level).get_Tables().get_Item(0);
            DataTable dt = SubItem.GetPaperSubItems(paperid, level).Tables[0];
            Hashtable result2;
            if (dt.Rows.Count <= 0)
            {
                result2 = result;
            }
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //result.Item(dtRows.Item[i]["Fsubitemname"], i);
                    result.Add(dt.Rows[i]["Fsubitemname"], i);
                }
                result2 = result;
            }
            return result2;
        }
        public static Hashtable GetPaperSubItemIdMap(int paperid, int level)
        {
            Hashtable result = new Hashtable();
            DataTable dt = SubItem.GetPaperSubItems(paperid, level).Tables[0];
            Hashtable result2;
            if (dt.Rows.Count <= 0)
            {
                result2 = result;
            }
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //result.set_Item(dt.get_Rows().get_Item(i).get_Item("Fsubitemname"), dt.get_Rows().get_Item(i).get_Item("Fsubitemid"));
                    result.Add(dt.Rows[i]["Fsubitemname"], dt.Rows[i]["Fsubitemid"]);
                }
                result2 = result;
            }
            return result2;
        }
        public static string GetPaperSubItemName(int paperId, int subitemId)
        {
            string sql = "select Fsubitemname from t_exam_subitems where Fpaperid = '" + paperId + "' and Fsubitemid = '" + subitemId + "'";
            

            //sql = string.Format(sql, paperId, subitemId);
            //DataBase db = new DataBase();
            //return db.ExecuteSqlScalar(sql, null).ToString();
            return HXD.DBUtility.SQLHelper.ExecuteScalar(sql).ToString();
        }
    }
}

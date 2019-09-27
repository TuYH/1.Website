using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace HXD.SQLServerDAL
{
    public class NewsTypeNav
    {
        /// <summary>
        /// 返回指定父类下分类信息(导航)
        /// </summary>
        /// <param name="ParentID">父类ID</param>
        /// <returns></returns>
        public string[] ReturnClass(int ParentID)
        {
            string str = "";
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@pid", ParentID);
            DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset("newstypenav", objParams);
            if (ds.Tables[0].Rows.Count > 0)
            { str = ds.Tables[0].Rows[0][0].ToString(); }
            ds.Tables[0].Clear();
            ds.Tables[0].Dispose();
            return HXD.Common.StringDeal.SplitString(str, "|");
        }

        /// <summary>
        /// 分类导航
        /// </summary>
        /// <param name="ParentID"></param>
        /// <returns></returns>
        public string ReturnNavigation(int ParentID,string url)
        {
            StringBuilder str1 = new StringBuilder();
            string urlstr="";
            if (url != string.Empty)
            { urlstr = url; }
            str1.Append("<A href='" + urlstr + "?ParentID=0'> 一级分类 </A> >>");
            if (ParentID != 0)
            {
                string[] s = ReturnClass(ParentID);
                string[] classname = HXD.Common.StringDeal.SplitString(s[0], ",");
                string[] classid = HXD.Common.StringDeal.SplitString(s[1], ",");
                if (s.Length > 0)
                {
                    if (classname.Length > 0)
                    {
                        for (int i = classname.Length - 1; i >= 0; i--)
                        {
                            str1.Append("<A href='" + urlstr + "?ParentID=" + classid[i] + "'>" + classname[i] + "</A> >>");
                        }
                    }
                }
            }
            return str1.ToString().Remove(str1.ToString().LastIndexOf(" >>"), 3);
        }
    }
}

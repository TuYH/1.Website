using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HXD.IDAL;
using HXD.Model;
using HXD.DALFactory;

namespace HXD.BLL
{
    public class bMenu
    {
        private static readonly iMenu dal = DataAccess.CreateMenu();

        public void MenuInsert(int ParentId,string Field, string Value)
        {
            dal.MenuInsert(ParentId,Field, Value);
        }
        public void MenuInsert2(int ParentId, int MenuId, int MenuId2, string Field, string Value)
        {
            dal.MenuInsert2(ParentId, MenuId, MenuId2, Field, Value);
        }

        /// <summary>
        /// 添加栏目(返回 @@Identity)
        /// </summary>
        /// <param name="ParentId"></param>
        /// <param name="Field"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        public int MenuInsert1(int ParentId, string Field, string Value)
        {
            return dal.MenuInsert1(ParentId, Field, Value);
        }

        public void MenuUpdate(int Id, int ParentId, string Field, string Value)
        {
            dal.MenuUpdate(Id, ParentId, Field, Value);
        }
        public void MenuUpdate1(int Id, int ParentId, int MenuId, int MenuId2,string Field, string Value)
        {
            dal.MenuUpdate1(Id, ParentId, MenuId, MenuId2, Field, Value);
        }

        public int MenuDel(mMenu Info)
        {
            return dal.MenuDel(Info);
        }

        public DataSet MenuList()
        {
            return dal.MenuList();
        }

        public DataSet MenuList(int ParentId)
        {
            return dal.MenuList(ParentId);
        }

        public DataSet MenuReader(mMenu Info)
        {
            return dal.MenuReader(Info);
        }

        public DataSet MenuReader(int Id)
        {
            return dal.MenuReader(Id);
        }

        public void MenuLock(mMenu Info)
        {
            dal.MenuLock(Info);
        }

        public void MenuTop(mMenu Info)
        {
            dal.MenuTop(Info);
        }

        public void MenuMove(mMenu Info, string Action)
        {
            dal.MenuMove(Info,Action);
        }

        public void MenuSet(mMenu Info)
        {
            dal.MenuSet(Info);
        }



        public string GetMenuField(mMenu Info, int MenuId)
        {
            return dal.GetMenuField(Info,MenuId);
        }

        public string GetMenuIsSub(int Id)
        {
            return dal.GetMenuIsSub(Id);
        }

        public string GetMenuTableName(int MenuId)
        {
            return dal.GetMenuTableName(MenuId);
        }

        public string GetMenuTitle(int MenuId)
        {
            return dal.GetMenuTitle(MenuId);
        }

        public DataSet classlist = new DataSet();
        public DataTable dt;
        public int dp=0;
        public bool First = true;
        /// <summary>
        /// 获取指定分类深度的栏目列表
        /// </summary>
        /// <param name="depth"></param>
        /// <param name="ParentId"></param>
        /// <returns></returns>
        public DataSet ClassList(int depth, int ParentId)
        {
            dp++;
            DataSet ds = new DataSet();
            ds = MenuList(ParentId);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (First)
                {
                    dt = classlist.Tables.Add("newtable");
                    for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                    {
                        classlist.Tables["newtable"].Columns.Add(ds.Tables[0].Columns[j].ColumnName);//有重载的方法，可以加入列数据的类型
                    }
                    First = false;
                }

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow row = classlist.Tables["newtable"].NewRow();
                    row.ItemArray = ds.Tables[0].Rows[i].ItemArray;
                    classlist.Tables["newtable"].Rows.Add(row);
                    if (dp <= depth)
                    {
                        ClassList(depth, Convert.ToInt32(ds.Tables[0].Rows[i]["Id"].ToString()));
                    }
                    else
                    {
                        dp = 0;
                    }
                }
            }

            return classlist;
        }

        #region 获取分类树的路径 
        public string GetClassTreePath(int StartId,int EndId,string IdList)
        {
            IdList = EndId + "/" + IdList;
            if (StartId != EndId)
            {
                return GetClassTreePath(StartId, GetParentId(EndId), IdList);
            }
            else
            {
                return IdList;
            }
        }

        public int GetParentId(int Id)
        {
            DataSet ds = MenuReader(Id);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return Convert.ToInt32(ds.Tables[0].Rows[0]["ParentId"]);
            }
            else
            {
                return 0;
            }

        }
        #endregion

        #region
        public string MakeClassTreePath(int StartId, int EndId, string ActionName, string LinkUrl, string ReplaceStr, bool IncludeFirst)
        {
            string treePath = "";
            try
            {
                string[] cid = GetClassTreePath(StartId, EndId, "").Trim('/').Split('/');
                for (int i = IncludeFirst ? 0 : 1; i < cid.Length; i++)
                {
                    treePath += ReplaceStr + " <a href=\"" + LinkUrl + "" + ActionName + "=" + cid[i] + "\">" + GetMenuTitle(Convert.ToInt32(cid[i])) + "</a>";
                }
            }
            catch
            {
                treePath = "参数错误";
            }
            return treePath;
        }
        #endregion

    }
}

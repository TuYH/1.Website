using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using XHR.DBUtility;
using XHR.Model;
using XHR.IDAL;

namespace XHR.AccessDAL
{
    public class sUsers : iUsers
    {
        private const string sql_Insert = "INSERT INTO tb_Users (UserName,UserPwd,GroupId,IsLock) VALUES (@UserName,@UserPwd,@GroupId,@IsLock)";
        private const string sql_Update = "UPDATE tb_Users SET UserName = @UserName,UserPwd = @UserPwd,GroupId = @GroupId,IsLock = @IsLock WHERE Id = @Id";
        private string sql_GetUserList = "SELECT Id,UserName,UserPwd,GroupId,IsLock,CreatTime FROM tb_Users @WHERE ORDER BY CreatTime DESC";
        private const string sql_GetUser = "SELECT TOP 1 UserName,UserPwd,GroupId,IsLock,CreatTime FROM tb_Users WHERE Id = @Id";

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="Info"></param>
        public void Insert(mUsers Info)
        {
            OleDbParameter[] par = new OleDbParameter[]
            {
                new OleDbParameter("@UserName",Info.UserName),
                new OleDbParameter("@UserPwd",Info.UserPwd),
                new OleDbParameter("@GroupId",Info.GroupId),
                new OleDbParameter("@IsLock",Info.IsLock)
            };
            OLEHelper.ExecuteNonQuery(sql_Insert, par);
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="Info"></param>
        public void Update(mUsers Info)
        {
            OleDbParameter[] par = new OleDbParameter[]
            {
                new OleDbParameter("@UserName",Info.UserName),
                new OleDbParameter("@UserPwd",Info.UserPwd),
                new OleDbParameter("@GroupId",Info.GroupId),
                new OleDbParameter("@IsLock",Info.IsLock),
                new OleDbParameter("@Id",Info.Id)
            };
            OLEHelper.ExecuteNonQuery(sql_Update, par);
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        public IList<DataSet> GetUserList(mUsers Info)
        {
            OleDbParameter[] par = new OleDbParameter[]
            {
                new OleDbParameter("@UserName",Info.UserName)  
            };
            if (!String.IsNullOrEmpty(Info.UserName))
            {
                sql_GetUserList = sql_GetUserList.Replace("@WHERE", "WHERE UserName LIKE '%@UserName%'");
            }
            else
            {
                sql_GetUserList = sql_GetUserList.Replace("@WHERE", "");
            }
            IList<DataSet> list = new List<DataSet>();
            DataSet ds = OLEHelper.ExecuteDataset(sql_GetUserList, par);
            list.Add(ds);
            return list;
        }

        /// <summary>
        /// 根据ID获取单条用户信息
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        public IList<mUsers> GetUser(mUsers Info)
        {
            OleDbParameter[] par = new OleDbParameter[] 
            { 
                new OleDbParameter("@Id",Info.Id)
            };
            IList<mUsers> list = new List<mUsers>();
            using (OleDbDataReader dr = OLEHelper.ExecuteReader(sql_GetUser, par))
            {
                while (dr.Read())
                {
                    mUsers m = new mUsers();
                    m.UserName = dr[0].ToString();
                    m.UserPwd = dr[1].ToString();
                    m.GroupId = (int)dr[2];
                    m.IsLock = (bool)dr[3];
                    m.CreatTime = (DateTime)dr[4];
                    list.Add(m);
                }
            }
            return list;
        }
    }
}

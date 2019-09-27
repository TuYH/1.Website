using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using HXD.Model;
using HXD.IDAL;
using HXD.DBUtility;
using HXD.Common;

namespace HXD.SQLServerDAL
{
    public class sUser : iUser
    {
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="Info"></param>
        public int UserInsert(mUser Info)
        {
            SqlParameter[] par = new SqlParameter[]{
                new SqlParameter("@GroupId",Info.GroupId),
                new SqlParameter("@UserName",Info.UserName),
                new SqlParameter("@UserPwd",Info.UserPwd)
            };
            return StringDeal.ToInt(SQLHelper.ExecuteScalar("UserInsert", par));
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="Info"></param>
        public void UserUpdate(mUser Info)
        {
            SqlParameter[] par = new SqlParameter[]{
                new SqlParameter("@Id",Info.Id),
                new SqlParameter("@GroupId",Info.GroupId),
                new SqlParameter("@UserPwd",Info.UserPwd)
            };
            SQLHelper.ExecuteNonQuery("UserEdit", par);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="Info"></param>
        public void UserDel(mUser Info)
        {
            SQLHelper.ExecuteNonQuery("UserDel", Info.Temp, Info.GroupId);
        }

        /// <summary>
        /// 根据ID读取单条用户信息
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        public IList<mUser> UserReader(mUser Info)
        {
            IList<mUser> list = new List<mUser>();
            using (SqlDataReader dr = SQLHelper.ExecuteReader("UserRead", Info.Id))
            {
                if (dr.Read())
                {
                    mUser mA = new mUser();
                    mA.GroupId = StringDeal.ToInt(dr[0]);
                    mA.UserName = dr[1].ToString();
                    mA.UserPwd = dr[2].ToString();
                    list.Add(mA);
                }
            }
            return list;
        }

        /// <summary>
        /// 根据ID更改用户锁定状态
        /// </summary>
        /// <param name="Info"></param>
        public void UserLock(mUser Info)
        {
            SQLHelper.ExecuteNonQuery("UserLock", Info.Temp, Info.IsLock);
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        public DataSet UserList(mUser Info)
        {
            SqlParameter[] par = new SqlParameter[]{
                new SqlParameter("@GroupId",Info.GroupId),
                new SqlParameter("@UserName",Info.UserName),
                new SqlParameter("@IsLock",Info.Temp)
            };
            DataSet ds = SQLHelper.ExecuteDataset("UserList", par);
            return ds;
        }


        /// <summary>
        /// 用户登陆
        /// </summary>
        /// <param name="Info"></param>
        /// <returns>登陆帐号状态</returns>
        public IList<mUser> UserLogin(mUser Info)
        {
            SqlParameter[] par = new SqlParameter[] { 
                new SqlParameter("@UserName",Info.UserName),
                new SqlParameter("@UserPwd",Info.UserPwd),
                new SqlParameter("@UserIp",Info.LastLoginIp)
            };
            IList<mUser> list = new List<mUser>();
            mUser m = new mUser();
            m.Temp = SQLHelper.ExecuteScalar("UserLogin", par).ToString();
            list.Add(m);
            return list;
        }

        /// <summary>
        /// 获取用户锁定状态
        /// </summary>
        /// <returns></returns>
        public bool GetUserLock(mUser Info)
        {
            return StringDeal.ToBool(SQLHelper.ExecuteScalar("GetUserLock", Info.Id));
        }

        /// <summary>
        /// 根据组ID获取组用户数量
        /// </summary>
        /// <param name="GroupId"></param>
        /// <returns></returns>
        public int GetUserCount(int GroupId)
        {
            return StringDeal.ToInt(SQLHelper.ExecuteScalar("GetUserCount", GroupId));
        }

        /// <summary>
        /// 根据用户组ID获取组名称
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        public string GetUserGroupTitle(mUser Info)
        {
            return StringDeal.StrFormat(SQLHelper.ExecuteScalar("GetUserGroupTitle", Info.GroupId));
        }

        /// <summary>
        /// 根据组ID，获取用户组模型
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        public string GetTableName(mUser Info)
        {
            int Id = StringDeal.ToInt(SQLHelper.ExecuteScalar("Select TOP 1 Model FROM tb_UserGroup WHERE Id = "+Info.GroupId+""));
            return StringDeal.StrFormat(SQLHelper.ExecuteScalar("GetTableName", Id));
        }


        /// <summary>
        /// 查看用户用户名是否存在
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        public bool IsUserUserName(mUser Info)
        {
            if (StringDeal.ToInt(SQLHelper.ExecuteScalar("IsUserUserName", Info.UserName)) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 判断旧密码是否输入正确
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        public bool IsOldPwd(mUser Info)
        {
            if (StringDeal.ToInt(SQLHelper.ExecuteScalar("IsUserOldPwd", Info.UserName, Info.UserPwd)) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 用户修改密码
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        public bool UserPwdEdit(mUser Info)
        {
            if (StringDeal.ToInt(SQLHelper.ExecuteScalar("UserPwdEdit", Info.UserName, Info.UserPwd)) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

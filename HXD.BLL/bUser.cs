using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HXD.Model;
using HXD.IDAL;
using HXD.DALFactory;

namespace HXD.BLL
{
    public class bUser
    {
        private static readonly iUser dal = DataAccess.CreateUser();
        public int UserInsert(mUser Info)
        {
            return dal.UserInsert(Info);
        }

        public void UserUpdate(mUser Info)
        {
            dal.UserUpdate(Info);
        }

        public void UserDel(mUser Info)
        {
            dal.UserDel(Info);
        }

        public IList<mUser> UserReader(mUser Info)
        {
            return dal.UserReader(Info);
        }

        public void UserLock(mUser Info)
        {
            dal.UserLock(Info);
        }

        public int GetUserCount(int GroupId)
        {
            return dal.GetUserCount(GroupId);
        }

        public string GetUserGroupTitle(mUser Info)
        {
            return dal.GetUserGroupTitle(Info);
        }

        public string GetTableName(mUser Info)
        {
            return dal.GetTableName(Info);
        }

        public DataSet UserList(mUser Info)
        {
            return dal.UserList(Info);
        }

        public IList<mUser> UserLogin(mUser Info)
        {
            return dal.UserLogin(Info);
        }

        public bool GetUserLock(mUser Info)
        {
            return dal.GetUserLock(Info);
        }

        public bool IsUserUserName(mUser Info)
        {
            return dal.IsUserUserName(Info);
        }

        public bool IsOldPwd(mUser Info)
        {
            return dal.IsOldPwd(Info);
        }

        public bool UserPwdEdit(mUser Info)
        {
            return dal.UserPwdEdit(Info);
        }
    }
}

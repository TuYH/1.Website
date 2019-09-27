using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HXD.Model;
using HXD.IDAL;
using HXD.DALFactory;

namespace HXD.BLL
{
    public class bUserGroup
    {
        private static readonly iUserGroup dal = DataAccess.CreateUserGroup();

        public void UserGroupInsert(mUserGroup Info)
        {
            dal.UserGroupInsert(Info);
        }

        public int UserGroupUpdate(mUserGroup Info)
        {
            return dal.UserGroupUpdate(Info);
        }

        public void UserGroupDel(mUserGroup Info)
        {
            dal.UserGroupDel(Info);
        }

        public IList<mUserGroup> UserGroupReader(mUserGroup Info)
        {
            return dal.UserGroupReader(Info);
        }

        public DataSet UserGroupList(mUserGroup Info)
        {
            return dal.UserGroupList(Info);
        }

        public void UserGroupLock(mUserGroup Info)
        {
            dal.UserGroupLock(Info);
        }

        public string GetUserGroupIsSub(int Id)
        {
            return dal.GetUserGroupIsSub(Id);
        }

        public string GetModelTitle(object ModelId)
        {
            return dal.GetModelTitle(ModelId);
        }
    }
}

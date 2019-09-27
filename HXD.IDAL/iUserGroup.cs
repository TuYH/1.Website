using System;
using System.Collections.Generic;
using System.Text;
using HXD.Model;
using System.Data;

namespace HXD.IDAL
{
    public interface iUserGroup
    {
        #region
        /// <summary>
        /// 添加用户组
        /// </summary>
        /// <param name="Info"></param>
        void UserGroupInsert(mUserGroup Info);

        /// <summary>
        /// 修改用户组
        /// </summary>
        /// <param name="Info"></param>
        int UserGroupUpdate(mUserGroup Info);

        /// <summary>
        /// 根据Id删除用户组
        /// </summary>
        /// <param name="Id"></param>
        void UserGroupDel(mUserGroup Info);

        /// <summary>
        /// 根据Id读取用户组单条信息
        /// </summary>
        /// <param name="Id"></param>
        IList<mUserGroup> UserGroupReader(mUserGroup Info);

        /// <summary>
        /// 根据父级ID获取DataSet
        /// </summary>
        /// <param name="ParentId"></param>
        DataSet UserGroupList(mUserGroup Info);

        /// <summary>
        /// 根据ID锁定/激活用户组
        /// </summary>
        /// <param name="Info"></param>
        void UserGroupLock(mUserGroup Info);

        /// <summary>
        /// 获取列表前的ICO
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        string GetUserGroupIsSub(int Id);

        /// <summary>
        /// 根据模型ID，获取模型标题
        /// </summary>
        /// <param name="ModelId"></param>
        /// <returns></returns>
        string GetModelTitle(object ModelId);
        #endregion
    }
}

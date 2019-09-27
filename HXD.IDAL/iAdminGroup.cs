using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HXD.Model;

namespace HXD.IDAL
{
    public interface iAdminGroup
    {
        #region
        /// <summary>
        /// 添加管理员组
        /// </summary>
        /// <param name="Info"></param>
        void AdminGroupInsert(mAdminGroup Info);

        /// <summary>
        /// 修改管理员组
        /// </summary>
        /// <param name="Info"></param>
        int AdminGroupUpdate(mAdminGroup Info);

        /// <summary>
        /// 根据Id删除管理员组
        /// </summary>
        /// <param name="Id"></param>
        void AdminGroupDel(mAdminGroup Info);

        /// <summary>
        /// 根据Id读取管理员组单条信息
        /// </summary>
        /// <param name="Id"></param>
        IList<mAdminGroup> AdminGroupReader(mAdminGroup Info);

        /// <summary>
        /// 根据父级ID获取DataSet
        /// </summary>
        /// <param name="ParentId"></param>
        DataSet AdminGroupList(mAdminGroup Info);

        /// <summary>
        /// 根据ID锁定/激活管理员组
        /// </summary>
        /// <param name="Info"></param>
        void AdminGroupLock(mAdminGroup Info);

        /// <summary>
        /// 获取列表前的ICO
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        string GetAdminGroupIsSub(int Id);
        #endregion
    }
}

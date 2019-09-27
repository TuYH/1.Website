using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HXD.Model;

namespace HXD.IDAL
{
    public interface iUser
    {
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="Info"></param>
        int UserInsert(mUser Info);

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="Info"></param>
        void UserUpdate(mUser Info);

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="Info"></param>
        void UserDel(mUser Info);

        /// <summary>
        /// 根据ID读取单条用户信息
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        IList<mUser> UserReader(mUser Info);

        /// <summary>
        /// 根据ID更改用户锁定状态
        /// </summary>
        /// <param name="Info"></param>
        void UserLock(mUser Info);

        /// <summary>
        /// 根据组ID获取组用户数量
        /// </summary>
        /// <param name="GroupId"></param>
        /// <returns></returns>
        int GetUserCount(int GroupId);

        /// <summary>
        /// 根据用户组ID获取组名称
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        string GetUserGroupTitle(mUser Info);

        /// <summary>
        /// 根据组ID，获取用户组模型
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        string GetTableName(mUser Info);

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        DataSet UserList(mUser Info);


        /// <summary>
        /// 用户登陆
        /// </summary>
        /// <param name="Info"></param>
        /// <returns>登陆帐号状态</returns>
        IList<mUser> UserLogin(mUser Info);

        /// <summary>
        /// 获取用户锁定状态
        /// </summary>
        /// <returns></returns>
        bool GetUserLock(mUser Info);


        /// <summary>
        /// 查看用户用户名是否存在
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        bool IsUserUserName(mUser Info);

        /// <summary>
        /// 判断旧密码是否输入正确
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        bool IsOldPwd(mUser Info);

        /// <summary>
        /// 用户修改密码
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        bool UserPwdEdit(mUser Info);
    }
}

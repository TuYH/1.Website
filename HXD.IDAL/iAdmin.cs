using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HXD.Model;

namespace HXD.IDAL
{
    public interface iAdmin
    {
        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="Info"></param>
        void AdminInsert(mAdmin Info);

        /// <summary>
        /// 修改管理员信息
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        void AdminUpdate(mAdmin Info);

        /// <summary>
        /// 删除管理员
        /// </summary>
        /// <param name="Info"></param>
        void AdminDel(mAdmin Info);

        /// <summary>
        /// 根据ID读取单条管理员信息
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        IList<mAdmin> AdminReader(mAdmin Info);

        /// <summary>
        /// 根据ID更改管理员锁定状态
        /// </summary>
        /// <param name="Info"></param>
        void AdminLock(mAdmin Info);

        /// <summary>
        /// 获取管理员列表
        /// </summary>
        /// <returns></returns>
        DataSet AdminList();

        /// <summary>
        /// 管理员后台登陆
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        IList<mAdmin> AdminLogin(mAdmin Info);

        /// <summary>
        /// 获取管理员锁定状态
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        bool GetAdminLock(mAdmin Info);

        /// <summary>
        /// 获取管理员是否允许修改密码
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        bool GetAdminEditPwd(mAdmin Info);

        /// <summary>
        /// 获取管理员是否允许多人同时登陆
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        bool GetAdminMultiLogin(mAdmin Info);

        /// <summary>
        /// 查看管理员用户名是否存在
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        bool IsAdminUserName(mAdmin Info);

        /// <summary>
        /// 判断旧密码是否输入正确
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        bool IsOldPwd(mAdmin Info);

        /// <summary>
        /// 管理员修改密码
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        bool AdminPwdEdit(mAdmin Info);
    }
}

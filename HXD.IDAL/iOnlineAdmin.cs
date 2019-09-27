using System;
using System.Collections.Generic;
using System.Text;
using HXD.Model;

namespace HXD.IDAL
{
    public interface iOnlineAdmin
    {
        /// <summary>
        /// 插入一条管理员登陆记录
        /// </summary>
        /// <param name="Info"></param>
        void OnlineAdminInsert(mOnlineAdmin Info);

        /// <summary>
        /// 更新已登陆用户的在线时间
        /// </summary>
        /// <param name="Info"></param>
        void OnlineAdminUpdate(mOnlineAdmin Info);

        /// <summary>
        /// 获取当前时间与最后活动时间差
        /// </summary>
        /// <returns></returns>
        int GetUpdateTimeSpan(mOnlineAdmin Info);
    }
}

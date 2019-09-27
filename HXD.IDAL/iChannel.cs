using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HXD.Model;

namespace HXD.IDAL
{
    public interface iChannel
    {
        #region
        /// <summary>
        /// 添加后台频道
        /// </summary>
        /// <param name="Info"></param>
        void ChannelInsert(mChannel Info);

        /// <summary>
        /// 修改后台频道
        /// </summary>
        /// <param name="Info"></param>
        int ChannelUpdate(mChannel Info);

        /// <summary>
        /// 删除后台频道
        /// </summary>
        /// <param name="Info"></param>
        string ChannelDel(int Id);

        /// <summary>
        /// 读取单条频道信息
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        IList<mChannel> ChannelRead(mChannel Info);

        /// <summary>
        /// 获取频道列表DATASET
        /// </summary>
        /// <param name="ParentId"></param>
        /// <returns></returns>
        DataSet ChannelList(int ParentId);

        /// <summary>
        /// 频道关闭/开放
        /// </summary>
        /// <param name="Info"></param>
        void ChannelLock(int Id);

        /// <summary>
        /// 频道排序
        /// </summary>
        /// <param name="Info"></param>
        void ChannelMove(int Id,string Action);
        #endregion

        #region 
        /// <summary>
        /// 根据ID获取栏目标题
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        string GetChannelTitle(int Id);

        /// <summary>
        /// 后台左侧顶级菜单
        /// </summary>
        /// <returns></returns>
        IList<DataSet> GetChannelMenu(int ParentId, string UserName);

        /// <summary>
        /// 获取后台左侧频道子级数
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        int GetChannelSubCount(int Id);

        /// <summary>
        /// 获取后台左侧频道第一个栏目ID
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        int GetChannelFirstParentId(string UserName);

        /// <summary>
        /// 获取列表前的ICO
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        string GetChannelIsSub(int Id);

        #endregion
    }
}

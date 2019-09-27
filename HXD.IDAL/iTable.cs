using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HXD.Model;

namespace HXD.IDAL
{
    public interface iTable
    {
        /// <summary>
        /// 添加模型
        /// </summary>
        /// <param name="Info"></param>
        void TableInsert(mTable Info);

        /// <summary>
        /// 修改模型表
        /// </summary>
        /// <param name="Info"></param>
        void TableUpdate(mTable Info);

        /// <summary>
        /// 删除模型表
        /// </summary>
        /// <param name="Info"></param>
        void TableDel(mTable Info);

        /// <summary>
        /// 根据ID获取单条模型信息
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        mTable TableRead(mTable Info);

        /// <summary>
        /// 读取模型列表
        /// </summary>
        /// <returns></returns>
        DataSet TableList();


        /// <summary>
        /// 判断数据库中是否存在某表名
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        bool IsTable(mTable Info);

        /// <summary>
        /// 根据模型表ID获取表名
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        string GetTableName(int Id);

        /// <summary>
        /// 获取模型是否为系统模型
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        bool GetIsSystem(mTable Info);
    }
}

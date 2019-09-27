using System;
using System.Collections.Generic;
using System.Text;
using HXD.Model;
using System.Data;

namespace HXD.IDAL
{
    public interface iField
    {
        /// <summary>
        /// 添加字段
        /// </summary>
        /// <param name="Info"></param>
        bool FieldInsert(mField Info);

        /// <summary>
        /// 修改字段
        /// </summary>
        /// <param name="Info"></param>
        bool FieldUpdate(mField Info);

        /// <summary>
        /// 删除字段
        /// </summary>
        /// <param name="Info"></param>
        void FieldDel(mField Info);

        /// <summary>
        /// 根据ID读取单条信息
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        mField FieldRead(mField Info);

        /// <summary>
        /// 根据表名读取字段列表
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        DataSet FieldList(mField Info);

        /// <summary>
        /// 移动字段显示位置
        /// </summary>
        /// <param name="Info"></param>
        /// <param name="Action"></param>
        void FieldMove(mField Info, string Action);


        /// <summary>
        /// 根据字段ID，获取表名和字段名
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        mField GetTableAndField(mField Info);

        /// <summary>
        /// 根据ID获取字段的标题
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        string GetFiledTitle(int Id);

        /// <summary>
        /// 根据字段名和表明获取字段标题
        /// </summary>
        /// <param name="Field"></param>
        /// <param name="Table"></param>
        /// <returns></returns>
        string GetFieldTitle(string Field, string Table);

        /// <summary>
        /// 根据字段名和表明获取字段排序号
        /// </summary>
        /// <param name="Field"></param>
        /// <param name="Table"></param>
        /// <returns></returns>
        string GetFieldSort(string Field, string Table);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using HXD.Model;
using System.Data;

namespace HXD.IDAL
{
    public interface iMenu
    {
        /// <summary>
        /// 添加栏目
        /// </summary>
        /// <param name="Info"></param>
        void MenuInsert(int ParentId,string Field, string Value);
       
        /// <summary>
        /// 添加栏目
        /// </summary>
        /// <param name="Info"></param>
        void MenuInsert2(int ParentId, int MenuId, int MenuId2, string Field, string Value);
        /// <summary>
        /// 添加栏目(返回 @@Identity)
        /// </summary>
        /// <param name="Info"></param>
        int MenuInsert1(int ParentId, string Field, string Value);

        /// <summary>
        /// 修改栏目
        /// </summary>
        /// <param name="Info"></param>
        void MenuUpdate(int Id, int ParentId,string Field, string Value);
        /// <summary>
        /// 修改栏目
        /// </summary>
        /// <param name="Info"></param>
        void MenuUpdate1(int Id, int ParentId, int MenuId,int MenuId2, string Field, string Value);

        /// <summary>
        /// 删除栏目
        /// </summary>
        /// <param name="Info"></param>
        int MenuDel(mMenu Info);

        /// <summary>
        /// 栏目列表DATASET
        /// </summary>
        /// <returns></returns>
        DataSet MenuList();

        /// <summary>
        /// 栏目列表DATASET
        /// </summary>
        /// <returns></returns>
        DataSet MenuList(int ParentId);

        /// <summary>
        /// 读取栏目基本信息
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        DataSet MenuReader(mMenu Info);

        /// <summary>
        /// 读取栏目基本信息
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        DataSet MenuReader(int Id);

        /// <summary>
        /// 栏目锁定/解锁
        /// </summary>
        /// <param name="Info"></param>
        void MenuLock(mMenu Info);

        /// <summary>
        /// 栏目置顶
        /// </summary>
        /// <param name="Info"></param>
        void MenuTop(mMenu Info);

        /// <summary>
        /// 栏目排序
        /// </summary>
        /// <param name="Info"></param>
        void MenuMove(mMenu Info, string Action);

        /// <summary>
        /// 设置栏目模型以及信息模型的字段
        /// </summary>
        /// <param name="Info"></param>
        void MenuSet(mMenu Info);



        /// <summary>
        /// 获取栏目模型字段信息
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        string GetMenuField(mMenu Info, int MenuId);

        /// <summary>
        /// 获取列表前的ICO
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        string GetMenuIsSub(int Id);

        /// <summary>
        /// 根据栏目ID获取模型表名称
        /// </summary>
        /// <param name="MenuId"></param>
        /// <returns></returns>
        string GetMenuTableName(int MenuId);

        /// <summary>
        /// 根据ID获取栏目标题
        /// </summary>
        /// <param name="MenuId"></param>
        /// <returns></returns>
        string GetMenuTitle(int MenuId);

    }
}

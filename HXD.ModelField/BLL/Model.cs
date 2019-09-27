using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HXD.ModelField.Common;

namespace HXD.ModelField.BLL
{
    public class Model
    {
        private readonly HXD.ModelField.SQLServerDAL.Model dal = new HXD.ModelField.SQLServerDAL.Model();

        /// <summary>
        /// 为模型中添加数据
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="Field"></param>
        /// <param name="Value"></param>
        public void ModelInsert(string TableName, string Field, string Value)
        {
            dal.ModelInsert(TableName, Field, Value);
        }
        /// <summary>
        /// 修改模型中已存在的数据
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="TableName"></param>
        /// <param name="Field"></param>
        /// <param name="Value"></param>
        public void ModelUpdate(int Id, string TableName, string Field, string Value)
        {
            dal.ModelUpdate(Id, TableName, Field, Value);
        }
        /// <summary>
        /// 根据表名和要获取的字段组合，获取此表的信息列表
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        public DataSet ModelList(HXD.ModelField.Model.Model Info)
        {
            return dal.ModelList(Info);
        }

        /// <summary>
        /// 根据表名和要获取的字段组合，获取此表的信息列表
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        public DataSet ModelList2(HXD.ModelField.Model.Model Info)
        {
            return dal.ModelList2(Info);
        }

        /// <summary>
        /// 获取前几条数据
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <param name="FieldList">字段列表</param>
        /// <param name="Condition">搜索条件</param>
        /// <param name="Sort">排序方式</param>
        /// <param name="ExceptNum">去除数量</param>
        /// <param name="GetNum">获取数量</param>
        /// <returns></returns>
        public DataSet ModelList(string TableName, string FieldList, string Condition, string Sort, int ExceptNum, int GetNum)
        {
            return dal.ModelList(TableName, FieldList, Condition, Sort, ExceptNum, GetNum);
        }

        /// <summary>
        /// 获取前几条数据
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <param name="FieldList">字段列表</param>
        /// <param name="Condition">搜索条件</param>
        /// <param name="Sort">排序方式</param>
        /// <param name="ExceptNum">去除数量</param>
        /// <param name="GetNum">获取数量</param>
        /// <returns></returns>
        public DataSet ModelList(string TableName, string Condition, string Sort, int GetNum)
        {
            return dal.ModelList(TableName, " * ", Condition, Sort, 0, GetNum);
        }

        /// <summary>
        /// 读取模型列表
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        public DataSet ModelReader(HXD.ModelField.Model.Model Info)
        {
            return dal.ModelReader(Info);
        }
        /// <summary>
        /// 根据ID删除模型中的数据
        /// </summary>
        /// <param name="Info"></param>
        public void ModelDelete(HXD.ModelField.Model.Model Info)
        {
            dal.ModelDelete(Info);
        }
        /// <summary>
        /// 根据ID设置模型中的数据审核
        /// </summary>
        /// <param name="Info"></param>
        public void ModelStatus(HXD.ModelField.Model.Model Info)
        {
            dal.ModelStatus(Info);
        }
        /// <summary>
        /// 根据ID设置模型中的数据置顶
        /// </summary>
        /// <param name="Info"></param>
        public void ModelTop(HXD.ModelField.Model.Model Info)
        {
            dal.ModelTop(Info);
        }
        /// <summary>
        /// 根据ID设置模型中的数据推荐
        /// </summary>
        /// <param name="Info"></param>
        public void ModelElite(HXD.ModelField.Model.Model Info)
        {
            dal.ModelElite(Info);
        }
        /// <summary>
        /// 根据ID设置模型中的数据热门
        /// </summary>
        /// <param name="Info"></param>
        public void ModelHot(HXD.ModelField.Model.Model Info)
        {
            dal.ModelHot(Info);
        }
        /// <summary>
        /// 排序修改
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="TableName"></param>
        /// <param name="Sort"></param>
        public void ModelSort(int Id, string TableName, int Sort)
        {
            dal.ModelSort(Id, TableName, Sort);
        }
        /// <summary>
        /// 首页产品排序修改
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="TableName"></param>
        /// <param name="Sort"></param>
        public void Modelleibie(int Id, string TableName, int Sort)
        {
            dal.Modelleibie(Id, TableName, Sort);
        }
    }
}

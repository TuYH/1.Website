using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;

namespace HXD.Template
{
    public class HtmlMaker
    {
        string templatepath = "/templates/mainsite/";
        string rootpath = HttpRuntime.AppDomainAppVirtualPath;
        string Physicalrootpath = HttpRuntime.AppDomainAppPath;

        //生成静态页
        /// 生成静态页
        /// </summary>
        /// <param name="MenuId">栏目编号</param>
        /// <param name="Type">生成类型：0全部生成，1只生成列表</param>
        public void CreateHtml(int MenuId,int Type)
        {
            //根据MenuId提取静态化相关信息
            bool IsList = true;   //页面是否为列表页

            if (IsList)
            {
                //生成列表页

                //①调取信息列表
                DataSet ds = null;
                //②调取相关信息
                //②生成页面
                if (HXD.Common.DataManage.DataSetIsNull(ds))
                {
                    //dataset为空，则生成空信息页面，提示：暂无信息！

                }
                else
                {
                    int PageCount = 10;
                    //生成列表页
                    for (int page = 1; page <= PageCount; page++)
                    {
                        string filepath=Physicalrootpath+rootpath+templatepath+"模板路径";
                        string filebody = "读取并替换模板";
                        savefile( filepath,  filebody);
                    }

                    //生成列表包含的所有内容页
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        string filepath = Physicalrootpath + rootpath + templatepath + "模板路径";
                        string filebody = "读取并替换模板";
                        savefile(filepath, filebody);
                    }
                }
            }
            else
            {
                //生成内容页
                string filepath = Physicalrootpath + rootpath + templatepath + "模板路径";
                string filebody = "读取并替换模板";
                savefile(filepath, filebody);
            }
        }

        /// <summary>
        /// 保存html页面
        /// </summary>
        /// <param name="filepath">保存路径</param>
        /// <param name="filebody">页面内容</param>
        void savefile(string filepath, string filebody)
        {
            System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(filepath));
            System.IO.File.WriteAllText(filepath, filebody);

        }

    }

}

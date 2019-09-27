using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace HXD.Common
{
    public class Files
    {
        /// <summary>
        /// 删除给定路径的文件
        /// </summary>
        /// <param name="FilePath"></param>
        public static void DeleteFile(string FilePath)
        {
            string filepath = System.Web.HttpContext.Current.Server.MapPath(FilePath);
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }
        }

        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="FolderPath"></param>
        public static void CreateFolder(string FolderPath)
        {
            string folderpath = System.Web.HttpContext.Current.Server.MapPath(FolderPath);
            if (!Directory.Exists(folderpath))
            {
                Directory.CreateDirectory(folderpath);
            }
        }
    }
}

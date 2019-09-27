using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace HXD.Common
{
    public class Files
    {
        /// <summary>
        /// ɾ������·�����ļ�
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
        /// �����ļ���
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

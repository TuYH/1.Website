using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Shell32;
using System.Text.RegularExpressions;

namespace HXD.Common
{
   
        /// <summary>
        /// 操作MP3音频文件的类
        /// </summary>
        public class Mp3Entity
        {

            /// <summary>
            /// 根据mp3文件的绝对路径和属性名称获得属性值
            /// </summary>
            /// <param name="FilePath"></param>
            /// <param name="AttributeName">如：播放时间、文件大小、比特率</param>
            /// <returns></returns>
            public string GetFileAttribute(string FilePath, string AttributeName)
            {
                string AttributeVal = "";
                List<string> fileInfoArr = GetMp3FileDetailInfo(FilePath);
                switch (AttributeName)
                {
                    case "播放时间":
                        if (fileInfoArr.Count > 22)
                            AttributeVal = fileInfoArr[28];
                        break;
                    case "文件大小":
                        if (fileInfoArr.Count > 2)
                            AttributeVal = fileInfoArr[2];
                        break;
                    case "比特率":
                        if (fileInfoArr.Count > 23)
                            AttributeVal = fileInfoArr[23];
                        break;

                }

                //AttributeVal = AttributeVal.Replace("00", "");
                return AttributeVal;
            }

            /// <summary>
            /// 获得mp3文件的详细信息
            /// </summary>
            /// <param name="strPath"></param>
            /// <returns></returns>
            public List<string> GetMp3FileDetailInfo(string strPath)
            {
                List<string> fileInfoArr = new List<string>();

                ShellClass sh = new ShellClass();
                Folder dir = sh.NameSpace(Path.GetDirectoryName(strPath));
                FolderItem item = dir.ParseName(Path.GetFileName(strPath));
                for (int i = -1; i < 50; i++)
                {
                    // 0检索项的名称。
                    // 1检索项的大小。
                    // 2检索条目的类型。
                    // 3检索项最后修改日期和时间。
                    // 4检索项的属性。
                    // -1项检索信息提示信息。
                    fileInfoArr.Add(dir.GetDetailsOf(item, i));
                }
                return fileInfoArr;
            }
        }
    
}

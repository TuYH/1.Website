using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
namespace HXD.Common
{
    public class FileOperate
    {
        #region    ------  删除文件   -----
        /// <summary>
        /// 删除文件（相对路径）
        /// </summary>
        /// <param name="strFileName">文件名称（相对路径）</param>
        /// <returns></returns>
        public static bool DeleteFile(string strFileName)
        {
            if (strFileName.Trim() == "" || strFileName.Trim() == String.Empty)
            {
                return false;
            }
            else
            {
                string filepath = System.Web.HttpContext.Current.Server.MapPath(strFileName);
                if (File.Exists(filepath))
                {
                    try
                    {
                        File.Delete(filepath);
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        #endregion

        #region   ------  删除信息中本地的图片 -----

        /// <summary>
        /// 删除内容中的图片
        /// </summary>
        /// <param name="htmlStr">Html字符串</param>
        /// <returns></returns>
        public static void GetImgTag(string htmlStr)
        {
            Regex regObj = new Regex("<img.+?>", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            foreach (Match matchItem in regObj.Matches(htmlStr))
            {
                string imgUrl = GetSrc(matchItem.Value);
                if (imgUrl != "")
                {
                    string img = System.Web.HttpContext.Current.Server.MapPath("~/") + imgUrl;
                    if (File.Exists(img))
                    {
                        File.Delete(img);
                    }
                }
            }
        }

        /// <summary>
        /// 返回信息中所以图片的路径
        /// </summary>
        /// <param name="htmlStr">Html字符串</param>
        /// <returns></returns>
        public static List<string> GetImgList(string htmlStr)
        {
            Regex regObj = new Regex("<img.+?>", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            List<string> strs = new List<string>();
            foreach (Match matchItem in regObj.Matches(htmlStr))
            {
                string imgUrl = GetSrc(matchItem.Value);
                if (imgUrl != "")
                {
                    strs.Add(imgUrl);
                }
            }
            return strs;
        }

        /// <summary>
        /// 判断内容中是否有图片
        /// </summary>
        /// <param name="htmlStr"></param>
        /// <returns></returns>
        public static bool IsGetImgTag(string htmlStr)
        {
            Regex regObj = new Regex("<img.+?>", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            if (regObj.Matches(htmlStr).Count > 0)
            { return true; }
            else
            { return false; }
        }

        /// <summary>
        /// 取出新闻中本地图片的URL地址
        /// </summary>
        /// <param name="imgTagStr"></param>
        /// <returns></returns>
        public static string GetImgUrl(string imgTagStr)
        {
            string str = "";
            if (imgTagStr.IndexOf("http") != -1)
            {
                str = "";
            }
            else
            {//获取本地图片的路径
                str = getLocalHostImg(imgTagStr);
            }
            return str;
        }

        /// <summary>
        /// 匹配<img src="" />中的图片路径实际链接
        /// </summary>
        /// <param name="ImgString"><img src="" />字符串</param>
        /// <returns></returns>
        private static string GetSrc(string ImgString)
        {
            string Reg = @"src=.+\.(bmp|jpg|gif|png|)";
            Regex regObj = new Regex(Reg, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            MatchCollection Collection = regObj.Matches(ImgString);
            if (Collection.Count == 1)
            { return Collection[0].Value.Replace("src=", "").Replace("\"", "").Trim(); }
            else
            { return string.Empty; }
        }

        /// <summary>
        /// 匹配内容的文件
        /// </summary>
        /// <param name="String">内容字符串</param>
        /// <param name="Link">匹配内容中的路径属性例如：src、url</param>
        /// <param name="Type">要匹配的类型用竖线分来(bmp|jpg|gif|png|)</param>
        /// <returns></returns>
        public static string[] GetSrc(string String, string Link, string Type)
        {
            string Reg = "" + Link + @"=.+\.(" + Type + ")";
            Regex regObj = new Regex(Reg, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            string[] strs = new string[] { };
            MatchCollection Collection = regObj.Matches(String);
            for (int i = 0; i < Collection.Count; i++)
            {
                strs[i] = Collection[i].Value.Replace(Link + "=", "").Replace("\"", "").Trim();
            }
            return strs;
        }

        /// <summary>
        /// 删除文本中指定格式的文件
        /// </summary>
        /// <param name="String">内容字符串</param>
        /// <param name="Link">匹配内容中的路径属性例如：src、url</param>
        /// <param name="Type">要匹配的类型用竖线分来(bmp|jpg|gif|png|)</param>
        /// <returns></returns>
        public static void DelFiles(string String, string Link, string Type)
        {
            string Reg = "" + Link + @"=.+\.(" + Type + ")";
            Regex regObj = new Regex(Reg, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            string[] strs = new string[] { };
            MatchCollection Collection = regObj.Matches(String);
            for (int i = 0; i < Collection.Count; i++)
            {
                FileOperate.DeleteFile(Collection[i].Value.Replace(Link + "=", "").Replace("\"", "").Trim());
            }
        }

        /// <summary>
        /// 取出本地上传的图片路径
        /// </summary>
        /// <param name="strImg"></param>
        /// <returns></returns>
        public static string getLocalHostImg(string strImg)
        {
            int num = strImg.IndexOf("src=");
            string str = "", tempstr = "", file = "";
            int sub = -1;//后缀名的位置
            int sub1 = -1;//后缀名的位置
            int num2 = 0;
            if (num != -1)
            {
                str = strImg.Substring(num + 4);
                int num1 = str.IndexOf("\"") == 0 ? 1 : str.IndexOf("'") == 0 ? 1 : 0;//开始位置
                sub = str.LastIndexOf(".");//后缀名开始的位置
                tempstr = str.Remove(0, sub);//去除后缀前面的所有字符
                sub1 = tempstr.IndexOf(" ") >= 0 ? tempstr.IndexOf(" ") : -1;//从后缀名到结束的位置
                num2 = sub1 + sub;//后缀名到最后的字符数
                if (num1 != 0)
                { file = str.Substring(num1, num2 - 2); }
                else
                { file = str.Substring(num1, num2); }
            }
            return file.Replace("/", "\\");//返回本地图片路径
        }
        #endregion

        #region   -----   备份文件操作  -----
        /// <summary>
        /// 备份文件
        /// </summary>
        /// <param name="sourceFileName">源文件名</param>
        /// <param name="destFileName">目标文件名</param>
        /// <param name="overwrite">当目标文件存在时是否覆盖</param>
        /// <returns>操作是否成功</returns>
        public static bool BackupFile(string sourceFileName, string destFileName, bool overwrite)
        {
            if (!System.IO.File.Exists(sourceFileName))
            {
                throw new FileNotFoundException(sourceFileName + "文件不存在！");
            }
            if (!overwrite && System.IO.File.Exists(destFileName))
            {
                return false;
            }
            try
            {
                System.IO.File.Copy(sourceFileName, destFileName, true);
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 备份文件,当目标文件存在时覆盖
        /// </summary>
        /// <param name="sourceFileName">源文件名</param>
        /// <param name="destFileName">目标文件名</param>
        /// <returns>操作是否成功</returns>
        public static bool BackupFile(string sourceFileName, string destFileName)
        {
            return BackupFile(sourceFileName, destFileName, true);
        }

        /// <summary>
        /// 恢复文件
        /// </summary>
        /// <param name="backupFileName">备份文件名</param>
        /// <param name="targetFileName">要恢复的文件名</param>
        /// <param name="backupTargetFileName">要恢复文件再次备份的名称,如果为null,则不再备份恢复文件</param>
        /// <returns>操作是否成功</returns>
        public static bool RestoreFile(string backupFileName, string targetFileName, string backupTargetFileName)
        {
            try
            {
                if (!System.IO.File.Exists(backupFileName))
                {
                    throw new FileNotFoundException(backupFileName + "文件不存在！");
                }
                if (backupTargetFileName != null)
                {
                    if (!System.IO.File.Exists(targetFileName))
                    {
                        throw new FileNotFoundException(targetFileName + "文件不存在！无法备份此文件！");
                    }
                    else
                    {
                        System.IO.File.Copy(targetFileName, backupTargetFileName, true);
                    }
                }
                System.IO.File.Delete(targetFileName);
                System.IO.File.Copy(backupFileName, targetFileName);
            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }

        public static bool RestoreFile(string backupFileName, string targetFileName)
        {
            return RestoreFile(backupFileName, targetFileName, null);
        }
        #endregion
    }
}

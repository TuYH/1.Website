using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.Text.RegularExpressions;
namespace HXD.Common
{
    public class Utils
    {
        /// <summary>
        /// 比较两个时间大小返回bool值(true表示未超期false表示已超期)
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public static bool IsTimeMax(string t1)
        {
            TimeSpan s = Convert.ToDateTime(t1) - System.DateTime.Now;
            if (s.Days >= 0)
            { return true; }
            else
            { return false; }
        }

        #region 图片操作
        /// <summary>
        /// 返回缩略图地址
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static string PhotoIco(string image)
        {
            if (image.Trim() != string.Empty)
            {
                string img = image.Insert(image.LastIndexOf("/"), "/ico");
                if (System.IO.File.Exists(System.Web.HttpContext.Current.Server.MapPath("~" + img)))
                { return img; }
                else
                { return string.Empty; }
            }
            else
            { return string.Empty; }
        }
        /// <summary>
        /// 返回缩略图地址
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static string PhotoIco1(string image)
        {
            if (image.Trim() != string.Empty)
            {
                string img = image.Insert(image.LastIndexOf("/"), "/ico1");
                if (System.IO.File.Exists(System.Web.HttpContext.Current.Server.MapPath("~" + img)))
                { return img; }
                else
                { return string.Empty; }
            }
            else
            { return string.Empty; }
        }

        /// <summary>
        /// 判断缩略是否存在
        /// </summary>
        /// <param name="image"></param>
        /// <param name="dirname"></param>
        /// <returns></returns>
        public static string PhotoIco(string image, string dirname)
        {
            if (image.Trim() != string.Empty)
            {
                string img = image.Insert(image.LastIndexOf("/"), "/" + dirname);
                if (System.IO.File.Exists(System.Web.HttpContext.Current.Server.MapPath("~" + img)))
                { return img; }
                else
                { return string.Empty; }
            }
            else
            { return string.Empty; }
        }

        /// <summary>
        /// 删除所有缩略图
        /// </summary>
        /// <param name="SelectImage"></param>
        public static void DelThumbnail(string SelectImage)
        {
            for (int i = 0; i < HXD.Common.Thumbnail.ThumbnailDir.Length; i++)
            {
                if (HXD.Common.Utils.PhotoIco(SelectImage, HXD.Common.Thumbnail.ThumbnailDir[i]) != string.Empty)
                { HXD.Common.FileObj.FileDel(HXD.Common.Utils.PhotoIco(SelectImage, HXD.Common.Thumbnail.ThumbnailDir[i])); }
            }
        }

        /// <summary>
        /// 判断是否有缩略图
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static bool isPhotoIco(string image)
        {
            if (image.Trim() != string.Empty)
            {
                string img = image.Insert(image.LastIndexOf("/"), "/ico");
                if (System.IO.File.Exists(System.Web.HttpContext.Current.Server.MapPath("~" + img)))
                { return true; }
                else
                { return false; }
            }
            else
            { return false; }
        }
        #endregion

        #region 判断字符串是否是正确的 Url 地址格式 public static bool IsUrl(string s)
        /// <summary>
        /// 判断字符串是否是正确的 Url 地址格式
        /// </summary>
        public static bool IsUrl(string s)
        {
            string pattern = @"^(http|https|ftp|rtsp|mms):(\/\/|\\\\)[A-Za-z0-9%\-_@]+\.[A-Za-z0-9%\-_@]+[A-Za-z0-9\.\/=\?%\-&_~`@:\+!;]*$";
            return Regex.IsMatch(s, pattern, RegexOptions.IgnoreCase);
        }
        #endregion

        /// <summary>
        /// 匹配<img src="" />中的图片路径实际链接
        /// </summary>
        /// <param name="ImgString"><img src="" />字符串</param>
        /// <returns></returns>
        public static string GetSrc(string ImgString)
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
        /// 提取值，如source: "xxx=yyy&yyy=zzz", 则GetQueryStringValue(source,"xxx")的返回值为"yyy"
        /// </summary>
        public static string GetQueryStringValue(string source, string name)
        {
            if (string.IsNullOrEmpty(source))
                return string.Empty;
            Regex reg = new Regex(string.Format(@"(^|&){0}=(?<value>(.*?))(&|$)", name), RegexOptions.IgnoreCase);
            MatchCollection mc = reg.Matches(source);
            if (mc.Count > 0)
            {
                return mc[0].Result("${value}");
            }
            return string.Empty;
        }
    }
}

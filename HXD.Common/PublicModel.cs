using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Model
{
    public class PublicModel
    {
        const string _UTF8Encoding = "UTF-8";//读写文件的编码格式
        const string _GB2312Encoding = "GB2312";//读写文件的编码格式
        const string _UpLoadFileType = "jpe|jpeg|jpg|png|tif|tiff|bmp|gif|wbmp|swf|psd";//要上传的文件类型
        const string _UpLoadFileImage = "jpe|jpeg|jpg|png|tif|tiff|bmp|gif|wbmp|psd";//要上传的文件类型
        const string _ADUpLoadFileImages = "~/UpLoadFile/NewFolder/";//Flash广告、广告、友情链接路径
        const string _PwdKey = "19860105";

        const int _filesizei = 2;//上传文件的限制大小
        const float _filesizef = 2;//上传文件的限制大小
        const string _filesizes = "2";//上传文件的限制大小
        /// <summary>
        /// 密码解密的密钥
        /// </summary>
        public static string PwdKey
        {
            get { return _PwdKey; }
        }

        /// <summary>
        /// 读写文件的编码格式UTF-8(无标签)
        /// </summary>
        public static Encoding EncodingUTF8W
        {
            get { return new UTF8Encoding(false); }
        }

        /// <summary>
        /// 读写文件的编码格式UTF-8(有标签)
        /// </summary>
        public static Encoding EncodingUTF8
        {
            get { return Encoding.GetEncoding(_UTF8Encoding); }
        }

        /// <summary>
        /// 读写文件的编码格式GB2312
        /// </summary>
        public static Encoding EncodingGB2312
        {
            get { return Encoding.GetEncoding(_GB2312Encoding); }
        }

        #region 上传是的文件类型
        /// <summary>
        /// 要上传的文件类型
        /// </summary>
        public static string UpLoadFileType
        {
            get { return _UpLoadFileType; }
        }
        #endregion

        #region 上传的图片文件类型
        /// <summary>
        /// 要上传的图片文件类型
        /// </summary>
        public static string UpLoadFileImage
        {
            get { return _UpLoadFileImage; }
        }
        #endregion

        #region 上传文件大小的设置
        /// <summary>
        /// 上传文件的限制大小(文件大小单位Mb)
        /// </summary>
        public static int filesizei
        {
            get { return _filesizei; }
        }

        /// <summary>
        /// 上传文件的限制大小(文件大小单位Mb)
        /// </summary>
        public static float filesizef
        {
            get { return _filesizef; }
        }

        /// <summary>
        /// 上传文件的限制大小(文件大小单位Mb)
        /// </summary>
        public static string filesizes
        {
            get { return _filesizes; }
        }
        #endregion

        /// <summary>
        /// 生成静态页的路径~/Html/News/
        /// </summary>
        public static string HTMLPath
        {
            get { return "~/sound/"; }
        }
        /// <summary>
        /// 显示静态页的路径/Html/News/
        /// </summary>
        public static string XHTMLPath
        {
            get { return "/qixin/hangye/"; }
        }

        #region Flash广告路径
        /// <summary>
        /// Flash广告、广告、友情链接路径
        /// ~/UpLoadFile/NewFolder/
        /// </summary>
        public static string ADUpLoadFileImages
        {
            get { return _ADUpLoadFileImages; }
        }
        /// <summary>
        /// 显示Flash广告、广告、友情链接路径
        /// /UpLoadFile/NewFolder/
        /// </summary>
        public static string XADUpLoadFileImages
        {
            get { return "/UpLoadFile/NewFolder/"; }
        }
        /// <summary>
        /// js广告路径
        /// ~/Upload/adjs/
        /// </summary>
        public static string ADJsFile
        {
            get { return "~/Upload/adjs/"; }
        }
        /// <summary>
        /// js广告路径
        /// /Upload/adjs/
        /// </summary>
        public static string XADJsFile
        {
            get { return "/Upload/adjs/"; }
        }
        #endregion Flash广告路径

    }
}

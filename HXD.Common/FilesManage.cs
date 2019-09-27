using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Configuration;

using System.Drawing.Imaging;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Data.SqlClient;
namespace HXD.Common
{
    public class FilesManage
    {
        private string file_names = "",//新文件名称
        _filename = "",//原始文件名称
        file_sizes = "",//文件大小(单位Mb精确到小数点后4位)
        file_types = "",//文件类型
        file_ljs = "",//按月份生成的文件夹名称
        _Path = "";//路径

        #region 随机生成的新文件名称
        /// <summary>
        /// 随机生成的新文件名称
        /// </summary>
        public string file_name
        {
            get { return this.file_names; }
            set { this.file_names = value; }
        }
        #endregion

        #region 原始文件名称
        /// <summary>
        /// 原始文件名称
        /// </summary>
        public string filename
        {
            get { return this._filename; }
            set { this._filename = value; }
        }
        #endregion

        #region 上传的文件路径
        /// <summary>
        /// 上传的文件路径
        /// </summary>
        public string Path
        {
            get { return this._Path; }
            set { this._Path = value; }
        }
        #endregion

        #region 文件大小(单位Mb精确到小数点后4位)
        /// <summary>
        /// 文件大小(单位Mb精确到小数点后4位)
        /// </summary>
        public string file_size
        {
            get { return this.file_sizes; }
            set { this.file_sizes = value; }
        }
        #endregion

        #region 文件后缀名称
        /// <summary>
        /// 文件后缀名称
        /// </summary>
        public string file_type
        {
            get { return this.file_types; }
            set { this.file_types = value; }
        }
        #endregion

        #region 按月份生成的文件夹路径
        /// <summary>
        /// 按月份生成的文件夹路径
        /// </summary>
        public string file_lj
        {
            get { return this.file_ljs; }
            set { this.file_ljs = value; }
        }
        #endregion

        #region AspnetUploadDemo2.2大文件上传方法(兼容2.3)
        ///// <summary>
        ///// AspnetUploadDemo2.2大文件上传方法(兼容2.3)
        ///// </summary>
        ///// <param name="filev">控件名称</param>
        ///// <param name="size">上传文件的大小</param>
        ///// <param name="typekey">上传文件的类型</param>
        ///// <param name="path">上传文件的相对路径</param>
        ///// <returns></returns>
        //public string AspnetUploadDemoUpFiles(string filev, double size, string typekey, string path)//AspnetUploadDemo2.2
        //{
        //    AspnetUpload upldr = new AspnetUpload();
        //    string datatimes = System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString() + "/";//文件的相对路径(按月生成文件夹)
        //    this.file_lj = datatimes;//生成的文件夹路径
        //    string src = HttpContext.Current.Server.MapPath("~" + path) + datatimes;//文件的完整路径
        //    if (!Directory.Exists(src))
        //    {
        //        Directory.CreateDirectory(src);//按月份创建文件夹
        //    }
        //    upldr.set_UploadFolder(src);//上传文件夹
        //    Bestcomy.Web.Controls.Upload.UploadFile files = AspnetUpload.GetUploadFile(filev);
        //    if (files != null)
        //    {
        //        string type = Path.GetFileName(files.get_FileName()).Substring(Path.GetFileName(files.get_FileName()).LastIndexOf(".") + 1);//文件后缀
        //        string filename = DateTime.Now.ToString("yyyyMMddhhmmss") + "." + type;//新文件名称
        //        double sizes = files.get_ContentLength() / (double)1024.0 / (double)1024.0;//文件大小
        //        this.file_type = type;//文件类型
        //        this.file_size = sizes.ToString("f4");//文件大小单位Mb精确到小数点后4位
        //        this.file_name = filename;//新文件名称

        //        bool filetype = false;//文件类型变量
        //        string[] types = typekey.Split('|');//文件格式集合
        //        for (int i = 0; i < types.Length; i++)
        //        {
        //            if (types[i].ToString().Trim().ToLower() == type.Trim().ToLower())
        //            {
        //                filetype = true;
        //                break;
        //            }
        //            else
        //            {
        //                filetype = false;
        //            }
        //        }
        //        if (filetype)//判断文件类型是否错误
        //        {
        //            if (sizes < size)
        //            {
        //                files.SaveAs(src + filename);//保存文件
        //                return "文件上传成功!";
        //            }
        //            else
        //            {
        //                return "文件大小超出指定范围!";
        //            }
        //        }
        //        else
        //        {
        //            return "文件格式错误!";
        //        }
        //StringBuilder sb = new StringBuilder();
        //sb.Append("<div class=\"entry\">");
        //sb.Append("<h2>File uploaded</h2>");
        //sb.Append("<strong>File Uploaded:</strong>&nbsp;&nbsp;");
        //string url = QueryFilename.EncryptFilename(Path.GetFileName(file.get_FileName()));
        //sb.Append("<a href=\"download.aspx?filename="+url+"\" target=\"_blank\">"+Path.GetFileName(file.get_FileName())+"</a>&nbsp;["+file.get_ContentLength().ToString("###,###")+"&nbsp;Bytes]"+"<br>");
        //sb.Append("<strong>Dscription:</strong>&nbsp;&nbsp;"+box_descript.Text+"<br><br>");
        //sb.Append("</div>");
        //txt.Text = sb.ToString();
        //    }
        //    else
        //    {
        //        return "请您选择文件\\n并且文件大小大于0字节的文件!";
        //    }
        //}
        #endregion

        #region 大文件上传类Webb.WAVE大文件上传组件
        //		/// <summary>
        //		/// 大文件上传类Webb.WAVE大文件上传组件
        //		/// </summary>
        //		/// <param name="filev">控件的名称</param>
        //		/// <param name="size">文件大小</param>
        //		/// <param name="typekey">文件格式,用|分隔开.例如(rar|txt)</param>
        //		/// <param name="path">相对路径(相对于根目录下的路径)例如:/UpLoadFile/Video/</param>
        //		/// <returns></returns>
        //		public string upfiles(string filev,double size,string typekey,string path)
        //		{
        //			try
        //			{
        //				string datatimes=System.DateTime.Now.Year.ToString()+System.DateTime.Now.Month.ToString()+"\\";//文件的相对路径(按月生成文件夹)
        //				this.file_lj=datatimes;//文件路径
        //				string src=HttpContext.Current.Server.MapPath("~"+path)+datatimes;//文件的完整路径
        //				if(!Directory.Exists(HttpContext.Current.Server.MapPath("~"+path)+datatimes))//判断是否有文件夹
        //				{
        //					Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~"+path)+datatimes);//如果不存在就创建文件夹
        //				}
        //				Webb.WAVE.Controls.Upload.WebbUpload m_upload = new WebbUpload();//上传类的实例化
        //				Webb.WAVE.Controls.Upload.UploadFile m_file = m_upload.GetUploadFile(filev);//获取上传控件
        //				if(m_file.ClientFullPathName!="")
        //				{
        //					string type=Path.GetFileName(m_file.ClientFullPathName).Substring(Path.GetFileName(m_file.ClientFullPathName).LastIndexOf(".")+1);//文件后缀
        //					string filename = DateTime.Now.ToString("yyyyMMddhhmmss")+"."+type;//文件名称
        //					double se=m_file.FileSize/(double)1024.0/(double)1024.0;//文件大小
        //					this.file_type=type;//文件类型
        //					this.file_size=se.ToString("f4");//文件大小单位Mb精确到小数点后4位
        //					this.file_name=filename;//文件名称

        //					bool filetype=false;
        //					string[] types=typekey.Split('|');//文件格式集合
        //					for(int i=0;i<types.Length;i++)
        //					{
        //						if(types[i].ToString().Trim().ToLower()==type.Trim().ToLower())
        //						{
        //							filetype=true;
        //							break;
        //						}
        //						else
        //						{
        //							filetype=false;
        //						}
        //					}
        //
        //					if(filetype)
        //					{
        //						if(se<size)
        //						{
        //							m_file.SaveAs(src+filename);//保存上传文件
        //							return "文件上传成功!";
        //						}
        //						else
        //						{
        //							return "文件大小超出指定范围!";
        //						}
        //					}
        //					else
        //					{
        //						return "文件格式错误!";
        //					}
        //				}
        //				else
        //				{
        //					return "请选择文件!";
        //				}
        //			}
        //			catch
        //			{return "请选择文件!";}
        //		}
        #endregion

        #region 生成文件名称
        /// <summary>
        /// 获取一个不重复的文件名
        /// </summary>
        /// <param name="hifile">HtmlInputFile控件</param>
        /// <returns>生成文件名</returns>
        public static string GetUniqueString()
        {
            //得到的文件名形如：20050922101010
            return DateTime.Now.ToString("yyyyMMddhhmmssfffffff");
        }
        #endregion

        #region 判断文件格式是否正确
        /// <summary>
        /// 判断文件格式是否正确，返回False表示文件格式错误，返回True表示文件格是正确
        /// </summary>
        /// <param name="aa">要上传的文件类型</param>
        /// <returns></returns>
        public static bool type(string aa, string types)
        {
            if (types.IndexOf(aa) < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region 文件上传(普通上传不生成文件夹)
        ///// <summary>
        ///// 文件上传(普通上传不生成文件夹)
        ///// </summary>
        ///// <param name="hifile">上传控件</param>
        ///// <param name="strAbsolutePath">相对路径(不包含文件名称)</param>
        ///// <param name="TYPE">文件类型(在WebConfig中配置)</param>
        ///// <param name="FileSize">文件大小单位:Mb(在WebConfig中配置)</param>
        ///// <param name="key">保证文件名称不重复的数字</param>
        ///// <returns></returns>
        //public bool SaveFile(HtmlInputFile hifile, string strAbsolutePath, string TYPE, string FileSize,int key,out string errorinfo)
        //{
        //    bool filetype = false;
        //    string /*文件的完整路径*/strOldFilePath = "", /*文件类型*/strExtension = "", /*新文件名称*/strNewFileName = "";
        //    //如果上传文件的文件名不为空
        //    if (hifile.PostedFile.FileName != string.Empty)
        //    {
        //        strOldFilePath = hifile.PostedFile.FileName;//文件的完整路径
        //        filename = FileObj.GetPostfixStr2(strOldFilePath);//原始文件名
        //        strAbsolutePath = HttpContext.Current.Server.MapPath(strAbsolutePath);//把相对路径转换成绝对路径
        //        Path = strAbsolutePath;//服务器路径
        //        //取得上传文件的扩展名

        //        strExtension = FileObj.GetPostfixStr1(strOldFilePath);
        //        file_type = strExtension;
        //        //文件大小单位Mb
        //        double sizes = hifile.PostedFile.ContentLength / (double)1024.0 / (double)1024.0;//文件大小
        //        this.file_size = sizes.ToString("f4");//文件大小单位Mb精确到小数点后4位
        //        //文件格式
        //        if (type(strExtension.Trim().ToLower(), TYPE.Trim().ToLower()))
        //        { filetype = true; }
        //        else { filetype = false; }

        //        if (filetype)//判断文件类型是否错误
        //        {
        //            if (sizes < Convert.ToDouble(FileSize))
        //            {
        //                //文件上传后的命名
        //                strNewFileName = GetUniqueString() + key + "." + strExtension;
        //                file_name = strNewFileName;
        //                if (!Directory.Exists(strAbsolutePath))//判断文件夹是否存在
        //                {
        //                    Directory.CreateDirectory(strAbsolutePath);//创建文件夹
        //                }
        //                hifile.PostedFile.SaveAs(strAbsolutePath + strNewFileName);//保存文件
        //                errorinfo = "文件上传成功!"; return true;
        //            }
        //            else
        //            { errorinfo = "文件大小不能超过" + FileSize + ".00Mb!"; return false; }
        //        }
        //        else
        //        { errorinfo = "文件格式错误!"; return false; }
        //    }
        //    else
        //    { errorinfo = "请选择要上传的文件!"; return false; }
        //}
        #endregion

        #region 文件上传(普通上传不生成文件夹)
        ///// <summary>
        ///// 文件上传(普通上传不生成文件夹)
        ///// </summary>
        ///// <param name="hifile">上传控件</param>
        ///// <param name="strAbsolutePath">相对路径(不包含文件名)</param>
        ///// <param name="TYPE">文件类型(在WebConfig中配置)</param>
        ///// <param name="FileSize">文件大小单位:Mb(在WebConfig中配置)</param>
        ///// <param name="key">保证文件名称不重复的数字</param>
        ///// <param name="content">出错后的说明性文字</param>
        ///// <returns></returns>
        //public bool SaveFile(HtmlInputFile hifile, string strAbsolutePath, string TYPE, string FileSize, int key, string content, out string errorinfo)
        //{
        //    bool filetype = false;
        //    string /*文件的完整路径*/strOldFilePath = "", /*文件类型*/strExtension = "", /*新文件名称*/strNewFileName = "";
        //    //如果上传文件的文件名不为空
        //    if (hifile.PostedFile.FileName != string.Empty)
        //    {
        //        strOldFilePath = hifile.PostedFile.FileName;//文件的完整路径
        //        filename = FileObj.GetPostfixStr2(strOldFilePath);//原始文件名
        //        strAbsolutePath = HttpContext.Current.Server.MapPath(strAbsolutePath);//把相对路径转换成绝对路径
        //        Path = strAbsolutePath;//服务器路径Path用来删除自身文件时使用
        //        //取得上传文件的扩展名
        //        strExtension = FileObj.GetPostfixStr1(strOldFilePath);
        //        file_type = strExtension;
        //        //文件大小单位Mb
        //        double sizes = hifile.PostedFile.ContentLength / (double)1024.0 / (double)1024.0;//文件大小
        //        this.file_size = sizes.ToString("f4");//文件大小单位Mb精确到小数点后4位
        //        //文件格式
        //        if (type(strExtension.Trim().ToLower(), TYPE.Trim().ToLower()))
        //        { filetype = true; }
        //        else { filetype = false; }

        //        if (filetype)//判断文件类型是否错误
        //        {
        //            if (sizes < Convert.ToDouble(FileSize))
        //            {
        //                //文件上传后的命名
        //                strNewFileName = GetUniqueString() + key + "." + strExtension;
        //                file_name = strNewFileName;
        //                if (!Directory.Exists(strAbsolutePath))//判断文件夹是否存在
        //                {
        //                    Directory.CreateDirectory(strAbsolutePath);//创建文件夹
        //                }
        //                hifile.PostedFile.SaveAs(strAbsolutePath + strNewFileName);//保存文件
        //                errorinfo = content + "上传成功!";
        //                return true;
        //            }
        //            else
        //            { errorinfo = content + "大小不能超过" + FileSize + ".00Mb!"; return false; }
        //        }
        //        else
        //        { errorinfo = content + "格式错误!"; return false; }
        //    }
        //    else
        //    { errorinfo = "请选择要上传的" + content + "!"; return false; }
        //}
        #endregion

        #region 文件上传(普通上传不生成文件夹)
        /// <summary>
        /// 文件上传(普通上传不生成文件夹)
        /// </summary>
        /// <param name="hifile">上传控件</param>
        /// <param name="strAbsolutePath">相对路径(不包含文件名称)</param>
        /// <param name="TYPE">文件类型(在WebConfig中配置)</param>
        /// <param name="FileSize">文件大小单位:Mb(在WebConfig中配置)</param>
        /// <returns></returns>
        public bool SaveFile(HtmlInputFile hifile, string strAbsolutePath, string TYPE, string FileSize, out string errorinfo)
        {
            bool filetype = false;
            string /*文件的完整路径*/strOldFilePath = "", /*文件类型*/strExtension = "", /*新文件名称*/strNewFileName = "";
            //如果上传文件的文件名不为空
            if (hifile.PostedFile.FileName != string.Empty)
            {
                strOldFilePath = hifile.PostedFile.FileName;//文件的完整路径
                filename = FileObj.GetPostfixStr2(strOldFilePath);//原始文件名
                strAbsolutePath = HttpContext.Current.Server.MapPath(strAbsolutePath);//把相对路径转换成绝对路径
                Path = strAbsolutePath;//服务器路径
                //取得上传文件的扩展名
                strExtension = FileObj.GetPostfixStr1(strOldFilePath);
                file_type = strExtension;
                //文件大小单位Mb
                double sizes = hifile.PostedFile.ContentLength / (double)1024.0 / (double)1024.0;//文件大小
                this.file_size = sizes.ToString("f4");//文件大小单位Mb精确到小数点后4位
                //文件格式
                if (type(strExtension.ToLower(), TYPE.ToLower()))
                {
                    if (TYPE.IndexOf("jpg") >= 0)
                    { filetype = ImageHelper.isImages(hifile.PostedFile.InputStream); }
                    else { filetype = true; }
                }
                else { filetype = false; }

                if (filetype)//判断文件类型是否错误
                {
                    if (sizes < Convert.ToDouble(FileSize))
                    {
                        //文件上传后的命名
                        strNewFileName = GetUniqueString() + "." + strExtension;
                        file_name = strNewFileName;
                        if (!Directory.Exists(strAbsolutePath))//判断文件夹是否存在
                        {
                            Directory.CreateDirectory(strAbsolutePath);//创建文件夹
                        }
                        hifile.PostedFile.SaveAs(strAbsolutePath + strNewFileName);//保存文件
                        errorinfo = "文件上传成功!"; return true;
                    }
                    else
                    { errorinfo = "文件大小不能超过" + FileSize + ".00Mb!"; return false; }
                }
                else
                { errorinfo = "文件格式错误!"; return false; }
            }
            else
            { errorinfo = "请选择要上传的文件!"; return false; }
        }

        /// <summary>
        /// 文件上传(普通上传不生成文件夹)
        /// </summary>
        /// <param name="hifile">上传控件</param>
        /// <param name="strAbsolutePath">相对路径(不包含文件名称)</param>
        /// <param name="TYPE">文件类型(在WebConfig中配置)</param>
        /// <param name="FileSize">文件大小单位:Mb(在WebConfig中配置)</param>
        /// <returns></returns>
        public bool SaveFile(HttpPostedFile hifile, string strAbsolutePath, string TYPE, string FileSize, out string errorinfo)
        {
            bool filetype = false;
            string /*文件的完整路径*/strOldFilePath = "", /*文件类型*/strExtension = "", /*新文件名称*/strNewFileName = "";
            //如果上传文件的文件名不为空
            if (hifile.FileName != string.Empty)
            {
                strOldFilePath = hifile.FileName;//文件的完整路径
                filename = FileObj.GetPostfixStr2(strOldFilePath);//原始文件名
                strAbsolutePath = HttpContext.Current.Server.MapPath(strAbsolutePath);//把相对路径转换成绝对路径
                Path = strAbsolutePath;//服务器路径
                //取得上传文件的扩展名
                strExtension = FileObj.GetPostfixStr1(strOldFilePath);
                file_type = strExtension;
                //文件大小单位Mb
                double sizes = hifile.ContentLength / (double)1024.0 / (double)1024.0;//文件大小
                this.file_size = sizes.ToString("f4");//文件大小单位Mb精确到小数点后4位
                //文件格式
                if (type(strExtension.Trim().ToLower(), TYPE.Trim().ToLower()))
                {
                    if (TYPE.IndexOf("jpg") >= 0)
                    { filetype = ImageHelper.isImages(hifile.InputStream); }
                    else { filetype = true; }
                }
                else { filetype = false; }

                if (filetype)//判断文件类型是否错误
                {
                    if (sizes < Convert.ToDouble(FileSize))
                    {
                        //文件上传后的命名
                        strNewFileName = GetUniqueString() + "." + strExtension;
                        file_name = strNewFileName;
                        if (!Directory.Exists(strAbsolutePath))//判断文件夹是否存在
                        {
                            Directory.CreateDirectory(strAbsolutePath);//创建文件夹
                        }
                        hifile.SaveAs(strAbsolutePath + strNewFileName);//保存文件
                        errorinfo = "文件上传成功!"; return true;
                    }
                    else
                    { errorinfo = "文件大小不能超过" + FileSize + ".00Mb!"; return false; }
                }
                else
                { errorinfo = "文件格式错误!"; return false; }
            }
            else
            { errorinfo = "请选择要上传的文件!"; return false; }
        }
        #endregion

        #region 读取文件信息
        /// <summary>
        /// 读取文件信息
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static string ReaderTextFile(string filename)
        {
            StreamReader reader = null;
            reader = new StreamReader(filename, Web.Model.PublicModel.EncodingUTF8);
            string text = reader.ReadToEnd();
            reader.Close();
            return text;
        }
        /// <summary>
        /// 读取文件信息
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static string ReaderTextFile(string filename, Encoding Encoding)
        {
            StreamReader reader = null;
            reader = new StreamReader(filename, Encoding);
            string text = reader.ReadToEnd();
            reader.Close();
            return text;
        }
        #endregion

        #region 写入文件
        /// <summary>
        /// 写入文件
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="Content"></param>
        /// <returns></returns>
        public static bool WriteTextFile(string filename, string Content, Encoding Encoding)
        {
            try
            {
                StreamWriter writer = new StreamWriter(System.Web.HttpContext.Current.Server.MapPath(filename), false, Encoding);
                writer.Write(Content);
                writer.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }
        #endregion

        #region 用来更新广告位的文件操作类
        /// <summary>
        /// 用来更新广告位的文件操作类
        /// </summary>
        /// <param name="filename">文件的名称包括路径例如：~/index.html</param>
        /// <param name="oldName">标签名称</param>
        /// <param name="newContent">内容</param>
        /// <returns></returns>
        public static bool ReplaceFileNewContent(string filename, string oldName, string newContent, Encoding Encoding)
        {
            bool flag = true;
            try
            {
                string content = "";
                string text2 = "";
                string text3 = "";
                text2 = "<!--" + oldName + "_start -->";
                text3 = "<!--" + oldName + "_end -->";
                //newContent = text2 + "\r\n" + newContent + "\r\n" + text3;
                newContent = text2 + newContent + text3;
                string input = ReaderTextFile(System.Web.HttpContext.Current.Server.MapPath(filename), Encoding);
                string oldValue = "";
                Regex regex = new Regex("<!--" + oldName + @"_start -->([\S\s]*)<!--" + oldName + "_end -->", RegexOptions.IgnoreCase);
                for (Match match = regex.Match(input); match.Success; match = match.NextMatch())
                {
                    oldValue = match.Groups[0].ToString();
                }
                content = input.Replace(oldValue, newContent);
                WriteTextFile(filename, content, Encoding);
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        /// <summary>
        /// 用来更新广告位的文件操作类
        /// </summary>
        /// <param name="filename">文件的名称包括路径例如：~/index.html</param>
        /// <param name="oldName">标签名称</param>
        /// <param name="newContent">内容</param>
        /// <returns></returns>
        public static bool ReplaceFileNewContent(string filename, Encoding ReaderEncoding, string oldName, string newContent, Encoding WriteEncoding)
        {
            bool flag = true;
            try
            {
                string content = "";
                string text2 = "";
                string text3 = "";
                text2 = "<!--" + oldName + "_start -->";
                text3 = "<!--" + oldName + "_end -->";
                //newContent = text2 + "\r\n" + newContent + "\r\n" + text3;
                newContent = text2 + newContent + text3;
                string input = ReaderTextFile(System.Web.HttpContext.Current.Server.MapPath(filename), ReaderEncoding);
                string oldValue = "";
                Regex regex = new Regex("<!--" + oldName + @"_start -->([\S\s]*)<!--" + oldName + "_end -->", RegexOptions.IgnoreCase);
                for (Match match = regex.Match(input); match.Success; match = match.NextMatch())
                {
                    oldValue = match.Groups[0].ToString();
                }
                content = input.Replace(oldValue, newContent);
                WriteTextFile(filename, content, WriteEncoding);
            }
            catch
            {
                flag = false;
            }
            return flag;
        }
        #endregion

        #region 用来更新广告位的文件操作类
        /// <summary>
        /// 用来更新广告位的文件操作类(两个自定义标记之间的内容)
        /// </summary>
        /// <param name="filename">文件的名称包括路径例如：~/index.html</param>
        /// <param name="startName">开始标签名称</param>
        /// <param name="endName">结束标签名称</param>
        /// <param name="newContent">内容</param>
        /// <returns></returns>
        public static bool ReplaceFileNewContents(string filename, string startName, string endName, string newContent)
        {
            bool flag = true;
            try
            {
                string content = "";
                string text2 = "";
                string text3 = "";
                text2 = startName;
                text3 = endName;
                newContent = text2 + newContent + text3;
                string input = ReaderTextFile(System.Web.HttpContext.Current.Server.MapPath(filename));
                string oldValue = "";
                Regex regex = new Regex(startName + @"([\S\s]*)" + endName, RegexOptions.IgnoreCase);
                for (Match match = regex.Match(input); match.Success; match = match.NextMatch())
                {
                    oldValue = match.Groups[0].ToString();
                }
                content = input.Replace(oldValue, newContent);
                WriteTextFile(filename, content, Web.Model.PublicModel.EncodingUTF8);
            }
            catch
            {
                flag = false;
            }
            return flag;
        }
        #endregion

        #region 文件上传(上传文件按月生成文件夹)
        /// <summary>
        /// 文件上传(上传文件按月生成文件夹)
        /// </summary>
        /// <param name="hifile">上传控件</param>
        /// <param name="strAbsolutePath">相对路径(不包含文件名)</param>
        /// <param name="TYPE">文件类型(在WebConfig中配置)</param>
        /// <param name="FileSize">文件大小单位:Mb(在WebConfig中配置)</param>
        /// <returns></returns>
        public bool SaveFileMonth(HtmlInputFile hifile, string strAbsolutePath, string TYPE, string FileSize, out string errorinfo)
        {
            bool filetype = false;
            string /*文件的完整路径*/strOldFilePath = "", /*文件类型*/strExtension = "", /*新文件名称*/strNewFileName = "";
            //如果上传文件的文件名不为空
            if (hifile.PostedFile.FileName != string.Empty)
            {
                strOldFilePath = hifile.PostedFile.FileName;//文件的完整路径
                //取得上传文件的扩展名
                strExtension = FileObj.GetPostfixStr1(strOldFilePath);
                file_type = strExtension;
                strAbsolutePath = HttpContext.Current.Server.MapPath(strAbsolutePath);//把相对路径转换成绝对路径
                //文件大小单位Mb
                double sizes = hifile.PostedFile.ContentLength / (double)1024.0 / (double)1024.0;//文件大小
                this.file_size = sizes.ToString("f4");//文件大小单位Mb精确到小数点后4位
                //文件格式
                if (type(strExtension.Trim().ToLower(), TYPE.Trim().ToLower()))
                { filetype = true; }
                else { filetype = false; }

                if (filetype)//判断文件类型是否错误
                {
                    if (sizes < Convert.ToDouble(FileSize))
                    {
                        //文件上传后的命名
                        strNewFileName = GetUniqueString() + "." + strExtension;
                        file_name = strNewFileName;
                        ////生成按月份为单位的文件夹
                        string datatimes = System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString() + "\\";//文件的相对路径(按月生成文件夹)
                        this.file_lj = datatimes;//生成的文件夹路径
                        Path = strAbsolutePath + datatimes;//文件的完整路径
                        if (!Directory.Exists(Path))
                        {
                            Directory.CreateDirectory(Path);//按月份创建文件夹
                        }
                        hifile.PostedFile.SaveAs(Path + strNewFileName);//保存文件
                        errorinfo = "文件上传成功!"; return true;
                    }
                    else
                    { errorinfo = "文件大小不能超过" + FileSize + ".00Mb!"; return false; }
                }
                else
                { errorinfo = "文件格式错误!"; return false; }
            }
            else
            { errorinfo = "请选择要上传的文件!"; return false; }
        }
        #endregion

        #region 删除文件(相对路径文件名称)
        /// <summary>
        /// 删除文件(相对路径+文件名称)
        /// </summary>
        /// <param name="path">文件的相对路径</param>
        /// <param name="filename">文件名</param>
        /// <returns></returns>
        public string WNdelfile(string filename, string path)
        {
            if (File.Exists(HttpContext.Current.Server.MapPath(path) + filename))
            {
                File.Delete(HttpContext.Current.Server.MapPath(path) + filename);
                return "文件删除成功!";
            }
            else
            {
                return "要删除的文件不存在!";
            }
        }
        #endregion

        #region 删除文件(相对路径)
        /// <summary>
        /// 删除文件(完整路径)
        /// </summary>
        /// <param name="path">文件的相对路径</param>
        /// <returns></returns>
        public string WNdelfile(string path)
        {
            if (File.Exists(HttpContext.Current.Server.MapPath(path)))
            {
                File.Delete(HttpContext.Current.Server.MapPath(path));
                return "文件删除成功!";
            }
            else
            {
                return "要删除的文件不存在!";
            }
        }
        #endregion

        #region 删除自身文件
        /// <summary>
        /// 删除自身文件
        /// </summary>
        public void Delete()
        {
            if (File.Exists(Path + file_name))
            {
                File.Delete(Path + file_name);
            }
        }
        #endregion
    }
}

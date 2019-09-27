using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace HXD.Common
{
    public class HtmlDal
    {
        /// <summary>
        /// 生成静态页面
        /// </summary>
        /// <param name="strNewsHtml">内容</param>
        /// <param name="strOldHtml">模板标记</param>
        /// <param name="strModeFilePath">模板路径</param>
        /// <param name="strPageFilePath">生成静态页面位置</param>
        /// <returns></returns>
        public static bool CreatHtmlPage(string[] strNewsHtml, string[] strOldHtml, string strModeFilePath, string strPageFilePath)
        {
            bool Flage = false;
            StreamReader ReaderFile = null;
            StreamWriter WrirteFile = null;
            string FilePath = HttpContext.Current.Server.MapPath(strModeFilePath);
            Encoding Code = Web.Model.PublicModel.EncodingUTF8;
            string strFile = string.Empty;
            try
            {
                ReaderFile = new StreamReader(FilePath, Code);
                strFile = ReaderFile.ReadToEnd();//读取文件流
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ReaderFile.Close();
            }
            try
            {
                int intLengTh = strNewsHtml.Length;
                for (int i = 0; i < intLengTh; i++)
                {
                    strFile = strFile.Replace(strOldHtml[i], strNewsHtml[i]);
                }
                WrirteFile = new StreamWriter(HttpContext.Current.Server.MapPath(strPageFilePath), false, Code);//创建文件
                WrirteFile.Write(strFile);
                Flage = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                WrirteFile.Flush();
                WrirteFile.Close();
            }
            return Flage;
        }

        /// <summary>
        /// 生成静态页面
        /// </summary>
        /// <param name="strNewsHtml">内容</param>
        /// <param name="strOldHtml">模板标记</param>
        /// <param name="strModeFilePath">模板路径</param>
        /// <param name="strPageFilePath">生成静态页面位置</param>
        /// <param name="Encoding">生成页面的编码</param>
        /// <returns></returns>
        public static bool CreatHtmlPage(string[] strNewsHtml, string[] strOldHtml, string strModeFilePath, string strPageFilePath, Encoding Encoding)
        {
            bool Flage = false;
            StreamReader ReaderFile = null;
            StreamWriter WrirteFile = null;
            string FilePath = HttpContext.Current.Server.MapPath(strModeFilePath);
            Encoding Code = Encoding;
            string strFile = string.Empty;
            try
            {
                ReaderFile = new StreamReader(FilePath, Code);
                strFile = ReaderFile.ReadToEnd();//读取文件流
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ReaderFile.Close();
            }
            try
            {
                int intLengTh = strNewsHtml.Length;
                for (int i = 0; i < intLengTh; i++)
                {
                    strFile = strFile.Replace(strOldHtml[i], strNewsHtml[i]);
                }
                WrirteFile = new StreamWriter(HttpContext.Current.Server.MapPath(strPageFilePath), false, Code);//创建文件
                WrirteFile.Write(strFile);
                Flage = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                WrirteFile.Flush();
                WrirteFile.Close();
            }
            return Flage;
        }

        /// <summary>
        /// 替换模板中的信息
        /// </summary>
        /// <param name="Content">原始内容</param>
        /// <param name="strNewsHtml">要替换的内容</param>
        /// <param name="strOldHtml">模板标记</param>
        /// <returns></returns>
        public static string CreatHtmlContent(string Content, string[] strNewsHtml, string[] strOldHtml)
        {
            try
            {
                int intLengTh = strNewsHtml.Length;
                for (int i = 0; i < intLengTh; i++)
                {
                    Content = Content.Replace(strOldHtml[i], strNewsHtml[i]);
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return Content;
        }

        #region 读取模板
        /// <summary>
        /// 读取模板
        /// </summary>
        /// <param name="templateUrl">模板地址</param>
        /// <param name="coding">编码</param>
        /// <returns>模板内容</returns>
        public static string ReadTemplate(string templateUrl, Encoding code)
        {
            string tlPath = System.Web.HttpContext.Current.Server.MapPath(templateUrl);
            StreamReader sr = null;
            string str = null;
            //读取模板内容
            try
            {
                sr = new StreamReader(tlPath, code);
                str = sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sr.Close();
            }
            return str;
        }
        #endregion

        #region 生成文件
        /// <summary>
        /// 生成文件 
        /// </summary>
        /// <param name="str">文件内容</param>
        /// <param name="htmlFile">文件存放地址</param>
        /// <param name="fileName">文件名</param>
        /// <param name="coding">编码</param>
        /// <returns>文件名</returns>
        public bool CreateHtml(string str, string htmlFile, string fileName, Encoding code)
        {
            StreamWriter sw = null;
            bool a = false;
            //写入生成
            try
            {
                htmlFile = System.Web.HttpContext.Current.Server.MapPath(htmlFile);
                FolderCreate(htmlFile);
                sw = new StreamWriter(htmlFile + fileName, false, code);
                sw.Write(str);
                sw.Flush();
                a = FileExists(htmlFile + fileName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sw.Close();
            }
            return a;
        }
        #endregion

        #region 判断文件是否存在
        /// <summary>
        /// 判断文件是否存在
        /// </summary>
        /// <param name="FilePath">文件路径</param>
        /// <returns></returns>
        public bool FileExists(string FilePath)
        {
            if (System.IO.File.Exists(FilePath))
                return true;
            else
                return false;
        }
        #endregion

        #region 创建目录
        /// <summary>
        /// 创建目录
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        public static bool FolderCreate(string Path)
        {
            // 判断目标目录是否存在如果不存在则新建之
            if (!Directory.Exists(Path))
                Directory.CreateDirectory(Path);
            return Directory.Exists(Path);
        }
        #endregion

        #region 静态列表页分页
        /// <summary>
        /// 静态列表页分页
        /// </summary>
        /// <param name="pageCount">总页数</param>
        /// <param name="currentPage">当前页</param>
        /// <param name="prefix">如:list</param>
        /// <param name="suffix">如:.shtml</param>
        /// <returns></returns>
        public static string GetHtmlPager(int pageCount, int currentPage, string prefix, string suffix)
        {
            int stepNum = 4;
            int pageRoot = 1;
            pageCount = pageCount == 0 ? 1 : pageCount;
            currentPage = currentPage == 0 ? 1 : currentPage;
            StringBuilder sb = new StringBuilder();
            sb.Append("<ul>");
            sb.Append("<li class=pagerTitle>&nbsp;分页&nbsp;" + currentPage.ToString() + "/" + pageCount.ToString() + "&nbsp;</li>\r");
            if (currentPage - stepNum < 2)
            { pageRoot = 1; }
            else
            { pageRoot = currentPage - stepNum; }
            int pageFoot = pageCount;
            if (currentPage + stepNum >= pageCount)
            { pageFoot = pageCount; }
            else
            { pageFoot = currentPage + stepNum; }
            if (pageRoot == 1)
            {
                if (currentPage > 1)
                {
                    sb.Append("<li>&nbsp;<a href='" + prefix + "1" + suffix + "' title='首页'>首页</a>&nbsp;</li>\r");
                    sb.Append("<li>&nbsp;<a href='" + prefix + Convert.ToString(currentPage - 1) + suffix + "' title='上页'>上页</a>&nbsp;</li>\r");
                }
            }
            else
            {
                sb.Append("<li>&nbsp;<a href='" + prefix + "1" + suffix + "' title='首页'>首页</a>&nbsp;</li>");
                sb.Append("<li>&nbsp;<a href='" + prefix + Convert.ToString(currentPage - 1) + suffix + "' title='上页'>上页</a>&nbsp;</li>\r");
            }
            for (int i = pageRoot; i <= pageFoot; i++)
            {
                if (i == currentPage)
                {
                    sb.Append("<li class='current'>&nbsp;" + i.ToString() + "&nbsp;</li>\r");
                }
                else
                {
                    sb.Append("<li>&nbsp;<a href='" + prefix + i.ToString() + suffix + "' title='第" + i.ToString() + "页'>" + i.ToString() + "</a>&nbsp;</li>\r");
                }
                if (i == pageCount)
                    break;
            }
            if (pageFoot == pageCount)
            {
                if (pageCount > currentPage)
                {
                    sb.Append("<li>&nbsp;<a href='" + prefix + Convert.ToString(currentPage + 1) + suffix + "' title='下页'>下页</a>&nbsp;</li>\r");
                    sb.Append("<li>&nbsp;<a href='" + prefix + pageCount.ToString() + suffix + "' title='尾页'>尾页</a>&nbsp;</li>\r");
                }
            }
            else
            {
                sb.Append("<li>&nbsp;<a href='" + prefix + Convert.ToString(currentPage + 1) + suffix + "' title='下页'>下页</a>&nbsp;</li>\r");
                sb.Append("<li>&nbsp;<a href='" + prefix + pageCount.ToString() + suffix + "' title='尾页'>尾页</a>&nbsp;</li>\r");
            }
            sb.Append("</ul>");
            return sb.ToString();
        }
        #endregion

        #region 压缩Html文件
        /// <summary>
        /// 压缩Html文件
        /// </summary>
        /// <param name="html">Html文件</param>
        /// <returns></returns>
        public static string ZipHtml(string Html)
        {
            Html = Regex.Replace(Html, @">\s+?<", "><");//去除Html中的空白字符.
            Html = Regex.Replace(Html, @"\r\n\s*", "");
            Html = Regex.Replace(Html, @"<body([\s|\S]*?)>([\s|\S]*?)</body>", @"<body$1>$2</body>", RegexOptions.IgnoreCase);
            return Html;
        }
        #endregion

        #region 从HTML中获取文本,保留br,p,img
        /// <summary>
        /// 从HTML中获取文本,保留br,p,img
        /// </summary>
        /// <param name="Html">文本内容</param>
        /// <returns></returns>
        public static string GetTextFromHtml(string Html)
        {
            Regex regEx = new Regex(@"</?(?!br|/?p|img)[^>]*>", RegexOptions.IgnoreCase);
            return regEx.Replace(Html, "");
        }
        /// <summary>
        /// 从HTML中获取文本
        /// </summary>
        /// <param name="Html">文本内容</param>
        /// <returns></returns>
        public static string GetTextFromHtml1(string Html)
        {
            Regex regEx = new Regex(@"</?[^>]*>", RegexOptions.IgnoreCase);
            return ZipHtml(regEx.Replace(Html, ""));
        }
        #endregion


        #region 静态文章(文章内分页)
        /// <summary>
        /// 静态分页(文章内分页)
        /// </summary>
        /// <param name="FileID">id</param>
        /// <param name="PageCount">共多少页</param>
        /// <param name="PageIndex">当前页数</param>
        /// <param name="Suffix">文件后缀</param>
        /// <returns></returns>
        private static string pagehtml(string id, int PageCount, int PageIndex, string Suffix)
        {
            StringBuilder str = new StringBuilder();
            str.Append("<div class=\"technorati\">");
            if (PageIndex == 1 && PageCount > 1)
            {
                str.Append("<a href=\"javascript:void(0);\">上一页</a>");
            }
            else if (PageIndex == 2)
            {
                str.Append("<a href=\"NewsContent_" + id + "." + Suffix + "\">上一页</a>");
            }
            else if (PageIndex > 2 && PageIndex <= PageCount)
            {
                str.Append("<a href=\"NewsContent_" + id + "_" + (PageIndex - 1) + "." + Suffix + "\">上一页</a>");
            }
            for (int i = 1; i <= PageCount; i++)
            {
                if (PageCount > 1)//如果总数等于1的话就不用添加索引
                {
                    if (PageIndex == i)//如果是当前索引就不加链接
                    { str.Append("<span class=\"current\">" + i.ToString() + "</span>"); }
                    else
                    {
                        if (i == 1)//如果是第一页的话不加添加索引地址
                        { str.Append("<a href=\"NewsContent_" + id + "." + Suffix + "\">" + i + "</a>"); }
                        else
                        { str.Append("<a href=\"NewsContent_" + id + "_" + i + "." + Suffix + "\">" + i + "</a>"); }
                    }
                }
            }
            if (PageIndex == PageCount && PageCount > 1)
            {
                str.Append("<a href=\"javascript:void(0);\">下一页</a>");
            }
            else if (PageIndex < PageCount)
            {
                str.Append("<a href=\"NewsContent_" + id + "_" + (PageIndex + 1) + "." + Suffix + "\">下一页</a>");
            }
            str.Append("</div>");
            return str.ToString();
        }
        #endregion

        #region 静态分页(上下篇)
        /// <summary>
        /// 静态分页(上下篇)
        /// </summary>
        /// <param name="FileID">用来标示页数的页码</param>
        /// <param name="PageCount">共多少页</param>
        /// <param name="PageIndex">当前页数</param>
        /// <returns></returns>
        private static string pagehtml1(string id, int classid)
        {
            StringBuilder str = new StringBuilder();
            str.Append("<script src=\"/AJAX/Next.ashx?id=" + id + "&classid=" + classid + "\" type=\"text/javascript\"></script>");
            str.Append("<script src=\"/AJAX/Previous.ashx?id=" + id + "&sortid=" + classid + "\" type=\"text/javascript\"></script>");
            return str.ToString();
        }
        #endregion


        #region 新闻的静态页生成方法
        /// <summary>
        /// 新闻的静态页生成方法(添加)
        /// </summary>
        //public static bool ToHtmlNewsAdd(int id)
        //{
        //    Web.Model.News model = new Web.Model.News();
        //    Web.DAL.News NewsDAL = new Web.DAL.News();
        //    model = NewsDAL.GetModel(id);
        //    #region 生成静态页
        //    string Pa = "<div style=\"page-break-after: always\"><span style=\"display: none\">&nbsp;</span></div>";//分页的标记
        //    string[] strcontent = Regex.Split(model.content, Pa, RegexOptions.IgnoreCase);//分割文章内容
        //    string str3 = string.Empty;//分页文件的名称
        //    string yuefen = System.DateTime.Now.ToString("yyyMMdd") + "/";//获取月份并且生成文件夹
        //    ToHtml.FolderCreate(HttpContext.Current.Server.MapPath(Web.Model.PublicModel.HTMLPath + yuefen));//新建文件夹
        //    StringBuilder str = new StringBuilder();
        //    for (int l = 1; l <= strcontent.Length; l++)
        //    {
        //        string filehtmls = string.Empty;
        //        if (strcontent.Length == 1)//如果总数等于1的话就不用添加索引
        //        {
        //            filehtmls = "NewsContent_" + model.id + ".shtml";
        //        }
        //        else
        //        {
        //            if (l == 1)
        //            { filehtmls = "NewsContent_" + model.id + ".shtml"; }//首页
        //            else
        //            { filehtmls = "NewsContent_" + model.id + "_" + l + ".shtml"; }//分页
        //        }
        //        string[] str1 = new string[] { strcontent[l - 1], pagehtml(model, strcontent.Length, l), pagehtml1(model.id.ToString(), model.sort_id), model.classname, model.title, model.source, model.submit_date.ToString("yyyy-MM-dd HH:mm:ss"), System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), SetConfig.GetConfigObj().Keywords, SetConfig.GetConfigObj().Description, model.id.ToString() };
        //        string[] str2 = new string[] { "[$内容$]", "[$分页$]", "[$上下篇$]", "[$分类$]", "[$标题$]", "[$来源$]", "[$时间$]", "[$生成时间$]", "[$keywords$]", "[$description$]", "[$ID$]" };
        //        ToHtml.CreatHtmlPage(str1, str2, "~/Template/NewsInfo.shtml", Web.DAL.PublicModel.SHTMLPath + yuefen + filehtmls);
        //    }
        //    model.PageCount = strcontent.Length;
        //    model.htmlfile = yuefen + "NewsContent_" + model.id + ".shtml";//首页静态文件
        //    return NewsDAL.Update1(model);//更新文章分页
        //    #endregion
        //}

        /// <summary>
        /// 新闻的静态页生成方法(带条件的)重新生成
        /// </summary>
        public static void WToHtmlNewsAdd(string where,string Suffix)
        {
            DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset("select * from V_News " + where);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string htmlfile = "";
                if (ds.Tables[0].Rows[i]["htmlfile"].ToString() != string.Empty)
                {
                    deletehtml(ds.Tables[0].Rows[i]["htmlfile"].ToString(), Convert.ToInt32(ds.Tables[0].Rows[i]["HtmlPageCount"]), "htm");//删除静态页面
                }
                else
                { htmlfile = System.DateTime.Now.ToString("yyyMMdd") + "/"; }
                #region 生成静态页
                string Pa = "<div style=\"page-break-after: always\"><span style=\"display: none\">&nbsp;</span></div>";//分页的标记
                string[] strcontent = Regex.Split(ds.Tables[0].Rows[i]["Content"].ToString(), Pa, RegexOptions.IgnoreCase);//分割文章内容
                string str3 = string.Empty;//分页文件的名称
                string yuefen = System.DateTime.Now.ToString("yyyMMdd") + "/";
                FolderCreate(HttpContext.Current.Server.MapPath(Web.Model.PublicModel.HTMLPath + yuefen));//新建文件夹
                StringBuilder str = new StringBuilder();
                for (int l = 1; l <= strcontent.Length; l++)//分页循环
                {
                    string filehtmls = string.Empty;
                    if (strcontent.Length == 1)//如果总数等于1的话就不用添加索引
                    {
                        filehtmls = "NewsContent_" + ds.Tables[0].Rows[i]["id"] + "." + Suffix;
                    }
                    else
                    {
                        if (l == 1)
                        { filehtmls = "NewsContent_" + ds.Tables[0].Rows[i]["id"] + "." + Suffix; }
                        else
                        { filehtmls = "NewsContent_" + ds.Tables[0].Rows[i]["id"] + "_" + l + "." + Suffix; }
                    }
                    string[] str1 = new string[] { strcontent[l - 1], pagehtml(ds.Tables[0].Rows[i]["id"].ToString(), strcontent.Length, l, Suffix), pagehtml1(ds.Tables[0].Rows[i]["id"].ToString(), Convert.ToInt32(ds.Tables[0].Rows[i]["ClassId"])), ds.Tables[0].Rows[i]["ClassName"].ToString(), ds.Tables[0].Rows[i]["Title"].ToString(), ds.Tables[0].Rows[i]["Source"].ToString(), Convert.ToDateTime(ds.Tables[0].Rows[i]["PostTime"]).ToString("yyyy-MM-dd HH:mm:ss"), System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), ds.Tables[0].Rows[i]["Keywords"].ToString(), ds.Tables[0].Rows[i]["Description"].ToString(), ds.Tables[0].Rows[i]["id"].ToString() };
                    string[] str2 = new string[] { "[$内容$]", "[$分页$]", "[$上下篇$]", "[$分类$]", "[$标题$]", "[$来源$]", "[$时间$]", "[$生成时间$]", "[$keywords$]", "[$description$]", "[$ID$]" };
                    CreatHtmlPage(str1, str2, "~/Template/NewsInfo." + Suffix, Web.Model.PublicModel.HTMLPath + yuefen + filehtmls);
                }
                int PageCount = strcontent.Length;
                htmlfile = yuefen + "NewsContent_" + ds.Tables[0].Rows[i]["id"] + "." + Suffix;
                Update1(Convert.ToInt32(ds.Tables[0].Rows[i]["id"]), htmlfile, PageCount);//修改文章分页的个数
            }
                #endregion
        }

        /// <summary>
        /// 更新静态页方法(单个更新)
        /// </summary>
        public static void ToHtmlNewsUpData(int id, string Suffix)
        {
            DataSet ds=HXD.DBUtility.SQLHelper.ExecuteDataset("select * from V_News where id=" + id);
            if (ds.Tables[0].Rows.Count == 1)
            {
                string htmlfile = ds.Tables[0].Rows[0]["htmlfile"].ToString();
                if (ds.Tables[0].Rows[0]["htmlfile"].ToString() != string.Empty)
                { deletehtml(ds.Tables[0].Rows[0]["htmlfile"].ToString(), Convert.ToInt32(ds.Tables[0].Rows[0]["PageCount"]), Suffix); }
                else
                { htmlfile = System.DateTime.Now.ToString("yyyMMdd") + "/"; }//如果记录不存在重新生成文件夹
                #region 生成静态页
                string Pa = "<div style=\"page-break-after: always\"><span style=\"display: none\">&nbsp;</span></div>";//分页的标记
                string[] strcontent = Regex.Split(ds.Tables[0].Rows[0]["Content"].ToString(), Pa, RegexOptions.IgnoreCase);//分割文章内容
                string str3 = string.Empty;//分页文件的名称
                string yuefen = htmlfile.Substring(0, htmlfile.LastIndexOf('/')) + "/";
                FolderCreate(HttpContext.Current.Server.MapPath(Web.Model.PublicModel.HTMLPath + yuefen));//新建文件夹
                StringBuilder str = new StringBuilder();
                for (int l = 1; l <= strcontent.Length; l++)
                {
                    string filehtmls = string.Empty;
                    if (strcontent.Length == 1)//如果总数等于1的话就不用添加索引
                    {
                        filehtmls = "NewsContent_" + ds.Tables[0].Rows[0]["id"] + "." + Suffix;
                    }
                    else
                    {
                        if (l == 1)
                        { filehtmls = "NewsContent_" + ds.Tables[0].Rows[0]["id"] + "." + Suffix; }
                        else
                        { filehtmls = "NewsContent_" + ds.Tables[0].Rows[0]["id"] + "_" + l + "." + Suffix; }
                    }
                    string[] str1 = new string[] { strcontent[l - 1], pagehtml(ds.Tables[0].Rows[0]["id"].ToString(), strcontent.Length, l, Suffix), pagehtml1(ds.Tables[0].Rows[0]["id"].ToString(), Convert.ToInt32(ds.Tables[0].Rows[0]["ClassId"])), ds.Tables[0].Rows[0]["ClassName"].ToString(), ds.Tables[0].Rows[0]["Title"].ToString(), ds.Tables[0].Rows[0]["Source"].ToString(), Convert.ToDateTime(ds.Tables[0].Rows[0]["PostTime"]).ToString("yyyy-MM-dd HH:mm:ss"), System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), ds.Tables[0].Rows[0]["Keywords"].ToString(), ds.Tables[0].Rows[0]["Description"].ToString(), ds.Tables[0].Rows[0]["id"].ToString() };
                    string[] str2 = new string[] { "[$内容$]", "[$分页$]", "[$上下篇$]", "[$分类$]", "[$标题$]", "[$来源$]", "[$时间$]", "[$生成时间$]", "[$keywords$]", "[$description$]", "[$ID$]" };
                    CreatHtmlPage(str1, str2, "~/Template/NewsInfo." + Suffix, Web.Model.PublicModel.HTMLPath + yuefen + filehtmls);
                }

                int PageCount = strcontent.Length;
                htmlfile = yuefen + "NewsContent_" + ds.Tables[0].Rows[0]["id"] + "." + Suffix;
                Update1(Convert.ToInt32(ds.Tables[0].Rows[0]["id"]), htmlfile, PageCount);//修改文章分页的个数
            }
            ds.Clear();
            ds.Dispose();
            #endregion
        }
        /// <summary>
        /// 更新静态页方法(带条件的更新)批量更新
        /// 语法：where id=1
        /// </summary>
        public static void WToHtmlNewsUpData(string where, string Suffix)
        {
            DataSet ds =HXD.DBUtility.SQLHelper.ExecuteDataset("select * from V_News " + where);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string htmlfile = ds.Tables[0].Rows[i]["htmlfile"].ToString();
                if (ds.Tables[0].Rows[i]["htmlfile"].ToString() != string.Empty)
                { deletehtml(ds.Tables[0].Rows[i]["htmlfile"].ToString(), Convert.ToInt32(ds.Tables[0].Rows[i]["HtmlPageCount"]), "htm"); }//删除静态页面
                else
                { htmlfile = System.DateTime.Now.ToString("yyyMMdd") + "/"; }

                #region 生成静态页
                string Pa = "<div style=\"page-break-after: always\"><span style=\"display: none\">&nbsp;</span></div>";//分页的标记
                string[] strcontent = Regex.Split(ds.Tables[0].Rows[i]["Content"].ToString(), Pa, RegexOptions.IgnoreCase);//分割文章内容
                string str3 = string.Empty;//分页文件的名称
                string yuefen = htmlfile.Substring(0, htmlfile.LastIndexOf('/')) + "/";
                FolderCreate(HttpContext.Current.Server.MapPath(Web.Model.PublicModel.HTMLPath + yuefen));//新建文件夹
                StringBuilder str = new StringBuilder();
                for (int l = 1; l <= strcontent.Length; l++)
                {
                    string filehtmls = string.Empty;
                    if (strcontent.Length == 1)//如果总数等于1的话就不用添加索引
                    {
                        filehtmls = "NewsContent_" + ds.Tables[0].Rows[i]["id"] + "." + Suffix;
                    }
                    else
                    {
                        if (l == 1)
                        { filehtmls = "NewsContent_" + ds.Tables[0].Rows[i]["id"] + "." + Suffix; }
                        else
                        { filehtmls = "NewsContent_" + ds.Tables[0].Rows[i]["id"] + "_" + l + "." + Suffix; }
                    }
                    string[] str1 = new string[] { strcontent[l - 1], pagehtml(ds.Tables[0].Rows[i]["id"].ToString(), strcontent.Length, l, Suffix), pagehtml1(ds.Tables[0].Rows[i]["id"].ToString(), Convert.ToInt32(ds.Tables[0].Rows[i]["ClassId"])), ds.Tables[0].Rows[i]["ClassName"].ToString(), ds.Tables[0].Rows[i]["Title"].ToString(), ds.Tables[0].Rows[i]["Source"].ToString(), Convert.ToDateTime(ds.Tables[0].Rows[i]["PostTime"]).ToString("yyyy-MM-dd HH:mm:ss"), System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), ds.Tables[0].Rows[i]["Keywords"].ToString(), ds.Tables[0].Rows[i]["Description"].ToString(), ds.Tables[0].Rows[i]["id"].ToString() };
                    string[] str2 = new string[] { "[$内容$]", "[$分页$]", "[$上下篇$]", "[$分类$]", "[$标题$]", "[$来源$]", "[$时间$]", "[$生成时间$]", "[$keywords$]", "[$description$]", "[$ID$]" };
                    CreatHtmlPage(str1, str2, "~/Template/NewsInfo." + Suffix, Web.Model.PublicModel.HTMLPath + yuefen + filehtmls);
                }
                #endregion
            }
        }
        #endregion


        /// <summary>
        /// 删除静态分页
        /// </summary>
        /// <param name="htmlfile">静态分页首页文件名</param>
        /// <param name="PageCount">分页个数</param>
        /// <param name="Suffix">要删除文件的后缀名</param>
        public static void deletehtml(string htmlfile, int PageCount, string Suffix)
        {
            HXD.Common.FileOperate.DeleteFile(Web.Model.PublicModel.HTMLPath + htmlfile);//删除静态页页面
            string filename = htmlfile.Substring(0, htmlfile.LastIndexOf("."));//获取文件名称
            for (int c = 2; c <= PageCount; c++)
            {
                HXD.Common.FileOperate.DeleteFile(Web.Model.PublicModel.HTMLPath + filename + "_" + c + "." + Suffix);//删除静态页页面
            }
        }

        /// <summary>
        /// 更新一条数据(修改静态文件名和文章分页数量)
        /// </summary>
        public static bool Update1(int id, string htmlfile, int PageCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_U_Info set ");
            strSql.Append("htmlfile=@htmlfile,");
            strSql.Append("HtmlPageCount=@HtmlPageCount");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
			new SqlParameter("@id", SqlDbType.Int,4),
			new SqlParameter("@htmlfile", SqlDbType.VarChar,100),
			new SqlParameter("@HtmlPageCount", SqlDbType.Int,4)};
            parameters[0].Value = id;
            parameters[1].Value = htmlfile;
            parameters[2].Value = PageCount;
            return HXD.DBUtility.SQLHelper.ExecuteNonQuery(strSql.ToString(), parameters) == 1;
        }

        /// <summary>
        /// 声音页面静态化(全分类)
        /// <param name="id">声音id</param>
        /// <param name="cid">城市id</param>
        /// </summary>
        public static void ToHtmlglmp3(int id, string cid)
        {
            string straxihuan = "", straxihua2 = "", straxihua3 = "",strbwg="", endtime = "", gl = "", timelist = "", chakan = "";
            string mp3html1 = "", mp3html2 = "", mp3html3 = "";
            int bbsurl = 0;

            string fenlei = HXD.DBUtility.SQLHelper.ExecuteScalar("select classid from tb_U_Info where id=" + id).ToString(); //classid=50  苏梅岛
            string fenlei2 = HXD.DBUtility.SQLHelper.ExecuteScalar("select ToMenu from tb_Menu where id=" + fenlei).ToString();//国家分类ToMenu =68
            bbsurl = int.Parse(HXD.DBUtility.SQLHelper.ExecuteScalar("select ParentId from tb_Menu where id=" + cid).ToString());//国家-城市分类-bbs-url
            string fenlei3 = HXD.DBUtility.SQLHelper.ExecuteScalar("select ParentId from tb_Menu where id=" + fenlei2).ToString();//

            #region 声音

            DataSet jd = HXD.DBUtility.SQLHelper.ExecuteDataset("select * from tb_U_Info where p_gl=44 and ClassId in(select id from tb_Menu where ToMenu=" + fenlei2 + ") and Id not in(" + id + ") and IsStatus=1 and IsHot=0");//景点
            if (jd.Tables[0].Rows.Count > 0)
            {
                mp3html1 += "<section class=\"yead_editor\">";
                mp3html1 += "<section class=\"mar\"><span class=\"yead_title\">景点</span></section>";
                mp3html1 += "</section>";
                mp3html1 += "<ul class=\"listc list1c clc \">";
                for (int i = 0; i < jd.Tables[0].Rows.Count; i++)
                {
                    mp3html1 += "<li class=\"item item-3\">";
                    mp3html1 += "<a class=\"pics\" href=\"" + jd.Tables[0].Rows[i]["id"].ToString() + ".html\">";
                    mp3html1 += "<div class=\"img default-img\"><img src=\"" + HXD.Common.Utils.PhotoIco(jd.Tables[0].Rows[i]["photo"].ToString().Trim()) + "\"></div>";
                    mp3html1 += "<p class=\"name ellipsis mgt-5\">" + jd.Tables[0].Rows[i]["title"].ToString() + "</p>";
                    mp3html1 += "</a></li>";
                }
                mp3html1 += "</ul><div class=\"wrapper3 cl\"><i class=\"item-4s fl\"><hr></i></div>";
            }
            //mp3html1 = straxihua2;
            //select * from tb_U_Info where p_gl=44 and ClassId in(select id from tb_Menu where ToMenu=79) and Id not in(21) and IsStatus=1
            //select * from tb_Menu where ToMenu='278' and PageType=239    博物馆
            DataSet bwg = HXD.DBUtility.SQLHelper.ExecuteDataset("select * from tb_Menu where ToMenu=" + cid + " and PageType=239");
            if (bwg.Tables[0].Rows.Count > 0)
            {
                strbwg += "<section class=\"yead_editor\">";
                strbwg += "<section class=\"mar\"><span class=\"yead_title\">博物馆</span></section>";
                strbwg += "</section>";
                strbwg += "<ul class=\"listc list1c clc \">";
                for (int i = 0; i < bwg.Tables[0].Rows.Count; i++)
                {
                    strbwg += "<li class=\"item item-3\">";
                    strbwg += "<a class=\"pics\" href=\"../bowuguan/" + bwg.Tables[0].Rows[i]["id"].ToString() + ".html\">";
                    strbwg += "<div class=\"img default-img\"><img src=\"" + bwg.Tables[0].Rows[i]["Content"].ToString().Trim() + "\" height=\"80px\"></div>";
                    strbwg += "<p class=\"name ellipsis mgt-5\">" + bwg.Tables[0].Rows[i]["title"].ToString() + "</p>";
                    strbwg += "</a></li>";
                }
                strbwg += "</ul><div class=\"wrapper3 cl\"><i class=\"item-4s fl\"><hr></i></div>";
            }
            //select * from tb_U_Info where p_gl=45 and ClassId in(select id from tb_Menu where ToMenu=68) --美食
            DataSet ms = HXD.DBUtility.SQLHelper.ExecuteDataset("select * from tb_U_Info where p_gl=45 and ClassId in(select id from tb_Menu where ToMenu=" + fenlei2 + ") and Id not in(" + id + ") and IsStatus=1");
            if (ms.Tables[0].Rows.Count > 0)
            {
                straxihua2 += "<section class=\"yead_editor\">";
                straxihua2 += "<section class=\"mar\"><span class=\"yead_title\">美食</span></section>";
                straxihua2 += "</section>";
                straxihua2 += "<ul class=\"listc list1c clc \">";
                for (int i = 0; i < ms.Tables[0].Rows.Count; i++)
                {
                    straxihua2 += "<li class=\"item item-3\">";
                    straxihua2 += "<a class=\"pics\" href=\"" + ms.Tables[0].Rows[i]["id"].ToString() + ".html\">";
                    straxihua2 += "<div class=\"img default-img\"><img src=\"" + HXD.Common.Utils.PhotoIco(ms.Tables[0].Rows[i]["photo"].ToString().Trim()) + "\"></div>";
                    straxihua2 += "<p class=\"name ellipsis mgt-5\">" + ms.Tables[0].Rows[i]["title"].ToString() + "</p>";
                    straxihua2 += "</a></li>";
                }
                straxihua2 += "</ul><div class=\"wrapper3 cl\"><i class=\"item-4s fl\"><hr></i></div>";
            }
            //select * from tb_U_Info where p_gl=46 and ClassId in(select id from tb_Menu where ToMenu=68) --购物
            DataSet gw = HXD.DBUtility.SQLHelper.ExecuteDataset("select * from tb_U_Info where p_gl=46 and ClassId in(select id from tb_Menu where ToMenu=" + fenlei2 + ") and Id not in(" + id + ") and IsStatus=1");
            if (gw.Tables[0].Rows.Count > 0)
            {
                straxihua2 += "<section class=\"yead_editor\">";
                straxihua2 += "<section class=\"mar\"><span class=\"yead_title\">购物</span></section>";
                straxihua2 += "</section>";
                straxihua2 += "<ul class=\"listc list1c clc \">";
                for (int i = 0; i < gw.Tables[0].Rows.Count; i++)
                {
                    straxihua2 += "<li class=\"item item-3\">";
                    straxihua2 += "<a class=\"pics\" href=\"" + gw.Tables[0].Rows[i]["id"].ToString() + ".html\">";
                    straxihua2 += "<div class=\"img default-img\"><img src=\"" + HXD.Common.Utils.PhotoIco(gw.Tables[0].Rows[i]["photo"].ToString().Trim()) + "\"></div>";
                    straxihua2 += "<p class=\"name ellipsis mgt-5\">" + gw.Tables[0].Rows[i]["title"].ToString() + "</p>";
                    straxihua2 += "</a></li>";
                }
                straxihua2 += "</ul><div class=\"wrapper3 cl\"><i class=\"item-4s fl\"><hr></i></div>";
            }
            //select * from tb_U_Info where p_gl=47 and ClassId in(select id from tb_Menu where ToMenu=68) --故事
            DataSet gs = HXD.DBUtility.SQLHelper.ExecuteDataset("select * from tb_U_Info where p_gl=47 and ClassId in(select id from tb_Menu where ToMenu=" + fenlei2 + ") and Id not in(" + id + ") and IsStatus=1");
            if (gs.Tables[0].Rows.Count > 0)
            {
                straxihua2 += "<section class=\"yead_editor\">";
                straxihua2 += "<section class=\"mar\"><span class=\"yead_title\">故事</span></section>";
                straxihua2 += "</section>";
                straxihua2 += "<ul class=\"listc list1c clc \">";
                for (int i = 0; i < gs.Tables[0].Rows.Count; i++)
                {
                    straxihua2 += "<li class=\"item item-3\">";
                    straxihua2 += "<a class=\"pics\" href=\"" + gs.Tables[0].Rows[i]["id"].ToString() + ".html\">";
                    straxihua2 += "<div class=\"img default-img\"><img src=\"" + HXD.Common.Utils.PhotoIco(gs.Tables[0].Rows[i]["photo"].ToString().Trim()) + "\"></div>";
                    straxihua2 += "<p class=\"name ellipsis mgt-5\">" + gs.Tables[0].Rows[i]["title"].ToString() + "</p>";
                    straxihua2 += "</a></li>";
                }
                straxihua2 += "</ul><div class=\"wrapper3 cl\"><i class=\"item-4s fl\"><hr></i></div>";
            }



            //select * from tb_U_Info where p_gl=49 and ClassId in(select id from tb_Menu where ToMenu=68) --娱乐
            DataSet yl = HXD.DBUtility.SQLHelper.ExecuteDataset("select * from tb_U_Info where p_gl=49 and ClassId in(select id from tb_Menu where ToMenu=" + fenlei2 + ") and Id not in(" + id + ") and IsStatus=1");
            if (yl.Tables[0].Rows.Count > 0)
            {
                straxihua2 += "<section class=\"yead_editor\">";
                straxihua2 += "<section class=\"mar\"><span class=\"yead_title\">娱乐</span></section>";
                straxihua2 += "</section>";
                straxihua2 += "<ul class=\"listc list1c clc \">";
                for (int i = 0; i < yl.Tables[0].Rows.Count; i++)
                {
                    straxihua2 += "<li class=\"item item-3\">";
                    straxihua2 += "<a class=\"pics\" href=\"" + yl.Tables[0].Rows[i]["id"].ToString() + ".html\">";
                    straxihua2 += "<div class=\"img default-img\"><img src=\"" + HXD.Common.Utils.PhotoIco(yl.Tables[0].Rows[i]["photo"].ToString().Trim()) + "\"></div>";
                    straxihua2 += "<p class=\"name ellipsis mgt-5\">" + yl.Tables[0].Rows[i]["title"].ToString() + "</p>";
                    straxihua2 += "</a></li>";
                }
                straxihua2 += "</ul><div class=\"wrapper3 cl\"><i class=\"item-4s fl\"><hr></i></div>";
            }

            //趣旅行
            DataSet qlx = HXD.DBUtility.SQLHelper.ExecuteDataset("select * from tb_U_Info where p_gl=289 and ClassId in(select id from tb_Menu where ToMenu=" + fenlei2 + ") and Id not in(" + id + ") and IsStatus=1");
            if (qlx.Tables[0].Rows.Count > 0)
            {
                straxihua2 += "<section class=\"yead_editor\">";
                straxihua2 += "<section class=\"mar\"><span class=\"yead_title\">趣旅行</span></section>";
                straxihua2 += "</section>";
                straxihua2 += "<ul class=\"listc list1c clc \">";
                for (int i = 0; i < qlx.Tables[0].Rows.Count; i++)
                {
                    straxihua2 += "<li class=\"item item-3\">";
                    straxihua2 += "<a class=\"pics\" href=\"" + qlx.Tables[0].Rows[i]["id"].ToString() + ".html\">";
                    straxihua2 += "<div class=\"img default-img\"><img src=\"" + HXD.Common.Utils.PhotoIco(qlx.Tables[0].Rows[i]["photo"].ToString().Trim()) + "\"></div>";
                    straxihua2 += "<p class=\"name ellipsis mgt-5\">" + qlx.Tables[0].Rows[i]["title"].ToString() + "</p>";
                    straxihua2 += "</a></li>";
                }
                straxihua2 += "</ul><div class=\"wrapper3 cl\"><i class=\"item-4s fl\"><hr></i></div>";
            }

            //select * from tb_U_Info where  ClassId in(select id from tb_Menu where ToMenu in(select id from tb_Menu where ParentId=" + fenlei2 + ")) and IsStatus=1 and IsHot=1 --推荐城市
            DataSet ci = HXD.DBUtility.SQLHelper.ExecuteDataset("select * from tb_U_Info where  ClassId in(select id from tb_Menu where ToMenu in(select id from tb_Menu where ParentId=" + bbsurl + ")) and IsStatus=1 and shouxuan=1 and id not in(" + id + ")");
            if (ci.Tables[0].Rows.Count > 0)
            {
                straxihua2 += "<section class=\"yead_editor\">";
                straxihua2 += "<section class=\"mar\"><span class=\"yead_title\">相关推荐</span></section>";
                straxihua2 += "</section>";
                straxihua2 += "<ul class=\"listc list1c clc \">";
                for (int i = 0; i < ci.Tables[0].Rows.Count; i++)
                {
                    straxihua2 += "<li class=\"item item-3\">";
                    straxihua2 += "<a class=\"pics\" href=\"" + ci.Tables[0].Rows[i]["id"].ToString() + ".html\">";
                    straxihua2 += "<div class=\"img default-img\"><img src=\"" + HXD.Common.Utils.PhotoIco(ci.Tables[0].Rows[i]["photo"].ToString().Trim()) + "\"></div>";
                    straxihua2 += "<p class=\"name ellipsis mgt-5\">" + ci.Tables[0].Rows[i]["title"].ToString() + "</p>";
                    straxihua2 += "</a></li>";
                }
                straxihua2 += "</ul><div class=\"wrapper3 cl\"><i class=\"item-4s fl\"><hr></i></div>";
            }
            //国家
            DataSet coun = HXD.DBUtility.SQLHelper.ExecuteDataset("select * from tb_U_Info where ClassId in(select id from tb_Menu where ToMenu=(select ParentId from tb_Menu where Id='" + cid + "'))and IsStatus=1");
            if (coun.Tables[0].Rows.Count > 0)
            {
                straxihua2 += "<section class=\"yead_editor\">";
                straxihua2 += "<section class=\"mar\"><span class=\"yead_title\">猜你喜欢</span></section>";
                straxihua2 += "</section>";
                straxihua2 += "<ul class=\"listc list1c clc \">";
                for (int i = 0; i < coun.Tables[0].Rows.Count; i++)
                {
                    straxihua2 += "<li class=\"item item-3\">";
                    straxihua2 += "<a class=\"pics\" href=\"" + coun.Tables[0].Rows[i]["id"].ToString() + ".html\">";
                    straxihua2 += "<div class=\"img default-img\"><img src=\"" + HXD.Common.Utils.PhotoIco(coun.Tables[0].Rows[i]["photo"].ToString().Trim()) + "\"></div>";
                    straxihua2 += "<p class=\"name ellipsis mgt-5\">" + coun.Tables[0].Rows[i]["title"].ToString() + "</p>";
                    straxihua2 += "</a></li>";
                }
                straxihua2 += "</ul><div class=\"wrapper3 cl\"><i class=\"item-4s fl\"><hr></i></div>";
            }
            straxihua3 = mp3html1+straxihua2;
           

            //select * from tb_U_Info where p_gl=520 and ClassId in(select id from tb_Menu where ToMenu=68) and IsStatus=1;--问达人列表

            //select * from tb_U_Info where p_gl=48 and ClassId in(select id from tb_Menu where ToMenu=79) --产品
            //达人列表
            DataSet dr2 = HXD.DBUtility.SQLHelper.ExecuteDataset("select * from tb_U_Info where p_gl=520 and ClassId in(select id from tb_Menu where ToMenu=" + bbsurl + ")and IsStatus=0 and IsHot=1");
            if (dr2.Tables[0].Rows.Count > 0)
            {
                straxihua2 += "<section class=\"yead_editor\">";
                straxihua2 += "<section class=\"mar\"><span class=\"yead_title\">推荐达人</span></section>";
                straxihua2 += "</section>";
                straxihua2 += "<ul class=\"listc list1c clc \">";
                for (int i = 0; i < dr2.Tables[0].Rows.Count; i++)
                {
                    straxihua2 += "<li class=\"item item-3\">";
                    straxihua2 += "<a class=\"pics\" href=\" " + dr2.Tables[0].Rows[i]["Title1"].ToString() + "\">";
                    straxihua2 += "<div class=\"img default-img\"><img src=\"" + dr2.Tables[0].Rows[i]["photo"].ToString().Trim() + "\"></div>";
                    straxihua2 += "<p class=\"name ellipsis mgt-5\">" + dr2.Tables[0].Rows[i]["title"].ToString() + "</p>";
                    straxihua2 += "</a></li>";
                }
                straxihua2 += "</ul><div class=\"wrapper3 cl\"><i class=\"item-4s fl\"><hr></i></div>";
            }

            
       
          

            //预订门票
            DataSet ydmp = HXD.DBUtility.SQLHelper.ExecuteDataset("select * from tb_U_Info where p_gl=560 and ClassId in(select id from tb_Menu where ToMenu=" + fenlei2 + ") ");
            if (ydmp.Tables[0].Rows.Count > 0)
            {
                straxihua2 += "<section class=\"yead_editor\">";
                straxihua2 += "<section class=\"mar\"><span class=\"yead_title2\">预订门票</span></section>";
                straxihua2 += "</section>";
                straxihua2 += "<ul class=\"listc list1c clc \">";
                for (int i = 0; i < ydmp.Tables[0].Rows.Count; i++)
                {
                    string url = ydmp.Tables[0].Rows[i]["Title1"].ToString();
                    string src = hao123(url);
                    straxihua2 += "<li class=\"item item-3\">";
                    straxihua2 += "<a class=\"pics\" href=\"" + url + "\">";
                    straxihua2 += "<div class=\"img default-img\"><b style=\"background-image: url('"+src+"'); background-size:contain;position:absolute; width:80px; height: 80px;\"></b><img src=\"" + ydmp.Tables[0].Rows[i]["photo"].ToString().Trim() + "\"></div>";
                    straxihua2 += "<p class=\"name ellipsis mgt-5\">" + ydmp.Tables[0].Rows[i]["title"].ToString() + "</p>";
                    straxihua2 += "</a></li>";
                }
                straxihua2 += "</ul><div class=\"wrapper3 cl\"><i class=\"item-4s fl\"><hr></i></div>";
            }
            //预订美食
            DataSet ydms = HXD.DBUtility.SQLHelper.ExecuteDataset("select * from tb_U_Info where p_gl=561 and ClassId in(select id from tb_Menu where ToMenu=" + fenlei2 + ") ");
            if (ydms.Tables[0].Rows.Count > 0)
            {
                straxihua2 += "<section class=\"yead_editor\">";
                straxihua2 += "<section class=\"mar\"><span class=\"yead_title2\">预订美食</span></section>";
                straxihua2 += "</section>";
                straxihua2 += "<ul class=\"listc list1c clc \">";
                for (int i = 0; i < ydms.Tables[0].Rows.Count; i++)
                {
                    string url = ydms.Tables[0].Rows[i]["Title1"].ToString();
                    string src = hao123(url);
                    straxihua2 += "<li class=\"item item-3\">";
                    straxihua2 += "<a class=\"pics\" href=\"" + url + "\">";
                    straxihua2 += "<div class=\"img default-img\"><b style=\"background-image: url('" + src + "'); background-size:contain;position:absolute; width:80px; height: 80px;\"></b><img src=\"" + ydms.Tables[0].Rows[i]["photo"].ToString().Trim() + "\"></div>";
                    straxihua2 += "<p class=\"name ellipsis mgt-5\">" + ydms.Tables[0].Rows[i]["title"].ToString() + "</p>";
                    straxihua2 += "</a></li>";
                }
                straxihua2 += "</ul><div class=\"wrapper3 cl\"><i class=\"item-4s fl\"><hr></i></div>";
            }
            //预订玩乐
            DataSet ydwl = HXD.DBUtility.SQLHelper.ExecuteDataset("select * from tb_U_Info where p_gl=562 and ClassId in(select id from tb_Menu where ToMenu=" + fenlei2 + ") ");
            if (ydwl.Tables[0].Rows.Count > 0)
            {
                straxihua2 += "<section class=\"yead_editor\">";
                straxihua2 += "<section class=\"mar\"><span class=\"yead_title2\">预订玩乐</span></section>";
                straxihua2 += "</section>";
                straxihua2 += "<ul class=\"listc list1c clc \">";
                for (int i = 0; i < ydwl.Tables[0].Rows.Count; i++)
                {
                    string url = ydwl.Tables[0].Rows[i]["Title1"].ToString();
                    string src = hao123(url);
                    straxihua2 += "<li class=\"item item-3\">";
                    straxihua2 += "<a class=\"pics\" href=\"" + url + "\">";
                    straxihua2 += "<div class=\"img default-img\"><b style=\"background-image: url('" + src + "'); background-size:contain;position:absolute; width:80px; height: 80px;\"></b><img src=\"" + ydwl.Tables[0].Rows[i]["photo"].ToString().Trim() + "\"></div>";
                    straxihua2 += "<p class=\"name ellipsis mgt-5\">" + ydwl.Tables[0].Rows[i]["title"].ToString() + "</p>";
                    straxihua2 += "</a></li>";
                }
                straxihua2 += "</ul><div class=\"wrapper3 cl\"><i class=\"item-4s fl\"><hr></i></div>";
            }
            //预订接机
            DataSet ydjj = HXD.DBUtility.SQLHelper.ExecuteDataset("select * from tb_U_Info where p_gl=563 and ClassId in(select id from tb_Menu where ToMenu=" + fenlei2 + ") ");
            if (ydjj.Tables[0].Rows.Count > 0)
            {
                straxihua2 += "<section class=\"yead_editor\">";
                straxihua2 += "<section class=\"mar\"><span class=\"yead_title2\">预订接机</span></section>";
                straxihua2 += "</section>";
                straxihua2 += "<ul class=\"listc list1c clc \">";
                for (int i = 0; i < ydjj.Tables[0].Rows.Count; i++)
                {
                    string url = ydjj.Tables[0].Rows[i]["Title1"].ToString();
                    string src = hao123(url);
                    straxihua2 += "<li class=\"item item-3\">";
                    straxihua2 += "<a class=\"pics\" href=\"" + url + "\">";
                    straxihua2 += "<div class=\"img default-img\"><b style=\"background-image: url('" + src + "'); background-size:contain;position:absolute; width:80px; height: 80px;\"></b><img src=\"" + ydjj.Tables[0].Rows[i]["photo"].ToString().Trim() + "\"></div>";
                    straxihua2 += "<p class=\"name ellipsis mgt-5\">" + ydjj.Tables[0].Rows[i]["title"].ToString() + "</p>";
                    straxihua2 += "</a></li>";
                }
                straxihua2 += "</ul><div class=\"wrapper3 cl\"><i class=\"item-4s fl\"><hr></i></div>";
            }
            //预订名宿
            DataSet ydmsu = HXD.DBUtility.SQLHelper.ExecuteDataset("select * from tb_U_Info where p_gl=565 and ClassId in(select id from tb_Menu where ToMenu=" + fenlei2 + ") ");
            if (ydmsu.Tables[0].Rows.Count > 0)
            {
                straxihua2 += "<section class=\"yead_editor\">";
                straxihua2 += "<section class=\"mar\"><span class=\"yead_title2\">预订名宿</span></section>";
                straxihua2 += "</section>";
                straxihua2 += "<ul class=\"listc list1c clc \">";
                for (int i = 0; i < ydmsu.Tables[0].Rows.Count; i++)
                {
                    string url = ydmsu.Tables[0].Rows[i]["Title1"].ToString();
                    string src = hao123(url);
                    straxihua2 += "<li class=\"item item-3\">";
                    straxihua2 += "<a class=\"pics\" href=\"" + url + "\">";
                    straxihua2 += "<div class=\"img default-img\"><b style=\"background-image: url('" + src + "'); background-size:contain;position:absolute; width:80px; height: 80px;\"></b><img src=\"" + ydmsu.Tables[0].Rows[i]["photo"].ToString().Trim() + "\"></div>";
                    straxihua2 += "<p class=\"name ellipsis mgt-5\">" + ydmsu.Tables[0].Rows[i]["title"].ToString() + "</p>";
                    straxihua2 += "</a></li>";
                }
                straxihua2 += "</ul><div class=\"wrapper3 cl\"><i class=\"item-4s fl\"><hr></i></div>";
            }
            //签证办理
            DataSet qzbl = HXD.DBUtility.SQLHelper.ExecuteDataset("select * from tb_U_Info where p_gl=566 and ClassId in(select id from tb_Menu where ToMenu=" + fenlei2 + ") ");
            if (qzbl.Tables[0].Rows.Count > 0)
            {
                straxihua2 += "<section class=\"yead_editor\">";
                straxihua2 += "<section class=\"mar\"><span class=\"yead_title2\">签证办理</span></section>";
                straxihua2 += "</section>";
                straxihua2 += "<ul class=\"listc list1c clc \">";
                for (int i = 0; i < qzbl.Tables[0].Rows.Count; i++)
                {
                    string url = qzbl.Tables[0].Rows[i]["Title1"].ToString();
                    string src = hao123(url);
                    straxihua2 += "<li class=\"item item-3\">";
                    straxihua2 += "<a class=\"pics\" href=\"" + url + "\">";
                    straxihua2 += "<div class=\"img default-img\"><b style=\"background-image: url('" + src + "'); background-size:contain;position:absolute; width:80px; height: 80px;\"></b><img src=\"" + qzbl.Tables[0].Rows[i]["photo"].ToString().Trim() + "\"></div>";
                    straxihua2 += "<p class=\"name ellipsis mgt-5\">" + qzbl.Tables[0].Rows[i]["title"].ToString() + "</p>";
                    straxihua2 += "</a></li>";
                }
                straxihua2 += "</ul><div class=\"wrapper3 cl\"><i class=\"item-4s fl\"><hr></i></div>";
            }
            //预约达人
            DataSet yydr = HXD.DBUtility.SQLHelper.ExecuteDataset("select * from tb_U_Info where p_gl=520 and ClassId in(select id from tb_Menu where ToMenu=" + fenlei2 + ")");
            if (yydr.Tables[0].Rows.Count > 0)
            {
                straxihua2 += "<section class=\"yead_editor\">";
                straxihua2 += "<section class=\"mar\"><span class=\"yead_title2\">预约达人</span></section>";
                straxihua2 += "</section>";
                straxihua2 += "<ul class=\"listc list1c clc \">";
                for (int i = 0; i < yydr.Tables[0].Rows.Count; i++)
                {
                    string url = yydr.Tables[0].Rows[i]["Title1"].ToString();
                    string src = hao123(url);
                    straxihua2 += "<li class=\"item item-3\">";
                    straxihua2 += "<a class=\"pics\" href=\"" + url + "\">";
                    straxihua2 += "<div class=\"img default-img\"><b style=\"background-image: url('" + src + "'); background-size:contain;position:absolute; width:80px; height: 80px;\"></b><img src=\"" + yydr.Tables[0].Rows[i]["photo"].ToString().Trim() + "\"></div>";
                    straxihua2 += "<p class=\"name ellipsis mgt-5\">" + yydr.Tables[0].Rows[i]["title"].ToString() + "</p>";
                    straxihua2 += "</a></li>";
                }
                straxihua2 += "</ul><div class=\"wrapper3 cl\"><i class=\"item-4s fl\"><hr></i></div>";
            }
            //代金券
            DataSet gyfl = HXD.DBUtility.SQLHelper.ExecuteDataset("select * from tb_U_Info where ClassId=498 and IsStatus=1 order by sort desc");
            if (gyfl.Tables[0].Rows.Count > 0)
            {
                straxihua2 += "<section class=\"yead_editor\">";
                straxihua2 += "<section class=\"mar\"><span class=\"yead_title2\">代金券</span></section>";
                straxihua2 += "</section>";
                straxihua2 += "<ul class=\"listc list1c clc \">";
                for (int i = 0; i < gyfl.Tables[0].Rows.Count; i++)
                {
                    straxihua2 += "<li class=\"item item-3\">";
                    straxihua2 += "<a class=\"pics\" href=\"" + gyfl.Tables[0].Rows[i]["url"].ToString() + "\">";
                    straxihua2 += "<div class=\"img default-img\"><img src=\"" + gyfl.Tables[0].Rows[i]["photo"].ToString().Trim() + "\"></div>";
                    straxihua2 += "<p class=\"name ellipsis mgt-5\">" + gyfl.Tables[0].Rows[i]["title"].ToString() + "</p>";
                    straxihua2 += "</a></li>";
                }
                straxihua2 += "</ul><div class=\"wrapper3 cl\"><i class=\"item-4s fl\"><hr></i></div>";
            }

            straxihua2 = mp3html1 + strbwg + straxihua2;

            #endregion

            #region 攻略
            try
            {
                string bsql = "select top 1 classid from tb_U_xinxi where Mp3id=" + id;
                int bs_idd = 0;
                DataSet dggg = HXD.DBUtility.SQLHelper.ExecuteDataset(bsql);
                if (dggg.Tables[0].Rows.Count > 0)
                {
                    bs_idd = int.Parse(dggg.Tables[0].Rows[0][0].ToString());
                }
                if (bs_idd == 151)
                {
                    #region 固定模板攻略
                    string gl1 = "select distinct bs_id from tb_U_xinxi where Mp3id=" + id;
                    DataSet dgl = HXD.DBUtility.SQLHelper.ExecuteDataset(gl1);
                    if (dgl.Tables[0].Rows.Count > 0)
                    {
                        chakan = "<a class=\"btn btn-default btn-open fr\" href=\"#readpage\" id=\"readpage\">查看攻略</a>";
                        for (int i = 0; i < dgl.Tables[0].Rows.Count; i++)
                        {
                            int bsid = 0;
                            bsid = int.Parse(dgl.Tables[0].Rows[i]["bs_id"].ToString().Trim());
                            switch (bsid)
                            {
                                case 1://概况
                                    string bsid1 = "select top 1 note from tb_U_xinxi where Mp3id=" + id + " and Bsid=1";
                                    string str = HXD.DBUtility.SQLHelper.ExecuteScalar(bsid1).ToString();
                                    gl += "<section class=\"wrapper\">";
                                    gl += "<h1 class=\"title\">概况</h1>";
                                    gl += "<div class=\"pic \"><img src=\"http://geliefofm.com/images/gl_gk.jpg\" alt=\"概况\"/></div>";
                                    gl += "</section>";
                                    gl += "<section class=\"else\">";
                                    gl += "<div class=\"content\">";
                                    gl += "  <ul class=\"item_box\">";
                                    gl += "<li class=\"\" ><div class=\"profile info\"></div><div class=\"content\">" + str + "";
                                    gl += "</div></li></ul></div></section>";
                                    break;

                                case 2://景点

                                    gl += "<section class=\"wrapper \" id='travel-spots'>";
                                    gl += "<h1 class=\"title\">景点</h1>";
                                    gl += "</section> ";

                                    string bsid2 = "select * from tb_U_xinxi where Mp3id=" + id + " and Bsid=2";
                                    DataSet bs2 = HXD.DBUtility.SQLHelper.ExecuteDataset(bsid2);
                                    for (int b = 0; b < bs2.Tables[0].Rows.Count; b++)
                                    {
                                        gl += "<section class=\"wrapper nopad\">";
                                        gl += "<div class=\"pic \"><img src=\"http://geliefofm.com/" + bs2.Tables[0].Rows[b]["Phote"].ToString() + "\"/></div>";
                                        gl += "</section>";
                                        gl += "<section class=\"else\">";
                                        gl += "<div class=\"wrapper3 cl\">";
                                        gl += "<i class=\"item-4 fl\"><hr></i><i class=\"item-2 fl\"><h2 class=\"title\">" + bs2.Tables[0].Rows[b]["title"].ToString() + "</h2></i><i class=\"item-4 fl\"><hr></i></div>";
                                        gl += "<div class=\"content\"><ul class=\"item_box\">";
                                        gl += "<li class=\"\" ><div class=\"profile info\"></div><div class=\"content\">" + bs2.Tables[0].Rows[b]["note"].ToString() + "</div></li>";
                                        if (bs2.Tables[0].Rows[b]["tell"].ToString() != "")
                                        {
                                            gl += "<li class=\"border-bottom\"><a href=\"tel:" + bs2.Tables[0].Rows[b]["tell"].ToString() + "\"><div class=\"profile tel\"></div><div class=\"content\">电话：" + bs2.Tables[0].Rows[b]["tell"].ToString() + "</div></a></li>";
                                        }
                                        if (bs2.Tables[0].Rows[b]["address"].ToString() != "")
                                        {
                                            gl += "<li class=\"border-bottom\"><div class=\"profile address\"></div><div class=\"content\">地址：" + bs2.Tables[0].Rows[b]["address"].ToString() + "</div></li>";
                                        }
                                        if (bs2.Tables[0].Rows[b]["menpiao"].ToString() != "")
                                        {
                                            gl += " <li class=\"border-bottom\"><div class=\"profile ticket\"></div><div class=\"content\">门票价格：" + bs2.Tables[0].Rows[b]["menpiao"].ToString() + " </div></li>";
                                        }
                                        if (bs2.Tables[0].Rows[b]["kftime"].ToString() != "")
                                        {
                                            gl += "<li class=\"border-bottom\"><div class=\"profile time\"></div><div class=\"content\">开放时间：" + bs2.Tables[0].Rows[b]["kftime"].ToString() + "</div></li>";
                                        }
                                        if (bs2.Tables[0].Rows[b]["jiaotong"].ToString() != "")
                                        {
                                            gl += "<li ><div class=\"profile traffic\"></div><div class=\"content\">到达方式：" + bs2.Tables[0].Rows[b]["jiaotong"].ToString() + "</div></li>";
                                        }
                                        gl += "</ul></div></section>";

                                    }

                                    break;

                                case 3://美食

                                    gl += "<section class=\"wrapper \" id='travel-spots'>";
                                    gl += "<h1 class=\"title\">美食</h1>";
                                    gl += "</section> ";

                                    string bsid3 = "select * from tb_U_xinxi where Mp3id=" + id + " and Bsid=3";
                                    DataSet bs3 = HXD.DBUtility.SQLHelper.ExecuteDataset(bsid3);
                                    for (int b = 0; b < bs3.Tables[0].Rows.Count; b++)
                                    {
                                        gl += "<section class=\"wrapper nopad\">";
                                        gl += "<div class=\"pic \"><img src=\"http://geliefofm.com/" + bs3.Tables[0].Rows[b]["Phote"].ToString() + "\"/></div>";
                                        gl += "</section>";
                                        gl += "<section class=\"else\">";
                                        gl += "<div class=\"wrapper3 cl\">";
                                        gl += "<i class=\"item-4 fl\"><hr></i><i class=\"item-2 fl\"><h2 class=\"title\">" + bs3.Tables[0].Rows[b]["title"].ToString() + "</h2></i><i class=\"item-4 fl\"><hr></i></div>";
                                        gl += "<div class=\"content\"><ul class=\"item_box\">";
                                        gl += "<li class=\"\" ><div class=\"profile info\"></div><div class=\"content\">" + bs3.Tables[0].Rows[b]["note"].ToString() + "</div></li>";
                                        if (bs3.Tables[0].Rows[b]["tell"].ToString() != "")
                                        {
                                            gl += "<li class=\"border-bottom\"><a href=\"tel:" + bs3.Tables[0].Rows[b]["tell"].ToString() + "\"><div class=\"profile tel\"></div><div class=\"content\">电话：" + bs3.Tables[0].Rows[b]["tell"].ToString() + "</div></a></li>";
                                        }
                                        if (bs3.Tables[0].Rows[b]["address"].ToString() != "")
                                        {
                                            gl += "<li class=\"border-bottom\"><div class=\"profile address\"></div><div class=\"content\">地址：" + bs3.Tables[0].Rows[b]["address"].ToString() + "</div></li>";
                                        }
                                        if (bs3.Tables[0].Rows[b]["menpiao"].ToString() != "")
                                        {
                                            gl += " <li class=\"border-bottom\"><div class=\"profile ticket\"></div><div class=\"content\">门票价格：" + bs3.Tables[0].Rows[b]["menpiao"].ToString() + " </div></li>";
                                        }
                                        if (bs3.Tables[0].Rows[b]["kftime"].ToString() != "")
                                        {
                                            gl += "<li class=\"border-bottom\"><div class=\"profile time\"></div><div class=\"content\">开放时间：" + bs3.Tables[0].Rows[b]["kftime"].ToString() + "</div></li>";
                                        }
                                        if (bs3.Tables[0].Rows[b]["jiaotong"].ToString() != "")
                                        {
                                            gl += "<li ><div class=\"profile traffic\"></div><div class=\"content\">到达方式：" + bs3.Tables[0].Rows[b]["jiaotong"].ToString() + "</div></li>";
                                        }
                                        gl += "</ul></div></section>";

                                    }
                                    break;

                                case 4://购物

                                    gl += "<section class=\"wrapper \" id='travel-spots'>";
                                    gl += "<h1 class=\"title\">购物</h1>";
                                    gl += "</section> ";

                                    string bsid4 = "select * from tb_U_xinxi where Mp3id=" + id + " and Bsid=4";
                                    DataSet bs4 = HXD.DBUtility.SQLHelper.ExecuteDataset(bsid4);
                                    for (int b = 0; b < bs4.Tables[0].Rows.Count; b++)
                                    {
                                        gl += "<section class=\"wrapper nopad\">";
                                        gl += "<div class=\"pic \"><img src=\"http://geliefofm.com/" + bs4.Tables[0].Rows[b]["Phote"].ToString() + "\"/></div>";
                                        gl += "</section>";
                                        gl += "<section class=\"else\">";
                                        gl += "<div class=\"wrapper3 cl\">";
                                        gl += "<i class=\"item-4 fl\"><hr></i><i class=\"item-2 fl\"><h2 class=\"title\">" + bs4.Tables[0].Rows[b]["title"].ToString() + "</h2></i><i class=\"item-4 fl\"><hr></i></div>";
                                        gl += "<div class=\"content\"><ul class=\"item_box\">";
                                        gl += "<li class=\"\" ><div class=\"profile info\"></div><div class=\"content\">" + bs4.Tables[0].Rows[b]["note"].ToString() + "</div></li>";
                                        if (bs4.Tables[0].Rows[b]["tell"].ToString() != "")
                                        {
                                            gl += "<li class=\"border-bottom\"><a href=\"tel:" + bs4.Tables[0].Rows[b]["tell"].ToString() + "\"><div class=\"profile tel\"></div><div class=\"content\">电话：" + bs4.Tables[0].Rows[b]["tell"].ToString() + "</div></a></li>";
                                        }
                                        if (bs4.Tables[0].Rows[b]["address"].ToString() != "")
                                        {
                                            gl += "<li class=\"border-bottom\"><div class=\"profile address\"></div><div class=\"content\">地址：" + bs4.Tables[0].Rows[b]["address"].ToString() + "</div></li>";
                                        }
                                        if (bs4.Tables[0].Rows[b]["menpiao"].ToString() != "")
                                        {
                                            gl += " <li class=\"border-bottom\"><div class=\"profile ticket\"></div><div class=\"content\">门票价格：" + bs4.Tables[0].Rows[b]["menpiao"].ToString() + " </div></li>";
                                        }
                                        if (bs4.Tables[0].Rows[b]["kftime"].ToString() != "")
                                        {
                                            gl += "<li class=\"border-bottom\"><div class=\"profile time\"></div><div class=\"content\">开放时间：" + bs4.Tables[0].Rows[b]["kftime"].ToString() + "</div></li>";
                                        }
                                        if (bs4.Tables[0].Rows[b]["jiaotong"].ToString() != "")
                                        {
                                            gl += "<li ><div class=\"profile traffic\"></div><div class=\"content\">到达方式：" + bs4.Tables[0].Rows[b]["jiaotong"].ToString() + "</div></li>";
                                        }
                                        gl += "</ul></div></section>";

                                    }
                                    break;

                                case 5://活动
                                    string bsid5 = "select top 1 note from tb_U_xinxi where Mp3id=" + id + " and Bsid=5";
                                    string str5 = HXD.DBUtility.SQLHelper.ExecuteScalar(bsid5).ToString();
                                    gl += "<section class=\"wrapper\">";
                                    gl += "<h1 class=\"title\">活动</h1>";
                                    gl += "<div class=\"pic \"><img src=\"http://geliefofm.com/images/gl_hd.jpg\" alt=\"活动\"/></div>";
                                    gl += "</section>";
                                    gl += "<section class=\"else\">";
                                    gl += "<div class=\"content\">";
                                    gl += "  <ul class=\"item_box\">";
                                    gl += "<li class=\"\" ><div class=\"profile info\"></div><div class=\"content\">" + str5 + "";
                                    gl += "</div></li></ul></div></section>";
                                    break;

                                case 6://交通
                                    gl += "<section class=\"wrapper \" >";
                                    gl += "    <h1 class=\"title\">交通</h1>";
                                    gl += "    <div class=\"pic \"><img src=\"http://geliefofm.com/images/gl_jt.jpg\" alt=\"交通\"/></div>";
                                    gl += "</section> ";
                                    string bsid6 = "select * from tb_U_xinxi where Mp3id=" + id + " and Bsid=6";
                                    DataSet bs6 = HXD.DBUtility.SQLHelper.ExecuteDataset(bsid6);
                                    for (int b = 0; b < bs6.Tables[0].Rows.Count; b++)
                                    {
                                        gl += "<section class=\"else\">";
                                        gl += " <div class=\"wrapper3 cl\">";
                                        gl += "   <i class=\"item-4 fl\"><hr></i>";
                                        gl += "   <i class=\"item-2 fl\"><h2 class=\"title\">" + bs6.Tables[0].Rows[b]["title"].ToString() + "</h2></i>";
                                        gl += "   <i class=\"item-4 fl\"><hr></i>";
                                        gl += " </div>";
                                        gl += " <div class=\"content\">";
                                        gl += "   <ul class=\"item_box\">";
                                        gl += "       <li class=\"\" ><div class=\"profile info\"></div><div class=\"content\">" + bs6.Tables[0].Rows[b]["note"].ToString() + "";
                                        gl += " </div></li></ul></div></section>";
                                    }

                                    break;

                                case 7://行前准备
                                    gl += "<section class=\"wrapper \" >";
                                    gl += "    <h1 class=\"title\">准备</h1>";
                                    gl += "    <div class=\"pic \"><img src=\"http://geliefofm.com/images/gl_xqzb.jpg\" alt=\"准备\"/></div>";
                                    gl += "</section> ";
                                    string bsid7 = "select * from tb_U_xinxi where Mp3id=" + id + " and Bsid=7";
                                    DataSet bs7 = HXD.DBUtility.SQLHelper.ExecuteDataset(bsid7);
                                    for (int b = 0; b < bs7.Tables[0].Rows.Count; b++)
                                    {
                                        gl += "<section class=\"else\">";
                                        gl += " <div class=\"wrapper3 cl\">";
                                        gl += "   <i class=\"item-4 fl\"><hr></i>";
                                        gl += "   <i class=\"item-2 fl\"><h2 class=\"title\">" + bs7.Tables[0].Rows[b]["title"].ToString() + "</h2></i>";
                                        gl += "   <i class=\"item-4 fl\"><hr></i>";
                                        gl += " </div>";
                                        gl += " <div class=\"content\">";
                                        gl += "   <ul class=\"item_box\">";
                                        gl += "       <li class=\"\" ><div class=\"profile info\"></div><div class=\"content\">" + bs7.Tables[0].Rows[b]["note"].ToString() + "";
                                        gl += " </div></li></ul></div></section>";
                                    }
                                    break;

                                case 8://安全贴士
                                    string bsid8 = "select top 1 note from tb_U_xinxi where Mp3id=" + id + " and Bsid=8";
                                    string str8 = HXD.DBUtility.SQLHelper.ExecuteScalar(bsid8).ToString();
                                    gl += "<section class=\"wrapper\">";
                                    gl += "<h1 class=\"title\">贴士</h1>";
                                    gl += "<div class=\"pic \"><img src=\"http://geliefofm.com/images/gl_ts.jpg\" alt=\"安全贴士\"/></div>";
                                    gl += "</section>";
                                    gl += "<section class=\"else\">";
                                    gl += "<div class=\"content\">";
                                    gl += "  <ul class=\"item_box\">";
                                    gl += "<li class=\"\" ><div class=\"profile info\"></div><div class=\"content\">" + str8 + "";
                                    gl += "</div></li></ul></div></section>";
                                    break;

                                case 9://住宿
                                    gl += "<section class=\"wrapper \" id='travel-spots'>";
                                    gl += "<h1 class=\"title\">住宿</h1>";
                                    gl += "</section> ";

                                    string bsid9 = "select * from tb_U_xinxi where Mp3id=" + id + " and Bsid=9";
                                    DataSet bs9 = HXD.DBUtility.SQLHelper.ExecuteDataset(bsid9);
                                    for (int b = 0; b < bs9.Tables[0].Rows.Count; b++)
                                    {
                                        gl += "<section class=\"wrapper nopad\">";
                                        gl += "<div class=\"pic \"><img src=\"http://geliefofm.com/" + bs9.Tables[0].Rows[b]["Phote"].ToString() + "\"/></div>";
                                        gl += "</section>";
                                        gl += "<section class=\"else\">";
                                        gl += "<div class=\"wrapper3 cl\">";
                                        gl += "<i class=\"item-4 fl\"><hr></i><i class=\"item-2 fl\"><h2 class=\"title\">" + bs9.Tables[0].Rows[b]["title"].ToString() + "</h2></i><i class=\"item-4 fl\"><hr></i></div>";
                                        gl += "<div class=\"content\"><ul class=\"item_box\">";
                                        gl += "<li class=\"\" ><div class=\"profile info\"></div><div class=\"content\">" + bs9.Tables[0].Rows[b]["note"].ToString() + "</div></li>";

                                        if (bs9.Tables[0].Rows[b]["address"].ToString() != "")
                                        {
                                            gl += "<li class=\"border-bottom\"><div class=\"profile address\"></div><div class=\"content\">地址：" + bs9.Tables[0].Rows[b]["address"].ToString() + "</div></li>";
                                        }
                                        if (bs9.Tables[0].Rows[b]["menpiao"].ToString() != "")
                                        {
                                            gl += " <li class=\"border-bottom\"><div class=\"profile ticket\"></div><div class=\"content\">门票价格：" + bs9.Tables[0].Rows[b]["menpiao"].ToString() + " </div></li>";
                                        }
                                        if (bs9.Tables[0].Rows[b]["kftime"].ToString() != "")
                                        {
                                            gl += "<li class=\"border-bottom\"><div class=\"profile time\"></div><div class=\"content\">开放时间：" + bs9.Tables[0].Rows[b]["kftime"].ToString() + "</div></li>";
                                        }
                                        if (bs9.Tables[0].Rows[b]["jiaotong"].ToString() != "")
                                        {
                                            gl += "<li ><div class=\"profile traffic\"></div><div class=\"content\">到达方式：" + bs9.Tables[0].Rows[b]["jiaotong"].ToString() + "</div></li>";
                                        }
                                        gl += "</ul></div></section>";
                                    }
                                    break;

                                case 10://其他
                                    gl += "<section class=\"wrapper\">";
                                    gl += "<h1 class=\"title\">准备</h1>";
                                    gl += "<div class=\"pic \"><img src=\"http://geliefofm.com/images/gl_xqzb.jpg\" alt=\"行前准备\"/></div>";
                                    gl += "</section>";
                                    break;

                            }


                        }
                    }
                    else
                    {
                        chakan = "";
                    }
                    #endregion
                }
                else if (bs_idd == 535)
                {
                    string bsid1 = "select title,content from tb_U_xinxi where Mp3id=" + id;
                    DataSet bsdl = HXD.DBUtility.SQLHelper.ExecuteDataset(bsid1);
                    if (bsdl.Tables[0].Rows.Count > 0)
                    {
                        chakan = "<a class=\"btn btn-default btn-open fr\" href=\"#readpage\" id=\"readpage\">查看攻略</a>";
                        gl += "<div class=\"content\">";
                        for (int ii = 0; ii < bsdl.Tables[0].Rows.Count; ii++)
                        {
                            gl += bsdl.Tables[0].Rows[ii]["content"].ToString().Trim();
                        }
                        gl += "</div>";
                    }
                    else
                    {
                        chakan = "";
                    }
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine("传递过来的异常值为：{0}", e);
            }
            //StringDeal.Alter(gl, "Create_html.aspx");

            #endregion

            #region 声音节点
            //HXD.Model.tb_U_Info mode = new HXD.Model.tb_U_Info();
            //HXD.SQLServerDAL.tb_U_Info dal = new HXD.SQLServerDAL.tb_U_Info();
            //mode = dal.GetModel(id);
            string mz_time = "", mjd_time = "", mms_time = "", mgw_time = "", mzb_time = "", modeTitle = "", modePhoto = "", modemp3 = "", modeInfoEditor = "", modeNote = "", modeU_id = "", modeId = "";
            string mp3sql = "select * from tb_U_Info where id="+id;
            DataSet mp3list = HXD.DBUtility.SQLHelper.ExecuteDataset(mp3sql);
            //modeTitle, modePhoto, modemp3, modeInfoEditor, modeNote, modeU_id, modeId
            modeTitle = mp3list.Tables[0].Rows[0]["title"].ToString();
            modePhoto = mp3list.Tables[0].Rows[0]["Photo"].ToString();
            modemp3 = mp3list.Tables[0].Rows[0]["mp3"].ToString();
            modeInfoEditor = mp3list.Tables[0].Rows[0]["InfoEditor"].ToString();
            modeNote = mp3list.Tables[0].Rows[0]["Note"].ToString();
            modeU_id = mp3list.Tables[0].Rows[0]["U_id"].ToString();
            modeId = mp3list.Tables[0].Rows[0]["id"].ToString();
            mz_time = mp3list.Tables[0].Rows[0]["z_time"].ToString();
            mjd_time = mp3list.Tables[0].Rows[0]["jd_time"].ToString();
            mms_time = mp3list.Tables[0].Rows[0]["ms_time"].ToString();
            mgw_time = mp3list.Tables[0].Rows[0]["gw_time"].ToString();
            mzb_time = mp3list.Tables[0].Rows[0]["zb_time"].ToString();

            if (mz_time != "")
            {
                mz_time = mz_time.Replace("：", ":");
                endtime = "00:" + mz_time;
                endtime = (TimeSpan.Parse(endtime).TotalSeconds).ToString();
            }
            else
            {
              
                    endtime = "1418";
               
            }
            //{ \"title\": \"准备\", \"time\": 175, \"point\": \"10%\" }, { "title": "准备", "time": 501, "point": "20.54%" },
            //{ "title": "景点", "time": 768, "point": "45.9%" },
            //{ "title": "美食", "time": 1050, "point": "62.7%" },
            //{ "title": "购物", "time": 1360, "point": "81.2%" }
            //if (mjd_time != ""&& mjd_time!=null)
            //{
            //    mjd_time = "00:" + mjd_time;
            //    mjd_time = (TimeSpan.Parse(mjd_time).TotalSeconds).ToString();
            //    string p = ((double)double.Parse(mjd_time) / double.Parse(endtime)).ToString("P");
            //    timelist += ",{ \"title\": \"景点\", \"time\": " + mjd_time + ", \"point\": \"" + p + "\" }";
            //}
            //if (mms_time != ""&&mms_time !=null)
            //{
            //    mms_time = "00:" + mms_time;
            //    mms_time = (TimeSpan.Parse(mms_time).TotalSeconds).ToString();
            //    string p = ((double)double.Parse(mms_time) / double.Parse(endtime)).ToString("P");
            //    timelist += ",{ \"title\": \"美食\", \"time\": " + mms_time + ", \"point\": \"" + p + "\" }";
            //}
            //if (mgw_time != "" && mgw_time != null)
            //{
            //    mgw_time = "00:" + mgw_time;
            //    mgw_time = (TimeSpan.Parse(mgw_time).TotalSeconds).ToString();
            //    string p = ((double)double.Parse(mgw_time) / double.Parse(endtime)).ToString("P");
            //    timelist += ",{ \"title\": \"购物\", \"time\": " + mgw_time + ", \"point\": \"" + p + "\" }";
            //}
            //if (mzb_time != "" && mzb_time != null)
            //{
            //    mzb_time = "00:" + mzb_time;
            //    mzb_time = (TimeSpan.Parse(mzb_time).TotalSeconds).ToString();
            //    string p = ((double)double.Parse(mzb_time) / double.Parse(endtime)).ToString("P");
            //    timelist += ",{ \"title\": \"准备\", \"time\": " + mzb_time + ", \"point\": \"" + p + "\" }";
            //}
            //if (timelist != "")
            //{
            //    timelist = HXD.Common.StringDeal.CutString(timelist, 1);
            //}

            #endregion

            #region 生成静态页

            //string surl = "";
            string idd = id.ToString();
            string surl = idd.Remove(0, idd.Length - 1);


            string Athor = HXD.DBUtility.SQLHelper.ExecuteScalar("select name from tb_U_zhubo where Id=" + modeU_id).ToString();
            string[] str1 = new string[] { modeTitle, modePhoto, modemp3, Athor, modeInfoEditor, modeNote, straxihuan, straxihua2, endtime, modeU_id, modeId, gl, timelist, chakan, bbsurl.ToString(), surl };
            string[] str2 = new string[] { "[$Title$]", "[$bimage$]", "[$mp3$]", "[$zhubo$]", "[$zhuanji$]", "[$jianjie$]", "[$xihuan$]", "[$xihuan2$]", "[$endtime$]", "[$zhuboid$]", "[$SID$]", "[$gl$]", "[$timelist$]", "[$chakan$]", "[$bbsurl$]", "[$countryid$]" };//"[$ID$]"
            string[] str3 = new string[] { modeTitle, modePhoto, modemp3, Athor, modeInfoEditor, modeNote, straxihuan, straxihua3, endtime, modeU_id, modeId, gl, timelist, chakan, bbsurl.ToString(), surl };

            HXD.Common.HtmlDal.CreatHtmlPage(str1, str2, "~/Template/audio2.html", Web.Model.PublicModel.HTMLPath + id + ".html");
            HXD.Common.HtmlDal.CreatHtmlPage(str3, str2, "~/Template/audio_bc.html", "~/bc/" + id + ".html");
            HXD.Common.HtmlDal.CreatHtmlPage(str3, str2, "~/Template/audio_leyou.html", "~/leyou/" + id + ".html");
            HXD.Common.HtmlDal.CreatHtmlPage(str3, str2, "~/Template/audio_jd.html", "~/jd/" + id + ".html");
            HXD.Common.HtmlDal.CreatHtmlPage(str3, str2, "~/Template/7z_audio.html", "~/7zhou/" + id + ".html");

            #endregion
        }
        //匹配供应商logo
        public static string hao123(string str)
        {
            string sert = "";
            DataSet jd = HXD.DBUtility.SQLHelper.ExecuteDataset("select * from tb_U_Link where ClassId=575");//景点
             if (jd.Tables[0].Rows.Count > 0)
             {
                 for (int i = 0; i < jd.Tables[0].Rows.Count; i++)//bs2.Tables[0].Rows[b]["Phote"].ToString()
                 {
                     string url = jd.Tables[0].Rows[i]["linkurl"].ToString();
                     string name = jd.Tables[0].Rows[i]["sitename"].ToString();
                     string phot0 = jd.Tables[0].Rows[i]["photo"].ToString();

                     int index = str.IndexOf(url);
                     if (index > -1)
                     {
                         sert = phot0;
                     }
                 }
             }

             return sert;
        }

        /// <summary>
        /// 声音页面静态化（国家）
        /// </summary>
        public static void ToHtmlgongl(int id, string sid)
        {
            string straxihuan = "", straxihua2 = "", endtime = "", gl = "", z_time = "", timelist = "", chakan = "", cid = "";
            int bbsurl = 0;

            string fenlei = HXD.DBUtility.SQLHelper.ExecuteScalar("select classid from tb_U_Info where id=" + id).ToString(); //classid=50  苏梅岛
            string fenlei2 = HXD.DBUtility.SQLHelper.ExecuteScalar("select ToMenu from tb_Menu where id=" + fenlei).ToString();//国家分类ToMenu =68
            string fenlei3 = HXD.DBUtility.SQLHelper.ExecuteScalar("select ParentId from tb_Menu where id=" + fenlei2).ToString();//
            #region 声音

            DataSet jd = HXD.DBUtility.SQLHelper.ExecuteDataset("select * from tb_U_Info where ClassId in(select id from tb_Menu where ToMenu='" + sid + "') and id not in(" + id + ") and IsStatus=1 and IsHot=0");//景点
            if (jd.Tables[0].Rows.Count > 0)
            {
                straxihua2 += "<section class=\"yead_editor\">";
                straxihua2 += "<section class=\"mar\"><span class=\"yead_title\">相关推荐</span></section>";
                straxihua2 += "</section>";
                straxihua2 += "<ul class=\"listc list1c clc \">";
                for (int i = 0; i < jd.Tables[0].Rows.Count; i++)//bs2.Tables[0].Rows[b]["Phote"].ToString()
                {
                    straxihua2 += "<li class=\"item item-3\">";
                    straxihua2 += "<a class=\"pics\" href=\"../sound/" + jd.Tables[0].Rows[i]["id"].ToString() + ".html\">";
                    straxihua2 += "<div class=\"img default-img\"><img src=\"" + HXD.Common.Utils.PhotoIco(jd.Tables[0].Rows[i]["photo"].ToString().Trim()) + "\"></div>";
                    straxihua2 += "<p class=\"name ellipsis mgt-5\">" + jd.Tables[0].Rows[i]["title"].ToString() + "</p>";
                    straxihua2 += "</a></li>";
                }
                straxihua2 += "</ul><div class=\"wrapper3 cl\"><i class=\"item-4s fl\"><hr></i></div>";
            }




            //国家
            DataSet coun = HXD.DBUtility.SQLHelper.ExecuteDataset("select * from tb_U_Info where IsHot=1 and classid in(select id from tb_Menu where ToMenu in(select id from tb_Menu where ParentId='" + sid + "'))");
            if (coun.Tables[0].Rows.Count > 0)
            {
                straxihua2 += "<section class=\"yead_editor\">";
                straxihua2 += "<section class=\"mar\"><span class=\"yead_title\">猜你喜欢</span></section>";
                straxihua2 += "</section>";
                straxihua2 += "<ul class=\"listc list1c clc \">";
                for (int i = 0; i < coun.Tables[0].Rows.Count; i++)
                {
                    straxihua2 += "<li class=\"item item-3\">";
                    straxihua2 += "<a class=\"pics\" href=\"../sound/" + coun.Tables[0].Rows[i]["id"].ToString() + ".html\">";
                    straxihua2 += "<div class=\"img default-img\"><img src=\"" + HXD.Common.Utils.PhotoIco(coun.Tables[0].Rows[i]["photo"].ToString().Trim()) + "\"></div>";
                    straxihua2 += "<p class=\"name ellipsis mgt-5\">" + coun.Tables[0].Rows[i]["title"].ToString() + "</p>";
                    straxihua2 += "</a></li>";
                }
                straxihua2 += "</ul><div class=\"wrapper3 cl\"><i class=\"item-4s fl\"><hr></i></div>";
            }
            //达人列表
            DataSet dr2 = HXD.DBUtility.SQLHelper.ExecuteDataset("select * from tb_U_Info where p_gl=520 and ClassId in(select id from tb_Menu where ToMenu=" + fenlei2 + ")and IsStatus=0 and IsHot=1");
            if (dr2.Tables[0].Rows.Count > 0)
            {
                straxihua2 += "<section class=\"yead_editor\">";
                straxihua2 += "<section class=\"mar\"><span class=\"yead_title\">推荐达人</span></section>";
                straxihua2 += "</section>";
                straxihua2 += "<ul class=\"listc list1c clc \">";
                for (int i = 0; i < dr2.Tables[0].Rows.Count; i++)
                {
                    straxihua2 += "<li class=\"item item-3\">";
                    straxihua2 += "<a class=\"pics\" href=\" " + dr2.Tables[0].Rows[i]["Title1"].ToString() + "\">";
                    straxihua2 += "<div class=\"img default-img\"><img src=\"" + dr2.Tables[0].Rows[i]["photo"].ToString().Trim() + "\"></div>";
                    straxihua2 += "<p class=\"name ellipsis mgt-5\">" + dr2.Tables[0].Rows[i]["title"].ToString() + "</p>";
                    straxihua2 += "</a></li>";
                }
                straxihua2 += "</ul><div class=\"wrapper3 cl\"><i class=\"item-4s fl\"><hr></i></div>";
            }
            //格友福利
            DataSet gyfl = HXD.DBUtility.SQLHelper.ExecuteDataset("select * from tb_U_Info where ClassId=498 and IsStatus=1");
            if (gyfl.Tables[0].Rows.Count > 0)
            {
                straxihua2 += "<section class=\"yead_editor\">";
                straxihua2 += "<section class=\"mar\"><span class=\"yead_title\">格友福利</span></section>";
                straxihua2 += "</section>";
                straxihua2 += "<ul class=\"listc list1c clc \">";
                for (int i = 0; i < gyfl.Tables[0].Rows.Count; i++)
                {
                    straxihua2 += "<li class=\"item item-3\">";
                    straxihua2 += "<a class=\"pics\" href=\" " + gyfl.Tables[0].Rows[i]["url"].ToString() + "\">";
                    straxihua2 += "<div class=\"img default-img\"><img src=\"" + HXD.Common.Utils.PhotoIco(gyfl.Tables[0].Rows[i]["photo"].ToString().Trim()) + "\"></div>";
                    straxihua2 += "<p class=\"name ellipsis mgt-5\">" + gyfl.Tables[0].Rows[i]["title"].ToString() + "</p>";
                    straxihua2 += "</a></li>";
                }
                straxihua2 += "</ul><div class=\"wrapper3 cl\"><i class=\"item-4s fl\"><hr></i></div>";
            }
            #endregion

            #region 攻略
            string bsql = "select top 1 classid from tb_U_xinxi where Mp3id=" + id;
            int bs_idd = 0;
            try
            {
                 bs_idd = int.Parse(HXD.DBUtility.SQLHelper.ExecuteScalar(bsql).ToString());
            }
            catch
            {
                bs_idd = 0;
            }
            if (bs_idd == 151)
            {
                #region 固定模板攻略
                string gl1 = "select distinct bsid from tb_U_xinxi where Mp3id=" + id;
                DataSet dgl = HXD.DBUtility.SQLHelper.ExecuteDataset(gl1);
                if (dgl.Tables[0].Rows.Count > 0)
                {
                    chakan = "<a class=\"btn btn-default btn-open fr\" href=\"#readpage\" id=\"readpage\">查看攻略</a>";
                    for (int i = 0; i < dgl.Tables[0].Rows.Count; i++)
                    {
                        int bsid = 0;
                        bsid = int.Parse(dgl.Tables[0].Rows[i]["bsid"].ToString().Trim());
                        switch (bsid)
                        {
                            case 1://概况
                                string bsid1 = "select * from tb_U_xinxi where Mp3id=" + id + " and bsid=1";
                                string str = HXD.DBUtility.SQLHelper.ExecuteScalar(bsid1).ToString();
                                gl += "<section class=\"wrapper\">";
                                gl += "<h1 class=\"title\">概况</h1>";
                                gl += "<div class=\"pic \"><img src=\"http://geliefofm.com/images/gl_gk.jpg\" alt=\"概况\"/></div>";
                                gl += "</section>";
                                gl += "<section class=\"else\">";
                                gl += "<div class=\"content\">";
                                gl += "  <ul class=\"item_box\">";
                                gl += "<li class=\"\" ><div class=\"profile info\"></div><div class=\"content\">" + str + "";
                                gl += "</div></li></ul></div></section>";
                                break;

                            case 2://景点

                                gl += "<section class=\"wrapper \" id='travel-spots'>";
                                gl += "<h1 class=\"title\">景点</h1>";
                                gl += "</section> ";

                                string bsid2 = "select * from tb_U_xinxi where Mp3id=" + id + " and Bsid=2";
                                DataSet bs2 = HXD.DBUtility.SQLHelper.ExecuteDataset(bsid2);
                                for (int b = 0; b < bs2.Tables[0].Rows.Count; b++)
                                {
                                    gl += "<section class=\"wrapper nopad\">";
                                    gl += "<div class=\"pic \"><img src=\"http://geliefofm.com/" + bs2.Tables[0].Rows[b]["Phote"].ToString() + "\"/></div>";
                                    gl += "</section>";
                                    gl += "<section class=\"else\">";
                                    gl += "<div class=\"wrapper3 cl\">";
                                    gl += "<i class=\"item-4 fl\"><hr></i><i class=\"item-2 fl\"><h2 class=\"title\">" + bs2.Tables[0].Rows[b]["title"].ToString() + "</h2></i><i class=\"item-4 fl\"><hr></i></div>";
                                    gl += "<div class=\"content\"><ul class=\"item_box\">";
                                    gl += "<li class=\"\" ><div class=\"profile info\"></div><div class=\"content\">" + bs2.Tables[0].Rows[b]["note"].ToString() + "</div></li>";
                                    if (bs2.Tables[0].Rows[b]["tell"].ToString() != "")
                                    {
                                        gl += "<li class=\"border-bottom\"><a href=\"tel:" + bs2.Tables[0].Rows[b]["tell"].ToString() + "\"><div class=\"profile tel\"></div><div class=\"content\">电话：" + bs2.Tables[0].Rows[b]["tell"].ToString() + "</div></a></li>";
                                    }
                                    if (bs2.Tables[0].Rows[b]["address"].ToString() != "")
                                    {
                                        gl += "<li class=\"border-bottom\"><div class=\"profile address\"></div><div class=\"content\">地址：" + bs2.Tables[0].Rows[b]["address"].ToString() + "</div></li>";
                                    }
                                    if (bs2.Tables[0].Rows[b]["menpiao"].ToString() != "")
                                    {
                                        gl += " <li class=\"border-bottom\"><div class=\"profile ticket\"></div><div class=\"content\">门票价格：" + bs2.Tables[0].Rows[b]["menpiao"].ToString() + " </div></li>";
                                    }
                                    if (bs2.Tables[0].Rows[b]["kftime"].ToString() != "")
                                    {
                                        gl += "<li class=\"border-bottom\"><div class=\"profile time\"></div><div class=\"content\">开放时间：" + bs2.Tables[0].Rows[b]["kftime"].ToString() + "</div></li>";
                                    }
                                    if (bs2.Tables[0].Rows[b]["jiaotong"].ToString() != "")
                                    {
                                        gl += "<li ><div class=\"profile traffic\"></div><div class=\"content\">到达方式：" + bs2.Tables[0].Rows[b]["jiaotong"].ToString() + "</div></li>";
                                    }
                                    gl += "</ul></div></section>";

                                }

                                break;

                            case 3://美食

                                gl += "<section class=\"wrapper \" id='travel-spots'>";
                                gl += "<h1 class=\"title\">美食</h1>";
                                gl += "</section> ";

                                string bsid3 = "select * from tb_U_xinxi where Mp3id=" + id + " and Bsid=3";
                                DataSet bs3 = HXD.DBUtility.SQLHelper.ExecuteDataset(bsid3);
                                for (int b = 0; b < bs3.Tables[0].Rows.Count; b++)
                                {
                                    gl += "<section class=\"wrapper nopad\">";
                                    gl += "<div class=\"pic \"><img src=\"http://geliefofm.com/" + bs3.Tables[0].Rows[b]["Phote"].ToString() + "\"/></div>";
                                    gl += "</section>";
                                    gl += "<section class=\"else\">";
                                    gl += "<div class=\"wrapper3 cl\">";
                                    gl += "<i class=\"item-4 fl\"><hr></i><i class=\"item-2 fl\"><h2 class=\"title\">" + bs3.Tables[0].Rows[b]["title"].ToString() + "</h2></i><i class=\"item-4 fl\"><hr></i></div>";
                                    gl += "<div class=\"content\"><ul class=\"item_box\">";
                                    gl += "<li class=\"\" ><div class=\"profile info\"></div><div class=\"content\">" + bs3.Tables[0].Rows[b]["note"].ToString() + "</div></li>";
                                    if (bs3.Tables[0].Rows[b]["tell"].ToString() != "")
                                    {
                                        gl += "<li class=\"border-bottom\"><a href=\"tel:" + bs3.Tables[0].Rows[b]["tell"].ToString() + "\"><div class=\"profile tel\"></div><div class=\"content\">电话：" + bs3.Tables[0].Rows[b]["tell"].ToString() + "</div></a></li>";
                                    }
                                    if (bs3.Tables[0].Rows[b]["address"].ToString() != "")
                                    {
                                        gl += "<li class=\"border-bottom\"><div class=\"profile address\"></div><div class=\"content\">地址：" + bs3.Tables[0].Rows[b]["address"].ToString() + "</div></li>";
                                    }
                                    if (bs3.Tables[0].Rows[b]["menpiao"].ToString() != "")
                                    {
                                        gl += " <li class=\"border-bottom\"><div class=\"profile ticket\"></div><div class=\"content\">门票价格：" + bs3.Tables[0].Rows[b]["menpiao"].ToString() + " </div></li>";
                                    }
                                    if (bs3.Tables[0].Rows[b]["kftime"].ToString() != "")
                                    {
                                        gl += "<li class=\"border-bottom\"><div class=\"profile time\"></div><div class=\"content\">开放时间：" + bs3.Tables[0].Rows[b]["kftime"].ToString() + "</div></li>";
                                    }
                                    if (bs3.Tables[0].Rows[b]["jiaotong"].ToString() != "")
                                    {
                                        gl += "<li ><div class=\"profile traffic\"></div><div class=\"content\">到达方式：" + bs3.Tables[0].Rows[b]["jiaotong"].ToString() + "</div></li>";
                                    }
                                    gl += "</ul></div></section>";

                                }
                                break;

                            case 4://购物

                                gl += "<section class=\"wrapper \" id='travel-spots'>";
                                gl += "<h1 class=\"title\">购物</h1>";
                                gl += "</section> ";

                                string bsid4 = "select * from tb_U_xinxi where Mp3id=" + id + " and Bsid=4";
                                DataSet bs4 = HXD.DBUtility.SQLHelper.ExecuteDataset(bsid4);
                                for (int b = 0; b < bs4.Tables[0].Rows.Count; b++)
                                {
                                    gl += "<section class=\"wrapper nopad\">";
                                    gl += "<div class=\"pic \"><img src=\"http://geliefofm.com/" + bs4.Tables[0].Rows[b]["Phote"].ToString() + "\"/></div>";
                                    gl += "</section>";
                                    gl += "<section class=\"else\">";
                                    gl += "<div class=\"wrapper3 cl\">";
                                    gl += "<i class=\"item-4 fl\"><hr></i><i class=\"item-2 fl\"><h2 class=\"title\">" + bs4.Tables[0].Rows[b]["title"].ToString() + "</h2></i><i class=\"item-4 fl\"><hr></i></div>";
                                    gl += "<div class=\"content\"><ul class=\"item_box\">";
                                    gl += "<li class=\"\" ><div class=\"profile info\"></div><div class=\"content\">" + bs4.Tables[0].Rows[b]["note"].ToString() + "</div></li>";
                                    if (bs4.Tables[0].Rows[b]["tell"].ToString() != "")
                                    {
                                        gl += "<li class=\"border-bottom\"><a href=\"tel:" + bs4.Tables[0].Rows[b]["tell"].ToString() + "\"><div class=\"profile tel\"></div><div class=\"content\">电话：" + bs4.Tables[0].Rows[b]["tell"].ToString() + "</div></a></li>";
                                    }
                                    if (bs4.Tables[0].Rows[b]["address"].ToString() != "")
                                    {
                                        gl += "<li class=\"border-bottom\"><div class=\"profile address\"></div><div class=\"content\">地址：" + bs4.Tables[0].Rows[b]["address"].ToString() + "</div></li>";
                                    }
                                    if (bs4.Tables[0].Rows[b]["menpiao"].ToString() != "")
                                    {
                                        gl += " <li class=\"border-bottom\"><div class=\"profile ticket\"></div><div class=\"content\">门票价格：" + bs4.Tables[0].Rows[b]["menpiao"].ToString() + " </div></li>";
                                    }
                                    if (bs4.Tables[0].Rows[b]["kftime"].ToString() != "")
                                    {
                                        gl += "<li class=\"border-bottom\"><div class=\"profile time\"></div><div class=\"content\">开放时间：" + bs4.Tables[0].Rows[b]["kftime"].ToString() + "</div></li>";
                                    }
                                    if (bs4.Tables[0].Rows[b]["jiaotong"].ToString() != "")
                                    {
                                        gl += "<li ><div class=\"profile traffic\"></div><div class=\"content\">到达方式：" + bs4.Tables[0].Rows[b]["jiaotong"].ToString() + "</div></li>";
                                    }
                                    gl += "</ul></div></section>";

                                }
                                break;

                            case 5://活动
                                string bsid5 = "select top 1 note from tb_U_xinxi where Mp3id=" + id + " and Bsid=5";
                                string str5 = HXD.DBUtility.SQLHelper.ExecuteScalar(bsid5).ToString();
                                gl += "<section class=\"wrapper\">";
                                gl += "<h1 class=\"title\">活动</h1>";
                                gl += "<div class=\"pic \"><img src=\"http://geliefofm.com/images/gl_hd.jpg\" alt=\"活动\"/></div>";
                                gl += "</section>";
                                gl += "<section class=\"else\">";
                                gl += "<div class=\"content\">";
                                gl += "  <ul class=\"item_box\">";
                                gl += "<li class=\"\" ><div class=\"profile info\"></div><div class=\"content\">" + str5 + "";
                                gl += "</div></li></ul></div></section>";
                                break;

                            case 6://交通
                                gl += "<section class=\"wrapper \" >";
                                gl += "    <h1 class=\"title\">交通</h1>";
                                gl += "    <div class=\"pic \"><img src=\"http://geliefofm.com/images/gl_jt.jpg\" alt=\"交通\"/></div>";
                                gl += "</section> ";
                                string bsid6 = "select * from tb_U_xinxi where Mp3id=" + id + " and Bsid=6";
                                DataSet bs6 = HXD.DBUtility.SQLHelper.ExecuteDataset(bsid6);
                                for (int b = 0; b < bs6.Tables[0].Rows.Count; b++)
                                {
                                    gl += "<section class=\"else\">";
                                    gl += " <div class=\"wrapper3 cl\">";
                                    gl += "   <i class=\"item-4 fl\"><hr></i>";
                                    gl += "   <i class=\"item-2 fl\"><h2 class=\"title\">" + bs6.Tables[0].Rows[b]["title"].ToString() + "</h2></i>";
                                    gl += "   <i class=\"item-4 fl\"><hr></i>";
                                    gl += " </div>";
                                    gl += " <div class=\"content\">";
                                    gl += "   <ul class=\"item_box\">";
                                    gl += "       <li class=\"\" ><div class=\"profile info\"></div><div class=\"content\">" + bs6.Tables[0].Rows[b]["note"].ToString() + "";
                                    gl += " </div></li></ul></div></section>";
                                }

                                break;

                            case 7://行前准备
                                gl += "<section class=\"wrapper \" >";
                                gl += "    <h1 class=\"title\">准备</h1>";
                                gl += "    <div class=\"pic \"><img src=\"http://geliefofm.com/images/gl_xqzb.jpg\" alt=\"准备\"/></div>";
                                gl += "</section> ";
                                string bsid7 = "select * from tb_U_xinxi where Mp3id=" + id + " and Bsid=7";
                                DataSet bs7 = HXD.DBUtility.SQLHelper.ExecuteDataset(bsid7);
                                for (int b = 0; b < bs7.Tables[0].Rows.Count; b++)
                                {
                                    gl += "<section class=\"else\">";
                                    gl += " <div class=\"wrapper3 cl\">";
                                    gl += "   <i class=\"item-4 fl\"><hr></i>";
                                    gl += "   <i class=\"item-2 fl\"><h2 class=\"title\">" + bs7.Tables[0].Rows[b]["title"].ToString() + "</h2></i>";
                                    gl += "   <i class=\"item-4 fl\"><hr></i>";
                                    gl += " </div>";
                                    gl += " <div class=\"content\">";
                                    gl += "   <ul class=\"item_box\">";
                                    gl += "       <li class=\"\" ><div class=\"profile info\"></div><div class=\"content\">" + bs7.Tables[0].Rows[b]["note"].ToString() + "";
                                    gl += " </div></li></ul></div></section>";
                                }
                                break;

                            case 8://安全贴士
                                string bsid8 = "select top 1 note from tb_U_xinxi where Mp3id=" + id + " and Bsid=8";
                                string str8 = HXD.DBUtility.SQLHelper.ExecuteScalar(bsid8).ToString();
                                gl += "<section class=\"wrapper\">";
                                gl += "<h1 class=\"title\">贴士</h1>";
                                gl += "<div class=\"pic \"><img src=\"http://geliefofm.com/images/gl_ts.jpg\" alt=\"安全贴士\"/></div>";
                                gl += "</section>";
                                gl += "<section class=\"else\">";
                                gl += "<div class=\"content\">";
                                gl += "  <ul class=\"item_box\">";
                                gl += "<li class=\"\" ><div class=\"profile info\"></div><div class=\"content\">" + str8 + "";
                                gl += "</div></li></ul></div></section>";
                                break;

                            case 9://住宿
                                gl += "<section class=\"wrapper \" id='travel-spots'>";
                                gl += "<h1 class=\"title\">住宿</h1>";
                                gl += "</section> ";

                                string bsid9 = "select * from tb_U_xinxi where Mp3id=" + id + " and Bsid=9";
                                DataSet bs9 = HXD.DBUtility.SQLHelper.ExecuteDataset(bsid9);
                                for (int b = 0; b < bs9.Tables[0].Rows.Count; b++)
                                {
                                    gl += "<section class=\"wrapper nopad\">";
                                    gl += "<div class=\"pic \"><img src=\"http://geliefofm.com/" + bs9.Tables[0].Rows[b]["Phote"].ToString() + "\"/></div>";
                                    gl += "</section>";
                                    gl += "<section class=\"else\">";
                                    gl += "<div class=\"wrapper3 cl\">";
                                    gl += "<i class=\"item-4 fl\"><hr></i><i class=\"item-2 fl\"><h2 class=\"title\">" + bs9.Tables[0].Rows[b]["title"].ToString() + "</h2></i><i class=\"item-4 fl\"><hr></i></div>";
                                    gl += "<div class=\"content\"><ul class=\"item_box\">";
                                    gl += "<li class=\"\" ><div class=\"profile info\"></div><div class=\"content\">" + bs9.Tables[0].Rows[b]["note"].ToString() + "</div></li>";

                                    if (bs9.Tables[0].Rows[b]["address"].ToString() != "")
                                    {
                                        gl += "<li class=\"border-bottom\"><div class=\"profile address\"></div><div class=\"content\">地址：" + bs9.Tables[0].Rows[b]["address"].ToString() + "</div></li>";
                                    }
                                    if (bs9.Tables[0].Rows[b]["menpiao"].ToString() != "")
                                    {
                                        gl += " <li class=\"border-bottom\"><div class=\"profile ticket\"></div><div class=\"content\">门票价格：" + bs9.Tables[0].Rows[b]["menpiao"].ToString() + " </div></li>";
                                    }
                                    if (bs9.Tables[0].Rows[b]["kftime"].ToString() != "")
                                    {
                                        gl += "<li class=\"border-bottom\"><div class=\"profile time\"></div><div class=\"content\">开放时间：" + bs9.Tables[0].Rows[b]["kftime"].ToString() + "</div></li>";
                                    }
                                    if (bs9.Tables[0].Rows[b]["jiaotong"].ToString() != "")
                                    {
                                        gl += "<li ><div class=\"profile traffic\"></div><div class=\"content\">到达方式：" + bs9.Tables[0].Rows[b]["jiaotong"].ToString() + "</div></li>";
                                    }
                                    gl += "</ul></div></section>";
                                }
                                break;

                            case 10://其他
                                gl += "<section class=\"wrapper\">";
                                gl += "<h1 class=\"title\">准备</h1>";
                                gl += "<div class=\"pic \"><img src=\"http://geliefofm.com/images/gl_xqzb.jpg\" alt=\"行前准备\"/></div>";
                                gl += "</section>";
                                break;

                        }


                    }
                }
                else
                {
                    chakan = "";
                }
                  #endregion
            }  
            else if (bs_idd == 535)
            {

               string bsid1 = "select title,content from tb_U_xinxi where Mp3id=" + id;
               DataSet bsdl = HXD.DBUtility.SQLHelper.ExecuteDataset(bsid1);
               if (bsdl.Tables[0].Rows.Count > 0)
               {
                   chakan = "<a class=\"btn btn-default btn-open fr\" href=\"#readpage\" id=\"readpage\">查看攻略</a>";
                   gl += "<div class=\"content\">";
                   for (int ii = 0; ii < bsdl.Tables[0].Rows.Count; ii++)
                   {
                       gl += bsdl.Tables[0].Rows[ii]["content"].ToString().Trim();
                   }
                   gl += "</div>";
               }
               else
               {
                   chakan = "";
               }
             }
            //StringDeal.Alter(gl, "Create_html.aspx");

            #endregion
            
            #region 声音节点

            string mz_time = "", mjd_time = "", mms_time = "", mgw_time = "", mzb_time = "", modeTitle = "", modePhoto = "", modemp3 = "", modeInfoEditor = "", modeNote = "", modeU_id = "", modeId = "";
            string mp3sql = "select * from tb_U_Info where id=" + id;
            DataSet mp3list = HXD.DBUtility.SQLHelper.ExecuteDataset(mp3sql);
            modeTitle = mp3list.Tables[0].Rows[0]["title"].ToString();
            modePhoto = mp3list.Tables[0].Rows[0]["Photo"].ToString();
            modemp3 = mp3list.Tables[0].Rows[0]["mp3"].ToString();
            modeInfoEditor = mp3list.Tables[0].Rows[0]["InfoEditor"].ToString();
            modeNote = mp3list.Tables[0].Rows[0]["Note"].ToString();
            modeU_id = mp3list.Tables[0].Rows[0]["U_id"].ToString();
            modeId = mp3list.Tables[0].Rows[0]["id"].ToString();
            mz_time = mp3list.Tables[0].Rows[0]["z_time"].ToString();
            mjd_time = mp3list.Tables[0].Rows[0]["jd_time"].ToString();
            mms_time = mp3list.Tables[0].Rows[0]["ms_time"].ToString();
            mgw_time = mp3list.Tables[0].Rows[0]["gw_time"].ToString();
            mzb_time = mp3list.Tables[0].Rows[0]["zb_time"].ToString();

            if (mz_time != "")
            {
                endtime = "00:" + mz_time;
                endtime = (TimeSpan.Parse(endtime).TotalSeconds).ToString();
            }
            else
            {

                endtime = "1418";

            }

            //if (mjd_time != "")
            //{
            //    mjd_time = "00:" + mjd_time;
            //    mjd_time = (TimeSpan.Parse(mjd_time).TotalSeconds).ToString();
            //    string p = ((double)double.Parse(mjd_time) / double.Parse(endtime)).ToString("P");
            //    timelist += ",{ \"title\": \"景点\", \"time\": " + mjd_time + ", \"point\": \"" + p + "\" }";
            //}
            //if (mms_time != "")
            //{
            //    mms_time = "00:" + mms_time;
            //    mms_time = (TimeSpan.Parse(mms_time).TotalSeconds).ToString();
            //    string p = ((double)double.Parse(mms_time) / double.Parse(endtime)).ToString("P");
            //    timelist += ",{ \"title\": \"美食\", \"time\": " + mms_time + ", \"point\": \"" + p + "\" }";
            //}
            //if (mgw_time != "")
            //{
            //    mgw_time = "00:" + mgw_time;
            //    mgw_time = (TimeSpan.Parse(mgw_time).TotalSeconds).ToString();
            //    string p = ((double)double.Parse(mgw_time) / double.Parse(endtime)).ToString("P");
            //    timelist += ",{ \"title\": \"购物\", \"time\": " + mgw_time + ", \"point\": \"" + p + "\" }";
            //}
            //if (mzb_time != "")
            //{
            //    mzb_time = "00:" + mzb_time;
            //    mzb_time = (TimeSpan.Parse(mzb_time).TotalSeconds).ToString();
            //    string p = ((double)double.Parse(mzb_time) / double.Parse(endtime)).ToString("P");
            //    timelist += ",{ \"title\": \"准备\", \"time\": " + mzb_time + ", \"point\": \"" + p + "\" }";
            //}
            //if (timelist != "")
            //{
            //    timelist = HXD.Common.StringDeal.CutString(timelist, 1);
            //}

            #endregion

            #region 生成静态页
            string idd = id.ToString();
            string surl = idd.Remove(0, idd.Length - 1);

            string Athor = HXD.DBUtility.SQLHelper.ExecuteScalar("select name from tb_U_zhubo where Id=" + modeU_id).ToString();
            string[] str1 = new string[] { modeTitle, modePhoto, modemp3, Athor, modeInfoEditor, modeNote, straxihuan, straxihua2, endtime, modeU_id, modeId, gl, timelist, chakan, bbsurl.ToString(), surl };
            string[] str2 = new string[] { "[$Title$]", "[$bimage$]", "[$mp3$]", "[$zhubo$]", "[$zhuanji$]", "[$jianjie$]", "[$xihuan$]", "[$xihuan2$]", "[$endtime$]", "[$zhuboid$]", "[$SID$]", "[$gl$]", "[$timelist$]", "[$chakan$]", "[$bbsurl$]", "[$countryid$]" };//"[$ID$]"

            HXD.Common.HtmlDal.CreatHtmlPage(str1, str2, "~/Template/audio2.html", Web.Model.PublicModel.HTMLPath + id + ".html");


            #endregion
        }

         /// <summary>
        /// 首页静态化
        /// </summary>
        public static void ToHtmlindex()
        {
            string Repeater1 = "", Repeater2 = "", Repeater3 = "", Repeater4 = "";
            string img_content = "";

            //首页图片轮换
            string strSqlzd1 = "select top 6 * from tb_U_Advertisement where ClassId=104 and IsStatus=1 order by Sort desc ";
            DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(strSqlzd1);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (i == 0)
                {
                    img_content += "{&quot;id&quot;:1,&quot;short_title&quot;:&quot;1&quot;,&quot;long_title&quot;:&quot;1&quot;,&quot;pic&quot;:&quot;" + ds.Tables[0].Rows[i]["Photo"].ToString() + "&quot;,&quot;type&quot;:3,&quot;track_id&quot;:1,&quot;uid&quot;:&quot;" + ds.Tables[0].Rows[i]["href"].ToString() + "&quot;}";
                }
                else
                {
                    img_content += ",{&quot;id&quot;:1,&quot;short_title&quot;:&quot;1&quot;,&quot;long_title&quot;:&quot;1&quot;,&quot;pic&quot;:&quot;" + ds.Tables[0].Rows[i]["Photo"].ToString() + "&quot;,&quot;type&quot;:3,&quot;track_id&quot;:1,&quot;uid&quot;:&quot;" + ds.Tables[0].Rows[i]["href"].ToString() + "&quot;}";
                }
            }
            //最新资讯
            DataSet ds1 = HXD.DBUtility.SQLHelper.ExecuteDataset("select top 4 * from tb_U_Info where  IsStatus=1 order by id desc");
            for (int ii = 0; ii < ds1.Tables[0].Rows.Count; ii++)
            {



                Repeater1 += "<li class=\"item item-4\">";
                Repeater1 += "<a class=\"inner\" href=\"sound/" + ds1.Tables[0].Rows[ii]["id"].ToString().Trim() + ".html\">";
                Repeater1 += "<div class=\"pic\">";
                Repeater1 += "<img onerror=\"this.style.display=&quot;none&quot;;\" data-original=\"" + HXD.Common.Utils.PhotoIco(ds1.Tables[0].Rows[ii]["photo"].ToString()).Trim() + "\" alt=\"\"></div>";
                Repeater1 += "<div class=\"info\"><p class=\"name\">" + HXD.Common.StringDeal.Substrings1(ds1.Tables[0].Rows[ii]["title"].ToString().Trim(), 24) + "</p></div>";
                Repeater1 += "</a></li>";

            }
            //推荐攻略
            DataSet ds2 = HXD.DBUtility.SQLHelper.ExecuteDataset("select top 4 * from tb_U_Info where IsElite=1 and IsStatus=1 order by Sort desc,id desc");
            for (int ii2 = 0; ii2 < ds2.Tables[0].Rows.Count; ii2++)
            {
                Repeater2 += "<li class=\"item item-4\">";
                Repeater2 += "<a class=\"inner\" href=\"sound/" + ds2.Tables[0].Rows[ii2]["id"].ToString().Trim() + ".html\">";
                Repeater2 += "<div class=\"pic\">";
                Repeater2 += "<img onerror=\"this.style.display=&quot;none&quot;;\" data-original=\"" + HXD.Common.Utils.PhotoIco(ds2.Tables[0].Rows[ii2]["photo"].ToString()).Trim() + "\" alt=\"\"></div>";
                Repeater2 += "<div class=\"info\"><p class=\"name\">" + HXD.Common.StringDeal.Substrings1(ds2.Tables[0].Rows[ii2]["title"].ToString().Trim(), 24) + "</p></div>";
                Repeater2 += "</a></li>";
            }

            DataSet ds3 = HXD.DBUtility.SQLHelper.ExecuteDataset("select top 4 * from tb_U_Info where p_gl=47 and IsStatus=1 order by f_leibie desc,id desc");
            for (int ii3 = 0; ii3 < ds3.Tables[0].Rows.Count; ii3++)
            {
                Repeater3 += "<li class=\"item item-4\">";
                Repeater3 += "<a class=\"inner\" href=\"sound/" + ds3.Tables[0].Rows[ii3]["id"].ToString().Trim() + ".html\">";
                Repeater3 += "<div class=\"pic\">";
                Repeater3 += "<img onerror=\"this.style.display=&quot;none&quot;;\" data-original=\"" + HXD.Common.Utils.PhotoIco(ds3.Tables[0].Rows[ii3]["photo"].ToString()).Trim() + "\" alt=\"\"></div>";
                Repeater3 += "<div class=\"info\"><p class=\"name\">" + HXD.Common.StringDeal.Substrings1(ds3.Tables[0].Rows[ii3]["title"].ToString().Trim(), 24) + "</p></div>";
                Repeater3 += "</a></li>";
            }
            //趣旅行
            DataSet ds4 = HXD.DBUtility.SQLHelper.ExecuteDataset("select top 4 * from tb_U_Info where p_gl=289 and IsStatus=1 order by f_leibie desc,id desc");
            for (int ii4 = 0; ii4 < ds4.Tables[0].Rows.Count; ii4++)
            {
                Repeater4 += "<li class=\"item item-4\">";
                Repeater4 += "<a class=\"inner\" href=\"sound/" + ds4.Tables[0].Rows[ii4]["id"].ToString().Trim() + ".html\">";
                Repeater4 += "<div class=\"pic\">";
                Repeater4 += "<img onerror=\"this.style.display=&quot;none&quot;;\" data-original=\"" + HXD.Common.Utils.PhotoIco(ds4.Tables[0].Rows[ii4]["photo"].ToString()).Trim() + "\" alt=\"\"></div>";
                Repeater4 += "<div class=\"info\"><p class=\"name\">" + HXD.Common.StringDeal.Substrings1(ds4.Tables[0].Rows[ii4]["title"].ToString().Trim(), 24) + "</p></div>";
                Repeater4 += "</a></li>";
            }



            #region 生成静态页
            //string str3 = string.Empty;//分页文件的名称
            //string yuefen = System.DateTime.Now.ToString("yyyMMdd") + "/";//获取月份并且生成文件夹
            //HXD.Common.HtmlDal.FolderCreate(HttpContext.Current.Server.MapPath(Web.Model.PublicModel.HTMLPath + yuefen));//新建文件夹



            string[] str1 = new string[] { img_content, Repeater1, Repeater2, Repeater3, Repeater4 };
            string[] str2 = new string[] { "[$img_content$]", "[$Repeater1$]", "[$Repeater2$]", "[$Repeater3$]", "[$Repeater4$]" };//"[$ID$]"

            HXD.Common.HtmlDal.CreatHtmlPage(str1, str2, "~/Template/Html_index.html", "~/index.html");


            #endregion
        }
       
    }
}
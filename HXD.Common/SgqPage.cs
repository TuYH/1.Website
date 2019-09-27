using System;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;

namespace HXD.Common
{
    public class SgqPage
    {
        /// <summary>
        /// 数据总页数
        /// </summary>
        private int PageCount;

        /// <summary>
        /// 数据总数
        /// </summary>
        public int RecordCount;

        /// <summary>
        /// 每页显示数据数
        /// </summary>
        public int PageSize;

        /// <summary>
        /// 当前页
        /// </summary>
        public int PageIndex;

        /// <summary>
        /// DataTable数据源
        /// </summary>
        public DataTable dt;

        /// <summary>
        /// 分页数据操作
        /// </summary>
        /// <returns></returns>
        public PagedDataSource DataSource()
        {
            PagedDataSource Pds = new PagedDataSource();
            Pds.AllowPaging = true;
            Pds.PageSize = PageSize;
            Pds.DataSource = dt.DefaultView;
            PageIndex = ((PageIndex < 1) ? 1 : PageIndex);
            RecordCount = Pds.DataSourceCount;
            PageCount = Pds.PageCount;
            Pds.CurrentPageIndex = PageIndex - 1;
            return Pds;
        }

        /// <summary>
        /// 分页样式1(带数据操作的分页)
        /// </summary>
        /// <returns></returns>
        public string PageView1()
        {
            if (RecordCount % PageSize == 0)
            {
                PageCount = RecordCount / PageSize;
            }
            else
            {
                PageCount = (RecordCount / PageSize) + 1;
            }
            if (PageIndex == 0)
            {
                PageIndex = 1;
            }
            int fromPage, toPage;
            string temp = "";
            int pages = PageCount;
            if (pages <= 10)
            {
                fromPage = 1;
                toPage = pages;
            }
            else
            {
                if (PageIndex <= 3 && pages - PageIndex >= 8)
                {
                    fromPage = 1;
                    toPage = 10;
                }
                else if (PageIndex > 3 && pages - PageIndex < 8)
                {
                    fromPage = pages - 9;
                    toPage = pages;
                }
                else
                {
                    fromPage = PageIndex - 2;
                    toPage = PageIndex + 7;
                }
            }
            
            #region 首 页
            temp += "<div id=\"page\">";
            if (PageIndex != 1)
            {
                temp += "<a href='" + PageUrl() + "Page=1' style='width:40px;'>首页</a><span class=\"s1 s3\">&lt;&lt;</span>";
            }
            else
            {
                temp += "<span class=\"s1 s3\">首页</span><span class=\"s1 s3\">&lt;&lt;</span> ";
            }
            #endregion
            #region 上一页
            if (PageIndex > 1)
            {
                temp += "<a href='" + PageUrl() + "Page=" + Convert.ToString(PageIndex - 1) + "' style='width:40px;'>上一页</a> ";
            }
            else
            {
                temp += "<span class=\"s1 s3\">上一页</span> ";
            }
            for (int i = fromPage; i <= toPage; i++)
            {
                if (i != PageIndex)
                {
                    temp = temp + "<a href=" + PageUrl() + "Page=" + i + ">" + i + "</a> ";
                }
                else
                {
                    temp = temp + "<span>" + i + "</span> ";
                }
            }
            #endregion
            #region 下一页
            if (PageIndex < PageCount)
            {
                temp += "<a href='" + PageUrl() + "Page=" + Convert.ToString(PageIndex + 1) + "' style='width:40px;'>下一页</a> <span class=\"s1 s3\">&gt;&gt;</span> ";
            }
            else
            {
                temp += "<a style='width:40px;'>下一页</a> <span class=\"s1 s3\">&gt;&gt;</span> ";
            }
            #endregion
            #region 尾 页
            if (PageIndex != PageCount)
            {
                temp += "<a href='" + PageUrl() + "Page=" + Convert.ToString(PageCount) + "' style='width:40px;'>末页</a> ";
            }
            else
            {
                temp += "<a style='width:40px;'>末页</a> ";
            }
            temp += "</div>";
            #endregion
            return temp;
        }

        /// <summary>
        /// 分页样式2(纯分页)
        /// </summary>
        /// <returns></returns>
        public string PageView2()
        {
            if (RecordCount % PageSize == 0)
            {
                PageCount = RecordCount / PageSize;
            }
            else
            {
                PageCount = (RecordCount / PageSize) + 1;
            }
            if (PageIndex == 0)
            {
                PageIndex = 1;
            }
		
            int fromPage, toPage;
            string temp = "";
            int pages = PageCount;
            if (pages <= 10)
            {
                fromPage = 1;
                toPage = pages;
            }
            else
            {
                if (PageIndex <= 3 && pages - PageIndex >= 8)
                {
                    fromPage = 1;
                    toPage = 10;
                }
                else if (PageIndex > 3 && pages - PageIndex < 8)
                {
                    fromPage = pages - 9;
                    toPage = pages;
                }
                else
                {
                    fromPage = PageIndex - 2;
                    toPage = PageIndex + 7;
                }
            }

            #region 首 页
            temp += "<ul class=\"am-pagination tpl-pagination\">";
            if (PageIndex != 1)
            {
                temp += "<li class=\"am-disabled\"><a href='" + PageUrl() + "Page=1' >«</a></li> ";
            }
            else
            {
                temp += "<li class=\"am-disabled\"><a href=\"#\">«</a></li>";
            }
            #endregion
            #region 上一页
           
            for (int i = fromPage; i <= toPage; i++)
            {
                if (i != PageIndex)
                {
                    temp = temp + "<li class=\"am-active\"><a href=" + PageUrl() + "Page=" + i + ">" + i + "</a></li> ";
                    
                }
                else
                {
                    temp = temp + "<li><a href=\"#\">" + i + "</a></li> ";
                }
            }
            #endregion
           
            #region 尾 页
            if (PageIndex != PageCount)
            {
                temp += "<li><a href='" + PageUrl() + "Page=" + Convert.ToString(PageCount) + "' >»</a></li> ";
            }
            else
            {
                temp += "<li><a >»</a> </li>";
            }
            temp += "</ul>";
            #endregion
            return temp;
        }

        /// <summary>
        /// 分页样式3(纯分页)
        /// </summary>
        /// <returns></returns>
        public string PageView3()
        {
            if (RecordCount % PageSize == 0)
            {
                PageCount = RecordCount / PageSize;
            }
            else
            {
                PageCount = (RecordCount / PageSize) + 1;
            }
            if (PageIndex == 0)
            {
                PageIndex = 1;
            }

            int fromPage, toPage;
            string temp = "";
            int pages = PageCount;
            if (pages <= 10)
            {
                fromPage = 1;
                toPage = pages;
            }
            else
            {
                if (PageIndex <= 3 && pages - PageIndex >= 8)
                {
                    fromPage = 1;
                    toPage = 10;
                }
                else if (PageIndex > 3 && pages - PageIndex < 8)
                {
                    fromPage = pages - 9;
                    toPage = pages;
                }
                else
                {
                    fromPage = PageIndex - 2;
                    toPage = PageIndex + 7;
                }
            }

            #region 首 页
            temp += "<div class='fenye'>";
            temp += "共有 " + RecordCount + " 条数据 当前第 <b>" + PageIndex + "</b>/" + PageCount + " 页 每页显示 " + PageSize + " 条 ";
            if (PageIndex != 1)
            {
                temp += "<a href='" + PageUrl() + "Page=1' style='width:40px;'>首页</a> ";
            }
            else
            {
                temp += "<a style='width:40px;'>首页</a> ";
            }
            #endregion
            #region 上一页
            if (PageIndex > 1)
            {
                temp += " <a href='" + PageUrl() + "Page=" + Convert.ToString(PageIndex - 1) + "' style='width:40px;'>上页</a> ";
            }
            else
            {
                temp += "<a style='width:40px;'>上页</a> ";
            }
            for (int i = fromPage; i <= toPage; i++)
            {
                if (i != PageIndex)
                {
                    temp = temp + "<a href=" + PageUrl() + "Page=" + i + ">" + i + "</a> ";
                }
                else
                {
                    temp = temp + "<span>" + i + "</span> ";
                }
            }
            #endregion
            #region 下一页
            if (PageIndex < PageCount)
            {
                temp += "<a href='" + PageUrl() + "Page=" + Convert.ToString(PageIndex + 1) + "' style='width:40px;'>下页</a> ";
            }
            else
            {
                temp += "<a style='width:40px;'>下页</a> ";
            }
            #endregion
            #region 尾 页
            if (PageIndex != PageCount)
            {
                temp += "<a href='" + PageUrl() + "Page=" + Convert.ToString(PageCount) + "' style='width:40px;'>尾页</a> ";
            }
            else
            {
                temp += "<a style='width:40px;'>尾页</a> ";
            }
            
            #endregion
            temp += "<select name=\"Topage\" onchange=\"window.location='" + PageUrl() + "Page='+this.value\">";
            for (int i = 1; i <= PageCount; i++)
            {
                temp += "<option value=\""+i+"\" "+(PageIndex==i?"Selected":"")+">"+i+"</option>";
            }
            temp += "</select>";

                temp += "</div>";
            return temp;
        }


        /// <summary>
        /// 分页样式3(纯分页)
        /// </summary>
        /// <returns></returns>
        public string PageView4()
        {
            if (RecordCount % PageSize == 0)
            {
                PageCount = RecordCount / PageSize;
            }
            else
            {
                PageCount = (RecordCount / PageSize) + 1;
            }
            if (PageIndex == 0)
            {
                PageIndex = 1;
            }

            int fromPage, toPage;
            string temp = "";
            int pages = PageCount;
            if (pages <= 10)
            {
                fromPage = 1;
                toPage = pages;
            }
            else
            {
                if (PageIndex <= 3 && pages - PageIndex >= 8)
                {
                    fromPage = 1;
                    toPage = 10;
                }
                else if (PageIndex > 3 && pages - PageIndex < 8)
                {
                    fromPage = pages - 9;
                    toPage = pages;
                }
                else
                {
                    fromPage = PageIndex - 2;
                    toPage = PageIndex + 7;
                }
            }

            #region 首 页
            temp += "<div class='fenye'>";
            temp += "共有 " + RecordCount + " 条数据 当前第 <b>" + PageIndex + "</b>/" + PageCount + " 页 每页显示 " + PageSize + " 条 ";
            if (PageIndex != 1)
            {
                temp += "<a href='" + PageUrl() + "Page=1' style='width:40px;'>首页</a> ";
            }
            else
            {
                temp += "<a style='width:40px;'>首页</a> ";
            }
            #endregion
            #region 上一页
            if (PageIndex > 1)
            {
                temp += " <a href='" + PageUrl() + "Page=" + Convert.ToString(PageIndex - 1) + "' style='width:40px;'>上页</a> ";
            }
            else
            {
                temp += "<a style='width:40px;'>上页</a> ";
            }
            for (int i = fromPage; i <= toPage; i++)
            {
                if (i != PageIndex)
                {
                    temp = temp + "<a href=" + PageUrl() + "Page=" + i + ">" + i + "</a> ";
                }
                else
                {
                    temp = temp + "<span>" + i + "</span> ";
                }
            }
            #endregion
            #region 下一页
            if (PageIndex < PageCount)
            {
                temp += "<a href='" + PageUrl() + "Page=" + Convert.ToString(PageIndex + 1) + "' style='width:40px;'>下页</a> ";
            }
            else
            {
                temp += "<a style='width:40px;'>下页</a> ";
            }
            #endregion
            #region 尾 页
            if (PageIndex != PageCount)
            {
                temp += "<a href='" + PageUrl() + "Page=" + Convert.ToString(PageCount) + "' style='width:40px;'>尾页</a> ";
            }
            else
            {
                temp += "<a style='width:40px;'>尾页</a> ";
            }

            #endregion
            temp += "<input type=\"text\" id=\"gotopage\" size=\"2\" value=\"" + PageIndex + "\" /> ";
            temp += "<a href=\"javascript:void(null);\" onclick=\"if(!Number(document.getElementById('gotopage').value)){alert('请输入数字！');}else{if(Number(document.getElementById('gotopage').value)>" + PageCount + "){alert('输入的数字过大！');}else{window.location='" + PageUrl() + "Page='+document.getElementById('gotopage').value;}}\">转向</a>";

            temp += "</div>";
            return temp;
        }

        #region 获得当前地址及参数
        /// <summary>
        /// 获得当前地址及参数
        /// </summary>
        /// <returns>返回地址及参数</returns>
        public string PageUrl()
        {
            string[] a, query;
            string UrlLast = "", Url;
            Url = "http://" + System.Web.HttpContext.Current.Request.ServerVariables["HTTP_HOST"] + System.Web.HttpContext.Current.Request.ServerVariables["SCRIPT_NAME"];
            query = System.Web.HttpContext.Current.Request.ServerVariables["QUERY_STRING"].Split('&');
            Url = Url.Replace("<", "").Replace(">", "");
            foreach (string x in query)
            {
                a = x.Split('=');
                if (!a[0].Equals("Page"))
                {
                    try
                    {
                        UrlLast = UrlLast + a[0] + "=" + a[1] + "&";
                    }
                    catch
                    {
                        UrlLast = "";
                    }
                }
            }
            if (!String.IsNullOrEmpty(UrlLast))
                UrlLast = UrlLast.Replace("<", "").Replace(">", "");
            return Url + "?" + UrlLast;
        }
        protected string PageUrl(int n)
        {
            string[] a, query;
            string UrlLast = "", Url;
            Url = "http://" + System.Web.HttpContext.Current.Request.ServerVariables["HTTP_HOST"] + System.Web.HttpContext.Current.Request.ServerVariables["SCRIPT_NAME"];
            query = System.Web.HttpContext.Current.Request.ServerVariables["QUERY_STRING"].Split('&');
            Url = Url.Replace("<", "").Replace(">", "");
            foreach (string x in query)
            {
                a = x.Split('=');
                if (!a[0].Equals("Page"))
                {
                    try
                    {
                        UrlLast = UrlLast + a[0] + "=" + a[1] + "&";
                    }
                    catch
                    {
                        UrlLast = "";
                    }
                }
            }
            if (!String.IsNullOrEmpty(UrlLast))
                UrlLast = UrlLast.Replace("<", "").Replace(">", "");
            return UrlLast;
        }
        #endregion
    }
}

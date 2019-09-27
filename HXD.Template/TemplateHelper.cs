using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Text.RegularExpressions;
using System.Data;
using System.Web;

namespace HXD.Template
{
    public class TemplateHelper
    {
        public int MenuId;
        public int ModelId;

        public string templacefile = "";

        //<HXD:a></HXD:a>格式
        string regexStr = @"<HXD:(\w*)(.*?)\>([\S\s]*?)</HXD:\1\s*>";
        public Regex cmsRegex;

        //<HXD:a/>格式
        string regexFieldStr = @"\<HXD:(\w*)(.*?)/\>";
        public Regex cmsFieldRegex;

        string regexVariableStr = @"(@@\w*)\b*";
        public Regex cmsVariableRegex;

        public TemplateHelper()
        {
            cmsRegex = new Regex(regexStr, RegexOptions.IgnoreCase);
            cmsFieldRegex = new Regex(regexFieldStr, RegexOptions.IgnoreCase);
            cmsVariableRegex = new Regex(regexVariableStr, RegexOptions.IgnoreCase);
        }

        //替换
        /// <summary>
        /// 替换
        /// </summary>
        /// <param name="templatefilepath">模板路径</param>
        /// <returns></returns>
        public string ReplaceTemplate(string templatefilepath)
        {
            templacefile = templatefilepath;
            //读取文件
            string tempbody = System.IO.File.ReadAllText(templacefile, System.Text.Encoding.Default);
            //替换标签并返回
            tempbody = cmsRegex.Replace(tempbody, new MatchEvaluator(CMSreplaceTag));
            tempbody = cmsFieldRegex.Replace(tempbody, new MatchEvaluator(CMSreplaceFieldTag));
            return tempbody;
        }

        /// <summary>
        /// 替换
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public string CMSreplaceTag(Match match)
        {
            System.Text.StringBuilder retstr = new System.Text.StringBuilder("");


            return retstr.ToString();
        }

        /// <summary>
        /// 替换
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public string CMSreplaceFieldTag(Match match)
        {
            System.Text.StringBuilder retstr = new System.Text.StringBuilder("");


            return retstr.ToString();
        }

    }
}

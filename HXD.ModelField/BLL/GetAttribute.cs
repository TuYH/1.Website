using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Data;
using HXD.Model;
using HXD.Common;

namespace HXD.ModelField.BLL
{
    public class GetAttribute
    {
        /// <summary>
        /// 字段类型
        /// </summary>
        public string FieldType;
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName;
        /// <summary>
        /// 字段名
        /// </summary>
        public string Field;
        /// <summary>
        /// XML对象
        /// </summary>
        private XmlDoc xml;
        /// <summary>
        /// DataTable对象
        /// </summary>
        private DataTable dt;
        /// <summary>
        /// 根据字段类型，显示此类型所需要配置的信息项
        /// </summary>
        public DataSet dsList;
        /// <summary>
        /// 根据字段类型，显示此类型所需要配置的信息项
        /// </summary>
        public void Attribute()
        {
            if (!String.IsNullOrEmpty(Field))
            {
                xml = new XmlDoc();
                xml.xmlfilePath = "../../App_Data/TableXml/" + TableName + ".xml";
                dt = xml.GetDataTable("Type='" + FieldType + "' and Name='" + Field + "'", "");
            }
            switch (FieldType)
            {
                case "SingleLine":
                    SingleLineType();
                    break;
                case "Password":
                    PasswordType();
                    break;
                case "MultiLine":
                    MultiLineType();
                    break;
                case "Editor":
                    EditorType();
                    break;
                case "Select":
                    SelectType();
                    break;
                case "Number":
                    NumberType();
                    break;
                case "DateTime":
                    DateTimeType();
                    break;
                case "Image":
                    ImageType();
                    break;
                case "File":
                    FileType();
                    break;
                case "BatchImage":
                    BatchImageType();
                    break;
                case "BatchFile":
                    BatchFileType();
                    break;
                case "OtherMenu":
                    OtherMenuType();
                    break;
                case "Provinces":
                    ProvincesType();
                    break;
                case "Increment":
                    Increment();
                    break;
            }
        }

        /// <summary>
        /// 获取XML节点值
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        private string GetXmlValue(string Key)
        {
            if (!String.IsNullOrEmpty(Field))
            {
                return dt.Rows[0][Key].ToString();
            }
            else
            {
                return "";
            }
        }
        #region 配置字段属性信息项
        /// <summary>
        /// 单行文本
        /// </summary>
        private void SingleLineType()
        {
            HttpContext.Current.Response.Write("最大字符数：<input type='text' value='" + GetXmlValue("MaxLength") + "' class='input' size='5' maxlength='4' name='MaxLength'><br />");
            HttpContext.Current.Response.Write("文本框长度：<input type='text' value='" + GetXmlValue("Size") + "' class='input' size='5' maxlength='3' name='Size'><br />");
            HttpContext.Current.Response.Write("默　认　值：<input type='text' value='" + GetXmlValue("Field_Text") + "' class='input' size='30' maxlength='100' name='Default'>");
            ValidatorInfo();
        }
        /// <summary>
        /// 密码
        /// </summary>
        private void PasswordType()
        {
            HttpContext.Current.Response.Write("最大字符数：<input type='text' value='" + GetXmlValue("MaxLength") + "' class='input' size='5' maxlength='4' name='MaxLength'><br />");
            HttpContext.Current.Response.Write("文本框长度：<input type='text' value='" + GetXmlValue("Size") + "' class='input' size='5' maxlength='3' name='Size'><br />");
            HttpContext.Current.Response.Write("默　认　值：<input type='text' value='" + GetXmlValue("Field_Text") + "' class='input' size='30' maxlength='100' name='Default'><br />");
            HttpContext.Current.Response.Write("加&nbsp;&nbsp;&nbsp;&nbsp;密&nbsp;&nbsp;&nbsp;&nbsp;方&nbsp;&nbsp;&nbsp;&nbsp;式：<select name='PwdMode'><option value='0'" + StringDeal.GetSelected(GetXmlValue("PwdMode"), "0") + ">不加密</option><option value='MD5'" + StringDeal.GetSelected(GetXmlValue("PwdMode"), "MD5") + ">MD5加密</option><option value='DES'" + StringDeal.GetSelected(GetXmlValue("PwdMode"), "DES") + ">DES加密</option><option value='AES'" + StringDeal.GetSelected(GetXmlValue("PwdMode"), "AES") + ">AES加密</option></select>");
            ValidatorInfo();
        }
        /// <summary>
        /// 多行文本
        /// </summary>
        private void MultiLineType()
        {
            HttpContext.Current.Response.Write("显示的宽度：<input type='text' value='" + GetXmlValue("Width") + "' class='input' size='5' maxlength='3' name='Width'><br />");
            HttpContext.Current.Response.Write("显示的高度：<input type='text' value='" + GetXmlValue("Height") + "' class='input' size='5' maxlength='3' name='Height'><br />");
            HttpContext.Current.Response.Write("默　认　值：<textarea name='Default' cols='45' rows='5'>" + GetXmlValue("Field_Text") + "</textarea>");
            ValidatorInfo();
        }
        /// <summary>
        /// 编辑器
        /// </summary>
        private void EditorType()
        {
            HttpContext.Current.Response.Write("编辑器类型：<select name='EditorType'><option value='1'" + StringDeal.GetSelected(GetXmlValue("EditorType"), 1) + ">简洁版</option><option value='2'" + StringDeal.GetSelected(GetXmlValue("EditorType"), 2) + ">标准版</option><option value='3'" + StringDeal.GetSelected(GetXmlValue("EditorType"), 3) + ">高级版</option></select><br />");
            HttpContext.Current.Response.Write("显示的宽度：<input type='text' value='" + GetXmlValue("Width") + "' class='input' size='5' maxlength='3' name='Width'><br />");
            HttpContext.Current.Response.Write("显示的高度：<input type='text' value='" + GetXmlValue("Height") + "' class='input' size='5' maxlength='3' name='Height'><br />");
            HttpContext.Current.Response.Write("默　认　值：<textarea name='Default' cols='45' rows='5'>" + GetXmlValue("Field_Text") + "</textarea>");
            ValidatorInfo();
        }
        /// <summary>
        /// 选项（下拉、单选、多选）
        /// </summary>
        private void SelectType()
        {
            HttpContext.Current.Response.Write("每个选项：<br /><textarea name='Options' cols='45' rows='5' class=''>" + GetXmlValue("Options") + "</textarea><br />请输入选项名称，中间用回车分割开<br />");
            HttpContext.Current.Response.Write("选项类型：<input value='select' type='radio' name='OptionsType'" + StringDeal.GetChecked(GetXmlValue("OptionsType"), "select") + " />单选下拉列表框");
            HttpContext.Current.Response.Write("　<input value='radio' type='radio' name='OptionsType'" + StringDeal.GetChecked(GetXmlValue("OptionsType"), "radio") + " />单选按钮");
            HttpContext.Current.Response.Write("　<input value='checkbox' type='radio' name='OptionsType'" + StringDeal.GetChecked(GetXmlValue("OptionsType"), "checkbox") + " />复选框<br />");
            HttpContext.Current.Response.Write("默&nbsp;&nbsp;认&nbsp;&nbsp;值：<input type='text' value='" + GetXmlValue("Field_Text") + "' class='input' maxlength='100' name='Default'>");
            ValidatorInfo();
        }
        /// <summary>
        /// 数字
        /// </summary>
        private void NumberType()
        {
            HttpContext.Current.Response.Write("小数位数：<select name='Bit'><option value='0'" + StringDeal.GetSelected(GetXmlValue("Bit"), 0) + ">0</option><option value='1'" + StringDeal.GetSelected(GetXmlValue("Bit"), 1) + ">1</option><option value='2'" + StringDeal.GetSelected(GetXmlValue("Bit"), 2) + ">2</option><option value='3'" + StringDeal.GetSelected(GetXmlValue("Bit"), 3) + ">3</option><option value='4'" + StringDeal.GetSelected(GetXmlValue("Bit"), 4) + ">4</option><option value='5'" + StringDeal.GetSelected(GetXmlValue("Bit"), 5) + ">5</option></select><br />");
            HttpContext.Current.Response.Write("默&nbsp;&nbsp;认&nbsp;&nbsp;值：<input type='text' value='" + GetXmlValue("Field_Text") + "' class='input' maxlength='18' name='Default'>");
            ValidatorInfo();
        }
        /// <summary>
        /// 日期
        /// </summary>
        private void DateTimeType()
        {
            HttpContext.Current.Response.Write("格　　式：<input value='yyyy-mm-dd' type='radio' name='DateTime'" + StringDeal.GetChecked(GetXmlValue("DateTime"), "yyyy-mm-dd") + " />仅日期");
            HttpContext.Current.Response.Write("　<input value='yyyy-mm-dd hh:mm:ss' type='radio' name='DateTime'" + StringDeal.GetChecked(GetXmlValue("DateTime"), "yyyy-mm-dd hh:mm:ss") + " />日期和时间<br />");
            HttpContext.Current.Response.Write("默&nbsp;&nbsp;认&nbsp;&nbsp;值：<input type='text' value='" + GetXmlValue("Field_Text") + "' class='input' maxlength='20' name='Default'>选择日期/当前日期");
            ValidatorInfo();
        }
        /// <summary>
        /// 图片上传
        /// </summary>
        private void ImageType()
        {
            HttpContext.Current.Response.Write("默　认　值：<input type='text' value='" + GetXmlValue("Field_Text") + "' class='input' maxlength='200' name='Default'> 图片名称或地址,注：地址需带\"http://\"");
            ValidatorInfo();
        }
        /// <summary>
        /// 文件上传
        /// </summary>
        private void FileType()
        {
            HttpContext.Current.Response.Write("文件类型：<select name='UploadFileType'><option value='VideoType'" + StringDeal.GetSelected(GetXmlValue("UploadFileType"), "VideoType") + ">视频类型</option><option value='AudioType'" + StringDeal.GetSelected(GetXmlValue("UploadFileType"), "AudioType") + ">音频类型</option><option value='SoftType'" + StringDeal.GetSelected(GetXmlValue("UploadFileType"), "SoftType") + ">软件类型</option><option value='OtherType'" + StringDeal.GetSelected(GetXmlValue("UploadFileType"), "OtherType") + ">其他类型</option><option value=''" + StringDeal.GetSelected(GetXmlValue("UploadFileType"), "") + ">全部类型</option></select><br />");
            HttpContext.Current.Response.Write("默　认　值：<input type='text' value='" + GetXmlValue("Field_Text") + "' class='input' maxlength='200' name='Default'>标题,文件名称或地址");
            ValidatorInfo();
        }
        /// <summary>
        /// 批量图片上传
        /// </summary>
        private void BatchImageType()
        {
            HttpContext.Current.Response.Write("默　认　值：<input type='text' value='" + GetXmlValue("Field_Text") + "' class='input' maxlength='200' name='Default'> 图片名称或地址,注：地址需带\"http://\"");
            ValidatorInfo();
        }
        /// <summary>
        /// 批量文件上传
        /// </summary>
        private void BatchFileType()
        {
            HttpContext.Current.Response.Write("文件类型：<select name='UploadFileType'><option value='VideoType'" + StringDeal.GetSelected(GetXmlValue("UploadFileType"), "VideoType") + ">视频类型</option><option value='AudioType'" + StringDeal.GetSelected(GetXmlValue("UploadFileType"), "AudioType") + ">音频类型</option><option value='SoftType'" + StringDeal.GetSelected(GetXmlValue("UploadFileType"), "SoftType") + ">软件类型</option><option value='OtherType'" + StringDeal.GetSelected(GetXmlValue("UploadFileType"), "OtherType") + ">其他类型</option><option value=''" + StringDeal.GetSelected(GetXmlValue("UploadFileType"), "") + ">全部类型</option></select><br />");
            HttpContext.Current.Response.Write("默　认　值：<input type='text' value='" + GetXmlValue("Field_Text") + "' class='input' maxlength='200' name='Default'>标题,文件名称或地址");
            ValidatorInfo();
        }

        /// <summary>
        /// 二级联动菜单
        /// </summary>
        private void OtherMenuType()
        {
            HttpContext.Current.Response.Write("其他节点：<select name='MenuId'>");
            MenuList(0, "┣", GetXmlValue("MenuId"));
            HttpContext.Current.Response.Write("</select><br />");
            HttpContext.Current.Response.Write("默&nbsp;&nbsp;认&nbsp;&nbsp;值：<input type='text' value='" + GetXmlValue("Field_Text") + "' class='input' maxlength='18' name='Default'>");
            ValidatorInfo();
        }
        private void MenuList(int Id, string Separator, string MenuId)
        {

            DataView dv = new DataView(dsList.Tables[0]);
            dv.RowFilter = "ParentId = " + Id;
            foreach (DataRowView dr in dv)
            {
                HttpContext.Current.Response.Write("    <option value='" + dr["Id"] + "'" + StringDeal.GetSelected(dr["Id"], MenuId) + ">" + Separator + StringDeal.StrFormat(dr["Title"]) + "</option>");
                MenuList(StringDeal.ToInt(dr[0]), "┃" + Separator, MenuId);
            }
        }
        /// <summary>
        /// 城市联动
        /// </summary>
        private void ProvincesType()
        {
            HttpContext.Current.Response.Write("默认值：<input type='text' value='" + GetXmlValue("Field_Text") + "' class='input' maxlength='200' name='Default'>");
            ValidatorInfo();
        }
        /// <summary>
        /// 动态增加
        /// </summary>
        private void Increment()
        {
            HttpContext.Current.Response.Write("最大字符数：<input type='text' value='" + GetXmlValue("MaxLength") + "' class='input' size='5' maxlength='4' name='MaxLength'><br />");
            HttpContext.Current.Response.Write("文本框长度：<input type='text' value='" + GetXmlValue("Size") + "' class='input' size='5' maxlength='3' name='Size'><br />");
            HttpContext.Current.Response.Write("默　认　值：<input type='text' value='" + GetXmlValue("Field_Text") + "' class='input' size='30' maxlength='100' name='Default'>");
            ValidatorInfo();
        }
        /// <summary>
        /// 验证信息
        /// </summary>
        private void ValidatorInfo()
        {
            HttpContext.Current.Response.Write("<br />信息验证：<input type='text' class='input' size='30' maxlength='200' name='Validator' value='" + GetXmlValue("Validator") + "'> (多个验证以“,”分割)");
        }
        #endregion



    }
}

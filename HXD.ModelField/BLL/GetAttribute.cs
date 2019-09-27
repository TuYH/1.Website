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
        /// �ֶ�����
        /// </summary>
        public string FieldType;
        /// <summary>
        /// ����
        /// </summary>
        public string TableName;
        /// <summary>
        /// �ֶ���
        /// </summary>
        public string Field;
        /// <summary>
        /// XML����
        /// </summary>
        private XmlDoc xml;
        /// <summary>
        /// DataTable����
        /// </summary>
        private DataTable dt;
        /// <summary>
        /// �����ֶ����ͣ���ʾ����������Ҫ���õ���Ϣ��
        /// </summary>
        public DataSet dsList;
        /// <summary>
        /// �����ֶ����ͣ���ʾ����������Ҫ���õ���Ϣ��
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
        /// ��ȡXML�ڵ�ֵ
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
        #region �����ֶ�������Ϣ��
        /// <summary>
        /// �����ı�
        /// </summary>
        private void SingleLineType()
        {
            HttpContext.Current.Response.Write("����ַ�����<input type='text' value='" + GetXmlValue("MaxLength") + "' class='input' size='5' maxlength='4' name='MaxLength'><br />");
            HttpContext.Current.Response.Write("�ı��򳤶ȣ�<input type='text' value='" + GetXmlValue("Size") + "' class='input' size='5' maxlength='3' name='Size'><br />");
            HttpContext.Current.Response.Write("Ĭ���ϡ�ֵ��<input type='text' value='" + GetXmlValue("Field_Text") + "' class='input' size='30' maxlength='100' name='Default'>");
            ValidatorInfo();
        }
        /// <summary>
        /// ����
        /// </summary>
        private void PasswordType()
        {
            HttpContext.Current.Response.Write("����ַ�����<input type='text' value='" + GetXmlValue("MaxLength") + "' class='input' size='5' maxlength='4' name='MaxLength'><br />");
            HttpContext.Current.Response.Write("�ı��򳤶ȣ�<input type='text' value='" + GetXmlValue("Size") + "' class='input' size='5' maxlength='3' name='Size'><br />");
            HttpContext.Current.Response.Write("Ĭ���ϡ�ֵ��<input type='text' value='" + GetXmlValue("Field_Text") + "' class='input' size='30' maxlength='100' name='Default'><br />");
            HttpContext.Current.Response.Write("��&nbsp;&nbsp;&nbsp;&nbsp;��&nbsp;&nbsp;&nbsp;&nbsp;��&nbsp;&nbsp;&nbsp;&nbsp;ʽ��<select name='PwdMode'><option value='0'" + StringDeal.GetSelected(GetXmlValue("PwdMode"), "0") + ">������</option><option value='MD5'" + StringDeal.GetSelected(GetXmlValue("PwdMode"), "MD5") + ">MD5����</option><option value='DES'" + StringDeal.GetSelected(GetXmlValue("PwdMode"), "DES") + ">DES����</option><option value='AES'" + StringDeal.GetSelected(GetXmlValue("PwdMode"), "AES") + ">AES����</option></select>");
            ValidatorInfo();
        }
        /// <summary>
        /// �����ı�
        /// </summary>
        private void MultiLineType()
        {
            HttpContext.Current.Response.Write("��ʾ�Ŀ�ȣ�<input type='text' value='" + GetXmlValue("Width") + "' class='input' size='5' maxlength='3' name='Width'><br />");
            HttpContext.Current.Response.Write("��ʾ�ĸ߶ȣ�<input type='text' value='" + GetXmlValue("Height") + "' class='input' size='5' maxlength='3' name='Height'><br />");
            HttpContext.Current.Response.Write("Ĭ���ϡ�ֵ��<textarea name='Default' cols='45' rows='5'>" + GetXmlValue("Field_Text") + "</textarea>");
            ValidatorInfo();
        }
        /// <summary>
        /// �༭��
        /// </summary>
        private void EditorType()
        {
            HttpContext.Current.Response.Write("�༭�����ͣ�<select name='EditorType'><option value='1'" + StringDeal.GetSelected(GetXmlValue("EditorType"), 1) + ">����</option><option value='2'" + StringDeal.GetSelected(GetXmlValue("EditorType"), 2) + ">��׼��</option><option value='3'" + StringDeal.GetSelected(GetXmlValue("EditorType"), 3) + ">�߼���</option></select><br />");
            HttpContext.Current.Response.Write("��ʾ�Ŀ�ȣ�<input type='text' value='" + GetXmlValue("Width") + "' class='input' size='5' maxlength='3' name='Width'><br />");
            HttpContext.Current.Response.Write("��ʾ�ĸ߶ȣ�<input type='text' value='" + GetXmlValue("Height") + "' class='input' size='5' maxlength='3' name='Height'><br />");
            HttpContext.Current.Response.Write("Ĭ���ϡ�ֵ��<textarea name='Default' cols='45' rows='5'>" + GetXmlValue("Field_Text") + "</textarea>");
            ValidatorInfo();
        }
        /// <summary>
        /// ѡ���������ѡ����ѡ��
        /// </summary>
        private void SelectType()
        {
            HttpContext.Current.Response.Write("ÿ��ѡ�<br /><textarea name='Options' cols='45' rows='5' class=''>" + GetXmlValue("Options") + "</textarea><br />������ѡ�����ƣ��м��ûس��ָ<br />");
            HttpContext.Current.Response.Write("ѡ�����ͣ�<input value='select' type='radio' name='OptionsType'" + StringDeal.GetChecked(GetXmlValue("OptionsType"), "select") + " />��ѡ�����б��");
            HttpContext.Current.Response.Write("��<input value='radio' type='radio' name='OptionsType'" + StringDeal.GetChecked(GetXmlValue("OptionsType"), "radio") + " />��ѡ��ť");
            HttpContext.Current.Response.Write("��<input value='checkbox' type='radio' name='OptionsType'" + StringDeal.GetChecked(GetXmlValue("OptionsType"), "checkbox") + " />��ѡ��<br />");
            HttpContext.Current.Response.Write("Ĭ&nbsp;&nbsp;��&nbsp;&nbsp;ֵ��<input type='text' value='" + GetXmlValue("Field_Text") + "' class='input' maxlength='100' name='Default'>");
            ValidatorInfo();
        }
        /// <summary>
        /// ����
        /// </summary>
        private void NumberType()
        {
            HttpContext.Current.Response.Write("С��λ����<select name='Bit'><option value='0'" + StringDeal.GetSelected(GetXmlValue("Bit"), 0) + ">0</option><option value='1'" + StringDeal.GetSelected(GetXmlValue("Bit"), 1) + ">1</option><option value='2'" + StringDeal.GetSelected(GetXmlValue("Bit"), 2) + ">2</option><option value='3'" + StringDeal.GetSelected(GetXmlValue("Bit"), 3) + ">3</option><option value='4'" + StringDeal.GetSelected(GetXmlValue("Bit"), 4) + ">4</option><option value='5'" + StringDeal.GetSelected(GetXmlValue("Bit"), 5) + ">5</option></select><br />");
            HttpContext.Current.Response.Write("Ĭ&nbsp;&nbsp;��&nbsp;&nbsp;ֵ��<input type='text' value='" + GetXmlValue("Field_Text") + "' class='input' maxlength='18' name='Default'>");
            ValidatorInfo();
        }
        /// <summary>
        /// ����
        /// </summary>
        private void DateTimeType()
        {
            HttpContext.Current.Response.Write("�񡡡�ʽ��<input value='yyyy-mm-dd' type='radio' name='DateTime'" + StringDeal.GetChecked(GetXmlValue("DateTime"), "yyyy-mm-dd") + " />������");
            HttpContext.Current.Response.Write("��<input value='yyyy-mm-dd hh:mm:ss' type='radio' name='DateTime'" + StringDeal.GetChecked(GetXmlValue("DateTime"), "yyyy-mm-dd hh:mm:ss") + " />���ں�ʱ��<br />");
            HttpContext.Current.Response.Write("Ĭ&nbsp;&nbsp;��&nbsp;&nbsp;ֵ��<input type='text' value='" + GetXmlValue("Field_Text") + "' class='input' maxlength='20' name='Default'>ѡ������/��ǰ����");
            ValidatorInfo();
        }
        /// <summary>
        /// ͼƬ�ϴ�
        /// </summary>
        private void ImageType()
        {
            HttpContext.Current.Response.Write("Ĭ���ϡ�ֵ��<input type='text' value='" + GetXmlValue("Field_Text") + "' class='input' maxlength='200' name='Default'> ͼƬ���ƻ��ַ,ע����ַ���\"http://\"");
            ValidatorInfo();
        }
        /// <summary>
        /// �ļ��ϴ�
        /// </summary>
        private void FileType()
        {
            HttpContext.Current.Response.Write("�ļ����ͣ�<select name='UploadFileType'><option value='VideoType'" + StringDeal.GetSelected(GetXmlValue("UploadFileType"), "VideoType") + ">��Ƶ����</option><option value='AudioType'" + StringDeal.GetSelected(GetXmlValue("UploadFileType"), "AudioType") + ">��Ƶ����</option><option value='SoftType'" + StringDeal.GetSelected(GetXmlValue("UploadFileType"), "SoftType") + ">�������</option><option value='OtherType'" + StringDeal.GetSelected(GetXmlValue("UploadFileType"), "OtherType") + ">��������</option><option value=''" + StringDeal.GetSelected(GetXmlValue("UploadFileType"), "") + ">ȫ������</option></select><br />");
            HttpContext.Current.Response.Write("Ĭ���ϡ�ֵ��<input type='text' value='" + GetXmlValue("Field_Text") + "' class='input' maxlength='200' name='Default'>����,�ļ����ƻ��ַ");
            ValidatorInfo();
        }
        /// <summary>
        /// ����ͼƬ�ϴ�
        /// </summary>
        private void BatchImageType()
        {
            HttpContext.Current.Response.Write("Ĭ���ϡ�ֵ��<input type='text' value='" + GetXmlValue("Field_Text") + "' class='input' maxlength='200' name='Default'> ͼƬ���ƻ��ַ,ע����ַ���\"http://\"");
            ValidatorInfo();
        }
        /// <summary>
        /// �����ļ��ϴ�
        /// </summary>
        private void BatchFileType()
        {
            HttpContext.Current.Response.Write("�ļ����ͣ�<select name='UploadFileType'><option value='VideoType'" + StringDeal.GetSelected(GetXmlValue("UploadFileType"), "VideoType") + ">��Ƶ����</option><option value='AudioType'" + StringDeal.GetSelected(GetXmlValue("UploadFileType"), "AudioType") + ">��Ƶ����</option><option value='SoftType'" + StringDeal.GetSelected(GetXmlValue("UploadFileType"), "SoftType") + ">�������</option><option value='OtherType'" + StringDeal.GetSelected(GetXmlValue("UploadFileType"), "OtherType") + ">��������</option><option value=''" + StringDeal.GetSelected(GetXmlValue("UploadFileType"), "") + ">ȫ������</option></select><br />");
            HttpContext.Current.Response.Write("Ĭ���ϡ�ֵ��<input type='text' value='" + GetXmlValue("Field_Text") + "' class='input' maxlength='200' name='Default'>����,�ļ����ƻ��ַ");
            ValidatorInfo();
        }

        /// <summary>
        /// ���������˵�
        /// </summary>
        private void OtherMenuType()
        {
            HttpContext.Current.Response.Write("�����ڵ㣺<select name='MenuId'>");
            MenuList(0, "��", GetXmlValue("MenuId"));
            HttpContext.Current.Response.Write("</select><br />");
            HttpContext.Current.Response.Write("Ĭ&nbsp;&nbsp;��&nbsp;&nbsp;ֵ��<input type='text' value='" + GetXmlValue("Field_Text") + "' class='input' maxlength='18' name='Default'>");
            ValidatorInfo();
        }
        private void MenuList(int Id, string Separator, string MenuId)
        {

            DataView dv = new DataView(dsList.Tables[0]);
            dv.RowFilter = "ParentId = " + Id;
            foreach (DataRowView dr in dv)
            {
                HttpContext.Current.Response.Write("    <option value='" + dr["Id"] + "'" + StringDeal.GetSelected(dr["Id"], MenuId) + ">" + Separator + StringDeal.StrFormat(dr["Title"]) + "</option>");
                MenuList(StringDeal.ToInt(dr[0]), "��" + Separator, MenuId);
            }
        }
        /// <summary>
        /// ��������
        /// </summary>
        private void ProvincesType()
        {
            HttpContext.Current.Response.Write("Ĭ��ֵ��<input type='text' value='" + GetXmlValue("Field_Text") + "' class='input' maxlength='200' name='Default'>");
            ValidatorInfo();
        }
        /// <summary>
        /// ��̬����
        /// </summary>
        private void Increment()
        {
            HttpContext.Current.Response.Write("����ַ�����<input type='text' value='" + GetXmlValue("MaxLength") + "' class='input' size='5' maxlength='4' name='MaxLength'><br />");
            HttpContext.Current.Response.Write("�ı��򳤶ȣ�<input type='text' value='" + GetXmlValue("Size") + "' class='input' size='5' maxlength='3' name='Size'><br />");
            HttpContext.Current.Response.Write("Ĭ���ϡ�ֵ��<input type='text' value='" + GetXmlValue("Field_Text") + "' class='input' size='30' maxlength='100' name='Default'>");
            ValidatorInfo();
        }
        /// <summary>
        /// ��֤��Ϣ
        /// </summary>
        private void ValidatorInfo()
        {
            HttpContext.Current.Response.Write("<br />��Ϣ��֤��<input type='text' class='input' size='30' maxlength='200' name='Validator' value='" + GetXmlValue("Validator") + "'> (�����֤�ԡ�,���ָ�)");
        }
        #endregion



    }
}

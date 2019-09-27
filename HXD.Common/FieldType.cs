using System;
using System.Collections.Generic;
using System.Text;

namespace HXD.Common
{
    public class FieldType
    {
        #region �����ֶε�XML��ȡ��ͬ�����ֶ���ʾ��ҳ��
        /// <summary>
        /// �����ֶε�XML��ȡ��ͬ�����ֶ���ʾ��ҳ��
        /// </summary>
        /// <param name="Val">���ֶε�ֵ</param>
        /// <param name="Xml">xml�ĵ���Ϣ</param>
        /// <returns></returns>
        public static string GetType(object Val, object Xml)
        { 
            string Results = "";
            XmlDoc xml = new XmlDoc();
            xml.xmlfileInfo = Xml.ToString();
            int Type = StringDeal.ToInt(xml.GetValue("/FieldInfo/FieldType"));
            string Field = xml.GetValue("/FieldInfo/FieldName");
            string CssClass = xml.GetValue("/FieldInfo/Validator");
            string useTitles = xml.GetValue("/FieldInfo/useTitles");
            if (String.IsNullOrEmpty(Val.ToString()))
            {
                Val = xml.GetValue("/FieldInfo/Default");
            }
            switch (Type)
            {
                case 1:
                    #region �����ı�
                    Results = "<input id='" + Field + "' name='" + Field + "' class='input " + CssClass + "' title='" + useTitles + "' value=\"" + StringDeal.StrFormat(Val) + "\" maxlength='" + xml.GetValue("/FieldInfo/MaxLength") + "' size='" + xml.GetValue("/FieldInfo/Size") + "' />";
                    break;
                    #endregion
                case 2:
                    #region �����ı�
                    Results = "<textarea name='" + Field + "' id='" + Field + "' style='width:" + xml.GetValue("/FieldInfo/Width") + "px; height:" + xml.GetValue("/FieldInfo/Height") + "px;' class='" + CssClass + "' title='" + useTitles + "'>" + Val + "</textarea>";
                    break;
                    #endregion
                case 3:
                    #region �༭��
                    string Editor = "";
                    if (xml.GetValue("/FieldInfo/Editor") == "1")
                    {
                        Editor = "Mini";
                    }
                    else if (xml.GetValue("/FieldInfo/Editor") == "2")
                    {
                        Editor = "Simple";
                    }
                    else
                    {
                        Editor = "Default";
                    }

                    Results = "<script type='text/javascript'>\n";
                    Results += "window.onload = function()\n";
                    Results += "{";
                    Results += "    var sBasePath = '/WebEditor/';\n";
                    Results += "    var oFCKeditor = new FCKeditor( '" + Field + "' );\n";
                    Results += "    oFCKeditor.BasePath	= sBasePath ;\n";
                    Results += "    oFCKeditor.ToolbarSet = '" + Editor + "';\n";
                    Results += "    oFCKeditor.Config['SkinPath'] = sBasePath+'editor/skins/silver/';\n";
                    Results += "    oFCKeditor.Width = '" + xml.GetValue("/FieldInfo/Width") + "';\n";
                    Results += "    oFCKeditor.Height = '" + xml.GetValue("/FieldInfo/Height") + "';\n";
                    Results += "    oFCKeditor.ReplaceTextarea();\n";
                    Results += "}\n";
                    Results += "    </script>\n";
                    Results += "<textarea name='" + Field + "' id='" + Field + "' class='" + CssClass + "' title='" + useTitles + "'>" + Val + "</textarea>";
                    break;
                    #endregion
                case 4:
                    #region �����˵�����ѡ����ѡ
                    string[] Arry = xml.GetValue("/FieldInfo/Options").Split('|');
                    string OptionsType = xml.GetValue("/FieldInfo/OptionsType");
                    if (Arry.Length > 0 && !String.IsNullOrEmpty(OptionsType))
                    {
                        if (OptionsType == "select")
                        {
                            Results += "<select name='" + Field + "' id='" + Field + "' class='" + CssClass + "' title='" + useTitles + "'>";
                            Results += "<option value=''>��ѡ��</option>";
					        foreach(string I in Arry)
                            {
                                Results += "<option value=\"" + I + "\"" + StringDeal.GetSelected(Val, I);
						        Results += ">"+I+"</option>/n";
					        }
                            Results += "</select>";
                        }
                        else
                        {
                            for (int I = 0; I < Arry.Length;I++ )
                            {
                                Results += "<input type='" + OptionsType + "' id='" + Field + I + "' name='" + Field + "' value=\"" + Arry[I] + "\"" + StringDeal.GetChecked(Val, Arry[I]) + ">" + Arry[I];
                            }
                        }
                    }
                    break;
                    #endregion
                case 5:
                    #region ����
                    Results += "<input type='text' class='input " + CssClass + "' title='" + useTitles + "' maxlength='16' size='5' name='" + Field + "' id='" + Field + "' value=\"" + Val + "\" />";
                    break;
                    #endregion
                case 6:
                    #region ����/ʱ������
                    string onFocus = "";
                    if (xml.GetValue("/FieldInfo/DateTime") == "yyyy-mm-dd")
                    {
                        onFocus = "setDay(this);";
                        if (Val.ToString() == "getdate()")
                        {
                            Val = DateTime.Today.ToString("yyyy-MM-dd");
                        }
                        else
                        {
                            Val = StringDeal.GetDateTime(Val, "yyyy-MM-dd");
                        }
                    }
                    else
                    {
                        onFocus = "setDayHM(this);";
                        if (Val.ToString() == "getdate()")
                        {
                            Val = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                        }
                        else
                        {
                            Val = StringDeal.GetDateTime(Val, "yyyy-MM-dd HH:mm");
                        }
                    }
                    Results += "<input readonly='readonly' type='text' onclick=\"" + onFocus + "\" class='input " + CssClass + "' title='" + useTitles + "' maxlength='25' size='25' name='" + Field + "' id='" + Field + "' value=\"" + Val + "\" />";
                    Results += "<script language=\"javascript\" type=\"text/javascript\" src='../js/calendar.js'></script>";
                    break;
                    #endregion
                case 7:
                    #region ͼƬ�ϴ�
                    //string UploadPhotoPath = xml.GetValue("/FieldInfo/UploadPhotoPath");
                    //string UploadPhotoSize = xml.GetValue("/FieldInfo/UploadPhotoSize");
                    //string UploadPhotoType = xml.GetValue("/FieldInfo/UploadPhotoType");
                    //string Mark = xml.GetValue("/FieldInfo/Mark");
                    //string Thumb = xml.GetValue("/FieldInfo/Thumb");
                    Results += "<input type='text' id='" + Field + "' readonly='readonly' class='input2 " + CssClass + "' name='" + Field + "' value=\"" + StringDeal.StrFormat(Val) + "\" /> <input type=\"button\" class=\"divbutton\" value=\"ͼƬ�ϴ�\" onclick=\"UploadImage('" + Field + "','" + GetConfig.System("ManagePath") + "');\" />";
                    break;
                    #endregion
                case 8:
                    #region �ļ��ϴ�
                    //string UploadFilePath = xml.GetValue("/FieldInfo/UploadPhotoPath");
                    //string UploadFileSize = xml.GetValue("/FieldInfo/UploadPhotoSize");
                    string UploadFileType = xml.GetValue("/FieldInfo/UploadImageType");
                    Results += "<input type=\"text\" id=\"" + Field + "\" readonly=\"readonly\" class=\"input2 " + CssClass + "\" name=\"" + Field + "\" value=\"" + StringDeal.StrFormat(Val) + "\" /> <input type=\"button\" class=\"divbutton\" value=\"�ļ��ϴ�\" onclick=\"UploadFile('" + Field + "','" + GetConfig.System("ManagePath") + "','" + UploadFileType + "');\" />";
                    break;
                    #endregion
            }
            return Results;
        }
        #endregion

        #region ��ȡ�����˱���Ϣ
        /// <summary>
        /// ��ȡ�����˱���Ϣ
        /// </summary>
        /// <param name="Type">�ֶ�����</param>
        /// <param name="Val">��ȡ��ֵ</param>
        /// <returns></returns>
        public static string FormatField(string Type, string Field)
        {
            string Val = System.Web.HttpContext.Current.Request.Form[Field];
            switch (Type)
            {
                case "1":
                    #region �����ı�
                    return "'" + StringDeal.ReplaceSql(Val) + "'";
                    #endregion
                case "2":
                    #region �����ı�
                    return "'" + StringDeal.ReplaceSql(Val) + "'";
                    #endregion
                case "3":
                    #region �༭��
                    return "'" + Val.Replace("'","''") + "'";
                    #endregion
                case "4":
                    #region �����˵�����ѡ����ѡ
                    return "'" + Val + "'";
                    #endregion
                case "5":
                    #region ����
                    return Val;
                    #endregion
                case "6":
                    #region ����/ʱ������
                    return "'" + StringDeal.GetDateTime(Val,"yyyy-MM-dd HH:mm") + "'";
                    #endregion
                case "7":
                    #region ͼƬ�ϴ�
                    return "'" + StringDeal.ReplaceSql(Val) + "'";
                    #endregion
                case "8":
                    #region �ļ��ϴ�
                    return "'" + StringDeal.ReplaceSql(Val); 
                    #endregion
                default :
                    #region �����ı�
                    return "'" + StringDeal.ReplaceSql(Val) + "'";
                    #endregion
            }
        }
        #endregion

        #region �����ֶ�����ID��ʾ�������ƺ�ICOͼ��
        /// <summary>
        /// �����ֶ�����ID��ʾ�������ƺ�ICOͼ��
        /// </summary>
        /// <param name="Type">����ID</param>
        /// <returns></returns>
        public static string GetTypeName(object Type)
        {
            string Results = "";
            switch (StringDeal.ToInt(Type))
            {
                case 1:
                    #region �����ı�
                    Results = "<img src='../images/SingleLine.gif' align='absmiddle'>�����ı�";
                    break;
                    #endregion
                case 2:
                    #region �����ı�
                    Results = "<img src='../images/MultiLine.gif' align='absmiddle'>�����ı�";
                    break;
                    #endregion
                case 3:
                    #region �༭��
                    Results = "<img src='../images/Editor.gif' align='absmiddle'>�༭��";
                    break;
                    #endregion
                case 4:
                    #region �����˵�����ѡ����ѡ
                    Results = "<img src='../images/Select.gif' align='absmiddle'>�����˵�����ѡ����ѡ";
                    break;
                    #endregion
                case 5:
                    #region ����
                    Results = "<img src='../images/Number.gif' align='absmiddle'>����";
                    break;
                    #endregion
                case 6:
                    #region ����/ʱ������
                    Results = "<img src='../images/DateTime.gif' align='absmiddle'>����/ʱ������";
                    break;
                    #endregion
                case 7:
                    #region ͼƬ�ϴ�
                    Results = "<img src='../images/Image.gif' align='absmiddle'>ͼƬ�ϴ�"; 
                    break;
                    #endregion
                case 8:
                    #region �ļ��ϴ�
                    Results = "<img src='../images/File.gif' align='absmiddle'>�ļ��ϴ�"; 
                    break;
                    #endregion
            }
            return Results;
        }
        #endregion
    }
}

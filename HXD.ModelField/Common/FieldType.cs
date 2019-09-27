using System;
using System.Collections.Generic;
using System.Text;
using HXD.Common;
using System.Data;
namespace HXD.ModelField.Common
{
    public class FieldType
    {
        #region �����ֶ����ͻ�ȡ����ͼƬ������˵��
        /// <summary>
        /// �����ֶ����ͻ�ȡ����ͼƬ������˵��
        /// </summary>
        /// <param name="Type">�ֶ�����</param>
        /// <returns></returns>
        public static string GetFieldType(object Type)
        {
            string Results = "";
            string type = Type.ToString();
            if (!String.IsNullOrEmpty(type))
            {
                switch (type)
                {
                    case "SingleLine":
                        Results = "<img src='../images/SingleLine.gif' align='absmiddle'>�����ı�";
                        break;
                    case "Password":
                        Results = "<img src='../images/Password.gif' align='absmiddle'>�ܡ�����";
                        break;
                    case "MultiLine":
                        Results = "<img src='../images/MultiLine.gif' align='absmiddle'>�����ı�";
                        break;
                    case "Editor":
                        Results = "<img src='../images/Editor.gif' align='absmiddle'>��&nbsp;&nbsp;��&nbsp;&nbsp;��";
                        break;
                    case "Select":
                        Results = "<img src='../images/Select.gif' align='absmiddle'>ѡ������";
                        break;
                    case "Number":
                        Results = "<img src='../images/Number.gif' align='absmiddle'>��������";
                        break;
                    case "DateTime":
                        Results = "<img src='../images/DateTime.gif' align='absmiddle'>ʱ������";
                        break;
                    case "Image":
                        Results = "<img src='../images/Image.gif' align='absmiddle'>ͼƬ�ϴ�";
                        break;
                    case "File":
                        Results = "<img src='../images/File.gif' align='absmiddle'>�ļ��ϴ�";
                        break;
                    case "BatchImage":
                        Results = "<img src='../images/BatchImage.gif' align='absmiddle'>������ͼ";
                        break;
                    case "BatchFile":
                        Results = "<img src='../images/BatchFile.gif' align='absmiddle'>�����ļ�";
                        break;
                    case "OtherMenu":
                        Results = "�����ڵ�";//<img src='../images/OtherMenu.gif' align='absmiddle'>
                        break;
                    case "Provinces":
                        Results = "ʡ�ݳ�������";//<img src='../images/OtherMenu.gif' align='absmiddle'>
                        break;
                    case "Increment":
                        Results = "<img src='../images/SingleLine+.gif' align='absmiddle'>��̬����";//<img src='../images/OtherMenu.gif' align='absmiddle'>
                        break;
                    default:
                        Results = "<img src='../images/err.gif' align='absmiddle'>��������";
                        break;
                }
            }
            return Results;
        }
        #endregion
        public DataSet dsList;
        public DataSet dszhubo;
        #region �����ֶ����ƺ�XML���������ֶ��Լ���Ϣ
        /// <summary>
        /// �����ֶ����ƺ�XML���������ֶ��Լ���Ϣ
        /// </summary>
        /// <param name="Val">ֵ</param>
        /// <param name="xml">����</param>
        /// <param name="Name">�ֶ�</param>
        /// <returns></returns>
        public static string GetType(object Val, XmlDoc xml, object Name)
        {
            string Results = "";
            DataTable dt = xml.GetDataTable("Name='" + Name.ToString() + "'", "");
            if (String.IsNullOrEmpty(Val.ToString()))
            {
                Val = dt.Rows[0]["Field_Text"].ToString();
            }
            string Field = Name.ToString();
            string Type = dt.Rows[0]["Type"].ToString();
            string Note = dt.Rows[0]["Note"].ToString();
            string Prompt = dt.Rows[0]["Prompt"].ToString();
            string Validator = dt.Rows[0]["Validator"].ToString();
            switch (Type)
            {
                case "SingleLine":
                    #region �����ı�
                    Results = "<input id=\"" + Field + "\" name=\"" + Field + "\" class=\"input " + Validator + "\" title=\"" + Prompt + "\" value=\"" + StringDeal.StrFormat(Val) + "\" maxlength=\"" + dt.Rows[0]["MaxLength"] + "\" size=\"" + dt.Rows[0]["Size"] + "\" />";
                    break;
                    #endregion
                case "Password":
                    #region ����
                    //Results = "<input type=\"password\" id=\"" + Field + "\" name=\"" + Field + "\" class=\"input " + Validator + "\" title=\"" + Prompt + "\" value=\"" + StringDeal.StrFormat(Val) + "\" maxlength=\"" + dt.Rows[0]["MaxLength"] + "\" size=\"" + dt.Rows[0]["Size"] + "\" />";
                    Results = "<input type=\"password\" id=\"" + Field + "\" name=\"" + Field + "\" class=\"input " + Validator + "\" title=\"" + Prompt + "\" maxlength=\"" + dt.Rows[0]["MaxLength"] + "\" size=\"" + dt.Rows[0]["Size"] + "\" />";
                    break;
                    #endregion
                case "MultiLine":
                    #region �����ı�
                    Results = "<textarea name=\"" + Field + "\" id=\"" + Field + "\" style=\"width:" + dt.Rows[0]["Width"] + "px; height:" + dt.Rows[0]["Height"] + "px;\" class=\"" + Validator + "\" title=\"" + Prompt + "\">" + Val + "</textarea>";
                    break;
                    #endregion
                case "Editor":
                    #region �༭��
                    string Editor = "";
                    if (dt.Rows[0]["EditorType"].ToString() == "1")
                    {
                        Editor = "Mini";
                    }
                    else if (dt.Rows[0]["EditorType"].ToString() == "2")
                    {
                        Editor = "Simple";
                    }
                    else
                    {
                        Editor = "Default";
                    }
                    Results = "<input type=\"hidden\" id=\"" + Field + "\" name=\"" + Field + "\" value=\"" + Val + "\" /><iframe id=\"" + Field + "___Frame\" src=\"../../WebEditor/editor/fckeditor.html?InstanceName=" + Field + "&amp;Toolbar=" + Editor + "\" width=\"" + dt.Rows[0]["Width"] + "\" height=\"" + dt.Rows[0]["Height"] + "\" frameborder=\"no\" scrolling=\"no\"></iframe>";
                    // Results = "<fckeditorv2:FCKeditor id=\"" + Field + "\" runat=\"server\" Width=\"" + dt.Rows[0]["Width"] + "\" BasePath=\"/WebEditor/\" Height=\"" + dt.Rows[0]["Height"] + "\" ToolbarSet=\"" + Editor + "\" SkinPath=\"/WebEditor/editor/skins /silver/ \"></fckeditorv2:FCKeditor>";   
                    //Results = "<script type=\"text/javascript\" language=\"javascript\">\n";
                    //Results += "window.onload = function()\n";
                    //Results += "{";
                    //Results += "    var sBasePath = \"../../WebEditor/\";\n";
                    //Results += "    var oFCKeditor = new FCKeditor( \"" + Field + "\" );\n";
                    //Results += "    oFCKeditor.BasePath	= sBasePath ;\n";
                    //Results += "    oFCKeditor.ToolbarSet = \"" + Editor + "\";\n";
                    //Results += "    oFCKeditor.Config[\"SkinPath\"] = sBasePath+\"editor/skins/silver/\";\n";
                    //Results += "    oFCKeditor.Width = \"" + dt.Rows[0]["Width"] + "\";\n";
                    //Results += "    oFCKeditor.Height = \"" + dt.Rows[0]["Height"] + "\";\n";
                    //Results += "    oFCKeditor.ReplaceTextarea();\n";
                    //Results += "}\n";
                    //Results += "    </script>\n";
                    //Results += "<textarea name=\"" + Field + "\" id=\"" + Field + "\" class=\"" + Validator + "\" title=\"" + Prompt + "\">" + Val + "</textarea>";
                    break;
                    #endregion
                case "Select":
                    #region ѡ��
                    string[] Arry = dt.Rows[0]["Options"].ToString().Split(new string[1] { "\r\n" }, System.StringSplitOptions.None);
                    string OptionsType = dt.Rows[0]["OptionsType"].ToString();
                    if (Arry.Length > 0 && !String.IsNullOrEmpty(OptionsType))
                    {
                        if (OptionsType == "select")
                        {
                            Results += "<select name=\"" + Field + "\" id=\"" + Field + "\" class=\"" + Validator + "\" title=\"" + Prompt + "\">";
                            Results += "<option value=\"\">��ѡ��</option>";
                            foreach (string I in Arry)
                            {
                                Results += "<option value=\"" + I + "\"" + StringDeal.GetSelected(Val, I);
                                Results += ">" + I + "</option>\n";
                            }
                            Results += "</select>";
                        }
                        else
                        {
                            for (int I = 0; I < Arry.Length; I++)
                            {
                                Results += "<input type=\"" + OptionsType + "\" id=\"" + Field + I + "\" name=\"" + Field + "\" value=\"" + Arry[I] + "\"" + StringDeal.GetChecked(Val, Arry[I]) + ">" + Arry[I]+" ";
                            }
                        }
                    }
                    break;
                    #endregion
                case "Number":
                    #region ����
                    Results += "<input type=\"text\" class=\"input " + Validator + "\" title=\"" + Prompt + "\" maxlength=\"16\" size=\"5\" name=\"" + Field + "\" id=\"" + Field + "\" value=\"" + Val + "\" />";
                    break;
                    #endregion
                case "DateTime":
                    #region ����/ʱ������
                    string onFocus = "";
                    if (dt.Rows[0]["DateTime"].ToString() == "yyyy-mm-dd")
                    {
                        //onFocus = "setDay(this);";
                        onFocus = "yyyy-MM-dd";
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
                        //onFocus = "setDayHM(this);";
                        onFocus = "yyyy-MM-dd HH:mm:ss";
                        if (Val.ToString() == "getdate()")
                        {
                            Val = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                        }
                        else
                        {
                            Val = StringDeal.GetDateTime(Val, "yyyy-MM-dd HH:mm");
                        }
                    }
                    //Results += "<input readonly=\"readonly\" type=\"text\" onclick=\"" + onFocus + "\" class=\"input " + Validator + "\" title=\"" + Prompt + "\" maxlength=\"25\" size=\"25\" name=\"" + Field + "\" id=\"" + Field + "\" value=\"" + Val + "\" />";
                    //Results += "<script language=\"javascript\" type=\"text/javascript\" src='../js/calendar.js'></script>";
                    Results += "<input readonly=\"readonly\" type=\"text\" class=\"input " + Validator + "\" onfocus=\"WdatePicker({skin:'YcloudRed',lang:'zh-cn',isShowClear:true,readOnly:true,dateFmt:'" + onFocus + "'})\" title=\"" + Prompt + "\" maxlength=\"25\" size=\"25\" name=\"" + Field + "\" id=\"" + Field + "\" value=\"" + Val + "\" />";
                    Results += "<script language=\"javascript\" type=\"text/javascript\" src='../Js/WdatePicker/WdatePicker.js'></script>";
                    break;
                    #endregion
                case "Image":
                    #region ͼƬ�ϴ�
                    //string UploadImagePath = GetConfig.Image("UploadImagePath");
                    //bool IsUploadImage = StringDeal.ToBool(dt.Rows[0]["IsUploadImage"]);
                    //string UploadImageSize = dt.Rows[0]["UploadImageSize"].ToString();
                    //string UploadImageType = dt.Rows[0]["UploadImageType"].ToString();
                    //bool IsSelect = StringDeal.ToBool(dt.Rows[0]["IsSelect"]);
                    //bool IsMark = StringDeal.ToBool(dt.Rows[0]["IsMark"]);
                    //string MarkImage = dt.Rows[0]["MarkImage"].ToString();
                    //bool IsThumb = StringDeal.ToBool(dt.Rows[0]["IsThumb"]);
                    //string ThumbSize = dt.Rows[0]["ThumbSize"].ToString();

                    Results += "<input type=\"text\" id=\"" + Field + "\" readonly=\"readonly\" class=\"input2 " + Validator + "\" name=\"" + Field + "\" value=\"" + StringDeal.StrFormat(Val) + "\" /> <input type=\"button\" class=\"divbutton\" value=\"ͼƬ�ϴ�\" onclick=\"UploadImage('" + Field + "','" + GetConfig.System("ManagePath") + "');\" />";
                    break;
                    #endregion
                case "File":
                    #region �ļ��ϴ�
                    //string UploadFilePath = GetConfig.File("UploadFilePath");
                    //bool IsUploadFile = StringDeal.ToBool(dt.Rows[0]["IsUploadFile"]);
                    //string UploadFileSize = dt.Rows[0]["UploadFileSize"].ToString();
                    string UploadFileType = dt.Rows[0]["UploadFileType"].ToString();
                    //bool IsSelect1 = StringDeal.ToBool(dt.Rows[0]["IsSelect"]);
                    Results += "<input type=\"text\" id=\"" + Field + "\" readonly=\"readonly\" class=\"input2 " + Validator + "\" name=\"" + Field + "\" value=\"" + StringDeal.StrFormat(Val) + "\" /> <input type=\"button\" class=\"divbutton\" value=\"�ļ��ϴ�\" onclick=\"UploadFile('" + Field + "','" + GetConfig.System("ManagePath") + "','" + UploadFileType + "');\" />";
                    break;
                    #endregion
                case "BatchImage":
                    #region ͼƬ�����ϴ�
                    //string UploadImagePath = GetConfig.Image("UploadImagePath");
                    //bool IsUploadImage = StringDeal.ToBool(dt.Rows[0]["IsUploadImage"]);
                    //string UploadImageSize = dt.Rows[0]["UploadImageSize"].ToString();
                    //string UploadImageType = dt.Rows[0]["UploadImageType"].ToString();
                    //bool IsSelect = StringDeal.ToBool(dt.Rows[0]["IsSelect"]);
                    //bool IsMark = StringDeal.ToBool(dt.Rows[0]["IsMark"]);
                    //string MarkImage = dt.Rows[0]["MarkImage"].ToString();
                    //bool IsThumb = StringDeal.ToBool(dt.Rows[0]["IsThumb"]);
                    //string ThumbSize = dt.Rows[0]["ThumbSize"].ToString();
                    Results += "<select id=\"" + Field + "_Select\" name=\"" + Field + "_Select\" size=\"10\" style=\"width:500px;\">";
                    foreach (string x in StringDeal.StrFormat(Val).Split(','))
                    {
                        if (x.Length > 0)
                        {
                            Results += "<option value=\"" + x + "\">" + x + "</option>";
                        }
                    }
                    Results += "</select>";
                    Results += "<br /><input id=\"" + Field + "\" name=\"" + Field + "\" type=\"hidden\"><input type=\"button\" class=\"divbutton\" value=\"ͼƬ�ϴ�\" onclick=\"BatchUploadImage('" + Field + "_Select','" + GetConfig.System("ManagePath") + "','');\" /> <input type=\"button\" class=\"divbutton\" value=\"����\" onclick=\"Upload_Move('" + Field + "_Select','up');\" /> <input type=\"button\" class=\"divbutton\" value=\"����\" onclick=\"Upload_Move('" + Field + "_Select','down');\" /> <input type=\"button\" class=\"divbutton\" value=\"ɾ��\" onclick=\"Upload_Remove('" + Field + "_Select');\" /> <input type=\"button\" class=\"divbutton\" value=\"ȫ��ɾ��\" onclick=\"Upload_AllRemove('" + Field + "_Select');\" /><script language='javascript'>ListText('" + Field + "_Select');</script>";
                    break;
                    #endregion
                case "BatchFile":
                    #region �ļ������ϴ�
                    //string UploadFilePath = GetConfig.File("UploadFilePath");
                    //bool IsUploadFile = StringDeal.ToBool(dt.Rows[0]["IsUploadFile"]);
                    //string UploadFileSize = dt.Rows[0]["UploadFileSize"].ToString();
                    string UploadFileType1 = dt.Rows[0]["UploadFileType"].ToString();
                    //bool IsSelect1 = StringDeal.ToBool(dt.Rows[0]["IsSelect"]);
                    Results += "<select id=\"" + Field + "_Select\" name=\"" + Field + "_Select\" size=\"10\" style=\"width:500px;\">";
                    foreach (string x in StringDeal.StrFormat(Val).Split(','))
                    {
                        if (x.Length > 0)
                        {
                            Results += "<option value=\"" + x + "\">" + x + "</option>";
                        }
                    }
                    Results += "</select>";
                    Results += "<br /><input id=\"" + Field + "\" name=\"" + Field + "\" type=\"hidden\"><input type=\"button\" class=\"divbutton\" value=\"�ļ��ϴ�\" onclick=\"BatchUploadFile('" + Field + "_Select','" + GetConfig.System("ManagePath") + "','" + UploadFileType1 + "');\" /> <input type=\"button\" class=\"divbutton\" value=\"����\" onclick=\"Upload_Move('" + Field + "_Select','up');\" /> <input type=\"button\" class=\"divbutton\" value=\"����\" onclick=\"Upload_Move('" + Field + "_Select','down');\" /> <input type=\"button\" class=\"divbutton\" value=\"ɾ��\" onclick=\"Upload_Remove('" + Field + "_Select');\" /> <input type=\"button\" class=\"divbutton\" value=\"ȫ��ɾ��\" onclick=\"Upload_AllRemove('" + Field + "_Select');\" /><script language='javascript'>ListText('" + Field + "_Select');</script>";
                    break;
                    #endregion
                case "OtherMenu":
                    #region �����ڵ�
                    HXD.BLL.bMenu bM = new HXD.BLL.bMenu();
                    HXD.ModelField.BLL.GetAttribute ga = new HXD.ModelField.BLL.GetAttribute();
                    FieldType FieldType = new FieldType();
                    FieldType.dsList = (DataSet)bM.MenuList();
                    string MenuId = dt.Rows[0]["MenuId"].ToString();
                    Results += "<select name='" + Field + "' id='" + Field + "'>";
                    Results += "<option value=''>ѡ��</option>";
                    Results += FieldType.MenuList(MenuId, "��", Val);
                    Results += "</select><br />";
                    break;
                    #endregion
                case "Provinces":
                    #region ʡ�ݳ�������
                    Results += "<script type=\"text/javascript\" src=\"../Js/Pcasunzip.js\"></script>";
                    Results += "<select name=\"" + Field + "_Province\"></select><select name=\"" + Field + "_City\"></select><select name=\"" + Field + "_Area\"></select><input type=\"hidden\" name=\"" + Field + "\" value=\"null\"/>";
                    if (Val.ToString() != string.Empty)
                    {
                        string[] Vals = Val.ToString().Split('-');
                        if (Vals.Length == 3)
                        { Results += "<script type=\"text/javascript\">new PCAS(\"" + Field + "_Province\",\"" + Field + "_City\",\"" + Field + "_Area\",\"" + Vals[0] + "\",\"" + Vals[1] + "\",\"" + Vals[2] + "\")</script>"; }
                        else { Results += "<script type=\"text/javascript\">new PCAS(\"" + Field + "_Province\",\"" + Field + "_City\",\"" + Field + "_Area\")</script>"; }
                    }
                    else { Results += "<script type=\"text/javascript\">new PCAS(\"" + Field + "_Province\",\"" + Field + "_City\",\"" + Field + "_Area\")</script>"; }
                    break;
                    #endregion
                case "Increment":
                    #region ��̬����(�����ı�)
                    Results = "<input id=\"" + Field + "\" name=\"" + Field + "\" class=\"input " + Validator + "\" title=\"" + Prompt + "\" value=\"" + StringDeal.StrFormat(Val) + "\" maxlength=\"" + dt.Rows[0]["MaxLength"] + "\" size=\"" + dt.Rows[0]["Size"] + "\" />";
                    Results += "<script type=\"text/javascript\">";
                    Results += "var " + Field + "obj = new AutoAdd();";
                    Results += Field + "obj.ElementName = \"" + Field + "\";";
                    Results += Field + "obj.objName = \"" + Field + "obj\";";
                    Results += Field + "obj.MaxLength = \"" + dt.Rows[0]["MaxLength"] + "\";";
                    Results += Field + "obj.Size = \"" + dt.Rows[0]["Size"] + "\";";
                    Results += "jQuery(document).ready(function(){" + Field + "obj.binder(\"\");});";
                    Results += "</script>";
                    break;
                    #endregion
                //////////////////////////////
            }
            return Results;
        }

        /// <summary>
        /// �����ֶ����ƺ�XML���������ֶ��Լ���Ϣ
        /// </summary>
        /// <param name="Val">ֵ</param>
        /// <param name="xml">����</param>
        /// <param name="Name">�ֶ�</param>
        /// <returns></returns>
        public static string GetType(object Val, XmlDoc xml, object Name, int CID)
        {
            string Results = "";
            DataTable dt = xml.GetDataTable("Name='" + Name.ToString() + "'", "");
            if (String.IsNullOrEmpty(Val.ToString()))
            {
                Val = dt.Rows[0]["Field_Text"].ToString();
            }
            string Field = Name.ToString();
            string Type = dt.Rows[0]["Type"].ToString();
            string Note = dt.Rows[0]["Note"].ToString();
            string Prompt = dt.Rows[0]["Prompt"].ToString();
            string Validator = dt.Rows[0]["Validator"].ToString();
            switch (Type)
            {
                case "SingleLine":
                    #region �����ı�
                    Results = "<input id=\"" + Field + "\" name=\"" + Field + "\" class=\"input " + Validator + "\" title=\"" + Prompt + "\" value=\"" + StringDeal.StrFormat(Val) + "\" maxlength=\"" + dt.Rows[0]["MaxLength"] + "\" size=\"" + dt.Rows[0]["Size"] + "\" />";
                    break;
                    #endregion
                case "Password":
                    #region ����
                    //Results = "<input type=\"password\" id=\"" + Field + "\" name=\"" + Field + "\" class=\"input " + Validator + "\" title=\"" + Prompt + "\" value=\"" + StringDeal.StrFormat(Val) + "\" maxlength=\"" + dt.Rows[0]["MaxLength"] + "\" size=\"" + dt.Rows[0]["Size"] + "\" />";
                    Results = "<input type=\"password\" id=\"" + Field + "\" name=\"" + Field + "\" class=\"input " + Validator + "\" title=\"" + Prompt + "\" maxlength=\"" + dt.Rows[0]["MaxLength"] + "\" size=\"" + dt.Rows[0]["Size"] + "\" />";
                    break;
                    #endregion
                case "MultiLine":
                    #region �����ı�
                    Results = "<textarea name=\"" + Field + "\" id=\"" + Field + "\" style=\"width:" + dt.Rows[0]["Width"] + "px; height:" + dt.Rows[0]["Height"] + "px;\" class=\"" + Validator + "\" title=\"" + Prompt + "\">" + Val + "</textarea>";
                    break;
                    #endregion
                case "Editor":
                    #region �༭��
                    string Editor = "";
                    if (dt.Rows[0]["EditorType"].ToString() == "1")
                    {
                        Editor = "Mini";
                    }
                    else if (dt.Rows[0]["EditorType"].ToString() == "2")
                    {
                        Editor = "Simple";
                    }
                    else
                    {
                        Editor = "Default";
                    }
                    Results = "<input type=\"hidden\" id=\"" + Field + "\" name=\"" + Field + "\" value=\"" + Val + "\" /><iframe id=\"" + Field + "___Frame\" src=\"../../WebEditor/editor/fckeditor.html?InstanceName=" + Field + "&amp;Toolbar=" + Editor + "\" width=\"" + dt.Rows[0]["Width"] + "\" height=\"" + dt.Rows[0]["Height"] + "\" frameborder=\"no\" scrolling=\"no\"></iframe>";
                    // Results = "<fckeditorv2:FCKeditor id=\"" + Field + "\" runat=\"server\" Width=\"" + dt.Rows[0]["Width"] + "\" BasePath=\"/WebEditor/\" Height=\"" + dt.Rows[0]["Height"] + "\" ToolbarSet=\"" + Editor + "\" SkinPath=\"/WebEditor/editor/skins /silver/ \"></fckeditorv2:FCKeditor>";   
                    //Results = "<script type=\"text/javascript\" language=\"javascript\">\n";
                    //Results += "window.onload = function()\n";
                    //Results += "{";
                    //Results += "    var sBasePath = \"../../WebEditor/\";\n";
                    //Results += "    var oFCKeditor = new FCKeditor( \"" + Field + "\" );\n";
                    //Results += "    oFCKeditor.BasePath	= sBasePath ;\n";
                    //Results += "    oFCKeditor.ToolbarSet = \"" + Editor + "\";\n";
                    //Results += "    oFCKeditor.Config[\"SkinPath\"] = sBasePath+\"editor/skins/silver/\";\n";
                    //Results += "    oFCKeditor.Width = \"" + dt.Rows[0]["Width"] + "\";\n";
                    //Results += "    oFCKeditor.Height = \"" + dt.Rows[0]["Height"] + "\";\n";
                    //Results += "    oFCKeditor.ReplaceTextarea();\n";
                    //Results += "}\n";
                    //Results += "    </script>\n";
                    //Results += "<textarea name=\"" + Field + "\" id=\"" + Field + "\" class=\"" + Validator + "\" title=\"" + Prompt + "\">" + Val + "</textarea>";
                    break;
                    #endregion
                case "Select":
                    #region ѡ��
                    string[] Arry = dt.Rows[0]["Options"].ToString().Split(new string[1] { "\r\n" }, System.StringSplitOptions.None);
                    string OptionsType = dt.Rows[0]["OptionsType"].ToString();
                    if (Arry.Length > 0 && !String.IsNullOrEmpty(OptionsType))
                    {
                        if (OptionsType == "select")
                        {
                            Results += "<select name=\"" + Field + "\" id=\"" + Field + "\" class=\"" + Validator + "\" title=\"" + Prompt + "\">";
                            Results += "<option value=\"\">��ѡ��</option>";
                            foreach (string I in Arry)
                            {
                                Results += "<option value=\"" + I + "\"" + StringDeal.GetSelected(Val, I);
                                Results += ">" + I + "</option>\n";
                            }
                            Results += "</select>";
                        }
                        else
                        {
                            for (int I = 0; I < Arry.Length; I++)
                            {
                                Results += "<input type=\"" + OptionsType + "\" id=\"" + Field + I + "\" name=\"" + Field + "\" value=\"" + Arry[I] + "\"" + StringDeal.GetChecked(Val, Arry[I]) + ">" + Arry[I] + " ";
                            }
                        }
                    }
                    break;
                    #endregion
                case "Number":
                    #region ����
                    Results += "<input type=\"text\" class=\"input " + Validator + "\" title=\"" + Prompt + "\" maxlength=\"16\" size=\"5\" name=\"" + Field + "\" id=\"" + Field + "\" value=\"" + Val + "\" />";
                    break;
                    #endregion
                case "DateTime":
                    #region ����/ʱ������
                    string onFocus = "";
                    if (dt.Rows[0]["DateTime"].ToString() == "yyyy-mm-dd")
                    {
                        onFocus = "yyyy-MM-dd";
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
                        onFocus = "yyyy-MM-dd HH:mm:ss";
                        if (Val.ToString() == "getdate()")
                        {
                            Val = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                        }
                        else
                        {
                            Val = StringDeal.GetDateTime(Val, "yyyy-MM-dd HH:mm");
                        }
                    }
                    Results += "<input readonly=\"readonly\" type=\"text\" class=\"input " + Validator + "\" onfocus=\"WdatePicker({skin:'YcloudRed',lang:'zh-cn',isShowClear:true,readOnly:true,dateFmt:'" + onFocus + "'})\" title=\"" + Prompt + "\" maxlength=\"25\" size=\"25\" name=\"" + Field + "\" id=\"" + Field + "\" value=\"" + Val + "\" />";
                    Results += "<script language=\"javascript\" type=\"text/javascript\" src='../Js/WdatePicker/WdatePicker.js'></script>";
                    break;
                    #endregion
                case "Image":
                    #region ͼƬ�ϴ�
                    Results += "<input type=\"text\" id=\"" + Field + "\" readonly=\"readonly\" class=\"input2 " + Validator + "\" name=\"" + Field + "\" value=\"" + StringDeal.StrFormat(Val) + "\" /> <input type=\"button\" class=\"divbutton\" value=\"ͼƬ�ϴ�\" onclick=\"UploadImage('" + Field + "','" + GetConfig.System("ManagePath") + "'," + CID + ");\" />";
                    break;
                    #endregion
                case "File":
                    #region �ļ��ϴ�
                    string UploadFileType = dt.Rows[0]["UploadFileType"].ToString();
                    Results += "<input type=\"text\" id=\"" + Field + "\" readonly=\"readonly\" class=\"input2 " + Validator + "\" name=\"" + Field + "\" value=\"" + StringDeal.StrFormat(Val) + "\" /> <input type=\"button\" class=\"divbutton\" value=\"�ļ��ϴ�\" onclick=\"UploadFile('" + Field + "','" + GetConfig.System("ManagePath") + "','" + UploadFileType + "'," + CID + ");\" />";
                    break;
                    #endregion
                case "BatchImage":
                    #region ͼƬ�����ϴ�
                    Results += "<select id=\"" + Field + "_Select\" name=\"" + Field + "_Select\" size=\"10\" style=\"width:500px;\">";
                    foreach (string x in StringDeal.StrFormat(Val).Split(','))
                    {
                        if (x.Length > 0)
                        {
                            Results += "<option value=\"" + x + "\">" + x + "</option>";
                        }
                    }
                    Results += "</select>";
                    Results += "<br /><input id=\"" + Field + "\" name=\"" + Field + "\" type=\"hidden\"><input type=\"button\" class=\"divbutton\" value=\"ͼƬ�ϴ�\" onclick=\"BatchUploadImage('" + Field + "_Select','" + GetConfig.System("ManagePath") + "'," + CID + ");\" /> <input type=\"button\" class=\"divbutton\" value=\"����\" onclick=\"Upload_Move('" + Field + "_Select','up');\" /> <input type=\"button\" class=\"divbutton\" value=\"����\" onclick=\"Upload_Move('" + Field + "_Select','down');\" /> <input type=\"button\" class=\"divbutton\" value=\"ɾ��\" onclick=\"Upload_Remove('" + Field + "_Select');\" /> <input type=\"button\" class=\"divbutton\" value=\"ȫ��ɾ��\" onclick=\"Upload_AllRemove('" + Field + "_Select');\" /><script language='javascript'>ListText('" + Field + "_Select');</script>";
                    break;
                    #endregion
                case "BatchFile":
                    #region �ļ������ϴ�
                    string UploadFileType1 = dt.Rows[0]["UploadFileType"].ToString();
                    Results += "<select id=\"" + Field + "_Select\" name=\"" + Field + "_Select\" size=\"10\" style=\"width:500px;\">";
                    foreach (string x in StringDeal.StrFormat(Val).Split(','))
                    {
                        if (x.Length > 0)
                        {
                            Results += "<option value=\"" + x + "\">" + x + "</option>";
                        }
                    }
                    Results += "</select>";
                    Results += "<br /><input id=\"" + Field + "\" name=\"" + Field + "\" type=\"hidden\"><input type=\"button\" class=\"divbutton\" value=\"�ļ��ϴ�\" onclick=\"BatchUploadFile('" + Field + "_Select','" + GetConfig.System("ManagePath") + "','" + UploadFileType1 + "');\" /> <input type=\"button\" class=\"divbutton\" value=\"����\" onclick=\"Upload_Move('" + Field + "_Select','up');\" /> <input type=\"button\" class=\"divbutton\" value=\"����\" onclick=\"Upload_Move('" + Field + "_Select','down');\" /> <input type=\"button\" class=\"divbutton\" value=\"ɾ��\" onclick=\"Upload_Remove('" + Field + "_Select');\" /> <input type=\"button\" class=\"divbutton\" value=\"ȫ��ɾ��\" onclick=\"Upload_AllRemove('" + Field + "_Select');\" /><script language='javascript'>ListText('" + Field + "_Select');</script>";
                    break;
                    #endregion
                case "OtherMenu":
                    #region �����ڵ�
                    HXD.BLL.bMenu bM = new HXD.BLL.bMenu();
                    
                    HXD.ModelField.BLL.GetAttribute ga = new HXD.ModelField.BLL.GetAttribute();
                    FieldType FieldType = new FieldType();
                    FieldType.dsList = (DataSet)bM.MenuList();
                    
                    string MenuId = dt.Rows[0]["MenuId"].ToString();
                    Results += "<select name='" + Field + "' id='" + Field + "'>";
                    Results += "<option value=''>ѡ��</option>";
                    Results += FieldType.MenuList(MenuId, "��", Val);
                    Results += "</select><br />";
                    break;
                    #endregion
                case "Provinces":
                    #region ʡ�ݳ�������
                    Results += "<script type=\"text/javascript\" src=\"../Js/Pcasunzip.js\"></script>";
                    Results += "<select name=\"" + Field + "_Province\"></select><select name=\"" + Field + "_City\"></select><select name=\"" + Field + "_Area\"></select><input type=\"hidden\" name=\"" + Field + "\" value=\"null\"/>";
                    if (Val.ToString() != string.Empty)
                    {
                        string[] Vals = Val.ToString().Split('-');
                        if (Vals.Length == 3)
                        { Results += "<script type=\"text/javascript\">new PCAS(\"" + Field + "_Province\",\"" + Field + "_City\",\"" + Field + "_Area\",\"" + Vals[0] + "\",\"" + Vals[1] + "\",\"" + Vals[2] + "\")</script>"; }
                        else { Results += "<script type=\"text/javascript\">new PCAS(\"" + Field + "_Province\",\"" + Field + "_City\",\"" + Field + "_Area\")</script>"; }
                    }
                    else { Results += "<script type=\"text/javascript\">new PCAS(\"" + Field + "_Province\",\"" + Field + "_City\",\"" + Field + "_Area\")</script>"; }
                    break;
                    #endregion
                case "Increment":
                    #region ��̬����(�����ı�)
                    Results = "<input id=\"" + Field + "\" name=\"" + Field + "\" class=\"input " + Validator + "\" title=\"" + Prompt + "\" value=\"" + StringDeal.StrFormat(Val) + "\" maxlength=\"" + dt.Rows[0]["MaxLength"] + "\" size=\"" + dt.Rows[0]["Size"] + "\" />";
                    Results += "<script type=\"text/javascript\">";
                    Results += "var " + Field + "obj = new AutoAdd();";
                    Results += Field + "obj.ElementName = \"" + Field + "\";";
                    Results += Field + "obj.objName = \"" + Field + "obj\";";
                    Results += Field + "obj.MaxLength = \"" + dt.Rows[0]["MaxLength"] + "\";";
                    Results += Field + "obj.Size = \"" + dt.Rows[0]["Size"] + "\";";
                    Results += "jQuery(document).ready(function(){" + Field + "obj.binder(\"\");});";
                    Results += "</script>";
                    break;
                    #endregion
                //////////////////////////////
            }
            return Results;
        }

        public string GetType(object Val, XmlDoc xml, object Name, string Action)
        {
            string Results = "";
            DataTable dt = xml.GetDataTable("Name='" + Name.ToString() + "'", "");
            if (String.IsNullOrEmpty(Val.ToString()))
            {
                Val = dt.Rows[0]["Field_Text"].ToString();
            }
            string Field = Name.ToString();
            string Type = dt.Rows[0]["Type"].ToString();
            string Note = dt.Rows[0]["Note"].ToString();
            string Prompt = dt.Rows[0]["Prompt"].ToString();
            string Validator = dt.Rows[0]["Validator"].ToString();
            switch (Type)
            {
                case "SingleLine":
                    #region �����ı�
                    Results = "<input id=\"" + Field + "\" name=\"" + Field + "\" class=\"input " + Validator + "\" title=\"" + Prompt + "\" value=\"" + StringDeal.StrFormat(Val) + "\" maxlength=\"" + dt.Rows[0]["MaxLength"] + "\" size=\"" + dt.Rows[0]["Size"] + "\" />";
                    break;
                    #endregion
                case "Password":
                    #region ����
                    //Results = "<input type=\"password\" id=\"" + Field + "\" name=\"" + Field + "\" class=\"input " + Validator + "\" title=\"" + Prompt + "\" value=\"" + StringDeal.StrFormat(Val) + "\" maxlength=\"" + dt.Rows[0]["MaxLength"] + "\" size=\"" + dt.Rows[0]["Size"] + "\" />";
                    Results = "<input type=\"password\" id=\"" + Field + "\" name=\"" + Field + "\" class=\"input " + Validator + "\" title=\"" + Prompt + "\" maxlength=\"" + dt.Rows[0]["MaxLength"] + "\" size=\"" + dt.Rows[0]["Size"] + "\" />";
                    break;
                    #endregion
                case "MultiLine":
                    #region �����ı�
                    Results = "<textarea name=\"" + Field + "\" id=\"" + Field + "\" style=\"width:" + dt.Rows[0]["Width"] + "px; height:" + dt.Rows[0]["Height"] + "px;\" class=\"" + Validator + "\" title=\"" + Prompt + "\">" + Val + "</textarea>";
                    break;
                    #endregion
                case "Editor":
                    #region �༭��
                    string Editor = "";
                    if (dt.Rows[0]["EditorType"].ToString() == "1")
                    {
                        Editor = "Mini";
                    }
                    else if (dt.Rows[0]["EditorType"].ToString() == "2")
                    {
                        Editor = "Simple";
                    }
                    else
                    {
                        Editor = "Default";
                    }
                    Results = "<input type=\"hidden\" id=\"" + Field + "\" name=\"" + Field + "\" value=\"" + Val + "\" /><iframe id=\"" + Field + "___Frame\" src=\"../../WebEditor/editor/fckeditor.html?InstanceName=" + Field + "&amp;Toolbar=" + Editor + "\" width=\"" + dt.Rows[0]["Width"] + "\" height=\"" + dt.Rows[0]["Height"] + "\" frameborder=\"no\" scrolling=\"no\"></iframe>";
                    //Results = "<script type=\"text/javascript\" language=\"javascript\">\n";
                    //Results += "window.onload = function()\n";
                    //Results += "{";
                    //Results += "    var sBasePath = \"../../WebEditor/\";\n";
                    //Results += "    var oFCKeditor = new FCKeditor( \"" + Field + "\" );\n";
                    //Results += "    oFCKeditor.BasePath	= sBasePath ;\n";
                    //Results += "    oFCKeditor.ToolbarSet = \"" + Editor + "\";\n";
                    //Results += "    oFCKeditor.Config[\"SkinPath\"] = sBasePath+\"editor/skins/silver/\";\n";
                    //Results += "    oFCKeditor.Width = \"" + dt.Rows[0]["Width"] + "\";\n";
                    //Results += "    oFCKeditor.Height = \"" + dt.Rows[0]["Height"] + "\";\n";
                    //Results += "    oFCKeditor.ReplaceTextarea();\n";
                    //Results += "}\n";
                    //Results += "    </script>\n";
                    //Results += "<textarea name=\"" + Field + "\" id=\"" + Field + "\" class=\"" + Validator + "\" title=\"" + Prompt + "\">" + Val + "</textarea>";
                    break;
                    #endregion
                case "Select":
                    #region ѡ��
                    string[] Arry = dt.Rows[0]["Options"].ToString().Split(new string[1] { "\r\n" }, System.StringSplitOptions.None);
                    string OptionsType = dt.Rows[0]["OptionsType"].ToString();
                    if (Arry.Length > 0 && !String.IsNullOrEmpty(OptionsType))
                    {
                        if (OptionsType == "select")
                        {
                            Results += "<select name=\"" + Field + "\" id=\"" + Field + "\" class=\"" + Validator + "\" title=\"" + Prompt + "\">";
                            Results += "<option value=\"\">��ѡ��</option>";
                            foreach (string I in Arry)
                            {
                                Results += "<option value=\"" + I + "\"" + StringDeal.GetSelected(Val, I);
                                Results += ">" + I + "</option>\n";
                            }
                            Results += "</select>";
                        }
                        else
                        {
                            for (int I = 0; I < Arry.Length; I++)
                            {
                                Results += "<input type=\"" + OptionsType + "\" id=\"" + Field + I + "\" name=\"" + Field + "\" value=\"" + Arry[I] + "\"" + StringDeal.GetChecked(Val, Arry[I]) + ">" + Arry[I];
                            }
                        }
                    }
                    break;
                    #endregion
                case "Number":
                    #region ����
                    Results += "<input type=\"text\" class=\"input " + Validator + "\" title=\"" + Prompt + "\" maxlength=\"16\" size=\"5\" name=\"" + Field + "\" id=\"" + Field + "\" value=\"" + Val + "\" />";
                    break;
                    #endregion
                case "DateTime":
                    #region ����/ʱ������
                    string onFocus = "";
                    if (dt.Rows[0]["DateTime"].ToString() == "yyyy-mm-dd")
                    {
                        //onFocus = "setDay(this);";
                        onFocus = "yyyy-MM-dd";
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
                        //onFocus = "setDayHM(this);";
                        onFocus = "yyyy-MM-dd HH:mm:ss";
                        if (Val.ToString() == "getdate()")
                        {
                            Val = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                        }
                        else
                        {
                            Val = StringDeal.GetDateTime(Val, "yyyy-MM-dd HH:mm");
                        }
                    }
                    //Results += "<input readonly=\"readonly\" type=\"text\" onclick=\"" + onFocus + "\" class=\"input " + Validator + "\" title=\"" + Prompt + "\" maxlength=\"25\" size=\"25\" name=\"" + Field + "\" id=\"" + Field + "\" value=\"" + Val + "\" />";
                    //Results += "<script language=\"javascript\" type=\"text/javascript\" src='../js/calendar.js'></script>";
                    Results += "<input readonly=\"readonly\" type=\"text\" class=\"input " + Validator + "\" onfocus=\"WdatePicker({skin:'YcloudRed',lang:'zh-cn',isShowClear:true,readOnly:true,dateFmt:'" + onFocus + "'})\" title=\"" + Prompt + "\" maxlength=\"25\" size=\"25\" name=\"" + Field + "\" id=\"" + Field + "\" value=\"" + Val + "\" />";
                    Results += "<script language=\"javascript\" type=\"text/javascript\" src='../Js/WdatePicker/WdatePicker.js'></script>";
                    break;
                    #endregion
                case "Image":
                    #region ͼƬ�ϴ�
                    //string UploadImagePath = GetConfig.Image("UploadImagePath");
                    //bool IsUploadImage = StringDeal.ToBool(dt.Rows[0]["IsUploadImage"]);
                    //string UploadImageSize = dt.Rows[0]["UploadImageSize"].ToString();
                    //string UploadImageType = dt.Rows[0]["UploadImageType"].ToString();
                    //bool IsSelect = StringDeal.ToBool(dt.Rows[0]["IsSelect"]);
                    //bool IsMark = StringDeal.ToBool(dt.Rows[0]["IsMark"]);
                    //string MarkImage = dt.Rows[0]["MarkImage"].ToString();
                    //bool IsThumb = StringDeal.ToBool(dt.Rows[0]["IsThumb"]);
                    //string ThumbSize = dt.Rows[0]["ThumbSize"].ToString();

                    Results += "<input type=\"text\" id=\"" + Field + "\" readonly=\"readonly\" class=\"input2 " + Validator + "\" name=\"" + Field + "\" value=\"" + StringDeal.StrFormat(Val) + "\" /> <input type=\"button\" class=\"divbutton\" value=\"ͼƬ�ϴ�\" onclick=\"UploadImage('" + Field + "','" + GetConfig.System("ManagePath") + "');\" />";
                    break;
                    #endregion
                case "File":
                    #region �ļ��ϴ�
                    //string UploadFilePath = GetConfig.File("UploadFilePath");
                    //bool IsUploadFile = StringDeal.ToBool(dt.Rows[0]["IsUploadFile"]);
                    //string UploadFileSize = dt.Rows[0]["UploadFileSize"].ToString();
                    string UploadFileType = dt.Rows[0]["UploadFileType"].ToString();
                    //bool IsSelect1 = StringDeal.ToBool(dt.Rows[0]["IsSelect"]);
                    Results += "<input type=\"text\" id=\"" + Field + "\" readonly=\"readonly\" class=\"input2 " + Validator + "\" name=\"" + Field + "\" value=\"" + StringDeal.StrFormat(Val) + "\" /> <input type=\"button\" class=\"divbutton\" value=\"�ļ��ϴ�\" onclick=\"UploadFile('" + Field + "','" + GetConfig.System("ManagePath") + "','" + UploadFileType + "');\" />";
                    break;
                    #endregion
                case "BatchImage":
                    #region ͼƬ�����ϴ�
                    //string UploadImagePath = GetConfig.Image("UploadImagePath");
                    //bool IsUploadImage = StringDeal.ToBool(dt.Rows[0]["IsUploadImage"]);
                    //string UploadImageSize = dt.Rows[0]["UploadImageSize"].ToString();
                    //string UploadImageType = dt.Rows[0]["UploadImageType"].ToString();
                    //bool IsSelect = StringDeal.ToBool(dt.Rows[0]["IsSelect"]);
                    //bool IsMark = StringDeal.ToBool(dt.Rows[0]["IsMark"]);
                    //string MarkImage = dt.Rows[0]["MarkImage"].ToString();
                    //bool IsThumb = StringDeal.ToBool(dt.Rows[0]["IsThumb"]);
                    //string ThumbSize = dt.Rows[0]["ThumbSize"].ToString();
                    Results += "<select id=\"" + Field + "_Select\" name=\"" + Field + "_Select\" size=\"10\" style=\"width:500px;\">";
                    foreach (string x in StringDeal.StrFormat(Val).Split(','))
                    {
                        if (x.Length > 0)
                        {
                            Results += "<option value=\"" + x + "\">" + x + "</option>";
                        }
                    }
                    Results += "</select>";
                    Results += "<br /><input id=\"" + Field + "\" name=\"" + Field + "\" type=\"hidden\"><input type=\"button\" class=\"divbutton\" value=\"ͼƬ�ϴ�\" onclick=\"BatchUploadImage('" + Field + "_Select','" + GetConfig.System("ManagePath") + "','');\" /> <input type=\"button\" class=\"divbutton\" value=\"����\" onclick=\"Upload_Move('" + Field + "_Select','up');\" /> <input type=\"button\" class=\"divbutton\" value=\"����\" onclick=\"Upload_Move('" + Field + "_Select','down');\" /> <input type=\"button\" class=\"divbutton\" value=\"ɾ��\" onclick=\"Upload_Remove('" + Field + "_Select');\" /> <input type=\"button\" class=\"divbutton\" value=\"ȫ��ɾ��\" onclick=\"Upload_AllRemove('" + Field + "_Select');\" /><script language='javascript'>ListText('" + Field + "_Select');</script>";
                    break;
                    #endregion
                case "BatchFile":
                    #region �ļ������ϴ�
                    //string UploadFilePath = GetConfig.File("UploadFilePath");
                    //bool IsUploadFile = StringDeal.ToBool(dt.Rows[0]["IsUploadFile"]);
                    //string UploadFileSize = dt.Rows[0]["UploadFileSize"].ToString();
                    string UploadFileType1 = dt.Rows[0]["UploadFileType"].ToString();
                    //bool IsSelect1 = StringDeal.ToBool(dt.Rows[0]["IsSelect"]);
                    Results += "<select id=\"" + Field + "_Select\" name=\"" + Field + "_Select\" size=\"10\" style=\"width:500px;\">";
                    foreach (string x in StringDeal.StrFormat(Val).Split(','))
                    {
                        if (x.Length > 0)
                        {
                            Results += "<option value=\"" + x + "\">" + x + "</option>";
                        }
                    }
                    Results += "</select>";
                    Results += "<br /><input id=\"" + Field + "\" name=\"" + Field + "\" type=\"hidden\"><input type=\"button\" class=\"divbutton\" value=\"�ļ��ϴ�\" onclick=\"BatchUploadFile('" + Field + "_Select','" + GetConfig.System("ManagePath") + "','" + UploadFileType1 + "');\" /> <input type=\"button\" class=\"divbutton\" value=\"����\" onclick=\"Upload_Move('" + Field + "_Select','up');\" /> <input type=\"button\" class=\"divbutton\" value=\"����\" onclick=\"Upload_Move('" + Field + "_Select','down');\" /> <input type=\"button\" class=\"divbutton\" value=\"ɾ��\" onclick=\"Upload_Remove('" + Field + "_Select');\" /> <input type=\"button\" class=\"divbutton\" value=\"ȫ��ɾ��\" onclick=\"Upload_AllRemove('" + Field + "_Select');\" /><script language='javascript'>ListText('" + Field + "_Select');</script>";
                    break;
                    #endregion
                case "OtherMenu":
                    #region �����ڵ�
                    HXD.BLL.bMenu bM = new HXD.BLL.bMenu();
                    HXD.BLL.bzhubo zb = new HXD.BLL.bzhubo();
                    HXD.ModelField.BLL.GetAttribute ga = new HXD.ModelField.BLL.GetAttribute();
                    this.dsList = (DataSet)bM.MenuList();
                    this.dszhubo = (DataSet)zb.GetAllList();
                    string MenuId = dt.Rows[0]["MenuId"].ToString();
                    Results += "<select name='" + Field + "' id='" + Field + "'>";
                    Results += "<option value=''>ѡ��</option>";
                    Results += MenuList(MenuId, "��", Val);
                    Results += "</select><br />";
                    break;
                    #endregion
                case "Provinces":
                    #region ʡ�ݳ�������
                    Results += "<script type=\"text/javascript\" src=\"../Js/Pcasunzip.js\"></script>";
                    Results += "<select name=\"" + Field + "_Province\"></select><select name=\"" + Field + "_City\"></select><select name=\"" + Field + "_Area\"></select><input type=\"hidden\" name=\"" + Field + "\" value=\"null\"/>";
                    if (Val.ToString() != string.Empty)
                    {
                        string[] Vals = Val.ToString().Split('-');
                        if (Vals.Length == 3)
                        { Results += "<script type=\"text/javascript\">new PCAS(\"" + Field + "_Province\",\"" + Field + "_City\",\"" + Field + "_Area\",\"" + Vals[0] + "\",\"" + Vals[1] + "\",\"" + Vals[2] + "\")</script>"; }
                        else { Results += "<script type=\"text/javascript\">new PCAS(\"" + Field + "_Province\",\"" + Field + "_City\",\"" + Field + "_Area\")</script>"; }
                    }
                    else { Results += "<script type=\"text/javascript\">new PCAS(\"" + Field + "_Province\",\"" + Field + "_City\",\"" + Field + "_Area\")</script>"; }
                    break;
                    #endregion
                case "Increment":
                    #region ��̬����(�����ı�)
                    Results = "<input id=\"" + Field + "\" name=\"" + Field + "\" class=\"input " + Validator + "\" title=\"" + Prompt + "\" value=\"" + StringDeal.StrFormat(Val) + "\" maxlength=\"" + dt.Rows[0]["MaxLength"] + "\" size=\"" + dt.Rows[0]["Size"] + "\" />";
                    Results += "<script type=\"text/javascript\">";
                    Results += "var " + Field + "obj = new AutoAdd();";
                    Results += Field + "obj.ElementName = \"" + Field + "\";";
                    Results += Field + "obj.objName = \"" + Field + "obj\";";
                    Results += Field + "obj.MaxLength = \"" + dt.Rows[0]["MaxLength"] + "\";";
                    Results += Field + "obj.Size = \"" + dt.Rows[0]["Size"] + "\";";
                    Results += "jQuery(document).ready(function(){" + Field + "obj.binder(\"\");});";
                    Results += "</script>";
                    break;
                    #endregion
                /////////////////////////////
            }
            return Results;
        }
        string temp = "";
        private string MenuList(object Id, string Separator, object MenuId)
        {
            if (int.Parse(Id.ToString()) == 1088)
            {

                 // ArrayList al = new ArrayList();
                 //DataSet ds = SqlHelper.ExecuteDataset(conn,CommandType.Text,"select * from dbo.Common_music_File");
                 //DataTable dt = ds.Tables[0];
                 //DataView dv = new DataView(dt,null,"Common_Music_FileName ASC",DataViewRowState.CurrentRows);//������ͼ��ɸѡ
                 //string strValue = "";
                 //foreach(DataRowView drv in dv)

                            //select * from tb_U_info where ClassId=8 and IsStatus=1 order by sort desc
                string sql = "select * from tb_U_info where ClassId=8 and IsStatus=1 order by sort desc";//��������
                DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
                //DataTable dt = ds.Tables[0];
                DataView dv = new DataView(ds.Tables[0]);
                dv.RowFilter = "";
                foreach (DataRowView dr in dv)
                {
                    temp += "<option value='" + dr["Id"] + "'" + StringDeal.GetSelected(dr["Id"], MenuId) + ">" + Separator + StringDeal.StrFormat(dr["Title"]) + "</option>";
                    //MenuList(StringDeal.ToInt(dr[0]), "��" + Separator, MenuId);
                }
            }
            else if (int.Parse(Id.ToString()) == 1089)
            {
                string sqll = "select * from tb_U_glfl where ClassId=540 and IsStatus=1";//���Է�������
                DataSet dss = HXD.DBUtility.SQLHelper.ExecuteDataset(sqll);
                //DataTable dt = ds.Tables[0];
                DataView dvv = new DataView(dss.Tables[0]);
                dvv.RowFilter = "";
                foreach (DataRowView drr in dvv)
                {
                    temp += "<option value='" + drr["Id"] + "'" + StringDeal.GetSelected(drr["Id"], MenuId) + ">" + Separator + StringDeal.StrFormat(drr["name"]) + "</option>";
                    //MenuList(StringDeal.ToInt(dr[0]), "��" + Separator, MenuId);
                }
            }
            else
            {
                DataView dv = new DataView(dsList.Tables[0]);
                dv.RowFilter = "ParentId = " + Id;
                foreach (DataRowView dr in dv)
                {
                    temp += "<option value='" + dr["Id"] + "'" + StringDeal.GetSelected(dr["Id"], MenuId) + ">" + Separator + StringDeal.StrFormat(dr["Title"]) + "</option>";
                    MenuList(StringDeal.ToInt(dr[0]), "��" + Separator, MenuId);
                }
            }
            return temp;
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
                case "SingleLine":
                    #region �����ı�
                    return "'" + StringDeal.RemoveUnsafeHtml(Val) + "'";
                    #endregion
                case "Password":
                    #region ����
                    return "'" + HXD.Common.Encryp.PassWordEncrypt(Val) + "'";
                    #endregion
                case "MultiLine":
                    #region �����ı�
                    return "'" + StringDeal.ReplaceSql(Val) + "'";
                    #endregion
                case "Editor":
                    #region �༭��
                    return "'" + StringDeal.ReplaceSql(Val) + "'";
                    #endregion
                case "Select":
                    #region �����˵�����ѡ����ѡ
                    return "'" + StringDeal.ReplaceSql(Val) + "'";
                    #endregion
                case "Number":
                    #region ����
                    return StringDeal.ToInt(Val).ToString();
                    #endregion
                case "DateTime":
                    #region ����/ʱ������
                    return "'" + StringDeal.GetDateTime(Val, "yyyy-MM-dd HH:mm:ss") + "'";
                    #endregion
                case "Image":
                    #region ͼƬ�ϴ�
                    return "'" + StringDeal.ReplaceSql(Val) + "'";
                    #endregion
                case "File":
                    #region �ļ��ϴ�
                    return "'" + StringDeal.ReplaceSql(Val) + "'";
                    #endregion
                case "OtherMenu":
                    #region �����ڵ�
                    return StringDeal.ToInt(Val).ToString();
                    #endregion
                case "Provinces":
                    #region ����ѡ��
                    return "'" + System.Web.HttpContext.Current.Request.Form[Field + "_Province"] + "-" + System.Web.HttpContext.Current.Request.Form[Field + "_City"] + "-" + System.Web.HttpContext.Current.Request.Form[Field + "_Area"] + "'";
                    #endregion
                case "Increment":
                    #region ��̬����(�����ı�)
                    Val = string.Empty;
                    string[] strs = System.Web.HttpContext.Current.Request.Form.GetValues(Field);
                    if (strs.Length > 1)
                    {
                        for (int c = 0; c < strs.Length; c++)
                        {
                            if (strs[c].Trim() != string.Empty)
                            { Val += strs[c] + "{$v$}"; }
                        }
                        Val = Val.Remove(Val.LastIndexOf("{$v$}"), "{$v$}".Length);
                    }
                    else
                    {
                        Val = System.Web.HttpContext.Current.Request.Form[Field];
                    }
                    return "'" + StringDeal.RemoveUnsafeHtml(Val) + "'";
                    #endregion
                default:
                    #region δ֪����
                    return "'" + StringDeal.RemoveUnsafeHtml(Val) + "'";
                    #endregion
                /////////////////////
            }
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using HXD.Common;

namespace HXD.ModelField.BLL
{
    public class Field
    {
        public HXD.ModelField.Model.Field Val;
        private XmlDoc xml;
        private string[] Field_Col, Field_Val;
        private readonly HXD.ModelField.SQLServerDAL.Field dal = new HXD.ModelField.SQLServerDAL.Field();
        /// <summary>
        /// 插入字段信息到XML
        /// </summary>
        public void InsertXml()
        {
            xml = new XmlDoc();
            xml.xmlfilePath = GetConfig.System("TableXmlPath") + Val.TableName + ".xml";
            switch (Val.Type)
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
            xml.InsertNode("/" + Val.TableName, "Field", Val.Default, Field_Col, Field_Val);
        }
        /// <summary>
        /// 从XML修改字段信息
        /// </summary>
        public void UpdateXml()
        {
            xml = new XmlDoc();
            xml.xmlfilePath = GetConfig.System("TableXmlPath") + Val.TableName + ".xml";
            switch (Val.Type)
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
            xml.UpdateNote("/" + Val.TableName, "Name", Val.Name, Val.Default, Field_Col, Field_Val);
        }
        /// <summary>
        /// 从XML删除字段信息
        /// </summary>
        public void DeleteXml()
        {
            xml = new XmlDoc();
            xml.xmlfilePath = GetConfig.System("TableXmlPath") + Val.TableName + ".xml";
            xml.DeleteNode("/" + Val.TableName, "Name", Val.Name);
        }
        /// <summary>
        /// 根据参数以及条件，创建字段
        /// </summary>
        public void InsertField()
        {
            dal.InsertField(Val);
        }
        /// <summary>
        /// 根据参数以及条件，修改字段
        /// </summary>
        public void UpdateField()
        {
            dal.UpdateField(Val);
        }
        #region 生成XML所需的属性名和属性值数组
        private void SingleLineType()
        {
            Field_Col = "Type|Name|Title|Note|Prompt|MaxLength|Size|Validator".Split('|');
            Field_Val = StringDeal.SplitString(Val.Type + "{$Split$}" + Val.Name + "{$Split$}" + Val.Title + "{$Split$}" + Val.Note + "{$Split$}" + Val.Prompt + "{$Split$}" + Val.MaxLength + "{$Split$}" + Val.Size + "{$Split$}" + Val.Validator, "{$Split$}");
        }
        private void PasswordType()
        {
            Field_Col = "Type|Name|Title|Note|Prompt|MaxLength|Size|PwdMode|Validator".Split('|');
            Field_Val = StringDeal.SplitString(Val.Type + "{$Split$}" + Val.Name + "{$Split$}" + Val.Title + "{$Split$}" + Val.Note + "{$Split$}" + Val.Prompt + "{$Split$}" + Val.MaxLength + "{$Split$}" + Val.Size + "{$Split$}" + Val.PwdMode + "{$Split$}" + Val.Validator, "{$Split$}");
        }
        private void MultiLineType()
        {
            Field_Col = "Type|Name|Title|Note|Prompt|Width|Height|Validator".Split('|');
            Field_Val = StringDeal.SplitString(Val.Type + "{$Split$}" + Val.Name + "{$Split$}" + Val.Title + "{$Split$}" + Val.Note + "{$Split$}" + Val.Prompt + "{$Split$}" + Val.Width + "{$Split$}" + Val.Height + "{$Split$}" + Val.Validator, "{$Split$}");
        }
        private void EditorType()
        {
            Field_Col = "Type|Name|Title|Note|Prompt|EditorType|Width|Height|Validator".Split('|');
            Field_Val = StringDeal.SplitString(Val.Type + "{$Split$}" + Val.Name + "{$Split$}" + Val.Title + "{$Split$}" + Val.Note + "{$Split$}" + Val.Prompt + "{$Split$}" + Val.EditorType + "{$Split$}" + Val.Width + "{$Split$}" + Val.Height + "{$Split$}" + Val.Validator, "{$Split$}");
        }
        private void SelectType()
        {
            Field_Col = "Type|Name|Title|Note|Prompt|Options|OptionsType|Validator".Split('|');
            Field_Val = StringDeal.SplitString(Val.Type + "{$Split$}" + Val.Name + "{$Split$}" + Val.Title + "{$Split$}" + Val.Note + "{$Split$}" + Val.Prompt + "{$Split$}" + Val.Options + "{$Split$}" + Val.OptionsType + "{$Split$}" + Val.Validator, "{$Split$}");
        }
        private void NumberType()
        {
            Field_Col = "Type|Name|Title|Note|Prompt|Bit|Validator".Split('|');
            Field_Val = StringDeal.SplitString(Val.Type + "{$Split$}" + Val.Name + "{$Split$}" + Val.Title + "{$Split$}" + Val.Note + "{$Split$}" + Val.Prompt + "{$Split$}" + Val.Bit + "{$Split$}" + Val.Validator, "{$Split$}");
        }
        private void DateTimeType()
        {
            Field_Col = "Type|Name|Title|Note|Prompt|DateTime|Validator".Split('|');
            Field_Val = StringDeal.SplitString(Val.Type + "{$Split$}" + Val.Name + "{$Split$}" + Val.Title + "{$Split$}" + Val.Note + "{$Split$}" + Val.Prompt + "{$Split$}" + Val.DateTime + "{$Split$}" + Val.Validator, "{$Split$}");
        }
        private void ImageType()
        {
            Field_Col = "Type|Name|Title|Note|Prompt|Validator".Split('|');
            Field_Val = StringDeal.SplitString(Val.Type + "{$Split$}" + Val.Name + "{$Split$}" + Val.Title + "{$Split$}" + Val.Note + "{$Split$}" + Val.Prompt + "{$Split$}" + Val.Validator, "{$Split$}");
        }
        private void FileType()
        {
            Field_Col = "Type|Name|Title|Note|Prompt|UploadFileType|Validator".Split('|');
            Field_Val = StringDeal.SplitString(Val.Type + "{$Split$}" + Val.Name + "{$Split$}" + Val.Title + "{$Split$}" + Val.Note + "{$Split$}" + Val.Prompt + "{$Split$}" + Val.UploadFileType + "{$Split$}" + Val.Validator, "{$Split$}");
        }
        private void BatchImageType()
        {
            Field_Col = "Type|Name|Title|Note|Prompt|Validator".Split('|');
            Field_Val = StringDeal.SplitString(Val.Type + "{$Split$}" + Val.Name + "{$Split$}" + Val.Title + "{$Split$}" + Val.Note + "{$Split$}" + Val.Prompt + "{$Split$}" + Val.Validator, "{$Split$}");
        }
        private void BatchFileType()
        {
            Field_Col = "Type|Name|Title|Note|Prompt|UploadFileType|Validator".Split('|');
            Field_Val = StringDeal.SplitString(Val.Type + "{$Split$}" + Val.Name + "{$Split$}" + Val.Title + "{$Split$}" + Val.Note + "{$Split$}" + Val.Prompt + "{$Split$}" + Val.UploadFileType + "{$Split$}" + Val.Validator, "{$Split$}");
        }
        private void OtherMenuType()
        {
            Field_Col = "Type|Name|Title|Note|Prompt|MenuId|Validator".Split('|');
            Field_Val = StringDeal.SplitString(Val.Type + "{$Split$}" + Val.Name + "{$Split$}" + Val.Title + "{$Split$}" + Val.Note + "{$Split$}" + Val.Prompt + "{$Split$}" + Val.MenuId + "{$Split$}" + Val.Validator, "{$Split$}");
        }
        private void ProvincesType()
        {
            Field_Col = "Type|Name|Title|Note|Prompt|Validator".Split('|');
            Field_Val = StringDeal.SplitString(Val.Type + "{$Split$}" + Val.Name + "{$Split$}" + Val.Title + "{$Split$}" + Val.Note + "{$Split$}" + Val.Prompt + "{$Split$}" + Val.Validator, "{$Split$}");
        }
        private void Increment()
        {
            Field_Col = "Type|Name|Title|Note|Prompt|MaxLength|Size|Validator".Split('|');
            Field_Val = StringDeal.SplitString(Val.Type + "{$Split$}" + Val.Name + "{$Split$}" + Val.Title + "{$Split$}" + Val.Note + "{$Split$}" + Val.Prompt + "{$Split$}" + Val.MaxLength + "{$Split$}" + Val.Size + "{$Split$}" + Val.Validator, "{$Split$}");
        }
        #endregion
    }
}

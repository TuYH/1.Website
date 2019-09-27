using System;
using System.Collections.Generic;
using System.Text;

namespace HXD.ModelField.Model
{
    #region 字段属性模型
    /// <summary>
    /// 字段属性模型
    /// </summary>
    public class Field
    {
        private string tablename;
        private string type;
        private string name;
        private string title;
        private string note;
        private string prompt;
        private int maxLength;
        private int size;
        private string defaults;
        private int width;
        private int height;
        private string pwdmode;
        private int editortype;
        private string options;
        private string optionstype;
        private int bit;
        private string datetime;
        private bool isuploadphoto;
        private int uploadphotosize;
        private string uploadphototype;
        private bool isselect;
        private bool ismark;
        private string markimage;
        private bool isthumb;
        private string thumbsize;
        private bool isuploadfile;
        private int uploadfilesize;
        private string uploadfiletype;
        private int menuid;
        private string validator;

        public string TableName
        {
            get { return tablename; }
            set { tablename = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Note
        {
            get { return note; }
            set { note = value; }
        }
        public string Prompt
        {
            get { return prompt; }
            set { prompt = value; }
        }
        public int MaxLength
        {
            get { return maxLength; }
            set { maxLength = value; }
        }
        public int Size
        {
            get { return size; }
            set { size = value; }
        }
        public string Default
        {
            get { return defaults; }
            set { defaults = value; }
        }
        public int Width
        {
            get { return width; }
            set { width = value; }
        }
        public int Height
        {
            get { return height; }
            set { height = value; }
        }
        public string PwdMode
        {
            get { return pwdmode; }
            set { pwdmode = value; }
        }
        public int EditorType
        {
            get { return editortype; }
            set { editortype = value; }
        }
        public string Options
        {
            get { return options; }
            set { options = value; }
        }
        public string OptionsType
        {
            get { return optionstype; }
            set { optionstype = value; }
        }
        public int Bit
        {
            get { return bit; }
            set { bit = value; }
        }
        public string DateTime
        {
            get { return datetime; }
            set { datetime = value; }
        }
        public bool IsUploadPhoto
        {
            get { return isuploadphoto; }
            set { isuploadphoto = value; }
        }
        public int UploadPhotoSize
        {
            get { return uploadphotosize; }
            set { uploadphotosize = value; }
        }
        public string UploadPhotoType
        {
            get { return uploadphototype; }
            set { uploadphototype = value; }
        }
        public bool IsSelect
        {
            get { return isselect; }
            set { isselect = value; }
        }
        public bool IsMark
        {
            get { return ismark; }
            set { ismark = value; }
        }
        public string MarkImage
        {
            get { return markimage; }
            set { markimage = value; }
        }
        public bool IsThumb
        {
            get { return isthumb; }
            set { isthumb = value; }
        }
        public string ThumbSize
        {
            get { return thumbsize; }
            set { thumbsize = value; }
        }
        public bool IsUploadFile
        {
            get { return isuploadfile; }
            set { isuploadfile = value; }
        }
        public int UploadFileSize
        {
            get { return uploadfilesize; }
            set { uploadfilesize = value; }
        }
        public string UploadFileType
        {
            get { return uploadfiletype; }
            set { uploadfiletype = value; }
        }
        public int MenuId
        {
            get { return menuid; }
            set { menuid = value; }
        }
        public string Validator
        {
            get { return validator; }
            set { validator = value; }
        }
    }
    #endregion
}

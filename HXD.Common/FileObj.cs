using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace HXD.Common
{
    public class FileObj
    {
        /// <summary>
        /// 日志目录
        /// </summary>
        public static string LogPath = AppDomain.CurrentDomain.BaseDirectory + "log\\";
        #region 构造函数
        private bool _alreadyDispose = false;
        public FileObj()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        ~FileObj()
        {
            Dispose();
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (_alreadyDispose) return;
            //if (isDisposing)
            //{
            //    if (xml != null)
            //    {
            //        xml = null;
            //    }
            //}
            _alreadyDispose = true;
        }
        #endregion

        #region IDisposable 成员

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region 取得文件后缀名(带点)
        /****************************************
         * 函数名称：GetPostfixStr(带点)
         * 功能说明：取得文件后缀名
         * 参    数：filename:文件名称
         * 调用示列：
         *           string filename = "aaa.aspx";        
         *           string s = EC.FileObj.GetPostfixStr(filename);         
        *****************************************/
        /// <summary>
        /// 取后缀名(带点).aspx
        /// </summary>
        /// <param name="filename">文件名</param>
        /// <returns>.gif|.html格式</returns>
        public static string GetPostfixStr(string filename)
        {
            int start = filename.LastIndexOf(".");
            int length = filename.Length;
            string postfix = filename.Substring(start, length - start);
            return postfix;
        }
        #endregion

        #region 取得文件后缀名(不带点)
        /****************************************
         * 函数名称：GetPostfixStr1
         * 功能说明：取得文件后缀名(不带点)
         * 参    数：filename:文件名称
         * 调用示列：
         *           string filename = "aaa.aspx";        
         *           string s = EC.FileObj.GetPostfixStr(filename);         
        *****************************************/
        /// <summary>
        /// 取后缀名(不带点)aspx
        /// </summary>
        /// <param name="filename">文件名</param>
        /// <returns>.gif|.html格式</returns>
        public static string GetPostfixStr1(string filename)
        {
            if (filename != string.Empty)
            {
                return filename.Substring(filename.LastIndexOf(".") + 1);
            }
            else
            { return ""; }
        }
        #endregion

        #region 取得文件名
        /****************************************
         * 函数名称：GetPostfixStr2
         * 功能说明：取得文件名
         * 参    数：filename:文件名称
         * 调用示列：
         *string filename = "aaa.aspx";        
         *string s = EC.FileObj.GetPostfixStr2(filename);         
        *****************************************/
        /// <summary>
        /// 取得文件名
        /// </summary>
        /// <param name="filename">文件名</param>
        /// <returns>.gif|.html格式</returns>
        public static string GetPostfixStr2(string filename)
        {
            if (filename != string.Empty)
            {
                if (filename.LastIndexOf("\\") > 0)
                { return filename.Substring((filename.LastIndexOf("\\") + 1), filename.LastIndexOf(".") - (filename.LastIndexOf("\\") + 1)); }
                else { return filename.Substring(0, filename.LastIndexOf(".")); }
            }
            else
            { return ""; }
        }
        #endregion

        #region 写文件
        /****************************************
         * 函数名称：WriteFile
         * 功能说明：当文件不存时，则创建文件，并追加文件
         * 参    数：Path:文件路径,Strings:文本内容
         * 调用示列：
         *           string Path = Server.MapPath("Default2.aspx");       
         *           string Strings = "这是我写的内容啊";
         *           EC.FileObj.WriteFile(Path,Strings);
        *****************************************/
        /// <summary>
        /// 写文件(相对路径)
        /// </summary>
        /// <param name="Path">(相对路径)文件路径</param>
        /// <param name="Strings">文件内容</param>
        /// <param name="Encoding">文件的编码格式</param>
        public static void WriteFile(string Path, string Strings, Encoding Encoding)
        {
            Path = HttpContext.Current.Server.MapPath(Path);
            if (!System.IO.File.Exists(Path))
            {
                //Directory.CreateDirectory(Path);//创建目录
                System.IO.FileStream f = System.IO.File.Create(Path);
                f.Close();
                f.Dispose();
            }
            System.IO.StreamWriter f2 = new System.IO.StreamWriter(Path, true, Encoding);
            f2.WriteLine(Strings);
            f2.Close();
            f2.Dispose();
        }
        #endregion

        #region 读文件
        /****************************************
         * 函数名称：ReadFile
         * 功能说明：读取文本内容
         * 参    数：Path:文件路径
         * 调用示列：
         *           string Path = Server.MapPath("Default2.aspx");       
         *           string s = EC.FileObj.ReadFile(Path);
        *****************************************/
        /// <summary>
        /// 读文件
        /// </summary>
        /// <param name="Path">(绝对路径)文件路径</param>
        /// <returns></returns>
        public static string ReadFile(string Path)
        {
            string s = "";
            if (!System.IO.File.Exists(Path))
                s = "不存在相应的目录";
            else
            {
                StreamReader f2 = new StreamReader(Path, System.Text.Encoding.Default);
                s = f2.ReadToEnd();
                f2.Close();
                f2.Dispose();
            }
            return s;
        }
        #endregion

        #region 追加文件
        /****************************************
         * 函数名称：FileAdd
         * 功能说明：追加文件内容
         * 参    数：Path:文件路径,strings:内容
         * 调用示列：
         *           string Path = Server.MapPath("Default2.aspx");     
         *           string Strings = "新追加内容";
         *           EC.FileObj.FileAdd(Path, Strings);
        *****************************************/
        /// <summary>
        /// 追加文件
        /// </summary>
        /// <param name="Path">文件路径</param>
        /// <param name="strings">内容</param>
        public static void FileAdd(string Path, string strings)
        {
            StreamWriter sw = File.AppendText(Path);
            sw.Write(strings);
            sw.Flush();
            sw.Close();
            sw.Dispose();
        }
        #endregion

        #region 拷贝文件
        /****************************************
         * 函数名称：FileCoppy
         * 功能说明：拷贝文件
         * 参    数：OrignFile:原始文件,NewFile:新文件路径
         * 调用示列：
         *           string OrignFile = Server.MapPath("Default2.aspx");     
         *           string NewFile = Server.MapPath("Default3.aspx");
         *           EC.FileObj.FileCoppy(OrignFile, NewFile);
        *****************************************/
        /// <summary>
        /// 拷贝文件
        /// </summary>
        /// <param name="OrignFile">原始文件</param>
        /// <param name="NewFile">新文件路径</param>
        public static void FileCoppy(string OrignFile, string NewFile)
        {
            File.Copy(OrignFile, NewFile, true);
        }

        #endregion

        #region 删除文件
        /****************************************
         * 函数名称：FileDel
         * 功能说明：删除文件
         * 参    数：Path:文件路径
         * 调用示列：
         *           string Path = Server.MapPath("Default3.aspx");    
         *           EC.FileObj.FileDel(Path);
        *****************************************/
        /// <summary>
        /// 删除文件(相对路径)
        /// </summary>
        /// <param name="Path">路径</param>
        public static void FileDel(string Path)
        {
            File.Delete(System.Web.HttpContext.Current.Server.MapPath(Path));
        }
        #endregion

        #region 移动文件
        /****************************************
         * 函数名称：FileMove
         * 功能说明：移动文件
         * 参    数：OrignFile:原始路径,NewFile:新文件路径
         * 调用示列：
         *            string OrignFile = Server.MapPath("../说明.txt");    
         *            string NewFile = Server.MapPath("http://www.cnblogs.com/说明.txt");
         *            EC.FileObj.FileMove(OrignFile, NewFile);
        *****************************************/
        /// <summary>
        /// 移动文件
        /// </summary>
        /// <param name="OrignFile">原始路径</param>
        /// <param name="NewFile">新路径</param>
        public static void FileMove(string OrignFile, string NewFile)
        {
            File.Move(OrignFile, NewFile);
        }
        #endregion

        #region 在当前目录下创建目录
        /****************************************
         * 函数名称：FolderCreate
         * 功能说明：在当前目录下创建目录
         * 参    数：OrignFolder:当前目录,NewFloder:新目录
         * 调用示列：
         *           string OrignFolder = Server.MapPath("test/");    
         *           string NewFloder = "new";
         *           EC.FileObj.FolderCreate(OrignFolder, NewFloder); 
        *****************************************/
        /// <summary>
        /// 在当前目录下创建目录
        /// </summary>
        /// <param name="OrignFolder">当前目录</param>
        /// <param name="NewFloder">新目录</param>
        public static void FolderCreate(string OrignFolder, string NewFloder)
        {
            Directory.SetCurrentDirectory(OrignFolder);
            Directory.CreateDirectory(NewFloder);
        }

        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="Path"></param>
        public static void FolderCreate(string Path)
        {
            // 判断目标目录是否存在如果不存在则新建之
            if (!Directory.Exists(Path))
                Directory.CreateDirectory(Path);
        }
        #endregion

        #region 创建目录
        public static void FileCreate(string Path)
        {
            FileInfo CreateFile = new FileInfo(Path); //创建文件 
            if (!CreateFile.Exists)
            {
                FileStream FS = CreateFile.Create();
                FS.Close();
            }
        }
        #endregion

        #region 递归删除文件夹目录及文件
        /****************************************
         * 函数名称：DeleteFolder
         * 功能说明：递归删除文件夹目录及文件
         * 参    数：dir:文件夹路径
         * 调用示列：
         *           string dir = Server.MapPath("test/"); 
         *           EC.FileObj.DeleteFolder(dir);       
        *****************************************/
        /// <summary>
        /// 递归删除文件夹目录及文件
        /// </summary>
        /// <param name="dir"></param> 
        /// <returns></returns>
        public static void DeleteFolder(string dir)
        {
            if (Directory.Exists(dir)) //如果存在这个文件夹删除之 
            {
                foreach (string d in Directory.GetFileSystemEntries(dir))
                {
                    if (File.Exists(d))
                        File.Delete(d); //直接删除其中的文件                        
                    else
                        DeleteFolder(d); //递归删除子文件夹 
                }
                Directory.Delete(dir, true); //删除已空文件夹                 
            }
        }

        #endregion

        #region 将指定文件夹下面的所有内容copy到目标文件夹下面 果目标文件夹为只读属性就会报错。
        /****************************************
         * 函数名称：CopyDir
         * 功能说明：将指定文件夹下面的所有内容copy到目标文件夹下面 果目标文件夹为只读属性就会报错。
         * 参    数：srcPath:原始路径,aimPath:目标文件夹
         * 调用示列：
         *           string srcPath = Server.MapPath("test/"); 
         *           string aimPath = Server.MapPath("test1/");
         *           EC.FileObj.CopyDir(srcPath,aimPath);   
        *****************************************/
        /// <summary>
        /// 指定文件夹下面的所有内容copy到目标文件夹下面
        /// </summary>
        /// <param name="srcPath">原始路径</param>
        /// <param name="aimPath">目标文件夹</param>
        public static void CopyDir(string srcPath, string aimPath)
        {
            try
            {
                // 检查目标目录是否以目录分割字符结束如果不是则添加之
                if (aimPath[aimPath.Length - 1] != Path.DirectorySeparatorChar)
                    aimPath += Path.DirectorySeparatorChar;
                // 判断目标目录是否存在如果不存在则新建之
                if (!Directory.Exists(aimPath))
                    Directory.CreateDirectory(aimPath);
                // 得到源目录的文件列表，该里面是包含文件以及目录路径的一个数组
                //如果你指向copy目标文件下面的文件而不包含目录请使用下面的方法
                //string[] fileList = Directory.GetFiles(srcPath);
                string[] fileList = Directory.GetFileSystemEntries(srcPath);
                //遍历所有的文件和目录
                foreach (string file in fileList)
                {
                    //先当作目录处理如果存在这个目录就递归Copy该目录下面的文件

                    if (Directory.Exists(file))
                        CopyDir(file, aimPath + Path.GetFileName(file));
                    //否则直接Copy文件
                    else
                        File.Copy(file, aimPath + Path.GetFileName(file), true);
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.ToString());
            }
        }
        #endregion

        #region 获取指定文件夹下所有子目录及文件(树形)
        /****************************************
         * 函数名称：GetFoldAll(string Path)
         * 功能说明：获取指定文件夹下所有子目录及文件(树形)
         * 参    数：Path:详细路径
         * 调用示列：
         *           string strDirlist = Server.MapPath("templates");       
         *           this.Literal1.Text = EC.FileObj.GetFoldAll(strDirlist); 
        *****************************************/
        /// <summary>
        /// 获取指定文件夹下所有子目录及文件
        /// </summary>
        /// <param name="Path">详细路径</param>
        public static string GetFoldAll(string Path)
        {
            string str = "";
            DirectoryInfo thisOne = new DirectoryInfo(Path);
            str = ListTreeShow(thisOne, 0, str);
            return str;

        }

        /****************************************
         * 函数名称：GetFileAll(string Path)
         * 功能说明：获取指定文件夹下所有文件(数组)
         * 参    数：Path:详细路径
         * 调用示列：
         *           string strDirlist = Server.MapPath("templates");       
         *           this.Literal1.Text = EC.FileObj.GetFoldAll(strDirlist); 
        *****************************************/
        /// <summary>
        /// 获取指定文件夹下所有子目录及文件(List)
        /// </summary>
        /// <param name="Path">详细路径</param>
        public static List<QuestionObject> GetFileAll(string BasePath, string Path)
        {
            List<QuestionObject> add = new List<QuestionObject>();
            DirectoryInfo thisOne = new DirectoryInfo(Path);
            BasePath = BasePath.Replace("/", "\\");
            add = ListTreeShowFile(BasePath, thisOne, add);
            return add;
        }


        /****************************************
         * 函数名称：GetFileDirAll(string Path)
         * 功能说明：获取当前文件夹下的目录及文件(List)
         * 参    数：Path:详细路径
         * 调用示列：
         *           string strDirlist = Server.MapPath("templates");       
         *           this.Literal1.Text = EC.FileObj.GetFoldAll(strDirlist); 
        *****************************************/
        /// <summary>
        /// 获取当前文件夹下的目录及图片文件(List)
        /// </summary>
        /// <param name="BasePath">根目录</param>
        /// <param name="Path">当前路径</param>
        /// <returns></returns>
        public static List<QuestionObject> GetFileDirAll(string BasePath, string Path)
        {
            List<QuestionObject> add = new List<QuestionObject>();
            DirectoryInfo thisOne = new DirectoryInfo(Path);//文件夹操作方法
            BasePath = BasePath.Replace("/", "\\");
            add = ListTreeShowFileDir(BasePath, thisOne, add);
            return add;
        }

        /// <summary>
        /// 获取指定文件夹下所有子目录及文件函数
        /// </summary>
        /// <param name="theDir">指定目录</param>
        /// <param name="nLevel">默认起始值,调用时,一般为0</param>
        /// <param name="Rn">用于迭加的传入值,一般为空</param>
        /// <returns></returns>
        public static string ListTreeShow(DirectoryInfo theDir, int nLevel, string Rn)//递归目录文件
        {
            DirectoryInfo[] subDirectories = theDir.GetDirectories();//获得目录
            foreach (DirectoryInfo dirinfo in subDirectories)
            {
                if (nLevel == 0)
                {
                    Rn += "├";
                }
                else
                {
                    string _s = "";
                    for (int i = 1; i <= nLevel; i++)
                    {
                        _s += "│&nbsp;";
                    }
                    Rn += _s + "├";
                }
                Rn += "<b>" + dirinfo.Name.ToString() + "</b><br />";
                FileInfo[] fileInfo = dirinfo.GetFiles();   //目录下的文件
                foreach (FileInfo fInfo in fileInfo)
                {
                    if (nLevel == 0)
                    {
                        Rn += "│&nbsp;├";
                    }
                    else
                    {
                        string _f = "";
                        for (int i = 1; i <= nLevel; i++)
                        {
                            _f += "│&nbsp;";
                        }
                        Rn += _f + "│&nbsp;├";
                    }
                    Rn += fInfo.Name.ToString() + " <br />";
                }
                Rn = ListTreeShow(dirinfo, nLevel + 1, Rn);
            }
            return Rn;
        }

        /// <summary>
        /// 获取指定目录下所有文件
        /// </summary>
        /// <param name="theDir">指定目录</param>
        /// <param name="Rn">用于迭加的传入值,一般为空</param>
        /// <returns></returns>
        public static List<QuestionObject> ListTreeShowFile(string BasePath, DirectoryInfo theDir, List<QuestionObject> Rn)//递归目录文件
        {
            DirectoryInfo[] subDirectories = theDir.GetDirectories();//获得目录
            foreach (DirectoryInfo dirinfo in subDirectories)
            {
                FileInfo[] fileInfo = dirinfo.GetFiles();//目录下的文件
                foreach (FileInfo fInfo in fileInfo)
                {
                    if (Web.Model.PublicModel.UpLoadFileType.IndexOf(GetPostfixStr1(fInfo.Name)) != -1)
                    {
                        QuestionObject qo = new QuestionObject();
                        qo.Filename = fInfo.FullName.Substring(fInfo.FullName.IndexOf(BasePath));
                        qo.Filename = qo.Filename.Replace("\\", "/");
                        Rn.Add(qo);
                    }
                }
                Rn = ListTreeShowFile(BasePath, dirinfo, Rn);
            }
            return Rn;
        }

        /// <summary>
        /// 获取指定目录下图片文件及文件夹
        /// </summary>
        /// <param name="theDir">指定目录</param>
        /// <param name="Rn">用于迭加的传入值,一般为空</param>
        /// <returns></returns>
        public static List<QuestionObject> ListTreeShowFileDir(string BasePath, DirectoryInfo theDir, List<QuestionObject> Rn)//递归目录文件
        {
            DirectoryInfo[] subDirectories = theDir.GetDirectories();//获得目录
            foreach (DirectoryInfo dirinfo in subDirectories)
            {
                QuestionObject qodir = new QuestionObject();
                qodir.Filename = dirinfo.FullName.Substring(dirinfo.FullName.IndexOf(BasePath)).Replace("\\", "/");
                qodir.Filetype = "dir";
                qodir.Name = dirinfo.Name;
                Rn.Add(qodir);
            }

            FileInfo[] fileInfo = theDir.GetFiles();//目录下的文件
            foreach (FileInfo fInfo in fileInfo)
            {
                if (Web.Model.PublicModel.UpLoadFileImage.IndexOf(GetPostfixStr1(fInfo.Name)) != -1)
                {
                    QuestionObject qofile = new QuestionObject();
                    qofile.Filename = fInfo.FullName.Substring(fInfo.FullName.IndexOf(BasePath)).Replace("\\", "/");
                    qofile.Filetype = "file";
                    qofile.Name = fInfo.Name;
                    Rn.Add(qofile);
                }
            }
            return Rn;
        }

        /// <summary>
        /// 列名类
        /// </summary>
        public class QuestionObject
        {
            private string _filename;
            /// <summary>
            /// 列名(全文件名)
            /// </summary>
            public string Filename
            {
                get { return _filename; }
                set { _filename = value; }
            }
            private string _filetype;
            /// <summary>
            /// 列名(文件类型)
            /// </summary>
            public string Filetype
            {
                get { return _filetype; }
                set { _filetype = value; }
            }
            private string _name;
            /// <summary>
            /// 列名(文件名)
            /// </summary>
            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }
        }

        /****************************************
         * 函数名称：GetFoldAll(string Path)
         * 功能说明：获取指定文件夹下所有子目录及文件(下拉框形)
         * 参    数：Path:详细路径
         * 调用示列：
         *            string strDirlist = Server.MapPath("templates");      
         *            this.Literal2.Text = EC.FileObj.GetFoldAll(strDirlist,"tpl","");
        *****************************************/
        /// <summary>
        /// 获取指定文件夹下所有子目录及文件(下拉框形)
        /// </summary>
        /// <param name="Path">详细路径</param>
        ///<param name="DropName">下拉列表名称</param>
        ///<param name="tplPath">默认选择模板名称</param>
        public static string GetFoldAll(string Path, string DropName, string tplPath)
        {
            string strDrop = "<select name=\"" + DropName + "\" id=\"" + DropName + "\"><option value=\"\">--请选择详细模板--</option>";
            string str = "";
            DirectoryInfo thisOne = new DirectoryInfo(Path);
            str = ListTreeShow(thisOne, 0, str, tplPath);
            return strDrop + str + "</select>";

        }

        /// <summary>
        /// 获取指定文件夹下所有子目录及文件函数
        /// </summary>
        /// <param name="theDir">指定目录</param>
        /// <param name="nLevel">默认起始值,调用时,一般为0</param>
        /// <param name="Rn">用于迭加的传入值,一般为空</param>
        /// <param name="tplPath">默认选择模板名称</param>
        /// <returns></returns>
        public static string ListTreeShow(DirectoryInfo theDir, int nLevel, string Rn, string tplPath)//递归目录文件
        {
            DirectoryInfo[] subDirectories = theDir.GetDirectories();//获得目录
            foreach (DirectoryInfo dirinfo in subDirectories)
            {
                Rn += "<option value=\"" + dirinfo.Name.ToString() + "\"";
                if (tplPath.ToLower() == dirinfo.Name.ToString().ToLower())
                {
                    Rn += " selected ";
                }
                Rn += ">";

                if (nLevel == 0)
                {
                    Rn += "┣";
                }
                else
                {
                    string _s = "";
                    for (int i = 1; i <= nLevel; i++)
                    {
                        _s += "│&nbsp;";
                    }
                    Rn += _s + "┣";
                }
                Rn += "" + dirinfo.Name.ToString() + "</option>";


                FileInfo[] fileInfo = dirinfo.GetFiles();   //目录下的文件
                foreach (FileInfo fInfo in fileInfo)
                {
                    Rn += "<option value=\"" + dirinfo.Name.ToString() + "/" + fInfo.Name.ToString() + "\"";
                    if (tplPath.ToLower() == fInfo.Name.ToString().ToLower())
                    {
                        Rn += " selected ";
                    }
                    Rn += ">";

                    if (nLevel == 0)
                    {
                        Rn += "│&nbsp;├";
                    }
                    else
                    {
                        string _f = "";
                        for (int i = 1; i <= nLevel; i++)
                        {
                            _f += "│&nbsp;";
                        }
                        Rn += _f + "│&nbsp;├";
                    }
                    Rn += fInfo.Name.ToString() + "</option>";
                }
                Rn = ListTreeShow(dirinfo, nLevel + 1, Rn, tplPath);
            }
            return Rn;
        }
        #endregion

        #region 获取文件夹大小
        /****************************************
         * 函数名称：GetDirectoryLength(string dirPath)
         * 功能说明：获取文件夹大小
         * 参    数：dirPath:文件夹详细路径
         * 调用示列：
         *           string Path = Server.MapPath("templates"); 
         *           Response.Write(EC.FileObj.GetDirectoryLength(Path));       
        *****************************************/
        /// <summary>
        /// 获取文件夹大小
        /// </summary>
        /// <param name="dirPath">文件夹路径</param>
        /// <returns></returns>
        public static long GetDirectoryLength(string dirPath)
        {
            if (!Directory.Exists(dirPath))
                return 0;
            long len = 0;
            DirectoryInfo di = new DirectoryInfo(dirPath);
            foreach (FileInfo fi in di.GetFiles())
            {
                len += fi.Length;
            }
            DirectoryInfo[] dis = di.GetDirectories();
            if (dis.Length > 0)
            {
                for (int i = 0; i < dis.Length; i++)
                {
                    len += GetDirectoryLength(dis[i].FullName);
                }
            }
            return len;
        }
        #endregion

        #region 获取指定文件详细属性
        /****************************************
         * 函数名称：GetFileAttibe(string filePath)
         * 功能说明：获取指定文件详细属性
         * 参    数：filePath:文件详细路径
         * 调用示列：
         *           string file = Server.MapPath("robots.txt"); 
         *            Response.Write(EC.FileObj.GetFileAttibe(file));         
        *****************************************/
        /// <summary>
        /// 获取指定文件详细属性
        /// </summary>
        /// <param name="filePath">文件详细路径</param>
        /// <returns></returns>
        public static string GetFileAttibe(string filePath)
        {
            string str = "";
            System.IO.FileInfo objFI = new System.IO.FileInfo(filePath);
            str += "详细路径:" + objFI.FullName + "<br>文件名称:" + objFI.Name + "<br>文件长度:" + objFI.Length.ToString() + "字节<br>创建时间" + objFI.CreationTime.ToString() + "<br>最后访问时间:" + objFI.LastAccessTime.ToString() + "<br>修改时间:" + objFI.LastWriteTime.ToString() + "<br>所在目录:" + objFI.DirectoryName + "<br>扩展名:" + objFI.Extension;
            return str;
        }
        #endregion

        /// <summary>
        /// 获取虚拟路径根目录的文件夹名称
        /// </summary>
        /// <returns></returns>
        public static string DirPath()
        {
            string path = HttpContext.Current.Server.MapPath("~/");
            path = path.Remove(path.LastIndexOf("\\"), 1);
            return path.Substring(path.LastIndexOf("\\"));
        }

        /// <summary>
        /// 获取日志目录下文件列表
        /// </summary>
        /// <returns></returns>
        public static SortedList<MyDateTime, string> GetFileList()
        {
            SortedList<MyDateTime, string> FileList = new SortedList<MyDateTime, string>();
            DirectoryInfo dirInfo = new DirectoryInfo(LogPath);
            foreach (FileSystemInfo var in dirInfo.GetFileSystemInfos())
            {
                if (var.Attributes != FileAttributes.Directory)
                {
                    FileList.Add(new MyDateTime(var.LastWriteTime), var.Name);
                }
            }
            return FileList;
        }

        /// <summary>
        /// 自定义日期类(实现倒排序)
        /// </summary>
        public class MyDateTime : IComparable
        {
            /// <summary>
            /// 日期
            /// </summary>
            public DateTime s_DateTime;
            /// <summary>
            /// 构造函数
            /// </summary>
            /// <param name="d"></param>
            public MyDateTime(DateTime d)
            {
                s_DateTime = d;
            }
            /// <summary>
            /// 重写比较类
            /// </summary>
            /// <param name="o"></param>
            /// <returns></returns>
            public int CompareTo(object o)
            {
                MyDateTime Two = o as MyDateTime;
                if (Two.s_DateTime > s_DateTime)
                    return 1;
                else if (Two.s_DateTime < s_DateTime)
                    return -1;
                else
                    return 0;
            }
        }
    }
}

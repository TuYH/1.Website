using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using System.Net;
using System.IO;
using HXD.Model;
using HXD.BLL;
using HXD.Common;
using HXD.DBUtility;


public partial class adminmanage_DataBase_DB_BackUp : System.Web.UI.Page
{
    //数据连接字符串
    private string CONN_STRING = ConfigurationManager.ConnectionStrings["SqlConnString"].ConnectionString;
    //数据库名称
    private string BaseName = ConfigurationManager.AppSettings["DB_Name"].ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdminManage();
        if (!IsPostBack)
        {
            this.DBList.DataSource = GetBackUpList().DefaultView;
            this.DBList.DataBind();
        }
    }

    protected void NewClick(object sender, EventArgs e)
    {
        string BackUpName = System.DateTime.Now.ToString("yyy-MM-dd-hh-mm-ss") + ".bak";
        string FilePath = System.Web.HttpContext.Current.Server.MapPath("../../DataBaseBackUp/" + BackUpName + "");
        string dbpath = System.Web.HttpContext.Current.Server.MapPath("../../DataBaseBackUp");
        //try
        //{
        if (File.Exists(FilePath))
        {
            File.Delete(dbpath + "\\" + BackUpName + "");//存在备份？删除...
        }
        else
        {
            SqlConnection sqlcon = new SqlConnection(CONN_STRING);
            sqlcon.Open();
            string dbname = sqlcon.Database;
            string strBacl = "backup database " + BaseName + " to disk='" + dbpath + "\\" + BackUpName + "'";
            HXD.DBUtility.SQLHelper.ExecuteNonQuery(strBacl);
            this.Message.Text = "数据库备份成功！";

            this.DBList.DataSource = GetBackUpList().DefaultView;
            this.DBList.DataBind();
        }
        //}
        //catch
        //{
        //    this.Message.Text = "数据库备份失败！";
        //}
    }


    public DataTable GetBackUpList()
    {

        DataTable dt = new DataTable();
        DataColumn dc1 = dt.Columns.Add("Name", typeof(string));
        DataColumn dc2 = dt.Columns.Add("Date", typeof(string));

        string dbpath = System.Web.HttpContext.Current.Server.MapPath("../../DataBaseBackUp");
        ArrayList al = new ArrayList();
        al = GetAllBackName(dbpath);


        foreach (string a in al)
        {
            DataRow row = dt.NewRow();

            row["Name"] = a;
            row["Date"] = a.Replace(".bak", "");

            dt.Rows.Add(row);
        }

        return dt;
    }

    /// <summary>
    ///获取指定路径下所有文件的名字
    /// </summary>
    ///
    public static ArrayList GetAllBackName(string path)
    {
        ArrayList db_Names = new ArrayList();
        DirectoryInfo dir = new DirectoryInfo(path);

        foreach (FileInfo subdir in dir.GetFiles())
            db_Names.Add(subdir.Name);
        return db_Names;
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "del")
        {
            string dbpath = System.Web.HttpContext.Current.Server.MapPath("../../DataBaseBackUp");
            if (File.Exists(dbpath + "/" + e.CommandArgument.ToString()))
            {
                File.Delete(dbpath + "\\" + e.CommandArgument.ToString() + "");//存在备份？删除...
            }

            this.DBList.DataSource = GetBackUpList().DefaultView;
            this.DBList.DataBind();
        }

        if (e.CommandName == "down")
        {
            string dbpath = "../../DataBaseBackUp";

            //System.IO.FileInfo file = new System.IO.FileInfo(dbpath + "\\" + e.CommandArgument.ToString());
            //HttpContext.Current.Response.Clear();
            //HttpContext.Current.Response.Charset = "utf-8";
            //HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
            //HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(file.Name, System.Text.Encoding.UTF8));
            //HttpContext.Current.Response.AddHeader("Content-Length", file.Length.ToString());
            //HttpContext.Current.Response.ContentType = "application/octet-stream";
            //HttpContext.Current.Response.WriteFile(file.FullName);
            //HttpContext.Current.Response.End();
            //HttpContext.Current.Response.Flush();
            //HttpContext.Current.Response.Clear();

            DownLoad(dbpath + "/" + e.CommandArgument.ToString(), e.CommandArgument.ToString());
        }

    }

    public void DownLoad(string FilePath, string FileName)
    {
        string fileName = FileName;//客户端保存的文件名
        string filePath = Server.MapPath(FilePath);//路径

        //以字符流的形式下载文件
        FileStream fs = new FileStream(filePath, FileMode.Open);
        byte[] bytes = new byte[(int)fs.Length];
        fs.Read(bytes, 0, bytes.Length);
        fs.Close();
        Response.ContentType = "application/octet-stream";
        //通知浏览器下载文件而不是打开
        Response.AddHeader("Content-Disposition", "attachment;   filename=" + HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8));
        Response.BinaryWrite(bytes);
        Response.Flush();
        Response.End();

    }

}

using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Net;
using System.IO;
using HXD.Model;
using HXD.BLL;
using HXD.Common;
using HXD.DBUtility;

public partial class adminmanage_DataBase_DB_Restore : System.Web.UI.Page
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
            this.DBList.DataTextField = "Name";
            this.DBList.DataValueField = "Name";
            this.DBList.DataBind();
        }
    }

    protected void NewClick(object sender, EventArgs e)
    {
        string BackUpName = this.DBList.SelectedValue.ToString();
        string FilePath = System.Web.HttpContext.Current.Server.MapPath("../../DataBaseBackUp/" + BackUpName + "");
        try
        {
            CloseJC();
            SqlConnection.ClearAllPools();

            SqlConnection sqlcon = new SqlConnection(CONN_STRING);
            sqlcon.Open();
            string dbname = sqlcon.Database;
            sqlcon.ChangeDatabase("master");
            string dbpath = FilePath;
            string sql = "backup DATABASE  " + BaseName + " to disk='" + FilePath + "' restore database " + BaseName + " from disk='" + FilePath + "' WITH REPLACE  ";
            SqlCommand sqlCmd = new SqlCommand(sql, sqlcon);
            sqlCmd.ExecuteNonQuery();
            sqlCmd.Dispose();
            sqlcon.Close();
            sqlcon.Dispose();
            SqlConnection.ClearAllPools();
            this.Message.Text = "<div class='evon_jg'>数据库还原成功！</div>";
        }
        catch (Exception ex)
        {
            SqlConnection.ClearAllPools();
            this.Message.Text = "<div class='evon_jg'>数据库还原失败！</div>";
            throw ex;
        }
    }

    /// <summary>
    ///强制关闭所有连接到数据库的进程
    /// </summary>
    ///
    public void CloseJC()
    {
        //getSqlConnection geCon = new getSqlConnection();
        SqlConnection connection1 = new SqlConnection(CONN_STRING);
        if (connection1.State == ConnectionState.Open)
        {
            connection1.Close();
        }
        SqlConnection conn = new SqlConnection(CONN_STRING);
        conn.Open();
        string dbname = conn.Database;
        conn.ChangeDatabase("master");

        //-------------------杀掉所有连接 db_CSManage 数据库的进程--------------   
        string strSQL = "select spid from master..sysprocesses where dbid=db_id( '" + BaseName + "') ";
        SqlDataAdapter Da = new SqlDataAdapter(strSQL, conn);

        DataTable spidTable = new DataTable();
        Da.Fill(spidTable);

        SqlCommand Cmd = new SqlCommand();
        Cmd.CommandType = CommandType.Text;
        Cmd.Connection = conn;

        for (int iRow = 0; iRow <= spidTable.Rows.Count - 1; iRow++)
        {
            Cmd.CommandText = "kill " + spidTable.Rows[iRow][0].ToString();   //强行关闭用户进程    
            Cmd.ExecuteNonQuery();
        }
        conn.Close();
        conn.Dispose();
        //--------------------------------------------------------------------    
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
}
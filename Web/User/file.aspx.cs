using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using HXD.Common;

public partial class User_file : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.AdManage(5);
    }
    private DataTable xsldata()
    {
        if (fuload.FileName == "")
        {
            lbmsg.Text = "请选择文件";
            return null;
        }
        string fileExtenSion;
        fileExtenSion = Path.GetExtension(fuload.FileName);
        if (fileExtenSion.ToLower() != ".xls" && fileExtenSion.ToLower() != ".xlsx")
        {
            lbmsg.Text = "上传的文件格式不正确";
            return null;
        }
        //try
        //{
            string FileName = "../App_Data/" + Path.GetFileName(fuload.FileName);
            if (File.Exists(Server.MapPath(FileName)))
            {
                File.Delete(Server.MapPath(FileName));
            }
            fuload.SaveAs(Server.MapPath(FileName));
            //HDR=Yes，这代表第一行是标题，不做为数据使用 ，如果用HDR=NO，则表示第一行不是标题，做为数据来使用。系统默认的是YES
            string connstr2003 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath(FileName) + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
            string connstr2007 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath(FileName) + ";Extended Properties=\"Excel 12.0;HDR=YES\"";
            OleDbConnection conn;
            if (fileExtenSion.ToLower() == ".xls")
            {
                conn = new OleDbConnection(connstr2003);
            }
            else
            {
                conn = new OleDbConnection(connstr2007);
            }
            conn.Open();
            string sql = "select * from [Sheet1$]";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            DataTable dt = new DataTable();
            OleDbDataReader sdr = cmd.ExecuteReader();

            dt.Load(sdr);
            sdr.Close();
            conn.Close();
            //删除服务器里上传的文件
            if (File.Exists(Server.MapPath(FileName)))
            {
                File.Delete(Server.MapPath(FileName));
            }
            return dt;
        //}
        //catch (Exception e)
        //{
        //    return null;
        //}
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //try
        //{
        if (fuload.FileName == "")
        {
            //lbmsg.Text = "请选择文件";
            //return null;

            StringDeal.Alter("请选择文件", "file.aspx");
        }
        else
        {
            DataTable dt = xsldata();

            //dataGridView2.DataSource = ds.Tables[0];
            int errorcount = 0;//记录错误信息条数
            int insertcount = 0;//记录插入成功条数

            int updatecount = 0;//记录更新信息条数

            //string strcon = "server=localhost;database=database1;uid=sa;pwd=sa";
            //SqlConnection conn = new SqlConnection(strcon);//链接数据库
            //conn.Open();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //dt.Rows[i]["Name"].ToString(); "Name"即为Excel中Name列的表头
                string excl_xuehao = dt.Rows[i][0].ToString();//学号
                string excl_name = dt.Rows[i][1].ToString();//姓名
                string excl_sex = dt.Rows[i][2].ToString();//性别
                string excl_Birthday = dt.Rows[i][3].ToString();//生日
                string excl_nationality = dt.Rows[i][4].ToString();//民族
                string excl_address = dt.Rows[i][5].ToString();//家庭住址
                string excl_ksname = dt.Rows[i][6].ToString();//科室名称
                string excl_nianji = dt.Rows[i][7].ToString();//年级
                string excl_banji = dt.Rows[i][8].ToString();//班级
                string excl_tel = dt.Rows[i][9].ToString();//电话号码
                string excl_tel2 = dt.Rows[i][10].ToString();//其他联系方式
                string excl_jieji = dt.Rows[i][11].ToString();//届级
                string UserPwd = Encryp.DESEncrypt("123456");

                //string userid = Session["userid"].ToString();
                //string sqlcl = "select classid from tb_user where id=" + userid;
                //string MenuId = HXD.DBUtility.SQLHelper.ExecuteScalar(sqlcl).ToString();
                string MenuId = LoginCheck.getadminid();//学校ID

                if (excl_xuehao != "" && excl_name != "" && excl_nianji != "" && excl_banji != "")
                {
                    string sql = "select count(id) from tb_user where username='" + excl_xuehao + "'";
                    int count = Convert.ToInt32(HXD.DBUtility.SQLHelper.ExecuteScalar(sql));
                    if (count > 0)
                    {
                        updatecount++;
                    }
                    else
                    {
                        string sqlin1 = "insert into tb_User(UserName,UserPwd,GroupId,classid,islock)values('" + excl_xuehao + "','" + UserPwd + "',1,'" + MenuId + "',1)";
                        HXD.DBUtility.SQLHelper.ExecuteScalar(sqlin1);

                        System.Threading.Thread.Sleep(100);
                        string sqlin2 = "select id from tb_User where UserName='" + excl_xuehao + "' and datediff(mi,RegTime,getdate())<=1";
                        string icd = HXD.DBUtility.SQLHelper.ExecuteScalar(sqlin2).ToString();
                        Session["userid"] = icd;
                        string sqlin3 = "insert into tb_U_User (Id,msn,name,sex,shengri,nationality,Address,ks_name,nianji,banji,tel,Mobile,jieji,sc_id)values('" + icd + "','" + excl_xuehao + "','" + excl_name + "','" + excl_sex + "','" + excl_Birthday + "','" + excl_nationality + "','" + excl_address + "','" + excl_ksname + "','" + excl_nianji + "','" + excl_banji + "','" + excl_tel + "','" + excl_tel2 + "','" + excl_jieji + "','" + MenuId + "')";
                        HXD.DBUtility.SQLHelper.ExecuteScalar(sqlin3);


                        //string sqlinsert = "insert into users(Name,Sex,Age,Address) values('" + Name + "','" + Sex + "'," + Age + ",'" + Address + "')";
                        //HXD.DBUtility.SQLHelper.ExecuteNonQuery(sqlinsert);
                        insertcount++;
                    }
                }
                else
                {
                    errorcount++;
                }
            }
            string msgg = insertcount + "条数据导入成功！" + updatecount + "条数据重复！" + errorcount + "条数据部分信息为空没有导入！";
            StringDeal.Alter(msgg, "font_list2.aspx");
            //catch (Exception ex)
            //{


        }//}
    }
        

    
}
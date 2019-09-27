using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using HXD.Common;
using System.Data;

public partial class User_Add_cp3 : System.Web.UI.Page
{
    protected string strm = "",stm2="";
    protected void Page_Load(object sender, EventArgs e)
    {

        LoginCheck.AdManage();
        getztOperation();
        if (!IsPostBack)
        {

            string MenuId = Session["userid"].ToString();
            string sql_mid = "select Classid from tb_User where id=" + MenuId;
            int scholl_id = int.Parse(HXD.DBUtility.SQLHelper.ExecuteScalar(sql_mid).ToString());

            //string sql = "SELECT * from tb_User where Classid='" + scholl_id + "' and GroupId=1 order by id";

            //Repeater1.DataSource = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
            //Repeater1.DataBind();


            HXD.ModelField.BLL.Model bll = new HXD.ModelField.BLL.Model();
            HXD.ModelField.Model.Model mod = new HXD.ModelField.Model.Model();
            mod.Condition = " Classid=" + scholl_id + " and GroupId=1  ";
            mod.FieldList = "UserName,RegTime,islock";
            mod.TableName = "tb_User";
            mod.Sort = "Sort desc";
            mod.PageSize = 20;
            mod.PageIndex = HXD.Common.StringDeal.ToInt(Request.QueryString["page"]);
            DataSet ds1 = bll.ModelList(mod);
            DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset("select top 20 UserName,RegTime,islock from tb_User where Classid=" + scholl_id + "  and GroupId=1 order by Sort desc,id desc;");
            this.Repeater1.DataSource = ds1;
            this.Repeater1.DataBind();

            HXD.Common.SgqPage pg = new HXD.Common.SgqPage();
            pg.PageSize = mod.PageSize;
            pg.PageIndex = mod.PageIndex;
            pg.RecordCount = (int)ds1.Tables[1].Rows[0][0];
            this.Literal1.Text = pg.PageView2();
            if (pg.RecordCount == 0)
            { this.Literal1.Text = "暂无数据！"; }
            ds.Clear();
            ds.Dispose();
            ds1.Clear();
            ds1.Dispose();


        }
    }
    protected string getname(string id)
    {
        string sql = "SELECT name from tb_U_User where id=" + id;
        string name = HXD.DBUtility.SQLHelper.ExecuteScalar(sql).ToString();
        return name;
    }
    protected string getzt(string str)
    {
        string name = "";

        string zt_yes = "<img src=\"assets/img/yes.png\">";
        string zt_no = "<img src=\"assets/img/no.png\">";
        bool sta = bool.Parse(str);
        if (sta == true)
        {
            name = zt_no;
        }
        else
        {
            name = zt_yes;
        }
        return name;
    }
    protected void getztOperation()
    {
        int icd = StringDeal.ToInt(Request.QueryString["Id"]);
        if (icd > 0)
        {
            string Action = Request.QueryString["Action"];
            if (Action == "del")
            {
                string sql = "delete from tb_User where ID='" + icd + "';delete from tb_U_User where ID='" + icd + "'";
                HXD.DBUtility.SQLHelper.ExecuteScalar(sql);
            }
            else if (Action == "lock")
            {
                string sql2 = "SELECT IsLock from tb_User where id='" + icd + "'";
                bool stra = bool.Parse(HXD.DBUtility.SQLHelper.ExecuteScalar(sql2).ToString());
                if (stra == true)
                {
                    string sql = "UPDATE tb_User set IsLock=0 where id='" + icd + "'";
                    HXD.DBUtility.SQLHelper.ExecuteScalar(sql);
                }
                else
                {
                    string sql = "UPDATE tb_User set IsLock=1 where id='" + icd + "'";
                    HXD.DBUtility.SQLHelper.ExecuteScalar(sql);
                }
            }


            Response.Redirect("Font_list2.aspx", true);
        }
    }
    /// <summUry>
    /// 批量删除
    /// </summUry>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        string userid = Session["userid"].ToString();
        string sql_cid = "select Classid from tb_User where id=" + userid;
        int ClassId = int.Parse(HXD.DBUtility.SQLHelper.ExecuteScalar(sql_cid).ToString());
        string lbset = Request.QueryString["lbid"].ToString();

        strm += Request["Id"] +","+ Session["stm"];
        strm = string.Join(",", strm.Split(',').Distinct().ToArray());
        if (String.IsNullOrEmpty(strm))
        {
            StringDeal.Alter("请选择要审核的对象！");
        }
        else
        {
            string[] sArray = strm.Split(',');
            int mun=sArray.Count()-1;
            string wid = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            foreach (string i in sArray)
            {

                //string sql2 = "SELECT IsLock from tb_User where id='" + i + "'";
                //bool stra = bool.Parse(HXD.DBUtility.SQLHelper.ExecuteScalar(sql2).ToString());
                //if (stra == true)
                //{
                //    string sql = "UPDATE tb_User set IsLock=0 where id='" + i + "'";
                //    HXD.DBUtility.SQLHelper.ExecuteScalar(sql);
                //}
                //else
                //{
                //    string sql = "UPDATE tb_User set IsLock=1 where id='" + i + "'";
                //    HXD.DBUtility.SQLHelper.ExecuteScalar(sql);
                //}
                if (i != "")
                {

                    string sql = "insert into tb_U_Message (ClassId,zxs_id,uid,Content,cid,rid)values('" + ClassId + "','" + userid + "','" + i + "','请尽快做心理普查，详情点击<a href=\"../cp/cp_list.aspx?set=" + lbset + "&wid="+wid+"\" target=\"_blank\">开始测试</a>','1','"+wid+i+"')";
                    HXD.DBUtility.SQLHelper.ExecuteNonQuery(sql);
                }


            }
            string title = "个体普查任务";
            string sqll = "insert into tb_U_cplist (title,cp_set,cp_umun,post_uid,cp_id)values('"+title+"','" + lbset + "','" + mun + "','" + userid + "','" + wid + "')";
            HXD.DBUtility.SQLHelper.ExecuteNonQuery(sqll);

            Caches.RemoveCache("stm");
            Session.Remove("stm");

            //生成二维码
            string url_host = "http://" + HttpContext.Current.Request.Url.Host;
            string url = url_host + "/cp/cp_list.aspx?set=" + lbset + "&wid=" + wid + "";

            var ms = new MemoryStream();
            string stringtest = url
                ;
            GetQRCode(stringtest, ms);
            Image img = Image.FromStream(ms);
            //string filename = DateTime.Now.ToString();
            string path = Server.MapPath("../Images/t1/") + wid + ".png";
            img.Save(path);

            string sqlimg = "update tb_U_Cplist set CreateUsers='" + wid + ".png' where cp_id='" + wid + "'";
            HXD.DBUtility.SQLHelper.ExecuteNonQuery(sqlimg);
            Response.Redirect("cp_list.aspx", true);

        }

    }
    /// <summary>
    /// 获取二维码
    /// </summary>
    /// <param name="strContent">待编码的字符</param>
    /// <param name="ms">输出流</param>
    ///<returns>True if the encoding succeeded, false if the content is empty or too large to fit in a QR code</returns>
    public static bool GetQRCode(string strContent, MemoryStream ms)
    {
        ErrorCorrectionLevel Ecl = ErrorCorrectionLevel.M; //误差校正水平 
        string Content = strContent;//待编码内容
        QuietZoneModules QuietZones = QuietZoneModules.Two;  //空白区域 
        int ModuleSize = 18;//大小
        var encoder = new QrEncoder(Ecl);
        QrCode qr;
        if (encoder.TryEncode(Content, out qr))//对内容进行编码，并保存生成的矩阵
        {
            var render = new GraphicsRenderer(new FixedModuleSize(ModuleSize, QuietZones));
            render.WriteToStream(qr.Matrix, ImageFormat.Png, ms);
        }
        else
        {
            return false;
        }
        return true;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string MenuId = Session["userid"].ToString();
        string sql_mid = "select Classid from tb_User where id=" + MenuId;
        int scholl_id = int.Parse(HXD.DBUtility.SQLHelper.ExecuteScalar(sql_mid).ToString());
        string name=this.Text1.Value;
        string sql = "SELECT * from tb_User where Classid='" + scholl_id + "' and GroupId=1 and id in(select id from tb_U_user where name like '%" + name + "%')  order by id";
        Repeater1.DataSource = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
        Repeater1.DataBind();
        stm2 = Request["Id"];
        if (String.IsNullOrEmpty(stm2))
        {
           
        }
        else
        {
            Session["stm"] += "," + stm2;
            
        }
    }
}
using System.Web.UI.WebControls;


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
using System.Collections;

public partial class User_Add_cp2 : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoginCheck.AdManage(5);
            string classid = LoginCheck.getadminid();
            bd(classid);
            
        }
    }
    /// <summary>
    /// 绑定数据到select
    /// </summary>
    /// <param name="id"></param>
    protected void bd(string id)
    {
        string sql = "select id,ClassId,title,depth from tb_U_schoolfl where depth=0 and menuid=2 and sid=" + id;
        this.Select1.DataSource = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
        this.Select1.DataTextField = "title";
        this.Select1.DataValueField = "id";
        this.Select1.DataBind();
        Select1.Items.Insert(0, new ListItem("全部年级", "0"));


        //DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //    {
        //        string demp = ds.Tables[0].Rows[i]["depth"].ToString();
        //        string stritem = ds.Tables[0].Rows[i]["id"].ToString();
        //        string strvalues = ds.Tables[0].Rows[i]["title"].ToString();

        //        this.Select1.Items.Add(new ListItem(strvalues, stritem));


        //    }
        //}
    }
    protected void bd2()
    {
        string sql = "select id,ClassId,title,depth from tb_U_schoolfl where menuid=2 and classid=" + this.Select1.SelectedValue;
        this.Select2.DataSource = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
        this.Select2.DataTextField = "title";
        this.Select2.DataValueField = "id";
        this.Select2.DataBind();

        //string sql = "select id,ClassId,title,depth from tb_U_schoolfl where menuid=2 and class=" + id;
        //DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //    {
        //        string demp = ds.Tables[0].Rows[i]["depth"].ToString();
        //        string stritem = ds.Tables[0].Rows[i]["id"].ToString();
        //        string strvalues = ds.Tables[0].Rows[i]["title"].ToString();

        //        this.Select2.Items.Add(new ListItem(strvalues, stritem));

        //        //<option value="a">-The.CC</option>
        //    }
        //}
    }


    protected void bd3(string id)
    {
        string sql = "select id,ClassId,title,depth from tb_U_schoolfl where menuid=3 and sid=" + id;
        DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string demp = ds.Tables[0].Rows[i]["depth"].ToString();
                string stritem = ds.Tables[0].Rows[i]["id"].ToString();
                string strvalues = ds.Tables[0].Rows[i]["title"].ToString();

                this.Select2.Items.Add(new ListItem(strvalues, stritem));

                //<option value="a">-The.CC</option>
            }
        }
    }

    protected string getlbname(string id)
    {
        string sql = "select Fpapername from t_exam_paper where Fpaperid=" + id;
        string name = HXD.DBUtility.SQLHelper.ExecuteScalar(sql).ToString();
        return name;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        object result = Session["readerIds"];
        string[] vs = result as string[];
        string lbid = Request.QueryString["lbid"].ToString();
        string userid = Session["userid"].ToString();
        string sql_cid = "select Classid from tb_User where id=" + userid;
        int ClassId = int.Parse(HXD.DBUtility.SQLHelper.ExecuteScalar(sql_cid).ToString());
        string wid = DateTime.Now.ToString("yyyyMMddHHmmssfff");
        string nianji = this.Select1.SelectedValue;
        string banji = this.Select2.SelectedValue;
        string tiaojian = "";
        int mun = 0;
        if (nianji == "0")//全年级
        {
            string sql = "select id from tb_User where Classid='" + ClassId + "' and GroupId=1";
            DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
            mun = ds.Tables[0].Rows.Count;
            if (mun > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string uid = ds.Tables[0].Rows[i]["id"].ToString();
                    if (vs != null) { 
                        for(int j = 0; j < vs.Length; j++) {
                    //cid 1=测评  2=预约  3=辅导 4=消息
                             string sqls = "insert into tb_U_Message (ClassId,zxs_id,uid,Content,cid,rid)values('" + ClassId + "','" + userid + "','" + uid + "','请尽快做心理普查，详情点击<a href=\"../cp/cp_list.aspx?set=" + vs[j] + "&wid=" + wid +j+ "\" target=\"_blank\">"+ getlbname(vs[j]) + "</a>','1','" + wid +j+ "')";
                             HXD.DBUtility.SQLHelper.ExecuteNonQuery(sqls);
                        }
                    }
                }
            }
        }
        else
        {
            nianji = getname(nianji);
            tiaojian = "nianji='" + nianji + "' ";
            if (banji == "0")
            {

            }
            else
            {
                banji = getname(banji);
                tiaojian += " and banji='" + banji + "'";
            }
            //select a.id from tb_User as a, tb_U_user as b where a.Id=b.id and banji='高二'  and nianji='2' and a.classid=19
            string sqlnb = "select a.id from tb_User as a, tb_U_user as b where a.Id=b.id and a.classid='" + ClassId + "' and " + tiaojian + " ";
            DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sqlnb);
            mun = ds.Tables[0].Rows.Count;
            if (mun > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string uid = ds.Tables[0].Rows[i]["id"].ToString();
                    if (vs != null)
                    {
                        for (int j = 0; j < vs.Length; j++)
                        {
                            string sqls = "insert into tb_U_Message (ClassId,zxs_id,uid,Content,cid,rid)values('" + ClassId + "','" + userid + "','" + uid + "','请尽快做心理普查，详情点击<a href=\"../cp/cp_list.aspx?set=" + vs[j] + "&wid=" + wid +j+ "\" target=\"_blank\">" + getlbname(vs[j]) + "</a>','1','" + wid +j+ "')";
                            HXD.DBUtility.SQLHelper.ExecuteNonQuery(sqls);
                        }
                    }
                }
            }
        }

        string title = "团体测评任务" + nianji + banji;
        if (vs != null)
        {
            for (int j = 0; j < vs.Length; j++)
            {
                string sqll = "insert into tb_U_cplist (title,cp_set,cp_umun,post_uid,cp_id)values('" + title + "','" + vs[j] + "','" + mun + "','" + userid + "','" + wid + j+"')";
                HXD.DBUtility.SQLHelper.ExecuteNonQuery(sqll);
            }
        }
        //string banji = this.Select2.Value;
        //banji="banji="+banji;

        //string sql = "select id from tb_U_User where "+nianji+" and banji=''";

        //生成二维码
        string url_host = "http://" + HttpContext.Current.Request.Url.Host;
        string url = url_host + "/cp/cp_list.aspx?set=" + lbid + "&wid=" + wid + "";

        var ms = new MemoryStream();
        string stringtest = url
            ;
        GetQRCode(stringtest, ms);
       
        System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
        //string filename = DateTime.Now.ToString();
        string path = Server.MapPath("../Images/t1/") + wid + ".png";
        img.Save(path);

        string sqlimg = "update tb_U_Cplist set CreateUsers='" + wid + ".png' where cp_id='" + wid + "'";
        HXD.DBUtility.SQLHelper.ExecuteNonQuery(sqlimg);

        Session.Remove("readerIds");
        Response.Redirect("cp_list.aspx", true);

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
    //protected void Button2_Click(object sender, EventArgs e)
    //{
    //    string lbid = Request.QueryString["lbid"].ToString();


    //}
    protected void Select1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string id = this.Select1.SelectedValue;

        
        string sql = "select id,ClassId,title,depth from tb_U_schoolfl where menuid=2 and classid="+id;
        this.Select2.DataSource = HXD.DBUtility.SQLHelper.ExecuteDataset(sql);
        this.Select2.DataTextField = "title";
        this.Select2.DataValueField = "id";
        this.Select2.DataBind();
        Select2.Items.Insert(0, new ListItem("全部", "0"));
    }

    protected string getname(string id)
    {
        string sql = "select title from tb_U_schoolfl where id=" + id;
        string name = HXD.DBUtility.SQLHelper.ExecuteScalar(sql).ToString();
        return name;
    }
}
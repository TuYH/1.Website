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
using System.Data;

public partial class Reg_lxxl : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string tell = this.TextBox2.Text.Trim();
        //string school = this.TextBox1.Text.Trim();
        //string sqls = "select * from tb_U_school where s_name='" + school + "'";
        //DataSet ds = HXD.DBUtility.SQLHelper.ExecuteDataset(sqls);
        //if (ds.Tables[0].Rows.Count == 0)
        //{
            if (tell == "13701108821")
            {
              

                string url = "http://"+HttpContext.Current.Request.Url.Host; 

                var ms = new MemoryStream();
                string stringtest = url+"/reg.aspx";
                GetQRCode(stringtest, ms);
                Image img = Image.FromStream(ms);
                string filename = "adminre";
                string path = Server.MapPath("Images/t1/") + filename + ".png";
                img.Save(path);

                System.Threading.Thread.Sleep(1000);
                var ms2 = new MemoryStream();
                string stringtest2 = url + "/reg_ls.aspx";
                GetQRCode(stringtest2, ms2);
                //Response.ContentType = "image/Png";
                //Response.OutputStream.Write(ms.GetBuffer(), 0, (int)ms.Length);
                Image img2 = Image.FromStream(ms2);
                string filename1 = "lsre";
                string path2 = Server.MapPath("Images/t1/") + filename1 + ".png";
                img2.Save(path2);

                System.Threading.Thread.Sleep(1000);
                var ms3 = new MemoryStream();
                string stringtest3 = url + "/reg_xs.aspx";
                GetQRCode(stringtest3, ms3);
                //Response.ContentType = "image/Png";
                //Response.OutputStream.Write(ms.GetBuffer(), 0, (int)ms.Length);
                Image img3 = Image.FromStream(ms3);
                string filename3 = "xsre";
                string path3 = Server.MapPath("Images/t1/") + filename3 + ".png";
                img3.Save(path3);


                System.Threading.Thread.Sleep(1000);
                var ms4 = new MemoryStream();
                string stringtest4 = url + "/logine.aspx";
                GetQRCode(stringtest4, ms4);
                //Response.ContentType = "image/Png";
                //Response.OutputStream.Write(ms.GetBuffer(), 0, (int)ms.Length);
                Image img4 = Image.FromStream(ms3);
                string filename4 = "login";
                string path4 = Server.MapPath("Images/t1/") + filename4+ ".png";
                img4.Save(path4);

              


          
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
}
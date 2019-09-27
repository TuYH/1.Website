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

public partial class User_erweima : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["url"] != null)
        {
            string url = Request.QueryString["url"].ToString();

            var ms = new MemoryStream();
            string stringtest = url
                ;
            GetQRCode(stringtest, ms);
            Image img = Image.FromStream(ms);
            string filename = DateTime.Now.ToString();
            string path = Server.MapPath("../Images/t1/") + filename + ".png";
            img.Save(path);
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
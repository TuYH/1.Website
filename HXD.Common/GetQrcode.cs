﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;


namespace HXD.Common
{
    public class GetQrcode
    {
        /// <summary>
        /// 获取二维码
        /// </summary>
        /// <param name="strContent">待编码的字符</param>
        /// <param name="ms">输出流</param>
        ///<returns>True if the encoding succeeded, false if the content is empty or too large to fit in a QR code</returns>
        //public static bool GetQRCode(string strContent, MemoryStream ms)
        //{
        //    ErrorCorrectionLevel Ecl = ErrorCorrectionLevel.M; //误差校正水平 
        //    string Content = strContent;//待编码内容
        //    QuietZoneModules QuietZones = QuietZoneModules.Two;  //空白区域 
        //    int ModuleSize = 12;//大小
        //    var encoder = new QrEncoder(Ecl);
        //    QrCode qr;
        //    if (encoder.TryEncode(Content, out qr))//对内容进行编码，并保存生成的矩阵
        //    {
        //        var render = new GraphicsRenderer(new FixedModuleSize(ModuleSize, QuietZones));
        //        render.WriteToStream(qr.Matrix, ImageFormat.Png, ms);
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //    return true;
        //}
    }
}

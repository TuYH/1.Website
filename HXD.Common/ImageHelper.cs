using System;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.IO;
using System.Web;
/// <summary>
/// 图片操作(缩略图)
/// </summary>
public class ImageHelper
{
    #region 生成缩略图
    /// <summary>
    /// 生成缩略图
    /// </summary>
    /// <param name="originalImagePath">源图路径（物理路径）</param>
    /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
    /// <param name="width">缩略图宽度</param>
    /// <param name="height">缩略图高度</param>
    /// <param name="mode">生成缩略图的方式</param>    
    public static void MakeThumbPhoto(string originalImagePath, string thumbnailPath, int width, int height, string mode)
    {
        System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);
        int towidth = width;
        int toheight = height;
        int x = 0;
        int y = 0;
        int ow = originalImage.Width;
        int oh = originalImage.Height;
        switch (mode)
        {
            case "HW"://指定高宽缩放（可能变形）                
                break;
            case "W"://指定宽，高按比例                    
                toheight = originalImage.Height * width / originalImage.Width;
                break;
            case "H"://指定高，宽按比例
                towidth = originalImage.Width * height / originalImage.Height;
                break;
            case "Cut"://指定高宽裁减（不变形）                
                if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                {
                    oh = originalImage.Height;
                    ow = originalImage.Height * towidth / toheight;
                    y = 0;
                    x = (originalImage.Width - ow) / 2;
                }
                else
                {
                    ow = originalImage.Width;
                    oh = originalImage.Width * height / towidth;
                    x = 0;
                    y = (originalImage.Height - oh) / 2;
                }
                break;
            default:
                break;
        }
        //新建一个bmp图片
        System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);
        //新建一个画板
        System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);
        //设置高质量插值法
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
        //设置高质量,低速度呈现平滑程度
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        //清空画布并以透明背景色填充
        g.Clear(System.Drawing.Color.Transparent);
        //在指定位置并且按指定大小绘制原图片的指定部分
        g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight),
            new System.Drawing.Rectangle(x, y, ow, oh),
            System.Drawing.GraphicsUnit.Pixel);
        try
        {
            //以jpg格式保存缩略图
            bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        catch (System.Exception e)
        {
            throw e;
        }
        finally
        {
            originalImage.Dispose();
            bitmap.Dispose();
            g.Dispose();
        }
    }

    /// <summary>
    /// 生成缩略图
    /// </summary>
    /// <param name="originalImagePath">源图路径（物理路径）</param>
    /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
    /// <param name="width">缩略图宽度</param>
    /// <param name="height">缩略图高度</param>
    /// <param name="mode">生成缩略图的方式</param>    
    public static void MakeThumbPhotoNew(string originalImagePath, string thumbnailPath, int towidth, int toheight)
    {
        System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);
        int x = 0;
        int y = 0;

        int dstTop = 0, dstLeft = 0, dstWidth = originalImage.Width, dstHeight = originalImage.Height;
        //计算出图像位置
        float defaultSizeScale = (float)toheight / towidth;
        float imageSizeScale = (float)originalImage.Height / originalImage.Width;
        if (defaultSizeScale > imageSizeScale)
        {
            dstLeft = 0;
            dstTop = (int)((toheight - (imageSizeScale * towidth)) / 2);
            dstWidth = towidth;
            dstHeight = (int)(imageSizeScale * towidth);
        }
        else if (defaultSizeScale == imageSizeScale)
        {
            dstLeft = 0;
            dstTop = 0;
            dstWidth = towidth;
            dstHeight = toheight;
        }
        else
        {
            dstLeft = (int)((towidth - (toheight / imageSizeScale)) / 2);
            dstTop = 0;
            dstWidth = (int)(toheight / imageSizeScale);
            dstHeight = toheight;
        }

        //新建一个bmp图片
        System.Drawing.Image bitmap = new System.Drawing.Bitmap(dstWidth, dstHeight);
        //新建一个画板
        System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);
        //设置高质量插值法
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
        //设置高质量,低速度呈现平滑程度
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        //清空画布并以透明背景色填充
        g.Clear(System.Drawing.Color.Transparent);
        //在指定位置并且按指定大小绘制原图片的指定部分
        g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, dstWidth, dstHeight),
            new System.Drawing.Rectangle(x, y, originalImage.Width, originalImage.Height),
            System.Drawing.GraphicsUnit.Pixel);
        try
        {
            //以jpg格式保存缩略图
            bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        catch (System.Exception e)
        {
            throw e;
        }
        finally
        {
            originalImage.Dispose();
            bitmap.Dispose();
            g.Dispose();
        }
    }
    #endregion

    #region 在图片上增加文字水印
    /// <summary>
    /// 在图片上增加文字水印
    /// </summary>
    /// <param name="Path">原服务器图片路径</param>
    /// <param name="Path_sy">生成的带文字水印的图片路径</param>
    public static void AddWater(string Path, string Path_sy)
    {
        string addText = "www.foodun.com";
        System.Drawing.Image image = System.Drawing.Image.FromFile(Path);
        System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
        //设置高质量插值法
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        //设置高质量,低速度呈现平滑程度
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        g.DrawImage(image, 0, 0, image.Width, image.Height);
        System.Drawing.Font f = new System.Drawing.Font("Verdana", 60);
        System.Drawing.Brush b = new System.Drawing.SolidBrush(System.Drawing.Color.Green);
        g.DrawString(addText, f, b, 35, 35);
        g.Dispose();
        image.Save(Path_sy);
        image.Dispose();
    }
    #endregion

    /// <summary>
    /// 生成文字位图
    /// </summary>
    /// <param name="VNum">要生成的文字</param>
    /// <param name="name">字体名称</param>
    /// <param name="path">要保存的路径</param>
    public static void ValidateCode(string VNum, string name,string path)
    {
        Bitmap image = null;//创建GDI位图
        Graphics graphics = null;//GDI绘图图层
        MemoryStream stream = null;//内存流
        image = new Bitmap(VNum.Length * 14, 0x18);//位图的宽度和高度15
        graphics = Graphics.FromImage(image);//创建绘制层
        //图片的补差模式双三次插值法
        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        //高质量低速度呈现图片
        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        graphics.Clear(Color.White);//创建背景颜色
        Font font = new Font(name, 14f, FontStyle.Bold);//字体颜色和字体大小
        SolidBrush brush = new SolidBrush(Color.Black);//颜色对象
        for (int i = VNum.Length; i >= 1; i--)
        {
            string str = VNum.Substring(VNum.Length - i, 1);
            graphics.DrawString(str, font, brush, (float)((VNum.Length - i) * 13) + 3, 1f);//绘制字符串14
        }
        stream = new MemoryStream();
        image.Save(System.Web.HttpContext.Current.Server.MapPath(path), ImageFormat.Png);
        graphics.Dispose();
        image.Dispose();
        image.Dispose();
    }

    #region 在图片上生成图片水印
    /// <summary>
    /// 加图片水印
    /// </summary>
    /// <param name="Path">原始图片名称</param>
    /// <param name="filename">新图片名称</param>
    /// <param name="watermarkFilename">水印名称</param>
    /// <param name="watermarkStatus">图片水印位置1左上2上中3右上4左中5中6右中7左下8中下9右下</param>
    /// <param name="watermarkTransparency">图片水印透明度 取值范围1--10 (10为不透明)</param>
    public static void AddImageSignPic(string Path, string filename, string watermarkFilename, int watermarkStatus,int watermarkTransparency)
    {
        System.Drawing.Image img = System.Drawing.Image.FromFile(Path);
        Graphics g = Graphics.FromImage(img);
        //设置高质量插值法
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        //设置高质量,低速度呈现平滑程度
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        System.Drawing.Image watermark = new Bitmap(watermarkFilename);
        if (watermark.Height >= img.Height || watermark.Width >= img.Width)
        { return; }
        ImageAttributes imageAttributes = new ImageAttributes();
        ColorMap colorMap = new ColorMap();
        colorMap.OldColor = Color.FromArgb(255, 0, 255, 0);
        colorMap.NewColor = Color.FromArgb(0, 0, 0, 0);
        ColorMap[] remapTable = { colorMap };
        imageAttributes.SetRemapTable(remapTable, ColorAdjustType.Bitmap);
        float transparency = 0.5F;
        if (watermarkTransparency >= 1 && watermarkTransparency <= 10)
        {
            transparency = (watermarkTransparency / 10.0F);
        }
        float[][] colorMatrixElements = {
		new float[] {1.0f,  0.0f,  0.0f,  0.0f, 0.0f},
		new float[] {0.0f,  1.0f,  0.0f,  0.0f, 0.0f},
		new float[] {0.0f,  0.0f,  1.0f,  0.0f, 0.0f},
		new float[] {0.0f,  0.0f,  0.0f,  transparency, 0.0f},
		new float[] {0.0f,  0.0f,  0.0f,  0.0f, 1.0f}
		};
        ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);
        imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
        int xpos = 0;
        int ypos = 0;

        switch (watermarkStatus)
        {
            case 1:
                xpos = (int)(img.Width * (float).01);
                ypos = (int)(img.Height * (float).01);
                break;
            case 2:
                xpos = (int)((img.Width * (float).50) - (watermark.Width / 2));
                ypos = (int)(img.Height * (float).01);
                break;
            case 3:
                xpos = (int)((img.Width * (float).99) - (watermark.Width));
                ypos = (int)(img.Height * (float).01);
                break;
            case 4:
                xpos = (int)(img.Width * (float).01);
                ypos = (int)((img.Height * (float).50) - (watermark.Height / 2));
                break;
            case 5:
                xpos = (int)((img.Width * (float).50) - (watermark.Width / 2));
                ypos = (int)((img.Height * (float).50) - (watermark.Height / 2));
                break;
            case 6:
                xpos = (int)((img.Width * (float).99) - (watermark.Width));
                ypos = (int)((img.Height * (float).50) - (watermark.Height / 2));
                break;
            case 7:
                xpos = (int)(img.Width * (float).01);
                ypos = (int)((img.Height * (float).99) - watermark.Height);
                break;
            case 8:
                xpos = (int)((img.Width * (float).50) - (watermark.Width / 2));
                ypos = (int)((img.Height * (float).99) - watermark.Height);
                break;
            case 9:
                xpos = (int)((img.Width * (float).99) - (watermark.Width));
                ypos = (int)((img.Height * (float).99) - watermark.Height);
                break;
        }
        g.DrawImage(watermark, new Rectangle(xpos, ypos, watermark.Width, watermark.Height), 1, 0, watermark.Width, watermark.Height, GraphicsUnit.Pixel, imageAttributes);//绘制水印图
        img.Save(filename);//保存图片
        g.Dispose();
        img.Dispose();
        watermark.Dispose();
        imageAttributes.Dispose();
    }

    /// <summary>
    /// 在图片上生成图片水印
    /// </summary>
    /// <param name="Path">原服务器图片路径</param>
    /// <param name="Path_syp">生成的带图片水印的图片路径</param>
    /// <param name="Path_sypf">水印图片路径</param>
    protected void AddWaterPic(string Path, string Path_syp, string Path_sypf)
    {
        System.Drawing.Image image = System.Drawing.Image.FromFile(Path);
        System.Drawing.Image copyImage = System.Drawing.Image.FromFile(Path_sypf);
        System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
        g.DrawImage(copyImage, new System.Drawing.Rectangle(image.Width - copyImage.Width, image.Height - copyImage.Height, copyImage.Width, copyImage.Height), 0, 0, copyImage.Width, copyImage.Height, System.Drawing.GraphicsUnit.Pixel);
        g.Dispose();
        image.Save(Path_syp);
        image.Dispose();
    }
    #endregion

    /// <summary>
    /// 向内容图片中添加水印
    /// </summary>
    /// <param name="htmlStr">Html字符串</param>
    /// <param name="IsWatermark">是否启用水印功能</param>
    /// <param name="WatermarkType">水印类型</param>
    /// <param name="WatermarkPath">水印图片路径(相对地址)</param>
    /// <param name="WatermarkFile">水印图片路径(相对地址)</param>
    /// <param name="WatermarkFile">水印位置1左上2上中3右上4左中5中6右中7左下8中下9右下</param>
    /// <param name="Transparent">水印透明度(1-10)10为不透明</param>
    /// <returns></returns>
    public static void AddWatermark(string htmlStr, bool IsWatermark, int WatermarkType, string WatermarkPath, string WatermarkFile, int Position, int Transparent)
    {
        if (IsWatermark)
        {
            Regex regObj = new Regex("<img.+?>", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            foreach (Match matchItem in regObj.Matches(htmlStr))
            {
                string imgUrl = HXD.Common.Utils.GetSrc(matchItem.Value);
                if (imgUrl != "")
                {
                    string paths = "";//路径
                    int pathsi = 0;//路径的位置
                    string filename = "";//文件名称
                    string newfilename = "";//新文件名称

                    pathsi = imgUrl.LastIndexOf("/") >= 0 ? imgUrl.LastIndexOf("/") : imgUrl.LastIndexOf("\\") >= 0 ? imgUrl.LastIndexOf("\\") : -1;//获取路径
                    paths = imgUrl.Substring(0, pathsi + 1);//路径
                    filename = "temp_" + imgUrl.Substring(pathsi + 1);//文件名称
                    newfilename = paths + filename;//新文件名称
                    System.IO.File.Move(System.Web.HttpContext.Current.Server.MapPath(imgUrl), System.Web.HttpContext.Current.Server.MapPath(newfilename));//修改文件名称
                    if (WatermarkType == 1)
                    {
                        AddImageSignPic(System.Web.HttpContext.Current.Server.MapPath(newfilename), System.Web.HttpContext.Current.Server.MapPath(imgUrl), System.Web.HttpContext.Current.Server.MapPath(WatermarkPath) + WatermarkFile, Position, Transparent);//添加图片水印 
                    }
                    //else
                    //{
                    //    AddWater(System.Web.HttpContext.Current.Server.MapPath(newfilename), System.Web.HttpContext.Current.Server.MapPath(imgUrl));
                    //}
                    new HXD.Common.FilesManage().WNdelfile(newfilename);
                }
            }
        }
    }

    /// <summary>
    /// 获取图像编码解码器的所有相关信息
    /// </summary>
    /// <param name="mimeType">包含编码解码器的多用途网际邮件扩充协议 (MIME) 类型的字符串</param>
    /// <returns>返回图像编码解码器的所有相关信息</returns>
    static ImageCodecInfo GetCodecInfo(string mimeType)
    {
        ImageCodecInfo[] CodecInfo = ImageCodecInfo.GetImageEncoders();
        foreach (ImageCodecInfo ici in CodecInfo)
        {
            if (ici.MimeType == mimeType) return ici;
        }
        return null;
    }

    /// <summary>
    /// 返回图片后缀
    /// </summary>
    public static string ImagesFormats(Image ImageFormat)
    {
        if (ImageFormat.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Bmp))
        { return ".Bmp"; }
        else if (ImageFormat.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Emf))
        { return ".Emf"; }
        else if (ImageFormat.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Exif))
        { return ".Exif"; }
        else if (ImageFormat.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Gif))
        { return ".Gif"; }
        else if (ImageFormat.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Icon))
        { return ".Icon"; }
        else if (ImageFormat.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Jpeg))
        { return ".Jpeg"; }
        else if (ImageFormat.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.MemoryBmp))
        { return ".MemoryBmp"; }
        else if (ImageFormat.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Png))
        { return ".Png"; }
        else if (ImageFormat.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Tiff))
        { return ".Tiff"; }
        else if (ImageFormat.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Wmf))
        { return ".Wmf"; }
        else { return ""; }
    }

    /// <summary>
    /// 判断是否为图片
    /// </summary>
    public static bool isImages(string Path)
    {
        try
        {
            System.Drawing.Image image = System.Drawing.Image.FromFile(Path);
            image.Dispose();
            return true;
        }
        catch
        { return false; }
    }

    /// <summary>
    /// 判断是否为图片
    /// </summary>
    public static bool isImages(Stream Stream)
    {
        try
        {
            System.Drawing.Image image = System.Drawing.Image.FromStream(Stream);
            image.Dispose();
            return true;
        }
        catch
        { return false; }
    }

    /// <summary>
    /// 返回文件格式
    /// </summary>
    /// <param name="ext"></param>
    /// <returns></returns>
    public static string GetHtmime(string ext)
    {
        Hashtable htmimes = new Hashtable();
        switch (ext.ToLower())
        {
            case ".jpe":
            case ".jpeg":
            case ".jpg":
                htmimes[ext] = "image/jpeg";
                break;
            case ".png":
                htmimes[ext] = "image/png";
                break;
            case ".tif":
            case ".tiff":
                htmimes[ext] = "image/tiff";
                break;
            case ".bmp":
                htmimes[ext] = "image/bmp";
                break;
            case ".gif":
                htmimes[ext] = "image/gif";
                break;
            case ".swf":
                htmimes[ext] = "image/swf";
                break;
            case ".wbmp":
                htmimes[ext] = "image/wbmp";
                break;
            case ".psd":
                htmimes[ext] = "image/psd";
                break;
        }
        return (string)htmimes[ext];
    }

    /// <summary>
    /// 保存图片
    /// </summary>
    /// <param name="image">Image 对象</param>
    /// <param name="savePath">保存路径</param>
    /// <param name="ici">指定格式的编解码参数</param>
    public static void SaveImage(System.Drawing.Image image, string savePath, ImageCodecInfo ici)
    {
        //设置 原图片 对象的 EncoderParameters 对象
        EncoderParameters parameters = new EncoderParameters(1);
        parameters.Param[0] = new EncoderParameter(Encoder.Quality, ((long)90));
        image.Save(savePath, ici, parameters);
        parameters.Dispose();
    }

    /// <summary>
    /// 按指定大小自动生成缩略图(有背景颜色)
    /// </summary>
    /// <param name="sourceImagePath">原图片路径(相对路径)</param>
    /// <param name="thumbnailImagePath">生成的缩略图路径(相对路径)</param>
    /// <param name="thumbnailImageWidth">缩略图的宽度</param>
    /// <param name="thumbnailImageHeight">缩略图的高度</param>
    /// <param name="backgroundcolor">缩略图的背景颜色,</param>
    public static void ToThumbnailImages(string sourceImagePath, string thumbnailImagePath, int thumbnailImageWidth, int thumbnailImageHeight, string backgroundcolor)
    {
        string SourceImagePath = HttpContext.Current.Server.MapPath(sourceImagePath);
        string ThumbnailImagePath = HttpContext.Current.Server.MapPath(thumbnailImagePath);
        int ThumbnailImageWidth = thumbnailImageWidth;
        string sExt = SourceImagePath.Substring(SourceImagePath.LastIndexOf(".")).ToLower();
        if (SourceImagePath.ToString() == System.String.Empty) throw new NullReferenceException("SourceImagePath is null!");
        System.Drawing.Image image = System.Drawing.Image.FromFile(SourceImagePath);
        if (ImagesFormats(image) == string.Empty)
        {
            throw new ArgumentException("原图片文件格式不正确！", "SourceImagePath");
        }
        Bitmap bitmap = new Bitmap(thumbnailImageWidth, thumbnailImageHeight, PixelFormat.Format32bppArgb);
        int dstTop = 0, dstLeft = 0, dstWidth = image.Width, dstHeight = image.Height;
        //计算出图像位置
        float defaultSizeScale = (float)thumbnailImageHeight / thumbnailImageWidth;
        float imageSizeScale = (float)image.Height / image.Width;
        if (defaultSizeScale > imageSizeScale)
        {
            dstLeft = 0;
            dstTop = (int)((thumbnailImageHeight - (imageSizeScale * thumbnailImageWidth)) / 2);
            dstWidth = thumbnailImageWidth;
            dstHeight = (int)(imageSizeScale * thumbnailImageWidth);
        }
        else if (defaultSizeScale == imageSizeScale)
        {
            dstLeft = 0;
            dstTop = 0;
            dstWidth = thumbnailImageWidth;
            dstHeight = thumbnailImageHeight;
        }
        else
        {
            dstLeft = (int)((thumbnailImageWidth - (thumbnailImageHeight / imageSizeScale)) / 2);
            dstTop = 0;
            dstWidth = (int)(thumbnailImageHeight / imageSizeScale);
            dstHeight = thumbnailImageHeight;
        }
        //填充背景颜色
        Graphics graphics = Graphics.FromImage(bitmap);
        //清除整个绘图面并以透明背景色填充
        //graphics.Clear(Color.Transparent);
        if (string.IsNullOrEmpty(backgroundcolor))
        {
            graphics.Clear(Color.Transparent);
        }
        else
        {
            ColorConverter colorConverter = new ColorConverter();
            Color color = new Color();
            color = (Color)colorConverter.ConvertFromString(backgroundcolor);
            graphics.Clear(color);
        }
        Rectangle srcRect = new Rectangle(0, 0, image.Width, image.Height);//要在原图上绘制的位置
        Rectangle dstRect = new Rectangle(dstLeft, dstTop, dstWidth, dstHeight);//要绘制的缩略大小
        //InterpolationMode 枚举指定在缩放或旋转图像时使用的算法。命名空间:System.Drawing.Drawing2D
        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;//指定高质量的双三次插值法。执行预筛选以确保高质量的收缩。此模式可产生质量最高的转换图像。
        //设置高质量,低速度呈现平滑程度
        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        graphics.DrawImage(image, dstRect, srcRect, GraphicsUnit.Pixel);//dstRect,生成缩略图的大小srcRect,截取图片的位置
        image.Dispose();
        try
        {
            //将此 原图片 以指定格式并用指定的编解码参数保存到指定文件 
            string savepath = (ThumbnailImagePath == null ? SourceImagePath : ThumbnailImagePath);
            //SaveImage(bitmap, HttpContext.Current.Server.MapPath(savepath), GetCodecInfo(GetHtmime(sExt)));
            SaveImage(bitmap, savepath, GetCodecInfo(GetHtmime(sExt)));
        }
        catch (System.Exception e)
        { throw e; }
        finally
        {
            bitmap.Dispose();
            graphics.Dispose();
        }
    }

    /// <summary>
    /// 按指定大小自动生成缩略图(有背景颜色)
    /// </summary>
    /// <param name="stream">原图片文件流</param>
    /// <param name="thumbnailImagePath">生成的缩略图路径(相对路径)</param>
    /// <param name="thumbnailImageWidth">缩略图的宽度</param>
    /// <param name="thumbnailImageHeight">缩略图的高度</param>
    /// <param name="backgroundcolor">缩略图的背景颜色,</param>
    public static void ToThumbnailImages(Stream stream, string thumbnailImagePath, int thumbnailImageWidth, int thumbnailImageHeight, string backgroundcolor)
    {
        string ThumbnailImagePath = HttpContext.Current.Server.MapPath(thumbnailImagePath);
        int ThumbnailImageWidth = thumbnailImageWidth;
        System.Drawing.Image image = System.Drawing.Image.FromStream(stream);
        if (ImagesFormats(image) == string.Empty)
        {
            throw new ArgumentException("原图片文件格式不正确！", "SourceImagePath");
        }
        Bitmap bitmap = new Bitmap(thumbnailImageWidth, thumbnailImageHeight, PixelFormat.Format32bppArgb);
        int dstTop = 0, dstLeft = 0, dstWidth = image.Width, dstHeight = image.Height;
        //计算出图像位置
        float defaultSizeScale = (float)thumbnailImageHeight / thumbnailImageWidth;
        float imageSizeScale = (float)image.Height / image.Width;
        if (defaultSizeScale > imageSizeScale)
        {
            dstLeft = 0;
            dstTop = (int)((thumbnailImageHeight - (imageSizeScale * thumbnailImageWidth)) / 2);
            dstWidth = thumbnailImageWidth;
            dstHeight = (int)(imageSizeScale * thumbnailImageWidth);
        }
        else if (defaultSizeScale == imageSizeScale)
        {
            dstLeft = 0;
            dstTop = 0;
            dstWidth = thumbnailImageWidth;
            dstHeight = thumbnailImageHeight;
        }
        else
        {
            dstLeft = (int)((thumbnailImageWidth - (thumbnailImageHeight / imageSizeScale)) / 2);
            dstTop = 0;
            dstWidth = (int)(thumbnailImageHeight / imageSizeScale);
            dstHeight = thumbnailImageHeight;
        }
        //填充背景颜色
        Graphics graphics = Graphics.FromImage(bitmap);
        //清除整个绘图面并以透明背景色填充
        //graphics.Clear(Color.Transparent);
        if (string.IsNullOrEmpty(backgroundcolor))
        {
            graphics.Clear(Color.Transparent);
        }
        else
        {
            ColorConverter colorConverter = new ColorConverter();
            Color color = new Color();
            color = (Color)colorConverter.ConvertFromString(backgroundcolor);
            graphics.Clear(color);
        }
        Rectangle srcRect = new Rectangle(0, 0, image.Width, image.Height);//要在原图上绘制的位置
        Rectangle dstRect = new Rectangle(dstLeft, dstTop, dstWidth, dstHeight);//要绘制的缩略大小
        //InterpolationMode 枚举指定在缩放或旋转图像时使用的算法。命名空间:System.Drawing.Drawing2D
        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;//指定高质量的双三次插值法。执行预筛选以确保高质量的收缩。此模式可产生质量最高的转换图像。
        //设置高质量,低速度呈现平滑程度
        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        graphics.DrawImage(image, dstRect, srcRect, GraphicsUnit.Pixel);//dstRect,生成缩略图的大小srcRect,截取图片的位置
        try
        {
            //将此 原图片 以指定格式并用指定的编解码参数保存到指定文件 
            string savepath = ThumbnailImagePath;
            SaveImage(bitmap, savepath, GetCodecInfo(GetHtmime(ImagesFormats(image))));
        }
        catch (System.Exception e)
        { throw e; }
        finally
        {
            bitmap.Dispose();
            graphics.Dispose();
            image.Dispose();
        }
    }


    /// <summary>
    /// 按指定大小自动生成缩略图(不添加背景)
    /// </summary>
    /// <param name="sourceImagePath">原图片路径(相对路径)</param>
    /// <param name="thumbnailImagePath">生成的缩略图路径(相对路径)</param>
    /// <param name="thumbnailImageWidth">缩略图的宽度</param>
    /// <param name="thumbnailImageHeight">缩略图的高度</param>
    /// <param name="backgroundcolor">缩略图的背景颜色,</param>
    public static void ToThumbnailImages(string sourceImagePath, string thumbnailImagePath, int thumbnailImageWidth, int thumbnailImageHeight)
    {
        string SourceImagePath = HttpContext.Current.Server.MapPath(sourceImagePath);
        string ThumbnailImagePath = HttpContext.Current.Server.MapPath(thumbnailImagePath);
        int ThumbnailImageWidth = thumbnailImageWidth;
        string sExt = SourceImagePath.Substring(SourceImagePath.LastIndexOf(".")).ToLower();
        if (SourceImagePath.ToString() == System.String.Empty) throw new NullReferenceException("SourceImagePath is null!");
        System.Drawing.Image image = System.Drawing.Image.FromFile(SourceImagePath);//原始图片
        if (ImagesFormats(image) == string.Empty)
        {
            throw new ArgumentException("原图片文件格式不正确！", "SourceImagePath");
        }
        int dstTop = 0, dstLeft = 0, dstWidth = image.Width, dstHeight = image.Height;
        //计算出图像位置
        float defaultSizeScale = (float)thumbnailImageHeight / thumbnailImageWidth;
        float imageSizeScale = (float)image.Height / image.Width;
        if (defaultSizeScale > imageSizeScale)
        {
            dstLeft = 0;
            dstTop = (int)((thumbnailImageHeight - (imageSizeScale * thumbnailImageWidth)) / 2);
            dstWidth = thumbnailImageWidth;
            dstHeight = (int)(imageSizeScale * thumbnailImageWidth);
        }
        else if (defaultSizeScale == imageSizeScale)
        {
            dstLeft = 0;
            dstTop = 0;
            dstWidth = thumbnailImageWidth;
            dstHeight = thumbnailImageHeight;
        }
        else
        {
            dstLeft = (int)((thumbnailImageWidth - (thumbnailImageHeight / imageSizeScale)) / 2);
            dstTop = 0;
            dstWidth = (int)(thumbnailImageHeight / imageSizeScale);
            dstHeight = thumbnailImageHeight;
        }
        Bitmap bitmap = new Bitmap(dstWidth, dstHeight, PixelFormat.Format32bppArgb);//新建位图
        Graphics graphics = Graphics.FromImage(bitmap);//建立绘制图面
        Rectangle srcRect = new Rectangle(0, 0, image.Width, image.Height);//要在原图上绘制的位置
        Rectangle dstRect = new Rectangle(0, 0, dstWidth, dstHeight);//要绘制的缩略大小
        //InterpolationMode 枚举指定在缩放或旋转图像时使用的算法。命名空间:System.Drawing.Drawing2D
        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;//指定高质量的双三次插值法。执行预筛选以确保高质量的收缩。此模式可产生质量最高的转换图像。
        //设置高质量,低速度呈现平滑程度
        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        graphics.DrawImage(image, dstRect, srcRect, GraphicsUnit.Pixel);//dstRect,生成缩略图的大小srcRect,截取图片的位置
        image.Dispose();
        try
        {
            //将此 原图片 以指定格式并用指定的编解码参数保存到指定文件 
            SaveImage(bitmap, ThumbnailImagePath, GetCodecInfo(GetHtmime(sExt)));
        }
        catch (System.Exception e)
        { throw e; }
        finally
        {
            bitmap.Dispose();
            graphics.Dispose();
        }
    }


    /// <summary>
    /// 按指定大小自动生成缩略图(不添加背景)
    /// </summary>
    /// <param name="sourceImagePath">原图片文件流</param>
    /// <param name="thumbnailImagePath">生成的缩略图路径(相对路径)</param>
    /// <param name="thumbnailImageWidth">缩略图的宽度</param>
    /// <param name="thumbnailImageHeight">缩略图的高度</param>
    /// <param name="backgroundcolor">缩略图的背景颜色,</param>
    public static void ToThumbnailImages(Stream stream, string thumbnailImagePath, int thumbnailImageWidth, int thumbnailImageHeight)
    {
        string ThumbnailImagePath = HttpContext.Current.Server.MapPath(thumbnailImagePath);
        int ThumbnailImageWidth = thumbnailImageWidth;
        System.Drawing.Image image = System.Drawing.Image.FromStream(stream);//原始图片
        if (ImagesFormats(image) == string.Empty)
        {
            throw new ArgumentException("原图片文件格式不正确！", "SourceImagePath");
        }
        int dstTop = 0, dstLeft = 0, dstWidth = image.Width, dstHeight = image.Height;
        //计算出图像位置
        float defaultSizeScale = (float)thumbnailImageHeight / thumbnailImageWidth;
        float imageSizeScale = (float)image.Height / image.Width;
        if (defaultSizeScale > imageSizeScale)
        {
            dstLeft = 0;
            dstTop = (int)((thumbnailImageHeight - (imageSizeScale * thumbnailImageWidth)) / 2);
            dstWidth = thumbnailImageWidth;
            dstHeight = (int)(imageSizeScale * thumbnailImageWidth);
        }
        else if (defaultSizeScale == imageSizeScale)
        {
            dstLeft = 0;
            dstTop = 0;
            dstWidth = thumbnailImageWidth;
            dstHeight = thumbnailImageHeight;
        }
        else
        {
            dstLeft = (int)((thumbnailImageWidth - (thumbnailImageHeight / imageSizeScale)) / 2);
            dstTop = 0;
            dstWidth = (int)(thumbnailImageHeight / imageSizeScale);
            dstHeight = thumbnailImageHeight;
        }
        Bitmap bitmap = new Bitmap(dstWidth, dstHeight, PixelFormat.Format32bppArgb);//新建位图
        Graphics graphics = Graphics.FromImage(bitmap);//建立绘制图面
        Rectangle srcRect = new Rectangle(0, 0, image.Width, image.Height);//要在原图上绘制的位置
        Rectangle dstRect = new Rectangle(0, 0, dstWidth, dstHeight);//要绘制的缩略大小
        //InterpolationMode 枚举指定在缩放或旋转图像时使用的算法。命名空间:System.Drawing.Drawing2D
        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;//指定高质量的双三次插值法。执行预筛选以确保高质量的收缩。此模式可产生质量最高的转换图像。
        //设置高质量,低速度呈现平滑程度
        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        graphics.DrawImage(image, dstRect, srcRect, GraphicsUnit.Pixel);//dstRect,生成缩略图的大小srcRect,截取图片的位置
        image.Dispose();
        try
        {
            //将此 原图片 以指定格式并用指定的编解码参数保存到指定文件 
            SaveImage(bitmap, ThumbnailImagePath, GetCodecInfo(GetHtmime(ImagesFormats(image))));

        }
        catch (System.Exception e)
        { throw e; }
        finally
        {
            bitmap.Dispose();
            graphics.Dispose();
        }
    }

    #region 按源图片比例自动生成缩略图
    /// <summary>
    /// 按源图片比例自动生成缩略图
    /// </summary>
    /// <param name="sourceImagePath">原图片路径(相对路径)</param>
    /// <param name="thumbnailImagePath">生成的缩略图路径(相对路径)</param>
    /// <param name="thumbnailImageWidth">缩略图的宽度（高度与按源图片比例自动生成）</param>
    public static void ToThumbnailImages(string sourceImagePath, string thumbnailImagePath, int thumbnailImageWidth, string backgroundcolor)
    {
        string SourceImagePath = HttpContext.Current.Server.MapPath(sourceImagePath);
        string ThumbnailImagePath = HttpContext.Current.Server.MapPath(thumbnailImagePath);
        int ThumbnailImageWidth = thumbnailImageWidth;
        string sExt = SourceImagePath.Substring(SourceImagePath.LastIndexOf(".")).ToLower();
        if (SourceImagePath.ToString() == System.String.Empty) throw new NullReferenceException("SourceImagePath is null!");
        //从 原图片 创建 Image 对象
        System.Drawing.Image image = System.Drawing.Image.FromFile(SourceImagePath);
        if (ImagesFormats(image) == string.Empty)
        {
            throw new ArgumentException("原图片文件格式不正确！", "SourceImagePath");
        }
        int num = ((ThumbnailImageWidth / 4) * 3);
        int width = image.Width;
        int height = image.Height;
        //计算图片的比例
        if ((((double)width) / ((double)height)) >= 1.3333333333333333f)
        {
            num = ((height * ThumbnailImageWidth) / width);
        }
        else
        {
            ThumbnailImageWidth = ((width * num) / height);
        }
        if ((ThumbnailImageWidth < 1) || (num < 1))
        { return; }
        //用指定的大小和格式初始化 Bitmap 类的新实例
        Bitmap bitmap = new Bitmap(ThumbnailImageWidth, num, PixelFormat.Format32bppArgb);
        //从指定的 Image 对象创建新 Graphics 对象
        Graphics graphics = Graphics.FromImage(bitmap);
        //清除整个绘图面并以透明背景色填充
        //graphics.Clear(Color.Transparent);
        if (string.IsNullOrEmpty(backgroundcolor))
        { graphics.Clear(Color.Transparent); }
        else
        {
            ColorConverter colorConverter = new ColorConverter();
            Color color = new Color();
            color = (Color)colorConverter.ConvertFromString(backgroundcolor);
            graphics.Clear(color);
        }
        //InterpolationMode 枚举指定在缩放或旋转图像时使用的算法。命名空间:System.Drawing.Drawing2D
        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;//指定高质量的双三次插值法。执行预筛选以确保高质量的收缩。此模式可产生质量最高的转换图像。
        //设置高质量,低速度呈现平滑程度
        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        //在指定位置并且按指定大小绘制 原图片 对象
        graphics.DrawImage(image, new Rectangle(0, 0, ThumbnailImageWidth, num));
        image.Dispose();
        try
        {
            //将此 原图片 以指定格式并用指定的编解码参数保存到指定文件 
            SaveImage(bitmap, HttpContext.Current.Server.MapPath(ThumbnailImagePath), GetCodecInfo(GetHtmime(sExt)));
        }
        catch (System.Exception e)
        {
            throw e;
        }
        finally
        {
            bitmap.Dispose();
            graphics.Dispose();
        }
    }
    #endregion

    /// <summary>
    /// 不按照比例进行缩略
    /// </summary>
    /// <param name="sourceImagePath">原图片路径(相对路径)</param>
    /// <param name="thumbnailImagePath">生成的缩略图路径(相对路径)</param>
    /// <param name="thumbnailImageWidth">缩略图的宽度</param>
    /// <param name="thumbnailImageHeight">缩略图的高度</param>
    public static void ToThumbnailImagesNO(string sourceImagePath, string thumbnailImagePath, int thumbnailImageWidth, int thumbnailImageHeight)
    {
        string SourceImagePath = HttpContext.Current.Server.MapPath(sourceImagePath);
        string ThumbnailImagePath = HttpContext.Current.Server.MapPath(thumbnailImagePath);
        int ThumbnailImageWidth = thumbnailImageWidth;
        string sExt = SourceImagePath.Substring(SourceImagePath.LastIndexOf(".")).ToLower();
        if (SourceImagePath.ToString() == System.String.Empty) throw new NullReferenceException("SourceImagePath is null!");
        System.Drawing.Image image = System.Drawing.Image.FromFile(SourceImagePath);
        if (ImagesFormats(image) == string.Empty)
        {
            throw new ArgumentException("原图片文件格式不正确！", "SourceImagePath");
        }
        Bitmap bitmap = new Bitmap(thumbnailImageWidth, thumbnailImageHeight, PixelFormat.Format32bppArgb);
        int dstTop = 0, dstLeft = 0, dstWidth = image.Width, dstHeight = image.Height;
        //计算出图像位置
        float defaultSizeScale = (float)thumbnailImageHeight / thumbnailImageWidth;
        float imageSizeScale = (float)image.Height / image.Width;
        dstLeft = 0;
        dstTop = 0;
        dstWidth = thumbnailImageWidth;
        dstHeight = thumbnailImageHeight;
        //填充背景颜色
        Graphics graphics = Graphics.FromImage(bitmap);
        Rectangle srcRect = new Rectangle(0, 0, image.Width, image.Height);//要在原图上绘制的位置
        Rectangle dstRect = new Rectangle(dstLeft, dstTop, dstWidth, dstHeight);//要绘制的缩略大小
        //InterpolationMode 枚举指定在缩放或旋转图像时使用的算法。命名空间:System.Drawing.Drawing2D
        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;//指定高质量的双三次插值法。执行预筛选以确保高质量的收缩。此模式可产生质量最高的转换图像。
        //设置高质量,低速度呈现平滑程度
        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        graphics.DrawImage(image, dstRect, srcRect, GraphicsUnit.Pixel);//dstRect,生成缩略图的大小srcRect,截取图片的位置
        image.Dispose();
        try
        {
            //将此 原图片 以指定格式并用指定的编解码参数保存到指定文件 
            SaveImage(bitmap, ThumbnailImagePath, GetCodecInfo(GetHtmime(sExt)));
        }
        catch (System.Exception e)
        { throw e; }
        finally
        {
            bitmap.Dispose();
            graphics.Dispose();
        }
    }

    /// <summary>
    /// 压缩图片
    /// </summary>
    /// <param name="sourceImagePath">要压缩的图片路径(相对路径)</param>
    public static void ToImagesRAR(string sourceImagePath)
    {
        string SourceImagePath = HttpContext.Current.Server.MapPath(sourceImagePath);
        string sExt = SourceImagePath.Substring(SourceImagePath.LastIndexOf(".")).ToLower();
        if (SourceImagePath.ToString() == System.String.Empty) throw new NullReferenceException("SourceImagePath is null!");
        System.Drawing.Image image = System.Drawing.Image.FromFile(SourceImagePath);
        if (ImagesFormats(image) == string.Empty)
        {
            throw new ArgumentException("原图片文件格式不正确！", "SourceImagePath");
        }
        int dstTop = 0, dstLeft = 0, dstWidth = image.Width, dstHeight = image.Height;
        Bitmap bitmap = new Bitmap(dstWidth, dstHeight, PixelFormat.Format32bppArgb);

        //计算出图像位置
        float defaultSizeScale = (float)dstHeight / dstWidth;
        float imageSizeScale = (float)image.Height / image.Width;
        //填充背景颜色
        Graphics graphics = Graphics.FromImage(bitmap);
        Rectangle srcRect = new Rectangle(0, 0, image.Width, image.Height);//要在原图上绘制的位置
        Rectangle dstRect = new Rectangle(dstLeft, dstTop, dstWidth, dstHeight);//要绘制的缩略大小
        //InterpolationMode 枚举指定在缩放或旋转图像时使用的算法。命名空间:System.Drawing.Drawing2D
        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;//指定高质量的双三次插值法。执行预筛选以确保高质量的收缩。此模式可产生质量最高的转换图像。
        //设置高质量,低速度呈现平滑程度
        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        graphics.DrawImage(image, dstRect, srcRect, GraphicsUnit.Pixel);//dstRect,生成缩略图的大小srcRect,截取图片的位置
        image.Dispose();
        try
        {
            //将此 原图片 以指定格式并用指定的编解码参数保存到指定文件 
            SaveImage(bitmap, SourceImagePath, GetCodecInfo(GetHtmime(sExt)));
        }
        catch (System.Exception e)
        { throw e; }
        finally
        {
            bitmap.Dispose();
            graphics.Dispose();
        }
    }

    /// <summary>
    /// 压缩图片
    /// </summary>
    /// <param name="sourceImagePath">原始图片的路径(相对路径)</param>
    /// <param name="thumbnailImagePath">生成的缩略图路径(相对路径)</param>
    public static void ToImagesRAR(string sourceImagePath, string thumbnailImagePath)
    {
        string SourceImagePath = HttpContext.Current.Server.MapPath(sourceImagePath);
        string ThumbnailImagePath = HttpContext.Current.Server.MapPath(thumbnailImagePath);
        string sExt = SourceImagePath.Substring(SourceImagePath.LastIndexOf(".")).ToLower();
        if (SourceImagePath.ToString() == System.String.Empty) throw new NullReferenceException("SourceImagePath is null!");
        System.Drawing.Image image = System.Drawing.Image.FromFile(SourceImagePath);
        if (ImagesFormats(image) == string.Empty)
        {
            throw new ArgumentException("原图片文件格式不正确！", "SourceImagePath");
        }
        int dstTop = 0, dstLeft = 0, dstWidth = image.Width, dstHeight = image.Height;
        Bitmap bitmap = new Bitmap(dstWidth, dstHeight, PixelFormat.Format32bppArgb);
        
        //计算出图像位置
        float defaultSizeScale = (float)dstHeight / dstWidth;
        float imageSizeScale = (float)image.Height / image.Width;
        //填充背景颜色
        Graphics graphics = Graphics.FromImage(bitmap);
        Rectangle srcRect = new Rectangle(0, 0, image.Width, image.Height);//要在原图上绘制的位置
        Rectangle dstRect = new Rectangle(dstLeft, dstTop, dstWidth, dstHeight);//要绘制的缩略大小
        //InterpolationMode 枚举指定在缩放或旋转图像时使用的算法。命名空间:System.Drawing.Drawing2D
        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;//指定高质量的双三次插值法。执行预筛选以确保高质量的收缩。此模式可产生质量最高的转换图像。
        //设置高质量,低速度呈现平滑程度
        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        graphics.DrawImage(image, dstRect, srcRect, GraphicsUnit.Pixel);//dstRect,生成缩略图的大小srcRect,截取图片的位置
        image.Dispose();
        try
        {
            //将此 原图片 以指定格式并用指定的编解码参数保存到指定文件 
            SaveImage(bitmap, ThumbnailImagePath, GetCodecInfo(GetHtmime(sExt)));
        }
        catch (System.Exception e)
        { throw e; }
        finally
        {
            bitmap.Dispose();
            graphics.Dispose();
        }
    }

    /// <summary>
    /// 把文件夹中的所有图片进行压缩
    /// </summary>
    /// <param name="sourceImagePath">原图片文件夹路径(相对路径)</param>
    /// <param name="thumbnailImagePath">生成的缩略图文件夹路径(相对路径)</param>
    public static void ToImagesRARDir(string sourceImagePath, string thumbnailImagePath)
    {
        string dirpath = HttpContext.Current.Server.MapPath(sourceImagePath);
        string newdirpath = HttpContext.Current.Server.MapPath(thumbnailImagePath);

        if (dirpath == newdirpath)
        { newdirpath = newdirpath + "R_"; }
        
        string[] files = System.IO.Directory.GetFiles(dirpath);
        for (int i = 0; i < files.Length; i++)
        {
            string SourceImagePath = dirpath + files[i].Substring(files[i].LastIndexOf("\\") + 1);
            string ThumbnailImagePath = newdirpath + files[i].Substring(files[i].LastIndexOf("\\") + 1);

            string sExt = SourceImagePath.Substring(SourceImagePath.LastIndexOf(".")).ToLower();
            if (SourceImagePath.ToString() == System.String.Empty) throw new NullReferenceException("SourceImagePath is null!");
            System.Drawing.Image image = System.Drawing.Image.FromFile(SourceImagePath);
            if (ImagesFormats(image) == string.Empty)
            {
                throw new ArgumentException("原图片文件格式不正确！", "SourceImagePath");
            }
            int dstTop = 0, dstLeft = 0, dstWidth = image.Width, dstHeight = image.Height;
            Bitmap bitmap = new Bitmap(dstWidth, dstHeight, PixelFormat.Format32bppArgb);
            
            //计算出图像位置
            float defaultSizeScale = (float)dstHeight / dstWidth;
            float imageSizeScale = (float)image.Height / image.Width;
            //填充背景颜色
            Graphics graphics = Graphics.FromImage(bitmap);
            Rectangle srcRect = new Rectangle(0, 0, image.Width, image.Height);//要在原图上绘制的位置
            Rectangle dstRect = new Rectangle(dstLeft, dstTop, dstWidth, dstHeight);//要绘制的缩略大小
            //InterpolationMode 枚举指定在缩放或旋转图像时使用的算法。命名空间:System.Drawing.Drawing2D
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;//指定高质量的双三次插值法。执行预筛选以确保高质量的收缩。此模式可产生质量最高的转换图像。
            //设置高质量,低速度呈现平滑程度
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            graphics.DrawImage(image, dstRect, srcRect, GraphicsUnit.Pixel);//dstRect,生成缩略图的大小srcRect,截取图片的位置
            image.Dispose();
            try
            {
                //将此 原图片 以指定格式并用指定的编解码参数保存到指定文件 
                SaveImage(bitmap, ThumbnailImagePath, GetCodecInfo(GetHtmime(sExt)));
            }
            catch (System.Exception e)
            { throw e; }
            finally
            {
                bitmap.Dispose();
                graphics.Dispose();
            }
        }
    }

    #region 截取图片
    /// <summary>
    /// 截取图片
    /// </summary>
    /// <param name="pPath">图片路径(绝对路径)</param>
    /// <param name="pSavePath">保存路径(绝对路径)</param>
    /// <param name="pPartStartPointX">目标图片开始绘制处的坐标X值(通常为0)</param>
    /// <param name="pPartStartPointY">目标图片开始绘制处的坐标Y值(通常为0)</param>
    /// <param name="pPartWidth">截取的宽度</param>
    /// <param name="pPartHeight">截取的高度</param>
    /// <param name="pOrigStartPointX">原始图片开始截取处的坐标X值</param>
    /// <param name="pOrigStartPointY">原始图片开始截取处的坐标Y值</param>
    public static void GetPart(string pPath, string pSavedPath, int pPartStartPointX, int pPartStartPointY, int pPartWidth, int pPartHeight, int pOrigStartPointX, int pOrigStartPointY)
    {
        string normalJpgPath = pSavedPath;
        string sExt = pPath.Substring(pPath.LastIndexOf(".")).ToLower();
        using (Image originalImg = Image.FromFile(pPath))
        {
            Bitmap partImg = new Bitmap(pPartWidth, pPartHeight);
            Graphics graphics = Graphics.FromImage(partImg);
            //设置高质量插值法
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            //设置高质量,低速度呈现平滑程度
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Rectangle destRect = new Rectangle(new Point(pPartStartPointX, pPartStartPointY), new Size(pPartWidth, pPartHeight));//绘制图片的大小
            Rectangle origRect = new Rectangle(new Point(pOrigStartPointX, pOrigStartPointY), new Size(pPartWidth, pPartHeight));//要在原图上绘制的位置
            graphics.DrawImage(originalImg, destRect, origRect, GraphicsUnit.Pixel);//绘制图片
            originalImg.Dispose();
            if (File.Exists(normalJpgPath))
            {
                File.SetAttributes(normalJpgPath, FileAttributes.Normal);
                File.Delete(normalJpgPath);
            }
            SaveImage(partImg, normalJpgPath, GetCodecInfo(GetHtmime(sExt)));
            partImg.Dispose();
            graphics.Dispose();
        }
    }
    #endregion

    #region 截取图片并且缩略
    /// <summary>
    /// 截取图片并且缩略
    /// </summary>
    /// <param name="pPath">图片路径(绝对路径)</param>
    /// <param name="pSavePath">保存路径(绝对路径)</param>
    /// <param name="pPartWidth">截取的宽度</param>
    /// <param name="pPartHeight">截取的高度</param>
    /// <param name="pOrigStartPointX">原始图片开始截取处的坐标X值</param>
    /// <param name="pOrigStartPointY">原始图片开始截取处的坐标Y值</param>
    /// <param name="thumbnailImageWidth">缩略图的宽度</param>
    /// <param name="thumbnailImageHeight">缩略图的高度</param>
    /// <param name="backgroundcolor">缩略图的背景颜色,</param>
    public static void GetPart(string pPath, string pSavedPath, int pPartWidth, int pPartHeight, int pOrigStartPointX, int pOrigStartPointY, int thumbnailImageWidth, int thumbnailImageHeight, string backgroundcolor)
    {
        string normalJpgPath = pSavedPath;
        string sExt = pPath.Substring(pPath.LastIndexOf(".")).ToLower();
        using (Image originalImg = Image.FromFile(pPath))
        {
            Bitmap partImg = new Bitmap(thumbnailImageWidth, thumbnailImageHeight);
            int dstTop = 0, dstLeft = 0, dstWidth = pPartWidth, dstHeight = pPartHeight;
            //计算出图像位置
            float defaultSizeScale = (float)thumbnailImageHeight / thumbnailImageWidth;
            float imageSizeScale = (float)pPartHeight / pPartWidth;
            if (defaultSizeScale > imageSizeScale)
            {
                dstLeft = 0;
                dstTop = (int)((thumbnailImageHeight - (imageSizeScale * thumbnailImageWidth)) / 2);
                dstWidth = thumbnailImageWidth;
                dstHeight = (int)(imageSizeScale * thumbnailImageWidth);
            }
            else if (defaultSizeScale == imageSizeScale)
            {
                dstLeft = 0;
                dstTop = 0;
                dstWidth = thumbnailImageWidth;
                dstHeight = thumbnailImageHeight;
            }
            else
            {
                dstLeft = (int)((thumbnailImageWidth - (thumbnailImageHeight / imageSizeScale)) / 2);
                dstTop = 0;
                dstWidth = (int)(thumbnailImageHeight / imageSizeScale);
                dstHeight = thumbnailImageHeight;
            }
            //填充背景色
            Graphics graphics = Graphics.FromImage(partImg);
            //清除整个绘图面并以透明背景色填充
            //graphics.Clear(Color.Transparent);
            if (string.IsNullOrEmpty(backgroundcolor))
            { graphics.Clear(Color.Transparent); }
            else
            {
                ColorConverter colorConverter = new ColorConverter();
                Color color = new Color();
                color = (Color)colorConverter.ConvertFromString(backgroundcolor);
                graphics.Clear(color);
            }
            Rectangle destRect = new Rectangle(dstLeft, dstTop, dstWidth, dstHeight);//要绘制的缩略大小
            Rectangle origRect = new Rectangle(new Point(pOrigStartPointX, pOrigStartPointY), new Size(pPartWidth, pPartHeight));//要在原图上绘制的位置
            //InterpolationMode 枚举指定在缩放或旋转图像时使用的算法。命名空间:System.Drawing.Drawing2D
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;//指定高质量的双三次插值法。执行预筛选以确保高质量的收缩。此模式可产生质量最高的转换图像。
            //设置高质量,低速度呈现平滑程度
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            graphics.DrawImage(originalImg, destRect, origRect, GraphicsUnit.Pixel);//绘制图片
            if (File.Exists(normalJpgPath))
            {
                File.SetAttributes(normalJpgPath, FileAttributes.Normal);
                File.Delete(normalJpgPath);
            }
            SaveImage(partImg, normalJpgPath, GetCodecInfo(GetHtmime(sExt)));
            partImg.Dispose();//清除绘制层资源
            graphics.Dispose();//清除绘制背景资源
        }
    }
    #endregion
}
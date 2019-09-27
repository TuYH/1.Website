using System;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.IO;
using System.Web;
/// <summary>
/// ͼƬ����(����ͼ)
/// </summary>
public class ImageHelper
{
    #region ��������ͼ
    /// <summary>
    /// ��������ͼ
    /// </summary>
    /// <param name="originalImagePath">Դͼ·��������·����</param>
    /// <param name="thumbnailPath">����ͼ·��������·����</param>
    /// <param name="width">����ͼ���</param>
    /// <param name="height">����ͼ�߶�</param>
    /// <param name="mode">��������ͼ�ķ�ʽ</param>    
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
            case "HW"://ָ���߿����ţ����ܱ��Σ�                
                break;
            case "W"://ָ�����߰�����                    
                toheight = originalImage.Height * width / originalImage.Width;
                break;
            case "H"://ָ���ߣ�������
                towidth = originalImage.Width * height / originalImage.Height;
                break;
            case "Cut"://ָ���߿�ü��������Σ�                
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
        //�½�һ��bmpͼƬ
        System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);
        //�½�һ������
        System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);
        //���ø�������ֵ��
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
        //���ø�����,���ٶȳ���ƽ���̶�
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        //��ջ�������͸������ɫ���
        g.Clear(System.Drawing.Color.Transparent);
        //��ָ��λ�ò��Ұ�ָ����С����ԭͼƬ��ָ������
        g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight),
            new System.Drawing.Rectangle(x, y, ow, oh),
            System.Drawing.GraphicsUnit.Pixel);
        try
        {
            //��jpg��ʽ��������ͼ
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
    /// ��������ͼ
    /// </summary>
    /// <param name="originalImagePath">Դͼ·��������·����</param>
    /// <param name="thumbnailPath">����ͼ·��������·����</param>
    /// <param name="width">����ͼ���</param>
    /// <param name="height">����ͼ�߶�</param>
    /// <param name="mode">��������ͼ�ķ�ʽ</param>    
    public static void MakeThumbPhotoNew(string originalImagePath, string thumbnailPath, int towidth, int toheight)
    {
        System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);
        int x = 0;
        int y = 0;

        int dstTop = 0, dstLeft = 0, dstWidth = originalImage.Width, dstHeight = originalImage.Height;
        //�����ͼ��λ��
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

        //�½�һ��bmpͼƬ
        System.Drawing.Image bitmap = new System.Drawing.Bitmap(dstWidth, dstHeight);
        //�½�һ������
        System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);
        //���ø�������ֵ��
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
        //���ø�����,���ٶȳ���ƽ���̶�
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        //��ջ�������͸������ɫ���
        g.Clear(System.Drawing.Color.Transparent);
        //��ָ��λ�ò��Ұ�ָ����С����ԭͼƬ��ָ������
        g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, dstWidth, dstHeight),
            new System.Drawing.Rectangle(x, y, originalImage.Width, originalImage.Height),
            System.Drawing.GraphicsUnit.Pixel);
        try
        {
            //��jpg��ʽ��������ͼ
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

    #region ��ͼƬ����������ˮӡ
    /// <summary>
    /// ��ͼƬ����������ˮӡ
    /// </summary>
    /// <param name="Path">ԭ������ͼƬ·��</param>
    /// <param name="Path_sy">���ɵĴ�����ˮӡ��ͼƬ·��</param>
    public static void AddWater(string Path, string Path_sy)
    {
        string addText = "www.foodun.com";
        System.Drawing.Image image = System.Drawing.Image.FromFile(Path);
        System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
        //���ø�������ֵ��
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        //���ø�����,���ٶȳ���ƽ���̶�
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
    /// ��������λͼ
    /// </summary>
    /// <param name="VNum">Ҫ���ɵ�����</param>
    /// <param name="name">��������</param>
    /// <param name="path">Ҫ�����·��</param>
    public static void ValidateCode(string VNum, string name,string path)
    {
        Bitmap image = null;//����GDIλͼ
        Graphics graphics = null;//GDI��ͼͼ��
        MemoryStream stream = null;//�ڴ���
        image = new Bitmap(VNum.Length * 14, 0x18);//λͼ�Ŀ�Ⱥ͸߶�15
        graphics = Graphics.FromImage(image);//�������Ʋ�
        //ͼƬ�Ĳ���ģʽ˫���β�ֵ��
        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        //���������ٶȳ���ͼƬ
        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        graphics.Clear(Color.White);//����������ɫ
        Font font = new Font(name, 14f, FontStyle.Bold);//������ɫ�������С
        SolidBrush brush = new SolidBrush(Color.Black);//��ɫ����
        for (int i = VNum.Length; i >= 1; i--)
        {
            string str = VNum.Substring(VNum.Length - i, 1);
            graphics.DrawString(str, font, brush, (float)((VNum.Length - i) * 13) + 3, 1f);//�����ַ���14
        }
        stream = new MemoryStream();
        image.Save(System.Web.HttpContext.Current.Server.MapPath(path), ImageFormat.Png);
        graphics.Dispose();
        image.Dispose();
        image.Dispose();
    }

    #region ��ͼƬ������ͼƬˮӡ
    /// <summary>
    /// ��ͼƬˮӡ
    /// </summary>
    /// <param name="Path">ԭʼͼƬ����</param>
    /// <param name="filename">��ͼƬ����</param>
    /// <param name="watermarkFilename">ˮӡ����</param>
    /// <param name="watermarkStatus">ͼƬˮӡλ��1����2����3����4����5��6����7����8����9����</param>
    /// <param name="watermarkTransparency">ͼƬˮӡ͸���� ȡֵ��Χ1--10 (10Ϊ��͸��)</param>
    public static void AddImageSignPic(string Path, string filename, string watermarkFilename, int watermarkStatus,int watermarkTransparency)
    {
        System.Drawing.Image img = System.Drawing.Image.FromFile(Path);
        Graphics g = Graphics.FromImage(img);
        //���ø�������ֵ��
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        //���ø�����,���ٶȳ���ƽ���̶�
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
        g.DrawImage(watermark, new Rectangle(xpos, ypos, watermark.Width, watermark.Height), 1, 0, watermark.Width, watermark.Height, GraphicsUnit.Pixel, imageAttributes);//����ˮӡͼ
        img.Save(filename);//����ͼƬ
        g.Dispose();
        img.Dispose();
        watermark.Dispose();
        imageAttributes.Dispose();
    }

    /// <summary>
    /// ��ͼƬ������ͼƬˮӡ
    /// </summary>
    /// <param name="Path">ԭ������ͼƬ·��</param>
    /// <param name="Path_syp">���ɵĴ�ͼƬˮӡ��ͼƬ·��</param>
    /// <param name="Path_sypf">ˮӡͼƬ·��</param>
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
    /// ������ͼƬ�����ˮӡ
    /// </summary>
    /// <param name="htmlStr">Html�ַ���</param>
    /// <param name="IsWatermark">�Ƿ�����ˮӡ����</param>
    /// <param name="WatermarkType">ˮӡ����</param>
    /// <param name="WatermarkPath">ˮӡͼƬ·��(��Ե�ַ)</param>
    /// <param name="WatermarkFile">ˮӡͼƬ·��(��Ե�ַ)</param>
    /// <param name="WatermarkFile">ˮӡλ��1����2����3����4����5��6����7����8����9����</param>
    /// <param name="Transparent">ˮӡ͸����(1-10)10Ϊ��͸��</param>
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
                    string paths = "";//·��
                    int pathsi = 0;//·����λ��
                    string filename = "";//�ļ�����
                    string newfilename = "";//���ļ�����

                    pathsi = imgUrl.LastIndexOf("/") >= 0 ? imgUrl.LastIndexOf("/") : imgUrl.LastIndexOf("\\") >= 0 ? imgUrl.LastIndexOf("\\") : -1;//��ȡ·��
                    paths = imgUrl.Substring(0, pathsi + 1);//·��
                    filename = "temp_" + imgUrl.Substring(pathsi + 1);//�ļ�����
                    newfilename = paths + filename;//���ļ�����
                    System.IO.File.Move(System.Web.HttpContext.Current.Server.MapPath(imgUrl), System.Web.HttpContext.Current.Server.MapPath(newfilename));//�޸��ļ�����
                    if (WatermarkType == 1)
                    {
                        AddImageSignPic(System.Web.HttpContext.Current.Server.MapPath(newfilename), System.Web.HttpContext.Current.Server.MapPath(imgUrl), System.Web.HttpContext.Current.Server.MapPath(WatermarkPath) + WatermarkFile, Position, Transparent);//���ͼƬˮӡ 
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
    /// ��ȡͼ���������������������Ϣ
    /// </summary>
    /// <param name="mimeType">��������������Ķ���;�����ʼ�����Э�� (MIME) ���͵��ַ���</param>
    /// <returns>����ͼ���������������������Ϣ</returns>
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
    /// ����ͼƬ��׺
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
    /// �ж��Ƿ�ΪͼƬ
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
    /// �ж��Ƿ�ΪͼƬ
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
    /// �����ļ���ʽ
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
    /// ����ͼƬ
    /// </summary>
    /// <param name="image">Image ����</param>
    /// <param name="savePath">����·��</param>
    /// <param name="ici">ָ����ʽ�ı�������</param>
    public static void SaveImage(System.Drawing.Image image, string savePath, ImageCodecInfo ici)
    {
        //���� ԭͼƬ ����� EncoderParameters ����
        EncoderParameters parameters = new EncoderParameters(1);
        parameters.Param[0] = new EncoderParameter(Encoder.Quality, ((long)90));
        image.Save(savePath, ici, parameters);
        parameters.Dispose();
    }

    /// <summary>
    /// ��ָ����С�Զ���������ͼ(�б�����ɫ)
    /// </summary>
    /// <param name="sourceImagePath">ԭͼƬ·��(���·��)</param>
    /// <param name="thumbnailImagePath">���ɵ�����ͼ·��(���·��)</param>
    /// <param name="thumbnailImageWidth">����ͼ�Ŀ��</param>
    /// <param name="thumbnailImageHeight">����ͼ�ĸ߶�</param>
    /// <param name="backgroundcolor">����ͼ�ı�����ɫ,</param>
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
            throw new ArgumentException("ԭͼƬ�ļ���ʽ����ȷ��", "SourceImagePath");
        }
        Bitmap bitmap = new Bitmap(thumbnailImageWidth, thumbnailImageHeight, PixelFormat.Format32bppArgb);
        int dstTop = 0, dstLeft = 0, dstWidth = image.Width, dstHeight = image.Height;
        //�����ͼ��λ��
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
        //��䱳����ɫ
        Graphics graphics = Graphics.FromImage(bitmap);
        //���������ͼ�沢��͸������ɫ���
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
        Rectangle srcRect = new Rectangle(0, 0, image.Width, image.Height);//Ҫ��ԭͼ�ϻ��Ƶ�λ��
        Rectangle dstRect = new Rectangle(dstLeft, dstTop, dstWidth, dstHeight);//Ҫ���Ƶ����Դ�С
        //InterpolationMode ö��ָ�������Ż���תͼ��ʱʹ�õ��㷨�������ռ�:System.Drawing.Drawing2D
        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;//ָ����������˫���β�ֵ����ִ��Ԥɸѡ��ȷ������������������ģʽ�ɲ���������ߵ�ת��ͼ��
        //���ø�����,���ٶȳ���ƽ���̶�
        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        graphics.DrawImage(image, dstRect, srcRect, GraphicsUnit.Pixel);//dstRect,��������ͼ�Ĵ�СsrcRect,��ȡͼƬ��λ��
        image.Dispose();
        try
        {
            //���� ԭͼƬ ��ָ����ʽ����ָ���ı����������浽ָ���ļ� 
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
    /// ��ָ����С�Զ���������ͼ(�б�����ɫ)
    /// </summary>
    /// <param name="stream">ԭͼƬ�ļ���</param>
    /// <param name="thumbnailImagePath">���ɵ�����ͼ·��(���·��)</param>
    /// <param name="thumbnailImageWidth">����ͼ�Ŀ��</param>
    /// <param name="thumbnailImageHeight">����ͼ�ĸ߶�</param>
    /// <param name="backgroundcolor">����ͼ�ı�����ɫ,</param>
    public static void ToThumbnailImages(Stream stream, string thumbnailImagePath, int thumbnailImageWidth, int thumbnailImageHeight, string backgroundcolor)
    {
        string ThumbnailImagePath = HttpContext.Current.Server.MapPath(thumbnailImagePath);
        int ThumbnailImageWidth = thumbnailImageWidth;
        System.Drawing.Image image = System.Drawing.Image.FromStream(stream);
        if (ImagesFormats(image) == string.Empty)
        {
            throw new ArgumentException("ԭͼƬ�ļ���ʽ����ȷ��", "SourceImagePath");
        }
        Bitmap bitmap = new Bitmap(thumbnailImageWidth, thumbnailImageHeight, PixelFormat.Format32bppArgb);
        int dstTop = 0, dstLeft = 0, dstWidth = image.Width, dstHeight = image.Height;
        //�����ͼ��λ��
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
        //��䱳����ɫ
        Graphics graphics = Graphics.FromImage(bitmap);
        //���������ͼ�沢��͸������ɫ���
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
        Rectangle srcRect = new Rectangle(0, 0, image.Width, image.Height);//Ҫ��ԭͼ�ϻ��Ƶ�λ��
        Rectangle dstRect = new Rectangle(dstLeft, dstTop, dstWidth, dstHeight);//Ҫ���Ƶ����Դ�С
        //InterpolationMode ö��ָ�������Ż���תͼ��ʱʹ�õ��㷨�������ռ�:System.Drawing.Drawing2D
        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;//ָ����������˫���β�ֵ����ִ��Ԥɸѡ��ȷ������������������ģʽ�ɲ���������ߵ�ת��ͼ��
        //���ø�����,���ٶȳ���ƽ���̶�
        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        graphics.DrawImage(image, dstRect, srcRect, GraphicsUnit.Pixel);//dstRect,��������ͼ�Ĵ�СsrcRect,��ȡͼƬ��λ��
        try
        {
            //���� ԭͼƬ ��ָ����ʽ����ָ���ı����������浽ָ���ļ� 
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
    /// ��ָ����С�Զ���������ͼ(����ӱ���)
    /// </summary>
    /// <param name="sourceImagePath">ԭͼƬ·��(���·��)</param>
    /// <param name="thumbnailImagePath">���ɵ�����ͼ·��(���·��)</param>
    /// <param name="thumbnailImageWidth">����ͼ�Ŀ��</param>
    /// <param name="thumbnailImageHeight">����ͼ�ĸ߶�</param>
    /// <param name="backgroundcolor">����ͼ�ı�����ɫ,</param>
    public static void ToThumbnailImages(string sourceImagePath, string thumbnailImagePath, int thumbnailImageWidth, int thumbnailImageHeight)
    {
        string SourceImagePath = HttpContext.Current.Server.MapPath(sourceImagePath);
        string ThumbnailImagePath = HttpContext.Current.Server.MapPath(thumbnailImagePath);
        int ThumbnailImageWidth = thumbnailImageWidth;
        string sExt = SourceImagePath.Substring(SourceImagePath.LastIndexOf(".")).ToLower();
        if (SourceImagePath.ToString() == System.String.Empty) throw new NullReferenceException("SourceImagePath is null!");
        System.Drawing.Image image = System.Drawing.Image.FromFile(SourceImagePath);//ԭʼͼƬ
        if (ImagesFormats(image) == string.Empty)
        {
            throw new ArgumentException("ԭͼƬ�ļ���ʽ����ȷ��", "SourceImagePath");
        }
        int dstTop = 0, dstLeft = 0, dstWidth = image.Width, dstHeight = image.Height;
        //�����ͼ��λ��
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
        Bitmap bitmap = new Bitmap(dstWidth, dstHeight, PixelFormat.Format32bppArgb);//�½�λͼ
        Graphics graphics = Graphics.FromImage(bitmap);//��������ͼ��
        Rectangle srcRect = new Rectangle(0, 0, image.Width, image.Height);//Ҫ��ԭͼ�ϻ��Ƶ�λ��
        Rectangle dstRect = new Rectangle(0, 0, dstWidth, dstHeight);//Ҫ���Ƶ����Դ�С
        //InterpolationMode ö��ָ�������Ż���תͼ��ʱʹ�õ��㷨�������ռ�:System.Drawing.Drawing2D
        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;//ָ����������˫���β�ֵ����ִ��Ԥɸѡ��ȷ������������������ģʽ�ɲ���������ߵ�ת��ͼ��
        //���ø�����,���ٶȳ���ƽ���̶�
        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        graphics.DrawImage(image, dstRect, srcRect, GraphicsUnit.Pixel);//dstRect,��������ͼ�Ĵ�СsrcRect,��ȡͼƬ��λ��
        image.Dispose();
        try
        {
            //���� ԭͼƬ ��ָ����ʽ����ָ���ı����������浽ָ���ļ� 
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
    /// ��ָ����С�Զ���������ͼ(����ӱ���)
    /// </summary>
    /// <param name="sourceImagePath">ԭͼƬ�ļ���</param>
    /// <param name="thumbnailImagePath">���ɵ�����ͼ·��(���·��)</param>
    /// <param name="thumbnailImageWidth">����ͼ�Ŀ��</param>
    /// <param name="thumbnailImageHeight">����ͼ�ĸ߶�</param>
    /// <param name="backgroundcolor">����ͼ�ı�����ɫ,</param>
    public static void ToThumbnailImages(Stream stream, string thumbnailImagePath, int thumbnailImageWidth, int thumbnailImageHeight)
    {
        string ThumbnailImagePath = HttpContext.Current.Server.MapPath(thumbnailImagePath);
        int ThumbnailImageWidth = thumbnailImageWidth;
        System.Drawing.Image image = System.Drawing.Image.FromStream(stream);//ԭʼͼƬ
        if (ImagesFormats(image) == string.Empty)
        {
            throw new ArgumentException("ԭͼƬ�ļ���ʽ����ȷ��", "SourceImagePath");
        }
        int dstTop = 0, dstLeft = 0, dstWidth = image.Width, dstHeight = image.Height;
        //�����ͼ��λ��
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
        Bitmap bitmap = new Bitmap(dstWidth, dstHeight, PixelFormat.Format32bppArgb);//�½�λͼ
        Graphics graphics = Graphics.FromImage(bitmap);//��������ͼ��
        Rectangle srcRect = new Rectangle(0, 0, image.Width, image.Height);//Ҫ��ԭͼ�ϻ��Ƶ�λ��
        Rectangle dstRect = new Rectangle(0, 0, dstWidth, dstHeight);//Ҫ���Ƶ����Դ�С
        //InterpolationMode ö��ָ�������Ż���תͼ��ʱʹ�õ��㷨�������ռ�:System.Drawing.Drawing2D
        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;//ָ����������˫���β�ֵ����ִ��Ԥɸѡ��ȷ������������������ģʽ�ɲ���������ߵ�ת��ͼ��
        //���ø�����,���ٶȳ���ƽ���̶�
        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        graphics.DrawImage(image, dstRect, srcRect, GraphicsUnit.Pixel);//dstRect,��������ͼ�Ĵ�СsrcRect,��ȡͼƬ��λ��
        image.Dispose();
        try
        {
            //���� ԭͼƬ ��ָ����ʽ����ָ���ı����������浽ָ���ļ� 
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

    #region ��ԴͼƬ�����Զ���������ͼ
    /// <summary>
    /// ��ԴͼƬ�����Զ���������ͼ
    /// </summary>
    /// <param name="sourceImagePath">ԭͼƬ·��(���·��)</param>
    /// <param name="thumbnailImagePath">���ɵ�����ͼ·��(���·��)</param>
    /// <param name="thumbnailImageWidth">����ͼ�Ŀ�ȣ��߶��밴ԴͼƬ�����Զ����ɣ�</param>
    public static void ToThumbnailImages(string sourceImagePath, string thumbnailImagePath, int thumbnailImageWidth, string backgroundcolor)
    {
        string SourceImagePath = HttpContext.Current.Server.MapPath(sourceImagePath);
        string ThumbnailImagePath = HttpContext.Current.Server.MapPath(thumbnailImagePath);
        int ThumbnailImageWidth = thumbnailImageWidth;
        string sExt = SourceImagePath.Substring(SourceImagePath.LastIndexOf(".")).ToLower();
        if (SourceImagePath.ToString() == System.String.Empty) throw new NullReferenceException("SourceImagePath is null!");
        //�� ԭͼƬ ���� Image ����
        System.Drawing.Image image = System.Drawing.Image.FromFile(SourceImagePath);
        if (ImagesFormats(image) == string.Empty)
        {
            throw new ArgumentException("ԭͼƬ�ļ���ʽ����ȷ��", "SourceImagePath");
        }
        int num = ((ThumbnailImageWidth / 4) * 3);
        int width = image.Width;
        int height = image.Height;
        //����ͼƬ�ı���
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
        //��ָ���Ĵ�С�͸�ʽ��ʼ�� Bitmap �����ʵ��
        Bitmap bitmap = new Bitmap(ThumbnailImageWidth, num, PixelFormat.Format32bppArgb);
        //��ָ���� Image ���󴴽��� Graphics ����
        Graphics graphics = Graphics.FromImage(bitmap);
        //���������ͼ�沢��͸������ɫ���
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
        //InterpolationMode ö��ָ�������Ż���תͼ��ʱʹ�õ��㷨�������ռ�:System.Drawing.Drawing2D
        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;//ָ����������˫���β�ֵ����ִ��Ԥɸѡ��ȷ������������������ģʽ�ɲ���������ߵ�ת��ͼ��
        //���ø�����,���ٶȳ���ƽ���̶�
        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        //��ָ��λ�ò��Ұ�ָ����С���� ԭͼƬ ����
        graphics.DrawImage(image, new Rectangle(0, 0, ThumbnailImageWidth, num));
        image.Dispose();
        try
        {
            //���� ԭͼƬ ��ָ����ʽ����ָ���ı����������浽ָ���ļ� 
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
    /// �����ձ�����������
    /// </summary>
    /// <param name="sourceImagePath">ԭͼƬ·��(���·��)</param>
    /// <param name="thumbnailImagePath">���ɵ�����ͼ·��(���·��)</param>
    /// <param name="thumbnailImageWidth">����ͼ�Ŀ��</param>
    /// <param name="thumbnailImageHeight">����ͼ�ĸ߶�</param>
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
            throw new ArgumentException("ԭͼƬ�ļ���ʽ����ȷ��", "SourceImagePath");
        }
        Bitmap bitmap = new Bitmap(thumbnailImageWidth, thumbnailImageHeight, PixelFormat.Format32bppArgb);
        int dstTop = 0, dstLeft = 0, dstWidth = image.Width, dstHeight = image.Height;
        //�����ͼ��λ��
        float defaultSizeScale = (float)thumbnailImageHeight / thumbnailImageWidth;
        float imageSizeScale = (float)image.Height / image.Width;
        dstLeft = 0;
        dstTop = 0;
        dstWidth = thumbnailImageWidth;
        dstHeight = thumbnailImageHeight;
        //��䱳����ɫ
        Graphics graphics = Graphics.FromImage(bitmap);
        Rectangle srcRect = new Rectangle(0, 0, image.Width, image.Height);//Ҫ��ԭͼ�ϻ��Ƶ�λ��
        Rectangle dstRect = new Rectangle(dstLeft, dstTop, dstWidth, dstHeight);//Ҫ���Ƶ����Դ�С
        //InterpolationMode ö��ָ�������Ż���תͼ��ʱʹ�õ��㷨�������ռ�:System.Drawing.Drawing2D
        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;//ָ����������˫���β�ֵ����ִ��Ԥɸѡ��ȷ������������������ģʽ�ɲ���������ߵ�ת��ͼ��
        //���ø�����,���ٶȳ���ƽ���̶�
        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        graphics.DrawImage(image, dstRect, srcRect, GraphicsUnit.Pixel);//dstRect,��������ͼ�Ĵ�СsrcRect,��ȡͼƬ��λ��
        image.Dispose();
        try
        {
            //���� ԭͼƬ ��ָ����ʽ����ָ���ı����������浽ָ���ļ� 
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
    /// ѹ��ͼƬ
    /// </summary>
    /// <param name="sourceImagePath">Ҫѹ����ͼƬ·��(���·��)</param>
    public static void ToImagesRAR(string sourceImagePath)
    {
        string SourceImagePath = HttpContext.Current.Server.MapPath(sourceImagePath);
        string sExt = SourceImagePath.Substring(SourceImagePath.LastIndexOf(".")).ToLower();
        if (SourceImagePath.ToString() == System.String.Empty) throw new NullReferenceException("SourceImagePath is null!");
        System.Drawing.Image image = System.Drawing.Image.FromFile(SourceImagePath);
        if (ImagesFormats(image) == string.Empty)
        {
            throw new ArgumentException("ԭͼƬ�ļ���ʽ����ȷ��", "SourceImagePath");
        }
        int dstTop = 0, dstLeft = 0, dstWidth = image.Width, dstHeight = image.Height;
        Bitmap bitmap = new Bitmap(dstWidth, dstHeight, PixelFormat.Format32bppArgb);

        //�����ͼ��λ��
        float defaultSizeScale = (float)dstHeight / dstWidth;
        float imageSizeScale = (float)image.Height / image.Width;
        //��䱳����ɫ
        Graphics graphics = Graphics.FromImage(bitmap);
        Rectangle srcRect = new Rectangle(0, 0, image.Width, image.Height);//Ҫ��ԭͼ�ϻ��Ƶ�λ��
        Rectangle dstRect = new Rectangle(dstLeft, dstTop, dstWidth, dstHeight);//Ҫ���Ƶ����Դ�С
        //InterpolationMode ö��ָ�������Ż���תͼ��ʱʹ�õ��㷨�������ռ�:System.Drawing.Drawing2D
        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;//ָ����������˫���β�ֵ����ִ��Ԥɸѡ��ȷ������������������ģʽ�ɲ���������ߵ�ת��ͼ��
        //���ø�����,���ٶȳ���ƽ���̶�
        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        graphics.DrawImage(image, dstRect, srcRect, GraphicsUnit.Pixel);//dstRect,��������ͼ�Ĵ�СsrcRect,��ȡͼƬ��λ��
        image.Dispose();
        try
        {
            //���� ԭͼƬ ��ָ����ʽ����ָ���ı����������浽ָ���ļ� 
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
    /// ѹ��ͼƬ
    /// </summary>
    /// <param name="sourceImagePath">ԭʼͼƬ��·��(���·��)</param>
    /// <param name="thumbnailImagePath">���ɵ�����ͼ·��(���·��)</param>
    public static void ToImagesRAR(string sourceImagePath, string thumbnailImagePath)
    {
        string SourceImagePath = HttpContext.Current.Server.MapPath(sourceImagePath);
        string ThumbnailImagePath = HttpContext.Current.Server.MapPath(thumbnailImagePath);
        string sExt = SourceImagePath.Substring(SourceImagePath.LastIndexOf(".")).ToLower();
        if (SourceImagePath.ToString() == System.String.Empty) throw new NullReferenceException("SourceImagePath is null!");
        System.Drawing.Image image = System.Drawing.Image.FromFile(SourceImagePath);
        if (ImagesFormats(image) == string.Empty)
        {
            throw new ArgumentException("ԭͼƬ�ļ���ʽ����ȷ��", "SourceImagePath");
        }
        int dstTop = 0, dstLeft = 0, dstWidth = image.Width, dstHeight = image.Height;
        Bitmap bitmap = new Bitmap(dstWidth, dstHeight, PixelFormat.Format32bppArgb);
        
        //�����ͼ��λ��
        float defaultSizeScale = (float)dstHeight / dstWidth;
        float imageSizeScale = (float)image.Height / image.Width;
        //��䱳����ɫ
        Graphics graphics = Graphics.FromImage(bitmap);
        Rectangle srcRect = new Rectangle(0, 0, image.Width, image.Height);//Ҫ��ԭͼ�ϻ��Ƶ�λ��
        Rectangle dstRect = new Rectangle(dstLeft, dstTop, dstWidth, dstHeight);//Ҫ���Ƶ����Դ�С
        //InterpolationMode ö��ָ�������Ż���תͼ��ʱʹ�õ��㷨�������ռ�:System.Drawing.Drawing2D
        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;//ָ����������˫���β�ֵ����ִ��Ԥɸѡ��ȷ������������������ģʽ�ɲ���������ߵ�ת��ͼ��
        //���ø�����,���ٶȳ���ƽ���̶�
        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        graphics.DrawImage(image, dstRect, srcRect, GraphicsUnit.Pixel);//dstRect,��������ͼ�Ĵ�СsrcRect,��ȡͼƬ��λ��
        image.Dispose();
        try
        {
            //���� ԭͼƬ ��ָ����ʽ����ָ���ı����������浽ָ���ļ� 
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
    /// ���ļ����е�����ͼƬ����ѹ��
    /// </summary>
    /// <param name="sourceImagePath">ԭͼƬ�ļ���·��(���·��)</param>
    /// <param name="thumbnailImagePath">���ɵ�����ͼ�ļ���·��(���·��)</param>
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
                throw new ArgumentException("ԭͼƬ�ļ���ʽ����ȷ��", "SourceImagePath");
            }
            int dstTop = 0, dstLeft = 0, dstWidth = image.Width, dstHeight = image.Height;
            Bitmap bitmap = new Bitmap(dstWidth, dstHeight, PixelFormat.Format32bppArgb);
            
            //�����ͼ��λ��
            float defaultSizeScale = (float)dstHeight / dstWidth;
            float imageSizeScale = (float)image.Height / image.Width;
            //��䱳����ɫ
            Graphics graphics = Graphics.FromImage(bitmap);
            Rectangle srcRect = new Rectangle(0, 0, image.Width, image.Height);//Ҫ��ԭͼ�ϻ��Ƶ�λ��
            Rectangle dstRect = new Rectangle(dstLeft, dstTop, dstWidth, dstHeight);//Ҫ���Ƶ����Դ�С
            //InterpolationMode ö��ָ�������Ż���תͼ��ʱʹ�õ��㷨�������ռ�:System.Drawing.Drawing2D
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;//ָ����������˫���β�ֵ����ִ��Ԥɸѡ��ȷ������������������ģʽ�ɲ���������ߵ�ת��ͼ��
            //���ø�����,���ٶȳ���ƽ���̶�
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            graphics.DrawImage(image, dstRect, srcRect, GraphicsUnit.Pixel);//dstRect,��������ͼ�Ĵ�СsrcRect,��ȡͼƬ��λ��
            image.Dispose();
            try
            {
                //���� ԭͼƬ ��ָ����ʽ����ָ���ı����������浽ָ���ļ� 
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

    #region ��ȡͼƬ
    /// <summary>
    /// ��ȡͼƬ
    /// </summary>
    /// <param name="pPath">ͼƬ·��(����·��)</param>
    /// <param name="pSavePath">����·��(����·��)</param>
    /// <param name="pPartStartPointX">Ŀ��ͼƬ��ʼ���ƴ�������Xֵ(ͨ��Ϊ0)</param>
    /// <param name="pPartStartPointY">Ŀ��ͼƬ��ʼ���ƴ�������Yֵ(ͨ��Ϊ0)</param>
    /// <param name="pPartWidth">��ȡ�Ŀ��</param>
    /// <param name="pPartHeight">��ȡ�ĸ߶�</param>
    /// <param name="pOrigStartPointX">ԭʼͼƬ��ʼ��ȡ��������Xֵ</param>
    /// <param name="pOrigStartPointY">ԭʼͼƬ��ʼ��ȡ��������Yֵ</param>
    public static void GetPart(string pPath, string pSavedPath, int pPartStartPointX, int pPartStartPointY, int pPartWidth, int pPartHeight, int pOrigStartPointX, int pOrigStartPointY)
    {
        string normalJpgPath = pSavedPath;
        string sExt = pPath.Substring(pPath.LastIndexOf(".")).ToLower();
        using (Image originalImg = Image.FromFile(pPath))
        {
            Bitmap partImg = new Bitmap(pPartWidth, pPartHeight);
            Graphics graphics = Graphics.FromImage(partImg);
            //���ø�������ֵ��
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            //���ø�����,���ٶȳ���ƽ���̶�
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Rectangle destRect = new Rectangle(new Point(pPartStartPointX, pPartStartPointY), new Size(pPartWidth, pPartHeight));//����ͼƬ�Ĵ�С
            Rectangle origRect = new Rectangle(new Point(pOrigStartPointX, pOrigStartPointY), new Size(pPartWidth, pPartHeight));//Ҫ��ԭͼ�ϻ��Ƶ�λ��
            graphics.DrawImage(originalImg, destRect, origRect, GraphicsUnit.Pixel);//����ͼƬ
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

    #region ��ȡͼƬ��������
    /// <summary>
    /// ��ȡͼƬ��������
    /// </summary>
    /// <param name="pPath">ͼƬ·��(����·��)</param>
    /// <param name="pSavePath">����·��(����·��)</param>
    /// <param name="pPartWidth">��ȡ�Ŀ��</param>
    /// <param name="pPartHeight">��ȡ�ĸ߶�</param>
    /// <param name="pOrigStartPointX">ԭʼͼƬ��ʼ��ȡ��������Xֵ</param>
    /// <param name="pOrigStartPointY">ԭʼͼƬ��ʼ��ȡ��������Yֵ</param>
    /// <param name="thumbnailImageWidth">����ͼ�Ŀ��</param>
    /// <param name="thumbnailImageHeight">����ͼ�ĸ߶�</param>
    /// <param name="backgroundcolor">����ͼ�ı�����ɫ,</param>
    public static void GetPart(string pPath, string pSavedPath, int pPartWidth, int pPartHeight, int pOrigStartPointX, int pOrigStartPointY, int thumbnailImageWidth, int thumbnailImageHeight, string backgroundcolor)
    {
        string normalJpgPath = pSavedPath;
        string sExt = pPath.Substring(pPath.LastIndexOf(".")).ToLower();
        using (Image originalImg = Image.FromFile(pPath))
        {
            Bitmap partImg = new Bitmap(thumbnailImageWidth, thumbnailImageHeight);
            int dstTop = 0, dstLeft = 0, dstWidth = pPartWidth, dstHeight = pPartHeight;
            //�����ͼ��λ��
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
            //��䱳��ɫ
            Graphics graphics = Graphics.FromImage(partImg);
            //���������ͼ�沢��͸������ɫ���
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
            Rectangle destRect = new Rectangle(dstLeft, dstTop, dstWidth, dstHeight);//Ҫ���Ƶ����Դ�С
            Rectangle origRect = new Rectangle(new Point(pOrigStartPointX, pOrigStartPointY), new Size(pPartWidth, pPartHeight));//Ҫ��ԭͼ�ϻ��Ƶ�λ��
            //InterpolationMode ö��ָ�������Ż���תͼ��ʱʹ�õ��㷨�������ռ�:System.Drawing.Drawing2D
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;//ָ����������˫���β�ֵ����ִ��Ԥɸѡ��ȷ������������������ģʽ�ɲ���������ߵ�ת��ͼ��
            //���ø�����,���ٶȳ���ƽ���̶�
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            graphics.DrawImage(originalImg, destRect, origRect, GraphicsUnit.Pixel);//����ͼƬ
            if (File.Exists(normalJpgPath))
            {
                File.SetAttributes(normalJpgPath, FileAttributes.Normal);
                File.Delete(normalJpgPath);
            }
            SaveImage(partImg, normalJpgPath, GetCodecInfo(GetHtmime(sExt)));
            partImg.Dispose();//������Ʋ���Դ
            graphics.Dispose();//������Ʊ�����Դ
        }
    }
    #endregion
}
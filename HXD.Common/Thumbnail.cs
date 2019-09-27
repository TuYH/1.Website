using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
using System.Web;
using System.Collections;
namespace HXD.Common
{
    public class Thumbnail
    {
        private string originalimagepath = string.Empty;
        private string thumbnailpath = string.Empty;
        private string filename = string.Empty;
        private int width = 0;
        private int height = 0;
        private string mode = "Cut";
        private ArrayList _info = new ArrayList();
        private static string[] _ThumbnailDir = new string[1] { "ico" };

        /// <summary>
        /// 源图路径(绝对路径)
        /// </summary>
        public string OriginalImagePath
        {
            get { return originalimagepath; }
            set { originalimagepath = value; }
        }

        /// <summary>
        /// 缩略图路径(绝对路径)
        /// </summary>
        public string ThumbnailPath
        {
            get { return thumbnailpath; }
            set { thumbnailpath = value; }
        }

        /// <summary>
        /// 图片文件名
        /// </summary>
        public string FileName
        {
            get { return filename; }
            set { filename = value; }
        }

        /// <summary>
        /// 缩略图宽
        /// </summary>
        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        /// <summary>
        /// 缩略图高
        /// </summary>
        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        /// <summary>
        /// 宽度,高度
        /// </summary>
        public ArrayList Info
        {
            get { return _info; }
            set { _info = value; }
        }

        /// <summary>
        /// 缩略文件夹名
        /// </summary>
        public static string[] ThumbnailDir
        {
            get { return _ThumbnailDir; }
            set { _ThumbnailDir = value; }
        }

        /// <summary>
        /// 生成缩略图的方式(HW:指定高宽缩放,W:指定宽，高按比例,H:指定高，宽按比例,Cut:指定高宽裁减)
        /// </summary>
        public string Mode
        {
            get { return mode; }
            set { mode = value; }
        }

        /// <summary>
        /// 生成缩略图
        /// </summary>
        public void MakeThumbnail()
        {
            originalimagepath = HttpContext.Current.Server.MapPath(originalimagepath);
            //for (int i = 0; i < this.Info.Count; i++)
            //{
            //    int[] k = (int[])this.Info[i];
                if (String.IsNullOrEmpty(thumbnailpath))
                {
                    thumbnailpath = originalimagepath +  "ico/";
                }
                else
                {
                    thumbnailpath = HttpContext.Current.Server.MapPath(thumbnailpath);
                }
                if (!Directory.Exists(thumbnailpath))
                {
                    Directory.CreateDirectory(thumbnailpath);
                }

                //width = k[0];
                //height = k[1];

                Image originalImage = Image.FromFile(originalimagepath + filename);

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
                }
                //新建一个bmp图片
                Image bitmap = new System.Drawing.Bitmap(towidth, toheight);
                //新建一个画板
                Graphics g = System.Drawing.Graphics.FromImage(bitmap);
                //设置高质量插值法
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                //设置高质量,低速度呈现平滑程度
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                //清空画布并以透明背景色填充
                g.Clear(Color.Transparent);
                //在指定位置并且按指定大小绘制原图片的指定部分
                g.DrawImage(originalImage, new Rectangle(0, 0, towidth, toheight), new Rectangle(x, y, ow, oh), GraphicsUnit.Pixel);
                try
                {
                    //以jpg格式保存缩略图
                    bitmap.Save(thumbnailpath + filename, System.Drawing.Imaging.ImageFormat.Jpeg);
                    originalImage.Dispose();
                    bitmap.Dispose();
                    g.Dispose();
                }
                catch (System.Exception e)
                {
                    throw e;
                }
            //}
        }
    }
}

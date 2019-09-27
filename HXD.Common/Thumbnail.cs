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
        /// Դͼ·��(����·��)
        /// </summary>
        public string OriginalImagePath
        {
            get { return originalimagepath; }
            set { originalimagepath = value; }
        }

        /// <summary>
        /// ����ͼ·��(����·��)
        /// </summary>
        public string ThumbnailPath
        {
            get { return thumbnailpath; }
            set { thumbnailpath = value; }
        }

        /// <summary>
        /// ͼƬ�ļ���
        /// </summary>
        public string FileName
        {
            get { return filename; }
            set { filename = value; }
        }

        /// <summary>
        /// ����ͼ��
        /// </summary>
        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        /// <summary>
        /// ����ͼ��
        /// </summary>
        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        /// <summary>
        /// ���,�߶�
        /// </summary>
        public ArrayList Info
        {
            get { return _info; }
            set { _info = value; }
        }

        /// <summary>
        /// �����ļ�����
        /// </summary>
        public static string[] ThumbnailDir
        {
            get { return _ThumbnailDir; }
            set { _ThumbnailDir = value; }
        }

        /// <summary>
        /// ��������ͼ�ķ�ʽ(HW:ָ���߿�����,W:ָ�����߰�����,H:ָ���ߣ�������,Cut:ָ���߿�ü�)
        /// </summary>
        public string Mode
        {
            get { return mode; }
            set { mode = value; }
        }

        /// <summary>
        /// ��������ͼ
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
                //�½�һ��bmpͼƬ
                Image bitmap = new System.Drawing.Bitmap(towidth, toheight);
                //�½�һ������
                Graphics g = System.Drawing.Graphics.FromImage(bitmap);
                //���ø�������ֵ��
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                //���ø�����,���ٶȳ���ƽ���̶�
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                //��ջ�������͸������ɫ���
                g.Clear(Color.Transparent);
                //��ָ��λ�ò��Ұ�ָ����С����ԭͼƬ��ָ������
                g.DrawImage(originalImage, new Rectangle(0, 0, towidth, toheight), new Rectangle(x, y, ow, oh), GraphicsUnit.Pixel);
                try
                {
                    //��jpg��ʽ��������ͼ
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

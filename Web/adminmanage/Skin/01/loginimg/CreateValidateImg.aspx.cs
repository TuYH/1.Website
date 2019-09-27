using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;

public partial class admin_loginimg_CreateValidateImg : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string validate = RandomString(4);
        Session["SGQ_WebValidate"] = validate;
        DrawImage(validate);
    }

    private string RandomString(int bit)
    {
        string chars = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,1,2,3,4,5,6,7,8,9,0";
        string[] charArray = chars.Split(',');
        string result = "";
        Random rdm = new Random();
        for (int i = 0; i < bit; i++)
        {
            result += charArray[rdm.Next(36)];
        }
        return result;
    }
    private void DrawImage(string valCode)
    {
        Bitmap bmp = new Bitmap(valCode.Length * 19, 25);
        Graphics g = Graphics.FromImage(bmp);
        try
        {
            g.Clear(Color.White);

            //定义颜色和字体集
            Color[] c = { Color.Gray, Color.Green, Color.Navy, Color.DarkCyan, Color.Brown, Color.Purple, Color.DarkMagenta };
            string fonts = "Arial";//Comic Sans MS

            //绘制背景网格
            Pen p = new Pen(Color.LightGray, 0);
            int y = 5;
            do
            {
                g.DrawLine(p, 0, y, bmp.Width, y);
                y += 5;
            }
            while (y < bmp.Height);
            int x = 5;
            do
            {
                g.DrawLine(p, x, 0, x, bmp.Height);
                x += 5;
            }
            while (x < bmp.Width);

            //输出验证码字符
            Random rdm = new Random();
            for (int i = 0; i < valCode.Length; i++)
            {
                int ci = rdm.Next(c.Length);
                Font f = new Font(fonts, 15, FontStyle.Bold);
                Brush b = new SolidBrush(c[ci]);
                g.DrawString(valCode.Substring(i, 1), f, b, 5 + (i * 15), rdm.Next(0, 1));
            }

            //绘制边框
            g.DrawRectangle(p, 0, 0, bmp.Width - 1, bmp.Height - 1);

            //输出到页面
            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            Response.Cache.SetNoStore();
            Response.ClearContent();
            Response.ContentType = "image/Gif";
            Response.BinaryWrite(ms.ToArray());
            Response.End();
        }
        finally
        {
            g.Dispose();
            bmp.Dispose();
        }
    }
}

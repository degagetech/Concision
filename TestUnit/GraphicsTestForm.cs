using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestUnit
{
    public partial class GraphicsTestForm : Form
    {
        public GraphicsTestForm()
        {
            InitializeComponent();
            this.pictureBox1.Image = new Bitmap(@".\concision.png");
            // ImageProcessor.CopyGray((Bitmap)this.pictureBox1.Image);
            this.pictureBox2.Image = ImageProcessor.CopyGray((Bitmap)this.pictureBox1.Image);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            base.OnPaint(e);
        }
        /// <summary>
        ///使用指定<see cref="Graphics"/>对象绘制并填充一个圆角矩形
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="radius"></param>
        /// <param name="g"></param>
        protected void DrawRoundRect(RectangleF rect, Single radius, Graphics g)
        {
            //RectangleF rect = new RectangleF(20, 20, 200, 100);
            //Single radius = 5F;
            Pen p = new Pen(Color.Black, 2);
            Brush b = new SolidBrush(Color.Black);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X + radius, rect.Y + radius, radius, radius, 180, 90);
            path.AddArc(rect.X + rect.Width - radius, rect.Y + radius, radius, radius, 270, 90);
            path.AddArc(rect.X + rect.Width - radius, rect.Y + rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X + radius, rect.Y + rect.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
            g.DrawPath(p, path);
            g.FillPath(b, path);
            p.Dispose();
            b.Dispose();
        }
    }
    /// <summary>
    /// 图像处理类
    /// </summary>
    public sealed class ImageProcessor
    {

        /// <summary>
        ///复制指定的<see cref="Bitmap"/>对象，并对新的图像做灰度处理
        /// </summary>
        public static Bitmap CopyGray(Bitmap image)
        {
            Bitmap grayBitmap = ImageProcessor.Clone(image);
            ImageProcessor.Gray(grayBitmap);
            return grayBitmap;
        }
        /// <summary>
        /// 对指定的图像进行缩放处理
        /// </summary>
        ///  <param name="scaleValue">缩放因子，例如 0.5 将图像的长宽缩放成原来的 50%</param>
        public static void Scale(Bitmap image, Single scaleValue)
        {
            
        }
        /// <summary>
        /// 对指定的图像进行灰度处理
        /// </summary>
        public static void Gray(Bitmap image)
        {
            Int32 width = image.Width;
            Int32 height = image.Height;
            for (Int32 x = 0; x < width; ++x)
            {
                for (Int32 y = 0; y < height; ++y)
                {
                    //此处对数据的随机访问，会造成巨大性能损失，以后改进！！！！
                    Color pixel = image.GetPixel(x, y);
                    //计算相应的灰度值  Gray=R*0.3+G*0.59+B*0.11;
                    //常用灰度值计算公式
                    //2至20位精度的系数：
                    //      Gray = (R * 1 + G * 2 + B * 1) >> 2
                    //      Gray = (R * 2 + G * 5 + B * 1) >> 3
                    //      Gray = (R * 4 + G * 10 + B * 2) >> 4
                    //      Gray = (R * 9 + G * 19 + B * 4) >> 5
                    //      Gray = (R * 19 + G * 37 + B * 8) >> 6
                    //      Gray = (R * 38 + G * 75 + B * 15) >> 7
                    //      Gray = (R * 76 + G * 150 + B * 30) >> 8
                    //      Gray = (R * 153 + G * 300 + B * 59) >> 9
                    //      Gray = (R * 306 + G * 601 + B * 117) >> 10
                    //      Gray = (R * 612 + G * 1202 + B * 234) >> 11
                    //      Gray = (R * 1224 + G * 2405 + B * 467) >> 12
                    //      Gray = (R * 2449 + G * 4809 + B * 934) >> 13
                    //      Gray = (R * 4898 + G * 9618 + B * 1868) >> 14
                    //      Gray = (R * 9797 + G * 19235 + B * 3736) >> 15
                    //      Gray = (R * 19595 + G * 38469 + B * 7472) >> 16
                    //      Gray = (R * 39190 + G * 76939 + B * 14943) >> 17
                    //      Gray = (R * 78381 + G * 153878 + B * 29885) >> 18
                    //      Gray = (R * 156762 + G * 307757 + B * 59769) >> 19
                    //      Gray = (R * 313524 + G * 615514 + B * 119538) >> 20
                    Int32 grayValue = (pixel.R * 38 + pixel.G * 75 + pixel.B * 15) >> 7;
                    pixel = Color.FromArgb(grayValue, grayValue, grayValue);
                    image.SetPixel(x, y, pixel);
                }
            }
        }
        /// <summary>
        /// 克隆指定的图像
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static Bitmap Clone(Bitmap image)
        {
            Bitmap clone = image.Clone() as Bitmap;
            return clone;
        }
        //        bitPhoto.Save(Response.OutputStream, ImageFormat.Jpeg)；
        //图像保存的问题，默认的质量是60%

        //            EncoderParameter p;
        //        EncoderParameters ps;

        //        ps = new EncoderParameters(1);

        //        p = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);
        //        ps.Param[0] = p;

        //            ImageCodecInfo ii = GetCodecInfo("image/jpeg");
        //        bitPhoto.Save(Response.OutputStream, ii, ps);

        //        private ImageCodecInfo GetCodecInfo(string mimeType)
        //        {
        //            ImageCodecInfo[] CodecInfo = ImageCodecInfo.GetImageEncoders();
        //            foreach (ImageCodecInfo ici in CodecInfo)
        //            {
        //                if (ici.MimeType == mimeType) return ici;
        //            }
        //            return null;
        //        }
        //        复制代码
    }
}

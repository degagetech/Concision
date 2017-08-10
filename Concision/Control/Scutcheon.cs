using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
namespace Concision.Control
{

    /// <summary>
    /// 标牌的形状类型
    /// </summary>
    public enum ScutcheonShapeType
    {
        /// <summary>
        /// 圆形
        /// </summary>
        Circle,
        /// <summary>
        /// 方形
        /// </summary>
        Square,
        /// <summary>
        /// 三角形
        /// </summary>
        Triangle
    }

    /// <summary>
    /// 标牌
    /// </summary>
    public class Scutcheon : BaseControl
    {
        [Description("标牌的颜色")]
        public Color ScutcheonColor { get; set; } = Color.FromArgb(175, 175, 175);
        [Description("阴影的颜色")]
        public Color ShadowColor { get; set; } = Color.FromArgb(150, 175, 175, 175);
        [Description("阴影的宽度")]
        public Int32 ShadowWidth { get; set; } = 1;
        [Description("标牌的形状")]
        public ScutcheonShapeType ScutcheonShape
        {
            get
            {

                return this._scutcheonShape;
            }
            set
            {
                if (this._scutcheonShape != value)
                {
                    this._scutcheonShape = value;
                    this.Invalidate();
                }

            }
        }


        /********************************/
        private ScutcheonShapeType _scutcheonShape = ScutcheonShapeType.Circle;
        public Scutcheon() : base()
        {
            this.ScutcheonColor = Color.FromArgb(27, 166, 228);
            this.DoubleBuffered = true;
            this.ForeColor = Color.White;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            Int32 scutcheonWidth = this.Width - this.ShadowWidth - 1;
            Int32 scutcheonHeight = this.Height - this.ShadowWidth - 1;
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.CompositingQuality = CompositingQuality.HighQuality;

            /*********************/

            Rectangle shadowRect = new Rectangle(this.ShadowWidth, this.ShadowWidth, scutcheonWidth, scutcheonHeight);
            Brush shadowBursh = new SolidBrush(this.ShadowColor);


            RectangleF scutcheonRect = new Rectangle(0, 0, scutcheonWidth, scutcheonHeight);
            Brush scutcheonBrush = new SolidBrush(this.ScutcheonColor);

            RectangleF textVectorRect = scutcheonRect;
            Brush textBrush = new SolidBrush(this.ForeColor);

            switch (this.ScutcheonShape)
            {
                case ScutcheonShapeType.Square:
                    {
                        g.FillRectangle(shadowBursh, shadowRect);
                        g.FillRectangle(scutcheonBrush, scutcheonRect);
                    }
                    break;
                case ScutcheonShapeType.Triangle:
                    {
                        //文字相对于垂直居中下移25%
                        textVectorRect.Height = textVectorRect.Height * 1.25F;

                        PointF[] vertexes = new PointF[]
                            {
                               new PointF(scutcheonWidth/2.0F,0),
                               new PointF(0,scutcheonHeight),
                               new PointF(scutcheonWidth,scutcheonHeight),
                            };
                        PointF[] shadowVertexes = new PointF[]
                           {
                               new PointF(scutcheonWidth/2.0F+this.ShadowWidth,ShadowWidth/2.0F),
                               new PointF(this.ShadowWidth,scutcheonHeight+this.ShadowWidth),
                               new PointF(scutcheonWidth+this.ShadowWidth,scutcheonHeight+this.ShadowWidth),
                            };
                        //绘制阴影
                        g.FillPolygon(shadowBursh, shadowVertexes);
                        //绘制内容
                        g.FillPolygon(scutcheonBrush, vertexes);
                    }
                    break;
                case ScutcheonShapeType.Circle:
                default:
                    {
                        g.FillEllipse(shadowBursh, shadowRect);
                        g.FillEllipse(scutcheonBrush, scutcheonRect);
                    }
                    break;
            }
            this.DrawText(g, this.Text, this.Font, textBrush, textVectorRect, this.TextAlignFormat);

            this.ReleaseBrush(shadowBursh, scutcheonBrush, textBrush);
            base.OnPaint(e);
        }
    }
}

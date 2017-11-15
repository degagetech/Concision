using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Concision;
namespace Concision.Controls
{
    
    public class BaseControl : System.Windows.Forms.Control
    {
        /// <summary>
        /// 获取或设置文本布局信息
        /// </summary>
        [Description("文本布局信息")]
        protected virtual StringFormat TextAlignFormat { get; set; } = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };

        /// <summary>
        /// 指定文本在控件上的对齐方式
        /// </summary>
        [Description("指定文本在控件上的对齐方式")]
        public virtual ContentAlignment TextAlign
        {
            get
            {
                return this._textAlign;
            }
            set
            {
                if (this._textAlign != value)
                {
                    this.OnTextAlignChanged(this._textAlign, value);
                    this._textAlign = value;
                }
            }
        }


        public override String Text
        {
            get
            {
                return base.Text;
            }

            set
            {
                base.Text = value;
                Graphics g = this.CreateGraphics();
                this.CalcuteTextPixelSize(g, true);
                g.Dispose();
            }
        }
        public override Font Font
        {
            get
            {
                return base.Font;
            }

            set
            {
                base.Font = value;
                Graphics g = this.CreateGraphics();
                this.CalcuteTextPixelSize(g, true);
                g.Dispose();
            }
        }
        /// <summary>
        /// 背景色跟随父容器
        /// </summary>
        protected virtual Boolean FollowParentBackColor { get; set; } = true;
        protected virtual SizeF TextPixelSizeCache { get; private set; } = SizeF.Empty;

        /// <summary>
        /// 开启鼠标穿透
        /// </summary>
        [Description("开启鼠标穿透")]
        public virtual Boolean EnabledMousePierce { get; set; } = false;

        /********************************/
        private ContentAlignment _textAlign = ContentAlignment.MiddleCenter;
        public BaseControl()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.Margin = new Padding(0, 0, 0, 0);
            this.Padding = new Padding(0, 0, 0, 0);
        }
        protected virtual void OnTextAlignChanged(ContentAlignment oldAlign, ContentAlignment newAlign)
        {
            switch (newAlign)
            {
                case ContentAlignment.BottomCenter:
                    {
                        this.TextAlignFormat.Alignment = StringAlignment.Center;
                        this.TextAlignFormat.LineAlignment = StringAlignment.Far;
                    }
                    break;
                case ContentAlignment.BottomLeft:
                    {
                        this.TextAlignFormat.Alignment = StringAlignment.Near;
                        this.TextAlignFormat.LineAlignment = StringAlignment.Far;
                    }
                    break;
                case ContentAlignment.BottomRight:
                    {
                        this.TextAlignFormat.Alignment = StringAlignment.Far;
                        this.TextAlignFormat.LineAlignment = StringAlignment.Far;
                    }
                    break;
                case ContentAlignment.MiddleCenter:
                    {
                        this.TextAlignFormat.Alignment = StringAlignment.Center;
                        this.TextAlignFormat.LineAlignment = StringAlignment.Center;
                    }
                    break;
                case ContentAlignment.MiddleLeft:
                    {
                        this.TextAlignFormat.Alignment = StringAlignment.Near;
                        this.TextAlignFormat.LineAlignment = StringAlignment.Center;
                    }
                    break;
                case ContentAlignment.MiddleRight:
                    {
                        this.TextAlignFormat.Alignment = StringAlignment.Far;
                        this.TextAlignFormat.LineAlignment = StringAlignment.Center;
                    }
                    break;
                case ContentAlignment.TopCenter:
                    {
                        this.TextAlignFormat.Alignment = StringAlignment.Center;
                        this.TextAlignFormat.LineAlignment = StringAlignment.Near;
                    }
                    break;
                case ContentAlignment.TopLeft:
                    {
                        this.TextAlignFormat.Alignment = StringAlignment.Near;
                        this.TextAlignFormat.LineAlignment = StringAlignment.Near;
                    }
                    break;
                case ContentAlignment.TopRight:
                    {
                        this.TextAlignFormat.Alignment = StringAlignment.Far;
                        this.TextAlignFormat.LineAlignment = StringAlignment.Near;
                    }
                    break;
                default:
                    break;
            }
            this.Invalidate();
        }
        /// <summary>
        /// 绘制文字信息至指定区域，默认文字垂直位置居中，水平位置由参数<see cref="x"/>指定
        /// </summary>
        /// <param name="g"></param>
        /// <param name="vectorRect"></param>
        protected virtual void DrawText(Graphics g, Brush brush, RectangleF vectorRect, Single x)
        {
            SizeF textSize = this.CalcuteTextPixelSize(g);
            Single offsetY = (vectorRect.Height - textSize.Height) / 2.0F;
            this.DrawText(g, brush, x, offsetY);
        }
        protected override void OnTextChanged(EventArgs e)
        {
            this.Invalidate();
            base.OnTextChanged(e);
        }
        /// <summary>
        /// 在控件上绘制文字信息，此函数默认将文字绘制至区域中心,并根据偏移量调整位置
        /// </summary>
        /// <param name="g"></param>
        /// <param name="vectorRect">承载文字的区域</param>
        /// <param name="offset">文字的偏移量</param>
        protected virtual void DrawText(Graphics g, Brush brush, PointF offset)
        {
            this.DrawText(g, brush, offset.X, offset.Y);
        }
        protected virtual void DrawText(Graphics g, Brush brush, String text, Font font, Single x, Single y)
        {
            if (!String.IsNullOrEmpty(text))
            {
                g.DrawString(text, font, brush, x, y);
            }
        }

        protected virtual void DrawText(Graphics g, Brush brush, Single x, Single y)
        {
            this.DrawText(g, brush, this.Text, this.Font, x, y);
        }
        protected virtual SizeF CalcuteTextPixelSize(Graphics g, Boolean force = false)
        {
            if (this.TextPixelSizeCache == SizeF.Empty || force)
            {
                this.TextPixelSizeCache = g.MeasureString(this.Text, this.Font);
            }
            return this.TextPixelSizeCache;
        }
        /// <summary>
        /// 使用 控件的字体与以及字体颜色创建的笔刷绘制 文本至指定的区域正中心
        /// </summary>
        /// <param name="g"></param>
        /// <param name="vectorRect"></param>
        protected virtual void DrawText(Graphics g, RectangleF vectorRect)
        {
            Brush textBrush = new SolidBrush(this.ForeColor);
            this.DrawText(g, textBrush, vectorRect);
            this.ReleaseBrush(textBrush);
        }
        /// <summary>
        /// 在控件上绘制文字信息，此函数默认将文字绘制至区域中心，如果需要调整文字的位置，请使用其他重载
        /// </summary>
        /// <param name="g"></param>
        /// <param name="vectorRect">承载文字的区域</param>
        protected virtual void DrawText(Graphics g, Brush brush, RectangleF vectorRect)
        {
            SizeF textSize = this.CalcuteTextPixelSize(g);
            Single offsetX = (vectorRect.Width - textSize.Width) / 2.0F;
            Single offsetY = (vectorRect.Height - textSize.Height) / 2.0F;
            this.DrawText(g, brush, this.Text, this.Font, offsetX, offsetY);
        }
        /// <summary>
        /// 使用指定字体、笔刷、文本对齐格式在指定范围内绘制指定文本
        /// </summary>
        protected virtual void DrawText(Graphics g, String text, Font font, Brush brush, RectangleF vectorRect, StringFormat format)
        {
            g.DrawString(text, font, brush, vectorRect, format);
        }
        protected override void OnParentBackColorChanged(EventArgs e)
        {
            //让容器背景跟随父容器的背景颜色变化
            if (this.Parent != null && this.FollowParentBackColor)
            {
                this.BackColor = this.Parent.BackColor;
            }
            base.OnParentBackColorChanged(e);
        }
        protected virtual void ReleaseBrush(params Brush[] brushs)
        {
            foreach (Brush brush in brushs)
            {
                brush.Dispose();
            }
        }
        protected virtual void SendMessageToParent(Int32 msg, Int32 wParam = 0, Int32 lParam = 0)
        {
            if (this.Parent != null)
            {
                Win32API.SendMessage(this.Parent.Handle, msg, wParam, lParam);
            }
        }
        protected override void WndProc(ref Message m)
        {
            if (!this.DesignMode && this.EnabledMousePierce)
            {
                switch (m.Msg)
                {
                    case Win32Constants.WM_MOUSEACTIVATE:
                    case Win32Constants.WM_MOUSEFIRST:
                    case Win32Constants.WM_MOUSEHOVER:
                    case Win32Constants.WM_MOUSELAST:
                    case Win32Constants.WM_MOUSELEAVE:
                    case Win32Constants.WM_LBUTTONDOWN:
                    case Win32Constants.WM_LBUTTONUP:
                    case Win32Constants.WM_LBUTTONDBLCLK:
                    case Win32Constants.WM_RBUTTONDOWN:
                    case Win32Constants.WM_RBUTTONUP:
                    case Win32Constants.WM_RBUTTONDBLCLK:
                    case Win32Constants.WM_MBUTTONDOWN:
                    case Win32Constants.WM_MBUTTONUP:
                    case Win32Constants.WM_MBUTTONDBLCLK:
                    case Win32Constants.WM_NCHITTEST:
                        {
                            //将返回值置为 -1 表示交由父控件处理
                            m.Result = (IntPtr)(-1);
                        }
                        break;
                    default:
                        {
                            base.WndProc(ref m);
                        }
                        break;
                }
            }
            else
            {
                base.WndProc(ref m);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace Concision.Controls
{
    public class Panel : System.Windows.Forms.Panel
    {
        /// <summary>
        /// 边框的样式
        /// </summary>
        [Description("边框的样式")]
        public new ButtonBorderStyle BorderStyle { get; set; } = ButtonBorderStyle.Solid;
        /// <summary>
        ///自定义边框的颜色
        /// </summary>
        [Description("边框的颜色")]
        public Color BorderColor { get; set; } = Color.Gray;

        [Description("边框的宽度")]
        public Int32 BorderWith { get; set; } = 1;

        [Description("鼠标穿透")]
        public Boolean EnabledMousePierce { get; set; } = false;
        /// <summary>
        /// 是否绘制边框
        /// </summary>
        public Boolean IsDrawBorder { get; set; } = false;

        public Panel() : base()
        {
            this.DoubleBuffered = true;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.IsDrawBorder)
            {
                ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, this.BorderColor, this.BorderWith,
                                           this.BorderStyle, this.BorderColor, this.BorderWith,
                                           this.BorderStyle, this.BorderColor, this.BorderWith,
                                           this.BorderStyle, this.BorderColor, this.BorderWith,
                                           this.BorderStyle);

            }
            base.OnPaint(e);
        }
        protected override void OnScroll(ScrollEventArgs se)
        {
            base.OnScroll(se);
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

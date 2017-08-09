using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace Concision.Control
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
                    case WindowsConstants.WM_MOUSEACTIVATE:
                    case WindowsConstants.WM_MOUSEFIRST:
                    case WindowsConstants.WM_MOUSEHOVER:
                    case WindowsConstants.WM_MOUSELAST:
                    case WindowsConstants.WM_MOUSELEAVE:
                    case WindowsConstants.WM_LBUTTONDOWN:
                    case WindowsConstants.WM_LBUTTONUP:
                    case WindowsConstants.WM_LBUTTONDBLCLK:
                    case WindowsConstants.WM_RBUTTONDOWN:
                    case WindowsConstants.WM_RBUTTONUP:
                    case WindowsConstants.WM_RBUTTONDBLCLK:
                    case WindowsConstants.WM_MBUTTONDOWN:
                    case WindowsConstants.WM_MBUTTONUP:
                    case WindowsConstants.WM_MBUTTONDBLCLK:
                    case WindowsConstants.WM_NCHITTEST:
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

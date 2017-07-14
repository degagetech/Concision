using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Concision.Control
{

    public class Line : BaseControl
    {
        /// <summary>
        /// 是否是竖直的
        /// </summary>
        [Description("是否竖直")]
        public Boolean IsVertical
        {
            get
            {
                return this._isVertical;
            }
            set
            {
                this._isVertical = value;
                this.AdaptingSize();
            }
        }
        /// <summary>
        /// 线的长度
        /// </summary>
        [Description("线的长度")]
        public Int32 LineLength
        {
            get
            {
                return this._lineLength;
            }
            set
            {
                this._lineLength = value;
                this.AdaptingSize();

            }
        }
        /// <summary>
        /// 线的颜色
        /// </summary>
        [Description("线的颜色")]
        public Color LineColor
        {
            get
            {
                return this._lineColor;
            }
            set
            {
                this._lineColor = value;
                this.Invalidate();
            }
        }
        /// <summary>
        ///线的宽度，单位 px。
        /// </summary>
        [Description("线的宽度，单位 px。")]
        public Int32 LineWidth
        {
            get
            {
                return this._lineWidth;
            }
            set
            {
                this._lineWidth = value;
                this.AdaptingSize();
            }
        }
        /// <summary>
        /// 自定义画线的画刷，设置此参数后，画线时使用此画刷。
        /// </summary>
        [Browsable(false)]
        [Description("用于画线的画刷")]
        public Brush CustomBursh
        {
            get
            {
                return this._customBrush;
            }
            set
            {
                if (value != null)
                {
                    this._customBrush = value;
                }
            }
        }

        /********************************/
        public Line()
        {
            this.AdaptingSize();
        }
        protected override void OnResize(EventArgs e)
        {
            this._lineWidth =this.IsVertical ? this.Width : this.Height;
            this._lineLength = this.IsVertical ? this.Height : this.Width;
            this.Invalidate();
            base.OnResize(e);
        }
        private void AdaptingSize()
        {
            Size size= new Size(this.IsVertical ? this._lineWidth : this._lineLength, this.IsVertical ? this._lineLength : this._lineWidth);
            if (size != this.Size)
            {
                this.Size = size;
            }
            this.Invalidate();
        }

        private Color _lineColor = Color.FromArgb(255, 175, 175, 175);
        private Brush _customBrush;
        private Int32 _lineLength = 100;
        private Int32 _lineWidth = 6;
        private Boolean _isVertical = false;


        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;

            Brush brush = this._customBrush != null ? this._customBrush : new SolidBrush(this._lineColor);

            g.FillRectangle(brush, this.ClientRectangle);
            //g.DrawLine(pen, 0, 0,
            //    this.IsVertical ? 0 : 0 + this._lineLength,
            //      this.IsVertical ? 0 + this._lineLength : 0
            //    );

            base.OnPaint(e);
        }

    }
}

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
    public class Button : BaseControl
    {
        /// <summary>
        /// 按钮处于等待状态时是否触发点击事件
        /// </summary>
        [Description("按钮处于等待状态时是否触发点击事件")]
        public Boolean EnabledWaitingClick { get; set; } = false;
        /// <summary>
        /// 是否处于等待状态
        /// </summary>
        [TextDescription("is_waiting")]
        public Boolean IsWaiting
        {
            get
            {
                return this._waitIndicator.IsRolled;
            }
            set
            {
                this._waitIndicator.Visible = value;
                this._waitIndicator.IsRolled = value;
            }
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public new Color BackColor { get; set; }
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }

            set
            {
                base.ForeColor = value;
                this._waitIndicator.WaitIndicatorColor = value;
            }
        }


        /// <summary>
        /// 按钮正常时的颜色
        /// </summary>
        [Description("按钮正常时的颜色")]
        public Color NormalColor
        {
            get
            {
                return this._normalColor;
            }
            set
            {
                if (this._normalColor != value)
                {
                    this._normalColor = value;
                    this._currentColor = value;
                    this.Invalidate();
                }
            }
        }
        /// <summary>
        /// 指针悬浮时按钮的颜色
        /// </summary>
        [Description("指针悬浮时按钮的颜色")]
        public Color HoverColor { get; set; } = Color.FromArgb(70, 200, 250);
        /// <summary>
        /// 按钮被点击时的颜色
        /// </summary>
        [Description("按钮被点击时的颜色")]
        public Color DownColor { get; set; } = Color.FromArgb(175, 175, 175);

        /// <summary>
        /// 此按钮的等待指示器
        /// </summary>
        [Description("此按钮的等待指示器")]
        public WaitIndicator WaitIndicator
        {
            get
            {
                return this._waitIndicator;
            }
        }
        /***********************/
        private Color _normalColor = Color.FromArgb(27, 166, 228);
        private Color _currentColor = Color.FromArgb(27, 166, 228);
        private Color _shadowColor = Color.FromArgb(150, 175, 175, 175);
        private Single _shadowWidth = 1;
        private WaitIndicator _waitIndicator = new WaitIndicator();
        public Button() : base()
        {
            this.Cursor = Cursors.Hand;
            this.ForeColor = Color.White;
            this._waitIndicator.Visible = false;
            this._waitIndicator.IsFollowParentBackColor = false;
            this._waitIndicator.EnabledMousePierce = true;
            this._waitIndicator.RollPartWidthPercent = 20;
            this._waitIndicator.RollPartLengthPercent = 50;
            this.Controls.Add(this._waitIndicator);

        }

        protected override void OnResize(EventArgs e)
        {
            this._waitIndicator.Size = new Size((this.Height * 0.4).RoundToInt32(), (this.Height * 0.4).RoundToInt32());
            this._waitIndicator.Location = new Point((Int32)(this.Width * 0.15), (this.Height - this._waitIndicator.Height) / 2);
            base.OnResize(e);
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {

            Graphics g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            this._waitIndicator.BackColor = this._currentColor;
            this._waitIndicator.InnerColor = this._currentColor;

            SizeF buttonSzie = new SizeF(this.Width - this._shadowWidth, this.Height - this._shadowWidth);
            Brush nrlBrush = new SolidBrush(this._currentColor);
            Brush shadowBrush = new SolidBrush(this._shadowColor);
            RectangleF buttonRect = new RectangleF(new PointF(0, 0), buttonSzie);
            RectangleF shadowRect = new RectangleF(new PointF(this._shadowWidth, this._shadowWidth), buttonSzie);
            SizeF textSize = g.MeasureString(this.Text, this.Font);
            Brush textBrush = new SolidBrush(this.ForeColor);

            g.FillRectangle(shadowBrush, shadowRect);
            g.FillRectangle(nrlBrush, buttonRect);


            this.DrawText(g, textBrush, buttonRect);
            //释放笔刷资源
            this.ReleaseBrush(nrlBrush, shadowBrush, textBrush);
            base.OnPaint(pevent);
        }



        protected override void OnMouseEnter(EventArgs e)
        {
            this._currentColor = this.HoverColor;
            this.Invalidate();
            base.OnMouseEnter(e);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            this._currentColor = this.NormalColor;
            this.Invalidate();
            base.OnMouseLeave(e);
        }
        protected override void OnClick(EventArgs e)
        {
            if (!this.IsWaiting || this.EnabledWaitingClick)
            {
                base.OnClick(e);
            }
        }
        protected override void OnMouseDown(MouseEventArgs mevent)
        {

            this._currentColor = this.DownColor;
            //     this._waitIndicator.WaitIndicatorColor = this.NormalColor;
            this.Invalidate();
            base.OnMouseDown(mevent);

        }
        protected override void OnMouseUp(MouseEventArgs mevent)
        {

            this._currentColor = this.HoverColor;
            //  this._waitIndicator.WaitIndicatorColor = this.DownColor;
            this.Invalidate();
            base.OnMouseUp(mevent);

        }

    }
}

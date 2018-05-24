using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Timers;
using Timer = System.Timers.Timer;
namespace Concision.Controls
{
    /// <summary>
    /// 滚动部分的笔刷类型
    /// </summary>
    public enum RollPartBrushType
    {
        /// <summary>
        /// 纯色
        /// </summary>
        Solid,
        Hatch
    }
    /// <summary>
    /// 等待指示器
    /// </summary>
    public class WaitIndicator : BaseControl
    {
        /// <summary>
        /// 当使用RollPartBrushType使用Hatch时此属性生效
        /// </summary>
        [Description("当使用RollPartBrushType使用Hatch时此属性生效")]
        public HatchStyle HatchBrushStyle { get; set; } = HatchStyle.DarkHorizontal;
        /// <summary>
        /// 等待指示器内部的颜色
        /// </summary>
        [Description("等待指示器内部的颜色")]
        public Color InnerColor { get; set; }
        /// <summary>
        /// 是否让指示器内部颜色跟随父容器背景色变化
        /// </summary>
        [Description("是否让指示器内部颜色跟随父容器背景色变化")]
        public Boolean IsFollowParentBackColor { get; set; } = true;
        /// <summary>
        /// 滚动部分绘制时的笔刷类型
        /// </summary>
        [Description("滚动部分绘制时的笔刷类型")]
        public RollPartBrushType RollPartBrushType { get; set; } = RollPartBrushType.Solid;

        [DefaultValue(false)]
        [Description("开启或关闭滚动")]
        public Boolean IsRolled
        {
            get
            {
                return this._timer.Enabled;
            }
            set
            {
                if (value)
                {
                    this._timer.Start();
                }
                else
                {
                    this._timer.Stop();
                }
            }
        }


        [Description("滚动的间隔（单位：毫秒）")]
        public Double RollingSpeed
        {
            get
            {
                return this._timer.Interval;
            }
            set
            {
                if (value > 0)
                {
                    this._timer.Interval = value;
                }
            }
        }

        [Description("滚动部分的宽度占控件宽度的百分比")]
        public Single RollPartWidthPercent
        {
            get
            {
                return this._rollPartWidthPercent;
            }
            set
            {
                if (value > 0 && value <= 60)
                {
                    this._rollPartWidthPercent = value;
                    this.LoadDrawRect(true);
                    this.Invalidate();
                }
            }
        }

        [Description("每次滚动的角度值")]
        public Single EachRollingAngle { get; set; } = 15;

        [Description("滚动部分的长度占总周长的百分比")]
        public Single RollPartLengthPercent
        {
            get
            {
                return this._rollPartLengthPercent;
            }
            set
            {
                if (value > 0 && value < 85)
                {
                    this._rollPartLengthPercent = value;
                    this.Invalidate();
                }
            }
        }

        [Description("等待指示器的颜色")]
        public Color WaitIndicatorColor { get; set; } = Color.FromArgb(175, 175, 175);

        public Single CurrentAngle
        {
            get
            {
                return this._currentAngle;
            }
            set
            {
                this._currentAngle = value;
            }
        }

        /**************************/
        private Timer _timer = new Timer();
        /// <summary>
        /// 当前的角度
        /// </summary>
        private Single _currentAngle;
        private Single _rollPartLengthPercent = 40;
        private Single _rollPartWidthPercent = 10;
        private RectangleF _outSideCircleRect;
        private RectangleF _innserCircleRect;
        /***************************/
        public WaitIndicator() : base()
        {
            this.DoubleBuffered = true;
            this._timer = new Timer(60.0);
            this._timer.Elapsed += _timer_Elapsed;
            this.InnerColor = this.BackColor;
            this.LoadDrawRect();
        }

        private void _timer_Elapsed(Object sender, ElapsedEventArgs e)
        {
            this.LoadCurrentAngle();
        }
        protected override void OnResize(EventArgs e)
        {
            this.LoadDrawRect(true);
            base.OnResize(e);
        }
        protected void LoadCurrentAngle()
        {
            this._currentAngle += this.EachRollingAngle;
            if (this._currentAngle > 360)
            {
                this._currentAngle = this._currentAngle % 360;
            }
            this.Invalidate();
        }
        private void LoadDrawRect(Boolean force = false)
        {
            if (force || this._outSideCircleRect == RectangleF.Empty || this._innserCircleRect == RectangleF.Empty)
            {
                Single annulusWidth = this.Width - 1;
                Single annulusHeight = this.Height - 1;
                //外圆区域
                RectangleF outsideCircleRect = new RectangleF(0, 0, annulusWidth, annulusHeight);

                Single innerCircleSziePercent = (100 - this._rollPartWidthPercent) / 100f;

                //计算内圆的大小与位置
                SizeF innerCircleSzie = new SizeF(annulusWidth * innerCircleSziePercent, annulusHeight * innerCircleSziePercent);
                PointF innerCircleLocation = new PointF((outsideCircleRect.X + outsideCircleRect.Width - innerCircleSzie.Width) / 2, (outsideCircleRect.Y + outsideCircleRect.Height - innerCircleSzie.Height) / 2);

                //内圆区域
                RectangleF innerCircleRect = new RectangleF(innerCircleLocation, innerCircleSzie);


                this._outSideCircleRect = outsideCircleRect;
                this._innserCircleRect = innerCircleRect;
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            this.LoadDrawRect();

            Brush annulusBrush = new SolidBrush(this.WaitIndicatorColor);
            Brush innerCircleBrush = new SolidBrush(this.InnerColor);

            //计算滚动部分的起始角度与结束角度
            Single beginAngle = this._currentAngle;
            Single endAngle = this._rollPartLengthPercent * 360F / 100F;

            switch (this.RollPartBrushType)
            {
                case RollPartBrushType.Hatch:
                    {
                        annulusBrush.Dispose();
                        annulusBrush = null;
                        annulusBrush = new HatchBrush(this.HatchBrushStyle, this.WaitIndicatorColor);
                    }
                    break;
                case RollPartBrushType.Solid:
                default:
                    {
                    }
                    break;
            }
            g.FillPie(annulusBrush,
                             this._outSideCircleRect.X, this._outSideCircleRect.Y,
                             this._outSideCircleRect.Width, this._outSideCircleRect.Height,
                         beginAngle, endAngle);
            g.FillEllipse(innerCircleBrush,
            this._innserCircleRect.X, this._innserCircleRect.Y,
            this._innserCircleRect.Width, this._innserCircleRect.Height);

            this.ReleaseBrush(annulusBrush, innerCircleBrush);
            base.OnPaint(e);
        }
        protected override void OnBackColorChanged(EventArgs e)
        {
            if (this.IsFollowParentBackColor && this.Parent!=null)
            {
                this.InnerColor = this.Parent.BackColor;
            }
            base.OnBackColorChanged(e);
        }
        protected override void Dispose(Boolean disposing)
        {
            this._timer.Dispose();
            base.Dispose(disposing);
        }
    }
}

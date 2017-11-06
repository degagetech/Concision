using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using Concision.Editor;
namespace Concision.Control
{



    public class Symbol : BaseControl
    {

        [Description(" 图标的大小,以磅值为单位")]
        public Single SymbolSize
        {
            get
            {
                return this.Font.Size;
            }
            set
            {
                this.Font = new Font(AwesomeFont.FontFamily, value);
                this.Invalidate();
            }
        }
        [Description(" 图标的颜色")]
        public Color SymbolColor
        {
            get
            {
                return this.ForeColor;
            }
            set
            {
                this.ForeColor = value;
                this.Invalidate();
            }
        }

        [Editor(typeof(SymbolEditor), typeof(UITypeEditor))]
        [Description("图标的样式")]
        public String SymbolPattern
        {
            get
            {
                return this._symbolPattern;
            }
            set
            {
                this._symbolPattern = value;
                this.Invalidate();
            }
        }
        private String _symbolPattern = AwesomeFont.user;

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Font Font
        {
            get => base.Font;
            set
            {
                base.Font = value;
            }
        }


        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override String Text
        {
            get => base.Text;
            set
            {
                base.Text = value;
            }
        }

        [Browsable(false)]
        public override Color ForeColor
        {
            get => base.ForeColor;
            set
            {
                base.ForeColor = value;
            }
        }

        public Symbol()
        {
            this.Font = new Font(AwesomeFont.FontFamily, 15);
            this.DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            if (!String.IsNullOrEmpty(this.SymbolPattern))
            {
                Graphics g = pevent.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.CompositingQuality = CompositingQuality.HighQuality;
                Brush textBrush = new SolidBrush(this.ForeColor);
                RectangleF rect = new RectangleF(new PointF(0, 0), this.Size);
                //SizeF patternSize = g.MeasureString(this.SymbolPattern, this.Font);
                //PointF point = new PointF((rect.Width - patternSize.Width) / 2, (rect.Height - patternSize.Height) / 2);
                this.DrawText(g, this.SymbolPattern, this.Font, textBrush, rect, this.TextAlignFormat);
                //释放笔刷资源
                this.ReleaseBrush(textBrush);
            }
            base.OnPaint(pevent);
        }


    }
}

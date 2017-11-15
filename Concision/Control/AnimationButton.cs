using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Concision.Controls
{
    public class AnimationButton : BaseControl
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public new Color BackColor { get; set; }
        public Color NormalColor { get; set; }
        public Color HoverColor { get; set; }
        public Color PressColor { get; set; }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
        }
    }
}

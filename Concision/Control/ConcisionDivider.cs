using System.ComponentModel;
using System.Windows.Forms;

namespace Concision.Controls
{
    public sealed class ConcisionDivider : System.Windows.Forms.Control, IConcisionControl
    {
        [Browsable(false)]
        public int Depth { get; set; }
        [Browsable(false)]
        public ConcisionManager SkinManager => ConcisionManager.Instance;
        [Browsable(false)]
        public MouseState MouseState { get; set; }

        public ConcisionDivider()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            Height = 1;
            BackColor = SkinManager.GetDividersColor();
        }
    }
}

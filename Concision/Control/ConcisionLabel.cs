using System.ComponentModel;
using System.Windows.Forms;

namespace Concision.Controls
{
    public class ConcisionLabel : System.Windows.Forms.Label, IConcisionControl
    {
        [Browsable(false)]
        public int Depth { get; set; }
        [Browsable(false)]
        public ConcisionManager SkinManager => ConcisionManager.Instance;
        [Browsable(false)]
        public MouseState MouseState { get; set; }
        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            ForeColor = SkinManager.GetPrimaryTextColor();
            Font = SkinManager.FontOfRegular11;

            BackColorChanged += (sender, args) => ForeColor = SkinManager.GetPrimaryTextColor();
        }
    }
}

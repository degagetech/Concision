using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
namespace Concision
{
    public static class AnimationExecutor
    {
        public static void DrawAnimation(this System.Windows.Forms.Control control, Func<Boolean> doEffect, Int32 interval = 10)
        {
            Action action = () =>
              {
                  Timer effectTimer = new Timer();
                  effectTimer.Interval = interval;
                  effectTimer.Tick += (s,e) =>
                    {
                        Timer timer = s as Timer;
                        timer.Enabled = false;
                        try
                        {
                            if (doEffect != null && doEffect())
                            {
                                control.Invalidate();
                                timer.Enabled = true;
                            }
                            else
                            {
                                timer.Dispose();
                            }
                        }
                        catch
                        {
                            timer.Dispose();
                        }
                    };
              };
            control.Invoke(action);
        }
    }
}

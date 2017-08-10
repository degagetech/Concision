using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
namespace Concision
{
    public static class AnimationExecutor
    {
        /// <summary>
        /// 使得控件做一些动画效果
        /// </summary>
        /// <param name="doEffect">实现动画效果的函数，当此函数返回false时动画效果触发停止</param>
        /// <param name="interval">动画帧触发间隔</param>
        public static void DoAnimation(this System.Windows.Forms.Control control, Func<Boolean> doEffect, Int32 interval = 10)
        {
            Action action = () =>
              {
                  Timer effectTimer = new Timer();
                  effectTimer.Interval = interval;
                  effectTimer.Tick += (s, e) =>
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
                  effectTimer.Start();
              };
            control.Invoke(action);
        }
    }
}

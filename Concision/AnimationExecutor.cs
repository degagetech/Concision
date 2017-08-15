using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        public static void DoAnimation(this System.Windows.Forms.Control control, Func<Boolean> doEffect, Int32 interval = 55)
        {
            if (doEffect == null) return;
            Action action = () =>
              {
                  System.Windows.Forms.Timer effectTimer = new System.Windows.Forms.Timer();
                  Int32 mutex = 0;
                  effectTimer.Interval = interval;
                  effectTimer.Tick += (s, e) =>
                    {
                        if (0==mutex)
                        {
                            Interlocked.Exchange(ref mutex,1);
                            try
                            {
                                if (doEffect())
                                {
                                    control.Invalidate();
                                }
                                else effectTimer.Enabled = false;
                            }
                            catch
                            {
                                effectTimer.Enabled = false;
                            }
                            Interlocked.Exchange(ref mutex, 0);
                        }
                    };
                  effectTimer.Start();
              };
            control.Invoke(action);
        }
    }
}

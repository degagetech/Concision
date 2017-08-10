using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
namespace Concision
{
    public class WindowsApi
    {
        [DllImport("user32.dll",CharSet =CharSet.Auto)]
        public static extern Int32 SendMessage(IntPtr hWnd, Int32 wMsg,
         Int32 wParam, [MarshalAs(UnmanagedType.LPWStr)] String lParam);

        [DllImport("user32.dll")]
        public static extern Boolean SendMessage(IntPtr hwnd, int msg, int wParam, StringBuilder lParam);

        [DllImport("user32.dll")]
        public static extern Int32 SendMessage(IntPtr hwnd, Int32 wMsg, Int32 wParam, Int32 lParam);

        [DllImport("user32.dll")]
        public static extern Boolean GetComboBoxInfo(IntPtr hwnd, ref COMBOBOXINFO pcbi);

        /// <summary>
        /// 该函数能在显示与隐藏窗口时能产生特殊的效果。
        /// </summary>
        /// <param name="handle">指定产生动画的窗口的句柄。</param>
        /// <param name="dwTime">指明动画持续的时间（以微秒计），完成一个动画的标准时间为200微秒。</param>
        /// <param name="dwFags">指定动画类型。这个参数可以是一个或多个下列标志的组合。标志描述：</param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "AnimateWindow")]
        public static extern Boolean AnimateWindow(IntPtr handle, Int32 dwTime, Int32 dwFags);

        [DllImport("user32.dll", EntryPoint = "GetScrollInfo")]
        public static extern Boolean GetScrollInfo(IntPtr hwnd, Int32 fnBar,ref SCROLLINFO lpsi);
    }
}

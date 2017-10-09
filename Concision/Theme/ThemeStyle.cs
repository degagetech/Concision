using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace Concision
{
    /// <summary>
    /// 主题风格，包含一系列字体，颜色等数据，控件根据主题绘制自身以控制界面的风格的统一
    /// </summary>
    public class ThemeStyle
    {
        /// <summary>
        /// 默认字体
        /// </summary>
        public Font Font { get; set; } = new Font("微软雅黑",9);
        /// <summary>
        /// 前景色（字体颜色）
        /// </summary>
        public Color Forecolor { get; set; } = Color.Black;
        /// <summary>
        /// 背景色
        /// </summary>
        public Color BackColor { get; set; } = Color.FromArgb(240,240,240);
        /// <summary>
        /// 阴影颜色
        /// </summary>
        public Color ShadowColor { get; set; }
    }
}

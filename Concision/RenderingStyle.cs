using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;

namespace Concision
{
    /// <summary>
    /// 渲染风格，包含一系列字体，颜色等数据
    /// </summary>
    public class RenderingStyle
    {
        /// <summary>
        /// 字体
        /// </summary>
        [Description("字体")]
        public Font Font { get; set; } = new Font("微软雅黑", 9);
        /// <summary>
        /// 正常状态的前景色
        /// </summary>
        [Description("正常状态的前景色")]
        public Color ForeColor { get; set; } = Color.Black;
        /// <summary>
        /// 鼠标悬浮时的前景色
        /// </summary>
        [Description("鼠标悬浮时的前景色")]
        public Color HoverForeColor { get; set; }
        /// <summary>
        /// 选中状态的前景色
        /// </summary>
        public Color SelectionForeColor { get; set; }

        /// <summary>
        /// 正常状态的背景色
        /// </summary>
        public Color BackColor { get; set; } = Color.FromArgb(240, 240, 240);
        /// <summary>
        /// 悬浮状态的背景色
        /// </summary>
        public Color HoverBackColor { get; set; }
        /// <summary>
        /// 选中状态的背景色
        /// </summary>
        public Color SelectionBackColor { get; set; }


        /// <summary>
        /// 圆角半径
        /// </summary>
        public Single Radius { get; set; }
        /// <summary>
        /// 阴影颜色
        /// </summary>
        public Color ShadowColor { get; set; }
        /// <summary>
        /// 阴影宽度
        /// </summary>
        public Int32 ShadowWidth { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace Concision
{
    /// <summary>
    /// 渲染帮助器，提供一系列渲染的辅助函数
    /// </summary>
    public sealed class RenderingAssistor
    {
        /// <summary>
        /// 根据指定的矩形计算带有指定半径的圆角的矩形路径
        /// </summary>
        /// <param name="rect">需计算的矩形信息</param>
        /// <param name="radius">圆角半径</param>
        /// <returns>带有圆角的矩形路径</returns>
        public static GraphicsPath RoundedPath(RectangleF rect,Single radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X + radius, rect.Y + radius, radius, radius, 180, 90);
            path.AddArc(rect.X + rect.Width - radius, rect.Y + radius, radius, radius, 270, 90);
            path.AddArc(rect.X + rect.Width - radius, rect.Y + rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X + radius, rect.Y + rect.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}

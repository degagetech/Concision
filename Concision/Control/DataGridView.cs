using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Concision.Control
{
    public class DataGridView : System.Windows.Forms.DataGridView
    {
        /// <summary>
        /// 绘制列标题单元格时发生
        /// </summary>
        [Description("绘制列标题单元格时发生")]
        public event DataGridViewCellPaintingEventHandler ColumnHeaderCellPainting;
        /// <summary>
        /// 绘制行标题单元格时发生
        /// </summary>
        [Description("绘制行标题单元格时发生")]
        public event DataGridViewCellPaintingEventHandler RowHeaderCellPainting;
        public DataGridView() : base()
        {
            this.DoubleBuffered = true;
            //   this.onhea
        }
        protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
        {
            if (-1 == e.RowIndex)
            {
                this.OnColumnHeaderCellPainting(e);
            }
            if (-1 == e.ColumnIndex)
            {
                this.OnRowHeaderCellPainting(e);
            }
            base.OnCellPainting(e);
        }
        /// <summary>
        /// 列标题单元格绘制
        /// </summary>
        protected virtual void OnColumnHeaderCellPainting(DataGridViewCellPaintingEventArgs e)
        {
            if (!this.EnableHeadersVisualStyles)
            {
                this.ColumnHeaderCellPainting?.Invoke(this, e);
            }
        }
        /// <summary>
        /// 行标题单元格绘制
        /// </summary>
        protected virtual void OnRowHeaderCellPainting(DataGridViewCellPaintingEventArgs e)
        {
            if (!this.EnableHeadersVisualStyles)
            {
                this.RowHeaderCellPainting?.Invoke(this, e);
            }
        }
    }
}

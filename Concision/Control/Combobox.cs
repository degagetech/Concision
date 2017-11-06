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
    public class Combobox : Button
    {
        /// <summary>
        /// 当选择的下拉项发生改变后
        /// </summary>
        [Description("当选择的下拉项发生改变后")]
        public event Action<Object, ComboboxToolStripItem> SelectItemChanged;


        /// <summary>
        /// 获取或设置Item的字体
        /// </summary>
        public Font ItemFont { get; set; }
        /// <summary>
        /// 当前下拉项的计数
        /// </summary>
        public Int32 ItemCount
        {
            get
            {
                return this._toolStripDropDown.Items.Count;
            }
        }
        /// <summary>
        /// 获取当前选中的项
        /// </summary>
        [Browsable(false)]
        public ComboboxToolStripItem SelectedItem { get; private set; }
        /// <summary>
        /// 获取当前选中项的索引，或将当前项设置为具有指定索引的项
        /// </summary>
        [Browsable(true)]
        public Int32 SelectedIndex
        {
            get
            {
                if (this.SelectedItem != null)
                {
                    return this.SelectedItem.Index;
                }
                return -1;
            }
            set
            {
                if (this.ItemCount > 0 && value >= 0 && value < this.ItemCount)
                {
                    ComboboxToolStripItem item = (ComboboxToolStripItem)this._toolStripDropDown.Items[value];
                    this.OnSelectItemChanged(this, item);
                }
            }
        }
        /// <summary>
        /// 获取当前选中项的文本或将当前项设置为具有指定文本的项
        /// </summary>
        [Description("获取当前选中项的文本")]
        [Browsable(true)]
        public String SelectedText
        {
            get
            {
                return this.SelectedItem?.Text;
            }
            set
            {
                if (this.ItemCount > 0 && !String.IsNullOrEmpty(value))
                {
                    foreach (ComboboxToolStripItem item in this._toolStripDropDown.Items)
                    {
                        if (item.Text == value)
                        {
                            this.OnSelectItemChanged(this, item);
                            break;
                        }
                    }
                }

            }
        }
        /// <summary>
        /// 获取当前选中项包含的至
        /// </summary>
        [Browsable(false)]
        public Object SelectedValue
        {
            get
            {
                return this.SelectedItem?.Value;
            }
        }
        /// <summary>
        /// 是否根据条目数量自动调整下拉框的高度
        /// </summary>
        public Boolean AutoDropDownHeight
        {
            get
            {
                return this._autoDropDownHeight;
            }
            set
            {
                this._autoDropDownHeight = value;
                if (value)
                {
                    this.RecalcuteDropDownHeight();
                }
            }
        }

        /// <summary>
        /// 设置下拉框的宽度
        /// </summary>
        public Int32 DropDownWidth
        {
            get
            {
                return this._toolStripDropDown.Width;
            }
            set
            {
                this._toolStripDropDown.Width = value;
            }
        }
        public Int32 DropDownHeight
        {
            get
            {
                return this._toolStripDropDown.Height;
            }
            set
            {
                if (!this.AutoDropDownHeight)
                {
                    this._toolStripDropDown.Height = value;
                }
            }
        }
        /// <summary>
        /// 是否已显示下拉框
        /// </summary>
        public Boolean DropDownShown { get; private set; }
        /// <summary>
        /// 获取或设置下拉条目的高度
        /// </summary>
        public Int32 ItemHeight { get; set; } = 30;

        public ToolStripItemCollection Items
        {
            get
            {
                return this._toolStripDropDown.Items;
            }
        }

        public override Font Font
        {
            get
            {
                return base.Font;
            }

            set
            {
                base.Font = value;
                if (this.Font.FontFamily != value.FontFamily)
                {
                    Graphics g = this.CreateGraphics();
                    this.CalcuteSymbolSize(g, true);
                    g.Dispose();
                }
            }
        }
        /// <summary>
        /// 下拉图标的颜色
        /// </summary>
        public Color SymbolColor { get; set; } = Color.FromArgb(175, 175, 175);
        /// <summary>
        /// 下拉图标的大小
        /// </summary>
        public Single SymbolSize
        {
            get
            {
                return this._symbolSize;
            }
            set
            {
                if (this._symbolSize != value)
                {
                    this._symbolSize = value;
                    Graphics g = this.CreateGraphics();
                    this.CalcuteSymbolSize(g, true);
                    g.Dispose();
                }
            }
        }
        /********************************/

        private ToolStripDropDown _toolStripDropDown = new ToolStripDropDown();
        private Int32 _heightExtra = 5;
        private const String SymbolDown = "▼";
        private SizeF _symbolSizeCache = SizeF.Empty;
        private Single _symbolSize = 10F;
        private Boolean _autoDropDownHeight = true;
        /********************************/
        public Combobox() : base()
        {
            this._toolStripDropDown.AutoSize = false;
            this._toolStripDropDown.ItemAdded += this.ToolStripDropDown_ItemAdded;
            this._toolStripDropDown.ItemRemoved += this.ToolStripDropDown_ItemRemoved;
            this.Size = new Size(250, 35);
            this.DropDownWidth = 250;

            this._toolStripDropDown.Height = 0;
            this.Font = new Font("微软雅黑", 10.5F);
            this.ItemFont = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
            this.NormalColor = Color.WhiteSmoke;
            this.BackColor = this.NormalColor;
            this.ForeColor = Color.FromArgb(90, 90, 90);
        }
        protected override void OnResize(EventArgs e)
        {
            if (this._toolStripDropDown.Width < this.Width)
            {
                this._toolStripDropDown.Width = this.Width;
            }
            base.OnResize(e);
        }
        /// <summary>
        /// 重新计算 DropDown 的高度，在将 <see cref="AutoDropDownHeight"/>  属性false设置为自动后，高度应该从固定值变回为根据Item项适应的高度
        /// </summary>
        private void RecalcuteDropDownHeight()
        {
            Int32 height = 0;
            this.DropDownHeight = 0;
            foreach (ComboboxToolStripItem item in this._toolStripDropDown.Items)
            {
                height = item.Height + this._heightExtra;
            }
            this.DropDownHeight = height;
        }
        /// <summary>
        /// 向下拉框添加具有指定文本，值，名称的Item
        /// </summary>
        public void Add(String text, Object value = null, String name = null)
        {
            ComboboxToolStripItem item = new ComboboxToolStripItem();
            item.Padding = new Padding();
            item.Text = text;
         
            item.Size = new Size(this._toolStripDropDown.Width, this.ItemHeight);
            item.AutoSize = false;
            item.Value = value;
            item.Name = name ?? Guid.NewGuid().ToString("N");
            item.Font = this.ItemFont;
            item.Size = new Size(this._toolStripDropDown.Width, this.ItemHeight);
            item.Index = this._toolStripDropDown.Items.Count - 1;
            item.TextAlignFormat = this.TextAlignFormat;
            item.Click += (s, e) =>
            {
                this.OnSelectItemChanged(this, item);
            };
            this._toolStripDropDown.Items.Add(item);
        }
        public void AddRange(IEnumerable<String> texts)
        {
            foreach (String text in texts)
            {
                this.Add(text);
            }
        }
        public void AddRange(IEnumerable<Tuple<String, Object, String>> items)
        {
            foreach (var item in items)
            {
                this.Add(item.Item1, item.Item2);
            }
        }
        protected virtual void OnSelectItemChanged(Object sender, ComboboxToolStripItem item)
        {
            this.SelectedItem = item;
            this.Text = this.SelectedItem.Text;
            this.SelectItemChanged?.Invoke(sender, item);
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics g = pevent.Graphics;
            SizeF size = this.CalcuteSymbolSize(g);
            Brush brush = new SolidBrush(this.SymbolColor);
            base.OnPaint(pevent);
            g.DrawString(SymbolDown, new Font(this.Font.FontFamily, this._symbolSize), brush, this.Width - size.Width.RoundToInt32() - (0.05 * this.Width).RoundToInt32(), ((this.Height - size.Height) / 2.0F).RoundToInt32());
            brush.Dispose();
            g.Dispose();
        }
        protected SizeF CalcuteSymbolSize(Graphics g, Boolean force = false)
        {
            if (this._symbolSizeCache == SizeF.Empty || force)
            {
                this._symbolSizeCache = g.MeasureString(SymbolDown, new Font(this.Font.FontFamily, this._symbolSize));
            }
            return this._symbolSizeCache;

        }
        protected override void OnClick(EventArgs e)
        {
            this._toolStripDropDown.Show(this, 3, this.Height);
            this.DropDownShown = true;
            base.OnClick(e);

        }
        private void ToolStripDropDown_ItemRemoved(Object sender, ToolStripItemEventArgs e)
        {
            if (this.AutoDropDownHeight)
            {
                this._toolStripDropDown.Height -= e.Item.Height + this._heightExtra;
            }
            this.RecalculateItemIndex();
        }
        /// <summary>
        /// 重新计算Item的索引
        /// </summary>
        private void RecalculateItemIndex()
        {
            Int32 index = -1;
            foreach (ComboboxToolStripItem item in this._toolStripDropDown.Items)
            {
                item.Index = index++;
            }
        }
        private void ToolStripDropDown_ItemAdded(Object sender, ToolStripItemEventArgs e)
        {
            if (this.AutoDropDownHeight)
            {
                this._toolStripDropDown.Height += e.Item.Height + this._heightExtra;
            }
        }
    }

    public class ComboboxToolStripItem : ToolStripItem
    {
        /// <summary>
        /// 文本的对齐方式
        /// </summary>
        public StringFormat TextAlignFormat { get; set; } = StringFormat.GenericDefault;

        /// <summary>
        ///获取该Item在所属于 <see cref="ToolStrip"/> 的Item集合中的索引
        /// </summary>
        public Int32 Index { get; internal set; }
        /// <summary>
        /// 获取或设置该 Item 包含的值
        /// </summary>
        public Object Value { get; set; }
        public Color HoverColor { get; set; } = Color.FromArgb(204, 204, 204);
        public Color NormalColor { get; set; } = Color.WhiteSmoke;
        public Color PressColor { get; set; } = Color.FromArgb(175, 175, 175);

        public Color HoverForeColor { get; set; } = Color.White;
        public Color NormalForeColor { get; set; } = Color.FromArgb(30, 30, 30);
        public Color PressForeColor { get; set; } = Color.White;



        public ComboboxToolStripItem()
        {
            this.Margin = new Padding(1,0,1,0);
            this.BackColor = this.NormalColor;
            this.ForeColor = this.NormalForeColor;
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            this.BackColor = this.HoverColor;
            this.ForeColor = this.HoverForeColor;
            base.OnMouseEnter(e);
        }
        //protected override void OnMouseHover(EventArgs e)
        //{
       
        //    base.OnMouseHover(e);
        //}
        protected override void OnMouseLeave(EventArgs e)
        {
            this.BackColor = this.NormalColor;
            this.ForeColor = this.NormalForeColor;
            base.OnMouseLeave(e);
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {

            this.BackColor = this.PressColor;
            this.ForeColor = this.PressForeColor;
            base.OnMouseDown(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            this.BackColor = this.HoverColor;
            this.ForeColor = this.HoverForeColor;
            base.OnMouseUp(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Brush backBrush = new SolidBrush(this.BackColor);
            Brush textBrush = new SolidBrush(this.ForeColor);
            g.FillRectangle(backBrush, new RectangleF(0, 0, this.Width, this.Height));
            SizeF textSize = g.MeasureString(this.Text, this.Font);
            g.DrawString(
                this.Text,
                this.Font,
                textBrush,
                new RectangleF(10, 0, this.Width, this.Height),
                this.TextAlignFormat);
            backBrush.Dispose();
            textBrush.Dispose();
            base.OnPaint(e);
        }

    }
}

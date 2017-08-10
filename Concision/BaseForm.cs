using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Concision
{

    public partial class BaseForm : Form
    {

        /// <summary>
        /// 窗体动画设置
        /// </summary>
        [Description("窗体动画设置")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public WindowAnimation Animation { get; set; } = new WindowAnimation();

        [Browsable(false)]
        public new FormBorderStyle FormBorderStyle
        {
            get
            {
                return base.FormBorderStyle;
            }
            set
            {
                base.FormBorderStyle = FormBorderStyle.None;
            }
        }

        private Point _currentMousePoint;
        private Boolean _isMoving = false;



        /********************************/
        public BaseForm()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(240, 240, 240);
            this.Icon = Properties.Resources.HandinessIcon;
            this.SetStyle(ControlStyles.Opaque, false);
            this.Load += BaseForm_Load;
        }

        private void BaseForm_Load(Object sender, EventArgs e)
        {
            this.InitializeForm();
        }

        /// <summary>
        /// 初始化窗体
        /// </summary>
        protected virtual void InitializeForm()
        {

       
       
        }
        protected override void OnLoad(EventArgs e)
        {
            if (this.Animation.Enabled)
            {
                Win32API.AnimateWindow(this.Handle, this.Animation.AnimationTime,
                    this.Animation.ShowAnimationFlag());
            }
            base.OnLoad(e);
        }
        protected override void OnClosed(EventArgs e)
        {
            if (this.Animation.Enabled)
            {
                Win32API.AnimateWindow(this.Handle, this.Animation.AnimationTime,
                 this.Animation.HideAnimationFlag());
            }
            base.OnClosed(e);
        }

        /// <summary>
        /// 窗体阴影的绘制
        /// </summary>
        /// <param name="e"></param>
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
        }


        #region 窗体点击任意位置拖动
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (MouseButtons.Left == e.Button)
            {
                this._currentMousePoint = e.Location;
                this._isMoving = true;
            }
            base.OnMouseDown(e);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (this._isMoving)
            {
                /**计算Point偏移值*/
                Int32 offsetX = e.Location.X - this._currentMousePoint.X;
                Int32 offsetY = e.Location.Y - this._currentMousePoint.Y;

                this.Location = new Point(this.Location.X + offsetX, this.Location.Y + offsetY);
            }
            base.OnMouseMove(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            this._isMoving = false;
            base.OnMouseUp(e);
        }
        #endregion
    }
}

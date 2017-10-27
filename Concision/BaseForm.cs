using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;

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
        /****************************/
        private Point _currentMousePoint;
        private Boolean _isMoving = false;
        private TaskScheduler _formTaskScheduler = null;


        /********************************/


        public BaseForm()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(240, 240, 240);
            this.Icon = Properties.Resources.HandinessIcon;
            this._formTaskScheduler = TaskScheduler.Current;
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


        #region  异步执行任务
        /// <summary>
        /// 异步以执行一个任务，将不要在执行的任务中操作UI组建，请在任务完成后，任务异常后，任务取消后
        /// 这三个回调中操作UI组建
        /// </summary>
        /// <param name="task">需要长时间执行的任务</param>
        /// <param name="taskCompleted">任务完成后执行的回调</param>
        /// <param name="taskException">任务发生异常时执行的回调</param>
        /// <param name="taskCancelled">任务取消时执行的回调</param>
        public void AsyncExecuteTask(Task task,
             Action<Task> taskCompleted,
             Action<Task> taskException = null,
             Action<Task> taskCancelled = null)
        {
            task.ContinueWith(taskCompleted, CancellationToken.None,
                TaskContinuationOptions.OnlyOnRanToCompletion,
                this._formTaskScheduler);
            if (taskException != null)
            {
                task.ContinueWith(taskCompleted, CancellationToken.None,
                    TaskContinuationOptions.OnlyOnFaulted,
                  this._formTaskScheduler);
            }
            if (taskCancelled != null)
            {
                task.ContinueWith(taskCompleted, CancellationToken.None,
                   TaskContinuationOptions.OnlyOnCanceled,
                 this._formTaskScheduler);
            }
            task.Start();
        }
        public void AsyncExecuteReturnTask<TResult>(Task<TResult> task,
                Action<Task<TResult>> taskCompleted,
                Action<Task<TResult>> taskException = null,
                Action<Task<TResult>> taskCancelled = null)
        {
            dynamic taskCompletedObj = taskCompleted;
            dynamic taskExceptionObj = taskException;
            dynamic taskCancelledObj = taskCancelled;
            this.AsyncExecuteTask(task, taskCompletedObj, taskExceptionObj, taskCancelledObj);
        }
        #endregion



        #region 窗体阴影
        //   [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        //   private static extern IntPtr CreateRoundRectRgn
        //(
        //    int nLeftRect, // x-coordinate of upper-left corner
        //    int nTopRect, // y-coordinate of upper-left corner
        //    int nRightRect, // x-coordinate of lower-right corner
        //    int nBottomRect, // y-coordinate of lower-right corner
        //    int nWidthEllipse, // height of ellipse
        //    int nHeightEllipse // width of ellipse
        // );
        //[DllImport("dwmapi.dll")]
        //public static extern Int32 DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

        //[DllImport("dwmapi.dll")]
        //public static extern Int32 DwmSetWindowAttribute(IntPtr hwnd, Int32 attr, ref Int32 attrValue, Int32 attrSize);

        //[DllImport("dwmapi.dll")]
        //public static extern Int32 DwmIsCompositionEnabled(ref Int32 pfEnabled);

        //private Boolean m_aeroEnabled = true;                     // variables for box shadow
        //private const Int32 CS_DROPSHADOW = 0x00020000;
        //private const Int32 WM_NCPAINT = 0x0085;
        //private const Int32 WM_ACTIVATEAPP = 0x001C;

        //public struct MARGINS                           // struct for box shadow
        //{
        //    public Int32 leftWidth;
        //    public Int32 rightWidth;
        //    public Int32 topHeight;
        //    public Int32 bottomHeight;
        //}

        //private const Int32 WM_NCHITTEST = 0x84;          // variables for dragging the form
        //private const Int32 HTCLIENT = 0x1;
        //private const Int32 HTCAPTION = 0x2;

        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        m_aeroEnabled = CheckAeroEnabled();

        //        CreateParams cp = base.CreateParams;
        //        if (!m_aeroEnabled)
        //            cp.ClassStyle |= CS_DROPSHADOW;
        //        return cp;
        //    }
        //}

        //private Boolean CheckAeroEnabled()
        //{
        //    if (Environment.OSVersion.Version.Major >= 6)
        //    {
        //        int enabled = 0;
        //        DwmIsCompositionEnabled(ref enabled);
        //        return (enabled == 1) ? true : false;
        //    }
        //    return false;
        //}

        //protected override void WndProc(ref Message m)
        //{
        //    switch (m.Msg)
        //    {
        //        case Win32Constants.WM_ACTIVATEAPP:
        //        case Win32Constants.WM_NCPAINT:              
        //            if (m_aeroEnabled)
        //            {
        //                var v = 2;
        //                DwmSetWindowAttribute(this.Handle, 2, ref v, 4);
        //                Int32 shadowWidth = 1;
        //                MARGINS margins = new MARGINS()
        //                {
        //                    bottomHeight = shadowWidth,
        //                    leftWidth = shadowWidth,
        //                    rightWidth = shadowWidth,
        //                    topHeight = shadowWidth
        //                };
        //                DwmExtendFrameIntoClientArea(this.Handle, ref margins);
        //            }
        //            break;
        //        default:
        //            break;
        //    }
        //    base.WndProc(ref m);

        //    if (m.Msg == WM_NCHITTEST && (int)m.Result == HTCLIENT)     // drag the form
        //        m.Result = (IntPtr)HTCAPTION;

        //}
        #endregion





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

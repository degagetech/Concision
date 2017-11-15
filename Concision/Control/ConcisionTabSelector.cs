using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using Concision.Animations;

namespace Concision.Controls
{

    public class ConcisionTabSelector : System.Windows.Forms.Control, IConcisionControl
    {
        /// <summary>
        /// 滑动条的颜色  Wlj alter 2017/4/10
        /// </summary>
        [Description(" 滑动条的颜色")]
        public Color SliderColor { get; set; } = Color.FromArgb(61, 195, 245);

        


        /**************************/
        [Browsable(false)]
        public int Depth { get; set; }
        [Browsable(false)]
        public ConcisionManager SkinManager => ConcisionManager.Instance;
        [Browsable(false)]
        public MouseState MouseState { get; set; }

        private ConcisionTabControl _baseTabControl;
        public ConcisionTabControl BaseTabControl
        {
            get { return _baseTabControl; }
            set
            {
                _baseTabControl = value;
                if (_baseTabControl == null)
                    return;
                _previousSelectedTabIndex = _baseTabControl.SelectedIndex;
                _baseTabControl.Deselected += (sender, args) =>
                {
                    _previousSelectedTabIndex = _baseTabControl.SelectedIndex;
                };
                _baseTabControl.SelectedIndexChanged += (sender, args) =>
                {
                    _animationManager.SetProgress(0);
                    _animationManager.StartNewAnimation(AnimationDirection.In);
                };
                _baseTabControl.ControlAdded += delegate
                {
                    Invalidate();
                };
                _baseTabControl.ControlRemoved += delegate
                {
                    Invalidate();
                };
            }
        }

        private int _previousSelectedTabIndex;
        private Point _animationSource;
        private readonly AnimationManager _animationManager;

        private List<Rectangle> _tabRects;
        private const int TAB_HEADER_PADDING = 24;
        private const int TAB_INDICATOR_HEIGHT = 2;

        public ConcisionTabSelector()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer, true);
            Height = 48;

            _animationManager = new AnimationManager
            {
                AnimationType = AnimationType.EaseOut,
                Increment = 0.04
            };
            _animationManager.OnAnimationProgress += sender => Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.TextRenderingHint = TextRenderingHint.AntiAlias;

            //   g.Clear(SkinManager.ColorScheme.PrimaryColor);
            g.Clear(this.BackColor);
            if (_baseTabControl == null)
                return;

            if (!_animationManager.IsAnimating() || _tabRects == null || _tabRects.Count != _baseTabControl.TabCount)
                UpdateTabRects();

            var animationProgress = _animationManager.GetProgress();

            //Click feedback
            if (_animationManager.IsAnimating())
            {
                var rippleBrush = new SolidBrush(Color.FromArgb((int)(51 - (animationProgress * 50)), Color.White));
                var rippleSize = (int)(animationProgress * _tabRects[_baseTabControl.SelectedIndex].Width * 1.75);

                g.SetClip(_tabRects[_baseTabControl.SelectedIndex]);
                g.FillEllipse(rippleBrush, new Rectangle(_animationSource.X - rippleSize / 2, _animationSource.Y - rippleSize / 2, rippleSize, rippleSize));
                g.ResetClip();
                rippleBrush.Dispose();
            }

            //Draw tab headers
            foreach (TabPage tabPage in _baseTabControl.TabPages)
            {
                var currentTabIndex = _baseTabControl.TabPages.IndexOf(tabPage);
                //    Brush textBrush = new SolidBrush(Color.FromArgb(CalculateTextAlpha(currentTabIndex, animationProgress), SkinManager.ColorScheme.TextColor));
                Brush textBrush = new SolidBrush(Color.FromArgb(CalculateTextAlpha(currentTabIndex, animationProgress),this.ForeColor));
                //  g.DrawString(tabPage.Text.ToUpper(), SkinManager.ROBOTO_MEDIUM_10, textBrush, _tabRects[currentTabIndex], new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                g.DrawString(tabPage.Text, this.Font, textBrush, _tabRects[currentTabIndex], new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                textBrush.Dispose();
            }

            //Animate tab indicator
            var previousSelectedTabIndexIfHasOne = _previousSelectedTabIndex == -1 ? _baseTabControl.SelectedIndex : _previousSelectedTabIndex;
            if (previousSelectedTabIndexIfHasOne == -1)
            {
                return;
            }
            var previousActiveTabRect = _tabRects[previousSelectedTabIndexIfHasOne];
            var activeTabPageRect = _tabRects[_baseTabControl.SelectedIndex];

            //计算滑动条的位置
            var y = activeTabPageRect.Bottom - TAB_INDICATOR_HEIGHT;

            var x = previousActiveTabRect.X + (int)((activeTabPageRect.X - previousActiveTabRect.X) * animationProgress);
            var width = previousActiveTabRect.Width + (int)((activeTabPageRect.Width - previousActiveTabRect.Width) * animationProgress);

            //绘制滑动条
            Brush sliderBrush = new SolidBrush(this.SliderColor);
            g.FillRectangle(sliderBrush, x, y, width, TAB_INDICATOR_HEIGHT);
            sliderBrush.Dispose();
        }

        private int CalculateTextAlpha(int tabIndex, double animationProgress)
        {
            int primaryA = SkinManager.ACTION_BAR_TEXT.A;
            int secondaryA = SkinManager.ACTION_BAR_TEXT_SECONDARY.A;

            if (tabIndex == _baseTabControl.SelectedIndex && !_animationManager.IsAnimating())
            {
                return primaryA;
            }
            if (tabIndex != _previousSelectedTabIndex && tabIndex != _baseTabControl.SelectedIndex)
            {
                return secondaryA;
            }
            if (tabIndex == _previousSelectedTabIndex)
            {
                return primaryA - (int)((primaryA - secondaryA) * animationProgress);
            }
            return secondaryA + (int)((primaryA - secondaryA) * animationProgress);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (_tabRects == null)
                UpdateTabRects();
            for (var i = 0; i < _tabRects.Count; i++)
            {
                if (_tabRects[i].Contains(e.Location))
                {
                    _baseTabControl.SelectedIndex = i;
                }
            }

            _animationSource = e.Location;
        }

        private void UpdateTabRects()
        {
            _tabRects = new List<Rectangle>();

            //If there isn't a base tab control, the rects shouldn't be calculated
            //If there aren't tab pages in the base tab control, the list should just be empty which has been set already; exit the void
            if (_baseTabControl == null || _baseTabControl.TabCount == 0)
                return;

            //Calculate the bounds of each tab header specified in the base tab control
            using (var b = new Bitmap(1, 1))
            {
                using (var g = Graphics.FromImage(b))
                {
                    _tabRects.Add(new Rectangle(SkinManager.FORM_PADDING, 0, TAB_HEADER_PADDING * 2 + (int)g.MeasureString(_baseTabControl.TabPages[0].Text, SkinManager.FontOfMedium10).Width, Height));
                    for (int i = 1; i < _baseTabControl.TabPages.Count; i++)
                    {
                        _tabRects.Add(new Rectangle(_tabRects[i - 1].Right, 0, TAB_HEADER_PADDING * 2 + (int)g.MeasureString(_baseTabControl.TabPages[i].Text, SkinManager.FontOfMedium10).Width, Height));
                    }
                }
            }
        }
    }
}

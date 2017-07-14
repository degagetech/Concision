using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace Concision.Control
{
    public enum CarouselSytle
    {
        /// <summary>
        /// 切换
        /// </summary>
        Switch = 0
    }
    public class CarouselPictrueBox : PictureBox
    {
        [Description("启用轮播效果")]
        public Boolean IsEnableCarousel
        {
            get
            {
                return this._carouselTimer.Enabled;
            }
            set
            {
                this._carouselTimer.Enabled = value;
            }
        }
        [Description("轮播间隔，单位：毫秒")]
        public Int32 Interval
        {
            get
            {
                return this._carouselTimer.Interval;
            }
            set
            {
                this._carouselTimer.Interval = value;
            }
        }
        [Description("轮播风格")]
        public CarouselSytle CarouselSytle { get; set; } = CarouselSytle.Switch;
        [Description("用于轮播的图片集合")]
        public Image[] Images
        {
            get
            {
                return this._images;
            }
            set
            {
                lock (_syncObj)
                {
                    this._images = value;
                    this._currentImageIndex = 0;
                }
                this.Image = this.GetNextImage();
            }
        }

        [Browsable(false)]
        public Int32 CurrentImageIndex
        {
            get
            {
                return this._currentImageIndex;
            }
            private set
            {
                lock (this._syncObj)
                {
                    this._currentImageIndex = value;
                }
            }
        }


        private Timer _carouselTimer = new Timer();
        private Boolean _isbusying = false;
        private Object _syncObj = new Object();
        private Int32 _currentImageIndex = 0;
        private Image[] _images = null;

        public CarouselPictrueBox() : base()
        {
            this._carouselTimer.Interval = 1000;
            this._carouselTimer.Tick += CarouselTimer_Tick;
        }

        private void CarouselTimer_Tick(Object sender, EventArgs e)
        {
            Timer timer = sender as Timer;
            timer.Enabled = false;
            if (!this._isbusying)
            {
                switch (this.CarouselSytle)
                {
                    case CarouselSytle.Switch:
                    default:
                        {
                            this.CarouselWithSwitch();
                        }
                        break;
                }
            }
            timer.Enabled = true;
        }
        private void CarouselWithSwitch()
        {
            this._isbusying = true;
            this.Image = this.GetNextImage();
            this._isbusying = false;
        }
        private Image GetNextImage()
        {
            Image image = null;
            if (this.Images != null && this.Images.Length > 0)
            {
                if (this.CurrentImageIndex >= this.Images.Length)
                {
                    this.CurrentImageIndex = 0;
                }
                image = this.Images[this.CurrentImageIndex++];
            }
            return image;
        }
    }
}

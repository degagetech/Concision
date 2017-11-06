using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestUnit
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            this.TestImage = new Bitmap(this.Size.Width,this.Height);
            this.Paint += Form5_Paint;
       
        }

        private void Form5_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawCheckBox(e.Graphics,new Rectangle(10,10,20,20),ButtonState.Normal);
            ControlPaint.DrawComboButton(e.Graphics, new Rectangle(10, 40, 20, 20), ButtonState.Pushed);
            //   ControlPaint.FillReversibleRectangle(new Rectangle(10, 40, 200, 200),Color.Red);
            ControlPaint.DrawLockedFrame(e.Graphics, new Rectangle(30, 40, 20, 20), true);
        }

        public Bitmap TestImage { get; set; } 
        protected override void OnPaint(PaintEventArgs e)
        {

         //   e.Graphics.Clear(Color.Blue);
         //   e.Graphics.
            base.OnPaint(e);

            //e.Graphics.DrawImage(TestImage, new PointF(0, 0));
            //TestImage.Save("test.png", ImageFormat.Png);
        }
    }
}

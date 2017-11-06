using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestUnit
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();

            //  this.TransparencyKey = this.BackColor;
            this.IsMdiContainer = true;
            this.Opacity = 0.3;
            Form5 form = new Form5();
            form.MdiParent = this;
            form.Show();
        }
    }
}

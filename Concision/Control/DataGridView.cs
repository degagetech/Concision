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
    public  class DataGridView : System.Windows.Forms.DataGridView
    {
        public  DataGridView():base()
        {
            this.DoubleBuffered = true;
        }
    }
}

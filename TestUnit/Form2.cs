using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Concision;
namespace TestUnit
{
    public partial class Form2 : DarkForm
    {
        public Form2()
        {
            InitializeComponent();
            this.label1.Text = System.Globalization.CultureInfo.InstalledUICulture.Name;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            for (Int32 i = 0; i < 1000; ++i)
            {
                String guid = Guid.NewGuid().ToString("N");
                this.dataGridView2.Rows.Add(true, guid, guid, guid, guid);
   
            }
        }
    }
}

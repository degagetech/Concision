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
    public partial class Form1 : BaseForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Boolean asc = true;
            Int32 max = 50;
            Int32 min = 10;
            this.symbol1.DoAnimation(
                () =>
                {
                    Int32 num = 2;
                    if (this.symbol1.SymbolSize == min) asc = true; 
                    if (this.symbol1.SymbolSize == max) asc =false;

                    this.symbol1.SymbolSize += (asc?num:-num);
                    this.scutcheon3.Text = this.symbol1.SymbolSize.ToString();
                    return true;
                },10
                );
            //this.combobox1.AddRange
            this.combobox1.Add("国土局");
            this.combobox1.Add("财政厅");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.button1.IsWaiting = !this.button1.IsWaiting;
            this.button1.Text = this.button1.IsWaiting ? "加载中..." : "点我马上开始";
        }
    }
}

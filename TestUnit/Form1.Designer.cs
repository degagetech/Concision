namespace TestUnit
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.scutcheon1 = new Concision.Controls.Scutcheon();
            this.scutcheon2 = new Concision.Controls.Scutcheon();
            this.button1 = new Concision.Controls.ConcisionButton();
            this.shade1 = new Concision.Controls.Shade();
            this.symbol1 = new Concision.Controls.Symbol();
            this.combobox1 = new Concision.Controls.ConcisionCombobox();
            this.symbol2 = new Concision.Controls.Symbol();
            this.symbol3 = new Concision.Controls.Symbol();
            this.line2 = new Concision.Controls.Line();
            this.scutcheon3 = new Concision.Controls.Scutcheon();
            this.waitIndicator1 = new Concision.Controls.WaitIndicator();
            this.waitIndicator2 = new Concision.Controls.WaitIndicator();
            this.waitIndicator3 = new Concision.Controls.WaitIndicator();
            this.waitIndicator4 = new Concision.Controls.WaitIndicator();
            this.button2 = new Concision.Controls.ConcisionButton();
            this.button3 = new Concision.Controls.ConcisionButton();
            this.SuspendLayout();
            // 
            // windowsButton3
            // 
            this.windowsButton3.BackColor = System.Drawing.SystemColors.Control;
            this.windowsButton3.Location = new System.Drawing.Point(749, 11);
            // 
            // windowsButton2
            // 
            this.windowsButton2.BackColor = System.Drawing.SystemColors.Control;
            this.windowsButton2.Location = new System.Drawing.Point(789, 11);
            // 
            // windowsButton1
            // 
            this.windowsButton1.BackColor = System.Drawing.SystemColors.Control;
            this.windowsButton1.Location = new System.Drawing.Point(829, 11);
            // 
            // line1
            // 
            this.line1.LineLength = 939;
            this.line1.Size = new System.Drawing.Size(939, 2);
            // 
            // scutcheon1
            // 
            this.scutcheon1.EnabledMousePierce = false;
            this.scutcheon1.ForeColor = System.Drawing.Color.White;
            this.scutcheon1.Location = new System.Drawing.Point(352, 173);
            this.scutcheon1.Margin = new System.Windows.Forms.Padding(0);
            this.scutcheon1.Name = "scutcheon1";
            this.scutcheon1.ScutcheonColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(166)))), ((int)(((byte)(228)))));
            this.scutcheon1.ScutcheonShape = Concision.Controls.ScutcheonShapeType.Circle;
            this.scutcheon1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.scutcheon1.ShadowWidth = 1;
            this.scutcheon1.Size = new System.Drawing.Size(147, 48);
            this.scutcheon1.TabIndex = 5;
            this.scutcheon1.Text = "标牌控件-椭圆";
            this.scutcheon1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scutcheon2
            // 
            this.scutcheon2.EnabledMousePierce = true;
            this.scutcheon2.ForeColor = System.Drawing.Color.White;
            this.scutcheon2.Location = new System.Drawing.Point(205, 221);
            this.scutcheon2.Margin = new System.Windows.Forms.Padding(0);
            this.scutcheon2.Name = "scutcheon2";
            this.scutcheon2.ScutcheonColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(166)))), ((int)(((byte)(228)))));
            this.scutcheon2.ScutcheonShape = Concision.Controls.ScutcheonShapeType.Triangle;
            this.scutcheon2.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.scutcheon2.ShadowWidth = 1;
            this.scutcheon2.Size = new System.Drawing.Size(147, 123);
            this.scutcheon2.TabIndex = 6;
            this.scutcheon2.Text = "标牌控件-三角";
            this.scutcheon2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.button1.EnabledMousePierce = false;
            this.button1.EnabledWaitingClick = false;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.button1.IsWaiting = false;
            this.button1.Location = new System.Drawing.Point(211, 159);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(166)))), ((int)(((byte)(228)))));
            this.button1.Size = new System.Drawing.Size(114, 44);
            this.button1.TabIndex = 8;
            this.button1.Text = "标牌控件-方形";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // shade1
            // 
            this.shade1.Alpha = 150;
            this.shade1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.shade1.EnabledDrawText = true;
            this.shade1.EnabledMousePierce = false;
            this.shade1.Location = new System.Drawing.Point(21, 129);
            this.shade1.Margin = new System.Windows.Forms.Padding(0);
            this.shade1.Name = "shade1";
            this.shade1.Size = new System.Drawing.Size(468, 245);
            this.shade1.TabIndex = 10;
            this.shade1.Text = "遮罩控件";
            this.shade1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // symbol1
            // 
            this.symbol1.EnabledMousePierce = false;
            this.symbol1.Font = new System.Drawing.Font("FontAwesome", 15F);
            this.symbol1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.symbol1.Location = new System.Drawing.Point(562, 306);
            this.symbol1.Margin = new System.Windows.Forms.Padding(0);
            this.symbol1.Name = "symbol1";
            this.symbol1.Size = new System.Drawing.Size(59, 45);
            this.symbol1.SymbolColor = System.Drawing.Color.DodgerBlue;
            this.symbol1.SymbolPattern = "";
            this.symbol1.SymbolSize = 15F;
            this.symbol1.TabIndex = 13;
            this.symbol1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // combobox1
            // 
            this.combobox1.AutoDropDownHeight = true;
            this.combobox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.combobox1.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.combobox1.DropDownHeight = 0;
            this.combobox1.DropDownWidth = 220;
            this.combobox1.EnabledMousePierce = false;
            this.combobox1.EnabledWaitingClick = false;
            this.combobox1.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.combobox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.combobox1.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.combobox1.IsWaiting = false;
            this.combobox1.ItemFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.combobox1.ItemHeight = 30;
            this.combobox1.Location = new System.Drawing.Point(513, 93);
            this.combobox1.Margin = new System.Windows.Forms.Padding(0);
            this.combobox1.Name = "combobox1";
            this.combobox1.NormalColor = System.Drawing.Color.WhiteSmoke;
            this.combobox1.SelectedIndex = -1;
            this.combobox1.SelectedText = null;
            this.combobox1.Size = new System.Drawing.Size(217, 42);
            this.combobox1.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.combobox1.SymbolSize = 10F;
            this.combobox1.TabIndex = 14;
            this.combobox1.Text = "Combobox";
            this.combobox1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // symbol2
            // 
            this.symbol2.EnabledMousePierce = false;
            this.symbol2.Font = new System.Drawing.Font("FontAwesome", 15F);
            this.symbol2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.symbol2.Location = new System.Drawing.Point(631, 306);
            this.symbol2.Margin = new System.Windows.Forms.Padding(0);
            this.symbol2.Name = "symbol2";
            this.symbol2.Size = new System.Drawing.Size(59, 45);
            this.symbol2.SymbolColor = System.Drawing.Color.DodgerBlue;
            this.symbol2.SymbolPattern = "";
            this.symbol2.SymbolSize = 15F;
            this.symbol2.TabIndex = 15;
            this.symbol2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // symbol3
            // 
            this.symbol3.EnabledMousePierce = false;
            this.symbol3.Font = new System.Drawing.Font("FontAwesome", 15F);
            this.symbol3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.symbol3.Location = new System.Drawing.Point(562, 361);
            this.symbol3.Margin = new System.Windows.Forms.Padding(0);
            this.symbol3.Name = "symbol3";
            this.symbol3.Size = new System.Drawing.Size(59, 45);
            this.symbol3.SymbolColor = System.Drawing.Color.DodgerBlue;
            this.symbol3.SymbolPattern = "";
            this.symbol3.SymbolSize = 15F;
            this.symbol3.TabIndex = 16;
            this.symbol3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // line2
            // 
            this.line2.CustomBursh = null;
            this.line2.EnabledMousePierce = false;
            this.line2.IsVertical = false;
            this.line2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.line2.LineLength = 372;
            this.line2.LineWidth = 5;
            this.line2.Location = new System.Drawing.Point(162, 454);
            this.line2.Margin = new System.Windows.Forms.Padding(0);
            this.line2.Name = "line2";
            this.line2.Size = new System.Drawing.Size(372, 5);
            this.line2.TabIndex = 17;
            this.line2.Text = "line2";
            this.line2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scutcheon3
            // 
            this.scutcheon3.EnabledMousePierce = false;
            this.scutcheon3.ForeColor = System.Drawing.Color.White;
            this.scutcheon3.Location = new System.Drawing.Point(30, 434);
            this.scutcheon3.Margin = new System.Windows.Forms.Padding(0);
            this.scutcheon3.Name = "scutcheon3";
            this.scutcheon3.ScutcheonColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(166)))), ((int)(((byte)(228)))));
            this.scutcheon3.ScutcheonShape = Concision.Controls.ScutcheonShapeType.Circle;
            this.scutcheon3.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.scutcheon3.ShadowWidth = 1;
            this.scutcheon3.Size = new System.Drawing.Size(120, 48);
            this.scutcheon3.TabIndex = 18;
            this.scutcheon3.Text = "Line控件";
            this.scutcheon3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // waitIndicator1
            // 
            this.waitIndicator1.CurrentAngle = 15F;
            this.waitIndicator1.EachRollingAngle = 15F;
            this.waitIndicator1.EnabledMousePierce = false;
            this.waitIndicator1.HatchBrushStyle = System.Drawing.Drawing2D.HatchStyle.DarkHorizontal;
            this.waitIndicator1.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.waitIndicator1.IsFollowParentBackColor = true;
            this.waitIndicator1.IsRolled = true;
            this.waitIndicator1.Location = new System.Drawing.Point(655, 468);
            this.waitIndicator1.Margin = new System.Windows.Forms.Padding(0);
            this.waitIndicator1.Name = "waitIndicator1";
            this.waitIndicator1.RollingSpeed = 60D;
            this.waitIndicator1.RollPartBrushType = Concision.Controls.RollPartBrushType.Solid;
            this.waitIndicator1.RollPartLengthPercent = 60F;
            this.waitIndicator1.RollPartWidthPercent = 20F;
            this.waitIndicator1.Size = new System.Drawing.Size(50, 50);
            this.waitIndicator1.TabIndex = 19;
            this.waitIndicator1.Text = "waitIndicator1";
            this.waitIndicator1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.waitIndicator1.WaitIndicatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            // 
            // waitIndicator2
            // 
            this.waitIndicator2.CurrentAngle = 240F;
            this.waitIndicator2.EachRollingAngle = 15F;
            this.waitIndicator2.EnabledMousePierce = false;
            this.waitIndicator2.HatchBrushStyle = System.Drawing.Drawing2D.HatchStyle.WideUpwardDiagonal;
            this.waitIndicator2.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.waitIndicator2.IsFollowParentBackColor = true;
            this.waitIndicator2.IsRolled = true;
            this.waitIndicator2.Location = new System.Drawing.Point(749, 468);
            this.waitIndicator2.Margin = new System.Windows.Forms.Padding(0);
            this.waitIndicator2.Name = "waitIndicator2";
            this.waitIndicator2.RollingSpeed = 60D;
            this.waitIndicator2.RollPartBrushType = Concision.Controls.RollPartBrushType.Hatch;
            this.waitIndicator2.RollPartLengthPercent = 60F;
            this.waitIndicator2.RollPartWidthPercent = 20F;
            this.waitIndicator2.Size = new System.Drawing.Size(30, 30);
            this.waitIndicator2.TabIndex = 20;
            this.waitIndicator2.Text = "waitIndicator2";
            this.waitIndicator2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.waitIndicator2.WaitIndicatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            // 
            // waitIndicator3
            // 
            this.waitIndicator3.CurrentAngle = 45F;
            this.waitIndicator3.EachRollingAngle = 15F;
            this.waitIndicator3.EnabledMousePierce = false;
            this.waitIndicator3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.waitIndicator3.HatchBrushStyle = System.Drawing.Drawing2D.HatchStyle.SmallGrid;
            this.waitIndicator3.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.waitIndicator3.IsFollowParentBackColor = true;
            this.waitIndicator3.IsRolled = true;
            this.waitIndicator3.Location = new System.Drawing.Point(799, 468);
            this.waitIndicator3.Margin = new System.Windows.Forms.Padding(0);
            this.waitIndicator3.Name = "waitIndicator3";
            this.waitIndicator3.RollingSpeed = 60D;
            this.waitIndicator3.RollPartBrushType = Concision.Controls.RollPartBrushType.Hatch;
            this.waitIndicator3.RollPartLengthPercent = 60F;
            this.waitIndicator3.RollPartWidthPercent = 20F;
            this.waitIndicator3.Size = new System.Drawing.Size(30, 30);
            this.waitIndicator3.TabIndex = 21;
            this.waitIndicator3.Text = "waitIndicator3";
            this.waitIndicator3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.waitIndicator3.WaitIndicatorColor = System.Drawing.SystemColors.ButtonFace;
            // 
            // waitIndicator4
            // 
            this.waitIndicator4.CurrentAngle = 255F;
            this.waitIndicator4.EachRollingAngle = 15F;
            this.waitIndicator4.EnabledMousePierce = false;
            this.waitIndicator4.HatchBrushStyle = System.Drawing.Drawing2D.HatchStyle.DarkHorizontal;
            this.waitIndicator4.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.waitIndicator4.IsFollowParentBackColor = true;
            this.waitIndicator4.IsRolled = true;
            this.waitIndicator4.Location = new System.Drawing.Point(582, 468);
            this.waitIndicator4.Margin = new System.Windows.Forms.Padding(0);
            this.waitIndicator4.Name = "waitIndicator4";
            this.waitIndicator4.RollingSpeed = 60D;
            this.waitIndicator4.RollPartBrushType = Concision.Controls.RollPartBrushType.Solid;
            this.waitIndicator4.RollPartLengthPercent = 60F;
            this.waitIndicator4.RollPartWidthPercent = 20F;
            this.waitIndicator4.Size = new System.Drawing.Size(50, 50);
            this.waitIndicator4.TabIndex = 22;
            this.waitIndicator4.Text = "waitIndicator4";
            this.waitIndicator4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.waitIndicator4.WaitIndicatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(166)))), ((int)(((byte)(228)))));
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.button2.EnabledMousePierce = false;
            this.button2.EnabledWaitingClick = false;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.button2.IsWaiting = true;
            this.button2.Location = new System.Drawing.Point(721, 303);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(166)))), ((int)(((byte)(228)))));
            this.button2.Size = new System.Drawing.Size(133, 41);
            this.button2.TabIndex = 23;
            this.button2.Text = "按钮-等待";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.button3.EnabledMousePierce = false;
            this.button3.EnabledWaitingClick = false;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.button3.IsWaiting = false;
            this.button3.Location = new System.Drawing.Point(721, 246);
            this.button3.Margin = new System.Windows.Forms.Padding(0);
            this.button3.Name = "button3";
            this.button3.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(166)))), ((int)(((byte)(228)))));
            this.button3.Size = new System.Drawing.Size(133, 41);
            this.button3.TabIndex = 24;
            this.button3.Text = "按钮";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 548);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.waitIndicator4);
            this.Controls.Add(this.waitIndicator3);
            this.Controls.Add(this.waitIndicator2);
            this.Controls.Add(this.waitIndicator1);
            this.Controls.Add(this.scutcheon3);
            this.Controls.Add(this.line2);
            this.Controls.Add(this.symbol3);
            this.Controls.Add(this.symbol2);
            this.Controls.Add(this.combobox1);
            this.Controls.Add(this.shade1);
            this.Controls.Add(this.symbol1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.scutcheon2);
            this.Controls.Add(this.scutcheon1);
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.windowsButton1, 0);
            this.Controls.SetChildIndex(this.windowsButton2, 0);
            this.Controls.SetChildIndex(this.windowsButton3, 0);
            this.Controls.SetChildIndex(this.scutcheon1, 0);
            this.Controls.SetChildIndex(this.scutcheon2, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.symbol1, 0);
            this.Controls.SetChildIndex(this.line1, 0);
            this.Controls.SetChildIndex(this.shade1, 0);
            this.Controls.SetChildIndex(this.combobox1, 0);
            this.Controls.SetChildIndex(this.symbol2, 0);
            this.Controls.SetChildIndex(this.symbol3, 0);
            this.Controls.SetChildIndex(this.line2, 0);
            this.Controls.SetChildIndex(this.scutcheon3, 0);
            this.Controls.SetChildIndex(this.waitIndicator1, 0);
            this.Controls.SetChildIndex(this.waitIndicator2, 0);
            this.Controls.SetChildIndex(this.waitIndicator3, 0);
            this.Controls.SetChildIndex(this.waitIndicator4, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            this.Controls.SetChildIndex(this.button3, 0);
            this.ResumeLayout(false);

        }

        #endregion
        private Concision.Controls.Scutcheon scutcheon1;
        private Concision.Controls.Scutcheon scutcheon2;
        private Concision.Controls.ConcisionButton button1;
        private Concision.Controls.Shade shade1;
        private Concision.Controls.Symbol symbol1;
        private Concision.Controls.ConcisionCombobox combobox1;
        private Concision.Controls.Symbol symbol2;
        private Concision.Controls.Symbol symbol3;
        private Concision.Controls.Line line2;
        private Concision.Controls.Scutcheon scutcheon3;
        private Concision.Controls.WaitIndicator waitIndicator1;
        private Concision.Controls.WaitIndicator waitIndicator2;
        private Concision.Controls.WaitIndicator waitIndicator3;
        private Concision.Controls.WaitIndicator waitIndicator4;
        private Concision.Controls.ConcisionButton button2;
        private Concision.Controls.ConcisionButton button3;
    }
}


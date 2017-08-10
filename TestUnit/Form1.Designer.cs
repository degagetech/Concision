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
            this.combobox1 = new Concision.Control.Combobox();
            this.scutcheon1 = new Concision.Control.Scutcheon();
            this.scutcheon2 = new Concision.Control.Scutcheon();
            this.scutcheon3 = new Concision.Control.Scutcheon();
            this.button1 = new Concision.Control.Button();
            this.shade1 = new Concision.Control.Shade();
            this.panel1 = new Concision.Control.Panel();
            this.windowsButton1 = new Concision.Control.WindowsButton();
            this.symbol1 = new Concision.Control.Symbol();
            this.SuspendLayout();
            // 
            // combobox1
            // 
            this.combobox1.AutoDropDownHeight = true;
            this.combobox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.combobox1.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.combobox1.DropDownHeight = 0;
            this.combobox1.DropDownWidth = 150;
            this.combobox1.EnabledMousePierce = false;
            this.combobox1.EnabledWaitingClick = false;
            this.combobox1.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.combobox1.ForeColor = System.Drawing.Color.White;
            this.combobox1.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.combobox1.IsWaiting = false;
            this.combobox1.ItemFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.combobox1.ItemHeight = 25;
            this.combobox1.Location = new System.Drawing.Point(44, 53);
            this.combobox1.Margin = new System.Windows.Forms.Padding(0);
            this.combobox1.Name = "combobox1";
            this.combobox1.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(166)))), ((int)(((byte)(228)))));
            this.combobox1.SelectedIndex = -1;
            this.combobox1.SelectedText = null;
            this.combobox1.Size = new System.Drawing.Size(137, 35);
            this.combobox1.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.combobox1.SymbolSize = 10F;
            this.combobox1.TabIndex = 4;
            this.combobox1.Text = "选择一个单位：";
            this.combobox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scutcheon1
            // 
            this.scutcheon1.EnabledMousePierce = false;
            this.scutcheon1.ForeColor = System.Drawing.Color.White;
            this.scutcheon1.Location = new System.Drawing.Point(34, 189);
            this.scutcheon1.Margin = new System.Windows.Forms.Padding(0);
            this.scutcheon1.Name = "scutcheon1";
            this.scutcheon1.ScutcheonColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(166)))), ((int)(((byte)(228)))));
            this.scutcheon1.ScutcheonShape = Concision.Control.ScutcheonShapeType.Circle;
            this.scutcheon1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.scutcheon1.ShadowWidth = 1;
            this.scutcheon1.Size = new System.Drawing.Size(147, 48);
            this.scutcheon1.TabIndex = 5;
            this.scutcheon1.Text = "在不在？";
            this.scutcheon1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scutcheon2
            // 
            this.scutcheon2.EnabledMousePierce = true;
            this.scutcheon2.ForeColor = System.Drawing.Color.White;
            this.scutcheon2.Location = new System.Drawing.Point(156, 263);
            this.scutcheon2.Margin = new System.Windows.Forms.Padding(0);
            this.scutcheon2.Name = "scutcheon2";
            this.scutcheon2.ScutcheonColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(166)))), ((int)(((byte)(228)))));
            this.scutcheon2.ScutcheonShape = Concision.Control.ScutcheonShapeType.Square;
            this.scutcheon2.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.scutcheon2.ShadowWidth = 1;
            this.scutcheon2.Size = new System.Drawing.Size(147, 48);
            this.scutcheon2.TabIndex = 6;
            this.scutcheon2.Text = "没事就在有事就不在";
            this.scutcheon2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scutcheon3
            // 
            this.scutcheon3.EnabledMousePierce = false;
            this.scutcheon3.ForeColor = System.Drawing.Color.White;
            this.scutcheon3.Location = new System.Drawing.Point(165, 409);
            this.scutcheon3.Margin = new System.Windows.Forms.Padding(0);
            this.scutcheon3.Name = "scutcheon3";
            this.scutcheon3.ScutcheonColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(166)))), ((int)(((byte)(228)))));
            this.scutcheon3.ScutcheonShape = Concision.Control.ScutcheonShapeType.Circle;
            this.scutcheon3.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.scutcheon3.ShadowWidth = 1;
            this.scutcheon3.Size = new System.Drawing.Size(147, 48);
            this.scutcheon3.TabIndex = 7;
            this.scutcheon3.Text = "没事";
            this.scutcheon3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.button1.Location = new System.Drawing.Point(216, 114);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(166)))), ((int)(((byte)(228)))));
            this.button1.Size = new System.Drawing.Size(156, 47);
            this.button1.TabIndex = 8;
            this.button1.Text = "点我，马上开始";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // shade1
            // 
            this.shade1.Alpha = 150;
            this.shade1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.shade1.EnabledDrawText = true;
            this.shade1.EnabledMousePierce = false;
            this.shade1.Location = new System.Drawing.Point(106, 36);
            this.shade1.Margin = new System.Windows.Forms.Padding(0);
            this.shade1.Name = "shade1";
            this.shade1.Size = new System.Drawing.Size(464, 337);
            this.shade1.TabIndex = 10;
            this.shade1.Text = "遮罩";
            this.shade1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BorderColor = System.Drawing.Color.Gray;
            this.panel1.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.panel1.BorderWith = 2;
            this.panel1.EnabledMousePierce = false;
            this.panel1.IsDrawBorder = true;
            this.panel1.Location = new System.Drawing.Point(492, 121);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(205, 252);
            this.panel1.TabIndex = 11;
            // 
            // windowsButton1
            // 
            this.windowsButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.windowsButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.windowsButton1.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.windowsButton1.EnabledAdsorb = true;
            this.windowsButton1.EnabledMousePierce = false;
            this.windowsButton1.Font = new System.Drawing.Font("FontAwesome", 10F);
            this.windowsButton1.ForeColor = System.Drawing.Color.White;
            this.windowsButton1.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.windowsButton1.IconSize = 10F;
            this.windowsButton1.Location = new System.Drawing.Point(663, 53);
            this.windowsButton1.Margin = new System.Windows.Forms.Padding(0);
            this.windowsButton1.Name = "windowsButton1";
            this.windowsButton1.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(195)))), ((int)(((byte)(245)))));
            this.windowsButton1.Size = new System.Drawing.Size(40, 35);
            this.windowsButton1.TabIndex = 12;
            this.windowsButton1.Text = "";
            this.windowsButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.windowsButton1.WindowsButtonType = Concision.Control.WindowsButtonType.Maximize;
            // 
            // symbol1
            // 
            this.symbol1.EnabledMousePierce = false;
            this.symbol1.Font = new System.Drawing.Font("FontAwesome", 10F);
            this.symbol1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.symbol1.Location = new System.Drawing.Point(389, 386);
            this.symbol1.Margin = new System.Windows.Forms.Padding(0);
            this.symbol1.Name = "symbol1";
            this.symbol1.Size = new System.Drawing.Size(100, 100);
            this.symbol1.SymbolColor = System.Drawing.SystemColors.ControlText;
            this.symbol1.SymbolPattern = "";
            this.symbol1.SymbolSize = 10F;
            this.symbol1.TabIndex = 13;
            this.symbol1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.Animation.AnimationTime = 200;
            this.Animation.Enabled = true;
            this.Animation.HideEffect = Concision.WindowAnimationStyle.Fade;
            this.Animation.ShowEffect = Concision.WindowAnimationStyle.Center;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 495);
            this.Controls.Add(this.shade1);
            this.Controls.Add(this.symbol1);
            this.Controls.Add(this.windowsButton1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.scutcheon3);
            this.Controls.Add(this.scutcheon2);
            this.Controls.Add(this.scutcheon1);
            this.Controls.Add(this.combobox1);
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private Concision.Control.Combobox combobox1;
        private Concision.Control.Scutcheon scutcheon1;
        private Concision.Control.Scutcheon scutcheon2;
        private Concision.Control.Scutcheon scutcheon3;
        private Concision.Control.Button button1;
        private Concision.Control.Shade shade1;
        private Concision.Control.Panel panel1;
        private Concision.Control.WindowsButton windowsButton1;
        private Concision.Control.Symbol symbol1;
    }
}


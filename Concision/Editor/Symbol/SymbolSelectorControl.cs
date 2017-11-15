using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Windows.Forms.Design;
using Concision.Controls;
using System.Diagnostics;

namespace Concision.Editor
{
    [ToolboxItem(false)]
    public partial class SymbolSelectorControl : UserControl
    {
        private static FieldInfo[] AwesomeFontFieldInfoCache = null;
        private static Dictionary<String, String> ValueNameMap = new Dictionary<String, String>();
        private static String[] LoadSymbolPatternList()
        {
            if (null == AwesomeFontFieldInfoCache)
            {
                AwesomeFontFieldInfoCache = typeof(AwesomeFont).GetFields();
                foreach (var field in AwesomeFontFieldInfoCache)
                {
                    String val = field.GetValue(null).ToString();
                    String name = field.Name;
                    if (!String.IsNullOrEmpty(val) && !ValueNameMap.ContainsKey(val))
                    {
                        ValueNameMap.Add(val, name);
                    }
                }

            }
            return ValueNameMap.Keys.ToArray();
        }

        public static String QueryPatternName(String pattern)
        {
            String name = String.Empty;
            if (ValueNameMap.ContainsKey(pattern))
            {
                name = ValueNameMap[pattern];
            }
            return name;
        }
        /*****/
        public IWindowsFormsEditorService WindowsFormsEditorService { get; set; }

        public String PatternSelected { get; set; } = AwesomeFont.warning;
        public String NameSelected { get; set; } = nameof(AwesomeFont.warning);


        private ToolTip _toolTip = new ToolTip();
        public SymbolSelectorControl(IWindowsFormsEditorService edSvc = null) : this()
        {
            this.WindowsFormsEditorService = edSvc;
        }
        public SymbolSelectorControl()
        {
            InitializeComponent();
        }



        protected override void OnLoad(EventArgs e)
        {
            this.DrawSymbolPatterns();
            base.OnLoad(e);
        }
        protected override void OnVisibleChanged(EventArgs e)
        {
            this.Invalidate();
            base.OnVisibleChanged(e);
        }

        private void DrawSymbolPatterns()
        {
            String[] patternList = LoadSymbolPatternList();
            this._flpPatternContainer.Visible = false;
            this._flpPatternContainer.Controls.Clear();
            var symbols = new Symbol[patternList.Length];
            for (int i = 0; i < patternList.Length; ++i)
            {
                var symbol = new Symbol();
                symbol.Size = new Size(24, 23);
                symbol.SymbolSize = 10;
                symbol.BackColor = Color.FromArgb(61, 195, 245);
                symbol.ForeColor = Color.White;
                symbol.SymbolPattern = patternList[i];
                symbol.Margin = new Padding(2, 2, 2, 2);
                this._toolTip.SetToolTip(symbol, QueryPatternName(patternList[i]));
                symbols[i] = symbol;
                symbol.MouseDown += (s, e) =>
                {
                    Symbol sbl = s as Symbol;
                    this.OnSymbolSelected(sbl.SymbolPattern);
                };
                symbol.MouseHover += (s, e) =>
                {
                    Symbol sbl = s as Symbol;
                    sbl.BackColor = Color.FromArgb(175, 175, 175);
                };
                symbol.MouseLeave += (s, e) =>
                 {
                     Symbol sbl = s as Symbol;
                     sbl.BackColor = Color.FromArgb(61, 195, 245);
                 };
            }
            this._flpPatternContainer.Controls.AddRange(symbols);
            this._flpPatternContainer.Visible = true;
        }
        private void OnSymbolSelected(String symbol)
        {
            this.PatternSelected = symbol;
            this.WindowsFormsEditorService?.CloseDropDown();
        }
    }

}

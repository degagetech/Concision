using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Drawing;
using System.Reflection;

namespace Concision.Editor
{

    public class SymbolEditor : UITypeEditor
    {
        public override Object EditValue(ITypeDescriptorContext context, IServiceProvider provider, Object value)
        {
            String current = value as String;
            String selected = AwesomeFont.warning;
            if (String.IsNullOrEmpty(current))
            {
                return selected;
            }

            IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            if (edSvc != null)
            {
                SymbolSelectorControl editControl = new SymbolSelectorControl(edSvc);
                editControl.PatternSelected = current;
                 editControl.Refresh();
                edSvc.DropDownControl(editControl);
                selected = editControl.PatternSelected;
            }
            return selected;
        }
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }
        public override void PaintValue(PaintValueEventArgs e)
        {
            Font font = new Font(AwesomeFont.FontFamily, 9F);
            Brush brush = new SolidBrush(Color.Black);
            String text = e.Value as String;
            if (text == null)
            {
                text = "Error";
                font = new Font("微软雅黑", 9F);
            }
       
            RectangleF rect = new RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
            e.Graphics.DrawString(text, font, brush, rect, new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            });
            brush.Dispose();
            base.PaintValue(e);
        }
     
        public override Boolean GetPaintValueSupported(ITypeDescriptorContext context)
        {
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
namespace Concision
{
    public class TextDescriptionAttribute : DescriptionAttribute
    {
        public TextDescriptionAttribute(String key) : base(key) { }

        public override String Description
        {
            get
            {
                return TextResourceReader.Instance[base.Description];
            }
        }
    }
}

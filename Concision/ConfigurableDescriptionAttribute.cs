using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
namespace Concision
{
    public class ConfigurableDescriptionAttribute : DescriptionAttribute
    {
        public override String Description => base.Description;
    }
}

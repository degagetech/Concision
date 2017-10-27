using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concision
{
    public class CultureInfoHelper
    {
        /// <summary>
        /// 获取当前操作系统区域设置的区域名称
        /// </summary>
        public static String Name
        {
            get => System.Globalization.CultureInfo.InstalledUICulture.Name;
        }
    }
}

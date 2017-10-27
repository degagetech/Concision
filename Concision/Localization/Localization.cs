using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concision
{
    public class Localization
    {
        internal const String TextResourceFileExt = ".ctrf";
        /// <summary>
        /// 加载符合当前操作系统区域设置的文本资源集合，
        /// 若无则尝试获取可用的文本资源，
        /// 再次失败则返回默认的文本资源
        /// </summary>
        /// <returns></returns>
        public static LocalizationTextReousrceCollection LoadSystemCultureInfo()
        {
            String name = CultureInfoHelper.Name;
            LocalizationTextReousrceCollection collection = null;
            //TKXmlSerializer.Search<LocalizationCollection>();
            return collection;
        }
        //public LocalizationTextReousrceCollection SearchLoca
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concision
{
    public partial class LocalizationTextReousrceCollection
    {
        /// <summary>
        /// 默认的本地化文本资源集合
        /// </summary>
        public static LocalizationTextReousrceCollection Default
        {
            get;
        } = new LocalizationTextReousrceCollection
        {
            LanguageCulture = "zh-CN",

            //请在此处按格式添加新的文本对
            //注意！如果文本对Key重复，则会使用新的Value覆盖旧Value
            Pairs = new TextPair[]
            {
                new TextPair("font","字体"),
                new TextPair("forecolor","正常状态时的前景色"),
                new TextPair("is_waiting","是否处于等待状态")
            }
        };
    }
}

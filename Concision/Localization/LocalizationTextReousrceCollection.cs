using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Concision
{
    /// <summary>
    /// 表示一组本地化的资源文本
    /// </summary>
    [XmlRoot("localization")]
    public partial class LocalizationTextReousrceCollection
    {
        [XmlElement("languageCulture")]
        public String LanguageCulture { get; set; }
        [XmlArray("textPairs")]
        public TextPair[] Pairs { get; set; }
    }
    /// <summary>
    /// 文本对
    /// </summary>
    [XmlType("pair")]
    public class TextPair
    {
        [XmlAttribute("key")]
        public String Key { get; set; }
        [XmlAttribute("value")]
        public String Value { get; set; }
        public TextPair(String key, String value)
        {
            this.Key = key;
            this.Value = value;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Concision
{
    public static class StringExtension
    {
        /*********************/
        /// <summary>
        /// 判断字符串是空引用或者是空字符串
        /// </summary>
        public static Boolean IsNullOrEmpty(this String str)
        {
            return String.IsNullOrEmpty(str);
        }
        /// <summary>
        /// 判断字符串是空引用，或者完全是由空白字符组成的
        /// </summary>
        public static Boolean IsNullOrWhiteSpace(this String str)
        {
            return String.IsNullOrWhiteSpace(str);
        }
        /// <summary>
        /// 判断字符串是否完全由数字和小数点（一个）构成
        /// </summary>
        public static Boolean IsNumeric(this String str)
        {
            return Regex.IsMatch(str, @"^[+-]?\d*[.]?\d*$");
        }
        /// <summary>
        ///  判断字符串是否是一个合法的中国大陆身份证号码
        /// </summary>
        public static Boolean IsIdCardNumber(this String str)
        {
            return Regex.IsMatch(str, @"\d{17}[Xx\d]");
        }
        /// <summary>
        ///  判断字符串是否是一个合法的中国大陆手机号码
        /// </summary>
        public static Boolean IsMobileNumber(this String str)
        {
            return Regex.IsMatch(str, @"\d{11}");
        }
        /// <summary>
        ///  判断字符串是否是一个合法的中国大陆电话号码
        /// </summary>
        public static Boolean IsPhoneNumber(this String str)
        {
            return Regex.IsMatch(str, @"\d{4}-?\d{7}");
        }
    }
}

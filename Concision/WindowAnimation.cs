using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Concision
{
    /// <summary>
    /// 窗体动画类
    /// </summary>
    [TypeConverter(typeof(WindowAnimationTypeConverter))]
    public class WindowAnimation
    {
        /// <summary>
        /// 显示标志位
        /// </summary>
        public static Int32 ShowFlag { get; private set; } = Win32Constants.AW_ACTIVATE;
        /// <summary>
        /// 隐藏标志位
        /// </summary>
        public static Int32 HideFlag { get; private set; } = Win32Constants.AW_HIDE;
        /************/
        /// <summary>
        /// 是否开启窗体动画
        /// </summary>
        [Description("是否开启窗体动画，默认开启")]
        public Boolean Enabled { get; set; }
        /// <summary>
        /// 窗体动画效果的持续时间，单位：us，默认 200 us。
        /// </summary>
        [Description("窗体动画效果的持续时间，单位：us，默认 200 us。")]
        public Int32 AnimationTime { get; set; }
        /// <summary>
        /// 窗体显示时动画的类型
        /// </summary>
        [Description("窗体显示时动画的类型")]
        public WindowAnimationStyle ShowEffect { get; set; }

        /// <summary>
        /// 窗体隐藏时动画的类型
        /// </summary>
        [Description("窗体隐藏时动画的类型")]
        public WindowAnimationStyle HideEffect
        {
            get
            {
                return _hideEffect;
            }
            set
            {
                this._hideEffect = value;
            }
        }
        private WindowAnimationStyle _hideEffect = WindowAnimationStyle.Fade;

        public WindowAnimation(Boolean enbaled = true,
            Int32 animationTime = 200,
            WindowAnimationStyle showEffect = WindowAnimationStyle.Center,
            WindowAnimationStyle hideEffect = WindowAnimationStyle.Fade
            )
        {
            this.Enabled = enbaled;
            this.AnimationTime = animationTime;
            this.ShowEffect = showEffect;
            this.HideEffect = hideEffect;
        }
        public Int32 ShowAnimationFlag()
        {
            return (Int32)this.ShowEffect | ShowFlag;
        }
        public Int32 HideAnimationFlag()
        {
            return (Int32)this.HideEffect | HideFlag;
        }
    }
    /// <summary>
    /// 窗体动画风格
    /// </summary>
    public enum WindowAnimationStyle
    {

        /// <summary>
        /// 自左往右滑动
        /// </summary>
        LeftToRight = Win32Constants.AW_SLIDE | Win32Constants.AW_HOR_POSITIVE,
        /// <summary>
        /// 自右往左滑动
        /// </summary>
        RightToLeft = Win32Constants.AW_SLIDE | Win32Constants.AW_HOR_NEGATIVE,
        /// <summary>
        /// 淡入淡出效果
        /// </summary>
        Fade = Win32Constants.AW_BLEND,
        /// <summary>
        ///扩散
        /// </summary>
        Center = Win32Constants.AW_CENTER,
        /// <summary>
        /// 自上而下滑动
        /// </summary>
        TopToBottom = Win32Constants.AW_SLIDE | Win32Constants.AW_VER_POSITIVE,
        /// <summary>
        /// 自下而上滑动
        /// </summary>
        BottomToTop = Win32Constants.AW_SLIDE | Win32Constants.AW_VER_NEGATIVE

    }
    public class WindowAnimationTypeConverter : TypeConverter
    {
        private const String SplitSymbol = ",";

        public WindowAnimationTypeConverter() { }
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, Object value, Attribute[] attributes)
        {
            string[] names = new string[] {
                nameof(WindowAnimation.Enabled),
                nameof(WindowAnimation.AnimationTime),
                nameof(WindowAnimation.ShowEffect) ,
            nameof(WindowAnimation.HideEffect)};
            return TypeDescriptor.GetProperties(typeof(WindowAnimation), attributes).Sort(names);
        }

        public override Boolean GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public override Boolean CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(String))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }
        public override object ConvertFrom(
     ITypeDescriptorContext context,
     System.Globalization.CultureInfo culture, object value)
        {
            String str = value as String;
            if (str != null)
            {
                Regex regex = new Regex(SplitSymbol);
                String[] propertyValues = regex.Split(str);
                if (propertyValues.Length < 4)
                {
                    throw new ArgumentException("Invalid parameter format");
                }
                Boolean enabled = Boolean.Parse(propertyValues[0]);
                Int32 animationTime = Int32.Parse(propertyValues[1]);
                Type enumType = typeof(WindowAnimationStyle);
                WindowAnimationStyle showEffect = (WindowAnimationStyle)Enum.Parse(enumType, propertyValues[2]);
                WindowAnimationStyle hideEffect = (WindowAnimationStyle)Enum.Parse(enumType, propertyValues[3]);
                return new WindowAnimation(enabled, animationTime, showEffect, hideEffect);
            }
            return base.ConvertFrom(context, culture, value);
        }

        public override Boolean CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(InstanceDescriptor))
            {
                return true;
            }
            if (destinationType == typeof(String))
            {
         
                return true;
            }

            return base.CanConvertTo(context, destinationType);
        }
        public override object ConvertTo(
        ITypeDescriptorContext context,
        System.Globalization.CultureInfo culture,
        object value, Type destinationType)
        {

            WindowAnimation animation = value as WindowAnimation;
            if (animation == null)
            {
                return null;
            }

            if (destinationType == typeof(String))
            {
                return $"{animation.Enabled}{SplitSymbol}{animation.AnimationTime}{SplitSymbol}{animation.ShowEffect.ToString()}{SplitSymbol}{animation.HideEffect.ToString()}";
            }
            if (destinationType == typeof(InstanceDescriptor))
            {
                ConstructorInfo ci = typeof(WindowAnimation).GetConstructor(
                  new Type[] { typeof(Boolean), typeof(Int32), typeof(WindowAnimationStyle), typeof(WindowAnimationStyle) });
                return new InstanceDescriptor(ci, new Object[] { animation.Enabled, animation.AnimationTime, animation.ShowEffect,
                animation.HideEffect});
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}

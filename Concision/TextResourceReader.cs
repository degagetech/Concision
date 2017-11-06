using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.Concurrent;
using System.IO;
using System.Threading;
using System.Reflection;
namespace Concision
{
    public class TextResourceReader : Component
    {
        /// <summary>
        /// 获取<see cref="TextResourceReader"/>的实例
        /// </summary>
        public static TextResourceReader Instance { get; set; } = new TextResourceReader();


        /*****************/
        private Dictionary<String, String> _textResoucePairDic = new Dictionary<String, String>();
        private SpinLock _spinLock = new SpinLock();

        /// <summary>
        /// 获取<see cref="TextResourceReader"/> 对象使用的 <see cref="LocalizationTextReousrceCollection"/> 资源实例
        /// </summary>
        public LocalizationTextReousrceCollection TextReousrceCollection { get; private set; }
        public TextResourceReader()
        {
            this.InitlizeReader(LocalizationTextReousrceCollection.Default);
        }
        public TextResourceReader(LocalizationTextReousrceCollection textReousrceCollection)
        {
            this.InitlizeReader(textReousrceCollection);
        }
        /// <summary>
        /// 初始化 <see cref="TextResourceReader"/> 实例，
        /// 并将 <see cref="LocalizationTextReousrceCollection"/>对象中的文本资源加载到对象中
        /// </summary>
        /// <param name="textReousrceCollection"></param>
        protected virtual void InitlizeReader(LocalizationTextReousrceCollection textReousrceCollection)
        {
            foreach (TextPair pair in textReousrceCollection.Pairs)
            {
                this.Add(pair.Key, pair.Value);
            }
            this.TextReousrceCollection = textReousrceCollection;
        }
        /// <summary>
        ///索引器-获取指定的Key对应的文本
        /// </summary>
        public String this[String key]
        {
            get
            {
                String text = null;
                if (this._textResoucePairDic.ContainsKey(key))
                {
                    text = this._textResoucePairDic[key];
                }
                return text;
            }
        }
        /// <summary>
        /// 添加一对文本资源，若存在相同Key的资源则更新，
        /// 此方法使用自旋锁，提供一定程度的线程安全
        /// </summary>
        /// <param name="key">文本资源的Key</param>
        /// <param name="value">文本资源的Value</param>
        public void Add(String key, String value)
        {
            Boolean lockTaken = false;
            try
            {
                this._spinLock.Enter(ref lockTaken);
                if (this._textResoucePairDic.ContainsKey(key))
                {
                    this._textResoucePairDic[key] = value;
                }
                else
                {
                    this._textResoucePairDic.Add(key, value);
                }
            }
            finally
            {
                if (lockTaken) this._spinLock.Exit();
            }
        }
    }
}

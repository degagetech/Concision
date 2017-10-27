using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
namespace Concision
{
    /// <summary>
    ///工具类：对象的XML序列化与反序列化
    /// </summary>
    public class TKXmlSerializer
    {
        /// <summary>
        /// 将文件列表反序列化成对象集合
        /// </summary>
        public static IEnumerable<T> Load<T>(params String[] files) where T : class
        {
            foreach (String file in files)
            {
                if (!File.Exists(file)) break;
                T schema = null;
                try
                {
                    schema = TKXmlSerializer.DeSerialize<T>(file);
                }
                catch
                {

                }
                if (schema != null) yield return schema;
            }
        }
        /// <summary>
        /// 搜索指定目录下符合指定格式的文件，并反序列化
        /// </summary>
        /// <param name="pattern">文件名称格式，例如 *.txt</param>
        /// <param name="directory">指定的目录</param>
        public static IEnumerable<T> Search<T>(String pattern, String directory = null) where T : class
        {
            directory = directory ?? AppDomain.CurrentDomain.BaseDirectory;
            var files = Directory.GetFiles(directory, pattern);
            return Load<T>(files);
        }
        /// <summary>
        /// 将对象序列化到文件中，此函数会创建一个新的文件，或者覆盖现有文件中的内容
        /// 而不是先现有文件追加
        /// </summary>
        /// <typeparam name="T">对象的类型</typeparam>
        /// <param name="obj">被序列化的对象</param>
        /// <param name="file">文件路径</param>
        public static void Serialize<T>(T obj, String file) where T : class
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (FileStream stream = new FileStream(
                  file,
                  FileMode.Open | FileMode.Truncate, FileAccess.Write, FileShare.Read,
                  8096,
                  FileOptions.WriteThrough))
            {
                TextWriter writer = new StreamWriter(stream);
                xmlSerializer.Serialize(writer, obj);
            }
        }
        /// <summary>
        /// 从含有类结构信息的文件中反序列化出实例
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="file">文件路径</param>
        /// <returns>实例</returns>
        public static T DeSerialize<T>(String file) where T : class
        {
            T obj = null;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (FileStream stream = new FileStream(file, FileMode.Open, FileAccess.Read))
            {
                obj = xmlSerializer.Deserialize(stream) as T;
            }
            return obj;
        }
    }
}

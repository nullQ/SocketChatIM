using System.Web.Script.Serialization;

namespace Chat.Common
{
    /// <summary>
    /// JSON组件
    /// </summary>
    public static class JSON
    {
        /// <summary>
        /// 将对象转换成JSON字符串
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string EncodeObject(object o)
        {
            return new JavaScriptSerializer().Serialize(o);
        }
        /// <summary>
        /// 将JSON字符串转换成对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T DecodeObject<T>(string json)
        {
            return new JavaScriptSerializer().Deserialize<T>(json);
        }
    }
}
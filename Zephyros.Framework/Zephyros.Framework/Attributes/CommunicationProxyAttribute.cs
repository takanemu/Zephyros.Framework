
namespace Zephyros.Framework.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class CommunicationProxyAttribute : System.Attribute
    {
        /// <summary>
        /// 属性パラメーター
        /// </summary>
        public object Key { get; set; }
    }
}

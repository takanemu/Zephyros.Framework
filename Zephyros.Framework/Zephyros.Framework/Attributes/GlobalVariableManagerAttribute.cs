
namespace Zephyros.Framework.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class GlobalVariableManagerAttribute : System.Attribute
    {
        /// <summary>
        /// 属性パラメーター<br/>
        /// </summary>
        public object Key { get; set; }
    }
}

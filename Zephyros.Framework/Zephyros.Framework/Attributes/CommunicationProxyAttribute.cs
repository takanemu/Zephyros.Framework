using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Zephyros.Framework.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class CommunicationProxyAttribute : System.Attribute
    {
        /// <summary>
        /// 属性パラメーター<br/>
        /// </summary>
        public object Key { get; set; }

        public static Enum GetDataKey(MethodInfo minfo)
        {
            CommunicationProxyAttribute[] items = (CommunicationProxyAttribute[])minfo.GetCustomAttributes(typeof(CommunicationProxyAttribute), false);

            if (items.Length == 0)
            {
                return null;
            }
            CommunicationProxyAttribute my = (CommunicationProxyAttribute)items[0];

            return (Enum)my.Key;
        }
    }
}

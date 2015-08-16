using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Zephyros.Framework.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class GlobalVariableManagerAttribute : System.Attribute
    {
        /// <summary>
        /// 属性パラメーター<br/>
        /// </summary>
        public object Key { get; set; }

        public static Enum GetDataKey(MethodInfo minfo)
        {
            GlobalVariableManagerAttribute[] items = (GlobalVariableManagerAttribute[])minfo.GetCustomAttributes(typeof(GlobalVariableManagerAttribute), false);

            if (items.Length == 0)
            {
                return null;
            }
            GlobalVariableManagerAttribute my = (GlobalVariableManagerAttribute)items[0];

            return (Enum)my.Key;
        }
    }
}

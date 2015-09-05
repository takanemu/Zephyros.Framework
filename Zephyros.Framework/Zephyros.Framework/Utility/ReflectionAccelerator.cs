
namespace Zephyros.Framework.Utility
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    /// <summary>
    /// Reflectionキャッシュクラス
    /// </summary>
    public class ReflectionAccelerator
    {
        /// <summary>
        /// メソッド配列マップ
        /// </summary>
        private static Dictionary<Type, MethodInfo[]> methods_map;

        /// <summary>
        /// メソッド配列取得
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static MethodInfo[] GetMethods(Type type)
        {
            if(methods_map == null)
            {
                methods_map = new Dictionary<Type, MethodInfo[]>();
            }
            MethodInfo[] result;

            if (!methods_map.TryGetValue(type, out result))
            {
                result = type.GetMethods();

                methods_map.Add(type, result);
            }
            return result;
        }
    }
}

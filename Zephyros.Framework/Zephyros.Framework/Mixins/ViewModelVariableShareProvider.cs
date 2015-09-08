
namespace Zephyros.Framework.Mixins
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using Zephyros.Framework.Attributes;
    using Zephyros.Framework.EventArgs;
    using Zephyros.Framework.Interfaces;
    using Zephyros.Framework.Utility;

    public static class ViewModelVariableShareProvider
    {
        internal delegate void VariableChangeDelegate(VariableChangeEventArgs args);
        static ConditionalWeakTable<MViewModelVariableShareProvider, Fields> table;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        static ViewModelVariableShareProvider()
        {
            table = new ConditionalWeakTable<MViewModelVariableShareProvider, Fields>();
        }

        private sealed class Fields
        {
            internal Dictionary<int, VariableChangeDelegate> DelegateMap = new Dictionary<int, VariableChangeDelegate>();
        }

        public static void Construction(this MViewModelVariableShareProvider map, object target)
        {
            Type type = target.GetType();
            MethodInfo[] methods = ReflectionAccelerator.GetMethods(type);

            foreach (MethodInfo method in methods)
            {
                if (method.IsDefined(typeof(GlobalVariableManagerAttribute), false))
                {
                    Enum ekey = (Enum)GetDataKey(method);

                    if (ekey != null)
                    {
                        var dmap = table.GetOrCreateValue(map).DelegateMap;

                        int index = Convert.ToInt32(ekey);

                        if (!dmap.ContainsKey(index))
                        {
                            var dg = (VariableChangeDelegate)Delegate.CreateDelegate(typeof(VariableChangeDelegate), target, method);

                            // デリゲートとして登録
                            dmap.Add(index, dg);
                        }
                    }
                }
            }
        }

        public static object GetDataKey(MethodInfo minfo)
        {
            var items = (GlobalVariableManagerAttribute[])minfo.GetCustomAttributes(typeof(GlobalVariableManagerAttribute), false);

            if (items.Length > 0)
            {
                return items[0].Key;
            }
            return null;
        }

        public static void CallFunction(this MViewModelVariableShareProvider map, VariableChangeEventArgs args)
        {
            var dmap = table.GetOrCreateValue(map).DelegateMap;

            VariableChangeDelegate dg;

            if (dmap.TryGetValue(args.Key, out dg))
            {
                dg(args);
            }
        }
    }
}

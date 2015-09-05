
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
            internal Dictionary<Enum, VariableChangeDelegate> DelegateMap = new Dictionary<Enum, VariableChangeDelegate>();
        }

        public static void Construction(this MViewModelVariableShareProvider map, object target)
        {
            Type type = target.GetType();
            MethodInfo[] methods = ReflectionAccelerator.GetMethods(type);

            foreach (MethodInfo method in methods)
            {
                if (method.IsDefined(typeof(GlobalVariableManagerAttribute), false))
                {
                    Enum ekey = GetDataKey(method);

                    if (ekey != null)
                    {
                        var dmap = table.GetOrCreateValue(map).DelegateMap;

                        if (!dmap.ContainsKey(ekey))
                        {
                            var dg = (VariableChangeDelegate)Delegate.CreateDelegate(typeof(VariableChangeDelegate), target, method);

                            // デリゲートとして登録
                            dmap.Add(ekey, dg);
                        }
                    }
                }
            }
        }

        public static Enum GetDataKey(MethodInfo minfo)
        {
            var items = (GlobalVariableManagerAttribute[])minfo.GetCustomAttributes(typeof(GlobalVariableManagerAttribute), false);

            if (items.Length == 0)
            {
                return null;
            }
            GlobalVariableManagerAttribute my = (GlobalVariableManagerAttribute)items[0];

            return (Enum)my.Key;
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

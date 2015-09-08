
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

    public static class ViewModelCommunicationProvider
    {
        internal delegate void CommunicationProxyDelegate(MessageReceiveEventArgs args);
        static ConditionalWeakTable<MViewModelCommunicationProvider, Fields> table;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        static ViewModelCommunicationProvider()
        {
            table = new ConditionalWeakTable<MViewModelCommunicationProvider, Fields>();
        }

        private sealed class Fields
        {
            internal Dictionary<int, CommunicationProxyDelegate> DelegateMap = new Dictionary<int, CommunicationProxyDelegate>();
        }

        public static void Construction(this MViewModelCommunicationProvider map, object target)
        {
            Type type = target.GetType();
            MethodInfo[] methods = ReflectionAccelerator.GetMethods(type);

            foreach (MethodInfo method in methods)
            {
                if (method.IsDefined(typeof(CommunicationProxyAttribute), false))
                {
                    Enum ekey = (Enum)GetDataKey(method);

                    if (ekey != null)
                    {
                        int index = Convert.ToInt32(ekey);

                        var dmap = table.GetOrCreateValue(map).DelegateMap;

                        if (!dmap.ContainsKey(index))
                        {
                            var dg = (CommunicationProxyDelegate)Delegate.CreateDelegate(typeof(CommunicationProxyDelegate), target, method);

                            // デリゲートとして登録
                            dmap.Add(index, dg);
                        }
                    }
                }
            }
        }

        public static object GetDataKey(MethodInfo minfo)
        {
            var items = (CommunicationProxyAttribute[])minfo.GetCustomAttributes(typeof(CommunicationProxyAttribute), false);

            if(items.Length > 0)
            {
                return items[0].Key;
            }
            return null;
        }

        public static void CallFunction(this MViewModelCommunicationProvider map, MessageReceiveEventArgs args)
        {
            var dmap = table.GetOrCreateValue(map).DelegateMap;

            CommunicationProxyDelegate dg;

            if (dmap.TryGetValue(args.Address, out dg))
            {
                dg(args);
            }
        }
    }
}

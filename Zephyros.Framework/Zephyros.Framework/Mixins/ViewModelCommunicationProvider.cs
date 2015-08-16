using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Zephyros.Framework.Attributes;
using Zephyros.Framework.EventArgs;
using Zephyros.Framework.Interfaces;
using Zephyros.Framework.Manager;

namespace Zephyros.Framework.Mixins
{
    public static class ViewModelCommunicationProvider
    {
        internal delegate void CommunicationProxyDelegate(MessageReceiveEventArgs args);
        static ConditionalWeakTable<MViewModelCommunicationProvider, Fields> table;

        static ViewModelCommunicationProvider()
        {
            table = new ConditionalWeakTable<MViewModelCommunicationProvider, Fields>();
        }

        private sealed class Fields
        {
            internal Dictionary<Enum, CommunicationProxyDelegate> DelegateMap = new Dictionary<Enum, CommunicationProxyDelegate>();
        }

        public static void Construction(this MViewModelCommunicationProvider map, object target)
        {
            Type type = target.GetType();
            MethodInfo[] methods = type.GetMethods();

            foreach (MethodInfo method in methods)
            {
                if (method.IsDefined(typeof(CommunicationProxyAttribute), false))
                {
                    // 検査キーを取得する
                    Enum ekey = CommunicationProxyAttribute.GetDataKey(method);

                    // ekeyの更新があった時だけ更新イベントを返す
                    if (ekey != null)
                    {
                        var dmap = table.GetOrCreateValue(map).DelegateMap;

                        if (!dmap.ContainsKey(ekey))
                        {
                            var dg = (CommunicationProxyDelegate)Delegate.CreateDelegate(typeof(CommunicationProxyDelegate), target, method);

                            dmap.Add(ekey, dg);
                        }
                    }
                }
            }
        }

        public static void CallFunction(this MViewModelCommunicationProvider map, MessageReceiveEventArgs args)
        {
            var dmap = table.GetOrCreateValue(map).DelegateMap;

            if (dmap.ContainsKey(args.Address))
            {
                CommunicationProxyDelegate dg;

                if (dmap.TryGetValue(args.Address, out dg))
                {
                    dg(args);
                }
            }
        }
    }
}

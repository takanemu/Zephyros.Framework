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

namespace Zephyros.Framework.Mixins
{
    public static class ViewModelVariableShareProvider
    {
        internal delegate void VariableChangeDelegate(VariableChangeEventArgs args);
        static ConditionalWeakTable<MViewModelVariableShareProvider, Fields> table;

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
            MethodInfo[] methods = type.GetMethods();

            foreach (MethodInfo method in methods)
            {
                if (method.IsDefined(typeof(GlobalVariableManagerAttribute), false))
                {
                    // 検査キーを取得する
                    Enum ekey = GlobalVariableManagerAttribute.GetDataKey(method);

                    // ekeyの更新があった時だけ更新イベントを返す
                    if (ekey != null)
                    {
                        var dmap = table.GetOrCreateValue(map).DelegateMap;

                        if (!dmap.ContainsKey(ekey))
                        {
                            var dg = (VariableChangeDelegate)Delegate.CreateDelegate(typeof(VariableChangeDelegate), target, method);

                            dmap.Add(ekey, dg);
                        }
                    }
                }
            }
        }

        public static void CallFunction(this MViewModelVariableShareProvider map, VariableChangeEventArgs args)
        {
            var dmap = table.GetOrCreateValue(map).DelegateMap;

            if (dmap.ContainsKey(args.Key))
            {
                VariableChangeDelegate dg;

                if (dmap.TryGetValue(args.Key, out dg))
                {
                    dg(args);
                }
            }
        }
    }
}

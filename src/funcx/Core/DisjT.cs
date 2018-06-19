using FunctionalLibrary.Collections.Internal;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class DisjT :
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunctionParams<object, object, object, object>
    {
        public object Invoke(object set) => set;
        public object Invoke(object set, object key) => ((ITransientSet)set).Disjoin(key);
        public object Invoke(object set, object key, params object[] ks)
        {
            var ret = ((ITransientSet)set).Disjoin(key);
            if ((bool)new Truthy().Invoke(ks))
            {
                return Invoke(ret, new First().Invoke(ks), new Next().Invoke(ks));
            }

            return ret;
        }
    }
}

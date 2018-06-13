using FunctionalLibrary.Collections;
using System;
using System.Linq;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Disj :
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunctionParams<object, object, object, object>
    {
        public object Invoke(object set) => set;
        public object Invoke(object set, object key) => 
            set is ISet s 
                ? s.Disj(key)
                : throw new InvalidCastException($"{set.GetType().FullName} cannot be casted to {typeof(ISet).FullName}");

        public object Invoke(object set, object key, params object[] ks)
        {
            if (set == null) return null;

            var ret = Invoke(set, key);
            var next = new Next().Invoke(ks);
            if (next != null)
                return Invoke(ret, new First().Invoke(ks), next);

            return ret;
        }
    }
}

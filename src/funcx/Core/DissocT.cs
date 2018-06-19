using FunctionalLibrary.Collections.Internal;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class DissocT :
        IFunction<object, object, object>,
        IFunctionParams<object, object, object, object>
    {
        public object Invoke(object map, object key) =>
            ((ITransientMap)map).Without(key);
        public object Invoke(object map, object key, params object[] ks)
        {
            var ret = ((ITransientMap)map).Without(key);

            if ((bool)new Truthy().Invoke(ks))
                return Invoke(ret, new First().Invoke(ks), new Next().Invoke(ks));

            return ret;
        }
    }
}

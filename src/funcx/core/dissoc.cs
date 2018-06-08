using FunctionalLibrary.Collections;
using System;
using System.Linq;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Dissoc :
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunctionParams<object, object, object, object>
    {
        public object Invoke(object map) => map;
        public object Invoke(object map, object key) => map == null ? null : ((IMap)map).Without(key);
        public object Invoke(object map, object key, params object[] ks)
        {
            var ret = Invoke(map, key);
            if (ks.Length > 0)
                return Invoke(ret, new First().Invoke(ks), (object[])new ToArray().Invoke(new Next().Invoke(ks)));

            return ret;
        }
    }
}

using FunctionalLibrary.Collections;
using FunctionalLibrary.Collections.Internal;
using System;
using System.Linq;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Assoc :
        IFunction<object, object, object, object>,
        IFunctionParams<object, object, object, object, object>
    {
        public object Invoke(object map, object key, object val)
        {
            if (map == null)
                return new ArrayMap().Invoke(key, val);

            return ((IAssociative)map).Assoc(key, val);
        }

        public object Invoke(object map, object key, object val, params object[] kvs)
        {
            var ret = Invoke(map, key, val);
            if (kvs.Count() % 2 == 0)
            {
                var nnext = new NNext().Invoke(kvs);
                if (nnext == null)
                    return Invoke(ret, new First().Invoke(kvs), new Second().Invoke(kvs));
                else
                    return Invoke(ret, new First().Invoke(kvs), new Second().Invoke(kvs), (object[])new ToArray().Invoke(nnext));
            }
            else
                throw new ArgumentException($"{nameof(Assoc)} expects an even number of arguments.");
        }
    }
}

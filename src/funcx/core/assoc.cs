using FunctionalLibrary.Collections;
using System;
using System.Linq;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Assoc :
        IFunction<IAssociative, object, object, IAssociative>,
        IFunctionParams<IAssociative, object, object, object, IAssociative>
    {
        public IAssociative Invoke(IAssociative map, object key, object val)
        {
            if (map == null)
                return new ArrayMap(new object[] { key, val });

            return map.Assoc(key, val);
        }
        public IAssociative Invoke(IAssociative map, object key, object val, params object[] kvs)
        {
            var ret = Invoke(map, key, val);
            if (kvs.Count() > 0)
            {
                var next = new Core.Next().Invoke(kvs);
                if (next != null)
                {
                    return Invoke(ret, new First().Invoke(kvs), new Second().Invoke(kvs), new NNext().Invoke(kvs));
                }
                else
                    throw new ArgumentException($"{nameof(Assoc)} expects an even number of arguments.");
            }
            return ret;
        }
    }
}

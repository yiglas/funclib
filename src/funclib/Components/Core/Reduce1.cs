using funclib.Collections;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Components.Core
{
    class Reduce1 :
        IFunction<object, object, object>,
        IFunction<object, object, object, object>
    {
        public object Invoke(object f, object coll)
        {
            var s = seq(coll);
            if ((bool)truthy(s))
                return Invoke(f, first(s), next(s));
            else
                return invoke(f);
        }
        public object Invoke(object f, object val, object coll)
        {
            var s = seq(coll);

            if ((bool)truthy(s))
            {
                if ((bool)isChunkedSeq(s))
                    return Invoke(f, ((IChunked)chunkFirst(s)).Reduce(f, val), chunkNext(s));
                else
                    return Invoke(f, invoke(f, val, first(s)), next(s));
            }

            return val;
        }
    }
}

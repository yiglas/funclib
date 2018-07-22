using funclib.Collections;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    class Reduce1 :
        IFunction<object, object, object>,
        IFunction<object, object, object, object>
    {
        public object Invoke(object f, object coll)
        {
            var s = (ISeq)new Seq().Invoke(coll);
            if ((bool)new Truthy().Invoke(s))
                return Invoke(f, s.First(), s.Next());
            else
                return ((IFunction<object>)f).Invoke();
        }
        public object Invoke(object f, object val, object coll)
        {
            var s = (ISeq)new Seq().Invoke(coll);

            if ((bool)new Truthy().Invoke(s))
            {
                if ((bool)new IsChunkedSeq().Invoke(s))
                    return Invoke(f, ((IChunked)chunkFirst(s)).Reduce((IFunction<object, object, object>)f, val), chunkNext(s));
                else
                    return Invoke(f, ((IFunction<object, object, object>)f).Invoke(val, first(s)), new Next().Invoke(s));
            }

            return val;
        }
    }
}

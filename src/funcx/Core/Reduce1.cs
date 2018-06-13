using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
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
                    return Invoke(f, ((IChunked)new ChunkFirst().Invoke(s)).Reduce((IFunction<object, object, object>)f, val), new ChunkNext().Invoke(s));
                else
                    return Invoke(f, ((IFunction<object, object, object>)f).Invoke(val, new First().Invoke(s)), new Next().Invoke(s));
            }

            return val;
        }
    }
}

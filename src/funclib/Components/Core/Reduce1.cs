using funclib.Collections;
using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    class Reduce1 :
        IFunction<object, object, object>,
        IFunction<object, object, object, object>
    {
        public object Invoke(object f, object coll)
        {
            var s = funclib.Core.Seq(coll);
            if (funclib.Core.T(s))
                return Invoke(f, funclib.Core.First(s), funclib.Core.Next(s));
            else
                return funclib.Core.Invoke(f);
        }
        public object Invoke(object f, object val, object coll)
        {
            var s = funclib.Core.Seq(coll);

            if (funclib.Core.T(s))
            {
                if ((bool)funclib.Core.IsChunkedSeq(s))
                    return Invoke(f, ((IChunked)funclib.Core.ChunkFirst(s)).Reduce(f, val), funclib.Core.ChunkNext(s));
                else
                    return Invoke(f, funclib.Core.Invoke(f, val, funclib.Core.First(s)), funclib.Core.Next(s));
            }

            return val;
        }
    }
}

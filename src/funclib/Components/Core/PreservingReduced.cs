using System;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    class PreservingReduced :
        IFunction<object, object>
    {
        public object Invoke(object rf) =>
            new Function<object, object, object>((_1, _2) =>
            {
                var ret = ((IFunction<object, object, object>)rf).Invoke(_1, _2);
                if ((bool)isReduced(ret))
                    return reduced(ret);
                return ret;
            });
    }
}

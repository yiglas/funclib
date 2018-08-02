using funclib.Components.Core.Generic;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Components.Core
{
    class PreservingReduced :
        IFunction<object, object>
    {
        public object Invoke(object rf) =>
            func((object _1, object _2) =>
            {
                var ret = invoke(rf, _1, _2);
                if ((bool)isReduced(ret))
                    return reduced(ret);
                return ret;
            });
    }
}

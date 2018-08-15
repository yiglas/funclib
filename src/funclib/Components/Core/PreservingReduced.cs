using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    class PreservingReduced :
        IFunction<object, object>
    {
        public object Invoke(object rf) =>
            funclib.Core.Func((_1, _2) =>
            {
                var ret = funclib.Core.Invoke(rf, _1, _2);
                if ((bool)funclib.Core.IsReduced(ret))
                    return funclib.Core.Reduced(ret);
                return ret;
            });
    }
}

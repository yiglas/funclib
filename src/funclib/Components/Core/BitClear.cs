using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    public class BitClear :
        IFunction<object, object, object>
    {
        public object Invoke(object x, object n) => Numbers.ClearBit(x, n);
    }
}

using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    public class UnsignedBitShiftRight:
        IFunction<object, object, object>
    {
        public object Invoke(object x, object n) => Numbers.UnsignedShiftRight(x, n);
    }
}

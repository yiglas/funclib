using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    public class BitShiftRight :
        IFunction<object, object, object>
    {
        public object Invoke(object x, object n) => Numbers.ShiftRight(x, n);
    }
}

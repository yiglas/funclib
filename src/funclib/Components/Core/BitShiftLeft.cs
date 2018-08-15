using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    public class BitShiftLeft :
        IFunction<object, object, object>
    {
        public object Invoke(object x, object n) => Numbers.ShiftLeft(x, n);
    }
}

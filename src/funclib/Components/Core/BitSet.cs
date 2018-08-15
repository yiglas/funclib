using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    public class BitSet :
        IFunction<object, object, object>
    {
        public object Invoke(object x, object n) => Numbers.SetBit(x, n);
    }
}

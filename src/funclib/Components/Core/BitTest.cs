using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    public class BitTest :
        IFunction<object, object, object>
    {
        public object Invoke(object x, object n) => Numbers.TestBit(x, n);
    }
}

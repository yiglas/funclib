using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    public class BitNot :
        IFunction<object, object>
    {
        public object Invoke(object x) => Numbers.Not(x);
    }
}

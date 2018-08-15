using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    public class BitXOr :
        IFunction<object, object, object>,
        IFunctionParams<object, object, object, object>
    {
        public object Invoke(object x, object y) => Numbers.XOr(x, y);
        public object Invoke(object x, object y, params object[] more) => funclib.Core.Reduce1(this, Invoke(x, y), more);
    }
}

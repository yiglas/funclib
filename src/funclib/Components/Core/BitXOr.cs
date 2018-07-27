using System;
using System.Collections.Generic;
using System.Text;
using static funclib.core;

namespace funclib.Components.Core
{
    public class BitXOr :
        IFunction<object, object, object>,
        IFunctionParams<object, object, object, object>
    {
        public object Invoke(object x, object y) => Numbers.XOr(x, y);
        public object Invoke(object x, object y, params object[] more) => reduce1(this, Invoke(x, y), more);
    }
}

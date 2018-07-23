using System;
using System.Collections.Generic;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    public class BitAndNot :
        IFunction<object, object, object>,
        IFunctionParams<object, object, object, object>
    {
        public object Invoke(object x, object y) => Numbers.AndNot(x, y);
        public object Invoke(object x, object y, params object[] more) => reduce1(this, Invoke(x, y), more);
    }
}

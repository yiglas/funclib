using funclib.Components.Core.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Components.Core
{
    public class BitNot :
        IFunction<object, object>
    {
        public object Invoke(object x) => Numbers.Not(x);
    }
}

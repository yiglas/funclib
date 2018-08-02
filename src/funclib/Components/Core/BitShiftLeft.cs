using funclib.Components.Core.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Components.Core
{
    public class BitShiftLeft :
        IFunction<object, object, object>
    {
        public object Invoke(object x, object n) => Numbers.ShiftLeft(x, n);
    }
}

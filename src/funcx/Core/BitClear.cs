using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class BitClear :
        IFunction<object, object, object>
    {
        public object Invoke(object x, object n) => Numbers.ClearBit(x, n);
    }
}

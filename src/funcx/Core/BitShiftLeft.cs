using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class BitShiftLeft :
        IFunction<object, object, object>
    {
        public object Invoke(object x, object n) => Numbers.ShiftLeft(x, n);
    }
}

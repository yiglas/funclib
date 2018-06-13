using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class BitSet :
        IFunction<object, object, object>
    {
        public object Invoke(object x, object n) => Numbers.SetBit(x, n);
    }
}

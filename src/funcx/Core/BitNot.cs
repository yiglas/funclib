using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class BitNot :
        IFunction<object, object>
    {
        public object Invoke(object x) => Numbers.Not(x);
    }
}

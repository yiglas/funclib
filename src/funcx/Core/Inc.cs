using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Inc :
        IFunction<object, object>
    {
        public object Invoke(object x) => Numbers.Inc(x);
    }
}

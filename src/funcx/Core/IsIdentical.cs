using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class IsIdentical :
        IFunction<object, object, object>
    {
        public object Invoke(object x, object y) =>
            x is ValueType
                ? x.Equals(y)
                : x == y;
    }
}

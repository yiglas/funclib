using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class IsFalse :
        IFunction<object, object>
    {
        public object Invoke(object x) => new IsIdentical().Invoke(x, false);
    }
}

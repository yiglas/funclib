using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class IsNull :
        IFunction<object, object>
    {
        public object Invoke(object x) => new IsIdentical().Invoke(x, null);
    }
}

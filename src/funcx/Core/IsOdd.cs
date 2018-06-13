using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class IsOdd :
        IFunction<object, object>
    {
        public object Invoke(object n) => new Not().Invoke(new IsEven().Invoke(n));
    }
}

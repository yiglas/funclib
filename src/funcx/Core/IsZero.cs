using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class IsZero :
        IFunction<object, object>
    {
        public object Invoke(object n) => Number.Create(n).Value == 0;
    }
}

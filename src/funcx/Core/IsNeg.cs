using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class IsNeg :
        IFunction<object, object>
    {
        public object Invoke(object num) => Numbers.IsNeg(num);
    }
}

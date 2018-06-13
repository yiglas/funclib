using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class IsAny :
        IFunction<object, object>
    {
        public object Invoke(object x) => true;
    }
}

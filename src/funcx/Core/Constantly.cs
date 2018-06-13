using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Constantly :
        IFunction<object, object>
    {
        public object Invoke(object x) => new FunctionParams<object, object>(args => x);
    }
}

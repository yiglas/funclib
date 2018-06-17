using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class IsBoolean :
        IFunction<object, object>
    {
        public object Invoke(object x) => new IsInstance().Invoke(typeof(bool), x);
    }
}

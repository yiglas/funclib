using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class IsChar :
        IFunction<object, object>
    {
        public object Invoke(object x) => new IsInstance().Invoke(typeof(char), x);
    }
}

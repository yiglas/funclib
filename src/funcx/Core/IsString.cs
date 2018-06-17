using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class IsString :
        IFunction<object, object>
    {
        public object Invoke(object x) => new IsInstance().Invoke(typeof(string), x);
    }
}

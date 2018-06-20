using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class IsInstance :
        IFunction<object, object, object>
    {
        public object Invoke(object c, object x) => ((Type)c).IsInstanceOfType(x);
    }
}

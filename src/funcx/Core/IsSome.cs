using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class IsSome :
        IFunction<object, object>
    {
        public object Invoke(object x) => new Not().Invoke(new IsNull().Invoke(x));
    }
}

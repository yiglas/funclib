using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Class :
        IFunction<object, object>
    {
        public object Invoke(object x) =>
            x == null
                ? x
                : x.GetType();
    }
}

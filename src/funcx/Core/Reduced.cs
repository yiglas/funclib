using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Reduced :
        IFunction<object, object>
    {
        public object Invoke(object x) => new Collections.Reduced(x);
    }
}

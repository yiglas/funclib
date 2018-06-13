using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Not :
        IFunction<object, object>
    {
        public object Invoke(object x) => !(bool)new Truthy().Invoke(x);
    }
}

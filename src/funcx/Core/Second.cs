using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Second :
        IFunction<object, object>
    {
        public object Invoke(object x) => new First().Invoke(new Next().Invoke(x));
    }
}

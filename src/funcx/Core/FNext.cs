using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class FNext :
        IFunction<object, object>
    {
        public object Invoke(object x) => new First().Invoke(new Next().Invoke(x));
    }
}

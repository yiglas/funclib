using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class FFirst :
        IFunction<object, object>
    {
        public object Invoke(object x) => new First().Invoke(new First().Invoke(x));
    }
}

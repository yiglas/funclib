using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Repeat :
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        public object Invoke(object x) => Collections.Repeat.Create(x);
        public object Invoke(object n, object x) => Collections.Repeat.Create(Numbers.ConvertToLong(n), x);
    }
}

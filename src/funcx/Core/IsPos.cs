using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class IsPos :
        IFunction<object, object>
    {
        public object Invoke(object num) => Numbers.IsPos(num);
    }
}

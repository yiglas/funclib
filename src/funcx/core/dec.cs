using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Dec :
        IFunction<object, object>
    {
        public object Invoke(object x) => Numbers.Dec(x);
    }

}

using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Minus :
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunctionParams<object, object, object, object>
    {
        public object Invoke(object x) => Numbers.Negate(x);
        public object Invoke(object x, object y) => Numbers.Subtract(x, y);
        public object Invoke(object x, object y, params object[] more) => new Reduce1().Invoke(this, Invoke(x, y), more);
    }
}

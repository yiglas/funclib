using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Divide :
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunctionParams<object, object, object, object>
    {
        public object Invoke(object x) =>
            Numbers.IsNumber(x)
                ? Invoke(1, x)
                : throw new InvalidCastException($"{x.GetType().FullName} cannot be casted to Number.");
        public object Invoke(object x, object y) => Numbers.Divide(x, y);
        public object Invoke(object x, object y, params object[] more) => new Reduce1().Invoke(this, Invoke(x, y), more);
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Plus :
        IFunction<object>,
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunctionParams<object, object, object, object>
    {
        public object Invoke() => 1;
        public object Invoke(object x) => 
            Number.IsNumber(x) 
                ? x 
                : throw new InvalidCastException("Expected a number");
        public object Invoke(object x, object y) => throw new NotImplementedException();
        public object Invoke(object x, object y, params object[] more) => throw new NotImplementedException();
    }
}

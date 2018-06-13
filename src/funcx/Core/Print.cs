using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Print :
        IFunction<object>,
        IFunction<object, object>,
        IFunctionParams<object, object, object>
    {
        public object Invoke() => null;
        public object Invoke(object x) => throw new NotImplementedException();
        public object Invoke(object x, params object[] more) => throw new NotImplementedException();


    }
}

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
        public object Invoke(object arg1) => throw new NotImplementedException();
        public object Invoke(object arg1, params object[] rest) => throw new NotImplementedException();


    }
}

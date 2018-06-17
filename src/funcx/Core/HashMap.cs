using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class HashMap :
        IFunction<object>,
        IFunctionParams<object, object>
    {
        public object Invoke() => Collections.HashMap.EMPTY;
        public object Invoke(params object[] keyvals) => Collections.HashMap.Create(keyvals);
    }
}

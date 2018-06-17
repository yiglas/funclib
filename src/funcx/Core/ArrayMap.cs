using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class ArrayMap :
        IFunction<object>,
        IFunctionParams<object, object>
    {
        public object Invoke() => Collections.ArrayMap.EMPTY;
        public object Invoke(params object[] keyvals) => Collections.ArrayMap.Create(keyvals);
    }
}

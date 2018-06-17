using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class HashSet :
        IFunction<object>,
        IFunctionParams<object, object>
    {
        public object Invoke() => Collections.HashSet.EMPTY;
        public object Invoke(params object[] keys) => Collections.HashSet.Create(keys);
    }
}

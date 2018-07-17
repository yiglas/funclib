using System;
using System.Text;

namespace funclib.Components.Core
{
    public class SortedSet :
        IFunction<object>,
        IFunctionParams<object, object>
    {
        public object Invoke() => Collections.SortedSet.EMPTY;
        public object Invoke(params object[] keys) => Collections.SortedSet.Create(keys);
    }
}

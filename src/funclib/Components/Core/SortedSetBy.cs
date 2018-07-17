using System;
using System.Text;

namespace funclib.Components.Core
{
    public class SortedSetBy :
        IFunctionParams<object, object, object>
    {
        public object Invoke(object comparator, params object[] keys) => Collections.SortedSet.Create((System.Collections.IComparer)comparator, keys);
    }
}

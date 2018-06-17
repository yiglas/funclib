using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class SortedSetBy :
        IFunctionParams<object, object, object>
    {
        public object Invoke(object comparator, params object[] keys) =>
            comparator is System.Collections.IComparer c
                ? Collections.SortedSet.Create(c, keys)
                : throw new InvalidCastException($"{comparator.GetType().FullName} cannot be casted to {typeof(System.Collections.IComparer).FullName}");
    }
}

using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class SortedMapBy :
        IFunctionParams<object, object, object>
    {
        public object Invoke(object comparator, params object[] keyvals) =>
            comparator is System.Collections.IComparer c
                ? Collections.SortedMap.Create(c, (ISeq)new Seq().Invoke(keyvals))
                : throw new InvalidCastException($"{comparator.GetType().FullName} cannot be casted to {typeof(System.Collections.IComparer).FullName}");
    }
}

using funclib.Collections;
using System;
using System.Text;

namespace funclib.Components.Core
{
    public class SortedMapBy :
        IFunctionParams<object, object, object>
    {
        public object Invoke(object comparator, params object[] keyvals) => Collections.SortedMap.Create((System.Collections.IComparer)comparator, (ISeq)new Seq().Invoke(keyvals));
    }
}

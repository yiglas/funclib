using funclib.Collections;
using System;
using System.Text;

namespace funclib.Components.Core
{
    public class SortedMap :
        IFunction<object>,
        IFunctionParams<object, object>
    {
        public object Invoke() => Collections.SortedMap.EMPTY;
        public object Invoke(params object[] keyvals) => Collections.SortedMap.Create((ISeq)new Seq().Invoke(keyvals));
    }
}

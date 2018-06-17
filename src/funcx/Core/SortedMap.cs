using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class SortedMap :
        IFunction<object>,
        IFunctionParams<object, object>
    {
        public object Invoke() => Collections.SortedMap.EMPTY;
        public object Invoke(params object[] keyvals) => Collections.SortedMap.Create((ISeq)new Seq().Invoke(keyvals));
    }
}

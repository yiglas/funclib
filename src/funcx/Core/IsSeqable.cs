using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class IsSeqable :
        IFunction<object, object>
    {
        public object Invoke(object x) =>
            x == null
                || x is ISeq
                || x is ISeqable
                || x.GetType().IsArray
                || x is string
                || x is System.Collections.IEnumerable;
    }
}

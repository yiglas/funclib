using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class IsChunkedSeq :
        IFunction<object, object>
    {
        public object Invoke(object s) => s is IChunkedSeq;
    }
}

using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class ChunkNext :
        IFunction<object, object>
    {
        public object Invoke(object s) =>
            s is IChunkedSeq c
                ? c.ChunkedNext()
                : throw new InvalidCastException($"{s.GetType().FullName} cannot be casted to {typeof(IChunkedSeq).FullName}");
    }
}

using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class ChunkFirst :
        IFunction<object, object>
    {
        public object Invoke(object s) =>
            s is IChunkedSeq c
                ? c.ChunkedFirst()
                : throw new InvalidCastException($"{s.GetType().FullName} cannot be casted to {typeof(IChunkedSeq).FullName}");
    }
}

using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class ChunkRest :
        IFunction<object, object>
    {
        public object Invoke(object s) =>
            s is IChunkedSeq c
                ? c.ChunkedMore()
                : throw new InvalidCastException();
    }
}

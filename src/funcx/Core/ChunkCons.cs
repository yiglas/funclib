using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class ChunkCons :
        IFunction<object, object, object>
    {
        public object Invoke(object chunk, object rest) =>
            (bool)new IsZero().Invoke(new Count().Invoke(chunk))
                ? rest
                : new ChunkedCons((IChunked)chunk, (ISeq)rest);
    }
}

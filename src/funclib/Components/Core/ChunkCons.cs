using funclib.Collections;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    public class ChunkCons :
        IFunction<object, object, object>
    {
        public object Invoke(object chunk, object rest) =>
            (bool)isZero(count(chunk))
                ? rest
                : new ChunkedCons((IChunked)chunk, (ISeq)rest);
    }
}

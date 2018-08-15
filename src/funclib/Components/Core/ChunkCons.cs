using funclib.Collections;
using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    public class ChunkCons :
        IFunction<object, object, object>
    {
        public object Invoke(object chunk, object rest) =>
            (bool)funclib.Core.IsZero(funclib.Core.Count(chunk))
                ? rest
                : new ChunkedCons((IChunked)chunk, (ISeq)rest);
    }
}

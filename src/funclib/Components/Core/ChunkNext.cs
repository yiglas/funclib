using funclib.Collections;
using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    public class ChunkNext :
        IFunction<object, object>
    {
        public object Invoke(object s) => ((IChunkedSeq)s).ChunkedNext();
    }
}

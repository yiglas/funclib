using funclib.Collections;
using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    public class ChunkFirst :
        IFunction<object, object>
    {
        public object Invoke(object s) => ((IChunkedSeq)s).ChunkedFirst();
    }
}

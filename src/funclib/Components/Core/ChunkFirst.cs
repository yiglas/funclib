using funclib.Collections;
using System;
using System.Text;

namespace funclib.Components.Core
{
    public class ChunkFirst :
        IFunction<object, object>
    {
        public object Invoke(object s) => ((IChunkedSeq)s).ChunkedFirst();
    }
}

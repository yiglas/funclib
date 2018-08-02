using funclib.Components.Core.Generic;
using funclib.Collections;
using System;
using System.Text;

namespace funclib.Components.Core
{
    public class ChunkRest :
        IFunction<object, object>
    {
        public object Invoke(object s) => ((IChunkedSeq)s).ChunkedMore();
    }
}

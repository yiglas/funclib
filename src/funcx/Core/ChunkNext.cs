using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class ChunkNext :
        IFunction<object, object>
    {
        public object Invoke(object s) => ((IChunkedSeq)s).ChunkedNext();
    }
}

using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class ChunkCons :
        IFunction<object, object, object>
    {
        public object Invoke(object chuck, object rest) =>
            (bool)new IsZero().Invoke(new Count().Invoke(chuck))
                ? rest
                : chuck is IChunked c && rest is ISeq r ? new ChunkedCons(c, r)
                : throw new InvalidCastException();
    }
}

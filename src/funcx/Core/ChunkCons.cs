using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class ChunkCons :
        IFunction<IChunked, ISeq, ISeq>
    {
        public ISeq Invoke(IChunked chuck, ISeq rest) =>
            new IsZero().Invoke(new Count().Invoke(chuck))
                ? rest
                : new ChunkedCons(chuck, rest);
    }
}

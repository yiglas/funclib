using System;
using System.Text;

namespace FunctionalLibrary.Collections
{
    public interface IChunkedSeq :
        ISeq,
        ISequential
    {
        IChunked ChunkedFirst();
        ISeq ChunkedNext();
        ISeq ChunkedMore();
    }
}

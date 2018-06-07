using System;
using System.Text;

namespace FunctionalLibrary.Collections
{
    public interface IChunkedSeq :
        ISeq
    {
        IChunked ChunkedFirst();
        ISeq ChunkedNext();
        ISeq ChunkedMore();
    }
}

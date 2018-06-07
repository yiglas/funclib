using System;
using System.Collections.Generic;
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

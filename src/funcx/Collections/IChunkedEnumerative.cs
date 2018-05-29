using System;
using System.Collections.Generic;
using System.Text;

namespace funcx.Collections
{
    public interface IChunkedEnumerative
    {
        IChunked ChunkedFirst();
        IEnumerative ChunkedNext();
        IEnumerative ChunkcedMore();
    }
}

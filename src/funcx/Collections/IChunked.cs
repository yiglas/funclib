using System;
using System.Collections.Generic;
using System.Text;

namespace funcx.Collections
{
    public interface IChunked
    {
        int Count { get; }
        object this[int index] { get; set; }
        object this[int index, object notFound] { get; set; }
        IChunked DropFirst();
    }
}

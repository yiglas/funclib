using funclib.Components.Core;
using System;
using System.Text;

namespace funclib.Collections
{
    public interface IChunked :
        ICounted
    {
        new int Count { get; }
        object this[int index] { get; set; }
        object this[int index, object notFound] { get; set; }
        IChunked DropFirst();
        object Reduce(IFunction<object, object, object> f, object init);
    }
}

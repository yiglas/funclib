using System;

namespace funclib.Collections.Generic
{
    public interface IChunked<T> :
        ICounted
    {
        new int Count { get; }
        T this[int index] { get; set; }
        T this[int index, T notFound] { get; set; }
        IChunked<T> DropFirst();
        TResult Reduce<TResult>(Func<TResult, T, TResult> f, TResult init);
    }
}
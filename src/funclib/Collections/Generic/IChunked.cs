using System;

namespace funclib.Collections.Generic
{
    public interface IChunked<T> :
        ICounted
    {
        new int Count { get; }
        UnionType<T, Nil> this[int index] { get; set; }
        UnionType<T, Nil> this[int index, T notFound] { get; set; }
        IChunked<UnionType<T, Nil>> DropFirst();
        TResult Reduce<TResult>(Func<TResult, UnionType<T, Nil>, TResult> f, TResult init);
    }
}
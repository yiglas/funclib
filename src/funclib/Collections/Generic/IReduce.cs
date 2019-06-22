using System;

namespace funclib.Collections.Generic
{
    public interface IReduce<T>
    {
        UnionType<T, Nil> Reduce(Func<UnionType<T, Nil>, UnionType<T, Nil>, UnionType<T, Nil>> f);
        TAccumulate Reduce<TAccumulate>(Func<TAccumulate, UnionType<T, Nil>, TAccumulate> f, TAccumulate init);
    }
}

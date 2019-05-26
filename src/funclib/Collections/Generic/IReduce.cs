using System;

namespace funclib.Collections.Generic
{
    public interface IReduce<T>
    {
        T Reduce(Func<T, T, T> f);
        TAccumulate Reduce<TAccumulate>(Func<TAccumulate, T, TAccumulate> f, TAccumulate init);
    }
}

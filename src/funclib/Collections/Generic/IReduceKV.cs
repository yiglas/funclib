using System;

namespace funclib.Collections.Generic
{
    public interface IReduceKV<TKey, TValue>
    {
        TResult ReduceKV<TResult>(Func<TResult, UnionType<TKey, Nil>, UnionType<TKey, Nil>, TResult> f, TResult init);
    }
}
using System;

namespace funclib.Collections.Generic
{
    public interface IReduceKV<TKey, TValue>
    {
        TResult ReduceKV<TInit, TResult>(Func<TInit, TKey, TValue, TResult> f, TInit init);
    }
}
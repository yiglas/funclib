using System;

namespace funclib.Collections.Generic
{
    public interface IReduceKV<TKey, TValue>
    {
        TResult ReduceKV<TResult>(Func<TResult, TKey, TValue, TResult> f, TResult init);
    }
}
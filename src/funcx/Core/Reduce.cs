using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Reduce<TAccumulate, TSource> :
        IFunction<IFunction<TAccumulate, TSource, TAccumulate>, TAccumulate, IEnumerable<TSource>, TAccumulate>
    {
        public TAccumulate Invoke(IFunction<TAccumulate, TSource, TAccumulate> f, TAccumulate val, IEnumerable<TSource> coll) =>
            coll == null || !coll.Any()
                ? val
                : coll.Aggregate(val, f.Invoke);

    }
    public class Reduce<TSource> :
        IFunction<IFunction<TSource, TSource, TSource>, IEnumerable<TSource>, TSource>
    {
        public TSource Invoke(IFunction<TSource, TSource, TSource> f, IEnumerable<TSource> coll) =>
            coll == null || !coll.Any()
                ? f.Invoke(default, default)
                : coll.Aggregate(f.Invoke);

    }
}

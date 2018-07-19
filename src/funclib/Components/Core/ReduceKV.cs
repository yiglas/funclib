using funclib.Collections;
using System;
using System.Text;

namespace funclib.Components.Core
{
    public class ReduceKV :
        IFunction<object, object, object, object>
    {
        /// <summary>
        /// Reduces a <see cref="IAssociative"/> collection. f should implement <see cref="IFunction{T1, T2, T3, TResult}"/> interface.
        /// Returns the result of applying f to init, the 1st key and value in coll. Then applying f to that result and the
        /// 2nd key and value, etc. If coll contains no entries, returns init and f is not called. Note: <see cref="ReduceKV"/>
        /// is supported on <see cref="IVector"/>'s where the keys will be the ordinal values.
        /// </summary>
        /// <param name="f">An object that implements the <see cref="IFunction{T1, T2, T3, TResult}"/> interface.</param>
        /// <param name="init">The initial value for the reducing.</param>
        /// <param name="coll">The collection that implements <see cref="IAssociative"/> interface.</param>
        /// <returns>
        /// Returns the result of applying f to init, the 1st key and value in coll. Then applying f to that result and the
        /// 2nd key and value, etc. If coll contains no entries, returns init and f is not called.
        /// </returns>
        public object Invoke(object f, object init, object coll) =>
            coll == null
                ? init
                : coll is IReduceKV r ? r.ReduceKV((IFunction<object, object, object, object>)f, init)
                : coll is IMap m ? new Reduce().Invoke(new Function<object, object, object>((ret, kv) =>
                {
                    var k = new Key().Invoke(kv);
                    var v = new Value().Invoke(kv);

                    return ((IFunction<object, object, object, object>)f).Invoke(ret, k, v);
                }), init, coll)
                : throw new InvalidCastException($"Unable to cast object of type '{coll.GetType().FullName}' to type '{typeof(IReduceKV).FullName}'.");
    }
}

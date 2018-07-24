using funclib.Collections;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="LazySeq"/> of the intermediate values of the reductions 
    /// (as per reduce) of coll by f, starting with init.
    /// </summary>
    public class Reductions :
        IFunction<object, object, object>,
        IFunction<object, object, object, object>
    {
        /// <summary>
        /// Returns a <see cref="LazySeq"/> of the intermediate values of the reductions 
        /// (as per reduce) of coll by f, starting with init.
        /// </summary>
        /// <param name="f">An object that implements the <see cref="IFunction{TResult}"/> if coll contains no items, otherwise <see cref="IFunction{T1, T2, TResult}"/> interface.</param>
        /// <param name="coll">A object that can be <see cref="Seq"/> over.</param>
        /// <returns>
        /// Returns a <see cref="LazySeq"/> of the intermediate values of the reductions 
        /// (as per reduce) of coll by f, starting with init.
        /// </returns>
        public object Invoke(object f, object coll) =>
            lazySeq(() =>
            {
                var s = seq(coll);
                if ((bool)truthy(s))
                {
                    return Invoke(f, first(s), rest(s));
                }

                return list(invoke(f));
            });

        /// <summary>
        /// Returns a <see cref="LazySeq"/> of the intermediate values of the reductions 
        /// (as per reduce) of coll by f, starting with init.
        /// </summary>
        /// <param name="f">An object that implements the <see cref="IFunction{T1, T2, TResult}"/> interface.</param>
        /// <param name="init">The initial starting value.</param>
        /// <param name="coll">A object that can be <see cref="Seq"/> over.</param>
        /// <returns>
        /// Returns a <see cref="LazySeq"/> of the intermediate values of the reductions 
        /// (as per reduce) of coll by f, starting with init.
        /// </returns>
        public object Invoke(object f, object init, object coll)
        {
            if (init is Reduced r)
                return list(r.Deref());

            return cons(init, lazySeq(() =>
            {
                var s = seq(coll);
                if ((bool)truthy(s))
                    return Invoke(f, invoke(f, init, first(s)), rest(s));

                return null;
            }));
        }
    }
}

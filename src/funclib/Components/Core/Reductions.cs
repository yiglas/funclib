using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="funclib.Components.Core.LazySeq"/> of the intermediate values of the reductions
    /// (as per reduce) of coll by f, starting with init.
    /// </summary>
    public class Reductions :
        IFunction<object, object, object>,
        IFunction<object, object, object, object>
    {
        /// <summary>
        /// Returns a <see cref="funclib.Components.Core.LazySeq"/> of the intermediate values of the reductions
        /// (as per reduce) of coll by f, starting with init.
        /// </summary>
        /// <param name="f">An object that implements the <see cref="IFunction{TResult}"/> if coll contains no items, otherwise <see cref="IFunction{T1, T2, TResult}"/> interface.</param>
        /// <param name="coll">A object that can be <see cref="Seq"/> over.</param>
        /// <returns>
        /// Returns a <see cref="funclib.Components.Core.LazySeq"/> of the intermediate values of the reductions
        /// (as per reduce) of coll by f, starting with init.
        /// </returns>
        public object Invoke(object f, object coll) =>
            funclib.Core.LazySeq(() =>
            {
                var s = funclib.Core.Seq(coll);
                if (funclib.Core.T(s))
                {
                    return Invoke(f, funclib.Core.First(s), funclib.Core.Rest(s));
                }

                return funclib.Core.List(funclib.Core.Invoke(f));
            });

        /// <summary>
        /// Returns a <see cref="funclib.Components.Core.LazySeq"/> of the intermediate values of the reductions
        /// (as per reduce) of coll by f, starting with init.
        /// </summary>
        /// <param name="f">An object that implements the <see cref="IFunction{T1, T2, TResult}"/> interface.</param>
        /// <param name="init">The initial starting value.</param>
        /// <param name="coll">A object that can be <see cref="Seq"/> over.</param>
        /// <returns>
        /// Returns a <see cref="funclib.Components.Core.LazySeq"/> of the intermediate values of the reductions
        /// (as per reduce) of coll by f, starting with init.
        /// </returns>
        public object Invoke(object f, object init, object coll)
        {
            if (init is Reduced r)
                return funclib.Core.List(r.Deref());

            return funclib.Core.Cons(init, funclib.Core.LazySeq(() =>
            {
                var s = funclib.Core.Seq(coll);
                if (funclib.Core.T(s))
                    return Invoke(f, funclib.Core.Invoke(f, init, funclib.Core.First(s)), funclib.Core.Rest(s));

                return null;
            }));
        }
    }
}

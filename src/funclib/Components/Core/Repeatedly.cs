using System;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Takes a function of no args, presumably with side effects, and
    /// returns an infinite (or length n if supplied) <see cref="LazySeq"/> of
    /// calls to it.
    /// </summary>
    public class Repeatedly :
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        /// <summary>
        /// Takes a function of no args, presumably with side effects, and
        /// returns an infinite (or length n if supplied) <see cref="LazySeq"/> of
        /// calls to it.
        /// </summary>
        /// <param name="f">An object that implements the <see cref="IFunction{TResult}"/> interface.</param>
        /// <returns>
        /// Takes a function of no args, presumably with side effects, and
        /// returns an infinite (or length n if supplied) <see cref="LazySeq"/> of
        /// calls to it.
        /// </returns>
        public object Invoke(object f) =>
            lazySeq(() => cons(((IFunction<object>)f).Invoke(), Invoke(f)));
        /// <summary>
        /// Takes a function of no args, presumably with side effects, and
        /// returns an infinite (or length n if supplied) <see cref="LazySeq"/> of
        /// calls to it.
        /// </summary>
        /// <param name="n">The length of the sequence.</param>
        /// <param name="f">An object that implements the <see cref="IFunction{TResult}"/> interface.</param>
        /// <returns>
        /// Takes a function of no args, presumably with side effects, and
        /// returns an infinite (or length n if supplied) <see cref="LazySeq"/> of
        /// calls to it.
        /// </returns>
        public object Invoke(object n, object f) => new Take().Invoke(n, Invoke(f));
    }
}

using funclib.Collections;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="LazySeq"/> of the first item in each coll, then the second, etc.
    /// </summary>
    public class Interleave :
        IFunction<object>,
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunctionParams<object, object, object, object>
    {
        /// <summary>
        /// Returns a <see cref="LazySeq"/> of the first item in each coll, then the second, etc.
        /// </summary>
        /// <returns>
        /// Returns <see cref="Collections.List.EMPTY"/>.
        /// </returns>
        public object Invoke() => Collections.List.EMPTY;
        /// <summary>
        /// Returns a <see cref="LazySeq"/> of the first item in each coll, then the second, etc.
        /// </summary>
        /// <param name="c1">The collection returned lazily.</param>
        /// <returns>
        /// Returns a <see cref="LazySeq"/> of c1.
        /// </returns>
        public object Invoke(object c1) => lazySeq(c1);
        /// <summary>
        /// Returns a <see cref="LazySeq"/> of the first item in each coll, then the second, etc.
        /// </summary>
        /// <param name="c1">First collection to interleave.</param>
        /// <param name="c2">Second collection to interleave.</param>
        /// <returns>
        /// Returns a <see cref="LazySeq"/> of the first item in each coll, then the second, etc.
        /// </returns>
        public object Invoke(object c1, object c2) =>
            lazySeq(() =>
            {
                var s1 = seq(c1);
                var s2 = seq(c2);
                if ((bool)truthy(and(s1, s2)))
                {
                    return cons(first(s1), cons(first(s2), Invoke(rest(s1), rest(s2))));
                }

                return null;
            });
        /// <summary>
        /// Returns a <see cref="LazySeq"/> of the first item in each coll, then the second, etc.
        /// </summary>
        /// <param name="c1">First collection to interleave.</param>
        /// <param name="c2">Second collection to interleave.</param>
        /// <param name="colls">Rest of the collections to interleave.</param>
        /// <returns>
        /// Returns a <see cref="LazySeq"/> of the first item in each coll, then the second, etc.
        /// </returns>
        public object Invoke(object c1, object c2, params object[] colls) =>
            lazySeq(() =>
            {
                var ss = map(funclib.core.Seq, conj(seq(colls), c2, c1));
                if ((bool)isEvery(funclib.core.Identity, ss))
                {
                    return concat(map(funclib.core.First, ss), apply(this, map(funclib.core.Rest, ss)));
                }
                return null;
            });
    }
}

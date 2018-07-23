using funclib.Collections;
using System;
using System.Text;
using static funclib.Core;

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
                var s1 = new Seq().Invoke(c1);
                var s2 = new Seq().Invoke(c2);
                if ((bool)new Truthy().Invoke(and(s1, s2)))
                {
                    return cons(first(s1), cons(first(s2), Invoke(new Rest().Invoke(s1), new Rest().Invoke(s2))));
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
                var ss = map(new Seq(), conj(new Seq().Invoke(colls), c2, c1));
                if ((bool)isEvery(new Identity(), ss))
                {
                    return concat(map(new First(), ss), apply(new Interleave(), map(new Rest(), ss)));
                }
                return null;
            });
    }
}

using funclib.Components.Core.Generic;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="LazySeq"/> representing the concatenation of the elements
    /// in the supplied colls.
    /// </summary>
    public class Concat :
        IFunction<object>,
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunctionParams<object, object, object, object>
    {
        /// <summary>
        /// Returns a <see cref="LazySeq"/> representing the concatenation of the elements
        /// in the supplied colls.
        /// </summary>
        /// <returns>
        /// Returns a <see cref="LazySeq"/>, when invoked returns null.
        /// </returns>
        public object Invoke() => lazySeq(func(() => (object)null));
        /// <summary>
        /// Returns a <see cref="LazySeq"/> representing the concatenation of the elements
        /// in the supplied colls.
        /// </summary>
        /// <param name="x">Object to return via a lazy implementation.</param>
        /// <returns>
        /// Returna a <see cref="LazySeq"/>, when invoked returns x.
        /// </returns>
        public object Invoke(object x) => lazySeq(func(() => x));
        /// <summary>
        /// Returns a <see cref="LazySeq"/> representing the concatenation of the elements
        /// in the supplied colls.
        /// </summary>
        /// <param name="x">First collection in the concatenation.</param>
        /// <param name="y">Second collection to be concatenated.</param>
        /// <returns>
        /// Returns a <see cref="LazySeq"/> that will concatenate y to x.
        /// </returns>
        public object Invoke(object x, object y) =>
            lazySeq(() =>
            {
                var s = seq(x);
                if ((bool)truthy(s))
                {
                    if ((bool)isChunkedSeq(s))
                        return chunkCons(chunkFirst(s), Invoke(chunkRest(s), y));
                    else
                        return cons(first(s), Invoke(rest(s), y));
                }
                else
                    return y;
            });
        /// <summary>
        /// Returns a <see cref="LazySeq"/> representing the concatenation of the elements
        /// in the supplied colls.
        /// </summary>
        /// <param name="x">First collection in the concatenation.</param>
        /// <param name="y">Second collection to be concatenated.</param>
        /// <param name="zs">Other collections to be concatenated with.</param>
        /// <returns>
        /// Returns a <see cref="LazySeq"/> that will concatentat zs, y to x.
        /// </returns>
        public object Invoke(object x, object y, params object[] zs)
        {
            Func<object, object, object> cat = null;
            cat = (xys, zss) =>
                lazySeq(() =>
                {
                    xys = seq(xys);
                    if ((bool)truthy(xys))
                    {
                        if ((bool)isChunkedSeq(xys))
                            return chunkCons(chunkFirst(xys), cat(chunkRest(xys), zss));
                        else
                            return cons(first(xys), cat(rest(xys), zss));
                    }
                    else if ((bool)truthy(zss))
                    {
                        return cat(first(zss), next(zss));
                    }
                    else
                        return null;
                });

            return cat(Invoke(x, y), zs);
        }
    }
}

using funclib.Components.Core.Generic;
using System;

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
        public object Invoke() => funclib.Core.LazySeq(funclib.Core.Func(() => null));
        /// <summary>
        /// Returns a <see cref="LazySeq"/> representing the concatenation of the elements
        /// in the supplied colls.
        /// </summary>
        /// <param name="x">Object to return via a lazy implementation.</param>
        /// <returns>
        /// Returns a <see cref="LazySeq"/>, when invoked returns x.
        /// </returns>
        public object Invoke(object x) => funclib.Core.LazySeq(funclib.Core.Func(() => x));
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
            funclib.Core.LazySeq(() =>
            {
                var s = funclib.Core.Seq(x);
                if ((bool)funclib.Core.Truthy(s))
                {
                    if ((bool)funclib.Core.IsChunkedSeq(s))
                        return funclib.Core.ChunkCons(funclib.Core.ChunkFirst(s), Invoke(funclib.Core.ChunkRest(s), y));
                    else
                        return funclib.Core.Cons(funclib.Core.First(s), Invoke(funclib.Core.Rest(s), y));
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
        /// Returns a <see cref="LazySeq"/> that will concatenate zs, y to x.
        /// </returns>
        public object Invoke(object x, object y, params object[] zs)
        {
            return cat(Invoke(x, y), zs);

            object cat(object xys, object zss) =>
                funclib.Core.LazySeq(() =>
                {
                    xys = funclib.Core.Seq(xys);
                    if ((bool)funclib.Core.Truthy(xys))
                    {
                        if ((bool)funclib.Core.IsChunkedSeq(xys))
                            return funclib.Core.ChunkCons(funclib.Core.ChunkFirst(xys), cat(funclib.Core.ChunkRest(xys), zss));
                        else
                            return funclib.Core.Cons(funclib.Core.First(xys), cat(funclib.Core.Rest(xys), zss));
                    }
                    else if ((bool)funclib.Core.Truthy(zss))
                    {
                        return cat(funclib.Core.First(zss), funclib.Core.Next(zss));
                    }
                    else
                        return null;
                });
        }
    }
}

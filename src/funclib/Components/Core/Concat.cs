using System;
using System.Text;

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
        public object Invoke() => new LazySeq(new Function<object>(() => null));
        /// <summary>
        /// Returns a <see cref="LazySeq"/> representing the concatenation of the elements
        /// in the supplied colls.
        /// </summary>
        /// <param name="x">Object to return via a lazy implementation.</param>
        /// <returns>
        /// Returna a <see cref="LazySeq"/>, when invoked returns x.
        /// </returns>
        public object Invoke(object x) => new LazySeq(new Function<object>(() => x));
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
            new LazySeq(() =>
            {
                var s = new Seq().Invoke(x);
                if ((bool)new Truthy().Invoke(s))
                {
                    if ((bool)new IsChunkedSeq().Invoke(s))
                        return new ChunkCons().Invoke(new ChunkFirst().Invoke(s), Invoke(new ChunkRest().Invoke(s), y));
                    else
                        return new Cons().Invoke(new First().Invoke(s), Invoke(new Rest().Invoke(s), y));
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
                new LazySeq(() =>
                {
                    xys = new Seq().Invoke(xys);
                    if ((bool)new Truthy().Invoke(xys))
                    {
                        if ((bool)new IsChunkedSeq().Invoke(xys))
                            return new ChunkCons().Invoke(new ChunkFirst().Invoke(xys), cat(new ChunkRest().Invoke(xys), zss));
                        else
                            return new Cons().Invoke(new First().Invoke(xys), cat(new Rest().Invoke(xys), zss));
                    }
                    else if ((bool)new Truthy().Invoke(zss))
                    {
                        return cat(new First().Invoke(zss), new Next().Invoke(zss));
                    }
                    else
                        return null;
                });

            return cat(Invoke(x, y), zs);
        }
    }
}

using System;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="LazySeq"/> of items in coll for which predicate returns a logical true.
    /// </summary>
    public class Filter :
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        public object Invoke(object pred) => func<object, object>(rf => new TransducerFunction(pred, rf));
        /// <summary>
        /// Returns a <see cref="LazySeq"/> of items in coll for which predicate returns a logical true.
        /// </summary>
        /// <param name="pred">An object that implements <see cref="IFunction{T1, TResult}"/> interface.</param>
        /// <param name="coll">An object to test.</param>
        /// <returns>
        /// Returns a <see cref="LazySeq"/> of items in coll for which predicate returns a logical true.
        /// </returns>
        public object Invoke(object pred, object coll) =>
            lazySeq(() =>
            {
                var fn = (IFunction<object, object>)pred;

                var s = seq(coll);
                if ((bool)truthy(s))
                {
                    if ((bool)isChunkedSeq(s))
                    {
                        var c = chunkFirst(s);
                        var size = (int)count(c);
                        var b = (Collections.ChunkBuffer)chunkBuffer(size);

                        doTimes(size, i =>
                        {
                            var v = nth(c, i);
                            if ((bool)truthy(fn.Invoke(v)))
                            {
                                return chunkAppend(b, v);
                            }
                            return null;
                        });

                        return chunkCons(b.Chunk(), Invoke(pred, chunkRest(s)));
                    }
                    else
                    {
                        var f = first(s);
                        var r = rest(s);

                        if ((bool)truthy(fn.Invoke(f)))
                        {
                            return cons(f, Invoke(pred, r));
                        }
                        else
                        {
                            return Invoke(pred, r);
                        }
                    }
                }

                return null;
            });


        public class TransducerFunction :
            ATransducerFunction
        {
            IFunction<object, object> _pred;

            public TransducerFunction(object pred, object rf) :
                base(rf)
            {
                this._pred = (IFunction<object, object>)pred;
            }

            #region Overrides
            public override object Invoke(object result, object input) =>
                (bool)truthy(this._pred.Invoke(input))
                    ? ((IFunction<object, object, object>)this._rf).Invoke(result, input)
                    : result;
            #endregion
        }
    }
}

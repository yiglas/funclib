using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    /// <summary>
    /// Returns a <see cref="LazySeq"/> of items in coll for which predicate returns a logical true.
    /// </summary>
    public class Filter :
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        public object Invoke(object pred) => new Function<object, object>(rf => new TransducerFunction(pred, rf));
        /// <summary>
        /// Returns a <see cref="LazySeq"/> of items in coll for which predicate returns a logical true.
        /// </summary>
        /// <param name="pred">An object that implements <see cref="IFunction{T1, TResult}"/> interface.</param>
        /// <param name="coll">An object to test.</param>
        /// <returns>
        /// Returns a <see cref="LazySeq"/> of items in coll for which predicate returns a logical true.
        /// </returns>
        public object Invoke(object pred, object coll) =>
            new LazySeq(() =>
            {
                var fn = (IFunction<object, object>)pred;

                var s = new Seq().Invoke(coll);
                if ((bool)new Truthy().Invoke(s))
                {
                    if ((bool)new IsChunkedSeq().Invoke(s))
                    {
                        var c = new ChunkFirst().Invoke(s);
                        var size = (int)new Count().Invoke(c);
                        var b = (Collections.ChunkBuffer)new ChunkBuffer().Invoke(size);

                        new DoTimes(size, i =>
                        {
                            var v = new Nth().Invoke(c, i);
                            if ((bool)new Truthy().Invoke(fn.Invoke(v)))
                            {
                                return new ChunkAppend().Invoke(b, v);
                            }
                            return null;
                        }).Invoke();

                        return new ChunkCons().Invoke(b.Chunk(), Invoke(pred, new ChunkRest().Invoke(s)));
                    }
                    else
                    {
                        var f = new First().Invoke(s);
                        var r = new Rest().Invoke(s);

                        if ((bool)new Truthy().Invoke(fn.Invoke(f)))
                        {
                            return new Cons().Invoke(f, Invoke(pred, r));
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
            object _pred;

            public TransducerFunction(object pred, object rf) :
                base(rf)
            {
                this._pred = pred;
            }

            #region Overrides
            public override object Invoke(object result, object input) =>
                (bool)new Truthy().Invoke(((IFunction<object, object>)this._pred).Invoke(input))
                    ? ((IFunction<object, object, object>)this._rf).Invoke(result, input)
                    : result;
            #endregion
        }
    }
}

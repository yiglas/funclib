using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="funclib.Components.Core.LazySeq"/> of items in coll for which predicate returns a logical true.
    /// </summary>
    public class Filter :
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        public object Invoke(object pred) => funclib.Core.Func(rf => new TransducerFunction(pred, rf));
        /// <summary>
        /// Returns a <see cref="funclib.Components.Core.LazySeq"/> of items in coll for which predicate returns a logical true.
        /// </summary>
        /// <param name="pred">An object that implements <see cref="IFunction{T1, TResult}"/> interface.</param>
        /// <param name="coll">An object to test.</param>
        /// <returns>
        /// Returns a <see cref="funclib.Components.Core.LazySeq"/> of items in coll for which predicate returns a logical true.
        /// </returns>
        public object Invoke(object pred, object coll) =>
            funclib.Core.LazySeq(() =>
            {
                var s = funclib.Core.Seq(coll);
                if (funclib.Core.T(s))
                {
                    if ((bool)funclib.Core.IsChunkedSeq(s))
                    {
                        var c = funclib.Core.ChunkFirst(s);
                        var size = (int)funclib.Core.Count(c);
                        var b = (Collections.ChunkBuffer)funclib.Core.ChunkBuffer(size);

                        funclib.Core.DoTimes(size, i =>
                        {
                            var v = funclib.Core.Nth(c, i);
                            if (funclib.Core.T(funclib.Core.Invoke(pred, v)))
                            {
                                return funclib.Core.ChunkAppend(b, v);
                            }
                            return null;
                        });

                        return funclib.Core.ChunkCons(b.Chunk(), Invoke(pred, funclib.Core.ChunkRest(s)));
                    }
                    else
                    {
                        var f = funclib.Core.First(s);
                        var r = funclib.Core.Rest(s);

                        if (funclib.Core.T(funclib.Core.Invoke(pred, f)))
                        {
                            return funclib.Core.Cons(f, Invoke(pred, r));
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
            public override object Invoke(object result, object input)
            {
                if (funclib.Core.T(funclib.Core.Invoke(this._pred, input)))
                    return funclib.Core.Invoke(this._rf, result, input);

                return result;
            }
            #endregion
        }
    }
}

using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="LazySeq"/> of the non-null results of <see cref="IFunction{T1, TResult}"/>.
    /// Note: this means false return values will be included. F must be free of side-effects.
    /// </summary>
    public class Keep :
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        public object Invoke(object f) => funclib.Core.Func(rf => new TransducerFunction(f, rf));
        /// <summary>
        /// Returns a <see cref="LazySeq"/> of the non-null results of <see cref="IFunction{T1, TResult}"/>.
        /// Note: this means false return values will be included. F must be free of side-effects.
        /// </summary>
        /// <param name="f">An object that implements the <see cref="IFunction{T1, TResult}"/> implements.</param>
        /// <param name="coll">A collection of items.</param>
        /// <returns>
        /// Returns a <see cref="LazySeq"/> of the non-null results of <see cref="IFunction{T1, TResult}"/>.
        /// Note: this means false return values will be included. F must be free of side-effects.
        /// </returns>
        public object Invoke(object f, object coll) =>
            funclib.Core.LazySeq(() =>
            {
                var s = funclib.Core.Seq(coll);
                if ((bool)funclib.Core.Truthy(s))
                {
                    if ((bool)funclib.Core.IsChunkedSeq(s))
                    {
                        var c = funclib.Core.ChunkFirst(s);
                        var size = (int)funclib.Core.Count(c);
                        var b = funclib.Core.ChunkBuffer(size);

                        funclib.Core.DoTimes(size, i =>
                        {
                            var y = funclib.Core.Invoke(f, funclib.Core.Nth(c, i));
                            if (!(bool)funclib.Core.IsNull(y))
                            {
                                funclib.Core.ChunkAppend(b, y);
                            }
                            return null;
                        });

                        return funclib.Core.ChunkCons(funclib.Core.Chunk(b), Invoke(f, funclib.Core.ChunkRest(s)));
                    }

                    var x = funclib.Core.Invoke(f, funclib.Core.First(s));
                    if ((bool)funclib.Core.IsNull(x))
                    {
                        return Invoke(f, funclib.Core.Rest(s));
                    }

                    return funclib.Core.Cons(x, Invoke(f, funclib.Core.Rest(s)));
                }

                return null;
            });

        public class TransducerFunction :
            ATransducerFunction
        {
            object _f;

            public TransducerFunction(object f, object rf) : 
                base(rf)
            {
                this._f = f;
            }

            #region Overrides
            public override object Invoke(object result, object input)
            {
                var v = funclib.Core.Invoke(this._f, input);
                if ((bool)funclib.Core.IsNull(v))
                    return result;

                return funclib.Core.Invoke(this._rf, result, v);
            }
            #endregion
        }
    }
}

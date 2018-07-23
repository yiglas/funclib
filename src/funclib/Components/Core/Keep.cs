using funclib.Collections;
using System;
using System.Text;
using static funclib.Core;

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
        public object Invoke(object f) => new Function<object, object>(rf => new TransducerFunction(f, rf));
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
            lazySeq(() =>
            {
                var s = (ISeq)new Seq().Invoke(coll);
                if ((bool)new Truthy().Invoke(s))
                {
                    if ((bool)isChunkedSeq(s))
                    {
                        var c = chunkFirst(s);
                        var size = (int)count(c);
                        var b = chunkBuffer(size);

                        doTimes(size, i =>
                        {
                            var y = ((IFunction<object, object>)f).Invoke(nth(c, i));
                            if (!(bool)isNull(y))
                            {
                                chunkAppend(b, y);
                            }
                            return null;
                        });

                        return chunkCons(chunk(b), Invoke(f, chunkRest(s)));
                    }

                    var x = ((IFunction<object, object>)f).Invoke(s.First());
                    if ((bool)isNull(x))
                    {
                        return Invoke(f, new Rest().Invoke(s));
                    }

                    return cons(x, Invoke(f, new Rest().Invoke(s)));
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
                var v = ((IFunction<object, object>)this._f).Invoke(input);
                if ((bool)isNull(v))
                    return result;

                return ((IFunction<object, object, object>)this._rf).Invoke(result, v);
            }
            #endregion
        }
    }
}

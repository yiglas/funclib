using funclib.Collections;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="LazySeq"/> of every nth item in coll.
    /// </summary>
    public class TakeNth :
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        public object Invoke(object n) => new Function<object, object>(rf => new TransducerFunction(n, rf));
        /// <summary>
        /// Returns a <see cref="LazySeq"/> of every nth item in coll.
        /// </summary>
        /// <param name="n">An <see cref="int"/> of the items to take every nth from collection.</param>
        /// <param name="coll">The collection to drop the first x items from.</param>
        /// <returns>
        /// Returns a <see cref="LazySeq"/> of every nth item in coll.
        /// </returns>
        public object Invoke(object n, object coll) =>
            lazySeq(() =>
            {
                var s = (ISeq)seq(coll);
                if ((bool)new Truthy().Invoke(s))
                {
                    return cons(s.First(), Invoke(n, drop(n, s)));
                }
                return null;
            });


        public class TransducerFunction :
            ATransducerFunction
        {
            Volatileǃ _iv;
            object _n;

            public TransducerFunction(object n, object rf) :
                base(rf)
            {
                this._n = n;
                this._iv = (Volatileǃ)new Volatileǃ().Invoke(-1);
            }

            #region Overrides
            public override object Invoke(object result, object input)
            {
                var i = new VSwapǃ(this._iv, new Inc()).Invoke();
                if ((bool)isZero(rem(i, this._n)))
                {
                    return ((IFunction<object, object, object>)this._rf).Invoke(result, input);
                }

                return result;
            }
            #endregion
        }
    }
}

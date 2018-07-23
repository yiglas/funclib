using funclib.Collections;
using System;
using System.Linq;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="LazySeq"/> of the first n items in the coll, or all items
    /// if there are fewer than n.
    /// </summary>
    public class Take :
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        public object Invoke(object n) => new Function<object, object>(rf => new TransducerFunction(n, rf));
        /// <summary>
        /// Returns a <see cref="LazySeq"/> of the first n items in the coll, or all items
        /// if there are fewer than n.
        /// </summary>
        /// <param name="n">An <see cref="int"/> of the items to take from the collection.</param>
        /// <param name="coll">The collection to take the first x items from.</param>
        /// <returns>
        /// Returns a <see cref="LazySeq"/> of the first n items in the coll, or all items
        /// if there are fewer than n.
        /// </returns>
        public object Invoke(object n, object coll) =>
            lazySeq(new Function<object>(() =>
            {
                if ((bool)isPos(n))
                {
                    var s = (ISeq)seq(coll);
                    if ((bool)truthy(s))
                        return cons(s.First(), Invoke(dec(n), rest(s)));
                }

                return null;
            }));

        public class TransducerFunction :
            ATransducerFunction
        {
            volatile Volatileǃ _nv;

            public TransducerFunction(object n, object rf) :
                base(rf)
            {
                this._nv = (Volatileǃ)new Volatileǃ().Invoke(n);
            }

            #region Overrides
            public override object Invoke(object result, object input)
            {
                var n = this._nv.Deref();
                var nn = new VSwapǃ(this._nv, new Dec()).Invoke();
                result = (bool)isPos(n) 
                    ? Apply.ApplyTo((IFunction)this._rf, (ISeq)list(result, input))
                    : result;

                if ((bool)not(isPos(nn)))
                    return ensureReduced(result);

                return result;
            }
            #endregion
        }
    }
}

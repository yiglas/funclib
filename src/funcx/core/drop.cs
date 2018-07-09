using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    /// <summary>
    /// Returns a <see cref="LazySeq"/> of all but the first n items in coll.
    /// </summary>
    public class Drop :
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        public object Invoke(object n) => new Function<object, object>(rf => new TransducerFunction(n, rf));
        /// <summary>
        /// Returns a <see cref="LazySeq"/> of all but the first n items in coll.
        /// </summary>
        /// <param name="n">An <see cref="int"/> of the items to drop from the collection.</param>
        /// <param name="coll">The collection to drop the first x items from.</param>
        /// <returns>
        /// Returns a <see cref="LazySeq"/> of items without the first x items.
        /// </returns>
        public object Invoke(object n, object coll) => new LazySeq(() => step(n, coll));

        object step(object n, object coll)
        {
            var s = new Seq().Invoke(coll);
            if ((bool)new Truthy().Invoke(new And().Invoke(new IsPos().Invoke(n), s)))
            {
                return step(new Dec().Invoke(n), new Rest().Invoke(s));
            }
            return s;
        }

        public class TransducerFunction :
            ATransducerFunction
        {
            Volatile _nv;

            public TransducerFunction(object n, object rf) :
                base(rf)
            {
                this._nv = (Volatile)new Volatile_().Invoke(n);
            }

            #region Overrides
            public override object Invoke(object result, object input)
            {
                var n = this._nv.Deref();
                new VSwap_(this._nv, new Dec());
                if ((bool)new IsPos().Invoke(n))
                    return result;

                return ((IFunction<object, object, object>)this._rf).Invoke(result, input);
            }
            #endregion
        }
    }
}

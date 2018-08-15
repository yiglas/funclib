using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="LazySeq"/> of all but the funclib.Core.First( n items in coll.
    /// </summary>
    public class Drop :
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        public object Invoke(object n) => funclib.Core.Func(rf => new TransducerFunction(n, rf));
        /// <summary>
        /// Returns a <see cref="LazySeq"/> of all but the funclib.Core.First( n items in coll.
        /// </summary>
        /// <param name="n">An <see cref="int"/> of the items to drop from the collection.</param>
        /// <param name="coll">The collection to drop the funclib.Core.First( x items from.</param>
        /// <returns>
        /// Returns a <see cref="LazySeq"/> of items without the funclib.Core.First( x items.
        /// </returns>
        public object Invoke(object n, object coll) => funclib.Core.LazySeq(() => step(n, coll));

        static object step(object n, object coll)
        {
            var s = funclib.Core.Seq(coll);
            if ((bool)funclib.Core.Truthy(funclib.Core.And(funclib.Core.IsPos(n), s)))
            {
                return step(funclib.Core.Dec(n), funclib.Core.Rest(s));
            }
            return s;
        }

        public class TransducerFunction :
            ATransducerFunction
        {
            Volatileǃ _nv;

            public TransducerFunction(object n, object rf) :
                base(rf)
            {
                this._nv = (Volatileǃ)funclib.Core.Volatileǃ(n);
            }

            #region Overrides
            public override object Invoke(object result, object input)
            {
                var n = this._nv.Deref();
                new VSwapǃ(this._nv, new Dec());
                if ((bool)funclib.Core.IsPos(n))
                    return result;

                return funclib.Core.Invoke(this._rf, result, input);
            }
            #endregion
        }
    }
}

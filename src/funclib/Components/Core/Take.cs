using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="funclib.Components.Core.LazySeq"/> of the funclib.Core.First( n items in the coll, or all items
    /// if there are fewer than n.
    /// </summary>
    public class Take :
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        public object Invoke(object n) => funclib.Core.Func(rf => new TransducerFunction(n, rf));
        /// <summary>
        /// Returns a <see cref="funclib.Components.Core.LazySeq"/> of the funclib.Core.First( n items in the coll, or all items
        /// if there are fewer than n.
        /// </summary>
        /// <param name="n">An <see cref="int"/> of the items to take from the collection.</param>
        /// <param name="coll">The collection to take the funclib.Core.First( x items from.</param>
        /// <returns>
        /// Returns a <see cref="funclib.Components.Core.LazySeq"/> of the funclib.Core.First( n items in the coll, or all items
        /// if there are fewer than n.
        /// </returns>
        public object Invoke(object n, object coll) =>
            funclib.Core.LazySeq(funclib.Core.Func(() =>
            {
                if ((bool)funclib.Core.IsPos(n))
                {
                    var s = funclib.Core.Seq(coll);
                    if (funclib.Core.T(s))
                        return funclib.Core.Cons(funclib.Core.First(s), Invoke(funclib.Core.Dec(n), funclib.Core.Rest(s)));
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
                this._nv = (Volatileǃ)funclib.Core.Volatileǃ(n);
            }

            #region Overrides
            public override object Invoke(object result, object input)
            {
                var n = this._nv.Deref();
                var nn = new VSwapǃ(this._nv, new Dec()).Invoke();
                result = (bool)funclib.Core.IsPos(n)
                    ? funclib.Core.Invoke(this._rf, result, input)
                    : result;

                if ((bool)funclib.Core.Not(funclib.Core.IsPos(nn)))
                    return funclib.Core.EnsureReduced(result);

                return result;
            }
            #endregion
        }
    }
}

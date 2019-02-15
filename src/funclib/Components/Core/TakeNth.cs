using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="funclib.Components.Core.LazySeq"/> of every nth item in coll.
    /// </summary>
    public class TakeNth :
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        public object Invoke(object n) => funclib.Core.Func(rf => new TransducerFunction(n, rf));
        /// <summary>
        /// Returns a <see cref="funclib.Components.Core.LazySeq"/> of every nth item in coll.
        /// </summary>
        /// <param name="n">An <see cref="int"/> of the items to take every nth from collection.</param>
        /// <param name="coll">The collection to drop the funclib.Core.First( x items from.</param>
        /// <returns>
        /// Returns a <see cref="funclib.Components.Core.LazySeq"/> of every nth item in coll.
        /// </returns>
        public object Invoke(object n, object coll) =>
            funclib.Core.LazySeq(() =>
            {
                var s = funclib.Core.Seq(coll);
                if (funclib.Core.T(s))
                {
                    return funclib.Core.Cons(funclib.Core.First(s), Invoke(n, funclib.Core.Drop(n, s)));
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
                this._iv = (Volatileǃ)funclib.Core.Volatileǃ(-1);
            }

            #region Overrides
            public override object Invoke(object result, object input)
            {
                var i = new VSwapǃ(this._iv, funclib.Core.inc).Invoke();
                if ((bool)funclib.Core.IsZero(funclib.Core.Rem(i, this._n)))
                {
                    return funclib.Core.Invoke(this._rf, result, input);
                }

                return result;
            }
            #endregion
        }
    }
}

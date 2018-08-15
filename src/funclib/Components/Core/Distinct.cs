using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="LazySeq"/> of elements of coll without duplicate values.
    /// </summary>
    public class Distinct :
        IFunction<object>,
        IFunction<object, object>
    {
        /// <summary>
        /// Returns a <see cref="LazySeq"/> of elements of coll without duplicate values.
        /// </summary>
        /// <returns>
        /// Returns a <see cref="IFunction{T1, TResult}"/> that returns a <see cref="TransducerFunction"/>.
        /// </returns>
        public object Invoke() => funclib.Core.Func(rf => new TransducerFunction(rf));
        /// <summary>
        /// Returns a <see cref="LazySeq"/> of elements of coll without duplicate values.
        /// </summary>
        /// <param name="coll">A collection of items to return distinct with.</param>
        /// <returns>
        /// Returns a <see cref="LazySeq"/> of unique items from coll.
        /// </returns>
        public object Invoke(object coll) => step(coll, funclib.Core.HashSet());

        static object step(object xs, object seen) => funclib.Core.LazySeq(() => anonymous(xs, seen));
        static object anonymous(object xs, object seen)
        {
            var f = funclib.Core.First(xs);
            var s = funclib.Core.Seq(xs);
            if ((bool)funclib.Core.Truthy(s))
            {
                if ((bool)funclib.Core.Contains(seen, f))
                {
                    return step(funclib.Core.Rest(s), seen);
                }

                return funclib.Core.Cons(f, step(funclib.Core.Rest(s), funclib.Core.Conj(seen, f)));
            }

            return null;
        }

        public class TransducerFunction :
            ATransducerFunction
        {
            Volatileǃ _seen;

            public TransducerFunction(object rf) :
                base(rf)
            {
                this._seen = (Volatileǃ)funclib.Core.Volatileǃ(funclib.Core.HashSet());
            }

            #region Overrides
            public override object Invoke(object result, object input)
            {
                if ((bool)funclib.Core.Contains(this._seen, input))
                {
                    return result;
                }

                new VSwapǃ(this._seen, new Conj(), input).Invoke();
                return funclib.Core.Invoke(this._rf, result, input);
            }
            #endregion
        }
    }
}

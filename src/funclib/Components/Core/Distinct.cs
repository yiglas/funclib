using System;
using System.Text;
using static funclib.core;

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
        public object Invoke() => func<object, object>(rf => new TransducerFunction(rf));
        /// <summary>
        /// Returns a <see cref="LazySeq"/> of elements of coll without duplicate values.
        /// </summary>
        /// <param name="coll">A collection of items to return distinct with.</param>
        /// <returns>
        /// Returns a <see cref="LazySeq"/> of unique items from coll.
        /// </returns>
        public object Invoke(object coll) => step(coll, hashSet());

        static object step(object xs, object seen) => lazySeq(() => anonymous(xs, seen));
        static object anonymous(object xs, object seen)
        {
            var f = first(xs);
            var s = seq(xs);
            if ((bool)truthy(s))
            {
                if ((bool)contains(seen, f))
                {
                    return step(rest(s), seen);
                }

                return cons(f, step(rest(s), conj(seen, f)));
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
                this._seen = (Volatileǃ)volatileǃ(hashSet());
            }

            #region Overrides
            public override object Invoke(object result, object input)
            {
                if ((bool)contains(this._seen, input))
                {
                    return result;
                }

                new VSwapǃ(this._seen, new Conj(), input).Invoke();
                return invoke(this._rf, result, input);
            }
            #endregion
        }
    }
}

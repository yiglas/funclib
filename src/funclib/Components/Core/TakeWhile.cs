using funclib.Collections;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="LazySeq"/> of successive items from coll while 
    /// <see cref="IFunction{T1, T2, TResult}"/> pred returns a logical true. pred
    /// must be free of side-effects.
    /// </summary>
    public class TakeWhile :
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        public object Invoke(object pred) => new Function<object, object>(rf => new TransducerFunction(pred, rf));
        /// <summary>
        /// Returns a <see cref="LazySeq"/> of successive items from coll while 
        /// <see cref="IFunction{T1, T2, TResult}"/> pred returns a logical true. pred
        /// must be free of side-effects.
        /// </summary>
        /// <param name="pred">An object that implements the <see cref="IFunction{T1, T2, TResult}"/> interface.</param>
        /// <param name="coll">List of times to process.</param>
        /// <returns>
        /// Returns a <see cref="LazySeq"/> of successive items from coll while 
        /// <see cref="IFunction{T1, T2, TResult}"/> pred returns a logical true. pred
        /// must be free of side-effects.
        /// </returns>
        public object Invoke(object pred, object coll) =>
            lazySeq(() =>
            {
                var s = (ISeq)new Seq().Invoke(coll);
                if ((bool)new Truthy().Invoke(s))
                {
                    var result = ((IFunction<object, object>)pred).Invoke(s.First());
                    if ((bool)new Truthy().Invoke(result))
                        return cons(s.First(), Invoke(pred, rest(s)));
                }
                return null;
            });


        public class TransducerFunction :
            ATransducerFunction
        {
            object _pred;

            public TransducerFunction(object pred, object rf) :
                base(rf)
            {
                this._pred = pred;
            }

            #region Overrides
            public override object Invoke(object result, object input) =>
                (bool)new Truthy().Invoke(((IFunction<object, object>)this._pred).Invoke(input))
                    ? ((IFunction<object, object, object>)this._rf).Invoke(result, input)
                    : reduced(result);
            #endregion
        }
    }
}

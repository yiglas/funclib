using funclib.Components.Core.Generic;

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
        public object Invoke(object pred) => funclib.Core.Func(rf => new TransducerFunction(pred, rf));
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
            funclib.Core.LazySeq(() =>
            {
                var s = funclib.Core.Seq(coll);
                if ((bool)funclib.Core.Truthy(s))
                {
                    var result = funclib.Core.Invoke(pred, funclib.Core.First(s));
                    if ((bool)funclib.Core.Truthy(result))
                        return funclib.Core.Cons(funclib.Core.First(s), Invoke(pred, funclib.Core.Rest(s)));
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
                (bool)funclib.Core.Truthy(funclib.Core.Invoke(this._pred, input))
                    ? funclib.Core.Invoke(this._rf, result, input)
                    : funclib.Core.Reduced(result);
            #endregion
        }
    }
}

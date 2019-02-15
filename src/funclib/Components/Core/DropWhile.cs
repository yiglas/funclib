using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="funclib.Components.Core.LazySeq"/> of the items in coll starting from the funclib.Core.First( item
    /// for which the predicate returns a logical false.
    /// </summary>
    public class DropWhile :
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        public object Invoke(object pred) => funclib.Core.Func(rf => new TransducerFunction(pred, rf));
        /// <summary>
        /// Returns a <see cref="funclib.Components.Core.LazySeq"/> of the items in coll starting from the funclib.Core.First( item
        /// for which the predicate returns a logical false.
        /// </summary>
        /// <param name="pred">An object that implements the <see cref="IFunction{T1, T2, TResult}"/> interface.</param>
        /// <param name="coll">List of times to process.</param>
        /// <returns>
        /// Returns a <see cref="funclib.Components.Core.LazySeq"/> with items starting from the funclib.Core.First( logically false item in coll.
        /// </returns>
        public object Invoke(object pred, object coll) => funclib.Core.LazySeq(() => step(pred, coll));

        static object step(object pred, object coll)
        {
            var s = funclib.Core.Seq(coll);
            if (funclib.Core.T(funclib.Core.And(s, funclib.Core.Invoke(pred, funclib.Core.First(s)))))
                return step(pred, funclib.Core.Rest(s));

            return s;
        }


        public class TransducerFunction :
            ATransducerFunction
        {
            object _pred;
            Volatileǃ _dv;

            public TransducerFunction(object pred, object rf) :
                base(rf)
            {
                this._pred = pred;
                this._dv = (Volatileǃ)funclib.Core.Volatileǃ(true);
            }

            #region Overrides
            public override object Invoke(object result, object input)
            {
                var drop = this._dv.Deref();
                if (funclib.Core.T(funclib.Core.And(drop, funclib.Core.Invoke(this._pred, input))))
                {
                    return result;
                }

                funclib.Core.VResetǃ(this._dv, null);
                return funclib.Core.Invoke(this._rf, result, input);
            }
            #endregion
        }
    }
}

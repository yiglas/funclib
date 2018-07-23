using funclib.Collections;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="LazySeq"/> of the items in coll starting from the first item 
    /// for which the predicate returns a logical false.
    /// </summary>
    public class DropWhile :
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        public object Invoke(object pred) => new Function<object, object>(rf => new TransducerFunction(pred, rf));
        /// <summary>
        /// Returns a <see cref="LazySeq"/> of the items in coll starting from the first item 
        /// for which the predicate returns a logical false.
        /// </summary>
        /// <param name="pred">An object that implements the <see cref="IFunction{T1, T2, TResult}"/> interface.</param>
        /// <param name="coll">List of times to process.</param>
        /// <returns>
        /// Returns a <see cref="LazySeq"/> with items starting from the first logically false item in coll.
        /// </returns>
        public object Invoke(object pred, object coll)
        {
            return lazySeq(() => step((IFunction<object, object>)pred, coll));

            object step(IFunction<object, object> p, object c)
            {
                var s = (ISeq)seq(c);
                if ((bool)new Truthy().Invoke(and(s, p.Invoke(s?.First()))))
                    return step(p, rest(s));

                return s;
            }
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
                this._dv = (Volatileǃ)new Volatileǃ().Invoke(true);
            }

            #region Overrides
            public override object Invoke(object result, object input)
            {
                var drop = this._dv.Deref();
                if ((bool)new Truthy().Invoke(and(drop, ((IFunction<object, object>)this._pred).Invoke(input))))
                {
                    return result;
                }

                new VResetǃ().Invoke(this._dv, null);
                return ((IFunction<object, object, object>)this._rf).Invoke(result, input);
            }
            #endregion
        }
    }
}

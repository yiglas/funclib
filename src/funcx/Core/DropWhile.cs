using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class DropWhile :
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        public object Invoke(object pred) => new Function<object, object>(rf => new TransducerFunction(pred, rf));
        public object Invoke(object pred, object coll)
        {
            return new LazySeq(() => step((IFunction<object, object>)pred, coll));

            object step(IFunction<object, object> p, object c)
            {
                var s = (ISeq)new Seq().Invoke(c);
                if ((bool)new Truthy().Invoke(new And().Invoke(s, p.Invoke(s.First()))))
                    return step(p, new Rest().Invoke(s));

                return s;
            }
        }


        public class TransducerFunction :
            ATransducerFunction
        {
            object _pred;
            Volatile _dv;

            public TransducerFunction(object pred, object rf) :
                base(rf)
            {
                this._pred = pred;
                this._dv = (Volatile)new Volatile_().Invoke(true);
            }

            #region Overrides
            public override object Invoke(object result, object input)
            {
                var drop = this._dv.Deref();
                if ((bool)new Truthy().Invoke(new And().Invoke(drop, ((IFunction<object, object>)this._pred).Invoke(input))))
                {
                    return result;
                }

                new VReset_().Invoke(this._dv, null);
                return ((IFunction<object, object, object>)this._rf).Invoke(result, input);
            }
            #endregion
        }
    }
}

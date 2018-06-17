using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Drop :
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        public object Invoke(object arg1) => throw new NotImplementedException();
        public object Invoke(object n, object coll) => new LazySeq(() => step(n, coll));

        object step(object n, object coll)
        {
            var s = new Seq().Invoke(coll);
            if ((bool)new And().Invoke(new IsPos().Invoke(n), s))
            {
                return step(new Dec().Invoke(n), new Rest().Invoke(s));
            }
            return s;
        }

        public class TransducerFunction :
            ATransducerFunction
        {
            Volatile _nv;

            public TransducerFunction(object n, object rf) :
                base(rf)
            {
                this._nv = (Volatile)new Volatile_().Invoke(n);
            }

            #region Overrides
            public override object Invoke(object result, object input)
            {
                var n = this._nv.Deref();
                new VSwap_(this._nv, new Dec());
                if ((bool)new IsPos().Invoke(n))
                    return result;

                return ((IFunction<object, object, object>)this._rf).Invoke(result, input);
            }
            #endregion
        }
    }
}

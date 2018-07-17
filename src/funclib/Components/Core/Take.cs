using funclib.Collections;
using System;
using System.Linq;
using System.Text;

namespace funclib.Components.Core
{
    public class Take :
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        public object Invoke(object n) => new Function<object, object>(rf => new TransducerFunction(n, rf));
        public object Invoke(object n, object coll) =>
            new LazySeq(new Function<object>(() =>
            {
                if ((bool)new IsPos().Invoke(n))
                {
                    var s = (ISeq)new Seq().Invoke(coll);
                    if ((bool)new Truthy().Invoke(s))
                        return new Cons().Invoke(s.First(), Invoke(new Dec().Invoke(n), new Rest().Invoke(s)));
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
                this._nv = (Volatileǃ)new Volatileǃ().Invoke(n);
            }

            #region Overrides
            public override object Invoke(object result, object input)
            {
                var n = this._nv.Deref();
                var nn = new VSwapǃ(this._nv, new Dec());
                result = (bool)new IsPos().Invoke(n) ? ((IFunction<object, object, object>)this._rf).Invoke(result, input) : result;

                if ((bool)new Not().Invoke(new IsPos().Invoke(nn)))
                    return new EnsureReduced().Invoke(result);

                return result;
            }
            #endregion
        }
    }
}

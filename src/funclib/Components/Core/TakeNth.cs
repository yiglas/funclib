using funclib.Collections;
using System;
using System.Text;

namespace funclib.Components.Core
{
    public class TakeNth :
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        public object Invoke(object n) => new Function<object, object>(rf => new TransducerFunction(n, rf));
        public object Invoke(object n, object coll) =>
            new LazySeq(() =>
            {
                var s = (ISeq)new Seq().Invoke(coll);
                if ((bool)new Truthy().Invoke(s))
                {
                    return new Cons().Invoke(s.First(), Invoke(n, new Drop().Invoke(n, s)));
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
                this._iv = (Volatileǃ)new Volatileǃ().Invoke(-1);
            }

            #region Overrides
            public override object Invoke(object result, object input)
            {
                var i = new VSwapǃ(this._iv, new Inc()).Invoke();
                if ((bool)new IsZero().Invoke(new Rem().Invoke(i, this._n)))
                {
                    return ((IFunction<object, object, object>)this._rf).Invoke(result, input);
                }

                return result;
            }
            #endregion
        }
    }
}

using System;
using System.Text;

namespace funclib.Components.Core
{
    public class HaltWhen :
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        public object Invoke(object pred) => Invoke(pred, null);
        public object Invoke(object pred, object retf) =>
            new Function<object, object>(rf => new TransducerFunction(pred, retf, rf));


        public class TransducerFunction :
            ATransducerFunction
        {
            IFunction<object, object> _pred;
            IFunction<object, object, object> _retf;

            public TransducerFunction(object pred, object retf, object rf) :
                base(rf)
            {
                this._pred = (IFunction<object, object>)pred;
                this._retf = (IFunction<object, object, object>)retf;
            }

            #region Overrides
            public override object Invoke(object result)
            {
                if ((bool)new Truthy().Invoke(new And().Invoke(new IsMap().Invoke(result), new Contains().Invoke(result, "::halt"))))
                {
                    return new Get().Invoke(result, "::halt");
                }

                return ((IFunction<object, object>)this._rf).Invoke(result);
            }
            public override object Invoke(object result, object input)
            {
                if ((bool)new Truthy().Invoke(this._pred.Invoke(input)))
                {
                    var haltVal = (bool)new Truthy().Invoke(this._retf) ? this._retf.Invoke(((IFunction<object, object>)this._rf).Invoke(result), input) : input;
                    return new Reduced().Invoke(new HashMap().Invoke("::halt", haltVal));
                }

                return ((IFunction<object, object, object>)this._rf).Invoke(result, input);
            }
            #endregion
        }
    }
}

using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    public class HaltWhen :
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        public object Invoke(object pred) => Invoke(pred, null);
        public object Invoke(object pred, object retf) => funclib.Core.Func(rf => new TransducerFunction(pred, retf, rf));


        public class TransducerFunction :
            ATransducerFunction
        {
            object _pred;
            object _retf;

            public TransducerFunction(object pred, object retf, object rf) :
                base(rf)
            {
                this._pred = pred;
                this._retf = retf;
            }

            #region Overrides
            public override object Invoke(object result)
            {
                if (funclib.Core.T(funclib.Core.And(funclib.Core.IsMap(result), funclib.Core.Contains(result, "::halt"))))
                {
                    return funclib.Core.Get(result, "::halt");
                }

                return funclib.Core.Invoke(this._rf, result);
            }
            public override object Invoke(object result, object input)
            {
                if (funclib.Core.T(funclib.Core.Invoke(this._pred, input)))
                {
                    var haltVal = funclib.Core.T(this._retf) ? funclib.Core.Invoke(this._retf, funclib.Core.Invoke(this._rf, result), input) : input;
                    return funclib.Core.Reduced(funclib.Core.HashMap("::halt", haltVal));
                }

                return funclib.Core.Invoke(this._rf, result, input);
            }
            #endregion
        }
    }
}

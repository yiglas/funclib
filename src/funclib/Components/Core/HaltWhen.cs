using System;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    public class HaltWhen :
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        public object Invoke(object pred) => Invoke(pred, null);
        public object Invoke(object pred, object retf) => func<object, object>(rf => new TransducerFunction(pred, retf, rf));


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
                if ((bool)truthy(and(isMap(result), contains(result, "::halt"))))
                {
                    return get(result, "::halt");
                }

                return invoke(this._rf, result);
            }
            public override object Invoke(object result, object input)
            {
                if ((bool)truthy(invoke(this._pred, input)))
                {
                    var haltVal = (bool)truthy(this._retf) ? invoke(this._retf, invoke(this._rf, result), input) : input;
                    return reduced(hashMap("::halt", haltVal));
                }

                return invoke(this._rf, result, input);
            }
            #endregion
        }
    }
}

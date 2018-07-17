using funclib.Collections;
using System;
using System.Text;

namespace funclib.Components.Core
{
    public class TakeWhile :
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        public object Invoke(object pred) => new Function<object, object>(rf => new TransducerFunction(pred, rf));
        public object Invoke(object pred, object coll) =>
            new LazySeq(() =>
            {
                var s = (ISeq)new Seq().Invoke(coll);
                if ((bool)new Truthy().Invoke(s))
                {
                    var result = ((IFunction<object, object>)pred).Invoke(s.First());
                    if ((bool)new Truthy().Invoke(result))
                        return new Cons().Invoke(s.First(), Invoke(pred, new Rest().Invoke(s)));
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
                (bool)new Truthy().Invoke(((IFunction<object, object>)this._pred).Invoke(input))
                    ? ((IFunction<object, object, object>)this._rf).Invoke(result, input)
                    : new Reduced().Invoke(result);
            #endregion
        }
    }
}

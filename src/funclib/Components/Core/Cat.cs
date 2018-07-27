using System;
using System.Text;
using static funclib.core;

namespace funclib.Components.Core
{
    public class Cat :
        IFunction<object, object>
    {
        public object Invoke(object rf) => new TransducerFunction(rf);

        public class TransducerFunction :
            ATransducerFunction
        {
            object _rrf;

            public TransducerFunction(object rf) : 
                base(rf)
            {
                this._rrf = preservingReduced(rf);
            }

            #region Override
            public override object Invoke(object result, object input) => reduce(this._rrf, result, input);
            #endregion
        }
    }
}

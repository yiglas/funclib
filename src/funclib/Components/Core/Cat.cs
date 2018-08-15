using funclib.Components.Core.Generic;

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
                this._rrf = funclib.Core.PreservingReduced(rf);
            }

            #region Override
            public override object Invoke(object result, object input) => funclib.Core.Reduce(this._rrf, result, input);
            #endregion
        }
    }
}

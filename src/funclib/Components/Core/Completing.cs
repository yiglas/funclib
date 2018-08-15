using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    public class Completing :
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        public object Invoke(object f) => Invoke(f, funclib.Core.identity);
        public object Invoke(object f, object cf) => new TransducerFunction(f, cf);

        public class TransducerFunction :
            ATransducerFunction
        {
            object _f;
            object _cf;

            internal TransducerFunction(object f, object cf) :
                base(null)
            {
                this._f = f;
                this._cf = cf;
            }

            #region Overrides
            public override object Invoke() => funclib.Core.Invoke(this._f);
            public override object Invoke(object x) => funclib.Core.Invoke(this._cf, x);
            public override object Invoke(object x, object y) => funclib.Core.Invoke(this._f, x, y);
            #endregion
        }
    }
}

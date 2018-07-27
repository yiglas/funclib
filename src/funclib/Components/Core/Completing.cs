using System;
using System.Text;
using static funclib.core;

namespace funclib.Components.Core
{
    public class Completing :
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        public object Invoke(object f) => Invoke(f, funclib.core.Identity);
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
            public override object Invoke() => invoke(this._f);
            public override object Invoke(object x) => invoke(this._cf, x);
            public override object Invoke(object x, object y) => invoke(this._f, x, y);
            #endregion
        }
    }
}

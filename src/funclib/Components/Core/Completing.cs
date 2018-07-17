using System;
using System.Text;

namespace funclib.Components.Core
{
    public class Completing :
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        public object Invoke(object f) => Invoke(f, new Identity());
        public object Invoke(object f, object cf) => new Function(f, cf);

        public class Function :
            IFunction<object>,
            IFunction<object, object>,
            IFunction<object, object, object>
        {
            object _f;
            object _cf;

            internal Function(object f, object cf)
            {
                this._f = f;
                this._cf = cf;
            }

            public object Invoke() => ((IFunction<object>)this._f).Invoke();
            public object Invoke(object x) => ((IFunction<object, object>)this._cf).Invoke(x);
            public object Invoke(object x, object y) => ((IFunction<object, object, object>)this._f).Invoke(x, y);
        }
    }
}

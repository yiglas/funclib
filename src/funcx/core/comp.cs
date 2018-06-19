using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Comp :
        IFunction<object>,
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunctionParams<object, object, object, object>
    {
        public object Invoke() => new Identity();
        public object Invoke(object f) => f;
        public object Invoke(object f, object g) => new Function(f, g);
        public object Invoke(object f, object g, params object[] fs) =>
            new Reduce1().Invoke(this, new ListS().Invoke(f, g, fs));

        public class Function :
            IFunction<object>,
            IFunction<object, object>,
            IFunction<object, object, object>,
            IFunction<object, object, object, object>,
            IFunctionParams<object, object, object, object, object>
        {
            object _f;
            object _g;

            public Function(object f, object g)
            {
                this._f = f;
                this._g = g;
            }

            public object Invoke() => ((IFunction<object, object>)this._f).Invoke(((IFunction<object>)this._g).Invoke());
            public object Invoke(object x) => ((IFunction<object, object>)this._f).Invoke(((IFunction<object, object>)this._g).Invoke(x));
            public object Invoke(object x, object y) => ((IFunction<object, object>)this._f).Invoke(((IFunction<object, object, object>)this._g).Invoke(x, y));
            public object Invoke(object x, object y, object z) => ((IFunction<object, object>)this._f).Invoke(((IFunction<object, object, object, object>)this._g).Invoke(x, y, z));
            public object Invoke(object x, object y, object z, params object[] args) => ((IFunction<object, object>)this._f).Invoke(new Apply().Invoke(this._g, x, y, z, args));
        }
    }
}

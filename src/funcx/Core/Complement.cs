using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Complement :
        IFunction<object, object>
    {
        public object Invoke(object f) => new Function(f);

        public class Function :
            IFunction<object>,
            IFunction<object, object>,
            IFunction<object, object, object>,
            IFunctionParams<object, object, object, object>
        {
            object _func;

            public Function(object f)
            {
                this._func = f;
            }

            public object Invoke() => new Not().Invoke(((IFunction<object>)this._func).Invoke());
            public object Invoke(object x) => new Not().Invoke(((IFunction<object, object>)this._func).Invoke(x));
            public object Invoke(object x, object y) => new Not().Invoke(((IFunction<object, object, object>)this._func).Invoke(x, y));
            public object Invoke(object x, object y, params object[] zs) => new Not().Invoke(new Apply().Invoke(this._func, x, y, zs));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Components.Core
{
    public class Partial :
        IFunction<object, object, object>,
        IFunction<object, object, object, object>,
        IFunction<object, object, object, object, object>,
        IFunctionParams<object, object, object, object, object, object>
    {
        public object Invoke(object f, object arg1) => new Function(f, arg1);
        public object Invoke(object f, object arg1, object arg2) => new Function(f, arg1, arg2);
        public object Invoke(object f, object arg1, object arg2, object arg3) => new Function(f, arg1, arg2, arg3);
        public object Invoke(object f, object arg1, object arg2, object arg3, params object[] more) =>
            new FunctionParams<object, object>(args => new Apply().Invoke(f, arg1, arg2, arg3, new Concat().Invoke(more, args)));

        public class Function :
            IFunction<object>,
            IFunction<object, object>,
            IFunction<object, object, object>,
            IFunction<object, object, object, object>,
            IFunctionParams<object, object, object, object, object>
        {
            object _func;
            object _arg1 = null;
            object _arg2 = null;
            object _arg3 = null;
            int _argCount = 0;

            public Function(object f, object arg1)
            {
                this._func = f;
                this._arg1 = arg1;
                this._argCount = 1;
            }

            public Function(object f, object arg1, object arg2)
            {
                this._func = f;
                this._arg1 = arg1;
                this._arg2 = arg2;
                this._argCount = 2;
            }

            public Function(object f, object arg1, object arg2, object arg3)
            {
                this._func = f;
                this._arg1 = arg1;
                this._arg2 = arg2;
                this._arg3 = arg3;
                this._argCount = 3;
            }

            public object Invoke() =>
                this._argCount == 3
                    ? ((IFunction<object, object, object, object>)this._func).Invoke(this._arg1, this._arg2, this._arg3)
                    : this._argCount == 2 ? ((IFunction<object, object, object>)this._func).Invoke(this._arg1, this._arg2)
                    : ((IFunction<object, object>)this._func).Invoke(this._arg1);

            public object Invoke(object x) =>
                this._argCount == 3
                    ? ((IFunction<object, object, object, object, object>)this._func).Invoke(this._arg1, this._arg2, this._arg3, x)
                    : this._argCount == 2 ? ((IFunction<object, object, object, object>)this._func).Invoke(this._arg1, this._arg2, x)
                    : ((IFunction<object, object, object>)this._func).Invoke(this._arg1, x);

            public object Invoke(object x, object y) =>
                this._argCount == 3
                    ? ((IFunction<object, object, object, object, object, object>)this._func).Invoke(this._arg1, this._arg2, this._arg3, x, y)
                    : this._argCount == 2 ? ((IFunction<object, object, object, object, object>)this._func).Invoke(this._arg1, this._arg2, x, y)
                    : ((IFunction<object, object, object, object>)this._func).Invoke(this._arg1, x, y);
            
            public object Invoke(object x, object y, object z) =>
                this._argCount == 3
                    ? ((IFunction<object, object, object, object, object, object, object>)this._func).Invoke(this._arg1, this._arg2, this._arg3, x, y, z)
                    : this._argCount == 2 ? ((IFunction<object, object, object, object, object, object>)this._func).Invoke(this._arg1, this._arg2, x, y, z)
                    : ((IFunction<object, object, object, object, object>)this._func).Invoke(this._arg1, x, y, z);

            public object Invoke(object x, object y, object z, params object[] args) =>
                this._argCount == 3
                    ? new Apply().Invoke(this._func, this._arg1, this._arg2, this._arg3, x, y, z, args)
                    : this._argCount == 2 ? new Apply().Invoke(this._func, this._arg1, this._arg2, x, y, z, args)
                    : new Apply().Invoke(this._func, this._arg1, x, y, z, args);
        }
    }
}

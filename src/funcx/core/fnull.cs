using FunctionalLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class FNull :
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunction<object, object, object, object>,
        IFunctionParams<object, object, object, object, object>
    {
        IFunction<object, object> _f1;
        IFunction<object, object, object> _f2;
        IFunction<object, object, object, object> _f3;
        IFunctionParams<object, object, object, object, object> _f4;

        object _x;
        object _y;
        object _z;

        bool _hasY;
        bool _hasZ;


        public FNull(IFunction<object, object> f, object x)
        {
            this._f1 = f;
            this._x = x;
        }

        public FNull(IFunction<object, object, object> f, object x)
        {
            this._f2 = f;
            this._x = x;
        }

        public FNull(IFunction<object, object, object, object> f, object x)
        {
            this._f3 = f;
            this._x = x;
        }

        public FNull(IFunctionParams<object, object, object, object, object> f, object x)
        {
            this._f4 = f;
            this._x = x;
        }

        public FNull(IFunction<object, object, object> f, object x, object y)
        {
            this._f2 = f;
            this._x = x;
            this._y = y;
            this._hasY = true;
        }

        public FNull(IFunction<object, object, object, object> f, object x, object y)
        {
            this._f3 = f;
            this._x = x;
            this._y = y;
            this._hasY = true;
        }

        public FNull(IFunctionParams<object, object, object, object, object> f, object x, object y)
        {
            this._f4 = f;
            this._x = x;
            this._y = y;
            this._hasY = true;
        }

        public FNull(IFunction<object, object, object, object> f, object x, object y, object z)
        {
            this._f3 = f;
            this._x = x;
            this._y = y;
            this._z = z;
            this._hasY = true;
            this._hasZ = true;
        }

        public FNull(IFunctionParams<object, object, object, object, object> f, object x, object y, object z)
        {
            this._f4 = f;
            this._x = x;
            this._y = y;
            this._z = z;
            this._hasY = true;
            this._hasZ = true;
        }

        public object Invoke(object a) =>
            this._f1 != null
                ? this._f1.Invoke(a ?? this._x)
                : ThrowArityException(1);

        public object Invoke(object a, object b) =>
            this._f1 != null
                ? ThrowArityException(2)
                : this._f2 != null ? this._f2.Invoke(a ?? this._x, this._hasY ? b ?? this._y : b)
                : ThrowArityException(2);

        public object Invoke(object a, object b, object c) =>
            this._f1 != null || this._f2 != null
                ? ThrowArityException(3)
                : this._f3 != null ? this._f3.Invoke(a ?? this._x, this._hasY ? b ?? this._y : b, this._hasZ ? c ?? this._z : c)
                : ThrowArityException(3);

        public object Invoke(object a, object b, object c, params object[] ds) =>
            this._f1 != null || this._f2 != null || this._f3 != null
                ? ThrowArityException(4)
                : this._f4 != null ? new Apply().Invoke(this._f4, a ?? this._x, this._hasY ? b ?? this._y : b, this._hasZ ? c ?? this._z : c, ds)
                : ThrowArityException(3);

        object ThrowArityException(int actual, [CallerMemberName] string methodName = "")
        {
            if (this._f1 != null) throw new ArityException(actual, this._f1.GetType().FullName);
            if (this._f2 != null) throw new ArityException(actual, this._f2.GetType().FullName);
            if (this._f3 != null) throw new ArityException(actual, this._f3.GetType().FullName);
            if (this._f4 != null) throw new ArityException(actual, this._f4.GetType().FullName);
            throw new ArityException(actual, methodName);
        }
    }
}

using FunctionalLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace FunctionalLibrary.Core
{
    /// <summary>
    /// Takes a <see cref="IFunction"/> f, and returns a <see cref="Function"/> that calls f, replacing
    /// a null first argument with the supplied value x. Higher arity versions can replace arguments in
    /// the second and third positions.  Note: that the function f can take any number of arguments,
    /// not just the one(s) being null-patched.
    /// </summary>
    public class FNull :
        IFunction<object, object, object>,
        IFunction<object, object, object, object>,
        IFunction<object, object, object, object, object>
    {
        /// <summary>
        /// Takes a <see cref="IFunction"/> f, and returns a <see cref="Function"/> that calls f, replacing
        /// a null first argument with the supplied value x. Higher arity versions can replace arguments in
        /// the second and third positions.  Note: that the function f can take any number of arguments,
        /// not just the one(s) being null-patched.
        /// </summary>
        /// <param name="f">An object that implements <see cref="IFunction"/> interface.</param>
        /// <param name="x">Object to replace a first parameter passed thats null.</param>
        /// <returns>
        /// Returns a <see cref="Function"/> that is null-patched.
        /// </returns>
        public object Invoke(object f, object x) => new Function(f, 1, x);
        /// <summary>
        /// Takes a <see cref="IFunction"/> f, and returns a <see cref="Function"/> that calls f, replacing
        /// a null first argument with the supplied value x. Higher arity versions can replace arguments in
        /// the second and third positions.  Note: that the function f can take any number of arguments,
        /// not just the one(s) being null-patched.
        /// </summary>
        /// <param name="f">An object that implements <see cref="IFunction"/> interface.</param>
        /// <param name="x">Object to replace a first parameter passed thats null.</param>
        /// <param name="y">Object to replace a second parameter passed thats null.</param>
        /// <returns>
        /// Returns a <see cref="Function"/> that is null-patched.
        /// </returns>
        public object Invoke(object f, object x, object y) => new Function(f, 2, x, y);
        /// <summary>
        /// Takes a <see cref="IFunction"/> f, and returns a <see cref="Function"/> that calls f, replacing
        /// a null first argument with the supplied value x. Higher arity versions can replace arguments in
        /// the second and third positions.  Note: that the function f can take any number of arguments,
        /// not just the one(s) being null-patched.
        /// </summary>
        /// <param name="f">An object that implements <see cref="IFunction"/> interface.</param>
        /// <param name="x">Object to replace a first parameter passed thats null.</param>
        /// <param name="y">Object to replace a second parameter passed thats null.</param>
        /// <param name="z">Object to replace a third parameter passed thats null.</param>
        /// <returns>
        /// Returns a <see cref="Function"/> that is null-patched.
        /// </returns>
        public object Invoke(object f, object x, object y, object z) => new Function(f, 3, x, y, z);

        public class Function :
            IFunction<object, object>,
            IFunction<object, object, object>,
            IFunction<object, object, object, object>,
            IFunctionParams<object, object, object, object, object>
        {
            object _f;
            object _x;
            object _y;
            object _z;
            int _count;

            public Function(object f, int count, object x) :
                this(f, count, x, null, null)
            {   
            }

            public Function(object f, int count, object x, object y) :
                this(f, count, x, y, null)
            {
            }

            public Function(object f, int count, object x, object y, object z)
            {
                this._f = f;
                this._x = x;
                this._y = y;
                this._z = z;
                this._count = count;
            }

            public object Invoke(object a)
            {
                var fn = this._f as IFunction<object, object>;
                if (fn == null)
                    throw new ArityException(1, this._f.GetType().FullName);

                return fn.Invoke(a ?? this._x);
            }
            public object Invoke(object a, object b)
            {
                var fn = this._f as IFunction<object, object, object>;
                if (fn == null)
                    throw new ArityException(2, this._f.GetType().FullName);

                var x = a ?? this._x;
                var y = this._count == 1 ? b : b ?? this._y;

                return fn.Invoke(x, y);
            }
            public object Invoke(object a, object b, object c)
            {
                var fn = this._f as IFunction<object, object, object, object>;
                if (fn == null)
                    throw new ArityException(3, this._f.GetType().FullName);

                var x = a ?? this._x;
                var y = this._count == 1 ? b : b ?? this._y;
                var z = this._count == 2 ? c : c ?? this._z;

                return fn.Invoke(x, y, z);
            }
            public object Invoke(object a, object b, object c, params object[] ds)
            {
                var x = a ?? this._x;
                var y = this._count == 1 ? b : b ?? this._y;
                var z = this._count == 2 ? c : c ?? this._z;

                return new Apply().Invoke(this._f, x, y, z, ds);
            }
        }
    }
}

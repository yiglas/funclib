﻿using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Takes a <see cref="IFunction"/> f, and returns a <see cref="IFunction"/> that calls f, replacing
    /// a null funclib.Core.First( argument with the supplied value x. Higher arity versions can replace arguments in
    /// the second and third positions.  Note: that the function f can take any number of arguments,
    /// not just the one(s) being null-patched.
    /// </summary>
    public class FNull :
        IFunction<object, object, object>,
        IFunction<object, object, object, object>,
        IFunction<object, object, object, object, object>
    {
        /// <summary>
        /// Takes a <see cref="IFunction"/> f, and returns a <see cref="IFunction"/> that calls f, replacing
        /// a null funclib.Core.First( argument with the supplied value x. Higher arity versions can replace arguments in
        /// the second and third positions.  Note: that the function f can take any number of arguments,
        /// not just the one(s) being null-patched.
        /// </summary>
        /// <param name="f">An object that implements <see cref="IFunction"/> interface.</param>
        /// <param name="x">Object to replace a funclib.Core.First( parameter passed thats null.</param>
        /// <returns>
        /// Returns a <see cref="IFunction"/> that is null-patched.
        /// </returns>
        public object Invoke(object f, object x) => new Function(f, 1, x);
        /// <summary>
        /// Takes a <see cref="IFunction"/> f, and returns a <see cref="IFunction"/> that calls f, replacing
        /// a null funclib.Core.First( argument with the supplied value x. Higher arity versions can replace arguments in
        /// the second and third positions.  Note: that the function f can take any number of arguments,
        /// not just the one(s) being null-patched.
        /// </summary>
        /// <param name="f">An object that implements <see cref="IFunction"/> interface.</param>
        /// <param name="x">Object to replace a funclib.Core.First( parameter passed thats null.</param>
        /// <param name="y">Object to replace a second parameter passed thats null.</param>
        /// <returns>
        /// Returns a <see cref="IFunction"/> that is null-patched.
        /// </returns>
        public object Invoke(object f, object x, object y) => new Function(f, 2, x, y);
        /// <summary>
        /// Takes a <see cref="IFunction"/> f, and returns a <see cref="IFunction"/> that calls f, replacing
        /// a null funclib.Core.First( argument with the supplied value x. Higher arity versions can replace arguments in
        /// the second and third positions.  Note: that the function f can take any number of arguments,
        /// not just the one(s) being null-patched.
        /// </summary>
        /// <param name="f">An object that implements <see cref="IFunction"/> interface.</param>
        /// <param name="x">Object to replace a funclib.Core.First( parameter passed thats null.</param>
        /// <param name="y">Object to replace a second parameter passed thats null.</param>
        /// <param name="z">Object to replace a third parameter passed thats null.</param>
        /// <returns>
        /// Returns a <see cref="IFunction"/> that is null-patched.
        /// </returns>
        public object Invoke(object f, object x, object y, object z) => new Function(f, 3, x, y, z);

        /// <summary>
        /// Internal function that does the <see cref="FNull"/>.
        /// </summary>
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

            internal Function(object f, int count, object x) :
                this(f, count, x, null, null)
            {
            }

            internal Function(object f, int count, object x, object y) :
                this(f, count, x, y, null)
            {
            }

            internal Function(object f, int count, object x, object y, object z)
            {
                this._f = f;
                this._x = x;
                this._y = y;
                this._z = z;
                this._count = count;
            }

            /// <summary>
            /// Execute the <see cref="IFunction"/>
            /// </summary>
            /// <param name="a">Parameter of the function.</param>
            /// <returns>
            /// Returns the results of invoking the <see cref="IFunction"/> function.
            /// </returns>
            public object Invoke(object a) => funclib.Core.Invoke(this._f, a ?? this._x);
            /// <summary>
            /// Execute the <see cref="IFunction"/>
            /// </summary>
            /// <param name="a">First parameter of the function.</param>
            /// <param name="b">Second parameter of the function.</param>
            /// <returns>
            /// Returns the results of invoking the <see cref="IFunction"/> function.
            /// </returns>
            public object Invoke(object a, object b) =>
                funclib.Core.Invoke(this._f,
                    a ?? this._x,
                    this._count == 1 ? b : b ?? this._y);
            /// <summary>
            /// Execute the <see cref="IFunction"/>
            /// </summary>
            /// <param name="a">First parameter of the function.</param>
            /// <param name="b">Second parameter of the function.</param>
            /// <param name="c">Third parameter of the function.</param>
            /// <returns>
            /// Returns the results of invoking the <see cref="IFunction"/> function.
            /// </returns>
            public object Invoke(object a, object b, object c) =>
                funclib.Core.Invoke(this._f,
                    a ?? this._x,
                    this._count == 1 ? b : b ?? this._y,
                    this._count == 2 ? c : c ?? this._z);
            /// <summary>
            /// Execute the <see cref="IFunction"/>
            /// </summary>
            /// <param name="a">First parameter of the function.</param>
            /// <param name="b">Second parameter of the function.</param>
            /// <param name="c">Third parameter of the function.</param>
            /// <param name="ds">Rest of the parameters of the function.</param>
            /// <returns>
            /// Returns the results of invoking the <see cref="IFunction"/> function.
            /// </returns>
            public object Invoke(object a, object b, object c, params object[] ds) =>
                funclib.Core.Apply(this._f,
                    a ?? this._x,
                    this._count == 1 ? b : b ?? this._y,
                    this._count == 2 ? c : c ?? this._z,
                    ds);
        }
    }
}

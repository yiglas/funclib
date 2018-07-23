using funclib.Collections;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Takes a <see cref="IFunction"/> f and fewer than the normal arguments, and returns a 
    /// <see cref="Function"/> that take the rest of the arguments.
    /// </summary>
    public class Partial :
        IFunction<object, object, object>,
        IFunction<object, object, object, object>,
        IFunction<object, object, object, object, object>,
        IFunctionParams<object, object, object, object, object, object>
    {
        /// <summary>
        /// Takes a <see cref="IFunction"/> f and fewer than the normal arguments, and returns a 
        /// <see cref="Function"/> that take the rest of the arguments.
        /// </summary>
        /// <param name="f">Object that implements the <see cref="IFunction"/> interface.</param>
        /// <param name="arg1">First argument to the function.</param>
        /// <returns>
        /// Returns <see cref="Function"/> that when executed will take args + additional args.
        /// </returns>
        public object Invoke(object f, object arg1) => new Function(f, arg1);
        /// <summary>
        /// Takes a <see cref="IFunction"/> f and fewer than the normal arguments, and returns a 
        /// <see cref="Function"/> that take the rest of the arguments.
        /// </summary>
        /// <param name="f">Object that implements the <see cref="IFunction"/> interface.</param>
        /// <param name="arg1">First argument to the function.</param>
        /// <param name="arg2">Second argument to the function.</param>
        /// <returns>
        /// Returns <see cref="Function"/> that when executed will take args + additional args.
        /// </returns>
        public object Invoke(object f, object arg1, object arg2) => new Function(f, arg1, arg2);
        /// <summary>
        /// Takes a <see cref="IFunction"/> f and fewer than the normal arguments, and returns a 
        /// <see cref="Function"/> that take the rest of the arguments.
        /// </summary>
        /// <param name="f">Object that implements the <see cref="IFunction"/> interface.</param>
        /// <param name="arg1">First argument to the function.</param>
        /// <param name="arg2">Second argument to the function.</param>
        /// <param name="arg3">Third argument to the function.</param>
        /// <returns>
        /// Returns <see cref="Function"/> that when executed will take args + additional args.
        /// </returns>
        public object Invoke(object f, object arg1, object arg2, object arg3) => new Function(f, arg1, arg2, arg3);
        /// <summary>
        /// Takes a <see cref="IFunction"/> f and fewer than the normal arguments, and returns a 
        /// <see cref="Function"/> that take the rest of the arguments.
        /// </summary>
        /// <param name="f">Object that implements the <see cref="IFunction"/> interface.</param>
        /// <param name="arg1">First argument to the function.</param>
        /// <param name="arg2">Second argument to the function.</param>
        /// <param name="arg3">Third argument to the function.</param>
        /// <param name="more">Rest of the arguments to the function.</param>
        /// <returns>
        /// Returns <see cref="Function"/> that when executed will take args + additional args.
        /// </returns>
        public object Invoke(object f, object arg1, object arg2, object arg3, params object[] more) =>
            new Function(f, arg1, arg2, arg3, more);

        /// <summary>
        /// Internal function that does the <see cref="Partial"/>.
        /// </summary>
        public class Function :
            IFunction<object>,
            IFunction<object, object>,
            IFunction<object, object, object>,
            IFunction<object, object, object, object>,
            IFunctionParams<object, object, object, object, object>
        {
            IFunction _func;
            object _arg1 = null;
            object _arg2 = null;
            object _arg3 = null;
            object[] _more = null;
            int _argCount = 0;

            internal Function(object f, object arg1) :
                this(f, arg1, null, null, null, 1)
            { }

            internal Function(object f, object arg1, object arg2) :
                this(f, arg1, arg2, null, null, 2)
            { }

            internal Function(object f, object arg1, object arg2, object arg3) :
                this(f, arg1, arg2, arg3, null, 3)
            { }

            internal Function(object f, object arg1, object arg2, object arg3, object[] more) :
                this(f, arg1, arg2, arg3, more, 4)
            { }

            Function(object f, object arg1, object arg2, object arg3, object[] more, int count)
            {
                this._func = (IFunction)f;
                this._arg1 = arg1;
                this._arg2 = arg2;
                this._arg3 = arg3;
                this._more = more;
                this._argCount = count;
            }

            /// <summary>
            /// Executes the function with the initial arguments.
            /// </summary>
            /// <returns>
            /// Returns the result of calling the function with no additional parameters.
            /// </returns>
            public object Invoke() =>
                this._argCount == 4
                    ? apply(this._func, this._arg1, this._arg2, this._arg3, seq(this._more))
                    : this._argCount == 3 ? Apply.ApplyTo(this._func, (ISeq)list(this._arg1, this._arg2, this._arg3))
                    : this._argCount == 2 ? Apply.ApplyTo(this._func, (ISeq)list(this._arg1, this._arg2))
                    : Apply.ApplyTo(this._func, (ISeq)list(this._arg1));
            /// <summary>
            /// Executes the function with the initial arguments.
            /// </summary>
            /// <param name="x">Last argument to the function.</param>
            /// <returns>
            /// Returns the result of calling the function with the args + x
            /// </returns>
            public object Invoke(object x) =>
                this._argCount == 4
                    ? apply(this._func, this._arg1, this._arg2, this._arg3, concat(this._more, new object[] { x }))
                    : this._argCount == 3 ? Apply.ApplyTo(this._func, (ISeq)list(this._arg1, this._arg2, this._arg3, x))
                    : this._argCount == 2 ? Apply.ApplyTo(this._func, (ISeq)list(this._arg1, this._arg2, x))
                    : Apply.ApplyTo(this._func, (ISeq)list(this._arg1, x));
            /// <summary>
            /// Executes the function with the initial arguments.
            /// </summary>
            /// <param name="x">Second to last argument to the function.</param>
            /// <param name="y">Last argument to the function.</param>
            /// <returns>
            /// Returns the result of calling the function with the args, x + y
            /// </returns>
            public object Invoke(object x, object y) =>
                this._argCount == 4
                    ? apply(this._func, this._arg1, this._arg2, this._arg3, concat(this._more, new object[] { x, y }))
                    : this._argCount == 3 ? Apply.ApplyTo(this._func, (ISeq)list(this._arg1, this._arg2, this._arg3, x, y))
                    : this._argCount == 2 ? Apply.ApplyTo(this._func, (ISeq)list(this._arg1, this._arg2, x, y))
                    : Apply.ApplyTo(this._func, (ISeq)list(this._arg1, x, y));
            /// <summary>
            /// Executes the function with the initial arguments.
            /// </summary>
            /// <param name="x">Third to last argument to the function.</param>
            /// <param name="y">Second to last argument to the function.</param>
            /// <param name="z">Last argument to the function.</param>
            /// <returns>
            /// Returns the result of calling the function with the args, x, y + z
            /// </returns>
            public object Invoke(object x, object y, object z) =>
                this._argCount == 4
                    ? apply(this._func, this._arg1, this._arg2, this._arg3, concat(this._more, new object[] { x, y, z }))
                    : this._argCount == 3 ? Apply.ApplyTo(this._func, (ISeq)list(this._arg1, this._arg2, this._arg3, x, y, z))
                    : this._argCount == 2 ? Apply.ApplyTo(this._func, (ISeq)list(this._arg1, this._arg2, x, y, z))
                    : Apply.ApplyTo(this._func, (ISeq)list(this._arg1, x, y, z));
            /// <summary>
            /// Executes the function with the initial arguments.
            /// </summary>
            /// <param name="x">Fourth to last argument to the function.</param>
            /// <param name="y">Third to last argument to the function.</param>
            /// <param name="z">Second to last argument to the function.</param>
            /// <param name="args">Last argument list to the function.</param>
            /// <returns>
            /// Returns the result of calling the function with the args, x, y, z + args
            /// </returns>
            public object Invoke(object x, object y, object z, params object[] args) =>
               this._argCount == 4
                    ? apply(this._func, this._arg1, this._arg2, this._arg3, concat(this._more, new object[] { x, y, z }, args))
                    : this._argCount == 3 ? apply(this._func, this._arg1, this._arg2, this._arg3, x, y, z, seq(args))
                    : this._argCount == 2 ? apply(this._func, this._arg1, this._arg2, x, y, z, seq(args))
                    : apply(this._func, this._arg1, x, y, z, seq(args));
        }
    }
}

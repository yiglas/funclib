using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Takes a set of functions and returns a function that is the composition of
    /// those functions. The returned <see cref="Function"/> takes a variable number 
    /// of args, applies the right-most of functions to the args, the next function
    /// (right-to-left) to the result, ect.
    /// </summary>
    public class Comp :
        IFunction<object>,
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunctionParams<object, object, object, object>
    {
        /// <summary>
        /// Takes a set of functions and returns a function that is the composition of
        /// those functions. The returned <see cref="Function"/> takes a variable number 
        /// of args, applies the right-most of functions to the args, the next function
        /// (right-to-left) to the result, ect.
        /// </summary>
        /// <returns>
        /// Returns the <see cref="Identity"/> fucntion;
        /// </returns>
        public object Invoke() => funclib.Core.identity;
        /// <summary>
        /// Takes a set of functions and returns a function that is the composition of
        /// those functions. The returned <see cref="Function"/> takes a variable number 
        /// of args, applies the right-most of functions to the args, the next function
        /// (right-to-left) to the result, ect.
        /// </summary>
        /// <param name="f">Object that implements the <see cref="IFunction{T1, TResult}"/> interface.</param>
        /// <returns>
        /// Returns the passed in function.
        /// </returns>
        public object Invoke(object f) => f;
        /// <summary>
        /// Takes a set of functions and returns a function that is the composition of
        /// those functions. The returned <see cref="Function"/> takes a variable number 
        /// of args, applies the right-most of functions to the args, the next function
        /// (right-to-left) to the result, ect.
        /// </summary>
        /// <param name="f">Object that implements the <see cref="IFunction{T1, TResult}"/> interface.</param>
        /// <param name="g">Object that implements the <see cref="IFunction"/> interface.</param>
        /// <returns>
        /// Returns <see cref="Function"/> with f and g composed together.
        /// </returns>
        public object Invoke(object f, object g) => new Function(f, g);
        /// <summary>
        /// Takes a set of functions and returns a function that is the composition of
        /// those functions. The returned <see cref="Function"/> takes a variable number 
        /// of args, applies the right-most of functions to the args, the next function
        /// (right-to-left) to the result, ect.
        /// </summary>
        /// <param name="f">Object that implements the <see cref="IFunction{T1, TResult}"/> interface.</param>
        /// <param name="g">Object that implements the <see cref="IFunction"/> interface.</param>
        /// <param name="fs">Array of objects that implement the <see cref="IFunction"/> interface.</param>
        /// <returns>
        /// Returns <see cref="Function"/> with f, g and fs composed together.
        /// </returns>
        public object Invoke(object f, object g, params object[] fs) =>
            funclib.Core.Reduce1(this, funclib.Core.ListS(f, g, fs));

        /// <summary>
        /// Internal function that does the <see cref="Comp"/>.
        /// </summary>
        public class Function :
            IFunction<object>,
            IFunction<object, object>,
            IFunction<object, object, object>,
            IFunction<object, object, object, object>,
            IFunctionParams<object, object, object, object, object>
        {
            object _f;
            object _g;

            /// <summary>
            /// Creates a new <see cref="Function"/> object.
            /// </summary>
            /// <param name="f">Object that implements the <see cref="IFunction{T1, TResult}"/> interface.</param>
            /// <param name="g">Object that implements the <see cref="IFunction"/> interface.</param>
            internal Function(object f, object g)
            {
                this._f = f;
                this._g = g;
            }

            /// <summary>
            /// Invoke g, with the output passed to f.
            /// </summary>
            /// <returns>
            /// Returns the results of calling f.
            /// </returns>
            public object Invoke() => funclib.Core.Invoke(this._f, funclib.Core.Invoke(this._g));
            /// <summary>
            /// Invoke g with parameter x, then passing the results to f.
            /// </summary>
            /// <param name="x">Function g's argument.</param>
            /// <returns>
            /// Returns the results of calling f.
            /// </returns>
            public object Invoke(object x) => funclib.Core.Invoke(this._f, funclib.Core.Invoke(this._g, x));
            /// <summary>
            /// <summary>
            /// Invoke g with parameter x and y, then passing the results to f.
            /// </summary>
            /// <param name="x">Function g's funclib.Core.First( argument.</param>
            /// <param name="y">Function g's second argument.</param>
            /// <returns>
            /// Returns the results of calling f.
            /// </returns>
            public object Invoke(object x, object y) => funclib.Core.Invoke(this._f, funclib.Core.Invoke(this._g, x, y));
            /// <summary>
            /// Invoke g with parameter x, y and z, then passing the results to f.
            /// </summary>
            /// <param name="x">Function g's funclib.Core.First( argument.</param>
            /// <param name="y">Function g's second argument.</param>
            /// <param name="z">Function g's third argument.</param>
            /// <returns>
            /// Returns the results of calling f.
            /// </returns>
            public object Invoke(object x, object y, object z) => funclib.Core.Invoke(this._f, funclib.Core.Invoke(this._g, x, y, z));
            /// <summary>
            /// Invoke g with parameter x, y, z and args, then passing the results to f.
            /// </summary>
            /// <param name="x">Function g's funclib.Core.First( argument.</param>
            /// <param name="y">Function g's second argument.</param>
            /// <param name="z">Function g's third argument.</param>
            /// <param name="args">Function g's rest of the arguments.</param>
            /// <returns>
            /// Returns the results of calling f.
            /// </returns>
            public object Invoke(object x, object y, object z, params object[] args) => funclib.Core.Invoke(this._f, funclib.Core.Invoke(this._g, x, y, z, args));
        }
    }
}

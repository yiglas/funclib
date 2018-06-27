using FunctionalLibrary.Collections;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    /// <summary>
    /// Takes a <see cref="IFunction"/> and returns the function that takes the same arguments
    /// with the same effects, if any, and returns the opposite truthy value.
    /// </summary>
    public class Complement :
        IFunction<object, object>
    {
        /// <summary>
        /// Takes a <see cref="IFunction"/> and returns the function that takes the same arguments
        /// with the same effects, if any, and returns the opposite truthy value.
        /// </summary>
        /// <param name="f">Object that implements the <see cref="IFunction"/> interface.</param>
        /// <returns>
        /// Returns a <see cref="bool"/> value which is the opposite truthy value.
        /// </returns>
        public object Invoke(object f) => new Function(f);

        /// <summary>
        /// Internal function that does the <see cref="Complement"/>.
        /// </summary>
        public class Function :
            IFunction<object>,
            IFunction<object, object>,
            IFunction<object, object, object>,
            IFunctionParams<object, object, object, object>
        {
            IFunction _func;

            /// <summary>
            /// Creates a new <see cref="Function"/> object.
            /// </summary>
            /// <param name="f">Object that implements the <see cref="IFunction"/> interface.</param>
            public Function(object f)
            {
                this._func = (IFunction)f;
            }

            /// <summary>
            /// Returns the opposit truthy value when calling the function with no parameters.
            /// </summary>
            /// <returns>
            /// Returns a <see cref="bool"/> that the opposite truthy value when calling the function.
            /// </returns>
            public object Invoke() => new Not().Invoke(((IFunction<object>)this._func).Invoke());
            /// <summary>
            /// Returns the opposit truthy value when calling the function with one parameters.
            /// </summary>
            /// <param name="x">The first parameter in the function.</param>
            /// <returns>
            /// Returns a <see cref="bool"/> that the opposite truthy value when calling the function.
            /// </returns>
            public object Invoke(object x) => new Not().Invoke(Apply.ApplyTo(this._func, (ISeq)new List().Invoke(x)));
            /// <summary>
            /// Returns the opposit truthy value when calling the function with two parameters.
            /// </summary>
            /// <param name="x">The first parameter in the function.</param>
            /// <param name="y">The second parameter in the function.</param>
            /// <returns>
            /// Returns a <see cref="bool"/> that the opposite truthy value when calling the function.
            /// </returns>
            public object Invoke(object x, object y) => new Not().Invoke(Apply.ApplyTo(this._func, (ISeq)new List().Invoke(x, y)));
            /// <summary>
            /// Returns the opposit truthy value when calling the function with more than two parameters.
            /// </summary>
            /// <param name="x">The first parameter in the function.</param>
            /// <param name="y">The second parameter in the function.</param>
            /// <param name="zs">The rest of the parameters in the function.</param>
            /// <returns>
            /// Returns a <see cref="bool"/> that the opposite truthy value when calling the function.
            /// </returns>
            public object Invoke(object x, object y, params object[] zs) => new Not().Invoke(new Apply().Invoke(this._func, x, y, zs));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Components.Core.Generic
{
    /// <summary>
    /// Creates a <see cref="Function{T1, TResult}"/> from a <see cref="Func{T1, TResult}"/>.
    /// </summary>
    /// <typeparam name="T1">Generic type of the input object.</typeparam>
    /// <typeparam name="TResult">Generic type of the return object.</typeparam>
    public class Function<T1, TResult> :
        IFunction<T1, TResult>
    {
        readonly Func<T1, TResult> _func;

        /// <summary>
        /// Creates a <see cref="Function{T1, TResult}"/> from a <see cref="Func{T1, TResult}"/>.
        /// </summary>
        /// <param name="x">A <see cref="Func{T1, TResult}"/> to execute.</param>
        public Function(Func<T1, TResult> x)
        {
            this._func = x;
        }

        /// <summary>
        /// Invokes the <see cref="Func{T1, TResult}"/>.
        /// </summary>
        /// <param name="x">First parameter of the function.</param>
        /// <returns>
        /// Returns the results of the <see cref="Func{T1, TResult}"/> function.
        /// </returns>
        public TResult Invoke(T1 x) => this._func(x);
    }
}

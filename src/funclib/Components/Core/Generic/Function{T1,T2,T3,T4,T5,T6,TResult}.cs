using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Components.Core.Generic
{
    /// <summary>
    /// Creates a <see cref="Function{T1, T2, T3, T4, T5, T6, TResult}"/> from a <see cref="Func{T1, T2, T3, T4, T5, T6, TResult}"/>.
    /// </summary>
    /// <typeparam name="T1">Generic type of the first input object.</typeparam>
    /// <typeparam name="T2">Generic type of the second input object.</typeparam>
    /// <typeparam name="T3">Generic type of the third input object.</typeparam>
    /// <typeparam name="T4">Generic type of the fourth input object.</typeparam>
    /// <typeparam name="T5">Generic type of the fifth input object.</typeparam>
    /// <typeparam name="T6">Generic type of the sixth input object.</typeparam>
    /// <typeparam name="TResult">Generic type of the return object.</typeparam>
    public class Function<T1, T2, T3, T4, T5, T6, TResult> :
        IFunction<T1, T2, T3, T4, T5, T6, TResult>
    {
        readonly Func<T1, T2, T3, T4, T5, T6, TResult> _func;

        /// <summary>
        /// Creates a <see cref="Function{T1, T2, T3, T4, T5, T6, TResult}"/> from a <see cref="Func{T1, T2, T3, T4, T5, T6, TResult}"/>.
        /// </summary>
        /// <param name="x">A <see cref="Func{T1, T2, T3, T4, T5, T6, TResult}"/> to execute.</param>
        public Function(Func<T1, T2, T3, T4, T5, T6, TResult> x)
        {
            this._func = x;
        }

        /// <summary>
        /// Invokes the <see cref="Func{T1, T2, T3, T4, T6, TResult}"/>.
        /// </summary>
        /// <param name="a">First parameter of the function.</param>
        /// <param name="b">Second parameter of the function.</param>
        /// <param name="c">Third parameter of the function.</param>
        /// <param name="d">Fourth parameter of the function.</param>
        /// <param name="e">Fifth parameter of the function.</param>
        /// <param name="f">Sixth parameter of the function.</param>
        /// <returns>
        /// Returns the results of the <see cref="Func{T1, T2, T3, T4, T5, T6, TResult}"/> function.
        /// </returns>
        public TResult Invoke(T1 a, T2 b, T3 c, T4 d, T5 e, T6 f) => this._func(a, b, c, d, e, f);
    }
}

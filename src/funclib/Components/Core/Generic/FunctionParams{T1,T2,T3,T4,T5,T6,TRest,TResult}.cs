using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Components.Core.Generic
{
    /// <summary>
    /// Creates a <see cref="FunctionParams{T1, T2, T3, T4, T5, T6, TRest, TResult}"/> from a <see cref="Func{T1, T2, T3, T4, T5, T6, TRest, TResult}"/>.
    /// </summary>
    /// <typeparam name="T1">First parameter of the function.</typeparam>
    /// <typeparam name="T2">Second parameter of the function.</typeparam>
    /// <typeparam name="T3">Third parameter of the function.</typeparam>
    /// <typeparam name="T4">Forth parameter of the function.</typeparam>
    /// <typeparam name="T5">Fifth parameter of the function.</typeparam>
    /// <typeparam name="T6">Sixth parameter of the function.</typeparam>
    /// <typeparam name="TRest">Generic type of the rest of the parameters.</typeparam>
    /// <typeparam name="TResult">Generic type of the return object.</typeparam>
    public class FunctionParams<T1, T2, T3, T4, T5, T6, TRest, TResult> :
        IFunctionParams<T1, T2, T3, T4, T5, T6, TRest, TResult>
    {
        readonly Func<T1, T2, T3, T4, T5, T6, TRest[], TResult> _func;

        /// <summary>
        /// Creates a <see cref="FunctionParams{T1, T2, T3, T4, T5, T6, TRest, TResult}"/> from a <see cref="Func{T1, T2, T3, T4, T5, T6, TRest, TResult}"/>.
        /// </summary>
        /// <param name="x">A <see cref="Func{T1, T2, T3, T4, T5, T6, TRest, TResult}"/> to execute.</param>
        public FunctionParams(Func<T1, T2, T3, T4, T5, T6, TRest[], TResult> x)
        {
            this._func = x;
        }

        /// <summary>
        /// Invokes the <see cref="Func{T1, T2, T3, T4, T5, T6, TRest, TResult}"/>.
        /// </summary>
        /// <param name="a">First parameter of the function.</param>
        /// <param name="b">Second parameter of the function.</param>
        /// <param name="c">Third parameter of the function.</param>
        /// <param name="d">Fourth parameter of the function.</param>
        /// <param name="e">Fifth parameter of the function.</param>
        /// <param name="f">Sixth parameter of the function.</param>
        /// <param name="args">Array of parameters.</param>
        /// <returns>
        /// Returns the results of the <see cref="Func{T1, T2, T3, T4, T5, T6, TRest, TResult}"/> function.
        /// </returns>
        public TResult Invoke(T1 a, T2 b, T3 c, T4 d, T5 e, T6 f, params TRest[] args) => this._func(a, b, c, d, e, f, args);
    }
}

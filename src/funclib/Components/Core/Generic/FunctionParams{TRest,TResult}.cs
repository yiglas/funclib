using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Components.Core.Generic
{
    /// <summary>
    /// Creates a <see cref="FunctionParams{T1, TResult}"/> from a <see cref="Func{T1[], TResult}"/>.
    /// </summary>
    /// <typeparam name="TRest">Generic type of the parameter array.</typeparam>
    /// <typeparam name="TResult">Generic type of the return object.</typeparam>
    public class FunctionParams<TRest, TResult> :
        IFunctionParams<TRest, TResult>
    {
        readonly Func<TRest[], TResult> _func;

        /// <summary>
        /// Creates a <see cref="FunctionParams{T1, TResult}"/> from a <see cref="Func{T1[], TResult}"/>.
        /// </summary>
        /// <param name="x">A <see cref="Func{T1[], TResult}"/> to execute.</param>
        public FunctionParams(Func<TRest[], TResult> x)
        {
            this._func = x;
        }

        /// <summary>
        /// Invokes the <see cref="Func{T1[], TResult}"/>.
        /// </summary>
        /// <param name="args">Array of parameters of the function.</param>
        /// <returns>
        /// Returns the results of the <see cref="Func{T1[], TResult}"/> function.
        /// </returns>
        public TResult Invoke(params TRest[] args) => this._func(args);
    }
}

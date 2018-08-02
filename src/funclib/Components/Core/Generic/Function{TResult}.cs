using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Components.Core.Generic
{
    /// <summary>
    /// Creates a <see cref="Function{TResult}"/> from a <see cref="Func{TResult}"/>.
    /// </summary>
    /// <typeparam name="TResult">Generic type of the return object.</typeparam>
    public class Function<TResult> :
        IFunction<TResult>
    {
        readonly Func<TResult> _func;

        /// <summary>
        /// Creates a <see cref="Function{TResult}"/> from a <see cref="Func{TResult}"/>.
        /// </summary>
        /// <param name="x">A <see cref="Func{TResult}"/> to execute.</param>
        public Function(Func<TResult> x)
        {
            this._func = x;
        }

        /// <summary>
        /// Invokes the <see cref="Func{TResult}"/>.
        /// </summary>
        /// <returns>
        /// Returns the results of the <see cref="Func{TResult}"/> function.
        /// </returns>
        public TResult Invoke() => this._func();
    }
}

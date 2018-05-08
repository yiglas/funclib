namespace funcx
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class core
    {
        /// <summary>
        /// If test is true, evaluates then with bindings, if not yields else.
        /// </summary>
        /// <typeparam name="T1">Type of the bindings to test.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates.</typeparam>
        /// <param name="bindings">Object to test.</param>
        /// <param name="then">Function to execute if bindings tested true.</param>
        /// <param name="else">Function to execute if bindings tested false.</param>
        /// <returns>
        /// Returns the result of then or else.
        /// </returns>
        public static TResult iflet<T1, TResult>(T1 bindings, Func<T1, TResult> then, Func<TResult> @else = null) =>
            truthy(bindings)
                ? then(bindings)
                : @else == null ? @else() : default;
    }
}

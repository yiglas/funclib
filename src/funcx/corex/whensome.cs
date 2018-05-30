namespace FunctionalLibrary
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class core
    {
        /// <summary>
        /// When test is not null, evaluates body with the input of test.
        /// </summary>
        /// <typeparam name="T">The type of the parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates.</typeparam>
        /// <param name="bindings">The test if not null</param>
        /// <param name="body">The function to execute.</param>
        /// <returns>
        /// Returns the results of the body.
        /// </returns>
        public static TResult whensome<T, TResult>(T bindings, Func<T, TResult> body)
        {
            if (!isnull(bindings))
                return body(bindings);

            return default;
        }
    }
}

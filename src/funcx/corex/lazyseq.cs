namespace FunctionalLibrary
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class core
    {
        // TODO: add more options for the function input.

        /// <summary>
        /// Takes a function that returns a <see cref="IEnumerable{T}"/> or null, and yields
        /// a <see cref="IEnumerable{T}"/> object that will invoke the body only the first time 
        /// seq is called, and will cache the result and return it on all subsequent seq calls.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates.</typeparam>
        /// <param name="fn">Function to yield.</param>
        /// <returns>
        /// Returns a <see cref="IEnumerable{T}"/> results from the function.
        /// </returns>
        public static IEnumerable<TResult> lazyseq<TResult>(Func<IEnumerable<TResult>> fn)
        {
            if (fn == null) yield break;

            IEnumerable<TResult> result = fn();

            while (result != null)
            {
                foreach (var item in result)
                    yield return item;

                result = fn();
            }
        }
    }
}

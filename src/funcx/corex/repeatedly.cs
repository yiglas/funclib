namespace FunctionalLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class core
    {
        /// <summary>
        /// Takes a function of no arguments, presumably with side-effects, and 
        /// returns an infinite lazy sequence of calls to it.
        /// </summary>
        /// <typeparam name="T">The generate return type of the function</typeparam>
        /// <param name="func">A function that presumably has side-effects.</param>
        /// <returns>
        /// Returns a infinite lazy sequence of calls to func.
        /// </returns>
        public static IEnumerable<T> repeatedly<T>(Func<T> func)
        {
            while (true)
            {
                yield return func();
            }
        }

        /// <summary>
        /// Takes a function of no arguments, presumably with side-effects, and 
        /// returns an length of n lazy sequence of calls to it.
        /// </summary>
        /// <typeparam name="T">The generate return type of the function</typeparam>
        /// <param name="n">The number of calls to the function.</param>
        /// <param name="func">A function that presumably has side-effects.</param>
        /// <returns>
        /// Returns a lazy sequence of calls to func of n times.
        /// </returns>
        public static IEnumerable<T> repeatedly<T>(int n, Func<T> func)
        {
            if (n <= 0) yield break;

            for (int i = 0; i < n; i++)
                yield return func();
        }
    }
}

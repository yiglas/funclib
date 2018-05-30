namespace FunctionalLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class core
    {
        /// <summary>
        /// Returns a infinite lazy sequence of x.
        /// </summary>
        /// <typeparam name="T">The generic type of x.</typeparam>
        /// <param name="x">What to repeat.</param>
        /// <returns>
        /// Returns a infinite lazy sequence.
        /// </returns>
        public static IEnumerable<T> repeat<T>(T x)
        {
            while (true)
            {
                yield return x;
            }
        }

        /// <summary>
        /// Returns a lazy sequence with length of n
        /// </summary>
        /// <typeparam name="T">The generic type of x.</typeparam>
        /// <param name="n">The number of items to return.</param>
        /// <param name="x">What to repeat.</param>
        /// <returns>
        /// Returns a lazy sequence of n items.
        /// </returns>
        public static IEnumerable<T> repeat<T>(int n, T x)
        {
            if (n <= 0) yield break;

            for (int i = 0; i < n; i++)
                yield return x;
        }
    }
}

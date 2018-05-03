namespace funcx
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class core
    {
        /// <summary>
        /// Returns a lazy sequence of x, func(x), func(func(x)) etc. func must be free of side-effects.
        /// </summary>
        /// <typeparam name="T">Generic type.</typeparam>
        /// <param name="func">The function to iterate over.</param>
        /// <param name="x">The starting value.</param>
        /// <returns>
        /// Returns a lazy sequence.
        /// </returns>
        public static IEnumerable<T> iterate<T>(Func<T, T> func, T x)
        {
            if (func == null) throw new ArgumentNullException(nameof(func));

            while (true)
            {
                yield return x;
                x = func(x);
            }
        }
    }
}

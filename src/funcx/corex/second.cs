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
        /// Same as first(next(x))
        /// </summary>
        /// <typeparam name="T">Generic type of the collection.</typeparam>
        /// <param name="x">The <see cref="IEnumerable{T}"/>.</param>
        /// <returns>
        /// Returns the second item in the list.
        /// </returns>
        public static T second<T>(IEnumerable<T> x) => first(next(x));

        /// <summary>
        /// Same as first(next(x))
        /// </summary>
        /// <param name="x">The <see cref="IEnumerable"/>.</param>
        /// <returns>
        /// Returns the second item in the list.
        /// </returns>
        public static object second(IEnumerable x) => first(next(x));
    }
}

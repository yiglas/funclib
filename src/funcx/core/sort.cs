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
        /// Sorts the elements of a sequence in ascending order according to a key.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="coll">A sequence of values to order.</param>
        /// <returns>
        /// Returns a <see cref="IList{T}"/> of sorted values.
        /// </returns>
        public static IList<T> sort<T>(IEnumerable<T> coll) => coll.OrderBy(x => x).ToList();

        /// <summary>
        /// Sorts the elements of a sequence in ascending order by using a specified comparer.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="comp">A function that returns true/false depending on the required sort.</param>
        /// <param name="coll">A sequence of values to order.</param>
        /// <returns>
        /// Returns a <see cref="IList{T}"/> of sorted values.
        /// </returns>
        public static IList<T> sort<T>(Func<T, T, int> comp, IEnumerable<T> coll) => coll.OrderBy(x => x, new FunctionComparer<T>(comp)).ToList();
    }
}

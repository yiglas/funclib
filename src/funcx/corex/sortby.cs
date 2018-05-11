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
        /// Returns a sorted sequence of the items in coll, where the sort
        /// order is determined by comparing keyfn(item). If no comparator is
        /// supplied, uses <see cref="compare{T}(T, T)"/>.
        /// </summary>
        /// <typeparam name="T">Type of the list.</typeparam>
        /// <param name="keyfn">Function to compare against.</param>
        /// <param name="coll">The column to sort.</param>
        /// <returns>
        /// Returns a sorted sequence of items.
        /// </returns>
        public static IList<T> sortby<T>(Func<T, int> keyfn, IEnumerable<T> coll) =>
            sortby(keyfn, compare, coll);

        /// <summary>
        /// Returns a sorted sequence of the items in coll, where the sort
        /// order is determined by comparing keyfn(item). If no comparator is
        /// supplied, uses <see cref="compare{T}(T, T)"/>.
        /// </summary>
        /// <typeparam name="T">Type of the list.</typeparam>
        /// <param name="keyfn">Function to compare against.</param>
        /// <param name="comp">Comparator function.</param>
        /// <param name="coll">The column to sort.</param>
        /// <returns>
        /// Returns a sorted sequence of items.
        /// </returns>
        public static IList<T> sortby<T, T2>(Func<T, T2> keyfn, Func<T2, T2, int> comp, IEnumerable<T> coll) =>
            sort((x, y) => comp(keyfn(x), keyfn(y)), coll);
    }
}

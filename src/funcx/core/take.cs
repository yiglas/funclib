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
        /// Returns a lazy sequence of the first n items in the collection, or all items if
        /// there are fewer than n.
        /// </summary>
        /// <typeparam name="T">Generic type of the collection.</typeparam>
        /// <param name="n">The number of items to take.</param>
        /// <param name="coll">The <see cref="IEnumerable{T}"/>.</param>
        /// <returns>
        /// Returns the n items in the collection.
        /// </returns>
        public static IEnumerable<T> take<T>(int n, IEnumerable<T> coll) =>
            n <= 0 || !truthy(coll)
                ? new List<T>()
                : takeInternal(n, coll);

        static IEnumerable<T> takeInternal<T>(int n, IEnumerable<T> coll)
        {
            int i = 0;
            foreach (var item in coll)
                if (++i > n) yield break; else yield return item;
        }

        /// <summary>
        /// Returns a lazy sequence of the first n items in the collection, or all items if
        /// there are fewer than n.
        /// </summary>
        /// <param name="coll">The <see cref="IEnumerable"/>.</param>
        /// <param name="n">The number of items to take.</param>
        /// <returns>
        /// Returns the n items in the collection.
        /// </returns>
        public static IEnumerable take(int n, IEnumerable coll) =>
            n <= 0 || !truthy(coll)
                ? new ArrayList()
                : takeInternal(n, coll);

        static IEnumerable takeInternal(int n, IEnumerable coll)
        {
            int i = 0;
            foreach (var item in coll)
                if (++i > n) yield break; else yield return item;
        }
    }
}

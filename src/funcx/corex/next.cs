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
        /// Returns a sequence of the items after the first. Calls sequence on its
        /// argument. If there are no more items, return null.
        /// </summary>
        /// <typeparam name="T">Generic type of the collection.</typeparam>
        /// <param name="coll">The <see cref="IEnumerable{T}"/>.</param>
        /// <returns>
        ///
        /// </returns>
        public static IEnumerable<T> next<T>(IEnumerable<T> coll) =>
            first(coll) == null
                ? null
                : nextInternal(coll);

        static IEnumerable<T> nextInternal<T>(IEnumerable<T> coll)
        {
            int i = 0;
            foreach (var item in coll)
                if (i++ == 0) continue; else yield return item;
        }

        /// <summary>
        /// Returns a sequence of the items after the first. Calls sequence on its
        /// argument. If there are no more items, return null.
        /// </summary>
        /// <param name="coll">The <see cref="IEnumerable"/>.</param>
        /// <returns>
        ///
        /// </returns>
        public static IEnumerable next(IEnumerable coll) =>
            first(coll) == null
                ? null
                : nextInternal(coll);

        static IEnumerable nextInternal(IEnumerable coll)
        {
            int i = 0;
            foreach (var item in coll)
                if (i++ == 0) continue; else yield return item;
        }
    }
}

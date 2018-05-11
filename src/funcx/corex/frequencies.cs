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
        /// Returns a <see cref="Dictionary{TKey, TValue}"/> from distinct items in coll to the number of times they appear.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="coll">List of items to count</param>
        /// <returns>
        /// Returns a <see cref="Dictionary{TKey, TValue}"/> containing the distinct items and their count.
        /// </returns>
        public static Dictionary<T, int> frequencies<T>(IEnumerable<T> coll) =>
            reduce((counts, x) => assocT(counts, (x, inc(get(counts, x, 0)))) as Dictionary<T, int>, new Dictionary<T, int>(), coll);
    }
}
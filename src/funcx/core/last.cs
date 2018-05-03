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
        /// Returns the last item in the collection, in linear time.
        /// </summary>
        /// <typeparam name="T">Generic type of the collection.</typeparam>
        /// <param name="coll">The <see cref="IEnumerable{T}"/>.</param>
        /// <returns>
        /// Returns the last item in the collection.
        /// </returns>
        public static T last<T>(IEnumerable<T> coll) =>
            coll == null
                ? default(T)
                : coll.Last();

        /// <summary>
        /// Returns the last item in the collection, in linear time.
        /// </summary>
        /// <param name="coll">The <see cref="IEnumerable"/>.</param>
        /// <returns>
        /// Returns the last item in the collection.
        /// </returns>
        public static object last(IEnumerable coll)
        {
            if (coll == null) return null;

            object v = null;
            foreach (var item in coll)
                v = item;

            return v;
        }
    }
}

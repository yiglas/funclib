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
        /// Returns the First item in the collection if object is an IEnumerable.
        /// If source is null or not an IEnumerable, returns null.
        /// </summary>
        /// <typeparam name="T">Generic type of the collection.</typeparam>
        /// <param name="coll">The <see cref="IEnumerable{T}"/>.</param>
        /// <returns>
        /// Either first item in list or null.
        /// </returns>
        public static T first<T>(IEnumerable<T> coll)
        {
            if (coll == null)
                return default(T);

            foreach (var item in coll)
                return item;

            return default(T);
        }

        /// <summary>
        /// Returns the First item in the collection if object is an IEnumerable.
        /// If source is null or not an IEnumerable, returns null.
        /// </summary>
        /// <param name="coll">The <see cref="IEnumerable"/>.</param>
        /// <returns>
        /// Either first item in list or null.
        /// </returns>
        public static object first(IEnumerable coll)
        {
            if (coll == null)
                return null;

            foreach (var item in coll)
                return item;

            return null;
        }
    }
}

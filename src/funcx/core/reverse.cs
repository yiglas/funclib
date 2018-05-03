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
        /// Returns a sequence of the items in the collection in reverse order. Not lazy.
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="coll">The <see cref="IEnumerable{T}"/> object.</param>
        /// <returns>
        /// </returns>
        public static IEnumerable<T> reverse<T>(IEnumerable<T> coll)
        {
            if (coll == null) return Enumerable.Empty<T>();

            return coll.Reverse();
        }
    }
}

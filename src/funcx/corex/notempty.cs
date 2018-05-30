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
        /// If the source is empty return null else return source.
        /// </summary>
        /// <typeparam name="T">The type of objects to enumerate.</typeparam>
        /// <param name="coll">The <see cref="IEnumerable{T}"/> to check if empty or not.</param>
        /// <returns>
        /// Returns the coll if not empty, otherwise null
        /// </returns>
        public static IEnumerable<T> notempty<T>(IEnumerable<T> coll) =>
            falsy(coll)
                ? null
                : coll is ICollection c ? c.Count > 0 ? coll : null
                : coll is string s ? s.Length > 0 ? coll : null
                : coll is IEnumerable ? notEmptyEnumerable(coll)
                : null;

        static IEnumerable<T> notEmptyEnumerable<T>(IEnumerable<T> e)
        {
            foreach (var item in e)
                return e;

            return null;
        }
    }
}

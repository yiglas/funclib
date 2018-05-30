namespace FunctionalLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class core
    {
        /// <summary>
        /// Returns a lazy sequence of the elements of <see cref="IEnumerable{T}"/> separated by the separator.
        /// </summary>
        /// <typeparam name="T">Generic type of the collection.</typeparam>
        /// <typeparam name="TSeparator">Generic type of the separator.</typeparam>
        /// <param name="sep">The separator.</param>
        /// <param name="coll">The <see cref="IEnumerable{T}"/>.</param>
        /// <returns>
        /// Returns a lazy sequence.
        /// </returns>
        public static IEnumerable<object> interpose<T, TSeparator>(TSeparator sep, IEnumerable<T> coll)
        {
            if (coll == null) yield break;

            var e = coll.GetEnumerator();
            if (!e.MoveNext()) yield break;

            do
            {
                yield return e.Current;
                if (!e.MoveNext())
                    yield break;

                yield return sep;
            } while (true);
        }
    }
}

namespace FunctionalLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class core
    {
        /// <summary>
        /// Returns a new <see cref="IEnumerable{T}"/> where x is the first element an the source is the rest.
        /// </summary>
        /// <typeparam name="T">The type of the items.</typeparam>
        /// <param name="x">The value adding to the beginning of the list</param>
        /// <param name="seq">The <see cref="IEnumerable{T}"/> object.</param>
        /// <returns>
        /// Returns a new <see cref="IEnumerable{T}"/>.
        /// </returns>
        public static IEnumerable<T> cons<T>(T x, IEnumerable<T> seq)
        {
            yield return x;

            if (seq != null)
                foreach (var item in seq)
                    yield return item;
        }
    }
}

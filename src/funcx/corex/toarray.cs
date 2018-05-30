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
        /// Returns an array of T containing the contents of coll, which
        /// can be any <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="coll">An <see cref="IEnumerable{T}"/> to create an array from.</param>
        /// <returns>
        /// An array that contains the elements from the input sequence.
        /// </returns>
        public static TSource[] toarray<TSource>(IEnumerable<TSource> coll) => coll.ToArray();
    }
}

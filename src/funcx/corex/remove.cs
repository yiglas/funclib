namespace FunctionalLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class core
    {
        /// <summary>
        /// Returns a lazy sequence of the items in <see cref="IEnumerable{T}"/> for which the
        /// <see cref="Predicate{T}"/> returns false.  <see cref="Predicate{T}"/> must be free of 
        /// side-effects.
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="coll">The <see cref="IEnumerable{T}"/> object.</param>
        /// <param name="pred"></param>
        /// <returns></returns>
        public static IEnumerable<T> remove<T>(Func<T, bool> pred, IEnumerable<T> coll)
        {
            if (coll == null) yield break;

            foreach (var item in coll)
                if (!pred(item)) yield return item;
        }
    }
}

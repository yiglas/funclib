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
        /// Returns a lazy sequence of the items in the collection for 
        /// which <see cref="Predicate{T}"/> returns true. <see cref="Predicate{T}"/> must be free of side-effects.
        /// </summary>
        /// <typeparam name="T">Generic type of the collection.</typeparam>
        /// <param name="pred">A <see cref="Predicate{T}"/> function.</param>
        /// <param name="coll">The <see cref="IEnumerable"/> object.</param>
        /// <returns>
        /// Returns a lazy list.
        /// </returns>
        public static IEnumerable<T> filter<T>(Func<T, bool> pred, IEnumerable<T> coll) =>
            truthy(coll)
                ? coll.Where(pred)
                : null;

        /// <summary>
        /// Returns a lazy sequence of the items in the collection for 
        /// which <see cref="Predicate{T}"/> returns true. <see cref="Predicate{T}"/> must be free of side-effects.
        /// </summary>
        /// <param name="coll">The <see cref="IEnumerable"/> object.</param>
        /// <param name="pred">A <see cref="Predicate{T}"/> function.</param>
        /// <returns>
        /// Returns a lazy list.
        /// </returns>
        public static IEnumerable filter(Func<object, bool> pred, IEnumerable coll) =>
            truthy(coll)
                ? filterInternal(pred, coll)
                : null;

        static IEnumerable filterInternal(Func<object, bool> pred, IEnumerable coll)
        {
            foreach (var item in coll)
                if (pred(item))
                    yield return item;
        }
    }
}

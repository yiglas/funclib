namespace funcx
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class core
    {
        /// <summary>
        /// Disj[oin]. Returns a new set of the same type, that does not contain the key
        /// </summary>
        /// <typeparam name="T">The generic type of the collection.</typeparam>
        /// <param name="coll">The collection being item is being removed from.</param>
        /// <param name="x">the item being removed.</param>
        /// <returns>
        /// Returns a new collection without the item.
        /// </returns>
        public static IList<T> disj<T>(IList<T> coll, T x) => disj(coll, new T[] { x });

        /// <summary>
        /// Disj[oin]. Returns a new set of the same type, that does not contain the keys
        /// </summary>
        /// <typeparam name="T">The generic type of the collection.</typeparam>
        /// <param name="coll">The collection being items is being removed from.</param>
        /// <param name="xs">the items being removed.</param>
        /// <returns>
        /// Returns a new collection without the items.
        /// </returns>
        public static IList<T> disj<T>(IList<T> coll, params T[] xs)
        {
            if (coll == null) return null;
            
            var remove = xs.ToList();

            var items = coll.Where(x => !remove.Contains(x));
            
            var list = Activator.CreateInstance(coll.GetType(), items) as IList<T>;

            return list;
        }
    }
}

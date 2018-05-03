namespace funcx
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class core
    {
        /// <summary>
        /// Conj[oin] the collection with x added.  Position of x being added, depends on the 
        /// concrete implementation.
        /// </summary>
        /// <typeparam name="T">The generic type of the collection.</typeparam>
        /// <param name="coll">The collection being added to.</param>
        /// <param name="x">the first item being added.</param>
        /// <returns>
        /// Returns a new collection with x added to the list.
        /// </returns>
        public static IList<T> conj<T>(IList<T> coll, T x) => conj(coll, new T[] { x });

        /// <summary>
        /// Conj[oin] the collection with xs added.  Position of xs being added, depends on the 
        /// concrete implementation.
        /// </summary>
        /// <typeparam name="T">The generic type of the collection.</typeparam>
        /// <param name="coll">The collection being added to.</param>
        /// <param name="xs">The items being added to the collection.</param>
        /// <returns>
        /// Returns a new collection with xs added to the list.
        /// </returns>
        public static IList<T> conj<T>(IList<T> coll, params T[] xs)
        {
            if (coll == null && !xs.Any()) return new List<T>();

            if (coll == null && xs.Any())
                return new List<T>(xs);
            else
            {
                var items = new T[coll.Count + xs.Count()];
                Array.Copy(coll.ToArray(), 0, items, 0, coll.Count);
                Array.Copy(xs, 0, items, coll.Count, xs.Length);

                var list = Activator.CreateInstance(coll.GetType(), items) as IList<T>;

                return list;
            }
        }
    }
}
